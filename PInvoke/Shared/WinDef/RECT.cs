using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

// ReSharper disable InconsistentNaming

namespace Vanara.PInvoke
{
	/// <summary>Defines the coordinates of the upper-left and lower-right corners of a rectangle.</summary>
	/// <remarks>
	/// By convention, the right and bottom edges of the rectangle are normally considered exclusive. In other words, the pixel whose coordinates are ( right,
	/// bottom ) lies immediately outside of the rectangle. For example, when RECT is passed to the FillRect function, the rectangle is filled up to, but not
	/// including, the right column and bottom row of pixels. This structure is identical to the RECT structure.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential), TypeConverter(typeof(RECTConverter))]
	public struct RECT : IEquatable<PRECT>, IEquatable<RECT>, IEquatable<Rectangle>
	{
		/// <summary>The x-coordinate of the upper-left corner of the rectangle.</summary>
		public int left;

		/// <summary>The y-coordinate of the upper-left corner of the rectangle.</summary>
		public int top;

		/// <summary>he x-coordinate of the lower-right corner of the rectangle.</summary>
		public int right;

		/// <summary>he y-coordinate of the lower-right corner of the rectangle.</summary>
		public int bottom;

		/// <summary>Initializes a new instance of the <see cref="RECT"/> struct.</summary>
		/// <param name="left">The left.</param>
		/// <param name="top">The top.</param>
		/// <param name="right">The right.</param>
		/// <param name="bottom">The bottom.</param>
		public RECT(int left, int top, int right, int bottom)
		{
			this.left = left;
			this.top = top;
			this.right = right;
			this.bottom = bottom;
		}

		/// <summary>Initializes a new instance of the <see cref="RECT"/> struct.</summary>
		/// <param name="r">The rectangle.</param>
		public RECT(Rectangle r) : this(r.Left, r.Top, r.Right, r.Bottom)
		{
		}

		/// <summary>Gets or sets the x-coordinate of the upper-left corner of this <see cref="RECT"/> structure.</summary>
		/// <value>The x-coordinate of the upper-left corner of this <see cref="RECT"/> structure. The default is 0.</value>
		public int X
		{
			get => left;
			set
			{
				right -= (left - value);
				left = value;
			}
		}

		/// <summary>Gets or sets the y-coordinate of the upper-left corner of this <see cref="RECT"/> structure.</summary>
		/// <value>The y-coordinate of the upper-left corner of this <see cref="RECT"/> structure. The default is 0.</value>
		public int Y
		{
			get => top;
			set
			{
				bottom -= (top - value);
				top = value;
			}
		}

		/// <summary>Gets or sets the height of this <see cref="RECT"/> structure.</summary>
		/// <value>The height of this <see cref="RECT"/> structure. The default is 0.</value>
		public int Height
		{
			get => bottom - top;
			set => bottom = value + top;
		}

		/// <summary>Gets or sets the width of this <see cref="RECT"/> structure.</summary>
		/// <value>The width of this <see cref="RECT"/> structure. The default is 0.</value>
		public int Width
		{
			get => right - left;
			set => right = value + left;
		}

		/// <summary>Gets or sets the coordinates of the upper-left corner of this <see cref="RECT"/> structure.</summary>
		/// <value>A Point that represents the upper-left corner of this <see cref="RECT"/> structure.</value>
		public Point Location
		{
			get => new Point(left, top);
			set
			{
				X = value.X;
				Y = value.Y;
			}
		}

		/// <summary>Gets or sets the size of this <see cref="RECT"/> structure.</summary>
		/// <value>A Size that represents the width and height of this <see cref="RECT"/> structure.</value>
		public Size Size
		{
			get => new Size(Width, Height);
			set
			{
				Width = value.Width;
				Height = value.Height;
			}
		}

		/// <summary>Tests whether all numeric properties of this <see cref="RECT"/> have values of zero.</summary>
		/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty => left == 0 && top == 0 && right == 0 && bottom == 0;

		/// <summary>Performs an implicit conversion from <see cref="RECT"/> to <see cref="Rectangle"/>.</summary>
		/// <param name="r">The <see cref="RECT"/> structure.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Rectangle(RECT r) => new Rectangle(r.left, r.top, r.Width, r.Height);

		/// <summary>Performs an implicit conversion from <see cref="Rectangle"/> to <see cref="RECT"/>.</summary>
		/// <param name="r">The Rectangle structure.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator RECT(Rectangle r) => new RECT(r);

		/// <summary>Tests whether two <see cref="RECT"/> structures have equal values.</summary>
		/// <param name="r1">The r1.</param>
		/// <param name="r2">The r2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(RECT r1, RECT r2) => r1.Equals(r2);

		/// <summary>Tests whether two <see cref="RECT"/> structures have different values.</summary>
		/// <param name="r1">The first <see cref="RECT"/> structure.</param>
		/// <param name="r2">The second <see cref="RECT"/> structure.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(RECT r1, RECT r2) => !r1.Equals(r2);

		/// <summary>Determines whether the specified <see cref="RECT"/>, is equal to this instance.</summary>
		/// <param name="r">The <see cref="RECT"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="RECT"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(RECT r) => r.left == left && r.top == top && r.right == right && r.bottom == bottom;

		/// <summary>Determines whether the specified <see cref="PRECT"/>, is equal to this instance.</summary>
		/// <param name="r">The <see cref="PRECT"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="PRECT"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(PRECT r) => (object)r != null && Equals(r.rect);

		/// <summary>Determines whether the specified <see cref="Rectangle"/>, is equal to this instance.</summary>
		/// <param name="r">The <see cref="Rectangle"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="Rectangle"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(Rectangle r) => r.Left == left && r.Top == top && r.Right == right && r.Bottom == bottom;

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case null:
					return false;
				case RECT r:
					return Equals(r);
				case PRECT r:
					return Equals(r);
				case Rectangle r:
					return Equals(r);
				default:
					return false;
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ((Rectangle)this).GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => $"{{left={left},top={top},right={right},bottom={bottom}}}";
	}

	/// <summary>Defines the coordinates of the upper-left and lower-right corners of a rectangle.</summary>
	/// <remarks>
	/// By convention, the right and bottom edges of the rectangle are normally considered exclusive. In other words, the pixel whose coordinates are ( right,
	/// bottom ) lies immediately outside of the rectangle. For example, when RECT is passed to the FillRect function, the rectangle is filled up to, but not
	/// including, the right column and bottom row of pixels. This structure is identical to the RECT structure.
	/// </remarks>
	[StructLayout(LayoutKind.Sequential), TypeConverter(typeof(PRECTConverter))]
	public class PRECT : IEquatable<PRECT>, IEquatable<RECT>, IEquatable<Rectangle>
	{
		internal RECT rect;

		/// <summary>Initializes a new instance of the <see cref="PRECT"/> class with all values set to 0.</summary>
		public PRECT()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="PRECT"/> class.</summary>
		/// <param name="left">The left.</param>
		/// <param name="top">The top.</param>
		/// <param name="right">The right.</param>
		/// <param name="bottom">The bottom.</param>
		public PRECT(int left, int top, int right, int bottom)
		{
			rect = new RECT(left, top, right, bottom);
		}

		/// <summary>Initializes a new instance of the <see cref="PRECT"/> class.</summary>
		/// <param name="r">The <see cref="Rectangle"/> structure.</param>
		public PRECT(Rectangle r)
		{
			rect = new RECT(r);
		}

		/// <summary>Initializes a new instance of the <see cref="PRECT"/> class.</summary>
		/// <param name="r">The r.</param>
		[ExcludeFromCodeCoverage]
		private PRECT(RECT r)
		{
			rect = r;
		}

		/// <summary>The x-coordinate of the upper-left corner of the rectangle.</summary>
		public int left
		{
			get => rect.left;
			set => rect.left = value;
		}

		/// <summary>The y-coordinate of the upper-left corner of the rectangle.</summary>
		public int top
		{
			get => rect.top;
			set => rect.top = value;
		}

		/// <summary>he x-coordinate of the lower-right corner of the rectangle.</summary>
		public int right
		{
			get => rect.right;
			set => rect.right = value;
		}

		/// <summary>he y-coordinate of the lower-right corner of the rectangle.</summary>
		public int bottom
		{
			get => rect.bottom;
			set => rect.bottom = value;
		}

		/// <summary>Gets or sets the x-coordinate of the upper-left corner of this <see cref="PRECT"/> structure.</summary>
		/// <value>The x-coordinate of the upper-left corner of this <see cref="PRECT"/> structure. The default is 0.</value>
		public int X
		{
			get => rect.X;
			set => rect.X = value;
		}

		/// <summary>Gets or sets the y-coordinate of the upper-left corner of this <see cref="PRECT"/> structure.</summary>
		/// <value>The y-coordinate of the upper-left corner of this <see cref="PRECT"/> structure. The default is 0.</value>
		public int Y
		{
			get => rect.Y;
			set => rect.Y = value;
		}

		/// <summary>Gets or sets the height of this <see cref="PRECT"/> structure.</summary>
		/// <value>The height of this <see cref="PRECT"/> structure. The default is 0.</value>
		public int Height
		{
			get => rect.Height;
			set => rect.Height = value;
		}

		/// <summary>Gets or sets the width of this <see cref="PRECT"/> structure.</summary>
		/// <value>The width of this <see cref="PRECT"/> structure. The default is 0.</value>
		public int Width
		{
			get => rect.Width;
			set => rect.Width = value;
		}

		/// <summary>Gets or sets the coordinates of the upper-left corner of this <see cref="PRECT"/> structure.</summary>
		/// <value>A Point that represents the upper-left corner of this <see cref="PRECT"/> structure.</value>
		public Point Location
		{
			get => rect.Location;
			set => rect.Location = value;
		}

		/// <summary>Gets or sets the size of this <see cref="PRECT"/> structure.</summary>
		/// <value>A Size that represents the width and height of this <see cref="PRECT"/> structure.</value>
		public Size Size
		{
			get => rect.Size;
			set => rect.Size = value;
		}

		/// <summary>Tests whether all numeric properties of this <see cref="RECT"/> have values of zero.</summary>
		/// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
		public bool IsEmpty => rect.IsEmpty;

		/// <summary>Performs an implicit conversion from <see cref="PRECT"/> to <see cref="Rectangle"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Rectangle(PRECT r) => r.rect;

		/// <summary>Performs an implicit conversion from <see cref="System.Nullable{Rectangle}"/> to <see cref="PRECT"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PRECT(Rectangle? r) => r.HasValue ? new PRECT(r.Value) : null;

		/// <summary>Performs an implicit conversion from <see cref="Rectangle"/> to <see cref="PRECT"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PRECT(Rectangle r) => new PRECT(r);

		/// <summary>Performs an implicit conversion from <see cref="RECT"/> to <see cref="PRECT"/>.</summary>
		/// <param name="r">The r.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator PRECT(RECT r) => new PRECT(r);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="r1">The r1.</param>
		/// <param name="r2">The r2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(PRECT r1, PRECT r2)
		{
			if (ReferenceEquals(r1, r2))
				return true;
			if ((object)r1 == null || (object)r2 == null)
				return false;
			return r1.Equals(r2);
		}

		/// <summary>Implements the operator !=.</summary>
		/// <param name="r1">The r1.</param>
		/// <param name="r2">The r2.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(PRECT r1, PRECT r2) => !(r1 == r2);

		/// <summary>Determines whether the specified <see cref="PRECT"/>, is equal to this instance.</summary>
		/// <param name="r">The <see cref="PRECT"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="PRECT"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(PRECT r) => rect == r?.rect;

		/// <summary>Determines whether the specified <see cref="RECT"/>, is equal to this instance.</summary>
		/// <param name="r">The <see cref="RECT"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="RECT"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(RECT r) => rect.Equals(r);

		/// <summary>Determines whether the specified <see cref="Rectangle"/>, is equal to this instance.</summary>
		/// <param name="r">The <see cref="Rectangle"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="Rectangle"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(Rectangle r) => rect.Equals(r);

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => rect.Equals(obj);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => rect.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => rect.ToString();
	}

	internal class RECTConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType) =>
			sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) =>
			destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (!(value is string strValue))
				return base.ConvertFrom(context, culture, value);

			var text = strValue.Trim();
			if (text.Length == 0)
				return null;

			var tokens = text.Split(culture.TextInfo.ListSeparator[0]);
			var values = new int[tokens.Length];
			var intConverter = TypeDescriptor.GetConverter(typeof(int));
			for (var i = 0; i < values.Length; i++)
				values[i] = (int)intConverter.ConvertFromString(context, culture, tokens[i]);
			if (values.Length == 4)
				return new RECT(values[0], values[1], values[2], values[3]);

			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
				throw new ArgumentNullException(nameof(destinationType));

			if (!(value is RECT rect))
				return base.ConvertTo(context, culture, value, destinationType);

			if (culture == null)
				culture = CultureInfo.CurrentCulture;

			if (destinationType == typeof(string))
				return IntConvertToString(context, culture, rect);

			if (destinationType == typeof(InstanceDescriptor))
			{
				var ctor = typeof(RECT).GetConstructor(new[] { typeof(int), typeof(int), typeof(int), typeof(int) });
				return new InstanceDescriptor(ctor, new object[] { rect.left, rect.top, rect.right, rect.bottom });
			}

			return base.ConvertTo(context, culture, value, destinationType);
		}

		protected static string IntConvertToString(ITypeDescriptorContext context, CultureInfo culture, RECT rect)
		{
			var intConverter = TypeDescriptor.GetConverter(typeof(int));
			var args = new string[4];
			var nArg = 0;

			args[nArg++] = intConverter.ConvertToString(context, culture, rect.left);
			args[nArg++] = intConverter.ConvertToString(context, culture, rect.top);
			args[nArg++] = intConverter.ConvertToString(context, culture, rect.right);
			args[nArg++] = intConverter.ConvertToString(context, culture, rect.bottom);

			return string.Join(culture.TextInfo.ListSeparator + " ", args);
		}

		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		{
			if (propertyValues == null)
				throw new ArgumentNullException(nameof(propertyValues));

			var left = propertyValues["left"] ?? 0;
			var top = propertyValues["top"] ?? 0;
			var right = propertyValues["right"] ?? 0;
			var bottom = propertyValues["bottom"] ?? 0;

			if (!(left is int) || !(top is int) || !(right is int) || !(bottom is int))
				throw new ArgumentException(@"Invalid property value.");

			return new RECT((int)left, (int)top, (int)right, (int)bottom);
		}

		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context) => true;

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			var props = TypeDescriptor.GetProperties(typeof(RECT), attributes);
			return props.Sort(new[] { "left", "top", "right", "bottom" });
		}

		public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
	}

	internal class PRECTConverter : RECTConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			var b = base.ConvertFrom(context, culture, value);
			if (b is RECT r)
				return new PRECT(r);
			return b;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			var prect = value as PRECT;
			if (destinationType == typeof(InstanceDescriptor) && prect != null)
			{
				var ctor = typeof(PRECT).GetConstructor(new[] { typeof(int), typeof(int), typeof(int), typeof(int) });
				return new InstanceDescriptor(ctor, new object[] { prect.left, prect.top, prect.right, prect.bottom });
			}

			return base.ConvertTo(context, culture, prect != null ? prect.rect : value, destinationType);
		}

		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		{
			if (propertyValues == null)
				throw new ArgumentNullException(nameof(propertyValues));

			var left = propertyValues["left"] ?? 0;
			var top = propertyValues["top"] ?? 0;
			var right = propertyValues["right"] ?? 0;
			var bottom = propertyValues["bottom"] ?? 0;

			if (!(left is int) || !(top is int) || !(right is int) || !(bottom is int))
				throw new ArgumentException(@"Invalid property value.");

			return new PRECT((int)left, (int)top, (int)right, (int)bottom);
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			var props = TypeDescriptor.GetProperties(typeof(PRECT), attributes);
			return props.Sort(new[] { "left", "top", "right", "bottom" });
		}
	}
}