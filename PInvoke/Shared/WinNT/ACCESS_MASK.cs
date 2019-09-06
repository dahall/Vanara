using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Access flags.</summary>
	[PInvokeData("winnt.h")]
	[StructLayout(LayoutKind.Sequential)]
	public partial struct ACCESS_MASK : IEquatable<ACCESS_MASK>
	{
		[Flags]
		private enum _ACCESS_MASK : uint
		{
			DELETE = 0x00010000,
			READ_CONTROL = 0x00020000,
			WRITE_DAC = 0x00040000,
			WRITE_OWNER = 0x00080000,
			SYNCHRONIZE = 0x00100000,
			STANDARD_RIGHTS_REQUIRED = 0x000F0000,
			STANDARD_RIGHTS_READ = 0x00020000,
			STANDARD_RIGHTS_WRITE = 0x00020000,
			STANDARD_RIGHTS_EXECUTE = 0x00020000,
			STANDARD_RIGHTS_ALL = 0x001F0000,
			SPECIFIC_RIGHTS_ALL = 0x0000FFFF,
			ACCESS_SYSTEM_SECURITY = 0x01000000,
			MAXIMUM_ALLOWED = 0x02000000,
			GENERIC_READ = 0x80000000,
			GENERIC_WRITE = 0x40000000,
			GENERIC_EXECUTE = 0x20000000,
			GENERIC_ALL = 0x10000000
		}

		/// <summary>
		/// Controls the ability to get or set the SACL in an object's security descriptor. The system grants this access right only if the
		/// SE_SECURITY_NAME privilege is enabled in the access token of the requesting thread.
		/// </summary>
		public const uint ACCESS_SYSTEM_SECURITY = (uint)_ACCESS_MASK.ACCESS_SYSTEM_SECURITY;

		/// <summary>The right to delete the object.</summary>
		public const uint DELETE = (uint)_ACCESS_MASK.DELETE;

		/// <summary>All possible access rights.</summary>
		public const uint GENERIC_ALL = (uint)_ACCESS_MASK.GENERIC_ALL;

		/// <summary>Execute access.</summary>
		public const uint GENERIC_EXECUTE = (uint)_ACCESS_MASK.GENERIC_EXECUTE;

		/// <summary>Read access.</summary>
		public const uint GENERIC_READ = (uint)_ACCESS_MASK.GENERIC_READ;

		/// <summary>Write access.</summary>
		public const uint GENERIC_WRITE = (uint)_ACCESS_MASK.GENERIC_WRITE;

		/// <summary>Request that the object be opened with all the access rights that are valid for the caller.</summary>
		public const uint MAXIMUM_ALLOWED = (uint)_ACCESS_MASK.MAXIMUM_ALLOWED;

		/// <summary>
		/// The right to read the information in the object's security descriptor, not including the information in the system access control
		/// list (SACL).
		/// </summary>
		public const uint READ_CONTROL = (uint)_ACCESS_MASK.READ_CONTROL;

		/// <summary>The specific rights all</summary>
		public const uint SPECIFIC_RIGHTS_ALL = (uint)_ACCESS_MASK.SPECIFIC_RIGHTS_ALL;

		/// <summary>Combines DELETE, READ_CONTROL, WRITE_DAC, WRITE_OWNER, and SYNCHRONIZE access.</summary>
		public const uint STANDARD_RIGHTS_ALL = (uint)_ACCESS_MASK.STANDARD_RIGHTS_ALL;

		/// <summary>Currently defined to equal READ_CONTROL.</summary>
		public const uint STANDARD_RIGHTS_EXECUTE = (uint)_ACCESS_MASK.STANDARD_RIGHTS_EXECUTE;

		/// <summary>Currently defined to equal READ_CONTROL.</summary>
		public const uint STANDARD_RIGHTS_READ = (uint)_ACCESS_MASK.STANDARD_RIGHTS_READ;

		/// <summary>Combines DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER access.</summary>
		public const uint STANDARD_RIGHTS_REQUIRED = (uint)_ACCESS_MASK.STANDARD_RIGHTS_REQUIRED;

		/// <summary>Currently defined to equal READ_CONTROL.</summary>
		public const uint STANDARD_RIGHTS_WRITE = (uint)_ACCESS_MASK.STANDARD_RIGHTS_WRITE;

		/// <summary>
		/// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state. Some
		/// object types do not support this access right.
		/// </summary>
		public const uint SYNCHRONIZE = (uint)_ACCESS_MASK.SYNCHRONIZE;

		/// <summary>The right to modify the discretionary access control list (DACL) in the object's security descriptor.</summary>
		public const uint WRITE_DAC = (uint)_ACCESS_MASK.WRITE_DAC;

		/// <summary>The right to change the owner in the object's security descriptor.</summary>
		public const uint WRITE_OWNER = (uint)_ACCESS_MASK.WRITE_OWNER;

		private readonly uint value;

		/// <summary>Initializes a new instance of the <see cref="ACCESS_MASK"/> struct.</summary>
		/// <param name="val">The value.</param>
		public ACCESS_MASK(uint val) => value = val;

		/// <summary>Initializes a new instance of the <see cref="ACCESS_MASK"/> struct.</summary>
		/// <param name="mask">The mask.</param>
		public ACCESS_MASK(IConvertible mask) : this(mask.ToUInt32(null)) { }

		/// <summary>Gets the raw value.</summary>
		/// <value>The value.</value>
		public uint Value => value;

		/// <summary>Creates an <see cref="ACCESS_MASK"/> from an enum value.</summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="enum">The enum value.</param>
		/// <returns>The converted <c>ACCESS_MASK</c> value.</returns>
		public static ACCESS_MASK FromEnum<TEnum>(TEnum @enum) where TEnum : System.Enum => new ACCESS_MASK(@enum);

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="ACCESS_MASK"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ACCESS_MASK(int value) => new ACCESS_MASK(unchecked((uint)value));

		/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="ACCESS_MASK"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator ACCESS_MASK(uint value) => new ACCESS_MASK(value);

		/// <summary>Performs an explicit conversion from <see cref="ACCESS_MASK"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator int(ACCESS_MASK value) => value.ToInt32();

		/// <summary>Performs an implicit conversion from <see cref="ACCESS_MASK"/> to <see cref="System.UInt32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator uint(ACCESS_MASK value) => value.Value;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(ACCESS_MASK left, ACCESS_MASK right) => left.value.Equals(right.value);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(ACCESS_MASK left, ACCESS_MASK right) => !left.value.Equals(right.value);

		/// <summary>Implements the operator &amp;.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static ACCESS_MASK operator &(ACCESS_MASK left, ACCESS_MASK right) => left.value & right.value;

		/// <summary>Implements the operator |.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static ACCESS_MASK operator |(ACCESS_MASK left, ACCESS_MASK right) => left.value | right.value;

		/// <summary>Implements the operator ^.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static ACCESS_MASK operator ^(ACCESS_MASK left, ACCESS_MASK right) => left.value ^ right.value;

		/// <summary>Implements the operator ~.</summary>
		/// <param name="val">The value.</param>
		/// <returns>The result of the operator.</returns>
		public static ACCESS_MASK operator ~(ACCESS_MASK val) => ~val.value;

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		/// <inheritdoc/>
		public bool Equals(ACCESS_MASK other) => value.Equals(other.value);

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is ACCESS_MASK am ? Equals(am) : base.Equals(obj);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		/// <inheritdoc/>
		public override int GetHashCode() => ToInt32();

		/// <summary>Determines whether [is flag set] [the specified mask].</summary>
		/// <param name="mask">The mask.</param>
		/// <returns><c>true</c> if [is flag set] [the specified mask]; otherwise, <c>false</c>.</returns>
		public bool IsFlagSet(ACCESS_MASK mask) => (value & (uint)mask) != 0;

		/// <summary>Converts to int32.</summary>
		/// <returns></returns>
		public int ToInt32() => unchecked((int)value);

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		/// <inheritdoc/>
		public override string ToString() => ((_ACCESS_MASK)value).ToString();

		/// <summary>Converts to uint32.</summary>
		/// <returns></returns>
		public uint ToUInt32() => value;
	}
}