using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices;

/// <summary>
/// A safe unmanaged array of structures allocated on the global heap with a prefix type (usually a uint or int) that determines the
/// count of elements.
/// </summary>
/// <typeparam name="TElem">The type of the array elements.</typeparam>
/// <typeparam name="TPrefix">The type of the value used to represent the number of elements in the array.</typeparam>
/// <typeparam name="TMem">The memory methods to use for allocation.</typeparam>
public class SafeElementArray<TElem, TPrefix, TMem> : SafeMemoryHandle<TMem>, IReadOnlyList<TElem> where TMem : IMemoryMethods, new() where TElem : struct where TPrefix : unmanaged, IConvertible
{
	/// <summary>The size, in bytes, of <c>TElem</c>.</summary>
	protected static readonly int ElemSize = InteropExtensions.SizeOf(typeof(TElem));
	/// <summary>The size, in bytes, of <c>TPrefix</c>.</summary>
	protected static readonly int PrefixSize = InteropExtensions.SizeOf(typeof(TPrefix));

	/// <summary>Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class.</summary>
	protected SafeElementArray() : this(0) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class and allocates <paramref
	/// name="elementCount"/> bytes.
	/// </summary>
	/// <param name="elementCount">The TElem count to allocate.</param>
	protected SafeElementArray(TPrefix elementCount) : this(Convert.ToInt32(elementCount)) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class from a copy of a managed TElem array.
	/// </summary>
	/// <param name="array">The array of bytes to copy.</param>
	/// <param name="getElemSize">Size of the get elem.</param>
	protected SafeElementArray(TElem[] array, Func<TElem, int>? getElemSize = null) : base(IntPtr.Zero, 0, true)
	{
		GetElemSize = getElemSize;
		Elements = array;
	}

	/// <summary>Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class.</summary>
	/// <param name="byteSize">Size of the byte.</param>
	/// <param name="elementCount">The element count. This value can be 0.</param>
	protected SafeElementArray(int byteSize, int elementCount) : base(byteSize)
	{
		Zero();
		if (elementCount > 0)
			IntCount = elementCount;
	}

	private SafeElementArray(int elementCount) : base(GetRequiredSize(elementCount))
	{
	}

	/// <summary>Gets or sets the <typeparamref name="TElem"/> value at the specified index.</summary>
	/// <value>The <typeparamref name="TElem"/> value.</value>
	/// <param name="index">The index.</param>
	/// <returns></returns>
	/// <exception cref="ArgumentOutOfRangeException">index or index</exception>
	public virtual TElem this[TPrefix index]
	{
		get => handle.ToStructure<TElem>(Size, ElemOffset(index));
		set => handle.Write(value, ElemOffset(index), Size);
	}

	/// <summary>Gets the number of elements contained in the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/>.</summary>
	protected TPrefix Count
	{
		get => IsInvalid ? default : handle.ToStructure<TPrefix>();
		private set { if (!IsInvalid) Marshal.StructureToPtr(value, handle, false); }
	}

	/// <summary>Gets or sets the elements.</summary>
	/// <value>The elements of the array.</value>
	protected TElem[] Elements
	{
		get => handle.ToArray<TElem>(IntCount, PrefixSize, Size) ?? new TElem[0];
		set
		{
			Size = GetElemSize != null ? PrefixSize + value.Sum(GetElemSize) : GetRequiredSize(value.Length);
			Zero();
			InteropExtensions.Write(handle, value, PrefixSize);
			IntCount = value.Length;
		}
	}

	/// <summary>Gets or sets the size of the element.</summary>
	/// <value>The size of the element.</value>
	protected Func<TElem, int>? GetElemSize { get; set; }

	private int IntCount
	{
		get => Convert.ToInt32(Count);
		set => Count = (TPrefix)Convert.ChangeType(value, typeof(TPrefix));
	}

	int IReadOnlyCollection<TElem>.Count => Count.ToInt32(null);

	TElem IReadOnlyList<TElem>.this[int index] => this[(TPrefix)Convert.ChangeType(index, typeof(TPrefix))];

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<TElem> GetEnumerator() => ((IEnumerable<TElem>)Elements).GetEnumerator();

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private int ElemOffset(TPrefix index) => index.ToUInt64(null) >= 0 && index.ToUInt64(null) < Count.ToUInt64(null) ? index.ToInt32(null) * ElemSize + PrefixSize : throw new ArgumentOutOfRangeException(nameof(index));

	/// <summary>Converts a byte count to a element count.</summary>
	/// <param name="byteSize">The byte count.</param>
	/// <returns>The converted element count.</returns>
	/// <exception cref="ArgumentException">Byte count does not match this structure.</exception>
	protected static uint BytesToCount(uint byteSize) => (byteSize - PrefixSize) % ElemSize != 0
			? throw new ArgumentException("Byte count does not match this structure.")
			: (uint)((byteSize - PrefixSize) / ElemSize);

	private static int GetRequiredSize(int elementCount) => PrefixSize + ElemSize * elementCount;
}