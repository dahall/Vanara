namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The memory allocation attributes.</summary>
	[Flags]
	public enum GMEM
	{
		/// <summary>Combines GMEM_MOVEABLE and GMEM_ZEROINIT.</summary>
		GHND = GMEM_MOVEABLE | GMEM_ZEROINIT,

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
		GPTR = GMEM_FIXED | GMEM_ZEROINIT,

		/// <summary>
		/// The function modifies the attributes of the memory object only (the dwBytes parameter is ignored). This value can only be
		/// used with <see cref="GlobalReAlloc"/>.
		/// </summary>
		GMEM_MODIFY = 0x0080,

		/// <summary>Allocate discardable memory.</summary>
		[Obsolete("Value is obsolete, but is provided for compatibility with 16-bit Windows.")]
		GMEM_DISCARDABLE = 0x0100,

		/// <summary>Allocate non-banked memory.</summary>
		[Obsolete("Value is obsolete, but is provided for compatibility with 16-bit Windows.")]
		GMEM_NOT_BANKED = 0x1000,

		/// <summary>Allocate sharable memory.</summary>
		GMEM_SHARE = 0x2000,

		/// <summary>Notify upon discarding</summary>
		[Obsolete("Value is obsolete, but is provided for compatibility with 16-bit Windows.")]
		GMEM_NOTIFY = 0x4000,

		/// <summary>Allocate non-banked memory.</summary>
		[Obsolete("Value is obsolete, but is provided for compatibility with 16-bit Windows.")]
		GMEM_LOWER = GMEM_NOT_BANKED,
	}

	/// <summary>The memory allocation attributes.</summary>
	[PInvokeData("MinWinBase.h")]
	[Flags]
	public enum LMEM
	{
		/// <summary>Allocates fixed memory. The return value is a pointer to the memory object.</summary>
		LMEM_FIXED = 0x0000,

		/// <summary>
		/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.
		/// The return value is a handle to the memory object. To translate the handle to a pointer, use the LocalLock function. This
		/// value cannot be combined with LMEM_FIXED.
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
		/// If the LMEM_MODIFY flag is specified in LocalReAlloc, this parameter modifies the attributes of the memory object, and the
		/// uBytes parameter is ignored.
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
		LHND = LMEM_MOVEABLE | LMEM_ZEROINIT,

		/// <summary>Combines LMEM_FIXED and LMEM_ZEROINIT.</summary>
		LPTR = LMEM_FIXED | LMEM_ZEROINIT,

		/// <summary>Same as LMEM_MOVEABLE.</summary>
		NONZEROLHND = LMEM_MOVEABLE,

		/// <summary>Same as LMEM_FIXED.</summary>
		NONZEROLPTR = LMEM_FIXED
	}

	/// <summary>Allocates the specified number of bytes from the heap.</summary>
	/// <param name="uFlags">
	/// <para>
	/// The memory allocation attributes. If zero is specified, the default is <c>GMEM_FIXED</c>. This parameter can be one or more of
	/// the following values, except for the incompatible combinations that are specifically noted.
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
	/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.The
	/// return value is a handle to the memory object. To translate the handle into a pointer, use the GlobalLock function.This value
	/// cannot be combined with GMEM_FIXED.
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
	/// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <c>GMEM_MOVEABLE</c>, the function
	/// returns a handle to a memory object that is marked as discarded.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the newly allocated memory object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HGLOBAL WINAPI GlobalAlloc( _In_ UINT uFlags, _In_ SIZE_T dwBytes); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366574(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366574")]
	public static extern HGLOBAL GlobalAlloc(GMEM uFlags, SIZE_T dwBytes);

	/// <summary>Retrieves information about the specified global memory object.</summary>
	/// <param name="hMem">
	/// A handle to the global memory object. This handle is returned by either the <c>GlobalAlloc</c> or <c>GlobalReAlloc</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the allocation values and the lock count for the memory object.</para>
	/// <para>
	/// If the function fails, the return value is <c>GMEM_INVALID_HANDLE</c>, indicating that the global handle is not valid. To get
	/// extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// UINT WINAPI GlobalFlags( _In_ HGLOBAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366577(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366577")]
	public static extern GMEM GlobalFlags([In, AddAsMember] HGLOBAL hMem);

	/// <summary>Frees the specified global memory object and invalidates its handle.</summary>
	/// <param name="hMem">
	/// A handle to the global memory object. This handle is returned by either the <c>GlobalAlloc</c> or <c>GlobalReAlloc</c> function.
	/// It is not safe to free memory allocated with <c>LocalAlloc</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NULL</c>.</para>
	/// <para>
	/// If the function fails, the return value is equal to a handle to the global memory object. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// HGLOBAL WINAPI GlobalFree( _In_ HGLOBAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366579(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366579")]
	public static extern HGLOBAL GlobalFree(HGLOBAL hMem);

	/// <summary>Retrieves the handle associated with the specified pointer to a global memory block.</summary>
	/// <param name="pMem">
	/// A pointer to the first byte of the global memory block. This pointer is returned by the <c>GlobalLock</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified global memory object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HGLOBAL WINAPI GlobalHandle( _In_ LPCVOID pMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366582(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366582")]
	public static extern HGLOBAL GlobalHandle([In] IntPtr pMem);

	/// <summary>
	/// <para>Locks a global memory object and returns a pointer to the first byte of the object's memory block.</para>
	/// <para>
	/// <c>Note</c> The global functions have greater overhead and provide fewer features than other memory management functions. New
	/// applications should use the heap functions unless documentation states that a global function should be used. For more
	/// information, see Global and Local Functions.
	/// </para>
	/// </summary>
	/// <param name="hMem">
	/// <para>A handle to the global memory object. This handle is returned by either the GlobalAlloc or GlobalReAlloc function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the first byte of the memory block.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The internal data structures for each memory object include a lock count that is initially zero. For movable memory objects,
	/// <c>GlobalLock</c> increments the count by one, and the GlobalUnlock function decrements the count by one. Each successful call
	/// that a process makes to <c>GlobalLock</c> for an object must be matched by a corresponding call to <c>GlobalUnlock</c>. Locked
	/// memory will not be moved or discarded, unless the memory object is reallocated by using the GlobalReAlloc function. The memory
	/// block of a locked memory object remains locked until its lock count is decremented to zero, at which time it can be moved or discarded.
	/// </para>
	/// <para>
	/// Memory objects allocated with <c>GMEM_FIXED</c> always have a lock count of zero. For these objects, the value of the returned
	/// pointer is equal to the value of the specified handle.
	/// </para>
	/// <para>If the specified memory block has been discarded or if the memory block has a zero-byte size, this function returns <c>NULL</c>.</para>
	/// <para>Discarded objects always have a lock count of zero.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-globallock LPVOID GlobalLock( HGLOBAL hMem );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "0d7deac2-c9c4-4adc-8a0a-edfc512a4d6c")]
	public static extern IntPtr GlobalLock([In, AddAsMember] HGLOBAL hMem);

	/// <summary>Changes the size or attributes of a specified global memory object. The size can increase or decrease.</summary>
	/// <param name="hMem">
	/// A handle to the global memory object to be reallocated. This handle is returned by either the <c>GlobalAlloc</c> or
	/// <c>GlobalReAlloc</c> function.
	/// </param>
	/// <param name="dwBytes">
	/// The new size of the memory block, in bytes. If uFlags specifies <c>GMEM_MODIFY</c>, this parameter is ignored.
	/// </param>
	/// <param name="uFlags">
	/// <para>
	/// The reallocation options. If <c>GMEM_MODIFY</c> is specified, the function modifies the attributes of the memory object only (the
	/// dwBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
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
	/// Allocates movable memory.If the memory is a locked GMEM_MOVEABLE memory block or a GMEM_FIXED memory block and this flag is not
	/// specified, the memory can only be reallocated in place.
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
	public static extern HGLOBAL GlobalReAlloc([In, AddAsMember] HGLOBAL hMem, SIZE_T dwBytes, GMEM uFlags);

	/// <summary>Retrieves the current size of the specified global memory object, in bytes.</summary>
	/// <param name="hMem">
	/// A handle to the global memory object. This handle is returned by either the <c>GlobalAlloc</c> or <c>GlobalReAlloc</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the size of the specified global memory object, in bytes.</para>
	/// <para>
	/// If the specified handle is not valid or if the object has been discarded, the return value is zero. To get extended error
	/// information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// SIZE_T WINAPI GlobalSize( _In_ HGLOBAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366593(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366593")]
	public static extern SIZE_T GlobalSize([In, AddAsMember] HGLOBAL hMem);

	/// <summary>
	/// <para>
	/// Decrements the lock count associated with a memory object that was allocated with <c>GMEM_MOVEABLE</c>. This function has no
	/// effect on memory objects allocated with <c>GMEM_FIXED</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The global functions have greater overhead and provide fewer features than other memory management functions. New
	/// applications should use the heap functions unless documentation states that a global function should be used. For more
	/// information, see Global and Local Functions.
	/// </para>
	/// </summary>
	/// <param name="hMem">
	/// <para>A handle to the global memory object. This handle is returned by either the GlobalAlloc or GlobalReAlloc function.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the memory object is still locked after decrementing the lock count, the return value is a nonzero value. If the memory object
	/// is unlocked after decrementing the lock count, the function returns zero and GetLastError returns <c>NO_ERROR</c>.
	/// </para>
	/// <para>If the function fails, the return value is zero and GetLastError returns a value other than <c>NO_ERROR</c>.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The internal data structures for each memory object include a lock count that is initially zero. For movable memory objects, the
	/// GlobalLock function increments the count by one, and <c>GlobalUnlock</c> decrements the count by one. For each call that a
	/// process makes to <c>GlobalLock</c> for an object, it must eventually call <c>GlobalUnlock</c>. Locked memory will not be moved or
	/// discarded, unless the memory object is reallocated by using the GlobalReAlloc function. The memory block of a locked memory
	/// object remains locked until its lock count is decremented to zero, at which time it can be moved or discarded.
	/// </para>
	/// <para>
	/// Memory objects allocated with <c>GMEM_FIXED</c> always have a lock count of zero. If the specified memory block is fixed memory,
	/// this function returns <c>TRUE</c>.
	/// </para>
	/// <para>If the memory object is already unlocked, <c>GlobalUnlock</c> returns <c>FALSE</c> and GetLastError reports <c>ERROR_NOT_LOCKED</c>.</para>
	/// <para>
	/// A process should not rely on the return value to determine the number of times it must subsequently call <c>GlobalUnlock</c> for
	/// a memory object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-globalunlock BOOL GlobalUnlock( HGLOBAL hMem );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "580a2873-7f06-47a1-acf5-c2b3c96e15e7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GlobalUnlock([In, AddAsMember] HGLOBAL hMem);

	/// <summary>Determines whether the calling process has read access to the memory at the specified address.</summary>
	/// <param name="lpfn">A pointer to a memory address.</param>
	/// <returns>
	/// <para>If the calling process has read access to the specified memory, the return value is zero.</para>
	/// <para>
	/// If the calling process does not have read access to the specified memory, the return value is nonzero. To get extended error
	/// information, call <c>GetLastError</c>.
	/// </para>
	/// <para>
	/// If the application is compiled as a debugging version, and the process does not have read access to the specified memory
	/// location, the function causes an assertion and breaks into the debugger. Leaving the debugger, the function continues as usual,
	/// and returns a nonzero value. This behavior is by design, as a debugging aid.
	/// </para>
	/// </returns>
	// BOOL WINAPI IsBadCodePtr( _In_ FARPROC lpfn); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366712(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366712")]
	[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsBadCodePtr([In] IntPtr lpfn);

	/// <summary>Verifies that the calling process has read access to the specified range of memory.</summary>
	/// <param name="lp">A pointer to the first byte of the memory block.</param>
	/// <param name="ucb">The size of the memory block, in bytes. If this parameter is zero, the return value is zero.</param>
	/// <returns>
	/// <para>If the calling process has read access to all bytes in the specified memory range, the return value is zero.</para>
	/// <para>If the calling process does not have read access to all bytes in the specified memory range, the return value is nonzero.</para>
	/// <para>
	/// If the application is compiled as a debugging version, and the process does not have read access to all bytes in the specified
	/// memory range, the function causes an assertion and breaks into the debugger. Leaving the debugger, the function continues as
	/// usual, and returns a nonzero value. This behavior is by design, as a debugging aid.
	/// </para>
	/// </returns>
	// BOOL WINAPI IsBadReadPtr( _In_ const VOID *lp, _In_ UINT_PTR ucb); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366713(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366713")]
	[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsBadReadPtr([In] IntPtr lp, SIZE_T ucb);

	/// <summary>Verifies that the calling process has read access to the specified range of memory.</summary>
	/// <param name="lpsz">A pointer to a null-terminated string, either Unicode or ASCII.</param>
	/// <param name="ucchMax">
	/// The maximum size of the string, in <c>TCHARs</c>. The function checks for read access in all characters up to the string's
	/// terminating null character or up to the number of characters specified by this parameter, whichever is smaller. If this parameter
	/// is zero, the return value is zero.
	/// </param>
	/// <returns>
	/// <para>
	/// If the calling process has read access to all characters up to the string's terminating null character or up to the number of
	/// characters specified by ucchMax, the return value is zero.
	/// </para>
	/// <para>
	/// If the calling process does not have read access to all characters up to the string's terminating null character or up to the
	/// number of characters specified by ucchMax, the return value is nonzero.
	/// </para>
	/// <para>
	/// If the application is compiled as a debugging version, and the process does not have read access to the entire memory range
	/// specified, the function causes an assertion and breaks into the debugger. Leaving the debugger, the function continues as usual,
	/// and returns a nonzero value This behavior is by design, as a debugging aid.
	/// </para>
	/// </returns>
	// BOOL WINAPI IsBadStringPtr( _In_ LPCTSTR lpsz, _In_ UINT_PTR ucchMax); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366714(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366714")]
	[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsBadStringPtr([In] IntPtr lpsz, SIZE_T ucchMax);

	/// <summary>Verifies that the calling process has write access to the specified range of memory.</summary>
	/// <param name="lp">A pointer to the first byte of the memory block.</param>
	/// <param name="ucb">The size of the memory block, in bytes. If this parameter is zero, the return value is zero.</param>
	/// <returns>
	/// <para>If the calling process has write access to all bytes in the specified memory range, the return value is zero.</para>
	/// <para>If the calling process does not have write access to all bytes in the specified memory range, the return value is nonzero.</para>
	/// <para>
	/// If the application is run under a debugger and the process does not have write access to all bytes in the specified memory range,
	/// the function causes a first chance STATUS_ACCESS_VIOLATION exception. The debugger can be configured to break for this condition.
	/// After resuming process execution in the debugger, the function continues as usual and returns a nonzero value This behavior is by
	/// design and serves as a debugging aid.
	/// </para>
	/// </returns>
	// BOOL WINAPI IsBadWritePtr( _In_ LPVOID lp, _In_ UINT_PTR ucb); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366716(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366716")]
	[Obsolete("This function is obsolete and should not be used. Despite its name, it does not guarantee that the pointer is valid or that the memory pointed to is safe to use.")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsBadWritePtr([In] IntPtr lp, SIZE_T ucb);

	/// <summary>
	/// <para>Allocates the specified number of bytes from the heap.</para>
	/// <para>
	/// <c>Note</c> The local functions have greater overhead and provide fewer features than other memory management functions. New
	/// applications should use the heap functions unless documentation states that a local function should be used. For more
	/// information, see Global and Local Functions.
	/// </para>
	/// </summary>
	/// <param name="uFlags">
	/// <para>
	/// The memory allocation attributes. The default is the <c>LMEM_FIXED</c> value. This parameter can be one or more of the following
	/// values, except for the incompatible combinations that are specifically noted.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LHND 0x0042</term>
	/// <term>Combines LMEM_MOVEABLE and LMEM_ZEROINIT.</term>
	/// </item>
	/// <item>
	/// <term>LMEM_FIXED 0x0000</term>
	/// <term>Allocates fixed memory. The return value is a pointer to the memory object.</term>
	/// </item>
	/// <item>
	/// <term>LMEM_MOVEABLE 0x0002</term>
	/// <term>
	/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap. The
	/// return value is a handle to the memory object. To translate the handle to a pointer, use the LocalLock function. This value
	/// cannot be combined with LMEM_FIXED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>LMEM_ZEROINIT 0x0040</term>
	/// <term>Initializes memory contents to zero.</term>
	/// </item>
	/// <item>
	/// <term>LPTR 0x0040</term>
	/// <term>Combines LMEM_FIXED and LMEM_ZEROINIT.</term>
	/// </item>
	/// <item>
	/// <term>NONZEROLHND</term>
	/// <term>Same as LMEM_MOVEABLE.</term>
	/// </item>
	/// <item>
	/// <term>NONZEROLPTR</term>
	/// <term>Same as LMEM_FIXED.</term>
	/// </item>
	/// </list>
	/// <para>The following values are obsolete, but are provided for compatibility with 16-bit Windows. They are ignored.</para>
	/// </param>
	/// <param name="uBytes">
	/// <para>
	/// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <c>LMEM_MOVEABLE</c>, the function
	/// returns a handle to a memory object that is marked as discarded.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the newly allocated memory object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Windows memory management does not provide a separate local heap and global heap. Therefore, the <c>LocalAlloc</c> and
	/// GlobalAlloc functions are essentially the same.
	/// </para>
	/// <para>
	/// The movable-memory flags <c>LHND</c>, <c>LMEM_MOVABLE</c>, and <c>NONZEROLHND</c> add unnecessary overhead and require locking to
	/// be used safely. They should be avoided unless documentation specifically states that they should be used.
	/// </para>
	/// <para>
	/// New applications should use the heap functions unless the documentation specifically states that a local function should be used.
	/// For example, some Windows functions allocate memory that must be freed with LocalFree.
	/// </para>
	/// <para>
	/// If the heap does not contain sufficient free space to satisfy the request, <c>LocalAlloc</c> returns <c>NULL</c>. Because
	/// <c>NULL</c> is used to indicate an error, virtual address zero is never allocated. It is, therefore, easy to detect the use of a
	/// <c>NULL</c> pointer.
	/// </para>
	/// <para>
	/// If the <c>LocalAlloc</c> function succeeds, it allocates at least the amount requested. If the amount allocated is greater than
	/// the amount requested, the process can use the entire amount. To determine the actual number of bytes allocated, use the LocalSize function.
	/// </para>
	/// <para>To free the memory, use the LocalFree function. It is not safe to free memory allocated with <c>LocalAlloc</c> using GlobalFree.</para>
	/// <para>Examples</para>
	/// <para>The following code shows a simple use of <c>LocalAlloc</c> and LocalFree.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-localalloc DECLSPEC_ALLOCATOR HLOCAL LocalAlloc( UINT
	// uFlags, SIZE_T uBytes );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "da8cd2be-ff4c-4da5-813c-8759a58228c9")]
	public static extern HLOCAL LocalAlloc(LMEM uFlags, SIZE_T uBytes);

	/// <summary>Retrieves information about the specified local memory object.</summary>
	/// <param name="hMem">
	/// A handle to the local memory object. This handle is returned by either the <c>LocalAlloc</c> or <c>LocalReAlloc</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value specifies the allocation values and the lock count for the memory object.</para>
	/// <para>
	/// If the function fails, the return value is <c>LMEM_INVALID_HANDLE</c>, indicating that the local handle is not valid. To get
	/// extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// UINT WINAPI LocalFlags( _In_ HLOCAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366728(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366728")]
	public static extern LMEM LocalFlags([In, AddAsMember] HLOCAL hMem);

	/// <summary>
	/// <para>Frees the specified local memory object and invalidates its handle.</para>
	/// <para>
	/// <c>Note</c> The local functions have greater overhead and provide fewer features than other memory management functions. New
	/// applications should use the heap functions unless documentation states that a local function should be used. For more
	/// information, see Global and Local Functions.
	/// </para>
	/// </summary>
	/// <param name="hMem">
	/// <para>
	/// A handle to the local memory object. This handle is returned by either the LocalAlloc or LocalReAlloc function. It is not safe to
	/// free memory allocated with GlobalAlloc.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NULL</c>.</para>
	/// <para>
	/// If the function fails, the return value is equal to a handle to the local memory object. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the process tries to examine or modify the memory after it has been freed, heap corruption may occur or an access violation
	/// exception (EXCEPTION_ACCESS_VIOLATION) may be generated.
	/// </para>
	/// <para>If the hMem parameter is <c>NULL</c>, <c>LocalFree</c> ignores the parameter and returns <c>NULL</c>.</para>
	/// <para>
	/// The <c>LocalFree</c> function will free a locked memory object. A locked memory object has a lock count greater than zero. The
	/// LocalLock function locks a local memory object and increments the lock count by one. The LocalUnlock function unlocks it and
	/// decrements the lock count by one. To get the lock count of a local memory object, use the LocalFlags function.
	/// </para>
	/// <para>
	/// If an application is running under a debug version of the system, <c>LocalFree</c> will issue a message that tells you that a
	/// locked object is being freed. If you are debugging the application, <c>LocalFree</c> will enter a breakpoint just before freeing
	/// a locked object. This allows you to verify the intended behavior, then continue execution.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example, see LocalAlloc.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-localfree HLOCAL LocalFree( _Frees_ptr_opt_ HLOCAL hMem );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "a0393983-cb43-4dfa-91a6-d82a5fb8de12")]
	public static extern HLOCAL LocalFree(HLOCAL hMem);

	/// <summary>Retrieves the handle associated with the specified pointer to a local memory object.</summary>
	/// <param name="pMem">
	/// A pointer to the first byte of the local memory object. This pointer is returned by the <c>LocalLock</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified local memory object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// HLOCAL WINAPI LocalHandle( _In_ LPCVOID pMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366733(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366733")]
	public static extern HLOCAL LocalHandle([In] IntPtr pMem);

	/// <summary>Locks a local memory object and returns a pointer to the first byte of the object's memory block.</summary>
	/// <param name="hMem">
	/// A handle to the local memory object. This handle is returned by either the <c>LocalAlloc</c> or <c>LocalReAlloc</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a pointer to the first byte of the memory block.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// LPVOID WINAPI LocalLock( _In_ HLOCAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366737(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366737")]
	public static extern IntPtr LocalLock([In] HLOCAL hMem);

	/// <summary>
	/// <para>Changes the size or the attributes of a specified local memory object. The size can increase or decrease.</para>
	/// <para>
	/// <c>Note</c> The local functions have greater overhead and provide fewer features than other memory management functions. New
	/// applications should use the heap functions unless documentation states that a local function should be used. For more
	/// information, see Global and Local Functions.
	/// </para>
	/// </summary>
	/// <param name="hMem">
	/// <para>
	/// A handle to the local memory object to be reallocated. This handle is returned by either the LocalAlloc or <c>LocalReAlloc</c> function.
	/// </para>
	/// </param>
	/// <param name="uBytes">
	/// <para>The new size of the memory block, in bytes. If uFlags specifies <c>LMEM_MODIFY</c>, this parameter is ignored.</para>
	/// </param>
	/// <param name="uFlags">
	/// <para>
	/// The reallocation options. If <c>LMEM_MODIFY</c> is specified, the function modifies the attributes of the memory object only (the
	/// uBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
	/// </para>
	/// <para>You can optionally combine <c>LMEM_MODIFY</c> with the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LMEM_MOVEABLE 0x0002</term>
	/// <term>
	/// Allocates fixed or movable memory. If the memory is a locked LMEM_MOVEABLE memory block or a LMEM_FIXED memory block and this
	/// flag is not specified, the memory can only be reallocated in place.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If this parameter does not specify <c>LMEM_MODIFY</c>, you can use the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>LMEM_ZEROINIT 0x0040</term>
	/// <term>Causes the additional memory contents to be initialized to zero if the memory object is growing in size.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the reallocated memory object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If <c>LocalReAlloc</c> fails, the original memory is not freed, and the original handle and pointer are still valid.</para>
	/// <para>
	/// If <c>LocalReAlloc</c> reallocates a fixed object, the value of the handle returned is the address of the first byte of the
	/// memory block. To access the memory, a process can simply cast the return value to a pointer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-localrealloc DECLSPEC_ALLOCATOR HLOCAL LocalReAlloc(
	// _Frees_ptr_opt_ HLOCAL hMem, SIZE_T uBytes, UINT uFlags );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "88527ddd-e0c2-4a41-825e-d3a6df77fd2a")]
	public static extern HLOCAL LocalReAlloc([In] HLOCAL hMem, SIZE_T uBytes, LMEM uFlags);

	/// <summary>
	/// <para>Retrieves the current size of the specified local memory object, in bytes.</para>
	/// <para>
	/// <c>Note</c> The local functions have greater overhead and provide fewer features than other memory management functions. New
	/// applications should use the heap functions unless documentation states that a local function should be used. For more
	/// information, see Global and Local Functions.
	/// </para>
	/// </summary>
	/// <param name="hMem">
	/// <para>A handle to the local memory object. This handle is returned by the LocalAlloc, LocalReAlloc, or LocalHandle function.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the size of the specified local memory object, in bytes. If the specified handle is
	/// not valid or if the object has been discarded, the return value is zero. To get extended error information, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The size of a memory block may be larger than the size requested when the memory was allocated.</para>
	/// <para>
	/// To verify that the specified object's memory block has not been discarded, call the LocalFlags function before calling <c>LocalSize</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winbase/nf-winbase-localsize SIZE_T LocalSize( HLOCAL hMem );
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "d1337845-d89c-4cd5-a584-36fe0c682c1a")]
	public static extern SIZE_T LocalSize([In] HLOCAL hMem);

	/// <summary>
	/// Decrements the lock count associated with a memory object that was allocated with <c>LMEM_MOVEABLE</c>. This function has no
	/// effect on memory objects allocated with <c>LMEM_FIXED</c>.
	/// </summary>
	/// <param name="hMem">
	/// A handle to the local memory object. This handle is returned by either the <c>LocalAlloc</c> or <c>LocalReAlloc</c> function.
	/// </param>
	/// <returns>
	/// <para>
	/// If the memory object is still locked after decrementing the lock count, the return value is nonzero. If the memory object is
	/// unlocked after decrementing the lock count, the function returns zero and <c>GetLastError</c> returns <c>NO_ERROR</c>.
	/// </para>
	/// <para>If the function fails, the return value is zero and <c>GetLastError</c> returns a value other than <c>NO_ERROR</c>.</para>
	/// </returns>
	// BOOL WINAPI LocalUnlock( _In_ HLOCAL hMem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366747(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366747")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LocalUnlock([In] HLOCAL hMem);
}