using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Managed instance of the SIZE_T type.</summary>
	[StructLayout(LayoutKind.Sequential), Serializable]
	[TypeConverter(typeof(SizeTTypeConverter))]
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
		public static implicit operator SizeT(uint value) => new SizeT(value);

		/// <summary>Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(long value) => value >= 0 ? new SizeT((ulong)value) : throw new ArgumentOutOfRangeException();

		/// <summary>Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(ulong value) => new SizeT(value);

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(SizeT value) => (int)value.val.ToUInt32();

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(SizeT value) => value.val.ToUInt32();

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.Int64"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator long(SizeT value) => (long)value.Value;

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
		public static bool operator <(SizeT s1, SizeT s2) => (s1.CompareTo(s2) < 0) ? true : false;

		/// <summary>Indicates whether a specified <see cref="SizeT"/> is less than or equal to another specified <see cref="SizeT"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
		/// otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator <=(SizeT s1, SizeT s2) => (s1.CompareTo(s2) <= 0) ? true : false;

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
		public static bool operator >(SizeT s1, SizeT s2) => (s1.CompareTo(s2) > 0) ? true : false;

		/// <summary>Indicates whether a specified <see cref="SizeT"/> is greater than or equal to another specified <see cref="SizeT"/>.</summary>
		/// <param name="s1">The first integral size to compare.</param>
		/// <param name="s2">The second integral size to compare.</param>
		/// <returns>
		/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
		/// otherwise, <see langword="false"/>.
		/// </returns>
		public static bool operator >=(SizeT s1, SizeT s2) => (s1.CompareTo(s2) >= 0) ? true : false;

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

		internal class SizeTTypeConverter : UInt64Converter
		{
			public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
			{
				if (!(value is SizeT sz)) throw new ArgumentException();
				return base.ConvertTo(context, culture, sz.Value, destinationType);
			}

			public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value) =>
				new SizeT((ulong)base.ConvertFrom(context, culture, value));
		}
	}
}