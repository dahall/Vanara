using System;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.Extensions
{
	/// <summary>Extensions for <see cref="FILETIME"/>.</summary>
	public static class FileTimeExtensions
	{
		/// <summary>Compares two instances of <see cref="FILETIME"/> and returns an integer that indicates whether the first instance is earlier than, the same as, or later than the second instance.</summary>
		/// <param name="ft">The first object to compare. </param>
		/// <param name="other">The second object to compare. </param>
		/// <returns>A signed number indicating the relative values of t1 and t2.
		/// <list type="table">
		/// <listheader><term>Value Type</term><term>Condition</term></listheader>
		/// <item><term>Less than zero</term><term>t1 is earlier than t2.</term></item>
		/// <item><term>Zero</term><term>t1 is the same as t2.</term></item>
		/// <item><term>Greater than zero</term><term>t1 is later than t2.</term></item>
		/// </list>
		///</returns>
		public static int CompareTo(this FILETIME ft, FILETIME other)
		{
			var a = ft.ToUInt64();
			var b = other.ToUInt64();
			return a > b ? 1 : (a < b ? -1 : 0);
		}

		/// <summary>Compares two <see cref="FILETIME"/> structures for equality.</summary>
		/// <param name="ft1">The first <see cref="FILETIME"/> value.</param>
		/// <param name="ft2">The second <see cref="FILETIME"/> value.</param>
		/// <returns>true if the current object is equal to the <paramref name="ft2"/> parameter; otherwise, false.</returns>
		public static bool Equals(FILETIME ft1, FILETIME ft2) => ft1.dwHighDateTime == ft2.dwHighDateTime && ft1.dwLowDateTime == ft2.dwLowDateTime;

		/// <summary>Creates a <see cref="FILETIME"/> from a 64-bit value.</summary>
		/// <param name="ul">The value to be converted.</param>
		/// <returns>The return value is a <see cref="FILETIME"/> created from the supplied 64-bit value.</returns>
		public static FILETIME MakeFILETIME(ulong ul) => new FILETIME
		{
			dwHighDateTime = (int)(ul >> 32),
			dwLowDateTime = (int)(ul & 0xFFFFFFFF)
		};

		/// <summary>Converts a <see cref="FILETIME"/> structure to a <see cref="DateTime"/> structure.</summary>
		/// <param name="ft">The <see cref="FILETIME"/> value to convert.</param>
		/// <param name="kind">The <see cref="DateTimeKind"/> value to use to determine local or UTC time.</param>
		/// <returns>The resulting <see cref="DateTime"/> structure.</returns>
		public static DateTime ToDateTime(this FILETIME ft, DateTimeKind kind = DateTimeKind.Local)
		{
			unchecked
			{
				var hFT2 = ((long)ft.dwHighDateTime << 32) | (uint)ft.dwLowDateTime;
				return kind == DateTimeKind.Utc ? DateTime.FromFileTimeUtc(hFT2) : DateTime.FromFileTime(hFT2);
			}
		}

		/// <summary>Converts a <see cref="DateTime"/> structure to a <see cref="FILETIME"/> structure using the local time.</summary>
		/// <param name="dt">The <see cref="DateTime"/> value to convert.</param>
		/// <returns>The resulting <see cref="FILETIME"/> structure as the local time.</returns>
		public static FILETIME ToFileTimeStruct(this DateTime dt)
		{
			if (dt.Kind == DateTimeKind.Utc) dt = dt.ToLocalTime();
			var l = dt.ToFileTime();
			return new FILETIME
			{
				dwHighDateTime = (int)(l >> 32),
				dwLowDateTime = (int)(l & 0xFFFFFFFF)
			};
		}

		/// <summary>Returns a <see cref="string"/> that represents the <see cref="FILETIME"/> instance.</summary>
		/// <param name="ft">The <see cref="FILETIME"/> to convert.</param>
		/// <param name="format">A standard or custom date and time format string. See notes for <a href="https://msdn.microsoft.com/en-us/library/8tfzyc64(v=vs.110).aspx">DateTime.ToString()</a>.</param>
		/// <param name="provider">An object that supplies culture-specific formatting information.</param>
		/// <returns>
		/// A string representation of value of the current <see cref="FILETIME"/> object as specified by <paramref name="format"/> and <paramref name="provider"/>.
		/// </returns>
		public static string ToString(this FILETIME ft, string format, IFormatProvider provider = null) => ft.ToDateTime().ToString(format, provider);

		/// <summary>Converts a <see cref="FILETIME"/> structure to its 64-bit representation.</summary>
		/// <param name="ft">The value to be converted.</param>
		/// <returns>The return value is a 64-bit value that represented the <see cref="FILETIME"/>.</returns>
		public static ulong ToUInt64(this FILETIME ft) => ((ulong)ft.dwHighDateTime << 32) | (uint)ft.dwLowDateTime;
	}
}