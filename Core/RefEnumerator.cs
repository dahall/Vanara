namespace Vanara.PInvoke;

/// <summary>Enumerator with zero copy access using ref.</summary>
/// <typeparam name="T">The structure type.</typeparam>
public unsafe ref struct RefEnumerator<T> where T : unmanaged
{
	private T* _arrayPtr, basePtr;
	private int _index;

	/// <summary>Create RefEnumerator.</summary>
	/// <param name="arrayPtr">Pointer to unmanaged array</param>
	/// <param name="count">Number of elements in the <paramref name="arrayPtr"/></param>
	public RefEnumerator(T* arrayPtr, int count)
	{
		_arrayPtr = basePtr = arrayPtr;
		Count = count;
		_index = -1;
	}

	/// <summary>Gets the number of elements available.</summary>
	/// <value>The number of elements available.</value>
	public int Count { get; private set; }

	/// <summary>Return current element.</summary>
	public ref T Current => ref *_arrayPtr;

	/// <summary>Gets the <typeparamref name="T"/> at the specified index.</summary>
	/// <value>The <typeparamref name="T"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns>A reference to <typeparamref name="T"/>.</returns>
	public ref T this[int index] => ref _arrayPtr[index];

	/// <summary>Move to next element.</summary>
	public bool MoveNext()
	{
		int index = _index + 1;
		if (index < Count)
		{
			_index = index;
			_arrayPtr++;
			return true;
		}
		return false;
	}

	/// <summary>Resets this iterator.</summary>
	public void Reset()
	{
		_arrayPtr = basePtr;
		_index = -1;
	}
}