using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Vanara.PInvoke;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.Windows.Shell;

/// <summary>Encapsulates the IPropertyStore object.</summary>
/// <seealso cref="IDictionary{PROPERTYKEY, Object}"/>
/// <seealso cref="IDisposable"/>
public abstract class PropertyStore : ReadOnlyPropertyStore, IDictionary<PROPERTYKEY, object>, IDisposable, INotifyPropertyChanged
{
	private bool noICapabilities = false;
	private IPropertyStoreCapabilities pCapabilities;

	/// <summary>Initializes a new instance of the <see cref="PropertyStore"/> class.</summary>
	protected PropertyStore() { }

	/// <summary>Occurs when a property value changes.</summary>
	public event PropertyChangedEventHandler PropertyChanged;

	/// <summary>Gets or sets a value indicating whether this property store has uncommitted changes.</summary>
	/// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
	public bool IsDirty { get; protected set; }

	/// <inheritdoc/>
	public override bool IsReadOnly => false;

	/// <summary>Gets an <see cref="ICollection{T}"/> containing the keys of the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</summary>
	public new ICollection<PROPERTYKEY> Keys => base.Keys.ToList();

	/// <summary>Gets an <see cref="ICollection{T}"/> containing the values in the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</summary>
	public new ICollection<object> Values => base.Values.ToList();

	/// <summary>Gets or sets the value of the property with the specified known key.</summary>
	/// <value>The value.</value>
	/// <param name="knownKey">The known key of the property (e.g. "System.Title"}.</param>
	/// <returns>The value of the property.</returns>
	public new object this[string knownKey]
	{
		get => base[knownKey];
		set => this[GetPropertyKeyFromName(knownKey)] = value;
	}

	/// <summary>Gets or sets the value of the property with the specified PROPERTYKEY.</summary>
	/// <value>The value.</value>
	/// <param name="key">The PROPERTYKEY of the property.</param>
	/// <returns>The value of the property.</returns>
	public new object this[PROPERTYKEY key]
	{
		get => base[key];
		set => Add(key, value);
	}

	/// <summary>Adds a property with the provided key and value to the property store.</summary>
	/// <param name="key">The PROPERTYKEY for the new property.</param>
	/// <param name="value">The value of the new property.</param>
	public virtual void Add(PROPERTYKEY key, object value)
	{
		Run(ps =>
		{
			if (ps is null)
				throw new InvalidOperationException("Property store does not exist.");
			if (IsReadOnly)
				throw new InvalidOperationException("Property store is read-only.");
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

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public override void Dispose()
	{
		Commit();
		base.Dispose();
	}

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
		if (IsReadOnly) return false;

		// Check for an IPropertyStoreCapabilities if possible
		if (pCapabilities is null && !noICapabilities)
		{
			try { pCapabilities = (IPropertyStoreCapabilities)iPropertyStore; } catch { }
			if (pCapabilities is null)
				noICapabilities = true;
		}

		// Grab the answer, one way or the other
		if (noICapabilities)
		{
			try
			{
				var val = this[key];
				Add(key, val);
				return true;
			}
			catch
			{
				return false;
			}
		}
		else
			return pCapabilities.IsPropertyWritable(key) == HRESULT.S_OK;
	}

	/// <summary>Adds an item to the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to add to the <see cref="ICollection{T}"/>.</param>
	void ICollection<KeyValuePair<PROPERTYKEY, object>>.Add(KeyValuePair<PROPERTYKEY, object> item) => Add(item.Key, item.Value);

	/// <summary>Removes all items from the <see cref="ICollection{T}"/>.</summary>
	/// <exception cref="InvalidOperationException"></exception>
	void ICollection<KeyValuePair<PROPERTYKEY, object>>.Clear() => throw new InvalidOperationException();

	/// <summary>Determines whether the <see cref="ICollection{T}"/> contains a specific value.</summary>
	/// <param name="item">The object to locate in the <see cref="ICollection{T}"/>.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="item"/> is found in the <see cref="ICollection{T}"/>; otherwise, <see langword="false"/>.
	/// </returns>
	bool ICollection<KeyValuePair<PROPERTYKEY, object>>.Contains(KeyValuePair<PROPERTYKEY, object> item) => Run(ps => TryGetValue(ps, item.Key, out object o) && Equals(o, item.Value));

	/// <summary>Removes the element with the specified key from the <see cref="IDictionary{PROPERTYKEY, Object}"/>.</summary>
	/// <param name="key">The key of the element to remove.</param>
	/// <returns>
	/// <see langword="true"/> if the element is successfully removed; otherwise, <see langword="false"/>. This method also returns <see
	/// langword="false"/> if <paramref name="key"/> was not found in the original <see cref="IDictionary{PROPERTYKEY, Object}"/>.
	/// </returns>
	/// <exception cref="InvalidOperationException"></exception>
	bool IDictionary<PROPERTYKEY, object>.Remove(PROPERTYKEY key) => throw new InvalidOperationException();

	/// <summary>Removes the first occurrence of a specific object from the <see cref="ICollection{T}"/>.</summary>
	/// <param name="item">The object to remove from the <see cref="ICollection{T}"/>.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="item"/> was successfully removed from the <see cref="ICollection{T}"/>; otherwise,
	/// <see langword="false"/>. This method also returns <see langword="false"/> if <paramref name="item"/> is not found in the
	/// original <see cref="ICollection{T}"/>.
	/// </returns>
	/// <exception cref="InvalidOperationException"></exception>
	bool ICollection<KeyValuePair<PROPERTYKEY, object>>.Remove(KeyValuePair<PROPERTYKEY, object> item) => throw new InvalidOperationException();

	/// <summary>Called when a property has changed.</summary>
	protected virtual void OnPropertyChanged(string propertyName)
	{
		IsDirty = true;
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}