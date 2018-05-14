using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>The memory allocation attributes.</summary>
		[Flags]
		public enum GMEM
		{
			/// <summary>Combines GMEM_MOVEABLE and GMEM_ZEROINIT.</summary>
			GHND = 0x0042,
			/// <summary>Allocates fixed memory. The return value is a pointer.</summary>
			GMEM_FIXED = 0x0000,
			/// <summary>
			/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.
			/// <para>The return value is a handle to the memory object. To translate the handle into a pointer, use the GlobalLock function.</para>
			/// <para>This value cannot be combined with GMEM_FIXED.</para>
			/// </summary>
			GMEM_MOVEABLE = 0x0002,
			/// <summary>Initializes memory contents to zero.</summary>
			GMEM_ZEROINIT = 0x0040,
			/// <summary>Combines GMEM_FIXED and GMEM_ZEROINIT.</summary>
			GPTR = 0x0040,
		}

		/// <summary>The memory allocation attributes.</summary>
		[PInvokeData("MinWinBase.h")]
		[Flags]
		public enum LMEM
		{
			/// <summary>Allocates fixed memory. The return value is a pointer to the memory object.</summary>
			LMEM_FIXED = 0x0000,
			/// <summary>
			/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap. The return value is a
			/// handle to the memory object. To translate the handle to a pointer, use the LocalLock function. This value cannot be combined with LMEM_FIXED.
			/// </summary>
			LMEM_MOVEABLE = 0x0002,
			/// <summary>Obsolete.</summary>
			[Obsolete]
			LMEM_NOCOMPACT = 0x0010,
			/// <summary>Obsolete.</summary>
			[Obsolete]
			LMEM_NODISCARD = 0x0020,
			/// <summary>Initializes memory contents to zero.</summary>
			LMEM_ZEROINIT = 0x0040,
			/// <summary>
			/// If the LMEM_MODIFY flag is specified in LocalReAlloc, this parameter modifies the attributes of the memory object, and the uBytes parameter is ignored.
			/// </summary>
			LMEM_MODIFY = 0x0080,
			/// <summary>Obsolete.</summary>
			[Obsolete]
			LMEM_DISCARDABLE = 0x0F00,
			/// <summary>Valid flags.</summary>
			LMEM_VALID_FLAGS = 0x0F72,
			/// <summary>Indicates that the local handle is not valid</summary>
			LMEM_INVALID_HANDLE = 0x8000,
			/// <summary>Combines LMEM_MOVEABLE and LMEM_ZEROINIT.</summary>
			LHND = (LMEM_MOVEABLE | LMEM_ZEROINIT),
			/// <summary>Combines LMEM_FIXED and LMEM_ZEROINIT.</summary>
			LPTR = (LMEM_FIXED | LMEM_ZEROINIT),
			/// <summary>Same as LMEM_MOVEABLE.</summary>
			NONZEROLHND = (LMEM_MOVEABLE),
			/// <summary>Same as LMEM_FIXED.</summary>
			NONZEROLPTR = (LMEM_FIXED)
		}

		/// <summary>Allocates the specified number of bytes from the heap.</summary>
		/// <param name="uFlags">
		/// <para>
		/// The memory allocation attributes. If zero is specified, the default is <c>GMEM_FIXED</c>. This parameter can be one or more of the following values,
		/// except for the incompatible combinations that are specifically noted.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GHND0x0042</term>
		/// <term>Combines GMEM_MOVEABLE and GMEM_ZEROINIT.</term>
		/// </item>
		/// <item>
		/// <term>GMEM_FIXED0x0000</term>
		/// <term>Allocates fixed memory. The return value is a pointer.</term>
		/// </item>
		/// <item>
		/// <term>GMEM_MOVEABLE0x0002</term>
		/// <term>
		/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.The return value is a
		/// handle to the memory object. To translate the handle into a pointer, use the GlobalLock function.This value cannot be combined with GMEM_FIXED.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GMEM_ZEROINIT0x0040</term>
		/// <term>Initializes memory contents to zero.</term>
		/// </item>
		/// <item>
		/// <term>GPTR0x0040</term>
		/// <term>Combines GMEM_FIXED and GMEM_ZEROINIT.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.</para>
		/// </param>
		/// <param name="dwBytes">
		/// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <c>GMEM_MOVEABLE</c>, the function returns a handle to
		/// a memory object that is marked as discarded.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the newly allocated memory object.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HGLOBAL WINAPI GlobalAlloc( _In_ UINT uFlags, _In_ SIZE_T dwBytes); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366574(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366574")]
		public static extern IntPtr GlobalAlloc(GMEM uFlags, SizeT dwBytes);

		/// <summary>Retrieves information about the specified global memory object.</summary>
		/// <param name="hMem">A handle to the global memory object. This handle is returned by either the <c>GlobalAlloc</c> or <c>GlobalReAlloc</c> function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the allocation values and the lock count for the memory object.</para>
		/// <para>
		/// If the function fails, the return value is <c>GMEM_INVALID_HANDLE</c>, indicating that the global handle is not valid. To get extended error
		/// information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// UINT WINAPI GlobalFlags( _In_ HGLOBAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366577(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366577")]
		public static extern GMEM GlobalFlags([In] IntPtr hMem);

		/// <summary>Frees the specified global memory object and invalidates its handle.</summary>
		/// <param name="hMem">
		/// A handle to the global memory object. This handle is returned by either the <c>GlobalAlloc</c> or <c>GlobalReAlloc</c> function. It is not safe to
		/// free memory allocated with <c>LocalAlloc</c>.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>NULL</c>.</para>
		/// <para>If the function fails, the return value is equal to a handle to the global memory object. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HGLOBAL WINAPI GlobalFree( _In_ HGLOBAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366579(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366579")]
		public static extern IntPtr GlobalFree(IntPtr hMem);

		/// <summary>Retrieves the handle associated with the specified pointer to a global memory block.</summary>
		/// <param name="pMem">A pointer to the first byte of the global memory block. This pointer is returned by the <c>GlobalLock</c> function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the specified global memory object.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HGLOBAL WINAPI GlobalHandle( _In_ LPCVOID pMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366582(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366582")]
		public static extern IntPtr GlobalHandle([In] IntPtr pMem);

		/// <summary>
		/// The GlobalLock function locks a global memory object and returns a pointer to the first byte of the object's memory block. GlobalLock function
		/// increments the lock count by one. Needed for the clipboard functions when getting the data from IDataObject
		/// </summary>
		/// <param name="hMem"></param>
		/// <returns></returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366584")]
		public static extern IntPtr GlobalLock(IntPtr hMem);

		/// <summary>Changes the size or attributes of a specified global memory object. The size can increase or decrease.</summary>
		/// <param name="hMem">
		/// A handle to the global memory object to be reallocated. This handle is returned by either the <c>GlobalAlloc</c> or <c>GlobalReAlloc</c> function.
		/// </param>
		/// <param name="dwBytes">The new size of the memory block, in bytes. If uFlags specifies <c>GMEM_MODIFY</c>, this parameter is ignored.</param>
		/// <param name="uFlags">
		/// <para>
		/// The reallocation options. If <c>GMEM_MODIFY</c> is specified, the function modifies the attributes of the memory object only (the dwBytes parameter
		/// is ignored.) Otherwise, the function reallocates the memory object.
		/// </para>
		/// <para>You can optionally combine <c>GMEM_MODIFY</c> with the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GMEM_MOVEABLE0x0002</term>
		/// <term>
		/// Allocates movable memory.If the memory is a locked GMEM_MOVEABLE memory block or a GMEM_FIXED memory block and this flag is not specified, the memory
		/// can only be reallocated in place.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>If this parameter does not specify <c>GMEM_MODIFY</c>, you can use the following value.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>GMEM_ZEROINIT0x0040</term>
		/// <term>Causes the additional memory contents to be initialized to zero if the memory object is growing in size.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the reallocated memory object.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HGLOBAL WINAPI GlobalReAlloc( _In_ HGLOBAL hMem, _In_ SIZE_T dwBytes, _In_ UINT uFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366590(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366590")]
		public static extern IntPtr GlobalReAlloc([In] IntPtr hMem, SizeT dwBytes, GMEM uFlags);

		/// <summary>Retrieves the current size of the specified global memory object, in bytes.</summary>
		/// <param name="hMem">A handle to the global memory object. This handle is returned by either the <c>GlobalAlloc</c> or <c>GlobalReAlloc</c> function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is the size of the specified global memory object, in bytes.</para>
		/// <para>
		/// If the specified handle is not valid or if the object has been discarded, the return value is zero. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// SIZE_T WINAPI GlobalSize( _In_ HGLOBAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366593(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366593")]
		public static extern SizeT GlobalSize([In] IntPtr hMem);

		/// <summary>The GlobalUnlock function decrements the lock count associated with a memory object.</summary>
		/// <param name="hMem"></param>
		/// <returns></returns>
		[DllImport(Lib.Kernel32, ExactSpelling = true, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366595")]
		public static extern bool GlobalUnlock(IntPtr hMem);

		/// <summary>Determines whether the calling process has read access to the memory at the specified address.</summary>
		/// <param name="lpfn">A pointer to a memory address.</param>
		/// <returns>
		/// <para>If the calling process has read access to the specified memory, the return value is zero.</para>
		/// <para>
		/// If the calling process does not have read access to the specified memory, the return value is nonzero. To get extended error information, call <c>GetLastError</c>.
		/// </para>
		/// <para>
		/// If the application is compiled as a debugging version, and the process does not have read access to the specified memory location, the function
		/// causes an assertion and breaks into the debugger. Leaving the debugger, the function continues as usual, and returns a nonzero value. This behavior
		/// is by design, as a debugging aid.
		/// </para>
		/// </returns>
		// BOOL WINAPI IsBadCodePtr( _In_ FARPROC lpfn); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366712(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366712")]
		[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsBadCodePtr(IntPtr lpfn);

		/// <summary>Verifies that the calling process has read access to the specified range of memory.</summary>
		/// <param name="lp">A pointer to the first byte of the memory block.</param>
		/// <param name="ucb">The size of the memory block, in bytes. If this parameter is zero, the return value is zero.</param>
		/// <returns>
		/// <para>If the calling process has read access to all bytes in the specified memory range, the return value is zero.</para>
		/// <para>If the calling process does not have read access to all bytes in the specified memory range, the return value is nonzero.</para>
		/// <para>
		/// If the application is compiled as a debugging version, and the process does not have read access to all bytes in the specified memory range, the
		/// function causes an assertion and breaks into the debugger. Leaving the debugger, the function continues as usual, and returns a nonzero value. This
		/// behavior is by design, as a debugging aid.
		/// </para>
		/// </returns>
		// BOOL WINAPI IsBadReadPtr( _In_ const VOID *lp, _In_ UINT_PTR ucb); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366713(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366713")]
		[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsBadReadPtr([In] IntPtr lp, UIntPtr ucb);

		/// <summary>Verifies that the calling process has read access to the specified range of memory.</summary>
		/// <param name="lpsz">A pointer to a null-terminated string, either Unicode or ASCII.</param>
		/// <param name="ucchMax">
		/// The maximum size of the string, in <c>TCHARs</c>. The function checks for read access in all characters up to the string's terminating null character
		/// or up to the number of characters specified by this parameter, whichever is smaller. If this parameter is zero, the return value is zero.
		/// </param>
		/// <returns>
		/// <para>
		/// If the calling process has read access to all characters up to the string's terminating null character or up to the number of characters specified by
		/// ucchMax, the return value is zero.
		/// </para>
		/// <para>
		/// If the calling process does not have read access to all characters up to the string's terminating null character or up to the number of characters
		/// specified by ucchMax, the return value is nonzero.
		/// </para>
		/// <para>
		/// If the application is compiled as a debugging version, and the process does not have read access to the entire memory range specified, the function
		/// causes an assertion and breaks into the debugger. Leaving the debugger, the function continues as usual, and returns a nonzero value This behavior is
		/// by design, as a debugging aid.
		/// </para>
		/// </returns>
		// BOOL WINAPI IsBadStringPtr( _In_ LPCTSTR lpsz, _In_ UINT_PTR ucchMax); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366714(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366714")]
		[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsBadStringPtr([In] string lpsz, UIntPtr ucchMax);

		/// <summary>Verifies that the calling process has write access to the specified range of memory.</summary>
		/// <param name="lp">A pointer to the first byte of the memory block.</param>
		/// <param name="ucb">The size of the memory block, in bytes. If this parameter is zero, the return value is zero.</param>
		/// <returns>
		/// <para>If the calling process has write access to all bytes in the specified memory range, the return value is zero.</para>
		/// <para>If the calling process does not have write access to all bytes in the specified memory range, the return value is nonzero.</para>
		/// <para>
		/// If the application is run under a debugger and the process does not have write access to all bytes in the specified memory range, the function causes
		/// a first chance STATUS_ACCESS_VIOLATION exception. The debugger can be configured to break for this condition. After resuming process execution in the
		/// debugger, the function continues as usual and returns a nonzero value This behavior is by design and serves as a debugging aid.
		/// </para>
		/// </returns>
		// BOOL WINAPI IsBadWritePtr( _In_ LPVOID lp, _In_ UINT_PTR ucb); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366716(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366716")]
		[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsBadWritePtr([In] IntPtr lp, UIntPtr ucb);

		/// <summary>
		/// Allocates the specified number of bytes from the heap. <note>The local functions have greater overhead and provide fewer features than other memory
		/// management functions. New applications should use the heap functions unless documentation states that a local function should be used. For more
		/// information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="uFlags">
		/// The memory allocation attributes. The default is the LMEM_FIXED value. This parameter can be one or more of the following values, except for the
		/// incompatible combinations that are specifically noted.
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>
		/// <c>LHND</c>
		/// <para>0x0042</para>
		/// </term>
		/// <term>Combines LMEM_MOVEABLE and LMEM_ZEROINIT.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LMEM_FIXED</c>
		/// <para>0x0000</para>
		/// </term>
		/// <term>Allocates fixed memory. The return value is a pointer to the memory object.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LMEM_MOVEABLE</c>
		/// <para>0x0002</para>
		/// </term>
		/// <term>
		/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.
		/// <para>The return value is a handle to the memory object. To translate the handle to a pointer, use the LocalLock function.</para>
		/// <para>This value cannot be combined with LMEM_FIXED.</para>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LMEM_ZEROINIT</c>
		/// <para>0x0040</para>
		/// </term>
		/// <term>Initializes memory contents to zero.</term>
		/// </item>
		/// <item>
		/// <term>
		/// <c>LPTR</c>
		/// <para>0x0040</para>
		/// </term>
		/// <term>Combines LMEM_FIXED and LMEM_ZEROINIT.</term>
		/// </item>
		/// <item>
		/// <term><c>NONZEROLHND</c></term>
		/// <term>Same as LMEM_MOVEABLE.</term>
		/// </item>
		/// <item>
		/// <term><c>NONZEROLPTR</c></term>
		/// <term>Same as LMEM_FIXED.</term>
		/// </item>
		/// </list>
		/// <para>The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>LMEM_DISCARDABLE</term>
		/// </item>
		/// <item>
		/// <term>LMEM_NOCOMPACT</term>
		/// </item>
		/// <item>
		/// <term>LMEM_NODISCARD</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="uBytes">
		/// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies LMEM_MOVEABLE, the function returns a handle to a
		/// memory object that is marked as discarded.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL. To get
		/// extended error information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// Windows memory management does not provide a separate local heap and global heap. Therefore, the LocalAlloc and GlobalAlloc functions are essentially
		/// the same.
		/// <para>
		/// The movable-memory flags LHND, LMEM_MOVABLE, and NONZEROLHND add unnecessary overhead and require locking to be used safely. They should be avoided
		/// unless documentation specifically states that they should be used.
		/// </para>
		/// <para>
		/// New applications should use the heap functions unless the documentation specifically states that a local function should be used. For example, some
		/// Windows functions allocate memory that must be freed with LocalFree.
		/// </para>
		/// <para>
		/// If the heap does not contain sufficient free space to satisfy the request, LocalAlloc returns NULL. Because NULL is used to indicate an error,
		/// virtual address zero is never allocated. It is, therefore, easy to detect the use of a NULL pointer.
		/// </para>
		/// <para>
		/// If the LocalAlloc function succeeds, it allocates at least the amount requested. If the amount allocated is greater than the amount requested, the
		/// process can use the entire amount. To determine the actual number of bytes allocated, use the LocalSize function.
		/// </para>
		/// <para>To free the memory, use the LocalFree function. It is not safe to free memory allocated with LocalAlloc using GlobalFree.</para>
		/// </remarks>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366723")]
		public static extern IntPtr LocalAlloc(LMEM uFlags, UIntPtr uBytes);

		/// <summary>Retrieves information about the specified local memory object.</summary>
		/// <param name="hMem">A handle to the local memory object. This handle is returned by either the <c>LocalAlloc</c> or <c>LocalReAlloc</c> function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value specifies the allocation values and the lock count for the memory object.</para>
		/// <para>
		/// If the function fails, the return value is <c>LMEM_INVALID_HANDLE</c>, indicating that the local handle is not valid. To get extended error
		/// information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// UINT WINAPI LocalFlags( _In_ HLOCAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366728(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366728")]
		public static extern LMEM LocalFlags([In] IntPtr hMem);

		/// <summary>
		/// Frees the specified local memory object and invalidates its handle. <note>The local functions have greater overhead and provide fewer features than
		/// other memory management functions. New applications should use the heap functions unless documentation states that a local function should be used.
		/// For more information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="hMem">
		/// A handle to the local memory object. This handle is returned by either the LocalAlloc or LocalReAlloc function. It is not safe to free memory
		/// allocated with GlobalAlloc.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is NULL. If the function fails, the return value is equal to a handle to the local memory object. To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366730")]
		public static extern IntPtr LocalFree(IntPtr hMem);

		/// <summary>Retrieves the handle associated with the specified pointer to a local memory object.</summary>
		/// <param name="pMem">A pointer to the first byte of the local memory object. This pointer is returned by the <c>LocalLock</c> function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a handle to the specified local memory object.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// HLOCAL WINAPI LocalHandle( _In_ LPCVOID pMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366733(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366733")]
		public static extern IntPtr LocalHandle([In] IntPtr pMem);

		/// <summary>Locks a local memory object and returns a pointer to the first byte of the object's memory block.</summary>
		/// <param name="hMem">A handle to the local memory object. This handle is returned by either the <c>LocalAlloc</c> or <c>LocalReAlloc</c> function.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is a pointer to the first byte of the memory block.</para>
		/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// LPVOID WINAPI LocalLock( _In_ HLOCAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366737(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366737")]
		public static extern IntPtr LocalLock([In] IntPtr hMem);

		/// <summary>
		/// Changes the size or the attributes of a specified local memory object. The size can increase or decrease. <note>The local functions have greater
		/// overhead and provide fewer features than other memory management functions. New applications should use the heap functions unless documentation
		/// states that a local function should be used. For more information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="hMem">A handle to the local memory object to be reallocated. This handle is returned by either the LocalAlloc or LocalReAlloc function.</param>
		/// <param name="uBytes">The new size of the memory block, in bytes. If uFlags specifies LMEM_MODIFY, this parameter is ignored.</param>
		/// <param name="uFlags">
		/// The reallocation options. If LMEM_MODIFY is specified, the function modifies the attributes of the memory object only (the uBytes parameter is
		/// ignored.) Otherwise, the function reallocates the memory object.
		/// <para>You can optionally combine LMEM_MODIFY with the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>
		/// <c>LMEM_MOVEABLE</c>
		/// <para>0x0002</para>
		/// </term>
		/// <term>
		/// Allocates fixed or movable memory.
		/// <para>
		/// If the memory is a locked LMEM_MOVEABLE memory block or a LMEM_FIXED memory block and this flag is not specified, the memory can only be reallocated
		/// in place.
		/// </para>
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// If the memory is a locked LMEM_MOVEABLE memory block or a LMEM_FIXED memory block and this flag is not specified, the memory can only be reallocated
		/// in place.
		/// </para>
		/// <para>If this parameter does not specify LMEM_MODIFY, you can use the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>
		/// <c>LMEM_ZEROINIT</c>
		/// <para>0x0040</para>
		/// </term>
		/// <term>Causes the additional memory contents to be initialized to zero if the memory object is growing in size.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the reallocated memory object. If the function fails, the return value is NULL. To get
		/// extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366742")]
		public static extern IntPtr LocalReAlloc(IntPtr hMem, UIntPtr uBytes, LMEM uFlags);

		/// <summary>
		/// Retrieves the current size of the specified local memory object, in bytes. <note>The local functions have greater overhead and provide fewer features
		/// than other memory management functions. New applications should use the heap functions unless documentation states that a local function should be
		/// used. For more information, see Global and Local Functions.</note>
		/// </summary>
		/// <param name="hMem">A handle to the local memory object. This handle is returned by the LocalAlloc, LocalReAlloc, or LocalHandle function.</param>
		/// <returns>
		/// If the function succeeds, the return value is the size of the specified local memory object, in bytes. If the specified handle is not valid or if the
		/// object has been discarded, the return value is zero. To get extended error information, call GetLastError.
		/// </returns>
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366745")]
		public static extern uint LocalSize(IntPtr hMem);

		/// <summary>
		/// Decrements the lock count associated with a memory object that was allocated with <c>LMEM_MOVEABLE</c>. This function has no effect on memory objects
		/// allocated with <c>LMEM_FIXED</c>.
		/// </summary>
		/// <param name="hMem">A handle to the local memory object. This handle is returned by either the <c>LocalAlloc</c> or <c>LocalReAlloc</c> function.</param>
		/// <returns>
		/// <para>
		/// If the memory object is still locked after decrementing the lock count, the return value is nonzero. If the memory object is unlocked after
		/// decrementing the lock count, the function returns zero and <c>GetLastError</c> returns <c>NO_ERROR</c>.
		/// </para>
		/// <para>If the function fails, the return value is zero and <c>GetLastError</c> returns a value other than <c>NO_ERROR</c>.</para>
		/// </returns>
		// BOOL WINAPI LocalUnlock( _In_ HLOCAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366747(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366747")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool LocalUnlock([In] IntPtr hMem);

		/// <summary>
		/// <para>Maps previously allocated physical memory pages at a specified address in an Address Windowing Extensions (AWE) region.</para>
		/// <para>
		/// <c>64-bit Windows on Itanium-based systems:</c> Due to the difference in page sizes, <c>MapUserPhysicalPagesScatter</c> is not supported for 32-bit applications.
		/// </para>
		/// </summary>
		/// <param name="VirtualAddresses">
		/// <para>A pointer to an array of starting addresses of the regions of memory to remap.</para>
		/// <para>
		/// Each entry in VirtualAddresses must be within the address range that the <c>VirtualAlloc</c> function returns when the Address Windowing Extensions
		/// (AWE) region is allocated. The value in NumberOfPages indicates the size of the array. Entries can be from multiple Address Windowing Extensions
		/// (AWE) regions.
		/// </para>
		/// </param>
		/// <param name="NumberOfPages">
		/// <para>The size of the physical memory and virtual address space for which to establish translations, in pages.</para>
		/// <para>The array at VirtualAddresses specifies the virtual address range.</para>
		/// </param>
		/// <param name="PageArray">
		/// <para>A pointer to an array of values that indicates how each corresponding page in VirtualAddresses should be treated.</para>
		/// <para>A 0 (zero) indicates that the corresponding entry in VirtualAddresses should be unmapped, and any nonzero value that it has should be mapped.</para>
		/// <para>If this parameter is <c>NULL</c>, then every address in the VirtualAddresses array is unmapped.</para>
		/// <para>The value in NumberOfPages indicates the size of the array.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>
		/// If the function fails, the return value is <c>FALSE</c>, and the function does not map or unmap—partial or otherwise. To get extended error
		/// information, call <c>GetLastError</c>.
		/// </para>
		/// </returns>
		// BOOL WINAPI MapUserPhysicalPagesScatter( _In_ PVOID *VirtualAddresses, _In_ ULONG_PTR NumberOfPages, _In_ PULONG_PTR PageArray); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366755(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366755")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool MapUserPhysicalPagesScatter(IntPtr VirtualAddresses, UIntPtr NumberOfPages, [In] IntPtr PageArray);

		/// <summary>Changes the protection on a region of committed pages in the virtual address space of a specified process.</summary>
		/// <param name="hProcess">
		/// A handle to the process whose memory protection is to be changed. The handle must have the <c>PROCESS_VM_OPERATION</c> access right. For more
		/// information, see Process Security and Access Rights.
		/// </param>
		/// <param name="lpAddress">
		/// <para>A pointer to the base address of the region of pages whose access protection attributes are to be changed.</para>
		/// <para>
		/// All pages in the specified region must be within the same reserved region allocated when calling the <c>VirtualAlloc</c> or <c>VirtualAllocEx</c>
		/// function using <c>MEM_RESERVE</c>. The pages cannot span adjacent reserved regions that were allocated by separate calls to <c>VirtualAlloc</c> or
		/// <c>VirtualAllocEx</c> using <c>MEM_RESERVE</c>.
		/// </para>
		/// </param>
		/// <param name="dwSize">
		/// The size of the region whose access protection attributes are changed, in bytes. The region of affected pages includes all pages containing one or
		/// more bytes in the range from the lpAddress parameter to . This means that a 2-byte range straddling a page boundary causes the protection attributes
		/// of both pages to be changed.
		/// </param>
		/// <param name="flNewProtect">
		/// <para>The memory protection option. This parameter can be one of the memory protection constants.</para>
		/// <para>
		/// For mapped views, this value must be compatible with the access protection specified when the view was mapped (see <c>MapViewOfFile</c>,
		/// <c>MapViewOfFileEx</c>, and <c>MapViewOfFileExNuma</c>).
		/// </para>
		/// </param>
		/// <param name="lpflOldProtect">
		/// A pointer to a variable that receives the previous access protection of the first page in the specified region of pages. If this parameter is
		/// <c>NULL</c> or does not point to a valid variable, the function fails.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
		/// </returns>
		// BOOL WINAPI VirtualProtectEx( _In_ HANDLE hProcess, _In_ LPVOID lpAddress, _In_ SIZE_T dwSize, _In_ DWORD flNewProtect, _Out_ PDWORD lpflOldProtect); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366899(v=vs.85).aspx
		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("WinBase.h", MSDNShortId = "aa366899")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool VirtualProtectEx([In] IntPtr hProcess, [In] IntPtr lpAddress, SizeT dwSize, uint flNewProtect, out uint lpflOldProtect);
	}
}