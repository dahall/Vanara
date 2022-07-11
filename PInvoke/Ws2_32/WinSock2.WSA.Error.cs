using System;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Security;

namespace Vanara.PInvoke;

public static partial class Ws2_32
{
	/// <summary>A WinSock2 result. Some functions can interpret the result from a simple failure (SOCKET_ERROR) to the actual error.</summary>
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	[PInvokeData("winsock2.h")]
	public struct WSRESULT : IComparable, IComparable<WSRESULT>, IEquatable<WSRESULT>, IEquatable<int>, IEquatable<SocketError>, IConvertible, IErrorProvider
	{
		internal readonly int _value;

		/// <summary>Initializes a new instance of the <see cref="WSRESULT"/> structure.</summary>
		/// <param name="rawValue">The raw WSRESULT value.</param>
		public WSRESULT(int rawValue) => _value = rawValue;

		/// <summary>Gets a value indicating whether this <see cref="WSRESULT"/> is a failure (Severity bit 31 equals 1).</summary>
		/// <value><c>true</c> if failed; otherwise, <c>false</c>.</value>
		public bool Failed => _value != 0;

		/// <summary>Gets a value indicating whether this <see cref="WSRESULT"/> is a success (Severity bit 31 equals 0).</summary>
		/// <value><c>true</c> if succeeded; otherwise, <c>false</c>.</value>
		public bool Succeeded => _value == 0;

		/// <summary>Performs an explicit conversion from <see cref="WSRESULT"/> to <see cref="HRESULT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The resulting <see cref="HRESULT"/> instance from the conversion.</returns>
		public static explicit operator HRESULT(WSRESULT value) => value.ToHRESULT();

		/// <summary>Performs an explicit conversion from <see cref="WSRESULT"/> to <see cref="int"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator int(WSRESULT value) => value._value;

		/// <summary>Performs an explicit conversion from <see cref="WSRESULT"/> to <see cref="SocketError"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator SocketError(WSRESULT value) => (SocketError)value._value;

		/// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="WSRESULT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WSRESULT(int value) => new(value);

		/// <summary>Performs an implicit conversion from <see cref="SocketError"/> to <see cref="WSRESULT"/>.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WSRESULT(SocketError value) => new((int)value);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="WSRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="WSRESULT"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(WSRESULT hrLeft, WSRESULT hrRight) => !(hrLeft == hrRight);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="hrLeft">The first <see cref="WSRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="int"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(WSRESULT hrLeft, int hrRight) => !(hrLeft == hrRight);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="WSRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="WSRESULT"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(WSRESULT hrLeft, WSRESULT hrRight) => hrLeft.Equals(hrRight);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="hrLeft">The first <see cref="WSRESULT"/>.</param>
		/// <param name="hrRight">The second <see cref="int"/>.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(WSRESULT hrLeft, int hrRight) => hrLeft.Equals(hrRight);

		/// <summary>
		/// If the supplied raw WSRESULT value represents a failure, throw the associated <see cref="Exception"/> with the optionally
		/// supplied message.
		/// </summary>
		/// <param name="value">The 32-bit raw WSRESULT value.</param>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		public static void ThrowIfFailed(int value, string message = null) => new WSRESULT(value).ThrowIfFailed(message);

		/// <summary>Throws the last error if the predicate delegate returns <see langword="true"/>.</summary>
		/// <typeparam name="T">The type of the value to evaluate.</typeparam>
		/// <param name="value">The value to check.</param>
		/// <param name="valueIsFailure">The delegate which returns <see langword="true"/> on failure.</param>
		/// <param name="message">The message.</param>
		/// <returns>The <paramref name="value"/> passed in on success.</returns>
		public static T ThrowLastErrorIf<T>(T value, Func<T, bool> valueIsFailure, string message = null)
		{
			if (valueIsFailure(value))
				GetLastError().ThrowIfFailed(message);
			return value;
		}

		/// <summary>Throws the last error if the function returns <see langword="false"/>.</summary>
		/// <param name="value">The value to check.</param>
		/// <param name="message">The message.</param>
		public static bool ThrowLastErrorIfFalse(bool value, string message = null) => ThrowLastErrorIf(value, v => !v, message);

		/// <summary>Throws the last error if the value is an invalid handle.</summary>
		/// <param name="value">The SafeHandle to check.</param>
		/// <param name="message">The message.</param>
		public static T ThrowLastErrorIfInvalid<T>(T value, string message = null) where T : SafeHandle => ThrowLastErrorIf(value, v => v.IsInvalid, message);

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A value that indicates the relative order of the objects being compared. The return value has the following
		/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal
		/// to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		public int CompareTo(WSRESULT other) => _value.CompareTo(other._value);

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
		public int CompareTo(object obj) => obj switch
		{
			WSRESULT r => CompareTo(r),
			int i => i.CompareTo(_value),
			SocketError e => e.CompareTo((SocketError)_value),
			IErrorProvider e => ToHRESULT().CompareTo(e.ToHRESULT()),
			_ => _value.CompareTo(obj)
		};

		/// <summary>Indicates whether the current object is equal to an <see cref="int"/>.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(int other) => other == _value;

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj switch
		{
			null => false,
			WSRESULT r => Equals(r),
			int i => Equals(i),
			SocketError e => Equals(e),
			IErrorProvider e => ToHRESULT().Equals(e.ToHRESULT()),
			IConvertible c => Equals(c.ToInt32(null)),
			_ => base.Equals(obj)
		};

		/// <summary>Indicates whether the current object is equal to an <see cref="SocketError"/>.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(SocketError other) => (int)other == _value;

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(WSRESULT other) => other._value == _value;

		/// <summary>Gets the .NET <see cref="Exception"/> associated with the WSRESULT value and optionally adds the supplied message.</summary>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		/// <returns>The associated <see cref="Exception"/> or <c>null</c> if this WSRESULT is not a failure.</returns>
		[SecurityCritical, SecuritySafeCritical]
		public Exception GetException(string message = null) => _value switch
		{
			0 => null,
			SOCKET_ERROR => new SocketException((int)GetLastError()),
			_ => new SocketException(_value)
		};

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => _value;

		/// <summary>Gets the last error.</summary>
		/// <returns>The last error.</returns>
		[SecurityCritical]
		[System.Diagnostics.DebuggerStepThrough]
		public static WSRESULT GetLastError() => WSAGetLastError();

		/// <summary>
		/// If this <see cref="WSRESULT"/> represents a failure, throw the associated <see cref="Exception"/> with the optionally supplied message.
		/// </summary>
		/// <param name="message">The optional message to assign to the <see cref="Exception"/>.</param>
		[SecurityCritical]
		[SecuritySafeCritical]
		public void ThrowIfFailed(string message = null)
		{
			Exception exception = GetException(message);
			if (exception is not null)
				throw exception;
		}

		/// <summary>Converts this error to an <see cref="HRESULT"/>.</summary>
		/// <returns>An equivalent <see cref="HRESULT"/>.</returns>
		public HRESULT ToHRESULT() => HRESULT.HRESULT_FROM_WIN32(unchecked((uint)(_value == SOCKET_ERROR ? GetLastError()._value : _value)));

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => StaticFieldValueHash.TryGetFieldName<WSRESULT, int>(_value, out var err) ? err : ToHRESULT().ToString();

		TypeCode IConvertible.GetTypeCode() => _value.GetTypeCode();

		bool IConvertible.ToBoolean(IFormatProvider provider) => Succeeded;

		byte IConvertible.ToByte(IFormatProvider provider) => ((IConvertible)_value).ToByte(provider);

		char IConvertible.ToChar(IFormatProvider provider) => throw new NotSupportedException();

		DateTime IConvertible.ToDateTime(IFormatProvider provider) => throw new NotSupportedException();

		decimal IConvertible.ToDecimal(IFormatProvider provider) => ((IConvertible)_value).ToDecimal(provider);

		double IConvertible.ToDouble(IFormatProvider provider) => ((IConvertible)_value).ToDouble(provider);

		short IConvertible.ToInt16(IFormatProvider provider) => ((IConvertible)_value).ToInt16(provider);

		int IConvertible.ToInt32(IFormatProvider provider) => _value;

		long IConvertible.ToInt64(IFormatProvider provider) => ((IConvertible)_value).ToInt64(provider);

		sbyte IConvertible.ToSByte(IFormatProvider provider) => ((IConvertible)_value).ToSByte(provider);

		float IConvertible.ToSingle(IFormatProvider provider) => ((IConvertible)_value).ToSingle(provider);

		string IConvertible.ToString(IFormatProvider provider) => ToString();

		object IConvertible.ToType(Type conversionType, IFormatProvider provider) =>
			((IConvertible)_value).ToType(conversionType, provider);

		ushort IConvertible.ToUInt16(IFormatProvider provider) => ((IConvertible)unchecked((uint)_value)).ToUInt16(provider);

		uint IConvertible.ToUInt32(IFormatProvider provider) => unchecked((uint)_value);

		ulong IConvertible.ToUInt64(IFormatProvider provider) => ((IConvertible)unchecked((uint)_value)).ToUInt64(provider);

		/// <summary>A blocking operation was interrupted by a call to WSACancelBlockingCall.</summary>
		public const int WSAEINTR = 0x00002714;

		/// <summary>The file handle supplied is not valid.</summary>
		public const int WSAEBADF = 0x00002719;

		/// <summary>An attempt was made to access a socket in a way forbidden by its access permissions.</summary>
		public const int WSAEACCES = 0x0000271D;

		/// <summary>The system detected an invalid pointer address in attempting to use a pointer argument in a call.</summary>
		public const int WSAEFAULT = 0x0000271E;

		/// <summary>An invalid argument was supplied.</summary>
		public const int WSAEINVAL = 0x00002726;

		/// <summary>Too many open sockets.</summary>
		public const int WSAEMFILE = 0x00002728;

		/// <summary>A nonblocking socket operation could not be completed immediately.</summary>
		public const int WSAEWOULDBLOCK = 0x00002733;

		/// <summary>A blocking operation is currently executing.</summary>
		public const int WSAEINPROGRESS = 0x00002734;

		/// <summary>An operation was attempted on a nonblocking socket that already had an operation in progress.</summary>
		public const int WSAEALREADY = 0x00002735;

		/// <summary>An operation was attempted on something that is not a socket.</summary>
		public const int WSAENOTSOCK = 0x00002736;

		/// <summary>A required address was omitted from an operation on a socket.</summary>
		public const int WSAEDESTADDRREQ = 0x00002737;

		/// <summary>A message sent on a datagram socket was larger than the internal message buffer or some other network limit, or the buffer used to receive a datagram into was smaller than the datagram itself.</summary>
		public const int WSAEMSGSIZE = 0x00002738;

		/// <summary>A protocol was specified in the socket function call that does not support the semantics of the socket type requested.</summary>
		public const int WSAEPROTOTYPE = 0x00002739;

		/// <summary>An unknown, invalid, or unsupported option or level was specified in a getsockopt or setsockopt call.</summary>
		public const int WSAENOPROTOOPT = 0x0000273A;

		/// <summary>The requested protocol has not been configured into the system, or no implementation for it exists.</summary>
		public const int WSAEPROTONOSUPPORT = 0x0000273B;

		/// <summary>The support for the specified socket type does not exist in this address family.</summary>
		public const int WSAESOCKTNOSUPPORT = 0x0000273C;

		/// <summary>The attempted operation is not supported for the type of object referenced.</summary>
		public const int WSAEOPNOTSUPP = 0x0000273D;

		/// <summary>The protocol family has not been configured into the system or no implementation for it exists.</summary>
		public const int WSAEPFNOSUPPORT = 0x0000273E;

		/// <summary>An address incompatible with the requested protocol was used.</summary>
		public const int WSAEAFNOSUPPORT = 0x0000273F;

		/// <summary>Only one usage of each socket address (protocol/network address/port) is normally permitted.</summary>
		public const int WSAEADDRINUSE = 0x00002740;

		/// <summary>The requested address is not valid in its context.</summary>
		public const int WSAEADDRNOTAVAIL = 0x00002741;

		/// <summary>A socket operation encountered a dead network.</summary>
		public const int WSAENETDOWN = 0x00002742;

		/// <summary>A socket operation was attempted to an unreachable network.</summary>
		public const int WSAENETUNREACH = 0x00002743;

		/// <summary>The connection has been broken due to keep-alive activity detecting a failure while the operation was in progress.</summary>
		public const int WSAENETRESET = 0x00002744;

		/// <summary>An established connection was aborted by the software in your host machine.</summary>
		public const int WSAECONNABORTED = 0x00002745;

		/// <summary>An existing connection was forcibly closed by the remote host.</summary>
		public const int WSAECONNRESET = 0x00002746;

		/// <summary>An operation on a socket could not be performed because the system lacked sufficient buffer space or because a queue was full.</summary>
		public const int WSAENOBUFS = 0x00002747;

		/// <summary>A connect request was made on an already connected socket.</summary>
		public const int WSAEISCONN = 0x00002748;

		/// <summary>A request to send or receive data was disallowed because the socket is not connected and (when sending on a datagram socket using a sendto call) no address was supplied.</summary>
		public const int WSAENOTCONN = 0x00002749;

		/// <summary>A request to send or receive data was disallowed because the socket had already been shut down in that direction with a previous shutdown call.</summary>
		public const int WSAESHUTDOWN = 0x0000274A;

		/// <summary>Too many references to a kernel object.</summary>
		public const int WSAETOOMANYREFS = 0x0000274B;

		/// <summary>A connection attempt failed because the connected party did not properly respond after a period of time, or the established connection failed because the connected host failed to respond.</summary>
		public const int WSAETIMEDOUT = 0x0000274C;

		/// <summary>No connection could be made because the target machine actively refused it.</summary>
		public const int WSAECONNREFUSED = 0x0000274D;

		/// <summary>Cannot translate name.</summary>
		public const int WSAELOOP = 0x0000274E;

		/// <summary>Name or name component was too long.</summary>
		public const int WSAENAMETOOLONG = 0x0000274F;

		/// <summary>A socket operation failed because the destination host was down.</summary>
		public const int WSAEHOSTDOWN = 0x00002750;

		/// <summary>A socket operation was attempted to an unreachable host.</summary>
		public const int WSAEHOSTUNREACH = 0x00002751;

		/// <summary>Cannot remove a directory that is not empty.</summary>
		public const int WSAENOTEMPTY = 0x00002752;

		/// <summary>A Windows Sockets implementation might have a limit on the number of applications that can use it simultaneously.</summary>
		public const int WSAEPROCLIM = 0x00002753;

		/// <summary>Ran out of quota.</summary>
		public const int WSAEUSERS = 0x00002754;

		/// <summary>Ran out of disk quota.</summary>
		public const int WSAEDQUOT = 0x00002755;

		/// <summary>File handle reference is no longer available.</summary>
		public const int WSAESTALE = 0x00002756;

		/// <summary>Item is not available locally.</summary>
		public const int WSAEREMOTE = 0x00002757;

		/// <summary>WSAStartup cannot function at this time because the underlying system it uses to provide network services is currently unavailable.</summary>
		public const int WSASYSNOTREADY = 0x0000276B;

		/// <summary>The Windows Sockets version requested is not supported.</summary>
		public const int WSAVERNOTSUPPORTED = 0x0000276C;

		/// <summary>Either the application has not called WSAStartup, or WSAStartup failed.</summary>
		public const int WSANOTINITIALISED = 0x0000276D;

		/// <summary>Returned by WSARecv or WSARecvFrom to indicate that the remote party has initiated a graceful shutdown sequence.</summary>
		public const int WSAEDISCON = 0x00002775;

		/// <summary>No more results can be returned by WSALookupServiceNext.</summary>
		public const int WSAENOMORE = 0x00002776;

		/// <summary>A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.</summary>
		public const int WSAECANCELLED = 0x00002777;

		/// <summary>The procedure call table is invalid.</summary>
		public const int WSAEINVALIDPROCTABLE = 0x00002778;

		/// <summary>The requested service provider is invalid.</summary>
		public const int WSAEINVALIDPROVIDER = 0x00002779;

		/// <summary>The requested service provider could not be loaded or initialized.</summary>
		public const int WSAEPROVIDERFAILEDINIT = 0x0000277A;

		/// <summary>A system call that should never fail has failed.</summary>
		public const int WSASYSCALLFAILURE = 0x0000277B;

		/// <summary>No such service is known. The service cannot be found in the specified namespace.</summary>
		public const int WSASERVICE_NOT_FOUND = 0x0000277C;

		/// <summary>The specified class was not found.</summary>
		public const int WSATYPE_NOT_FOUND = 0x0000277D;

		/// <summary>No more results can be returned by WSALookupServiceNext.</summary>
		public const int WSA_E_NO_MORE = 0x0000277E;

		/// <summary>A call to WSALookupServiceEnd was made while this call was still processing. The call has been canceled.</summary>
		public const int WSA_E_CANCELLED = 0x0000277F;

		/// <summary>A database query failed because it was actively refused.</summary>
		public const int WSAEREFUSED = 0x00002780;

		/// <summary>No such host is known.</summary>
		public const int WSAHOST_NOT_FOUND = 0x00002AF9;

		/// <summary>This is usually a temporary error during host name resolution and means that the local server did not receive a response from an authoritative server.</summary>
		public const int WSATRY_AGAIN = 0x00002AFA;

		/// <summary>A nonrecoverable error occurred during a database lookup.</summary>
		public const int WSANO_RECOVERY = 0x00002AFB;

		/// <summary>The requested name is valid, but no data of the requested type was found.</summary>
		public const int WSANO_DATA = 0x00002AFC;

		/// <summary>At least one reserve has arrived.</summary>
		public const int WSA_QOS_RECEIVERS = 0x00002AFD;

		/// <summary>At least one path has arrived.</summary>
		public const int WSA_QOS_SENDERS = 0x00002AFE;

		/// <summary>There are no senders.</summary>
		public const int WSA_QOS_NO_SENDERS = 0x00002AFF;

		/// <summary>There are no receivers.</summary>
		public const int WSA_QOS_NO_RECEIVERS = 0x00002B00;

		/// <summary>Reserve has been confirmed.</summary>
		public const int WSA_QOS_REQUEST_CONFIRMED = 0x00002B01;

		/// <summary>Error due to lack of resources.</summary>
		public const int WSA_QOS_ADMISSION_FAILURE = 0x00002B02;

		/// <summary>Rejected for administrative reasons - bad credentials.</summary>
		public const int WSA_QOS_POLICY_FAILURE = 0x00002B03;

		/// <summary>Unknown or conflicting style.</summary>
		public const int WSA_QOS_BAD_STYLE = 0x00002B04;

		/// <summary>There is a problem with some part of the filterspec or provider-specific buffer in general.</summary>
		public const int WSA_QOS_BAD_OBJECT = 0x00002B05;

		/// <summary>There is a problem with some part of the flowspec.</summary>
		public const int WSA_QOS_TRAFFIC_CTRL_ERROR = 0x00002B06;

		/// <summary>General quality of serve (QOS) error.</summary>
		public const int WSA_QOS_GENERIC_ERROR = 0x00002B07;

		/// <summary>An invalid or unrecognized service type was found in the flowspec.</summary>
		public const int WSA_QOS_ESERVICETYPE = 0x00002B08;

		/// <summary>An invalid or inconsistent flowspec was found in the QOS structure.</summary>
		public const int WSA_QOS_EFLOWSPEC = 0x00002B09;

		/// <summary>Invalid QOS provider-specific buffer.</summary>
		public const int WSA_QOS_EPROVSPECBUF = 0x00002B0A;

		/// <summary>An invalid QOS filter style was used.</summary>
		public const int WSA_QOS_EFILTERSTYLE = 0x00002B0B;

		/// <summary>An invalid QOS filter type was used.</summary>
		public const int WSA_QOS_EFILTERTYPE = 0x00002B0C;

		/// <summary>An incorrect number of QOS FILTERSPECs were specified in the FLOWDESCRIPTOR.</summary>
		public const int WSA_QOS_EFILTERCOUNT = 0x00002B0D;

		/// <summary>An object with an invalid ObjectLength field was specified in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_EOBJLENGTH = 0x00002B0E;

		/// <summary>An incorrect number of flow descriptors was specified in the QOS structure.</summary>
		public const int WSA_QOS_EFLOWCOUNT = 0x00002B0F;

		/// <summary>An unrecognized object was found in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_EUNKOWNPSOBJ = 0x00002B10;

		/// <summary>An invalid policy object was found in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_EPOLICYOBJ = 0x00002B11;

		/// <summary>An invalid QOS flow descriptor was found in the flow descriptor list.</summary>
		public const int WSA_QOS_EFLOWDESC = 0x00002B12;

		/// <summary>An invalid or inconsistent flowspec was found in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_EPSFLOWSPEC = 0x00002B13;

		/// <summary>An invalid FILTERSPEC was found in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_EPSFILTERSPEC = 0x00002B14;

		/// <summary>An invalid shape discard mode object was found in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_ESDMODEOBJ = 0x00002B15;

		/// <summary>An invalid shaping rate object was found in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_ESHAPERATEOBJ = 0x00002B16;

		/// <summary>A reserved policy element was found in the QOS provider-specific buffer.</summary>
		public const int WSA_QOS_RESERVED_PETYPE = 0x00002B17;
	}
}