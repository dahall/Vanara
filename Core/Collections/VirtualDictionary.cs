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

		/// <inheritdoc />
		public bool IsReadOnly { get; internal set; }

		/// <inheritdoc />
		public abstract ICollection<TKey> Keys { get; }

		/// <summary>Gets the number of elements in the collection.</summary>
		/// <value>The number of elements in the collection.</value>
		public virtual int Count => Keys.Count();

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
			get => TryGetValue(key, out var value) ? value : default(TValue);
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
}