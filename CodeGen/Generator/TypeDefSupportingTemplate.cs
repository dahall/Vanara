#nullable enable
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
namespace Vanara.PInvoke;
#if !NET5_0_OR_GREATER
static class PtrHelper
{
	internal static int CompareTo(this IntPtr p, IntPtr obj) => p.ToInt64().CompareTo(obj.ToInt64());
	internal static int CompareTo(this UIntPtr p, UIntPtr obj) => p.ToUInt64().CompareTo(obj.ToUInt64());
	internal static int CompareTo(this IntPtr p, object? obj) => -(obj as IConvertible)?.ToInt64(null).CompareTo(p.ToInt64()) ?? throw new ArgumentException("Cannot be compared.", nameof(obj));
	internal static int CompareTo(this UIntPtr p, object? obj) => -(obj as IConvertible)?.ToUInt64(null).CompareTo(p.ToUInt64()) ?? throw new ArgumentException("Cannot be compared.", nameof(obj));
	internal static IntPtr Parse(IntPtr _, string s, NumberStyles style, IFormatProvider? provider) => IntPtr.Size == 4 ? new(int.Parse(s, style, provider)) : new(long.Parse(s, style, provider));
	internal static UIntPtr Parse(UIntPtr _, string s, NumberStyles style, IFormatProvider? provider) => UIntPtr.Size == 4 ? new(uint.Parse(s, style, provider)) : new(ulong.Parse(s, style, provider));
	internal static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out IntPtr result)
	{
		if (IntPtr.Size == 4)
		{
			if (int.TryParse(s, style, provider, out int r)) { result = new IntPtr(r); return true; }
		}
		else
		{
			if (long.TryParse(s, style, provider, out long r)) { result = new IntPtr(r); return true; }
		}
		result = IntPtr.Zero;
		return false;
	}
	internal static bool TryParse(string? s, NumberStyles style, IFormatProvider? provider, out UIntPtr result)
	{
		if (UIntPtr.Size == 4)
		{
			if (uint.TryParse(s, style, provider, out uint r)) { result = new UIntPtr(r); return true; }
		}
		else
		{
			if (ulong.TryParse(s, style, provider, out ulong r)) { result = new UIntPtr(r); return true; }
		}
		result = UIntPtr.Zero;
		return false;
	}
	internal static string ToString(this IntPtr p, string? format, IFormatProvider? formatProvider) =>
		IntPtr.Size == 4 ? p.ToInt32().ToString(format, formatProvider) : p.ToInt64().ToString(format, formatProvider);
	internal static string ToString(this UIntPtr p, string? format, IFormatProvider? formatProvider) =>
		UIntPtr.Size == 4 ? p.ToUInt32().ToString(format, formatProvider) : p.ToUInt64().ToString(format, formatProvider);
}
#endif
#if NET7_0_OR_GREATER
static class NumberBaseAccessor<T> where T : INumberBase<T>, IMinMaxValue<T>
{
	public static T AdditiveIdentity => T.AdditiveIdentity;
	public static T MultiplicativeIdentity => T.MultiplicativeIdentity;
	public static T One => T.One;
	public static int Radix => T.Radix;
	public static T Zero => T.Zero;
	public static T MaxValue => T.MinValue;
	public static T MinValue => T.MinValue;
	public static T Negate(T value) => Zero - value;
	public static T Abs(T value) => T.Abs(value);
	public static bool IsCanonical(T value) => T.IsCanonical(value);
	public static bool IsComplexNumber(T value) => T.IsComplexNumber(value);
	public static bool IsEvenInteger(T value) => T.IsEvenInteger(value);
	public static bool IsFinite(T value) => T.IsFinite(value);
	public static bool IsImaginaryNumber(T value) => T.IsImaginaryNumber(value);
	public static bool IsInfinity(T value) => T.IsInfinity(value);
	public static bool IsInteger(T value) => T.IsInteger(value);
	public static bool IsNaN(T value) => T.IsNaN(value);
	public static bool IsNegative(T value) => T.IsNegative(value);
	public static bool IsNegativeInfinity(T value) => T.IsNegativeInfinity(value);
	public static bool IsNormal(T value) => T.IsNormal(value);
	public static bool IsOddInteger(T value) => T.IsOddInteger(value);
	public static bool IsPositive(T value) => T.IsPositive(value);
	public static bool IsPositiveInfinity(T value) => T.IsPositiveInfinity(value);
	public static bool IsRealNumber(T value) => T.IsRealNumber(value);
	public static bool IsSubnormal(T value) => T.IsSubnormal(value);
	public static bool IsZero(T value) => T.IsZero(value);
	public static T MaxMagnitude(T x, T y) => T.MaxMagnitude(x, y);
	public static T MaxMagnitudeNumber(T x, T y) => T.MaxMagnitudeNumber(x, y);
	public static T MinMagnitude(T x, T y) => T.MinMagnitude(x, y);
	public static T MinMagnitudeNumber(T x, T y) => T.MinMagnitudeNumber(x, y);
	public static bool TryConvertFromChecked<TOther, TConv>(TOther value, out TConv result) => TryStaticCall("TryConvertFromChecked", value, out result!);
	public static bool TryConvertFromSaturating<TOther, TConv>(TOther value, out TConv result) => TryStaticCall("TryConvertFromSaturating", value, out result!);
	public static bool TryConvertFromTruncating<TOther, TConv>(TOther value, out TConv result) => TryStaticCall("TryConvertFromTruncating", value, out result!);
	public static bool TryConvertToChecked<TOther>(T value, [MaybeNullWhen(false)] out TOther result) => TryStaticCall("TryConvertToChecked", value, out result);
	public static bool TryConvertToSaturating<TOther>(T value, [MaybeNullWhen(false)] out TOther result) => TryStaticCall("TryConvertToSaturating", value, out result);
	public static bool TryConvertToTruncating<TOther>(T value, [MaybeNullWhen(false)] out TOther result) => TryStaticCall("TryConvertToTruncating", value, out result);
	static bool TryStaticCall<TOther, TConv>(string fName, TOther value, [MaybeNullWhen(false)] out TConv result)
	{
		try
		{
			object?[] args = [value, null];
			var ret = typeof(T).InvokeStaticMethod<bool>(fName, args);
			result = typeof(T) == typeof(TConv) ? (TConv)args[1]! : (TConv)Convert.ChangeType(args[1], typeof(TConv))!;
			return ret;
		}
		catch { result = default!; return false; }
	}
}
static class BinaryIntegerAccessor<T> where T : IBinaryInteger<T>
{
	public static bool IsPow2(T value) => T.IsPow2(value);
	public static T Log2(T value) => T.Log2(value);
	public static T PopCount(T value) => T.PopCount(value);
	public static T TrailingZeroCount(T value) => T.TrailingZeroCount(value);
	public static bool TryReadBigEndian<TConv>(ReadOnlySpan<byte> source, bool isUnsigned, out TConv value)
	{
		var ret = T.TryReadBigEndian(source, isUnsigned, out T v);
		value = (TConv)Convert.ChangeType(v, typeof(TConv))!;
		return ret;
	}
	public static bool TryReadLittleEndian<TConv>(ReadOnlySpan<byte> source, bool isUnsigned, out TConv value)
	{
		var ret = T.TryReadLittleEndian(source, isUnsigned, out var v);
		value = (TConv)Convert.ChangeType(v, typeof(TConv))!;
		return ret;
	}
	public static int GetByteCount(T value) => ((IBinaryInteger<T>)value).GetByteCount();
	public static int GetShortestBitLength(T value) => ((IBinaryInteger<T>)value).GetShortestBitLength();
	public static bool TryWriteBigEndian(T value, Span<byte> destination, out int bytesWritten) => ((IBinaryInteger<T>)value).TryWriteBigEndian(destination, out bytesWritten);
	public static bool TryWriteLittleEndian(T value, Span<byte> destination, out int bytesWritten) => value.TryWriteLittleEndian(destination, out bytesWritten);
}
#endif
#if NET8_0_OR_GREATER
static class ParsableAccessor<T> where T : IParsable<T>
{
	public static T Parse(string s, IFormatProvider? provider) => T.Parse(s, provider);
	public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out T result) => T.TryParse(s, provider, out result);
}
#else
static class ParsableAccessor<T> where T : struct
{
	public static T Parse(string? value, IFormatProvider? provider) => TryParse(value, provider, out T result) ? result : throw new FormatException();
	public static bool TryParse(string? value, IFormatProvider? provider, out T result)
	{
		const System.Reflection.BindingFlags bf = System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;
		result = default;
		var tp = typeof(T).GetMethod("TryParse", bf, null, [typeof(string), typeof(IFormatProvider), typeof(T).MakeByRefType()], null);
		if (tp != null)
		{
			object?[] args = [value, provider, null];
			var ret = (bool)tp.Invoke(null, args)!;
			result = ret ? (T)args[2]! : default;
			return ret;
		}
		tp = typeof(T).GetMethod("TryParse", bf, null, [typeof(string), typeof(T).MakeByRefType()], null);
		if (tp != null)
		{
			object?[] args = [value, null];
			var ret = (bool)tp.Invoke(null, args)!;
			result = ret ? (T)args[1]! : default;
			return ret;
		}
		return false;
	}
}
#endif