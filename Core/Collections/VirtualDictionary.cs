using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vanara.Collections
{
	/// <summary>
	/// A generic base class for providing a dictionary that gets and sets its values using virtual method calls. Useful for exposing lookups
	/// into existing list environments like the file system, registry, service controller, etc.
	/// </summary>
	/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
	public abstract class VirtualDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>, IDictionary<TKey, TValue>
	{
		/// <summary>Initializes a new instance of the <see cref="VirtualDictionary{TKey, TValue}"/> class.</summary>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		protected VirtualDictionary(bool readOnly)
		{
			IsReadOnly = readOnly;
		}

		/// <summary>Gets the number of elements in the collection.</summary>
		/// <value>The number of elements in the collection.</value>
		public virtual int Count => Keys.Count;

		/// <inheritdoc />
		public bool IsReadOnly { get; internal set; }

		/// <inheritdoc />
		public abstract ICollection<TKey> Keys { get; }

		/// <inheritdoc />
		IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Keys;

		/// <inheritdoc />
		public virtual ICollection<TValue> Values => Keys.Select(k => this[k]).ToList();

		/// <inheritdoc />
		IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Values;

		/// <summary>Gets the enumerated list of items.</summary>
		/// <value>The enumerated list of items.</value>
		protected IEnumerable<KeyValuePair<TKey, TValue>> Items =>
			Keys.Select(k => new KeyValuePair<TKey, TValue>(k, this[k]));

		/// <summary>Gets or sets the <see cref="TValue"/> with the specified key.</summary>
		/// <value>The <see cref="TValue"/>.</value>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		public virtual TValue this[TKey key]
		{
			get => TryGetValue(key, out var value) ? value : default;
			set => SetValue(key, value);
		}

		/// <inheritdoc />
		public void Add(TKey key, TValue value) => SetValue(key, value);

		/// <inheritdoc />
		public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

		/// <inheritdoc />
		public virtual void Clear()
		{
			foreach (var key in Keys.ToList())
				Remove(key);
		}

		/// <inheritdoc />
		public bool Contains(KeyValuePair<TKey, TValue> item) =>
			ContainsKey(item.Key) && Equals(this[item.Key], item.Value);

		/// <summary>Determines whether the read-only dictionary contains an element that has the specified key.</summary>
		/// <param name="key">The key to locate.</param>
		/// <returns>
		/// <see langword="true"/> if the read-only dictionary contains an element that has the specified key; otherwise, <see langword="false"/>.
		/// </returns>
		public abstract bool ContainsKey(TKey key);

		/// <inheritdoc />
		public virtual void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			var items = Items.ToArray();
			Array.Copy(items, 0, array, arrayIndex, items.Length);
		}

		/// <inheritdoc />
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Items.GetEnumerator();

		/// <inheritdoc />
		public abstract bool Remove(TKey key);

		/// <inheritdoc />
		public bool Remove(KeyValuePair<TKey, TValue> item) => Contains(item) && Remove(item.Key);

		/// <summary>Gets the value that is associated with the specified key.</summary>
		/// <param name="key">The key to locate.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
		/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// <see langword="true"/> if the object that implements the <see cref="IReadOnlyDictionary{TKey,TValue}"/>
		/// interface contains an element that has the specified key; otherwise, <see langword="false"/>.
		/// </returns>
		public abstract bool TryGetValue(TKey key, out TValue value);

		/// <summary>
		/// Sets the value that is associated with the specified key. If the value for <paramref name="key"/> does not exist, this method
		/// should create it. If the value does exist, this method should update it to match <paramref name="value"/>.
		/// </summary>
		/// <param name="key">The key for which to set the data.</param>
		/// <param name="value">The value to associate with the key.</param>
		protected abstract void SetValue(TKey key, TValue value);

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	/// <summary>
	/// A generic base class for providing a read-only dictionary that gets its values using virtual method calls. Useful for exposing lookups
	/// into existing list environments like the file system, registry, service controller, etc.
	/// </summary>
	/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
	/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
	public abstract class VirtualReadOnlyDictionary<TKey, TValue> : IReadOnlyDictionary<TKey, TValue>
	{
		/// <inheritdoc />
		public abstract IEnumerable<TKey> Keys { get; }

		/// <inheritdoc />
		public virtual int Count => Keys.Count();

		/// <inheritdoc />
		public virtual IEnumerable<TValue> Values => Keys.Select(k => this[k]).ToList();

		/// <summary>Gets the enumerated list of items.</summary>
		/// <value>The enumerated list of items.</value>
		protected IEnumerable<KeyValuePair<TKey, TValue>> Items =>
			Keys.Select(k => new KeyValuePair<TKey, TValue>(k, this[k]));

		/// <inheritdoc />
		public virtual TValue this[TKey key] => TryGetValue(key, out var value) ? value : default;

		/// <inheritdoc />
		public abstract bool ContainsKey(TKey key);

		/// <inheritdoc />
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => Items.GetEnumerator();

		/// <inheritdoc />
		public abstract bool TryGetValue(TKey key, out TValue value);

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	/// <summary>A generic class that creates a read-only dictionary from a list and getter function.</summary>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	/// <typeparam name="TValue">The type of the value.</typeparam>
	public class GenericVirtualReadOnlyDictionaryy<TKey, TValue> : VirtualReadOnlyDictionary<TKey, TValue>
	{
		public delegate bool TryGetValueDelegate(TKey key, out TValue value);

		private readonly TryGetValueDelegate getValFunc;
		private readonly Func<TKey, bool> hasKeyFunc;

		/// <summary>Initializes a new instance of the <see cref="GenericVirtualReadOnlyDictionaryy{TKey, TValue}"/> class.</summary>
		/// <param name="keys">The enumerated list of keys.</param>
		/// <param name="getValue">The function used to get a value given a key. Called directly by <c>TryGetValue</c>.</param>
		/// <param name="hasKey">
		/// An optional function to directly determine if a key exists. If not supplied, the default implementation checks for equality on
		/// every value in <paramref name="keys"/>.
		/// </param>
		public GenericVirtualReadOnlyDictionaryy(IEnumerable<TKey> keys, TryGetValueDelegate getValue, Func<TKey, bool> hasKey = null)
		{
			Keys = keys ?? throw new ArgumentNullException(nameof(keys));
			getValFunc = getValue ?? throw new ArgumentNullException(nameof(getValue));
			hasKeyFunc = hasKey ?? DefHasKey;
		}

		/// <inheritdoc />
		public override IEnumerable<TKey> Keys { get; }

		/// <inheritdoc />
		public override bool ContainsKey(TKey key) => hasKeyFunc(key);

		/// <inheritdoc />
		public override bool TryGetValue(TKey key, out TValue value) => getValFunc(key, out value);

		private bool DefHasKey(TKey k1) => Keys.Any(k2 => Equals(k1, k2));
	}
}