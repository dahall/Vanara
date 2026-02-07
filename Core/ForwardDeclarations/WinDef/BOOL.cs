using Vanara.Marshaler;
using Vanara.PInvoke;

namespace Vanara;

/// <summary>Managed instance of the four-byte BOOL type.</summary>
[TypeDef(typeof(uint), ConvertTo = typeof(bool), Excludes = ExcludeOptions.Numerics)]
public partial struct BOOL
{
	internal const uint True = 1U;

	internal const uint False = 0U;

	/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(int value) => new(unchecked((uint)value));

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="System.Int32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator int(BOOL value) => unchecked((int)value.value);

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(BOOL value) => (IntPtr)(int)value;

	/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(IntPtr value) => value != IntPtr.Zero;
}

/*[StructLayout(LayoutKind.Sequential), Serializable]
[TypeConverter(typeof(BOOLTypeConverter))]
public struct BOOL : IComparable, IComparable<BOOL>, IComparable<bool>, IConvertible, IEquatable<BOOL>, IEquatable<bool>
{
	private uint val;

	internal const uint True = 1U;

	internal const uint False = 0U;

	/// <summary>Initializes a new instance of the <see cref="BOOL"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOL(uint value) => val = value;

	/// <summary>Initializes a new instance of the <see cref="BOOL"/> struct.</summary>
	/// <param name="value">The value.</param>
	public BOOL(bool value) => val = value ? True : False;

	/// <summary>Gets the value.</summary>
	/// <value>The value.</value>
	public bool Value { readonly get => val != False; private set => val = value ? True : False; }

	/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(int value) => new(unchecked((uint)value));

	/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(uint value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(bool value) => new(value);

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="System.Int32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator int(BOOL value) => unchecked((int)value.val);

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="System.UInt32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator uint(BOOL value) => value.val;

	/// <summary>Performs an implicit conversion from <see cref="BOOL"/> to <see cref="System.Boolean"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator bool(BOOL value) => value.Value;

	/// <summary>Performs an explicit conversion from <see cref="BOOL"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(BOOL value) => (IntPtr)(int)value;

	/// <summary>Performs an explicit conversion from <see cref="IntPtr"/> to <see cref="BOOL"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator BOOL(IntPtr value) => value != IntPtr.Zero;

	/// <summary>Indicates whether two <see cref="BOOL"/> instances are not equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is not equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator !=(BOOL s1, BOOL s2) => !s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is less than another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <(BOOL s1, BOOL s2) => s1.CompareTo(s2) < 0;

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is less than or equal to another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is less than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator <=(BOOL s1, BOOL s2) => s1.CompareTo(s2) <= 0;

	/// <summary>Indicates whether two <see cref="BOOL"/> instances are equal.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is equal to the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator ==(BOOL s1, BOOL s2) => s1.Equals(s2);

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is greater than another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than the value of <paramref name="s2"/>; otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >(BOOL s1, BOOL s2) => s1.CompareTo(s2) > 0;

	/// <summary>Indicates whether a specified <see cref="BOOL"/> is greater than or equal to another specified <see cref="BOOL"/>.</summary>
	/// <param name="s1">The first integral size to compare.</param>
	/// <param name="s2">The second integral size to compare.</param>
	/// <returns>
	/// <see langword="true"/> if the value of <paramref name="s1"/> is greater than or equal to the value of <paramref name="s2"/>;
	/// otherwise, <see langword="false"/>.
	/// </returns>
	public static bool operator >=(BOOL s1, BOOL s2) => s1.CompareTo(s2) >= 0;

	/// <summary>Implements the operator !.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static BOOL operator !(BOOL value) => !value.Value;

#if !NETSTANDARD
	/// <summary>Implements the operator <see langword="true"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator true(BOOL value) => value.Value;

	/// <summary>Implements the operator <see langword="false"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator false(BOOL value) => !value.Value;
#endif

	/// <inheritdoc/>
	public readonly int CompareTo(BOOL other) => Value.CompareTo(other.Value);

	/// <inheritdoc/>
	public readonly int CompareTo(bool other) => Value.CompareTo(other);

	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj is BOOL s ? Equals(s) : (obj is bool b ? Value.Equals(b) : Value.Equals(obj));

	/// <inheritdoc/>
	public readonly bool Equals(BOOL other) => Value.Equals(other.Value);

	/// <inheritdoc/>
	public readonly bool Equals(bool other) => Value.Equals(other);

	/// <inheritdoc/>
	public override readonly int GetHashCode() => unchecked((int)val);

	/// <inheritdoc/>
	public readonly TypeCode GetTypeCode() => Value.GetTypeCode();

	/// <inheritdoc/>
	public override readonly string ToString() => Value.ToString();

	/// <inheritdoc/>
	public readonly string ToString(IFormatProvider? provider) => Value.ToString(provider);

	/// <inheritdoc/>
	readonly int IComparable.CompareTo(object? obj) => Value.CompareTo(Convert.ChangeType(obj, typeof(ulong)));

	/// <inheritdoc/>
	readonly bool IConvertible.ToBoolean(IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	readonly byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)Value).ToByte(provider);

	/// <inheritdoc/>
	readonly char IConvertible.ToChar(IFormatProvider? provider) => ((IConvertible)Value).ToChar(provider);

	/// <inheritdoc/>
	readonly DateTime IConvertible.ToDateTime(IFormatProvider? provider) => ((IConvertible)Value).ToDateTime(provider);

	/// <inheritdoc/>
	readonly decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)Value).ToDecimal(provider);

	/// <inheritdoc/>
	readonly double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)Value).ToDouble(provider);

	/// <inheritdoc/>
	readonly short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)Value).ToInt16(provider);

	/// <inheritdoc/>
	readonly int IConvertible.ToInt32(IFormatProvider? provider) => ((IConvertible)Value).ToInt32(provider);

	/// <inheritdoc/>
	readonly long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)Value).ToInt64(provider);

	/// <inheritdoc/>
	readonly sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)Value).ToSByte(provider);

	/// <inheritdoc/>
	readonly float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)Value).ToSingle(provider);

	/// <inheritdoc/>
	readonly object IConvertible.ToType(Type conversionType, IFormatProvider? provider) => ((IConvertible)Value).ToBoolean(provider);

	/// <inheritdoc/>
	readonly ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)Value).ToUInt16(provider);

	/// <inheritdoc/>
	readonly uint IConvertible.ToUInt32(IFormatProvider? provider) => ((IConvertible)Value).ToUInt32(provider);

	/// <inheritdoc/>
	readonly ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)Value).ToUInt64(provider);

	internal class BOOLTypeConverter : UInt32Converter
	{
		public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType) =>
			value is BOOL b ? base.ConvertTo(context, culture, b.Value, destinationType) : throw new ArgumentException(null, nameof(value));

		public override object ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
			base.CanConvertFrom(context, value.GetType()) ? new BOOL((uint)(base.ConvertFrom(context, culture, value) ?? 0)) : throw new ArgumentException(null, nameof(value));
	}
}*/