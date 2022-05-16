using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Managed instance of the SIZE_T type.</summary>
	[StructLayout(LayoutKind.Sequential), Serializable]
	[TypeConverter(typeof(SizeTTypeConverter))]
	[DebuggerDisplay("{Value}")]
	public struct SizeT : IEquatable<SizeT>, IComparable<SizeT>, IConvertible, IComparable
	{
		/// <summary>Represents the smallest possible value of <see cref="SizeT"/>. This field is constant.</summary>
		public static readonly SizeT MinValue = 0;

		/// <summary>Represents the zero value of <see cref="SizeT"/>. This field is constant.</summary>
		public static readonly SizeT Zero = default;

		private UIntPtr val;

		/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
		/// <param name="value">The value.</param>
		public SizeT(uint value) => val = (UIntPtr)value;

		/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
		/// <param name="value">The value.</param>
		public SizeT(ulong value) => val = new UIntPtr(value);

		/// <summary>
		/// Represents the largest possible value of <see cref="SizeT"/>. This property is determined by the maximum bit-size of a pointer.
		/// </summary>
		public static SizeT MaxValue => UIntPtr.Size == 8 ? ulong.MaxValue : uint.MaxValue;

		/// <summary>Gets the value.</summary>
		/// <value>The value.</value>
		public ulong Value { get => val.ToUInt64(); private set => val = new UIntPtr(value); }

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(int value) => value >= 0 ? new SizeT((uint)value) : throw new ArgumentOutOfRangeException();

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(uint value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(long value) => value >= 0 ? new SizeT((ulong)value) : throw new ArgumentOutOfRangeException();

		/// <summary>Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(ulong value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(SizeT value) => ((IConvertible)value).ToInt32(null);

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(SizeT value) => ((IConvertible)value).ToUInt32(null);

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.Int64"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator long(SizeT value) => ((IConvertible)value).ToInt64(null);

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.UInt64"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ulong(SizeT value) => value.Value;

		/// <summary>Indicates whether two <see cref="SizeT"/> instances are not equal.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator !=(SizeT s1, SizeT s2) => !s1.Equals(s2);

		/// <summary>Indicates whether a specified <see cref="SizeT"/> is less than another specified <see cref="SizeT"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <(SizeT s1, SizeT s2) => s1.CompareTo(s2) < 0;

		/// <summary>Indicates whether a specified <see cref="SizeT"/> is less than or equal to another specified <see cref="SizeT"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
		/// otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <=(SizeT s1, SizeT s2) => s1.CompareTo(s2) <= 0;

		/// <summary>Indicates whether two <see cref="SizeT"/> instances are equal.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator ==(SizeT s1, SizeT s2) => s1.Equals(s2);

		/// <summary>Indicates whether a specified <see cref="SizeT"/> is greater than another specified <see cref="SizeT"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >(SizeT s1, SizeT s2) => s1.CompareTo(s2) > 0;

		/// <summary>Indicates whether a specified <see cref="SizeT"/> is greater than or equal to another specified <see cref="SizeT"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
		/// otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >=(SizeT s1, SizeT s2) => s1.CompareTo(s2) >= 0;

		/// <summary>Adds two specified <see cref="SizeT"/> values.</summary>
		/// <param name="s1">The first value to add.</param>
		/// <param name="s2">The second value to add.</param>
		/// <returns>The result of adding <paramref name="s1"/> and <paramref name="s2"/>.</returns>
		public static SizeT operator +(SizeT s1, SizeT s2) => s1.Value + s2.Value;

		/// <summary>Divides two specified <see cref="SizeT"/> values.</summary>
		/// <param name="s1">The divident.</param>
		/// <param name="s2">The divisor.</param>
		/// <returns>The result of dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
		public static SizeT operator /(SizeT s1, SizeT s2) => s1.Value / s2.Value;

		/// <summary>Returns the remainder resulting from dividing two specified <see cref="SizeT"/> values.</summary>
		/// <param name="s1">The divident.</param>
		/// <param name="s2">The divisor.</param>
		/// <returns>The remainder resulting from dividing <paramref name="s1"/> by <paramref name="s2"/>.</returns>
		public static SizeT operator %(SizeT s1, SizeT s2) => s1.Value % s2.Value;

		/// <summary>Multiplies two specified <see cref="SizeT"/> values.</summary>
		/// <param name="s1">The first value to multiply.</param>
		/// <param name="s2">The second value to multiply.</param>
		/// <returns>The result of multiplying <paramref name="s1"/> by <paramref name="s2"/>.</returns>
		public static SizeT operator *(SizeT s1, SizeT s2) => s1.Value * s2.Value;

		/// <summary>Subtracts two specified <see cref="SizeT"/> values.</summary>
		/// <param name="s1">The minuend.</param>
		/// <param name="s2">The subtrahend.</param>
		/// <returns>The result of subtracting <paramref name="s2"/> from <paramref name="s1"/>.</returns>
		public static SizeT operator -(SizeT s1, SizeT s2) => s1.Value - s2.Value;

		/// <summary>Increments the <see cref="SizeT"/> by 1.</summary>
		/// <param name="s1">The value to increment.</param>
		/// <returns>The value of <paramref name="s1"/> incremented by 1.</returns>
		public static SizeT operator ++(SizeT s1) => s1.Value += 1;

		/// <summary>Decrements the <see cref="SizeT"/> by 1.</summary>
		/// <param name="s1">The value to decrement.</param>
		/// <returns>The value of <paramref name="s1"/> decremented by 1.</returns>
		public static SizeT operator --(SizeT s1) => s1.Value += 1;

		/// <inheritdoc/>
		public int CompareTo(SizeT other) => Value.CompareTo(other.Value);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is SizeT s ? Equals(s) : Value.Equals(obj);

		/// <inheritdoc/>
		public bool Equals(SizeT other) => Value.Equals(other.Value);

		/// <inheritdoc/>
		public override int GetHashCode() => Value.GetHashCode();

		/// <inheritdoc/>
		public TypeCode GetTypeCode() => Value.GetTypeCode();

		/// <inheritdoc/>
		public override string ToString() => Value.ToString();

		/// <inheritdoc/>
		public string ToString(IFormatProvider provider) => Value.ToString(provider);

		/// <inheritdoc/>
		int IComparable.CompareTo(object obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(ulong)));

		/// <inheritdoc/>
		bool IConvertible.ToBoolean(IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);

		/// <inheritdoc/>
		byte IConvertible.ToByte(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < (ulong)byte.MaxValue)
				return (byte)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return byte.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

		/// <inheritdoc/>
		DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

		/// <inheritdoc/>
		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < decimal.MaxValue)
				return (decimal)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return decimal.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		double IConvertible.ToDouble(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < double.MaxValue)
				return ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return double.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		short IConvertible.ToInt16(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < (ulong)short.MaxValue)
				return (short)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return short.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		int IConvertible.ToInt32(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < int.MaxValue)
				return (int)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return int.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		long IConvertible.ToInt64(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < long.MaxValue)
				return (long)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return long.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < (ulong)sbyte.MaxValue)
				return (sbyte)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return sbyte.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		float IConvertible.ToSingle(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < float.MaxValue)
				return ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return float.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToType(conversionType, provider);

		/// <inheritdoc/>
		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < (ulong)ushort.MaxValue)
				return (ushort)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return ushort.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			var ul = Value;
			if (ul < uint.MaxValue)
				return (uint)ul;
			if (ul is uint.MaxValue or ulong.MaxValue)
				return uint.MaxValue;
			throw new OverflowException();
		}

		/// <inheritdoc/>
		ulong IConvertible.ToUInt64(IFormatProvider provider) => Value;

		internal class SizeTTypeConverter : UInt64Converter
		{
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (value is not SizeT sz) throw new ArgumentException();
				return base.ConvertTo(context, culture, sz.Value, destinationType);
			}

			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
				new SizeT((ulong)base.ConvertFrom(context, culture, value));
		}
	}
}