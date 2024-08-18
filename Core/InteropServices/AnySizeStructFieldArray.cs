using System.Runtime.CompilerServices;

namespace Vanara.InteropServices;

/// <summary>
/// For structures that end with an ANYSIZE array field, this structure can be used to represent the value rather than using <see
/// cref="UnmanagedType.ByValArray"/> but only when using an <c>unmanaged</c> type for <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the array element.</typeparam>
public struct AnySizeStructUnmanagedFieldArray<T> where T : unmanaged
{
	internal T elem;

	/// <summary>Gets a reference to the element of type <typeparamref name="T"/> at the specified index.</summary>
	/// <value>A reference to the element at <paramref name="index"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns>A reference to the element at <paramref name="index"/>.</returns>
	/// <exception cref="System.ArgumentOutOfRangeException">index</exception>
	public ref T this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
			unsafe { return ref Unsafe.AsRef<T>(&((T*)Unsafe.AsPointer(ref elem))[index]); }
		}
	}

	/// <summary>Gets a <see cref="Span{T}"/> of the elements.</summary>
	/// <param name="length">The length of spanned elements.</param>
	/// <returns>A <see cref="Span{T}"/> of the elements.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public Span<T> AsSpan(int length)
	{
		unsafe { return new Span<T>(Unsafe.AsPointer(ref elem), length); }
	}
}

/// <summary>
/// For structures that end with an ANYSIZE array field, this structure can be used to represent the value rather than using <see
/// cref="UnmanagedType.ByValArray"/> but only when using an <c>unmanaged</c> type for <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the array element.</typeparam>
public struct AnySizeStructFieldArray<T> where T : struct
{
	/// <summary>The elem</summary>
	internal T elem;

	/// <summary>Gets a copy of the element of type <typeparamref name="T"/> at the specified index.</summary>
	/// <value>A copy of the element at <paramref name="index"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns>A copy of the element at <paramref name="index"/>.</returns>
	/// <exception cref="System.ArgumentOutOfRangeException">index</exception>
	public T this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));
			unsafe { return ((IntPtr)Unsafe.AsPointer(ref elem)).ToStructure<T>(); }
		}
	}
}