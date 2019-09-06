using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>
	/// An LCID is a 4-byte value. The value supplied in an LCID is a standard numeric substitution for the international [RFC5646] string.
	/// </summary>
	/// <seealso cref="System.IComparable"/>
	/// <seealso cref="System.IComparable{LCID}"/>
	/// <seealso cref="System.IEquatable{LCID}"/>
	[StructLayout(LayoutKind.Sequential)]
	[TypeConverter(typeof(NTStatusTypeConverter))]
	[PInvokeData("winnls.h")]
	public partial struct LCID : IComparable, IComparable<LCID>, IEquatable<LCID>
	{
		internal readonly uint _value;

		private const int langMask = 0x0FFFF;
		private const uint sortMask = 0xF0000;
		private const int sortShift = 16;

		/// <summary>Initializes a new instance of the <see cref="NTStatus"/> structure.</summary>
		/// <param name="rawValue">The raw NTStatus value.</param>
		public LCID(uint rawValue) => _value = rawValue;

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following
		/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal
		/// to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		public int CompareTo(LCID other) => _value.CompareTo(other._value);

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current
		/// instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less
		/// than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the
		/// sort order as <paramref name="obj"/> . Greater than zero This instance follows <paramref name="obj"/> in the sort order.
		/// </returns>
		public int CompareTo(object obj)
		{
			if (!(obj is IConvertible c)) throw new ArgumentException(@"Object cannot be converted to a UInt32 value for comparison.", nameof(obj));
			return _value.CompareTo(c.ToUInt32(null));
		}

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj is IConvertible c ? _value.Equals(c.ToUInt32(null)) : false;

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(LCID other) => other._value == _value;

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => _value.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => string.Format(CultureInfo.InvariantCulture, "0x{0:X8}", _value);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
		/// <param name="hrRight">The second <see cref="LCID"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(LCID hrLeft, LCID hrRight) => hrLeft._value == hrRight._value;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
		/// <param name="hrRight">The second <see cref="uint"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(LCID hrLeft, uint hrRight) => hrLeft._value == hrRight;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
		/// <param name="hrRight">The second <see cref="LCID"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(LCID hrLeft, LCID hrRight) => !(hrLeft == hrRight);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="LCID"/>.</param>
		/// <param name="hrRight">The second <see cref="uint"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(LCID hrLeft, uint hrRight) => !(hrLeft == hrRight);

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="LCID"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator LCID(uint value) => new LCID(value);

		/// <summary>Performs an explicit conversion from <see cref="LCID"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator uint(LCID value) => value._value;
	}
}