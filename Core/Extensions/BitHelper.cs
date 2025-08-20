using System.Collections.Generic;

namespace Vanara.Extensions;

/// <summary>Static methods to help with bit manipulation.</summary>
/// <remarks>
/// This class is intended to support whole numbers. Without a specific constraint for numbers, the list of constraints helps to limit
/// incorrect types, but is NOT foolproof.
/// </remarks>
public static class BitHelper
{
	/// <summary>Converts a bitmask into a sequence of indices representing the positions of set bits.</summary>
	/// <typeparam name="T">The type of the bitmask. Must be an integer type.</typeparam>
	/// <param name="bitMask">The bitmask to convert. Each bit in the bitmask corresponds to a potential index in the resulting sequence.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> of <see cref="uint"/> values, where each value represents the zero-based index of a bit that is set
	/// to <see langword="true"/> in the bitmask.
	/// </returns>
	/// <remarks>
	/// This method iterates through the bits of the provided bitmask and yields the indices of all bits that are set to <see
	/// langword="true"/>. The sequence is ordered from the least significant bit (index 0) to the most significant bit.
	/// </remarks>
	public static IEnumerable<uint> BitMaskToHitList<T>(T bitMask) where T :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<T>, IConvertible
#else
		unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
#endif
	{
		var v = Convert.ToUInt64(bitMask);
		for (uint i = 0; i < UsableBits<T>(); i++)
		{
			if ((v & 0x1UL) == 1)
				yield return i;
			v >>= 1;
		}
	}

	/// <summary>Gets the bit value at the specified index in a bit vector.</summary>
	/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <param name="bits">The bit vector.</param>
	/// <param name="idx">The zero-based index of the bit to get.</param>
	/// <returns><see langword="true"/> if the bit is set (1); <see langword="false"/> otherwise.</returns>
	public static bool GetBit<T>(T bits, byte idx) where T :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<T>, IConvertible
#else
		unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
#endif
		=> (idx < Marshal.SizeOf(typeof(T)) * 8) ? (bits.ToInt64(null) & 1 << idx) != 0 : throw new ArgumentOutOfRangeException(nameof(idx));

	/// <summary>Gets the bit array value from the specified range in a bit vector.</summary>
	/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <param name="bits">The bit vector.</param>
	/// <param name="startIdx">The zero-based start index of the bit range to get.</param>
	/// <param name="count">The number of sequential bits to fetch starting at <paramref name="startIdx"/>.</param>
	/// <returns>The value of the requested bit range.</returns>
	public static T GetBits<T>(T bits, byte startIdx, byte count) where T :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<T>, IConvertible
#else
		unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
#endif
	{
		if (startIdx >= Marshal.SizeOf(typeof(T)) * 8) throw new ArgumentOutOfRangeException(nameof(startIdx));
		return count + startIdx > Marshal.SizeOf(typeof(T)) * 8
			? throw new ArgumentOutOfRangeException(nameof(count))
			: (T)Convert.ChangeType((bits.ToInt64(null) >> startIdx) & ((1 << count) - 1), typeof(T));
	}

	/// <summary>Converts a collection of hit indices into a bitmask of the specified numeric type.</summary>
	/// <typeparam name="T">The type of the bitmask. Must be an integer type.</typeparam>
	/// <remarks>
	/// The method calculates the bitmask by setting the bits at the specified indices in a zero-initialized value. The maximum number of
	/// usable bits is determined by the size of the type <typeparamref name="T"/>.
	/// </remarks>
	/// <param name="hitIndices">
	/// A collection of zero-based indices representing the positions to set in the bitmask. Each index must be less than the maximum number
	/// of usable bits for the specified type <typeparamref name="T"/>.
	/// </param>
	/// <returns>A bitmask of type <typeparamref name="T"/> where the bits at the specified indices are set to <see langword="true"/>.</returns>
	/// <exception cref="ArgumentOutOfRangeException">
	/// Thrown if any index in <paramref name="hitIndices"/> is greater than or equal to the maximum number of usable bits for the specified
	/// type <typeparamref name="T"/>.
	/// </exception>
	public static T HitListToBitMask<T>(IEnumerable<uint> hitIndices) where T :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<T>, IConvertible
#else
		unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
#endif
	{
		ulong v = 0;
		var maxBits = UsableBits<T>();
		foreach (var i in hitIndices)
		{
			if (i >= maxBits)
				throw new ArgumentOutOfRangeException(nameof(hitIndices), $"Hit index {i} exceeds maximum usable bits {maxBits} for type {typeof(T)}.");
			v |= 1UL << (int)i;
		}
		return (T)Convert.ChangeType(v, typeof(T));
	}

	/// <summary>Sets the bit value at the specified index in a bit vector.</summary>
	/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
	/// <param name="bits">The bit vector.</param>
	/// <param name="idx">The index of the bit to set.</param>
	/// <param name="value">If set to <see langword="true"/>, set the bit (= 1); otherwise, clear the bit (= 0).</param>
	public static void SetBit<T>(ref T bits, byte idx, bool value) where T :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<T>, IConvertible
#else
		unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
#endif
	{
		if (idx >= Marshal.SizeOf(typeof(T)) * 8) throw new ArgumentOutOfRangeException(nameof(idx));
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
	public static void SetBits<T, TValue>(ref T bits, byte startIdx, byte count, TValue value) where T :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<T>, IConvertible
#else
		unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
#endif
		where TValue :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<TValue>, IConvertible
#else
		unmanaged, IComparable, IComparable<TValue>, IConvertible, IEquatable<TValue>, IFormattable
#endif
	{
		if (startIdx >= Marshal.SizeOf(typeof(T)) * 8) throw new ArgumentOutOfRangeException(nameof(startIdx));
		if (count + startIdx > Marshal.SizeOf(typeof(T)) * 8) throw new ArgumentOutOfRangeException(nameof(count));
		var val = value.ToInt64(null);
		if (val >= 1 << count) throw new ArgumentOutOfRangeException(nameof(value));
		bits = (T)Convert.ChangeType(bits.ToInt64(null) & ~(((1 << count) - 1) << startIdx) | (val << startIdx), typeof(T));
	}

	/// <summary>Calculates the number of usable bits for the specified numeric type.</summary>
	/// <typeparam name="T">The type of the bitmask. Must be an integer type.</typeparam>
	/// <returns>The total number of bits available for the specified type, minus one if the type is signed.</returns>
	public static uint UsableBits<T>() where T :
#if NET7_0_OR_GREATER
		System.Numerics.IBinaryInteger<T>, IConvertible
#else
		unmanaged, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
#endif
	{
		uint bits = Convert.ToUInt32(Marshal.SizeOf<T>() * 8);
		return default(T) is byte or ushort or uint or ulong or nuint ? bits : bits - 1;
	}
}