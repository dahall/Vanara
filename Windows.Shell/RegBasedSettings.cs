using Microsoft.Win32;
using System;

namespace Vanara.Windows.Shell
{
	/// <summary>Base class for registry based settings.</summary>
	public abstract class RegBasedSettings : IDisposable, IEquatable<RegBasedSettings>, IComparable<RegBasedSettings>
	{
		/// <summary>The base key from which to perform all queries.</summary>
		protected internal RegistryKey key;

		/// <summary>Initializes a new instance of the <see cref="RegBasedSettings"/> class.</summary>
		/// <param name="key">The key to use as the base key for queries.</param>
		/// <param name="readOnly">if set to <c>true</c> the supplied <paramref name="key"/> was opened read-only.</param>
		protected RegBasedSettings(RegistryKey key, bool readOnly)
		{
			this.key = key ?? throw new ArgumentNullException(nameof(key));
			ReadOnly = readOnly;
		}

		/// <summary>Gets or sets a value indicating whether these settings are read-only.</summary>
		public bool ReadOnly { get; }

		/// <inheritdoc/>
		public bool Equals(RegBasedSettings other) => ((IComparable<RegBasedSettings>)this).CompareTo(other) == 0;

		/// <inheritdoc/>
		public override int GetHashCode() => key?.Name.GetHashCode() ?? 0;

		/// <inheritdoc/>
		public override string ToString() => key?.ToString() ?? "";

		/// <inheritdoc/>
		int IComparable<RegBasedSettings>.CompareTo(RegBasedSettings other) => string.Compare(key.Name, other?.key.Name, StringComparison.InvariantCulture);

		/// <inheritdoc/>
		void IDisposable.Dispose()
		{
			key?.Close();
		}

		/// <summary>Checks the ReadOnly flag and throws an exception if it is true.</summary>
		protected void CheckRW() { if (ReadOnly) throw new InvalidOperationException("Object is read only and its values cannot be changed."); }

		/// <summary>Toggles the value identified by having a named subkey present.</summary>
		/// <param name="name">The name of the subkey.</param>
		/// <param name="set">if set to <c>true</c>, creates a subkey named <paramref name="name"/>; otherwise deletes that subkey.</param>
		protected void ToggleKeyValue(string name, bool set)
		{
			CheckRW();
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
			CheckRW();
			if (!set)
				key.DeleteValue(name, false);
			else
				key.SetValue(name, "", RegistryValueKind.String);
		}

		/// <summary>Updates the value identified by having a named subkey with its default value set.</summary>
		/// <param name="name">The name of the subkey.</param>
		/// <param name="value">The value of the default value.</param>
		/// <param name="deleteIfValue">The value that, if equal to <paramref name="value"/>, causes the removal of the subkey.</param>
		protected void UpdateKeyValue(string name, string value, string deleteIfValue = null)
		{
			CheckRW();
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
		protected void UpdateValue<T>(string name, T value, RegistryValueKind valueKind = RegistryValueKind.Unknown, T deleteIfValue = default)
		{
			CheckRW();
			if (Equals(value, deleteIfValue))
				key.DeleteValue(name, false);
			else
				key.SetValue(name, value, valueKind == RegistryValueKind.Unknown && value is string ? RegistryValueKind.String : valueKind);
		}
	}
}