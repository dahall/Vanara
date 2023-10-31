using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Vanara.Collections;

/// <summary>Interface that defines the methods for a virtual list. This interface is used by the <see cref="VirtualList{T}"/> class.</summary>
/// <typeparam name="T">The type of the element.</typeparam>
/// <seealso cref="IVirtualReadOnlyListMethods&lt;T&gt;"/>
public interface IVirtualListMethods<T> : IVirtualReadOnlyListMethods<T>
{
	/// <summary>Adds an item to the end of the list.</summary>
	/// <param name="item">The object to add to the list.</param>
	void AddItem(T item);

	/// <summary>Inserts an item to the list at the specified index.</summary>
	/// <param name="index">The zero-based index at which item should be inserted.</param>
	/// <param name="item">The object to insert into the list.</param>
	void InsertItemAt(int index, T item);

	/// <summary>Removes the item at the specified index.</summary>
	/// <param name="index">The zero-based index of the item to remove.</param>
	void RemoveItemAt(int index);

	/// <summary>Sets the element at the specified index.</summary>
	/// <param name="index">The zero-based index of the element to set.</param>
	/// <param name="value">The element at the specified index.</param>
	void SetItemAt(int index, T value);
}

/// <summary>
/// Interface that defines the methods for a virtual read-only list. This interface is used by the <see cref="VirtualReadOnlyList{T}"/> class.
/// </summary>
/// <typeparam name="T">The type of the element.</typeparam>
public interface IVirtualReadOnlyListMethods<T>
{
	/// <summary>Gets the number of elements in the collection.</summary>
	/// <returns>The number of elements in the collection.</returns>
	int GetItemCount();

	/// <summary>Tries to get the element at the specified index.</summary>
	/// <param name="index">The zero-based index of the element to get.</param>
	/// <param name="value">The value, if <paramref name="index"/> is a valid index; or <see langword="default"/> if not.</param>
	/// <returns><see langword="true"/> if the list contains an element at the specified index; otherwise, <see langword="false"/>.</returns>
	bool TryGet(int index, [NotNullWhen(true)] out T? value);
}

/// <summary>A virtual list that implements a lot of the scaffolding.</summary>
/// <typeparam name="T">The element type.</typeparam>
public class VirtualList<T> : VirtualReadOnlyList<T>, IList<T>
{
	/// <summary>The implementation.</summary>
	protected readonly IVirtualListMethods<T> impl;

	/// <summary>Initializes a new instance of the <see cref="VirtualList{T}"/> class.</summary>
	public VirtualList(IVirtualListMethods<T> impl) : base(impl) => this.impl = impl;

	/// <inheritdoc/>
	bool ICollection<T>.IsReadOnly => false;

	/// <inheritdoc/>
	public new T this[int index]
	{
		get => base[index];
		set => impl.SetItemAt(index, value);
	}

	/// <inheritdoc/>
	public void Add(T item) => impl.AddItem(item);

	/// <inheritdoc/>
	public void Clear()
	{
		for (int i = Count - 1; i >= 0; i--)
			RemoveAt(i);
	}

	/// <inheritdoc/>
	public void Insert(int index, T item) => impl.InsertItemAt(index, item);

	/// <inheritdoc/>
	public bool Remove(T item)
	{
		int i = IndexOf(item);
		if (i >= 0)
		{
			RemoveAt(i);
			return true;
		}
		return false;
	}

	/// <inheritdoc/>
	public void RemoveAt(int index) => impl.RemoveItemAt(index);

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

/// <summary>Wrapper for <see cref="IVirtualListMethods{T}"/> that allows for the use of delegates instead of implementing the interface.</summary>
/// <typeparam name="T">The element type.</typeparam>
/// <seealso cref="IVirtualListMethods&lt;T&gt;"/>
public class VirtualListMethodCarrier<T> : IVirtualListMethods<T>
{
	/// <summary>Initializes a new instance of the <see cref="VirtualListMethodCarrier{T}"/> class.</summary>
	/// <param name="tryGet">Delegate that tries to get the element at the specified index.</param>
	/// <param name="getCount">Delegate that gets the number of elements in the collection.</param>
	/// <param name="add">Delegate that adds an item to the end of the list.</param>
	/// <param name="insert">Delegate that inserts an item to the list at the specified index.</param>
	/// <param name="removeAt">Delegate that removes the item at the specified index.</param>
	/// <param name="setAt">Delegate that sets the element at the specified index.</param>
	public VirtualListMethodCarrier(VirtualReadOnlyList<T>.TryGetDelegate tryGet, Func<int> getCount, Action<T>? add = null, Action<int, T>? insert = null, Action<int>? removeAt = null, Action<int, T>? setAt = null)
	{
		TryGet = tryGet;
		GetCount = getCount;
		Add = add;
		Insert = insert;
		RemoveAt = removeAt;
		SetAt = setAt;
	}

	/// <summary>Delegate that adds an item to the end of the list.</summary>
	public Action<T>? Add { get; }

	/// <summary>Delegate that gets the number of elements in the collection.</summary>
	public Func<int> GetCount { get; }

	/// <summary>Delegate that inserts an item to the list at the specified index.</summary>
	public Action<int, T>? Insert { get; }

	/// <summary>Delegate that removes the item at the specified index.</summary>
	public Action<int>? RemoveAt { get; }

	/// <summary>Delegate that sets the element at the specified index.</summary>
	public Action<int, T>? SetAt { get; }

	/// <summary>Delegate that tries to get the element at the specified index.</summary>
	public VirtualReadOnlyList<T>.TryGetDelegate TryGet { get; }

	/// <inheritdoc/>
	void IVirtualListMethods<T>.AddItem(T item) => Add?.Invoke(item);

	/// <inheritdoc/>
	int IVirtualReadOnlyListMethods<T>.GetItemCount() => GetCount();

	/// <inheritdoc/>
	void IVirtualListMethods<T>.InsertItemAt(int index, T item) => Insert?.Invoke(index, item);

	/// <inheritdoc/>
	void IVirtualListMethods<T>.RemoveItemAt(int index) => RemoveAt?.Invoke(index);

	/// <inheritdoc/>
	void IVirtualListMethods<T>.SetItemAt(int index, T value) => SetAt?.Invoke(index, value);

	/// <inheritdoc/>
	bool IVirtualReadOnlyListMethods<T>.TryGet(int index, [NotNullWhen(true)] out T? value) => TryGet(index, out value);
}

/// <summary>A virtual read-only list that implements a lot of the scaffolding.</summary>
/// <typeparam name="T">The element type.</typeparam>
public class VirtualReadOnlyList<T> : IReadOnlyList<T>
{
	/// <summary>The read only implementation.</summary>
	protected readonly IVirtualReadOnlyListMethods<T> readOnlyImpl;

	/// <summary>Initializes a new instance of the <see cref="VirtualList{T}"/> class.</summary>
	public VirtualReadOnlyList(IVirtualReadOnlyListMethods<T> impl) => readOnlyImpl = impl;

	/// <summary>Delegate for a method that tries to get the element at the specified index.</summary>
	/// <param name="index">The zero-based index of the element to get.</param>
	/// <param name="value">The value, if <paramref name="index"/> is a valid index; or <see langword="default"/> if not.</param>
	/// <returns><see langword="true"/> if the list contains an element at the specified index; otherwise, <see langword="false"/>.</returns>
	public delegate bool TryGetDelegate(int index, [NotNullWhen(true)] out T? value);

	/// <inheritdoc/>
	public virtual int Count => readOnlyImpl.GetItemCount();

	/// <inheritdoc/>
	public virtual T this[int index] => readOnlyImpl.TryGet(index, out T? v) ? v : throw new ArgumentOutOfRangeException(nameof(index));

	/// <inheritdoc/>
	public virtual bool Contains(T item) => IndexOf(item) >= 0;

	/// <inheritdoc/>
	public virtual void CopyTo(T[] array, int arrayIndex)
	{
		if (array is null)
			throw new ArgumentNullException(nameof(array));
		if (arrayIndex < 0 || arrayIndex > array.Length)
			throw new ArgumentOutOfRangeException(nameof(arrayIndex));
		if (array.Length - arrayIndex < Count)
			throw new ArgumentException("The number of elements in the source ICollection<T> is greater than the available space from arrayIndex to the end of the destination array.");

		for (int i = 0; i < Count; i++)
			array[arrayIndex + i] = this[i];
	}

	/// <inheritdoc/>
	public virtual IEnumerator<T> GetEnumerator()
	{
		for (int i = 0; i < Count; i++)
			yield return this[i];
	}

	/// <inheritdoc/>
	public virtual int IndexOf(T item)
	{
		for (int i = 0; i < Count; i++)
		{
			/* Unmerged change from project 'Vanara.PInvoke.Printing (net48)'
			Before:
							if (Equals(this[i], item))
			After:
					{
						if (Equals(this[i], item))
			*/
			if (Equals(this[i], item))
				return i;
		}

		/* Unmerged change from project 'Vanara.PInvoke.Printing (net48)'
		Before:
					return -1;
		After:
				}

				return -1;
		*/
		return -1;
	}

	/// <inheritdoc/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}