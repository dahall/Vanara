using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public bool IsNull => ptr == IntPtr.Zero;

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

	/// <summary>Performs an implicit conversion from <see cref="ArrayPointer{T}"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="ap">The <see cref="ArrayPointer{T}"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(ArrayPointer<T> ap) => ap.ptr;

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

/// <summary>This structure is used to hold a reference to an IUnknown interface pointer.</summary>
/// <typeparam name="T">The type of the interface.</typeparam>
[StructLayout(LayoutKind.Sequential)]
public struct IUnknownPointer<T> where T : class
{
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="IUnknownPointer{T}"/> struct.</summary>
	/// <param name="value">The value.</param>
	public IUnknownPointer(T? value) => ptr = value == null ? IntPtr.Zero :
#if NET45
		Marshal.GetIUnknownForObject(value);
#else
		Marshal.GetComInterfaceForObject(value, typeof(T));
#endif

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public readonly bool IsNull => ptr == IntPtr.Zero;

	/// <summary>
	/// <para>Gets the value as an interface.</para>
	/// <note type="warning">This must only be used with COM interfaces.</note>
	/// </summary>
	/// <value>The value.</value>
	public T? Value => ptr == IntPtr.Zero ? null :
#if NETSTANDARD
		(T)Marshal.GetObjectForIUnknown(ptr);
#else
		(T)Marshal.GetTypedObjectForIUnknown(ptr, typeof(T));
#endif

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="IUnknownPointer{T}"/>.</summary>
	/// <param name="p">The IUnknown interface pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IUnknownPointer<T>(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="IUnknownPointer{T}"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(IUnknownPointer<T> p) => p.ptr;
}

/// <summary>A pointer to an array of ANSI string pointers as a field in a structure.</summary>
[StructLayout(LayoutKind.Sequential)]
public struct LPCSTRArrayPointer
{
	private IntPtr ptr;

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public bool IsNull => ptr == IntPtr.Zero;

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

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public bool IsNull => ptr == IntPtr.Zero;

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

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public bool IsNull => ptr == IntPtr.Zero;

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

/// <summary>A pointer to a managed structure.</summary>
/// <typeparam name="T">The structure type.</typeparam>
[StructLayout(LayoutKind.Sequential)]
public struct ManagedStructPointer<T> where T : struct
{
	private IntPtr ptr;

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public bool IsNull => ptr == IntPtr.Zero;

	/// <summary>Gets a reference to a structure based on this allocated memory.</summary>
	/// <returns>A referenced structure.</returns>
	public ref T AsRef() { if (ptr != IntPtr.Zero) return ref ptr.AsRef<T>(); throw new InvalidCastException("Cannot get reference to null pointer."); }

	/// <summary>Converts this pointer to a copied structure. If pointer has no value, <c>null</c> is returned.</summary>
	/// <returns>The converted structure or <c>null</c>.</returns>
	public T? Value => ptr.ToNullableStructure<T>();

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StructPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ManagedStructPointer<T>(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="StructPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="SafeAllocatedMemoryHandle"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ManagedStructPointer<T>(SafeAllocatedMemoryHandle p) => new() { ptr = p };

	/// <summary>Performs an explicit conversion from <see cref="ManagedStructPointer{T}"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The pointer instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(ManagedStructPointer<T> p) => p.ptr;

	/// <summary>
	/// <para>Destructively assigns a created pointer to allocated memory containing <paramref name="item"/>.</para>
	/// <note type="warning">This function will overwrite the value of the underlying pointer without releasing any allocated memory already
	/// assigned to it.</note>
	/// </summary>
	/// <param name="item">The item to allocate to memory and assign to this pointer.</param>
	/// <returns>A reference to the allocated memory behind <paramref name="item"/>.</returns>
	public SafeAllocatedMemoryHandle DestructiveAssign(T? item)
	{
		var h = SafeCoTaskMemHandle.CreateFromStructure(item);
		ptr = h;
		return h;
	}
}

/// <summary>A pointer to a structure.</summary>
/// <typeparam name="T">The structure type.</typeparam>
[StructLayout(LayoutKind.Sequential)]
public struct StructPointer<T> where T : unmanaged
{
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="StructPointer{T}"/> struct.</summary>
	/// <param name="value">The value.</param>
	/// <param name="mem">The memory.</param>
	public StructPointer(in T? value, out SafeAllocatedMemoryHandle mem) => mem = DestructiveAssign(value);

#if !NET45
	/// <summary>Initializes a new instance of the <see cref="StructPointer{T}"/> struct.</summary>
	/// <param name="value">The value's reference.</param>
	public StructPointer(ref T value)
	{
		unsafe
		{
			ptr = (IntPtr)System.Runtime.CompilerServices.Unsafe.AsPointer(ref value);
		}
	}
#endif

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public readonly bool IsNull => ptr == IntPtr.Zero;

	/// <summary>Gets a reference to a structure based on this allocated memory.</summary>
	/// <summary>Converts this pointer to a copied structure. If pointer has no value, <c>null</c> is returned.</summary>
	/// <returns>The converted structure or <c>null</c>.</returns>
	public T? Value => ptr.ToNullableStructure<T>();

	/// <returns>A referenced structure.</returns>
	public ref T AsRef() { if (ptr != IntPtr.Zero) return ref ptr.AsRef<T>(); throw new InvalidCastException("Cannot get reference to null pointer."); }

	/// <summary>
	/// <para>Destructively assigns a created pointer to allocated memory containing <paramref name="item"/>.</para>
	/// <note type="warning">This function will overwrite the value of the underlying pointer without releasing any allocated memory already
	/// assigned to it.</note>
	/// </summary>
	/// <param name="item">The item to allocate to memory and assign to this pointer.</param>
	/// <returns>A reference to the allocated memory behind <paramref name="item"/>.</returns>
	public SafeAllocatedMemoryHandle DestructiveAssign(T? item)
	{
		var h = SafeCoTaskMemHandle.CreateFromStructure(item);
		ptr = h;
		return h;
	}

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StructPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="IntPtr"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator StructPointer<T>(IntPtr p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandle"/> to <see cref="StructPointer{T}"/>.</summary>
	/// <param name="p">The <see cref="SafeAllocatedMemoryHandle"/> to assign to this pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator StructPointer<T>(SafeAllocatedMemoryHandle p) => new() { ptr = p };

	/// <summary>Performs an implicit conversion from <see cref="StructPointer{T}"/> to <typeparamref name="T"/>*.</summary>
	/// <param name="ap">The <see cref="StructPointer{T}"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator T*(StructPointer<T> ap) => (T*)ap.ptr;

	/// <summary>Performs an implicit conversion from <typeparamref name="T"/>* to <see cref="StructPointer{T}"/>.</summary>
	/// <param name="ap">The <typeparamref name="T"/>*.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator StructPointer<T>(T* ap) => new() { ptr = (IntPtr)ap };

	/// <summary>Performs an explicit conversion from <see cref="StructPointer{T}"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The pointer instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(StructPointer<T> p) => p.ptr;
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

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public bool IsNull => ptr == IntPtr.Zero;

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

	/// <summary>Performs an explicit conversion from <see cref="ManagedArrayPointer{T}"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The pointer instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(ManagedArrayPointer<T> p) => p.ptr;

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

/// <summary>
/// Should be used with <see cref="ManagedArrayPointer{T}"/> or <see cref="ArrayPointer{T}"/> to indicate which field within the same
/// structure contains the size of the array.
/// </summary>
/// <seealso cref="System.Attribute"/>
/// <remarks>Initializes a new instance of the <see cref="SizeFieldNameAttribute"/> class.</remarks>
/// <param name="FieldName">Name of the field that contains the size of the array.</param>
[System.AttributeUsage(AttributeTargets.Field, Inherited = false)]
public sealed class SizeFieldNameAttribute(string FieldName) : Attribute
{
	/// <summary>Gets the name of the field that contains the size of the array.</summary>
	/// <value>The name of the field that contains the size of the array.</value>
	public string FieldName { get; private set; } = FieldName;
}

/// <summary>Extension methods for <see cref="SizeFieldNameAttribute"/> to get the size of an array pointer within a structure via attribute.</summary>
public static class SizeFieldNameAttributeExt
{
	/// <summary>Gets the field size of an array pointer within a structure via attribute.</summary>
	/// <typeparam name="T">The type of the structure.</typeparam>
	/// <param name="structInstance">The structure instance.</param>
	/// <param name="fi">The <see cref="FieldInfo"/> of the array pointer.</param>
	/// <returns>
	/// The size of the array indicated by the referenced field, if available, or <see langword="null"/> if no attribute was found.
	/// </returns>
	public static SizeT? GetFieldSizeViaAttribute<T>(this T structInstance, FieldInfo fi) where T : struct
	{
		var attr = fi.GetCustomAttribute<SizeFieldNameAttribute>();
		if (attr is null)
			return null;
		var fld = fi.DeclaringType!.GetField(attr.FieldName);
		var fval = fld?.GetValue(structInstance);
		return fval is IConvertible cnv ? cnv.ToUInt64(null) : null;
	}

	/// <summary>Gets the field size of an array pointer within a structure via attribute.</summary>
	/// <typeparam name="T">The type of the structure.</typeparam>
	/// <param name="structInstance">The structure instance.</param>
	/// <param name="fieldName">The name of the array pointer field.</param>
	/// <returns>
	/// The size of the array indicated by the referenced field, if available, or <see langword="null"/> if no attribute was found.
	/// </returns>
	public static SizeT? GetFieldSizeViaAttribute<T>(this T structInstance, string fieldName) where T : struct =>
		GetFieldSizeViaAttribute(structInstance, typeof(T).GetField(fieldName) ?? throw new ArgumentException("Unable to find matching field.", nameof(fieldName)));
}