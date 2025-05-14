using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary/>
	public const int HEAP_MAXIMUM_TAG = 0x0FFF;

	/// <summary/>
	public const int HEAP_TAG_SHIFT = 18;

	/// <summary>The current version to be used by <see cref="HEAP_OPTIMIZE_RESOURCES_INFORMATION.Version"/></summary>
	public const uint HEAP_OPTIMIZE_RESOURCES_CURRENT_VERSION = 1;

	/// <summary>Specifies the class of heap information to be set or retrieved.</summary>
	// typedef enum _HEAP_INFORMATION_CLASS { HeapCompatibilityInformation = 0, HeapEnableTerminationOnCorruption = 1}
	// HEAP_INFORMATION_CLASS; https://msdn.microsoft.com/en-us/library/windows/desktop/dn280633(v=vs.85).aspx
	[PInvokeData("WinNT.h", MSDNShortId = "dn280633")]
	public enum HEAP_INFORMATION_CLASS
	{
		/// <summary>
		/// <para>
		/// The heap features that are enabled. The available features vary based on operating system. Depending on the HeapInformation
		/// parameter in the <c>HeapQueryInformation</c> or <c>HeapSetInformation</c> functions, specifying this enumeration value can
		/// indicate one of the following features:
		/// </para>
		/// <para>For more information about look-aside lists, see the Remarks section.</para>
		/// </summary>
		[CorrespondingType(typeof(HeapCompatibility), CorrespondingAction.GetSet)]
		HeapCompatibilityInformation = 0,

		/// <summary>
		/// <para>
		/// The terminate-on-corruption feature. If the heap manager detects an error in any heap used by the process, it calls the
		/// Windows Error Reporting service and terminates the process.
		/// </para>
		/// <para>After a process enables this feature, it cannot be disabled.</para>
		/// </summary>
		HeapEnableTerminationOnCorruption = 1,

		/// <summary>
		/// If HeapSetInformation is called with HeapHandle set to NULL, then all heaps in the process with a low-fragmentation heap
		/// (LFH) will have their caches optimized, and the memory will be decommitted if possible.
		/// <para>If a heap pointer is supplied in HeapHandle, then only that heap will be optimized.</para>
		/// <para>Note that the HEAP_OPTIMIZE_RESOURCES_INFORMATION structure passed in HeapInformation must be properly initialized.</para>
		/// <para>Note This value was added in Windows 8.1.</para>
		/// </summary>
		[CorrespondingType(typeof(HEAP_OPTIMIZE_RESOURCES_INFORMATION), CorrespondingAction.Set)]
		HeapOptimizeResources = 3
	}

	/// <summary>Values for Query/SetHeapInformation. Use with HeapCompatibilityInformation.</summary>
	public enum HeapCompatibility : uint
	{
		/// <summary>A standard heap.</summary>
		HEAP_STANDARD = 0,

		/// <summary>The heap supports look-aside lists.</summary>
		HEAP_LAL = 1,

		/// <summary>A low-fragmentation heap.</summary>
		HEAP_LFH = 2
	}

	/// <summary>Flags for Heap functions.</summary>
	[PInvokeData("HeapApi.h")]
	[Flags]
	public enum HeapFlags
	{
		/// <summary>
		/// Serialized access will not be used for this allocation. For more information, see Remarks.
		/// <para>
		/// To ensure that serialized access is disabled for all calls to this function, specify HEAP_NO_SERIALIZE in the call to
		/// HeapCreate. In this case, it is not necessary to additionally specify HEAP_NO_SERIALIZE in this function call.
		/// </para>
		/// <para>
		/// This value should not be specified when accessing the process's default heap. The system may create additional threads within
		/// the application's process, such as a CTRL+C handler, that simultaneously access the process's default heap.
		/// </para>
		/// </summary>
		HEAP_NO_SERIALIZE = 0x00000001,

		/// <summary>Specifies that the heap is growable. Must be specified if HeapBase is NULL.</summary>
		HEAP_GROWABLE = 0x00000002,

		/// <summary>
		/// The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
		/// <para>
		/// To ensure that exceptions are generated for all calls to this function, specify HEAP_GENERATE_EXCEPTIONS in the call to
		/// HeapCreate. In this case, it is not necessary to additionally specify HEAP_GENERATE_EXCEPTIONS in this function call.
		/// </para>
		/// </summary>
		HEAP_GENERATE_EXCEPTIONS = 0x00000004,

		/// <summary>The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.</summary>
		HEAP_ZERO_MEMORY = 0x00000008,

		/// <summary>
		/// There can be no movement when reallocating a memory block. If this value is not specified, the function may move the block to
		/// a new location. If this value is specified and the block cannot be resized without moving, the function fails, leaving the
		/// original memory block unchanged.
		/// </summary>
		HEAP_REALLOC_IN_PLACE_ONLY = 0x00000010,

		/// <summary/>
		HEAP_TAIL_CHECKING_ENABLED = 0x00000020,

		/// <summary/>
		HEAP_FREE_CHECKING_ENABLED = 0x00000040,

		/// <summary/>
		HEAP_DISABLE_COALESCE_ON_FREE = 0x00000080,

		/// <summary/>
		HEAP_CREATE_SEGMENT_HEAP = 0x00000100,

		/// <summary/>
		HEAP_CREATE_HARDENED = 0x00000200,

		/// <summary/>
		HEAP_PSEUDO_TAG_FLAG = 0x8000,

		/// <summary/>
		HEAP_CREATE_ALIGN_16 = 0x00010000,

		/// <summary/>
		HEAP_CREATE_ENABLE_TRACING = 0x00020000,

		/// <summary>
		/// All memory blocks that are allocated from this heap allow code execution, if the hardware enforces data execution prevention.
		/// Use this flag heap in applications that run code from the heap. If HEAP_CREATE_ENABLE_EXECUTE is not specified and an
		/// application attempts to run code from a protected page, the application receives an exception with the status code STATUS_ACCESS_VIOLATION.
		/// </summary>
		HEAP_CREATE_ENABLE_EXECUTE = 0x00040000,
	}

	/// <summary>The properties of the heap element.</summary>
	[Flags]
	public enum PROCESS_HEAP : ushort
	{
		/// <summary>
		/// The heap element is located at the beginning of a region of contiguous virtual memory in use by the heap.The lpData member of
		/// the structure points to the first virtual address used by the region; the cbData member specifies the total size, in bytes,
		/// of the address space that is reserved for this region; and the cbOverhead member specifies the size, in bytes, of the heap
		/// control structures that describe the region.The Region structure becomes valid. The dwCommittedSize, dwUnCommittedSize,
		/// lpFirstBlock, and lpLastBlock members of the structure contain additional information about the region.
		/// </summary>
		PROCESS_HEAP_REGION = 1,

		/// <summary>
		/// The heap element is located in a range of uncommitted memory within the heap region.The lpData member points to the beginning
		/// of the range of uncommitted memory; the cbData member specifies the size, in bytes, of the range of uncommitted memory; and
		/// the cbOverhead member specifies the size, in bytes, of the control structures that describe this uncommitted range.
		/// </summary>
		PROCESS_HEAP_UNCOMMITTED_RANGE = 2,

		/// <summary>
		/// The heap element is an allocated block.If PROCESS_HEAP_ENTRY_MOVEABLE is also specified, the Block structure becomes valid.
		/// The hMem member of the Block structure contains a handle to the allocated, moveable memory block.
		/// </summary>
		PROCESS_HEAP_ENTRY_BUSY = 4,

		/// <summary>
		/// This value must be used with PROCESS_HEAP_ENTRY_BUSY, indicating that the heap element is an allocated block.The block was
		/// allocated with LMEM_MOVEABLE or GMEM_MOVEABLE, and the Block structure becomes valid. The hMem member of the Block structure
		/// contains a handle to the allocated, moveable memory block.
		/// </summary>
		PROCESS_HEAP_ENTRY_MOVEABLE = 16,

		/// <summary>This value must be used with PROCESS_HEAP_ENTRY_BUSY, indicating that the heap element is an allocated block.</summary>
		PROCESS_HEAP_ENTRY_DDESHARE = 32,
	}

	/// <summary>
	/// Retrieves a handle to the default heap of the calling process. This handle can then be used in subsequent calls to the heap functions.
	/// </summary>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the calling process's heap.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetProcessHeap</c> function obtains a handle to the default heap for the calling process. A process can use this handle to
	/// allocate memory from the process heap without having to first create a private heap using the HeapCreate function.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> To enable the low-fragmentation heap for the default heap of the process, call the
	/// HeapSetInformation function with the handle returned by <c>GetProcessHeap</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see Getting Process Heaps.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/heapapi/nf-heapapi-getprocessheap HANDLE GetProcessHeap( );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("heapapi.h", MSDNShortId = "ecd716b2-df48-4914-9de4-47d8ad8ff9a2")]
	public static extern HHEAP GetProcessHeap();

	/// <summary>Returns the number of active heaps and retrieves handles to all of the active heaps for the calling process.</summary>
	/// <param name="NumberOfHeaps">The maximum number of heap handles that can be stored into the buffer pointed to by ProcessHeaps.</param>
	/// <param name="ProcessHeaps">A pointer to a buffer that receives an array of heap handles.</param>
	/// <returns>
	/// <para>The return value is the number of handles to heaps that are active for the calling process.</para>
	/// <para>
	/// If the return value is less than or equal to NumberOfHeaps, the function has stored that number of heap handles in the buffer
	/// pointed to by ProcessHeaps.
	/// </para>
	/// <para>
	/// If the return value is greater than NumberOfHeaps, the buffer pointed to by ProcessHeaps is too small to hold all the heap
	/// handles for the calling process, and the function stores NumberOfHeaps handles in the buffer. Use the return value to allocate a
	/// buffer that is large enough to receive all of the handles, and call the function again.
	/// </para>
	/// <para>
	/// If the return value is zero, the function has failed because every process has at least one active heap, the default heap for the
	/// process. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// DWORD WINAPI GetProcessHeaps( _In_ DWORD NumberOfHeaps, _Out_ PHANDLE ProcessHeaps); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366571(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366571")]
	public static extern uint GetProcessHeaps([Optional] uint NumberOfHeaps, [Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] HHEAP[]? ProcessHeaps);

	/// <summary>Returns handles to all of the active heaps for the calling process.</summary>
	/// <returns>An array of heap handles.</returns>
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366571")]
	public static HHEAP[] GetProcessHeaps()
	{
		var c = GetProcessHeaps(0, null);
		var ret = new HHEAP[c];
		if (GetProcessHeaps(c, ret) == 0)
			Win32Error.ThrowLastError();
		return ret;
	}

	/// <summary>Allocates a block of memory from a heap. The allocated memory is not movable.</summary>
	/// <param name="hHeap">
	/// A handle to the heap from which the memory will be allocated. This handle is returned by the HeapCreate or GetProcessHeap function.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The heap allocation options. Specifying any of these values will override the corresponding value specified when the heap was
	/// created with HeapCreate. This parameter can be one or more of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HEAP_GENERATE_EXCEPTIONS 0x00000004</term>
	/// <term>
	/// The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
	/// To ensure that exceptions are generated for all calls to this function, specify HEAP_GENERATE_EXCEPTIONS in the call to
	/// HeapCreate. In this case, it is not necessary to additionally specify HEAP_GENERATE_EXCEPTIONS in this function call.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HEAP_NO_SERIALIZE 0x00000001</term>
	/// <term>
	/// Serialized access will not be used for this allocation. For more information, see Remarks. To ensure that serialized access is
	/// disabled for all calls to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate. In this case, it is not necessary
	/// to additionally specify HEAP_NO_SERIALIZE in this function call. This value should not be specified when accessing the process's
	/// default heap. The system may create additional threads within the application's process, such as a CTRL+C handler, that
	/// simultaneously access the process's default heap.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HEAP_ZERO_MEMORY 0x00000008</term>
	/// <term>The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwBytes">
	/// <para>The number of bytes to be allocated.</para>
	/// <para>
	/// If the heap specified by the hHeap parameter is a "non-growable" heap, dwBytes must be less than 0x7FFF8. You create a
	/// non-growable heap by calling the HeapCreate function with a nonzero value.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the allocated memory block.</para>
	/// <para>If the function fails and you have not specified <c>HEAP_GENERATE_EXCEPTIONS</c>, the return value is <c>NULL</c>.</para>
	/// <para>
	/// If the function fails and you have specified <c>HEAP_GENERATE_EXCEPTIONS</c>, the function may generate either of the exceptions
	/// listed in the following table. The particular exception depends upon the nature of the heap corruption. For more information, see GetExceptionCode.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Exception code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>The allocation attempt failed because of a lack of available memory or heap corruption.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_ACCESS_VIOLATION</term>
	/// <term>The allocation attempt failed because of heap corruption or improper function parameters.</term>
	/// </item>
	/// </list>
	/// <para>If the function fails, it does not call SetLastError. An application cannot call GetLastError for extended error information.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the <c>HeapAlloc</c> function succeeds, it allocates at least the amount of memory requested.</para>
	/// <para>
	/// To allocate memory from the process's default heap, use <c>HeapAlloc</c> with the handle returned by the GetProcessHeap function.
	/// </para>
	/// <para>To free a block of memory allocated by <c>HeapAlloc</c>, use the HeapFree function.</para>
	/// <para>
	/// Memory allocated by <c>HeapAlloc</c> is not movable. The address returned by <c>HeapAlloc</c> is valid until the memory block is
	/// freed or reallocated; the memory block does not need to be locked. Because the system cannot compact a private heap, it can
	/// become fragmented.
	/// </para>
	/// <para>
	/// Applications that allocate large amounts of memory in various allocation sizes can use the low-fragmentation heap to reduce heap fragmentation.
	/// </para>
	/// <para>
	/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
	/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
	/// from the same heap. Setting the <c>HEAP_NO_SERIALIZE</c> value eliminates mutual exclusion on the heap. Without serialization,
	/// two or more threads that use the same heap handle might attempt to allocate or free memory simultaneously, likely causing
	/// corruption in the heap. The <c>HEAP_NO_SERIALIZE</c> value can, therefore, be safely used only in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The process has only one thread.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, but only one thread calls the heap functions for a specific heap.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>For an example, see AWE Example.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/heapapi/nf-heapapi-heapalloc DECLSPEC_ALLOCATOR LPVOID HeapAlloc( HANDLE
	// hHeap, DWORD dwFlags, SIZE_T dwBytes );
	[PInvokeData("heapapi.h", MSDNShortId = "9a176312-0312-4cc1-baf5-949b346d983e")]
	public static SafeHeapBlock HeapAlloc(HHEAP hHeap, HeapFlags dwFlags, SizeT dwBytes) => new(hHeap, dwBytes, dwFlags);

	/// <summary>
	/// Returns the size of the largest committed free block in the specified heap. If the Disable heap coalesce on free global flag is
	/// set, this function also coalesces adjacent free blocks of memory in the heap.
	/// </summary>
	/// <param name="hHeap">A handle to the heap. This handle is returned by either the HeapCreate or GetProcessHeap function.</param>
	/// <param name="dwFlags">
	/// <para>The heap access options. This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HEAP_NO_SERIALIZE 0x00000001</term>
	/// <term>
	/// Serialized access will not be used. For more information, see Remarks. To ensure that serialized access is disabled for all calls
	/// to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate. In this case, it is not necessary to additionally specify
	/// HEAP_NO_SERIALIZE in this function call. Do not specify this value when accessing the process heap. The system may create
	/// additional threads within the application's process, such as a CTRL+C handler, that simultaneously access the process heap.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the size of the largest committed free block in the heap, in bytes.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>
	/// In the unlikely case that there is absolutely no space available in the heap, the function return value is zero, and GetLastError
	/// returns the value NO_ERROR.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>HeapCompact</c> function is primarily useful for debugging. Ordinarily, the system compacts the heap whenever the HeapFree
	/// function is called, and the <c>HeapCompact</c> function returns the size of the largest free block in the heap but does not
	/// compact the heap any further. If the Disable heap coalesce on free global flag is set during debugging, the system does not
	/// compact the heap and calling the <c>HeapCompact</c> function does compact the heap. For more information about global flags, see
	/// the GFlags documentation.
	/// </para>
	/// <para>
	/// There is no guarantee that an application can successfully allocate a memory block of the size returned by <c>HeapCompact</c>.
	/// Other threads or the commit threshold might prevent such an allocation.
	/// </para>
	/// <para>
	/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
	/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
	/// from the same heap. Setting the <c>HEAP_NO_SERIALIZE</c> value eliminates mutual exclusion on the heap. Without serialization,
	/// two or more threads that use the same heap handle might attempt to allocate or free memory simultaneously, likely causing
	/// corruption in the heap. The <c>HEAP_NO_SERIALIZE</c> value can, therefore, be safely used only in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The process has only one thread.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, but only one thread calls the heap functions for a specific heap.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/heapapi/nf-heapapi-heapcompact SIZE_T HeapCompact( HANDLE hHeap, DWORD
	// dwFlags );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("heapapi.h", MSDNShortId = "792ec16f-d6b0-4afd-a832-29fe12b25058")]
	public static extern SizeT HeapCompact([In] HHEAP hHeap, HeapFlags dwFlags);

	/// <summary>
	/// Creates a private heap object that can be used by the calling process. The function reserves space in the virtual address space
	/// of the process and allocates physical storage for a specified initial portion of this block.
	/// </summary>
	/// <param name="flOptions">
	/// The heap allocation options. These options affect subsequent access to the new heap through calls to the heap functions. This
	/// parameter can be 0 or one or more of the following values: HEAP_CREATE_ENABLE_EXECUTE, HEAP_GENERATE_EXCEPTIONS, HEAP_NO_SERIALIZE.
	/// </param>
	/// <param name="dwInitialSize">
	/// The initial size of the heap, in bytes. This value determines the initial amount of memory that is committed for the heap. The
	/// value is rounded up to a multiple of the system page size. The value must be smaller than dwMaximumSize.
	/// <para>
	/// If this parameter is 0, the function commits one page. To determine the size of a page on the host computer, use the
	/// GetSystemInfo function.
	/// </para>
	/// </param>
	/// <param name="dwMaximumSize">
	/// The maximum size of the heap, in bytes. The HeapCreate function rounds dwMaximumSize up to a multiple of the system page size and
	/// then reserves a block of that size in the process's virtual address space for the heap. If allocation requests made by the
	/// HeapAlloc or HeapReAlloc functions exceed the size specified by dwInitialSize, the system commits additional pages of memory for
	/// the heap, up to the heap's maximum size.
	/// <para>
	/// If dwMaximumSize is not zero, the heap size is fixed and cannot grow beyond the maximum size. Also, the largest memory block that
	/// can be allocated from the heap is slightly less than 512 KB for a 32-bit process and slightly less than 1,024 KB for a 64-bit
	/// process. Requests to allocate larger blocks fail, even if the maximum size of the heap is large enough to contain the block.
	/// </para>
	/// <para>
	/// If dwMaximumSize is 0, the heap can grow in size. The heap's size is limited only by the available memory. Requests to allocate
	/// memory blocks larger than the limit for a fixed-size heap do not automatically fail; instead, the system calls the VirtualAlloc
	/// function to obtain the memory that is needed for large blocks. Applications that need to allocate large memory blocks should set
	/// dwMaximumSize to 0.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is a handle to the newly created heap. If the function fails, the return value is
	/// NULL. To get extended error information, call GetLastError.
	/// </returns>
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366599")]
	[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
	public static extern SafeHHEAP HeapCreate(HeapFlags flOptions, SizeT dwInitialSize = default, SizeT dwMaximumSize = default);

	/// <summary>
	/// Destroys the specified heap object. It decommits and releases all the pages of a private heap object, and it invalidates the
	/// handle to the heap.
	/// </summary>
	/// <param name="hHeap">
	/// A handle to the heap to be destroyed. This handle is returned by the HeapCreate function. Do not use the handle to the process
	/// heap returned by the GetProcessHeap function.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
	/// information, call GetLastError.
	/// </returns>
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366700")]
	[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapDestroy(HHEAP hHeap);

	/// <summary>Frees a memory block allocated from a heap by the HeapAlloc or HeapReAlloc function.</summary>
	/// <param name="hHeap">
	/// A handle to the heap whose memory block is to be freed. This handle is returned by either the HeapCreate or GetProcessHeap function.
	/// </param>
	/// <param name="dwFlags">
	/// The heap free options. Specifying the following value overrides the corresponding value specified in the flOptions parameter when
	/// the heap was created by using the HeapCreate function: HEAP_NO_SERIALIZE
	/// </param>
	/// <param name="lpMem">
	/// A pointer to the memory block to be freed. This pointer is returned by the HeapAlloc or HeapReAlloc function. If this pointer is
	/// NULL, the behavior is undefined.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.An application can call
	/// GetLastError for extended error information.
	/// </returns>
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366701")]
	[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapFree(HHEAP hHeap, HeapFlags dwFlags, IntPtr lpMem);

	/// <summary>Attempts to acquire the critical section object, or lock, that is associated with a specified heap.</summary>
	/// <param name="hHeap">A handle to the heap to be locked. This handle is returned by either the HeapCreate or GetProcessHeap function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the function succeeds, the calling thread owns the heap lock. Only the calling thread will be able to allocate or release
	/// memory from the heap. The execution of any other thread of the calling process will be blocked if that thread attempts to
	/// allocate or release memory from the heap. Such threads will remain blocked until the thread that owns the heap lock calls the
	/// HeapUnlock function.
	/// </para>
	/// <para>
	/// The <c>HeapLock</c> function is primarily useful for preventing the allocation and release of heap memory by other threads while
	/// the calling thread uses the HeapWalk function.
	/// </para>
	/// <para>If the <c>HeapLock</c> function is called on a heap created with the HEAP_NO_SERIALIZATION flag, the results are undefined.</para>
	/// <para>
	/// Each successful call to <c>HeapLock</c> must be matched by a corresponding call to HeapUnlock. Failure to call <c>HeapUnlock</c>
	/// will block the execution of any other threads of the calling process that attempt to access the heap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/heapapi/nf-heapapi-heaplock BOOL HeapLock( HANDLE hHeap );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("heapapi.h", MSDNShortId = "bc01b82d-ef10-40d7-af82-e599ba825944")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapLock([In] HHEAP hHeap);

	/// <summary>Retrieves information about the specified heap.</summary>
	/// <param name="HeapHandle">
	/// A handle to the heap whose information is to be retrieved. This handle is returned by either the HeapCreate or GetProcessHeap function.
	/// </param>
	/// <param name="HeapInformationClass">
	/// <para>
	/// The class of information to be retrieved. This parameter can be the following value from the <c>HEAP_INFORMATION_CLASS</c>
	/// enumeration type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HeapCompatibilityInformation 0</term>
	/// <term>
	/// Indicates the heap features that are enabled. The HeapInformation parameter is a pointer to a ULONG variable. If HeapInformation
	/// is 0, the heap is a standard heap that does not support look-aside lists. If HeapInformation is 1, the heap supports look-aside
	/// lists. For more information, see Remarks. If HeapInformation is 2, the low-fragmentation heap (LFH) has been enabled for the
	/// heap. Enabling the LFH disables look-aside lists.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="HeapInformation">
	/// A pointer to a buffer that receives the heap information. The format of this data depends on the value of the
	/// HeapInformationClass parameter.
	/// </param>
	/// <param name="HeapInformationLength">The size of the heap information being queried, in bytes.</param>
	/// <param name="ReturnLength">
	/// <para>
	/// A pointer to a variable that receives the length of data written to the HeapInformation buffer. If the buffer is too small, the
	/// function fails and ReturnLength specifies the minimum size required for the buffer.
	/// </para>
	/// <para>If you do not want to receive this information, specify <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To enable the LFH or the terminate-on-corruption feature, use the HeapSetInformation function.</para>
	/// <para>
	/// <c>Windows XP and Windows Server 2003:</c> A look-aside list is a fast memory allocation mechanism that contains only fixed-sized
	/// blocks. Look-aside lists are enabled by default for heaps that support them. Starting with Windows Vista, look-aside lists are
	/// not used and the LFH is enabled by default.
	/// </para>
	/// <para>
	/// Look-aside lists are faster than general pool allocations that vary in size, because the system does not search for free memory
	/// that fits the allocation. In addition, access to look-aside lists is generally synchronized using fast atomic processor exchange
	/// instructions instead of mutexes or spinlocks. Look-aside lists can be created by the system or drivers. They can be allocated
	/// from paged or nonpaged pool.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following example uses GetProcessHeap to obtain a handle to the default process heap and <c>HeapQueryInformation</c> to
	/// retrieve information about the heap.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/heapapi/nf-heapapi-heapqueryinformation BOOL HeapQueryInformation( HANDLE
	// HeapHandle, HEAP_INFORMATION_CLASS HeapInformationClass, PVOID HeapInformation, SIZE_T HeapInformationLength, PSIZE_T ReturnLength );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("heapapi.h", MSDNShortId = "6bf6cb8b-7212-4ddb-9ea6-34bc78824a8f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapQueryInformation([In] HHEAP HeapHandle, HEAP_INFORMATION_CLASS HeapInformationClass, IntPtr HeapInformation, SizeT HeapInformationLength, out SizeT ReturnLength);

	/// <summary>Retrieves information about the specified heap.</summary>
	/// <param name="HeapHandle">
	/// A handle to the heap whose information is to be retrieved. This handle is returned by either the <c>HeapCreate</c> or
	/// <c>GetProcessHeap</c> function.
	/// </param>
	/// <param name="HeapInformationClass">
	/// <para>
	/// The class of information to be retrieved. This parameter can be the following value from the <c>HEAP_INFORMATION_CLASS</c>
	/// enumeration type.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HeapCompatibilityInformation0</term>
	/// <term>
	/// Indicates the heap features that are enabled. The HeapInformation parameter is a pointer to a ULONG variable.If HeapInformation
	/// is 0, the heap is a standard heap that does not support look-aside lists.If HeapInformation is 1, the heap supports look-aside
	/// lists. For more information, see Remarks.If HeapInformation is 2, the low-fragmentation heap (LFH) has been enabled for the heap.
	/// Enabling the LFH disables look-aside lists.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>The heap information. The format of this data depends on the value of the HeapInformationClass parameter.</returns>
	public static T HeapQueryInformation<T>(HHEAP HeapHandle, HEAP_INFORMATION_CLASS HeapInformationClass) where T : unmanaged
	{
		if (!CorrespondingTypeAttribute.CanGet(HeapInformationClass, typeof(T))) throw new InvalidOperationException("Type mismatch");
		using var mem = SafeHGlobalHandle.CreateFromStructure<T>();
		if (!HeapQueryInformation(HeapHandle, HeapInformationClass, (IntPtr)mem, mem.Size, out _))
			Win32Error.ThrowLastError();
		return mem.ToStructure<T>();
	}

	/// <summary>
	/// Reallocates a block of memory from a heap. This function enables you to resize a memory block and change other memory block
	/// properties. The allocated memory is not movable.
	/// </summary>
	/// <param name="hHeap">
	/// A handle to the heap from which the memory is to be reallocated. This handle is a returned by either the <c>HeapCreate</c> or
	/// <c>GetProcessHeap</c> function.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The heap reallocation options. Specifying a value overrides the corresponding value specified in the flOptions parameter when the
	/// heap was created by using the <c>HeapCreate</c> function. This parameter can be one or more of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HEAP_GENERATE_EXCEPTIONS0x00000004</term>
	/// <term>
	/// The operating-system raises an exception to indicate a function failure, such as an out-of-memory condition, instead of returning
	/// NULL.To ensure that exceptions are generated for all calls to this function, specify HEAP_GENERATE_EXCEPTIONS in the call to
	/// HeapCreate. In this case, it is not necessary to additionally specify HEAP_GENERATE_EXCEPTIONS in this function call.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HEAP_NO_SERIALIZE0x00000001</term>
	/// <term>
	/// Serialized access will not be used. For more information, see Remarks.To ensure that serialized access is disabled for all calls
	/// to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate. In this case, it is not necessary to additionally specify
	/// HEAP_NO_SERIALIZE in this function call.This value should not be specified when accessing the process heap. The system may create
	/// additional threads within the application's process, such as a CTRL+C handler, that simultaneously access the process heap.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HEAP_REALLOC_IN_PLACE_ONLY0x00000010</term>
	/// <term>
	/// There can be no movement when reallocating a memory block. If this value is not specified, the function may move the block to a
	/// new location. If this value is specified and the block cannot be resized without moving, the function fails, leaving the original
	/// memory block unchanged.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HEAP_ZERO_MEMORY0x00000008</term>
	/// <term>
	/// If the reallocation request is for a larger size, the additional region of memory beyond the original size be initialized to
	/// zero. The contents of the memory block up to its original size are unaffected.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpMem">
	/// A pointer to the block of memory that the function reallocates. This pointer is returned by an earlier call to the
	/// <c>HeapAlloc</c> or <c>HeapReAlloc</c> function.
	/// </param>
	/// <param name="dwBytes">
	/// <para>The new size of the memory block, in bytes. A memory block's size can be increased or decreased by using this function.</para>
	/// <para>
	/// If the heap specified by the hHeap parameter is a "non-growable" heap, dwBytes must be less than 0x7FFF8. You create a
	/// non-growable heap by calling the <c>HeapCreate</c> function with a nonzero value.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the reallocated memory block.</para>
	/// <para>If the function fails and you have not specified <c>HEAP_GENERATE_EXCEPTIONS</c>, the return value is <c>NULL</c>.</para>
	/// <para>
	/// If the function fails and you have specified <c>HEAP_GENERATE_EXCEPTIONS</c>, the function may generate either of the exceptions
	/// listed in the following table. For more information, see <c>GetExceptionCode</c>.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Exception code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_NO_MEMORY</term>
	/// <term>The allocation attempt failed because of a lack of available memory or heap corruption.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_ACCESS_VIOLATION</term>
	/// <term>The allocation attempt failed because of heap corruption or improper function parameters.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>
	/// If the function fails, it does not call <c>SetLastError</c>. An application cannot call <c>GetLastError</c> for extended error information.
	/// </para>
	/// </returns>
	// LPVOID WINAPI HeapReAlloc( _In_ HANDLE hHeap, _In_ DWORD dwFlags, _In_ LPVOID lpMem, _In_ SIZE_T dwBytes);// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366704(v=vs.85).aspx
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366704")]
	public static SafeHeapBlock HeapReAlloc(HHEAP hHeap, HeapFlags dwFlags, SafeHeapBlock lpMem, SizeT dwBytes)
	{
		var ptr = HeapReAllocInternal(hHeap, dwFlags, lpMem.DangerousGetHandle(), dwBytes);
		if (ptr == IntPtr.Zero) Win32Error.ThrowLastError();
		lpMem.SetHandleAsInvalid();
		return new SafeHeapBlock(hHeap, ptr, dwBytes);
	}

	/// <summary>Enables features for a specified heap.</summary>
	/// <param name="HeapHandle">
	/// A handle to the heap where information is to be set. This handle is returned by either the HeapCreate or GetProcessHeap function.
	/// </param>
	/// <param name="HeapInformationClass">
	/// <para>
	/// The class of information to be set. This parameter can be one of the following values from the <c>HEAP_INFORMATION_CLASS</c>
	/// enumeration type.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HeapCompatibilityInformation 0</term>
	/// <term>
	/// Enables heap features. Only the low-fragmentation heap (LFH) is supported. However, it is not necessary for applications to
	/// enable the LFH because the system uses the LFH as needed to service memory allocation requests. Windows XP and Windows Server
	/// 2003: The LFH is not enabled by default. To enable the LFH for the specified heap, set the variable pointed to by the
	/// HeapInformation parameter to 2. After the LFH is enabled for a heap, it cannot be disabled. The LFH cannot be enabled for heaps
	/// created with HEAP_NO_SERIALIZE or for heaps created with a fixed size. The LFH also cannot be enabled if you are using the heap
	/// debugging tools in Debugging Tools for Windows or Microsoft Application Verifier. When a process is run under any debugger,
	/// certain heap debug options are automatically enabled for all heaps in the process. These heap debug options prevent the use of
	/// the LFH. To enable the low-fragmentation heap when running under a debugger, set the _NO_DEBUG_HEAP environment variable to 1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HeapEnableTerminationOnCorruption 1</term>
	/// <term>
	/// Enables the terminate-on-corruption feature. If the heap manager detects an error in any heap used by the process, it calls the
	/// Windows Error Reporting service and terminates the process. After a process enables this feature, it cannot be disabled. Windows
	/// Server 2003 and Windows XP: This value is not supported until Windows Vista and Windows XP with SP3. The function succeeds but
	/// the HeapEnableTerminationOnCorruption value is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HeapOptimizeResources 3</term>
	/// <term>
	/// If HeapSetInformation is called with HeapHandle set to NULL, then all heaps in the process with a low-fragmentation heap (LFH)
	/// will have their caches optimized, and the memory will be decommitted if possible. If a heap pointer is supplied in HeapHandle,
	/// then only that heap will be optimized. Note that the HEAP_OPTIMIZE_RESOURCES_INFORMATION structure passed in HeapInformation must
	/// be properly initialized. Note This value was added in Windows 8.1.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="HeapInformation">
	/// <para>The heap information buffer. The format of this data depends on the value of the HeapInformationClass parameter.</para>
	/// <para>
	/// If the HeapInformationClass parameter is <c>HeapCompatibilityInformation</c>, the HeapInformation parameter is a pointer to a
	/// <c>ULONG</c> variable.
	/// </para>
	/// <para>
	/// If the HeapInformationClass parameter is <c>HeapEnableTerminationOnCorruption</c>, the HeapInformation parameter should be
	/// <c>NULL</c> and HeapInformationLength should be 0
	/// </para>
	/// </param>
	/// <param name="HeapInformationLength">The size of the HeapInformation buffer, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To retrieve the current settings for the heap, use the HeapQueryInformation function.</para>
	/// <para>
	/// Setting the <c>HeapEnableTerminateOnCorruption</c> option is strongly recommended because it reduces an application's exposure to
	/// security exploits that take advantage of a corrupted heap.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following example shows you how to enable the low-fragmentation heap.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/heapapi/nf-heapapi-heapsetinformation BOOL HeapSetInformation( HANDLE
	// HeapHandle, HEAP_INFORMATION_CLASS HeapInformationClass, PVOID HeapInformation, SIZE_T HeapInformationLength );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("heapapi.h", MSDNShortId = "33c262ca-5093-4f44-a8c6-09045bc90f60")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapSetInformation([In] HHEAP HeapHandle, HEAP_INFORMATION_CLASS HeapInformationClass, [In] IntPtr HeapInformation, SizeT HeapInformationLength);

	/// <summary>Enables features for a specified heap.</summary>
	/// <param name="HeapHandle">
	/// A handle to the heap where information is to be set. This handle is returned by either the <c>HeapCreate</c> or
	/// <c>GetProcessHeap</c> function.
	/// </param>
	/// <param name="HeapInformationClass">
	/// <para>
	/// The class of information to be set. This parameter can be one of the following values from the <c>HEAP_INFORMATION_CLASS</c>
	/// enumeration type.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HeapCompatibilityInformation0</term>
	/// <term>
	/// Enables heap features. Only the low-fragmentation heap (LFH) is supported. However, it is not necessary for applications to
	/// enable the LFH because the system uses the LFH as needed to service memory allocation requests. Windows XP and Windows Server
	/// 2003: The LFH is not enabled by default. To enable the LFH for the specified heap, set the variable pointed to by the
	/// HeapInformation parameter to 2. After the LFH is enabled for a heap, it cannot be disabled.The LFH cannot be enabled for heaps
	/// created with HEAP_NO_SERIALIZE or for heaps created with a fixed size. The LFH also cannot be enabled if you are using the heap
	/// debugging tools in Debugging Tools for Windows or Microsoft Application Verifier.When a process is run under any debugger,
	/// certain heap debug options are automatically enabled for all heaps in the process. These heap debug options prevent the use of
	/// the LFH. To enable the low-fragmentation heap when running under a debugger, set the _NO_DEBUG_HEAP environment variable to 1.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HeapEnableTerminationOnCorruption1</term>
	/// <term>
	/// Enables the terminate-on-corruption feature. If the heap manager detects an error in any heap used by the process, it calls the
	/// Windows Error Reporting service and terminates the process.After a process enables this feature, it cannot be disabled.Windows
	/// Server 2003 and Windows XP: This value is not supported until Windows Vista and Windows XP with SP3. The function succeeds but
	/// the HeapEnableTerminationOnCorruption value is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>HeapOptimizeResources3</term>
	/// <term>
	/// If HeapSetInformation is called with HeapHandle set to NULL, then all heaps in the process with a low-fragmentation heap (LFH)
	/// will have their caches optimized, and the memory will be decommitted if possible. If a heap pointer is supplied in HeapHandle,
	/// then only that heap will be optimized.Note that the HEAP_OPTIMIZE_RESOURCES_INFORMATION structure passed in HeapInformation must
	/// be properly initialized.Note This value was added in Windows 8.1.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="HeapInformation">
	/// <para>The heap information buffer. The format of this data depends on the value of the HeapInformationClass parameter.</para>
	/// <para>
	/// If the HeapInformationClass parameter is <c>HeapCompatibilityInformation</c>, the HeapInformation parameter is a pointer to a
	/// <c>ULONG</c> variable.
	/// </para>
	/// <para>
	/// If the HeapInformationClass parameter is <c>HeapEnableTerminationOnCorruption</c>, the HeapInformation parameter should be
	/// <c>NULL</c> and HeapInformationLength should be 0
	/// </para>
	/// </param>
	public static void HeapSetInformation<T>([In] HHEAP HeapHandle, HEAP_INFORMATION_CLASS HeapInformationClass, in T HeapInformation) where T : unmanaged
	{
		if (!CorrespondingTypeAttribute.CanSet(HeapInformationClass, typeof(T))) throw new InvalidOperationException("Type mismatch");
		using var mem = SafeHGlobalHandle.CreateFromStructure(HeapInformation);
		if (!HeapSetInformation(HeapHandle, HeapInformationClass, mem, mem.Size))
			Win32Error.ThrowLastError();
	}

	/// <summary>Retrieves the size of a memory block allocated from a heap by the HeapAlloc or HeapReAlloc function.</summary>
	/// <param name="hHeap">
	/// A handle to the heap in which the memory block resides. This handle is returned by either the HeapCreate or GetProcessHeap function.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// The heap size options. Specifying the following value overrides the corresponding value specified in the flOptions parameter when
	/// the heap was created by using the HeapCreate function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HEAP_NO_SERIALIZE 0x00000001</term>
	/// <term>
	/// Serialized access will not be used. For more information, see Remarks. To ensure that serialized access is disabled for all calls
	/// to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate. In this case, it is not necessary to additionally specify
	/// HEAP_NO_SERIALIZE in this function call. This value should not be specified when accessing the process heap. The system may
	/// create additional threads within the application's process, such as a CTRL+C handler, that simultaneously access the process heap.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpMem">
	/// A pointer to the memory block whose size the function will obtain. This is a pointer returned by the HeapAlloc or HeapReAlloc
	/// function. The memory block must be from the heap specified by the hHeap parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the requested size of the allocated memory block, in bytes.</para>
	/// <para>
	/// If the function fails, the return value is . The function does not call SetLastError. An application cannot call GetLastError for
	/// extended error information.
	/// </para>
	/// <para>
	/// If the lpMem parameter refers to a heap allocation that is not in the heap specified by the hHeap parameter, the behavior of the
	/// <c>HeapSize</c> function is undefined.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
	/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
	/// from the same heap. Setting the <c>HEAP_NO_SERIALIZE</c> value eliminates mutual exclusion on the heap. Without serialization,
	/// two or more threads that use the same heap handle might attempt to allocate or free memory simultaneously, likely causing
	/// corruption in the heap. The <c>HEAP_NO_SERIALIZE</c> value can, therefore, be safely used only in the following situations:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The process has only one thread.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, but only one thread calls the heap functions for a specific heap.</term>
	/// </item>
	/// <item>
	/// <term>The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/heapapi/nf-heapapi-heapsize SIZE_T HeapSize( HANDLE hHeap, DWORD dwFlags,
	// LPCVOID lpMem );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("heapapi.h", MSDNShortId = "a8fcfd99-7b04-4aa3-8619-272b254551a3")]
	public static extern SizeT HeapSize(HHEAP hHeap, HeapFlags dwFlags, SafeHeapBlock lpMem);

	/// <summary>Undocumented.</summary>
	/// <param name="hHeap">
	/// A handle to the heap in which the memory block resides. This handle is returned by either the HeapCreate or GetProcessHeap function.
	/// </param>
	/// <param name="dwFlags">The heap summary options.</param>
	/// <param name="lpSummary">A <c>HEAP_SUMMARY</c> structure. Must be initialized with size.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("HeapApi.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapSummary([In] HHEAP hHeap, uint dwFlags, ref HEAP_SUMMARY lpSummary);

	/// <summary>
	/// Releases ownership of the critical section object, or lock, that is associated with a specified heap. It reverses the action of
	/// the <c>HeapLock</c> function.
	/// </summary>
	/// <param name="hHeap">
	/// A handle to the heap to be unlocked. This handle is returned by either the <c>HeapCreate</c> or <c>GetProcessHeap</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI HeapUnlock( _In_ HANDLE hHeap);// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366707(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366707")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapUnlock([In] HHEAP hHeap);

	/// <summary>
	/// Validates the specified heap. The function scans all the memory blocks in the heap and verifies that the heap control structures
	/// maintained by the heap manager are in a consistent state. You can also use the <c>HeapValidate</c> function to validate a single
	/// memory block within a specified heap without checking the validity of the entire heap.
	/// </summary>
	/// <param name="hHeap">
	/// A handle to the heap to be validated. This handle is returned by either the <c>HeapCreate</c> or <c>GetProcessHeap</c> function.
	/// </param>
	/// <param name="dwFlags">
	/// <para>The heap access options. This parameter can be the following value.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HEAP_NO_SERIALIZE0x00000001</term>
	/// <term>
	/// Serialized access will not be used. For more information, see Remarks.To ensure that serialized access is disabled for all calls
	/// to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate. In this case, it is not necessary to additionally specify
	/// HEAP_NO_SERIALIZE in this function call.This value should not be specified when accessing the process default heap. The system
	/// may create additional threads within the application's process, such as a CTRL+C handler, that simultaneously access the process
	/// default heap.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpMem">
	/// <para>A pointer to a memory block within the specified heap. This parameter may be <c>NULL</c>.</para>
	/// <para>If this parameter is <c>NULL</c>, the function attempts to validate the entire heap specified by hHeap.</para>
	/// <para>
	/// If this parameter is not <c>NULL</c>, the function attempts to validate the memory block pointed to by lpMem. It does not attempt
	/// to validate the rest of the heap.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the specified heap or memory block is valid, the return value is nonzero.</para>
	/// <para>
	/// If the specified heap or memory block is invalid, the return value is zero. On a system set up for debugging, the
	/// <c>HeapValidate</c> function then displays debugging messages that describe the part of the heap or memory block that is invalid,
	/// and stops at a hard-coded breakpoint so that you can examine the system to determine the source of the invalidity. The
	/// <c>HeapValidate</c> function does not set the thread's last error value. There is no extended error information for this
	/// function; do not call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI HeapValidate( _In_ HANDLE hHeap, _In_ DWORD dwFlags, _In_opt_ LPCVOID lpMem);// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366708(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366708")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapValidate([In] HHEAP hHeap, HeapFlags dwFlags, [In] SafeHeapBlock lpMem);

	/// <summary>Enumerates the memory blocks in the specified heap.</summary>
	/// <param name="hHeap">
	/// A handle to the heap. This handle is returned by either the <c>HeapCreate</c> or <c>GetProcessHeap</c> function.
	/// </param>
	/// <param name="lpEntry">
	/// <para>A pointer to a <c>PROCESS_HEAP_ENTRY</c> structure that maintains state information for a particular heap enumeration.</para>
	/// <para>
	/// If the <c>HeapWalk</c> function succeeds, returning the value <c>TRUE</c>, this structure's members contain information about the
	/// next memory block in the heap.
	/// </para>
	/// <para>
	/// To initiate a heap enumeration, set the <c>lpData</c> field of the <c>PROCESS_HEAP_ENTRY</c> structure to <c>NULL</c>. To
	/// continue a particular heap enumeration, call the <c>HeapWalk</c> function repeatedly, with no changes to hHeap, lpEntry, or any
	/// of the members of the <c>PROCESS_HEAP_ENTRY</c> structure.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// <para>
	/// If the heap enumeration terminates successfully by reaching the end of the heap, the function returns <c>FALSE</c>, and
	/// <c>GetLastError</c> returns the error code <c>ERROR_NO_MORE_ITEMS</c>.
	/// </para>
	/// </returns>
	// BOOL WINAPI HeapWalk( _In_ HANDLE hHeap, _Inout_ LPPROCESS_HEAP_ENTRY lpEntry);// https://msdn.microsoft.com/en-us/library/windows/desktop/aa366710(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366710")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool HeapWalk([In] HHEAP hHeap, ref PROCESS_HEAP_ENTRY lpEntry);

	/// <summary>Enumerates the memory blocks in the specified heap.</summary>
	/// <param name="hHeap">
	/// A handle to the heap. This handle is returned by either the <c>HeapCreate</c> or <c>GetProcessHeap</c> function.
	/// </param>
	/// <returns>An enumeration of <c>PROCESS_HEAP_ENTRY</c> structures with state information for a particular heap.</returns>
	[PInvokeData("HeapApi.h", MSDNShortId = "aa366710")]
	public static IEnumerable<PROCESS_HEAP_ENTRY> HeapWalk([In] HHEAP hHeap)
	{
		var e = default(PROCESS_HEAP_ENTRY);
		while (HeapWalk(hHeap, ref e))
			yield return e;
		var err = Win32Error.GetLastError();
		if (err != Win32Error.ERROR_NO_MORE_ITEMS) err.ThrowIfFailed();
	}

	[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "HeapAlloc")]
	internal static extern IntPtr HeapAllocInternal(HHEAP hHeap, HeapFlags dwFlags, SizeT dwBytes);

	[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "HeapReAlloc")]
	internal static extern IntPtr HeapReAllocInternal(HHEAP hHeap, HeapFlags dwFlags, IntPtr lpMem, SizeT dwBytes);

	/// <summary>Specifies flags for a HeapOptimizeResources operation initiated with HeapSetInformation.</summary>
	/// <remarks>
	/// <para>Mandatory parameter to the HeapOptimizeResources class.</para>
	/// <para>
	/// The <c>HEAP_OPTIMIZE_RESOURCES_CURRENT_VERSION</c> constant is available to fill in the Version field of the
	/// <c>HEAP_OPTIMIZE_RESOURCES_INFORMATION</c> structure. The only legal value for this field is currently 1.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_heap_optimize_resources_information typedef struct
	// _HEAP_OPTIMIZE_RESOURCES_INFORMATION { DWORD Version; DWORD Flags; } HEAP_OPTIMIZE_RESOURCES_INFORMATION, *PHEAP_OPTIMIZE_RESOURCES_INFORMATION;
	[PInvokeData("winnt.h", MSDNShortId = "c801a08a-0b1a-4ffe-8ec7-c3ea8d913ec8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HEAP_OPTIMIZE_RESOURCES_INFORMATION
	{
		/// <summary>The version</summary>
		public uint Version;

		/// <summary>Undocumented.</summary>
		public uint Flags;

		/// <summary>Initializes a new instance of the <see cref="HEAP_OPTIMIZE_RESOURCES_INFORMATION"/> struct.</summary>
		/// <param name="flags">The flags.</param>
		public HEAP_OPTIMIZE_RESOURCES_INFORMATION(uint flags)
		{
			Version = HEAP_OPTIMIZE_RESOURCES_CURRENT_VERSION;
			Flags = flags;
		}
	}

	/// <summary>Represents a heap summary retrieved with a call to HeapSummary</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/heapapi/ns-heapapi-heap_summary
	// typedef struct _HEAP_SUMMARY { DWORD cb; SIZE_T cbAllocated; SIZE_T cbCommitted; SIZE_T cbReserved; SIZE_T cbMaxReserve; } HEAP_SUMMARY, *PHEAP_SUMMARY;
	[PInvokeData("heapapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HEAP_SUMMARY
	{
		/// <summary>Address of a continuous block of memory.</summary>
		public uint cb;
		/// <summary>The size of the allocated memory.</summary>
		public SizeT cbAllocated;
		/// <summary>The size of the committed memory.</summary>
		public SizeT cbCommitted;
		/// <summary>The size of the reserved memory.</summary>
		public SizeT cbReserved;
		/// <summary>The size of the maximum reserved memory.</summary>
		public SizeT cbMaxReserve;

		/// <summary>Gets this structure with the size field set appropriately.</summary>
		public static readonly HEAP_SUMMARY Default = new() { cb = (uint)Marshal.SizeOf(typeof(HEAP_SUMMARY)) };
	}

	public partial struct HHEAP
	{
		/// <summary>Gets a block of memory from this private heap.</summary>
		/// <param name="size">The size of the block.</param>
		/// <returns>A safe handle for the memory that will call HeapFree on disposal.</returns>
		public SafeHeapBlock GetBlock(int size) => new(this, size);

		/// <summary>
		/// Retrieves a handle to the default heap of the calling process. This handle can then be used in subsequent calls to the heap functions.
		/// </summary>
		/// <returns>The heap handle for the current process.</returns>
		public static HHEAP FromProcess() => GetProcessHeap();
	}

	/// <summary>
	/// Contains information about a heap element. The <c>HeapWalk</c> function uses a <c>PROCESS_HEAP_ENTRY</c> structure to enumerate
	/// the elements of a heap.
	/// </summary>
	// typedef struct _PROCESS_HEAP_ENTRY { PVOID lpData; DWORD cbData; BYTE cbOverhead; BYTE iRegionIndex; WORD wFlags; union { struct {
	// HANDLE hMem; DWORD dwReserved[3]; } Block; struct { DWORD dwCommittedSize; DWORD dwUnCommittedSize; LPVOID lpFirstBlock; LPVOID
	// lpLastBlock; } Region; };} PROCESS_HEAP_ENTRY, *LPPROCESS_HEAP_ENTRY; https://msdn.microsoft.com/en-us/library/windows/desktop/aa366798(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "aa366798")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PROCESS_HEAP_ENTRY
	{
		/// <summary>
		/// <para>A pointer to the data portion of the heap element.</para>
		/// <para>To initiate a <c>HeapWalk</c> heap enumeration, set <c>lpData</c> to <c>NULL</c>.</para>
		/// <para>
		/// If <c>PROCESS_HEAP_REGION</c> is used in the <c>wFlags</c> member, <c>lpData</c> points to the first virtual address used by
		/// the region.
		/// </para>
		/// <para>
		/// If <c>PROCESS_HEAP_UNCOMMITTED_RANGE</c> is used in <c>wFlags</c>, <c>lpData</c> points to the beginning of the range of
		/// uncommitted memory.
		/// </para>
		/// </summary>
		public IntPtr lpData;

		/// <summary>
		/// <para>The size of the data portion of the heap element, in bytes.</para>
		/// <para>
		/// If <c>PROCESS_HEAP_REGION</c> is used in <c>wFlags</c>, <c>cbData</c> specifies the total size, in bytes, of the address
		/// space that is reserved for this region.
		/// </para>
		/// <para>
		/// If <c>PROCESS_HEAP_UNCOMMITTED_RANGE</c> is used in <c>wFlags</c>, <c>cbData</c> specifies the size, in bytes, of the range
		/// of uncommitted memory.
		/// </para>
		/// </summary>
		public uint cbData;

		/// <summary>
		/// <para>
		/// The size of the data used by the system to maintain information about the heap element, in bytes. These overhead bytes are in
		/// addition to the <c>cbData</c> bytes of the data portion of the heap element.
		/// </para>
		/// <para>
		/// If <c>PROCESS_HEAP_REGION</c> is used in <c>wFlags</c>, <c>cbOverhead</c> specifies the size, in bytes, of the heap control
		/// structures that describe the region.
		/// </para>
		/// <para>
		/// If <c>PROCESS_HEAP_UNCOMMITTED_RANGE</c> is used in <c>wFlags</c>, <c>cbOverhead</c> specifies the size, in bytes, of the
		/// control structures that describe this uncommitted range.
		/// </para>
		/// </summary>
		public byte cbOverhead;

		/// <summary>
		/// <para>
		/// A handle to the heap region that contains the heap element. A heap consists of one or more regions of virtual memory, each
		/// with a unique region index.
		/// </para>
		/// <para>
		/// In the first heap entry returned for most heap regions, <c>HeapWalk</c> uses the <c>PROCESS_HEAP_REGION</c> in the
		/// <c>wFlags</c> member. When this value is used, the members of the <c>Region</c> structure contain additional information
		/// about the region.
		/// </para>
		/// <para>
		/// The <c>HeapAlloc</c> function sometimes uses the <c>VirtualAlloc</c> function to allocate large blocks from a growable heap.
		/// The heap manager treats such a large block allocation as a separate region with a unique region index. <c>HeapWalk</c> does
		/// not use <c>PROCESS_HEAP_REGION</c> in the heap entry returned for a large block region, so the members of the <c>Region</c>
		/// structure are not valid. You can use the <c>VirtualQuery</c> function to get additional information about a large block region.
		/// </para>
		/// </summary>
		public byte iRegionIndex;

		/// <summary>
		/// <para>
		/// The properties of the heap element. Some values affect the meaning of other members of this <c>PROCESS_HEAP_ENTRY</c> data
		/// structure. The following values are defined.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PROCESS_HEAP_ENTRY_BUSY0x0004</term>
		/// <term>
		/// The heap element is an allocated block.If PROCESS_HEAP_ENTRY_MOVEABLE is also specified, the Block structure becomes valid.
		/// The hMem member of the Block structure contains a handle to the allocated, moveable memory block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROCESS_HEAP_ENTRY_DDESHARE0x0020</term>
		/// <term>This value must be used with PROCESS_HEAP_ENTRY_BUSY, indicating that the heap element is an allocated block.</term>
		/// </item>
		/// <item>
		/// <term>PROCESS_HEAP_ENTRY_MOVEABLE0x0010</term>
		/// <term>
		/// This value must be used with PROCESS_HEAP_ENTRY_BUSY, indicating that the heap element is an allocated block.The block was
		/// allocated with LMEM_MOVEABLE or GMEM_MOVEABLE, and the Block structure becomes valid. The hMem member of the Block structure
		/// contains a handle to the allocated, moveable memory block.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROCESS_HEAP_REGION0x0001</term>
		/// <term>
		/// The heap element is located at the beginning of a region of contiguous virtual memory in use by the heap.The lpData member of
		/// the structure points to the first virtual address used by the region; the cbData member specifies the total size, in bytes,
		/// of the address space that is reserved for this region; and the cbOverhead member specifies the size, in bytes, of the heap
		/// control structures that describe the region.The Region structure becomes valid. The dwCommittedSize, dwUnCommittedSize,
		/// lpFirstBlock, and lpLastBlock members of the structure contain additional information about the region.
		/// </term>
		/// </item>
		/// <item>
		/// <term>PROCESS_HEAP_UNCOMMITTED_RANGE0x0002</term>
		/// <term>
		/// The heap element is located in a range of uncommitted memory within the heap region.The lpData member points to the beginning
		/// of the range of uncommitted memory; the cbData member specifies the size, in bytes, of the range of uncommitted memory; and
		/// the cbOverhead member specifies the size, in bytes, of the control structures that describe this uncommitted range.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public PROCESS_HEAP wFlags;

		/// <summary>A union</summary>
		public BLOCK_REGION_UNION union;

		/// <summary>Union of child structures.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct BLOCK_REGION_UNION
		{
			/// <summary>
			/// This structure is valid only if both the <c>PROCESS_HEAP_ENTRY_BUSY</c> and <c>PROCESS_HEAP_ENTRY_MOVEABLE</c> are
			/// specified in <c>wFlags</c>.
			/// </summary>
			[FieldOffset(0)]
			public BLOCK_DATA Block;

			/// <summary>This structure is valid only if the <c>wFlags</c> member specifies <c>PROCESS_HEAP_REGION</c>.</summary>
			[FieldOffset(0)]
			public REGION_DATA Region;

			/// <summary>
			/// This structure is valid only if both the <c>PROCESS_HEAP_ENTRY_BUSY</c> and <c>PROCESS_HEAP_ENTRY_MOVEABLE</c> are
			/// specified in <c>wFlags</c>.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct BLOCK_DATA
			{
				/// <summary>Handle to the allocated, moveable memory block.</summary>
				public IntPtr hMem;

				/// <summary>Reserved; not used.</summary>
				public uint dwReserved1;

				/// <summary>Reserved; not used.</summary>
				public uint dwReserved2;

				/// <summary>Reserved; not used.</summary>
				public uint dwReserved3;
			}

			/// <summary>This structure is valid only if the <c>wFlags</c> member specifies <c>PROCESS_HEAP_REGION</c>.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct REGION_DATA
			{
				/// <summary>
				/// Number of bytes in the heap region that are currently committed as free memory blocks, busy memory blocks, or heap
				/// control structures. This is an optional field that is set to zero if the number of committed bytes is not available.
				/// </summary>
				public uint dwCommittedSize;

				/// <summary>
				/// Number of bytes in the heap region that are currently uncommitted. This is an optional field that is set to zero if
				/// the number of uncommitted bytes is not available.
				/// </summary>
				public uint dwUnCommittedSize;

				/// <summary>Pointer to the first valid memory block in this heap region.</summary>
				public IntPtr lpFirstBlock;

				/// <summary>Pointer to the first invalid memory block in this heap region.</summary>
				public IntPtr lpLastBlock;
			}
		}
	}

	/// <summary>Unmanaged memory methods for a heap.</summary>
	/// <seealso cref="IMemoryMethods"/>
	public sealed class HeapMemoryMethods : MemoryMethodsBase
	{
		/// <summary>Gets a static instance of this class.</summary>
		/// <value>The instance.</value>
		public static IMemoryMethods Instance { get; } = new HeapMemoryMethods();

		internal HHEAP HeapHandle { get; set; } = GetProcessHeap();

		/// <inheritdoc/>
		public override bool AllocZeroes => true;

		/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		public override IntPtr AllocMem(int size) => Win32Error.ThrowLastErrorIfNull((IntPtr)HeapAllocInternal(HeapHandle, HeapFlags.HEAP_ZERO_MEMORY, size));

		/// <summary>Frees the memory associated with a handle.</summary>
		/// <param name="hMem">A memory handle.</param>
		public override void FreeMem(IntPtr hMem) => HeapFree(HeapHandle, 0, hMem);

		/// <summary>Gets the reallocation method.</summary>
		/// <param name="hMem">A memory handle.</param>
		/// <param name="size">The size, in bytes, of memory to allocate.</param>
		/// <returns>A memory handle.</returns>
		public override IntPtr ReAllocMem(IntPtr hMem, int size) => Win32Error.ThrowLastErrorIfNull((IntPtr)HeapReAllocInternal(HeapHandle, HeapFlags.HEAP_ZERO_MEMORY, hMem, size));

		private int GetSize(IntPtr ptr) => (int)HeapSize(HeapHandle, 0, ptr).Value;
	}

	/// <summary>Safe handle for memory heaps.</summary>
	/// <seealso cref="GenericSafeHandle"/>
	public partial class SafeHeapBlock : SafeMemoryHandleExt<HeapMemoryMethods>, ISafeMemoryHandleFactory
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHeapBlock"/> class.</summary>
		/// <param name="ptr">The handle created by <see cref="HeapAlloc"/>.</param>
		/// <param name="ownsHandle">if set to <c>true</c> this safe handle disposes the handle when done.</param>
		/// <param name="size">The size, in bytes, of the allocated heap memory, if known.</param>
		public SafeHeapBlock(IntPtr ptr, SizeT size, bool ownsHandle = true) : base(ptr, size, ownsHandle)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeHeapBlock"/> class.</summary>
		/// <param name="hHeap">A handle to a heap created using <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/>.</param>
		/// <param name="ptr">The handle created by <see cref="HeapAlloc"/>.</param>
		/// <param name="ownsHandle">if set to <c>true</c> this safe handle disposes the handle when done.</param>
		/// <param name="size">The size, in bytes, of the allocated heap memory, if known.</param>
		public SafeHeapBlock(HHEAP hHeap, IntPtr ptr, SizeT size, bool ownsHandle = true) : base(ptr, size, ownsHandle)
		{
			if (hHeap.IsNull) throw new ArgumentNullException(nameof(hHeap));
			mm.HeapHandle = hHeap;
		}

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		public SafeHeapBlock(SizeT size) : base(size)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
		/// <param name="hHeap">A handle to a heap created using <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/>.</param>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <param name="flags">
		/// <para>
		/// The heap allocation options. Specifying any of these values will override the corresponding value specified when the heap was
		/// created with HeapCreate. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HEAP_GENERATE_EXCEPTIONS 0x00000004</term>
		/// <term>
		/// The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning
		/// NULL. To ensure that exceptions are generated for all calls to this function, specify HEAP_GENERATE_EXCEPTIONS in the call to
		/// HeapCreate. In this case, it is not necessary to additionally specify HEAP_GENERATE_EXCEPTIONS in this function call.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HEAP_NO_SERIALIZE 0x00000001</term>
		/// <term>
		/// Serialized access will not be used for this allocation. For more information, see Remarks. To ensure that serialized access
		/// is disabled for all calls to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate. In this case, it is not
		/// necessary to additionally specify HEAP_NO_SERIALIZE in this function call. This value should not be specified when accessing
		/// the process's default heap. The system may create additional threads within the application's process, such as a CTRL+C
		/// handler, that simultaneously access the process's default heap.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HEAP_ZERO_MEMORY 0x00000008</term>
		/// <term>The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		public SafeHeapBlock(HHEAP hHeap, SizeT size = default, HeapFlags flags = 0) : this(hHeap, IntPtr.Zero, size)
		{
			if (size < 0)
				throw new ArgumentOutOfRangeException(nameof(size), "The value of this argument must be non-negative");
			if (size == 0) return;
			RuntimeHelpers.PrepareConstrainedRegions();
			SetHandle(HeapAllocInternal(hHeap, flags, size));
		}

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
		public SafeHeapBlock(byte[] bytes) : base(bytes) { }

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="hHeap">A handle to a heap created using <see cref="HeapCreate"/> or <see cref="GetProcessHeap"/>.</param>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
		public SafeHeapBlock(HHEAP hHeap, byte[] bytes) : this(hHeap, bytes.Length) => Marshal.Copy(bytes, 0, handle, bytes.Length);

		/// <summary>Prevents a default instance of the <see cref="SafeHeapBlock"/> class from being created.</summary>
		private SafeHeapBlock() : base(0) { }

		/// <summary>Represents a NULL memory pointer.</summary>
		public static SafeHeapBlock Null => new(IntPtr.Zero, 0, false);

		/// <summary>Gets the heap handle associated with this block.</summary>
		/// <value>The heap handle.</value>
		public HHEAP HeapHandle => mm.HeapHandle;

		/// <inheritdoc/>
		public static ISafeMemoryHandle Create(IntPtr handle, SizeT size, bool ownsHandle = true) => new SafeHeapBlock(handle, size, ownsHandle);

		/// <inheritdoc/>
		public static ISafeMemoryHandle Create(byte[] bytes) => new SafeHeapBlock(bytes);

		/// <inheritdoc/>
		public static ISafeMemoryHandle Create(SizeT size) => new SafeHeapBlock(size);

		/// <summary>
		/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure
		/// elements. It is the callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY
		/// structures with attribute StructLayout of LayoutKind.Sequential are supported.
		/// </summary>
		/// <typeparam name="T">Type of the trailing array of structures</typeparam>
		/// <param name="values">Collection of structure objects</param>
		/// <param name="count">
		/// Number of items in <paramref name="values"/>. Setting this value to -1 will cause the method to get the count by iterating
		/// through <paramref name="values"/>.
		/// </param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
		/// <returns><see cref="SafeHeapBlock"/> object to an native (unmanaged) structure with a trail array of structures</returns>
		public static SafeHeapBlock CreateFromList<T>(IEnumerable<T> values, int count = -1, int prefixBytes = 0) => new(InteropExtensions.MarshalToPtr(values, mm.AllocMem, out int s, prefixBytes), s);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
		/// <param name="values">The list of strings.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>
		/// <see cref="SafeHeapBlock"/> object to an native (unmanaged) array of strings stored using the <paramref name="packing"/>
		/// model and the character set defined by <paramref name="charSet"/>.
		/// </returns>
		public static SafeHeapBlock CreateFromStringList(IEnumerable<string?> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto, int prefixBytes = 0) => new(InteropExtensions.MarshalToPtr(values, packing, mm.AllocMem, out int s, charSet, prefixBytes), s);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
		/// <typeparam name="T">Native type</typeparam>
		/// <param name="value">The value.</param>
		/// <returns><see cref="SafeHeapBlock"/> object to an native (unmanaged) memory block the size of T.</returns>
		public static SafeHeapBlock CreateFromStructure<T>(in T value = default) where T : struct => new(InteropExtensions.MarshalToPtr(value, mm.AllocMem, out int s), s);

		/// <summary>Converts an <see cref="IntPtr"/> to a <see cref="SafeHeapBlock"/> where it owns the reference.</summary>
		/// <param name="ptr">The <see cref="IntPtr"/>.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeHeapBlock(IntPtr ptr) => new(ptr, 0, true);
	}

	public partial class SafeHHEAP
	{
		/// <summary>Gets or sets the heap features that are enabled.</summary>
		HeapCompatibility Compatibility
		{
			get => HeapQueryInformation<HeapCompatibility>(this, HEAP_INFORMATION_CLASS.HeapCompatibilityInformation);
			set => HeapSetInformation(this, HEAP_INFORMATION_CLASS.HeapCompatibilityInformation, value);
		}

		/// <summary>
		/// Enables the terminate-on-corruption feature. If the heap manager detects an error in any heap used by the process, it calls
		/// the Windows Error Reporting service and terminates the process.
		/// <para>After a process enables this feature, it cannot be disabled.</para>
		/// </summary>
		public void EnableTerminationOnCorruption() => Win32Error.ThrowLastErrorIfFalse(HeapSetInformation(this, HEAP_INFORMATION_CLASS.HeapEnableTerminationOnCorruption, default, default));

		/// <summary>Gets a block of memory from this private heap.</summary>
		/// <param name="size">The size of the block.</param>
		/// <returns>A safe handle for the memory that will call HeapFree on disposal.</returns>
		public SafeHeapBlock GetBlock(SizeT size) => new(this, size);

		/// <summary>Optimizes caches for this heap, and decommits the memory if possible.</summary>
		public void OptimizeResources() => HeapSetInformation(this, HEAP_INFORMATION_CLASS.HeapOptimizeResources, new HEAP_OPTIMIZE_RESOURCES_INFORMATION(0));
	}
}