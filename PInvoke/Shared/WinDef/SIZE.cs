using System.Drawing;

namespace Vanara.PInvoke;

/// <summary>The <c>SIZE</c> structure specifies the width and height of a rectangle.</summary>
/// <remarks>Initializes a new instance of the <see cref="SIZE"/> struct.</remarks>
/// <param name="width">The width.</param>
/// <param name="height">The height.</param>
// typedef struct tagSIZE { LONG cx; LONG cy;} SIZE, *PSIZE; https://msdn.microsoft.com/en-us/library/windows/desktop/dd145106(v=vs.85).aspx
[PInvokeData("Windef.h", MSDNShortId = "dd145106")]
[StructLayout(LayoutKind.Sequential), Serializable]
public struct SIZE(int width, int height) : IEquatable<SIZE>
{
	/// <summary>Specifies the rectangle's width. The units depend on which function uses this.</summary>
	public int cx = width;

	/// <summary>Specifies the rectangle's height. The units depend on which function uses this.</summary>
	public int cy = height;

	/// <summary>Specifies the rectangle's height. The units depend on which function uses this.</summary>
	public int Height { get => cy; set => cy = value; }

	/// <summary>Gets a value indicating whether this instance is empty.</summary>
	/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
	public bool IsEmpty => cx == 0 && cy == 0;

	/// <summary>Specifies the rectangle's width. The units depend on which function uses this.</summary>
	public int Width { get => cx; set => cx = value; }

	/// <summary>Tests whether two <see cref="SIZE"/> structures are equal.</summary>
	/// <param name="sz1">The <see cref="SIZE"/> structure on the left side of the equality operator.</param>
	/// <param name="sz2">The <see cref="SIZE"/> structure on the right side of the equality operator.</param>
	/// <returns><c>true</c> if <paramref name="sz1"/> and <paramref name="sz2"/> have equal width and height; otherwise, <c>false</c>.</returns>
	public static bool operator ==(SIZE sz1, SIZE sz2) => sz1.Equals(sz2);

	/// <summary>Tests whether two <see cref="SIZE"/> structures are different.</summary>
	/// <param name="sz1">The <see cref="SIZE"/> structure on the left side of the inequality operator.</param>
	/// <param name="sz2">The <see cref="SIZE"/> structure on the right side of the inequality operator.</param>
	/// <returns><c>true</c> if <paramref name="sz1"/> and <paramref name="sz2"/> differ either in width or height; otherwise, <c>false</c>.</returns>
	public static bool operator !=(SIZE sz1, SIZE sz2) => !sz1.Equals(sz2);

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(SIZE other) => cx == other.cx || cy == other.cy;

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => obj switch
	{
		SIZE sz => Equals(sz),
		Size msz => Equals((SIZE)msz),
		_ => false
	};

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => IsEmpty ? 0 : cx.GetHashCode() ^ cy.GetHashCode();

	/// <summary>Converts this structure to a <see cref="Size"/> structure.</summary>
	/// <returns>An equivalent <see cref="Size"/> structure.</returns>
	public Size ToSize() => this;

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => $"{{cx={cx}, cy={cy}}}";

	/// <summary>Performs an implicit conversion from <see cref="SIZE"/> to <see cref="Size"/>.</summary>
	/// <param name="s">The <see cref="SIZE"/>.</param>
	/// <returns>The <see cref="Size"/> result of the conversion.</returns>
	public static implicit operator Size(SIZE s) => new(s.cx, s.cy);

	/// <summary>Performs an implicit conversion from <see cref="Size"/> to <see cref="SIZE"/>.</summary>
	/// <param name="s">The <see cref="Size"/>.</param>
	/// <returns>The <see cref="SIZE"/> result of the conversion.</returns>
	public static implicit operator SIZE(Size s) => new(s.Width, s.Height);

	/// <summary>Represents a SIZE structures whose values are set to zero.</summary>
	public static readonly SIZE Empty = new();
}