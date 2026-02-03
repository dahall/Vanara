using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

/// <summary>Enumerator with zero copy access using ref.</summary>
/// <typeparam name="T">The structure type.</typeparam>
public unsafe ref struct RefEnumerator<T> where T : unmanaged
{
	private T* _arrayPtr;
	private readonly T* basePtr;
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

/// <summary>Enumerator with zero copy access using ref.</summary>
/// <typeparam name="T">The structure type.</typeparam>
public unsafe ref struct RefEnumeratorEx<T> where T : unmanaged
{
	/// <summary>Delegate to get next element pointer.</summary>
	public unsafe delegate T* GetNextDelegate(T* current);

	private unsafe T* _arrayPtr;
	private unsafe readonly T* basePtr;
	private readonly GetNextDelegate _getNext;

	/// <summary>Create RefEnumerator.</summary>
	/// <param name="arrayPtr">Pointer to unmanaged array</param>
	/// <param name="getNext">Delegate used to advance pointer to next value.</param>
	public RefEnumeratorEx(T* arrayPtr, GetNextDelegate getNext)
	{
		if (getNext is null)
			throw new ArgumentNullException(nameof(getNext));
		_getNext = getNext;
		basePtr = arrayPtr;
	}

	/// <summary>Unsupported default constructor.</summary>
	[Obsolete("Default constructor is not supported.", true)]
	public RefEnumeratorEx() => throw new NotSupportedException();

	/// <summary>Return current element.</summary>
	public ref T Current
	{
		get
		{
			if (_arrayPtr is null)
				throw new InvalidOperationException("Current is undefined.");
			return ref *_arrayPtr;
		}
	}

	/// <summary>Return current element pointer.</summary>
	public readonly unsafe T* CurrentPtr => _arrayPtr;

	/// <summary>Gets the <typeparamref name="T"/> at the specified index.</summary>
	/// <value>The <typeparamref name="T"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns>A reference to <typeparamref name="T"/>.</returns>
	public ref T this[int index]
	{
		get
		{
			for (int i = 0; MoveNext() && i < index; i++) ;
			if (_arrayPtr is null)
				throw new IndexOutOfRangeException();
			return ref *_arrayPtr;
		}
	}

	/// <summary>Move to next element.</summary>
	public bool MoveNext()
	{
		if (_arrayPtr is null)
		{
			_arrayPtr = basePtr;
			return true;
		}

		_arrayPtr = _getNext(_arrayPtr);
		return _arrayPtr is not null;
	}

	/// <summary>Resets this iterator.</summary>
	public void Reset() => _arrayPtr = null;
}