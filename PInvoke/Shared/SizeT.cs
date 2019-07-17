using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Vanara.PInvoke
{
	/// <summary>Managed instance of the SIZE_T type.</summary>
	[StructLayout(LayoutKind.Sequential), Serializable]
	public struct SizeT : IEquatable<SizeT>, IComparable<SizeT>, IConvertible, IComparable
	{
		private UIntPtr val;

		/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
		/// <param name="value">The value.</param>
		public SizeT(uint value) => val = (UIntPtr)value;

		/// <summary>Initializes a new instance of the <see cref="SizeT"/> struct.</summary>
		/// <param name="value">The value.</param>
		public SizeT(ulong value) => val = new UIntPtr(value);

		/// <summary>Gets the value.</summary>
		/// <value>The value.</value>
		public ulong Value { get => val.ToUInt64(); private set => val = new UIntPtr(value); }

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(int value) => new SizeT((uint)value);

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(uint value) => new SizeT(value);

		/// <summary>Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(long value) => new SizeT((ulong)value);

		/// <summary>Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="SizeT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator SizeT(ulong value) => new SizeT(value);

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator int(SizeT value) => (int)value.Value;

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(SizeT value) => (uint)value.Value;

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.Int64"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator long(SizeT value) => (long)value.Value;

		/// <summary>Performs an implicit conversion from <see cref="SizeT"/> to <see cref="System.UInt64"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ulong(SizeT value) => value.Value;

		/// <inheritdoc/>
		public int CompareTo(SizeT other) => Value.CompareTo(other.Value);

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
		char IConvertible.ToChar(IFormatProvider provider) => ((IConvertible)Value).ToChar(provider);

		/// <inheritdoc/>
		sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)Value).ToSByte(provider);

		/// <inheritdoc/>
		byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)Value).ToByte(provider);

		/// <inheritdoc/>
		short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)Value).ToInt16(provider);

		/// <inheritdoc/>
		ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)Value).ToUInt16(provider);

		/// <inheritdoc/>
		int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)Value).ToInt32(provider);

		/// <inheritdoc/>
		uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)Value).ToUInt32(provider);

		/// <inheritdoc/>
		long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)Value).ToInt64(provider);

		/// <inheritdoc/>
		ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)Value).ToUInt64(provider);

		/// <inheritdoc/>
		float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)Value).ToSingle(provider);

		/// <inheritdoc/>
		double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)Value).ToDouble(provider);

		/// <inheritdoc/>
		decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)Value).ToDecimal(provider);

		/// <inheritdoc/>
		DateTime IConvertible.ToDateTime(IFormatProvider provider) => ((IConvertible)Value).ToDateTime(provider);

		/// <inheritdoc/>
		object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)Value).ToBoolean(provider);
	}
}