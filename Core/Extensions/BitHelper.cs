namespace Vanara.Extensions;

/// <summary>Static methods to help with bit manipulation.</summary>
/// <remarks>This class is intended to support whole numbers. Without a specific constraint for numbers, the list of constraints helps to limit incorrect types, but is NOT foolproof.</remarks>
public static class BitHelper
{
	/// <summary>Gets the bit value at the specified index in a bit vector.</summary>
	/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <param name="bits">The bit vector.</param>
	/// <param name="idx">The zero-based index of the bit to get.</param>
	/// <returns><see langword="true"/> if the bit is set (1); <see langword="false"/> otherwise.</returns>
	public static bool GetBit<T>(T bits, byte idx) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable =>
		(idx < (Marshal.SizeOf(typeof(T)) * 8)) ? (bits.ToInt64(null) & 1 << idx) != 0 : throw new ArgumentOutOfRangeException(nameof(idx));

	/// <summary>Gets the bit array value from the specified range in a bit vector.</summary>
	/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <param name="bits">The bit vector.</param>
	/// <param name="startIdx">The zero-based start index of the bit range to get.</param>
	/// <param name="count">The number of sequential bits to fetch starting at <paramref name="startIdx"/>.</param>
	/// <returns>The value of the requested bit range.</returns>
	public static T GetBits<T>(T bits, byte startIdx, byte count) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
	{
		if (startIdx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(startIdx));
		if (count + startIdx > (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(count));
		return (T)Convert.ChangeType((bits.ToInt64(null) >> startIdx) & ((1 << count) - 1), typeof(T));
	}

	/// <summary>Sets the bit value at the specified index in a bit vector.</summary>
	/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <param name="bits">The bit vector.</param>
	/// <param name="idx">The index of the bit to set.</param>
	/// <param name="value">If set to <see langword="true"/>, set the bit (= 1); otherwise, clear the bit (= 0).</param>
	public static void SetBit<T>(ref T bits, byte idx, bool value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
	{
		if (idx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(idx));
		long bit = 1 << idx;
		var l = bits.ToInt64(null);
		bits = (T)Convert.ChangeType(value ? l | bit : l & ~bit, typeof(T));
	}

	/// <summary>Sets the bit values at the specified range in a bit vector.</summary>
	/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <typeparam name="TValue">The type of the value. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <param name="bits">The bit vector.</param>
	/// <param name="startIdx">The zero-based start index of the bit range to set.</param>
	/// <param name="count">The number of sequential bits to set starting at <paramref name="startIdx"/>.</param>
	/// <param name="value">The value to set within the specified range of <paramref name="bits"/>.</param>
	public static void SetBits<T, TValue>(ref T bits, byte startIdx, byte count, TValue value) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable where TValue : struct, IComparable, IComparable<TValue>, IConvertible, IEquatable<TValue>, IFormattable
	{
		if (startIdx >= (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(startIdx));
		if (count + startIdx > (Marshal.SizeOf(typeof(T)) * 8)) throw new ArgumentOutOfRangeException(nameof(count));
		var val = value.ToInt64(null);
		if (val >= (1 << count)) throw new ArgumentOutOfRangeException(nameof(value));
		bits = (T)Convert.ChangeType(bits.ToInt64(null) & ~(((1 << count) - 1) << startIdx) | (val << startIdx), typeof(T));
	}
}