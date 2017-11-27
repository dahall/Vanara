using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		[PInvokeData("HeapApi.h")]
		[Flags]
		public enum HeapFlags
		{
			/// <summary>Serialized access will not be used for this allocation. For more information, see Remarks.
			/// <para>To ensure that serialized access is disabled for all calls to this function, specify HEAP_NO_SERIALIZE in the call to HeapCreate. In this case, it is not necessary to additionally specify HEAP_NO_SERIALIZE in this function call.</para>
			/// <para>This value should not be specified when accessing the process's default heap. The system may create additional threads within the application's process, such as a CTRL+C handler, that simultaneously access the process's default heap.</para></summary>
			HEAP_NO_SERIALIZE = 0x00000001,
			HEAP_GROWABLE = 0x00000002,
			/// <summary>The system will raise an exception to indicate a function failure, such as an out-of-memory condition, instead of returning NULL.
			/// <para>To ensure that exceptions are generated for all calls to this function, specify HEAP_GENERATE_EXCEPTIONS in the call to HeapCreate. In this case, it is not necessary to additionally specify HEAP_GENERATE_EXCEPTIONS in this function call.</para></summary>
			HEAP_GENERATE_EXCEPTIONS = 0x00000004,
			/// <summary>The allocated memory will be initialized to zero. Otherwise, the memory is not initialized to zero.</summary>
			HEAP_ZERO_MEMORY = 0x00000008,
			HEAP_REALLOC_IN_PLACE_ONLY = 0x00000010,
			HEAP_TAIL_CHECKING_ENABLED = 0x00000020,
			HEAP_FREE_CHECKING_ENABLED = 0x00000040,
			HEAP_DISABLE_COALESCE_ON_FREE = 0x00000080,
			HEAP_CREATE_ALIGN_16 = 0x00010000,
			HEAP_CREATE_ENABLE_TRACING = 0x00020000,
			/// <summary>All memory blocks that are allocated from this heap allow code execution, if the hardware enforces data execution prevention. Use this flag heap in applications that run code from the heap. If HEAP_CREATE_ENABLE_EXECUTE is not specified and an application attempts to run code from a protected page, the application receives an exception with the status code STATUS_ACCESS_VIOLATION.</summary>
			HEAP_CREATE_ENABLE_EXECUTE = 0x00040000,
			HEAP_MAXIMUM_TAG = 0x0FFF,
			HEAP_PSEUDO_TAG_FLAG = 0x8000,
			HEAP_TAG_SHIFT = 18,
			HEAP_CREATE_SEGMENT_HEAP = 0x00000100,
			HEAP_CREATE_HARDENED = 0x00000200,
		}

		/// <summary>Retrieves a handle to the default heap of the calling process. This handle can then be used in subsequent calls to the heap functions.</summary>
		/// <returns>If the function succeeds, the return value is a handle to the calling process's heap. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
		[PInvokeData("HeapApi.h", MSDNShortId = "aa366569")]
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr GetProcessHeap();

		/// <summary>Allocates a block of memory from a heap. The allocated memory is not movable.</summary>
		/// <param name="hHeap">A handle to the heap from which the memory will be allocated. This handle is returned by the HeapCreate or GetProcessHeap function.</param>
		/// <param name="dwFlags">The heap allocation options. Specifying any of these values will override the corresponding value specified when the heap was created with HeapCreate. This parameter can be one or more of the following values: HEAP_GENERATE_EXCEPTIONS, HEAP_NO_SERIALIZE and HEAP_ZERO_MEMORY.</param>
		/// <param name="dwBytes">The number of bytes to be allocated. If the heap specified by the hHeap parameter is a "non-growable" heap, dwBytes must be less than 0x7FFF8. You create a non-growable heap by calling the HeapCreate function with a nonzero value.</param>
		/// <returns>If the function succeeds, the return value is a pointer to the allocated memory block.
		/// <para>If the function fails and you have not specified HEAP_GENERATE_EXCEPTIONS, the return value is NULL.</para>
		/// <para>If the function fails and you have specified HEAP_GENERATE_EXCEPTIONS, the function may generate either of the exceptions listed in the following table. The particular exception depends upon the nature of the heap corruption. For more information, see GetExceptionCode.</para></returns>
		[PInvokeData("HeapApi.h", MSDNShortId = "aa366597")]
		[DllImport(Lib.Kernel32, ExactSpelling = true)]
		public static extern IntPtr HeapAlloc(IntPtr hHeap, HeapFlags dwFlags, [MarshalAs(UnmanagedType.SysInt)] IntPtr dwBytes);

		/// <summary>Creates a private heap object that can be used by the calling process. The function reserves space in the virtual address space of the process and allocates physical storage for a specified initial portion of this block.</summary>
		/// <param name="flOptions">The heap allocation options. These options affect subsequent access to the new heap through calls to the heap functions. This parameter can be 0 or one or more of the following values: HEAP_CREATE_ENABLE_EXECUTE, HEAP_GENERATE_EXCEPTIONS, HEAP_NO_SERIALIZE.</param>
		/// <param name="dwInitialSize">The initial size of the heap, in bytes. This value determines the initial amount of memory that is committed for the heap. The value is rounded up to a multiple of the system page size. The value must be smaller than dwMaximumSize.
		/// <para>If this parameter is 0, the function commits one page. To determine the size of a page on the host computer, use the GetSystemInfo function.</para></param>
		/// <param name="dwMaximumSize">The maximum size of the heap, in bytes. The HeapCreate function rounds dwMaximumSize up to a multiple of the system page size and then reserves a block of that size in the process's virtual address space for the heap. If allocation requests made by the HeapAlloc or HeapReAlloc functions exceed the size specified by dwInitialSize, the system commits additional pages of memory for the heap, up to the heap's maximum size.
		/// <para>If dwMaximumSize is not zero, the heap size is fixed and cannot grow beyond the maximum size. Also, the largest memory block that can be allocated from the heap is slightly less than 512 KB for a 32-bit process and slightly less than 1,024 KB for a 64-bit process. Requests to allocate larger blocks fail, even if the maximum size of the heap is large enough to contain the block.</para>
		/// <para>If dwMaximumSize is 0, the heap can grow in size. The heap's size is limited only by the available memory. Requests to allocate memory blocks larger than the limit for a fixed-size heap do not automatically fail; instead, the system calls the VirtualAlloc function to obtain the memory that is needed for large blocks. Applications that need to allocate large memory blocks should set dwMaximumSize to 0.</para></param>
		/// <returns>If the function succeeds, the return value is a handle to the newly created heap. If the function fails, the return value is NULL. To get extended error information, call GetLastError.</returns>
		[PInvokeData("HeapApi.h", MSDNShortId = "aa366599")]
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		public static extern SafePrivateHeapHandle HeapCreate(HeapFlags flOptions, [MarshalAs(UnmanagedType.SysInt)] IntPtr dwInitialSize, [MarshalAs(UnmanagedType.SysInt)] IntPtr dwMaximumSize);

		/// <summary>Destroys the specified heap object. It decommits and releases all the pages of a private heap object, and it invalidates the handle to the heap.</summary>
		/// <param name="hHeap">A handle to the heap to be destroyed. This handle is returned by the HeapCreate function. Do not use the handle to the process heap returned by the GetProcessHeap function.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call GetLastError.</returns>
		[PInvokeData("HeapApi.h", MSDNShortId = "aa366700")]
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool HeapDestroy(IntPtr hHeap);

		/// <summary>Frees a memory block allocated from a heap by the HeapAlloc or HeapReAlloc function.</summary>
		/// <param name="hHeap">A handle to the heap whose memory block is to be freed. This handle is returned by either the HeapCreate or GetProcessHeap function.</param>
		/// <param name="dwFlags">The heap free options. Specifying the following value overrides the corresponding value specified in the flOptions parameter when the heap was created by using the HeapCreate function: HEAP_NO_SERIALIZE</param>
		/// <param name="lpMem">A pointer to the memory block to be freed. This pointer is returned by the HeapAlloc or HeapReAlloc function. If this pointer is NULL, the behavior is undefined.</param>
		/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.An application can call GetLastError for extended error information.</returns>
		[PInvokeData("HeapApi.h", MSDNShortId = "aa366701")]
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool HeapFree(IntPtr hHeap, HeapFlags dwFlags, IntPtr lpMem);

		/// <summary>Retrieves the size of a memory block allocated from a heap by the HeapAlloc or HeapReAlloc function.</summary>
		/// <param name="hHeap">A handle to the heap in which the memory block resides. This handle is returned by either the HeapCreate or GetProcessHeap function.</param>
		/// <param name="dwFlags">The heap size options. Specifying the following value overrides the corresponding value specified in the flOptions parameter when the heap was created by using the HeapCreate function.</param>
		/// <param name="lpMem">A pointer to the memory block whose size the function will obtain. This is a pointer returned by the HeapAlloc or HeapReAlloc function. The memory block must be from the heap specified by the hHeap parameter.</param>
		/// <returns>If the function succeeds, the return value is the requested size of the allocated memory block, in bytes.
		/// <para>If the function fails, the return value is (SIZE_T)-1. The function does not call SetLastError. An application cannot call GetLastError for extended error information.</para>
		/// <para>If the lpMem parameter refers to a heap allocation that is not in the heap specified by the hHeap parameter, the behavior of the HeapSize function is undefined.</para></returns>
		[PInvokeData("HeapApi.h", MSDNShortId = "aa366706")]
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.SysInt)]
		public static extern IntPtr HeapSize(IntPtr hHeap, HeapFlags dwFlags, IntPtr lpMem);

		/// <summary>Safe handle for memory heaps.</summary>
		/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
		public class SafePrivateHeapBlockHandle : GenericSafeHandle
		{
			private SafePrivateHeapHandle hHeap;

			/// <summary>Initializes a new instance of the <see cref="SafePrivateHeapBlockHandle"/> class.</summary>
			public SafePrivateHeapBlockHandle(SafePrivateHeapHandle hHeap) : this(hHeap, IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafePrivateHeapBlockHandle"/> class.</summary>
			/// <param name="hHeap">A handle to a heap created using <see cref="HeapCreate"/>.</param>
			/// <param name="ptr">The handle created by <see cref="HeapAlloc"/>.</param>
			/// <param name="own">if set to <c>true</c> this safe handle disposes the handle when done.</param>
			public SafePrivateHeapBlockHandle(SafePrivateHeapHandle hHeap, IntPtr ptr, bool own = true) : base(ptr, h => HeapFree(hHeap, 0, h), own)
			{
				this.hHeap = hHeap;
			}

			/// <summary>Initializes a new instance of the <see cref="SafePrivateHeapBlockHandle"/> class and allocates the specified amount of memory from the process heap.</summary>
			/// <param name="hHeap">A handle to a heap created using <see cref="HeapCreate"/>.</param>
			/// <param name="size">The size. This value cannot be zero.</param>
			public SafePrivateHeapBlockHandle(SafePrivateHeapHandle hHeap, int size) : this(hHeap, HeapAlloc(hHeap, HeapFlags.HEAP_ZERO_MEMORY, (IntPtr)size)) { }

			/// <summary>Retrieves the size of this memory block.</summary>
			/// <value>The size in bytes of this memory block.</value>
			public long Size => HeapSize(hHeap, 0, handle).ToInt64();
		}

		/// <summary>Safe handle for memory heaps.</summary>
		/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
		public class SafeProcessHeapBlockHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeProcessHeapBlockHandle"/> class.</summary>
			public SafeProcessHeapBlockHandle() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeProcessHeapBlockHandle"/> class.</summary>
			/// <param name="ptr">The handle created by <see cref="HeapAlloc"/>.</param>
			/// <param name="own">if set to <c>true</c> this safe handle disposes the handle when done.</param>
			public SafeProcessHeapBlockHandle(IntPtr ptr, bool own = true) : base(ptr, h => HeapFree(GetProcessHeap(), 0, h), own) { }

			/// <summary>Initializes a new instance of the <see cref="SafeProcessHeapBlockHandle"/> class and allocates the specified amount of memory from the process heap.</summary>
			/// <param name="size">The size. This value cannot be zero.</param>
			public SafeProcessHeapBlockHandle(ulong size) : this(HeapAlloc(GetProcessHeap(), HeapFlags.HEAP_ZERO_MEMORY, (IntPtr)size)) { }

			/// <summary>Retrieves the size of this memory block.</summary>
			/// <value>The size in bytes of this memory block.</value>
			public long Size => HeapSize(GetProcessHeap(), 0, handle).ToInt64();
		}

		/// <summary>Safe handle for memory heaps.</summary>
		/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
		public class SafePrivateHeapHandle : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafePrivateHeapHandle"/> class.</summary>
			public SafePrivateHeapHandle() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafePrivateHeapHandle"/> class.</summary>
			/// <param name="ptr">The handle created by <see cref="HeapCreate"/>.</param>
			/// <param name="own">if set to <c>true</c> this safe handle disposes the handle when done.</param>
			public SafePrivateHeapHandle(IntPtr ptr, bool own = true) : base(ptr, HeapDestroy, own) { }

			/// <summary>Gets a block of memory from this private heap.</summary>
			/// <param name="size">The size of the block.</param>
			/// <returns>A safe handle for the memory that will call HeapFree on disposal.</returns>
			public SafePrivateHeapBlockHandle GetBlock(int size) => new SafePrivateHeapBlockHandle(this, size);
		}
	}
}