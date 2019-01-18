using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;

namespace Vanara.PInvoke
{
	/// <summary>
	/// Formal replacement for the Windows HRESULT definition. In windows.h, it is a defined UINT value. For .NET, this class strongly types
	/// the value.
	/// <para>The 32-bit value is organized as follows:</para>
	/// <list type="table">
	/// <item>
	/// <term>Bit</term>
	/// <description>31</description>
	/// <description>30</description>
	/// <description>29</description>
	/// <description>28</description>
	/// <description>27</description>
	/// <description>26 - 16</description>
	/// <description>15 - 0</description>
	/// </item>
	/// <item>
	/// <term>Field</term>
	/// <description>Severity</description>
	/// <description>Severity</description>
	/// <description>Customer</description>
	/// <description>NT status</description>
	/// <description>MsgID</description>
	/// <description>Facility</description>
	/// <description>Code</description>
	/// </item>
	/// </list>
	/// </summary>
	/// <seealso cref="System.IComparable"/>
	/// <seealso cref="System.IComparable{HRESULT}"/>
	/// <seealso cref="System.IEquatable{HRESULT}"/>
	[StructLayout(LayoutKind.Sequential)]
	[TypeConverter(typeof(HRESULTTypeConverter))]
	public partial struct HRESULT : IComparable, IComparable<HRESULT>, IEquatable<HRESULT>, IConvertible
	{
		internal readonly uint _value;

		private const int codeMask = 0xFFFF;
		private const uint facilityMask = 0x7FF0000;
		private const int facilityShift = 16;
		private const uint severityMask = 0x80000000;
		private const int severityShift = 31;

		/// <summary>Enumeration of facility codes</summary>
		public enum FacilityCode
		{
			/// <summary>The default facility code.</summary>
			FACILITY_NULL = 0,

			/// <summary>The source of the error code is an RPC subsystem.</summary>
			FACILITY_RPC = 1,

			/// <summary>The source of the error code is a COM Dispatch.</summary>
			FACILITY_DISPATCH = 2,

			/// <summary>The source of the error code is OLE Storage.</summary>
			FACILITY_STORAGE = 3,

			/// <summary>The source of the error code is COM/OLE Interface management.</summary>
			FACILITY_ITF = 4,

			/// <summary>This region is reserved to map undecorated error codes into HRESULTs.</summary>
			FACILITY_WIN32 = 7,

			/// <summary>The source of the error code is the Windows subsystem.</summary>
			FACILITY_WINDOWS = 8,

			/// <summary>The source of the error code is the Security API layer.</summary>
			FACILITY_SECURITY = 9,

			/// <summary>The source of the error code is the Security API layer.</summary>
			FACILITY_SSPI = 9,

			/// <summary>The source of the error code is the control mechanism.</summary>
			FACILITY_CONTROL = 10,

			/// <summary>The source of the error code is a certificate client or server?</summary>
			FACILITY_CERT = 11,

			/// <summary>The source of the error code is Wininet related.</summary>
			FACILITY_INTERNET = 12,

			/// <summary>The source of the error code is the Windows Media Server.</summary>
			FACILITY_MEDIASERVER = 13,

			/// <summary>The source of the error code is the Microsoft Message Queue.</summary>
			FACILITY_MSMQ = 14,

			/// <summary>The source of the error code is the Setup API.</summary>
			FACILITY_SETUPAPI = 15,

			/// <summary>The source of the error code is the Smart-card subsystem.</summary>
			FACILITY_SCARD = 16,

			/// <summary>The source of the error code is COM+.</summary>
			FACILITY_COMPLUS = 17,

			/// <summary>The source of the error code is the Microsoft agent.</summary>
			FACILITY_AAF = 18,

			/// <summary>The source of the error code is .NET CLR.</summary>
			FACILITY_URT = 19,

			/// <summary>The source of the error code is the audit collection service.</summary>
			FACILITY_ACS = 20,

			/// <summary>The source of the error code is Direct Play.</summary>
			FACILITY_DPLAY = 21,

			/// <summary>The source of the error code is the ubiquitous memoryintrospection service.</summary>
			FACILITY_UMI = 22,

			/// <summary>The source of the error code is Side-by-side servicing.</summary>
			FACILITY_SXS = 23,

			/// <summary>The error code is specific to Windows CE.</summary>
			FACILITY_WINDOWS_CE = 24,

			/// <summary>The source of the error code is HTTP support.</summary>
			FACILITY_HTTP = 25,

			/// <summary>The source of the error code is common Logging support.</summary>
			FACILITY_USERMODE_COMMONLOG = 26,

			/// <summary>The source of the error code is the user mode filter manager.</summary>
			FACILITY_USERMODE_FILTER_MANAGER = 31,

			/// <summary>The source of the error code is background copy control</summary>
			FACILITY_BACKGROUNDCOPY = 32,

			/// <summary>The source of the error code is configuration services.</summary>
			FACILITY_CONFIGURATION = 33,

			/// <summary>The source of the error code is state management services.</summary>
			FACILITY_STATE_MANAGEMENT = 34,

			/// <summary>The source of the error code is the Microsoft Identity Server.</summary>
			FACILITY_METADIRECTORY = 35,

			/// <summary>The source of the error code is a Windows update.</summary>
			FACILITY_WINDOWSUPDATE = 36,

			/// <summary>The source of the error code is Active Directory.</summary>
			FACILITY_DIRECTORYSERVICE = 37,

			/// <summary>The source of the error code is the graphics drivers.</summary>
			FACILITY_GRAPHICS = 38,

			/// <summary>The source of the error code is the user Shell.</summary>
			FACILITY_SHELL = 39,

			/// <summary>The source of the error code is the Trusted Platform Module services.</summary>
			FACILITY_TPM_SERVICES = 40,

			/// <summary>The source of the error code is the Trusted Platform Module applications.</summary>
			FACILITY_TPM_SOFTWARE = 41,

			/// <summary>The source of the error code is Performance Logs and Alerts</summary>
			FACILITY_PLA = 48,

			/// <summary>The source of the error code is Full volume encryption.</summary>
			FACILITY_FVE = 49,

			/// <summary>The source of the error code is the Firewall Platform.</summary>
			FACILITY_FWP = 50,

			/// <summary>The source of the error code is the Windows Resource Manager.</summary>
			FACILITY_WINRM = 51,

			/// <summary>The source of the error code is the Network Driver Interface.</summary>
			FACILITY_NDIS = 52,

			/// <summary>The source of the error code is the Usermode Hypervisor components.</summary>
			FACILITY_USERMODE_HYPERVISOR = 53,

			/// <summary>The source of the error code is the Configuration Management Infrastructure.</summary>
			FACILITY_CMI = 54,

			/// <summary>The source of the error code is the user mode virtualization subsystem.</summary>
			FACILITY_USERMODE_VIRTUALIZATION = 55,

			/// <summary>The source of the error code is the user mode volume manager</summary>
			FACILITY_USERMODE_VOLMGR = 56,

			/// <summary>The source of the error code is the Boot Configuration Database.</summary>
			FACILITY_BCD = 57,

			/// <summary>The source of the error code is user mode virtual hard disk support.</summary>
			FACILITY_USERMODE_VHD = 58,

			/// <summary>The source of the error code is System Diagnostics.</summary>
			FACILITY_SDIAG = 60,

			/// <summary>The source of the error code is the Web Services.</summary>
			FACILITY_WEBSERVICES = 61,

			/// <summary>The source of the error code is a Windows Defender component.</summary>
			FACILITY_WINDOWS_DEFENDER = 80,

			/// <summary>The source of the error code is the open connectivity service.</summary>
			FACILITY_OPC = 81,
		}

		/// <summary>A value indicating whether an <see cref="HRESULT"/> is a success (Severity bit 31 equals 0).</summary>
		public enum SeverityLevel
		{
			/// <summary>Success</summary>
			Success = 0,

			/// <summary>Failure</summary>
			Fail = 1
		}

		/// <summary>Initializes a new instance of the <see cref="HRESULT"/> structure.</summary>
		/// <param name="rawValue">The raw HRESULT value.</param>
		public HRESULT(uint rawValue) => _value = rawValue;

		/// <summary>Gets the code portion of the <see cref="HRESULT"/>.</summary>
		/// <value>The code value (bits 0-15).</value>
		public int Code => GetCode((int)_value);

		/// <summary>Gets the facility portion of the <see cref="HRESULT"/>.</summary>
		/// <value>The facility value (bits 16-26).</value>
		public FacilityCode Facility => GetFacility((int)_value);

		/// <summary>Gets a value indicating whether this <see cref="HRESULT"/> is a failure (Severity bit 31 equals 1).</summary>
		/// <value><c>true</c> if failed; otherwise, <c>false</c>.</value>
		public bool Failed => Severity == SeverityLevel.Fail;

		/// <summary>Gets the severity level of the <see cref="HRESULT"/>.</summary>
		/// <value>The severity level.</value>
		public SeverityLevel Severity => GetSeverity((int)_value);

		/// <summary>Gets a value indicating whether this <see cref="HRESULT"/> is a success (Severity bit 31 equals 0).</summary>
		/// <value><c>true</c> if succeeded; otherwise, <c>false</c>.</value>
		public bool Succeeded => Severity == SeverityLevel.Success;

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following meanings: Value
		/// Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal to <paramref
		/// name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		public int CompareTo(HRESULT other) => _value.CompareTo(other._value);

		/// <summary>
		/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current
		/// instance precedes, follows, or occurs in the same position in the sort order as the other object.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less
		/// than zero This instance precedes <paramref name="obj"/> in the sort order. Zero This instance occurs in the same position in the
		/// sort order as <paramref name="obj"/>. Greater than zero This instance follows <paramref name="obj"/> in the sort order.
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
		public bool Equals(HRESULT other) => other._value == _value;

		/// <summary>Gets the code value from a 32-bit value.</summary>
		/// <param name="hresult">The 32-bit raw HRESULT value.</param>
		/// <returns>The code value (bits 0-15).</returns>
		public static int GetCode(int hresult) => hresult & codeMask;

		/// <summary>Gets the .NET <see cref="Exception"/> associated with the HRESULT value and optionally adds the supplied message.</summary>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		/// <returns>The associated <see cref="Exception"/> or <c>null</c> if this HRESULT is not a failure.</returns>
		[SecurityCritical, SecuritySafeCritical]
		public Exception GetException(string message = null)
		{
			if (!Failed) return null;

			var exceptionForHR = Marshal.GetExceptionForHR((int)_value, new IntPtr(-1));
			if (exceptionForHR.GetType() == typeof(COMException))
			{
				if (Facility == FacilityCode.FACILITY_WIN32)
					return string.IsNullOrEmpty(message) ? new Win32Exception(Code) : new Win32Exception(Code, message);
				return new COMException(message ?? exceptionForHR.Message, (int)_value);
			}
			if (!string.IsNullOrEmpty(message))
			{
				Type[] types = { typeof(string) };
				var constructor = exceptionForHR.GetType().GetConstructor(types);
				if (null != constructor)
				{
					object[] parameters = { message };
					exceptionForHR = constructor.Invoke(parameters) as Exception;
				}
			}
			return exceptionForHR;
		}

		/// <summary>Gets the facility value from a 32-bit value.</summary>
		/// <param name="hresult">The 32-bit raw HRESULT value.</param>
		/// <returns>The facility value (bits 16-26).</returns>
		public static FacilityCode GetFacility(int hresult) => (FacilityCode)((hresult & facilityMask) >> facilityShift);

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => _value.GetHashCode();

		/// <summary>Gets the severity value from a 32-bit value.</summary>
		/// <param name="hresult">The 32-bit raw HRESULT value.</param>
		/// <returns>The severity value (bit 31).</returns>
		public static SeverityLevel GetSeverity(int hresult)
			=> (SeverityLevel)((hresult & severityMask) >> severityShift);

		/// <summary>Creates a new <see cref="HRESULT"/> from provided values.</summary>
		/// <param name="severe">if set to <c>false</c>, sets the severity bit to 1.</param>
		/// <param name="facility">The facility.</param>
		/// <param name="code">The code.</param>
		/// <returns>The resulting <see cref="HRESULT"/>.</returns>
		public static HRESULT Make(bool severe, FacilityCode facility, uint code) => Make(severe, (uint)facility, code);

		/// <summary>Creates a new <see cref="HRESULT"/> from provided values.</summary>
		/// <param name="severe">if set to <c>false</c>, sets the severity bit to 1.</param>
		/// <param name="facility">The facility.</param>
		/// <param name="code">The code.</param>
		/// <returns>The resulting <see cref="HRESULT"/>.</returns>
		public static HRESULT Make(bool severe, uint facility, uint code) => new HRESULT(
			(severe ? severityMask : 0) | (facility << facilityShift) | code);

		/// <summary>
		/// If this <see cref="HRESULT"/> represents a failure, throw the associated <see cref="Exception"/> with the optionally supplied message.
		/// </summary>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		[SecurityCritical, SecuritySafeCritical]
		[System.Diagnostics.DebuggerStepThrough]
		public void ThrowIfFailed(string message = null)
		{
			var exception = GetException(message);
			if (exception != null)
				throw exception;
		}

		/// <summary>
		/// If the supplied raw HRESULT value represents a failure, throw the associated <see cref="Exception"/> with the optionally supplied message.
		/// </summary>
		/// <param name="hresult">The 32-bit raw HRESULT value.</param>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		[System.Diagnostics.DebuggerStepThrough]
		public static void ThrowIfFailed(int hresult, string message = null) => new HRESULT((uint)hresult).ThrowIfFailed(message);

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString()
		{
			// Check for defined HRESULT value
			foreach (var info in typeof(HRESULT).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				if (info.FieldType == typeof(uint) && (uint)info.GetValue(null) == _value)
					return info.Name;
			}
			// Check for Win32Error defined value
			if (Facility == FacilityCode.FACILITY_WIN32)
			{
				foreach (var info2 in typeof(Win32Error).GetFields(BindingFlags.Public | BindingFlags.Static))
				{
					if (info2.FieldType == typeof(int) && (HRESULT)(Win32Error)(int)info2.GetValue(null) == this)
						return $"HRESULT_FROM_WIN32({info2.Name})";
				}
			}
			return string.Format(CultureInfo.InvariantCulture, "0x{0:X8}", _value);
		}

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="HRESULT"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HRESULT hrLeft, HRESULT hrRight) => hrLeft._value == hrRight._value;

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="uint"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HRESULT hrLeft, uint hrRight) => hrLeft._value == hrRight;

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="HRESULT"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HRESULT hrLeft, HRESULT hrRight) => !(hrLeft == hrRight);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="uint"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HRESULT hrLeft, uint hrRight) => !(hrLeft == hrRight);

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="HRESULT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRESULT(int value) => new HRESULT((uint)value);

		/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="HRESULT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRESULT(uint value) => new HRESULT(value);

		/// <summary>Performs an explicit conversion from <see cref="HRESULT"/> to <see cref="System.Int32"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator int(HRESULT value) => (int)value._value;

		/// <summary>Performs an explicit conversion from <see cref="System.Boolean"/> to <see cref="HRESULT"/>.</summary>
		/// <param name="value">if set to <see langword="true" /> returns S_OK; otherwise S_FALSE.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator HRESULT(bool value) => value ? S_OK : S_FALSE;

		private static uint? ValueFromObj(object obj)
		{
			if (obj == null) return null;
			var c = TypeDescriptor.GetConverter(obj);
			return c.CanConvertTo(typeof(uint)) ? (uint?)c.ConvertTo(obj, typeof(uint)) : null;
		}

		TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();

		bool IConvertible.ToBoolean(IFormatProvider provider) => Succeeded;

		char IConvertible.ToChar(IFormatProvider provider) => throw new NotSupportedException();

		sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);

		byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);

		short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);

		ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)_value).ToUInt16(provider);

		int IConvertible.ToInt32(IFormatProvider provider) => ((IConvertible)_value).ToInt32(provider);

		uint IConvertible.ToUInt32(IFormatProvider provider) => ((IConvertible)_value).ToUInt32(provider);

		long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);

		ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)_value).ToUInt64(provider);

		float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);

		double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);

		decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);

		DateTime IConvertible.ToDateTime(IFormatProvider provider) => throw new NotSupportedException();

		string IConvertible.ToString(IFormatProvider provider) => ToString();

		object IConvertible.ToType(Type conversionType, IFormatProvider provider) =>
			((IConvertible)_value).ToType(conversionType, provider);
	}

	internal class HRESULTTypeConverter : TypeConverter
	{
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			if (sourceType == typeof(Win32Error) || sourceType.IsPrimitive && sourceType != typeof(char))
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
			if (value is Win32Error e)
				return e.ToHRESULT();
			if (value != null && value.GetType().IsPrimitive)
			{
				if (value is bool b)
					return b ? HRESULT.S_OK : HRESULT.S_FALSE;
				if (!(value is char))
					return new HRESULT((uint)Convert.ChangeType(value, TypeCode.UInt32));
			}
			return base.ConvertFrom(context, culture, value);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value,
			Type destinationType)
		{
			if (!(value is HRESULT hr)) throw new NotSupportedException();
			if (destinationType.IsPrimitive && destinationType != typeof(char))
				return Convert.ChangeType(hr, destinationType);
			if (destinationType == typeof(string))
				return hr.ToString();
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}