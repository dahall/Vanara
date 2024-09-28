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
[StructLayout(LayoutKind.Sequential), Serializable]
[TypeConverter(typeof(SizeTTypeConverter))]
[DebuggerDisplay("{Value}")]
public struct SizeT : IEquatable<SizeT>, IComparable<SizeT>, IConvertible, IComparable, ISerializable
#if NET7_0_OR_GREATER
	, IParsable<SizeT>, ISpanParsable<SizeT>, IBinaryInteger<SizeT>, IUnsignedNumber<SizeT>
#endif
{
	/// <summary>
	/// Represents the largest possible value of <see cref="SizeT"/>. This property is determined by the maximum bit-size of a pointer.
	/// </summary>
	public static readonly SizeT MaxValue =
#if NET6_0_OR_GREATER
		nuint.MaxValue;
#else
		UIntPtr.Size == 8 ? new(ulong.MaxValue) : new(uint.MaxValue);
#endif

	/// <summary>Represents the smallest possible value of <see cref="SizeT"/>. This field is constant.</summary>
	public static readonly SizeT MinValue = 0;

	/// <summary>Represents the zero value of <see cref="SizeT"/>. This field is constant.</summary>
	public static readonly SizeT Zero = default;

	private nuint val;

	/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
	/// <param name="value">The value.</param>
	public SizeT(uint value) => val = value;

	/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
	/// <param name="value">The value.</param>
	public SizeT(ulong value) => val = new UIntPtr(value);

	/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
	/// <param name="value">The value.</param>
	public unsafe SizeT(void* value) => val = (nuint)value;

	private SizeT(SerializationInfo info, StreamingContext context) => val = (nuint)info.GetUInt64("value");

	/// <inheritdoc/>
	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		if (info is null) throw new ArgumentNullException(nameof(info));
		info.AddValue("value", (ulong)val);
	}

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public ulong Value { get => val; private set => val = new UIntPtr(value); }

#if NET7_0_OR_GREATER
	/// <inheritdoc/>
	static SizeT IAdditiveIdentity<SizeT, SizeT>.AdditiveIdentity => Zero;

	/// <inheritdoc/>
	static SizeT IMultiplicativeIdentity<SizeT, SizeT>.MultiplicativeIdentity => new(1UL);

	/// <inheritdoc/>
	static SizeT INumberBase<SizeT>.One => new(1UL);

	/// <inheritdoc/>
	static int INumberBase<SizeT>.Radix => 2;

	/// <inheritdoc/>
	static SizeT INumberBase<SizeT>.Zero => Zero;
#endif

	/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="short"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator short(SizeT value) => ((IConvertible)value).ToInt16(null);

	/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="int"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator int(SizeT value) => ((IConvertible)value).ToInt32(null);

	/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="long"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator long(SizeT value) => ((IConvertible)value).ToInt64(null);

	/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="SizeT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SizeT(short value) => value >= 0 ? new SizeT((uint)value) : throw new ArgumentOutOfRangeException(nameof(value));

	/// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="SizeT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SizeT(ushort value) => new((uint)value);

	/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="SizeT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SizeT(int value) => value >= 0 ? new SizeT((uint)value) : throw new ArgumentOutOfRangeException(nameof(value));

	/// <summary>Performs an implicit conversion from <see cref="uint"/> to <see cref="SizeT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SizeT(uint value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="long"/> to <see cref="SizeT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SizeT(long value) => value >= 0 ? new SizeT((ulong)value) : throw new ArgumentOutOfRangeException(nameof(value));

	/// <summary>Performs an implicit conversion from <see cref="ulong"/> to <see cref="SizeT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator SizeT(ulong value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="ushort"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ushort(SizeT value) => (ushort)value.val;

	/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="uint"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator uint(SizeT value) => (uint)value.val;

	/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="ulong"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ulong(SizeT value) => value.val;

	/// <summary>Subtracts two specified <see cref="SizeT"/> values.</summary>
	/// <param name="s1">The minuend.</param>
	/// <param name="s2">The subtrahend.</param>
	/// <returns>The result of subtracting <paramref name="s2"/> from <paramref name="s1"/>.</returns>
	public static SizeT operator -(SizeT s1, SizeT s2) => s1.Value - s2.Value;

	/// <inheritdoc/>
	public static SizeT operator -(SizeT value) => UIntPtr.Zero - value.val;

	/// <summary>Decrements the <see cref="SizeT"/> by 1.</summary>
	/// <param name="s1">The value to decrement.</param>
	/// <returns>The value of <paramref name="s1"/> decremented by 1.</returns>
	public static SizeT operator --(SizeT s1) => s1.Value += 1;

	/// <summary>Indicates whether two <see cref="SizeT"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(SizeT s1, SizeT s2) => !s1.Equals(s2);

	/// <summary>Returns the remainder resulting from dividing two specified <see cref="SizeT"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The remainder resulting from dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static SizeT operator %(SizeT s1, SizeT s2) => s1.Value % s2.Value;

	/// <inheritdoc/>
	public static SizeT operator &(SizeT left, SizeT right) => left.Value & right.Value;

	/// <summary>Multiplies two specified <see cref="SizeT"/> values.</summary>
	/// <param name="s1">The first value to multiply.</param>
	/// <param name="s2">The second value to multiply.</param>
	/// <returns>The result of multiplying <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static SizeT operator *(SizeT s1, SizeT s2) => s1.Value * s2.Value;

	/// <summary>Divides two specified <see cref="SizeT"/> values.</summary>
	/// <param name="s1">The divident.</param>
	/// <param name="s2">The divisor.</param>
	/// <returns>The result of dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
	public static SizeT operator /(SizeT s1, SizeT s2) => s1.Value / s2.Value;

	/// <inheritdoc/>
	public static SizeT operator ^(SizeT left, SizeT right) => left.Value ^ right.Value;

	/// <inheritdoc/>
	public static SizeT operator ~(SizeT value) => ~value.Value;

	/// <summary>Adds two specified <see cref="SizeT"/> values.</summary>
	/// <param name="s1">The first value to add.</param>
	/// <param name="s2">The second value to add.</param>
	/// <returns>The result of adding <paramref name="s1"/> and <paramref name="s2"/>.</returns>
	public static SizeT operator +(SizeT s1, SizeT s2) => s1.Value + s2.Value;

	/// <inheritdoc/>
	public static SizeT operator +(SizeT value) => +value.Value;

	/// <summary>Increments the <see cref="SizeT"/> by 1.</summary>
	/// <param name="s1">The value to increment.</param>
	/// <returns>The value of <paramref name="s1"/> incremented by 1.</returns>
	public static SizeT operator ++(SizeT s1) => s1.Value += 1;

	/// <summary>Indicates whether a specified <see cref="SizeT"/> is less than another specified <see cref="SizeT"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(SizeT s1, SizeT s2) => s1.CompareTo(s2) < 0;

	/// <inheritdoc/>
	public static SizeT operator <<(SizeT value, int shiftAmount) => value.Value << shiftAmount;

	/// <summary>Indicates whether a specified <see cref="SizeT"/> is less than or equal to another specified <see cref="SizeT"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(SizeT s1, SizeT s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether two <see cref="SizeT"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(SizeT s1, SizeT s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="SizeT"/> is greater than another specified <see cref="SizeT"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(SizeT s1, SizeT s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="SizeT"/> is greater than or equal to another specified <see cref="SizeT"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(SizeT s1, SizeT s2) => s1.CompareTo(s2) >= 0;

	/// <inheritdoc/>
	public static SizeT operator >>(SizeT value, int shiftAmount) => value.Value >> shiftAmount;

	/// <inheritdoc/>
	public static SizeT operator >>>(SizeT value, int shiftAmount) => value.Value >>> shiftAmount;

	/// <inheritdoc/>
	public static SizeT Parse(string s, IFormatProvider? provider = null) => Parse(s, NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static SizeT Parse(string s, NumberStyles style, IFormatProvider? provider) => ulong.Parse(s, style, provider);

	/// <inheritdoc/>
	public static SizeT Parse(ReadOnlySpan<char> s, IFormatProvider? provider) => Parse(s.ToString(), NumberStyles.Any, provider);

	/// <inheritdoc/>
	public static SizeT Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) => Parse(s.ToString(), style, provider);

	/// <inheritdoc/>
	public static bool TryParse(string? s, IFormatProvider? provider, out SizeT result) => TryParse(s, NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out SizeT result) => TryParse(s.ToString(), NumberStyles.Any, provider, out result);

	/// <inheritdoc/>
	public static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out SizeT result) { var b = ulong.TryParse(s, style, provider, out var r); result = b ? r : default; return b; }

	/// <inheritdoc/>
	public static bool TryParse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out SizeT result) => TryParse(s.ToString(), style, provider, out result);

	/// <inheritdoc/>
	public int CompareTo(SizeT other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is SizeT s ? Equals(s) : Value.Equals(obj);

	/// <inheritdoc/>
	public bool Equals(SizeT other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public override int GetHashCode() => Value.GetHashCode();

	/// <inheritdoc/>
	public TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <inheritdoc/>
	public override string ToString() => Value.ToString();

	/// <inheritdoc/>
	public string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <inheritdoc/>
	public string ToString(string? format, IFormatProvider? formatProvider) => Value.ToString(format, formatProvider);

#if NET6_0_OR_GREATER || NETCOREAPP3_1_OR_GREATER
	/// <inheritdoc/>
	public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
		Value.TryFormat(destination, out charsWritten, format, provider);
#endif

#if NET7_0_OR_GREATER
	/// <inheritdoc/>
	static SizeT INumberBase<SizeT>.Abs(SizeT value) => value;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsCanonical(SizeT value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsComplexNumber(SizeT value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsEvenInteger(SizeT value) => (value.Value & 1) == 0;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsFinite(SizeT value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsImaginaryNumber(SizeT value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsInfinity(SizeT value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsInteger(SizeT value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsNaN(SizeT value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsNegative(SizeT value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsNegativeInfinity(SizeT value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsNormal(SizeT value) => value.Value != 0;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsOddInteger(SizeT value) => (value.Value & 1) != 0;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsPositive(SizeT value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsPositiveInfinity(SizeT value) => false;

	/// <inheritdoc/>
	static bool IBinaryNumber<SizeT>.IsPow2(SizeT value) => nuint.IsPow2(value.val);

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsRealNumber(SizeT value) => true;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsSubnormal(SizeT value) => false;

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.IsZero(SizeT value) => value.val == nuint.Zero;

	/// <inheritdoc/>
	static SizeT IBinaryNumber<SizeT>.Log2(SizeT value) => nuint.Log2(value.val);

	/// <inheritdoc/>
	static SizeT INumberBase<SizeT>.MaxMagnitude(SizeT x, SizeT y) => Math.Max(x.Value, y.Value);

	/// <inheritdoc/>
	static SizeT INumberBase<SizeT>.MaxMagnitudeNumber(SizeT x, SizeT y) => Math.Max(x.Value, y.Value);

	/// <inheritdoc/>
	static SizeT INumberBase<SizeT>.MinMagnitude(SizeT x, SizeT y) => Math.Min(x.Value, y.Value);

	/// <inheritdoc/>
	static SizeT INumberBase<SizeT>.MinMagnitudeNumber(SizeT x, SizeT y) => Math.Min(x.Value, y.Value);

	/// <inheritdoc/>
	public static SizeT operator |(SizeT left, SizeT right) => left.Value | right.Value;

	/// <inheritdoc/>
	static SizeT IBinaryInteger<SizeT>.PopCount(SizeT value) => nuint.PopCount(value.val);

	/// <inheritdoc/>
	static SizeT IBinaryInteger<SizeT>.TrailingZeroCount(SizeT value) => nuint.TrailingZeroCount(value.val);

	/// <inheritdoc/>
	static bool INumberBase<SizeT>.TryConvertFromChecked<TOther>(TOther value, out SizeT result)
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
	static bool INumberBase<SizeT>.TryConvertFromSaturating<TOther>(TOther value, out SizeT result)
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
	static bool INumberBase<SizeT>.TryConvertFromTruncating<TOther>(TOther value, out SizeT result)
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
	static bool INumberBase<SizeT>.TryConvertToChecked<TOther>(SizeT value, [MaybeNullWhen(false)] out TOther result)
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
	static bool INumberBase<SizeT>.TryConvertToSaturating<TOther>(SizeT value, [MaybeNullWhen(false)] out TOther result)
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
	static bool INumberBase<SizeT>.TryConvertToTruncating<TOther>(SizeT value, [MaybeNullWhen(false)] out TOther result)
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
	static bool IBinaryInteger<SizeT>.TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out SizeT value)
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
	static bool IBinaryInteger<SizeT>.TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out SizeT value)
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
	int IBinaryInteger<SizeT>.GetByteCount() => ((IBinaryInteger<nuint>)val).GetByteCount();

	/// <inheritdoc/>
	int IBinaryInteger<SizeT>.GetShortestBitLength() => ((IBinaryInteger<nuint>)val).GetShortestBitLength();

	/// <inheritdoc/>
	bool IBinaryInteger<SizeT>.TryWriteBigEndian(Span<byte> destination, out int bytesWritten) => ((IBinaryInteger<nuint>)val).TryWriteBigEndian(destination, out bytesWritten);

	/// <inheritdoc/>
	bool IBinaryInteger<SizeT>.TryWriteLittleEndian(Span<byte> destination, out int bytesWritten) => ((IBinaryInteger<nuint>)val).TryWriteLittleEndian(destination, out bytesWritten);
#endif

	/// <inheritdoc/>
	int IComparable.CompareTo(object? obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(ulong)));

	/// <inheritdoc/>
	bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	byte IConvertible.ToByte(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < byte.MaxValue)
			return (byte)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return byte.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)Value).ToDateTime(provider);

	/// <inheritdoc/>
	decimal IConvertible.ToDecimal(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < decimal.MaxValue)
			return ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return decimal.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	double IConvertible.ToDouble(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < double.MaxValue)
			return ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return double.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	short IConvertible.ToInt16(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < (ulong)short.MaxValue)
			return (short)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return short.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	int IConvertible.ToInt32(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < int.MaxValue)
			return (int)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return int.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	long IConvertible.ToInt64(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < long.MaxValue)
			return (long)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return long.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	sbyte IConvertible.ToSByte(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < (ulong)sbyte.MaxValue)
			return (sbyte)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return sbyte.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	float IConvertible.ToSingle(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < float.MaxValue)
			return ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return float.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToType(conversionType, provider);

	/// <inheritdoc/>
	ushort IConvertible.ToUInt16(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < ushort.MaxValue)
			return (ushort)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return ushort.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	uint IConvertible.ToUInt32(IFormatProvider? provider)
	{
		var ul = Value;
		if (ul < uint.MaxValue)
			return (uint)ul;
		if (ul is uint.MaxValue or ulong.MaxValue)
			return uint.MaxValue;
		throw new OverflowException();
	}

	/// <inheritdoc/>
	ulong IConvertible.ToUInt64(IFormatProvider? provider) => Value;

	internal class SizeTTypeConverter : UInt64Converter
	{
		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			new SizeT((ulong)base.ConvertFrom(context, culture, value)!);

		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
					value is SizeT sz ? base.ConvertTo(context, culture, sz.Value, destinationType) : throw new NotSupportedException();
	}
}