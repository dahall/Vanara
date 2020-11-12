using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara
{
	/// <summary>Managed instance of the OLE CY type.</summary>
	[StructLayout(LayoutKind.Sequential), Serializable]
	[TypeConverter(typeof(CYTypeConverter))]
	public struct CY : IEquatable<CY>, IComparable<CY>, IEquatable<decimal>, IComparable<decimal>, IConvertible, IComparable
	{
		private long int64;

		/// <summary>Initializes a new instance of the <see cref="CY"/> struct.</summary>
		/// <param name="value">The value.</param>
		public CY(decimal value) : this(decimal.ToOACurrency(value)) { }

		/// <summary>Initializes a new instance of the <see cref="CY"/> struct.</summary>
		/// <param name="value">The value.</param>
		public CY(long value)
		{
			if (value > (long.MaxValue / 10000) || value < (long.MinValue / 10000))
				throw new ArgumentOutOfRangeException();
			int64 = value * 10000;
		}

		/// <summary>Gets the value.</summary>
		/// <value>The value.</value>
		public decimal Value => decimal.FromOACurrency(int64);

		/// <summary>Performs an implicit conversion from <see cref="System.Byte"/> to <see cref="CY"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator CY(decimal value) => new CY(value);

		/// <summary>Performs an explicit conversion from <see cref="CY"/> to <see cref="System.Byte"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator decimal(CY value) => value.Value;

		/// <summary>Indicates whether two <see cref="CY"/> instances are not equal.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator !=(CY s1, CY s2) => !s1.Equals(s2);

		/// <summary>Indicates whether a specified <see cref="CY"/> is less than another specified <see cref="CY"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <(CY s1, CY s2) => s1.CompareTo(s2) < 0;

		/// <summary>Indicates whether a specified <see cref="CY"/> is less than or equal to another specified <see cref="CY"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
		/// otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <=(CY s1, CY s2) => s1.CompareTo(s2) <= 0;

		/// <summary>Indicates whether two <see cref="CY"/> instances are equal.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator ==(CY s1, CY s2) => s1.Equals(s2);

		/// <summary>Indicates whether a specified <see cref="CY"/> is greater than another specified <see cref="CY"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >(CY s1, CY s2) => s1.CompareTo(s2) > 0;

		/// <summary>Indicates whether a specified <see cref="CY"/> is greater than or equal to another specified <see cref="CY"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
		/// otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >=(CY s1, CY s2) => s1.CompareTo(s2) >= 0;

		/// <inheritdoc/>
		public int CompareTo(CY other) => Value.CompareTo(other.Value);

		/// <inheritdoc/>
		public int CompareTo(decimal other) => Value.CompareTo(other);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is CY s ? Equals(s) : (obj is decimal b ? Value.Equals(b) : Value.Equals(obj));

		/// <inheritdoc/>
		public bool Equals(CY other) => Value.Equals(other.Value);

		/// <inheritdoc/>
		public bool Equals(decimal other) => Value.Equals(other);

		/// <inheritdoc/>
		public override int GetHashCode() => Value.GetHashCode();

		/// <inheritdoc/>
		public TypeCode GetTypeCode() => Value.GetTypeCode();

		/// <inheritdoc/>
		public override string ToString() => Value.ToString();

		/// <inheritdoc/>
		public string ToString(IFormatProvider provider) => Value.ToString(provider);

		/// <inheritdoc/>
		int IComparable.CompareTo(object obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(decimal)));

		/// <inheritdoc/>
		bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

		/// <inheritdoc/>
		byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

		/// <inheritdoc/>
		char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

		/// <inheritdoc/>
		DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

		/// <inheritdoc/>
		decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

		/// <inheritdoc/>
		double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)Value).ToDouble(provider);

		/// <inheritdoc/>
		short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

		/// <inheritdoc/>
		int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

		/// <inheritdoc/>
		long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

		/// <inheritdoc/>
		sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

		/// <inheritdoc/>
		float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

		/// <inheritdoc/>
		object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

		/// <inheritdoc/>
		ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

		/// <inheritdoc/>
		uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

		/// <inheritdoc/>
		ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

		internal class CYTypeConverter : DecimalConverter
		{
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (!(value is CY b)) throw new ArgumentException();
				return base.ConvertTo(context, culture, b.Value, destinationType);
			}

			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
				new CY((decimal)base.ConvertFrom(context, culture, value));
		}
	}
}