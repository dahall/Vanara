using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>An abstract base class for a safe, unmanaged list of structures allocated by a memory scheme.</summary>
/// <typeparam name="TElem">The type of the list elements.</typeparam>
/// <typeparam name="TMem">The type of memory allocation to use.</typeparam>
public abstract class SafeNativeListBase<TElem, TMem> : SafeMemoryHandle<TMem>, IReadOnlyList<TElem> where TElem : struct where TMem : IMemoryMethods, new()
{
	/// <summary>Initializes a new instance of the <see cref="SafeNativeLinkedList{TElem, TMem}"/> class.</summary>
	/// <param name="ptr">The handle.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	protected SafeNativeListBase(IntPtr ptr, SIZE_T size, bool ownsHandle) : base(ptr, size, ownsHandle) { }

	/// <summary>Initializes a new instance of the <see cref="SafeNativeLinkedList{TElem, TMem}"/> class.</summary>
	/// <param name="byteCount">The number of bytes to allocate for this new array.</param>
	public SafeNativeListBase(SIZE_T byteCount) : base(byteCount) { }

	/// <summary>Gets the number of elements contained in the <see cref="SafeNativeLinkedList{TElem, TMem}"/>.</summary>
	public virtual int Count => IsInvalid ? 0 : Items.Count();

	/// <summary>Enumerates the elements.</summary>
	/// <returns>An enumeration of values from the pointer.</returns>
	protected abstract IEnumerable<TElem> Items { get; }

	/// <summary>Gets or sets the <typeparamref name="TElem"/> value at the specified index.</summary>
	/// <value>The <typeparamref name="TElem"/> value.</value>
	/// <param name="index">The index.</param>
	/// <returns></returns>
	/// <exception cref="ArgumentOutOfRangeException">index or index</exception>
	public virtual TElem this[int index] => Items.ElementAt(index);

	/// <summary>Determines whether this instance contains the object.</summary>
	/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
	/// </returns>
	public virtual bool Contains(TElem item) => Items.Contains(item);

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
	public virtual IEnumerator<TElem> GetEnumerator() => Items.GetEnumerator();

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}