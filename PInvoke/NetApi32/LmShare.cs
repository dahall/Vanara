namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>Flags used by SESSION_INFO_XX structures</summary>
	[PInvokeData("lmshare.h", MSDNShortId = "a86a00ae-f60a-4b12-a9ac-4b96f9abd6a2")]
	[Flags]
	public enum SESS
	{
		/// <summary>The user specified by the sesi502_username member established the session using a guest account.</summary>
		SESS_GUEST = 0x00000001,

		/// <summary>The user specified by the sesi502_username member established the session without using password encryption.</summary>
		SESS_NOENCRYPTION = 0x00000002,
	}

	/// <summary>
	/// Indicates the shared resource's permissions for servers running with share-level security. A server running user-level security
	/// ignores this member.
	/// </summary>
	[PInvokeData("lmshare.h", MSDNShortId = "cd152ccd-cd60-455f-b25c-c4939c65e0ab")]
	[Flags]
	public enum ShareLevelAccess
	{
		/// <summary>No access.</summary>
		ACCESS_NONE = 0,

		/// <summary>Permission to read, write, create, execute, and delete resources, and to modify their attributes and permissions.</summary>
		ACCESS_ALL = ACCESS_READ | ACCESS_WRITE | ACCESS_CREATE | ACCESS_EXEC | ACCESS_DELETE | ACCESS_ATRIB | ACCESS_PERM,

		/// <summary>Permission to read data from a resource and, by default, to execute the resource.</summary>
		ACCESS_READ = 0x01,

		/// <summary>Permission to write data to the resource.</summary>
		ACCESS_WRITE = 0x02,

		/// <summary>
		/// Permission to create an instance of the resource (such as a file); data can be written to the resource as the resource is created.
		/// </summary>
		ACCESS_CREATE = 0x04,

		/// <summary>Permission to execute the resource.</summary>
		ACCESS_EXEC = 0x08,

		/// <summary>Permission to delete the resource.</summary>
		ACCESS_DELETE = 0x10,

		/// <summary>Permission to modify the resource's attributes (such as the date and time when a file was last modified).</summary>
		ACCESS_ATRIB = 0x20,

		/// <summary>
		/// Permission to modify the permissions (read, write, create, execute, and delete) assigned to a resource for a user or application.
		/// </summary>
		ACCESS_PERM = 0x40,
	}

	/// <summary>A bitmask of flags that specify information about the shared resource.</summary>
	[PInvokeData("lmshare.h", MSDNShortId = "9fb3e0ae-76b5-4432-80dd-f3361738aa7c")]
	[Flags]
	public enum SHI1005_FLAGS
	{
		/// <summary>The specified share is present in a Dfs tree structure. This flag cannot be set with NetShareSetInfo.</summary>
		SHI1005_FLAGS_DFS = 0x0001,

		/// <summary>The specified share is the root volume in a Dfs tree structure. This flag cannot be set with NetShareSetInfo.</summary>
		SHI1005_FLAGS_DFS_ROOT = 0x0002,

		/// <summary>The specified share disallows exclusive file opens, where reads to an open file are disallowed.</summary>
		SHI1005_FLAGS_RESTRICT_EXCLUSIVE_OPENS = 0x0100,

		/// <summary>Shared files in the specified share can be forcibly deleted.</summary>
		SHI1005_FLAGS_FORCE_SHARED_DELETE = 0x0200,

		/// <summary>Clients are allowed to cache the namespace of the specified share.</summary>
		SHI1005_FLAGS_ALLOW_NAMESPACE_CACHING = 0x0400,

		/// <summary>
		/// The server will filter directory entries based on the access permissions that the user on the client computer has for the
		/// server on which the files reside. Only files for which the user has read access and directories for which the user has
		/// FILE_LIST_DIRECTORY access will be returned. If the user has SeBackupPrivilege, all available information will be returned.
		/// <para>For more information about file and directory access, see File Security and Access Rights.</para>
		/// <para>For more information about SeBackupPrivilege, see Privilege Constants.</para>
		/// <para>Note This flag is supported only on servers running Windows Server 2003 with SP1 or later.</para>
		/// </summary>
		SHI1005_FLAGS_ACCESS_BASED_DIRECTORY_ENUM = 0x0800,

		/// <summary>
		/// Prevents exclusive caching modes that can cause delays for highly shared read-only data.
		/// <para>Note This flag is supported only on servers running Windows Server 2008 R2 or later.</para>
		/// </summary>
		SHI1005_FLAGS_FORCE_LEVELII_OPLOCK = 0x1000,

		/// <summary>
		/// Enables server-side functionality needed for peer caching support. Clients on high-latency or low-bandwidth connections can
		/// use alternate methods to retrieve data from peers if available, instead of sending requests to the server. This is only
		/// supported on shares configured for manual caching (CSC_CACHE_MANUAL_REINT).
		/// <para>Note This flag is supported only on servers running Windows Server 2008 R2 or later.</para>
		/// </summary>
		SHI1005_FLAGS_ENABLE_HASH = 0x2000,

		/// <summary>
		/// Enables Continuous Availability on a cluster share. Handles that are opened against a continuously available share can
		/// survive network failures as well as cluster node failures.
		/// <para>Note This flag can only be set on a scoped share on a server that meets the following conditions:</para>
		/// <para>It is running Windows Server 2012 or later.</para>
		/// <para>It is in a cluster configuration.</para>
		/// <para>It has the "Services for Continuously Available shares" role service installed.</para>
		/// <para>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008 and Windows Server 2003: This flag is not supported.</para>
		/// </summary>
		SHI1005_FLAGS_ENABLE_CA = 0X4000,

		/// <summary>Undocumented.</summary>
		SHI1005_FLAGS_ENCRYPT_DATA = 0x08000,

		/// <summary>Undocumented.</summary>
		SHI1005_FLAGS_RESERVED = 0x10000,

		/// <summary>Undocumented.</summary>
		SHI1005_FLAGS_DISABLE_CLIENT_BUFFERING = 0x20000,

		/// <summary>Undocumented.</summary>
		SHI1005_FLAGS_IDENTITY_REMOTING = 0x40000,

		/// <summary>Undocumented.</summary>
		SHI1005_FLAGS_CLUSTER_MANAGED = 0x80000,

		/// <summary>Used to mask off the following states (including SHI1005_FLAGS_ENABLE_HASH)</summary>
		CSC_MASK_EXT = 0x2030,

		/// <summary>Used to mask off the following states</summary>
		CSC_MASK = 0x0030,

		/// <summary>No automatic file by file reintegration</summary>
		CSC_CACHE_MANUAL_REINT = 0x0000,

		/// <summary>File by file reintegration is OK</summary>
		CSC_CACHE_AUTO_REINT = 0x0010,

		/// <summary>no need to flow opens</summary>
		CSC_CACHE_VDO = 0x0020,

		/// <summary>no CSC for this share</summary>
		CSC_CACHE_NONE = 0x0030,
	}

	/// <summary>Type of shared device.</summary>
	[PInvokeData("lmshare.h", MSDNShortId = "8453dcd2-5c58-4fe4-9426-0fd51647394d")]
	[Flags]
	public enum STYPE : uint
	{
		/// <summary>Disk drive.</summary>
		STYPE_DISKTREE = 0,

		/// <summary>Print queue.</summary>
		STYPE_PRINTQ = 1,

		/// <summary>Communication device.</summary>
		STYPE_DEVICE = 2,

		/// <summary>Interprocess communication (IPC).</summary>
		STYPE_IPC = 3,

		/// <summary>Mask</summary>
		STYPE_MASK = 0x000000FF,

		/// <summary>Reserved.</summary>
		STYPE_RESERVED1 = 0x01000000,

		/// <summary>Reserved.</summary>
		STYPE_RESERVED2 = 0x02000000,

		/// <summary>Reserved.</summary>
		STYPE_RESERVED3 = 0x04000000,

		/// <summary>Reserved.</summary>
		STYPE_RESERVED4 = 0x08000000,

		/// <summary>Reserved.</summary>
		STYPE_RESERVED5 = 0x00100000,

		/// <summary>Reserved.</summary>
		STYPE_RESERVED_ALL = 0x3FFFFF00,

		/// <summary>A temporary share.</summary>
		STYPE_TEMPORARY = 0x40000000,

		/// <summary>
		/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer
		/// to administrative shares such as C$, D$, E$, and so forth. For more information, see Network Share Functions.
		/// </summary>
		STYPE_SPECIAL = 0x80000000,
	}

	/// <summary>
	/// Lists all connections made to a shared resource on the server or all connections established from a particular computer. If there
	/// is more than one user using this connection, then it is possible to get more than one structure for the same connection, but with
	/// a different user name.
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="qualifier">
	/// <para>
	/// Pointer to a string that specifies a share name or computer name for the connections of interest. If it is a share name, then all
	/// the connections made to that share name are listed. If it is a computer name (for example, it starts with two backslash
	/// characters), then <c>NetConnectionEnum</c> lists all connections made from that computer to the server specified.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Return connection identifiers. The bufptr parameter is a pointer to an array of CONNECTION_INFO_0 structures.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Return connection identifiers and connection information. The bufptr parameter is a pointer to an array of CONNECTION_INFO_1 structures.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>
	/// Pointer to the address of the buffer that receives the information. The format of this data depends on the value of the level parameter.
	/// </para>
	/// <para>
	/// This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer
	/// even if the function fails with <c>ERROR_MORE_DATA</c>.
	/// </para>
	/// </param>
	/// <param name="prefmaxlen">
	/// Specifies the preferred maximum length of returned data, in bytes. If you specify <c>MAX_PREFERRED_LENGTH</c>, the function
	/// allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number
	/// of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
	/// <c>ERROR_MORE_DATA</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="totalentries">
	/// Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
	/// Note that applications should consider this value only as a hint.
	/// </param>
	/// <param name="resume_handle">
	/// Pointer to a value that contains a resume handle which is used to continue an existing connection search. The handle should be
	/// zero on the first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, then no resume handle is stored.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrator, Server or Print Operator, or Power User group membership is required to successfully execute the
	/// <c>NetConnectionEnum</c> function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to list the connections made to a shared resource with a call to the
	/// <c>NetConnectionEnum</c> function. The sample calls <c>NetConnectionEnum</c>, specifying information level 1 (CONNECTION_INFO_1).
	/// If there are entries to return, it prints the values of the <c>coni1_username</c> and <c>coni1_netname</c> members. If there are
	/// no entries to return, the sample prints an appropriate message. Finally, the code sample frees the memory allocated for the
	/// information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netconnectionenum NET_API_STATUS NET_API_FUNCTION
	// NetConnectionEnum( LMSTR servername, LMSTR qualifier, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD
	// totalentries, LPDWORD resume_handle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "935ac6e9-78e0-42ae-a454-0a14b03ddc21")]
	public static extern Win32Error NetConnectionEnum([Optional] string? servername, string qualifier, uint level, out SafeNetApiBuffer bufptr,
		uint prefmaxlen, out uint entriesread, out uint totalentries, ref uint resume_handle);

	/// <summary>
	/// Forces a resource to close. This function can be used when an error prevents closure by any other means. You should use
	/// <c>NetFileClose</c> with caution because it does not write data cached on the client system to the file before closing the file.
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="fileid">Specifies the file identifier of the opened resource instance to close.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The file was not found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetFileClose</c> function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netfileclose NET_API_STATUS NET_API_FUNCTION NetFileClose(
	// LMSTR servername, DWORD fileid );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmshare.h", MSDNShortId = "36a5f464-fec3-4b4f-91c3-447ff5ff70af")]
	public static extern Win32Error NetFileClose([MarshalAs(UnmanagedType.LPWStr)] string servername, uint fileid);

	/// <summary>Returns information about some or all open files on a server, depending on the parameters specified.</summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="basepath">
	/// <para>
	/// Pointer to a string that specifies a qualifier for the returned information. If this parameter is <c>NULL</c>, all open resources
	/// are enumerated. If this parameter is not <c>NULL</c>, the function enumerates only resources that have the value of the basepath
	/// parameter as a prefix. (A prefix is the portion of a path that comes before a backslash.)
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="username">
	/// <para>
	/// Pointer to a string that specifies the name of the user or the name of the connection. If the string begins with two backslashes
	/// ("\"), then it indicates the name of the connection, for example, "\127.0.0.1" or "\ClientName". The part of the connection name
	/// after the backslashes is the same as the client name in the session information structure returned by the NetSessionEnum
	/// function. If the string does not begin with two backslashes, then it indicates the name of the user. If this parameter is not
	/// <c>NULL</c>, its value serves as a qualifier for the enumeration. The files returned are limited to those that have user names or
	/// connection names that match the qualifier. If this parameter is <c>NULL</c>, no user-name qualifier is used.
	/// </para>
	/// <para>
	/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This parameter is a pointer to a string that
	/// specifies the name of the user. If this parameter is not <c>NULL</c>, its value serves as a qualifier for the enumeration. The
	/// files returned are limited to those that have user names matching the qualifier. If this parameter is <c>NULL</c>, no user-name
	/// qualifier is used.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>2</term>
	/// <term>Return the file identification number. The bufptr parameter points to an array of FILE_INFO_2 structures.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>Return information about the file. The bufptr parameter points to an array of FILE_INFO_3 structures.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>
	/// Pointer to the address of the buffer that receives the information. The format of this data depends on the value of the level parameter.
	/// </para>
	/// <para>
	/// This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer
	/// even if the function fails with <c>ERROR_MORE_DATA</c>.
	/// </para>
	/// </param>
	/// <param name="prefmaxlen">
	/// Specifies the preferred maximum length of returned data, in bytes. If you specify <c>MAX_PREFERRED_LENGTH</c>, the function
	/// allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number
	/// of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
	/// <c>ERROR_MORE_DATA</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="totalentries">
	/// Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
	/// Note that applications should consider this value only as a hint.
	/// </param>
	/// <param name="resume_handle">
	/// Pointer to a value that contains a resume handle which is used to continue an existing file search. The handle should be zero on
	/// the first call and left unchanged for subsequent calls. If this parameter is <c>NULL</c>, no resume handle is stored.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_BufTooSmall</term>
	/// <term>The supplied buffer is too small.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Only members of the Administrators or Server Operators local group can successfully execute the <c>NetFileEnum</c> function.</para>
	/// <para>You can call the NetFileGetInfo function to retrieve information about a particular opening of a server resource.</para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling <c>NetFileEnum</c>. For more information, see IADsResource and IADsFileServiceOperations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netfileenum NET_API_STATUS NET_API_FUNCTION NetFileEnum(
	// LMSTR servername, LMSTR basepath, LMSTR username, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD
	// totalentries, PDWORD_PTR resume_handle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "1375b337-efb0-4be1-94f7-473456a825b5")]
	public static extern Win32Error NetFileEnum([Optional] string? servername, [Optional] string? basepath, [Optional] string? username, uint level, out SafeNetApiBuffer bufptr,
		uint prefmaxlen, out uint entriesread, out uint totalentries, ref IntPtr resume_handle);

	/// <summary>Retrieves information about a particular opening of a server resource.</summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="fileid">
	/// Specifies the file identifier of the open resource for which to return information. The value of this parameter must have been
	/// returned in a previous enumeration call. For more information, see the following Remarks section.
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>2</term>
	/// <term>Return the file identification number. The bufptr parameter is a pointer to a FILE_INFO_2 structure.</term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>
	/// Return the file identification number and other information about the file. The bufptr parameter is a pointer to a FILE_INFO_3 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// Pointer to the address of the buffer that receives the information. The format of this data depends on the value of the level
	/// parameter. This buffer is allocated by the system and must be freed using the NetApiBufferFree function. For more information,
	/// see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The file was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_BufTooSmall</term>
	/// <term>The supplied buffer is too small.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetFileGetInfo</c> function.
	/// </para>
	/// <para>You can call the NetFileEnum function to retrieve information about multiple files open on a server.</para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling <c>NetFileGetInfo</c>. For more information, see IADsResource and IADsFileServiceOperations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netfilegetinfo NET_API_STATUS NET_API_FUNCTION
	// NetFileGetInfo( LMSTR servername, DWORD fileid, DWORD level, LPBYTE *bufptr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "d50c05e7-7ddd-4a7d-96f6-51878e52373c")]
	public static extern Win32Error NetFileGetInfo([Optional] string? servername, uint fileid, uint level, out SafeNetApiBuffer bufptr);

	/// <summary>Ends a network session between a server and a workstation.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="UncClientName">
	/// Pointer to a string that specifies the computer name of the client to disconnect. If the UncClientName parameter is <c>NULL</c>,
	/// then all the sessions of the user identified by the username parameter will be deleted on the server specified by the servername
	/// parameter. For more information, see NetSessionEnum.
	/// </param>
	/// <param name="username">
	/// Pointer to a string that specifies the name of the user whose session is to be terminated. If this parameter is <c>NULL</c>, all
	/// users' sessions from the client specified by the UncClientName parameter are to be terminated.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_ClientNameNotFound</term>
	/// <term>A session does not exist with that computer name.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Only members of the Administrators or Server Operators local group can successfully execute the <c>NetSessionDel</c> function.</para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management session functions. For more information, see
	/// IADsSession and IADsFileServiceOperations.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to terminate a session between a server and a workstation using a call to the
	/// <c>NetSessionDel</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsessiondel NET_API_STATUS NET_API_FUNCTION
	// NetSessionDel( LMSTR servername, LMSTR UncClientName, LMSTR username );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "a1360f5d-9fd0-44af-b9f5-ab9bc057dfe6")]
	public static extern Win32Error NetSessionDel([Optional] string? servername, [Optional] string? UncClientName, [Optional] string? username);

	/// <summary>Provides information about sessions established on a server.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="UncClientName">
	/// Pointer to a string that specifies the name of the computer session for which information is to be returned. If this parameter is
	/// <c>NULL</c>, <c>NetSessionEnum</c> returns information for all computer sessions on the server.
	/// </param>
	/// <param name="username">
	/// Pointer to a string that specifies the name of the user for which information is to be returned. If this parameter is
	/// <c>NULL</c>, <c>NetSessionEnum</c> returns information for all users.
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Return the name of the computer that established the session. The bufptr parameter points to an array of SESSION_INFO_0 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Return the name of the computer, name of the user, and open files, pipes, and devices on the computer. The bufptr parameter
	/// points to an array of SESSION_INFO_1 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// In addition to the information indicated for level 1, return the type of client and how the user established the session. The
	/// bufptr parameter points to an array of SESSION_INFO_2 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>10</term>
	/// <term>
	/// Return the name of the computer, name of the user, and active and idle times for the session. The bufptr parameter points to an
	/// array of SESSION_INFO_10 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>502</term>
	/// <term>
	/// Return the name of the computer; name of the user; open files, pipes, and devices on the computer; and the name of the transport
	/// the client is using. The bufptr parameter points to an array of SESSION_INFO_502 structures.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter.</para>
	/// <para>
	/// This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer
	/// even if the function fails with <c>ERROR_MORE_DATA</c>.
	/// </para>
	/// </param>
	/// <param name="prefmaxlen">
	/// Specifies the preferred maximum length of returned data, in bytes. If you specify <c>MAX_PREFERRED_LENGTH</c>, the function
	/// allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number
	/// of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
	/// <c>ERROR_MORE_DATA</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="totalentries">
	/// Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
	/// Note that applications should consider this value only as a hint.
	/// </param>
	/// <param name="resume_handle">
	/// Pointer to a value that contains a resume handle which is used to continue an existing session search. The handle should be zero
	/// on the first call and left unchanged for subsequent calls. If resume_handle is <c>NULL</c>, no resume handle is stored.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_ClientNameNotFound</term>
	/// <term>A session does not exist with the computer name.</term>
	/// </item>
	/// <item>
	/// <term>NERR_InvalidComputer</term>
	/// <term>The computer name is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NERR_UserNotFound</term>
	/// <term>The user name could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetSessionEnum</c> function at
	/// level 1 or level 2. No special group membership is required for level 0 or level 10 calls.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management session functions. For more information, see
	/// IADsSession and IADsFileServiceOperations.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to retrieve information about current sessions using a call to the
	/// <c>NetSessionEnum</c> function. The sample calls <c>NetSessionEnum</c>, specifying information level 10 ( SESSION_INFO_10). The
	/// sample loops through the entries and prints the retrieved information. Finally, the code prints the total number of sessions
	/// enumerated and frees the memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsessionenum NET_API_STATUS NET_API_FUNCTION
	// NetSessionEnum( LMSTR servername, LMSTR UncClientName, LMSTR username, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD
	// entriesread, LPDWORD totalentries, LPDWORD resume_handle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "5923a8cc-bf7a-4ffa-b089-fd7f26ee42d2")]
	public static extern Win32Error NetSessionEnum([Optional] string? servername, [Optional] string? UncClientName, [Optional] string? username, uint level, out SafeNetApiBuffer bufptr,
		uint prefmaxlen, out uint entriesread, out uint totalentries, ref uint resume_handle);

	/// <summary>Retrieves information about a session established between a particular server and workstation.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="UncClientName">
	/// Pointer to a string that specifies the name of the computer session for which information is to be returned. This parameter is
	/// required and cannot be <c>NULL</c>. For more information, see NetSessionEnum.
	/// </param>
	/// <param name="username">
	/// Pointer to a string that specifies the name of the user whose session information is to be returned. This parameter is required
	/// and cannot be <c>NULL</c>.
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Return the name of the computer that established the session. The bufptr parameter points to a SESSION_INFO_0 structure.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Return the name of the computer, name of the user, and open files, pipes, and devices on the computer. The bufptr parameter
	/// points to a SESSION_INFO_1 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// In addition to the information indicated for level 1, return the type of client and how the user established the session. The
	/// bufptr parameter points to a SESSION_INFO_2 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>10</term>
	/// <term>
	/// Return the name of the computer; name of the user; and active and idle times for the session. The bufptr parameter points to a
	/// SESSION_INFO_10 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>
	/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. For more
	/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </para>
	/// <para>This buffer is allocated by the system and must be freed using the NetApiBufferFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_ClientNameNotFound</term>
	/// <term>A session does not exist with the computer name.</term>
	/// </item>
	/// <item>
	/// <term>NERR_InvalidComputer</term>
	/// <term>The computer name is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NERR_UserNotFound</term>
	/// <term>The user name could not be found.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetSessionGetInfo</c> function
	/// at level 1 or level 2. No special group membership is required for level 0 or level 10 calls.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management session functions. For more information, see
	/// IADsSession and IADsFileServiceOperations.
	/// </para>
	/// <para>
	/// If you call this function at information level 1 or 2 on a member server or workstation, all authenticated users can view the information.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to retrieve information about a session using a call to the <c>NetSessionGetInfo</c>
	/// function. The sample calls <c>NetSessionGetInfo</c>, specifying information level 10 ( SESSION_INFO_10). If the call succeeds,
	/// the code prints information about the session. Finally, the sample frees the memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsessiongetinfo NET_API_STATUS NET_API_FUNCTION
	// NetSessionGetInfo( LMSTR servername, LMSTR UncClientName, LMSTR username, DWORD level, LPBYTE *bufptr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "d44fb8d8-2b64-4268-8603-7784e2c5f2d5")]
	public static extern Win32Error NetSessionGetInfo([Optional] string? servername, string UncClientName, string username, uint level, out SafeNetApiBuffer bufptr);

	/// <summary>Shares a server resource.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Specifies information about the shared resource, including the name of the resource, type and permissions, and number of
	/// connections. The buf parameter points to a SHARE_INFO_2 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>502</term>
	/// <term>
	/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
	/// and other pertinent information. The buf parameter points to a SHARE_INFO_502 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>503</term>
	/// <term>
	/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
	/// and other pertinent information. The buf parameter points to a SHARE_INFO_503 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="buf">
	/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
	/// information, see Network Management Function Buffers.
	/// </param>
	/// <param name="parm_err">
	/// Pointer to a value that receives the index of the first member of the share information structure that causes the
	/// <c>ERROR_INVALID_PARAMETER</c> error. If this parameter is <c>NULL</c>, the index is not returned on error. For more information,
	/// see the NetShareSetInfo function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_NAME</term>
	/// <term>The character or file system name is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>NERR_DuplicateShare</term>
	/// <term>The share name is already in use on this server.</term>
	/// </item>
	/// <item>
	/// <term>NERR_RedirectedPath</term>
	/// <term>The operation is not valid for a redirected resource. The specified device name is assigned to a shared resource.</term>
	/// </item>
	/// <item>
	/// <term>NERR_UnknownDevDir</term>
	/// <term>The device or directory does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
	/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
	/// </para>
	/// <para>
	/// Only members of the Administrators, System Operators, or Power Users local group can add file shares with a call to the
	/// <c>NetShareAdd</c> function. The Print Operator can add printer shares.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
	/// </para>
	/// <para>
	/// If 503 is specified for the level parameter, the remote server specified in the <c>shi503_servername</c> member of the
	/// SHARE_INFO_503 structure must have been bound to a transport protocol using the NetServerTransportAddEx function. In the call to
	/// <c>NetServerTransportAddEx</c>, either 2 or 3 must have been specified for the level parameter, and the <c>SVTI2_SCOPED_NAME</c>
	/// flag must have been specified in the SERVER_TRANSPORT_INFO_2 structure for the transport protocol.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to share a network resource using a call to the <c>NetShareAdd</c> function. The code
	/// sample fills in the members of the SHARE_INFO_2 structure and calls <c>NetShareAdd</c>, specifying information level 2. A
	/// password is not required because these platforms do not support share-level security.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netshareadd NET_API_STATUS NET_API_FUNCTION NetShareAdd(
	// LMSTR servername, DWORD level, LPBYTE buf, LPDWORD parm_err );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "8b51c155-24e8-4d39-b818-eb2d1bb0ee8b")]
	public static extern Win32Error NetShareAdd([Optional] string? servername, uint level, IntPtr buf, out uint parm_err);

	/// <summary>Checks whether or not a server is sharing a device.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="device">Pointer to a string that specifies the name of the device to check for shared access.</param>
	/// <param name="type">
	/// <para>
	/// Pointer to a variable that receives a bitmask of flags that specify the type of the shared device. This parameter is set only if
	/// the function returns successfully.
	/// </para>
	/// <para>One of the following flags may be specified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>STYPE_DISKTREE</term>
	/// <term>Disk drive.</term>
	/// </item>
	/// <item>
	/// <term>STYPE_PRINTQ</term>
	/// <term>Print queue.</term>
	/// </item>
	/// <item>
	/// <term>STYPE_DEVICE</term>
	/// <term>Communication device.</term>
	/// </item>
	/// <item>
	/// <term>STYPE_IPC</term>
	/// <term>Interprocess communication (IPC).</term>
	/// </item>
	/// </list>
	/// <para>In addition, one or both of the following flags may be specified.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>STYPE_SPECIAL</term>
	/// <term>
	/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer to
	/// administrative shares such as C$, D$, E$, and so forth. For more information, see Network Share Functions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STYPE_TEMPORARY</term>
	/// <term>A temporary share.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_DeviceNotShared</term>
	/// <term>The device is not shared.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
	/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
	/// </para>
	/// <para>No special group membership is required to successfully execute the <c>NetShareCheck</c> function.</para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to check whether a server is sharing a device, using a call to the
	/// <c>NetShareCheck</c> function. The function returns the type of device being shared, as described in the preceding documentation
	/// for the type parameter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsharecheck NET_API_STATUS NET_API_FUNCTION
	// NetShareCheck( LMSTR servername, LMSTR device, LPDWORD type );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "8453dcd2-5c58-4fe4-9426-0fd51647394d")]
	public static extern Win32Error NetShareCheck([Optional] string? servername, string device, out STYPE type);

	/// <summary>
	/// <para>Deletes a share name from a server's list of shared resources, disconnecting all connections to the shared resource.</para>
	/// <para>
	/// The extended function NetShareDelEx allows the caller to specify a SHARE_INFO_0, SHARE_INFO_1, SHARE_INFO_2, SHARE_INFO_502, or
	/// SHARE_INFO_503 structure.
	/// </para>
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="netname">
	/// <para>Pointer to a string that specifies the name of the share to delete.</para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="reserved">Reserved, must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_NetNameNotFound</term>
	/// <term>The share name does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
	/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
	/// </para>
	/// <para>
	/// Only members of the Administrators, Server Operators, or Power Users local group, or those with Server Operator group membership,
	/// can successfully delete file shares with a call to the <c>NetShareDel</c> function. The Print Operator can delete printer shares.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
	/// </para>
	/// <para>Examples</para>
	/// <para>The following code sample demonstrates how to delete a share using a call to the <c>NetShareDel</c> function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsharedel NET_API_STATUS NET_API_FUNCTION NetShareDel(
	// LMSTR servername, LMSTR netname, DWORD reserved );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "374b8f81-b3d6-4967-bd4a-ffd3fdc3cf7c")]
	public static extern Win32Error NetShareDel([Optional] string? servername, string netname, uint reserved = 0);

	/// <summary>
	/// Deletes a share name from a server's list of shared resources, which disconnects all connections to that share. This function,
	/// which is an extended version of the NetShareDel function, allows the caller to specify a SHARE_INFO_0, SHARE_INFO_1,
	/// SHARE_INFO_2, SHARE_INFO_502, or SHARE_INFO_503 structure.
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
	/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> is defined.</para>
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0, 1, 2, or 502</term>
	/// <term>
	/// Specifies information about the shared resource, including the name of the resource, type and permissions, and number of
	/// connections. The buf parameter points to a SHARE_INFO_0, SHARE_INFO_1, SHARE_INFO_2, or SHARE_INFO_502 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>503</term>
	/// <term>
	/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
	/// and other pertinent information. The buf parameter points to a SHARE_INFO_503 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="buf">
	/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
	/// information, see Network Management Function Buffers.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INTERNAL_ERROR</term>
	/// <term>An internal error occurred.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>The request is not supported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If 503 is specified for the level parameter, the buf parameter points to a SHARE_INFO_503 structure, and the
	/// <c>shi503_netname</c> and <c>shi503_servername</c> members of that structure are used to look up the shared resource on the
	/// server; the other members are ignored. The remote server specified in the <c>shi503_servername</c> member must have been bound to
	/// a transport protocol using the NetServerTransportAddEx function. In the call to <c>NetServerTransportAddEx</c>, either 2 or 3
	/// must have been specified for the level parameter, and the <c>SVTI2_SCOPED_NAME</c> flag must have been specified in the
	/// SERVER_TRANSPORT_INFO_2 structure for the transport protocol.
	/// </para>
	/// <para>
	/// If 0, 1, 2, or 502 is specified for the level parameter, the buf parameter points to a SHARE_INFO_0, SHARE_INFO_1, SHARE_INFO_2,
	/// or SHARE_INFO_502 structure, and the <c>shi0_netname</c>, <c>shi1_netname</c>, <c>shi2_netname</c>, or <c>shi502_netname</c>
	/// member of that structure is used; the other members are ignored.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsharedelex NET_API_STATUS NET_API_FUNCTION
	// NetShareDelEx( LMSTR servername, DWORD level, LPBYTE buf );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "2461c533-351b-48f4-b660-cb17ac3398fa")]
	public static extern Win32Error NetShareDelEx([Optional] string? servername, uint level, IntPtr buf);

	/// <summary>
	/// <para>Retrieves information about each shared resource on a server.</para>
	/// <para>
	/// You can also use the WNetEnumResource function to retrieve resource information. However, <c>WNetEnumResource</c> does not
	/// enumerate hidden shares or users connected to a share.
	/// </para>
	/// </summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Return share names. The bufptr parameter points to an array of SHARE_INFO_0 structures.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Return information about shared resources, including the name and type of the resource, and a comment associated with the
	/// resource. The bufptr parameter points to an array of SHARE_INFO_1 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Return information about shared resources, including name of the resource, type and permissions, password, and number of
	/// connections. The bufptr parameter points to an array of SHARE_INFO_2 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>502</term>
	/// <term>
	/// Return information about shared resources, including name of the resource, type and permissions, number of connections, and other
	/// pertinent information. The bufptr parameter points to an array of SHARE_INFO_502 structures. Shares from different scopes are not
	/// returned. For more information about scoping, see the Remarks section of the documentation for the NetServerTransportAddEx function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>503</term>
	/// <term>
	/// Return information about shared resources, including the name of the resource, type and permissions, number of connections, and
	/// other pertinent information. The bufptr parameter points to an array of SHARE_INFO_503 structures. Shares from all scopes are
	/// returned. If the shi503_servername member of this structure is "*", there is no configured server name and the NetShareEnum
	/// function enumerates shares for all the unscoped names. Windows Server 2003 and Windows XP: This information level is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter.</para>
	/// <para>
	/// This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer
	/// even if the function fails with <c>ERROR_MORE_DATA</c>.
	/// </para>
	/// </param>
	/// <param name="prefmaxlen">
	/// Specifies the preferred maximum length of returned data, in bytes. If you specify <c>MAX_PREFERRED_LENGTH</c>, the function
	/// allocates the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number
	/// of bytes that the function returns. If the buffer size is insufficient to hold all entries, the function returns
	/// <c>ERROR_MORE_DATA</c>. For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="totalentries">
	/// Pointer to a value that receives the total number of entries that could have been enumerated. Note that applications should
	/// consider this value only as a hint.
	/// </param>
	/// <param name="resume_handle">
	/// Pointer to a value that contains a resume handle which is used to continue an existing share search. The handle should be zero on
	/// the first call and left unchanged for subsequent calls. If resume_handle is <c>NULL</c>, then no resume handle is stored.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
	/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
	/// </para>
	/// <para>
	/// For interactive users (users who are logged on locally to the machine), no special group membership is required to execute the
	/// <c>NetShareEnum</c> function. For non-interactive users, Administrator, Power User, Print Operator, or Server Operator group
	/// membership is required to successfully execute the <c>NetShareEnum</c> function at levels 2, 502, and 503. No special group
	/// membership is required for level 0 or level 1 calls.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> For all users, Administrator, Power User, Print Operator, or Server Operator group
	/// membership is required to successfully execute the <c>NetShareEnum</c> function at levels 2 and 502.
	/// </para>
	/// <para>
	/// To retrieve a value that indicates whether a share is the root volume in a DFS tree structure, you must call the NetShareGetInfo
	/// function and specify information level 1005.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to retrieve information about each shared resource on a server using a call to the
	/// <c>NetShareEnum</c> function. The sample calls <c>NetShareEnum</c>, specifying information level 502 (SHARE_INFO_502). If the
	/// call succeeds, the code loops through the entries and prints information about each share. The sample also calls the
	/// IsValidSecurityDescriptor function to validate the <c>shi502_security_descriptor</c> member. Finally, the code sample frees the
	/// memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netshareenum NET_API_STATUS NET_API_FUNCTION NetShareEnum(
	// LMSTR servername, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD totalentries, LPDWORD resume_handle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "9114c54d-3905-4d40-9162-b3ea605f6fcb")]
	public static extern Win32Error NetShareEnum([Optional] string? servername, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen,
		out uint entriesread, out uint totalentries, ref uint resume_handle);

	/// <summary>Retrieves information about a particular shared resource on a server.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="netname">Pointer to a string that specifies the name of the share for which to return information.</param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>Return the share name. The bufptr parameter points to a SHARE_INFO_0 structure.</term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Return information about the shared resource, including the name and type of the resource, and a comment associated with the
	/// resource. The bufptr parameter points to a SHARE_INFO_1 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Return information about the shared resource, including name of the resource, type and permissions, password, and number of
	/// connections. The bufptr parameter points to a SHARE_INFO_2 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>501</term>
	/// <term>
	/// Return the name and type of the resource, and a comment associated with the resource. The bufptr parameter points to a
	/// SHARE_INFO_501 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>502</term>
	/// <term>
	/// Return information about the shared resource, including name of the resource, type and permissions, number of connections, and
	/// other pertinent information. The bufptr parameter points to a SHARE_INFO_502 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>503</term>
	/// <term>
	/// Specifies information about the shared resource, including the name of the resource, type and permissions, number of connections,
	/// and other pertinent information. The buf parameter points to a SHARE_INFO_503 structure. If the shi503_servername member of this
	/// structure is "*", there is no configured server name. Windows Server 2003 and Windows XP: This information level is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1005</term>
	/// <term>
	/// Return a value that indicates whether the share is the root volume in a Dfs tree structure. The bufptr parameter points to a
	/// SHARE_INFO_1005 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>
	/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. For more
	/// information, see Network Management Function Buffers.
	/// </para>
	/// <para>This buffer is allocated by the system and must be freed using the NetApiBufferFree function.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// <item>
	/// <term>NERR_NetNameNotFound</term>
	/// <term>The share name does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
	/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
	/// </para>
	/// <para>
	/// For interactive users (users who are logged on locally to the machine), no special group membership is required to execute the
	/// <c>NetShareGetInfo</c> function. For non-interactive users, Administrator, Power User, Print Operator, or Server Operator group
	/// membership is required to successfully execute the NetShareEnum function at levels 2, 502, and 503. No special group membership
	/// is required for level 0 or level 1 calls.
	/// </para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> For all users, Administrator, Power User, Print Operator, or Server Operator group
	/// membership is required to successfully execute the <c>NetShareGetInfo</c> function at levels 2 and 502.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
	/// </para>
	/// <para>
	/// If 503 is specified for the level parameter, the remote server specified in the <c>shi503_servername</c> member of the
	/// SHARE_INFO_503 structure must have been bound to a transport protocol using the NetServerTransportAddEx function. In the call to
	/// <c>NetServerTransportAddEx</c>, either 2 or 3 must have been specified for the level parameter, and the <c>SVTI2_SCOPED_NAME</c>
	/// flag must have been specified in the SERVER_TRANSPORT_INFO_2 structure for the transport protocol.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to retrieve information about a particular shared resource using a call to the
	/// <c>NetShareGetInfo</c> function. The sample calls <c>NetShareGetInfo</c>, specifying information level 502 ( SHARE_INFO_502). If
	/// the call succeeds, the code prints the retrieved data. The sample also calls the IsValidSecurityDescriptor function to validate
	/// the <c>shi502_security_descriptor</c> member. Finally, the sample frees the memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsharegetinfo NET_API_STATUS NET_API_FUNCTION
	// NetShareGetInfo( LMSTR servername, LMSTR netname, DWORD level, LPBYTE *bufptr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "672ea208-4048-4d2f-9606-ee3e2133765b")]
	public static extern Win32Error NetShareGetInfo([Optional] string? servername, string netname, uint level, out SafeNetApiBuffer bufptr);

	/// <summary>Sets the parameters of a shared resource.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="netname">Pointer to a string that specifies the name of the share to set information on.</param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Specifies information about the shared resource, including the name and type of the resource, and a comment associated with the
	/// resource. The buf parameter points to a SHARE_INFO_1 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Specifies information about the shared resource, including the name of the resource, type and permissions, password, and number
	/// of connections. The buf parameter points to a SHARE_INFO_2 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>502</term>
	/// <term>
	/// Specifies information about the shared resource, including the name and type of the resource, required permissions, number of
	/// connections, and other pertinent information. The buf parameter points to a SHARE_INFO_502 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>503</term>
	/// <term>
	/// Specifies the name of the shared resource. The buf parameter points to a SHARE_INFO_503 structure. All members of this structure
	/// except shi503_servername are ignored by the NetShareSetInfo function. Windows Server 2003 and Windows XP: This information level
	/// is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1004</term>
	/// <term>Specifies a comment associated with the shared resource. The buf parameter points to a SHARE_INFO_1004 structure.</term>
	/// </item>
	/// <item>
	/// <term>1005</term>
	/// <term>Specifies a set of flags describing the shared resource. The buf parameter points to a SHARE_INFO_1005 structure.</term>
	/// </item>
	/// <item>
	/// <term>1006</term>
	/// <term>
	/// Specifies the maximum number of concurrent connections that the shared resource can accommodate. The buf parameter points to a
	/// SHARE_INFO_1006 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1501</term>
	/// <term>Specifies the SECURITY_DESCRIPTOR associated with the specified share. The buf parameter points to a SHARE_INFO_1501 structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="buf">
	/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
	/// information, see Network Management Function Buffers.
	/// </param>
	/// <param name="parm_err">
	/// Pointer to a value that receives the index of the first member of the share information structure that causes the
	/// <c>ERROR_INVALID_PARAMETER</c> error. If this parameter is <c>NULL</c>, the index is not returned on error. For more information,
	/// see the following Remarks section.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have access to the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is not valid. For more information, see the following Remarks section.</term>
	/// </item>
	/// <item>
	/// <term>NERR_NetNameNotFound</term>
	/// <term>The share name does not exist.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function applies only to Server Message Block (SMB) shares. For other types of shares, such as Distributed File System (DFS)
	/// or WebDAV shares, use Windows Networking (WNet) functions, which support all types of shares.
	/// </para>
	/// <para>
	/// Only members of the Administrators or Power Users local group, or those with Print or Server Operator group membership, can
	/// successfully execute the <c>NetShareSetInfo</c> function. The Print Operator can set information only about Printer shares.
	/// </para>
	/// <para>
	/// If the <c>NetShareSetInfo</c> function returns <c>ERROR_INVALID_PARAMETER</c>, you can use the parm_err parameter to indicate the
	/// first member of the share information structure that is not valid. (A share information structure begins with <c>SHARE_INFO_</c>
	/// and its format is specified by the level parameter.) The following table lists the values that can be returned in the parm_err
	/// parameter and the corresponding structure member that is in error. (The prefix <c>shi*</c> indicates that the member can begin
	/// with multiple prefixes, for example, shi2 or <c>shi502_</c>.)
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Member</term>
	/// </listheader>
	/// <item>
	/// <term>SHARE_NETNAME_PARMNUM</term>
	/// <term>shi*_netname</term>
	/// </item>
	/// <item>
	/// <term>SHARE_TYPE_PARMNUM</term>
	/// <term>shi*_type</term>
	/// </item>
	/// <item>
	/// <term>SHARE_REMARK_PARMNUM</term>
	/// <term>shi*_remark</term>
	/// </item>
	/// <item>
	/// <term>SHARE_PERMISSIONS_PARMNUM</term>
	/// <term>shi*_permissions</term>
	/// </item>
	/// <item>
	/// <term>SHARE_MAX_USES_PARMNUM</term>
	/// <term>shi*_max_uses</term>
	/// </item>
	/// <item>
	/// <term>SHARE_CURRENT_USES_PARMNUM</term>
	/// <term>shi*_current_uses</term>
	/// </item>
	/// <item>
	/// <term>SHARE_PATH_PARMNUM</term>
	/// <term>shi*_path</term>
	/// </item>
	/// <item>
	/// <term>SHARE_PASSWD_PARMNUM</term>
	/// <term>shi*_passwd</term>
	/// </item>
	/// <item>
	/// <term>SHARE_FILE_SD_PARMNUM</term>
	/// <term>shi*_security_descriptor</term>
	/// </item>
	/// </list>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management share functions. For more information, see IADsFileShare.
	/// </para>
	/// <para>
	/// If 503 is specified for the level parameter, the remote server specified in the <c>shi503_servername</c> member of the
	/// SHARE_INFO_503 structure must have been bound to a transport protocol using the NetServerTransportAddEx function. In the call to
	/// <c>NetServerTransportAddEx</c>, either 2 or 3 must have been specified for the level parameter, and the <c>SVTI2_SCOPED_NAME</c>
	/// flag must have been specified in the SERVER_TRANSPORT_INFO_2 structure for the transport protocol.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to set the comment associated with a shared resource using a call to the
	/// <c>NetShareSetInfo</c> function. To do this, the sample specifies information level 1004 (SHARE_INFO_1004).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/nf-lmshare-netsharesetinfo NET_API_STATUS NET_API_FUNCTION
	// NetShareSetInfo( LMSTR servername, LMSTR netname, DWORD level, LPBYTE buf, LPDWORD parm_err );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmshare.h", MSDNShortId = "216b0b78-87da-4734-ad07-5ad1c9edf494")]
	public static extern Win32Error NetShareSetInfo([Optional] string? servername, string netname, uint level, IntPtr buf, out uint parm_err);

	/// <summary>Contains the identification number of a connection.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_connection_info_0 typedef struct _CONNECTION_INFO_0 {
	// DWORD coni0_id; } CONNECTION_INFO_0, *PCONNECTION_INFO_0, *LPCONNECTION_INFO_0;
	[PInvokeData("lmshare.h", MSDNShortId = "aebafe24-1216-48ab-92db-df8f77d36f26")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CONNECTION_INFO_0
	{
		/// <summary>Specifies a connection identification number.</summary>
		public uint coni0_id;
	}

	/// <summary>
	/// Contains the identification number of a connection, number of open files, connection time, number of users on the connection, and
	/// the type of connection.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-connection_info_1 typedef struct _CONNECTION_INFO_1 {
	// DWORD coni1_id; DWORD coni1_type; DWORD coni1_num_opens; DWORD coni1_num_users; DWORD coni1_time; LMSTR coni1_username; LMSTR
	// coni1_netname; } CONNECTION_INFO_1, *PCONNECTION_INFO_1, *LPCONNECTION_INFO_1;
	[PInvokeData("lmshare.h", MSDNShortId = "9904c448-dcc4-47cc-a2e0-7df8d4d37f3f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CONNECTION_INFO_1
	{
		/// <summary>Specifies a connection identification number.</summary>
		public uint coni1_id;

		/// <summary>
		/// <para>A combination of values that specify the type of connection made from the local device name to the shared resource.</para>
		/// <para>One of the following values may be specified. You can isolate these values by using the <c>STYPE_MASK</c> value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_DISKTREE</term>
		/// <term>Disk drive.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_PRINTQ</term>
		/// <term>Print queue.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_DEVICE</term>
		/// <term>Communication device.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_IPC</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// <para>In addition, one or both of the following values may be specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_SPECIAL</term>
		/// <term>
		/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer
		/// to administrative shares such as C$, D$, E$, and so forth. For more information, see Network Share Functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STYPE_TEMPORARY</term>
		/// <term>A temporary share.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STYPE coni1_type;

		/// <summary>Specifies the number of files currently open as a result of the connection.</summary>
		public uint coni1_num_opens;

		/// <summary>Specifies the number of users on the connection.</summary>
		public uint coni1_num_users;

		/// <summary>Specifies the number of seconds that the connection has been established.</summary>
		public uint coni1_time;

		/// <summary>
		/// <para>
		/// Pointer to a string. If the server sharing the resource is running with user-level security, the <c>coni1_username</c> member
		/// describes which user made the connection. If the server is running with share-level security, <c>coni1_username</c> describes
		/// which computer (computername) made the connection. Note that Windows does not support share-level security.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string coni1_username;

		/// <summary>
		/// <para>
		/// Pointer to a string that specifies either the share name of the server's shared resource or the computername of the client.
		/// The value of this member depends on which name was specified as the qualifier parameter to the NetConnectionEnum function.
		/// The name not specified in the qualifier parameter to <c>NetConnectionEnum</c> is automatically supplied to <c>coni1_netname</c>.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string coni1_netname;
	}

	/// <summary>Contains the identification number for a file, device, or pipe.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_file_info_2 typedef struct _FILE_INFO_2 { DWORD fi2_id; }
	// FILE_INFO_2, *PFILE_INFO_2, *LPFILE_INFO_2;
	[PInvokeData("lmshare.h", MSDNShortId = "c80090d5-7064-4809-9185-02116f7ac2ef")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_INFO_2
	{
		/// <summary>Specifies a DWORD value that contains the identification number assigned to the resource when it is opened.</summary>
		public uint fi2_id;
	}

	/// <summary>Contains the identification number and other pertinent information about files, devices, and pipes.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_file_info_3 typedef struct _FILE_INFO_3 { DWORD fi3_id;
	// DWORD fi3_permissions; DWORD fi3_num_locks; LMSTR fi3_pathname; LMSTR fi3_username; } FILE_INFO_3, *PFILE_INFO_3, *LPFILE_INFO_3;
	[PInvokeData("lmshare.h", MSDNShortId = "67f5fa89-12c7-46fb-a118-de4bfed96923")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FILE_INFO_3
	{
		/// <summary>Specifies a DWORD value that contains the identification number assigned to the resource when it is opened.</summary>
		public uint fi3_id;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that contains the access permissions associated with the opening application. This member can be one
		/// or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PERM_FILE_READ</term>
		/// <term>Permission to read a resource and, by default, execute the resource.</term>
		/// </item>
		/// <item>
		/// <term>PERM_FILE_WRITE</term>
		/// <term>Permission to write to a resource.</term>
		/// </item>
		/// <item>
		/// <term>PERM_FILE_CREATE</term>
		/// <term>Permission to create a resource; data can be written when creating the resource.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint fi3_permissions;

		/// <summary>Specifies a DWORD value that contains the number of file locks on the file, device, or pipe.</summary>
		public uint fi3_num_locks;

		/// <summary>
		/// <para>Pointer to a string that specifies the path of the opened resource.</para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string fi3_pathname;

		/// <summary>
		/// <para>
		/// Pointer to a string that specifies which user (on servers that have user-level security) or which computer (on servers that
		/// have share-level security) opened the resource. Note that Windows does not support share-level security.
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string fi3_username;
	}

	/// <summary>Contains the name of the computer that established the session.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_session_info_0 typedef struct _SESSION_INFO_0 { LMSTR
	// sesi0_cname; } SESSION_INFO_0, *PSESSION_INFO_0, *LPSESSION_INFO_0;
	[PInvokeData("lmshare.h", MSDNShortId = "6b39df47-f25c-41dd-ba15-6e6806c4ec89")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SESSION_INFO_0
	{
		/// <summary>
		/// Pointer to a Unicode string that contains the name of the computer that established the session. This string cannot contain a
		/// backslash ().
		/// </summary>
		public string sesi0_cname;
	}

	/// <summary>
	/// Contains information about the session, including name of the computer; name of the user; and open files, pipes, and devices on
	/// the computer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_session_info_1 typedef struct _SESSION_INFO_1 { LMSTR
	// sesi1_cname; LMSTR sesi1_username; DWORD sesi1_num_opens; DWORD sesi1_time; DWORD sesi1_idle_time; DWORD sesi1_user_flags; }
	// SESSION_INFO_1, *PSESSION_INFO_1, *LPSESSION_INFO_1;
	[PInvokeData("lmshare.h", MSDNShortId = "bc1c985e-b8af-4134-9ae4-511d82e3909b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SESSION_INFO_1
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the name of the computer that established the session. This string cannot contain a
		/// backslash ().
		/// </summary>
		public string sesi1_cname;

		/// <summary>Pointer to a Unicode string specifying the name of the user who established the session.</summary>
		public string sesi1_username;

		/// <summary>Specifies a DWORD value that contains the number of files, devices, and pipes opened during the session.</summary>
		public uint sesi1_num_opens;

		/// <summary>Specifies a DWORD value that contains the number of seconds the session has been active.</summary>
		public uint sesi1_time;

		/// <summary>Specifies a DWORD value that contains the number of seconds the session has been idle.</summary>
		public uint sesi1_idle_time;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that describes how the user established the session. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SESS_GUEST</term>
		/// <term>The user specified by the sesi1_username member established the session using a guest account.</term>
		/// </item>
		/// <item>
		/// <term>SESS_NOENCRYPTION</term>
		/// <term>The user specified by the sesi1_username member established the session without using password encryption.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SESS sesi1_user_flags;
	}

	/// <summary>
	/// Contains information about the session, including name of the computer; name of the user; and active and idle times for the session.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_session_info_10 typedef struct _SESSION_INFO_10 { LMSTR
	// sesi10_cname; LMSTR sesi10_username; DWORD sesi10_time; DWORD sesi10_idle_time; } SESSION_INFO_10, *PSESSION_INFO_10, *LPSESSION_INFO_10;
	[PInvokeData("lmshare.h", MSDNShortId = "a23a5647-f99d-4cb8-9d84-93653a3e7428")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SESSION_INFO_10
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the name of the computer that established the session. This string cannot contain a
		/// backslash ().
		/// </summary>
		public string sesi10_cname;

		/// <summary>Pointer to a Unicode string specifying the name of the user who established the session.</summary>
		public string sesi10_username;

		/// <summary>Specifies the number of seconds the session has been active.</summary>
		public uint sesi10_time;

		/// <summary>Specifies the number of seconds the session has been idle.</summary>
		public uint sesi10_idle_time;
	}

	/// <summary>
	/// Contains information about the session, including name of the computer; name of the user; open files, pipes, and devices on the
	/// computer; and the type of client that established the session.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_session_info_2 typedef struct _SESSION_INFO_2 { LMSTR
	// sesi2_cname; LMSTR sesi2_username; DWORD sesi2_num_opens; DWORD sesi2_time; DWORD sesi2_idle_time; DWORD sesi2_user_flags; LMSTR
	// sesi2_cltype_name; } SESSION_INFO_2, *PSESSION_INFO_2, *LPSESSION_INFO_2;
	[PInvokeData("lmshare.h", MSDNShortId = "c3429eba-4277-4dc7-9255-cd2ff18dc583")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SESSION_INFO_2
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the name of the computer that established the session. This string cannot contain a
		/// backslash ().
		/// </summary>
		public string sesi2_cname;

		/// <summary>Pointer to a Unicode string specifying the name of the user who established the session.</summary>
		public string sesi2_username;

		/// <summary>Specifies a DWORD value that contains the number of files, devices, and pipes opened during the session.</summary>
		public uint sesi2_num_opens;

		/// <summary>Specifies a DWORD value that contains the number of seconds the session has been active.</summary>
		public uint sesi2_time;

		/// <summary>Specifies a DWORD value that contains the number of seconds the session has been idle.</summary>
		public uint sesi2_idle_time;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that describes how the user established the session. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SESS_GUEST</term>
		/// <term>The user specified by the sesi2_username member established the session using a guest account.</term>
		/// </item>
		/// <item>
		/// <term>SESS_NOENCRYPTION</term>
		/// <term>The user specified by the sesi2_username member established the session without using password encryption.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SESS sesi2_user_flags;

		/// <summary>
		/// <para>
		/// Pointer to a Unicode string that specifies the type of client that established the session. Following are the defined types
		/// for LAN Manager servers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DOS LM 1.0</term>
		/// <term>LAN Manager for MS-DOS 1.0 clients</term>
		/// </item>
		/// <item>
		/// <term>DOS LM 2.0</term>
		/// <term>LAN Manager for MS-DOS 2.0 clients</term>
		/// </item>
		/// <item>
		/// <term>OS/2 LM 1.0</term>
		/// <term>LAN Manager for MS-OS/2 1.0 clients</term>
		/// </item>
		/// <item>
		/// <term>OS/2 LM 2.0</term>
		/// <term>LAN Manager for MS-OS/2 2.0 clients</term>
		/// </item>
		/// </list>
		/// <para>Sessions from LAN Manager servers running UNIX also will appear as LAN Manager 2.0.</para>
		/// </summary>
		public string sesi2_cltype_name;
	}

	/// <summary>
	/// Contains information about the session, including name of the computer; name of the user; open files, pipes, and devices on the
	/// computer; and the name of the transport the client is using.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_session_info_502 typedef struct _SESSION_INFO_502 { LMSTR
	// sesi502_cname; LMSTR sesi502_username; DWORD sesi502_num_opens; DWORD sesi502_time; DWORD sesi502_idle_time; DWORD
	// sesi502_user_flags; LMSTR sesi502_cltype_name; LMSTR sesi502_transport; } SESSION_INFO_502, *PSESSION_INFO_502, *LPSESSION_INFO_502;
	[PInvokeData("lmshare.h", MSDNShortId = "a86a00ae-f60a-4b12-a9ac-4b96f9abd6a2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SESSION_INFO_502
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the name of the computer that established the session. This string cannot contain a
		/// backslash ().
		/// </summary>
		public string sesi502_cname;

		/// <summary>Pointer to a Unicode string specifying the name of the user who established the session.</summary>
		public string sesi502_username;

		/// <summary>Specifies the number of files, devices, and pipes opened during the session.</summary>
		public uint sesi502_num_opens;

		/// <summary>Specifies the number of seconds the session has been active.</summary>
		public uint sesi502_time;

		/// <summary>Specifies the number of seconds the session has been idle.</summary>
		public uint sesi502_idle_time;

		/// <summary>
		/// <para>Specifies a value that describes how the user established the session. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SESS_GUEST</term>
		/// <term>The user specified by the sesi502_username member established the session using a guest account.</term>
		/// </item>
		/// <item>
		/// <term>SESS_NOENCRYPTION</term>
		/// <term>The user specified by the sesi502_username member established the session without using password encryption.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SESS sesi502_user_flags;

		/// <summary>
		/// <para>
		/// Pointer to a Unicode string that specifies the type of client that established the session. Following are the defined types
		/// for LAN Manager servers.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DOS LM 1.0</term>
		/// <term>LAN Manager for MS-DOS 1.0 clients.</term>
		/// </item>
		/// <item>
		/// <term>DOS LM 2.0</term>
		/// <term>LAN Manager for MS-DOS 2.0 clients.</term>
		/// </item>
		/// <item>
		/// <term>OS/2 LM 1.0</term>
		/// <term>LAN Manager for MS-OS/2 1.0 clients.</term>
		/// </item>
		/// <item>
		/// <term>OS/2 LM 2.0</term>
		/// <term>LAN Manager for MS-OS/2 2.0 clients.</term>
		/// </item>
		/// </list>
		/// <para>Sessions from LAN Manager servers running UNIX also will appear as LAN Manager 2.0.</para>
		/// </summary>
		public string sesi502_cltype_name;

		/// <summary>Specifies the name of the transport that the client is using to communicate with the server.</summary>
		public string sesi502_transport;
	}

	/// <summary>Contains the name of the shared resource.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_share_info_0 typedef struct _SHARE_INFO_0 { LMSTR
	// shi0_netname; } SHARE_INFO_0, *PSHARE_INFO_0, *LPSHARE_INFO_0;
	[PInvokeData("lmshare.h", MSDNShortId = "47a74c71-1fcb-4c49-93b5-ea7cf3a0e567")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHARE_INFO_0
	{
		/// <summary>Pointer to a Unicode string specifying the share name of a resource.</summary>
		public string shi0_netname;
	}

	/// <summary>
	/// Contains information about the shared resource, including the name and type of the resource, and a comment associated with the resource.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_share_info_1 typedef struct _SHARE_INFO_1 { LMSTR
	// shi1_netname; DWORD shi1_type; LMSTR shi1_remark; } SHARE_INFO_1, *PSHARE_INFO_1, *LPSHARE_INFO_1;
	[PInvokeData("lmshare.h", MSDNShortId = "9bc69340-4ea5-4180-ae5c-667c0a245b66")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHARE_INFO_1
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the share name of a resource. Calls to the NetShareSetInfo function ignore this member.
		/// </summary>
		public string shi1_netname;

		/// <summary>
		/// <para>
		/// A combination of values that specify the type of the shared resource. Calls to the <c>NetShareSetInfo</c> function ignore
		/// this member.
		/// </para>
		/// <para>One of the following values may be specified. You can isolate these values by using the <c>STYPE_MASK</c> value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_DISKTREE</term>
		/// <term>Disk drive.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_PRINTQ</term>
		/// <term>Print queue.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_DEVICE</term>
		/// <term>Communication device.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_IPC</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// <para>In addition, one or both of the following values may be specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_SPECIAL</term>
		/// <term>
		/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer
		/// to administrative shares such as C$, D$, E$, and so forth. For more information, see Network Share Functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STYPE_TEMPORARY</term>
		/// <term>A temporary share.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STYPE shi1_type;

		/// <summary>Pointer to a Unicode string specifying an optional comment about the shared resource.</summary>
		public string? shi1_remark;
	}

	/// <summary>Contains a comment associated with the shared resource.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_share_info_1004 typedef struct _SHARE_INFO_1004 { LMSTR
	// shi1004_remark; } SHARE_INFO_1004, *PSHARE_INFO_1004, *LPSHARE_INFO_1004;
	[PInvokeData("lmshare.h", MSDNShortId = "41749066-d0e2-4a6b-aea5-216af9a530f4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHARE_INFO_1004
	{
		/// <summary>Pointer to a Unicode string that contains an optional comment about the shared resource.</summary>
		public string? shi1004_remark;
	}

	/// <summary>Contains information about the shared resource.</summary>
	/// <remarks>
	/// This structure can be retrieved by calling the NetShareGetInfo function. It can be set by calling the NetShareSetInfo function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_share_info_1005 typedef struct _SHARE_INFO_1005 { DWORD
	// shi1005_flags; } SHARE_INFO_1005, *PSHARE_INFO_1005, *LPSHARE_INFO_1005;
	[PInvokeData("lmshare.h", MSDNShortId = "9fb3e0ae-76b5-4432-80dd-f3361738aa7c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SHARE_INFO_1005
	{
		/// <summary>
		/// <para>A bitmask of flags that specify information about the shared resource.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SHI1005_FLAGS_DFS 0x0001</term>
		/// <term>The specified share is present in a Dfs tree structure. This flag cannot be set with NetShareSetInfo.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_DFS_ROOT 0x0002</term>
		/// <term>The specified share is the root volume in a Dfs tree structure. This flag cannot be set with NetShareSetInfo.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_RESTRICT_EXCLUSIVE_OPENS 0x0100</term>
		/// <term>The specified share disallows exclusive file opens, where reads to an open file are disallowed.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_FORCE_SHARED_DELETE 0x0200</term>
		/// <term>Shared files in the specified share can be forcibly deleted.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ALLOW_NAMESPACE_CACHING 0x0400</term>
		/// <term>Clients are allowed to cache the namespace of the specified share.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ACCESS_BASED_DIRECTORY_ENUM 0x0800</term>
		/// <term>
		/// The server will filter directory entries based on the access permissions that the user on the client computer has for the
		/// server on which the files reside. Only files for which the user has read access and directories for which the user has
		/// FILE_LIST_DIRECTORY access will be returned. If the user has SeBackupPrivilege, all available information will be returned.
		/// For more information about file and directory access, see File Security and Access Rights. For more information about
		/// SeBackupPrivilege, see Privilege Constants.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_FORCE_LEVELII_OPLOCK 0x1000</term>
		/// <term>Prevents exclusive caching modes that can cause delays for highly shared read-only data.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ENABLE_HASH 0x2000</term>
		/// <term>
		/// Enables server-side functionality needed for peer caching support. Clients on high-latency or low-bandwidth connections can
		/// use alternate methods to retrieve data from peers if available, instead of sending requests to the server. This is only
		/// supported on shares configured for manual caching (CSC_CACHE_MANUAL_REINT).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ENABLE_CA 0X4000</term>
		/// <term>
		/// Enables Continuous Availability on a cluster share. Handles that are opened against a continuously available share can
		/// survive network failures as well as cluster node failures. Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server
		/// 2008 and Windows Server 2003: This flag is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The CSC_MASK and CSC_MASK_EXT mask values can be used to apply flags that are specific to client-side caching (CSC).</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CSC_MASK 0x0030</term>
		/// <term>
		/// Provides a mask for the following CSC states. CSC_CACHE_MANUAL_REINT 0x0000 CSC_CACHE_AUTO_REINT 0x0010 CSC_CACHE_VDO 0x0020
		/// CSC_CACHE_NONE 0x0030
		/// </term>
		/// </item>
		/// <item>
		/// <term>CSC_MASK_EXT 0x2030</term>
		/// <term>
		/// Provides a mask for the following CSC states and options. CSC_CACHE_MANUAL_REINT 0x0000 CSC_CACHE_AUTO_REINT 0x0010
		/// CSC_CACHE_VDO 0x0020 CSC_CACHE_NONE 0x0030 SHI1005_FLAGS_ENABLE_HASH 0x2000
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SHI1005_FLAGS shi1005_flags;
	}

	/// <summary>Specifies the maximum number of concurrent connections that the shared resource can accommodate.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-share_info_1006 typedef struct _SHARE_INFO_1006 { DWORD
	// shi1006_max_uses; } SHARE_INFO_1006, *PSHARE_INFO_1006, *LPSHARE_INFO_1006;
	[PInvokeData("lmshare.h", MSDNShortId = "645a8670-5661-4d6c-8d9e-67c1bbb0f1d7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SHARE_INFO_1006
	{
		/// <summary>
		/// Specifies a DWORD value that indicates the maximum number of concurrent connections that the shared resource can accommodate.
		/// The number of connections is unlimited if the value specified in this member is –1.
		/// </summary>
		public uint shi1006_max_uses;
	}

	/// <summary>Contains the security descriptor associated with the specified share. For more information, see Security Descriptors.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-share_info_1501 typedef struct _SHARE_INFO_1501 { DWORD
	// shi1501_reserved; PSECURITY_DESCRIPTOR shi1501_security_descriptor; } SHARE_INFO_1501, *PSHARE_INFO_1501, *LPSHARE_INFO_1501;
	[PInvokeData("lmshare.h", MSDNShortId = "ef5d4936-8c0b-4a3c-b2b9-34868eb01a2e")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SHARE_INFO_1501
	{
		/// <summary>Reserved; must be zero.</summary>
		public uint shi1501_reserved;

		/// <summary>Specifies the SECURITY_DESCRIPTOR associated with the share.</summary>
		public PSECURITY_DESCRIPTOR shi1501_security_descriptor;
	}

	/// <summary>Contains the filter associated with the specified share.</summary>
	[PInvokeData("lmshare.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SHARE_INFO_1503
	{
		/// <summary>Undocumented.</summary>
		public Guid shi1503_sharefilter;
	}

	/// <summary>
	/// Contains information about the shared resource, including name of the resource, type and permissions, and the number of current
	/// connections. For more information about controlling access to securable objects, see Access Control, Privileges, and Securable Objects.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_share_info_2 typedef struct _SHARE_INFO_2 { LMSTR
	// shi2_netname; DWORD shi2_type; LMSTR shi2_remark; DWORD shi2_permissions; DWORD shi2_max_uses; DWORD shi2_current_uses; LMSTR
	// shi2_path; LMSTR shi2_passwd; } SHARE_INFO_2, *PSHARE_INFO_2, *LPSHARE_INFO_2;
	[PInvokeData("lmshare.h", MSDNShortId = "cd152ccd-cd60-455f-b25c-c4939c65e0ab")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHARE_INFO_2
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the share name of a resource. Calls to the NetShareSetInfo function ignore this member.
		/// </summary>
		public string shi2_netname;

		/// <summary>
		/// <para>
		/// A combination of values that specify the type of the shared resource. Calls to the <c>NetShareSetInfo</c> function ignore
		/// this member.
		/// </para>
		/// <para>One of the following values may be specified. You can isolate these values by using the <c>STYPE_MASK</c> value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_DISKTREE</term>
		/// <term>Disk drive.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_PRINTQ</term>
		/// <term>Print queue.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_DEVICE</term>
		/// <term>Communication device.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_IPC</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// <para>In addition, one or both of the following values may be specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_SPECIAL</term>
		/// <term>
		/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer
		/// to administrative shares such as C$, D$, E$, and so forth. For more information, see Network Share Functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STYPE_TEMPORARY</term>
		/// <term>A temporary share.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STYPE shi2_type;

		/// <summary>Pointer to a Unicode string that contains an optional comment about the shared resource.</summary>
		public string? shi2_remark;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that indicates the shared resource's permissions for servers running with share-level security. A
		/// server running user-level security ignores this member. This member can be one or more of the following values. Calls to the
		/// NetShareSetInfo function ignore this member.
		/// </para>
		/// <para>Note that Windows does not support share-level security.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACCESS_READ</term>
		/// <term>Permission to read data from a resource and, by default, to execute the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_WRITE</term>
		/// <term>Permission to write data to the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_CREATE</term>
		/// <term>
		/// Permission to create an instance of the resource (such as a file); data can be written to the resource as the resource is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACCESS_EXEC</term>
		/// <term>Permission to execute the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_DELETE</term>
		/// <term>Permission to delete the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_ATRIB</term>
		/// <term>Permission to modify the resource's attributes (such as the date and time when a file was last modified).</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_PERM</term>
		/// <term>
		/// Permission to modify the permissions (read, write, create, execute, and delete) assigned to a resource for a user or application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACCESS_ALL</term>
		/// <term>Permission to read, write, create, execute, and delete resources, and to modify their attributes and permissions.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ShareLevelAccess shi2_permissions;

		/// <summary>
		/// Specifies a DWORD value that indicates the maximum number of concurrent connections that the shared resource can accommodate.
		/// The number of connections is unlimited if the value specified in this member is –1.
		/// </summary>
		public uint shi2_max_uses;

		/// <summary>
		/// Specifies a DWORD value that indicates the number of current connections to the resource. Calls to the NetShareSetInfo
		/// function ignore this member.
		/// </summary>
		public uint shi2_current_uses;

		/// <summary>
		/// Pointer to a Unicode string specifying the local path for the shared resource. For disks, <c>shi2_path</c> is the path being
		/// shared. For print queues, <c>shi2_path</c> is the name of the print queue being shared. Calls to the <c>NetShareSetInfo</c>
		/// function ignore this member.
		/// </summary>
		public string shi2_path;

		/// <summary>
		/// Pointer to a Unicode string that specifies the share's password when the server is running with share-level security. If the
		/// server is running with user-level security, this member is ignored. The <c>shi2_passwd</c> member can be no longer than
		/// SHPWLEN+1 bytes (including a terminating null character). Calls to the <c>NetShareSetInfo</c> function ignore this member.
		/// Note that Windows does not support share-level security.
		/// </summary>
		public string shi2_passwd;
	}

	/// <summary>
	/// Contains information about the shared resource, including name of the resource, type, remark and flags. For more information
	/// about controlling access to securable objects, see Access Control, Privileges, and Securable Objects.
	/// </summary>
	[PInvokeData("lmshare.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHARE_INFO_501
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the share name of a resource. Calls to the NetShareSetInfo function ignore this member.
		/// </summary>
		public string shi501_netname;

		/// <summary>
		/// <para>
		/// A combination of values that specify the type of the shared resource. Calls to the <c>NetShareSetInfo</c> function ignore
		/// this member.
		/// </para>
		/// <para>One of the following values may be specified. You can isolate these values by using the <c>STYPE_MASK</c> value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_DISKTREE</term>
		/// <term>Disk drive.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_PRINTQ</term>
		/// <term>Print queue.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_DEVICE</term>
		/// <term>Communication device.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_IPC</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// <para>In addition, one or both of the following values may be specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_SPECIAL</term>
		/// <term>
		/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer
		/// to administrative shares such as C$, D$, E$, and so forth. For more information, see Network Share Functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STYPE_TEMPORARY</term>
		/// <term>A temporary share.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STYPE shi501_type;

		/// <summary>Pointer to a Unicode string that contains an optional comment about the shared resource.</summary>
		public string? shi501_remark;

		/// <summary>
		/// <para>A bitmask of flags that specify information about the shared resource.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SHI1005_FLAGS_DFS 0x0001</term>
		/// <term>The specified share is present in a Dfs tree structure. This flag cannot be set with NetShareSetInfo.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_DFS_ROOT 0x0002</term>
		/// <term>The specified share is the root volume in a Dfs tree structure. This flag cannot be set with NetShareSetInfo.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_RESTRICT_EXCLUSIVE_OPENS 0x0100</term>
		/// <term>The specified share disallows exclusive file opens, where reads to an open file are disallowed.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_FORCE_SHARED_DELETE 0x0200</term>
		/// <term>Shared files in the specified share can be forcibly deleted.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ALLOW_NAMESPACE_CACHING 0x0400</term>
		/// <term>Clients are allowed to cache the namespace of the specified share.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ACCESS_BASED_DIRECTORY_ENUM 0x0800</term>
		/// <term>
		/// The server will filter directory entries based on the access permissions that the user on the client computer has for the
		/// server on which the files reside. Only files for which the user has read access and directories for which the user has
		/// FILE_LIST_DIRECTORY access will be returned. If the user has SeBackupPrivilege, all available information will be returned.
		/// For more information about file and directory access, see File Security and Access Rights. For more information about
		/// SeBackupPrivilege, see Privilege Constants.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_FORCE_LEVELII_OPLOCK 0x1000</term>
		/// <term>Prevents exclusive caching modes that can cause delays for highly shared read-only data.</term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ENABLE_HASH 0x2000</term>
		/// <term>
		/// Enables server-side functionality needed for peer caching support. Clients on high-latency or low-bandwidth connections can
		/// use alternate methods to retrieve data from peers if available, instead of sending requests to the server. This is only
		/// supported on shares configured for manual caching (CSC_CACHE_MANUAL_REINT).
		/// </term>
		/// </item>
		/// <item>
		/// <term>SHI1005_FLAGS_ENABLE_CA 0X4000</term>
		/// <term>
		/// Enables Continuous Availability on a cluster share. Handles that are opened against a continuously available share can
		/// survive network failures as well as cluster node failures. Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server
		/// 2008 and Windows Server 2003: This flag is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// <para>The CSC_MASK and CSC_MASK_EXT mask values can be used to apply flags that are specific to client-side caching (CSC).</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CSC_MASK 0x0030</term>
		/// <term>
		/// Provides a mask for the following CSC states. CSC_CACHE_MANUAL_REINT 0x0000 CSC_CACHE_AUTO_REINT 0x0010 CSC_CACHE_VDO 0x0020
		/// CSC_CACHE_NONE 0x0030
		/// </term>
		/// </item>
		/// <item>
		/// <term>CSC_MASK_EXT 0x2030</term>
		/// <term>
		/// Provides a mask for the following CSC states and options. CSC_CACHE_MANUAL_REINT 0x0000 CSC_CACHE_AUTO_REINT 0x0010
		/// CSC_CACHE_VDO 0x0020 CSC_CACHE_NONE 0x0030 SHI1005_FLAGS_ENABLE_HASH 0x2000
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SHI1005_FLAGS shi501_flags;
	}

	/// <summary>
	/// Contains information about the shared resource, including name of the resource, type and permissions, number of connections, and
	/// other pertinent information.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_share_info_502 typedef struct _SHARE_INFO_502 { LMSTR
	// shi502_netname; DWORD shi502_type; LMSTR shi502_remark; DWORD shi502_permissions; DWORD shi502_max_uses; DWORD
	// shi502_current_uses; LMSTR shi502_path; LMSTR shi502_passwd; DWORD shi502_reserved; PSECURITY_DESCRIPTOR
	// shi502_security_descriptor; } SHARE_INFO_502, *PSHARE_INFO_502, *LPSHARE_INFO_502;
	[PInvokeData("lmshare.h", MSDNShortId = "306e6704-2068-42da-bcc4-c0772c719ee8")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHARE_INFO_502
	{
		/// <summary>
		/// Pointer to a Unicode string specifying the name of a shared resource. Calls to the NetShareSetInfo function ignore this member.
		/// </summary>
		public string shi502_netname;

		/// <summary>
		/// <para>A combination of values that specify the type of share. Calls to the <c>NetShareSetInfo</c> function ignore this member.</para>
		/// <para>One of the following values may be specified. You can isolate these values by using the <c>STYPE_MASK</c> value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_DISKTREE</term>
		/// <term>Disk Drive.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_PRINTQ</term>
		/// <term>Print Queue.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_DEVICE</term>
		/// <term>Communication device.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_IPC</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// <para>In addition, one or both of the following values may be specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_SPECIAL</term>
		/// <term>
		/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer
		/// to administrative shares such as C$, D$, E$, and so forth. For more information, see the network share functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STYPE_TEMPORARY</term>
		/// <term>A temporary share.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STYPE shi502_type;

		/// <summary>Pointer to a Unicode string specifying an optional comment about the shared resource.</summary>
		public string? shi502_remark;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that indicates the shared resource's permissions for servers running with share-level security. This
		/// member is ignored on a server running user-level security. This member can be any of the following values. Calls to the
		/// NetShareSetInfo function ignore this member.
		/// </para>
		/// <para>
		/// Note that Windows does not support share-level security. For more information about controlling access to securable objects,
		/// see Access Control, Privileges, and Securable Objects.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACCESS_READ</term>
		/// <term>Permission to read data from a resource and, by default, to execute the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_WRITE</term>
		/// <term>Permission to write data to the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_CREATE</term>
		/// <term>
		/// Permission to create an instance of the resource (such as a file); data can be written to the resource as the resource is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACCESS_EXEC</term>
		/// <term>Permission to execute the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_DELETE</term>
		/// <term>Permission to delete the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_ATRIB</term>
		/// <term>Permission to modify the resource's attributes (such as the date and time when a file was last modified).</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_PERM</term>
		/// <term>
		/// Permission to modify the permissions (read, write, create, execute, and delete) assigned to a resource for a user or application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACCESS_ALL</term>
		/// <term>Permission to read, write, create, execute, and delete resources, and to modify their attributes and permissions.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ShareLevelAccess shi502_permissions;

		/// <summary>
		/// Specifies a DWORD value that indicates the maximum number of concurrent connections that the shared resource can accommodate.
		/// The number of connections is unlimited if the value specified in this member is –1.
		/// </summary>
		public uint shi502_max_uses;

		/// <summary>
		/// Specifies a DWORD value that indicates the number of current connections to the resource. Calls to the NetShareSetInfo
		/// function ignore this member.
		/// </summary>
		public uint shi502_current_uses;

		/// <summary>
		/// Pointer to a Unicode string that contains the local path for the shared resource. For disks, this member is the path being
		/// shared. For print queues, this member is the name of the print queue being shared. Calls to the <c>NetShareSetInfo</c>
		/// function ignore this member.
		/// </summary>
		public string shi502_path;

		/// <summary>
		/// <para>
		/// Pointer to a Unicode string that specifies the share's password (when the server is running with share-level security). If
		/// the server is running with user-level security, this member is ignored. Note that Windows does not support share-level security.
		/// </para>
		/// <para>
		/// This member can be no longer than SHPWLEN+1 bytes (including a terminating null character). Calls to the
		/// <c>NetShareSetInfo</c> function ignore this member.
		/// </para>
		/// </summary>
		public string shi502_passwd;

		/// <summary>Reserved; must be zero. Calls to the NetShareSetInfo function ignore this member.</summary>
		public uint shi502_reserved;

		/// <summary>Specifies the SECURITY_DESCRIPTOR associated with this share.</summary>
		public PSECURITY_DESCRIPTOR shi502_security_descriptor;
	}

	/// <summary>
	/// Contains information about the shared resource. It is identical to the SHARE_INFO_502 structure, except that it also contains the
	/// server name.
	/// </summary>
	/// <remarks>
	/// The remote server specified in the <c>shi503_servername</c> member must have been bound to a transport protocol using the
	/// NetServerTransportAddEx function. In the call to <c>NetServerTransportAddEx</c>, either 2 or 3 must have been specified for the
	/// level parameter, and the <c>SVTI2_SCOPED_NAME</c> value must have been specified in the SERVER_TRANSPORT_INFO_2 structure for the
	/// transport protocol.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmshare/ns-lmshare-_share_info_503 typedef struct _SHARE_INFO_503 { LMSTR
	// shi503_netname; DWORD shi503_type; LMSTR shi503_remark; DWORD shi503_permissions; DWORD shi503_max_uses; DWORD
	// shi503_current_uses; LMSTR shi503_path; LMSTR shi503_passwd; LMSTR shi503_servername; DWORD shi503_reserved; PSECURITY_DESCRIPTOR
	// shi503_security_descriptor; } SHARE_INFO_503, *PSHARE_INFO_503, *LPSHARE_INFO_503;
	[PInvokeData("lmshare.h", MSDNShortId = "12650bc0-f67d-464e-8386-a0fd53cdc749")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SHARE_INFO_503
	{
		/// <summary>
		/// A pointer to a Unicode string specifying the name of a shared resource. Calls to the NetShareSetInfo function ignore this member.
		/// </summary>
		public string shi503_netname;

		/// <summary>
		/// <para>A combination of values that specify the type of share. Calls to the NetShareSetInfo function ignore this member.</para>
		/// <para>One of the following values may be specified. You can isolate these values by using the <c>STYPE_MASK</c> value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_DISKTREE 0x00000000</term>
		/// <term>Disk drive.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_PRINTQ 0x00000001</term>
		/// <term>Print queue.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_DEVICE 0x00000002</term>
		/// <term>Communication device.</term>
		/// </item>
		/// <item>
		/// <term>STYPE_IPC 0x00000003</term>
		/// <term>Interprocess communication (IPC).</term>
		/// </item>
		/// </list>
		/// <para>In addition, one or both of the following values may be specified.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STYPE_SPECIAL 0x80000000</term>
		/// <term>
		/// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). Can also refer
		/// to administrative shares such as C$, D$, E$, and so forth. For more information, see the network share functions.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STYPE_TEMPORARY 0x40000000</term>
		/// <term>A temporary share.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STYPE shi503_type;

		/// <summary>A pointer to a Unicode string specifying an optional comment about the shared resource.</summary>
		public string? shi503_remark;

		/// <summary>
		/// <para>
		/// Specifies a DWORD value that indicates the shared resource's permissions for servers running with share-level security. Note
		/// that Windows does not support share-level security. This member is ignored on a server running user-level security. For more
		/// information about controlling access to securable objects, see Access Control, Privileges, and Securable Objects.
		/// </para>
		/// <para>Calls to the NetShareSetInfo function ignore this member.</para>
		/// <para>This member can be any of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ACCESS_READ 0x00000001</term>
		/// <term>Permission to read data from a resource and, by default, to execute the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_WRITE 0x00000002</term>
		/// <term>Permission to write data to the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_CREATE 0x00000004</term>
		/// <term>
		/// Permission to create an instance of the resource (such as a file); data can be written to the resource as the resource is created.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACCESS_EXEC 0x00000008</term>
		/// <term>Permission to execute the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_DELETE 0x00000010</term>
		/// <term>Permission to delete the resource.</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_ATRIB 0x00000020</term>
		/// <term>Permission to modify the resource's attributes (such as the date and time when a file was last modified).</term>
		/// </item>
		/// <item>
		/// <term>ACCESS_PERM 0x00000040</term>
		/// <term>
		/// Permission to modify the permissions (read, write, create, execute, and delete) assigned to a resource for a user or application.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ACCESS_ALL 0x00008000</term>
		/// <term>Permission to read, write, create, execute, and delete resources, and to modify their attributes and permissions.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ShareLevelAccess shi503_permissions;

		/// <summary>
		/// Specifies a DWORD value that indicates the maximum number of concurrent connections that the shared resource can accommodate.
		/// The number of connections is unlimited if the value specified in this member is –1.
		/// </summary>
		public uint shi503_max_uses;

		/// <summary>
		/// Specifies a DWORD value that indicates the number of current connections to the resource. Calls to the NetShareSetInfo
		/// function ignore this member.
		/// </summary>
		public uint shi503_current_uses;

		/// <summary>
		/// A pointer to a Unicode string that contains the local path for the shared resource. For disks, this member is the path being
		/// shared. For print queues, this member is the name of the print queue being shared. Calls to the NetShareSetInfo function
		/// ignore this member.
		/// </summary>
		public string shi503_path;

		/// <summary>
		/// <para>
		/// A pointer to a Unicode string that specifies the share's password (when the server is running with share-level security). If
		/// the server is running with user-level security, this member is ignored. Note that Windows does not support share-level security.
		/// </para>
		/// <para>
		/// This member can be no longer than SHPWLEN+1 bytes (including a terminating null character). Calls to the NetShareSetInfo
		/// function ignore this member.
		/// </para>
		/// </summary>
		public string shi503_passwd;

		/// <summary>
		/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the shared resource resides. A
		/// value of "*" indicates no configured server name.
		/// </summary>
		public string shi503_servername;

		/// <summary>Reserved; must be zero. Calls to the NetShareSetInfo function ignore this member.</summary>
		public uint shi503_reserved;

		/// <summary>Specifies the SECURITY_DESCRIPTOR associated with this share.</summary>
		public PSECURITY_DESCRIPTOR shi503_security_descriptor;
	}
}