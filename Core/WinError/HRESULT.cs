using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security;

namespace Vanara.PInvoke;

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
/// <seealso cref="IErrorProvider2{HRESULT}"/>
[StructLayout(LayoutKind.Sequential)]
[TypeConverter(typeof(HRESULTTypeConverter))]
[PInvokeData("winerr.h")]
public partial struct HRESULT : IEquatable<int>, IEquatable<uint>, IEquatable<IErrorProvider>, IErrorProvider2<HRESULT>
{
	internal readonly int _value;

	private const int codeMask = 0xFFFF;
	private const uint facilityMask = 0x7FF0000;
	private const int facilityShift = 16;
	private const uint severityMask = 0x80000000;
	private const int severityShift = 31;

	/// <summary>Initializes a new instance of the <see cref="HRESULT"/> structure.</summary>
	/// <param name="rawValue">The raw HRESULT value.</param>
	public HRESULT(int rawValue) => _value = rawValue;

	/// <summary>Initializes a new instance of the <see cref="HRESULT"/> structure.</summary>
	/// <param name="rawValue">The raw HRESULT value.</param>
	public HRESULT(uint rawValue) => _value = unchecked((int)rawValue);

	/// <summary>Enumeration of facility codes</summary>
	[PInvokeData("winerr.h")]
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

		/// <summary/>
		FACILITY_XPS = 82,

		/// <summary/>
		FACILITY_MBN = 84,

		/// <summary/>
		FACILITY_POWERSHELL = 84,

		/// <summary/>
		FACILITY_RAS = 83,

		/// <summary/>
		FACILITY_P2P_INT = 98,

		/// <summary/>
		FACILITY_P2P = 99,

		/// <summary/>
		FACILITY_DAF = 100,

		/// <summary/>
		FACILITY_BLUETOOTH_ATT = 101,

		/// <summary/>
		FACILITY_AUDIO = 102,

		/// <summary/>
		FACILITY_STATEREPOSITORY = 103,

		/// <summary/>
		FACILITY_VISUALCPP = 109,

		/// <summary/>
		FACILITY_SCRIPT = 112,

		/// <summary/>
		FACILITY_PARSE = 113,

		/// <summary/>
		FACILITY_BLB = 120,

		/// <summary/>
		FACILITY_BLB_CLI = 121,

		/// <summary/>
		FACILITY_WSBAPP = 122,

		/// <summary/>
		FACILITY_BLBUI = 128,

		/// <summary/>
		FACILITY_USN = 129,

		/// <summary/>
		FACILITY_USERMODE_VOLSNAP = 130,

		/// <summary/>
		FACILITY_TIERING = 131,

		/// <summary/>
		FACILITY_WSB_ONLINE = 133,

		/// <summary/>
		FACILITY_ONLINE_ID = 134,

		/// <summary/>
		FACILITY_DEVICE_UPDATE_AGENT = 135,

		/// <summary/>
		FACILITY_DRVSERVICING = 136,

		/// <summary/>
		FACILITY_DLS = 153,

		/// <summary/>
		FACILITY_DELIVERY_OPTIMIZATION = 208,

		/// <summary/>
		FACILITY_USERMODE_SPACES = 231,

		/// <summary/>
		FACILITY_USER_MODE_SECURITY_CORE = 232,

		/// <summary/>
		FACILITY_USERMODE_LICENSING = 234,

		/// <summary/>
		FACILITY_SOS = 160,

		/// <summary/>
		FACILITY_DEBUGGERS = 176,

		/// <summary/>
		FACILITY_SPP = 256,

		/// <summary/>
		FACILITY_RESTORE = 256,

		/// <summary/>
		FACILITY_DMSERVER = 256,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_SERVER = 257,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_IMAGING = 258,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_MANAGEMENT = 259,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_UTIL = 260,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_BINLSVC = 261,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_PXE = 263,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_TFTP = 264,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_TRANSPORT_MANAGEMENT = 272,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_DRIVER_PROVISIONING = 278,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_MULTICAST_SERVER = 289,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_MULTICAST_CLIENT = 290,

		/// <summary/>
		FACILITY_DEPLOYMENT_SERVICES_CONTENT_PROVIDER = 293,

		/// <summary/>
		FACILITY_LINGUISTIC_SERVICES = 305,

		/// <summary/>
		FACILITY_AUDIOSTREAMING = 1094,

		/// <summary/>
		FACILITY_ACCELERATOR = 1536,

		/// <summary/>
		FACILITY_WMAAECMA = 1996,

		/// <summary/>
		FACILITY_DIRECTMUSIC = 2168,

		/// <summary/>
		FACILITY_DIRECT3D10 = 2169,

		/// <summary/>
		FACILITY_DXGI = 2170,

		/// <summary/>
		FACILITY_DXGI_DDI = 2171,

		/// <summary/>
		FACILITY_DIRECT3D11 = 2172,

		/// <summary/>
		FACILITY_DIRECT3D11_DEBUG = 2173,

		/// <summary/>
		FACILITY_DIRECT3D12 = 2174,

		/// <summary/>
		FACILITY_DIRECT3D12_DEBUG = 2175,

		/// <summary/>
		FACILITY_LEAP = 2184,

		/// <summary/>
		FACILITY_AUDCLNT = 2185,

		/// <summary/>
		FACILITY_WINCODEC_DWRITE_DWM = 2200,

		/// <summary/>
		FACILITY_WINML = 2192,

		/// <summary/>
		FACILITY_DIRECT2D = 2201,

		/// <summary/>
		FACILITY_DEFRAG = 2304,

		/// <summary/>
		FACILITY_USERMODE_SDBUS = 2305,

		/// <summary/>
		FACILITY_JSCRIPT = 2306,

		/// <summary/>
		FACILITY_PIDGENX = 2561,

		/// <summary/>
		FACILITY_EAS = 85,

		/// <summary/>
		FACILITY_WEB = 885,

		/// <summary/>
		FACILITY_WEB_SOCKET = 886,

		/// <summary/>
		FACILITY_MOBILE = 1793,

		/// <summary/>
		FACILITY_SQLITE = 1967,

		/// <summary/>
		FACILITY_UTC = 1989,

		/// <summary/>
		FACILITY_WEP = 2049,

		/// <summary/>
		FACILITY_SYNCENGINE = 2050,

		/// <summary/>
		FACILITY_XBOX = 2339,

		/// <summary/>
		FACILITY_GAME = 2340,

		/// <summary/>
		FACILITY_PIX = 2748
	}

	/// <summary>A value indicating whether an <see cref="HRESULT"/> is a success (Severity bit 31 equals 0).</summary>
	[PInvokeData("winerr.h")]
	public enum SeverityLevel
	{
		/// <summary>Success</summary>
		Success = 0,

		/// <summary>Failure</summary>
		Fail = 1
	}

	/// <summary>Gets the code portion of the <see cref="HRESULT"/>.</summary>
	/// <value>The code value (bits 0-15).</value>
	public int Code => GetCode(_value);

	/// <summary>Gets the facility portion of the <see cref="HRESULT"/>.</summary>
	/// <value>The facility value (bits 16-26).</value>
	public FacilityCode Facility => GetFacility(_value);

	/// <summary>Gets a value indicating whether this <see cref="HRESULT"/> is a failure (Severity bit 31 equals 1).</summary>
	/// <value><c>true</c> if failed; otherwise, <c>false</c>.</value>
	public bool Failed => _value < 0;

	/// <summary>Gets the severity level of the <see cref="HRESULT"/>.</summary>
	/// <value>The severity level.</value>
	public SeverityLevel Severity => GetSeverity(_value);

	/// <summary>Gets a value indicating whether this <see cref="HRESULT"/> is a success (Severity bit 31 equals 0).</summary>
	/// <value><c>true</c> if succeeded; otherwise, <c>false</c>.</value>
	public bool Succeeded => _value >= 0;

	/// <summary>Performs an explicit conversion from <see cref="System.Boolean"/> to <see cref="HRESULT"/>.</summary>
	/// <param name="value">if set to <see langword="true"/> returns S_OK; otherwise S_FALSE.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator HRESULT(bool value) => value ? S_OK : S_FALSE;

	/// <summary>Performs an explicit conversion from <see cref="HRESULT"/> to <see cref="System.Int32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator int(HRESULT value) => value._value;

	/// <summary>Performs an explicit conversion from <see cref="HRESULT"/> to <see cref="System.UInt32"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator uint(HRESULT value) => unchecked((uint)value._value);

	/// <summary>Tries to extract a HRESULT from an exception.</summary>
	/// <param name="exception">The exception.</param>
	/// <returns>The error. If undecipherable, E_FAIL is returned.</returns>
	public static HRESULT FromException(Exception exception)
	{
		if (exception is Win32Exception we)
			return new Win32Error(unchecked((uint)we.NativeErrorCode)).ToHRESULT();
		if (exception.InnerException is Win32Exception iwe)
			return new Win32Error(unchecked((uint)iwe.NativeErrorCode)).ToHRESULT();
		if (exception.HResult != 0)
			return new HRESULT(exception.HResult);
		else if (exception.InnerException != null && exception.InnerException.HResult != 0)
			return new HRESULT(exception.InnerException.HResult);
		return E_FAIL;
	}

	/// <summary>Gets the code value from a 32-bit value.</summary>
	/// <param name="hresult">The 32-bit raw HRESULT value.</param>
	/// <returns>The code value (bits 0-15).</returns>
	public static int GetCode(int hresult) => hresult & codeMask;

	/// <summary>Gets the facility value from a 32-bit value.</summary>
	/// <param name="hresult">The 32-bit raw HRESULT value.</param>
	/// <returns>The facility value (bits 16-26).</returns>
	public static FacilityCode GetFacility(int hresult) => (FacilityCode)((hresult & facilityMask) >> facilityShift);

	/// <summary>Gets the severity value from a 32-bit value.</summary>
	/// <param name="hresult">The 32-bit raw HRESULT value.</param>
	/// <returns>The severity value (bit 31).</returns>
	public static SeverityLevel GetSeverity(int hresult)
		=> (SeverityLevel)((hresult & severityMask) >> severityShift);

	/// <summary>Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="HRESULT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HRESULT(int value) => new(value);

	/// <summary>Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="HRESULT"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The resulting <see cref="HRESULT"/> instance from the conversion.</returns>
	public static implicit operator HRESULT(uint value) => new(value);

	/// <summary>Maps an NT Status value to an HRESULT value.</summary>
	/// <param name="err">The NT Status value.</param>
	/// <returns>The HRESULT value.</returns>
	public static HRESULT HRESULT_FROM_NT(NTStatus err) => err.ToHRESULT();

	/// <summary>Maps a system error code to an HRESULT value.</summary>
	/// <param name="err">The system error code.</param>
	/// <returns>The HRESULT value.</returns>
	public static HRESULT HRESULT_FROM_WIN32(Win32Error err) => err.ToHRESULT();

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
	public static HRESULT Make(bool severe, uint facility, uint code) =>
		new(unchecked((int)((severe ? severityMask : 0) | (facility << facilityShift) | code)));

	/// <summary>Implements the operator !=.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="HRESULT"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HRESULT hrLeft, HRESULT hrRight) => !(hrLeft == hrRight);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="int"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HRESULT hrLeft, int hrRight) => !(hrLeft == hrRight);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="uint"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HRESULT hrLeft, uint hrRight) => !(hrLeft == hrRight);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="IErrorProvider"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HRESULT hrLeft, IErrorProvider hrRight) => !hrLeft.Equals(hrRight.ToHRESULT());

	/// <summary>Implements the operator ==.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="HRESULT"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HRESULT hrLeft, HRESULT hrRight) => hrLeft.Equals(hrRight);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="int"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HRESULT hrLeft, int hrRight) => hrLeft.Equals(hrRight);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="uint"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HRESULT hrLeft, uint hrRight) => hrLeft.Equals(hrRight);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="hrLeft">The first <see cref="HRESULT"/>.</param>
	/// <param name="hrRight">The second <see cref="IErrorProvider"/>.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HRESULT hrLeft, IErrorProvider hrRight) => hrLeft.Equals(hrRight.ToHRESULT());

	/// <summary>
	/// If the supplied raw HRESULT value represents a failure, throw the associated <see cref="Exception"/> with the optionally
	/// supplied message.
	/// </summary>
	/// <param name="hresult">The 32-bit raw HRESULT value.</param>
	/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
	[System.Diagnostics.DebuggerStepThrough, System.Diagnostics.DebuggerHidden, System.Diagnostics.StackTraceHidden]
	public static void ThrowIfFailed(HRESULT hresult, string? message = null) => hresult.ThrowIfFailed(message);

	/// <summary>
	/// If the supplied raw HRESULT value represents a failure, throw the associated <see cref="Exception"/> with the optionally
	/// supplied message.
	/// </summary>
	/// <param name="hresult">The 32-bit raw HRESULT value.</param>
	/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
	[System.Diagnostics.DebuggerStepThrough, System.Diagnostics.DebuggerHidden, System.Diagnostics.StackTraceHidden]
	public static void ThrowIfFailed(int hresult, string? message = null) => new HRESULT(hresult).ThrowIfFailed(message);

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
	public int CompareTo(object? obj)
	{
		var v = ValueFromObj(obj);
		return v.HasValue
			? _value.CompareTo(v.Value)
			: throw new ArgumentException(@"Object cannot be converted to a UInt32 value for comparison.", nameof(obj));
	}

	/// <summary>Indicates whether the current object is equal to an <see cref="int"/>.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(int other) => other == _value;

	/// <summary>Indicates whether the current object is equal to an <see cref="uint"/>.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(uint other) => unchecked((int)other) == _value;

	/// <summary>Indicates whether the current object is equal to an <see cref="uint"/>.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(IErrorProvider? other) => Equals(other?.ToHRESULT());

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => obj switch
	{
		null => false,
		HRESULT h => Equals(h),
		int i => Equals(i),
		uint u => Equals(u),
		IErrorProvider e => Equals(e),
		_ => Equals(_value, ValueFromObj(obj)),
	};

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(HRESULT other) => other._value == _value;

	/// <summary>Gets the .NET <see cref="Exception"/> associated with the HRESULT value and optionally adds the supplied message.</summary>
	/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
	/// <returns>The associated <see cref="Exception"/> or <c>null</c> if this HRESULT is not a failure.</returns>
	[SecurityCritical, SecuritySafeCritical]
	public Exception? GetException(string? message = null)
	{
		if (!Failed) return null;

		var exceptionForHR = Marshal.GetExceptionForHR(_value, new IntPtr(-1));
		if (exceptionForHR is null) return null;
		if (exceptionForHR.GetType() == typeof(COMException))
		{
			return Facility == FacilityCode.FACILITY_WIN32
				? string.IsNullOrEmpty(message) ? new Win32Exception(Code) : new Win32Exception(Code, message)
				: new COMException(message ?? exceptionForHR.Message, _value);
		}
		if (!string.IsNullOrEmpty(message))
		{
			var constructor = exceptionForHR.GetType().GetConstructor([typeof(string)])!;
			exceptionForHR = constructor.Invoke([message!]) as Exception;
			# if NETCOREAPP3_0_OR_GREATER
			exceptionForHR!.HResult = _value;
			#endif
		}
		return exceptionForHR;
	}

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => _value;

	/// <summary>
	/// If this <see cref="HRESULT"/> represents a failure, throw the associated <see cref="Exception"/> with the optionally supplied message.
	/// </summary>
	/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
	[SecurityCritical, SecuritySafeCritical]
	[System.Diagnostics.DebuggerStepThrough, System.Diagnostics.DebuggerHidden, System.Diagnostics.StackTraceHidden]
	public void ThrowIfFailed(string? message = null)
	{
		var exception = GetException(message);
		if (exception != null)
			throw exception;
	}

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString()
	{
		// Check for defined HRESULT value
		if (!StaticFieldValueHash.TryGetFieldName<HRESULT, int>(_value, out var err) && Facility == FacilityCode.FACILITY_WIN32)
		{
			foreach (FieldInfo info2 in typeof(Win32Error).GetFields(BindingFlags.Public | BindingFlags.Static).Where(fi => fi.FieldType == typeof(uint)))
			{
				if ((HRESULT)(Win32Error)(uint)info2.GetValue(null)! == this)
				{
					err = $"HRESULT_FROM_WIN32({info2.Name})";
					break;
				}
			}
		}
		var msg = ErrorHelper.GetErrorMessage<HRESULT, int>(_value);
		return (err ?? string.Format(CultureInfo.InvariantCulture, "0x{0:X8}", _value)) + (msg == null ? "" : ": " + msg);
	}

	TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();

	bool IConvertible.ToBoolean(IFormatProvider? provider) => Succeeded;

	byte IConvertible.ToByte(IFormatProvider? provider) => ((IConvertible)_value).ToByte(provider);

	char IConvertible.ToChar(IFormatProvider? provider) => throw new NotSupportedException();

	DateTime IConvertible.ToDateTime(IFormatProvider? provider) => throw new NotSupportedException();

	decimal IConvertible.ToDecimal(IFormatProvider? provider) => ((IConvertible)_value).ToDecimal(provider);

	double IConvertible.ToDouble(IFormatProvider? provider) => ((IConvertible)_value).ToDouble(provider);

	/// <summary>Converts this error to an <see cref="T:Vanara.PInvoke.HRESULT"/>.</summary>
	/// <returns>An equivalent <see cref="T:Vanara.PInvoke.HRESULT"/>.</returns>
	HRESULT IErrorProvider.ToHRESULT() => this;

	short IConvertible.ToInt16(IFormatProvider? provider) => ((IConvertible)_value).ToInt16(provider);

	int IConvertible.ToInt32(IFormatProvider? provider) => _value;

	long IConvertible.ToInt64(IFormatProvider? provider) => ((IConvertible)_value).ToInt64(provider);

	sbyte IConvertible.ToSByte(IFormatProvider? provider) => ((IConvertible)_value).ToSByte(provider);

	float IConvertible.ToSingle(IFormatProvider? provider) => ((IConvertible)_value).ToSingle(provider);

	string IConvertible.ToString(IFormatProvider? provider) => ToString();

	object IConvertible.ToType(Type conversionType, IFormatProvider? provider) =>
		((IConvertible)_value).ToType(conversionType, provider);

	ushort IConvertible.ToUInt16(IFormatProvider? provider) => ((IConvertible)unchecked((uint)_value)).ToUInt16(provider);

	uint IConvertible.ToUInt32(IFormatProvider? provider) => unchecked((uint)_value);

	ulong IConvertible.ToUInt64(IFormatProvider? provider) => ((IConvertible)unchecked((uint)_value)).ToUInt64(provider);

	private static int? ValueFromObj(object? obj)
	{
		switch (obj)
		{
			case null:
				return null;

			case int i:
				return i;

			case uint u:
				return unchecked((int)u);

			default:
				var c = TypeDescriptor.GetConverter(obj);
				return c.CanConvertTo(typeof(int)) ? (int?)c.ConvertTo(obj, typeof(int)) : null;
		}
	}
}

internal class HRESULTTypeConverter : TypeConverter
{
	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
		typeof(IErrorProvider).IsAssignableFrom(sourceType) || sourceType.IsPrimitive && sourceType != typeof(char) || base.CanConvertFrom(context, sourceType);

	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) =>
		destinationType == typeof(string) || destinationType is not null && destinationType.IsPrimitive && destinationType != typeof(char) || base.CanConvertTo(context, destinationType);

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value is null) return null;
		if (value is IErrorProvider e)
			return e.ToHRESULT();
		if (value.GetType().IsPrimitive)
		{
			if (value is bool b)
				return b ? HRESULT.S_OK : HRESULT.S_FALSE;
			if (value is not char)
				return new HRESULT((int)Convert.ChangeType(value, TypeCode.Int32));
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
		Type destinationType)
	{
		if (value is not HRESULT hr) throw new NotSupportedException();
		if (destinationType.IsPrimitive && destinationType != typeof(char))
			return Convert.ChangeType(hr, destinationType);
		return destinationType == typeof(string) ? hr.ToString() : base.ConvertTo(context, culture, value, destinationType);
	}
}