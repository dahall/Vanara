using System.Diagnostics.CodeAnalysis;

namespace Vanara.PInvoke;

/// <summary>Items from the WTSApi32.dll</summary>
public static partial class WTSApi32
{
	/// <summary>A session value the indicates all WTS sessions.</summary>
	public const uint WTS_ANY_SESSION = unchecked((uint)-2);

	/// <summary>
	/// To work with sessions running on virtual machines on the RD Virtualization Host server on which the calling application is
	/// running, specify WTS_CURRENT_SERVER_NAME for the pServerName parameter.
	/// </summary>
	public const string? WTS_CURRENT_SERVER_NAME = null;

	/// <summary>Indicates the RD Session Host server on which your application is running.</summary>
	public static SafeHWTSSERVER WTS_CURRENT_SERVER => SafeHWTSSERVER.Current;

	/// <summary>Indicates the RD Session Host server on which your application is running.</summary>
	public static SafeHWTSSERVER WTS_CURRENT_SERVER_HANDLE => SafeHWTSSERVER.Current;

	/// <summary>Specifies the current session (SessionId)</summary>
	public const uint WTS_CURRENT_SESSION = unchecked((uint)-1);

	private const int CLIENTADDRESS_LENGTH = 30;
	private const int CLIENTNAME_LENGTH = 20;
	private const int DOMAIN_LENGTH = 17;
	private const string Lib_WTSApi32 = "wtsapi32.dll";
	private const int MAX_PATH = 260;
	private const int USERNAME_LENGTH = 20;
	private const int WINSTATIONNAME_LENGTH = 32;
	private const int WTS_COMMENT_LENGTH = 60;
	private const int WTS_DRIVE_LENGTH = 3;

	/// <summary>The virtual modifier that represents the key to press to stop remote control of the session.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSStartRemoteControlSessionA")]
	[Flags]
	public enum REMOTECONTROL_HOTKEY
	{
		/// <summary>The SHIFT key.</summary>
		REMOTECONTROL_KBDSHIFT_HOTKEY = 0x1,

		/// <summary>The CTRL key.</summary>
		REMOTECONTROL_KBDCTRL_HOTKEY = 0x2,

		/// <summary>The ALT key.</summary>
		REMOTECONTROL_KBDALT_HOTKEY = 0x4,
	}

	/// <summary>A <see cref="WTS_INFO_CLASS.WTSClientProtocolType"/> return value indicating the session protocol type.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelOpenEx")]
	public enum SessionProtocolType : ushort
	{
		/// <summary>The console session.</summary>
		Console = 0,

		/// <summary>This value is retained for legacy purposes.</summary>
		Legacy = 1,

		/// <summary>The RDP protocol.</summary>
		RDP = 2
	}

	/// <summary>Options for <c>WTSVirtualChannelOpenEx</c>.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelOpenEx")]
	[Flags]
	public enum WTS_CHANNEL_OPTION
	{
		/// <summary>Open the channel as a DVC.</summary>
		WTS_CHANNEL_OPTION_DYNAMIC = 0x00000001,

		/// <summary>
		/// Low priority. The data will be sent on both sides with low priority. Use this priority level for block transfers of all
		/// sizes, where the transfer speed is not important. In almost all (95%) cases, the channel should be opened with this flag.
		/// </summary>
		WTS_CHANNEL_OPTION_DYNAMIC_PRI_LOW = 0x00000000,

		/// <summary>
		/// Medium priority. Use this priority level to send short control messages that must have priority over the data in the low
		/// priority channels.
		/// </summary>
		WTS_CHANNEL_OPTION_DYNAMIC_PRI_MED = 0x00000002,

		/// <summary>
		/// High priority. Use this priority level for data that is critical and directly affects the user experience. The transfer size
		/// may vary. Display data falls into this category.
		/// </summary>
		WTS_CHANNEL_OPTION_DYNAMIC_PRI_HIGH = 0x00000004,

		/// <summary>
		/// Real-time priority. Use this priority level only in cases where the data transfer is absolutely critical. The data transfer
		/// size should be limited to a few hundred bytes per message.
		/// </summary>
		WTS_CHANNEL_OPTION_DYNAMIC_PRI_REAL = 0x00000006,

		/// <summary>
		/// Disables compression for this DVC. You must specify this value in combination with the <c>WTS_CHANNEL_OPTION_DYNAMIC</c> value.
		/// </summary>
		WTS_CHANNEL_OPTION_DYNAMIC_NO_COMPRESS = 0x00000008
	}

	/// <summary>
	/// Contains values that indicate the type of user configuration information to set or retrieve in a call to the WTSQueryUserConfig
	/// and WTSSetUserConfig functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_config_class typedef enum _WTS_CONFIG_CLASS {
	// WTSUserConfigInitialProgram, WTSUserConfigWorkingDirectory, WTSUserConfigfInheritInitialProgram,
	// WTSUserConfigfAllowLogonTerminalServer, WTSUserConfigTimeoutSettingsConnections, WTSUserConfigTimeoutSettingsDisconnections,
	// WTSUserConfigTimeoutSettingsIdle, WTSUserConfigfDeviceClientDrives, WTSUserConfigfDeviceClientPrinters,
	// WTSUserConfigfDeviceClientDefaultPrinter, WTSUserConfigBrokenTimeoutSettings, WTSUserConfigReconnectSettings,
	// WTSUserConfigModemCallbackSettings, WTSUserConfigModemCallbackPhoneNumber, WTSUserConfigShadowingSettings,
	// WTSUserConfigTerminalServerProfilePath, WTSUserConfigTerminalServerHomeDir, WTSUserConfigTerminalServerHomeDirDrive,
	// WTSUserConfigfTerminalServerRemoteHomeDir, WTSUserConfigUser } WTS_CONFIG_CLASS;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NE:wtsapi32._WTS_CONFIG_CLASS")]
	public enum WTS_CONFIG_CLASS
	{
		/// <summary>
		/// A null-terminated string that contains the path of the initial program that Remote Desktop Services runs when the user logs
		/// on.If the WTSUserConfigfInheritInitialProgram value is 1, the initial program can be any program specified by the client.
		/// </summary>
		WTSUserConfigInitialProgram,

		/// <summary>A null-terminated string that contains the path of the working directory for the initial program.</summary>
		WTSUserConfigWorkingDirectory,

		/// <summary>A value that indicates whether the client can specify the initial program.</summary>
		WTSUserConfigfInheritInitialProgram,

		/// <summary>A value that indicates whether the user account is permitted to log on to an RD Session Host server.</summary>
		WTSUserConfigfAllowLogonTerminalServer,

		/// <summary>
		/// A DWORD value that specifies the maximum connection duration, in milliseconds. One minute before the connection time-out
		/// interval expires, the user is notified of the pending disconnection. The user's session is disconnected or terminated
		/// depending on the WTSUserConfigBrokenTimeoutSettings value. Every time the user logs on, the timer is reset. A value of zero
		/// indicates that the connection timer is disabled.
		/// </summary>
		WTSUserConfigTimeoutSettingsConnections,

		/// <summary>
		/// A DWORD value that specifies the maximum duration, in milliseconds, that an RD Session Host server retains a disconnected
		/// session before the logon is terminated. A value of zero indicates that the disconnection timer is disabled.
		/// </summary>
		WTSUserConfigTimeoutSettingsDisconnections,

		/// <summary>
		/// A DWORD value that specifies the maximum idle time, in milliseconds. If there is no keyboard or mouse activity for the
		/// specified interval, the user's session is disconnected or terminated depending on the WTSUserConfigBrokenTimeoutSettings
		/// value. A value of zero indicates that the idle timer is disabled.
		/// </summary>
		WTSUserConfigTimeoutSettingsIdle,

		/// <summary>
		/// This constant currently is not used by Remote Desktop Services.A value that indicates whether the RD Session Host server
		/// automatically reestablishes client drive mappings at logon.
		/// </summary>
		WTSUserConfigfDeviceClientDrives,

		/// <summary>
		/// RDP 5.0 and later clients: A value that indicates whether the RD Session Host server automatically reestablishes client
		/// printer mappings at logon.
		/// </summary>
		WTSUserConfigfDeviceClientPrinters,

		/// <summary>RDP 5.0 and later clients: A value that indicates whether the client printer is the default printer.</summary>
		WTSUserConfigfDeviceClientDefaultPrinter,

		/// <summary>
		/// A value that indicates what happens when the connection or idle timers expire or when a connection is lost due to a
		/// connection error.
		/// </summary>
		WTSUserConfigBrokenTimeoutSettings,

		/// <summary>A value that indicates how a disconnected session for this user can be reconnected.</summary>
		WTSUserConfigReconnectSettings,

		/// <summary>
		/// This constant currently is not used by Remote Desktop Services.A value that indicates the configuration for dial-up
		/// connections in which the RD Session Host server stops responding and then calls back the client to establish the connection.
		/// </summary>
		WTSUserConfigModemCallbackSettings,

		/// <summary>
		/// This constant currently is not used by Remote Desktop Services.A null-terminated string that contains the phone number to
		/// use for callback connections.
		/// </summary>
		WTSUserConfigModemCallbackPhoneNumber,

		/// <summary>
		/// RDP 5.0 and later clients: A value that indicates whether the user session can be shadowed. Shadowing allows a user to
		/// remotely monitor the on-screen operations of another user.
		/// </summary>
		WTSUserConfigShadowingSettings,

		/// <summary>
		/// A null-terminated string that contains the path of the user's profile for RD Session Host server logon. The directory the
		/// path identifies must be created manually, and must exist prior to the logon. WTSSetUserConfig will not create the directory
		/// if it does not already exist.
		/// </summary>
		WTSUserConfigTerminalServerProfilePath,

		/// <summary>
		/// A null-terminated string that contains the path of the user's root directory for RD Session Host server logon. This string
		/// can specify a local path or a UNC path (\ComputerName\Share\Path). For more information, see WTSUserConfigfTerminalServerRemoteHomeDir.
		/// </summary>
		WTSUserConfigTerminalServerHomeDir,

		/// <summary>
		/// A null-terminated string that contains a drive name (a drive letter followed by a colon) to which the UNC path specified in
		/// the WTSUserConfigTerminalServerHomeDir string is mapped. For more information, see WTSUserConfigfTerminalServerRemoteHomeDir.
		/// </summary>
		WTSUserConfigTerminalServerHomeDirDrive,

		/// <summary>
		/// A value that indicates whether the user's root directory for RD Session Host server logon is a local path or a mapped drive
		/// letter. Note that this value cannot be used with WTSSetUserConfig.
		/// </summary>
		WTSUserConfigfTerminalServerRemoteHomeDir,

		/// <summary>
		/// A WTSUSERCONFIG structure that contains configuration data for the session. Windows Server 2008 and Windows Vista: This
		/// value is not supported.
		/// </summary>
		WTSUserConfigUser,
	}

	/// <summary>
	/// Specifies the source of configuration information returned by the WTSQueryUserConfig function. This enumeration type is used in
	/// the WTSUSERCONFIG structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_config_source typedef enum _WTS_CONFIG_SOURCE {
	// WTSUserConfigSourceSAM } WTS_CONFIG_SOURCE;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NE:wtsapi32._WTS_CONFIG_SOURCE")]
	public enum WTS_CONFIG_SOURCE
	{
		/// <summary>The configuration information came from the Security Accounts Manager (SAM) database.</summary>
		WTSUserConfigSourceSAM,
	}

	/// <summary>Specifies the connection state of a Remote Desktop Services session.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_connectstate_class typedef enum
	// _WTS_CONNECTSTATE_CLASS { WTSActive, WTSConnected, WTSConnectQuery, WTSShadow, WTSDisconnected, WTSIdle, WTSListen, WTSReset,
	// WTSDown, WTSInit } WTS_CONNECTSTATE_CLASS;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NE:wtsapi32._WTS_CONNECTSTATE_CLASS")]
	public enum WTS_CONNECTSTATE_CLASS
	{
		/// <summary>
		/// A user is logged on to the WinStation. This state occurs when a user is signed in and actively connected to the device.
		/// </summary>
		WTSActive,

		/// <summary>The WinStation is connected to the client.</summary>
		WTSConnected,

		/// <summary>The WinStation is in the process of connecting to the client.</summary>
		WTSConnectQuery,

		/// <summary>The WinStation is shadowing another WinStation.</summary>
		WTSShadow,

		/// <summary>
		/// The WinStation is active but the client is disconnected. This state occurs when a user is signed in but not actively
		/// connected to the device, such as when the user has chosen to exit to the lock screen.
		/// </summary>
		WTSDisconnected,

		/// <summary>The WinStation is waiting for a client to connect.</summary>
		WTSIdle,

		/// <summary>
		/// The WinStation is listening for a connection. A listener session waits for requests for new client connections. No user is
		/// logged on a listener session. A listener session cannot be reset, shadowed, or changed to a regular client session.
		/// </summary>
		WTSListen,

		/// <summary>The WinStation is being reset.</summary>
		WTSReset,

		/// <summary>The WinStation is down due to an error.</summary>
		WTSDown,

		/// <summary>The WinStation is initializing.</summary>
		WTSInit,
	}

	/// <summary>Bitmask that specifies the set of events to wait for.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSWaitSystemEvent")]
	[Flags]
	public enum WTS_EVENT : uint
	{
		/// <summary>The wait terminated because of a <c>WTSWaitSystemEvent</c> call with <c>WTS_EVENT_FLUSH</c>.</summary>
		WTS_EVENT_NONE = 0x00000000,

		/// <summary>A new WinStation was created.</summary>
		WTS_EVENT_CREATE = 0x00000001,

		/// <summary>An existing WinStation was deleted.</summary>
		WTS_EVENT_DELETE = 0x00000002,

		/// <summary>An existing WinStation was renamed.</summary>
		WTS_EVENT_RENAME = 0x00000004,

		/// <summary>A client connected to a WinStation.</summary>
		WTS_EVENT_CONNECT = 0x00000008,

		/// <summary>A client disconnected from a WinStation.</summary>
		WTS_EVENT_DISCONNECT = 0x00000010,

		/// <summary>A user logged on to the system from either the Remote Desktop Services console or from a client WinStation.</summary>
		WTS_EVENT_LOGON = 0x00000020,

		/// <summary>A user logged off from either the Remote Desktop Services console or from a client WinStation.</summary>
		WTS_EVENT_LOGOFF = 0x00000040,

		/// <summary>
		/// A WinStation connection state changed. For a list of connection states, see the WTS_CONNECTSTATE_CLASS enumeration type.
		/// </summary>
		WTS_EVENT_STATECHANGE = 0x00000080,

		/// <summary>
		/// The Remote Desktop Services' license state changed. This occurs when a license is added or deleted using License Manager.
		/// </summary>
		WTS_EVENT_LICENSE = 0x00000100,

		/// <summary>Wait for any event type.</summary>
		WTS_EVENT_ALL = 0x7fffffff,

		/// <summary>Cause all pending <c>WTSWaitSystemEvent</c> calls on the specified RD Session Host server handle to return.</summary>
		WTS_EVENT_FLUSH = 0x80000000,
	}

	/// <summary>
	/// Contains values that indicate the type of session information to retrieve in a call to the WTSQuerySessionInformation function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_info_class typedef enum _WTS_INFO_CLASS {
	// WTSInitialProgram, WTSApplicationName, WTSWorkingDirectory, WTSOEMId, WTSSessionId, WTSUserName, WTSWinStationName,
	// WTSDomainName, WTSConnectState, WTSClientBuildNumber, WTSClientName, WTSClientDirectory, WTSClientProductId, WTSClientHardwareId,
	// WTSClientAddress, WTSClientDisplay, WTSClientProtocolType, WTSIdleTime, WTSLogonTime, WTSIncomingBytes, WTSOutgoingBytes,
	// WTSIncomingFrames, WTSOutgoingFrames, WTSClientInfo, WTSSessionInfo, WTSSessionInfoEx, WTSConfigInfo, WTSValidationInfo,
	// WTSSessionAddressV4, WTSIsRemoteSession } WTS_INFO_CLASS;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NE:wtsapi32._WTS_INFO_CLASS")]
	public enum WTS_INFO_CLASS
	{
		/// <summary>
		/// A null-terminated string that contains the name of the initial program that Remote Desktop Services runs when the user logs on.
		/// </summary>
		[CorrespondingType(typeof(string))]
		WTSInitialProgram,

		/// <summary>
		/// A null-terminated string that contains the published name of the application that the session is running.Windows Server 2008
		/// R2, Windows 7, Windows Server 2008 and Windows Vista: This value is not supported
		/// </summary>
		[CorrespondingType(typeof(string))]
		WTSApplicationName,

		/// <summary>A null-terminated string that contains the default directory used when launching the initial program.</summary>
		[CorrespondingType(typeof(string))]
		WTSWorkingDirectory,

		/// <summary>This value is not used.</summary>
		WTSOEMId,

		/// <summary>A ULONG value that contains the session identifier.</summary>
		[CorrespondingType(typeof(uint))]
		WTSSessionId,

		/// <summary>A null-terminated string that contains the name of the user associated with the session.</summary>
		[CorrespondingType(typeof(string))]
		WTSUserName,

		/// <summary>A null-terminated string that contains the name of the Remote Desktop Services session.</summary>
		[CorrespondingType(typeof(string))]
		WTSWinStationName,

		/// <summary>A null-terminated string that contains the name of the domain to which the logged-on user belongs.</summary>
		[CorrespondingType(typeof(string))]
		WTSDomainName,

		/// <summary>The session's current connection state. For more information, see WTS_CONNECTSTATE_CLASS.</summary>
		[CorrespondingType(typeof(WTS_CONNECTSTATE_CLASS))]
		WTSConnectState,

		/// <summary>A ULONG value that contains the build number of the client.</summary>
		[CorrespondingType(typeof(uint))]
		WTSClientBuildNumber,

		/// <summary>A null-terminated string that contains the name of the client.</summary>
		[CorrespondingType(typeof(string))]
		WTSClientName,

		/// <summary>A null-terminated string that contains the directory in which the client is installed.</summary>
		[CorrespondingType(typeof(string))]
		WTSClientDirectory,

		/// <summary>A USHORT client-specific product identifier.</summary>
		[CorrespondingType(typeof(ushort))]
		WTSClientProductId,

		/// <summary>
		/// A ULONG value that contains a client-specific hardware identifier. This option is reserved for future use.
		/// WTSQuerySessionInformation will always return a value of 0.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		WTSClientHardwareId,

		/// <summary>
		/// The network type and network address of the client. For more information, see WTS_CLIENT_ADDRESS. The IP address is offset
		/// by two bytes from the start of the Address member of the WTS_CLIENT_ADDRESS structure.
		/// </summary>
		[CorrespondingType(typeof(WTS_CLIENT_ADDRESS))]
		WTSClientAddress,

		/// <summary>Information about the display resolution of the client. For more information, see WTS_CLIENT_DISPLAY.</summary>
		[CorrespondingType(typeof(WTS_CLIENT_DISPLAY))]
		WTSClientDisplay,

		/// <summary>
		/// A USHORT value that specifies information about the protocol type for the session. This is one of the following values.
		/// </summary>
		[CorrespondingType(typeof(SessionProtocolType))]
		WTSClientProtocolType,

		/// <summary>
		/// This value returns FALSE. If you call GetLastError to get extended error information, GetLastError returns
		/// ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows Vista: This value is not used.
		/// </summary>
		WTSIdleTime,

		/// <summary>
		/// This value returns FALSE. If you call GetLastError to get extended error information, GetLastError returns
		/// ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows Vista: This value is not used.
		/// </summary>
		WTSLogonTime,

		/// <summary>
		/// This value returns FALSE. If you call GetLastError to get extended error information, GetLastError returns
		/// ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows Vista: This value is not used.
		/// </summary>
		WTSIncomingBytes,

		/// <summary>
		/// This value returns FALSE. If you call GetLastError to get extended error information, GetLastError returns
		/// ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows Vista: This value is not used.
		/// </summary>
		WTSOutgoingBytes,

		/// <summary>
		/// This value returns FALSE. If you call GetLastError to get extended error information, GetLastError returns
		/// ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows Vista: This value is not used.
		/// </summary>
		WTSIncomingFrames,

		/// <summary>
		/// This value returns FALSE. If you call GetLastError to get extended error information, GetLastError returns
		/// ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows Vista: This value is not used.
		/// </summary>
		WTSOutgoingFrames,

		/// <summary>Information about a Remote Desktop Connection (RDC) client. For more information, see WTSCLIENT.</summary>
		[CorrespondingType(typeof(WTSCLIENT))]
		WTSClientInfo,

		/// <summary>Information about a client session on a RD Session Host server. For more information, see WTSINFO.</summary>
		[CorrespondingType(typeof(WTSINFO))]
		WTSSessionInfo,

		/// <summary>
		/// Extended information about a session on a RD Session Host server. For more information, see WTSINFOEX. Windows Server 2008
		/// and Windows Vista: This value is not supported.
		/// </summary>
		[CorrespondingType(typeof(WTSINFOEX))]
		WTSSessionInfoEx,

		/// <summary>
		/// A WTSCONFIGINFO structure that contains information about the configuration of a RD Session Host server. Windows Server 2008
		/// and Windows Vista: This value is not supported.
		/// </summary>
		[CorrespondingType(typeof(WTSCONFIGINFO))]
		WTSConfigInfo,

		/// <summary>This value is not supported.</summary>
		WTSValidationInfo,

		/// <summary>
		/// A WTS_SESSION_ADDRESS structure that contains the IPv4 address assigned to the session. If the session does not have a
		/// virtual IP address, the WTSQuerySessionInformation function returns ERROR_NOT_SUPPORTED.Windows Server 2008 and Windows
		/// Vista: This value is not supported.
		/// </summary>
		[CorrespondingType(typeof(WTS_SESSION_ADDRESS))]
		WTSSessionAddressV4,

		/// <summary>
		/// Determines whether the current session is a remote session. The WTSQuerySessionInformation function returns a value of TRUE
		/// to indicate that the current session is a remote session, and FALSE to indicate that the current session is a local session.
		/// This value can only be used for the local machine, so the hServer parameter of the WTSQuerySessionInformation function must
		/// contain WTS_CURRENT_SERVER_HANDLE. Windows Server 2008 and Windows Vista: This value is not supported.
		/// </summary>
		WTSIsRemoteSession,
	}

	/// <summary>The purpose of the call.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSCreateListenerA")]
	public enum WTS_LISTENER
	{
		/// <summary>Create a new listener.</summary>
		WTS_LISTENER_CREATE = 0x00000001,

		/// <summary>Update the settings of an existing listener.</summary>
		WTS_LISTENER_UPDATE = 0x00000010,
	}

	/// <summary>The state of the session.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSINFOEX_LEVEL1_A")]
	[Flags]
	public enum WTS_SESSIONSTATE : uint
	{
		/// <summary>The session state is not known.</summary>
		WTS_SESSIONSTATE_UNKNOWN = 0xFFFFFFFF,

		/// <summary>The session state is locked.</summary>
		WTS_SESSIONSTATE_LOCK = 0x00000000,

		/// <summary>The session state is unlocked.</summary>
		WTS_SESSIONSTATE_UNLOCK = 0x00000001,
	}

	/// <summary>Specifies the type of structure that a Remote Desktop Services function has returned in a buffer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_type_class typedef enum _WTS_TYPE_CLASS {
	// WTSTypeProcessInfoLevel0, WTSTypeProcessInfoLevel1, WTSTypeSessionInfoLevel1 } WTS_TYPE_CLASS;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NE:wtsapi32._WTS_TYPE_CLASS")]
	public enum WTS_TYPE_CLASS
	{
		/// <summary>The buffer contains one or more WTS_PROCESS_INFO structures.</summary>
		WTSTypeProcessInfoLevel0,

		/// <summary>The buffer contains one or more WTS_PROCESS_INFO_EX structures.</summary>
		WTSTypeProcessInfoLevel1,

		/// <summary>The buffer contains one or more WTS_SESSION_INFO_1 structures.</summary>
		WTSTypeSessionInfoLevel1,
	}

	/// <summary>Contains values that indicate the type of virtual channel information to retrieve.</summary>
	/// <remarks>
	/// For an example that shows the use of the WTSVirtualFileHandle value, see WTSVirtualChannelQuery. This example shows how to gain
	/// access to a virtual channel file handle that can be used for asynchronous I/O.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ne-wtsapi32-wts_virtual_class typedef enum _WTS_VIRTUAL_CLASS {
	// WTSVirtualClientData, WTSVirtualFileHandle } WTS_VIRTUAL_CLASS;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NE:wtsapi32._WTS_VIRTUAL_CLASS")]
	public enum WTS_VIRTUAL_CLASS
	{
		/// <summary>This value is not currently supported.</summary>
		WTSVirtualClientData,

		/// <summary>Indicates a request for the file handle of a virtual channel that can be used for asynchronous I/O.</summary>
		WTSVirtualFileHandle,
	}

	/// <summary>Indicates the type of shutdown.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSShutdownSystem")]
	public enum WTS_WSD
	{
		/// <summary>
		/// Forces all client sessions to log off (except the session calling <c>WTSShutdownSystem</c>) and disables any subsequent
		/// remote logons. This can be used as a step before shutting down. Logons will be re-enabled when the Remote Desktop Services
		/// service is restarted.
		/// </summary>
		WTS_WSD_LOGOFF = 0x00000001,

		/// <summary>
		/// Shuts down the system on the RD Session Host server. This is equivalent to calling the ExitWindowsEx function with
		/// <c>EWX_SHUTDOWN</c>. The calling process must have the <c>SE_SHUTDOWN_NAME</c> privilege enabled.
		/// </summary>
		WTS_WSD_SHUTDOWN = 0x00000002,

		/// <summary>
		/// Shuts down and then restarts the system on the RD Session Host server. This is equivalent to calling <c>ExitWindowsEx</c>
		/// with <c>EWX_REBOOT</c>. The calling process must have the <c>SE_SHUTDOWN_NAME</c> privilege enabled.
		/// </summary>
		WTS_WSD_REBOOT = 0x00000004,

		/// <summary>
		/// Shuts down the system on the RD Session Host server and, on computers that support software control of AC power, turns off
		/// the power. This is equivalent to calling ExitWindowsEx with <c>EWX_SHUTDOWN</c> and <c>EWX_POWEROFF</c>. The calling process
		/// must have the <c>SE_SHUTDOWN_NAME</c> privilege enabled.
		/// </summary>
		WTS_WSD_POWEROFF = 0x00000008,

		/// <summary>This value is not supported currently.</summary>
		WTS_WSD_FASTREBOOT = 0x00000010,
	}

	/// <summary>Specifies which session notifications are to be received.</summary>
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSRegisterSessionNotificationEx")]
	public enum WTSNotification
	{
		/// <summary>
		/// Only session notifications involving the session attached to by the window identified by the hWnd parameter value are to be received.
		/// </summary>
		NOTIFY_FOR_THIS_SESSION = 0,

		/// <summary>All session notifications are to be received.</summary>
		NOTIFY_FOR_ALL_SESSIONS = 1
	}

	/// <summary>Closes an open handle to a Remote Desktop Session Host (RD Session Host) server.</summary>
	/// <param name="hServer">
	/// <para>A handle to an RD Session Host server opened by a call to the WTSOpenServer or WTSOpenServerEx function.</para>
	/// <para>Do not pass <c>WTS_CURRENT_SERVER_HANDLE</c> for this parameter.</para>
	/// </param>
	/// <returns>None</returns>
	/// <remarks>
	/// <para>
	/// Call the <c>WTSCloseServer</c> function as part of your program's clean-up routine to close all the server handles opened by
	/// calls to the WTSOpenServer or WTSOpenServerEx function.
	/// </para>
	/// <para>After the handle has been closed, it cannot be used with any other WTS APIs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtscloseserver void WTSCloseServer( HANDLE hServer );
	[DllImport(Lib_WTSApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSCloseServer")]
	public static extern void WTSCloseServer(HWTSSERVER hServer);

	/// <summary>Connects a Remote Desktop Services session to an existing session on the local computer.</summary>
	/// <param name="LogonId">
	/// <para>
	/// The logon ID of the session to connect to. The user of that session must have permissions to connect to an existing session. The
	/// output of this session will be routed to the session identified by the TargetLogonId parameter.
	/// </para>
	/// <para>This can be <c>LOGONID_CURRENT</c> to use the current session.</para>
	/// </param>
	/// <param name="TargetLogonId">
	/// <para>
	/// The logon ID of the session to receive the output of the session represented by the LogonId parameter. The output of the session
	/// identified by the LogonId parameter will be routed to this session.
	/// </para>
	/// <para>This can be <c>LOGONID_CURRENT</c> to use the current session.</para>
	/// </param>
	/// <param name="pPassword">
	/// A pointer to the password for the user account that is specified in the LogonId parameter. The value of pPassword can be an
	/// empty string if the caller is logged on using the same domain name and user name as the logon ID. The value of pPassword cannot
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="bWait">
	/// Indicates whether the operation is synchronous. Specify <c>TRUE</c> to wait for the operation to complete, or <c>FALSE</c> to
	/// return immediately.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>Either the LogonId or TargetLogonId parameter can be <c>LOGONID_CURRENT</c>, but not both.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsconnectsessiona BOOL WTSConnectSessionA( ULONG
	// LogonId, ULONG TargetLogonId, StrPtrAnsi pPassword, BOOL bWait );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSConnectSessionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSConnectSession(uint LogonId, uint TargetLogonId, [MarshalAs(UnmanagedType.LPTStr)] string pPassword,
		[MarshalAs(UnmanagedType.Bool)] bool bWait);

	/// <summary>Creates a new Remote Desktop Services listener or configures an existing listener.</summary>
	/// <param name="hServer">A handle to an RD Session Host server. Always set this parameter to <c>WTS_CURRENT_SERVER_HANDLE</c>.</param>
	/// <param name="pReserved">This parameter is reserved. Always set this parameter to <c>NULL</c>.</param>
	/// <param name="Reserved">This parameter is reserved. Always set this parameter to zero.</param>
	/// <param name="pListenerName">A pointer to a null-terminated string that contains the name of the listener to create or configure.</param>
	/// <param name="pBuffer">A pointer to a WTSLISTENERCONFIG structure that contains configuration information for the listener.</param>
	/// <param name="flag">
	/// <para>The purpose of the call. This parameter can be one of the following values.</para>
	/// <para>WTS_LISTENER_CREATE (1 (0x1))</para>
	/// <para>Create a new listener.</para>
	/// <para>WTS_LISTENER_UPDATE (16 (0x10))</para>
	/// <para>Update the settings of an existing listener.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function creates or configures a listener that uses Remote Desktop Protocol (RDP). Always set the <c>version</c> member of
	/// the WTSLISTENERCONFIG structure that is pointed to by the pBuffer parameter to one.
	/// </para>
	/// <para>
	/// This function does not create or configure the security descriptor of the listener. When you call this function to create a new
	/// listener, the function assigns the default security descriptor to the new listener. To modify the security descriptor, call the
	/// WTSSetListenerSecurity function. For more information about security descriptors, see SECURITY_DESCRIPTOR.
	/// </para>
	/// <para>
	/// This function does not validate the settings for the new listener. Be sure that the settings are valid before calling this function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtscreatelistenera BOOL WTSCreateListenerA( HANDLE
	// hServer, PVOID pReserved, DWORD Reserved, StrPtrAnsi pListenerName, PWTSLISTENERCONFIGA pBuffer, DWORD flag );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSCreateListenerA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSCreateListener(HWTSSERVER hServer, [In, Optional] IntPtr pReserved, [In, Optional] uint Reserved,
		[MarshalAs(UnmanagedType.LPTStr)] string pListenerName, in WTSLISTENERCONFIG pBuffer, WTS_LISTENER flag);

	/// <summary>
	/// Disconnects the logged-on user from the specified Remote Desktop Services session without closing the session. If the user
	/// subsequently logs on to the same Remote Desktop Session Host (RD Session Host) server, the user is reconnected to the same session.
	/// </summary>
	/// <param name="hServer">
	/// A handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer or WTSOpenServerEx function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="SessionId">
	/// <para>
	/// A Remote Desktop Services session identifier. To indicate the current session, specify <c>WTS_CURRENT_SESSION</c>. To retrieve
	/// the identifiers of all sessions on a specified RD Session Host server, use the WTSEnumerateSessions function.
	/// </para>
	/// <para>
	/// To be able to disconnect another user's session, you need to have the Disconnect permission. For more information, see Remote
	/// Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// <para>
	/// To disconnect sessions running on a virtual machine hosted on a RD Virtualization Host server, you must be a member of the
	/// Administrators group on the RD Virtualization Host server.
	/// </para>
	/// </param>
	/// <param name="bWait">
	/// Indicates whether the operation is synchronous. Specify <c>TRUE</c> to wait for the operation to complete, or <c>FALSE</c> to
	/// return immediately.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsdisconnectsession BOOL WTSDisconnectSession( HANDLE
	// hServer, DWORD SessionId, BOOL bWait );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSDisconnectSession")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSDisconnectSession(HWTSSERVER hServer, uint SessionId, [MarshalAs(UnmanagedType.Bool)] bool bWait);

	/// <summary>Enables or disables Child Sessions.</summary>
	/// <param name="bEnable">
	/// Indicates whether to enable or disable child sessions. Pass <c>TRUE</c> if child sessions are to be enabled or <c>FALSE</c> otherwise.
	/// </param>
	/// <returns>Returns nonzero if the function succeeds or zero otherwise.</returns>
	/// <remarks>For more information about child sessions, see Child Sessions.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenablechildsessions BOOL WTSEnableChildSessions( BOOL
	// bEnable );
	[DllImport(Lib_WTSApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnableChildSessions")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSEnableChildSessions([MarshalAs(UnmanagedType.Bool)] bool bEnable);

	/// <summary>Enumerates all the Remote Desktop Services listeners on a Remote Desktop Session Host (RD Session Host) server.</summary>
	/// <param name="hServer">A handle to an RD Session Host server. Always set this parameter to <c>WTS_CURRENT_SERVER_HANDLE</c>.</param>
	/// <param name="pReserved">This parameter is reserved. Always set this parameter to <c>NULL</c>.</param>
	/// <param name="Reserved">This parameter is reserved. Always set this parameter to zero.</param>
	/// <param name="pListeners">A pointer to an array of <c>WTSLISTENERNAME</c> variables that receive the names of the listeners.</param>
	/// <param name="pCount">
	/// A pointer to a <c>DWORD</c> variable that contains the number of listener names in the array referenced by the pListeners
	/// parameter. If the number of listener names is unknown, pass pListeners as <c>NULL</c>. The function will return the number of
	/// <c>WTSLISTENERNAME</c> variables necessary to allocate for the array pointed to by the pListeners parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function returns all listeners currently running on the server, including listeners that do not support Remote Desktop
	/// Protocol (RDP).
	/// </para>
	/// <para>
	/// If the number of listeners is unknown, you can call this function with pListeners set to <c>NULL</c>. The function will then
	/// return, in the pCount parameter, the number of <c>WTSLISTENERNAME</c> variables necessary to receive all the listeners. Allocate
	/// the array for pListeners based on this number, and then call the function again, setting pListeners to the newly allocated array
	/// and pCount to the number returned by the first call.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumeratelistenersa BOOL WTSEnumerateListenersA(
	// HANDLE hServer, PVOID pReserved, DWORD Reserved, PWTSLISTENERNAMEA pListeners, DWORD *pCount );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateListenersA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSEnumerateListeners(HWTSSERVER hServer, [In, Optional] IntPtr pReserved, [In, Optional] uint Reserved,
		[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] WTSLISTENERNAME[]? pListeners, ref uint pCount);

	/// <summary>Retrieves information about the active processes on a specified Remote Desktop Session Host (RD Session Host) server.</summary>
	/// <param name="hServer">
	/// Handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="Reserved">Reserved; must be zero.</param>
	/// <param name="Version">Specifies the version of the enumeration request. Must be 1.</param>
	/// <param name="ppProcessInfo">
	/// Pointer to a variable that receives a pointer to an array of WTS_PROCESS_INFO structures. Each structure in the array contains
	/// information about an active process on the specified RD Session Host server. To free the returned buffer, call the WTSFreeMemory function.
	/// </param>
	/// <param name="pCount">
	/// Pointer to a variable that receives the number of <c>WTS_PROCESS_INFO</c> structures returned in the ppProcessInfo buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// The caller must be a member of the Administrators group to enumerate processes that are running under a different user's context.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumerateprocessesa BOOL WTSEnumerateProcessesA(
	// HANDLE hServer, DWORD Reserved, DWORD Version, PWTS_PROCESS_INFOA *ppProcessInfo, DWORD *pCount );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateProcessesA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSEnumerateProcesses(HWTSSERVER hServer, [In, Optional] uint Reserved, uint Version,
		out SafeWTSMemoryHandle ppProcessInfo, out uint pCount);

	/// <summary>
	/// Retrieves information about the active processes on the specified Remote Desktop Session Host (RD Session Host) server or Remote
	/// Desktop Virtualization Host (RD Virtualization Host) server.
	/// </summary>
	/// <param name="hServer">
	/// A handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the server on which your application is running.
	/// </param>
	/// <param name="pLevel">
	/// <para>
	/// A pointer to a <c>DWORD</c> variable that, on input, specifies the type of information to return. To return an array of
	/// WTS_PROCESS_INFO structures, specify zero. To return an array of WTS_PROCESS_INFO_EX structures, specify one.
	/// </para>
	/// <para>
	/// If you do not specify a valid value for this parameter, on output, <c>WTSEnumerateProcessesEx</c> sets this parameter to one and
	/// returns an error. Otherwise, on output, <c>WTSEnumerateProcessesEx</c> does not change the value of this parameter.
	/// </para>
	/// </param>
	/// <param name="SessionId">
	/// The session for which to enumerate processes. To enumerate processes for all sessions on the server, specify <c>WTS_ANY_SESSION</c>.
	/// </param>
	/// <param name="ppProcessInfo">
	/// A pointer to a variable that receives a pointer to an array of WTS_PROCESS_INFO or WTS_PROCESS_INFO_EX structures. The type of
	/// structure is determined by the value passed to the pLevel parameter. Each structure in the array contains information about an
	/// active process. When you have finished using the array, free it by calling the WTSFreeMemoryEx function. You should also set the
	/// pointer to <c>NULL</c>.
	/// </param>
	/// <param name="pCount">
	/// A pointer to a variable that receives the number of structures returned in the buffer referenced by the ppProcessInfo parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// The caller must be a member of the Administrators group to enumerate processes that are running under another user session.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumerateprocessesexa BOOL WTSEnumerateProcessesExA(
	// HANDLE hServer, DWORD *pLevel, DWORD SessionId, StrPtrAnsi *ppProcessInfo, DWORD *pCount );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateProcessesExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSEnumerateProcessesEx(HWTSSERVER hServer, ref uint pLevel, uint SessionId, out IntPtr ppProcessInfo, out uint pCount);

	/// <summary>
	/// Retrieves information about the active processes on the specified Remote Desktop Session Host (RD Session Host) server or Remote
	/// Desktop Virtualization Host (RD Virtualization Host) server.
	/// </summary>
	/// <param name="hServer">
	/// A handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the server on which your application is running.
	/// </param>
	/// <param name="SessionId">
	/// The session for which to enumerate processes. To enumerate processes for all sessions on the server, specify <c>WTS_ANY_SESSION</c>.
	/// </param>
	/// <param name="ppProcessInfo">An array of WTS_PROCESS_INFO_EX structures.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// The caller must be a member of the Administrators group to enumerate processes that are running under another user session.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumerateprocessesexa BOOL WTSEnumerateProcessesExA(
	// HANDLE hServer, DWORD *pLevel, DWORD SessionId, StrPtrAnsi *ppProcessInfo, DWORD *pCount );
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateProcessesExA")]
	public static bool WTSEnumerateProcessesEx(HWTSSERVER hServer, uint SessionId, [NotNullWhen(true)] out WTS_PROCESS_INFO_EX[]? ppProcessInfo)
	{
		uint lvl = 1;
		if (WTSEnumerateProcessesEx(hServer, ref lvl, SessionId, out var ptr, out var cnt) && lvl == 1)
		{
			try
			{
				ppProcessInfo = ptr.ToArray<WTS_PROCESS_INFO_EX>((int)cnt) ?? new WTS_PROCESS_INFO_EX[0];
			}
			finally
			{
				WTSFreeMemoryEx(WTS_TYPE_CLASS.WTSTypeProcessInfoLevel1, ptr, cnt);
			}
			return true;
		}
		ppProcessInfo = null;
		return false;
	}

	/// <summary>Returns a list of all Remote Desktop Session Host (RD Session Host) servers within the specified domain.</summary>
	/// <param name="pDomainName">
	/// Pointer to the name of the domain to be queried. If the value of this parameter is <c>NULL</c>, the specified domain is the
	/// current domain.
	/// </param>
	/// <param name="Reserved">Reserved. The value of this parameter must be 0.</param>
	/// <param name="Version">Version of the enumeration request. The value of the parameter must be 1.</param>
	/// <param name="ppServerInfo">
	/// Points to an array of WTS_SERVER_INFO structures, which contains the returned results of the enumeration. After use, the memory
	/// used by this buffer should be freed by calling WTSFreeMemory.
	/// </param>
	/// <param name="pCount">
	/// Pointer to a variable that receives the number of WTS_SERVER_INFO structures returned in the ppServerInfo buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>This function will not work if NetBT is disabled.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumerateserversa BOOL WTSEnumerateServersA( StrPtrAnsi
	// pDomainName, DWORD Reserved, DWORD Version, PWTS_SERVER_INFOA *ppServerInfo, DWORD *pCount );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateServersA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSEnumerateServers([Optional, MarshalAs(UnmanagedType.LPTStr)] string? pDomainName, [Optional] uint Reserved, uint Version,
		out SafeWTSMemoryHandle ppServerInfo, out uint pCount);

	/// <summary>Returns a list of all Remote Desktop Session Host (RD Session Host) servers within the specified domain.</summary>
	/// <param name="pDomainName">
	/// Pointer to the name of the domain to be queried. If the value of this parameter is <c>NULL</c>, the specified domain is the
	/// current domain.
	/// </param>
	/// <param name="ppServerInfo">An array of WTS_SERVER_INFO structures, which contains the returned results of the enumeration.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>This function will not work if NetBT is disabled.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumerateserversa BOOL WTSEnumerateServersA( StrPtrAnsi
	// pDomainName, DWORD Reserved, DWORD Version, PWTS_SERVER_INFOA *ppServerInfo, DWORD *pCount );
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateServersA")]
	public static bool WTSEnumerateServers([Optional] string? pDomainName, [NotNullWhen(true)] out WTS_SERVER_INFO[]? ppServerInfo)
	{
		if (WTSEnumerateServers(pDomainName, 0, 1, out var ptr, out var cnt))
		{
			using (ptr)
				ppServerInfo = ptr.ToArray<WTS_SERVER_INFO>((int)cnt);
			return true;
		}
		ppServerInfo = null;
		return false;
	}

	/// <summary>Retrieves a list of sessions on a Remote Desktop Session Host (RD Session Host) server.</summary>
	/// <param name="hServer">
	/// <para>A handle to the RD Session Host server.</para>
	/// <para>
	/// <c>Note</c> You can use the WTSOpenServer or WTSOpenServerEx functions to retrieve a handle to a specific server, or
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to use the RD Session Host server that hosts your application.
	/// </para>
	/// </param>
	/// <param name="Reserved">This parameter is reserved. It must be zero.</param>
	/// <param name="Version">The version of the enumeration request. This parameter must be 1.</param>
	/// <param name="ppSessionInfo">
	/// <para>
	/// A pointer to an array of WTS_SESSION_INFO structures that represent the retrieved sessions. To free the returned buffer, call
	/// the WTSFreeMemory function.
	/// </para>
	/// <para>Session permissions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To enumerate a session, you must enable the query information permission. For more information, see Remote Desktop Services Permissions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>To change permissions on a session, use the Remote Desktop Services Configuration administrative tool.</term>
	/// </item>
	/// <item>
	/// <term>
	/// To enumerate sessions running on a virtual machine hosted on a RD Virtualization Host server, you must be a member of the
	/// Administrators group on the RD Virtualization Host server.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pCount">A pointer to the number of <c>WTS_SESSION_INFO</c> structures returned in the ppSessionInfo parameter.</param>
	/// <returns>
	/// <para>Returns zero if this function fails. If this function succeeds, a nonzero value is returned.</para>
	/// <para>To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>For more information, and an extended example on how to use this function, see the following kb article.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumeratesessionsa BOOL WTSEnumerateSessionsA( HANDLE
	// hServer, DWORD Reserved, DWORD Version, PWTS_SESSION_INFOA *ppSessionInfo, DWORD *pCount );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateSessionsA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSEnumerateSessions(HWTSSERVER hServer, [Optional] uint Reserved, uint Version, out SafeWTSMemoryHandle ppSessionInfo, out uint pCount);

	/// <summary>
	/// Retrieves a list of sessions on a specified Remote Desktop Session Host (RD Session Host) server or Remote Desktop
	/// Virtualization Host (RD Virtualization Host) server.
	/// </summary>
	/// <param name="hServer">
	/// A handle to the target server. Specify a handle returned by the WTSOpenServer or WTSOpenServerEx function. To enumerate sessions
	/// on the RD Session Host server on which the application is running, specify <c>WTS_CURRENT_SERVER_HANDLE</c>.
	/// </param>
	/// <param name="pLevel">
	/// This parameter is reserved. Always set this parameter to one. On output, <c>WTSEnumerateSessionsEx</c> does not change the value
	/// of this parameter.
	/// </param>
	/// <param name="Filter">This parameter is reserved. Always set this parameter to zero.</param>
	/// <param name="ppSessionInfo">
	/// A pointer to a <c>PWTS_SESSION_INFO_1</c> variable that receives a pointer to an array of WTS_SESSION_INFO_1 structures. Each
	/// structure in the array contains information about a session on the specified RD Session Host server. If you obtained a handle to
	/// an RD Virtualization Host server by calling the WTSOpenServerEx function, the array contains information about sessions on
	/// virtual machines on the server. When you have finished using the array, free it by calling the WTSFreeMemoryEx function. You
	/// should also set the pointer to <c>NULL</c>.
	/// </param>
	/// <param name="pCount">
	/// A pointer to a <c>DWORD</c> variable that receives the number of WTS_SESSION_INFO_1 structures returned in the ppSessionInfo buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To obtain information about sessions running on virtual machines on an RD Virtualization Host server, you must obtain the handle
	/// by calling the WTSOpenServerEx function. To free the returned buffer, call the WTSFreeMemoryEx function and set the WTSClassType
	/// parameter to <c>WTSTypeSessionInfoLevel1</c>.
	/// </para>
	/// <para>
	/// To enumerate a session, you need to have the Query Information permission for that session. For more information, see Remote
	/// Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// <para>
	/// To enumerate sessions running on a virtual machine hosted on an RD Virtualization Host server, you must be a member of the
	/// Administrators group on the RD Virtualization Host server.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumeratesessionsexa BOOL WTSEnumerateSessionsExA(
	// HANDLE hServer, DWORD *pLevel, DWORD Filter, PWTS_SESSION_INFO_1A *ppSessionInfo, DWORD *pCount );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateSessionsExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSEnumerateSessionsEx(HWTSSERVER hServer, in uint pLevel, [Optional] uint Filter, out IntPtr ppSessionInfo, out uint pCount);

	/// <summary>
	/// Retrieves a list of sessions on a specified Remote Desktop Session Host (RD Session Host) server or Remote Desktop
	/// Virtualization Host (RD Virtualization Host) server.
	/// </summary>
	/// <param name="hServer">
	/// A handle to the target server. Specify a handle returned by the WTSOpenServer or WTSOpenServerEx function. To enumerate sessions
	/// on the RD Session Host server on which the application is running, specify <c>WTS_CURRENT_SERVER_HANDLE</c>.
	/// </param>
	/// <param name="ppSessionInfo">
	/// Receives an array of WTS_SESSION_INFO_1 structures. Each
	/// structure in the array contains information about a session on the specified RD Session Host server. If you obtained a handle to
	/// an RD Virtualization Host server by calling the WTSOpenServerEx function, the array contains information about sessions on
	/// virtual machines on the server.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To obtain information about sessions running on virtual machines on an RD Virtualization Host server, you must obtain the handle
	/// by calling the WTSOpenServerEx function. To free the returned buffer, call the WTSFreeMemoryEx function and set the WTSClassType
	/// parameter to <c>WTSTypeSessionInfoLevel1</c>.
	/// </para>
	/// <para>
	/// To enumerate a session, you need to have the Query Information permission for that session. For more information, see Remote
	/// Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// <para>
	/// To enumerate sessions running on a virtual machine hosted on an RD Virtualization Host server, you must be a member of the
	/// Administrators group on the RD Virtualization Host server.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsenumeratesessionsexa BOOL WTSEnumerateSessionsExA(
	// HANDLE hServer, DWORD *pLevel, DWORD Filter, PWTS_SESSION_INFO_1A *ppSessionInfo, DWORD *pCount );
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSEnumerateSessionsExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static bool WTSEnumerateSessionsEx(HWTSSERVER hServer, [NotNullWhen(true)] out WTS_SESSION_INFO_1[]? ppSessionInfo)
	{
		if (WTSEnumerateSessionsEx(hServer, 1, 0, out var ptr, out var cnt))
		{
			try
			{
				ppSessionInfo = ptr.ToArray<WTS_SESSION_INFO_1>((int)cnt) ?? new WTS_SESSION_INFO_1[0];
			}
			finally
			{
				WTSFreeMemoryEx(WTS_TYPE_CLASS.WTSTypeSessionInfoLevel1, ptr, cnt);
			}
			return true;
		}
		ppSessionInfo = null;
		return false;
	}

	/// <summary>Frees memory allocated by a Remote Desktop Services function.</summary>
	/// <param name="pMemory">Pointer to the memory to free.</param>
	/// <returns>None</returns>
	/// <remarks>
	/// Several Remote Desktop Services functions allocate buffers to return information. Use the <c>WTSFreeMemory</c> function to free
	/// these buffers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsfreememory void WTSFreeMemory( PVOID pMemory );
	[DllImport(Lib_WTSApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSFreeMemory")]
	public static extern void WTSFreeMemory(IntPtr pMemory);

	/// <summary>
	/// Frees memory that contains WTS_PROCESS_INFO_EX or WTS_SESSION_INFO_1 structures allocated by a Remote Desktop Services function.
	/// </summary>
	/// <param name="WTSTypeClass">
	/// A value of the WTS_TYPE_CLASS enumeration type that specifies the type of structures contained in the buffer referenced by the
	/// pMemory parameter.
	/// </param>
	/// <param name="pMemory">A pointer to the buffer to free.</param>
	/// <param name="NumberOfEntries">The number of elements in the buffer referenced by the pMemory parameter.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// Several Remote Desktop Services functions allocate buffers to return information. To free buffers that contain
	/// WTS_PROCESS_INFO_EX or WTS_SESSION_INFO_1 structures, you must call the <c>WTSFreeMemoryEx</c> function. To free other buffers,
	/// you can call either the WTSFreeMemory function or the <c>WTSFreeMemoryEx</c> function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsfreememoryexa BOOL WTSFreeMemoryExA( WTS_TYPE_CLASS
	// WTSTypeClass, PVOID pMemory, ULONG NumberOfEntries );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSFreeMemoryExA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSFreeMemoryEx(WTS_TYPE_CLASS WTSTypeClass, IntPtr pMemory, uint NumberOfEntries);

	/// <summary>Retrieves the child session identifier, if present.</summary>
	/// <param name="pSessionId">
	/// The address of a <c>ULONG</c> variable that receives the child session identifier. This will be ( <c>ULONG</c>)–1 if there is no
	/// child session for the current session.
	/// </param>
	/// <returns>Returns nonzero if the function succeeds or zero otherwise.</returns>
	/// <remarks>For more information about child sessions, see Child Sessions.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsgetchildsessionid BOOL WTSGetChildSessionId( PULONG
	// pSessionId );
	[DllImport(Lib_WTSApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSGetChildSessionId")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSGetChildSessionId(out uint pSessionId);

	/// <summary>Retrieves the security descriptor of a Remote Desktop Services listener.</summary>
	/// <param name="hServer">A handle to an RD Session Host server. Always set this parameter to <c>WTS_CURRENT_SERVER_HANDLE</c>.</param>
	/// <param name="pReserved">This parameter is reserved. Always set this parameter to <c>NULL</c>.</param>
	/// <param name="Reserved">This parameter is reserved. Always set this parameter to zero.</param>
	/// <param name="pListenerName">A pointer to a null-terminated string that contains the name of the listener.</param>
	/// <param name="SecurityInformation">
	/// <para>
	/// A SECURITY_INFORMATION value that specifies the security information to retrieve. Always enable the
	/// <c>DACL_SECURITY_INFORMATION</c> and <c>SACL_SECURITY_INFORMATION</c> flags.
	/// </para>
	/// <para>For more information about possible values, see SECURITY_INFORMATION.</para>
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// <para>
	/// A pointer to a SECURITY_DESCRIPTOR structure that receives the security information associated with the listener referenced by
	/// the pListenerName parameter. The <c>SECURITY_DESCRIPTOR</c> structure is returned in self-relative format. For more information
	/// about possible values, see <c>SECURITY_DESCRIPTOR</c>.
	/// </para>
	/// <para>The discretionary access control list (DACL) of the security descriptor can contain one or more of the following values.</para>
	/// <para>WTS_SECURITY_ALL_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>STANDARD_RIGHTS_REQUIRED</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_CONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_DISCONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_LOGON</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_MESSAGE</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_QUERY_INFORMATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_REMOTE_CONTROL</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_RESET</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_SET_INFORMATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_VIRTUAL_CHANNELS</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_CONNECT (256 (0x100))</para>
	/// <para>The right to connect.</para>
	/// <para>WTS_SECURITY_CURRENT_GUEST_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WTS_SECURITY_LOGOFF</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_VIRTUAL_CHANNELS</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_CURRENT_USER_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WTS_SECURITY_DISCONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_LOGOFF</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_RESET</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_SET_INFORMATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_VIRTUAL_CHANNELS</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_DISCONNECT (512 (0x200))</para>
	/// <para>The right to disconnect.</para>
	/// <para>WTS_SECURITY_GUEST_ACCESS</para>
	/// <para>Defined as <c>WTS_SECURITY_LOGON</c>.</para>
	/// <para>WTS_SECURITY_LOGOFF (64 (0x40))</para>
	/// <para>The right to log off.</para>
	/// <para>WTS_SECURITY_LOGON (32 (0x20))</para>
	/// <para>The right to log on.</para>
	/// <para>WTS_SECURITY_MESSAGE (128 (0x80))</para>
	/// <para>The right to send a message to the user.</para>
	/// <para>WTS_SECURITY_QUERY_INFORMATION (1 (0x1))</para>
	/// <para>The right to query for information.</para>
	/// <para>WTS_SECURITY_REMOTE_CONTROL (16 (0x10))</para>
	/// <para>The right to use remote control.</para>
	/// <para>WTS_SECURITY_RESET (4 (0x4))</para>
	/// <para>The right to reset information.</para>
	/// <para>WTS_SECURITY_SET_INFORMATION (2 (0x2))</para>
	/// <para>The right to set information.</para>
	/// <para>WTS_SECURITY_USER_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WTS_SECURITY_CONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_CURRENT_GUEST_ACCESS</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_QUERY_INFORMATION</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_VIRTUAL_CHANNELS (8 (0x8))</para>
	/// <para>The right to use virtual channels.</para>
	/// </param>
	/// <param name="nLength">The size, in bytes, of the SECURITY_DESCRIPTOR structure referenced by the pSecurityDescriptor parameter.</param>
	/// <param name="lpnLengthNeeded">
	/// A pointer to a variable that receives the number of bytes required to store the complete security descriptor. If this number is
	/// less than or equal to the value of the nLength parameter, the security descriptor is copied to the SECURITY_DESCRIPTOR structure
	/// referenced by the pSecurityDescriptor parameter; otherwise, no action is taken.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// If the number of bytes needed for the buffer that receives the SECURITY_DESCRIPTOR structure is unknown, you can call this
	/// method with nLength set to zero. The method will then return, in the lpnLengthNeeded parameter, the number of bytes required for
	/// the buffer. Allocate the buffer based on this number, and then call the method again, setting pSecurityDescriptor to the newly
	/// allocated buffer and nLength to the number returned by the first call.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsgetlistenersecuritya BOOL WTSGetListenerSecurityA(
	// HANDLE hServer, PVOID pReserved, DWORD Reserved, StrPtrAnsi pListenerName, SECURITY_INFORMATION SecurityInformation,
	// PSECURITY_DESCRIPTOR pSecurityDescriptor, DWORD nLength, LPDWORD lpnLengthNeeded );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSGetListenerSecurityA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSGetListenerSecurity(HWTSSERVER hServer, [In, Optional] IntPtr pReserved, [Optional] uint Reserved,
		[MarshalAs(UnmanagedType.LPTStr)] string pListenerName, SECURITY_INFORMATION SecurityInformation,
		[Out, Optional] PSECURITY_DESCRIPTOR pSecurityDescriptor, [Optional] uint nLength, out uint lpnLengthNeeded);

	/// <summary>Determines whether child sessions are enabled.</summary>
	/// <param name="pbEnabled">
	/// The address of a <c>BOOL</c> variable that receives a nonzero value if child sessions are enabled or zero otherwise.
	/// </param>
	/// <returns>Returns nonzero if the function succeeds or zero otherwise.</returns>
	/// <remarks>For more information about child sessions, see Child Sessions.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsischildsessionsenabled BOOL WTSIsChildSessionsEnabled(
	// PBOOL pbEnabled );
	[DllImport(Lib_WTSApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSIsChildSessionsEnabled")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSIsChildSessionsEnabled([MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);

	/// <summary>Logs off a specified Remote Desktop Services session.</summary>
	/// <param name="hServer">
	/// A handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer or WTSOpenServerEx function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="SessionId">
	/// <para>
	/// A Remote Desktop Services session identifier. To indicate the current session, specify <c>WTS_CURRENT_SESSION</c>. You can use
	/// the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session Host server.
	/// </para>
	/// <para>
	/// To be able to log off another user's session, you need to have the Reset permission. For more information, see Remote Desktop
	/// Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// <para>
	/// To log off sessions running on a virtual machine hosted on a RD Virtualization Host server, you must be a member of the
	/// Administrators group on the RD Virtualization Host server.
	/// </para>
	/// </param>
	/// <param name="bWait">
	/// <para>Indicates whether the operation is synchronous.</para>
	/// <para>If bWait is <c>TRUE</c>, the function returns when the session is logged off.</para>
	/// <para>
	/// If bWait is <c>FALSE</c>, the function returns immediately. To verify that the session has been logged off, specify the session
	/// identifier in a call to the WTSQuerySessionInformation function. <c>WTSQuerySessionInformation</c> returns zero if the session
	/// is logged off.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtslogoffsession BOOL WTSLogoffSession( HANDLE hServer,
	// DWORD SessionId, BOOL bWait );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSLogoffSession")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSLogoffSession(HWTSSERVER hServer, uint SessionId, [MarshalAs(UnmanagedType.Bool)] bool bWait);

	/// <summary>Opens a handle to the specified Remote Desktop Session Host (RD Session Host) server.</summary>
	/// <param name="pServerName">Pointer to a null-terminated string specifying the NetBIOS name of the RD Session Host server.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified server.</para>
	/// <para>
	/// If the function fails, it returns a handle that is not valid. You can test the validity of the handle by using it in another
	/// function call.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>When you have finished using the handle returned by <c>WTSOpenServer</c>, release it by calling the WTSCloseServer function.</para>
	/// <para>
	/// You do not need to open a handle for operations performed on the RD Session Host server on which your application is running.
	/// Use the constant <c>WTS_CURRENT_SERVER_HANDLE</c> instead.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsopenservera HANDLE WTSOpenServerA( StrPtrAnsi pServerName );
	[DllImport(Lib_WTSApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSOpenServerA")]
	public static extern SafeHWTSSERVER WTSOpenServer([MarshalAs(UnmanagedType.LPTStr)] string pServerName);

	/// <summary>
	/// Opens a handle to the specified Remote Desktop Session Host (RD Session Host) server or Remote Desktop Virtualization Host (RD
	/// Virtualization Host) server.
	/// </summary>
	/// <param name="pServerName">A pointer to a null-terminated string that contains the NetBIOS name of the server.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified server.</para>
	/// <para>
	/// If the function fails, it returns an invalid handle. You can test the validity of the handle by using it in another function call.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the server specified by the pServerName parameter is an RD Session Host server, the behavior of this function is identical to
	/// that of the WTSOpenServer function.
	/// </para>
	/// <para>
	/// To work with sessions running on virtual machines on the RD Virtualization Host server on which the calling application is
	/// running, specify <c>WTS_CURRENT_SERVER_NAME</c> for the pServerName parameter.
	/// </para>
	/// <para>When you have finished using the handle returned by this function, release it by calling the WTSCloseServer function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsopenserverexa HANDLE WTSOpenServerExA( StrPtrAnsi
	// pServerName );
	[DllImport(Lib_WTSApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSOpenServerExA")]
	public static extern SafeHWTSSERVER WTSOpenServerEx([MarshalAs(UnmanagedType.LPTStr)] string pServerName);

	/// <summary>Retrieves configuration information for a Remote Desktop Services listener.</summary>
	/// <param name="hServer">A handle to an RD Session Host server. Always set this parameter to <c>WTS_CURRENT_SERVER_HANDLE</c>.</param>
	/// <param name="pReserved">This parameter is reserved. Always set this parameter to <c>NULL</c>.</param>
	/// <param name="Reserved">This parameter is reserved. Always set this parameter to zero.</param>
	/// <param name="pListenerName">A pointer to a null-terminated string that contains the name of the listener to query.</param>
	/// <param name="pBuffer">A pointer to a WTSLISTENERCONFIG structure that receives the retrieved listener configuration information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// This function does not retrieve the security descriptor for the listener. To retrieve the security descriptor, call the
	/// WTSGetListenerSecurity function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsquerylistenerconfiga BOOL WTSQueryListenerConfigA(
	// HANDLE hServer, PVOID pReserved, DWORD Reserved, StrPtrAnsi pListenerName, PWTSLISTENERCONFIGA pBuffer );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSQueryListenerConfigA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSQueryListenerConfig(HWTSSERVER hServer, [In, Optional] IntPtr pReserved, [In, Optional] uint Reserved,
		[MarshalAs(UnmanagedType.LPTStr)] string pListenerName, out WTSLISTENERCONFIG pBuffer);

	/// <summary>
	/// Retrieves session information for the specified session on the specified Remote Desktop Session Host (RD Session Host) server.
	/// It can be used to query session information on local and remote RD Session Host servers.
	/// </summary>
	/// <param name="hServer">
	/// A handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="SessionId">
	/// <para>
	/// A Remote Desktop Services session identifier. To indicate the session in which the calling application is running (or the
	/// current session) specify <c>WTS_CURRENT_SESSION</c>. Only specify <c>WTS_CURRENT_SESSION</c> when obtaining session information
	/// on the local server. If <c>WTS_CURRENT_SESSION</c> is specified when querying session information on a remote server, the
	/// returned session information will be inconsistent. Do not use the returned data.
	/// </para>
	/// <para>
	/// You can use the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session Host server.
	/// </para>
	/// <para>
	/// To query information for another user's session, you must have Query Information permission. For more information, see Remote
	/// Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// </param>
	/// <param name="WTSInfoClass">
	/// A value of the WTS_INFO_CLASS enumeration that indicates the type of session information to retrieve in a call to the
	/// <c>WTSQuerySessionInformation</c> function.
	/// </param>
	/// <param name="ppBuffer">
	/// A pointer to a variable that receives a pointer to the requested information. The format and contents of the data depend on the
	/// information class specified in the WTSInfoClass parameter. To free the returned buffer, call the WTSFreeMemory function.
	/// </param>
	/// <param name="pBytesReturned">A pointer to a variable that receives the size, in bytes, of the data returned in ppBuffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To retrieve the session ID for the current session when Remote Desktop Services is running, call
	/// <c>WTSQuerySessionInformation</c> and specify <c>WTS_CURRENT_SESSION</c> for the SessionId parameter and <c>WTSSessionId</c> for
	/// the WTSInfoClass parameter. The session ID will be returned in the ppBuffer parameter. If Remote Desktop Services is not
	/// running, calls to <c>WTSQuerySessionInformation</c> fail. In this situation, you can retrieve the current session ID by calling
	/// the ProcessIdToSessionId function.
	/// </para>
	/// <para>
	/// To determine whether your application is running on the physical console, you must specify <c>WTS_CURRENT_SESSION</c> for the
	/// SessionId parameter, and <c>WTSClientProtocolType</c> as the WTSInfoClass parameter. If ppBuffer is "0", the session is attached
	/// to the physical console.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsquerysessioninformationa BOOL
	// WTSQuerySessionInformationA( HANDLE hServer, DWORD SessionId, WTS_INFO_CLASS WTSInfoClass, StrPtrAnsi *ppBuffer, DWORD *pBytesReturned );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSQuerySessionInformationA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSQuerySessionInformation(HWTSSERVER hServer, uint SessionId, WTS_INFO_CLASS WTSInfoClass,
		out SafeWTSMemoryHandle ppBuffer, out uint pBytesReturned);

	/// <summary>
	/// Retrieves configuration information for the specified user on the specified domain controller or Remote Desktop Session Host (RD
	/// Session Host) server.
	/// </summary>
	/// <param name="pServerName">
	/// Pointer to a null-terminated string containing the name of a domain controller or an RD Session Host server. Specify
	/// <c>WTS_CURRENT_SERVER_NAME</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="pUserName">
	/// <para>
	/// Pointer to a null-terminated string containing the user name to query. To retrieve the default user settings for the RD Session
	/// Host server, set this parameter to <c>NULL</c>.
	/// </para>
	/// <para><c>Windows Server 2008 and Windows Vista:</c> Setting this parameter to <c>NULL</c> returns an error.</para>
	/// </param>
	/// <param name="WTSConfigClass">
	/// Specifies the type of information to retrieve. This parameter can be one of the values from the WTS_CONFIG_CLASS enumeration
	/// type. The documentation for <c>WTS_CONFIG_CLASS</c> describes the format of the data returned in ppBuffer for each of the
	/// information types.
	/// </param>
	/// <param name="ppBuffer">
	/// Pointer to a variable that receives a pointer to the requested information. The format and contents of the data depend on the
	/// information class specified in the WTSConfigClass parameter. To free the returned buffer, call the WTSFreeMemory function.
	/// </param>
	/// <param name="pBytesReturned">Pointer to a variable that receives the size, in bytes, of the data returned in ppBuffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>WTSQueryUserConfig</c> and WTSSetUserConfig functions are passed a server name instead of a handle because user account
	/// information often resides on a domain controller. To set user configuration information, use the primary domain controller. You
	/// can call the NetGetDCName function to get the name of the primary domain controller. To query user configuration information,
	/// you can use the NetGetAnyDCName function to get the name of a primary or backup domain controller.
	/// </para>
	/// <para>
	/// Any domain controller can set or query user configuration information. Use the DsGetDcName function to retrieve the name of a
	/// domain controller.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsqueryuserconfiga BOOL WTSQueryUserConfigA( StrPtrAnsi
	// pServerName, StrPtrAnsi pUserName, WTS_CONFIG_CLASS WTSConfigClass, StrPtrAnsi *ppBuffer, DWORD *pBytesReturned );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSQueryUserConfigA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSQueryUserConfig([MarshalAs(UnmanagedType.LPTStr)] string pServerName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? pUserName,
		WTS_CONFIG_CLASS WTSConfigClass, out SafeWTSMemoryHandle ppBuffer, out uint pBytesReturned);

	/// <summary>
	/// <para>
	/// Obtains the primary access token of the logged-on user specified by the session ID. To call this function successfully, the
	/// calling application must be running within the context of the LocalSystem account and have the <c>SE_TCB_NAME</c> privilege.
	/// </para>
	/// <para>
	/// <c>Caution</c><c>WTSQueryUserToken</c> is intended for highly trusted services. Service providers must use caution that they do
	/// not leak user tokens when calling this function. Service providers must close token handles after they have finished using them.
	/// </para>
	/// </summary>
	/// <param name="SessionId">
	/// <para>
	/// A Remote Desktop Services session identifier. Any program running in the context of a service will have a session identifier of
	/// zero (0). You can use the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session
	/// Host server.
	/// </para>
	/// <para>
	/// To be able to query information for another user's session, you need to have the Query Information permission. For more
	/// information, see Remote Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services
	/// Configuration administrative tool.
	/// </para>
	/// </param>
	/// <param name="phToken">
	/// If the function succeeds, receives a pointer to the token handle for the logged-on user. Note that you must call the CloseHandle
	/// function to close this handle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a nonzero value, and the phToken parameter points to the primary token of the user.
	/// </para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Among other errors,
	/// <c>GetLastError</c> can return one of the following errors.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For information about primary tokens, see Access Tokens. For more information about account privileges, see Remote Desktop
	/// Services Permissions and Authorization Constants.
	/// </para>
	/// <para>See LocalSystem account for information about the privileges associated with that account.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsqueryusertoken BOOL WTSQueryUserToken( ULONG
	// SessionId, PHANDLE phToken );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSQueryUserToken")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSQueryUserToken(uint SessionId, out HTOKEN phToken);

	/// <summary>Registers the specified window to receive session change notifications.</summary>
	/// <param name="hWnd">Handle of the window to receive session change notifications.</param>
	/// <param name="dwFlags">
	/// <para>Specifies which session notifications are to be received. This parameter can be one of the following values.</para>
	/// <para>0 - NOTIFY_FOR_THIS_SESSION</para>
	/// <para>
	/// Only session notifications involving the session attached to by the window identified by the hWnd parameter value are to be received.
	/// </para>
	/// <para>1 - NOTIFY_FOR_ALL_SESSIONS</para>
	/// <para>All session notifications are to be received.</para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>. To get extended error information,
	/// call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called before the dependent services of Remote Desktop Services have started, an
	/// <c>RPC_S_INVALID_BINDING</c> error code may be returned. When the Global\TermSrvReadyEvent global event is set, all dependent
	/// services have started and this function can be successfully called.
	/// </para>
	/// <para>
	/// Session change notifications are sent in the form of a WM_WTSSESSION_CHANGE message. These notifications are sent only to the
	/// windows that have registered for them using this function.
	/// </para>
	/// <para>
	/// When a window no longer requires these notifications, it must call WTSUnRegisterSessionNotification before being destroyed. For
	/// every call to this function, there must be a corresponding call to <c>WTSUnRegisterSessionNotification</c>.
	/// </para>
	/// <para>If the window handle passed in this function is already registered, the value of the dwFlags parameter is ignored.</para>
	/// <para>To receive session change notifications from a service, use the HandlerEx function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsregistersessionnotification BOOL
	// WTSRegisterSessionNotification( HWND hWnd, DWORD dwFlags );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSRegisterSessionNotification")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSRegisterSessionNotification(HWND hWnd, WTSNotification dwFlags);

	/// <summary>Registers the specified window to receive session change notifications.</summary>
	/// <param name="hServer">Handle of the server returned from WTSOpenServer or <c>WTS_CURRENT_SERVER</c>.</param>
	/// <param name="hWnd">Handle of the window to receive session change notifications.</param>
	/// <param name="dwFlags">
	/// <para>
	/// Specifies which session notifications are to be received. This parameter can only be <c>NOTIFY_FOR_THIS_SESSION</c> if hServer
	/// is a remote server.
	/// </para>
	/// <list type="bullet">
	/// <item>NOTIFY_FOR_THIS_SESSION (0)
	/// <para>
	/// Only session notifications involving the session attached to by the window identified by the hWnd parameter value are to be received.
	/// </para>
	/// </item>
	/// <item>NOTIFY_FOR_ALL_SESSIONS (1)
	/// <para>All session notifications are to be received.</para>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>. To get extended error information,
	/// call GetLastError.
	/// </returns>
	/// <remarks>
	/// <para>
	/// If this function is called before the dependent services of Remote Desktop Services have started, an
	/// <c>RPC_S_INVALID_BINDING</c> error code may be returned. When the "Global\TermSrvReadyEvent" global event is set, all dependent
	/// services have started and this function can be successfully called.
	/// </para>
	/// <para>
	/// Session change notifications are sent in the form of a WM_WTSSESSION_CHANGE message. These notifications are sent only to the
	/// windows that have registered for them using this function.
	/// </para>
	/// <para>
	/// When a window no longer requires these notifications, it must call WTSUnRegisterSessionNotificationEx before being destroyed.
	/// For every call to this function, there must be a corresponding call to <c>WTSUnRegisterSessionNotificationEx</c>.
	/// </para>
	/// <para>If the window handle passed in this function is already registered, the value of the dwFlags parameter is ignored.</para>
	/// <para>To receive session change notifications from a service, use the HandlerEx function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsregistersessionnotificationex BOOL
	// WTSRegisterSessionNotificationEx( HANDLE hServer, HWND hWnd, DWORD dwFlags );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSRegisterSessionNotificationEx")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSRegisterSessionNotificationEx(HWTSSERVER hServer, HWND hWnd, WTSNotification dwFlags);

	/// <summary>Displays a message box on the client desktop of a specified Remote Desktop Services session.</summary>
	/// <param name="hServer">
	/// A handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="SessionId">
	/// <para>
	/// A Remote Desktop Services session identifier. To indicate the current session, specify <c>WTS_CURRENT_SESSION</c>. You can use
	/// the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session Host server.
	/// </para>
	/// <para>
	/// To send a message to another user's session, you need to have the Message permission. For more information, see Remote Desktop
	/// Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration administrative tool.
	/// </para>
	/// </param>
	/// <param name="pTitle">A pointer to a null-terminated string for the title bar of the message box.</param>
	/// <param name="TitleLength">The length, in bytes, of the title bar string.</param>
	/// <param name="pMessage">A pointer to a null-terminated string that contains the message to display.</param>
	/// <param name="MessageLength">The length, in bytes, of the message string.</param>
	/// <param name="Style">
	/// The contents and behavior of the message box. This value is typically <c>MB_OK</c>. For a complete list of values, see the uType
	/// parameter of the MessageBox function.
	/// </param>
	/// <param name="Timeout">
	/// The time, in seconds, that the <c>WTSSendMessage</c> function waits for the user's response. If the user does not respond within
	/// the time-out interval, the pResponse parameter returns <c>IDTIMEOUT</c>. If the Timeout parameter is zero, <c>WTSSendMessage</c>
	/// waits indefinitely for the user to respond.
	/// </param>
	/// <param name="pResponse">
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
	/// <para>The bWait parameter was <c>FALSE</c>, so the function returned without waiting for a response.</para>
	/// <para>IDTIMEOUT (32000 (0x7D00))</para>
	/// <para>The bWait parameter was <c>TRUE</c> and the time-out interval elapsed.</para>
	/// </param>
	/// <param name="bWait">
	/// <para>
	/// If <c>TRUE</c>, <c>WTSSendMessage</c> does not return until the user responds or the time-out interval elapses. If the Timeout
	/// parameter is zero, the function does not return until the user responds.
	/// </para>
	/// <para>
	/// If <c>FALSE</c>, the function returns immediately and the pResponse parameter returns <c>IDASYNC</c>. Use this method for simple
	/// information messages (such as print job–notification messages) that do not need to return the user's response to the calling program.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtssendmessagea BOOL WTSSendMessageA( HANDLE hServer,
	// DWORD SessionId, StrPtrAnsi pTitle, DWORD TitleLength, StrPtrAnsi pMessage, DWORD MessageLength, DWORD Style, DWORD Timeout, DWORD
	// *pResponse, BOOL bWait );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSSendMessageA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSSendMessage(HWTSSERVER hServer, uint SessionId, [MarshalAs(UnmanagedType.LPTStr)] string pTitle, int TitleLength,
		[MarshalAs(UnmanagedType.LPTStr)] string pMessage, int MessageLength, uint Style, uint Timeout, out uint pResponse, [MarshalAs(UnmanagedType.Bool)] bool bWait);

	/// <summary>Configures the security descriptor of a Remote Desktop Services listener.</summary>
	/// <param name="hServer">A handle to an RD Session Host server. Always set this parameter to <c>WTS_CURRENT_SERVER_HANDLE</c>.</param>
	/// <param name="pReserved">This parameter is reserved. Always set this parameter to <c>NULL</c>.</param>
	/// <param name="Reserved">This parameter is reserved. Always set this parameter to zero.</param>
	/// <param name="pListenerName">A pointer to a null-terminated string that contains the name of the listener.</param>
	/// <param name="SecurityInformation">
	/// <para>
	/// A SECURITY_INFORMATION value that specifies the security information to set. Always enable the <c>DACL_SECURITY_INFORMATION</c>
	/// and <c>SACL_SECURITY_INFORMATION</c> flags.
	/// </para>
	/// <para>For more information about possible values, see SECURITY_INFORMATION.</para>
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// <para>
	/// A pointer to a SECURITY_DESCRIPTOR structure that contains the security information associated with the listener. For more
	/// information about possible values, see <c>SECURITY_DESCRIPTOR</c>. For information about <c>STANDARD_RIGHTS_REQUIRED</c>, see
	/// Standard Access Rights.
	/// </para>
	/// <para>The discretionary access control list (DACL) of the security descriptor can contain one or more of the following values.</para>
	/// <para>WTS_SECURITY_ALL_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>STANDARD_RIGHTS_REQUIRED</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_CONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_DISCONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_LOGON</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_MESSAGE</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_QUERY_INFORMATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_REMOTE_CONTROL</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_RESET</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_SET_INFORMATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_VIRTUAL_CHANNELS</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_CONNECT (256 (0x100))</para>
	/// <para>The right to connect.</para>
	/// <para>WTS_SECURITY_CURRENT_GUEST_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WTS_SECURITY_LOGOFF</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_VIRTUAL_CHANNELS</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_CURRENT_USER_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WTS_SECURITY_DISCONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_LOGOFF</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_RESET</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_SET_INFORMATION</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_VIRTUAL_CHANNELS</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_DISCONNECT (512 (0x200))</para>
	/// <para>The right to disconnect.</para>
	/// <para>WTS_SECURITY_GUEST_ACCESS</para>
	/// <para>Defined as <c>WTS_SECURITY_LOGON</c>.</para>
	/// <para>WTS_SECURITY_LOGOFF (64 (0x40))</para>
	/// <para>The right to log off.</para>
	/// <para>WTS_SECURITY_LOGON (32 (0x20))</para>
	/// <para>The right to log on.</para>
	/// <para>WTS_SECURITY_MESSAGE (128 (0x80))</para>
	/// <para>The right to send a message to the user.</para>
	/// <para>WTS_SECURITY_QUERY_INFORMATION (1 (0x1))</para>
	/// <para>The right to query for information.</para>
	/// <para>WTS_SECURITY_REMOTE_CONTROL (16 (0x10))</para>
	/// <para>The right to use remote control.</para>
	/// <para>WTS_SECURITY_RESET (4 (0x4))</para>
	/// <para>The right to reset information.</para>
	/// <para>WTS_SECURITY_SET_INFORMATION (2 (0x2))</para>
	/// <para>The right to set information.</para>
	/// <para>WTS_SECURITY_USER_ACCESS</para>
	/// <para>Combines these values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WTS_SECURITY_CONNECT</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_CURRENT_GUEST_ACCESS</c></term>
	/// </item>
	/// <item>
	/// <term><c>WTS_SECURITY_QUERY_INFORMATION</c></term>
	/// </item>
	/// </list>
	/// <para>WTS_SECURITY_VIRTUAL_CHANNELS (8 (0x8))</para>
	/// <para>The right to use virtual channels.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtssetlistenersecuritya BOOL WTSSetListenerSecurityA(
	// HANDLE hServer, PVOID pReserved, DWORD Reserved, StrPtrAnsi pListenerName, SECURITY_INFORMATION SecurityInformation,
	// PSECURITY_DESCRIPTOR pSecurityDescriptor );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSSetListenerSecurityA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSSetListenerSecurity(HWTSSERVER hServer, [In, Optional] IntPtr pReserved, [In, Optional] uint Reserved,
		[MarshalAs(UnmanagedType.LPTStr)] string pListenerName, SECURITY_INFORMATION SecurityInformation, [In] PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>
	/// Modifies configuration information for the specified user on the specified domain controller or Remote Desktop Session Host (RD
	/// Session Host) server.
	/// </summary>
	/// <param name="pServerName">
	/// Pointer to a null-terminated string containing the name of a domain controller or RD Session Host server. Specify
	/// <c>WTS_CURRENT_SERVER_NAME</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="pUserName">Pointer to a null-terminated string containing the name of the user whose configuration is being set.</param>
	/// <param name="WTSConfigClass">
	/// Specifies the type of information to set for the user. This parameter can be one of the values from the WTS_CONFIG_CLASS
	/// enumeration type. The documentation for <c>WTS_CONFIG_CLASS</c> describes the format of the data specified in ppBuffer for each
	/// of the information types.
	/// </param>
	/// <param name="pBuffer">Pointer to the data used to modify the specified user's configuration.</param>
	/// <param name="DataLength">Size, in <c>TCHARs</c>, of the pBuffer buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The WTSQueryUserConfig and <c>WTSSetUserConfig</c> functions are passed a server name instead of a handle because user account
	/// information often resides on a domain controller. To set user configuration information, use the primary domain controller. You
	/// can call the NetGetDCName function to get the name of the primary domain controller. To query user configuration information,
	/// you can use the NetGetAnyDCName function to get the name of a primary or backup domain controller.
	/// </para>
	/// <para>
	/// Any domain controller can set or query user configuration information. Use the DsGetDcName function to retrieve the name of a
	/// domain controller.
	/// </para>
	/// <para>
	/// If the value of the WTSConfigClass parameter corresponds to an integer value in the WTS_CONFIG_CLASS enumeration, define the
	/// value to be set as a <c>DWORD</c>. Then cast the value to an <c>StrPtrUni</c> in the call to <c>WTSSetUserConfig</c>, as in the
	/// following example:
	/// </para>
	/// <para>
	/// <code>WTSSetUserConfig( strServer.GetBuffer(0), m_strName.GetBuffer(0), WTSUserConfigfAllowLogonTerminalServer, (StrPtrUni) &amp;dwEnable, sizeof(DWORD));</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtssetuserconfiga BOOL WTSSetUserConfigA( StrPtrAnsi
	// pServerName, StrPtrAnsi pUserName, WTS_CONFIG_CLASS WTSConfigClass, StrPtrAnsi pBuffer, DWORD DataLength );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSSetUserConfigA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSSetUserConfig([MarshalAs(UnmanagedType.LPTStr)] string pServerName, [MarshalAs(UnmanagedType.LPTStr)] string pUserName,
		WTS_CONFIG_CLASS WTSConfigClass, [MarshalAs(UnmanagedType.LPTStr)] string pBuffer, int DataLength);

	/// <summary>
	/// <para>Shuts down (and optionally restarts) the specified Remote Desktop Session Host (RD Session Host) server.</para>
	/// <para>
	/// To shut down or restart the system, the calling process must have the <c>SE_SHUTDOWN_NAME</c> privilege enabled. For more
	/// information about security privileges, see Privileges and Authorization Constants.
	/// </para>
	/// </summary>
	/// <param name="hServer">
	/// Handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify
	/// <c>WTS_CURRENT_SERVER_HANDLE</c> to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="ShutdownFlag">
	/// <para>Indicates the type of shutdown. This parameter can be one of the following values.</para>
	/// <para>WTS_WSD_LOGOFF</para>
	/// <para>
	/// Forces all client sessions to log off (except the session calling <c>WTSShutdownSystem</c>) and disables any subsequent remote
	/// logons. This can be used as a step before shutting down. Logons will be re-enabled when the Remote Desktop Services service is restarted.
	/// </para>
	/// <para>Use this value only on the Remote Desktop Services console.</para>
	/// <para>WTS_WSD_POWEROFF</para>
	/// <para>
	/// Shuts down the system on the RD Session Host server and, on computers that support software control of AC power, turns off the
	/// power. This is equivalent to calling ExitWindowsEx with <c>EWX_SHUTDOWN</c> and <c>EWX_POWEROFF</c>. The calling process must
	/// have the <c>SE_SHUTDOWN_NAME</c> privilege enabled.
	/// </para>
	/// <para>WTS_WSD_REBOOT</para>
	/// <para>
	/// Shuts down and then restarts the system on the RD Session Host server. This is equivalent to calling <c>ExitWindowsEx</c> with
	/// <c>EWX_REBOOT</c>. The calling process must have the <c>SE_SHUTDOWN_NAME</c> privilege enabled.
	/// </para>
	/// <para>WTS_WSD_SHUTDOWN</para>
	/// <para>
	/// Shuts down the system on the RD Session Host server. This is equivalent to calling the ExitWindowsEx function with
	/// <c>EWX_SHUTDOWN</c>. The calling process must have the <c>SE_SHUTDOWN_NAME</c> privilege enabled.
	/// </para>
	/// <para>WTS_WSD_FASTREBOOT</para>
	/// <para>This value is not supported currently.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>A system shutdown terminates all users and active programs. The following steps occur during shutdown.</para>
	/// <list type="number">
	/// <item>
	/// <term>An exit command is issued to all active user applications.</term>
	/// </item>
	/// <item>
	/// <term>If the application does not exit within a specific interval, the application is terminated.</term>
	/// </item>
	/// <item>
	/// <term>After all the applications for a user terminate, the user is logged off.</term>
	/// </item>
	/// <item>
	/// <term>After all users are logged off, an exit command is issued to all system services.</term>
	/// </item>
	/// <item>
	/// <term>If the system service does not terminate within a specific interval, the service is terminated.</term>
	/// </item>
	/// <item>
	/// <term>The file system cache is written to disk.</term>
	/// </item>
	/// <item>
	/// <term>The disks are marked read-only.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The RD Session Host server displays the message "It is now safe to turn off your computer", or the system is restarted if
	/// <c>WTS_WSD_REBOOT</c> is specified. (The message is displayed on the console because all client sessions have been terminated.)
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Because there can be many users and processes in a large multiple-user configuration, large system configurations
	/// may take some time to shut down in an orderly fashion. It is important to allow the system to shut down completely.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008 and Windows Vista:</c> A call to <c>WTSShutdownSystem</c> does not work when Remote Connection Manager
	/// (RCM) is disabled. This is the case when the Remote Desktop Services service is stopped.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsshutdownsystem BOOL WTSShutdownSystem( HANDLE hServer,
	// DWORD ShutdownFlag );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSShutdownSystem")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSShutdownSystem(HWTSSERVER hServer, WTS_WSD ShutdownFlag);

	/// <summary>
	/// Starts the remote control of another Remote Desktop Services session. You must call this function from a remote session.
	/// </summary>
	/// <param name="pTargetServerName">A pointer to the name of the server where the session that you want remote control of exists.</param>
	/// <param name="TargetLogonId">The logon ID of the session that you want remote control of.</param>
	/// <param name="HotkeyVk">
	/// The virtual-key code that represents the key to press to stop remote control of the session. The key that is defined in this
	/// parameter is used with the HotkeyModifiers parameter.
	/// </param>
	/// <param name="HotkeyModifiers">
	/// <para>
	/// The virtual modifier that represents the key to press to stop remote control of the session. The virtual modifier is used with
	/// the HotkeyVk parameter.
	/// </para>
	/// <para>
	/// For example, if the <c>WTSStartRemoteControlSession</c> function is called with HotkeyVk set to <c>VK_MULTIPLY</c> and
	/// HotkeyModifiers set to <c>REMOTECONTROL_KBDCTRL_HOTKEY</c>, the user who has remote control of the target session can press CTRL
	/// + * to stop remote control of the session and return to their own session.
	/// </para>
	/// <para>REMOTECONTROL_KBDSHIFT_HOTKEY</para>
	/// <para>The SHIFT key</para>
	/// <para>REMOTECONTROL_KBDCTRL_HOTKEY</para>
	/// <para>The CTRL key</para>
	/// <para>REMOTECONTROL_KBDALT_HOTKEY</para>
	/// <para>The ALT key</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsstartremotecontrolsessiona BOOL
	// WTSStartRemoteControlSessionA( StrPtrAnsi pTargetServerName, ULONG TargetLogonId, BYTE HotkeyVk, USHORT HotkeyModifiers );
	[DllImport(Lib_WTSApi32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSStartRemoteControlSessionA")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSStartRemoteControlSession([MarshalAs(UnmanagedType.LPTStr)] string pTargetServerName, uint TargetLogonId,
		byte HotkeyVk, REMOTECONTROL_HOTKEY HotkeyModifiers);

	/// <summary>Stops a remote control session.</summary>
	/// <param name="LogonId">The logon ID of the session that you want to stop the remote control of.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsstopremotecontrolsession BOOL
	// WTSStopRemoteControlSession( ULONG LogonId );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSStopRemoteControlSession")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSStopRemoteControlSession(uint LogonId);

	/// <summary>Terminates the specified process on the specified Remote Desktop Session Host (RD Session Host) server.</summary>
	/// <param name="hServer">
	/// Handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify WTS_CURRENT_SERVER_HANDLE
	/// to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="ProcessId">Specifies the process identifier of the process to terminate.</param>
	/// <param name="ExitCode">Specifies the exit code for the terminated process.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsterminateprocess BOOL WTSTerminateProcess( HANDLE
	// hServer, DWORD ProcessId, DWORD ExitCode );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSTerminateProcess")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSTerminateProcess(HWTSSERVER hServer, uint ProcessId, uint ExitCode);

	/// <summary>Unregisters the specified window so that it receives no further session change notifications.</summary>
	/// <param name="hWnd">Handle of the window to be unregistered from receiving session notifications.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>. To get extended error information,
	/// call GetLastError.
	/// </returns>
	/// <remarks>This function must be called once for every call to the WTSRegisterSessionNotification function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsunregistersessionnotification BOOL
	// WTSUnRegisterSessionNotification( HWND hWnd );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSUnRegisterSessionNotification")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSUnRegisterSessionNotification(HWND hWnd);

	/// <summary>Unregisters the specified window so that it receives no further session change notifications.</summary>
	/// <param name="hServer">Handle of the server returned from WTSOpenServer or <c>WTS_CURRENT_SERVER</c>.</param>
	/// <param name="hWnd">Handle of the window to be unregistered from receiving session notifications.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>TRUE</c>. Otherwise, it is <c>FALSE</c>. To get extended error information,
	/// call GetLastError.
	/// </returns>
	/// <remarks>This function must be called once for every call to the WTSRegisterSessionNotificationEx function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsunregistersessionnotificationex BOOL
	// WTSUnRegisterSessionNotificationEx( HANDLE hServer, HWND hWnd );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSUnRegisterSessionNotificationEx")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSUnRegisterSessionNotificationEx(HWTSSERVER hServer, HWND hWnd);

	/// <summary>Closes an open virtual channel handle.</summary>
	/// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelclose BOOL WTSVirtualChannelClose(
	// HANDLE hChannelHandle );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelClose")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSVirtualChannelClose(HVIRTUALCHANNEL hChannelHandle);

	/// <summary>
	/// <para>Opens a handle to the server end of a specified virtual channel.</para>
	/// <para>This function is obsolete. Instead, use the WTSVirtualChannelOpenEx function.</para>
	/// </summary>
	/// <param name="hServer">This parameter must be WTS_CURRENT_SERVER_HANDLE.</param>
	/// <param name="SessionId">
	/// <para>
	/// A Remote Desktop Services session identifier. To indicate the current session, specify <c>WTS_CURRENT_SESSION</c>. You can use
	/// the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session Host server.
	/// </para>
	/// <para>
	/// To open a virtual channel on another user's session, you need to have permission from the Virtual Channel. For more information,
	/// see Remote Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services Configuration
	/// administrative tool.
	/// </para>
	/// </param>
	/// <param name="pVirtualName">
	/// A pointer to a <c>null</c>-terminated string containing the virtual channel name. Note that this is an ANSI string even when
	/// UNICODE is defined. The virtual channel name consists of one to CHANNEL_NAME_LEN characters, not including the terminating <c>null</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the specified virtual channel.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>When you have finished using the handle, release it by calling the WTSVirtualChannelClose function.</para>
	/// <para>
	/// For an example that shows how to gain access to a virtual channel file handle that can be used for asynchronous I/O, see WTSVirtualChannelQuery.
	/// </para>
	/// <para>
	/// If you try to use this function to open the same virtual channel multiple times, it can cause a 10-second delay and disrupt the
	/// established channel.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelopen HANDLE WTSVirtualChannelOpen(
	// HANDLE hServer, DWORD SessionId, StrPtrAnsi pVirtualName );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelOpen")]
	public static extern SafeHVIRTUALCHANNEL WTSVirtualChannelOpen(HWTSSERVER hServer, uint SessionId, [MarshalAs(UnmanagedType.LPStr)] string pVirtualName);

	/// <summary>
	/// <para>Creates a virtual channel in a manner similar to WTSVirtualChannelOpen.</para>
	/// <para>
	/// This API supports both static virtual channel (SVC) and dynamic virtual channel (DVC) creation. If the flags parameter is zero,
	/// it behaves the same as WTSVirtualChannelOpen. A DVC can be opened by specifying the appropriate flag. After a DVC is created,
	/// you can use the same functions for Read, Write, Query, or Close that are used for the SVC.
	/// </para>
	/// </summary>
	/// <param name="SessionId">
	/// <para>
	/// A Remote Desktop Services session identifier. To indicate the current session, specify <c>WTS_CURRENT_SESSION</c>. You can use
	/// the WTSEnumerateSessions function to retrieve the identifiers of all sessions on a specified RD Session Host server.
	/// </para>
	/// <para>
	/// To be able to open a virtual channel on another user's session, you must have the Virtual Channels permission. For more
	/// information, see Remote Desktop Services Permissions. To modify permissions on a session, use the Remote Desktop Services
	/// Configuration administrative tool.
	/// </para>
	/// </param>
	/// <param name="pVirtualName">
	/// <para>
	/// In the case of an SVC, points to a null-terminated string that contains the virtual channel name. The length of an SVC name is
	/// limited to <c>CHANNEL_NAME_LEN</c> characters, not including the terminating null.
	/// </para>
	/// <para>
	/// In the case of a DVC, points to a null-terminated string that contains the endpoint name of the listener. The length of a DVC
	/// name is limited to <c>MAX_PATH</c> characters.
	/// </para>
	/// </param>
	/// <param name="flags">
	/// <para>To open the channel as an SVC, specify zero for this parameter. To open the channel as a DVC, specify <c>WTS_CHANNEL_OPTION_DYNAMIC</c>.</para>
	/// <para>
	/// When opening a DVC, you can specify a priority setting for the data that is being transferred by specifying one of the
	/// <c>WTS_CHANNEL_OPTION_DYNAMIC_PRI_XXX</c> values in combination with the <c>WTS_CHANNEL_OPTION_DYNAMIC</c> value.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <strong>WTS_CHANNEL_OPTION_DYNAMIC_NO_COMPRESS</strong><br/> Disables compression for this DVC. You must specify this value in
	/// combination with the <c>WTS_CHANNEL_OPTION_DYNAMIC</c> value.
	/// </item>
	/// <item>
	/// <strong>WTS_CHANNEL_OPTION_DYNAMIC_PRI_LOW</strong> (default) <br/> Low priority. The data will be sent on both sides with low
	/// priority. Use this priority level for block transfers of all sizes, where the transfer speed is not important. In almost all
	/// (95%) cases, the channel should be opened with this flag.
	/// </item>
	/// <item>
	/// <strong>WTS_CHANNEL_OPTION_DYNAMIC_PRI_MED</strong><br/> Medium priority. Use this priority level to send short control messages
	/// that must have priority over the data in the low priority channels.
	/// </item>
	/// <item>
	/// <strong>WTS_CHANNEL_OPTION_DYNAMIC_PRI_HIGH</strong><br/> High priority. Use this priority level for data that is critical and
	/// directly affects the user experience. The transfer size may vary. Display data falls into this category.
	/// </item>
	/// <item>
	/// <strong>WTS_CHANNEL_OPTION_DYNAMIC_PRI_REAL</strong><br/> Real-time priority. Use this priority level only in cases where the
	/// data transfer is absolutely critical. The data transfer size should be limited to a few hundred bytes per message.
	/// </item>
	/// </list>
	/// </param>
	/// <returns><c>NULL</c> on error with GetLastError set.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelopenex HANDLE WTSVirtualChannelOpenEx(
	// DWORD SessionId, StrPtrAnsi pVirtualName, DWORD flags );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelOpenEx")]
	public static extern SafeHVIRTUALCHANNEL WTSVirtualChannelOpenEx(uint SessionId, [MarshalAs(UnmanagedType.LPStr)] string pVirtualName, WTS_CHANNEL_OPTION flags);

	/// <summary>Deletes all queued input data sent from the client to the server on a specified virtual channel.</summary>
	/// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelpurgeinput BOOL
	// WTSVirtualChannelPurgeInput( HANDLE hChannelHandle );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelPurgeInput")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSVirtualChannelPurgeInput(HVIRTUALCHANNEL hChannelHandle);

	/// <summary>Deletes all queued output data sent from the server to the client on a specified virtual channel.</summary>
	/// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelpurgeoutput BOOL
	// WTSVirtualChannelPurgeOutput( HANDLE hChannelHandle );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelPurgeOutput")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSVirtualChannelPurgeOutput(HVIRTUALCHANNEL hChannelHandle);

	/// <summary>Returns information about a specified virtual channel.</summary>
	/// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function.</param>
	/// <param name="WTSVirtualClass">Specifies the type of information to get for the channel.</param>
	/// <param name="ppBuffer">Pointer to a buffer that receives the requested information.</param>
	/// <param name="pBytesReturned">Pointer to a variable that receives the number of bytes returned in the ppBuffer parameter.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is a nonzero value. Call the WTSFreeMemory function with the value returned in the
	/// ppBuffer parameter to free the temporary memory allocated by <c>WTSVirtualChannelQuery</c>.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The following example shows how to gain access to a virtual channel file handle that can be used for asynchronous I/O. First the
	/// code opens a virtual channel by using a call to the WTSVirtualChannelOpen function. Then the code calls the
	/// <c>WTSVirtualChannelQuery</c> function, specifying the WTSVirtualFileHandle virtual class type. <c>WTSVirtualChannelQuery</c>
	/// returns a file handle that you can use to perform asynchronous (overlapped) read and write operations. Finally, the code frees
	/// the memory allocated by <c>WTSVirtualChannelQuery</c> with a call to the WTSFreeMemory function, and closes the virtual channel
	/// with a call to the WTSVirtualChannelClose function.
	/// </para>
	/// <para>
	/// Note that you should not explicitly close the file handle obtained by calling <c>WTSVirtualChannelQuery</c>. This is because
	/// WTSVirtualChannelClose closes the file handle.
	/// </para>
	/// <para><code language="cpp"><![CDATA[PVOID vcFileHandlePtr = NULL;
	/// DWORD len;
	/// DWORD result = ERROR_SUCCESS;
	/// HANDLE vcHandle = NULL;
	/// HANDLE vcFileHandle = NULL;
	/// //
	/// // Open a virtual channel.
	/// //
	/// vcHandle = WTSVirtualChannelOpen(
	///    WTS_CURRENT_SERVER_HANDLE, // Current TS Server
	///    WTS_CURRENT_SESSION,       // Current TS Session
	///    (StrPtrAnsi) "TSTCHNL"          // Channel name
	/// );
	/// 
	/// if (vcHandle == NULL)
	/// {
	///    result = GetLastError();
	/// }
	/// 
	/// //
	/// // Gain access to the underlying file handle for
	/// // asynchronous I/O.
	/// //
	/// if (result == ERROR_SUCCESS)
	/// {
	///    if (!WTSVirtualChannelQuery(vcHandle, WTSVirtualFileHandle, &vcFileHandlePtr, &len))
	///    {
	///       result = GetLastError();
	///    }
	/// }
	/// 
	/// //
	/// // Copy the data and
	/// // free the buffer allocated by WTSVirtualChannelQuery.
	/// //
	/// if (result == ERROR_SUCCESS)
	/// {
	///    memcpy(&vcFileHandle, vcFileHandlePtr, sizeof(vcFileHandle));
	///    WTSFreeMemory(vcFileHandlePtr);
	///    
	///    //
	///    // Use vcFileHandle for overlapped reads and writes here.
	///    //
	///    //.
	///    //.
	///    //.
	/// }
	/// 
	/// //
	/// // Call WTSVirtualChannelClose to close the virtual channel.
	/// // Note: do not close the file handle.
	/// //
	/// if (vcHandle != NULL)
	/// {
	///    WTSVirtualChannelClose(vcHandle);
	///    vcFileHandle = NULL;
	/// }]]></code></para>
	/// <para>For more information about overlapped mode, see Synchronization and Overlapped Input and Output.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelquery BOOL WTSVirtualChannelQuery(
	// HANDLE hChannelHandle, WTS_VIRTUAL_CLASS , PVOID *ppBuffer, DWORD *pBytesReturned );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelQuery")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSVirtualChannelQuery(HVIRTUALCHANNEL hChannelHandle, WTS_VIRTUAL_CLASS WTSVirtualClass, out SafeWTSMemoryHandle ppBuffer, out uint pBytesReturned);

	/// <summary>
	/// <para>Reads data from the server end of a virtual channel.</para>
	/// <para><c>WTSVirtualChannelRead</c> reads the data written by a VirtualChannelWrite call at the client end of the virtual channel.</para>
	/// </summary>
	/// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function.</param>
	/// <param name="TimeOut">
	/// Specifies the time-out, in milliseconds. If TimeOut is zero, <c>WTSVirtualChannelRead</c> returns immediately if there is no
	/// data to read. If TimeOut is INFINITE (defined in Winbase.h), the function waits indefinitely until there is data to read.
	/// </param>
	/// <param name="Buffer">
	/// <para>
	/// Pointer to a buffer that receives a chunk of data read from the server end of the virtual channel. The maximum amount of data
	/// that the server can receive in a single <c>WTSVirtualChannelRead</c> call is <c>CHANNEL_CHUNK_LENGTH</c> bytes. If the client's
	/// VirtualChannelWrite call writes a larger block of data, the server must make multiple <c>WTSVirtualChannelRead</c> calls.
	/// </para>
	/// <para>
	/// In certain cases, Remote Desktop Services places a <c>CHANNEL_PDU_HEADER</c> structure at the beginning of each chunk of data
	/// read by the <c>WTSVirtualChannelRead</c> function. This will occur if the client DLL sets the
	/// <c>CHANNEL_OPTION_SHOW_PROTOCOL</c> option when it calls the VirtualChannelInit function to initialize the virtual channel. This
	/// will also occur if the channel is a dynamic virtual channel written to by using the IWTSVirtualChannel::Write method. Otherwise,
	/// the buffer receives only the data written in the VirtualChannelWrite call.
	/// </para>
	/// </param>
	/// <param name="BufferSize">
	/// Specifies the size, in bytes, of Buffer. If the chunk of data in Buffer will be preceded by a <c>CHANNEL_PDU_HEADER</c>
	/// structure, the value of this parameter should be at least <c>CHANNEL_PDU_LENGTH</c>. Otherwise, the value of this parameter
	/// should be at least <c>CHANNEL_CHUNK_LENGTH</c>.
	/// </param>
	/// <param name="pBytesRead">Pointer to a variable that receives the number of bytes read.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <c>Note</c><c>WTSVirtualChannelRead</c> is not thread safe. To access a virtual channel from multiple threads, or to do
	/// asynchronous IO through a virtual channel, use WTSVirtualChannelQuery with <c>WTSVirtualFileHandle</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelread BOOL WTSVirtualChannelRead( HANDLE
	// hChannelHandle, ULONG TimeOut, PCHAR Buffer, ULONG BufferSize, PULONG pBytesRead );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelRead")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSVirtualChannelRead(HVIRTUALCHANNEL hChannelHandle, uint TimeOut, [Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder Buffer,
		uint BufferSize, out uint pBytesRead);

	/// <summary>Writes data to the server end of a virtual channel.</summary>
	/// <param name="hChannelHandle">Handle to a virtual channel opened by the WTSVirtualChannelOpen function.</param>
	/// <param name="Buffer">Pointer to a buffer containing the data to write to the virtual channel.</param>
	/// <param name="Length">Specifies the size, in bytes, of the data to write.</param>
	/// <param name="pBytesWritten">Pointer to a variable that receives the number of bytes written.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <c>Note</c><c>WTSVirtualChannelWrite</c> is not thread safe. To access a virtual channel from multiple threads, or to do
	/// asynchronous IO through a virtual channel, use WTSVirtualChannelQuery with <c>WTSVirtualFileHandle</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtsvirtualchannelwrite BOOL WTSVirtualChannelWrite(
	// HANDLE hChannelHandle, PCHAR Buffer, ULONG Length, PULONG pBytesWritten );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSVirtualChannelWrite")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSVirtualChannelWrite(HVIRTUALCHANNEL hChannelHandle, [MarshalAs(UnmanagedType.LPStr)] string Buffer, uint Length, out uint pBytesWritten);

	/// <summary>Waits for a Remote Desktop Services event before returning to the caller.</summary>
	/// <param name="hServer">
	/// Handle to an RD Session Host server. Specify a handle opened by the WTSOpenServer function, or specify WTS_CURRENT_SERVER_HANDLE
	/// to indicate the RD Session Host server on which your application is running.
	/// </param>
	/// <param name="EventMask">
	/// <para>
	/// Bitmask that specifies the set of events to wait for. This mask can be WTS_EVENT_FLUSH to cause all pending
	/// <c>WTSWaitSystemEvent</c> calls on the specified RD Session Host server handle to return. Or, the mask can be a combination of
	/// the following values.
	/// </para>
	/// <para>WTS_EVENT_ALL</para>
	/// <para>Wait for any event type.</para>
	/// <para>WTS_EVENT_CONNECT</para>
	/// <para>A client connected to a WinStation.</para>
	/// <para>WTS_EVENT_CREATE</para>
	/// <para>A new WinStation was created.</para>
	/// <para>WTS_EVENT_DELETE</para>
	/// <para>An existing WinStation was deleted.</para>
	/// <para>WTS_EVENT_DISCONNECT</para>
	/// <para>A client disconnected from a WinStation.</para>
	/// <para>WTS_EVENT_LICENSE</para>
	/// <para>The Remote Desktop Services' license state changed. This occurs when a license is added or deleted using License Manager.</para>
	/// <para>WTS_EVENT_LOGOFF</para>
	/// <para>A user logged off from either the Remote Desktop Services console or from a client WinStation.</para>
	/// <para>WTS_EVENT_LOGON</para>
	/// <para>A user logged on to the system from either the Remote Desktop Services console or from a client WinStation.</para>
	/// <para>WTS_EVENT_RENAME</para>
	/// <para>An existing WinStation was renamed.</para>
	/// <para>WTS_EVENT_STATECHANGE</para>
	/// <para>A WinStation connection state changed. For a list of connection states, see the WTS_CONNECTSTATE_CLASS enumeration type.</para>
	/// </param>
	/// <param name="pEventFlags">
	/// Pointer to a variable that receives a bitmask of the event or events that occurred. The returned mask can be a combination of
	/// the values from the previous list, or it can be <c>WTS_EVENT_NONE</c> if the wait terminated because of a
	/// <c>WTSWaitSystemEvent</c> call with <c>WTS_EVENT_FLUSH</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/nf-wtsapi32-wtswaitsystemevent BOOL WTSWaitSystemEvent( HANDLE
	// hServer, DWORD EventMask, DWORD *pEventFlags );
	[DllImport(Lib_WTSApi32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wtsapi32.h", MSDNShortId = "NF:wtsapi32.WTSWaitSystemEvent")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WTSWaitSystemEvent(HVIRTUALCHANNEL hServer, WTS_EVENT EventMask, out WTS_EVENT pEventFlags);

	public partial struct HWTSSERVER
	{
		/// <summary>A constant representing the handle of the current WTS server.</summary>
		public static readonly HWTSSERVER WTS_CURRENT_SERVER_HANDLE = NULL;

		/// <summary>A constant representing the handle of the current WTS server.</summary>
		public static readonly HWTSSERVER WTS_CURRENT_SERVER = NULL;
	}

	/// <summary>Contains the client network address of a Remote Desktop Services session.</summary>
	/// <remarks>
	/// <para>
	/// The client network address is reported by the RDP client itself when it connects to the server. This could be different than the
	/// address that actually connected to the server. For example, suppose there is a NAT between the client and the server. The client
	/// can report its own IP address, but the IP address that actually connects to the server is the NAT address. For VPN connections,
	/// the IP address might not be discoverable by the client. If it cannot be discovered, the client can report the only IP address it
	/// has, which may be the ISP assigned address. Because the address may not be the actual network address, it should not be used as
	/// a form of client authentication.
	/// </para>
	/// <para>The client network address is also not available in the following cases:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The connection is established through a Remote Desktop Gateway.</term>
	/// </item>
	/// <item>
	/// <term>The connection is originated by the <c>Microsoft Remote Desktop</c> app that is available in the Store.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_client_address typedef struct _WTS_CLIENT_ADDRESS {
	// DWORD AddressFamily; BYTE Address[20]; } WTS_CLIENT_ADDRESS, *PWTS_CLIENT_ADDRESS;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_CLIENT_ADDRESS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WTS_CLIENT_ADDRESS
	{
		/// <summary>Address family. This member can be <c>AF_INET</c>, <c>AF_INET6</c>, <c>AF_IPX</c>, <c>AF_NETBIOS</c>, or <c>AF_UNSPEC</c>.</summary>
		public uint AddressFamily;

		/// <summary>
		/// <para>
		/// Client network address. The format of the field of <c>Address</c> depends on the address type as specified by the
		/// <c>AddressFamily</c> member.
		/// </para>
		/// <para>
		/// For an address family <c>AF_INET</c>: <c>Address</c> contains the IPV4 address of the client as a null-terminated string.
		/// </para>
		/// <para>
		/// For an family <c>AF_INET6</c>: <c>Address</c> contains the IPV6 address of the client as raw byte values. (For example, the
		/// address "FFFF::1" would be represented as the following series of byte values: "0xFF 0xFF 0x00 0x00 0x00 0x00 0x00 0x00 0x00
		/// 0x00 0x00 0x00 0x00 0x00 0x00 0x01")
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] Address;
	}

	/// <summary>Contains information about the display of a Remote Desktop Connection (RDC) client.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_client_display typedef struct _WTS_CLIENT_DISPLAY {
	// DWORD HorizontalResolution; DWORD VerticalResolution; DWORD ColorDepth; } WTS_CLIENT_DISPLAY, *PWTS_CLIENT_DISPLAY;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_CLIENT_DISPLAY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WTS_CLIENT_DISPLAY
	{
		/// <summary>Horizontal dimension, in pixels, of the client's display.</summary>
		public uint HorizontalResolution;

		/// <summary>Vertical dimension, in pixels, of the client's display.</summary>
		public uint VerticalResolution;

		/// <summary>
		/// <para>Color depth of the client's display. This member can be one of the following values.</para>
		/// <para>1</para>
		/// <para>4 bits per pixel.</para>
		/// <para>2</para>
		/// <para>8 bits per pixel.</para>
		/// <para>4</para>
		/// <para>16 bits per pixel.</para>
		/// <para>8</para>
		/// <para>A 3-byte RGB values for a maximum of 2^24 colors.</para>
		/// <para>16</para>
		/// <para>15 bits per pixel.</para>
		/// <para>24</para>
		/// <para>24 bits per pixel.</para>
		/// <para>32</para>
		/// <para>32 bits per pixel.</para>
		/// </summary>
		public uint ColorDepth;
	}

	/// <summary>Contains information about a process running on a Remote Desktop Session Host (RD Session Host) server.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_process_infoa typedef struct _WTS_PROCESS_INFOA {
	// DWORD SessionId; DWORD ProcessId; StrPtrAnsi pProcessName; PSID pUserSid; } WTS_PROCESS_INFOA, *PWTS_PROCESS_INFOA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_PROCESS_INFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTS_PROCESS_INFO
	{
		/// <summary>Remote Desktop Services session identifier for the session associated with the process.</summary>
		public uint SessionId;

		/// <summary>Process identifier that uniquely identifies the process on the RD Session Host server.</summary>
		public uint ProcessId;

		/// <summary>Pointer to a null-terminated string containing the name of the executable file associated with the process.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pProcessName;

		/// <summary>
		/// Pointer to the user Security Identifiers in the process's primary access token. For more information about SIDs and access
		/// tokens, see Access Control.
		/// </summary>
		public PSID pUserSid;
	}

	/// <summary>
	/// Contains extended information about a process running on a Remote Desktop Session Host (RD Session Host) server. This structure
	/// is returned by the WTSEnumerateProcessesEx function when you set the pLevel parameter to one.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_process_info_exa typedef struct _WTS_PROCESS_INFO_EXA
	// { DWORD SessionId; DWORD ProcessId; StrPtrAnsi pProcessName; PSID pUserSid; DWORD NumberOfThreads; DWORD HandleCount; DWORD
	// PagefileUsage; DWORD PeakPagefileUsage; DWORD WorkingSetSize; DWORD PeakWorkingSetSize; LARGE_INTEGER UserTime; LARGE_INTEGER
	// KernelTime; } WTS_PROCESS_INFO_EXA, *PWTS_PROCESS_INFO_EXA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_PROCESS_INFO_EXA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTS_PROCESS_INFO_EX
	{
		/// <summary>The Remote Desktop Services session identifier for the session associated with the process.</summary>
		public uint SessionId;

		/// <summary>The process identifier that uniquely identifies the process on the RD Session Host server.</summary>
		public uint ProcessId;

		/// <summary>A pointer to a null-terminated string that contains the name of the executable file associated with the process.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pProcessName;

		/// <summary>
		/// A pointer to the user security identifiers (SIDs) in the primary access token of the process. For more information about
		/// SIDs and access tokens, see Access Control and Security Identifiers.
		/// </summary>
		public PSID pUserSid;

		/// <summary>The number of threads in the process.</summary>
		public uint NumberOfThreads;

		/// <summary>The number of handles in the process.</summary>
		public uint HandleCount;

		/// <summary>The page file usage of the process, in bytes.</summary>
		public uint PagefileUsage;

		/// <summary>The peak page file usage of the process, in bytes.</summary>
		public uint PeakPagefileUsage;

		/// <summary>The working set size of the process, in bytes.</summary>
		public uint WorkingSetSize;

		/// <summary>The peak working set size of the process, in bytes.</summary>
		public uint PeakWorkingSetSize;

		/// <summary>The amount of time, in milliseconds, the process has been running in user mode.</summary>
		public long UserTime;

		/// <summary>The amount of time, in milliseconds, the process has been running in kernel mode.</summary>
		public long KernelTime;
	}

	/// <summary>Contains information about a specific Remote Desktop Services server.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_server_infoa typedef struct _WTS_SERVER_INFOA { StrPtrAnsi
	// pServerName; } WTS_SERVER_INFOA, *PWTS_SERVER_INFOA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_SERVER_INFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTS_SERVER_INFO
	{
		/// <summary>Name of the server.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pServerName;
	}

	/// <summary>
	/// Contains the virtual IP address assigned to a session. This structure is returned by the WTSQuerySessionInformation function
	/// when you specify "WTSSessionAddressV4" for the WTSInfoClass parameter.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_session_address typedef struct _WTS_SESSION_ADDRESS {
	// DWORD AddressFamily; BYTE Address[20]; } WTS_SESSION_ADDRESS, *PWTS_SESSION_ADDRESS;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_SESSION_ADDRESS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WTS_SESSION_ADDRESS
	{
		/// <summary>A null-terminated string that contains the address family. Always set this member to "AF_INET".</summary>
		public uint AddressFamily;

		/// <summary>
		/// The virtual IP address assigned to the session. The format of this address is identical to that used in the
		/// WTS_CLIENT_ADDRESS structure.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
		public byte[] Address;
	}

	/// <summary>Contains information about a client session on a Remote Desktop Session Host (RD Session Host) server.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_session_infoa typedef struct _WTS_SESSION_INFOA {
	// DWORD SessionId; StrPtrAnsi pWinStationName; WTS_CONNECTSTATE_CLASS State; } WTS_SESSION_INFOA, *PWTS_SESSION_INFOA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_SESSION_INFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTS_SESSION_INFO
	{
		/// <summary>Session identifier of the session.</summary>
		public uint SessionId;

		/// <summary>
		/// Pointer to a null-terminated string that contains the WinStation name of this session. The WinStation name is a name that
		/// Windows associates with the session, for example, "services", "console", or "RDP-Tcp#0".
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pWinStationName;

		/// <summary>A value from the WTS_CONNECTSTATE_CLASS enumeration type that indicates the session's current connection state.</summary>
		public WTS_CONNECTSTATE_CLASS State;
	}

	/// <summary>
	/// Contains extended information about a client session on a Remote Desktop Session Host (RD Session Host) server or Remote Desktop
	/// Virtualization Host (RD Virtualization Host) server.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The WTSEnumerateSessionsEx function returns this structure if you call the function and specify a handle to an RD Virtualization
	/// Host server that you obtained by calling the WTSOpenServerEx function. In this case, the <c>WTSEnumerateSessionsEx</c> function
	/// aggregates all the sessions running on the host itself as well as sessions running on individual virtual machines. The ExecEnvId
	/// parameter uniquely identifies each session in the aggregated list. This identifier may be different from the actual session
	/// identifier defined in the server or virtual machine that hosts the session, which is specified by the <c>SessionId</c> member.
	/// </para>
	/// <para>
	/// The session represented by this structure could be a session running directly on the server or a session running within a
	/// virtual machine. If the session is running within a virtual machine, the <c>pHostName</c> member contains the name of the
	/// virtual machine. The <c>pFarmName</c> member is applicable to sessions that are hosted on virtual machines that are joined to a
	/// RD Session Host farm.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wts_session_info_1a typedef struct _WTS_SESSION_INFO_1A {
	// DWORD ExecEnvId; WTS_CONNECTSTATE_CLASS State; DWORD SessionId; StrPtrAnsi pSessionName; StrPtrAnsi pHostName; StrPtrAnsi pUserName; StrPtrAnsi
	// pDomainName; StrPtrAnsi pFarmName; } WTS_SESSION_INFO_1A, *PWTS_SESSION_INFO_1A;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTS_SESSION_INFO_1A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTS_SESSION_INFO_1
	{
		/// <summary>
		/// An identifier that uniquely identifies the session within the list of sessions returned by the WTSEnumerateSessionsEx
		/// function. For more information, see Remarks.
		/// </summary>
		public uint ExecEnvId;

		/// <summary>
		/// A value of the WTS_CONNECTSTATE_CLASS enumeration type that specifies the connection state of a Remote Desktop Services session.
		/// </summary>
		public WTS_CONNECTSTATE_CLASS State;

		/// <summary>A session identifier assigned by the RD Session Host server, RD Virtualization Host server, or virtual machine.</summary>
		public uint SessionId;

		/// <summary>
		/// A pointer to a null-terminated string that contains the name of this session. For example, "services", "console", or "RDP-Tcp#0".
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string pSessionName;

		/// <summary>
		/// A pointer to a null-terminated string that contains the name of the computer that the session is running on. If the session
		/// is running directly on an RD Session Host server or RD Virtualization Host server, the string contains <c>NULL</c>. If the
		/// session is running on a virtual machine, the string contains the name of the virtual machine.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? pHostName;

		/// <summary>
		/// A pointer to a null-terminated string that contains the name of the user who is logged on to the session. If no user is
		/// logged on to the session, the string contains <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? pUserName;

		/// <summary>
		/// A pointer to a null-terminated string that contains the domain name of the user who is logged on to the session. If no user
		/// is logged on to the session, the string contains <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? pDomainName;

		/// <summary>
		/// A pointer to a null-terminated string that contains the name of the farm that the virtual machine is joined to. If the
		/// session is not running on a virtual machine that is joined to a farm, the string contains <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? pFarmName;
	}

	/// <summary>Contains information about a Remote Desktop Connection (RDC) client.</summary>
	/// <remarks>
	/// For the <c>ClientAddressFamily</c> member, <c>AF_INET</c> (IPv4) will return in string format, for example "127.0.0.1".
	/// <c>AF_INET6</c> (IPv6) will return in binary form.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtsclienta typedef struct _WTSCLIENTA { CHAR
	// ClientName[CLIENTNAME_LENGTH + 1]; CHAR Domain[DOMAIN_LENGTH + 1]; CHAR UserName[USERNAME_LENGTH + 1]; CHAR
	// WorkDirectory[MAX_PATH + 1]; CHAR InitialProgram[MAX_PATH + 1]; BYTE EncryptionLevel; ULONG ClientAddressFamily; USHORT
	// ClientAddress[CLIENTADDRESS_LENGTH + 1]; USHORT HRes; USHORT VRes; USHORT ColorDepth; CHAR ClientDirectory[MAX_PATH + 1]; ULONG
	// ClientBuildNumber; ULONG ClientHardwareId; USHORT ClientProductId; USHORT OutBufCountHost; USHORT OutBufCountClient; USHORT
	// OutBufLength; CHAR DeviceId[MAX_PATH + 1]; } WTSCLIENTA, *PWTSCLIENTA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSCLIENTA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSCLIENT
	{
		/// <summary>The NetBIOS name of the client computer.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = CLIENTNAME_LENGTH + 1)]
		public string ClientName;

		/// <summary>The domain name of the client computer.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DOMAIN_LENGTH + 1)]
		public string Domain;

		/// <summary>The client user name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = USERNAME_LENGTH + 1)]
		public string UserName;

		/// <summary>The folder for the initial program.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string WorkDirectory;

		/// <summary>The program to start on connection.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string InitialProgram;

		/// <summary>The security level of encryption.</summary>
		public byte EncryptionLevel;

		/// <summary>
		/// The address family. This member can be <c>AF_INET</c>, <c>AF_INET6</c>, <c>AF_IPX</c>, <c>AF_NETBIOS</c>, or <c>AF_UNSPEC</c>.
		/// </summary>
		public uint ClientAddressFamily;

		/// <summary>The client network address.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = CLIENTADDRESS_LENGTH + 1)]
		public ushort[] ClientAddress;

		/// <summary>Horizontal dimension, in pixels, of the client's display.</summary>
		public ushort HRes;

		/// <summary>Vertical dimension, in pixels, of the client's display.</summary>
		public ushort VRes;

		/// <summary>
		/// Color depth of the client's display. For possible values, see the <c>ColorDepth</c> member of the WTS_CLIENT_DISPLAY structure.
		/// </summary>
		public ushort ColorDepth;

		/// <summary>The location of the client ActiveX control DLL.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string ClientDirectory;

		/// <summary>The client build number.</summary>
		public uint ClientBuildNumber;

		/// <summary>Reserved.</summary>
		public uint ClientHardwareId;

		/// <summary>Reserved.</summary>
		public ushort ClientProductId;

		/// <summary>The number of output buffers on the server per session.</summary>
		public ushort OutBufCountHost;

		/// <summary>The number of output buffers on the client.</summary>
		public ushort OutBufCountClient;

		/// <summary>The length of the output buffers, in bytes.</summary>
		public ushort OutBufLength;

		/// <summary>The device ID of the network adapter.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string DeviceId;
	}

	/// <summary>
	/// Contains information about a Remote Desktop Services session. This structure is returned by the WTSQuerySessionInformation
	/// function when you specify "WTSConfigInfo" for the WTSInfoClass parameter.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtsconfiginfoa typedef struct _WTSCONFIGINFOA { ULONG
	// version; ULONG fConnectClientDrivesAtLogon; ULONG fConnectPrinterAtLogon; ULONG fDisablePrinterRedirection; ULONG
	// fDisableDefaultMainClientPrinter; ULONG ShadowSettings; CHAR LogonUserName[USERNAME_LENGTH + 1]; CHAR LogonDomain[DOMAIN_LENGTH +
	// 1]; CHAR WorkDirectory[MAX_PATH + 1]; CHAR InitialProgram[MAX_PATH + 1]; CHAR ApplicationName[MAX_PATH + 1]; } WTSCONFIGINFOA, *PWTSCONFIGINFOA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSCONFIGINFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSCONFIGINFO
	{
		/// <summary>This member is reserved.</summary>
		public uint version;

		/// <summary>This member is reserved.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fConnectClientDrivesAtLogon;

		/// <summary>This member is reserved.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fConnectPrinterAtLogon;

		/// <summary>
		/// <para>Specifies whether the client can use printer redirection.</para>
		/// <para>0</para>
		/// <para>Enable client printer redirection.</para>
		/// <para>1</para>
		/// <para>Disable client printer redirection.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fDisablePrinterRedirection;

		/// <summary>
		/// <para>Specifies whether the printer connected to the client is the default printer for the user.</para>
		/// <para>0</para>
		/// <para>The printer connected to the client is not the default printer for the user.</para>
		/// <para>1</para>
		/// <para>The printer connected to the client is the default printer for the user.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fDisableDefaultMainClientPrinter;

		/// <summary>
		/// <para>
		/// The remote control setting. Remote control allows a user to remotely monitor the on-screen operations of another user. This
		/// member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>Remote control is disabled.</para>
		/// <para>1</para>
		/// <para>The user of remote control has full control of the user's session, with the user's permission.</para>
		/// <para>2</para>
		/// <para>The user of remote control has full control of the user's session; the user's permission is not required.</para>
		/// <para>3</para>
		/// <para>
		/// The user of remote control can view the session remotely, with the user's permission; the remote user cannot actively
		/// control the session.
		/// </para>
		/// <para>4</para>
		/// <para>
		/// The user of remote control can view the session remotely but not actively control the session; the user's permission is not required.
		/// </para>
		/// </summary>
		public uint ShadowSettings;

		/// <summary>A null-terminated string that contains the user name used in automatic logon scenarios.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = USERNAME_LENGTH + 1)]
		public string LogonUserName;

		/// <summary>A null-terminated string that contains the domain name used in automatic logon scenarios.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DOMAIN_LENGTH + 1)]
		public string LogonDomain;

		/// <summary>A null-terminated string that contains the path of the working directory of the initial program.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string WorkDirectory;

		/// <summary>
		/// A null-terminated string that contains the name of the program to start immediately after the user logs on to the server.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string InitialProgram;

		/// <summary>This member is reserved.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string ApplicationName;
	}

	/// <summary>Contains information about a Remote Desktop Services session.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtsinfoa typedef struct _WTSINFOA {
	// WTS_CONNECTSTATE_CLASS State; DWORD SessionId; DWORD IncomingBytes; DWORD OutgoingBytes; DWORD IncomingFrames; DWORD
	// OutgoingFrames; DWORD IncomingCompressedBytes; DWORD OutgoingCompressedBy; CHAR WinStationName[WINSTATIONNAME_LENGTH]; CHAR
	// Domain[DOMAIN_LENGTH]; CHAR UserName[USERNAME_LENGTH + 1]; LARGE_INTEGER ConnectTime; LARGE_INTEGER DisconnectTime; LARGE_INTEGER
	// LastInputTime; LARGE_INTEGER LogonTime; LARGE_INTEGER CurrentTime; } WTSINFOA, *PWTSINFOA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSINFOA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSINFO
	{
		/// <summary>A value of the WTS_CONNECTSTATE_CLASS enumeration type that indicates the session's current connection state.</summary>
		public WTS_CONNECTSTATE_CLASS State;

		/// <summary>The session identifier.</summary>
		public uint SessionId;

		/// <summary>Uncompressed Remote Desktop Protocol (RDP) data from the client to the server.</summary>
		public uint IncomingBytes;

		/// <summary>Uncompressed RDP data from the server to the client.</summary>
		public uint OutgoingBytes;

		/// <summary>The number of frames of RDP data sent from the client to the server since the client connected.</summary>
		public uint IncomingFrames;

		/// <summary>The number of frames of RDP data sent from the server to the client since the client connected.</summary>
		public uint OutgoingFrames;

		/// <summary>Compressed RDP data from the client to the server.</summary>
		public uint IncomingCompressedBytes;

		/// <summary/>
		public uint OutgoingCompressedBytes;

		/// <summary>A null-terminated string that contains the name of the WinStation for the session.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINSTATIONNAME_LENGTH)]
		public string WinStationName;

		/// <summary>A null-terminated string that contains the name of the domain that the user belongs to.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DOMAIN_LENGTH)]
		public string Domain;

		/// <summary>A null-terminated string that contains the name of the user who owns the session.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = USERNAME_LENGTH + 2)]
		public string UserName;

		/// <summary>The most recent client connection time.</summary>
		public long ConnectTimeUTC;
		
		/// <summary>The most recent client connection time.</summary>
		public DateTime ConnectTime => DateTime.FromFileTimeUtc(ConnectTimeUTC);

		/// <summary>The last client disconnection time.</summary>
		public long DisconnectTimeUTC;
		
		/// <summary>The last client disconnection time.</summary>
		public DateTime DisconnectTime => DateTime.FromFileTimeUtc(DisconnectTimeUTC);

		/// <summary>The time of the last user input in the session.</summary>
		public long LastInputTimeUTC;
		
		/// <summary>The time of the last user input in the session.</summary>
		public DateTime LastInputTime => DateTime.FromFileTimeUtc(LastInputTimeUTC);

		/// <summary>The time that the user logged on to the session.</summary>
		public long LogonTimeUTC;
		
		/// <summary>The time that the user logged on to the session.</summary>
		public DateTime LogonTime => DateTime.FromFileTimeUtc(LogonTimeUTC);

		/// <summary>The time that the <c>WTSINFO</c> data structure was called.</summary>
		public long CurrentTimeUTC;
		
		/// <summary>The time that the <c>WTSINFO</c> data structure was called.</summary>
		public DateTime CurrentTime => DateTime.FromFileTimeUtc(CurrentTimeUTC);
	}

	/// <summary>
	/// Contains a WTSINFOEX_LEVEL union that contains extended information about a Remote Desktop Services session. This structure is
	/// returned by the WTSQuerySessionInformation function when you specify "WTSSessionInfoEx" for the WTSInfoClass parameter.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtsinfoexa typedef struct _WTSINFOEXA { DWORD Level;
	// WTSINFOEX_LEVEL_A Data; } WTSINFOEXA, *PWTSINFOEXA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSINFOEXA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSINFOEX
	{
		/// <summary>Specifies the level of information contained in the Data member. This can be the following value.
		/// <para><strong>1</strong></para>
		/// <para>The Data member is a WTSINFOEX_LEVEL1 structure.</para>
		/// </summary>
		public uint Level;

		/// <summary>A WTSINFOEX_LEVEL union. The type of structure contained here is specified by the <c>Level</c> member.</summary>
		public WTSINFOEX_LEVEL Data;
	}

	/// <summary>Contains a WTSINFOEX_LEVEL1 structure that contains extended information about a Remote Desktop Services session.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtsinfoex_level_a typedef union _WTSINFOEX_LEVEL_A {
	// WTSINFOEX_LEVEL1_A WTSInfoExLevel1; } WTSINFOEX_LEVEL_A, *PWTSINFOEX_LEVEL_A;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSINFOEX_LEVEL_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSINFOEX_LEVEL
	{
		/// <summary>A WTSINFOEX_LEVEL1 structure that contains extended session information.</summary>
		public WTSINFOEX_LEVEL1 WTSInfoExLevel1;
	}

	/// <summary>Contains extended information about a Remote Desktop Services session.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtsinfoex_level1_a typedef struct _WTSINFOEX_LEVEL1_A {
	// ULONG SessionId; WTS_CONNECTSTATE_CLASS SessionState; LONG SessionFlags; CHAR WinStationName[WINSTATIONNAME_LENGTH + 1]; CHAR
	// UserName[USERNAME_LENGTH + 1]; CHAR DomainName[DOMAIN_LENGTH + 1]; LARGE_INTEGER LogonTime; LARGE_INTEGER ConnectTime;
	// LARGE_INTEGER DisconnectTime; LARGE_INTEGER LastInputTime; LARGE_INTEGER CurrentTime; DWORD IncomingBytes; DWORD OutgoingBytes;
	// DWORD IncomingFrames; DWORD OutgoingFrames; DWORD IncomingCompressedBytes; DWORD OutgoingCompressedBytes; } WTSINFOEX_LEVEL1_A, *PWTSINFOEX_LEVEL1_A;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSINFOEX_LEVEL1_A")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSINFOEX_LEVEL1
	{
		/// <summary>The session identifier.</summary>
		public uint SessionId;

		/// <summary>
		/// A value of the WTS_CONNECTSTATE_CLASS enumeration type that specifies the connection state of a Remote Desktop Services session.
		/// </summary>
		public WTS_CONNECTSTATE_CLASS SessionState;

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
		/// <c>WTS_SESSIONSTATE_UNLOCK</c> flags is reversed. That is, <c>WTS_SESSIONSTATE_LOCK</c> indicates that the session is
		/// unlocked, and <c>WTS_SESSIONSTATE_UNLOCK</c> indicates the session is locked.
		/// </para>
		/// </summary>
		public WTS_SESSIONSTATE SessionFlags;

		/// <summary>A null-terminated string that contains the name of the window station for the session.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WINSTATIONNAME_LENGTH + 1)]
		public string WinStationName;

		/// <summary>A null-terminated string that contains the name of the user who owns the session.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = USERNAME_LENGTH + 1)]
		public string UserName;

		/// <summary>A null-terminated string that contains the name of the domain that the user belongs to.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DOMAIN_LENGTH + 1)]
		public string DomainName;

		/// <summary>
		/// The time that the user logged on to the session. This value is stored as a large integer that represents the number of
		/// 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time (Greenwich Mean Time).
		/// </summary>
		public long LogonTimeUTC;
		
		/// <summary>
		/// The time that the user logged on to the session. This value is stored as a large integer that represents the number of
		/// 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time (Greenwich Mean Time).
		/// </summary>
		public DateTime LogonTime => DateTime.FromFileTimeUtc(LogonTimeUTC);

		/// <summary>
		/// The time of the most recent client connection to the session. This value is stored as a large integer that represents the
		/// number of 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public long ConnectTimeUTC;
		
		/// <summary>
		/// The time of the most recent client connection to the session. This value is stored as a large integer that represents the
		/// number of 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public DateTime ConnectTime => DateTime.FromFileTimeUtc(ConnectTimeUTC);

		/// <summary>
		/// The time of the most recent client disconnection to the session. This value is stored as a large integer that represents the
		/// number of 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public long DisconnectTimeUTC;

		/// <summary>
		/// The time of the most recent client disconnection to the session. This value is stored as a large integer that represents the
		/// number of 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public DateTime DisconnectTime => DateTime.FromFileTimeUtc(DisconnectTimeUTC);			

		/// <summary>
		/// The time of the last user input in the session. This value is stored as a large integer that represents the number of
		/// 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public long LastInputTimeUTC;
		
		/// <summary>
		/// The time of the last user input in the session. This value is stored as a large integer that represents the number of
		/// 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public DateTime LastInputTime => DateTime.FromFileTimeUtc(LastInputTimeUTC);			

		/// <summary>
		/// The time that this structure was filled. This value is stored as a large integer that represents the number of
		/// 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public long CurrentTimeUTC;
		
		/// <summary>
		/// The time that this structure was filled. This value is stored as a large integer that represents the number of
		/// 100-nanosecond intervals since January 1, 1601 Coordinated Universal Time.
		/// </summary>
		public DateTime CurrentTime => DateTime.FromFileTimeUtc(CurrentTimeUTC);			

		/// <summary>
		/// The number of bytes of uncompressed Remote Desktop Protocol (RDP) data sent from the client to the server since the client connected.
		/// </summary>
		public uint IncomingBytes;

		/// <summary>The number of bytes of uncompressed RDP data sent from the server to the client since the client connected.</summary>
		public uint OutgoingBytes;

		/// <summary>The number of frames of RDP data sent from the client to the server since the client connected.</summary>
		public uint IncomingFrames;

		/// <summary>The number of frames of RDP data sent from the server to the client since the client connected.</summary>
		public uint OutgoingFrames;

		/// <summary>The number of bytes of compressed RDP data sent from the client to the server since the client connected.</summary>
		public uint IncomingCompressedBytes;

		/// <summary>The number of bytes of compressed RDP data sent from the server to the client since the client connected.</summary>
		public uint OutgoingCompressedBytes;
	}

	/// <summary>Contains information about a Remote Desktop Services listener. This structure is used by the WTSCreateListener function.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtslistenerconfiga typedef struct _WTSLISTENERCONFIGA {
	// ULONG version; ULONG fEnableListener; ULONG MaxConnectionCount; ULONG fPromptForPassword; ULONG fInheritColorDepth; ULONG
	// ColorDepth; ULONG fInheritBrokenTimeoutSettings; ULONG BrokenTimeoutSettings; ULONG fDisablePrinterRedirection; ULONG
	// fDisableDriveRedirection; ULONG fDisableComPortRedirection; ULONG fDisableLPTPortRedirection; ULONG fDisableClipboardRedirection;
	// ULONG fDisableAudioRedirection; ULONG fDisablePNPRedirection; ULONG fDisableDefaultMainClientPrinter; ULONG LanAdapter; ULONG
	// PortNumber; ULONG fInheritShadowSettings; ULONG ShadowSettings; ULONG TimeoutSettingsConnection; ULONG
	// TimeoutSettingsDisconnection; ULONG TimeoutSettingsIdle; ULONG SecurityLayer; ULONG MinEncryptionLevel; ULONG UserAuthentication;
	// CHAR Comment[WTS_COMMENT_LENGTH + 1]; CHAR LogonUserName[USERNAME_LENGTH + 1]; CHAR LogonDomain[DOMAIN_LENGTH + 1]; CHAR
	// WorkDirectory[MAX_PATH + 1]; CHAR InitialProgram[MAX_PATH + 1]; } WTSLISTENERCONFIGA, *PWTSLISTENERCONFIGA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSLISTENERCONFIGA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSLISTENERCONFIG
	{
		/// <summary>This member is reserved.</summary>
		public uint version;

		/// <summary>
		/// <para>Specifies whether the listener is enabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The listener is disabled.</para>
		/// <para>1</para>
		/// <para>The listener is enabled.</para>
		/// </summary>
		public uint fEnableListener;

		/// <summary>The maximum number of active connections that the listener accepts.</summary>
		public uint MaxConnectionCount;

		/// <summary>
		/// <para>Specifies whether the listener always prompts the user for a password. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>Prompt the user for a password only when specified by the server.</para>
		/// <para>1</para>
		/// <para>Always prompt the user for a password.</para>
		/// </summary>
		public uint fPromptForPassword;

		/// <summary>
		/// <para>
		/// Specifies whether the listener should use the color depth specified by the user. This member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>Use the color depth specified by the server.</para>
		/// <para>1</para>
		/// <para>Use the color depth specified by the user.</para>
		/// </summary>
		public uint fInheritColorDepth;

		/// <summary>
		/// <para>
		/// The color depth setting for the listener. This setting only applies when the <c>fInheritColorDepth</c> member is zero. This
		/// can be one of the following values.
		/// </para>
		/// <para>1</para>
		/// <para>8 bit</para>
		/// <para>2</para>
		/// <para>15 bit</para>
		/// <para>3</para>
		/// <para>16 bit</para>
		/// <para>4</para>
		/// <para>24 bit</para>
		/// <para>5</para>
		/// <para>32 bit</para>
		/// </summary>
		public uint ColorDepth;

		/// <summary>
		/// <para>
		/// Specifies whether the listener should use the <c>BrokenTimeoutSettings</c> value specified by the user. This member can be
		/// one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>Use the <c>BrokenTimeoutSettings</c> value specified by server.</para>
		/// <para>1</para>
		/// <para>Use the <c>BrokenTimeoutSettings</c> value specified by the user.</para>
		/// </summary>
		public uint fInheritBrokenTimeoutSettings;

		/// <summary>
		/// <para>
		/// The action the listener takes when a connection or idle timer expires, or when a connection is lost due to a connection
		/// error. This setting only applies when the <c>fInheritBrokenTimeoutSettings</c> member is zero. This member can be one of the
		/// following values.
		/// </para>
		/// <para>0</para>
		/// <para>
		/// When a connection or idle timer expires, or when a connection is lost due to a connection error, the user is disconnected
		/// but the session remains on the server.
		/// </para>
		/// <para>1</para>
		/// <para>When a connection or idle timer expires, or when a connection is lost due to a connection error, the session is terminated.</para>
		/// </summary>
		public uint BrokenTimeoutSettings;

		/// <summary>
		/// <para>Specifies whether printer redirection is disabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The user can enable printer redirection.</para>
		/// <para>1</para>
		/// <para>Printer redirection is disabled.</para>
		/// </summary>
		public uint fDisablePrinterRedirection;

		/// <summary>
		/// <para>Specifies whether drive redirection is disabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The user can enable drive redirection.</para>
		/// <para>1</para>
		/// <para>Drive redirection is disabled.</para>
		/// </summary>
		public uint fDisableDriveRedirection;

		/// <summary>
		/// <para>Specifies whether COM port redirection is disabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The user can enable COM port redirection.</para>
		/// <para>1</para>
		/// <para>COM port redirection is disabled.</para>
		/// </summary>
		public uint fDisableComPortRedirection;

		/// <summary>
		/// <para>Specifies whether LPT port redirection is disabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The user can enable LPT port redirection.</para>
		/// <para>1</para>
		/// <para>LPT port redirection is disabled.</para>
		/// </summary>
		public uint fDisableLPTPortRedirection;

		/// <summary>
		/// <para>Specifies whether clipboard redirection is disabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The user can enable clipboard redirection.</para>
		/// <para>1</para>
		/// <para>Clipboard redirection is disabled.</para>
		/// </summary>
		public uint fDisableClipboardRedirection;

		/// <summary>
		/// <para>Specifies whether audio redirection is disabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The user can enable audio redirection.</para>
		/// <para>1</para>
		/// <para>Audio redirection is disabled.</para>
		/// </summary>
		public uint fDisableAudioRedirection;

		/// <summary>
		/// <para>Specifies whether Plug and Play redirection is disabled. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The user can enable Plug and Play redirection.</para>
		/// <para>1</para>
		/// <para>Plug and Play redirection is disabled.</para>
		/// </summary>
		public uint fDisablePNPRedirection;

		/// <summary>
		/// <para>Specifies whether the client printer is the default printer. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>The client printer is not the default printer.</para>
		/// <para>1</para>
		/// <para>The client printer is the default printer.</para>
		/// </summary>
		public uint fDisableDefaultMainClientPrinter;

		/// <summary>The network adapter that the listener uses.</summary>
		public uint LanAdapter;

		/// <summary>The port number of the listener.</summary>
		public uint PortNumber;

		/// <summary>
		/// <para>
		/// Specifies whether the listener should use the <c>ShadowSettings</c> value specified by the user. This member can be one of
		/// the following values.
		/// </para>
		/// <para>0</para>
		/// <para>Use the setting specified by the server.</para>
		/// <para>1</para>
		/// <para>Use the setting specified by the user.</para>
		/// </summary>
		public uint fInheritShadowSettings;

		/// <summary>
		/// <para>
		/// The remote control setting for the listener. Remote control allows a user to remotely monitor the on-screen operations of
		/// another user. This setting only applies when the <c>fInheritShadowSettings</c> member is zero. This member can be one of the
		/// following values.
		/// </para>
		/// <para>0</para>
		/// <para>Remote control is disabled.</para>
		/// <para>1</para>
		/// <para>The user of remote control has full control of the user's session, with the user's permission.</para>
		/// <para>2</para>
		/// <para>The user of remote control has full control of the user's session; the user's permission is not required.</para>
		/// <para>3</para>
		/// <para>
		/// The user of remote control can view the session remotely, with the user's permission; the remote user cannot actively
		/// control the session.
		/// </para>
		/// <para>4</para>
		/// <para>
		/// The user of remote control can view the session remotely but not actively control the session; the user's permission is not required.
		/// </para>
		/// </summary>
		public uint ShadowSettings;

		/// <summary>
		/// The maximum connection duration, in milliseconds. Every time the user logs on, the timer is reset. A value of zero indicates
		/// that the connection timer is disabled.
		/// </summary>
		public uint TimeoutSettingsConnection;

		/// <summary>
		/// The maximum duration, in milliseconds, that a server retains a disconnected session before the logon is terminated. A value
		/// of zero indicates that the disconnection timer is disabled.
		/// </summary>
		public uint TimeoutSettingsDisconnection;

		/// <summary>The maximum idle time, in milliseconds. A value of zero indicates that the idle timer is disabled.</summary>
		public uint TimeoutSettingsIdle;

		/// <summary>
		/// <para>The security layer of the listener. This member can be one of the following values.</para>
		/// <para>0</para>
		/// <para>Remote Desktop Protocol (RDP) is used by the server and the client for authentication before a connection is established.</para>
		/// <para>1</para>
		/// <para>The server and the client negotiate the method for authentication before a connection is established.</para>
		/// <para>2</para>
		/// <para>
		/// Transport Layer Security (TLS) protocol is used by the server and the client for authentication before a connection is established.
		/// </para>
		/// </summary>
		public uint SecurityLayer;

		/// <summary>
		/// <para>Encryption level of the listener. This member can be one of the following values.</para>
		/// <para>1</para>
		/// <para>
		/// Data sent from the client to the server is encrypted by using 56-bit encryption. Data sent from the server to the client is
		/// not encrypted.
		/// </para>
		/// <para>2</para>
		/// <para>
		/// All data sent from the client to the server and from the server to the client is encrypted by using the maximum key strength
		/// supported by the client.
		/// </para>
		/// <para>3</para>
		/// <para>
		/// All data sent from the client to the server and from the server to the client is encrypted by using 128-bit encryption.
		/// Clients that do not support this level of encryption cannot connect.
		/// </para>
		/// <para>4</para>
		/// <para>
		/// All data sent from the client to the server and from the server to the client is encrypted and decrypted by using the
		/// Federal Information Processing Standards (FIPS) encryption algorithms and Microsoft cryptographic modules.
		/// </para>
		/// </summary>
		public uint MinEncryptionLevel;

		/// <summary>
		/// <para>
		/// Specifies whether network-level user authentication is required before the connection is established. This member can be one
		/// of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>Network-level user authentication is not required.</para>
		/// <para>1</para>
		/// <para>Network-level user authentication is required.</para>
		/// </summary>
		public uint UserAuthentication;

		/// <summary>A null-terminated string that contains a description of the listener.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTS_COMMENT_LENGTH + 1)]
		public string Comment;

		/// <summary>A null-terminated string that contains the user name used in automatic logon scenarios.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = USERNAME_LENGTH + 1)]
		public string LogonUserName;

		/// <summary>A null-terminated string that contains the domain name used in automatic logon scenarios.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = DOMAIN_LENGTH + 1)]
		public string LogonDomain;

		/// <summary>A null-terminated string that contains the path of the working directory of the initial program.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string WorkDirectory;

		/// <summary>
		/// A null-terminated string that contains the name of the program to start immediately after the user logs on to the server.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string InitialProgram;
	}

	/// <summary>A fixed length string used by <see cref="WTSEnumerateListeners"/></summary>
	[PInvokeData("wtsapi32.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSLISTENERNAME
	{
		private const int WTS_LISTENER_NAME_LENGTH = 32;

		/// <summary>Name of the server.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTS_LISTENER_NAME_LENGTH + 1)]
		public string Name;

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => Name ?? "";

		/// <summary>Performs an implicit conversion from <see cref="WTSLISTENERNAME"/> to <see cref="System.String"/>.</summary>
		/// <param name="n">The n.</param>
		/// <returns>The resulting <see cref="System.String"/> instance from the conversion.</returns>
		public static implicit operator string(WTSLISTENERNAME n) => n.Name;

		/// <summary>Performs an implicit conversion from <see cref="System.String"/> to <see cref="WTSLISTENERNAME"/>.</summary>
		/// <param name="n">The n.</param>
		/// <returns>The resulting <see cref="WTSLISTENERNAME"/> instance from the conversion.</returns>
		public static implicit operator WTSLISTENERNAME(string n) => new() { Name = n };
	}

	/// <summary>
	/// Contains configuration information for a user on a domain controller or Remote Desktop Session Host (RD Session Host) server.
	/// This structure is used by the WTSQueryUserConfig and WTSSetUserConfig functions.
	/// </summary>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/wtsapi32/ns-wtsapi32-wtsuserconfiga typedef struct _WTSUSERCONFIGA { DWORD
	// Source; DWORD InheritInitialProgram; DWORD AllowLogonTerminalServer; DWORD TimeoutSettingsConnections; DWORD
	// TimeoutSettingsDisconnections; DWORD TimeoutSettingsIdle; DWORD DeviceClientDrives; DWORD DeviceClientPrinters; DWORD
	// ClientDefaultPrinter; DWORD BrokenTimeoutSettings; DWORD ReconnectSettings; DWORD ShadowingSettings; DWORD
	// TerminalServerRemoteHomeDir; CHAR InitialProgram[MAX_PATH + 1]; CHAR WorkDirectory[MAX_PATH + 1]; CHAR
	// TerminalServerProfilePath[MAX_PATH + 1]; CHAR TerminalServerHomeDir[MAX_PATH + 1]; CHAR
	// TerminalServerHomeDirDrive[WTS_DRIVE_LENGTH + 1]; } WTSUSERCONFIGA, *PWTSUSERCONFIGA;
	[PInvokeData("wtsapi32.h", MSDNShortId = "NS:wtsapi32._WTSUSERCONFIGA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct WTSUSERCONFIG
	{
		/// <summary>
		/// A value of the WTS_CONFIG_SOURCE enumeration type that specifies the source of configuration information returned by the
		/// WTSQueryUserConfig function.
		/// </summary>
		public WTS_CONFIG_SOURCE Source;

		/// <summary>
		/// <para>
		/// A value that indicates whether the client can specify the initial program. This member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>
		/// The client cannot specify the initial program. Instead, the program specified by the <c>InitialProgram</c> member starts
		/// automatically when the user logs on to the server. The server logs the user off when the user exits that program.
		/// </para>
		/// <para>1</para>
		/// <para>The client can specify the initial program.</para>
		/// </summary>
		public uint InheritInitialProgram;

		/// <summary>
		/// <para>
		/// A value that indicates whether the user account is permitted to log on to an RD Session Host server. This member can be one
		/// of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>The user cannot log on.</para>
		/// <para>1</para>
		/// <para>The user can log on.</para>
		/// </summary>
		public uint AllowLogonTerminalServer;

		/// <summary>
		/// The maximum connection duration, in milliseconds. One minute before the connection expires, the server notifies the user
		/// about the pending disconnection. When the connection times out, the server takes the action specified by the
		/// <c>BrokenTimeoutSettings</c> member. Every time the user logs on, the timer is reset. A value of zero indicates that the
		/// connection timer is disabled.
		/// </summary>
		public uint TimeoutSettingsConnections;

		/// <summary>
		/// The maximum duration, in milliseconds, that the server retains a disconnected session before the logon is terminated. A
		/// value of zero indicates that the disconnection timer is disabled.
		/// </summary>
		public uint TimeoutSettingsDisconnections;

		/// <summary>
		/// The amount of time, in milliseconds, that a connection can remain idle. If there is no keyboard or mouse activity for this
		/// period of time, the server takes the action specified by the <c>BrokenTimeoutSettings</c> member. A value of zero indicates
		/// that the idle timer is disabled.
		/// </summary>
		public uint TimeoutSettingsIdle;

		/// <summary>This member is reserved.</summary>
		public uint DeviceClientDrives;

		/// <summary>
		/// <para>
		/// A value that indicates whether the server automatically connects to previously mapped client printers when the user logs on
		/// to the server. This member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>The server does not automatically connect to previously mapped client printers.</para>
		/// <para>1</para>
		/// <para>The server automatically connects to previously mapped client printers.</para>
		/// </summary>
		public uint DeviceClientPrinters;

		/// <summary>
		/// <para>
		/// A value that indicates whether the client printer is the default printer. This member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>The client printer is not the default printer.</para>
		/// <para>1</para>
		/// <para>The client printer is the default printer.</para>
		/// </summary>
		public uint ClientDefaultPrinter;

		/// <summary>
		/// <para>
		/// The action the server takes when the connection or idle timers expire, or when a connection is lost due to a connection
		/// error. This member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>The session is disconnected, but it remains on the server.</para>
		/// <para>1</para>
		/// <para>The session is terminated.</para>
		/// </summary>
		public uint BrokenTimeoutSettings;

		/// <summary>
		/// <para>
		/// A value that indicates how a disconnected session for this user can be reconnected. This member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>The user can log on to any client computer to reconnect to a disconnected session.</para>
		/// <para>1</para>
		/// <para>
		/// The user must log on to the client computer originally used to establish the disconnected session. If the user logs on to a
		/// different client computer, the user gets a new session.
		/// </para>
		/// </summary>
		public uint ReconnectSettings;

		/// <summary>
		/// <para>
		/// The remote control setting. Remote control allows a user to remotely monitor the on-screen operations of another user. This
		/// member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>Remote control is disabled.</para>
		/// <para>1</para>
		/// <para>The user of remote control has full control of the user's session, with the user's permission.</para>
		/// <para>2</para>
		/// <para>The user of remote control has full control of the user's session; the user's permission is not required.</para>
		/// <para>3</para>
		/// <para>
		/// The user of remote control can view the session remotely, with the user's permission; the remote user cannot actively
		/// control the session.
		/// </para>
		/// <para>4</para>
		/// <para>
		/// The user of remote control can view the session remotely but not actively control the session; the user's permission is not required.
		/// </para>
		/// </summary>
		public uint ShadowingSettings;

		/// <summary>
		/// <para>
		/// A value that indicates whether the <c>TerminalServerHomeDir</c> member contains a path to a local directory or a network
		/// share. You cannot set this member by using the WTSSetUserConfig function. This member can be one of the following values.
		/// </para>
		/// <para>0</para>
		/// <para>The <c>TerminalServerHomeDir</c> member contains a path to a local directory.</para>
		/// <para>1</para>
		/// <para>
		/// The <c>TerminalServerHomeDir</c> member contains a path to a network share, and the <c>TerminalServerHomeDirDrive</c> member
		/// contains a drive letter to which this path is mapped.
		/// </para>
		/// </summary>
		public uint TerminalServerRemoteHomeDir;

		/// <summary>
		/// A null-terminated string that contains the name of the program to start immediately after the user logs on to the server.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string InitialProgram;

		/// <summary>A null-terminated string that contains the path of the working directory for the initial program.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string WorkDirectory;

		/// <summary>
		/// A null-terminated string that contains the profile path that is assigned to the user when the user connects to the server.
		/// The directory specified by the path must be created manually, and must exist prior to the logon.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string TerminalServerProfilePath;

		/// <summary>
		/// A null-terminated string that contains the path to the home folder of the user's Remote Desktop Services sessions. The
		/// folder can be a local folder or a network share.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
		public string TerminalServerHomeDir;

		/// <summary>
		/// A null-terminated string that contains the drive name (a drive letter followed by a colon) to which the path specified in
		/// the <c>TerminalServerHomeDir</c> member is mapped. This member is only valid when the <c>TerminalServerRemoteHomeDir</c>
		/// member is set to one.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = WTS_DRIVE_LENGTH + 1)]
		public string TerminalServerHomeDirDrive;
	}

	public partial class SafeHWTSSERVER
	{
		/// <summary>Gets the handle of the current server (WTS_CURRENT_SERVER).</summary>
		public static SafeHWTSSERVER Current => new(IntPtr.Zero, false);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for WTS memory that is disposed using <see cref="WTSFreeMemory"/>.</summary>
	[AutoSafeHandle("{ WTSFreeMemory(handle); return true; }")]
	public partial class SafeWTSMemoryHandle
	{
		/// <summary>
		/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note
		/// type="note">This call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all
		/// the structures.</note>
		/// </summary>
		/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
		/// <param name="count">The number of structures to retrieve.</param>
		/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
		public T[] ToArray<T>(int count) => handle.ToArray<T>(count) ?? new T[0];

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <param name="allocatedBytes">The size, in bytes, of the data returned in ppBuffer.</param>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public string? ToString(uint allocatedBytes) => StringHelper.GetString(handle, CharSet.Auto, allocatedBytes);

		/// <summary>Marshals data from this memory to a newly allocated managed object of the type specified by a generic type parameter.</summary>
		/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory.</param>
		/// <returns>A managed object that contains the data that this memory points to.</returns>
		public T? ToStructure<T>(uint allocatedBytes) => handle.Convert<T>(allocatedBytes == 0 ? uint.MaxValue : allocatedBytes);

#if ALLOWSPAN
		/// <summary>Creates a new span over this allocated memory.</summary>
		/// <returns>The span representation of the structure.</returns>
		public virtual ReadOnlySpan<T> AsReadOnlySpan<T>(int length) => handle.AsReadOnlySpan<T>(length);

		/// <summary>Creates a new span over this allocated memory.</summary>
		/// <returns>The span representation of the structure.</returns>
		public virtual Span<T> AsSpan<T>(int length) => handle.AsSpan<T>(length);
#endif
	}
}