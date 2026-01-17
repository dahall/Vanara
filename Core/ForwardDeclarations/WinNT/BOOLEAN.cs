using Vanara.PInvoke;

namespace Vanara;

/// <summary>Managed instance of the single-byte BOOLEAN type.</summary>
[TypeDef(typeof(byte), Excludes = ExcludeOptions.EqualsOverride | ExcludeOptions.Value | ExcludeOptions.ToString | ExcludeOptions.Parsable | ExcludeOptions.Numerics)]
public partial struct BOOLEAN : IComparable<bool>, IEquatable<bool>
{
	internal const byte True = 1;

	internal const byte False = 0;

	/// <summary>Initializes a new instance of the <see cref="BOOLEAN"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOLEAN(bool value) : this(value ? True : False) { }

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
		BOOLEAN s => Equals(s),
		BOOL b => Equals((bool)b),
		bool b => Equals(b),
		byte i => Equals(i),
		_ => Value.Equals(obj)
	};

	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <summary>Performs an implicit conversion from <see cref="bool"/> to <see cref="BOOLEAN"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOLEAN(bool value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="BOOLEAN"/> to <see cref="bool"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator bool(BOOLEAN value) => value.Value;

	/// <summary>Implements the operator !.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static BOOLEAN operator !(BOOLEAN value) => !value.Value;

#if !NETSTANDARD
	/// <summary>Implements the operator <see langword="true"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator true(BOOLEAN value) => value.Value;

	/// <summary>Implements the operator <see langword="false"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator false(BOOLEAN value) => !value.Value;
#endif
}