using Vanara.PInvoke;

namespace Vanara;

/// <summary>Managed instance of the four-byte BOOL type.</summary>
[TypeDef(typeof(uint), Excludes = ExcludeOptions.EqualsOverride | ExcludeOptions.Value | ExcludeOptions.ToString | ExcludeOptions.Parsable | ExcludeOptions.Numerics)]
public partial struct BOOL : IComparable<bool>, IEquatable<bool>
{
	internal const uint True = 1U;

	internal const uint False = 0U;

	/// <summary>Initializes a new instance of the <see cref="BOOL"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOL(bool value) : this(value ? True : False) { }

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public bool Value { readonly get => value != False; private set => this.value = value ? True : False; }

	/// <inheritdoc/>
	readonly int IComparable<bool>.CompareTo(bool other) => Value.CompareTo(other);

	/// <inheritdoc/>
	public readonly bool Equals(bool other) => Value.Equals(other);

	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj switch
	{
		BOOL b => Equals(b),
		BOOLEAN s => Equals((bool)s),
		bool b => Equals(b),
		uint i => Equals(i),
		int i => Equals(unchecked((uint)i)),
		_ => Value.Equals(obj)
	};

	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <summary>Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(bool value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="BOOL"/> to <see cref="System.Boolean"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator bool(BOOL value) => value.Value;

	/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(int value) => new(unchecked((uint)value));

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="System.Int32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator int(BOOL value) => unchecked((int)value.value);

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(BOOL value) => (IntPtr)(int)value;

	/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(IntPtr value) => value != IntPtr.Zero;

	/// <summary>Implements the operator !.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static BOOL operator !(BOOL value) => !value.Value;

#if !NETSTANDARD
	/// <summary>Implements the operator <see langword="true"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator true(BOOL value) => value.Value;

	/// <summary>Implements the operator <see langword="false"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator false(BOOL value) => !value.Value;
#endif
}