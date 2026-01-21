using System.ComponentModel;
using System.Globalization;

namespace Vanara;

/// <summary>Managed instance of the single-byte BOOLEAN type.</summary>
[StructLayout(LayoutKind.Sequential), Serializable]
[TypeConverter(typeof(BOOLEANTypeConverter))]
public struct BOOLEAN : IComparable, IComparable<BOOLEAN>, IComparable<bool>, IConvertible, IEquatable<BOOLEAN>, IEquatable<bool>
{
	private byte val;

	internal const byte True = 1;

	internal const byte False = 0;

	/// <summary>Initializes a new instance of the <see cref="BOOLEAN"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOLEAN(byte value) => val = value;

	/// <summary>Initializes a new instance of the <see cref="BOOLEAN"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOLEAN(bool value) => val = value ? True : False;

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public bool Value { readonly get => val != False; private set => val = value ? True : False; }

	/// <summary>Performs an implicit conversion from <see cref="byte"/> to <see cref="BOOLEAN"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOLEAN(byte value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="bool"/> to <see cref="BOOLEAN"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOLEAN(bool value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="BOOLEAN"/> to <see cref="byte"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator byte(BOOLEAN value) => value.val;

	/// <summary>Performs an implicit conversion from <see cref="BOOLEAN"/> to <see cref="bool"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator bool(BOOLEAN value) => value.Value;

	/// <summary>Indicates whether two <see cref="BOOLEAN"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(BOOLEAN s1, BOOLEAN s2) => !s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="BOOLEAN"/> is less than another specified <see cref="BOOLEAN"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(BOOLEAN s1, BOOLEAN s2) => s1.CompareTo(s2) < 0;

	/// <summary>Indicates whether a specified <see cref="BOOLEAN"/> is less than or equal to another specified <see cref="BOOLEAN"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>; otherwise,
	/// <see langword="false"/>.
	/// </returns>
	public static bool operator <=(BOOLEAN s1, BOOLEAN s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether two <see cref="BOOLEAN"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(BOOLEAN s1, BOOLEAN s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="BOOLEAN"/> is greater than another specified <see cref="BOOLEAN"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(BOOLEAN s1, BOOLEAN s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="BOOLEAN"/> is greater than or equal to another specified <see cref="BOOLEAN"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(BOOLEAN s1, BOOLEAN s2) => s1.CompareTo(s2) >= 0;

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

	/// <inheritdoc/>
	public readonly int CompareTo(BOOLEAN other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	public readonly int CompareTo(bool other) => Value.CompareTo(other);

	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj is BOOLEAN s ? Equals(s) : (obj is bool b ? Value.Equals(b) : Value.Equals(obj));

	/// <inheritdoc/>
	public readonly bool Equals(BOOLEAN other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public readonly bool Equals(bool other) => Value.Equals(other);

	/// <inheritdoc/>
	public override readonly int GetHashCode() => val;

	/// <inheritdoc/>
	public readonly TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <inheritdoc/>
	public override readonly string ToString() => Value.ToString();

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <inheritdoc/>
	readonly int IComparable.CompareTo(object? obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(ulong)));

	/// <inheritdoc/>
	readonly bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	readonly byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)Value).ToByte(provider);

	/// <inheritdoc/>
	readonly char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	readonly DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)Value).ToDateTime(provider);

	/// <inheritdoc/>
	readonly decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)Value).ToDecimal(provider);

	/// <inheritdoc/>
	readonly double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)Value).ToDouble(provider);

	/// <inheritdoc/>
	readonly short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)Value).ToInt16(provider);

	/// <inheritdoc/>
	readonly int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)Value).ToInt32(provider);

	/// <inheritdoc/>
	readonly long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)Value).ToInt64(provider);

	/// <inheritdoc/>
	readonly sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)Value).ToSByte(provider);

	/// <inheritdoc/>
	readonly float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)Value).ToSingle(provider);

	/// <inheritdoc/>
	readonly object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	readonly ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)Value).ToUInt16(provider);

	/// <inheritdoc/>
	readonly uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)Value).ToUInt32(provider);

	/// <inheritdoc/>
	readonly ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)Value).ToUInt64(provider);

	internal class BOOLEANTypeConverter : ByteConverter
	{
		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
			value is BOOLEAN b ? base.ConvertTo(context, culture, b.Value, destinationType) : throw new ArgumentException(null, nameof(value));

		public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			base.CanConvertFrom(context, value.GetType()) ? new BOOLEAN((byte)(base.ConvertFrom(context, culture, value) ?? 0)) : throw new ArgumentException(null, nameof(value));
	}
}