using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>A <see cref="SafeHandle"/> for memory allocated as moveable HGLOBAL.</summary>
	/// <seealso cref="SafeHandle"/>
	public class SafeMoveableHGlobalHandle : SafeMemoryHandleExt<MoveableHGlobalMemoryMethods>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeMoveableHGlobalHandle"/> class.</summary>
		/// <param name="handle">The handle.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		public SafeMoveableHGlobalHandle(IntPtr handle, bool ownsHandle = true) : base(handle, handle == default ? 0 : GlobalSize(handle), ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMoveableHGlobalHandle"/> class.</summary>
		/// <param name="size">The size of memory to allocate, in bytes.</param>
		/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
		public SafeMoveableHGlobalHandle(SizeT size) : base(size) { }

		/// <summary>
		/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
		/// array equivalent.
		/// </summary>
		/// <param name="bytes">Array of unmanaged pointers</param>
		/// <returns>SafeMoveableHGlobalHandle object to an native (unmanaged) array of pointers</returns>
		public SafeMoveableHGlobalHandle(byte[] bytes) : base(bytes?.Length ?? 0)
		{
			if (Size == 0) return;
			CallLocked(p => Marshal.Copy(bytes!, 0, p, sz));
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeMoveableHGlobalHandle"/> class from a <see cref="SafeAllocatedMemoryHandle"/>
		/// instance, copying all the memory.
		/// </summary>
		/// <param name="source">The source memory block.</param>
		public SafeMoveableHGlobalHandle(SafeAllocatedMemoryHandle source) : base(source) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMoveableHGlobalHandle"/> class.</summary>
		[ExcludeFromCodeCoverage]
		internal SafeMoveableHGlobalHandle() : base(0) { }

		/// <summary>Represents a NULL memory pointer.</summary>
		public static SafeMoveableHGlobalHandle Null { get; } = new SafeMoveableHGlobalHandle(IntPtr.Zero, false);

		/// <summary>
		/// Allocates from unmanaged memory to represent a structure with a variable length array at the end and marshal these structure
		/// elements. It is the callers responsibility to marshal what precedes the trailing array into the unmanaged memory. ONLY
		/// structures with attribute StructLayout of LayoutKind.Sequential are supported.
		/// </summary>
		/// <typeparam name="T">Type of the trailing array of structures</typeparam>
		/// <param name="values">Collection of structure objects</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing array of structures</param>
		/// <returns><see cref="SafeMoveableHGlobalHandle"/> object to an native (unmanaged) structure with a trail array of structures</returns>
		public static SafeMoveableHGlobalHandle CreateFromList<T>(IEnumerable<T> values, int prefixBytes = 0) =>
			new(InteropExtensions.MarshalToPtr(values, mm.AllocMem, out _, prefixBytes, mm.LockMem, mm.UnlockMem), true);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an array of strings.</summary>
		/// <param name="values">The list of strings.</param>
		/// <param name="packing">The packing type for the strings.</param>
		/// <param name="charSet">The character set to use for the strings.</param>
		/// <param name="prefixBytes">Number of bytes preceding the trailing strings.</param>
		/// <returns>
		/// <see cref="SafeMoveableHGlobalHandle"/> object to an native (unmanaged) array of strings stored using the <paramref
		/// name="packing"/> model and the character set defined by <paramref name="charSet"/>.
		/// </returns>
		public static SafeMoveableHGlobalHandle CreateFromStringList(IEnumerable<string?> values, StringListPackMethod packing = StringListPackMethod.Concatenated,
			CharSet charSet = CharSet.Auto, int prefixBytes = 0) => new(InteropExtensions.MarshalToPtr(values, packing, mm.AllocMem, out _, charSet, prefixBytes, mm.LockMem, mm.UnlockMem), true);

		/// <summary>Allocates from unmanaged memory sufficient memory to hold an object of type T.</summary>
		/// <typeparam name="T">Native type</typeparam>
		/// <param name="value">The value.</param>
		/// <returns><see cref="SafeMoveableHGlobalHandle"/> object to an native (unmanaged) memory block the size of T.</returns>
		public static SafeMoveableHGlobalHandle CreateFromStructure<T>(in T? value = default) =>
			new(InteropExtensions.MarshalToPtr(value, mm.AllocMem, out _, 0, mm.LockMem, mm.UnlockMem), true);

		/// <summary>Converts an <see cref="SafeMoveableHGlobalHandle"/> to a <see cref="HGLOBAL"/> where it owns the reference.</summary>
		/// <param name="ptr">The <see cref="SafeMoveableHGlobalHandle"/>.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HGLOBAL(SafeMoveableHGlobalHandle ptr) => ptr.handle;

		/// <summary>Converts an <see cref="IntPtr"/> to a <see cref="SafeMoveableHGlobalHandle"/> where it owns the reference.</summary>
		/// <param name="ptr">The <see cref="IntPtr"/>.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SafeMoveableHGlobalHandle(IntPtr ptr) => new(ptr, true);

		/// <summary>Runs a delegate method while locking the memory.</summary>
		/// <typeparam name="T">The output type.</typeparam>
		/// <param name="action">The action to perform while memory is locked.</param>
		/// <returns>The output from the action.</returns>
		public new T CallLocked<T>(Func<IntPtr, T> action) => base.CallLocked(action);
	}
}