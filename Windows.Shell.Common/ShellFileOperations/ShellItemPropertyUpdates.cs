using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Vanara.Collections;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell;

/// <summary>
/// A dictionary of properties that can be used to set or update property values on Shell items via the <see
/// cref="ShellFileOperations.QueueApplyPropertiesOperation(ShellItem, ShellItemPropertyUpdates)"/> method. This class wraps the <see
/// cref="IPropertyChangeArray"/> COM interface.
/// </summary>
/// <seealso cref="IDictionary{TKey, TValue}"/>
/// <seealso cref="IDisposable"/>
public class ShellItemPropertyUpdates : IDictionary<PROPERTYKEY, object?>, IDisposable
{
	private IPropertyChangeArray changes;

	/// <summary>Initializes a new instance of the <see cref="ShellItemPropertyUpdates"/> class.</summary>
	public ShellItemPropertyUpdates() => PSCreatePropertyChangeArray(null, null, null, 0, typeof(IPropertyChangeArray).GUID, out changes).ThrowIfFailed();

	/// <summary>Finalizes an instance of the <see cref="ShellItemPropertyUpdates"/> class.</summary>
	~ShellItemPropertyUpdates() => Dispose(false);

	/// <summary>Gets the number of elements contained in the <see cref="ICollection{T}"/>.</summary>
	public int Count => (int)changes.GetCount();

	/// <summary>Gets the COM interface for <see cref="IPropertyChangeArray"/>.</summary>
	/// <value>The <see cref="IPropertyChangeArray"/> value.</value>
	public IPropertyChangeArray IPropertyChangeArray => changes;

	/// <summary>Gets an <see cref="ICollection{T}"/> containing the keys of the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	public ICollection<PROPERTYKEY> Keys
	{
		get
		{
			var l = new List<PROPERTYKEY>(Count);
			for (uint i = 0; i < Count; i++)
			{
				using var p = new ComReleaser<IPropertyChange>(changes.GetAt<IPropertyChange>(i));
				l.Add(p.Item.GetPropertyKey());
			}
			return l;
		}
	}

	/// <summary>Gets an <see cref="ICollection{T}"/> containing the values in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	public ICollection<object?> Values
	{
		get
		{
			var l = new List<object?>(Count);
			for (int i = 0; i < Count; i++)
				l.Add(this[i].Value);
			return l;
		}
	}

	/// <summary>Gets a value indicating whether the <see cref="ICollection{T}"/> is read-only.</summary>
	bool ICollection<KeyValuePair<PROPERTYKEY, object?>>.IsReadOnly => false;

	/// <summary>Gets or sets the <see cref="object"/> with the specified key.</summary>
	/// <value>The <see cref="object"/>.</value>
	/// <param name="key">The key.</param>
	/// <returns>The object associated with <paramref name="key"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">key</exception>
	public object? this[PROPERTYKEY key]
	{
		get => TryGetValue(key, out var value) ? value : throw new ArgumentOutOfRangeException(nameof(key));
		set => changes.AppendOrReplace(ToPC(key, value));
	}

	internal KeyValuePair<PROPERTYKEY, object?> this[int index]
	{
		get
		{
			using var p = new ComReleaser<IPropertyChange>(changes.GetAt<IPropertyChange>((uint)index));
			p.Item.ApplyToPropVariant(new PROPVARIANT(), out var pv);
			return new KeyValuePair<PROPERTYKEY, object?>(p.Item.GetPropertyKey(), pv.Value);
		}
	}

	/// <summary>Adds an element with the provided key and value to the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <param name="key">The object to use as the key of the element to add.</param>
	/// <param name="value">The object to use as the value of the element to add.</param>
	public void Add(PROPERTYKEY key, object? value) => changes.Append(ToPC(key, value));

	/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
	public void Clear()
	{
		for (uint i = (uint)Count - 1; i >= 0; i--)
			changes.RemoveAt(i);
	}

	/// <summary>Determines whether the <see cref="IDictionary{TKey, TValue}"/> contains an element with the specified key.</summary>
	/// <param name="key">The key to locate in the <see cref="IDictionary{TKey, TValue}"/>.</param>
	/// <returns>true if the <see cref="IDictionary{TKey, TValue}"/> contains an element with the key; otherwise, false.</returns>
	public bool ContainsKey(PROPERTYKEY key) => changes.IsKeyInArray(key).Succeeded;

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<KeyValuePair<PROPERTYKEY, object?>> GetEnumerator() =>
		new IEnumFromIndexer<KeyValuePair<PROPERTYKEY, object?>>(changes.GetCount, i => this[(int)i]).GetEnumerator();

	/// <summary>Removes the element with the specified key from the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <param name="key">The key of the element to remove.</param>
	/// <returns>
	/// true if the element is successfully removed; otherwise, false. This method also returns false if <paramref name="key"/> was not
	/// found in the original <see cref="IDictionary{TKey, TValue}"/>.
	/// </returns>
	public bool Remove(PROPERTYKEY key)
	{
		var idx = IndexOf(key);
		if (idx == -1) return false;
		try { changes.RemoveAt((uint)idx); return true; } catch { return false; }
	}

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
	/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// true if the object that implements <see cref="IDictionary{TKey, TValue}"/> contains an element with the specified key;
	/// otherwise, false.
	/// </returns>
	public bool TryGetValue(PROPERTYKEY key, [NotNullWhen(true)] out object? value)
	{
		value = null;
		var idx = IndexOf(key);
		if (idx == -1) return false;
		try { value = this[idx]; return true; } catch { return false; }
	}

	void ICollection<KeyValuePair<PROPERTYKEY, object?>>.Add(KeyValuePair<PROPERTYKEY, object?> item) =>
		Add(item.Key, item.Value);

	bool ICollection<KeyValuePair<PROPERTYKEY, object?>>.Contains(KeyValuePair<PROPERTYKEY, object?> item) =>
		ContainsKey(item.Key) && this[item.Key] == item.Value;

	void ICollection<KeyValuePair<PROPERTYKEY, object?>>.CopyTo(KeyValuePair<PROPERTYKEY, object?>[] array, int arrayIndex)
	{
		if (array == null) throw new ArgumentNullException(nameof(array));
		if (arrayIndex + Count > array.Length) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
		for (int i = 0; i < Count; i++)
			array[i + arrayIndex] = this[i];
	}

	void IDisposable.Dispose() { Dispose(true); GC.SuppressFinalize(this); }

	/// <summary>Releases the unmanaged resources used by the object and optionally releases the managed resources.</summary>
	/// <remarks>
	/// This method is called by both the public Dispose() method and the finalizer. When disposing is <see langword="true"/>, managed
	/// resources can be disposed. Override this method to release resources specific to the derived class.
	/// </remarks>
	/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
	protected virtual void Dispose(bool disposing)
	{
		if (changes is not null)
		{
			Marshal.FinalReleaseComObject(changes);
			changes = null!;
		}
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	bool ICollection<KeyValuePair<PROPERTYKEY, object?>>.Remove(KeyValuePair<PROPERTYKEY, object?> item)
	{
		var idx = IndexOf(item.Key);
		if (idx == -1) return false;
		if (this[idx].Value != item.Value) return false;
		try { changes.RemoveAt((uint)idx); return true; } catch { return false; }
	}

	private int IndexOf(PROPERTYKEY key)
	{
		for (uint i = 0; i < Count; i++)
		{
			using var p = new ComReleaser<IPropertyChange>(changes.GetAt<IPropertyChange>(i));
			if (key == p.Item.GetPropertyKey())
				return (int)i;
		}
		return -1;
	}

	private IPropertyChange ToPC(PROPERTYKEY key, object? value, PKA_FLAGS flags = PKA_FLAGS.PKA_SET)
	{
		PSCreateSimplePropertyChange(flags, key, new PROPVARIANT(value), typeof(IPropertyChange).GUID, out var pc).ThrowIfFailed();
		return pc;
	}
}