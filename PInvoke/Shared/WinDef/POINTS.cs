using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>The POINTS structure defines the coordinates of a point.</summary>
	[StructLayout(LayoutKind.Sequential), Serializable]
	public struct POINTS : IEquatable<POINTS>
	{
		/// <summary>The x-coordinate of the point.</summary>
		public short x;

		/// <summary>The y-coordinate of the point.</summary>
		public short y;

		/// <summary>Initializes a new instance of the <see cref="POINTS"/> struct.</summary>
		/// <param name="width">The x-coordinate.</param>
		/// <param name="height">The y-coordinate.</param>
		public POINTS(short width, short height)
		{
			x = width;
			y = height;
		}

		/// <summary>Gets a value indicating whether this instance is empty.</summary>
		/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty => x == 0 && y == 0;

		/// <summary>Tests whether two <see cref="POINTS"/> structures are equal.</summary>
		/// <param name="pt1">The <see cref="POINTS"/> structure on the left side of the equality operator.</param>
		/// <param name="pt2">The <see cref="POINTS"/> structure on the right side of the equality operator.</param>
		/// <returns><c>true</c> if <paramref name="pt1"/> and <paramref name="pt2"/> have equal width and height; otherwise, <c>false</c>.</returns>
		public static bool operator ==(POINTS pt1, POINTS pt2) => pt1.x == pt2.x && pt1.y == pt2.y;

		/// <summary>Tests whether two <see cref="POINTS"/> structures are different.</summary>
		/// <param name="pt1">The <see cref="POINTS"/> structure on the left side of the inequality operator.</param>
		/// <param name="pt2">The <see cref="POINTS"/> structure on the right side of the inequality operator.</param>
		/// <returns><c>true</c> if <paramref name="pt1"/> and <paramref name="pt2"/> differ either in width or height; otherwise, <c>false</c>.</returns>
		public static bool operator !=(POINTS pt1, POINTS pt2) => !(pt1 == pt2);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(POINTS other) => x == other.x || y == other.y;

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case POINTS pt:
					return Equals(pt);

				case Point ptl:
					return Equals(ptl);

				default:
					return false;
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => IsEmpty ? 0 : x.GetHashCode() ^ y.GetHashCode();

		/// <summary>Converts this structure to a <see cref="Point"/> structure.</summary>
		/// <returns>An equivalent <see cref="Point"/> structure.</returns>
		public Point ToPoint() => this;

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => "{x=" + x.ToString(CultureInfo.CurrentCulture) + ", y=" + y.ToString(CultureInfo.CurrentCulture) + "}";

		/// <summary>Performs an implicit conversion from <see cref="POINTS"/> to <see cref="Point"/>.</summary>
		/// <param name="p">The <see cref="POINTS"/>.</param>
		/// <returns>The <see cref="Point"/> result of the conversion.</returns>
		public static implicit operator Point(POINTS p) => new Point(p.x, p.y);

		/// <summary>Performs an implicit conversion from <see cref="Point"/> to <see cref="POINTS"/>.</summary>
		/// <param name="p">The <see cref="Point"/>.</param>
		/// <returns>The <see cref="POINTS"/> result of the conversion.</returns>
		public static implicit operator POINTS(Point p) => new POINTS((short)p.X, (short)p.Y);
	}
}