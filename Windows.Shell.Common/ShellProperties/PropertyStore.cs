using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Vanara.PInvoke;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.Shell32;
using System.Collections;

namespace Vanara.Windows.Shell;

/// <summary>Encapsulates the IPropertyStore object.</summary>
/// <seealso cref="IDictionary{PROPERTYKEY, Object}"/>
/// <seealso cref="IDisposable"/>
public class PropertyStore : IDictionary<PROPERTYKEY, object?>, IDisposable, INotifyPropertyChanged
{
	/// <summary>The flags.</summary>
	protected GETPROPERTYSTOREFLAGS flags = GETPROPERTYSTOREFLAGS.GPS_DEFAULT;

	/// <summary>An optional IBindCtx object, which provides access to a bind context.</summary>
	protected System.Runtime.InteropServices.ComTypes.IBindCtx? iBindCtx = null;

	/// <summary>If specified, the path to the file system item.</summary>
	protected string? itemPath = null;

	/// <summary>Initializes a new instance of the <see cref="PropertyStore"/> class from a file system path.</summary>
	/// <param name="path">A string that specifies the item path.</param>
	/// <param name="propChangedHandler">The optional property changed handler.</param>
	public PropertyStore(string path, PropertyChangedEventHandler? propChangedHandler = null) : this(path, GETPROPERTYSTOREFLAGS.GPS_DEFAULT)
	{
		if (propChangedHandler != null)
			PropertyChanged += propChangedHandler;
	}

	/// <summary>Initializes a new instance of the <see cref="PropertyStore"/> class.</summary>
	protected PropertyStore() { }

	/// <summary>Returns a property store for an item, given a path or parsing name.</summary>
	/// <param name="path">A string that specifies the item path.</param>
	/// <param name="flags">One or more values from the GETPROPERTYSTOREFLAGS constants.</param>
	/// <param name="pbc">An optional IBindCtx object, which provides access to a bind context.</param>
	protected PropertyStore(string path, GETPROPERTYSTOREFLAGS? flags = null, System.Runtime.InteropServices.ComTypes.IBindCtx? pbc = null)
	{
		itemPath = Path.GetFullPath(Environment.ExpandEnvironmentVariables(path));
		if (flags.HasValue) this.flags = flags.Value;
		iBindCtx = pbc;
	}

	/// <summary>Occurs when a property value changes.</summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>Gets the number of properties in the current property store.</summary>
	public int Count => Run(ps => (int)(ps?.GetCount() ?? 0));

	/// <summary>Value that allows matching this property store's keys to their property descriptions.</summary>
	/// <value>The property descriptions.</value>
	public virtual IReadOnlyDictionary<PROPERTYKEY, PropertyDescription> Descriptions => new PropertyDescriptionDictionary(this);

	/// <summary>Gets or sets a value indicating whether to include slow properties.</summary>
	/// <value><c>true</c> if including slow properties; otherwise, <c>false</c>.</value>
	[DefaultValue(false)]
	public bool IncludeSlow
	{
		get => flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_OPENSLOWITEM);
		set
		{
			if (IncludeSlow == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_OPENSLOWITEM, value);
			if (value)
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY | GETPROPERTYSTOREFLAGS.GPS_FASTPROPERTIESONLY, false);
		}
	}

	/// <summary>Gets or sets a value indicating whether this property store has uncommitted changes.</summary>
	/// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
	public bool IsDirty { get; protected set; }

	/// <summary>Gets an <see cref="IEnumerable{T}"/> containing the keys of the <see cref="IReadOnlyDictionary{PROPERTYKEY, Object}"/>.</summary>
	public ICollection<PROPERTYKEY> Keys => Run(ps => GetKeyEnum(ps).ToList())!;

	/// <summary>Gets or sets a value indicating whether to include only properties directly from the property handler.</summary>
	/// <value><c>true</c> if no inherited properties; otherwise, <c>false</c>.</value>
	[DefaultValue(false)]
	public bool NoInheritedProperties
	{
		get => flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY);
		set
		{
			if (NoInheritedProperties == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY, value);
			if (value)
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY | GETPROPERTYSTOREFLAGS.GPS_BESTEFFORT | GETPROPERTYSTOREFLAGS.GPS_FASTPROPERTIESONLY, false);
		}
	}

	/// <summary>Gets or sets a value indicating whether properties can be read and written.</summary>
	/// <value><c>true</c> if properties are read/write; otherwise, <c>false</c>.</value>
	[DefaultValue(true)]
	public bool ReadOnly
	{
		get => !flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_READWRITE);
		set
		{
			if (ReadOnly == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_READWRITE, !value);
			if (!value)
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_DELAYCREATION | GETPROPERTYSTOREFLAGS.GPS_TEMPORARY | GETPROPERTYSTOREFLAGS.GPS_BESTEFFORT | GETPROPERTYSTOREFLAGS.GPS_FASTPROPERTIESONLY, false);
			else
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_HANDLERPROPERTIESONLY);
		}
	}

	/// <summary>
	/// Gets or sets a value indicating whether this <see cref="PropertyStore"/> provides a writable store, with no initial
	/// properties, that exists for the lifetime of the Shell item instance; basically, a property bag attached to the item instance.
	/// </summary>
	/// <value><c>true</c> if temporary; otherwise, <c>false</c>.</value>
	[DefaultValue(false)]
	public bool Temporary
	{
		get => flags.IsFlagSet(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY);
		set
		{
			if (Temporary == value) return;
			flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY, value);
			if (value)
			{
				flags = GETPROPERTYSTOREFLAGS.GPS_TEMPORARY;
				ReadOnly = false;
			}
			else
			{
				flags = flags.SetFlags(GETPROPERTYSTOREFLAGS.GPS_TEMPORARY, false);
			}
		}
	}

	/// <summary>Gets an <see cref="IEnumerable{T}"/> containing the values in the <see cref="IReadOnlyDictionary{PROPERTYKEY, Object}"/>.</summary>
	public ICollection<object?> Values => Run(ps => GetKeyEnum(ps).Select(k => TryGetValue(ps, k, out object? v) ? v : null).ToList())!;

	bool ICollection<KeyValuePair<PROPERTYKEY, object?>>.IsReadOnly => ReadOnly;

	/// <summary>Gets or sets the value of the property with the specified known key.</summary>
	/// <value>The value.</value>
	/// <param name="knownKey">The known key of the property (e.g. "System.Title"}.</param>
	/// <returns>The value of the property.</returns>
	public virtual object? this[string knownKey]
	{
		get => this[GetPropertyKeyFromName(knownKey)];
		set => this[GetPropertyKeyFromName(knownKey)] = value;
	}

	/// <summary>Gets or sets the value of the property with the specified PROPERTYKEY.</summary>
	/// <value>The value.</value>
	/// <param name="key">The PROPERTYKEY of the property.</param>
	/// <returns>The value of the property.</returns>
	public virtual object? this[PROPERTYKEY key]
	{
		get => TryGetValue(key, out var r) ? r : null;
		set => Add(key, value);
	}

	/// <summary>Gets the property description related to a property key.</summary>
	/// <param name="key">The key.</param>
	/// <returns>The related property description, if one exists; otherwise <see langword="null"/>.</returns>
	public static PropertyDescription GetPropertyDescription(PROPERTYKEY key) => PropertyDescription.Create(key) ?? throw new ArgumentOutOfRangeException(nameof(key));

	/// <summary>Gets the property key for a canonical property name.</summary>
	/// <param name="name">A property name.</param>
	/// <returns>The requested property key.</returns>
	public static PROPERTYKEY GetPropertyKeyFromName(string name)
	{
		if (name is null) throw new ArgumentNullException(nameof(name));
		var hr = PSGetPropertyKeyFromName(name, out var pk);
		if (hr == HRESULT.TYPE_E_ELEMENTNOTFOUND) throw new ArgumentOutOfRangeException(nameof(name));
		hr.ThrowIfFailed();
		return pk;
	}

	/// <summary>Adds a property with the provided key and value to the property store.</summary>
	/// <param name="key">The PROPERTYKEY for the new property.</param>
	/// <param name="value">The value of the new property.</param>
	public virtual void Add(PROPERTYKEY key, object? value)
	{
		ReadOnly = false;
		Run(ps =>
		{
			if (ps is null)
				throw new InvalidOperationException("Property store does not exist.");
			ps.SetValue(key, value, false);
			OnPropertyChanged(key.ToString());
		});
	}

	/// <summary>Commits all changes to the property store.</summary>
	public void Commit()
	{
		if (!IsDirty) return;
		Run(ps => ps?.Commit());
		IsDirty = false;
	}

	/// <summary>Determines whether the <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the specified key.</summary>
	/// <param name="key">The key to locate in the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</param>
	/// <returns>true if the <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the key; otherwise, false.</returns>
	public bool ContainsKey(PROPERTYKEY key) => Keys.Contains(key);

	/// <summary>
	/// Copies the elements of the <see cref="ICollection{T}"/> to an <see cref="T:System.Array"/>, starting at a particular <see
	/// cref="T:System.Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see
	/// cref="ICollection{T}"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	/// <exception cref="ArgumentOutOfRangeException">arrayIndex - The number of items exceeds the length of the supplied array.</exception>
	/// <exception cref="ArgumentNullException">array</exception>
	public void CopyTo(KeyValuePair<PROPERTYKEY, object?>[] array, int arrayIndex)
	{
		if (array.Length < arrayIndex + Count)
			throw new ArgumentOutOfRangeException(nameof(arrayIndex), "The number of items exceeds the length of the supplied array.");
		if (array is null)
			throw new ArgumentNullException(nameof(array));
		var i = arrayIndex;
		foreach (var kv in this)
			array[i++] = kv;
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose()
	{
		Commit();
		GC.SuppressFinalize(this);
	}

	/// <summary>Gets the property.</summary>
	/// <typeparam name="TVal">The type of the value.</typeparam>
	/// <param name="key">The key.</param>
	/// <returns>The cast value of the property.</returns>
	/// <exception cref="ArgumentOutOfRangeException">key</exception>
	public TVal GetProperty<TVal>(PROPERTYKEY key) => TryGetValue<TVal>(key, out var ret) ? ret! : throw new ArgumentOutOfRangeException(nameof(key));

	/// <summary>Gets the string value of the property.</summary>
	/// <param name="key">The key.</param>
	/// <param name="flags">The formatting flags.</param>
	/// <returns>The string value of the property.</returns>
	/// <exception cref="ArgumentOutOfRangeException">key</exception>
	public string? GetPropertyString(PROPERTYKEY key, PROPDESC_FORMAT_FLAGS flags = PROPDESC_FORMAT_FLAGS.PDFF_DEFAULT)
	{
		using var pv = GetPropVariant(key);
		return PropertyDescription.Create(key)?.FormatForDisplay(pv, flags);
	}

	/// <summary>Gets the PROPVARIANT value for a key.</summary>
	/// <param name="key">The key.</param>
	/// <returns>The PROPVARIANT value.</returns>
	/// <exception cref="ArgumentOutOfRangeException">key</exception>
	public PROPVARIANT GetPropVariant(PROPERTYKEY key) => Run(ps =>
	{
		var pv = new PROPVARIANT();
		ps.GetValue(key, pv);
		return pv;
	})!;

	/// <summary>Queries whether the property handler allows a specific property to be edited in the UI by the user.</summary>
	/// <param name="key">
	/// <para>A PROPERTYKEY structure that represents the property being queried.</para>
	/// </param>
	/// <returns><see langword="true"/> if the property can be edited and stored by the handler; otherwise <see langword="false"/>.</returns>
	/// <remarks>
	/// The Shell disables the editing of controls by the user as appropriate through this method. A handler that does not support
	/// IPropertyStoreCapabilities is assumed to support writing of any property.
	/// </remarks>
	public bool IsPropertyWritable(in PROPERTYKEY key)
	{
		if (ReadOnly) return false;

		IPropertyStoreCapabilities? pCapabilities = null;

		// Check for an IPropertyStoreCapabilities if possible
		try { pCapabilities = Run(ps => ps as IPropertyStoreCapabilities); } catch { }

		// Grab the answer, one way or the other
		if (pCapabilities is null)
		{
			try
			{
				Add(key, this[key]);
				return true;
			}
			catch { }
			return false;
		}
		else
		{
			var ret = pCapabilities.IsPropertyWritable(key) == HRESULT.S_OK;
			Marshal.FinalReleaseComObject(pCapabilities);
			return ret;
		}
	}

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
	/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the object that implements <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the
	/// specified key; otherwise, <see langword="false"/>.
	/// </returns>
	public bool TryGetValue(PROPERTYKEY key, [NotNullWhen(true)] out object? value) => TryGetValue<object>(key, out value);

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <typeparam name="TVal">The type of the returned value.</typeparam>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the
	/// type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the object that implements <see cref="IDictionary{PROPERTYKEY, Object}"/> contains an element with the
	/// specified key; otherwise, <see langword="false"/>.
	/// </returns>
	public virtual bool TryGetValue<TVal>(PROPERTYKEY key, out TVal? value)
	{
		var result = Run(ps =>
		{
			var ret = TryGetValue<TVal>(ps, key, out var val);
			return (ret, ret ? val : default);
		});
		value = result.Item2;
		return result.ret;
	}

	/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
	void ICollection<KeyValuePair<PROPERTYKEY, object?>>.Add(KeyValuePair<PROPERTYKEY, object?> item) => Add(item.Key, item.Value);

	/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
	/// <exception cref="InvalidOperationException"></exception>
	void ICollection<KeyValuePair<PROPERTYKEY, object?>>.Clear() => throw new InvalidOperationException();

	/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
	/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, <see langword="false"/>.
	/// </returns>
	bool ICollection<KeyValuePair<PROPERTYKEY, object?>>.Contains(KeyValuePair<PROPERTYKEY, object?> item) => Run(ps => TryGetValue(ps, item.Key, out object? o) && Equals(o, item.Value));

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
	IEnumerator<KeyValuePair<PROPERTYKEY, object?>> IEnumerable<KeyValuePair<PROPERTYKEY, object?>>.GetEnumerator() =>
		(Run(ps => GetKeyEnum(ps).Select(k => new KeyValuePair<PROPERTYKEY, object?>(k, TryGetValue(ps, k, out object? pv) ? pv : null))) ?? []).GetEnumerator();

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<KeyValuePair<PROPERTYKEY, object>>)this).GetEnumerator();

	/// <summary>Removes the element with the specified key from the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</summary>
	/// <param name="key">The key of the element to remove.</param>
	/// <returns>
	/// <see langword="true"/> if the element is successfully removed; otherwise, <see langword="false"/>. This method also returns <see
	/// langword="false"/> if <paramref name="key"/> was not found in the original <see cref="IDictionary{PROPERTYKEY, Object}"/>.
	/// </returns>
	/// <exception cref="InvalidOperationException"></exception>
	bool IDictionary<PROPERTYKEY, object?>.Remove(PROPERTYKEY key) => throw new InvalidOperationException();

	/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise,
	/// <see langword="false"/>. This method also returns <see langword="false"/> if <paramref name="item"/> is not found in the
	/// original <see cref="ICollection{T}"/>.
	/// </returns>
	/// <exception cref="InvalidOperationException"></exception>
	bool ICollection<KeyValuePair<PROPERTYKEY, object?>>.Remove(KeyValuePair<PROPERTYKEY, object?> item) => throw new InvalidOperationException();

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <param name="ps">The IPropertyStore instance.</param>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, <c>default(T)</c>.
	/// </param>
	/// <returns><see langword="true"/> if the property store contains an element with the specified key; otherwise, <see langword="false"/>.</returns>
	protected static bool TryGetValue<T>(IPropertyStore ps, PROPERTYKEY key, [NotNullWhen(true)] out T? value)
	{
		var ret = ps.GetValue(key);
		value = ret is null ? default : (T)ret;
		return ret is not null;
	}

	/// <summary>The IPropertyStore instance. This can be null.</summary>
	protected virtual IPropertyStore? GetIPropertyStore()
	{
		if (itemPath is not null)
		{
			SHGetPropertyStoreFromParsingName(itemPath, iBindCtx, flags, typeof(IPropertyStore).GUID, out var iPropertyStore).ThrowIfFailed();
			return iPropertyStore;
		}
		return null;
	}

	/// <summary>Gets an enumeration of the keys in the property store.</summary>
	/// <returns>Keys in the property store.</returns>
	protected virtual IEnumerable<PROPERTYKEY> GetKeyEnum(IPropertyStore ps)
	{
		if (ps is null) yield break;
		for (uint i = 0; i < Count; i++)
			yield return ps.GetAt(i);
	}

	/// <summary>Called when a property has changed.</summary>
	protected virtual void OnPropertyChanged(string propertyName)
	{
		IsDirty = true;
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}

	/// <summary>Runs the specified action with a retrived IPropertyStore instance.</summary>
	/// <param name="action">The action to run.</param>
	protected void Run(Action<IPropertyStore> action)
	{
		var iPropertyStore = GetIPropertyStore();
		if (iPropertyStore is not null)
		{
			try { action(iPropertyStore); }
			finally { Marshal.FinalReleaseComObject(iPropertyStore); }
		}
	}

	/// <summary>Runs the specified action with a retrived IPropertyStore instance.</summary>
	/// <typeparam name="T">The return type of the action and method.</typeparam>
	/// <param name="action">The action to run.</param>
	/// <returns>The return value from <paramref name="action"/>.</returns>
	protected T? Run<T>(Func<IPropertyStore, T> action)
	{
		var iPropertyStore = GetIPropertyStore();
		if (iPropertyStore is not null)
		{
			try
			{
				return action(iPropertyStore);
			}
			finally
			{
				Marshal.FinalReleaseComObject(iPropertyStore);
			}
		}
		return default;
	}

	private class PropertyDescriptionDictionary(PropertyStore ps) : IReadOnlyDictionary<PROPERTYKEY, PropertyDescription>
	{
		public int Count => ps.Count;
		public IEnumerable<PROPERTYKEY> Keys => ps.Keys;
		public IEnumerable<PropertyDescription> Values => ps.Keys.Select(GetPropertyDescription).ToList();
		public PropertyDescription this[PROPERTYKEY key] => GetPropertyDescription(key);

		public bool ContainsKey(PROPERTYKEY key) => ps.ContainsKey(key);

		public IEnumerator<KeyValuePair<PROPERTYKEY, PropertyDescription>> GetEnumerator() =>
			ps.Keys.Select(k => new KeyValuePair<PROPERTYKEY, PropertyDescription>(k, GetPropertyDescription(k))).ToList().GetEnumerator();

#if NET40_OR_GREATER || NETSTANDARD2_0_OR_GREATER && !NET5_0_OR_GREATER
#nullable disable
		public bool TryGetValue(PROPERTYKEY key, out PropertyDescription value)
#nullable restore
#else
		public bool TryGetValue(PROPERTYKEY key, [MaybeNullWhen(false)] out PropertyDescription value)
#endif
		{
			if (ps.ContainsKey(key))
			{
				value = this[key];
				return true;
			}
			value = null;
			return false;
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}