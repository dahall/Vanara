using System.Collections;
using System.Collections.Generic;

namespace Vanara.Collections;

/// <summary>A sparse array based on a dictionary.</summary>
public class SparseArray<T> : IList<T>
{
	/// <summary>Base hash table</summary>
	protected readonly Dictionary<int, T> hashtable = new();

	/// <summary>Initializes a new instance of the <see cref="SparseArray{T}"/> class.</summary>
	public SparseArray()
	{
	}

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<T> GetEnumerator() => hashtable.Values.GetEnumerator();

	/// <summary>Determines whether the array contains the specified value.</summary>
	/// <param name="item">The value.</param>
	/// <returns><c>true</c> if the array contains the specified value; otherwise, <c>false</c>.</returns>
	public bool Contains(T item) => hashtable.ContainsValue(item);

	/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
	/// <exception cref="NotSupportedException">The <see cref="ICollection{T}"/> is read-only.</exception>
	public void Clear() => hashtable.Clear();

	/// <summary>Gets the index of the specified item, or returns -1 if item is not in the array.</summary>
	/// <param name="item">The item.</param>
	/// <returns></returns>
	public int IndexOf(T item)
	{
		foreach (var hash in hashtable)
		{
			if (hash.Value is not null && hash.Value.Equals(item))
				return hash.Key;
		}
		return -1;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Inserts an item to the <see cref="IList{T}"/> at the specified index.</summary>
	/// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
	/// <param name="item">The object to insert into the <see cref="IList{T}"/>.</param>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="IList{T}"/>.</exception>
	/// <exception cref="NotSupportedException">The <see cref="IList{T}"/> is read-only.</exception>
	public void Insert(int index, T item)
	{
		if (hashtable.ContainsKey(index))
			hashtable[index] = item;
		else
			hashtable.Add(index, item);
	}

	/// <summary>Removes the <see cref="IList{T}"/> item at the specified index.</summary>
	/// <param name="index">The zero-based index of the item to remove.</param>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is not a valid index in the <see cref="IList{T}"/>.</exception>
	/// <exception cref="NotSupportedException">The <see cref="IList{T}"/> is read-only.</exception>
	public void RemoveAt(int index) => hashtable.Remove(index);

	/// <summary>Gets or sets the element at the specified index.</summary>
	/// <param name="index">The index of the element.</param>
	/// <value>The element at the specified index.</value>
	public T? this[int index]
	{
		get => hashtable.TryGetValue(index, out var ret) ? ret : default;
		set { if (value is not null) Insert(index, value); else throw new ArgumentNullException(nameof(value)); }
	}

	T IList<T>.this[int index] { get => hashtable[index]; set => hashtable[index] = value; }

	/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
	/// <exception cref="NotSupportedException">The <see cref="ICollection{T}"/> is read-only.</exception>
	void ICollection<T>.Add(T item) => throw new NotSupportedException();

	/// <summary>
	/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="Array"/>, starting at a particular <see cref="Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="Array"/> that is the destination of the elements copied from <see cref="ICollection{T}"/>. The <see
	/// cref="Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	/// <exception cref="ArgumentNullException"><paramref name="array"/> is null.</exception>
	/// <exception cref="ArgumentOutOfRangeException"><paramref name="arrayIndex"/> is less than 0.</exception>
	/// <exception cref="ArgumentException">
	/// <paramref name="array"/> is multidimensional.-or- <paramref name="arrayIndex"/> is equal to or greater than the length of <paramref
	/// name="array"/>.-or-The number of elements in the source <see cref="ICollection{T}"/> is greater than the available space from
	/// <paramref name="arrayIndex"/> to the end of the destination <paramref name="array"/>.-or-Type <c>T</c> cannot be cast automatically
	/// to the type of the destination <paramref name="array"/>.
	/// </exception>
	public void CopyTo(T[] array, int arrayIndex) => hashtable.Values.CopyTo(array, arrayIndex);

	/// <summary>Gets the number of elements contained in the <see cref="ICollection{T}"/>.</summary>
	/// <returns>The number of elements contained in the <see cref="ICollection{T}"/>.</returns>
	public int Count => hashtable.Count;

	/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
	/// <returns>true if the <see cref="ICollection{T}"/> is read-only; otherwise, false.</returns>
	public bool IsReadOnly => false;

	/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise, false. This method also
	/// returns false if <paramref name="item"/> is not found in the original <see cref="ICollection{T}"/>.
	/// </returns>
	/// <exception cref="NotSupportedException">The <see cref="ICollection{T}"/> is read-only.</exception>
	public bool Remove(T item)
	{
		var idx = IndexOf(item);
		if (idx == -1)
			return false;
		RemoveAt(idx);
		return true;
	}

	/// <summary>Collapses array into new, condensed array. Does not maintain indexes.</summary>
	/// <returns>An array of <typeparamref name="T"/></returns>
	public T[] ToArray()
	{
		var output = new T[hashtable.Values.Count];
		hashtable.Values.CopyTo(output, 0);
		return output;
	}
}
