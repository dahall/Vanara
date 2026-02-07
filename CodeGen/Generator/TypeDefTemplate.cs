#nullable enable
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using Vanara.PInvoke;
__USINGS__

namespace __NAMESPACE__;

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

##CONVTYPE
	/// <summary>Initializes a new instance of the <see cref="__TYPENAME__"/> struct.</summary>
	/// <param name="value">The value.</param>
	__CTORACC__ __TYPENAME__(__CONVTYPE__ value) : this(__SETCONVVALUE__) { }

	/// <summary>Gets or sets the value.</summary>
	/// <value>The value.</value>
	__VALUEACC__ __CONVTYPE__ Value { readonly get => __GETCONVVALUE__; internal set => this.value = __SETCONVVALUE__; }

%%CONVTYPE
##!CONVTYPE
	/// <summary>Gets or sets the value.</summary>
	/// <value>The value.</value>
	__VALUEACC__ __CONVTYPE__ Value { readonly get => value; private set => this.value = value; }

%%!CONVTYPE
##SERIALIZABLE
	private __TYPENAME__(SerializationInfo info, StreamingContext context) => value = (__BASETYPE__?)info.GetValue("value", typeof(__BASETYPE__)) ?? default;

	/// <inheritdoc/>
	readonly void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info is null) throw new ArgumentNullException(nameof(info));
		info.AddValue("value", (__BASETYPE__)value);
	}

%%SERIALIZABLE
##HASH
	/// <inheritdoc/>
	public override readonly int GetHashCode() => Value.GetHashCode();

%%HASH
##CONVERSIONS
	/// <summary>Performs an implicit conversion from <see cref="__BASETYPE__"/> to <see cref="__TYPENAME__"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator __TYPENAME__(__BASETYPE__ value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="__TYPENAME__"/> to <see cref="__BASETYPE__"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator __BASETYPE__(__TYPENAME__ value) => value.value;

##CONVTYPE
	/// <summary>Performs an implicit conversion from <see cref="__CONVTYPE__"/> to <see cref="__TYPENAME__"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator __TYPENAME__(__CONVTYPE__ value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="__TYPENAME__"/> to <see cref="__CONVTYPE__"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator __CONVTYPE__(__TYPENAME__ value) => value.Value;

%%CONVTYPE
%%CONVERSIONS
##EQUALSOVERRIDE
	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj is __TYPENAME__ s ? Equals(s) : (obj is __CONVTYPE__ v ? value.Equals(v) : value.Equals(obj));

%%EQUALSOVERRIDE
##EQUATABLE
	/// <inheritdoc/>
	public readonly bool Equals(__TYPENAME__ other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public readonly bool Equals(__BASETYPE__ other) => value.Equals(other);

##CONVTYPE
	/// <inheritdoc/>
	public readonly bool Equals(__CONVTYPE__ other) => Value.Equals(other);

%%CONVTYPE
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
	public readonly int CompareTo(__TYPENAME__ other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	readonly int IComparable.CompareTo(object? obj) => Value.CompareTo(obj); //Convert.ChangeType(obj, typeof(__CONVTYPE__)));

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
##TOSTRING
##PTR
	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null, null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => ToString(null, provider);

	/// <inheritdoc/>
	public readonly string ToString(string? format, IFormatProvider? formatProvider) =>
#if NET5_0_OR_GREATER
		((IFormattable)Value).ToString(format, formatProvider);
#else
		Value.ToString(format, formatProvider);
#endif
%%PTR
##!PTR
##IFMT
	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null, null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => ToString(null, provider);

	/// <inheritdoc/>
	public readonly string ToString(string? format, IFormatProvider? formatProvider) => ((IFormattable)Value).ToString(format, formatProvider);

%%IFMT
##!IFMT
	/// <inheritdoc/>
	public override readonly string ToString() => ToString(null);

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => Value.ToString(provider);

%%!IFMT
%%!PTR
%%TOSTRING
##PARSABLE
##ISNUM
	/// <inheritdoc/>
	public static __TYPENAME__ Parse(string s, IFormatProvider? provider = null) => Parse(s, NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static __TYPENAME__ Parse(string s, NumberStyles style, IFormatProvider? provider) =>
##PTR
#if NET5_0_OR_GREATER
		new(__CONVTYPE__.Parse(s, style, provider));
#else
		PtrHelper.Parse((__CONVTYPE__)0, s, style, provider);
#endif
%%PTR
##!PTR
		new(__CONVTYPE__.Parse(s, style, provider));
%%!PTR

	/// <inheritdoc/>
	public static __TYPENAME__ Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s.ToString(), NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static __TYPENAME__ Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s.ToString(), style, provider);

%%ISNUM
##!ISNUM
	/// <inheritdoc/>
	public static __TYPENAME__ Parse(string s, IFormatProvider? provider = null) => new(ParsableAccessor<bool>.Parse(s, provider));

	/// <inheritdoc/>
	public static __TYPENAME__ Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s.ToString(), provider);

%%!ISNUM
##ISNUM
	/// <inheritdoc/>
	public static bool TryParse(string? s, IFormatProvider? provider, out __TYPENAME__ result) => TryParse(s, NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out __TYPENAME__ result) => TryParse(s.ToString(), NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out __TYPENAME__ result)
	{
##PTR
#if NET5_0_OR_GREATER
		bool bRet = __CONVTYPE__.TryParse(s, style, provider, out var r);
#else
		bool bRet = PtrHelper.TryParse(s, style, provider, out var r);
#endif
%%PTR
##!PTR
		bool bRet = __CONVTYPE__.TryParse(s, style, provider, out var r);
%%!PTR
		result = bRet ? new(r) : default;
		return bRet;
	}

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out __TYPENAME__ result) => TryParse(s.ToString(), style, provider, out result);

%%ISNUM
##!ISNUM
	/// <inheritdoc/>
	public static bool TryParse(string? s, IFormatProvider? provider, out __TYPENAME__ result)
	{
		bool bRet = ParsableAccessor<__CONVTYPE__>.TryParse(s, provider, out var r);
		result = bRet ? new(r) : default;
		return bRet;
	}

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out __TYPENAME__ result) => TryParse(s.ToString(), provider, out result);

%%!ISNUM
%%PARSABLE
##CONVERTIBLE
	/// <inheritdoc/>
	public readonly TypeCode GetTypeCode() => ((IConvertible)value).GetTypeCode();

##ISPANFMT
#if NET6_0_OR_GREATER
	/// <inheritdoc/>
	public readonly bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
		((ISpanFormattable)Value).TryFormat(destination, out charsWritten, format, provider);

#endif
%%ISPANFMT
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
	readonly object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToType(conversionType, provider);

	/// <inheritdoc/>
	readonly ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)Value).ToUInt16(provider);

	/// <inheritdoc/>
	readonly uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)Value).ToUInt32(provider);

	/// <inheritdoc/>
	readonly ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)Value).ToUInt64(provider);

%%CONVERTIBLE
##ISNUM
##NUMERICS
#if NET7_0_OR_GREATER
	/// <summary>Represents the largest possible value of <see cref="__TYPENAME__"/>.</summary>
	public static __TYPENAME__ MaxValue => NumberBaseAccessor<__CONVTYPE__>.MaxValue;

	/// <summary>Represents the smallest possible value of <see cref="__TYPENAME__"/>. This field is constant.</summary>
	public static __TYPENAME__ MinValue => NumberBaseAccessor<__CONVTYPE__>.MinValue;

	/// <summary>Represents the zero value of <see cref="__TYPENAME__"/>. This field is constant.</summary>
	public static __TYPENAME__ One => NumberBaseAccessor<__CONVTYPE__>.One;

	/// <summary>Represents the zero value of <see cref="__TYPENAME__"/>. This field is constant.</summary>
	public static __TYPENAME__ Zero => NumberBaseAccessor<__CONVTYPE__>.Zero;

	/// <inheritdoc/>
	static __TYPENAME__ IAdditiveIdentity<__TYPENAME__, __TYPENAME__>.AdditiveIdentity => NumberBaseAccessor<__CONVTYPE__>.AdditiveIdentity;

	/// <inheritdoc/>
	static __TYPENAME__ IMultiplicativeIdentity<__TYPENAME__, __TYPENAME__>.MultiplicativeIdentity => NumberBaseAccessor<__CONVTYPE__>.MultiplicativeIdentity;

	/// <inheritdoc/>
	static int INumberBase<__TYPENAME__>.Radix => NumberBaseAccessor<__CONVTYPE__>.Radix;

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.Abs(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.Abs(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsCanonical(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsCanonical(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsComplexNumber(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsComplexNumber(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsEvenInteger(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsEvenInteger(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsFinite(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsFinite(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsImaginaryNumber(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsImaginaryNumber(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsInfinity(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsInfinity(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsInteger(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsInteger(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNaN(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsNaN(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNegative(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsNegative(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNegativeInfinity(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsNegativeInfinity(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsNormal(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsNormal(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsOddInteger(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsOddInteger(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsPositive(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsPositive(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsPositiveInfinity(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsPositiveInfinity(value.Value);

	/// <inheritdoc/>
	static bool IBinaryNumber<__TYPENAME__>.IsPow2(__TYPENAME__ value) => BinaryIntegerAccessor<__CONVTYPE__>.IsPow2(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsRealNumber(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsRealNumber(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsSubnormal(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsSubnormal(value.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.IsZero(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.IsZero(value.Value);

	/// <inheritdoc/>
	static __TYPENAME__ IBinaryNumber<__TYPENAME__>.Log2(__TYPENAME__ value) => BinaryIntegerAccessor<__CONVTYPE__>.Log2(value.Value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MaxMagnitude(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__CONVTYPE__>.MaxMagnitude(x.Value, y.Value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MaxMagnitudeNumber(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__CONVTYPE__>.MaxMagnitudeNumber(x.Value, y.Value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MinMagnitude(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__CONVTYPE__>.MinMagnitude(x.Value, y.Value);

	/// <inheritdoc/>
	static __TYPENAME__ INumberBase<__TYPENAME__>.MinMagnitudeNumber(__TYPENAME__ x, __TYPENAME__ y) => NumberBaseAccessor<__CONVTYPE__>.MinMagnitudeNumber(x.Value, y.Value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertFromChecked<TOther>(TOther value, out __TYPENAME__ result) => NumberBaseAccessor<__CONVTYPE__>.TryConvertFromChecked<TOther, __BASETYPE__>(value, out result.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertFromSaturating<TOther>(TOther value, out __TYPENAME__ result) => NumberBaseAccessor<__CONVTYPE__>.TryConvertFromSaturating<TOther, __BASETYPE__>(value, out result.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertFromTruncating<TOther>(TOther value, out __TYPENAME__ result) => NumberBaseAccessor<__CONVTYPE__>.TryConvertFromTruncating<TOther, __BASETYPE__>(value, out result.value);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertToChecked<TOther>(__TYPENAME__ value, [MaybeNullWhen(false)] out TOther result) => NumberBaseAccessor<__CONVTYPE__>.TryConvertToChecked(value.Value, out result);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertToSaturating<TOther>(__TYPENAME__ value, [MaybeNullWhen(false)] out TOther result) => NumberBaseAccessor<__CONVTYPE__>.TryConvertToSaturating(value.Value, out result);

	/// <inheritdoc/>
	static bool INumberBase<__TYPENAME__>.TryConvertToTruncating<TOther>(__TYPENAME__ value, [MaybeNullWhen(false)] out TOther result) => NumberBaseAccessor<__CONVTYPE__>.TryConvertToTruncating(value.Value, out result);

	/// <inheritdoc/>
	static __TYPENAME__ IBinaryInteger<__TYPENAME__>.PopCount(__TYPENAME__ value) => BinaryIntegerAccessor<__CONVTYPE__>.PopCount(value.Value);

	/// <inheritdoc/>
	static __TYPENAME__ IBinaryInteger<__TYPENAME__>.TrailingZeroCount(__TYPENAME__ value) => BinaryIntegerAccessor<__CONVTYPE__>.TrailingZeroCount(value.Value);

	/// <inheritdoc/>
	static bool IBinaryInteger<__TYPENAME__>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out __TYPENAME__ value) => BinaryIntegerAccessor<__CONVTYPE__>.TryReadBigEndian<__BASETYPE__>(source, isUnsigned, out value.value);

	/// <inheritdoc/>
	static bool IBinaryInteger<__TYPENAME__>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out __TYPENAME__ value) => BinaryIntegerAccessor<__CONVTYPE__>.TryReadLittleEndian<__BASETYPE__>(source, isUnsigned, out value.value);

	/// <inheritdoc/>
	int IBinaryInteger<__TYPENAME__>.GetByteCount() => BinaryIntegerAccessor<__CONVTYPE__>.GetByteCount(value);

	/// <inheritdoc/>
	int IBinaryInteger<__TYPENAME__>.GetShortestBitLength() => BinaryIntegerAccessor<__CONVTYPE__>.GetShortestBitLength(value);

	/// <inheritdoc/>
	bool IBinaryInteger<__TYPENAME__>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten) => BinaryIntegerAccessor<__CONVTYPE__>.TryWriteBigEndian(value, destination, out bytesWritten);

	/// <inheritdoc/>
	bool IBinaryInteger<__TYPENAME__>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten) => BinaryIntegerAccessor<__CONVTYPE__>.TryWriteLittleEndian(value, destination, out bytesWritten);

	/// <inheritdoc/>
	public static __TYPENAME__ operator -(__TYPENAME__ value) => NumberBaseAccessor<__CONVTYPE__>.Negate(value.Value);
#endif // NET7_0_OR_GREATER

	/// <summary>Subtracts two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The minuend.</param>
	/// <param name="s2">The subtrahend.</param>
	/// <returns>The result of subtracting <paramref name="s2"/> from <paramref name="s1"/>.</returns>
	public static __TYPENAME__ operator -(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.Value - s2.Value);

	/// <summary>Decrements the <see cref="__TYPENAME__"/> by 1.</summary>
	/// <param name="s1">The value to decrement.</param>
	/// <returns>The value of <paramref name="s1"/> decremented by 1.</returns>
	public static __TYPENAME__ operator --(__TYPENAME__ s1) => s1.Value += 1;

	/// <summary>Returns the remainder resulting from dividing two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The remainder resulting from dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator %(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.Value % s2.Value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator &(__TYPENAME__ left, __TYPENAME__ right) => (__TYPENAME__)(left.Value & right.Value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator |(__TYPENAME__ left, __TYPENAME__ right) => (__TYPENAME__)(left.Value | right.Value);

	/// <summary>Multiplies two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The first value to multiply.</param>
	/// <param name="s2">The second value to multiply.</param>
	/// <returns>The result of multiplying <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator *(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.Value * s2.Value);

	/// <summary>Divides two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The result of dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator /(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.Value / s2.Value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator ^(__TYPENAME__ left, __TYPENAME__ right) => (__TYPENAME__)(left.Value ^ right.Value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator ~(__TYPENAME__ value) => (__TYPENAME__)~value.Value;

	/// <summary>Adds two specified <see cref="__TYPENAME__"/> values.</summary>
	/// <param name="s1">The first value to add.</param>
	/// <param name="s2">The second value to add.</param>
	/// <returns>The result of adding <paramref name="s1"/> and <paramref name="s2"/>.</returns>
	public static __TYPENAME__ operator +(__TYPENAME__ s1, __TYPENAME__ s2) => (__TYPENAME__)(s1.Value + s2.Value);

	/// <inheritdoc/>
	public static __TYPENAME__ operator +(__TYPENAME__ value) => (__TYPENAME__)(+value.Value);

	/// <summary>Increments the <see cref="__TYPENAME__"/> by 1.</summary>
	/// <param name="s1">The value to increment.</param>
	/// <returns>The value of <paramref name="s1"/> incremented by 1.</returns>
	public static __TYPENAME__ operator ++(__TYPENAME__ s1) => s1.Value += 1;

	/// <inheritdoc/>
	public static __TYPENAME__ operator <<(__TYPENAME__ value, int shiftAmount) => (__TYPENAME__)(value.Value << shiftAmount);

	/// <inheritdoc/>
	public static __TYPENAME__ operator >>(__TYPENAME__ value, int shiftAmount) => (__TYPENAME__)(value.Value >> shiftAmount);

	/// <inheritdoc/>
	public static __TYPENAME__ operator >>>(__TYPENAME__ value, int shiftAmount) => (__TYPENAME__)(value.Value >>> shiftAmount);

%%NUMERICS
%%ISNUM
##CONVERSIONS
	internal class __TYPENAME__TypeConverter : global::__CONVTYPEFULL__
	{
		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			new __TYPENAME__((__CONVTYPE__)base.ConvertFrom(context, culture, value)!);

		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
			value is __TYPENAME__ sz ? base.ConvertTo(context, culture, sz.Value, destinationType) : throw new NotSupportedException();
	}
%%CONVERSIONS
}