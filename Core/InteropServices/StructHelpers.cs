using System.Collections.Generic;
using System.Linq;

namespace Vanara.PInvoke;

/// <summary>A pointer to an array of entries in a structure.</summary>
/// <typeparam name="T">The structure that is the element of the array.</typeparam>
[StructLayout(LayoutKind.Sequential)]
public struct ArrayPointer<T> where T : unmanaged
{
	private IntPtr ptr;

	/// <summary>
	/// <para>Gets or sets the <typeparamref name="T"/> value at the specified index.</para>
	/// <note type="warning">There is no range checking with this property. If <paramref name="index"/> is not the range of memory allocated
	/// to this pointer, the results are unpredictable and may result in a buffer overrun.</note>
	/// </summary>
	/// <param name="index">The index of the element.</param>
	/// <value>The <typeparamref name="T"/> value to assign to the <paramref name="index"/> location in the array.</value>
	/// <returns>The <typeparamref name="T"/> value at the location.</returns>
	public T this[int index]
	{
		get => ptr.AsReadOnlySpan<T>(index + 1)[index];
		set => ptr.AsSpan<T>(index + 1)[index] = value;
	}

	/// <summary>Gets a <see cref="ReadOnlySpan{T}"/> over the pointer.</summary>
	/// <param name="length">The number of elements allocated to this pointer.</param>
	/// <returns>A <see cref="ReadOnlySpan{T}"/> over the pointer.</returns>
	public readonly ReadOnlySpan<T> AsReadOnlySpan(SizeT length) => ptr == IntPtr.Zero ? [] : ptr.AsReadOnlySpan<T>(length);

	/// <summary>Gets a writable <see cref="Span{T}"/> over the pointer.</summary>
	/// <param name="length">The number of elements allocated to this pointer.</param>
	/// <returns>A writable <see cref="Span{T}"/> over the pointer.</returns>
	public readonly Span<T> AsSpan(SizeT length) => ptr == IntPtr.Zero ? [] : ptr.AsSpan<T>(length);

	/// <summary>Converts this pointer to a copied array of <typeparamref name="T"/> elements.</summary>
	/// <param name="length">The number of elements allocated to this pointer.</param>
	/// <returns>A copied array of <typeparamref name="T"/> elements.</returns>
	public readonly T[] ToArray(SizeT length) => ptr.ToArray<T>(length) ?? [];

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="ArrayPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ArrayPointer<T>(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="ArrayPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="SafeAllocatedMemoryHandle"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ArrayPointer<T>(SafeAllocatedMemoryHandle p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="ArrayPointer{T}"/> to <typeparamref name="T"/>*.</summary>
	/// <param name="ap">The <see cref="ArrayPointer{T}"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator T*(ArrayPointer<T> ap) => (T*)ap.ptr;

	/// <summary>Performs an implicit conversion from <typeparamref name="T"/>* to <see cref="ArrayPointer{T}"/>.</summary>
	/// <param name="ap">The <typeparamref name="T"/>*.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator ArrayPointer<T>(T* ap) => new() { ptr = (IntPtr)ap };

	/// <summary>
	/// <para>Destructively assigns a created pointer to allocated memory containing <paramref name="items"/>.</para>
	/// <note type="warning">This function will overwrite the value of the underlying pointer without releasing any allocated memory already
	/// assigned to it.</note>
	/// </summary>
	/// <param name="items">The items to allocate to memory and assign to this pointer.</param>
	/// <returns>A reference to the allocated memory behind <paramref name="items"/>.</returns>
	public SafeAllocatedMemoryHandle DestructiveAssign(IEnumerable<T> items)
	{
		var h = SafeCoTaskMemHandle.CreateFromList(items);
		ptr = h;
		return h;
	}
}

/// <summary>A pointer to an array of ANSI string pointers as a field in a structure.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct LPCSTRArrayPointer
{
	private IntPtr ptr;

	/// <summary>
	/// <para>Gets a copy of the <see cref="string"/> value at the specified index.</para>
	/// <note type="warning">There is no range checking with this property. If <paramref name="index"/> is not the range of memory allocated
	/// to this pointer, the results are unpredictable and may result in a buffer overrun.</note>
	/// </summary>
	/// <param name="index">The index of the element.</param>
	/// <value>The <see cref="string"/> value to assign to the <paramref name="index"/> location in the array.</value>
	/// <returns>The <see cref="string"/> value at the location.</returns>
	public readonly string? this[int index] => Marshal.PtrToStringAnsi(ptr.AsReadOnlySpan<IntPtr>(index + 1)[index]);

	/// <summary>Converts this pointer to a copied array of <see cref="string"/> elements.</summary>
	/// <param name="length">The number of elements allocated to this pointer.</param>
	/// <returns>A copied array of <see cref="string"/> elements.</returns>
	public readonly string?[] ToArray(SizeT length) => Array.ConvertAll(ptr.ToArray<IntPtr>(length) ?? [], Marshal.PtrToStringAnsi);

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LPCSTRArrayPointer"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPCSTRArrayPointer(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="LPCSTRArrayPointer"/>.</summary>
	/// <param name="p">The <see cref="SafeAllocatedMemoryHandle"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPCSTRArrayPointer(SafeAllocatedMemoryHandle p) => new() { ptr = p };
}

/// <summary>A pointer to an array of platform specific string pointers as a field in a structure.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct LPCTSTRArrayPointer
{
	private IntPtr ptr;

	/// <summary>
	/// <para>Gets a copy of the <see cref="string"/> value at the specified index.</para>
	/// <note type="warning">There is no range checking with this property. If <paramref name="index"/> is not the range of memory allocated
	/// to this pointer, the results are unpredictable and may result in a buffer overrun.</note>
	/// </summary>
	/// <param name="index">The index of the element.</param>
	/// <value>The <see cref="string"/> value to assign to the <paramref name="index"/> location in the array.</value>
	/// <returns>The <see cref="string"/> value at the location.</returns>
	public readonly string? this[int index] => Marshal.PtrToStringAuto(ptr.AsReadOnlySpan<IntPtr>(index + 1)[index]);

	/// <summary>Converts this pointer to a copied array of <see cref="string"/> elements.</summary>
	/// <param name="length">The number of elements allocated to this pointer.</param>
	/// <returns>A copied array of <see cref="string"/> elements.</returns>
	public readonly string?[] ToArray(SizeT length) => Array.ConvertAll(ptr.ToArray<IntPtr>(length) ?? [], Marshal.PtrToStringAuto);

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LPCSTRArrayPointer"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPCTSTRArrayPointer(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="LPCSTRArrayPointer"/>.</summary>
	/// <param name="p">The <see cref="SafeAllocatedMemoryHandle"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPCTSTRArrayPointer(SafeAllocatedMemoryHandle p) => new() { ptr = p };
}

/// <summary>A pointer to an array of Unicode (wide) string pointers as a field in a structure.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct LPCWSTRArrayPointer
{
	private IntPtr ptr;

	/// <summary>
	/// <para>Gets a copy of the <see cref="string"/> value at the specified index.</para>
	/// <note type="warning">There is no range checking with this property. If <paramref name="index"/> is not the range of memory allocated
	/// to this pointer, the results are unpredictable and may result in a buffer overrun.</note>
	/// </summary>
	/// <param name="index">The index of the element.</param>
	/// <value>The <see cref="string"/> value to assign to the <paramref name="index"/> location in the array.</value>
	/// <returns>The <see cref="string"/> value at the location.</returns>
	public readonly string? this[int index] => Marshal.PtrToStringUni(ptr.AsReadOnlySpan<IntPtr>(index + 1)[index]);

	/// <summary>Converts this pointer to a copied array of <see cref="string"/> elements.</summary>
	/// <param name="length">The number of elements allocated to this pointer.</param>
	/// <returns>A copied array of <see cref="string"/> elements.</returns>
	public readonly string?[] ToArray(SizeT length) => Array.ConvertAll(ptr.ToArray<IntPtr>(length) ?? [], Marshal.PtrToStringUni);

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LPCSTRArrayPointer"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPCWSTRArrayPointer(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="LPCSTRArrayPointer"/>.</summary>
	/// <param name="p">The <see cref="SafeAllocatedMemoryHandle"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPCWSTRArrayPointer(SafeAllocatedMemoryHandle p) => new() { ptr = p };
}

/// <summary>A pointer to an array of entries in a structure.</summary>
/// <typeparam name="T">The managed structure that is the element of the array.</typeparam>
[StructLayout(LayoutKind.Sequential)]
public struct ManagedArrayPointer<T> where T : struct
{
	private IntPtr ptr;

	/// <summary>
	/// <para>Gets a copy of the <typeparamref name="T"/> value at the specified index.</para>
	/// <note type="warning">There is no range checking with this property. If <paramref name="index"/> is not the range of memory allocated
	/// to this pointer, the results are unpredictable and may result in a buffer overrun.</note>
	/// </summary>
	/// <param name="index">The index of the element.</param>
	/// <value>The <typeparamref name="T"/> value to assign to the <paramref name="index"/> location in the array.</value>
	/// <returns>The <typeparamref name="T"/> value at the location.</returns>
	public readonly T this[int index] => ptr.ToStructure<T>(0, InteropExtensions.SizeOf<T>() * index);

	/// <summary>Converts this pointer to a copied array of <typeparamref name="T"/> elements.</summary>
	/// <param name="length">The number of elements allocated to this pointer.</param>
	/// <returns>A copied array of <typeparamref name="T"/> elements.</returns>
	public readonly T[] ToArray(SizeT length) => ptr.ToArray<T>(length) ?? [];

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="ManagedArrayPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ManagedArrayPointer<T>(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="ManagedArrayPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="SafeAllocatedMemoryHandle"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ManagedArrayPointer<T>(SafeAllocatedMemoryHandle p) => new() { ptr = p };

	/// <summary>
	/// <para>Destructively assigns a created pointer to allocated memory containing <paramref name="items"/>.</para>
	/// <note type="warning">This function will overwrite the value of the underlying pointer without releasing any allocated memory already
	/// assigned to it.</note>
	/// </summary>
	/// <param name="items">The items to allocate to memory and assign to this pointer.</param>
	/// <returns>A reference to the allocated memory behind <paramref name="items"/>.</returns>
	public SafeAllocatedMemoryHandle DestructiveAssign(IEnumerable<T> items)
	{
		var h = SafeCoTaskMemHandle.CreateFromList(items);
		ptr = h;
		return h;
	}
}