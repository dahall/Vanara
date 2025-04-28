using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>Unmanaged memory methods for HGlobal.</summary>
/// <seealso cref="IMemoryMethods"/>
public sealed class HGlobalMemoryMethods : IMemoryMethods
{
	/// <inheritdoc/>
	bool ISimpleMemoryMethods.AllocZeroes => false;

	/// <summary>Gets a value indicating whether this memory supports locking.</summary>
	/// <value><see langword="true"/> if lockable; otherwise, <see langword="false"/>.</value>
	bool ISimpleMemoryMethods.Lockable => false;

	/// <summary>Static instance to methods.</summary>
	public static IMemoryMethods Instance { get; } = new HGlobalMemoryMethods();

	/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>A memory handle.</returns>
	public IntPtr AllocMem(int size) => Marshal.AllocHGlobal(size);

	/// <summary>Gets the Ansi <see cref="SecureString"/> allocation method.</summary>
	/// <param name="secureString">The secure string.</param>
	/// <returns>A memory handle.</returns>
	public IntPtr AllocSecureStringAnsi(SecureString? secureString) => secureString is null ? IntPtr.Zero : Marshal.SecureStringToGlobalAllocAnsi(secureString);

	/// <summary>Gets the Unicode <see cref="SecureString"/> allocation method.</summary>
	/// <param name="secureString">The secure string.</param>
	/// <returns>A memory handle.</returns>
	public IntPtr AllocSecureStringUni(SecureString? secureString) => secureString is null ? IntPtr.Zero : Marshal.SecureStringToGlobalAllocUnicode(secureString);

	/// <summary>Gets the Ansi string allocation method.</summary>
	/// <param name="value">The value.</param>
	/// <returns>A memory handle.</returns>
	public IntPtr AllocStringAnsi(string? value) => value is null ? IntPtr.Zero : Marshal.StringToHGlobalAnsi(value);

	/// <summary>Gets the Unicode string allocation method.</summary>
	/// <param name="value">The value.</param>
	/// <returns>A memory handle.</returns>
	public IntPtr AllocStringUni(string? value) => value is null ? IntPtr.Zero : Marshal.StringToHGlobalUni(value);

	/// <summary>Frees the memory associated with a handle.</summary>
	/// <param name="hMem">A memory handle.</param>
	public void FreeMem(IntPtr hMem) => Marshal.FreeHGlobal(hMem);

	/// <summary>Gets the Ansi <see cref="SecureString"/> free method.</summary>
	/// <param name="hMem">A memory handle.</param>
	public void FreeSecureStringAnsi(IntPtr hMem) => Marshal.ZeroFreeGlobalAllocAnsi(hMem);

	/// <summary>Gets the Unicode <see cref="SecureString"/> free method.</summary>
	/// <param name="hMem">A memory handle.</param>
	public void FreeSecureStringUni(IntPtr hMem) => Marshal.ZeroFreeGlobalAllocUnicode(hMem);

	/// <summary>Locks the memory of a specified handle and gets a pointer to it.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <returns>A pointer to the locked memory.</returns>
	public IntPtr LockMem(IntPtr hMem) => hMem;

	/// <summary>Gets the reallocation method.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>A memory handle.</returns>
	public IntPtr ReAllocMem(IntPtr hMem, int size) => Marshal.ReAllocHGlobal(hMem, (IntPtr)size);

	/// <summary>Unlocks the memory of a specified handle.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <returns><see langword="true"/> if the memory object is still locked after decrementing the lock count; otherwise <see langword="false"/>.</returns>
	public bool UnlockMem(IntPtr hMem) => false;
}

/// <summary>A <see cref="SafeHandle"/> for memory allocated via LocalAlloc.</summary>
/// <seealso cref="SafeHandle"/>
public partial class SafeHGlobalHandle : SafeMemoryHandleExt<HGlobalMemoryMethods>
{
	/// <summary>Initializes a new instance of the <see cref="SafeHGlobalHandle"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	public SafeHGlobalHandle(IntPtr handle, SizeT size, bool ownsHandle = true) : base(handle, size, ownsHandle) { }

	/// <summary>Initializes a new instance of the <see cref="SafeHGlobalHandle"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	public SafeHGlobalHandle(IntPtr handle, bool ownsHandle = true) : base(handle, GetPtrSize(handle), ownsHandle) { }

	/// <summary>Initializes a new instance of the <see cref="SafeHGlobalHandle"/> class.</summary>
	/// <param name="size">The size of memory to allocate, in bytes.</param>
	/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
	public SafeHGlobalHandle(SizeT size) : base(size) { }

	/// <summary>Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native array equivalent.</summary>
	/// <param name="bytes">Array of unmanaged pointers</param>
	/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
	public SafeHGlobalHandle(byte[] bytes) : base(bytes) { }

	/// <summary>Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native array equivalent.</summary>
	/// <param name="values">Array of unmanaged pointers</param>
	/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
	public SafeHGlobalHandle(IntPtr[] values) : base(values) { }

	/// <summary>Allocates from unmanaged memory to represent a Unicode string (WSTR) and marshal this to a native PWSTR.</summary>
	/// <param name="s">The string value.</param>
	/// <returns>SafeHGlobalHandle object to an native (unmanaged) Unicode string</returns>
	public SafeHGlobalHandle(string s) : base(s) { }

	/// <summary>Initializes a new instance of the <see cref="SafeHGlobalHandle"/> class.</summary>
	[ExcludeFromCodeCoverage]
	internal SafeHGlobalHandle() : base(0) { }

	/// <summary>Represents a NULL memory pointer.</summary>
	public static SafeHGlobalHandle Null { get; } = new SafeHGlobalHandle(IntPtr.Zero, 0, false);

	/// <summary>Converts an <see cref="IntPtr"/> to a <see cref="SafeHGlobalHandle"/> where it owns the reference.</summary>
	/// <param name="ptr">The <see cref="IntPtr"/>.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SafeHGlobalHandle(IntPtr ptr) => new(ptr, 0, true);

	/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
	/// <typeparam name="T">Native type</typeparam>
	/// <param name="value">The value.</param>
	/// <returns><see cref="SafeHGlobalHandle"/> object to an native (unmanaged) memory block the size of T.</returns>
	public static SafeHGlobalHandle CreateFromStructure<T>(in T? value = default) => new(InteropExtensions.MarshalToPtr(value, mm.AllocMem, out int s), s);

	/// <summary>
	/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure elements. It is the
	/// callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY structures with attribute StructLayout of
	/// LayoutKind.Sequential are supported.
	/// </summary>
	/// <typeparam name="T">Type of the trailing array of structures</typeparam>
	/// <param name="values">Collection of structure objects</param>
	/// <param name="count">Number of items in <paramref name="values"/>.</param>
	/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
	/// <returns><see cref="SafeHGlobalHandle"/> object to an native (unmanaged) structure with a trail array of structures</returns>
	public static SafeHGlobalHandle CreateFromList<T>(IEnumerable<T> values, int count = -1, int prefixBytes = 0) =>
		new(InteropExtensions.MarshalToPtr(count < 0 ? values : values.Take(count), mm.AllocMem, out int s, prefixBytes), s);

	/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
	/// <param name="values">The list of strings.</param>
	/// <param name="packing">The packing type for the strings.</param>
	/// <param name="charSet">The character set to use for the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
	/// <returns><see cref="SafeHGlobalHandle"/> object to an native (unmanaged) array of strings stored using the <paramref name="packing"/> model and the character set defined by <paramref name="charSet"/>.</returns>
	public static SafeHGlobalHandle CreateFromStringList(IEnumerable<string?> values, StringListPackMethod packing = StringListPackMethod.Concatenated,
		CharSet charSet = CharSet.Auto, int prefixBytes = 0) => new(InteropExtensions.MarshalToPtr(values, packing, mm.AllocMem, out int s, charSet, prefixBytes), s);

	[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
	private static extern SizeT GlobalSize([In] IntPtr hMem);

	private static SizeT GetPtrSize(IntPtr hMem)
	{
		var sz = GlobalSize(hMem);
		if (sz == 0)
		{
			var err = Marshal.GetHRForLastWin32Error();
			if (err != 0)
				Marshal.ThrowExceptionForHR(err);
		}
		return sz;
	}
}

#if NET7_0_OR_GREATER
public partial class SafeHGlobalHandle : ICreateSafeMemoryHandle
{
	/// <inheritdoc/>
	public static ISafeMemoryHandle Create(SizeT size) => new SafeHGlobalHandle(size);
}
#endif