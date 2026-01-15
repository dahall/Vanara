using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>
	/// Allocates and locks the specified number of bytes from the heap returning a pointer to the to the first byte of the global memory lock.
	/// </summary>
	/// <param name="flags">The memory allocation attributes.</param>
	/// <param name="cb">
	/// The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <c>GMEM_MOVEABLE</c>, the function
	/// returns a handle to a memory object that is marked as discarded.
	/// </param>
	/// <returns>A pointer to the to the first byte of the global memory lock.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IntPtr GlobalAllocPtr(GMEM flags, SIZE_T cb) => GlobalLock(GlobalAlloc(flags, cb));

	/// <summary>Frees the specified locked global memory block and invalidates its handle.</summary>
	/// <param name="lp">A pointer to a locked global memory block to be freed.</param>
	/// <returns><see langword="true"/> if pointer was unlocked and freed; otherwise <see langword="false"/>.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GlobalFreePtr(IntPtr lp)
	{ GlobalUnlockPtr(lp); return !GlobalFree(GlobalPtrHandle(lp)).IsNull; }

	/// <summary>Locks a pointer to a global memory block.</summary>
	/// <param name="lp">A pointer to the first byte of the global memory block. This pointer is returned by the <c>GlobalLock</c> function.</param>
	/// <returns><see langword="true"/> if pointer was locked; otherwise <see langword="false"/>.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GlobalLockPtr(IntPtr lp) => GlobalLock(GlobalPtrHandle(lp)) != IntPtr.Zero;

	/// <summary>Retrieves the handle associated with the specified pointer to a global memory block.</summary>
	/// <param name="lp">A pointer to the first byte of the global memory block. This pointer is returned by the <c>GlobalLock</c> function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified global memory object.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static HGLOBAL GlobalPtrHandle(IntPtr lp) => GlobalHandle(lp);

	/// <summary>
	/// Changes the size or attributes of a specified global memory block. The size can increase or decrease. Returns a pointer to a locked
	/// global memory block.
	/// </summary>
	/// <param name="lp">A pointer to a locked global memory block to be reallocated.</param>
	/// <param name="cbNew">The new size of the memory block, in bytes. If flags specifies <c>GMEM_MODIFY</c>, this parameter is ignored.</param>
	/// <param name="flags">
	/// The reallocation options. If <c>GMEM_MODIFY</c> is specified, the function modifies the attributes of the memory object only (the
	/// dwBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
	/// </param>
	/// <returns>A pointer to the to the first byte of the reallocated global memory lock.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IntPtr GlobalReAllocPtr(IntPtr lp, SIZE_T cbNew, GMEM flags)
	{ GlobalUnlockPtr(lp); return GlobalLock(GlobalReAlloc(GlobalPtrHandle(lp), cbNew, flags)); }

	/// <summary>Unlocks a pointer to a global memory block.</summary>
	/// <param name="lp">A pointer to the first byte of the global memory block. This pointer is returned by the <c>GlobalLock</c> function.</param>
	/// <returns><see langword="true"/> if pointer was unlocked; otherwise <see langword="false"/>.</returns>
	[PInvokeData("windowsx.h")]
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool GlobalUnlockPtr(IntPtr lp) => GlobalUnlock(GlobalPtrHandle(lp));
}