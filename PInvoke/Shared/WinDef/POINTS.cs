namespace Vanara.PInvoke;

/// <summary>The POINTS structure defines the coordinates of a point.</summary>
/// <remarks>Initializes a new instance of the <see cref="POINTS"/> struct.</remarks>
/// <param name="x">The x-coordinate.</param>
/// <param name="y">The y-coordinate.</param>
[PInvokeData("windef.h")]
[StructLayout(LayoutKind.Sequential), Serializable]
public struct POINTS(short x, short y) : IEquatable<POINTS>
{
	/// <summary>The x-coordinate of the point.</summary>
	public short x = x;

	/// <summary>The y-coordinate of the point.</summary>
	public short y = y;

	/// <summary>Gets a value indicating whether this instance is empty.</summary>
	/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
	public readonly bool IsEmpty => x == 0 && y == 0;

	/// <summary>Tests whether two <see cref="POINTS"/> structures are equal.</summary>
	/// <param name="pt1">The <see cref="POINTS"/> structure on the left side of the equality operator.</param>
	/// <param name="pt2">The <see cref="POINTS"/> structure on the right side of the equality operator.</param>
	/// <returns><c>true</c> if <paramref name="pt1"/> and <paramref name="pt2"/> have equal width and height; otherwise, <c>false</c>.</returns>
	public static bool operator ==(POINTS pt1, POINTS pt2) => pt1.Equals(pt2);

	/// <summary>Tests whether two <see cref="POINTS"/> structures are different.</summary>
	/// <param name="pt1">The <see cref="POINTS"/> structure on the left side of the inequality operator.</param>
	/// <param name="pt2">The <see cref="POINTS"/> structure on the right side of the inequality operator.</param>
	/// <returns><c>true</c> if <paramref name="pt1"/> and <paramref name="pt2"/> differ either in width or height; otherwise, <c>false</c>.</returns>
	public static bool operator !=(POINTS pt1, POINTS pt2) => !pt1.Equals(pt2);

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public readonly bool Equals(POINTS other) => x == other.x || y == other.y;

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => obj switch
	{
		POINTS pt => Equals(pt),
		POINT ptl => Equals(ptl),
		_ => false,
	};

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => IsEmpty ? 0 : x.GetHashCode() ^ y.GetHashCode();

	/// <summary>Converts this structure to a <see cref="POINT"/> structure.</summary>
	/// <returns>An equivalent <see cref="POINT"/> structure.</returns>
	public readonly POINT ToPoint() => new(x, y);

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => $"{{x={x}, y={y}}}";

	/// <summary>Performs an implicit conversion from <see cref="POINTS"/> to <see cref="POINT"/>.</summary>
	/// <param name="p">The <see cref="POINTS"/>.</param>
	/// <returns>The <see cref="POINT"/> result of the conversion.</returns>
	public static implicit operator POINT(POINTS p) => p.ToPoint();

	/// <summary>Performs an implicit conversion from <see cref="POINT"/> to <see cref="POINTS"/>.</summary>
	/// <param name="p">The <see cref="POINT"/>.</param>
	/// <returns>The <see cref="POINTS"/> result of the conversion.</returns>
	public static implicit operator POINTS(POINT p) => new((short)p.X, (short)p.Y);

	/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="POINTS"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator POINTS(IntPtr p) => new(unchecked((short)(long)p), unchecked((short)((long)p >> 16)));

	/// <summary>Performs an implicit conversion from <see cref="POINTS"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="POINTS"/>.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(POINTS p) => Macros.MAKELPARAM(unchecked((ushort)p.x), unchecked((ushort)p.y));
}