using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Formal replacement for the Windows NTStatus definition. In ntstatus.h, it is a defined UINT value. For .NET, this class strongly
	/// types the value.
	/// <para>The 32-bit value is organized as follows:</para>
	/// <list type="table">
	/// <item>
	/// <term>Bit</term>
	/// <description>0 - 1</description>
	/// <description>2</description>
	/// <description>3</description>
	/// <description>4 - 15</description>
	/// <description>16 - 31</description>
	/// </item>
	/// <item>
	/// <term>Field</term>
	/// <description>Sev</description>
	/// <description>Customer</description>
	/// <description>Reserved</description>
	/// <description>Facility</description>
	/// <description>Code</description>
	/// </item>
	/// </list>
	/// </summary>
	/// <seealso cref="System.IComparable"/>
	/// <seealso cref="System.IComparable{NTStatus}"/>
	/// <seealso cref="System.IEquatable{NTStatus}"/>
	[StructLayout(LayoutKind.Sequential)]
	[TypeConverter(typeof(NTStatusTypeConverter))]
	[PInvokeData("winerr.h")]
	public partial struct NTStatus : IComparable, IComparable<NTStatus>, IEquatable<NTStatus>, IConvertible, IErrorProvider
	{
		internal readonly int _value;

		private const int codeMask = 0xFFFF;
		private const uint customerMask = 0x20000000;
		private const int FACILITY_NT_BIT = 0x10000000;
		private const uint facilityMask = 0x0FFF0000;
		private const int facilityShift = 16;
		private const uint severityMask = 0xC0000000;
		private const int severityShift = 30;

		/// <summary>Initializes a new instance of the <see cref="NTStatus"/> structure.</summary>
		/// <param name="rawValue">The raw NTStatus value.</param>
		public NTStatus(int rawValue) => _value = rawValue;

		/// <summary>Enumeration of facility codes</summary>
		[PInvokeData("winerr.h")]
		public enum FacilityCode : ushort
		{
			/// <summary>The default facility code.</summary>
			FACILITY_NULL = 0,

			/// <summary>The facility debugger</summary>
			FACILITY_DEBUGGER = 0x1,

			/// <summary>The facility RPC runtime</summary>
			FACILITY_RPC_RUNTIME = 0x2,

			/// <summary>The facility RPC stubs</summary>
			FACILITY_RPC_STUBS = 0x3,

			/// <summary>The facility io error code</summary>
			FACILITY_IO_ERROR_CODE = 0x4,

			/// <summary>The facility codclass error code</summary>
			FACILITY_CODCLASS_ERROR_CODE = 0x6,

			/// <summary>The facility ntwi N32</summary>
			FACILITY_NTWIN32 = 0x7,

			/// <summary>The facility ntcert</summary>
			FACILITY_NTCERT = 0x8,

			/// <summary>The facility ntsspi</summary>
			FACILITY_NTSSPI = 0x9,

			/// <summary>The facility terminal server</summary>
			FACILITY_TERMINAL_SERVER = 0xA,

			/// <summary>The faciltiy MUI error code</summary>
			FACILTIY_MUI_ERROR_CODE = 0xB,

			/// <summary>The facility usb error code</summary>
			FACILITY_USB_ERROR_CODE = 0x10,

			/// <summary>The facility hid error code</summary>
			FACILITY_HID_ERROR_CODE = 0x11,

			/// <summary>The facility firewire error code</summary>
			FACILITY_FIREWIRE_ERROR_CODE = 0x12,

			/// <summary>The facility cluster error code</summary>
			FACILITY_CLUSTER_ERROR_CODE = 0x13,

			/// <summary>The facility acpi error code</summary>
			FACILITY_ACPI_ERROR_CODE = 0x14,

			/// <summary>The facility SXS error code</summary>
			FACILITY_SXS_ERROR_CODE = 0x15,

			/// <summary>The facility transaction</summary>
			FACILITY_TRANSACTION = 0x19,

			/// <summary>The facility commonlog</summary>
			FACILITY_COMMONLOG = 0x1A,

			/// <summary>The facility video</summary>
			FACILITY_VIDEO = 0x1B,

			/// <summary>The facility filter manager</summary>
			FACILITY_FILTER_MANAGER = 0x1C,

			/// <summary>The facility monitor</summary>
			FACILITY_MONITOR = 0x1D,

			/// <summary>The facility graphics kernel</summary>
			FACILITY_GRAPHICS_KERNEL = 0x1E,

			/// <summary>The facility driver framework</summary>
			FACILITY_DRIVER_FRAMEWORK = 0x20,

			/// <summary>The facility fve error code</summary>
			FACILITY_FVE_ERROR_CODE = 0x21,

			/// <summary>The facility FWP error code</summary>
			FACILITY_FWP_ERROR_CODE = 0x22,

			/// <summary>The facility ndis error code</summary>
			FACILITY_NDIS_ERROR_CODE = 0x23,

			/// <summary>The facility TPM</summary>
			FACILITY_TPM = 0x29,

			/// <summary>The facility RTPM</summary>
			FACILITY_RTPM = 0x2A,

			/// <summary>The facility hypervisor</summary>
			FACILITY_HYPERVISOR = 0x35,

			/// <summary>The facility ipsec</summary>
			FACILITY_IPSEC = 0x36,

			/// <summary>The facility virtualization</summary>
			FACILITY_VIRTUALIZATION = 0x37,

			/// <summary>The facility volmgr</summary>
			FACILITY_VOLMGR = 0x38,

			/// <summary>The facility BCD error code</summary>
			FACILITY_BCD_ERROR_CODE = 0x39,

			/// <summary>The facility wi N32 k ntuser</summary>
			FACILITY_WIN32K_NTUSER = 0x3E,

			/// <summary>The facility wi N32 k ntgdi</summary>
			FACILITY_WIN32K_NTGDI = 0x3F,

			/// <summary>The facility resume key filter</summary>
			FACILITY_RESUME_KEY_FILTER = 0x40,

			/// <summary>The facility RDBSS</summary>
			FACILITY_RDBSS = 0x41,

			/// <summary>The facility BTH att</summary>
			FACILITY_BTH_ATT = 0x42,

			/// <summary>The facility secureboot</summary>
			FACILITY_SECUREBOOT = 0x43,

			/// <summary>The facility audio kernel</summary>
			FACILITY_AUDIO_KERNEL = 0x44,

			/// <summary>The facility VSM</summary>
			FACILITY_VSM = 0x45,

			/// <summary>The facility volsnap</summary>
			FACILITY_VOLSNAP = 0x50,

			/// <summary>The facility sdbus</summary>
			FACILITY_SDBUS = 0x51,

			/// <summary>The facility shared VHDX</summary>
			FACILITY_SHARED_VHDX = 0x5C,

			/// <summary>The facility SMB</summary>
			FACILITY_SMB = 0x5D,

			/// <summary>The facility interix</summary>
			FACILITY_INTERIX = 0x99,

			/// <summary>The facility spaces</summary>
			FACILITY_SPACES = 0xE7,

			/// <summary>The facility security core</summary>
			FACILITY_SECURITY_CORE = 0xE8,

			/// <summary>The facility system integrity</summary>
			FACILITY_SYSTEM_INTEGRITY = 0xE9,

			/// <summary>The facility licensing</summary>
			FACILITY_LICENSING = 0xEA,

			/// <summary>The facility platform manifest</summary>
			FACILITY_PLATFORM_MANIFEST = 0xEB,

			/// <summary>The facility maximum value</summary>
			FACILITY_MAXIMUM_VALUE = 0xEC
		}

		/// <summary>A value indicating the severity of an <see cref="NTStatus"/> value (bits 30-31).</summary>
		[PInvokeData("winerr.h")]
		public enum SeverityLevel : byte
		{
			/// <summary>
			/// Indicates a successful NTSTATUS value, such as STATUS_SUCCESS, or the value IO_ERR_RETRY_SUCCEEDED in error log packets.
			/// </summary>
			STATUS_SEVERITY_SUCCESS = 0x0,

			/// <summary>Indicates an informational NTSTATUS value, such as STATUS_SERIAL_MORE_WRITES.</summary>
			STATUS_SEVERITY_INFORMATIONAL = 0x1,

			/// <summary>Indicates a warning NTSTATUS value, such as STATUS_DEVICE_PAPER_EMPTY.</summary>
			STATUS_SEVERITY_WARNING = 0x2,

			/// <summary>
			/// Indicates an error NTSTATUS value, such as STATUS_INSUFFICIENT_RESOURCES for a FinalStatus value or
			/// IO_ERR_CONFIGURATION_ERROR for an ErrorCode value in error log packets.
			/// </summary>
			STATUS_SEVERITY_ERROR = 0x3
		}

		/// <summary>Gets the code portion of the <see cref="NTStatus"/>.</summary>
		/// <value>The code value (bits 0-15).</value>
		public ushort Code => GetCode(_value);

		/// <summary>Gets a value indicating whether this code is customer defined (true) or from Microsoft (false).</summary>
		/// <value><c>true</c> if customer defined; otherwise, <c>false</c>.</value>
		public bool CustomerDefined => IsCustomerDefined(_value);

		/// <summary>Gets the facility portion of the <see cref="NTStatus"/>.</summary>
		/// <value>The facility value (bits 16-26).</value>
		public FacilityCode Facility => GetFacility(_value);

		/// <summary>Gets a value indicating whether this <see cref="NTStatus"/> is a failure (Severity bit 31 equals 1).</summary>
		/// <value><c>true</c> if failed; otherwise, <c>false</c>.</value>
		public bool Failed => Severity == SeverityLevel.STATUS_SEVERITY_ERROR;

		/// <summary>Gets the severity level of the <see cref="NTStatus"/>.</summary>
		/// <value>The severity level.</value>
		public SeverityLevel Severity => GetSeverity(_value);

		/// <summary>Gets a value indicating whether this <see cref="NTStatus"/> is a success (Severity bit 31 equals 0).</summary>
		/// <value><c>true</c> if succeeded; otherwise, <c>false</c>.</value>
		public bool Succeeded => !Failed;

		/// <summary>Performs an explicit conversion from <see cref="NTStatus"/> to <see cref="HRESULT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="HRESULT"/> instance from the conversion.</returns>
		public static explicit operator HRESULT(NTStatus value) => value.ToHRESULT();

		/// <summary>Performs an explicit conversion from <see cref="NTStatus"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator int(NTStatus value) => value._value;

		/// <summary>Gets the code value from a 32-bit value.</summary>
		/// <param name="ntstatus">The 32-bit raw NTStatus value.</param>
		/// <returns>The code value (bits 0-15).</returns>
		public static ushort GetCode(int ntstatus) => (ushort)(ntstatus & codeMask);

		/// <summary>Gets the facility value from a 32-bit value.</summary>
		/// <param name="ntstatus">The 32-bit raw NTStatus value.</param>
		/// <returns>The facility value (bits 16-26).</returns>
		public static FacilityCode GetFacility(int ntstatus) => (FacilityCode)((ntstatus & facilityMask) >> facilityShift);

		/// <summary>Gets the severity value from a 32-bit value.</summary>
		/// <param name="ntstatus">The 32-bit raw NTStatus value.</param>
		/// <returns>The severity value (bit 31).</returns>
		public static SeverityLevel GetSeverity(int ntstatus) => (SeverityLevel)((ntstatus & severityMask) >> severityShift);

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="NTStatus"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator NTStatus(int value) => new NTStatus(value);

		/// <summary>Performs an implicit conversion from <see cref="Win32Error"/> to <see cref="NTStatus"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="NTStatus"/> instance from the conversion.</returns>
		public static implicit operator NTStatus(Win32Error value) => NTSTATUS_FROM_WIN32((uint)value);

		/// <summary>Gets the customer defined bit from a 32-bit value.</summary>
		/// <param name="ntstatus">The 32-bit raw NTStatus value.</param>
		/// <returns><c>true</c> if the customer defined bit is set; otherwise, <c>false</c>.</returns>
		public static bool IsCustomerDefined(int ntstatus) => (ntstatus & customerMask) > 0;

		/// <summary>Creates a new <see cref="NTStatus"/> from provided values.</summary>
		/// <param name="severity">The severity level.</param>
		/// <param name="customerDefined">The bit is set for customer-defined values and clear for Microsoft-defined values.</param>
		/// <param name="facility">The facility.</param>
		/// <param name="code">The code.</param>
		/// <returns>The resulting <see cref="NTStatus"/>.</returns>
		public static NTStatus Make(SeverityLevel severity, bool customerDefined, FacilityCode facility, ushort code) => Make(severity, customerDefined, (ushort)facility, code);

		/// <summary>Creates a new <see cref="NTStatus"/> from provided values.</summary>
		/// <param name="severity">The severity level.</param>
		/// <param name="customerDefined">The bit is set for customer-defined values and clear for Microsoft-defined values.</param>
		/// <param name="facility">The facility.</param>
		/// <param name="code">The code.</param>
		/// <returns>The resulting <see cref="NTStatus"/>.</returns>
		public static NTStatus Make(SeverityLevel severity, bool customerDefined, ushort facility, ushort code) =>
			new NTStatus(unchecked((int)(((uint)severity << severityShift) | (customerDefined ? customerMask : 0U) | ((uint)facility << facilityShift) | code)));

		/// <summary>Converts a Win32 error to an NTSTATUS.</summary>
		/// <param name="x">The Win32 error codex.</param>
		/// <returns>The equivalent NTSTATUS value.</returns>
		public static NTStatus NTSTATUS_FROM_WIN32(uint x) => unchecked((int)x) <= 0 ? unchecked((int)x) : unchecked((int)(((x) & 0x0000FFFF) | ((uint)FacilityCode.FACILITY_NTWIN32 << 16) | 0xC0000000U));

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="NTStatus"/>.</param>
		/// <param name="hrRight">The second <see cref="NTStatus"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(NTStatus hrLeft, NTStatus hrRight) => !(hrLeft == hrRight);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="NTStatus"/>.</param>
		/// <param name="hrRight">The second <see cref="int"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(NTStatus hrLeft, int hrRight) => !(hrLeft == hrRight);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="NTStatus"/>.</param>
		/// <param name="hrRight">The second <see cref="NTStatus"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(NTStatus hrLeft, NTStatus hrRight) => hrLeft._value == hrRight._value;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="NTStatus"/>.</param>
		/// <param name="hrRight">The second <see cref="int"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(NTStatus hrLeft, int hrRight) => hrLeft._value == hrRight;

		/// <summary>Converts the specified NTSTATUS code to its equivalent system error code.</summary>
		/// <param name="status">The NTSTATUS code to be converted.</param>
		/// <returns>
		/// The function returns the corresponding system error code. ERROR_MR_MID_NOT_FOUND is returned when the specified NTSTATUS code
		/// does not have a corresponding system error code.
		/// </returns>
		[DllImport(Lib.NtDll, ExactSpelling = true)]
		[PInvokeData("Winternl.h", MSDNShortId = "ms680600")]
		public static extern uint RtlNtStatusToDosError(int status);

		/// <summary>
		/// If the supplied raw NTStatus value represents a failure, throw the associated <see cref="Exception"/> with the optionally
		/// supplied message.
		/// </summary>
		/// <param name="ntstatus">The 32-bit raw NTStatus value.</param>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		public static void ThrowIfFailed(int ntstatus, string message = null) => new NTStatus(ntstatus).ThrowIfFailed(message);

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following
		/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal
		/// to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		public int CompareTo(NTStatus other) => _value.CompareTo(other._value);

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current
		/// instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less
		/// than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the
		/// sort order as <paramref name="obj"/> . Greater than zero This instance follows <paramref name="obj"/> in the sort order.
		/// </returns>
		public int CompareTo(object obj)
		{
			var v = ValueFromObj(obj);
			return v.HasValue
				? _value.CompareTo(v.Value)
				: throw new ArgumentException(@"Object cannot be converted to a UInt32 value for comparison.", nameof(obj));
		}

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => Equals(_value, ValueFromObj(obj));

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(NTStatus other) => other._value == _value;

		/// <summary>Gets the .NET <see cref="Exception"/> associated with the NTStatus value and optionally adds the supplied message.</summary>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		/// <returns>The associated <see cref="Exception"/> or <c>null</c> if this NTStatus is not a failure.</returns>
		[SecurityCritical]
		[SecuritySafeCritical]
		public Exception GetException(string message = null)
		{
			if (!Failed) return null;
			return ToHRESULT().GetException();
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => _value;

		/// <summary>
		/// If this <see cref="NTStatus"/> represents a failure, throw the associated <see cref="Exception"/> with the optionally supplied message.
		/// </summary>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		[SecurityCritical]
		[SecuritySafeCritical]
		public void ThrowIfFailed(string message = null)
		{
			var exception = GetException(message);
			if (exception != null)
				throw exception;
		}

		/// <summary>Converts this error to an <see cref="T:Vanara.PInvoke.HRESULT"/>.</summary>
		/// <returns>An equivalent <see cref="T:Vanara.PInvoke.HRESULT"/>.</returns>
		public HRESULT ToHRESULT()
		{
			Win32Error werr = RtlNtStatusToDosError(_value);
			return werr != Win32Error.ERROR_MR_MID_NOT_FOUND ? (HRESULT)werr : HRESULT_FROM_NT(_value);
		}

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString()
		{
			// Check for defined NTStatus value
			StaticFieldValueHash.TryGetFieldName<NTStatus, int>(_value, out var err);
			var msg = HRESULT.FormatMessage(unchecked((uint)_value));
			return (err ?? string.Format(CultureInfo.InvariantCulture, "0x{0:X8}", _value)) + (msg == null ? "" : ": " + msg);
		}

		TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();

		bool IConvertible.ToBoolean(IFormatProvider provider) => Succeeded;

		byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);

		char IConvertible.ToChar(IFormatProvider provider) => throw new NotSupportedException();

		DateTime IConvertible.ToDateTime(IFormatProvider provider) => throw new NotSupportedException();

		decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);

		double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);

		short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);

		int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);

		long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);

		sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);

		float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);

		string IConvertible.ToString(IFormatProvider provider) => ToString();

		object IConvertible.ToType(Type conversionType, IFormatProvider provider) => ((IConvertible)_value).ToType(conversionType, provider);

		ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);

		uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);

		ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);

		[ExcludeFromCodeCoverage]
		private static HRESULT HRESULT_FROM_NT(int ntStatus) => ntStatus | FACILITY_NT_BIT;

		private static int? ValueFromObj(object obj)
		{
			if (obj == null) return null;
			var c = TypeDescriptor.GetConverter(obj);
			return c.CanConvertTo(typeof(int)) ? (int?)c.ConvertTo(obj, typeof(int)) : null;
		}
	}

	internal class NTStatusTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType.IsPrimitive && sourceType != typeof(char))
				return true;
			return base.CanConvertFrom(context, sourceType);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string) || destinationType.IsPrimitive && destinationType != typeof(char))
				return true;
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value != null && value.GetType().IsPrimitive)
			{
				if (value is bool b)
					return b ? NTStatus.STATUS_SUCCESS : NTStatus.STATUS_UNSUCCESSFUL;
				if (!(value is char))
					return new NTStatus((int)Convert.ChangeType(value, TypeCode.Int32));
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
			Type destinationType)
		{
			if (!(value is NTStatus)) throw new NotSupportedException();
			if (destinationType.IsPrimitive && destinationType != typeof(char))
				return Convert.ChangeType((NTStatus)value, destinationType);
			if (destinationType == typeof(string))
				return ((NTStatus)value).ToString();
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}