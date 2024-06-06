using Microsoft.Win32;

namespace Vanara.Windows.Shell;

/// <summary>Base class for registry based settings.</summary>
/// <remarks>Initializes a new instance of the <see cref="RegBasedSettings"/> class.</remarks>
/// <param name="key">The key to use as the base key for queries.</param>
/// <param name="readOnly">if set to <c>true</c> the supplied <paramref name="key"/> was opened read-only.</param>
public abstract class RegBasedSettings(RegistryKey key, bool readOnly) : IDisposable, IEquatable<RegBasedSettings>, IComparable<RegBasedSettings>
{
	/// <summary>The base key from which to perform all queries.</summary>
	protected internal RegistryKey key = key ?? throw new ArgumentNullException(nameof(key));

	/// <summary>Gets a value indicating whether this instance is system wide.</summary>
	/// <value><see langword="true"/> if this instance is system wide; otherwise, <see langword="false"/>.</value>
	public bool IsSystemWide => !key.Name.StartsWith("HKEY_CURRENT_USER");

	/// <summary>Gets or sets a value indicating whether these settings are read-only.</summary>
	public bool ReadOnly { get; } = readOnly;

	/// <summary>Gets the absolute (qualified) name of the key.</summary>
	public string RegPath => key.Name;

	/// <inheritdoc/>
	public int CompareTo(RegBasedSettings? other) => string.Compare(key.Name, other?.key.Name, StringComparison.InvariantCulture);

	/// <inheritdoc/>
	public bool Equals(RegBasedSettings? other) => CompareTo(other) == 0;

	/// <inheritdoc/>
	public override int GetHashCode() => key?.Name.GetHashCode() ?? 0;

	/// <inheritdoc/>
	public override string ToString() => key?.ToString() ?? "";

	/// <inheritdoc/>
	public virtual void Dispose()
	{
		key?.Close();
		ShellRegistrar.NotifyShell();
	}

	/// <summary>Checks the ReadOnly flag and throws an exception if it is true.</summary>
	protected void EnsureWritable() { if (ReadOnly) throw new InvalidOperationException("Object is read only and its values cannot be changed."); }

	/// <summary>Toggles the value identified by having a named subkey present.</summary>
	/// <param name="name">The name of the subkey.</param>
	/// <param name="set">if set to <c>true</c>, creates a subkey named <paramref name="name"/>; otherwise deletes that subkey.</param>
	protected void ToggleKeyValue(string name, bool set)
	{
		EnsureWritable();
		if (!set)
			key.DeleteSubKey(name, false);
		else
			key.CreateSubKey(name)?.Close();
	}

	/// <summary>Toggles the value identified by having a named value present.</summary>
	/// <param name="name">The name of the value.</param>
	/// <param name="set">if set to <c>true</c>, creates a value named <paramref name="name"/>; otherwise deletes that value.</param>
	protected void ToggleValue(string name, bool set)
	{
		EnsureWritable();
		if (!set)
			key.DeleteValue(name, false);
		else
			key.SetValue(name, "", RegistryValueKind.String);
	}

	/// <summary>Updates the value identified by having a named subkey with its default value set.</summary>
	/// <param name="name">The name of the subkey.</param>
	/// <param name="value">The value of the default value.</param>
	/// <param name="deleteIfValue">The value that, if equal to <paramref name="value"/>, causes the removal of the subkey.</param>
	protected internal void UpdateKeyValue(string name, string? value, string? deleteIfValue = null)
	{
		EnsureWritable();
		if (Equals(value, deleteIfValue))
			key.DeleteSubKey(name, false);
		else
			key.CreateSubKey(name, value).Close();
	}

	/// <summary>Updates the value identified by having a named value.</summary>
	/// <typeparam name="T">Type of the value</typeparam>
	/// <param name="name">The name of the value.</param>
	/// <param name="value">The value of the value.</param>
	/// <param name="valueKind">Kind of the value.</param>
	/// <param name="deleteIfValue">The value that, if equal to <paramref name="value"/>, causes the removal of the value.</param>
	protected internal void UpdateValue<T>(string? name, T? value, RegistryValueKind valueKind = RegistryValueKind.Unknown, T? deleteIfValue = default)
	{
		EnsureWritable();
		if (name is not null && Equals(value, deleteIfValue))
			key.DeleteValue(name, false);
		else if (value is not null)
		{
			var o = value is Guid g ? (object)g.ToRegString() : value;
			key.SetValue(name, value, valueKind == RegistryValueKind.Unknown && o is string ? RegistryValueKind.ExpandString : valueKind);
		}
		else
			throw new ArgumentNullException(nameof(value));
	}
}