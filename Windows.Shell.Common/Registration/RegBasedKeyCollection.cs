using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Vanara.Windows.Shell.Registration;

/// <summary>A collection of values under a key that is treated as a collection of strings.</summary>
/// <seealso cref="System.Collections.Generic.ICollection{T}"/>
internal class RegBasedKeyCollection : ICollection<string>, IDisposable
{
	/// <summary>The base key from which to perform all queries.</summary>
	protected internal RegistryKey key;

	/// <summary>Initializes a new instance of the <see cref="RegBasedSettings"/> class.</summary>
	/// <param name="key">The key to use as the base key for queries.</param>
	/// <param name="readOnly">if set to <c>true</c> the supplied <paramref name="key"/> was opened read-only.</param>
	protected internal RegBasedKeyCollection(RegistryKey key, bool readOnly)
	{
		if (key is null && !readOnly) throw new ArgumentNullException(nameof(key));
		this.key = key;
		IsReadOnly = readOnly;
	}

	/// <summary>Gets the count.</summary>
	/// <value>The count.</value>
	public int Count => key?.ValueCount ?? 0;

	/// <summary>Gets or sets a value indicating whether these settings are read-only.</summary>
	public bool IsReadOnly { get; }

	/// <summary>Adds the specified item.</summary>
	/// <param name="item">The item.</param>
	public void Add(string item) { EnsureWritable(); key.SetValue(item, string.Empty, RegistryValueKind.String); }

	/// <summary>Clears this instance.</summary>
	public void Clear() { EnsureWritable(); key.DeleteAllSubItems(); }

	/// <summary>Determines whether this instance contains the object.</summary>
	/// <param name="item">The item.</param>
	/// <returns><see langword="true"/> if [contains] [the specified item]; otherwise, <see langword="false"/>.</returns>
	public bool Contains(string item) => key?.HasValue(item) ?? false;

	/// <summary>Copies to.</summary>
	/// <param name="array">The array.</param>
	/// <param name="arrayIndex">Index of the array.</param>
	public void CopyTo(string[] array, int arrayIndex) { if (key != null) Array.Copy(key.GetValueNames(), 0, array, arrayIndex, Count); }

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose() => key?.Close();

	/// <summary>Gets the enumerator.</summary>
	/// <returns></returns>
	public IEnumerator<string> GetEnumerator() => (key?.GetValueNames().Cast<string>() ?? new string[0]).GetEnumerator();

	/// <summary>Removes the specified item.</summary>
	/// <param name="item">The item.</param>
	/// <returns></returns>
	public bool Remove(string item) { EnsureWritable(); try { key.DeleteValue(item, true); return true; } catch { return false; } }

	/// <summary>Gets the enumerator.</summary>
	/// <returns></returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Checks the ReadOnly flag and throws an exception if it is true.</summary>
	protected void EnsureWritable() { if (IsReadOnly) throw new NotSupportedException("The collection is read only."); }
}