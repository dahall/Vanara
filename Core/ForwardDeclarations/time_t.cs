using System.ComponentModel;
using System.Globalization;

namespace Vanara.PInvoke;

/// <summary>Managed instance of the time_t type.</summary>
[StructLayout(LayoutKind.Sequential), Serializable]
[TypeConverter(typeof(time_tTypeConverter))]
#pragma warning disable IDE1006 // Naming Styles
public readonly struct time_t : IEquatable<time_t>, IComparable<time_t>, IEquatable<DateTime>, IComparable<DateTime>, IConvertible, IComparable
#pragma warning restore IDE1006 // Naming Styles
{
	private static readonly DateTime epoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);

	private readonly long val;

	/// <summary>Initializes a new instance of the <see cref="time_t"/> struct.</summary>
	/// <param name="ticks">
	/// The number of seconds since the start of the epoch: midnight UTC of January 1, 1970 (not counting leap seconds).
	/// </param>
	public time_t(long ticks) => val = ticks;

	/// <summary>Initializes a new instance of the <see cref="time_t"/> struct.</summary>
	/// <param name="dateTime">The date.</param>
	public time_t(DateTime dateTime) => val = (long)(dateTime.ToLocalTime() - epoch).TotalSeconds;

	/// <summary>
	/// Represents the largest possible value of <see cref="time_t"/>. This property is determined by the maximum bit-size of a pointer.
	/// </summary>
	public static readonly time_t MaxValue = (time_t)long.MaxValue;

	/// <summary>Represents the smallest possible value of <see cref="time_t"/>. This field is constant.</summary>
	public static readonly time_t MinValue = (time_t)long.MinValue;

	/// <summary>Represents the zero value of <see cref="time_t"/>. This field is constant.</summary>
	public static readonly time_t Zero = default;

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public DateTime Value => epoch.AddSeconds(val);

	/// <summary>Performs an explicit conversion from <see cref="System.Int64"/> to <see cref="time_t"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator time_t(long value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="time_t"/> to <see cref="System.Int64"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator long(time_t value) => value.val;

	/// <summary>Performs an implicit conversion from <see cref="DateTime"/> to <see cref="time_t"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The resulting <see cref="time_t"/> instance from the conversion.</returns>
	public static implicit operator time_t(DateTime value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="time_t"/> to <see cref="DateTime"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The resulting <see cref="DateTime"/> instance from the conversion.</returns>
	public static implicit operator DateTime(time_t value) => value.Value;

	/// <summary>Indicates whether two <see cref="time_t"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(time_t s1, time_t s2) => !s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="time_t"/> is less than another specified <see cref="time_t"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(time_t s1, time_t s2) => (s1.CompareTo(s2) < 0);

	/// <summary>Indicates whether a specified <see cref="time_t"/> is less than or equal to another specified <see cref="time_t"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(time_t s1, time_t s2) => (s1.CompareTo(s2) <= 0);

	/// <summary>Indicates whether two <see cref="time_t"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(time_t s1, time_t s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="time_t"/> is greater than another specified <see cref="time_t"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(time_t s1, time_t s2) => (s1.CompareTo(s2) > 0);

	/// <summary>Indicates whether a specified <see cref="time_t"/> is greater than or equal to another specified <see cref="time_t"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(time_t s1, time_t s2) => (s1.CompareTo(s2) >= 0);

	/// <inheritdoc/>
	public int CompareTo(time_t other) => val.CompareTo(other.val);

	/// <inheritdoc/>
	public int CompareTo(DateTime other) => Value.CompareTo(other);

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj is time_t s ? Equals(s) : Value.Equals(obj);

	/// <inheritdoc/>
	public bool Equals(time_t other) => val.Equals(other.val);

	/// <inheritdoc/>
	public bool Equals(DateTime other) => Value.Equals(other);

	/// <inheritdoc/>
	public override int GetHashCode() => val.GetHashCode();

	/// <inheritdoc/>
	public TypeCode GetTypeCode() => val.GetTypeCode();

	/// <inheritdoc/>
	public override string ToString() => ToString(null);

	/// <inheritdoc/>
	public string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <inheritdoc/>
	int IComparable.CompareTo(object? obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(DateTime)));

	/// <inheritdoc/>
	bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)Value).ToByte(provider);

	/// <inheritdoc/>
	char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Value;

	/// <inheritdoc/>
	decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)Value).ToDecimal(provider);

	/// <inheritdoc/>
	double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)Value).ToDouble(provider);

	/// <inheritdoc/>
	short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)Value).ToInt16(provider);

	/// <inheritdoc/>
	int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)Value).ToInt32(provider);

	/// <inheritdoc/>
	long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)Value).ToInt64(provider);

	/// <inheritdoc/>
	sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)Value).ToSByte(provider);

	/// <inheritdoc/>
	float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)Value).ToSingle(provider);

	/// <inheritdoc/>
	object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToType(conversionType, provider);

	/// <inheritdoc/>
	ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)Value).ToUInt16(provider);

	/// <inheritdoc/>
	uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)Value).ToUInt32(provider);

	/// <inheritdoc/>
	ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)Value).ToUInt64(provider);

#pragma warning disable IDE1006 // Naming Styles
	internal class time_tTypeConverter : DateTimeConverter
#pragma warning restore IDE1006 // Naming Styles
	{
		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
			value is time_t sz ? base.ConvertTo(context, culture, sz.Value, destinationType) : throw new ArgumentException();

		public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			new time_t((DateTime)base.ConvertFrom(context, culture, value)!);
	}
}