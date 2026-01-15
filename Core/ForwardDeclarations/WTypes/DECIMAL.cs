using System.ComponentModel;
using System.Globalization;

namespace Vanara;

/// <summary>Managed instance of the OLE DECIMAL type.</summary>
[StructLayout(LayoutKind.Sequential), Serializable]
[TypeConverter(typeof(DECIMALTypeConverter))]
public struct DECIMAL : IEquatable<DECIMAL>, IComparable<DECIMAL>, IEquatable<decimal>, IComparable<decimal>, IConvertible, IComparable
{
	private ushort wReserved;
	private byte scale;
	private byte sign;
	private uint Hi32;
	private uint Lo32;
	private uint Mid32;

	/// <summary>Initializes a new instance of the <see cref="DECIMAL"/> struct.</summary>
	/// <param name="value">The value.</param>
	public DECIMAL(decimal value)
	{
		wReserved = 0;
		var bits = decimal.GetBits(value);
		Lo32 = unchecked((uint)bits[0]);
		Mid32 = unchecked((uint)bits[1]);
		Hi32 = unchecked((uint)bits[2]);
		sign = value < 0m ? (byte)0x80 : (byte)0;
		scale = (byte)((unchecked((uint)bits[3]) & 0x00FF0000) >> 16);
	}

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public readonly decimal Value => new(unchecked((int)Lo32), unchecked((int)Mid32), unchecked((int)Hi32), sign == 0x80, scale);

	/// <summary>Performs an implicit conversion from <see cref="System.Byte"/> to <see cref="DECIMAL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator DECIMAL(decimal value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="DECIMAL"/> to <see cref="System.Byte"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator decimal(DECIMAL value) => value.Value;

	/// <summary>Indicates whether two <see cref="DECIMAL"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(DECIMAL s1, DECIMAL s2) => !s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="DECIMAL"/> is less than another specified <see cref="DECIMAL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(DECIMAL s1, DECIMAL s2) => s1.CompareTo(s2) < 0;

	/// <summary>Indicates whether a specified <see cref="DECIMAL"/> is less than or equal to another specified <see cref="DECIMAL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(DECIMAL s1, DECIMAL s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether two <see cref="DECIMAL"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(DECIMAL s1, DECIMAL s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="DECIMAL"/> is greater than another specified <see cref="DECIMAL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(DECIMAL s1, DECIMAL s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="DECIMAL"/> is greater than or equal to another specified <see cref="DECIMAL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(DECIMAL s1, DECIMAL s2) => s1.CompareTo(s2) >= 0;

	/// <inheritdoc/>
	public readonly int CompareTo(DECIMAL other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	public readonly int CompareTo(decimal other) => Value.CompareTo(other);

	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj is DECIMAL s ? Equals(s) : (obj is decimal b ? Value.Equals(b) : Value.Equals(obj));

	/// <inheritdoc/>
	public readonly bool Equals(DECIMAL other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public readonly bool Equals(decimal other) => Value.Equals(other);

	/// <inheritdoc/>
	public override readonly int GetHashCode() => Value.GetHashCode();

	/// <inheritdoc/>
	public readonly TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <inheritdoc/>
	public override readonly string ToString() => Value.ToString();

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <inheritdoc/>
	readonly int IComparable.CompareTo(object? obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(decimal)));

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

	internal class DECIMALTypeConverter : DecimalConverter
	{
		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
			value is DECIMAL b ? base.ConvertTo(context, culture, b.Value, destinationType) : throw new NotSupportedException();

		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			new DECIMAL((decimal)base.ConvertFrom(context, culture, value)!);
	}
}