using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Vanara.Extensions;
using Vanara.PInvoke;
using Vanara.Security;
using static Vanara.PInvoke.WTSApi32;

namespace Vanara;

/// <summary>Represents a Windows session.</summary>
public class Session : INamedEntity
{
	private readonly SafeHWTSSERVER hServer;
	private WTS_SESSION_INFO_1 sessionInfo;

	internal Session(string target, in WTS_SESSION_INFO_1 info)
	{
		sessionInfo = info;
		//Id = new WindowsIdentity($"{info.pDomainName}\\{info.pUserName}");
		hServer = target is null ? SafeHWTSSERVER.Current : WTSOpenServerEx(target);
	}

	private Session() { }

	/// <summary>
	/// The network type and network address of the client. For more information, see WTS_CLIENT_ADDRESS. The IP address is offset by two
	/// bytes from the start of the Address member of the WTS_CLIENT_ADDRESS structure.
	/// </summary>
	public WTS_CLIENT_ADDRESS ClientAddress => QueryInfo<WTS_CLIENT_ADDRESS>(WTS_INFO_CLASS.WTSClientAddress);
	//{
	//	get
	//	{
	//		var ca =  QueryInfo<WTS_CLIENT_ADDRESS>(WTS_INFO_CLASS.WTSClientAddress);
	//		switch ((Ws2_32.ADDRESS_FAMILY)ca.AddressFamily)
	//		{
	//			case Ws2_32.ADDRESS_FAMILY.AF_INET:
	//				try { return IPAddress.Parse(string.Join(".", ca.Address.Skip(2).Take(4))); }
	//				catch { return null; }
	//			case Ws2_32.ADDRESS_FAMILY.AF_INET6:
	//				try { return new(ca.Address.Take(16).ToArray()); }
	//				catch { return null; }
	//			default:
	//				return new(ca.Address);
	//		}
	//	}
	//}

	/// <summary>A ULONG value that contains the build number of the client.</summary>
	public uint ClientBuildNumber => QueryInfo<uint>(WTS_INFO_CLASS.WTSClientBuildNumber);

	/// <summary>A string that contains the directory in which the client is installed.</summary>
	public string ClientDirectory => QueryInfo<string>(WTS_INFO_CLASS.WTSClientDirectory);

	/// <summary>Information about the display resolution of the client. For more information, see WTS_CLIENT_DISPLAY.</summary>
	public WTS_CLIENT_DISPLAY ClientDisplay => QueryInfo<WTS_CLIENT_DISPLAY>(WTS_INFO_CLASS.WTSClientDisplay);

	/// <summary>A string that contains the name of the client.</summary>
	public string ClientName => QueryInfo<string>(WTS_INFO_CLASS.WTSClientName);

	/// <summary>A USHORT client-specific product identifier.</summary>
	public ushort ClientProductId => QueryInfo<ushort>(WTS_INFO_CLASS.WTSClientProductId);

	/// <summary>A value that specifies information about the protocol type for the session.</summary>
	public SessionProtocolType ClientProtocolType => QueryInfo<SessionProtocolType>(WTS_INFO_CLASS.WTSClientProtocolType);

	/// <summary>The session's current connection state. For more information, see WTS_CONNECTSTATE_CLASS.</summary>
	public WTS_CONNECTSTATE_CLASS ConnectionState => QueryInfo<WTS_CONNECTSTATE_CLASS>(WTS_INFO_CLASS.WTSConnectState);

	/// <summary>
	/// The time of the most recent client connection to the session. This value is stored as a large integer that represents the number of
	/// 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
	/// </summary>
	public DateTime ConnectTime => DateTime.FromFileTimeUtc(SessionInfo.ConnectTimeUTC);

	/// <summary>
	/// The time that this structure was filled. This value is stored as a large integer that represents the number of 100-nanosecond
	/// intervals since January 1, 1601 Coordinated Universal Time.
	/// </summary>
	public DateTime CurrentTime => DateTime.FromFileTimeUtc(SessionInfo.CurrentTimeUTC);

	/// <summary>The device ID of the network adapter.</summary>
	public string DeviceId => ClientInfo.DeviceId;

	/// <summary>
	/// <para>Specifies whether the printer connected to the client is the default printer for the user.</para>
	/// <para>0</para>
	/// <para>The printer connected to the client is not the default printer for the user.</para>
	/// <para>1</para>
	/// <para>The printer connected to the client is the default printer for the user.</para>
	/// </summary>
	public bool DisableDefaultMainClientPrinter => ConfigInfo.fDisableDefaultMainClientPrinter;

	/// <summary>
	/// <para>Specifies whether the client can use printer redirection.</para>
	/// <para>0</para>
	/// <para>Enable client printer redirection.</para>
	/// <para>1</para>
	/// <para>Disable client printer redirection.</para>
	/// </summary>
	public bool DisablePrinterRedirection => ConfigInfo.fDisablePrinterRedirection;

	/// <summary>
	/// The time of the most recent client disconnection to the session. This value is stored as a large integer that represents the number
	/// of 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
	/// </summary>
	public DateTime DisconnectTime => DateTime.FromFileTimeUtc(SessionInfo.DisconnectTimeUTC);

	/// <summary>
	/// A string that contains the domain name of the user who is logged on to the session. If no user is logged on to the session, the
	/// string contains <see langword="null"/>.
	/// </summary>
	public string DomainName => sessionInfo.pDomainName;

	/// <summary>
	/// A string that contains the name of the farm that the virtual machine is joined to. If the session is not running on a virtual machine
	/// that is joined to a farm, the string contains <see langword="null"/>.
	/// </summary>
	public string FarmName => sessionInfo.pFarmName;

	/// <summary>
	/// A string that contains the name of the computer that the session is running on. If the session is running directly on an RD Session
	/// Host server or RD Virtualization Host server, the string contains <see langword="null"/>. If the session is running on a virtual
	/// machine, the string contains the name of the virtual machine.
	/// </summary>
	public string HostName => sessionInfo.pHostName;

	/// <summary>
	/// The number of bytes of uncompressed Remote Desktop Protocol (RDP) data sent from the client to the server since the client connected.
	/// </summary>
	public uint IncomingBytes => SessionInfo.IncomingBytes;

	/// <summary>The number of bytes of compressed RDP data sent from the client to the server since the client connected.</summary>
	public uint IncomingCompressedBytes => SessionInfo.IncomingCompressedBytes;

	/// <summary>The number of frames of RDP data sent from the client to the server since the client connected.</summary>
	public uint IncomingFrames => SessionInfo.IncomingFrames;

	/// <summary>A string that contains the name of the initial program that Remote Desktop Services runs when the user logs on.</summary>
	public string InitialProgram { get { try { return QueryInfo<string>(WTS_INFO_CLASS.WTSInitialProgram); } catch { return string.Empty; } } }

	/// <summary>
	/// Determines whether the current session is a remote session. The WTSQuerySessionInformation function returns a value of TRUE to
	/// indicate that the current session is a remote session, and FALSE to indicate that the current session is a local session. This value
	/// can only be used for the local machine, so the hServer parameter of the WTSQuerySessionInformation function must contain
	/// WTS_CURRENT_SERVER_HANDLE. Windows Server 2008 and Windows Vista: This value is not supported.
	/// </summary>
	public bool IsRemoteSession => WTSQuerySessionInformation(hServer, SessionId, WTS_INFO_CLASS.WTSIsRemoteSession, out _, out _);

	/// <summary>
	/// The time of the last user input in the session. This value is stored as a large integer that represents the number of 100-nanosecond
	/// intervals since January 1, 1601 Coordinated Universal Time.
	/// </summary>
	public DateTime LastInputTime => DateTime.FromFileTimeUtc(SessionInfo.LastInputTimeUTC);

	/// <summary>
	/// The time that the user logged on to the session. This value is stored as a large integer that represents the number of 100-nanosecond
	/// intervals since January 1, 1601 Coordinated Universal Time (Greenwich Mean Time).
	/// </summary>
	public DateTime LogonTime => DateTime.FromFileTimeUtc(SessionInfo.LogonTimeUTC);

	/// <summary>A string that contains the name of this session. For example, "services", "console", or "RDP-Tcp#0".</summary>
	public string Name => sessionInfo.pSessionName;

	/// <summary>The number of bytes of uncompressed RDP data sent from the server to the client since the client connected.</summary>
	public uint OutgoingBytes => SessionInfo.OutgoingBytes;

	/// <summary>The number of bytes of compressed RDP data sent from the server to the client since the client connected.</summary>
	public uint OutgoingCompressedBytes => SessionInfo.OutgoingCompressedBytes;

	/// <summary>The number of frames of RDP data sent from the server to the client since the client connected.</summary>
	public uint OutgoingFrames => SessionInfo.OutgoingFrames;

	/// <summary>
	/// A WTS_SESSION_ADDRESS structure that contains the IPv4 address assigned to the session. If the session does not have a virtual IP
	/// address, the WTSQuerySessionInformation function returns ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows
	/// Vista: This value is not supported.
	/// </summary>
	public IPAddress SessionAddressV4
	{
		get
		{
			try { return new(QueryInfo<WTS_SESSION_ADDRESS>(WTS_INFO_CLASS.WTSSessionAddressV4).Address.Take(4).ToArray()); }
			catch { return null; }
		}
	}

	/// <summary>
	/// <para>The state of the session. This can be one or more of the following values.</para>
	/// <para>WTS_SESSIONSTATE_UNKNOWN (4294967295 (0xFFFFFFFF))</para>
	/// <para>The session state is not known.</para>
	/// <para>WTS_SESSIONSTATE_LOCK (0 (0x0))</para>
	/// <para>The session is locked.</para>
	/// <para>WTS_SESSIONSTATE_UNLOCK (1 (0x1))</para>
	/// <para>The session is unlocked.</para>
	/// <para>
	/// <c>Windows Server 2008 R2 and Windows 7:</c> Due to a code defect, the usage of the <c>WTS_SESSIONSTATE_LOCK</c> and
	/// <c>WTS_SESSIONSTATE_UNLOCK</c> flags is reversed. That is, <c>WTS_SESSIONSTATE_LOCK</c> indicates that the session is unlocked, and
	/// <c>WTS_SESSIONSTATE_UNLOCK</c> indicates the session is locked.
	/// </para>
	/// </summary>
	public WTS_SESSIONSTATE SessionFlags => SessionInfoEx.Data.WTSInfoExLevel1.SessionFlags;

	/// <summary>A session identifier assigned by the RD Session Host server, RD Virtualization Host server, or virtual machine.</summary>
	public uint SessionId => sessionInfo.SessionId;

	/// <summary>
	/// <para>
	/// The remote control setting. Remote control allows a user to remotely monitor the on-screen operations of another user. This member
	/// can be one of the following values.
	/// </para>
	/// <para>0</para>
	/// <para>Remote control is disabled.</para>
	/// <para>1</para>
	/// <para>The user of remote control has full control of the user's session, with the user's permission.</para>
	/// <para>2</para>
	/// <para>The user of remote control has full control of the user's session; the user's permission is not required.</para>
	/// <para>3</para>
	/// <para>
	/// The user of remote control can view the session remotely, with the user's permission; the remote user cannot actively control the session.
	/// </para>
	/// <para>4</para>
	/// <para>
	/// The user of remote control can view the session remotely but not actively control the session; the user's permission is not required.
	/// </para>
	/// </summary>
	public uint ShadowSettings => ConfigInfo.ShadowSettings;

	/// <summary>
	/// Gets a string that specifies the DNS or NetBIOS name of the remote server on which the local group resides. If this value is <see
	/// langword="null"/>, the local computer is assumed.
	/// </summary>
	/// <value>The target server.</value>
	public string Target { get; }

	/// <summary>
	/// A string that contains the name of the user who is logged on to the session. If no user is logged on to the session, the string
	/// contains <see langword="null"/>.
	/// </summary>
	public string UserName => sessionInfo.pUserName;

	/// <summary>A string that contains the name of the Remote Desktop Services session.</summary>
	public string WinStationName => QueryInfo<string>(WTS_INFO_CLASS.WTSWinStationName);

	/// <summary>A string that contains the default directory used when launching the initial program.</summary>
	public string WorkingDirectory => QueryInfo<string>(WTS_INFO_CLASS.WTSWorkingDirectory);

	internal WindowsIdentity Id { get; private set; }

	/// <summary>Information about a Remote Desktop Connection (RDC) client. For more information, see WTSCLIENT.</summary>
	private WTSCLIENT ClientInfo => QueryInfo<WTSCLIENT>(WTS_INFO_CLASS.WTSClientInfo);

	/// <summary>
	/// A WTSCONFIGINFO structure that contains information about the configuration of a RD Session Host server. Windows Server 2008 and
	/// Windows Vista: This value is not supported.
	/// </summary>
	private WTSCONFIGINFO ConfigInfo => QueryInfo<WTSCONFIGINFO>(WTS_INFO_CLASS.WTSConfigInfo);

	/// <summary>
	/// information about a session on a RD Session Host server. For more information, see WTSINFOEX. Windows Server 2008 and Windows Vista:
	/// This value is not supported.
	/// </summary>
	private WTSINFO SessionInfo => QueryInfo<WTSINFO>(WTS_INFO_CLASS.WTSSessionInfo);

	/// <summary>
	/// Extended information about a session on a RD Session Host server. For more information, see WTSINFOEX. Windows Server 2008 and
	/// Windows Vista: This value is not supported.
	/// </summary>
	private WTSINFOEX SessionInfoEx => QueryInfo<WTSINFOEX>(WTS_INFO_CLASS.WTSSessionInfoEx);

	/// <summary>
	/// Disconnects the logged-on user from this session without closing the session. If the user
	/// subsequently logs on to the same Remote Desktop Session Host (RD Session Host) server, the user is reconnected to the same session.
	/// </summary>
	/// <param name="wait">
	/// Indicates whether the operation is synchronous. Specify <c>TRUE</c> to wait for the operation to complete, or <c>FALSE</c> to
	/// return immediately.
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To be able to disconnect another user's session, you need to have the Disconnect permission. For more information, see Remote
	/// Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// <para>
	/// To disconnect sessions running on a virtual machine hosted on a RD Virtualization Host server, you must be a member of the
	/// Administrators group on the RD Virtualization Host server.
	/// </para>
	/// </remarks>
	public bool Disconnect(bool wait) => WTSDisconnectSession(hServer, SessionId, wait);

	/// <summary>Logs off a specified Remote Desktop Services session.</summary>
	/// <param name="wait">
	/// <para>Indicates whether the operation is synchronous.</para>
	/// <para>If wait is <c>TRUE</c>, the function returns when the session is logged off.</para>
	/// <para>
	/// If wait is <c>FALSE</c>, the function returns immediately. To verify that the session has been logged off, specify the session
	/// identifier in a call to the WTSQuerySessionInformation function. <c>WTSQuerySessionInformation</c> returns zero if the session
	/// is logged off.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To be able to log off another user's session, you need to have the Reset permission. For more information, see Remote Desktop
	/// Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// <para>
	/// To log off sessions running on a virtual machine hosted on a RD Virtualization Host server, you must be a member of the
	/// Administrators group on the RD Virtualization Host server.
	/// </para>
	/// </remarks>
	public bool Logoff(bool wait) => WTSLogoffSession(hServer, SessionId, wait);

	/// <summary>Displays a message box on the client desktop of a specified Remote Desktop Services session.</summary>
	/// <param name="title">A pointer to a null-terminated string for the title bar of the message box.</param>
	/// <param name="message">A pointer to a null-terminated string that contains the message to display.</param>
	/// <param name="style">
	/// The contents and behavior of the message box. This value is typically <c>MB_OK</c>. For a complete list of values, see the uType
	/// parameter of the MessageBox function.
	/// </param>
	/// <param name="timeout">
	/// The time, in seconds, that the <c>WTSSendMessage</c> function waits for the user's response. If the user does not respond within the
	/// time-out interval, the response parameter returns <c>IDTIMEOUT</c>. If the timeout parameter is zero, <c>WTSSendMessage</c> waits
	/// indefinitely for the user to respond.
	/// </param>
	/// <param name="wait">
	/// <para>
	/// If <c>TRUE</c>, <c>WTSSendMessage</c> does not return until the user responds or the time-out interval elapses. If the timeout
	/// parameter is zero, the function does not return until the user responds.
	/// </para>
	/// <para>
	/// If <c>FALSE</c>, the function returns immediately and the response parameter returns <c>IDASYNC</c>. Use this method for simple
	/// information messages (such as print job–notification messages) that do not need to return the user's response to the calling program.
	/// </para>
	/// </param>
	/// <param name="response">
	/// <para>A pointer to a variable that receives the user's response, which can be one of the following values.</para>
	/// <para>IDABORT (3)</para>
	/// <para><c>Abort</c></para>
	/// <para>IDCANCEL (2)</para>
	/// <para><c>Cancel</c></para>
	/// <para>IDCONTINUE (11)</para>
	/// <para><c>Continue</c></para>
	/// <para>IDIGNORE (5)</para>
	/// <para><c>Ignore</c></para>
	/// <para>IDNO (7)</para>
	/// <para><c>No</c></para>
	/// <para>IDOK (1)</para>
	/// <para><c>OK</c></para>
	/// <para>IDRETRY (4)</para>
	/// <para><c>Retry</c></para>
	/// <para>IDTRYAGAIN (10)</para>
	/// <para><c>Try Again</c></para>
	/// <para>IDYES (6)</para>
	/// <para><c>Yes</c></para>
	/// <para>IDASYNC (32001 (0x7D01))</para>
	/// <para>The wait parameter was <c>FALSE</c>, so the function returned without waiting for a response.</para>
	/// <para>IDTIMEOUT (32000 (0x7D00))</para>
	/// <para>The wait parameter was <c>TRUE</c> and the time-out interval elapsed.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	public bool SendMessage(string title, string message, User32.MB_FLAGS style, TimeSpan timeout, bool wait, out User32.MB_RESULT response)
	{
		var ret = WTSSendMessage(hServer, SessionId, title, StringHelper.GetByteCount(title), message, StringHelper.GetByteCount(message), (uint)style,
			(uint)timeout.TotalSeconds, out var resp, wait);
		response = (User32.MB_RESULT)resp;
		return ret;
	}

	private T QueryInfo<T>(WTS_INFO_CLASS c)
	{
		Win32Error.ThrowLastErrorIfFalse(WTSQuerySessionInformation(hServer, SessionId, c, out var mem, out var sz));
		return typeof(T) == typeof(string) ? (T)(object)mem.ToString(sz) : mem.ToStructure<T>(sz);
	}
}

/// <summary>A collection of Windows sessions for the specified target computer.</summary>
public class Sessions : IReadOnlyDictionary<uint, Session>
{
	private readonly SafeHWTSSERVER hServer;
	private readonly WindowsIdentity identity;
	private readonly string target = null;

	/// <summary>Initializes a new instance of the <see cref="SharedDevices"/> class.</summary>
	/// <param name="serverName">Name of the computer from which to retrieve and manage the shared devices.</param>
	/// <param name="accessIdentity">
	/// The Windows identity used to access the shared device information. If this value <see langword="null"/>, the current identity is used.
	/// </param>
	public Sessions(string serverName = null, WindowsIdentity accessIdentity = null) : base()
	{
		target = serverName;
		identity = accessIdentity ?? WindowsIdentity.GetCurrent();
		hServer = target is null ? SafeHWTSSERVER.Current : WTSOpenServerEx(target);
	}

	internal Sessions(Computer computer) : this(computer.Target, computer.Identity)
	{
	}

	/// <summary>Gets the number of elements in the collection.</summary>
	public int Count => EnumSessions().Length;

	/// <summary>Gets an <see cref="ICollection{TValue}"/> containing the keys in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>An <see cref="ICollection{TValue}"/> containing the keys in the object that implements <see cref="IDictionary{TKey, TValue}"/>.</value>
	public IEnumerable<uint> Keys => Array.ConvertAll(EnumSessions(), i => i.SessionId);

	/// <summary>Gets an <see cref="ICollection{TValue}"/> containing the values in the <see cref="IDictionary{TKey, TValue}"/>.</summary>
	/// <value>An <see cref="ICollection{TValue}"/> containing the values in the object that implements <see cref="IDictionary{TKey, TValue}"/>.</value>
	public IEnumerable<Session> Values => Array.ConvertAll(EnumSessions(), i => new Session(target, i));

	/// <summary>Gets the <see cref="Session"/> with the specified key.</summary>
	/// <value>The <see cref="Session"/>.</value>
	/// <param name="key">The key.</param>
	/// <returns>The <see cref="Session"/> instance with the specified session id.</returns>
	/// <exception cref="System.ArgumentOutOfRangeException">key</exception>
	public Session this[uint key] => TryGetValue(key, out var sess) ? sess : throw new ArgumentOutOfRangeException(nameof(key));

	/// <summary>Determines whether the read-only dictionary contains an element that has the specified key.</summary>
	/// <param name="key">The key to locate.</param>
	/// <returns><see langword="true"/> if the read-only dictionary contains an element that has the specified key; otherwise, <see langword="false"/>.</returns>
	public bool ContainsKey(uint key) => EnumSessions().Any(s => Equals(key, s.SessionId));

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>An enumerator that can be used to iterate through the collection.</returns>
	public IEnumerator<KeyValuePair<uint, Session>> GetEnumerator() => EnumSessions().ToDictionary(i => i.SessionId, i => new Session(target, i)).GetEnumerator();

	/// <summary>Gets the value associated with the specified key.</summary>
	/// <param name="key">The key whose value to get.</param>
	/// <param name="value">
	/// When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type
	/// of the <paramref name="value"/> parameter. This parameter is passed uninitialized.
	/// </param>
	/// <returns>
	/// <see langword="true"/> if the <see cref="T:System.Collections.Generic.IDictionary`2"/> contains an element with the key; otherwise,
	/// <see langword="false"/>.
	/// </returns>
	public bool TryGetValue(uint key, out Session value)
	{
		var si = EnumSessions().FirstOrDefault(s => Equals(key, s.SessionId));
		if (si.SessionId == 0)
		{
			value = null;
			return false;
		}
		value = new Session(target, si);
		return true;
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	private WTS_SESSION_INFO_1[] EnumSessions() => identity.Run(() => { Win32Error.ThrowLastErrorIfFalse(WTSEnumerateSessionsEx(hServer, out var sessions)); return sessions; });
}