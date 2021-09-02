using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke
{
	public static partial class NtDll
	{
		/// <summary>Callback routine to commit pages from the heap.</summary>
		/// <param name="Base">Base address for the block of caller-allocated memory being used for the heap.</param>
		/// <param name="CommitAddress">Pointer to a variable that will receive the base address of the committed region of pages.</param>
		/// <param name="CommitSize">Pointer to a variable that will receive the actual size, in bytes, of the allocated region of pages.</param>
		/// <returns>Result of commit.</returns>
		[UnmanagedFunctionPointer(CallingConvention.Winapi, SetLastError = false)]
		public delegate NTStatus PRTL_HEAP_COMMIT_ROUTINE([In] IntPtr Base, ref IntPtr CommitAddress, ref SizeT CommitSize);

		/// <summary>The <c>RtlAllocateHeap</c> routine allocates a block of memory from a heap.</summary>
		/// <param name="HeapHandle">
		/// [in] Handle for a private heap from which the memory will be allocated. This parameter is a handle returned from a successful
		/// call to <c>RtlCreateHeap</c> .
		/// </param>
		/// <param name="Flags">
		/// <para>
		/// [in, optional] Controllable aspects of heap allocation. Specifying any of these values will override the corresponding value
		/// specified when the heap was created with <c>RtlCreateHeap</c>. This parameter can be one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HEAP_GENERATE_EXCEPTIONS</term>
		/// <term>
		/// The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HEAP_NO_SERIALIZE</term>
		/// <term>Mutual exclusion will not be used while RtlAllocateHeap is accessing the heap.</term>
		/// </item>
		/// <item>
		/// <term>HEAP_ZERO_MEMORY</term>
		/// <term>The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="Size">
		/// [in] Number of bytes to be allocated. If the heap, specified by the HeapHandle parameter, is a nongrowable heap, Size must be
		/// less than or equal to the heap's virtual memory threshold. (For more information, see the <c>VirtualMemoryThreshold</c> member
		/// of the Parameters parameter to <c>RtlCreateHeap</c>.)
		/// </param>
		/// <returns>
		/// If the call to <c>RtlAllocateHeap</c> succeeds, the return value is a pointer to the newly-allocated block. The return value is
		/// NULL if the allocation failed.
		/// </returns>
		/// <remarks>
		/// <para><c>RtlAllocateHeap</c> allocates a block of memory of the specified size from the specified heap.</para>
		/// <para>To free a block of memory allocated by <c>RtlAllocateHeap</c>, call <c>RtlFreeHeap</c>.</para>
		/// <para>
		/// Memory allocated by <c>RtlAllocateHeap</c> is not movable. Since the memory is not movable, it is possible for the heap to
		/// become fragmented.
		/// </para>
		/// <para>
		/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
		/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
		/// from the same heap. Setting the HEAP_NO_SERIALIZE value eliminates mutual exclusion on the heap. Without serialization, two or
		/// more threads that use the same heap handle might attempt to allocate or free memory simultaneously, likely causing corruption in
		/// the heap. The HEAP_NO_SERIALIZE value can, therefore, be safely used only in the following situations:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <para>The process has only one thread.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The process has multiple threads, but only one thread calls the heap functions for a specific heap.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <para>The process has multiple threads, and the application provides its own mechanism for mutual exclusion to a specific heap.</para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// To guard against an access violation, use structured exception handling to protect any code that writes to or reads from a heap.
		/// For more information about structured exception handling with memory accesses, see Handling Exceptions.
		/// </para>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtlallocateheap NTSYSAPI PVOID RtlAllocateHeap(
		// PVOID HeapHandle, ULONG Flags, SIZE_T Size );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlAllocateHeap")]
		public static extern IntPtr RtlAllocateHeap(IntPtr HeapHandle, [In, Optional] HeapFlags Flags, SizeT Size);

		/// <summary>
		/// The <c>RtlCreateHeap</c> routine creates a heap object that can be used by the calling process. This routine reserves space in
		/// the virtual address space of the process and allocates physical storage for a specified initial portion of this block.
		/// </summary>
		/// <param name="Flags">
		/// <para>
		/// [in] Flags specifying optional attributes of the heap. These options affect subsequent access to the new heap through calls to
		/// the heap functions (RtlAllocateHeap and RtlFreeHeap).
		/// </para>
		/// <para>Callers should set this parameter to zero if no optional attributes are requested.</para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <para>HEAP_GENERATE_EXCEPTIONS</para>
		/// <para>
		/// Specifies that the system will indicate a heap failure by raising an exception, such as STATUS_NO_MEMORY, instead of returning <c>NULL</c>.
		/// </para>
		/// <para>HEAP_GROWABLE</para>
		/// <para>Specifies that the heap is growable. Must be specified if HeapBase is <c>NULL</c>.</para>
		/// <para>HEAP_NO_SERIALIZE</para>
		/// <para>
		/// Specifies that mutual exclusion will not be used when the heap functions allocate and free memory from this heap. The default,
		/// when HEAP_NO_SERIALIZE is not specified, is to serialize access to the heap. Serialization of heap access allows two or more
		/// threads to simultaneously allocate and free memory from the same heap.
		/// </para>
		/// </param>
		/// <param name="HeapBase">
		/// <para>[in, optional] Specifies one of two actions:</para>
		/// <para>
		/// If HeapBase is a non- <c>NULL</c> value, it specifies the base address for a block of caller-allocated memory to use for the heap.
		/// </para>
		/// <para>
		/// If HeapBase is <c>NULL</c>, <c>RtlCreateHeap</c> allocates system memory for the heap from the process's virtual address space.
		/// </para>
		/// </param>
		/// <param name="ReserveSize">
		/// <para>
		/// [in, optional] If ReserveSize is a nonzero value, it specifies the initial amount of memory, in bytes, to reserve for the heap.
		/// <c>RtlCreateHeap</c> rounds ReserveSize up to the next page boundary, and then reserves a block of that size for the heap.
		/// </para>
		/// <para>
		/// This parameter is optional and can be zero. The following table summarizes the interaction of the ReserveSize and CommitSize parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Values</term>
		/// <term>Result</term>
		/// </listheader>
		/// <item>
		/// <term>ReserveSize zero, CommitSize zero</term>
		/// <term>64 pages are initially reserved for the heap. One page is initially committed.</term>
		/// </item>
		/// <item>
		/// <term>ReserveSize zero, CommitSize nonzero</term>
		/// <term>
		/// RtlCreateHeap sets ReserveSize to be equal to CommitSize, and then rounds ReserveSize up to the nearest multiple of (PAGE_SIZE * 16).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ReserveSize nonzero, CommitSize zero</term>
		/// <term>One page is initially committed for the heap.</term>
		/// </item>
		/// <item>
		/// <term>ReserveSize nonzero, CommitSize nonzero</term>
		/// <term>If CommitSize is greater than ReserveSize, RtlCreateHeap reduces CommitSize to ReserveSize.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="CommitSize">
		/// <para>
		/// [in, optional] If CommitSize is a nonzero value, it specifies the initial amount of memory, in bytes, to commit for the heap.
		/// <c>RtlCreateHeap</c> rounds CommitSize up to the next page boundary, and then commits a block of that size in the process's
		/// virtual address space for the heap.
		/// </para>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="Lock">
		/// [in, optional] Pointer to an opaque ERESOURCE structure to be used as a resource lock. This parameter is optional and can be
		/// <c>NULL</c>. When provided by the caller, the structure must be allocated from nonpaged pool and initialized by calling
		/// ExInitializeResourceLite or ExReinitializeResourceLite. If the HEAP_NO_SERIALIZE flag is set, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="Parameters">
		/// [in, optional] Pointer to a RTL_HEAP_PARAMETERS structure that contains parameters to be applied when creating the heap. This
		/// parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <returns><c>RtlCreateHeap</c> returns a handle to be used in accessing the created heap.</returns>
		/// <remarks>
		/// <para>
		/// <c>RtlCreateHeap</c> creates a private heap object from which the calling process can allocate memory blocks by calling
		/// RtlAllocateHeap. The initial commit size determines the number of pages that are initially allocated for the heap. The initial
		/// reserve size determines the number of pages that are initially reserved for the heap. Pages that are reserved but uncommitted
		/// create a block in the process's virtual address space into which the heap can expand.
		/// </para>
		/// <para>
		/// If allocation requests made by RtlAllocateHeap exceed the heap's initial commit size, the system commits additional pages of
		/// physical storage for the heap, up to the heap's maximum size. If the heap is nongrowable, its maximum size is limited to its
		/// initial reserve size.
		/// </para>
		/// <para>
		/// If the heap is growable, its size is limited only by available memory. If requests by RtlAllocateHeap exceed the current size of
		/// committed pages, the system calls ZwAllocateVirtualMemory to obtain the memory needed, assuming that the physical storage is available.
		/// </para>
		/// <para>
		/// In addition, if the heap is nongrowable, an absolute limitation arises: the maximum size of a memory block in the heap is
		/// 0x7F000 bytes. The virtual memory threshold of the heap is equal to the maximum heap block size or the value of the
		/// <c>VirtualMemoryThreshold</c> member of the Parameters structure, whichever is less. The heap also may need to pad the request
		/// size for metadata and alignment purposes so requests to allocate blocks within 4096 Bytes (1 Page) of the
		/// <c>VirtualMemoryThreshold</c> may fail even if the maximum size of the heap is large enough to contain the block. (For more
		/// information about <c>VirtualMemoryThreshold</c>, see the members of the Parameters parameter to <c>RtlCreateHeap</c>.)
		/// </para>
		/// <para>
		/// If the heap is growable, requests to allocate blocks larger than the heap's virtual memory threshold do not automatically fail;
		/// the system calls ZwAllocateVirtualMemory to obtain the memory needed for such large blocks.
		/// </para>
		/// <para>The memory of a private heap object is accessible only to the process that created it.</para>
		/// <para>
		/// The system uses memory from the private heap to store heap support structures, so not all of the specified heap size is
		/// available to the process. For example, if RtlAllocateHeap requests 64 kilobytes (K) from a heap with a maximum size of 64K, the
		/// request may fail because of system overhead.
		/// </para>
		/// <para>
		/// If HEAP_NO_SERIALIZE is not specified (the simple default), the heap will serialize access within the calling process.
		/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
		/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
		/// from the same heap.
		/// </para>
		/// <para>
		/// Setting HEAP_NO_SERIALIZE eliminates mutual exclusion on the heap. Without serialization, two or more threads that use the same
		/// heap handle might attempt to allocate or free memory simultaneously, likely causing corruption in the heap. Therefore,
		/// HEAP_NO_SERIALIZE can safely be used only in the following situations:
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
		/// <para><c>Note</c>
		/// <para></para>
		/// To guard against an access violation, use structured exception handling to protect any code that writes to or reads from a heap.
		/// For more information about structured exception handling with memory accesses, see Handling Exceptions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtlcreateheap NTSYSAPI PVOID RtlCreateHeap( ULONG
		// Flags, PVOID HeapBase, SIZE_T ReserveSize, SIZE_T CommitSize, PVOID Lock, PRTL_HEAP_PARAMETERS Parameters );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlCreateHeap")]
		public static extern IntPtr RtlCreateHeap(HeapFlags Flags, [In, Optional] IntPtr HeapBase, [In, Optional] SizeT ReserveSize,
			[In, Optional] SizeT CommitSize, [In, Optional] IntPtr Lock, [In, Optional] IntPtr Parameters);

		/// <summary>
		/// The <c>RtlCreateHeap</c> routine creates a heap object that can be used by the calling process. This routine reserves space in
		/// the virtual address space of the process and allocates physical storage for a specified initial portion of this block.
		/// </summary>
		/// <param name="Flags">
		/// <para>
		/// [in] Flags specifying optional attributes of the heap. These options affect subsequent access to the new heap through calls to
		/// the heap functions (RtlAllocateHeap and RtlFreeHeap).
		/// </para>
		/// <para>Callers should set this parameter to zero if no optional attributes are requested.</para>
		/// <para>This parameter can be one or more of the following values.</para>
		/// <para>HEAP_GENERATE_EXCEPTIONS</para>
		/// <para>
		/// Specifies that the system will indicate a heap failure by raising an exception, such as STATUS_NO_MEMORY, instead of returning <c>NULL</c>.
		/// </para>
		/// <para>HEAP_GROWABLE</para>
		/// <para>Specifies that the heap is growable. Must be specified if HeapBase is <c>NULL</c>.</para>
		/// <para>HEAP_NO_SERIALIZE</para>
		/// <para>
		/// Specifies that mutual exclusion will not be used when the heap functions allocate and free memory from this heap. The default,
		/// when HEAP_NO_SERIALIZE is not specified, is to serialize access to the heap. Serialization of heap access allows two or more
		/// threads to simultaneously allocate and free memory from the same heap.
		/// </para>
		/// </param>
		/// <param name="HeapBase">
		/// <para>[in, optional] Specifies one of two actions:</para>
		/// <para>
		/// If HeapBase is a non- <c>NULL</c> value, it specifies the base address for a block of caller-allocated memory to use for the heap.
		/// </para>
		/// <para>
		/// If HeapBase is <c>NULL</c>, <c>RtlCreateHeap</c> allocates system memory for the heap from the process's virtual address space.
		/// </para>
		/// </param>
		/// <param name="ReserveSize">
		/// <para>
		/// [in, optional] If ReserveSize is a nonzero value, it specifies the initial amount of memory, in bytes, to reserve for the heap.
		/// <c>RtlCreateHeap</c> rounds ReserveSize up to the next page boundary, and then reserves a block of that size for the heap.
		/// </para>
		/// <para>
		/// This parameter is optional and can be zero. The following table summarizes the interaction of the ReserveSize and CommitSize parameters.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Values</term>
		/// <term>Result</term>
		/// </listheader>
		/// <item>
		/// <term>ReserveSize zero, CommitSize zero</term>
		/// <term>64 pages are initially reserved for the heap. One page is initially committed.</term>
		/// </item>
		/// <item>
		/// <term>ReserveSize zero, CommitSize nonzero</term>
		/// <term>
		/// RtlCreateHeap sets ReserveSize to be equal to CommitSize, and then rounds ReserveSize up to the nearest multiple of (PAGE_SIZE * 16).
		/// </term>
		/// </item>
		/// <item>
		/// <term>ReserveSize nonzero, CommitSize zero</term>
		/// <term>One page is initially committed for the heap.</term>
		/// </item>
		/// <item>
		/// <term>ReserveSize nonzero, CommitSize nonzero</term>
		/// <term>If CommitSize is greater than ReserveSize, RtlCreateHeap reduces CommitSize to ReserveSize.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="CommitSize">
		/// <para>
		/// [in, optional] If CommitSize is a nonzero value, it specifies the initial amount of memory, in bytes, to commit for the heap.
		/// <c>RtlCreateHeap</c> rounds CommitSize up to the next page boundary, and then commits a block of that size in the process's
		/// virtual address space for the heap.
		/// </para>
		/// <para>This parameter is optional and can be zero.</para>
		/// </param>
		/// <param name="Lock">
		/// [in, optional] Pointer to an opaque ERESOURCE structure to be used as a resource lock. This parameter is optional and can be
		/// <c>NULL</c>. When provided by the caller, the structure must be allocated from nonpaged pool and initialized by calling
		/// ExInitializeResourceLite or ExReinitializeResourceLite. If the HEAP_NO_SERIALIZE flag is set, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="Parameters">
		/// [in, optional] Pointer to a RTL_HEAP_PARAMETERS structure that contains parameters to be applied when creating the heap. This
		/// parameter is optional and can be <c>NULL</c>.
		/// </param>
		/// <returns><c>RtlCreateHeap</c> returns a handle to be used in accessing the created heap.</returns>
		/// <remarks>
		/// <para>
		/// <c>RtlCreateHeap</c> creates a private heap object from which the calling process can allocate memory blocks by calling
		/// RtlAllocateHeap. The initial commit size determines the number of pages that are initially allocated for the heap. The initial
		/// reserve size determines the number of pages that are initially reserved for the heap. Pages that are reserved but uncommitted
		/// create a block in the process's virtual address space into which the heap can expand.
		/// </para>
		/// <para>
		/// If allocation requests made by RtlAllocateHeap exceed the heap's initial commit size, the system commits additional pages of
		/// physical storage for the heap, up to the heap's maximum size. If the heap is nongrowable, its maximum size is limited to its
		/// initial reserve size.
		/// </para>
		/// <para>
		/// If the heap is growable, its size is limited only by available memory. If requests by RtlAllocateHeap exceed the current size of
		/// committed pages, the system calls ZwAllocateVirtualMemory to obtain the memory needed, assuming that the physical storage is available.
		/// </para>
		/// <para>
		/// In addition, if the heap is nongrowable, an absolute limitation arises: the maximum size of a memory block in the heap is
		/// 0x7F000 bytes. The virtual memory threshold of the heap is equal to the maximum heap block size or the value of the
		/// <c>VirtualMemoryThreshold</c> member of the Parameters structure, whichever is less. The heap also may need to pad the request
		/// size for metadata and alignment purposes so requests to allocate blocks within 4096 Bytes (1 Page) of the
		/// <c>VirtualMemoryThreshold</c> may fail even if the maximum size of the heap is large enough to contain the block. (For more
		/// information about <c>VirtualMemoryThreshold</c>, see the members of the Parameters parameter to <c>RtlCreateHeap</c>.)
		/// </para>
		/// <para>
		/// If the heap is growable, requests to allocate blocks larger than the heap's virtual memory threshold do not automatically fail;
		/// the system calls ZwAllocateVirtualMemory to obtain the memory needed for such large blocks.
		/// </para>
		/// <para>The memory of a private heap object is accessible only to the process that created it.</para>
		/// <para>
		/// The system uses memory from the private heap to store heap support structures, so not all of the specified heap size is
		/// available to the process. For example, if RtlAllocateHeap requests 64 kilobytes (K) from a heap with a maximum size of 64K, the
		/// request may fail because of system overhead.
		/// </para>
		/// <para>
		/// If HEAP_NO_SERIALIZE is not specified (the simple default), the heap will serialize access within the calling process.
		/// Serialization ensures mutual exclusion when two or more threads attempt to simultaneously allocate or free blocks from the same
		/// heap. There is a small performance cost to serialization, but it must be used whenever multiple threads allocate and free memory
		/// from the same heap.
		/// </para>
		/// <para>
		/// Setting HEAP_NO_SERIALIZE eliminates mutual exclusion on the heap. Without serialization, two or more threads that use the same
		/// heap handle might attempt to allocate or free memory simultaneously, likely causing corruption in the heap. Therefore,
		/// HEAP_NO_SERIALIZE can safely be used only in the following situations:
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
		/// <para><c>Note</c>
		/// <para></para>
		/// To guard against an access violation, use structured exception handling to protect any code that writes to or reads from a heap.
		/// For more information about structured exception handling with memory accesses, see Handling Exceptions.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtlcreateheap NTSYSAPI PVOID RtlCreateHeap( ULONG
		// Flags, PVOID HeapBase, SIZE_T ReserveSize, SIZE_T CommitSize, PVOID Lock, PRTL_HEAP_PARAMETERS Parameters );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlCreateHeap")]
		public static extern IntPtr RtlCreateHeap(HeapFlags Flags, [In, Optional] IntPtr HeapBase, [In, Optional] SizeT ReserveSize,
			[In, Optional] SizeT CommitSize, [In, Optional] IntPtr Lock, in RTL_HEAP_PARAMETERS Parameters);

		/// <summary>
		/// The <c>RtlDestroyHeap</c> routine destroys the specified heap object. <c>RtlDestroyHeap</c> decommits and releases all the pages
		/// of a private heap object, and it invalidates the handle to the heap.
		/// </summary>
		/// <param name="HeapHandle">[in] Handle for the heap to be destroyed. This parameter is a heap handle returned by <c>RtlCreateHeap</c>.</param>
		/// <returns>
		/// <para>If the call to <c>RtlDestroyHeap</c> succeeds, the return value is a <c>NULL</c> pointer.</para>
		/// <para>If the call to <c>RtlDestroyHeap</c> fails, the return value is a handle for the heap.</para>
		/// </returns>
		/// <remarks>
		/// Processes can call <c>RtlDestroyHeap</c> without first calling <c>RtlFreeHeap</c> to free memory that was allocated from the heap.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntifs/nf-ntifs-rtldestroyheap NTSYSAPI PVOID RtlDestroyHeap( PVOID
		// HeapHandle );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntifs.h", MSDNShortId = "NF:ntifs.RtlDestroyHeap")]
		public static extern IntPtr RtlDestroyHeap(IntPtr HeapHandle);

		/// <summary>Frees a memory block that was allocated from a heap by <c>RtlAllocateHeap</c>.</summary>
		/// <param name="HeapHandle">A handle for the heap whose memory block is to be freed. This parameter is a handle returned by <c>RtlCreateHeap</c>.</param>
		/// <param name="Flags">
		/// <para>
		/// A set of flags that controls aspects of freeing a memory block. Specifying the following value overrides the corresponding value
		/// that was specified in the Flags parameter when the heap was created by <c>RtlCreateHeap</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HEAP_NO_SERIALIZE</term>
		/// <term>Mutual exclusion will not be used when RtlFreeHeap is accessing the heap.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="HeapBase">A pointer to the memory block to free. This pointer is returned by <c>RtlAllocateHeap</c>.</param>
		/// <returns>
		/// <para>Returns <c>TRUE</c> if the block was freed successfully; <c>FALSE</c> otherwise.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>Starting with Windows 8 the return value is typed as <c>LOGICAL</c>, which has a different size than <c>BOOLEAN</c>.</para>
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/devnotes/rtlfreeheap BOOLEAN RtlFreeHeap( _In_ PVOID HeapHandle, _In_opt_ ULONG
		// Flags, _In_ PVOID HeapBase );
		[DllImport(Lib.NtDll, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("ntifs.h")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool RtlFreeHeap([In] IntPtr HeapHandle, [In, Optional] HeapFlags Flags, [In] IntPtr HeapBase);

		/// <summary>Contains parameters to be applied when creating the heap.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct RTL_HEAP_PARAMETERS
		{
			/// <summary>Size, in bytes, of the RTL_HEAP_PARAMETERS structure.</summary>
			public uint Length;

			/// <summary>Segment reserve size, in bytes. If this value is not specified, 1 MB is used.</summary>
			public SizeT SegmentReserve;

			/// <summary>Segment reserve size, in bytes. If this value is not specified, 1 MB is used.</summary>
			public SizeT SegmentCommit;

			/// <summary>Decommit free block threshold, in bytes. If this value is not specified, PAGE_SIZE is used.</summary>
			public SizeT DeCommitFreeBlockThreshold;

			/// <summary>Decommit total free threshold, in bytes. If this value is not specified, 65536 is used.</summary>
			public SizeT DeCommitTotalFreeThreshold;

			/// <summary>
			/// Size, in bytes, of the largest block of memory that can be allocated from the heap. If this value is not specified, the
			/// difference between the highest and lowest addresses, less one page, is used.
			/// </summary>
			public SizeT MaximumAllocationSize;

			/// <summary>
			/// Virtual memory threshold, in bytes. If this value is not specified, or if it is greater than the maximum heap block size,
			/// the maximum heap block size of 0x7F000 is used.
			/// </summary>
			public SizeT VirtualMemoryThreshold;

			/// <summary>
			/// Initial amount of memory, in bytes, to commit for the heap.
			/// <para>Must be less than or equal to InitialReserve.</para>
			/// <para>
			/// If HeapBase and CommitRoutine are non-NULL, this parameter, which overrides the value of CommitSize, must be a nonzero
			/// value; otherwise it is ignored.
			/// </para>
			/// </summary>
			public SizeT InitialCommit;

			/// <summary>
			/// Initial amount of memory, in bytes, to reserve for the heap.
			/// <para>
			/// If HeapBase and CommitRoutine are non-NULL, this parameter, which overrides the value of ReserveSize, must be a nonzero
			/// value; otherwise it is ignored.
			/// </para>
			/// </summary>
			public SizeT InitialReserve;

			/// <summary>
			/// Callback routine to commit pages from the heap. If this parameter is non-NULL, the heap must be nongrowable.
			/// <para>If HeapBase is NULL, CommitRoutine must also be NULL.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.FunctionPtr)]
			public PRTL_HEAP_COMMIT_ROUTINE CommitRoutine;

			/// <summary>Reserved for system use. Drivers must set this parameter to zero.</summary>
			private SizeT Reserved1;

			/// <summary>Reserved for system use. Drivers must set this parameter to zero.</summary>
			private SizeT Reserved2;
		}
	}
}