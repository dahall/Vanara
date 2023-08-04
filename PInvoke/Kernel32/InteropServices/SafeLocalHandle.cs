using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.InteropServices;

/// <summary>Unmanaged memory methods for local heap.</summary>
/// <seealso cref="IMemoryMethods"/>
public sealed class LocalMemoryMethods : MemoryMethodsBase
{
	/// <summary>Gets a static instance of these methods.</summary>
	public static readonly IMemoryMethods Instance = new LocalMemoryMethods();

	/// <inheritdoc/>
	public override bool AllocZeroes => true;

	/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>A memory handle.</returns>
	public override IntPtr AllocMem(int size) => Win32Error.ThrowLastErrorIfNull((IntPtr)LocalAlloc(LMEM.LPTR, size));

	/// <summary>Frees the memory associated with a handle.</summary>
	/// <param name="hMem">A memory handle.</param>
	public override void FreeMem(IntPtr hMem) => LocalFree(hMem);

	/// <summary>Gets the reallocation method.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>A memory handle.</returns>
	public override IntPtr ReAllocMem(IntPtr hMem, int size) => Win32Error.ThrowLastErrorIfNull((IntPtr)LocalReAlloc(hMem, size, LMEM.LMEM_FIXED | LMEM.LMEM_ZEROINIT));
}

/// <summary>A <see cref="SafeHandle"/> for memory allocated via LocalAlloc.</summary>
/// <seealso cref="SafeHandle"/>
public class SafeLocalHandle : SafeMemoryHandleExt<LocalMemoryMethods>
{
	/// <summary>Initializes a new instance of the <see cref="SafeLocalHandle"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	public SafeLocalHandle(HLOCAL handle, SizeT size, bool ownsHandle = true) : base((IntPtr)handle, size, ownsHandle) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLocalHandle"/> class.</summary>
	/// <param name="size">The size of memory to allocate, in bytes.</param>
	/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
	public SafeLocalHandle(SizeT size) : base(size) { }

	/// <summary>
	/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
	/// array equivalent.
	/// </summary>
	/// <param name="bytes">Array of unmanaged pointers</param>
	/// <returns>SafeLocalHandle object to an native (unmanaged) array of pointers</returns>
	public SafeLocalHandle(byte[] bytes) : base(bytes) { }

	/// <summary>
	/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
	/// array equivalent.
	/// </summary>
	/// <param name="values">Array of unmanaged pointers</param>
	/// <returns>SafeLocalHandle object to an native (unmanaged) array of pointers</returns>
	public SafeLocalHandle(IntPtr[] values) : base(values) { }

	/// <summary>Allocates from unmanaged memory to represent a Unicode string (WSTR) and marshal this to a native PWSTR.</summary>
	/// <param name="s">The string value.</param>
	/// <returns>SafeLocalHandle object to an native (unmanaged) Unicode string</returns>
	public SafeLocalHandle(string s) : base(s) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLocalHandle"/> class.</summary>
	[ExcludeFromCodeCoverage]
	internal SafeLocalHandle() : base(0) { }

	/// <summary>Represents a NULL memory pointer.</summary>
	public static SafeLocalHandle Null { get; } = new SafeLocalHandle(IntPtr.Zero, 0, false);

	/// <summary>
	/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure
	/// elements. It is the callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY structures
	/// with attribute StructLayout of LayoutKind.Sequential are supported.
	/// </summary>
	/// <typeparam name="T">Type of the trailing array of structures</typeparam>
	/// <param name="values">Collection of structure objects</param>
	/// <param name="count">Number of items in <paramref name="values"/>.</param>
	/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
	/// <returns><see cref="SafeLocalHandle"/> object to an native (unmanaged) structure with a trail array of structures</returns>
	public static SafeLocalHandle CreateFromList<T>(IEnumerable<T> values, int count = -1, int prefixBytes = 0) => new(InteropExtensions.MarshalToPtr(values, mm.AllocMem, out var s, prefixBytes), s);

	/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
	/// <param name="values">The list of strings.</param>
	/// <param name="packing">The packing type for the strings.</param>
	/// <param name="charSet">The character set to use for the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
	/// <returns>
	/// <see cref="SafeLocalHandle"/> object to an native (unmanaged) array of strings stored using the <paramref name="packing"/> model
	/// and the character set defined by <paramref name="charSet"/>.
	/// </returns>
	public static SafeLocalHandle CreateFromStringList(IEnumerable<string> values, StringListPackMethod packing = StringListPackMethod.Concatenated, CharSet charSet = CharSet.Auto, int prefixBytes = 0) => new(InteropExtensions.MarshalToPtr(values, packing, mm.AllocMem, out var s, charSet, prefixBytes), s);

	/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
	/// <typeparam name="T">Native type</typeparam>
	/// <param name="value">The value.</param>
	/// <returns><see cref="SafeLocalHandle"/> object to an native (unmanaged) memory block the size of T.</returns>
	public static SafeLocalHandle CreateFromStructure<T>(in T? value = default) => new(InteropExtensions.MarshalToPtr(value, mm.AllocMem, out var s), s);

	/// <summary>Converts an <see cref="IntPtr"/> to a <see cref="SafeLocalHandle"/> where it owns the reference.</summary>
	/// <param name="ptr">The <see cref="IntPtr"/>.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SafeLocalHandle(IntPtr ptr) => new(ptr, 0, true);
}