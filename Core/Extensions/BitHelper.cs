using System;

namespace Vanara.Extensions
{
	/// <summary>Static methods to help with bit manipulation.</summary>
	public static class BitHelper
	{
		/// <summary>Gets the bit value at the specified index in a bit vector.</summary>
		/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
		/// <param name="bits">The bit vector.</param>
		/// <param name="idx">The index of the bit to get.</param>
		/// <returns><see langword="true"/> if the bit is set (1); <see langword="false"/> otherwise.</returns>
		public static bool GetBit<T>(ref T bits, byte idx) where T : IConvertible => (bits.ToInt64(null) & 1 << idx) != 0;

		/// <summary>Sets the bit value at the specified index in a bit vector.</summary>
		/// <typeparam name="T">The type of the bit vector. Must be of type <see cref="IConvertible"/>.</typeparam>
		/// <param name="bits">The bit vector.</param>
		/// <param name="idx">The index of the bit to set.</param>
		/// <param name="value">If set to <see langword="true"/>, set the bit (= 1); otherwise, clear the bit (= 0).</param>
		public static void SetBit<T>(ref T bits, byte idx, bool value) where T : IConvertible
		{
			long bit = 1 << idx;
			var l = bits.ToInt64(null);
			bits = (T)(object)(value ? l | bit : l & ~bit);
		}
	}
}