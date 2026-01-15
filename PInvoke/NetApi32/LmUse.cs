namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>A set of bit flags that describe connection behavior and credential handling.</summary>
	[PInvokeData("lmuse.h", MSDNShortId = "3fb3ad35-f9e5-46ba-b930-fc2ccafd8ee9")]
	[Flags]
	public enum NetUseFlags
	{
		/// <summary>Do not connect to the server.</summary>
		CREATE_NO_CONNECT = 0x1,

		/// <summary>Force a connection to the server, bypassing the CSC.</summary>
		CREATE_BYPASS_CSC = 0x2,

		/// <summary>
		/// Create a connection with credentials passed in this netuse if none exist. If connection already exists then update
		/// credentials after issuing remote tree connection. This is needed as CSC cannot verify credentials while offline.
		/// </summary>
		CREATE_CRED_RESET = 0x4,

		/// <summary>No explicit credentials are supplied in the call to NetUseAdd.</summary>
		USE_DEFAULT_CREDENTIALS = 0x4,

		/// <summary>Enforce connection level integrity.</summary>
		CREATE_REQUIRE_CONNECTION_INTEGRITY = 0x8,

		/// <summary>Enforce connection level privacy.</summary>
		CREATE_REQUIRE_CONNECTION_PRIVACY = 0x10,

		/// <summary>Persist the mapping in the registry. (Only valid for global mappings.)</summary>
		CREATE_PERSIST_MAPPING = 0x20,

		/// <summary>Enables write-through semantics on all files opened via this mapping.</summary>
		CREATE_WRITE_THROUGH_SEMANTICS = 0x40,
	}

	/// <summary>The level of force to use in deleting the connection.</summary>
	[PInvokeData("lmuse.h", MSDNShortId = "200b0640-71e9-4f60-bf4c-c8df10bfe095")]
	public enum NetUseForce
	{
		/// <summary>Fail the disconnection if open files exist on the connection.</summary>
		USE_NOFORCE = 0,

		/// <summary>Do not fail the disconnection if open files exist on the connection.</summary>
		USE_FORCE = 1,

		/// <summary>Close any open files and delete the connection.</summary>
		USE_LOTS_OF_FORCE = 2
	}

	/// <summary>The status of the connection.</summary>
	[PInvokeData("lmuse.h", MSDNShortId = "b9f680b8-b56a-42be-9af1-d7b18328ded4")]
	public enum NetUseStatus
	{
		/// <summary>The connection is valid.</summary>
		USE_OK = 0,

		/// <summary>Paused by local workstation.</summary>
		USE_PAUSED = 1,

		/// <summary>Disconnected.</summary>
		USE_SESSLOST = 2,

		/// <summary>An error occurred.</summary>
		USE_DISCONN = 2,

		/// <summary>A network error occurred.</summary>
		USE_NETERR = 3,

		/// <summary>The connection is being made.</summary>
		USE_CONN = 4,

		/// <summary>Reconnecting.</summary>
		USE_RECONN = 5,
	}

	/// <summary>The type of remote resource being accessed.</summary>
	[PInvokeData("lmuse.h", MSDNShortId = "b9f680b8-b56a-42be-9af1-d7b18328ded4")]
	public enum NetUseType
	{
		/// <summary>
		/// Matches the type of the server's shared resources. Wildcards can be used only with the NetUseAdd function, and only when the
		/// ui1_local member is NULL. For more information, see the following Remarks section.
		/// </summary>
		USE_WILDCARD = -1,

		/// <summary>Disk device.</summary>
		USE_DISKDEV = 0,

		/// <summary>Spooled printer.</summary>
		USE_SPOOLDEV = 1,

		/// <summary>Undocumented</summary>
		USE_CHARDEV = 2,

		/// <summary>Interprocess communication (IPC).</summary>
		USE_IPC = 3,
	}

	/// <summary>
	/// The <c>NetUseAdd</c> function establishes a connection between the local computer and a remote server. You can specify a local
	/// drive letter or a printer device to connect. If you do not specify a local drive letter or printer device, the function
	/// authenticates the client with the server for future connections.
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// The UNC name of the computer on which to execute this function. If this parameter is <c>NULL</c>, then the local computer is
	/// used. If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using
	/// the legacy Remote Access Protocol mechanism.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
	/// </param>
	/// <param name="LevelFlags">
	/// <para>A value that specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
	/// status and type. The Buf parameter is a pointer to a USE_INFO_1 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
	/// status and type, and a user name and domain name. The Buf parameter is a pointer to a USE_INFO_2 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="buf">
	/// A pointer to the buffer that specifies the data. The format of this data depends on the value of the Level parameter. For more
	/// information, see Network Management Function Buffers.
	/// </param>
	/// <param name="parm_err">
	/// A pointer to a value that receives the index of the first member of the information structure in error when the
	/// ERROR_INVALID_PARAMETER error is returned. If this parameter is <c>NULL</c>, the index is not returned on error. For more
	/// information, see the following Remarks section.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>You can also use the WNetAddConnection2 and WNetAddConnection3 functions to redirect a local device to a network resource.</para>
	/// <para>
	/// No special group membership is required to call the <c>NetUseAdd</c> function. This function cannot be executed on a remote
	/// server except in cases of downlevel compatibility.
	/// </para>
	/// <para>
	/// This function applies only to the Server Message Block (LAN Manager Workstation) client. The <c>NetUseAdd</c> function does not
	/// support Distributed File System (DFS) shares. To add a share using a different network provider (WebDAV or a DFS share, for
	/// example), use the WNetAddConnection2 or WNetAddConnection3 function.
	/// </para>
	/// <para>
	/// If the <c>NetUseAdd</c> function returns ERROR_INVALID_PARAMETER, you can use the ParmError parameter to indicate the first
	/// member of the information structure that is invalid. (The information structure begins with USE_INFO_ and its format is specified
	/// by the Level parameter.) The following table lists the values that can be returned in the ParmError parameter and the
	/// corresponding structure member that is in error. (The prefix ui*_ indicates that the member can begin with multiple prefixes, for
	/// example, ui1_ or ui2_.)
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Value</term>
	/// <term>Member</term>
	/// </listheader>
	/// <item>
	/// <term>USE_LOCAL_PARMNUM</term>
	/// <term>1</term>
	/// <term>ui*_local</term>
	/// </item>
	/// <item>
	/// <term>USE_REMOTE_PARMNUM</term>
	/// <term>2</term>
	/// <term>ui*_remote</term>
	/// </item>
	/// <item>
	/// <term>USE_PASSWORD_PARMNUM</term>
	/// <term>3</term>
	/// <term>ui*_password</term>
	/// </item>
	/// <item>
	/// <term>USE_ASGTYPE_PARMNUM</term>
	/// <term>4</term>
	/// <term>ui*_asg_type</term>
	/// </item>
	/// <item>
	/// <term>USE_USERNAME_PARMNUM</term>
	/// <term>5</term>
	/// <term>ui*_username</term>
	/// </item>
	/// <item>
	/// <term>USE_DOMAINNAME_PARMNUM</term>
	/// <term>6</term>
	/// <term>ui*_domainname</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/nf-lmuse-netuseadd NET_API_STATUS NET_API_FUNCTION NetUseAdd( PTSTR
	// servername, DWORD LevelFlags, LPBYTE buf, LPDWORD parm_err );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Auto)]
	[PInvokeData("lmuse.h", MSDNShortId = "22550c17-003a-4f59-80f0-58fa3e286844")]
	public static extern Win32Error NetUseAdd([Optional] string? servername, uint LevelFlags, IntPtr buf, out uint parm_err);

	/// <summary>
	/// <para>The <c>NetUseDel</c> function ends a connection to a shared resource.</para>
	/// <para>You can also use the WNetCancelConnection2 function to terminate a network connection.</para>
	/// </summary>
	/// <param name="UncServerName">
	/// <para>
	/// The UNC name of the computer on which to execute this function. If this is parameter is <c>NULL</c>, then the local computer is used.
	/// </para>
	/// <para>
	/// If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using the
	/// legacy Remote Access Protocol mechanism.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
	/// </param>
	/// <param name="UseName">
	/// <para>A pointer to a string that specifies the path of the connection to delete.</para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
	/// </param>
	/// <param name="ForceLevelFlags">
	/// <para>The level of force to use in deleting the connection.</para>
	/// <para>This parameter can be one of the following values defined in the lmuseflg.h header file.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>USE_NOFORCE</term>
	/// <term>Fail the disconnection if open files exist on the connection.</term>
	/// </item>
	/// <item>
	/// <term>USE_FORCE</term>
	/// <term>Do not fail the disconnection if open files exist on the connection.</term>
	/// </item>
	/// <item>
	/// <term>USE_LOTS_OF_FORCE</term>
	/// <term>Close any open files and delete the connection.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NetUseDel</c> function applies only to the Server Message Block (LAN Manager Workstation) client. The <c>NetUseDel</c>
	/// function does not support Distributed File System (DFS) shares or other network file systems. To terminate a connection to a
	/// share using a different network provider (WebDAV or a DFS share, for example), use the WNetCancelConnection2 function.
	/// </para>
	/// <para>
	/// No special group membership is required to call the <c>NetUseDel</c> function. This function cannot be executed on a remote
	/// server except in cases of downlevel compatibility.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/nf-lmuse-netusedel NET_API_STATUS NET_API_FUNCTION NetUseDel( LMSTR
	// UncServerName, LMSTR UseName, DWORD ForceLevelFlags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Auto)]
	[PInvokeData("lmuse.h", MSDNShortId = "200b0640-71e9-4f60-bf4c-c8df10bfe095")]
	public static extern Win32Error NetUseDel([Optional] string? UncServerName, string UseName, NetUseForce ForceLevelFlags);

	/// <summary>
	/// <para>The <c>NetUseEnum</c> function lists all current connections between the local computer and resources on remote servers.</para>
	/// <para>You can also use the WNetOpenEnum and the WNetEnumResource functions to enumerate network resources or connections.</para>
	/// </summary>
	/// <param name="UncServerName">
	/// <para>
	/// The UNC name of the computer on which to execute this function. If this is parameter is <c>NULL</c>, then the local computer is
	/// used. If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using
	/// the legacy Remote Access Protocol mechanism.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
	/// </param>
	/// <param name="LevelFlags">
	/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Specifies a local device name and the share name of a remote resource. The BufPtr parameter points to an array of USE_INFO_0 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Specifies information about the connection between a local device and a shared resource, including connection status and type.
	/// The BufPtr parameter points to an array of USE_INFO_1 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
	/// status, connection type, user name, and domain name. The BufPtr parameter points to an array of USE_INFO_2 structures.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="BufPtr">
	/// A pointer to the buffer that receives the information structures. The format of this data depends on the value of the Level
	/// parameter. This buffer is allocated by the system and must be freed using the NetApiBufferFree function when the information is
	/// no longer needed. Note that you must free the buffer even if the function fails with <c>ERROR_MORE_DATA</c>.
	/// </param>
	/// <param name="PreferedMaximumSize">
	/// The preferred maximum length, in bytes, of the data to return. If <c>MAX_PREFERRED_LENGTH</c> is specified, the function
	/// allocates the amount of memory required for the data. If another value is specified in this parameter, it can restrict the number
	/// of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
	/// <c>ERROR_MORE_DATA</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="EntriesRead">A pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="TotalEntries">
	/// A pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
	/// Note that applications should consider this value only as a hint.
	/// </param>
	/// <param name="ResumeHandle">
	/// A pointer to a value that contains a resume handle which is used to continue the search. The handle should be zero on the first
	/// call and left unchanged for subsequent calls. If ResumeHandle is <c>NULL</c>, then no resume handle is stored.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// An invalid parameter was passed to the function. This error is returned if a NULL pointer is passed in the BufPtr or entriesread parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>There is more data to return. This error is returned if the buffer size is insufficient to hold all entries.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The request is not supported. This error is returned if the UncServerName parameter was not NULL and the remote server does not
	/// support remote RPC calls using the legacy Remote Access Protocol mechanism.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// No special group membership is required to call the <c>NetUseEnum</c> function. This function cannot be executed on a remote
	/// server except in cases of downlevel compatibility using the legacy Remote Access Protocol.
	/// </para>
	/// <para>To retrieve information about one network connection, you can call the NetUseGetInfo function.</para>
	/// <para>
	/// This function applies only to the Server Message Block (LAN Manager Workstation) client. The <c>NetUseEnum</c> function does not
	/// support Distributed File System (DFS) shares. To enumerate shares using a different network provider (WebDAV or a DFS share, for
	/// example), use the WNetOpenEnum, WNetEnumResource, and WNetCloseEnum functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/nf-lmuse-netuseenum NET_API_STATUS NET_API_FUNCTION NetUseEnum( LMSTR
	// UncServerName, DWORD LevelFlags, LPBYTE *BufPtr, DWORD PreferedMaximumSize, LPDWORD EntriesRead, LPDWORD TotalEntries, LPDWORD
	// ResumeHandle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Auto)]
	[PInvokeData("lmuse.h", MSDNShortId = "fb527f85-baea-48e8-b837-967870834ec5")]
	public static extern Win32Error NetUseEnum([Optional] string? UncServerName, uint LevelFlags, out SafeNetApiBuffer BufPtr, uint PreferedMaximumSize, out uint EntriesRead, out uint TotalEntries, ref uint ResumeHandle);

	/// <summary>
	/// <para>The <c>NetUseGetInfo</c> function retrieves information about a connection to a shared resource.</para>
	/// <para>You can also use the WNetGetConnection function to retrieve the name of a network resource associated with a local device.</para>
	/// </summary>
	/// <param name="UncServerName">
	/// <para>
	/// The UNC name of computer on which to execute this function. If this is parameter is <c>NULL</c>, then the local computer is used.
	/// If the UncServerName parameter specified is a remote computer, then the remote computer must support remote RPC calls using the
	/// legacy Remote Access Protocol mechanism.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
	/// </param>
	/// <param name="UseName">
	/// <para>A pointer to a string that specifies the name of the connection for which to return information.</para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
	/// </param>
	/// <param name="LevelFlags">
	/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Specifies a local device name and the share name of a remote resource. The BufPtr parameter is a pointer to a USE_INFO_0 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Specifies information about the connection between a local device and a shared resource, including connection status and type.
	/// The BufPtr parameter is a pointer to a USE_INFO_1 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Specifies information about the connection between a local device and a shared resource. Information includes the connection
	/// status, connection type, user name, and domain name. The BufPtr parameter is a pointer to a USE_INFO_2 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// A pointer to the buffer that receives the data. The format of this data depends on the value of the Level parameter. This buffer
	/// is allocated by the system and must be freed using the NetApiBufferFree function. For more information, see Network Management
	/// Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// No special group membership is required to call the <c>NetUseGetInfo</c> function. This function cannot be executed on a remote
	/// server except in cases of downlevel compatibility.
	/// </para>
	/// <para>
	/// To list all current connections between the local computer and resources on remote servers, you can call the NetUseEnum function.
	/// </para>
	/// <para>
	/// This function applies only to the Server Message Block (LAN Manager Workstation) client. The <c>NetUseGetInfo</c> function does
	/// not support Distributed File System (DFS) shares. To retrieve information for a share using a different network provider (WebDAV
	/// or a DFS share, for example), use the WNetGetConnection function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/nf-lmuse-netusegetinfo NET_API_STATUS NET_API_FUNCTION NetUseGetInfo(
	// LMSTR UncServerName, LMSTR UseName, DWORD LevelFlags, LPBYTE *bufptr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Auto)]
	[PInvokeData("lmuse.h", MSDNShortId = "257875db-5ed9-4569-8dbb-5dcc7a6af95c")]
	public static extern Win32Error NetUseGetInfo([Optional] string? UncServerName, string UseName, uint LevelFlags, out SafeNetApiBuffer bufptr);

	/// <summary>The <c>USE_INFO_0</c> structure contains the name of a shared resource and the local device redirected to it.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/ns-lmuse-_use_info_0 typedef struct _USE_INFO_0 { LMSTR ui0_local;
	// LMSTR ui0_remote; } USE_INFO_0, *PUSE_INFO_0, *LPUSE_INFO_0;
	[PInvokeData("lmuse.h", MSDNShortId = "86db3f19-84c5-4e89-82cb-f01d17dcf4ec")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USE_INFO_0
	{
		/// <summary>
		/// Pointer to a Unicode string that specifies the local device name (for example, drive E or LPT1) being redirected to the
		/// shared resource. The constant DEVLEN specifies the maximum number of characters in the string.
		/// </summary>
		public string ui0_local;

		/// <summary>
		/// Pointer to a Unicode string that specifies the share name of the remote resource being accessed. The string is in the form:
		/// </summary>
		public string ui0_remote;
	}

	/// <summary>
	/// The <c>USE_INFO_1</c> structure contains information about the connection between a local device and a shared resource. The
	/// information includes connection status and connection type.
	/// </summary>
	/// <remarks>
	/// Specifying a <c>ui1_local</c> member that is <c>NULL</c> requests authentication with the server without redirecting a drive
	/// letter or a device. Future redirections involving the server while the same connection is in effect use the password specified by
	/// the <c>ui1_password</c> member in the initial call to the NetUseAdd function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/ns-lmuse-use_info_1 typedef struct _USE_INFO_1 { LMSTR ui1_local; LMSTR
	// ui1_remote; LMSTR ui1_password; DWORD ui1_status; DWORD ui1_asg_type; DWORD ui1_refcount; DWORD ui1_usecount; } USE_INFO_1,
	// *PUSE_INFO_1, *LPUSE_INFO_1;
	[PInvokeData("lmuse.h", MSDNShortId = "b9f680b8-b56a-42be-9af1-d7b18328ded4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USE_INFO_1
	{
		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a string that contains the local device name (for example, drive E or LPT1) being redirected to the shared
		/// resource. The constant DEVLEN specifies the maximum number of characters in the string. This member can be <c>NULL</c>. For
		/// more information, see the following Remarks section.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string? ui1_local;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a string that contains the share name of the remote resource being accessed. The string is in the form:</para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string ui1_remote;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a string that contains the password needed to establish a session between a specific workstation and a server.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string ui1_password;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The status of the connection. This element is not used by the NetUseAdd function. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>USE_OK</term>
		/// <term>The connection is valid.</term>
		/// </item>
		/// <item>
		/// <term>USE_PAUSED</term>
		/// <term>Paused by local workstation.</term>
		/// </item>
		/// <item>
		/// <term>USE_SESSLOST</term>
		/// <term>Disconnected.</term>
		/// </item>
		/// <item>
		/// <term>USE_DISCONN</term>
		/// <term>An error occurred.</term>
		/// </item>
		/// <item>
		/// <term>USE_NETERR</term>
		/// <term>A network error occurred.</term>
		/// </item>
		/// <item>
		/// <term>USE_CONN</term>
		/// <term>The connection is being made.</term>
		/// </item>
		/// <item>
		/// <term>USE_RECONN</term>
		/// <term>Reconnecting.</term>
		/// </item>
		/// </list>
		/// </summary>
		public NetUseStatus ui1_status;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of remote resource being accessed. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>USE_WILDCARD</term>
		/// <term>
		/// Matches the type of the server's shared resources. Wildcards can be used only with the NetUseAdd function, and only when the
		/// ui1_local member is NULL. For more information, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>USE_DISKDEV</term>
		/// <term>Disk device.</term>
		/// </item>
		/// <item>
		/// <term>USE_SPOOLDEV</term>
		/// <term>Spooled printer.</term>
		/// </item>
		/// <item>
		/// <term>USE_IPC</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// </summary>
		public NetUseType ui1_asg_type;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of files, directories, and other processes that are open on the remote resource. This element is not used by the
		/// NetUseAdd function.
		/// </para>
		/// </summary>
		public uint ui1_refcount;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of explicit connections (redirection with a local device name) or implicit UNC connections (redirection without a
		/// local device name) that are established with the resource.
		/// </para>
		/// </summary>
		public uint ui1_usecount;
	}

	/// <summary>
	/// The <c>USE_INFO_2</c> structure contains information about a connection between a local computer and a shared resource, including
	/// connection type, connection status, user name, and domain name.
	/// </summary>
	/// <remarks>
	/// Specifying a <c>ui2_local</c> member that is <c>NULL</c> requests authentication with the server without redirecting a drive
	/// letter or a device. Future redirections involving the server while the same connection is in effect use the authentication
	/// information specified in the initial call to the NetUseAdd function. This information includes the combination of the
	/// <c>ui2_password</c>, <c>ui2_username</c>, and <c>ui2_domainname</c> members.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/ns-lmuse-_use_info_2 typedef struct _USE_INFO_2 { LMSTR ui2_local;
	// LMSTR ui2_remote; LMSTR ui2_password; DWORD ui2_status; DWORD ui2_asg_type; DWORD ui2_refcount; DWORD ui2_usecount; LMSTR
	// ui2_username; LMSTR ui2_domainname; } USE_INFO_2, *PUSE_INFO_2, *LPUSE_INFO_2;
	[PInvokeData("lmuse.h", MSDNShortId = "4cc36108-085a-47c4-9dfa-b46f7e208c8b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USE_INFO_2
	{
		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a string that contains the local device name (for example, drive E or LPT1) being redirected to the shared
		/// resource. The constant DEVLEN specifies the maximum number of characters in the string. This member can be <c>NULL</c>. For
		/// more information, see the following Remarks section.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string? ui2_local;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a string that contains the share name of the remote resource. The string is in the form</para>
		/// </summary>
		public string ui2_remote;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a string that contains the password needed to establish a session with a specific workstation.</para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string ui2_password;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The status of the connection. This element is not used by the NetUseAdd function. The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>USE_OK</term>
		/// <term>The connection is successful.</term>
		/// </item>
		/// <item>
		/// <term>USE_PAUSED</term>
		/// <term>Paused by a local workstation.</term>
		/// </item>
		/// <item>
		/// <term>USE_SESSLOST</term>
		/// <term>Disconnected.</term>
		/// </item>
		/// <item>
		/// <term>USE_DISCONN</term>
		/// <term>An error occurred.</term>
		/// </item>
		/// <item>
		/// <term>USE_NETERR</term>
		/// <term>A network error occurred.</term>
		/// </item>
		/// <item>
		/// <term>USE_CONN</term>
		/// <term>The connection is being made.</term>
		/// </item>
		/// <item>
		/// <term>USE_RECONN</term>
		/// <term>Reconnecting.</term>
		/// </item>
		/// </list>
		/// </summary>
		public NetUseStatus ui2_status;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of remote resource being accessed. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>USE_WILDCARD</term>
		/// <term>
		/// Matches the type of the server's shared resources. Wildcards can be used only with the NetUseAdd function, and only when the
		/// ui2_local member is a NULL string. For more information, see the following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>USE_DISKDEV</term>
		/// <term>Disk device.</term>
		/// </item>
		/// <item>
		/// <term>USE_SPOOLDEV</term>
		/// <term>Spooled printer.</term>
		/// </item>
		/// <item>
		/// <term>USE_IPC</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// </summary>
		public NetUseType ui2_asg_type;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of files, directories, and other processes that are open on the remote resource. This element is not used by the
		/// <c>NetUseAdd</c> function.
		/// </para>
		/// </summary>
		public uint ui2_refcount;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of explicit connections (redirection with a local device name) or implicit UNC connections (redirection without a
		/// local device name) that are established with the resource.
		/// </para>
		/// </summary>
		public uint ui2_usecount;

		/// <summary>
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>A pointer to a string that contains the name of the user who initiated the connection.</para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string ui2_username;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a string that contains the domain name of the remote resource.</para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string ui2_domainname;
	}

	/// <summary>
	/// The <c>USE_INFO_3</c> structure contains information about a connection between a local computer and a shared resource, including
	/// connection type, connection status, user name, domain name, and specific flags that describe connection behavior.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmuse/ns-lmuse-_use_info_3 typedef struct _USE_INFO_3 { USE_INFO_2 ui3_ui2;
	// ULONG ui3_flags; } USE_INFO_3, *PUSE_INFO_3, *LPUSE_INFO_3;
	[PInvokeData("lmuse.h", MSDNShortId = "3fb3ad35-f9e5-46ba-b930-fc2ccafd8ee9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USE_INFO_3
	{
		/// <summary>USE_INFO_2 structure that contains</summary>
		public USE_INFO_2 ui3_ui2;

		/// <summary>A set of bit flags that describe connection behavior and credential handling.</summary>
		public NetUseFlags ui3_flags;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("lmuse.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USE_INFO_4
	{
		/// <summary>Undocumented.</summary>
		public USE_INFO_3 ui4_ui3;

		/// <summary>Undocumented.</summary>
		public uint ui4_auth_identity_length;

		/// <summary>Undocumented.</summary>
		public IntPtr ui4_auth_identity;
	}

	/// <summary>Undocumented.</summary>
	[PInvokeData("lmuse.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct USE_INFO_5
	{
		/// <summary>Undocumented.</summary>
		public USE_INFO_3 ui4_ui3;

		/// <summary>Undocumented.</summary>
		public uint ui4_auth_identity_length;

		/// <summary>Undocumented.</summary>
		public IntPtr ui4_auth_identity;

		/// <summary>Undocumented.</summary>
		public uint ui5_security_descriptor_length;

		/// <summary>Undocumented.</summary>
		public IntPtr ui5_security_descriptor;

		/// <summary>Undocumented.</summary>
		public uint ui5_use_options_length;

		/// <summary>Undocumented.</summary>
		public IntPtr ui5_use_options;
	}
}