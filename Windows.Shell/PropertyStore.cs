using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell
{
	/// <summary>Encapsulates the IPropertyStore object.</summary>
	/// <seealso cref="IDictionary{PROPERTYKEY, Object}"/>
	/// <seealso cref="System.IDisposable"/>
	public class PropertyStore : IDictionary<PROPERTYKEY, object>, IDisposable, INotifyPropertyChanged
	{
		/// <summary>The IPropertyStore instance. This can be null.</summary>
		protected IPropertyStore iprops;

		/// <summary>Initializes a new instance of the <see cref="PropertyStore"/> class.</summary>
		protected PropertyStore() { }

		/// <summary>Initializes a new instance of the <see cref="PropertyStore"/> class.</summary>
		/// <param name="ps">The ps.</param>
		protected PropertyStore(IPropertyStore ps) { iprops = ps; }

		/// <summary>Occurs when a property value changes.</summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>Gets the number of properties in the current property store.</summary>
		public int Count => (int)(iprops?.GetCount() ?? 0);

		/// <summary>Gets or sets a value indicating whether this property store has uncommitted changes.</summary>
		/// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
		public bool IsDirty { get; protected set; }

		/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
		public virtual bool IsReadOnly => false;

		/// <summary>Gets an <see cref="ICollection{T}"/> containing the keys of the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</summary>
		public ICollection<PROPERTYKEY> Keys
		{
			get
			{
				var keys = new List<PROPERTYKEY>(Count);
				for (uint i = 0; i < Count; i++)
					keys.Add(iprops.GetAt(i));
				return keys;
			}
		}

		/// <summary>Gets an <see cref="ICollection{T}"/> containing the values in the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</summary>
		public ICollection<object> Values
		{
			get
			{
				var vals = new List<object>(Count);
				for (uint i = 0; i < Count; i++)
					vals.Add(this[iprops.GetAt(i)]);
				return vals;
			}
		}

		/// <summary>Gets or sets the value of the property with the specified known key.</summary>
		/// <value>The value.</value>
		/// <param name="knownKey">The known key of the property (e.g. "System.Title"}.</param>
		/// <returns>The value of the property.</returns>
		public object this[string knownKey]
		{
			get => this[GetPropertyKeyFromName(knownKey)];
			set => this[GetPropertyKeyFromName(knownKey)] = value;
		}

		/// <summary>Gets or sets the value of the property with the specified PROPERTYKEY.</summary>
		/// <value>The value.</value>
		/// <param name="key">The PROPERTYKEY of the property.</param>
		/// <returns>The value of the property.</returns>
		public object this[PROPERTYKEY key]
		{
			get
			{
				if (!TryGetValue(key, out object r))
					throw new ArgumentOutOfRangeException(nameof(key));
				return r;
			}
			set
			{
				if (iprops == null)
					throw new InvalidOperationException("Property store does not exist.");
				if (IsReadOnly)
					throw new InvalidOperationException("Property store is read-only.");
				iprops.SetValue(key, new PROPVARIANT(value));
				OnPropertyChanged(key.ToString());
			}
		}

		/// <summary>Gets the property key for a canonical property name.</summary>
		/// <param name="name">A property name.</param>
		/// <returns>The requested property key.</returns>
		public static PROPERTYKEY GetPropertyKeyFromName(string name)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			var hr = PSGetPropertyKeyFromName(name, out var pk);
			if (hr == HRESULT.TYPE_E_ELEMENTNOTFOUND) throw new ArgumentOutOfRangeException(nameof(name));
			hr.ThrowIfFailed();
			return pk;
		}

		/// <summary>Adds a property with the provided key and value to the property store.</summary>
		/// <param name="key">The PROPERTYKEY for the new property.</param>
		/// <param name="value">The value of the new property.</param>
		public void Add(PROPERTYKEY key, object value)
		{
			if (iprops == null)
				throw new InvalidOperationException("Property store does not exist.");
			iprops.SetValue(key, new PROPVARIANT(value));
			OnPropertyChanged(key.ToString());
		}

		/// <summary>Commits all changes to the property store.</summary>
		public void Commit() { iprops?.Commit(); IsDirty = false; }

		/// <summary>Determines whether the <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the specified key.</summary>
		/// <param name="key">The key to locate in the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</param>
		/// <returns>true if the <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the key; otherwise, false.</returns>
		public bool ContainsKey(PROPERTYKEY key) => Keys.Contains(key);

		/// <summary>
		/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="T:System.Array"/>, starting at a particular
		/// <see cref="T:System.Array"/> index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from
		/// <see cref="ICollection{T}"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
		/// <exception cref="ArgumentOutOfRangeException">arrayIndex - The number of items exceeds the length of the supplied array.</exception>
		/// <exception cref="ArgumentNullException">array</exception>
		public void CopyTo(KeyValuePair<PROPERTYKEY, object>[] array, int arrayIndex)
		{
			if (array.Length < (arrayIndex + Count))
				throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The number of items exceeds the length of the supplied array.");
			if (array == null)
				throw new ArgumentNullException(nameof(array));
			var i = arrayIndex;
			foreach (var kv in this)
				array[i++] = kv;
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose()
		{
			if (iprops != null)
			{
				if (IsDirty) Commit();
				Marshal.ReleaseComObject(iprops);
				iprops = null;
			}
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<KeyValuePair<PROPERTYKEY, object>> GetEnumerator() => Enum().GetEnumerator();

		/// <summary>Gets the property.</summary>
		/// <typeparam name="TVal">The type of the value.</typeparam>
		/// <param name="key">The key.</param>
		/// <returns>The cast value of the property.</returns>
		/// <exception cref="ArgumentOutOfRangeException">key</exception>
		public TVal GetProperty<TVal>(PROPERTYKEY key)
		{
			if (!TryGetValue<TVal>(key, out var ret))
				throw new ArgumentOutOfRangeException(nameof(key));
			return ret;
		}

		/// <summary>Gets the string value of the property.</summary>
		/// <param name="key">The key.</param>
		/// <param name="flags">The formatting flags.</param>
		/// <returns>The string value of the property.</returns>
		/// <exception cref="ArgumentOutOfRangeException">key</exception>
		public string GetPropertyString(PROPERTYKEY key, PROPDESC_FORMAT_FLAGS flags = PROPDESC_FORMAT_FLAGS.PDFF_DEFAULT)
		{
			if (!TryGetValue(key, out PROPVARIANT ret))
				throw new ArgumentOutOfRangeException(nameof(key));
			return new PropertyDescription(key).FormatForDisplay(ret, flags);
		}

		/// <summary>Gets the PROPVARIANT value for a key.</summary>
		/// <param name="key">The key.</param>
		/// <returns>The PROPVARIANT value.</returns>
		/// <exception cref="ArgumentOutOfRangeException">key</exception>
		public PROPVARIANT GetPropVariant(PROPERTYKEY key)
		{
			if (!TryGetValue(key, out PROPVARIANT ret))
				throw new ArgumentOutOfRangeException(nameof(key));
			return ret;
		}

		/// <summary>Gets the value associated with the specified key.</summary>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the
		/// <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// true if the object that implements <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		public bool TryGetValue(PROPERTYKEY key, out object value)
		{
			var ret = TryGetValue(key, out PROPVARIANT pv);
			value = ret ? pv.Value : null;
			return ret;
		}

		/// <summary>Gets the value associated with the specified key.</summary>
		/// <typeparam name="TVal">The type of the returned value.</typeparam>
		/// <param name="key">The key whose value to get.</param>
		/// <param name="value">
		/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the
		/// <paramref name="value"/> parameter. This parameter is passed uninitialized.
		/// </param>
		/// <returns>
		/// true if the object that implements <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		public bool TryGetValue<TVal>(PROPERTYKEY key, out TVal value)
		{
			var ret = TryGetValue(key, out PROPVARIANT val);
			value = ret ? (TVal)val.Value : default(TVal);
			return ret;
		}

		/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
		void ICollection<KeyValuePair<PROPERTYKEY, object>>.Add(KeyValuePair<PROPERTYKEY, object> item) { Add(item.Key, item.Value); }

		/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
		/// <exception cref="InvalidOperationException"></exception>
		void ICollection<KeyValuePair<PROPERTYKEY, object>>.Clear() { throw new InvalidOperationException(); }

		/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
		/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
		/// <returns>true if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, false.</returns>
		bool ICollection<KeyValuePair<PROPERTYKEY, object>>.Contains(KeyValuePair<PROPERTYKEY, object> item) => TryGetValue(item.Key, out object o) && Equals(o, item.Value);

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Removes the element with the specified key from the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</summary>
		/// <param name="key">The key of the element to remove.</param>
		/// <returns>
		/// true if the element is successfully removed; otherwise, false. This method also returns false if <paramref name="key"/> was not found in the original <see cref="IDictionary{PROPERTYKEY, Object}"/>.
		/// </returns>
		/// <exception cref="InvalidOperationException"></exception>
		bool IDictionary<PROPERTYKEY, object>.Remove(PROPERTYKEY key) { throw new InvalidOperationException(); }

		/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
		/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise, false. This
		/// method also returns false if <paramref name="item"/> is not found in the original <see cref="ICollection{T}"/>.
		/// </returns>
		/// <exception cref="InvalidOperationException"></exception>
		bool ICollection<KeyValuePair<PROPERTYKEY, object>>.Remove(KeyValuePair<PROPERTYKEY, object> item) { throw new InvalidOperationException(); }

		/// <summary>Called when a property has changed.</summary>
		protected virtual void OnPropertyChanged(string propertyName)
		{
			IsDirty = true;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private IEnumerable<KeyValuePair<PROPERTYKEY, object>> Enum()
		{
			for (uint i = 0; i < Count; i++)
			{
				var k = iprops.GetAt(i);
				yield return new KeyValuePair<PROPERTYKEY, object>(k, this[k]);
			}
			yield break;
		}

		private bool TryGetValue(PROPERTYKEY key, out PROPVARIANT value)
		{
			if (iprops != null)
			{
				try
				{
					var pv = new PROPVARIANT();
					iprops.GetValue(ref key, pv);
					value = pv;
					return true;
				}
				catch { }
			}
			value = null;
			return false;
		}
	}
}