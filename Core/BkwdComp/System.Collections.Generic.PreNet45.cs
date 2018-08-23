#if (NET20 || NET35 || NET40)
namespace System.Collections.Generic
{
	/// <summary>Represents a strongly-typed, read-only collection of elements.</summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	/// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
	public interface IReadOnlyCollection<T> : IEnumerable<T>
	{
		/// <summary>Gets the number of elements in the collection.</summary>
		/// <value>The number of elements in the collection.</value>
		int Count { get; }
	}

	/// <summary>Represents a generic read-only collection of key/value pairs.</summary>
	/// <typeparam name="TKey">The type of keys in the read-only dictionary.</typeparam>
	/// <typeparam name="TValue">The type of values in the read-only dictionary.</typeparam>
	public interface IReadOnlyDictionary<TKey, TValue> : IReadOnlyCollection<KeyValuePair<TKey, TValue>>
	{
		/// <summary>Determines whether the read-only dictionary contains an element that has the specified key.</summary>
		/// <param name="key">The key to locate.</param>
		/// <returns>
		/// <see langword="true"/> if the read-only dictionary contains an element that has the specified key; otherwise, <see langword="false"/>.
		/// </returns>
		bool ContainsKey(TKey key);
		/// <summary>Gets the value that is associated with the specified key.</summary>
		/// <param name="key">The key to locate.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
		/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// <see langword="true"/> if the object that implements the <see cref="IReadOnlyDictionary{TKey, TValue}"/> interface contains an
		/// element that has the specified key; otherwise, <see langword="false"/>.
		/// </returns>
		bool TryGetValue(TKey key, out TValue value);
		/// <summary>Gets the element that has the specified key in the read-only dictionary.</summary>
		/// <value>The key to locate.</value>
		/// <returns>The element that has the specified key in the read-only dictionary.</returns>
		TValue this[TKey key] { get; }
		/// <summary>Gets an enumerable collection that contains the keys in the read-only dictionary.</summary>
		/// <value>An enumerable collection that contains the keys in the read-only dictionary.</value>
		IEnumerable<TKey> Keys { get; }
		/// <summary>Gets an enumerable collection that contains the values in the read-only dictionary.</summary>
		/// <value>An enumerable collection that contains the values in the read-only dictionary.</value>
		IEnumerable<TValue> Values { get; }
	}

	/// <summary>Represents a read-only collection of elements that can be accessed by index.</summary>
	/// <typeparam name="T">The type of elements in the read-only list.</typeparam>
	/// <seealso cref="System.Collections.Generic.IReadOnlyCollection{T}"/>
	public interface IReadOnlyList<T> : IReadOnlyCollection<T>
	{
		/// <summary>Gets the element at the specified index in the read-only list.</summary>
		/// <value>The element at the specified index in the read-only list.</value>
		/// <param name="index">The zero-based index of the element to get.</param>
		T this[int index] { get; }
	}
}
#endif