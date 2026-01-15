//using static Vanara.Extensions.BitHelper;

using System.ComponentModel.DataAnnotations;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary/>
	public const uint ACL_REVISION = 2;
	/// <summary/>
	public const uint ACL_REVISION_DS = 4;
	/// <summary/>
	public const string OUT_OF_PROCESS_FUNCTION_TABLE_CALLBACK_EXPORT_NAME = "OutOfProcessFunctionTableCallback";
	/// <summary/>
	public const byte PERFORMANCE_DATA_VERSION = 1;

	/// <summary>Retrieves the function table entries for the functions in the specified region of memory.</summary>
	/// <param name="ControlPc">The control address.</param>
	/// <param name="Context">A pointer to the user-defined data to be passed from the function call.</param>
	/// <returns>Pointer to a <see cref="IMAGE_RUNTIME_FUNCTION_ENTRY"/> structure.</returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("WinNT.h")]
	public delegate IntPtr GetRuntimeFunctionCallback([In] IntPtr ControlPc, [In, Optional] IntPtr Context);

	/// <summary/>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("WinNT.h")]
	public delegate uint OutOfProcessFunctionTableCallback([In] HPROCESS Process, [In] IntPtr TableAddress, out uint Entries,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IMAGE_RUNTIME_FUNCTION_ENTRY[] Functions);

	/// <summary>
	/// <para>The application-defined user-mode scheduling (UMS) scheduler entry point function associated with a UMS completion list.</para>
	/// <para>
	/// The <c>PUMS_SCHEDULER_ENTRY_POINT</c> type defines a pointer to this function. UmsSchedulerProc is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Reason">
	/// <para>The reason the scheduler entry point is being called. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UmsSchedulerStartup 0</term>
	/// <term>
	/// A UMS scheduler thread was created. The entry point is called with this reason once each time EnterUmsSchedulingMode is called.
	/// </term>
	/// </item>
	/// <item>
	/// <term>UmsSchedulerThreadBlocked 1</term>
	/// <term>A UMS worker thread blocked.</term>
	/// </item>
	/// <item>
	/// <term>UmsSchedulerThreadYield 2</term>
	/// <term>An executing UMS worker thread yielded control by calling the UmsThreadYield function.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ActivationPayload">
	/// <para>If the Reason parameter is <c>UmsSchedulerStartup</c>, this parameter is NULL.</para>
	/// <para>
	/// If the Reason parameter is <c>UmsSchedulerThreadBlocked</c>, bit 0 of this parameter indicates the type of activity that was
	/// being serviced when the UMS worker thread blocked.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// The thread blocked on a trap (for example, a hard page fault) or an interrupt (for example, an asynchronous procedure call).
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>The thread blocked on a system call.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the Reason parameter is <c>UmsSchedulerThreadYield</c>, this parameter is a pointer to the UMS thread context of the UMS
	/// worker thread that yielded.
	/// </para>
	/// </param>
	/// <param name="SchedulerParam">
	/// <para>
	/// If the Reason parameter is <c>UmsSchedulerStartup</c>, this parameter is the <c>SchedulerParam</c> member of the
	/// UMS_SCHEDULER_STARTUP_INFO structure passed to the EnterUmsSchedulingMode function that triggered the entry point call.
	/// </para>
	/// <para>
	/// If the Reason parameter is <c>UmsSchedulerThreadYield</c> this parameter is the SchedulerParam parameter passed to the
	/// UmsThreadYield function that triggered the entry point call.
	/// </para>
	/// <para>If the Reason parameter is <c>UmsSchedulerThreadBlocked</c>, this parameter is NULL.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The UmsSchedulerProc function pointer type is defined as <c>PUMS_SCHEDULER_ENTRY_POINT</c> in WinBase.h. The underlying function
	/// type is defined as <c>RTL_UMS_SCHEDULER_ENTRY_POINT</c> in WinNT.h
	/// </para>
	/// <para>
	/// Each UMS scheduler thread has an associated UmsSchedulerProc entry point function that is specified when the thread calls the
	/// EnterUmsSchedulingMode function. The system calls the scheduler entry point function with a reason of <c>UmsSchedulerStartup</c>
	/// when the scheduler thread is converted for UMS.
	/// </para>
	/// <para>
	/// Subsequently, when a UMS worker thread that is running on the scheduler thread yields or blocks, the system calls the scheduler
	/// thread's entry point function with a pointer to the UMS thread context of the worker thread.
	/// </para>
	/// <para>
	/// The application's scheduler is responsible for selecting the next UMS worker thread to run. The scheduler implements all policies
	/// that influence execution of its UMS threads, including processor affinity and thread priority. For example, a scheduler might
	/// give priority to I/O-intensive threads, or it might run threads on a first-come, first-served basis. This logic can be
	/// implemented in the scheduler entry point function or elsewhere in the application.
	/// </para>
	/// <para>
	/// When a blocked UMS worker thread becomes unblocked, the system queues the unblocked thread to the associated completion list and
	/// signals the completion list event. To retrieve UMS worker threads from the completion list, use the DequeueUmsCompletionListItems function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/nc-winnt-rtl_ums_scheduler_entry_point RTL_UMS_SCHEDULER_ENTRY_POINT
	// RtlUmsSchedulerEntryPoint; void RtlUmsSchedulerEntryPoint( RTL_UMS_SCHEDULER_REASON Reason, ULONG_PTR ActivationPayload, PVOID
	// SchedulerParam ) {...}
	[PInvokeData("winnt.h", MSDNShortId = "10de1c48-255d-45c3-acf0-25f8a564b585")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void RtlUmsSchedulerEntryPoint(RTL_UMS_SCHEDULER_REASON Reason, [In] IntPtr ActivationPayload, [In] IntPtr SchedulerParam);

	/// <summary>
	/// <para>
	/// An application-defined function previously registered with the AddSecureMemoryCacheCallback function that is called when a
	/// secured memory range is freed or its protections are changed.
	/// </para>
	/// <para>
	/// The <c>PSECURE_MEMORY_CACHE_CALLBACK</c> type defines a pointer to this callback function. is a placeholder for the
	/// application-defined function name.
	/// </para>
	/// </summary>
	/// <param name="Addr">
	/// <para>The starting address of the memory range.</para>
	/// </param>
	/// <param name="Range">
	/// <para>The size of the memory range, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>The return value indicates the success or failure of this function.</para>
	/// <para>If the caller has secured the specified memory range, this function should unsecure the memory and return <c>TRUE</c>.</para>
	/// <para>If the caller has not secured the specified memory range, this function should return <c>FALSE</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After the callback function is registered, it is called after any attempt to free the specified memory range or change its
	/// protections. If the application has secured any part of the specified memory range, the callback function must invalidate all of
	/// the application's cached memory mappings for the secured memory range, unsecure the secured parts of the memory range, and return
	/// <c>TRUE</c>. Otherwise it must return <c>FALSE</c>.
	/// </para>
	/// <para>
	/// The application secures and unsecures a memory range by sending requests to a device driver, which uses the MmSecureVirtualMemory
	/// and MmUnsecureVirtualMemory functions to actually secure and unsecure the range. Operations on other types of secured or locked
	/// memory do not trigger this callback.
	/// </para>
	/// <para>
	/// Examples of function calls that trigger the callback function include calls to the VirtualFree, VirtualFreeEx, VirtualProtect,
	/// VirtualProtectEx, and UnmapViewOfFile functions.
	/// </para>
	/// <para>
	/// The callback function can also be triggered by a heap operation. In this case, the function must not perform any further
	/// operations on the heap that triggered the callback. This includes calling heap functions on a private heap or the process's
	/// default heap, or calling standard library functions such as <c>malloc</c> and <c>free</c>, which implicitly use the process's
	/// default heap.
	/// </para>
	/// <para>To unregister the callback function, use the RemoveSecureMemoryCacheCallback function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/nc-winnt-psecure_memory_cache_callback BOOLEAN
	// PsecureMemoryCacheCallback( PVOID Addr, SIZE_T Range ) {...}
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("winnt.h", MSDNShortId = "abde4b6f-7cd8-4a4b-9b00-f035b2c29054")]
	[return: MarshalAs(UnmanagedType.U1)]
	public delegate bool SecureMemoryCacheCallback([In] IntPtr Addr, SIZE_T Range);

	/// <summary>A bitmask that specifies the compression format.</summary>
	[PInvokeData("winnt.h")]
	public enum COMPRESSION_FORMAT : ushort
	{
		/// <summary>No compression.</summary>
		COMPRESSION_FORMAT_NONE = 0x0000,

		/// <summary>The system default for compression.</summary>
		COMPRESSION_FORMAT_DEFAULT = 0x0001,

		/// <summary>The LZNT1 compression algorithm is used.</summary>
		COMPRESSION_FORMAT_LZNT1 = 0x0002,

		/// <summary>The Xpress LZ77 compression algorithm is used.</summary>
		COMPRESSION_FORMAT_XPRESS = 0x0003,

		/// <summary>The Xpress LZ77+Huffman compression algorithm is used.</summary>
		COMPRESSION_FORMAT_XPRESS_HUFF = 0x0004,
	}

	/// <summary>The flags that control the enforcement of the minimum and maximum working set sizes.</summary>
	[PInvokeData("winnt.h")]
	[Flags]
	public enum QUOTA_LIMITS_HARDWS
	{
		/// <summary>The working set will not fall below the minimum working set limit.</summary>
		QUOTA_LIMITS_HARDWS_MIN_ENABLE = 0x00000001,

		/// <summary>The working set may fall below the minimum working set limit if memory demands are high.</summary>
		QUOTA_LIMITS_HARDWS_MIN_DISABLE = 0x00000002,

		/// <summary>The working set will not exceed the maximum working set limit.</summary>
		QUOTA_LIMITS_HARDWS_MAX_ENABLE = 0x00000004,

		/// <summary>The working set may exceed the maximum working set limit if there is abundant memory.</summary>
		QUOTA_LIMITS_HARDWS_MAX_DISABLE = 0x00000008,

		/// <summary>The quota limits use default limits</summary>
		QUOTA_LIMITS_USE_DEFAULT_LIMITS = 0x00000010,
	}

	/// <summary>Used by <see cref="RtlUmsSchedulerEntryPoint"/>.</summary>
	[PInvokeData("winnt.h", MSDNShortId = "10de1c48-255d-45c3-acf0-25f8a564b585")]
	public enum RTL_UMS_SCHEDULER_REASON
	{
		/// <summary>
		/// A UMS scheduler thread was created. The entry point is called with this reason once each time EnterUmsSchedulingMode is called.
		/// </summary>
		UmsSchedulerStartup = 0,

		/// <summary>A UMS worker thread blocked.</summary>
		UmsSchedulerThreadBlocked = 1,

		/// <summary>An executing UMS worker thread yielded control by calling the UmsThreadYield function.</summary>
		UmsSchedulerThreadYield = 2,
	}

	/// <summary>
	/// <para>Represents classes of information about user-mode scheduling (UMS) threads.</para>
	/// <para>This enumeration is used by the QueryUmsThreadInformation and SetUmsThreadInformation functions.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ne-winnt-_rtl_ums_thread_info_class typedef enum
	// _RTL_UMS_THREAD_INFO_CLASS { UmsThreadInvalidInfoClass , UmsThreadUserContext , UmsThreadPriority , UmsThreadAffinity ,
	// UmsThreadTeb , UmsThreadIsSuspended , UmsThreadIsTerminated , UmsThreadMaxInfoClass } RTL_UMS_THREAD_INFO_CLASS, *PRTL_UMS_THREAD_INFO_CLASS;
	[PInvokeData("winnt.h", MSDNShortId = "2d6730b2-4d01-45f5-9514-0d91806f50d5")]
	public enum RTL_UMS_THREAD_INFO_CLASS
	{
		/// <summary>Reserved.</summary>
		UmsThreadInvalidInfoClass,

		/// <summary>Application-defined information stored in a UMS thread context.</summary>
		[CorrespondingType(typeof(IntPtr))]
		UmsThreadUserContext,

		/// <summary>Reserved.</summary>
		UmsThreadPriority,

		/// <summary>Reserved.</summary>
		UmsThreadAffinity,

		/// <summary>
		/// The thread execution block (TEB) for a UMS thread. This information class can only be queried; it cannot be set.
		/// </summary>
		[CorrespondingType(typeof(IntPtr), CorrespondingAction.Get)]
		UmsThreadTeb,

		/// <summary>The suspension status of the thread. This information can only be queried; it cannot be set.</summary>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		UmsThreadIsSuspended,

		/// <summary>The termination status of the thread. This information can only be queried; it cannot be set.</summary>
		[CorrespondingType(typeof(BOOL), CorrespondingAction.Get)]
		UmsThreadIsTerminated,

		/// <summary>Reserved.</summary>
		UmsThreadMaxInfoClass,
	}

	/// <summary>Section access rights.</summary>
	[PInvokeData("winnt.h")]
	[Flags]
	public enum SECTION_MAP : uint
	{
		/// <summary>Query the section object for information about the section. Drivers should set this flag.</summary>
		SECTION_QUERY = 0x0001,

		/// <summary>Write views of the section.</summary>
		SECTION_MAP_WRITE = 0x0002,

		/// <summary>Read views of the section.</summary>
		SECTION_MAP_READ = 0x0004,

		/// <summary>Execute views of the section.</summary>
		SECTION_MAP_EXECUTE = 0x0008,

		/// <summary>Dynamically extend the size of the section.</summary>
		SECTION_EXTEND_SIZE = 0x0010,

		/// <summary>Undocumented.</summary>
		SECTION_MAP_EXECUTE_EXPLICIT = 0x0020,

		/// <summary>All of the previous flags combined with STANDARD_RIGHTS_REQUIRED.</summary>
		SECTION_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | SECTION_QUERY | SECTION_MAP_WRITE | SECTION_MAP_READ | SECTION_MAP_EXECUTE | SECTION_EXTEND_SIZE,
	}

	/// <summary>
	/// The operator to be used for the comparison. The VerifyVersionInfo function uses this operator to compare a specified attribute
	/// value to the corresponding value for the currently running system.
	/// </summary>
	public enum VERSION_CONDITION : byte
	{
		/// <summary>The current value must be equal to the specified value.</summary>
		VER_EQUAL = 1,

		/// <summary>The current value must be greater than the specified value.</summary>
		VER_GREATER,

		/// <summary>The current value must be greater than or equal to the specified value.</summary>
		VER_GREATER_EQUAL,

		/// <summary>The current value must be less than the specified value.</summary>
		VER_LESS,

		/// <summary>The current value must be less than or equal to the specified value.</summary>
		VER_LESS_EQUAL,

		/// <summary>All product suites specified in the wSuiteMask member must be present in the current system.</summary>
		VER_AND,

		/// <summary>At least one of the specified product suites must be present in the current system.</summary>
		VER_OR,
	}

	/// <summary>
	/// A mask that indicates the member of the OSVERSIONINFOEX structure whose comparison operator is being set. This value corresponds
	/// to one of the bits specified in the dwTypeMask parameter for the VerifyVersionInfo function.
	/// </summary>
	[Flags]
	public enum VERSION_MASK : uint
	{
		/// <summary>dwMinorVersion</summary>
		VER_MINORVERSION = 0x0000001,

		/// <summary>dwMajorVersion</summary>
		VER_MAJORVERSION = 0x0000002,

		/// <summary>dwBuildNumber</summary>
		VER_BUILDNUMBER = 0x0000004,

		/// <summary>dwPlatformId</summary>
		VER_PLATFORMID = 0x0000008,

		/// <summary>wServicePackMinor</summary>
		VER_SERVICEPACKMINOR = 0x0000010,

		/// <summary>wServicePackMajor</summary>
		VER_SERVICEPACKMAJOR = 0x0000020,

		/// <summary>wSuiteMask</summary>
		VER_SUITENAME = 0x0000040,

		/// <summary>wProductType</summary>
		VER_PRODUCT_TYPE = 0x0000080,
	}

	/// <summary>The <c>RtlCopyMemory</c> routine copies the contents of a source memory block to a destination memory block.</summary>
	/// <param name="Destination">Datatype: void*. A pointer to the destination memory block to copy the bytes to.</param>
	/// <param name="Source">Datatype: const void*. A pointer to the source memory block to copy the bytes from.</param>
	/// <param name="Length">Datatype: size_t. The number of bytes to copy from the source to the destination.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// <c>RtlCopyMemory</c> runs faster than <c>RtlMoveMemory</c>. However, <c>RtlCopyMemory</c> requires that the source memory block,
	/// which is defined by Source and Length, cannot overlap the destination memory block, which is defined by Destination and Length.
	/// In contrast, <c>RtlMoveMemory</c> correctly handles the case in which the source and destination memory blocks overlap.
	/// </para>
	/// <para>New drivers should use the <c>RtlCopyMemory</c> routine instead of <c>RtlCopyBytes</c>.</para>
	/// <para>
	/// Callers of <c>RtlCopyMemory</c> can be running at any IRQL if the source and destination memory blocks are in nonpaged system
	/// memory. Otherwise, the caller must be running at IRQL &lt;= APC_LEVEL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlcopymemory
	// void RtlCopyMemory( Destination, Source, Length );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wdm.h", MSDNShortId = "d204eeb4-e109-4a86-986f-0fccdda3f8f8")]
	public static extern void RtlCopyMemory([Out] IntPtr Destination, [In] IntPtr Source, SIZE_T Length);

	/// <summary>The <c>RtlFillMemory</c> routine fills a block of memory with the specified fill value.</summary>
	/// <param name="Destination">Datatype: void*. A pointer to the block of memory to be filled.</param>
	/// <param name="Length">Datatype: size_t. The number of bytes in the block of memory to be filled.</param>
	/// <param name="Fill">
	/// Datatype: int. The value to fill the destination memory block with. This value is copied to every byte in the memory block that
	///           is defined by Destination and Length.
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// Callers of <c>RtlFillMemory</c> can be running at any IRQL if the destination memory block is in nonpaged system memory.
	/// Otherwise, the caller must be running at IRQL &lt;= APC_LEVEL.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/nf-wdm-rtlfillmemory
	// void RtlFillMemory( Destination, Length, Fill );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wdm.h", MSDNShortId = "9a73331a-cc73-4a47-948b-a821600ca6a6")]
	public static extern void RtlFillMemory([Out] IntPtr Destination, SIZE_T Length, [Range(0, byte.MaxValue)] int Fill);

	/// <summary>
	/// Copies the contents of a source memory block to a destination memory block, and supports overlapping source and destination
	/// memory blocks.
	/// </summary>
	/// <param name="Destination">A pointer to the destination memory block to copy the bytes to.</param>
	/// <param name="Source">A pointer to the source memory block to copy the bytes from.</param>
	/// <param name="Length">The number of bytes to copy from the source to the destination.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// The source memory block, which is defined by Source and Length, can overlap the destination memory block, which is defined by
	/// Destination and Length.
	/// </para>
	/// <para>
	/// The <c>RtlCopyMemory</c> routine runs faster than <c>RtlMoveMemory</c>, but <c>RtlCopyMemory</c> requires that the source and
	/// destination memory blocks do not overlap.
	/// </para>
	/// <para>
	/// Callers of <c>RtlMoveMemory</c> can be running at any IRQL if the source and destination memory blocks are in non-paged system
	/// memory. Otherwise, the caller must be running at IRQL &lt;= APC_LEVEL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/devnotes/rtlmovememory VOID RtlMoveMemory( _Out_ VOID UNALIGNED *Destination, _In_
	// const VOID UNALIGNED *Source, _In_ SIZE_T Length );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winnt.h", MSDNShortId = "D374F14D-24C7-4771-AD40-3AC37E7A2D2F")]
	public static extern void RtlMoveMemory([In] IntPtr Destination, [In] IntPtr Source, [In] SIZE_T Length);

	/// <summary>
	/// The RtlZeroMemory routine fills a block of memory with zeros, given a pointer to the block and the length, in bytes, to be filled.
	/// </summary>
	/// <param name="Destination">A pointer to the memory block to be filled with zeros.</param>
	/// <param name="Length">The number of bytes to fill with zeros.</param>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/wdm/nf-wdm-rtlzeromemory
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winnt.h")]
	public static extern void RtlZeroMemory([In] IntPtr Destination, SIZE_T Length);

	/// <summary>
	/// Contains processor-specific register data. The system uses CONTEXT structures to perform various internal operations. Refer to
	/// the header file WinNT.h for definitions of this structure for each processor architecture.
	/// </summary>
	/// <param name="flags">The context flags.</param>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/ms679284(v=vs.85).aspx
	[StructLayout(LayoutKind.Sequential)]
	public struct CONTEXT(uint flags = 0u)
	{
		/// <summary/>
		public uint ContextFlags = flags;

		/// <summary/>
		public uint Dr0;

		/// <summary/>
		public uint Dr1;

		/// <summary/>
		public uint Dr2;

		/// <summary/>
		public uint Dr3;

		/// <summary/>
		public uint Dr6;

		/// <summary/>
		public uint Dr7;

		// Retrieved by CONTEXT_FLOATING_POINT
		/// <summary/>
		public FLOATING_SAVE_AREA FloatSave;

		// Retrieved by CONTEXT_SEGMENTS
		/// <summary/>
		public uint SegGs;

		/// <summary/>
		public uint SegFs;

		/// <summary/>
		public uint SegEs;

		/// <summary/>
		public uint SegDs;

		// Retrieved by CONTEXT_INTEGER
		/// <summary/>
		public uint Edi;

		/// <summary/>
		public uint Esi;

		/// <summary/>
		public uint Ebx;

		/// <summary/>
		public uint Edx;

		/// <summary/>
		public uint Ecx;

		/// <summary/>
		public uint Eax;

		// Retrieved by CONTEXT_CONTROL
		/// <summary/>
		public uint Ebp;

		/// <summary/>
		public uint Eip;

		/// <summary/>
		public uint SegCs;

		/// <summary/>
		public uint EFlags;

		/// <summary/>
		public uint Esp;

		/// <summary/>
		public uint SegSs;

		// Retrieved by CONTEXT_EXTENDED_REGISTERS
		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public byte[] ExtendedRegisters = new byte[512];

		/// <summary>Represents the 80387 save area on WOW64. Refer to the header file WinNT.h for the definition of this structure.</summary>
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms681671(v=vs.85).aspx
		[PInvokeData("WinNT.h", MSDNShortId = "ms681671")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FLOATING_SAVE_AREA
		{
			/// <summary/>
			public int ControlWord;

			/// <summary/>
			public int StatusWord;

			/// <summary/>
			public int TagWord;

			/// <summary/>
			public int ErrorOffset;

			/// <summary/>
			public int ErrorSelector;

			/// <summary/>
			public int DataOffset;

			/// <summary/>
			public int DataSelector;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
			public byte[] RegisterArea;

			/// <summary/>
			public int Cr0NpxState;
		}
	}

	/// <summary/>
	[StructLayout(LayoutKind.Sequential, Pack = 16)]
	public struct CONTEXT64
	{
		/// <summary/>
		public ulong P1Home;

		/// <summary/>
		public ulong P2Home;

		/// <summary/>
		public ulong P3Home;

		/// <summary/>
		public ulong P4Home;

		/// <summary/>
		public ulong P5Home;

		/// <summary/>
		public ulong P6Home;

		/// <summary/>
		public uint ContextFlags;

		/// <summary/>
		public uint MxCsr;

		/// <summary/>
		public ushort SegCs;

		/// <summary/>
		public ushort SegDs;

		/// <summary/>
		public ushort SegEs;

		/// <summary/>
		public ushort SegFs;

		/// <summary/>
		public ushort SegGs;

		/// <summary/>
		public ushort SegSs;

		/// <summary/>
		public uint EFlags;

		/// <summary/>
		public ulong Dr0;

		/// <summary/>
		public ulong Dr1;

		/// <summary/>
		public ulong Dr2;

		/// <summary/>
		public ulong Dr3;

		/// <summary/>
		public ulong Dr6;

		/// <summary/>
		public ulong Dr7;

		/// <summary/>
		public ulong Rax;

		/// <summary/>
		public ulong Rcx;

		/// <summary/>
		public ulong Rdx;

		/// <summary/>
		public ulong Rbx;

		/// <summary/>
		public ulong Rsp;

		/// <summary/>
		public ulong Rbp;

		/// <summary/>
		public ulong Rsi;

		/// <summary/>
		public ulong Rdi;

		/// <summary/>
		public ulong R8;

		/// <summary/>
		public ulong R9;

		/// <summary/>
		public ulong R10;

		/// <summary/>
		public ulong R11;

		/// <summary/>
		public ulong R12;

		/// <summary/>
		public ulong R13;

		/// <summary/>
		public ulong R14;

		/// <summary/>
		public ulong R15;

		/// <summary/>
		public ulong Rip;

		/// <summary/>
		public XSAVE_FORMAT64 DUMMYUNIONNAME;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 26)]
		public M128A[] VectorRegister;

		/// <summary/>
		public ulong VectorControl;

		/// <summary/>
		public ulong DebugControl;

		/// <summary/>
		public ulong LastBranchToRip;

		/// <summary/>
		public ulong LastBranchFromRip;

		/// <summary/>
		public ulong LastExceptionToRip;

		/// <summary/>
		public ulong LastExceptionFromRip;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct M128A
		{
			/// <summary/>
			public ulong High;

			/// <summary/>
			public long Low;
		}

		/// <summary/>
		[StructLayout(LayoutKind.Sequential, Pack = 16)]
		public struct XSAVE_FORMAT64
		{
			/// <summary/>
			public ushort ControlWord;

			/// <summary/>
			public ushort StatusWord;

			/// <summary/>
			public byte TagWord;

			/// <summary/>
			public byte Reserved1;

			/// <summary/>
			public ushort ErrorOpcode;

			/// <summary/>
			public uint ErrorOffset;

			/// <summary/>
			public ushort ErrorSelector;

			/// <summary/>
			public ushort Reserved2;

			/// <summary/>
			public uint DataOffset;

			/// <summary/>
			public ushort DataSelector;

			/// <summary/>
			public ushort Reserved3;

			/// <summary/>
			public uint MxCsr;

			/// <summary/>
			public uint MxCsr_Mask;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
			public M128A[] FloatRegisters;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
			public M128A[] XmmRegisters;

			/// <summary/>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 96)]
			public byte[] Reserved4;
		}
	}

	/// <summary>Contains the hardware counter value.</summary>
	// typedef struct _HARDWARE_COUNTER_DATA { HARDWARE_COUNTER_TYPE Type; DWORD Reserved; DWORD64 Value;} HARDWARE_COUNTER_DATA,
	// *PHARDWARE_COUNTER_DATA; https://msdn.microsoft.com/en-us/library/windows/desktop/dd796394(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "dd796394")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HARDWARE_COUNTER_DATA
	{
		/// <summary>The type of hardware counter data collected. For possible values, see the <c>HARDWARE_COUNTER_TYPE</c> enumeration.</summary>
		public HARDWARE_COUNTER_TYPE Type;

		/// <summary>Reserved. Initialize to zero.</summary>
		public uint Reserved;

		/// <summary>
		/// The counter index. Each hardware counter in a processor's performance monitoring unit (PMU) is identified by an index.
		/// </summary>
		public ulong Value;
	}

	/// <summary>Represents an entry in the function table on 64-bit Windows.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-runtime_function typedef struct _IMAGE_RUNTIME_FUNCTION_ENTRY {
	// DWORD BeginAddress; DWORD EndAddress; union { DWORD UnwindInfoAddress; DWORD UnwindData; } DUMMYUNIONNAME; } RUNTIME_FUNCTION,
	// *PRUNTIME_FUNCTION, _IMAGE_RUNTIME_FUNCTION_ENTRY, *_PIMAGE_RUNTIME_FUNCTION_ENTRY;
	[PInvokeData("winnt.h", MSDNShortId = "9ed16f9a-3403-4ba9-9968-f51f6788a1f8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_RUNTIME_FUNCTION_ENTRY
	{
		/// <summary>The address of the start of the function.</summary>
		public uint BeginAddress;

		/// <summary>The address of the end of the function.</summary>
		public uint EndAddress;

		/// <summary>The address of the unwind information for the function.</summary>
		public uint UnwindInfoAddress;
	}

	/// <summary>
	/// Contains information about message strings with identifiers in the range indicated by the <c>LowId</c> and <c>HighId</c> members.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-message_resource_block typedef struct _MESSAGE_RESOURCE_BLOCK {
	// DWORD LowId; DWORD HighId; DWORD OffsetToEntries; } MESSAGE_RESOURCE_BLOCK, *PMESSAGE_RESOURCE_BLOCK;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._MESSAGE_RESOURCE_BLOCK")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MESSAGE_RESOURCE_BLOCK
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The lowest message identifier contained within this structure.</para>
		/// </summary>
		public uint LowId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The highest message identifier contained within this structure.</para>
		/// </summary>
		public uint HighId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The offset, in bytes, from the beginning of the MESSAGE_RESOURCE_DATA structure to the MESSAGE_RESOURCE_ENTRY structures in this
		/// <c>MESSAGE_RESOURCE_BLOCK</c>. The <c>MESSAGE_RESOURCE_ENTRY</c> structures contain the message strings.
		/// </para>
		/// </summary>
		public uint OffsetToEntries;
	}

	/// <summary>Contains information about formatted text for display as an error message or in a message box in a message table resource.</summary>
	/// <remarks>
	/// A <c>MESSAGE_RESOURCE_DATA</c> structure can contain one or more MESSAGE_RESOURCE_BLOCK structures, which can each contain one or
	/// more MESSAGE_RESOURCE_ENTRY structures.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-message_resource_data typedef struct _MESSAGE_RESOURCE_DATA { DWORD
	// NumberOfBlocks; MESSAGE_RESOURCE_BLOCK Blocks[1]; } MESSAGE_RESOURCE_DATA, *PMESSAGE_RESOURCE_DATA;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._MESSAGE_RESOURCE_DATA")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<MESSAGE_RESOURCE_DATA>), nameof(NumberOfBlocks))]
	[StructLayout(LayoutKind.Sequential)]
	public struct MESSAGE_RESOURCE_DATA
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of MESSAGE_RESOURCE_BLOCK structures.</para>
		/// </summary>
		public uint NumberOfBlocks;

		/// <summary>
		/// <para>Type: <c>MESSAGE_RESOURCE_BLOCK[1]</c></para>
		/// <para>An array of structures. The array is the size indicated by the <c>NumberOfBlocks</c> member.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public MESSAGE_RESOURCE_BLOCK[] Blocks;
	}

	/// <summary>Contains the error message or message box display text for a message table resource.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-message_resource_entry typedef struct _MESSAGE_RESOURCE_ENTRY {
	// WORD Length; WORD Flags; BYTE Text[1]; } MESSAGE_RESOURCE_ENTRY, *PMESSAGE_RESOURCE_ENTRY;
	[PInvokeData("winnt.h", MSDNShortId = "NS:winnt._MESSAGE_RESOURCE_ENTRY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MESSAGE_RESOURCE_ENTRY
	{
		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The length, in bytes, of the <c>MESSAGE_RESOURCE_ENTRY</c> structure.</para>
		/// </summary>
		public ushort Length;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// Indicates that the string is encoded in Unicode, if equal to the value 0x0001. Indicates that the string is encoded in ANSI, if
		/// equal to the value 0x0000.
		/// </para>
		/// </summary>
		public ushort Flags;

		/// <summary>
		/// <para>Type: <c>BYTE[1]</c></para>
		/// <para>Pointer to an array that contains the error message or message box display text.</para>
		/// </summary>
		public byte Text;

		internal static unsafe string GetText([In] MESSAGE_RESOURCE_ENTRY* mre) => mre->Flags == 0x0001 ? Marshal.PtrToStringUni(((IntPtr)(void*)mre).Offset(TextOffset.Value))! : Marshal.PtrToStringAnsi(((IntPtr)(void*)mre).Offset(TextOffset.Value))!;

		private static Lazy<long> TextOffset => new(() => Marshal.OffsetOf(typeof(MESSAGE_RESOURCE_ENTRY), nameof(Text)).ToInt64());
	}

	/// <summary>Contains the thread profiling and hardware counter data that you requested.</summary>
	// typedef struct _PERFORMANCE_DATA { WORD Size; BYTE Version; BYTE HwCountersCount; DWORD ContextSwitchCount; DWORD64
	// WaitReasonBitMap; DWORD64 CycleTime; DWORD RetryCount; DWORD Reserved; HARDWARE_COUNTER_DATA HwCounters[MAX_HW_COUNTERS];}
	// PERFORMANCE_DATA, *PPERFORMANCE_DATA; https://msdn.microsoft.com/en-us/library/windows/desktop/dd796401(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "dd796401")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct PERFORMANCE_DATA()
	{
		private const int MAX_HW_COUNTERS = 16;

		/// <summary>The size of this structure.</summary>
		public ushort Size = (ushort)Marshal.SizeOf<PERFORMANCE_DATA>();

		/// <summary>The version of this structure. Must be set to PERFORMANCE_DATA_VERSION.</summary>
		public byte Version = PERFORMANCE_DATA_VERSION;

		/// <summary>
		/// The number of array elements in the <c>HwCounters</c> array that contain hardware counter data. A value of 3 means that the
		/// array contains data for three hardware counters, not that elements 0 through 2 contain counter data.
		/// </summary>
		public byte HwCountersCount;

		/// <summary>The number of context switches that occurred from the time profiling was enabled.</summary>
		public uint ContextSwitchCount;

		/// <summary>
		/// A bitmask that identifies the reasons for the context switches that occurred since the last time the data was read. For
		/// possible values, see the <c>KWAIT_REASON</c> enumeration (the enumeration is included in the Wdm.h file in the WDK).
		/// </summary>
		public ulong WaitReasonBitMap;

		/// <summary>The cycle time of the thread (excludes the time spent interrupted) from the time profiling was enabled.</summary>
		public ulong CycleTime;

		/// <summary>The number of times that the read operation read the data to ensure a consistent snapshot of the data.</summary>
		public uint RetryCount;

		/// <summary>Reserved. Set to zero.</summary>
		public uint Reserved;

		/// <summary>
		/// An array of <c>HARDWARE_COUNTER_DATA</c> structures that contain the counter values. The elements of the array that contain
		/// counter data relate directly to the bits set in the HardwareCounters bitmask that you specified when you called the
		/// <c>EnableThreadProfiling</c> function. For example, if you set bit 3 in the HardwareCounters bitmask, HwCounters[3] will
		/// contain the counter data for that counter.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HW_COUNTERS)]
		public HARDWARE_COUNTER_DATA[] HwCounters = new HARDWARE_COUNTER_DATA[MAX_HW_COUNTERS];

		/// <summary>Gets a default instance with the size pre-set.</summary>
		public static readonly PERFORMANCE_DATA Default = new();
	}

	/// <summary>The <c>SECURITY_CAPABILITIES</c> structure defines the security capabilities of the app container.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_security_capabilities typedef struct _SECURITY_CAPABILITIES {
	// #if ... PISID AppContainerSid; #if ... PSID_AND_ATTRIBUTES Capabilities; #else PSID AppContainerSid; #endif #else
	// PSID_AND_ATTRIBUTES Capabilities; #endif DWORD CapabilityCount; DWORD Reserved; } SECURITY_CAPABILITIES, *PSECURITY_CAPABILITIES, *LPSECURITY_CAPABILITIES;
	[PInvokeData("winnt.h", MSDNShortId = "1A865519-E042-4871-886C-9AA64D71CCE4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SECURITY_CAPABILITIES
	{
		/// <summary>The SID of the app container.</summary>
		public PSID AppContainerSid;

		/// <summary>The specific capabilities.</summary>
		public IntPtr Capabilities;

		/// <summary>The number of the capabilities.</summary>
		public uint CapabilityCount;

		/// <summary>This member is reserved. Do not use it.</summary>
		public uint Reserved;
	}

	/// <summary>
	/// <para>Specifies attributes for a user-mode scheduling (UMS) worker thread.</para>
	/// <para>This structure is used with the UpdateProcThreadAttribute function.</para>
	/// </summary>
	/// <remarks>Initializes a new instance of the <see cref="UMS_CREATE_THREAD_ATTRIBUTES"/> struct.</remarks>
	/// <param name="ctx">
	/// A UMS thread context for the worker thread to be created. This pointer is provided by the CreateUmsThreadContext function.
	/// </param>
	/// <param name="completionList">
	/// A UMS completion list. This pointer is provided by the CreateUmsCompletionList function. The newly created worker thread is
	/// queued to the specified completion list.
	/// </param>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-ums_create_thread_attributes typedef struct
	// _UMS_CREATE_THREAD_ATTRIBUTES { DWORD UmsVersion; PVOID UmsContext; PVOID UmsCompletionList; } UMS_CREATE_THREAD_ATTRIBUTES, *PUMS_CREATE_THREAD_ATTRIBUTES;
	[PInvokeData("winnt.h", MSDNShortId = "5d3e1721-c439-49bb-9cb6-8386fa8aaf50")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UMS_CREATE_THREAD_ATTRIBUTES(PUMS_CONTEXT ctx = default, PUMS_COMPLETION_LIST completionList = default)
	{
		/// <summary>The UMS version for which the application was built. This parameter must be <c>UMS_VERSION</c>.</summary>
		public uint UmsVersion = UMS_VERSION;

		/// <summary>
		/// A pointer to a UMS thread context for the worker thread to be created. This pointer is provided by the CreateUmsThreadContext function.
		/// </summary>
		public PUMS_CONTEXT UmsContext = ctx;

		/// <summary>
		/// A pointer to a UMS completion list. This pointer is provided by the CreateUmsCompletionList function. The newly created
		/// worker thread is queued to the specified completion list.
		/// </summary>
		public PUMS_COMPLETION_LIST UmsCompletionList = completionList;
	}

	/// <summary/>
	[PInvokeData("winnt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UNWIND_HISTORY_TABLE
	{
		/// <summary/>
		public uint Count;

		/// <summary/>
		public byte LocalHint;

		/// <summary/>
		public byte GlobalHint;

		/// <summary/>
		public byte Search;

		/// <summary/>
		public byte Once;

		/// <summary/>
		public ulong LowAddress;

		/// <summary/>
		public ulong HighAddress;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
		public UNWIND_HISTORY_TABLE_ENTRY[] Entry;
	}

	/// <summary/>
	[PInvokeData("winnt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct UNWIND_HISTORY_TABLE_ENTRY
	{
		/// <summary/>
		public ulong ImageBase;

		/// <summary/>
		public IMAGE_RUNTIME_FUNCTION_ENTRY FunctionEntry;
	}

	/// <summary>
	/// <para>Represents a context frame on WOW64. Refer to the header file WinNT.h for the definition of this structure.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// In the following versions of Windows, Slot 1 of Thread Local Storage (TLS) holds a pointer to a structure that contains a
	/// <c>WOW64_CONTEXT</c> structure starting at offset 4. This might change in later versions of Windows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Windows Vista</term>
	/// <term>Windows Server 2008</term>
	/// </listheader>
	/// <item>
	/// <term>Windows 7</term>
	/// <term>Windows Server 2008 R2</term>
	/// </item>
	/// <item>
	/// <term>Windows 8</term>
	/// <term>Windows Server 2012</term>
	/// </item>
	/// <item>
	/// <term>Windows 8.1</term>
	/// <term>Windows Server 2012 R2</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_wow64_context
	[PInvokeData("winnt.h", MSDNShortId = "b27205a2-2c33-4f45-8948-9919bcd2355a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WOW64_CONTEXT
	{
		/// <summary/>
		public WOW64_CONTEXT_FLAGS ContextFlags;

		/// <summary/>
		public uint Dr0;

		/// <summary/>
		public uint Dr1;

		/// <summary/>
		public uint Dr2;

		/// <summary/>
		public uint Dr3;

		/// <summary/>
		public uint Dr6;

		/// <summary/>
		public uint Dr7;

		/// <summary/>
		public WOW64_FLOATING_SAVE_AREA FloatSave;

		/// <summary/>
		public uint SegGs;

		/// <summary/>
		public uint SegFs;

		/// <summary/>
		public uint SegEs;

		/// <summary/>
		public uint SegDs;

		/// <summary/>
		public uint Edi;

		/// <summary/>
		public uint Esi;

		/// <summary/>
		public uint Ebx;

		/// <summary/>
		public uint Edx;

		/// <summary/>
		public uint Ecx;

		/// <summary/>
		public uint Eax;

		/// <summary/>
		public uint Ebp;

		/// <summary/>
		public uint Eip;

		/// <summary/>
		public uint SegCs;

		/// <summary/>
		public uint EFlags;

		/// <summary/>
		public uint Esp;

		/// <summary/>
		public uint SegSs;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		public byte[] ExtendedRegisters;
	}

	/// <summary>
	/// <para>Represents the 80387 save area on WOW64. Refer to the header file WinNT.h for the definition of this structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_wow64_floating_save_area
	[PInvokeData("winnt.h", MSDNShortId = "56fba1c1-432b-40a8-b882-e4c637c03d5d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WOW64_FLOATING_SAVE_AREA
	{
		/// <summary/>
		public uint ControlWord;

		/// <summary/>
		public uint StatusWord;

		/// <summary/>
		public uint TagWord;

		/// <summary/>
		public uint ErrorOffset;

		/// <summary/>
		public uint ErrorSelector;

		/// <summary/>
		public uint DataOffset;

		/// <summary/>
		public uint DataSelector;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
		public byte[] RegisterArea;

		/// <summary/>
		public uint Cr0NpxState;
	}

	/// <summary>
	/// <para>
	/// Describes an entry in the descriptor table for a 32-bit thread on a 64-bit system. This structure is valid only on 64-bit systems.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The Wow64GetThreadSelectorEntry function fills this structure with information from an entry in the descriptor table. You can use
	/// this information to convert a segment-relative address to a linear virtual address.
	/// </para>
	/// <para>
	/// The base address of a segment is the address of offset 0 in the segment. To calculate this value, combine the <c>BaseLow</c>,
	/// <c>BaseMid</c>, and <c>BaseHi</c> members.
	/// </para>
	/// <para>
	/// The limit of a segment is the address of the last byte that can be addressed in the segment. To calculate this value, combine the
	/// <c>LimitLow</c> and <c>LimitHi</c> members.
	/// </para>
	/// <para>
	/// The <c>WOW64_LDT_ENTRY</c> structure has the same layout for a 64-bit process as the LDT_ENTRY structure has for a 32-bit process.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_wow64_ldt_entry typedef struct _WOW64_LDT_ENTRY { WORD
	// LimitLow; WORD BaseLow; union { struct { BYTE BaseMid; BYTE Flags1; BYTE Flags2; BYTE BaseHi; } Bytes; struct { DWORD BaseMid : 8;
	// DWORD Type : 5; DWORD Dpl : 2; DWORD Pres : 1; DWORD LimitHi : 4; DWORD Sys : 1; DWORD Reserved_0 : 1; DWORD Default_Big : 1;
	// DWORD Granularity : 1; DWORD BaseHi : 8; } Bits; } HighWord; } WOW64_LDT_ENTRY, *PWOW64_LDT_ENTRY;
	[PInvokeData("winnt.h", MSDNShortId = "a571cd2f-0873-4ad5-bcb8-c0da2d47a820")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct WOW64_LDT_ENTRY
	{
		/// <summary>
		/// <para>The low-order part of the address of the last byte in the segment.</para>
		/// </summary>
		public ushort LimitLow;

		/// <summary>
		/// <para>The low-order part of the base address of the segment.</para>
		/// </summary>
		public ushort BaseLow;

		/// <summary>
		/// <para>Middle bits (16-23) of the base address of the segment.</para>
		/// </summary>
		public byte BaseMid;

		private BitField<ushort> Flags;

		/// <summary>
		/// <para>The high bits (24-31) of the base address of the segment.</para>
		/// </summary>
		public byte BaseHi;

		/// <summary>
		/// <para>The type of segment. This member can be one of the following values:</para>
		/// </summary>
		public byte Type { get => (byte)Flags[0..4]; set => Flags[0..4] = value; }

		/// <summary>
		/// <para>
		/// The privilege level of the descriptor. This member is an integer value in the range 0 (most privileged) through 3 (least privileged).
		/// </para>
		/// </summary>
		public byte Dpl { get => (byte)Flags[5..6]; set => Flags[5..6] = value; }

		/// <summary>
		/// <para>The present flag. This member is 1 if the segment is present in physical memory or 0 if it is not.</para>
		/// </summary>
		public bool Pres { get => Flags[7]; set => Flags[7] = value; }

		/// <summary>
		/// <para>The high bits (16â€“19) of the address of the last byte in the segment.</para>
		/// </summary>
		public byte LimitHi { get => (byte)Flags[8..11]; set => Flags[8..11] = value; }

		/// <summary>
		/// <para>
		/// The space that is available to system programmers. This member might be used for marking segments in some system-specific way.
		/// </para>
		/// </summary>
		public bool Sys { get => Flags[12]; set => Flags[12] = value; }

		/// <summary>
		/// <para>Reserved.</para>
		/// </summary>
		public bool Reserved_0 { get => Flags[13]; set => Flags[13] = value; }

		/// <summary>
		/// <para>
		/// The size of segment. If the segment is a data segment, this member contains 1 if the segment is larger than 64 kilobytes (KB)
		/// or 0 if the segment is smaller than or equal to 64 KB.
		/// </para>
		/// <para>
		/// If the segment is a code segment, this member contains 1. The segment runs with the default (native mode) instruction set.
		/// </para>
		/// </summary>
		public bool Default_Big { get => Flags[14]; set => Flags[14] = value; }

		/// <summary>
		/// <para>The granularity. This member contains 0 if the segment is byte granular, 1 if the segment is page granular.</para>
		/// </summary>
		public bool Granularity { get => Flags[15]; set => Flags[15] = value; }
	}

	/// <summary>Used by thread context functions.</summary>
	[PInvokeData("winnt.h")]
	public static class CONTEXT_FLAG
	{
		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_AMD64 = 0x00100000;

		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_ARM = 0x00200000;

		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_EXCEPTION_ACTIVE = 0x08000000;

		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_EXCEPTION_REPORTING = 0x80000000;

		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_EXCEPTION_REQUEST = 0x40000000;

		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_i386 = 0x00010000;

		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_KERNEL_DEBUGGER = 0x04000000;

		/// <summary>Undocumented.</summary>
		public const uint CONTEXT_SERVICE_ACTIVE = 0x10000000;

		private static readonly uint systemContext;

		static CONTEXT_FLAG()
		{
			GetNativeSystemInfo(out var info);
			systemContext = info.wProcessorArchitecture switch
			{
				ProcessorArchitecture.PROCESSOR_ARCHITECTURE_INTEL => CONTEXT_i386,
				ProcessorArchitecture.PROCESSOR_ARCHITECTURE_ARM => CONTEXT_ARM,
				ProcessorArchitecture.PROCESSOR_ARCHITECTURE_AMD64 => CONTEXT_AMD64,
				_ => throw new InvalidOperationException("Processor context not recognized."),
			};
		}

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_ALL => CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_SEGMENTS | CONTEXT_FLOATING_POINT | CONTEXT_DEBUG_REGISTERS;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_CONTROL => systemContext | 0x00000001;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_DEBUG_REGISTERS => systemContext | 0x00000010;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_EXTENDED_REGISTERS => systemContext | 0x00000020;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_FLOATING_POINT => systemContext | 0x00000008;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_FULL => CONTEXT_CONTROL | CONTEXT_INTEGER | CONTEXT_FLOATING_POINT;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_INTEGER => systemContext | 0x00000002;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_SEGMENTS => systemContext | 0x00000004;

		/// <summary>Undocumented.</summary>
		public static uint CONTEXT_XSTATE => systemContext | 0x00000040;
	}

	/// <summary>
	/// Contains processor-specific register data. The system uses <c>CONTEXT</c> structures to perform various internal operations.
	/// Refer to the header file WinNT.h for definitions of this structure for each processor architecture.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-_arm64_nt_context typedef struct _ARM64_NT_CONTEXT { DWORD
	// ContextFlags; DWORD Cpsr; union { struct { DWORD64 X0; DWORD64 X1; DWORD64 X2; DWORD64 X3; DWORD64 X4; DWORD64 X5; DWORD64 X6;
	// DWORD64 X7; DWORD64 X8; DWORD64 X9; DWORD64 X10; DWORD64 X11; DWORD64 X12; DWORD64 X13; DWORD64 X14; DWORD64 X15; DWORD64 X16;
	// DWORD64 X17; DWORD64 X18; DWORD64 X19; DWORD64 X20; DWORD64 X21; DWORD64 X22; DWORD64 X23; DWORD64 X24; DWORD64 X25; DWORD64 X26;
	// DWORD64 X27; DWORD64 X28; DWORD64 Fp; DWORD64 Lr; } DUMMYSTRUCTNAME; DWORD64 X[31]; } DUMMYUNIONNAME; DWORD64 Sp; DWORD64 Pc;
	// ARM64_NT_NEON128 V[32]; DWORD Fpcr; DWORD Fpsr; DWORD Bcr[ARM64_MAX_BREAKPOINTS]; DWORD64 Bvr[ARM64_MAX_BREAKPOINTS]; DWORD
	// Wcr[ARM64_MAX_WATCHPOINTS]; DWORD64 Wvr[ARM64_MAX_WATCHPOINTS]; } ARM64_NT_CONTEXT, *PARM64_NT_CONTEXT;
	[PInvokeData("winnt.h", MSDNShortId = "a6c201b3-4402-4de4-89c7-e6e2fbcd27f7")]
	public partial class SafeCONTEXT : SafeHANDLE
	{
		private readonly SafeHGlobalHandle buffer;

		/// <summary>Initializes a new instance of the <see cref="SafeCONTEXT"/> class.</summary>
		/// <param name="contextFlags">The context flags from values in the <see cref="CONTEXT_FLAG"/> class.</param>
		public SafeCONTEXT(uint contextFlags) : base(IntPtr.Zero, true)
		{
			uint len = 0;
			InitializeContext(IntPtr.Zero, contextFlags, out _, ref len);
			buffer = new SafeHGlobalHandle((int)len);
			if (!InitializeContext(buffer.DangerousGetHandle(), contextFlags, out var ptr, ref len))
				Win32Error.ThrowLastError();
			SetHandle(ptr);
		}

		/// <inheritdoc/>
		public override bool IsInvalid => handle == IntPtr.Zero;

		/// <summary>Creates a new instance by copying from a <c>CONTEXT</c> structure.</summary>
		/// <typeparam name="TContext">The type of the context to copy from.</typeparam>
		/// <param name="context">The context value.</param>
		/// <param name="contextFlags">The context flags.</param>
		/// <returns>A new instance.</returns>
		public static SafeCONTEXT FromContextStruct<TContext>(in TContext context, uint contextFlags) where TContext : struct
		{
			var output = new SafeCONTEXT(contextFlags);
			var pCtx = new PinnedObject(context);
			if (!CopyContext(output, contextFlags, pCtx))
				Win32Error.ThrowLastError();
			return output;
		}

		/// <summary>Clones this instance.</summary>
		/// <param name="contextFlags">The context flags.</param>
		/// <returns>A full copy of this instance.</returns>
		public SafeCONTEXT Clone(uint contextFlags)
		{
			var output = new SafeCONTEXT(contextFlags);
			if (!CopyContext(output, contextFlags, handle))
				Win32Error.ThrowLastError();
			return output;
		}

		/// <summary>Converts to a <c>CONTEXT</c> structure.</summary>
		/// <typeparam name="TContext">The type of the context structure to which to convert.</typeparam>
		/// <returns>The context structure.</returns>
		public TContext ToContextStruct<TContext>() where TContext : struct =>
			handle.ToStructure<TContext>(buffer.Size - handle.ToInt32() + buffer.DangerousGetHandle().ToInt32());

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle()
		{
			buffer.Dispose();
			SetHandle(IntPtr.Zero);
			return true;
		}
	}
}