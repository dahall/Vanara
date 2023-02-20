using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara;

/// <summary>Managed instance of the OLE DATE type.</summary>
[StructLayout(LayoutKind.Sequential), Serializable]
[TypeConverter(typeof(DATETypeConverter))]
public struct DATE : IEquatable<DATE>, IComparable<DATE>, IEquatable<DateTime>, IComparable<DateTime>, IConvertible, IComparable
{
	private double value;

	/// <summary>Initializes a new instance of the <see cref="DATE"/> struct.</summary>
	/// <param name="value">The value.</param>
	public DATE(DateTime value) => this.value = value.ToOADate();

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public DateTime Value => DateTime.FromOADate(value);

	/// <summary>Performs an implicit conversion from <see cref="System.Byte"/> to <see cref="DATE"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator DATE(DateTime value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="DATE"/> to <see cref="System.Byte"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator DateTime(DATE value) => value.Value;

	/// <summary>Indicates whether two <see cref="DATE"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(DATE s1, DATE s2) => !s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="DATE"/> is less than another specified <see cref="DATE"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(DATE s1, DATE s2) => s1.CompareTo(s2) < 0;

	/// <summary>Indicates whether a specified <see cref="DATE"/> is less than or equal to another specified <see cref="DATE"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(DATE s1, DATE s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether two <see cref="DATE"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(DATE s1, DATE s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="DATE"/> is greater than another specified <see cref="DATE"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(DATE s1, DATE s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="DATE"/> is greater than or equal to another specified <see cref="DATE"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(DATE s1, DATE s2) => s1.CompareTo(s2) >= 0;

	/// <inheritdoc/>
	public int CompareTo(DATE other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	public int CompareTo(DateTime other) => Value.CompareTo(other);

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is DATE s ? Equals(s) : (obj is DateTime b ? Value.Equals(b) : Value.Equals(obj));

	/// <inheritdoc/>
	public bool Equals(DATE other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public bool Equals(DateTime other) => Value.Equals(other);

	/// <inheritdoc/>
	public override int GetHashCode() => Value.GetHashCode();

	/// <inheritdoc/>
	public TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <inheritdoc/>
	public override string ToString() => Value.ToString();

	/// <inheritdoc/>
	public string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <inheritdoc/>
	int IComparable.CompareTo(object? obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(DateTime)));

	/// <inheritdoc/>
	bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)Value).ToByte(provider);

	/// <inheritdoc/>
	char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)Value).ToDateTime(provider);

	/// <inheritdoc/>
	decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)Value).ToDecimal(provider);

	/// <inheritdoc/>
	double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)Value).ToDouble(provider);

	/// <inheritdoc/>
	short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)Value).ToInt16(provider);

	/// <inheritdoc/>
	int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)Value).ToInt32(provider);

	/// <inheritdoc/>
	long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)Value).ToInt64(provider);

	/// <inheritdoc/>
	sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)Value).ToSByte(provider);

	/// <inheritdoc/>
	float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)Value).ToSingle(provider);

	/// <inheritdoc/>
	object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)Value).ToUInt16(provider);

	/// <inheritdoc/>
	uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)Value).ToUInt32(provider);

	/// <inheritdoc/>
	ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)Value).ToUInt64(provider);

	internal class DATETypeConverter : DecimalConverter
	{
		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
			value is DATE b ? base.ConvertTo(context, culture, b.Value, destinationType) : throw new NotSupportedException();

		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			new DATE((DateTime)base.ConvertFrom(context, culture, value)!);
	}
}