using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Vanara.Collections;

/// <summary>A generic class that creates a read-only dictionary from a list and getter function.</summary>
/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
public class GenericVirtualReadOnlyDictionary<TKey, TValue> : VirtualReadOnlyDictionary<TKey, TValue> where TKey : notnull
{
	private readonly TryGetValueDelegate getValFunc;

	private readonly Func<TKey, bool> hasKeyFunc;

	/// <summary>Initializes a new instance of the <see cref="GenericVirtualReadOnlyDictionary{TKey, TValue}"/> class.</summary>
	/// <param name="keys">The enumerated list of keys.</param>
	/// <param name="getValue">The function used to get a value given a key. Called directly by <c>TryGetValue</c>.</param>
	/// <param name="hasKey">
	/// An optional function to directly determine if a key exists. If not supplied, the default implementation checks for equality on
	/// every value in <paramref name="keys"/>.
	/// </param>
	public GenericVirtualReadOnlyDictionary(IEnumerable<TKey> keys, TryGetValueDelegate getValue, Func<TKey, bool>? hasKey = null)
	{
		Keys = keys ?? throw new ArgumentNullException(nameof(keys));
		getValFunc = getValue ?? throw new ArgumentNullException(nameof(getValue));
		hasKeyFunc = hasKey ?? DefHasKey;
	}

	/// <summary>Delegate for the implementation of the <see cref="TryGetValue(TKey, out TValue)"/> method.</summary>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
	/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
	/// </returns>
	public delegate bool TryGetValueDelegate(TKey key, out TValue value);

	/// <summary>Gets an enumerable collection that contains the keys in the read-only dictionary.</summary>
	/// <value>An enumerable collection that contains the keys in the read-only dictionary.</value>
	public override IEnumerable<TKey> Keys { get; }

	/// <summary>Determines whether the <see cref="IDictionary{TKey, TValue}"/> contains an element with the specified key.</summary>
	/// <param name="key">The key to locate in the <see cref="IDictionary{TKey, TValue}"/>.</param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
	/// </returns>
	public override bool ContainsKey(TKey key) => hasKeyFunc(key);

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
	/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
	/// </returns>
	public override bool TryGetValue(TKey key, out TValue value) => getValFunc(key, out value);

	private bool DefHasKey(TKey k1) => Keys.Any(k2 => Equals(k1, k2));
}

/// <summary>
/// A generic base class for providing a dictionary that gets and sets its values using virtual method calls. Useful for exposing lookups
/// into existing list environments like the file system, registry, service controller, etc.
/// </summary>
/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
public abstract class VirtualDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IDictionary<TKey, TValue> where TKey : notnull
{
	/// <summary>Initializes a new instance of the <see cref="VirtualDictionary{TKey, TValue}"/> class.</summary>
	/// <param name="readOnly">if set to <c>true</c> makes the collection read-only.</param>
	protected VirtualDictionary(bool readOnly) => IsReadOnly = readOnly;

	/// <summary>Gets a value indicating whether this instance is read only.</summary>
	/// <value><see langword="true"/> if this instance is read only; otherwise, <see langword="false"/>.</value>
	public bool IsReadOnly { get; internal set; }

	/// <summary>Gets an <see cref="ICollection{TKey}"/> containing the keys of the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>An <see cref="ICollection{TKey}"/> containing the keys of the object that implements <see cref="IDictionary{TKey, TValue}"/>.</value>
	public abstract ICollection<TKey> Keys { get; }

	/// <summary>Gets an <see cref="ICollection{TValue}"/> containing the values in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>An <see cref="ICollection{TValue}"/> containing the values in the object that implements <see cref="IDictionary{TKey, TValue}"/>.</value>
	/// <remarks>
	/// The order of the keys in the enumerable collection is unspecified, but the implementation must guarantee that the values are in
	/// the same order as the corresponding keys in the enumerable collection that is returned by the <see cref="Keys"/> property.
	/// </remarks>
	public virtual ICollection<TValue> Values => Keys.Select(k => this[k]).ToList();

	/// <summary>Gets the number of elements contained in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>The number of elements contained in the <see cref="IDictionary{TKey, TValue}"/>.</value>
	public virtual int Count => Keys.Count;

	/// <summary>Gets an enumerable collection that contains the keys in the read-only dictionary.</summary>
	/// <value>An enumerable collection that contains the keys in the read-only dictionary.</value>
	/// <remarks>
	/// The order of the keys in the enumerable collection is unspecified, but the implementation must guarantee that the keys are in the
	/// same order as the corresponding values in the enumerable collection that is returned by the <see cref="Values"/> property.
	/// </remarks>
	IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

	/// <summary>Gets an <see cref="ICollection{TValue}"/> containing the values in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>An <see cref="ICollection{TValue}"/> containing the values in the object that implements <see cref="IDictionary{TKey, TValue}"/>.</value>
	IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

	/// <summary>Gets the enumerated list of items.</summary>
	/// <value>The enumerated list of items.</value>
	protected virtual IEnumerable<KeyValuePair<TKey, TValue>> Items =>
		Keys.Select(k => new KeyValuePair<TKey, TValue>(k, this[k]));

	/// <summary>Gets or sets the <typeparamref name="TValue"/> with the specified key.</summary>
	/// <value>The <typeparamref name="TValue"/>.</value>
	/// <param name="key">The key.</param>
	/// <returns>The <typeparamref name="TValue"/> with the specified key.</returns>
	public virtual TValue this[TKey key]
	{
		get => TryGetValue(key, out var value) ? value : throw new KeyNotFoundException(nameof(key));
		set => SetValue(key, value);
	}

	/// <summary>Adds an element with the provided key and value to the <see cref="T:System.Collections.Generic.IDictionary`2"/>.</summary>
	/// <param name="key">The object to use as the key of the element to add.</param>
	/// <param name="value">The object to use as the value of the element to add.</param>
	public virtual void Add(TKey key, TValue value) => SetValue(key, value);

	/// <summary>Removes all items from the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	public virtual void Clear()
	{
		foreach (var key in Keys.ToList())
			Remove(key);
	}

	/// <summary>Determines whether the <see cref="IDictionary{TKey, TValue}"/> contains an element with the specified key.</summary>
	/// <param name="key">The key to locate in the <see cref="IDictionary{TKey, TValue}"/>.</param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
	/// </returns>
	public virtual bool ContainsKey(TKey key) => Keys.Contains(key);

	/// <summary>
	/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting
	/// at a particular <see cref="T:System.Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from
	/// <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
	{
		var items = Items.ToArray();
		Array.Copy(items, 0, array, arrayIndex, items.Length);
	}

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>An enumerator that can be used to iterate through the collection.</returns>
	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Items.GetEnumerator();

	/// <summary>Removes the element with the specified key from the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <param name="key">The key of the element to remove.</param>
	/// <returns>
	/// <see langword="true"/> if the element is successfully removed; otherwise, <see langword="false"/>. This method also returns false
	/// if key was not found in the original <see cref="IDictionary{TKey, TValue}"/>.
	/// </returns>
	public virtual bool Remove(TKey key) => throw new NotSupportedException();

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
	/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
	/// </returns>
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
	public abstract bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

	/// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
	/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
	void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item) => SetValue(item.Key, item.Value);

	/// <summary>Determines whether this instance contains the object.</summary>
	/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
	/// </returns>
	bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item) =>
		ContainsKey(item.Key) && Equals(this[item.Key], item.Value);

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>
	/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </summary>
	/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1" />.</param>
	/// <returns>
	/// true if <paramref name="item" /> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1" />; otherwise, false. This method also returns false if <paramref name="item" /> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1" />.
	/// </returns>
	bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item) => ((ICollection<KeyValuePair<TKey, TValue>>)this).Contains(item) && Remove(item.Key);

	/// <summary>
	/// Sets the value that is associated with the specified key. If the value for <paramref name="key"/> does not exist, this method
	/// should create it. If the value does exist, this method should update it to match <paramref name="value"/>.
	/// </summary>
	/// <param name="key">The key for which to set the data.</param>
	/// <param name="value">The value to associate with the key.</param>
	protected virtual void SetValue(TKey key, TValue value) => throw new NotSupportedException();
}

/// <summary>
/// A generic base class for providing a read-only dictionary that gets its values using virtual method calls. Useful for exposing
/// lookups into existing list environments like the file system, registry, service controller, etc.
/// </summary>
/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
public abstract class VirtualReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue> where TKey : notnull
{
	/// <summary>Gets an enumerable collection that contains the keys in the read-only dictionary.</summary>
	/// <value>An enumerable collection that contains the keys in the read-only dictionary.</value>
	/// <remarks>
	/// The order of the keys in the enumerable collection is unspecified, but the implementation must guarantee that the keys are in the
	/// same order as the corresponding values in the enumerable collection that is returned by the <see cref="Values"/> property.
	/// </remarks>
	public abstract IEnumerable<TKey> Keys { get; }

	/// <inheritdoc/>
	/// <summary>Gets an <see cref="ICollection{TValue}"/> containing the values in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>An <see cref="ICollection{TValue}"/> containing the values in the object that implements <see cref="IDictionary{TKey, TValue}"/>.</value>
	public virtual IEnumerable<TValue> Values => Keys.Select(k => this[k]).ToList();

	/// <summary>Gets the number of elements contained in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>The number of elements contained in the <see cref="IDictionary{TKey, TValue}"/>.</value>
	public virtual int Count => Keys.Count();

	/// <summary>Gets the enumerated list of items.</summary>
	/// <value>The enumerated list of items.</value>
	protected IEnumerable<KeyValuePair<TKey, TValue>> Items =>
		Keys.Select(k => new KeyValuePair<TKey, TValue>(k, this[k]));

	/// <summary>Gets the <typeparamref name="TValue"/> with the specified key.</summary>
	/// <value>The element with the specified key.</value>
	/// <param name="key">The key of the element to get.</param>
	public virtual TValue this[TKey key] => TryGetValue(key, out var value) ? value : throw new KeyNotFoundException(nameof(key));

	/// <summary>Determines whether the <see cref="IDictionary{TKey, TValue}"/> contains an element with the specified key.</summary>
	/// <param name="key">The key to locate in the <see cref="IDictionary{TKey, TValue}"/>.</param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
	/// </returns>
	public abstract bool ContainsKey(TKey key);

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>An enumerator that can be used to iterate through the collection.</returns>
	public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Items.GetEnumerator();

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
	/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, <see langword="false"/>.
	/// </returns>
#pragma warning disable CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).
	public abstract bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value);
#pragma warning restore CS8767 // Nullability of reference types in type of parameter doesn't match implicitly implemented member (possibly because of nullability attributes).

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}