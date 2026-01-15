using System.Buffers.Binary;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Vanara.PInvoke;

/// <summary>Managed instance of the SIZE_T type.</summary>
[StructLayout(LayoutKind.Sequential), Serializable, TypeConverter(typeof(SIZE_TTypeConverter)), DebuggerDisplay("{Value}")]
public struct SIZE_T : IEquatable<SIZE_T>, IComparable<SIZE_T>, IConvertible, IComparable, ISerializable
#if NET7_0_OR_GREATER
	, IParsable<SIZE_T>, ISpanParsable<SIZE_T>, IBinaryInteger<SIZE_T>, IUnsignedNumber<SIZE_T>
#endif
{
	/// <summary>
	/// Represents the largest possible value of <see cref="SIZE_T"/>. This property is determined by the maximum bit-size of a pointer.
	/// </summary>
	public static readonly SIZE_T MaxValue =
#if NET6_0_OR_GREATER
		nuint.MaxValue;
#else
		UIntPtr.Size == 8 ? new(ulong.MaxValue) : new(uint.MaxValue);
#endif

	/// <summary>Represents the smallest possible value of <see cref="SIZE_T"/>. This field is constant.</summary>
	public static readonly SIZE_T MinValue = 0;

	/// <summary>Represents the zero value of <see cref="SIZE_T"/>. This field is constant.</summary>
	public static readonly SIZE_T Zero = default;

	private nuint val;

	/// <summary>Initializes a new instance of the <see cref="SIZE_T"/> struct.</summary>
	/// <param name="value">The value.</param>
	public SIZE_T(uint value) => val = value;

	/// <summary>Initializes a new instance of the <see cref="SIZE_T"/> struct.</summary>
	/// <param name="value">The value.</param>
	public SIZE_T(ulong value) => val = new UIntPtr(value);

	/// <summary>Initializes a new instance of the <see cref="SIZE_T"/> struct.</summary>
	/// <param name="value">The value.</param>
	public unsafe SIZE_T(void* value) => val = (nuint)value;

	private SIZE_T(SerializationInfo info, StreamingContext context) => val = (nuint)info.GetUInt64("value");

	/// <inheritdoc/>
	readonly void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info is null) throw new ArgumentNullException(nameof(info));
		info.AddValue("value", (ulong)val);
	}

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public ulong Value { readonly get => val; private set => val = new UIntPtr(value); }

#if NET7_0_OR_GREATER
	/// <inheritdoc/>
	static SIZE_T IAdditiveIdentity<SIZE_T, SIZE_T>.AdditiveIdentity => Zero;

	/// <inheritdoc/>
	static SIZE_T IMultiplicativeIdentity<SIZE_T, SIZE_T>.MultiplicativeIdentity => new(1UL);

	/// <inheritdoc/>
	static SIZE_T INumberBase<SIZE_T>.One => new(1UL);

	/// <inheritdoc/>
	static int INumberBase<SIZE_T>.Radix => 2;

	/// <inheritdoc/>
	static SIZE_T INumberBase<SIZE_T>.Zero => Zero;
#endif

	/// <summary>Performs an implicit conversion from <see cref="SIZE_T"/> to <see cref="short"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator short(SIZE_T value) => ((IConvertible)value).ToInt16(null);

	/// <summary>Performs an implicit conversion from <see cref="SIZE_T"/> to <see cref="int"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator int(SIZE_T value) => ((IConvertible)value).ToInt32(null);

	/// <summary>Performs an implicit conversion from <see cref="SIZE_T"/> to <see cref="long"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator long(SIZE_T value) => ((IConvertible)value).ToInt64(null);

	/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="SIZE_T"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SIZE_T(short value) => value >= 0 ? new SIZE_T((uint)value) : throw new ArgumentOutOfRangeException(nameof(value));

	/// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="SIZE_T"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SIZE_T(ushort value) => new((uint)value);

	/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="SIZE_T"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SIZE_T(int value) => value >= 0 ? new SIZE_T((uint)value) : throw new ArgumentOutOfRangeException(nameof(value));

	/// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="SIZE_T"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SIZE_T(uint value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="long"/> to <see cref="SIZE_T"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SIZE_T(long value) => value >= 0 ? new SIZE_T((ulong)value) : throw new ArgumentOutOfRangeException(nameof(value));

	/// <summary>Performs an implicit conversion from <see cref="ulong"/> to <see cref="SIZE_T"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SIZE_T(ulong value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="SIZE_T"/> to <see cref="ushort"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ushort(SIZE_T value) => (ushort)value.val;

	/// <summary>Performs an implicit conversion from <see cref="SIZE_T"/> to <see cref="uint"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator uint(SIZE_T value) => (uint)value.val;

	/// <summary>Performs an implicit conversion from <see cref="SIZE_T"/> to <see cref="ulong"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ulong(SIZE_T value) => value.val;

	/// <summary>Subtracts two specified <see cref="SIZE_T"/> values.</summary>
	/// <param name="s1">The minuend.</param>
	/// <param name="s2">The subtrahend.</param>
	/// <returns>The result of subtracting <paramref name="s2"/> from <paramref name="s1"/>.</returns>
	public static SIZE_T operator -(SIZE_T s1, SIZE_T s2) => s1.Value - s2.Value;

	/// <inheritdoc/>
	public static SIZE_T operator -(SIZE_T value) => UIntPtr.Zero - value.val;

	/// <summary>Decrements the <see cref="SIZE_T"/> by 1.</summary>
	/// <param name="s1">The value to decrement.</param>
	/// <returns>The value of <paramref name="s1"/> decremented by 1.</returns>
	public static SIZE_T operator --(SIZE_T s1) => s1.Value += 1;

	/// <summary>Indicates whether two <see cref="SIZE_T"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(SIZE_T s1, SIZE_T s2) => !s1.Equals(s2);

	/// <summary>Returns the remainder resulting from dividing two specified <see cref="SIZE_T"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The remainder resulting from dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static SIZE_T operator %(SIZE_T s1, SIZE_T s2) => s1.Value % s2.Value;

	/// <inheritdoc/>
	public static SIZE_T operator &(SIZE_T left, SIZE_T right) => left.Value & right.Value;

	/// <summary>Multiplies two specified <see cref="SIZE_T"/> values.</summary>
	/// <param name="s1">The first value to multiply.</param>
	/// <param name="s2">The second value to multiply.</param>
	/// <returns>The result of multiplying <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static SIZE_T operator *(SIZE_T s1, SIZE_T s2) => s1.Value * s2.Value;

	/// <summary>Divides two specified <see cref="SIZE_T"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The result of dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static SIZE_T operator /(SIZE_T s1, SIZE_T s2) => s1.Value / s2.Value;

	/// <inheritdoc/>
	public static SIZE_T operator ^(SIZE_T left, SIZE_T right) => left.Value ^ right.Value;

	/// <inheritdoc/>
	public static SIZE_T operator ~(SIZE_T value) => ~value.Value;

	/// <summary>Adds two specified <see cref="SIZE_T"/> values.</summary>
	/// <param name="s1">The first value to add.</param>
	/// <param name="s2">The second value to add.</param>
	/// <returns>The result of adding <paramref name="s1"/> and <paramref name="s2"/>.</returns>
	public static SIZE_T operator +(SIZE_T s1, SIZE_T s2) => s1.Value + s2.Value;

	/// <inheritdoc/>
	public static SIZE_T operator +(SIZE_T value) => +value.Value;

	/// <summary>Increments the <see cref="SIZE_T"/> by 1.</summary>
	/// <param name="s1">The value to increment.</param>
	/// <returns>The value of <paramref name="s1"/> incremented by 1.</returns>
	public static SIZE_T operator ++(SIZE_T s1) => s1.Value += 1;

	/// <summary>Indicates whether a specified <see cref="SIZE_T"/> is less than another specified <see cref="SIZE_T"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(SIZE_T s1, SIZE_T s2) => s1.CompareTo(s2) < 0;

	/// <inheritdoc/>
	public static SIZE_T operator <<(SIZE_T value, int shiftAmount) => value.Value << shiftAmount;

	/// <summary>Indicates whether a specified <see cref="SIZE_T"/> is less than or equal to another specified <see cref="SIZE_T"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(SIZE_T s1, SIZE_T s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether two <see cref="SIZE_T"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(SIZE_T s1, SIZE_T s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="SIZE_T"/> is greater than another specified <see cref="SIZE_T"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(SIZE_T s1, SIZE_T s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="SIZE_T"/> is greater than or equal to another specified <see cref="SIZE_T"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(SIZE_T s1, SIZE_T s2) => s1.CompareTo(s2) >= 0;

	/// <inheritdoc/>
	public static SIZE_T operator >>(SIZE_T value, int shiftAmount) => value.Value >> shiftAmount;

	/// <inheritdoc/>
	public static SIZE_T operator >>>(SIZE_T value, int shiftAmount) => value.Value >>> shiftAmount;

	/// <inheritdoc/>
	public static SIZE_T Parse(string s, IFormatProvider? provider = null) => Parse(s, NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static SIZE_T Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

	/// <inheritdoc/>
	public static SIZE_T Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s.ToString(), NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static SIZE_T Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s.ToString(), style, provider);

	/// <inheritdoc/>
	public static bool TryParse(string? s, IFormatProvider? provider, out SIZE_T result) => TryParse(s, NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out SIZE_T result) => TryParse(s.ToString(), NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out SIZE_T result) { var b = ulong.TryParse(s, style, provider, out var r); result = b ? r : default; return b; }

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out SIZE_T result) => TryParse(s.ToString(), style, provider, out result);

	/// <inheritdoc/>
	public readonly int CompareTo(SIZE_T other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj is SIZE_T s ? Equals(s) : Value.Equals(obj);

	/// <inheritdoc/>
	public readonly bool Equals(SIZE_T other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public override readonly int GetHashCode() => Value.GetHashCode();

	/// <inheritdoc/>
	public readonly TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <inheritdoc/>
	public override readonly string ToString() => Value.ToString();

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <inheritdoc/>
	public readonly string ToString(string? format, IFormatProvider? formatProvider) => Value.ToString(format, formatProvider);

#if NET6_0_OR_GREATER || NETCOREAPP3_1_OR_GREATER
	/// <inheritdoc/>
	public readonly bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
		Value.TryFormat(destination, out charsWritten, format, provider);
#endif

#if NET7_0_OR_GREATER
	/// <inheritdoc/>
	static SIZE_T INumberBase<SIZE_T>.Abs(SIZE_T value) => value;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsCanonical(SIZE_T value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsComplexNumber(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsEvenInteger(SIZE_T value) => (value.Value & 1) == 0;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsFinite(SIZE_T value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsImaginaryNumber(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsInfinity(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsInteger(SIZE_T value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsNaN(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsNegative(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsNegativeInfinity(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsNormal(SIZE_T value) => value.Value != 0;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsOddInteger(SIZE_T value) => (value.Value & 1) != 0;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsPositive(SIZE_T value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsPositiveInfinity(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool IBinaryNumber<SIZE_T>.IsPow2(SIZE_T value) => nuint.IsPow2(value.val);

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsRealNumber(SIZE_T value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsSubnormal(SIZE_T value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.IsZero(SIZE_T value) => value.val == nuint.Zero;

	/// <inheritdoc/>
	static SIZE_T IBinaryNumber<SIZE_T>.Log2(SIZE_T value) => nuint.Log2(value.val);

	/// <inheritdoc/>
	static SIZE_T INumberBase<SIZE_T>.MaxMagnitude(SIZE_T x, SIZE_T y) => Math.Max(x.Value, y.Value);

	/// <inheritdoc/>
	static SIZE_T INumberBase<SIZE_T>.MaxMagnitudeNumber(SIZE_T x, SIZE_T y) => Math.Max(x.Value, y.Value);

	/// <inheritdoc/>
	static SIZE_T INumberBase<SIZE_T>.MinMagnitude(SIZE_T x, SIZE_T y) => Math.Min(x.Value, y.Value);

	/// <inheritdoc/>
	static SIZE_T INumberBase<SIZE_T>.MinMagnitudeNumber(SIZE_T x, SIZE_T y) => Math.Min(x.Value, y.Value);

	/// <inheritdoc/>
	public static SIZE_T operator |(SIZE_T left, SIZE_T right) => left.Value | right.Value;

	/// <inheritdoc/>
	static SIZE_T IBinaryInteger<SIZE_T>.PopCount(SIZE_T value) => nuint.PopCount(value.val);

	/// <inheritdoc/>
	static SIZE_T IBinaryInteger<SIZE_T>.TrailingZeroCount(SIZE_T value) => nuint.TrailingZeroCount(value.val);

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.TryConvertFromChecked<TOther>(TOther value, out SIZE_T result)
	{
		// In order to reduce overall code duplication and improve the inlinabilty of these
		// methods for the corelib types we have `ConvertFrom` handle the same sign and
		// `ConvertTo` handle the opposite sign. However, since there is an uneven split
		// between signed and unsigned types, the one that handles unsigned will also
		// handle `Decimal`.
		//
		// That is, `ConvertFrom` for `ulong` will handle the other unsigned types and
		// `ConvertTo` will handle the signed types

		if (typeof(TOther) == typeof(byte))
		{
			byte actualValue = (byte)(object)value;
			result = (ulong)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(char))
		{
			char actualValue = (char)(object)value;
			result = (ulong)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(decimal))
		{
			decimal actualValue = (decimal)(object)value;
			result = checked((ulong)actualValue);
			return true;
		}
		else if (typeof(TOther) == typeof(ushort))
		{
			ushort actualValue = (ushort)(object)value;
			result = (ulong)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(uint))
		{
			uint actualValue = (uint)(object)value;
			result = actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(ulong))
		{
			ulong actualValue = (ulong)(object)value;
			result = actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(UInt128))
		{
			UInt128 actualValue = (UInt128)(object)value;
			result = checked((ulong)actualValue);
			return true;
		}
		else if (typeof(TOther) == typeof(nuint))
		{
			nuint actualValue = (nuint)(object)value;
			result = actualValue;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.TryConvertFromSaturating<TOther>(TOther value, out SIZE_T result)
	{
		// In order to reduce overall code duplication and improve the inlinabilty of these
		// methods for the corelib types we have `ConvertFrom` handle the same sign and
		// `ConvertTo` handle the opposite sign. However, since there is an uneven split
		// between signed and unsigned types, the one that handles unsigned will also
		// handle `Decimal`.
		//
		// That is, `ConvertFrom` for `ulong` will handle the other unsigned types and
		// `ConvertTo` will handle the signed types

		if (typeof(TOther) == typeof(byte))
		{
			byte actualValue = (byte)(object)value;
			result = (uint)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(char))
		{
			char actualValue = (char)(object)value;
			result = (uint)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(decimal))
		{
			decimal actualValue = (decimal)(object)value;
			result = (actualValue >= (ulong)MaxValue) ? MaxValue :
					 (actualValue <= (ulong)MinValue) ? MinValue : (ulong)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(ushort))
		{
			ushort actualValue = (ushort)(object)value;
			result = (uint)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(uint))
		{
			uint actualValue = (uint)(object)value;
			result = actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(ulong))
		{
			ulong actualValue = (ulong)(object)value;
			result = actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(UInt128))
		{
			UInt128 actualValue = (UInt128)(object)value;
			result = (actualValue >= (ulong)MaxValue) ? MaxValue : (ulong)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(nuint))
		{
			nuint actualValue = (nuint)(object)value;
			result = actualValue;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.TryConvertFromTruncating<TOther>(TOther value, out SIZE_T result)
	{
		// In order to reduce overall code duplication and improve the inlinabilty of these
		// methods for the corelib types we have `ConvertFrom` handle the same sign and
		// `ConvertTo` handle the opposite sign. However, since there is an uneven split
		// between signed and unsigned types, the one that handles unsigned will also
		// handle `Decimal`.
		//
		// That is, `ConvertFrom` for `ulong` will handle the other unsigned types and
		// `ConvertTo` will handle the signed types

		if (typeof(TOther) == typeof(byte))
		{
			byte actualValue = (byte)(object)value;
			result = (uint)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(char))
		{
			char actualValue = (char)(object)value;
			result = (uint)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(decimal))
		{
			decimal actualValue = (decimal)(object)value;
			result = (actualValue >= (ulong)MaxValue) ? MaxValue :
					 (actualValue <= (ulong)MinValue) ? MinValue : (ulong)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(ushort))
		{
			ushort actualValue = (ushort)(object)value;
			result = (uint)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(uint))
		{
			uint actualValue = (uint)(object)value;
			result = actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(ulong))
		{
			ulong actualValue = (ulong)(object)value;
			result = actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(UInt128))
		{
			UInt128 actualValue = (UInt128)(object)value;
			result = (ulong)actualValue;
			return true;
		}
		else if (typeof(TOther) == typeof(nuint))
		{
			nuint actualValue = (nuint)(object)value;
			result = actualValue;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.TryConvertToChecked<TOther>(SIZE_T value, [MaybeNullWhen(false)] out TOther result)
	{
		// In order to reduce overall code duplication and improve the inlinabilty of these
		// methods for the corelib types we have `ConvertFrom` handle the same sign and
		// `ConvertTo` handle the opposite sign. However, since there is an uneven split
		// between signed and unsigned types, the one that handles unsigned will also
		// handle `Decimal`.
		//
		// That is, `ConvertFrom` for `nuint` will handle the other unsigned types and
		// `ConvertTo` will handle the signed types

		if (typeof(TOther) == typeof(double))
		{
			double actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(Half))
		{
			Half actualResult = (Half)value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(short))
		{
			short actualResult = checked((short)value);
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(int))
		{
			int actualResult = checked((int)value);
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(long))
		{
			long actualResult = checked((long)value);
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(Int128))
		{
			Int128 actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(nint))
		{
			nint actualResult = checked((nint)value);
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(sbyte))
		{
			sbyte actualResult = checked((sbyte)value);
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(float))
		{
			float actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.TryConvertToSaturating<TOther>(SIZE_T value, [MaybeNullWhen(false)] out TOther result)
	{
		if (typeof(TOther) == typeof(double))
		{
			double actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(Half))
		{
			Half actualResult = (Half)value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(short))
		{
			short actualResult = (value >= (nuint)short.MaxValue) ? short.MaxValue : (short)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(int))
		{
			int actualResult = (value >= int.MaxValue) ? int.MaxValue : (int)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(long))
		{
			long actualResult = (value >= long.MaxValue) ? long.MaxValue : (long)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(Int128))
		{
			Int128 actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(nint))
		{
			nint actualResult = (value >= (nuint)nint.MaxValue) ? nint.MaxValue : (nint)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(sbyte))
		{
			sbyte actualResult = (value >= (nuint)sbyte.MaxValue) ? sbyte.MaxValue : (sbyte)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(float))
		{
			float actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}

	/// <inheritdoc/>
	static bool INumberBase<SIZE_T>.TryConvertToTruncating<TOther>(SIZE_T value, [MaybeNullWhen(false)] out TOther result)
	{
		// In order to reduce overall code duplication and improve the inlinabilty of these
		// methods for the corelib types we have `ConvertFrom` handle the same sign and
		// `ConvertTo` handle the opposite sign. However, since there is an uneven split
		// between signed and unsigned types, the one that handles unsigned will also
		// handle `Decimal`.
		//
		// That is, `ConvertFrom` for `nuint` will handle the other unsigned types and
		// `ConvertTo` will handle the signed types

		if (typeof(TOther) == typeof(double))
		{
			double actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(Half))
		{
			Half actualResult = (Half)value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(short))
		{
			short actualResult = (short)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(int))
		{
			int actualResult = (int)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(long))
		{
			long actualResult = (long)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(Int128))
		{
			Int128 actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(nint))
		{
			nint actualResult = (nint)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(sbyte))
		{
			sbyte actualResult = (sbyte)value;
			result = (TOther)(object)actualResult;
			return true;
		}
		else if (typeof(TOther) == typeof(float))
		{
			float actualResult = value.val;
			result = (TOther)(object)actualResult;
			return true;
		}
		else
		{
			result = default;
			return false;
		}
	}

	/// <inheritdoc/>
	static bool IBinaryInteger<SIZE_T>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out SIZE_T value)
	{
		ulong result = default;

		if (source.Length != 0)
		{
			if (!isUnsigned && sbyte.IsNegative((sbyte)source[0]))
			{
				// When we are signed and the sign bit is set, we are negative and therefore
				// definitely out of range

				value = result;
				return false;
			}

			if ((source.Length > sizeof(ulong)) && (source[..^sizeof(ulong)].IndexOfAnyExcept((byte)0x00) >= 0))
			{
				// When we have any non-zero leading data, we are a large positive and therefore
				// definitely out of range

				value = result;
				return false;
			}

			ref byte sourceRef = ref MemoryMarshal.GetReference(source);

			if (source.Length >= sizeof(ulong))
			{
				sourceRef = ref Unsafe.Add(ref sourceRef, source.Length - sizeof(ulong));

				// We have at least 8 bytes, so just read the ones we need directly
				result = Unsafe.ReadUnaligned<ulong>(ref sourceRef);

				if (BitConverter.IsLittleEndian)
				{
					result = BinaryPrimitives.ReverseEndianness(result);
				}
			}
			else
			{
				// We have between 1 and 7 bytes, so construct the relevant value directly
				// since the data is in Big Endian format, we can just read the bytes and
				// shift left by 8-bits for each subsequent part

				for (int i = 0; i < source.Length; i++)
				{
					result <<= 8;
					result |= Unsafe.Add(ref sourceRef, i);
				}
			}
		}

		value = result;
		return true;
	}

	/// <inheritdoc/>
	static bool IBinaryInteger<SIZE_T>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out SIZE_T value)
	{
		ulong result = default;

		if (source.Length != 0)
		{
			if (!isUnsigned && sbyte.IsNegative((sbyte)source[^1]))
			{
				// When we are signed and the sign bit is set, we are negative and therefore
				// definitely out of range

				value = result;
				return false;
			}

			if ((source.Length > sizeof(ulong)) && (source[sizeof(ulong)..].IndexOfAnyExcept((byte)0x00) >= 0))
			{
				// When we have any non-zero leading data, we are a large positive and therefore
				// definitely out of range

				value = result;
				return false;
			}

			ref byte sourceRef = ref MemoryMarshal.GetReference(source);

			if (source.Length >= sizeof(ulong))
			{
				// We have at least 8 bytes, so just read the ones we need directly
				result = Unsafe.ReadUnaligned<ulong>(ref sourceRef);

				if (!BitConverter.IsLittleEndian)
				{
					result = BinaryPrimitives.ReverseEndianness(result);
				}
			}
			else
			{
				// We have between 1 and 7 bytes, so construct the relevant value directly
				// since the data is in Little Endian format, we can just read the bytes and
				// shift left by 8-bits for each subsequent part, then reverse endianness to
				// ensure the order is correct. This is more efficient than iterating in reverse
				// due to current JIT limitations

				for (int i = 0; i < source.Length; i++)
				{
					ulong part = Unsafe.Add(ref sourceRef, i);
					part <<= (i * 8);
					result |= part;
				}
			}
		}

		value = result;
		return true;
	}

	/// <inheritdoc/>
	int IBinaryInteger<SIZE_T>.GetByteCount() => ((IBinaryInteger<nuint>)val).GetByteCount();

	/// <inheritdoc/>
	int IBinaryInteger<SIZE_T>.GetShortestBitLength() => ((IBinaryInteger<nuint>)val).GetShortestBitLength();

	/// <inheritdoc/>
	bool IBinaryInteger<SIZE_T>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten) => ((IBinaryInteger<nuint>)val).TryWriteBigEndian(destination, out bytesWritten);

	/// <inheritdoc/>
	bool IBinaryInteger<SIZE_T>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten) => ((IBinaryInteger<nuint>)val).TryWriteLittleEndian(destination, out bytesWritten);
#endif

	/// <inheritdoc/>
	readonly int IComparable.CompareTo(object? obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(ulong)));

	/// <inheritdoc/>
	readonly bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	readonly byte IConvertible.ToByte(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= byte.MaxValue)
			return (byte)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return byte.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	readonly DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)Value).ToDateTime(provider);

	/// <inheritdoc/>
	readonly decimal IConvertible.ToDecimal(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= decimal.MaxValue)
			return ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return decimal.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly double IConvertible.ToDouble(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= double.MaxValue)
			return ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return double.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly short IConvertible.ToInt16(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= (ulong)short.MaxValue)
			return (short)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return short.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly int IConvertible.ToInt32(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= int.MaxValue)
			return (int)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return int.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly long IConvertible.ToInt64(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= long.MaxValue)
			return (long)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return long.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly sbyte IConvertible.ToSByte(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= (ulong)sbyte.MaxValue)
			return (sbyte)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return sbyte.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly float IConvertible.ToSingle(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= float.MaxValue)
			return ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return float.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToType(conversionType, provider);

	/// <inheritdoc/>
	readonly ushort IConvertible.ToUInt16(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= ushort.MaxValue)
			return (ushort)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return ushort.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly uint IConvertible.ToUInt32(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul <= uint.MaxValue)
			return (uint)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return uint.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	readonly ulong IConvertible.ToUInt64(IFormatProvider? provider) => Value;

	internal class SIZE_TTypeConverter : UInt64Converter
	{
		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			new SIZE_T((ulong)base.ConvertFrom(context, culture, value)!);

		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
					value is SIZE_T sz ? base.ConvertTo(context, culture, sz.Value, destinationType) : throw new NotSupportedException();
	}
}