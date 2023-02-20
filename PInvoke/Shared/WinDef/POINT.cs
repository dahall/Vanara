using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

/// <summary>The POINT structure defines the x- and y-coordinates of a point.</summary>
// https://docs.microsoft.com/en-us/windows/win32/api/windef/ns-windef-point
[PInvokeData("windef.h", MSDNShortId = "NS:windef.tagPOINT")]
[TypeConverter(typeof(POINTConverter))]
[StructLayout(LayoutKind.Sequential), Serializable]
[ComVisible(true)]
public struct POINT : IEquatable<POINT>
{
	/// <summary>Represents a POINT that has X and Y values set to zero.</summary>
	public static readonly POINT Empty = new();

	/// <summary>Specifies the <c>x</c>-coordinate of the point.</summary>
	public int X;

	/// <summary>Specifies the <c>y</c>-coordinate of the point.</summary>
	public int Y;

	/// <summary>Initializes a new instance of the <see cref="POINT"/> struct with the specified coordinates.</summary>
	/// <param name="X">The horizontal position of the point.</param>
	/// <param name="Y">The vertical position of the point.</param>
	public POINT(int X, int Y)
	{
		this.X = X;
		this.Y = Y;
	}

	/// <summary>Initializes a new instance of the <see cref="POINT"/> struct from a <see cref="SIZE"/>.</summary>
	/// <param name="sz">A <see cref="SIZE"/> that specifies the coordinates for the new <see cref="POINT"/>.</param>
	public POINT(SIZE sz)
	{
		X = sz.cx;
		Y = sz.cy;
	}

	/// <summary>Initializes a new instance of the <see cref="POINT"/> struct using coordinates specified by an integer value.</summary>
	/// <param name="dw">A 32-bit integer that specifies the coordinates for the new <see cref="POINT"/>.</param>
	public POINT(int dw)
	{
		unchecked
		{
			X = (short)Macros.LOWORD((uint)dw);
			Y = (short)Macros.HIWORD((uint)dw);
		}
	}

	/// <summary>Specifies the <c>x</c>-coordinate of the point.</summary>
	public int x { get => X; set => X = value; }

	/// <summary>Specifies the <c>y</c>-coordinate of the point.</summary>
	public int y { get => Y; set => Y = value; }

	/// <summary>Gets a value indicating whether this <see cref="POINT"/> is empty.</summary>
	/// <value><see langword="true"/> if both X and Y are 0; otherwise, <see langword="false"/>.</value>
	[Browsable(false)]
	public bool IsEmpty => X == 0 && Y == 0;

	/// <summary>Adds the specified <see cref="SIZE"/> to the specified <see cref="POINT"/>.</summary>
	/// <param name="pt">The <see cref="POINT"/> to add.</param>
	/// <param name="sz">The <see cref="SIZE"/> to add.</param>
	/// <returns>The <see cref="POINT"/> that is the result of the addition operation.</returns>
	public static POINT Add(POINT pt, SIZE sz) => new(pt.X + sz.cx, pt.Y + sz.cy);

	/// <summary>Performs an explicit conversion from <see cref="POINT"/> to <see cref="SIZE"/>.</summary>
	/// <param name="p">The <see cref="POINT"/> to be converted.</param>
	/// <returns>The <see cref="SIZE"/> that results from the conversion.</returns>
	public static explicit operator SIZE(POINT p) => new(p.X, p.Y);

	/// <summary>Performs an implicit conversion from <see cref="POINT"/> to <see cref="Point"/>.</summary>
	/// <param name="p">The <see cref="POINT"/>.</param>
	/// <returns>The <see cref="Point"/> result of the conversion.</returns>
	public static implicit operator Point(POINT p) => new(p.X, p.Y);

	/// <summary>Performs an implicit conversion from <see cref="Point"/> to <see cref="POINT"/>.</summary>
	/// <param name="p">The <see cref="Point"/>.</param>
	/// <returns>The <see cref="POINT"/> result of the conversion.</returns>
	public static implicit operator POINT(Point p) => new(p.X, p.Y);

	/// <summary>Translates a <see cref="POINT"/> by the negative of a given <see cref="SIZE"/>.</summary>
	/// <param name="pt">The <see cref="POINT"/> to translate.</param>
	/// <param name="sz">A <see cref="SIZE"/> that specifies the pair of numbers to subtract from the coordinates of pt.</param>
	/// <returns>A <see cref="POINT"/> structure that is translated by the negative of a given <see cref="SIZE"/> structure.</returns>
	public static POINT operator -(POINT pt, SIZE sz) => Subtract(pt, sz);

	/// <summary>
	/// Compares two <see cref="POINT"/> objects. The result specifies whether the values of the X or Y properties of the two <see
	/// cref="POINT"/> objects are unequal.
	/// </summary>
	/// <param name="left">A <see cref="POINT"/> to compare.</param>
	/// <param name="right">A <see cref="POINT"/> to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the values of either the X properties or the Y properties of left and right differ; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(POINT left, POINT right) => !(left == right);

	/// <summary>Translates a <see cref="POINT"/> by a given <see cref="SIZE"/>.</summary>
	/// <param name="pt">The <see cref="POINT"/> to translate.</param>
	/// <param name="sz">A <see cref="SIZE"/> that specifies the pair of numbers to add to the coordinates of pt.</param>
	/// <returns>The translated <see cref="POINT"/>.</returns>
	public static POINT operator +(POINT pt, SIZE sz) => Add(pt, sz);

	/// <summary>
	/// Compares two <see cref="POINT"/> objects. The result specifies whether the values of the X and Y properties of the two <see
	/// cref="POINT"/> objects are equal.
	/// </summary>
	/// <param name="left">A <see cref="POINT"/> to compare.</param>
	/// <param name="right">A <see cref="POINT"/> to compare.</param>
	/// <returns><see langword="true"/> if the X and Y values of left and right are equal; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(POINT left, POINT right) => left.X == right.X && left.Y == right.Y;

	/// <summary>Returns the result of subtracting specified <see cref="SIZE"/> from the specified <see cref="POINT"/>.</summary>
	/// <param name="pt">The <see cref="POINT"/> to be subtracted from.</param>
	/// <param name="sz">The <see cref="SIZE"/> to subtract from the <see cref="POINT"/>.</param>
	/// <returns>The <see cref="POINT"/> that is the result of the subtraction operation.</returns>
	public static POINT Subtract(POINT pt, SIZE sz) => new(pt.X - sz.cx, pt.Y - sz.cy);

	/// <summary>Specifies whether this point instance contains the same coordinates as another point.</summary>
	/// <param name="other">The point to test for equality.</param>
	/// <returns><see langword="true"/> if <paramref name="other"/> has the same coordinates as this point instance.</returns>
	public bool Equals(POINT other) => other.X == X && other.Y == Y;

	/// <summary>Specifies whether this point instance contains the same coordinates as the specified object.</summary>
	/// <param name="obj">The <see cref="System.Object"/> to test for equality.</param>
	/// <returns>
	/// <see langword="true"/> if <paramref name="obj"/> is a <see cref="POINT"/> and has the same coordinates as this point instance.
	/// </returns>
	public override bool Equals(object? obj) => obj switch
	{
		POINT p => Equals(p),
		Point p => Equals((POINT)p),
		_ => false
	};

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => unchecked(X ^ Y);

	/// <summary>Translates the <see cref="POINT"/> by the specified amount.</summary>
	/// <param name="dx">The amount to offset the x-coordinate.</param>
	/// <param name="dy">The amount to offset the y-coordinate.</param>
	public void Offset(int dx, int dy)
	{
		X += dx;
		Y += dy;
	}

	/// <summary>Translates the <see cref="POINT"/> by the specified <see cref="POINT"/>.</summary>
	/// <param name="p">The <see cref="POINT"/> used offset this <see cref="POINT"/>.</param>
	public void Offset(POINT p) => Offset(p.X, p.Y);

	/// <summary>Converts this <see cref="POINT"/> to a human-readable string.</summary>
	/// <returns>A <see cref="System.String"/> that represents this <see cref="POINT"/>.</returns>
	public override string ToString() => $"{{X={X},Y={Y}}}";
}

internal class POINTConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
		sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) =>
		destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value is string strValue)
		{
			string text = strValue.Trim();
			if (text.Length == 0)
				return null;

			culture ??= CultureInfo.CurrentCulture;
			string[] tokens = text.Split(culture.TextInfo.ListSeparator[0]);
			if (tokens.Length == 2)
			{
				TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
				int[] values = Array.ConvertAll(tokens, i => (int)intConverter.ConvertFromString(context, culture, i)!);
				return new POINT(values[0], values[1]);
			}
		}

		return base.ConvertFrom(context, culture, value);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		if (destinationType is null) throw new ArgumentNullException(nameof(destinationType));

		if (value is POINT pt)
		{
			if (destinationType == typeof(string))
			{
				culture ??= CultureInfo.CurrentCulture;
				string sep = culture.TextInfo.ListSeparator + " ";
				TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));
				return string.Concat(intConverter.ConvertToString(context, culture, pt.X), sep, intConverter.ConvertToString(context, culture, pt.Y));
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				ConstructorInfo? ctor = typeof(POINT).GetConstructor(new[] { typeof(int), typeof(int) });
				if (ctor is not null)
				{
					return new InstanceDescriptor(ctor, new[] { pt.X, pt.Y });
				}
			}
		}

		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object CreateInstance(ITypeDescriptorContext? context, IDictionary propertyValues)
	{
		if (propertyValues is null) throw new ArgumentNullException(nameof(propertyValues));

		object? x = propertyValues["X"] ?? propertyValues["x"];
		object? y = propertyValues["Y"] ?? propertyValues["y"];

		return x is int ix && y is int iy ? new POINT(ix, iy) : throw new ArgumentException("Invalid property values.", nameof(propertyValues));
	}

	public override bool GetCreateInstanceSupported(ITypeDescriptorContext? context) => true;

#if NET6_0_OR_GREATER
	[RequiresUnreferencedCode("")]
#endif
	public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext? context, object value, Attribute[]? attributes)
	{
		PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(POINT), attributes);
		return props.Sort(new[] { "X", "Y" });
	}

	public override bool GetPropertiesSupported(ITypeDescriptorContext? context) => true;
}