using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara;

/// <summary>Managed instance of the four-byte BOOL type.</summary>
[StructLayout(LayoutKind.Sequential), Serializable]
[TypeConverter(typeof(BOOLTypeConverter))]
public struct BOOL : IComparable, IComparable<BOOL>, IComparable<bool>, IConvertible, IEquatable<BOOL>, IEquatable<bool>
{
	private uint val;

	internal const uint True = 1U;

	internal const uint False = 0U;

	/// <summary>Initializes a new instance of the <see cref="BOOL"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOL(uint value) => val = value;

	/// <summary>Initializes a new instance of the <see cref="BOOL"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOL(bool value) => val = value ? True : False;

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public bool Value { get => val != False; private set => val = value ? True : False; }

	/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(int value) => new(unchecked((uint)value));

	/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(uint value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(bool value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="System.Int32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator int(BOOL value) => unchecked((int)value.val);

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="System.UInt32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator uint(BOOL value) => value.val;

	/// <summary>Performs an implicit conversion from <see cref="BOOL"/> to <see cref="System.Boolean"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator bool(BOOL value) => value.Value;

	/// <summary>Indicates whether two <see cref="BOOL"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(BOOL s1, BOOL s2) => !s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is less than another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(BOOL s1, BOOL s2) => s1.CompareTo(s2) < 0;

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is less than or equal to another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(BOOL s1, BOOL s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether two <see cref="BOOL"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(BOOL s1, BOOL s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is greater than another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(BOOL s1, BOOL s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is greater than or equal to another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(BOOL s1, BOOL s2) => s1.CompareTo(s2) >= 0;

	/// <summary>Implements the operator !.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static BOOL operator !(BOOL value) => !value.Value;

	/// <inheritdoc/>
	public int CompareTo(BOOL other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	public int CompareTo(bool other) => Value.CompareTo(other);

	/// <inheritdoc/>
	public override bool Equals(object obj) => obj is BOOL s ? Equals(s) : (obj is bool b ? Value.Equals(b) : Value.Equals(obj));

	/// <inheritdoc/>
	public bool Equals(BOOL other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public bool Equals(bool other) => Value.Equals(other);

	/// <inheritdoc/>
	public override int GetHashCode() => unchecked((int)val);

	/// <inheritdoc/>
	public TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <inheritdoc/>
	public override string ToString() => Value.ToString();

	/// <inheritdoc/>
	public string ToString(IFormatProvider provider) => Value.ToString(provider);

	/// <inheritdoc/>
	int IComparable.CompareTo(object obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(ulong)));

	/// <inheritdoc/>
	bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

	/// <inheritdoc/>
	char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

	/// <inheritdoc/>
	decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

	/// <inheritdoc/>
	double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)Value).ToDouble(provider);

	/// <inheritdoc/>
	short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

	/// <inheritdoc/>
	int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

	/// <inheritdoc/>
	long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

	/// <inheritdoc/>
	sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

	/// <inheritdoc/>
	float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

	/// <inheritdoc/>
	object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

	/// <inheritdoc/>
	uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

	/// <inheritdoc/>
	ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

	internal class BOOLTypeConverter : UInt32Converter
	{
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) =>
			value is BOOL b ? base.ConvertTo(context, culture, b.Value, destinationType) : throw new ArgumentException(null, nameof(value));

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
			new BOOL((uint)base.ConvertFrom(context, culture, value));
	}
}