#nullable enable
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
__USINGS__

namespace __NAMESPACE__;

/// <summary>Managed instance of the __TYPENAME__ type.</summary>
[StructLayout(LayoutKind.Sequential)]
##SERIALIZABLE
[Serializable]
%%SERIALIZABLE
##CONVERSIONS
[TypeConverter(typeof(__TYPENAME__TypeConverter))]
%%CONVERSIONS
public partial struct __TYPENAME____INTERFACES__
{
	private __BASETYPE__ value;

	/// <summary>Initializes a new instance of the <see cref="__TYPENAME__"/> struct.</summary>
	/// <param name="value">The value.</param>
	__CTORACC__ __TYPENAME__(__BASETYPE__ value) => this.value = value;

##VALUE
	/// <summary>Gets or sets the value.</summary>
	/// <value>The value.</value>
	public __BASETYPE__ Value { readonly get => value; private set => this.value = value; }

%%VALUE
##HASH
	/// <inheritdoc/>
	public override readonly int GetHashCode() => value.GetHashCode();

%%HASH
##CONVERSIONS
	/// <summary>Performs an implicit conversion from <see cref="__BASETYPE__"/> to <see cref="__TYPENAME__"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator __TYPENAME__(__BASETYPE__ value) => new() { value = value };

	/// <summary>Performs an explicit conversion from <see cref="__TYPENAME__"/> to <see cref="__BASETYPE__"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator __BASETYPE__(__TYPENAME__ value) => value.value;

%%CONVERSIONS
##SERIALIZABLE
	private __TYPENAME__(SerializationInfo info, StreamingContext context) => value = (__BASETYPE__?)info.GetValue("value", typeof(__BASETYPE__)) ?? default;

	/// <inheritdoc/>
	readonly void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info is null) throw new ArgumentNullException(nameof(info));
		info.AddValue("value", (__BASETYPE__)value);
	}

%%SERIALIZABLE
##NUMERICS
#if NET7_0_OR_GREATER
	/// <summary>Represents the largest possible value of <see cref="__TYPENAME__"/>.</summary>
	public static __TYPENAME__ MaxValue => NumberBaseAccessor<__BASETYPE__>.MaxValue;

	/// <summary>Represents the smallest possible value of <see cref="__TYPENAME__"/>. This field is constant.</summary>
	public static __TYPENAME__ MinValue => NumberBaseAccessor<__BASETYPE__>.MinValue;

	/// <summary>Represents the zero value of <see cref="__TYPENAME__"/>. This field is constant.</summary>
	public static __TYPENAME__ One => NumberBaseAccessor<__BASETYPE__>.One;

	/// <summary>Represents the zero value of <see cref="__TYPENAME__"/>. This field is constant.</summary>
	public static __TYPENAME__ Zero => NumberBaseAccessor<__BASETYPE__>.Zero;

	/// <inheritdoc/>
	static __TYPENAME__ IAdditiveIdentity<__TYPENAME__, __TYPENAME__>.AdditiveIdentity => NumberBaseAccessor<__BASETYPE__>.AdditiveIdentity;

	/// <inheritdoc/>
	static __TYPENAME__ IMultiplicativeIdentity<__TYPENAME__, __TYPENAME__>.MultiplicativeIdentity => NumberBaseAccessor<__BASETYPE__>.MultiplicativeIdentity;

	/// <inheritdoc/>
	static int INumberBase<__TYPENAME__>.Radix => NumberBaseAccessor<__BASETYPE__>.Radix;

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.Abs(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.Abs(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsCanonical(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsCanonical(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsComplexNumber(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsComplexNumber(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsEvenInteger(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsEvenInteger(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsFinite(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsFinite(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsImaginaryNumber(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsImaginaryNumber(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsInfinity(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsInfinity(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsInteger(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsInteger(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNaN(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsNaN(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNegative(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsNegative(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNegativeInfinity(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsNegativeInfinity(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNormal(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsNormal(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsOddInteger(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsOddInteger(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsPositive(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsPositive(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsPositiveInfinity(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsPositiveInfinity(value.value);

	/// <inheritdoc/>
	static bool IBinaryNumber<__TYPENAME__>.IsPow2(__TYPENAME__ value) => BinaryIntegerAccessor<__BASETYPE__>.IsPow2(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsRealNumber(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsRealNumber(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsSubnormal(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsSubnormal(value.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsZero(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.IsZero(value.value);

	/// <inheritdoc/>
	static __TYPENAME__ IBinaryNumber<__TYPENAME__>.Log2(__TYPENAME__ value) => BinaryIntegerAccessor<__BASETYPE__>.Log2(value.value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MaxMagnitude(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__BASETYPE__>.MaxMagnitude(x.value, y.value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MaxMagnitudeNumber(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__BASETYPE__>.MaxMagnitudeNumber(x.value, y.value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MinMagnitude(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__BASETYPE__>.MinMagnitude(x.value, y.value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MinMagnitudeNumber(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__BASETYPE__>.MinMagnitudeNumber(x.value, y.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertFromChecked<TOther>(TOther value, out __TYPENAME__ result) => NumberBaseAccessor<__BASETYPE__>.TryConvertFromChecked(value, out result.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertFromSaturating<TOther>(TOther value, out __TYPENAME__ result) => NumberBaseAccessor<__BASETYPE__>.TryConvertFromSaturating(value, out result.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertFromTruncating<TOther>(TOther value, out __TYPENAME__ result) => NumberBaseAccessor<__BASETYPE__>.TryConvertFromTruncating(value, out result.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertToChecked<TOther>(__TYPENAME__ value, [MaybeNullWhen(false)] out TOther result) => NumberBaseAccessor<__BASETYPE__>.TryConvertToChecked(value.value, out result);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertToSaturating<TOther>(__TYPENAME__ value, [MaybeNullWhen(false)] out TOther result) => NumberBaseAccessor<__BASETYPE__>.TryConvertToSaturating(value.value, out result);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertToTruncating<TOther>(__TYPENAME__ value, [MaybeNullWhen(false)] out TOther result) => NumberBaseAccessor<__BASETYPE__>.TryConvertToTruncating(value.value, out result);

	/// <inheritdoc/>
	static __TYPENAME__ IBinaryInteger<__TYPENAME__>.PopCount(__TYPENAME__ value) => BinaryIntegerAccessor<__BASETYPE__>.PopCount(value.value);

	/// <inheritdoc/>
	static __TYPENAME__ IBinaryInteger<__TYPENAME__>.TrailingZeroCount(__TYPENAME__ value) => BinaryIntegerAccessor<__BASETYPE__>.TrailingZeroCount(value.value);

	/// <inheritdoc/>
	static bool IBinaryInteger<__TYPENAME__>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out __TYPENAME__ value) => BinaryIntegerAccessor<__BASETYPE__>.TryReadBigEndian(source, isUnsigned, out value.value);

	/// <inheritdoc/>
	static bool IBinaryInteger<__TYPENAME__>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out __TYPENAME__ value) => BinaryIntegerAccessor<__BASETYPE__>.TryReadLittleEndian(source, isUnsigned, out value.value);

	/// <inheritdoc/>
	int IBinaryInteger<__TYPENAME__>.GetByteCount() => BinaryIntegerAccessor<__BASETYPE__>.GetByteCount(value);

	/// <inheritdoc/>
	int IBinaryInteger<__TYPENAME__>.GetShortestBitLength() => BinaryIntegerAccessor<__BASETYPE__>.GetShortestBitLength(value);

	/// <inheritdoc/>
	bool IBinaryInteger<__TYPENAME__>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten) => BinaryIntegerAccessor<__BASETYPE__>.TryWriteBigEndian(value, destination, out bytesWritten);

	/// <inheritdoc/>
	bool IBinaryInteger<__TYPENAME__>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten) => BinaryIntegerAccessor<__BASETYPE__>.TryWriteLittleEndian(value, destination, out bytesWritten);

	/// <inheritdoc/>
	public static __TYPENAME__ operator -(__TYPENAME__ value) => NumberBaseAccessor<__BASETYPE__>.Negate(value.value);
#endif // NET7_0_OR_GREATER

	/// <summary>Subtracts two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The minuend.</param>
	/// <param name="s2">The subtrahend.</param>
	/// <returns>The result of subtracting <paramref name="s2"/> from <paramref name="s1"/>.</returns>
	public static __TYPENAME__ operator -(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.value - s2.value);

	/// <summary>Decrements the <see cref="__TYPENAME__"/> by 1.</summary>
	/// <param name="s1">The value to decrement.</param>
	/// <returns>The value of <paramref name="s1"/> decremented by 1.</returns>
	public static __TYPENAME__ operator --(__TYPENAME__ s1) => s1.value += 1;

	/// <summary>Returns the remainder resulting from dividing two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The remainder resulting from dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator %(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.value % s2.value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator &(__TYPENAME__ left, __TYPENAME__ right) => (__TYPENAME__)(left.value & right.value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator |(__TYPENAME__ left, __TYPENAME__ right) => (__TYPENAME__)(left.value | right.value);

	/// <summary>Multiplies two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The first value to multiply.</param>
	/// <param name="s2">The second value to multiply.</param>
	/// <returns>The result of multiplying <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator *(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.value * s2.value);

	/// <summary>Divides two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The result of dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator /(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.value / s2.value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator ^(__TYPENAME__ left, __TYPENAME__ right) => (__TYPENAME__)(left.value ^ right.value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator ~(__TYPENAME__ value) => (__TYPENAME__)~value.value;

	/// <summary>Adds two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The first value to add.</param>
	/// <param name="s2">The second value to add.</param>
	/// <returns>The result of adding <paramref name="s1"/> and <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator +(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.value + s2.value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator +(__TYPENAME__ value) => (__TYPENAME__)(+value.value);

	/// <summary>Increments the <see cref="__TYPENAME__"/> by 1.</summary>
	/// <param name="s1">The value to increment.</param>
	/// <returns>The value of <paramref name="s1"/> incremented by 1.</returns>
	public static __TYPENAME__ operator ++(__TYPENAME__ s1) => s1.value += 1;

	/// <inheritdoc/>
	public static __TYPENAME__ operator <<(__TYPENAME__ value, int shiftAmount) => (__TYPENAME__)(value.value << shiftAmount);

	/// <inheritdoc/>
	public static __TYPENAME__ operator >>(__TYPENAME__ value, int shiftAmount) => (__TYPENAME__)(value.value >> shiftAmount);

	/// <inheritdoc/>
	public static __TYPENAME__ operator >>>(__TYPENAME__ value, int shiftAmount) => (__TYPENAME__)(value.value >>> shiftAmount);

%%NUMERICS
##EQUALSOVERRIDE
	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj is __TYPENAME__ s ? Equals(s) : (obj is __BASETYPE__ v ? value.Equals(v) : value.Equals(obj));

%%EQUALSOVERRIDE
##EQUATABLE
	/// <inheritdoc/>
	public readonly bool Equals(__TYPENAME__ other) => value.Equals(other.value);

	/// <inheritdoc/>
	public readonly bool Equals(__BASETYPE__ other) => value.Equals(other);

	/// <summary>Indicates whether two <see cref="__TYPENAME__"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(__TYPENAME__ s1, __TYPENAME__ s2) => s1.Equals(s2);

	/// <summary>Indicates whether two <see cref="__TYPENAME__"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(__TYPENAME__ s1, __TYPENAME__ s2) => !s1.Equals(s2);

%%EQUATABLE
##COMPARABLE
	/// <inheritdoc/>
	public readonly int CompareTo(__TYPENAME__ other) => value.CompareTo(other.value);

	/// <inheritdoc/>
	readonly int IComparable.CompareTo(object? obj) => value.CompareTo(Convert.ChangeType(obj, typeof(__BASETYPE__)));

	/// <summary>Indicates whether a specified <see cref="__TYPENAME__"/> is less than another specified <see cref="__TYPENAME__"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(__TYPENAME__ s1, __TYPENAME__ s2) => s1.CompareTo(s2) < 0;

	/// <summary>Indicates whether a specified <see cref="__TYPENAME__"/> is less than or equal to another specified <see cref="__TYPENAME__"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(__TYPENAME__ s1, __TYPENAME__ s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether a specified <see cref="__TYPENAME__"/> is greater than another specified <see cref="__TYPENAME__"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(__TYPENAME__ s1, __TYPENAME__ s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="__TYPENAME__"/> is greater than or equal to another specified <see cref="__TYPENAME__"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(__TYPENAME__ s1, __TYPENAME__ s2) => s1.CompareTo(s2) >= 0;

%%COMPARABLE
##PARSABLE
	/// <inheritdoc/>
	public static __TYPENAME__ Parse(string s, IFormatProvider? provider = null) => Parse(s, NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static __TYPENAME__ Parse(string s, NumberStyles style, IFormatProvider? provider) => new() { value = __BASETYPE__.Parse(s, style, provider) };

	/// <inheritdoc/>
	public static __TYPENAME__ Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s.ToString(), NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static __TYPENAME__ Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s.ToString(), style, provider);

	/// <inheritdoc/>
	public static bool TryParse(string? s, IFormatProvider? provider, out __TYPENAME__ result) => TryParse(s, NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out __TYPENAME__ result) => TryParse(s.ToString(), NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out __TYPENAME__ result) { var b = __BASETYPE__.TryParse(s, style, provider, out var r); result = new() { value = b ? r : default }; return b; }

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out __TYPENAME__ result) => TryParse(s.ToString(), style, provider, out result);

%%PARSABLE
##TOSTRING
##PTR
#if NET5_0_OR_GREATER
	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null, null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => ToString(null, provider);

	/// <inheritdoc/>
	public readonly string ToString(string? format, IFormatProvider? formatProvider) => ((IFormattable)value).ToString(format, formatProvider);

#else
	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => ((IConvertible)value).ToString(provider);

#endif
%%PTR
##NONPTR
	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null, null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => ToString(null, provider);

	/// <inheritdoc/>
	public readonly string ToString(string? format, IFormatProvider? formatProvider) => ((IFormattable)value).ToString(format, formatProvider);

#endif
%%NONPTR
%%TOSTRING
##CONVERTIBLE
	/// <inheritdoc/>
	public readonly TypeCode GetTypeCode() => ((IConvertible)value).GetTypeCode();

#if NET6_0_OR_GREATER
	/// <inheritdoc/>
	public readonly bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
		((ISpanFormattable)value).TryFormat(destination, out charsWritten, format, provider);
#endif

	/// <inheritdoc/>
	readonly bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)value).ToBoolean(provider);

	/// <inheritdoc/>
	readonly byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)value).ToByte(provider);

	/// <inheritdoc/>
	readonly char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)value).ToChar(provider);

	/// <inheritdoc/>
	readonly DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)value).ToDateTime(provider);

	/// <inheritdoc/>
	readonly decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)value).ToDecimal(provider);

	/// <inheritdoc/>
	readonly double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)value).ToDouble(provider);

	/// <inheritdoc/>
	readonly short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)value).ToInt16(provider);

	/// <inheritdoc/>
	readonly int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)value).ToInt32(provider);

	/// <inheritdoc/>
	readonly long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)value).ToInt64(provider);

	/// <inheritdoc/>
	readonly sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)value).ToSByte(provider);

	/// <inheritdoc/>
	readonly float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)value).ToSingle(provider);

	/// <inheritdoc/>
	readonly object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)value).ToType(conversionType, provider);

	/// <inheritdoc/>
	readonly ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)value).ToUInt16(provider);

	/// <inheritdoc/>
	readonly uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)value).ToUInt32(provider);

	/// <inheritdoc/>
	readonly ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)value).ToUInt64(provider);

%%CONVERTIBLE
##CONVERSIONS
	internal class __TYPENAME__TypeConverter : UInt64Converter
	{
		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			new __TYPENAME__() { value = ((__BASETYPE__)base.ConvertFrom(context, culture, value)!) };

		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
			value is __TYPENAME__ sz ? base.ConvertTo(context, culture, sz.value, destinationType) : throw new NotSupportedException();
	}
%%CONVERSIONS
}