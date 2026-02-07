namespace Vanara.PInvoke;

/// <summary>Platform invokable enumerated types, constants and functions from netapi32.h</summary>
public static partial class NetApi32
{
	/// <summary>
	/// A constant of type DWORD that is set to –1. This value is valid as an input parameter to any method that takes a
	/// PreferedMaximumLength parameter. When specified as an input parameter, this value indicates that the method MUST allocate as much
	/// space as the data requires.
	/// </summary>
	public const uint MAX_PREFERRED_LENGTH = unchecked((uint)-1);

	/// <summary>Filters used by <see cref="NetServerEnum(string, uint, out SafeNetApiBuffer, uint, out uint, out uint, NetServerEnumFilter, string, IntPtr)"/>.</summary>
	[Flags]
	[PInvokeData("lmserver.h", MSDNShortId = "aa370623")]
	public enum NetServerEnumFilter : uint
	{
		/// <summary>All workstations.</summary>
		SV_TYPE_WORKSTATION = 0x00000001,

		/// <summary>All computers that run the Server service.</summary>
		SV_TYPE_SERVER = 0x00000002,

		/// <summary>Any server that runs an instance of Microsoft SQL Server.</summary>
		SV_TYPE_SQLSERVER = 0x00000004,

		/// <summary>A server that is primary domain controller.</summary>
		SV_TYPE_DOMAIN_CTRL = 0x00000008,

		/// <summary>Any server that is a backup domain controller.</summary>
		SV_TYPE_DOMAIN_BAKCTRL = 0x00000010,

		/// <summary>Any server that runs the Timesource service.</summary>
		SV_TYPE_TIME_SOURCE = 0x00000020,

		/// <summary>Any server that runs the Apple Filing Protocol (AFP) file service.</summary>
		SV_TYPE_AFP = 0x00000040,

		/// <summary>Any server that is a Novell server.</summary>
		SV_TYPE_NOVELL = 0x00000080,

		/// <summary>Any computer that is LAN Manager 2.x domain member.</summary>
		SV_TYPE_DOMAIN_MEMBER = 0x00000100,

		/// <summary>Any computer that shares a print queue.</summary>
		SV_TYPE_PRINTQ_SERVER = 0x00000200,

		/// <summary>Any server that runs a dial-in service.</summary>
		SV_TYPE_DIALIN_SERVER = 0x00000400,

		/// <summary>Any server that is a Xenix server.</summary>
		SV_TYPE_XENIX_SERVER = 0x00000800,

		/// <summary>Any server that is a UNIX server. This is the same as the SV_TYPE_XENIX_SERVER.</summary>
		SV_TYPE_SERVER_UNIX = 0x00000800,

		/// <summary>A workstation or server.</summary>
		SV_TYPE_NT = 0x00001000,

		/// <summary>Any computer that runs Windows for Workgroups.</summary>
		SV_TYPE_WFW = 0x00002000,

		/// <summary>Any server that runs the Microsoft File and Print for NetWare service.</summary>
		SV_TYPE_SERVER_MFPN = 0x00004000,

		/// <summary>Any server that is not a domain controller.</summary>
		SV_TYPE_SERVER_NT = 0x00008000,

		/// <summary>Any computer that can run the browser service.</summary>
		SV_TYPE_POTENTIAL_BROWSER = 0x00010000,

		/// <summary>A computer that runs a browser service as backup.</summary>
		SV_TYPE_BACKUP_BROWSER = 0x00020000,

		/// <summary>A computer that runs the master browser service.</summary>
		SV_TYPE_MASTER_BROWSER = 0x00040000,

		/// <summary>A computer that runs the domain master browser.</summary>
		SV_TYPE_DOMAIN_MASTER = 0x00080000,

		/// <summary>A computer that runs OSF/1.</summary>
		SV_TYPE_SERVER_OSF = 0x00100000,

		/// <summary>A computer that runs Open Virtual Memory System (VMS).</summary>
		SV_TYPE_SERVER_VMS = 0x00200000,

		/// <summary>A computer that runs Windows.</summary>
		SV_TYPE_WINDOWS = 0x00400000,

		/// <summary>A computer that is the root of Distributed File System (DFS) tree.</summary>
		SV_TYPE_DFS = 0x00800000,

		/// <summary>Server clusters available in the domain.</summary>
		SV_TYPE_CLUSTER_NT = 0x01000000,

		/// <summary>A server running the Terminal Server service.</summary>
		SV_TYPE_TERMINALSERVER = 0x02000000,

		/// <summary>
		/// Cluster virtual servers available in the domain.
		/// <para>Windows 2000: This value is not supported.</para>
		/// </summary>
		SV_TYPE_CLUSTER_VS_NT = 0x04000000,

		/// <summary>A computer that runs IBM Directory and Security Services (DSS) or equivalent.</summary>
		SV_TYPE_DCE = 0x10000000,

		/// <summary>A computer that over an alternate transport.</summary>
		SV_TYPE_ALTERNATE_XPORT = 0x20000000,

		/// <summary>Any computer maintained in a list by the browser. See the following Remarks section.</summary>
		SV_TYPE_LOCAL_LIST_ONLY = 0x40000000,

		/// <summary>The primary domain.</summary>
		SV_TYPE_DOMAIN_ENUM = 0x80000000,

		/// <summary>All servers. This is a convenience that will return all possible servers.</summary>
		SV_TYPE_ALL = 0xFFFFFFFF,
	}

	/// <summary>Flags used by <see cref="SERVER_TRANSPORT_INFO_2"/>.</summary>
	[Flags]
	[PInvokeData("lmserver.h")]
	public enum SERVER_TRANSPORT_FLAGS : uint
	{
		/// <summary>
		/// If this value is set for an endpoint, client requests arriving over the transport to open a named pipe are rerouted
		/// (remapped) to the following local pipe name:
		/// <para>
		/// <code>
		/// $$\ServerName\PipeName
		/// </code>
		/// </para>
		/// </summary>
		SVTI2_REMAP_PIPE_NAMES = 0x02,

		/// <summary>
		/// If this value is set for an endpoint and there is an attempt to create a second transport with the same network address but a
		/// different transport name and conflicting settings for the SCOPED flag, this transport creation will fail. Thus, every
		/// registered transport for a given network address must have the same scoped setting.
		/// <para>This value is defined on Windows Server 2008 and Windows Vista with SP1.</para>
		/// </summary>
		SVTI2_SCOPED_NAME = 0x04,

		/// <summary>The scope belongs to clustering.</summary>
		SVTI2_CLUSTER_NAME = 0x08,

		/// <summary>The scope belongs to scale-out clustering.</summary>
		SVTI2_CLUSTER_DNN_NAME = 0x10,

		/// <summary>The transport address field passed with the server transport info struct contains a unicode string.</summary>
		SVTI2_UNICODE_TRANSPORT_ADDRESS = 0x20,
	}

	/// <summary>The information level to use for platform-specific information.</summary>
	[PInvokeData("lmserver.h", MSDNShortId = "aa370903")]
	public enum ServerPlatform
	{
		/// <summary>The MS-DOS platform.</summary>
		PLATFORM_ID_DOS = 300,

		/// <summary>The OS/2 platform.</summary>
		PLATFORM_ID_OS2 = 400,

		/// <summary>The Windows NT platform.</summary>
		PLATFORM_ID_NT = 500,

		/// <summary>The OSF platform.</summary>
		PLATFORM_ID_OSF = 600,

		/// <summary>The VMS platform.</summary>
		PLATFORM_ID_VMS = 700
	}

	/// <summary>Inherit from this interface for any implementation of the SERVER_INFO_XXXX structures to use the helper functions.</summary>
	public interface INetServerInfo { }

	/// <summary>
	/// <para>
	/// The <c>NetServerComputerNameAdd</c> function enumerates the transports on which the specified server is active, and binds the
	/// emulated server name to each of the transports.
	/// </para>
	/// <para>
	/// <c>NetServerComputerNameAdd</c> is a utility function that combines the functionality of the NetServerTransportEnum function and
	/// the NetServerTransportAddEx function.
	/// </para>
	/// </summary>
	/// <param name="ServerName">
	/// <para>
	/// Pointer to a string that specifies the name of the remote server on which the function is to execute. If this parameter is
	/// <c>NULL</c>, the local computer is used.
	/// </para>
	/// </param>
	/// <param name="EmulatedDomainName">
	/// <para>
	/// Pointer to a string that contains the domain name the specified server should use when announcing its presence using the
	/// EmulatedServerName. This parameter is optional.
	/// </para>
	/// </param>
	/// <param name="EmulatedServerName">
	/// <para>
	/// Pointer to a null-terminated character string that contains the emulated name the server should begin supporting in addition to
	/// the name specified by the ServerName parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is NERR_Success. Note that <c>NetServerComputerNameAdd</c> succeeds if the emulated
	/// server name specified is added to at least one transport.
	/// </para>
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
	/// <term>ERROR_DUP_NAME</term>
	/// <term>A duplicate name exists on the network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DOMAINNAME</term>
	/// <term>The domain name could not be found on the network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerComputerNameAdd</c> function.
	/// </para>
	/// <para>
	/// The server specified by the ServerName parameter continues to support all names it was supporting, and additionally begins to
	/// support new names supplied by successful calls to the <c>NetServerComputerNameAdd</c> function.
	/// </para>
	/// <para>
	/// Name emulation that results from a call to <c>NetServerComputerNameAdd</c> ceases when the server reboots or restarts. To
	/// discontinue name emulation set by a previous call to <c>NetServerComputerNameAdd</c> without restarting or rebooting, you can
	/// call the NetServerComputerNameDel function.
	/// </para>
	/// <para>
	/// The <c>NetServerComputerNameAdd</c> function is typically used when a system administrator replaces a server, but wants to keep
	/// the conversion transparent to users.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// Following is an example of a call to the <c>NetServerComputerNameAdd</c> function requesting that \Server1 also respond to
	/// requests for \Server2.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netservercomputernameadd NET_API_STATUS NET_API_FUNCTION
	// NetServerComputerNameAdd( LMSTR ServerName, LMSTR EmulatedDomainName, LMSTR EmulatedServerName );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "0789fbfe-be91-4849-a31c-1e1a6ae1e70d")]
	public static extern Win32Error NetServerComputerNameAdd([Optional] string? ServerName, [Optional] string? EmulatedDomainName, string EmulatedServerName);

	/// <summary>
	/// <para>
	/// The <c>NetServerComputerNameDel</c> function causes the specified server to cease supporting the emulated server name set by a
	/// previous call to the NetServerComputerNameAdd function. The function does this by unbinding network transports from the emulated name.
	/// </para>
	/// </summary>
	/// <param name="ServerName">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
	/// </param>
	/// <param name="EmulatedServerName">
	/// <para>
	/// Pointer to a null-terminated character string that contains the emulated name the server should stop supporting. The server
	/// continues to support all other server names it was supporting.
	/// </para>
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
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is invalid.</term>
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
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerComputerNameDel</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netservercomputernamedel NET_API_STATUS NET_API_FUNCTION
	// NetServerComputerNameDel( LMSTR ServerName, LMSTR EmulatedServerName );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "501232ad-2821-4bbd-9f16-0f49984f6101")]
	public static extern Win32Error NetServerComputerNameDel([Optional] string? ServerName, string EmulatedServerName);

	/// <summary>
	/// The <c>NetServerDiskEnum</c> function retrieves a list of disk drives on a server. The function returns an array of
	/// three-character strings (a drive letter, a colon, and a terminating null character).
	/// </summary>
	/// <param name="servername">
	/// A pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </param>
	/// <param name="level">The level of information required. A value of zero is the only valid level.</param>
	/// <param name="bufptr">
	/// A pointer to the buffer that receives the data. The data is an array of three-character strings (a drive letter, a colon, and a
	/// terminating null character). This buffer is allocated by the system and must be freed using the NetApiBufferFree function. Note
	/// that you must free the buffer even if the function fails with ERROR_MORE_DATA.
	/// </param>
	/// <param name="prefmaxlen">
	/// <para>
	/// The preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates the amount
	/// of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes that the
	/// function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
	/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </para>
	/// <para><c>Note</c> This parameter is currently ignored.</para>
	/// </param>
	/// <param name="entriesread">A pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="totalentries">
	/// A pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
	/// Note that applications should consider this value only as a hint.
	/// </param>
	/// <param name="resume_handle">
	/// A pointer to a value that contains a resume handle which is used to continue an existing server disk search. The handle should be
	/// zero on the first call and left unchanged for subsequent calls. If the resume_handle parameter is a <c>NULL</c> pointer, then no
	/// resume handle is stored.
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
	/// <term>The value specified for the level parameter is invalid.</term>
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
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The request is not supported. This error is returned if a remote server was specified in servername parameter, the remote server
	/// only supports remote RPC calls using the legacy Remote Access Protocol mechanism, and this request is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerDiskEnum</c> function
	/// on a remote computer.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same results you can achieve by calling the network management server functions. For more information, see the
	/// IADsComputer interface reference.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to call the <c>NetServerDiskEnum</c> function to retrieve a list of disk drives on a
	/// server. The sample calls <c>NetServerDiskEnum</c>, specifying the information level 0 (required). If there are entries to return,
	/// and the user has access to the information, it prints a list of the drives, in the format of a three-character string: a drive
	/// letter, a colon, and a terminating null character. The sample also prints the total number of entries that are available and a
	/// hint about the number of entries actually enumerated. Finally, the code sample frees the memory allocated for the buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netserverdiskenum NET_API_STATUS NET_API_FUNCTION
	// NetServerDiskEnum( LMSTR servername, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD totalentries,
	// LPDWORD resume_handle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "56c981f4-7a1d-4465-bd7b-5996222c4210")]
	public static extern Win32Error NetServerDiskEnum([Optional] string? servername, [Optional] uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref uint resume_handle);

	/// <summary>The <c>NetServerEnum</c> function lists all servers of the specified type that are visible in a domain.</summary>
	/// <param name="servername">Reserved; must be <c>NULL</c>.</param>
	/// <param name="level">
	/// <para>The information level of the data requested. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>100</term>
	/// <term>Return server names and platform information. The bufptr parameter points to an array of SERVER_INFO_100 structures.</term>
	/// </item>
	/// <item>
	/// <term>101</term>
	/// <term>Return server names, types, and associated data. The bufptr parameter points to an array of SERVER_INFO_101 structures.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// A pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer
	/// is allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the
	/// function fails with ERROR_MORE_DATA.
	/// </param>
	/// <param name="prefmaxlen">
	/// The preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates the amount
	/// of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes that the
	/// function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
	/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="entriesread">A pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="totalentries">
	/// A pointer to a value that receives the total number of visible servers and workstations on the network. Note that applications
	/// should consider this value only as a hint.
	/// </param>
	/// <param name="servertype">
	/// <para>
	/// A value that filters the server entries to return from the enumeration. This parameter can be a combination of the following
	/// values defined in the Lmserver.h header file.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>SV_TYPE_WORKSTATION 0x00000001</term>
	/// <term>All workstations.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_SERVER 0x00000002</term>
	/// <term>All computers that run the Server service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_SQLSERVER 0x00000004</term>
	/// <term>Any server that runs an instance of Microsoft SQL Server.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DOMAIN_CTRL 0x00000008</term>
	/// <term>A server that is primary domain controller.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DOMAIN_BAKCTRL 0x00000010</term>
	/// <term>Any server that is a backup domain controller.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_TIME_SOURCE 0x00000020</term>
	/// <term>Any server that runs the Timesource service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_AFP 0x00000040</term>
	/// <term>Any server that runs the Apple Filing Protocol (AFP) file service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_NOVELL 0x00000080</term>
	/// <term>Any server that is a Novell server.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DOMAIN_MEMBER 0x00000100</term>
	/// <term>Any computer that is LAN Manager 2.x domain member.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_PRINTQ_SERVER 0x00000200</term>
	/// <term>Any computer that shares a print queue.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DIALIN_SERVER 0x00000400</term>
	/// <term>Any server that runs a dial-in service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_XENIX_SERVER 0x00000800</term>
	/// <term>Any server that is a Xenix server.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_SERVER_UNIX 0x00000800</term>
	/// <term>Any server that is a UNIX server. This is the same as the SV_TYPE_XENIX_SERVER.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_NT 0x00001000</term>
	/// <term>A workstation or server.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_WFW 0x00002000</term>
	/// <term>Any computer that runs Windows for Workgroups.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_SERVER_MFPN 0x00004000</term>
	/// <term>Any server that runs the Microsoft File and Print for NetWare service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_SERVER_NT 0x00008000</term>
	/// <term>Any server that is not a domain controller.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_POTENTIAL_BROWSER 0x00010000</term>
	/// <term>Any computer that can run the browser service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_BACKUP_BROWSER 0x00020000</term>
	/// <term>A computer that runs a browser service as backup.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_MASTER_BROWSER 0x00040000</term>
	/// <term>A computer that runs the master browser service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DOMAIN_MASTER 0x00080000</term>
	/// <term>A computer that runs the domain master browser.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_SERVER_OSF 0x00100000</term>
	/// <term>A computer that runs OSF/1.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_SERVER_VMS 0x00200000</term>
	/// <term>A computer that runs Open Virtual Memory System (VMS).</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_WINDOWS 0x00400000</term>
	/// <term>A computer that runs Windows.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DFS 0x00800000</term>
	/// <term>A computer that is the root of Distributed File System (DFS) tree.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_CLUSTER_NT 0x01000000</term>
	/// <term>Server clusters available in the domain.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_TERMINALSERVER 0x02000000</term>
	/// <term>A server running the Terminal Server service.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_CLUSTER_VS_NT 0x04000000</term>
	/// <term>Cluster virtual servers available in the domain. Windows 2000: This value is not supported.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DCE 0x10000000</term>
	/// <term>A computer that runs IBM Directory and Security Services (DSS) or equivalent.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_ALTERNATE_XPORT 0x20000000</term>
	/// <term>A computer that over an alternate transport.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_LOCAL_LIST_ONLY 0x40000000</term>
	/// <term>Any computer maintained in a list by the browser. See the following Remarks section.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_DOMAIN_ENUM 0x80000000</term>
	/// <term>The primary domain.</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_ALL 0xFFFFFFFF</term>
	/// <term>All servers. This is a convenience that will return all possible servers.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="domain">
	/// <para>
	/// A pointer to a constant string that specifies the name of the domain for which a list of servers is to be returned. The domain
	/// name must be a NetBIOS domain name (for example, microsoft). The <c>NetServerEnum</c> function does not support DNS-style names
	/// (for example, microsoft.com).
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the primary domain is implied.</para>
	/// </param>
	/// <param name="resume_handle">Reserved; must be set to zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value can be one of the following error codes:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED 5</term>
	/// <term>Access was denied.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER 87</term>
	/// <term>The parameter is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA 234</term>
	/// <term>More entries are available. Specify a large enough buffer to receive all entries.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_BROWSER_SERVERS_FOUND 6118</term>
	/// <term>No browser servers found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED 50</term>
	/// <term>The request is not supported.</term>
	/// </item>
	/// <item>
	/// <term>NERR_RemoteErr 2127</term>
	/// <term>A remote error occurred with no data returned by the server.</term>
	/// </item>
	/// <item>
	/// <term>NERR_ServerNotStarted 2114</term>
	/// <term>The server service is not started.</term>
	/// </item>
	/// <item>
	/// <term>NERR_ServiceNotInstalled 2184</term>
	/// <term>The service has not been started.</term>
	/// </item>
	/// <item>
	/// <term>NERR_WkstaNotStarted 2138</term>
	/// <term>
	/// The Workstation service has not been started. The local workstation service is used to communicate with a downlevel remote server.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NetServerEnum</c> function is used to list all servers of the specified type that are visible in a domain. For example, an
	/// application can call <c>NetServerEnum</c> to list all domain controllers only or all servers that run instances of SQL server only.
	/// </para>
	/// <para>
	/// An application combine the bit masks for various server types in the servertype parameter to list several types. For example, a
	/// value of SV_TYPE_WORKSTATION | SVTYPE_SERVER (0x00000003) combines the bit masks for SV_TYPE_WORKSTATION (0x00000001) and
	/// SV_TYPE_SERVER (0x00000002).
	/// </para>
	/// <para>If you require more information for a specific server, call the WNetEnumResource function.</para>
	/// <para>No special group membership is required to successfully execute the <c>NetServerEnum</c> function.</para>
	/// <para>
	/// If you specify the value SV_TYPE_LOCAL_LIST_ONLY, the <c>NetServerEnum</c> function returns the list of servers that the browser
	/// maintains internally. This has meaning only on the master browser (or on a computer that has been the master browser in the
	/// past). The master browser is the computer that currently has rights to determine which computers can be servers or workstations
	/// on the network.
	/// </para>
	/// <para>
	/// If there are no servers found that match the types specified in the servertype parameter, the <c>NetServerEnum</c> function
	/// returns the bufptr parameter as <c>NULL</c> and DWORD values pointed to by the entriesread and totalentries parameters are set to zero.
	/// </para>
	/// <para>
	/// The <c>NetServerEnum</c> function depends on the browser service being installed and running. If no browser servers are found,
	/// then <c>NetServerEnum</c> fails with ERROR_NO_BROWSER_SERVERS_FOUND.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same function you can achieve by calling the network management server functions. For more information, see IADsComputer.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to list all servers that are visible in a domain with a call to the
	/// <c>NetServerEnum</c> function. The sample calls <c>NetServerEnum</c>, specifying information level 101 ( SERVER_INFO_101). If any
	/// servers are found, the sample code loops through the entries and prints the retrieved data. If the server is a domain controller,
	/// it identifies the server as either a primary domain controller (PDC) or a backup domain controller (BDC). The sample also prints
	/// the total number of entries available and a hint about the number of entries actually enumerated, warning the user if all entries
	/// were not enumerated. Finally, the sample frees the memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netserverenum NET_API_STATUS NET_API_FUNCTION
	// NetServerEnum( IN LMCSTR servername, IN DWORD level, OUT LPBYTE *bufptr, IN DWORD prefmaxlen, OUT LPDWORD entriesread, OUT LPDWORD
	// totalentries, IN DWORD servertype, IN LMCSTR domain, IN OUT LPDWORD resume_handle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "10012a87-805e-4817-9f09-9e5632b1fa09")]
	public static extern Win32Error NetServerEnum([Optional] string? servername, uint level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread,
		out uint totalentries, NetServerEnumFilter servertype, [Optional] string? domain, [Optional] IntPtr resume_handle);

	/// <summary>The NetServerGetInfo function retrieves current configuration information for the specified server.</summary>
	/// <param name="servername">
	/// Pointer to a string that specifies the name of the remote server on which the function is to execute. If this parameter is NULL,
	/// the local computer is used.
	/// </param>
	/// <param name="level">Specifies the information level of the data.</param>
	/// <param name="bufptr">
	/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is
	/// allocated by the system and must be freed using the NetApiBufferFree function.
	/// </param>
	/// <returns>If the function succeeds, the return value is NERR_Success.</returns>
	[DllImport(Lib.NetApi32, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "aa370624")]
	public static extern Win32Error NetServerGetInfo([Optional] string? servername, int level, out SafeNetApiBuffer bufptr);

	/// <summary>
	/// <para>
	/// The <c>NetServerSetInfo</c> function sets a server's operating parameters; it can set them individually or collectively. The
	/// information is stored in a way that allows it to remain in effect after the system has been reinitialized.
	/// </para>
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the name of the remote server on which the function is to execute. If this parameter is
	/// <c>NULL</c>, the local computer is used.
	/// </para>
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>101</term>
	/// <term>Specifies the server name, type, and associated software. The buf parameter points to a SERVER_INFO_101 structure.</term>
	/// </item>
	/// <item>
	/// <term>102</term>
	/// <term>
	/// Specifies the server name, type, associated software, and other attributes. The buf parameter points to a SERVER_INFO_102 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>402</term>
	/// <term>Specifies detailed information about the server. The buf parameter points to a SERVER_INFO_402 structure.</term>
	/// </item>
	/// <item>
	/// <term>403</term>
	/// <term>Specifies detailed information about the server. The buf parameter points to a SERVER_INFO_403 structure.</term>
	/// </item>
	/// </list>
	/// <para>
	/// In addition, levels 1001-1006, 1009-1011, 1016-1018, 1021, 1022, 1028, 1029, 1037, and 1043 are valid based on the restrictions
	/// for LAN Manager systems.
	/// </para>
	/// </param>
	/// <param name="buf">
	/// <para>
	/// Pointer to a buffer that receives the server information. The format of this data depends on the value of the level parameter.
	/// For more information, see Network Management Function Buffers.
	/// </para>
	/// </param>
	/// <param name="ParmError">
	/// <para>
	/// Pointer to a value that receives the index of the first member of the server information structure that causes the
	/// ERROR_INVALID_PARAMETER error. If this parameter is <c>NULL</c>, the index is not returned on error. For more information, see
	/// the following Remarks section.
	/// </para>
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
	/// <term>The value specified for the level parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is invalid. For more information, see the following Remarks section.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerSetInfo</c> function.
	/// </para>
	/// <para>
	/// If you are programming for Active Directory, you may be able to call certain Active Directory Service Interface (ADSI) methods to
	/// achieve the same functionality you can achieve by calling the network management server functions. For more information, see IADsComputer.
	/// </para>
	/// <para>
	/// If the <c>NetServerSetInfo</c> function returns ERROR_INVALID_PARAMETER, you can use the ParmError parameter to indicate the
	/// first member of the server information structure that is invalid. (A server information structure begins with SERVER_INFO_ and
	/// its format is specified by the level parameter.) The following table lists the values that can be returned in the ParmError
	/// parameter and the corresponding structure member that is in error. (The prefix sv*_ indicates that the member can begin with
	/// multiple prefixes, for example, sv101_ or sv402_.)
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Member</term>
	/// </listheader>
	/// <item>
	/// <term>SV_PLATFORM_ID_PARMNUM</term>
	/// <term>sv*_platform_id</term>
	/// </item>
	/// <item>
	/// <term>SV_NAME_PARMNUM</term>
	/// <term>sv*_name</term>
	/// </item>
	/// <item>
	/// <term>SV_VERSION_MAJOR_PARMNUM</term>
	/// <term>sv*_version_major</term>
	/// </item>
	/// <item>
	/// <term>SV_VERSION_MINOR_PARMNUM</term>
	/// <term>sv*_version_minor</term>
	/// </item>
	/// <item>
	/// <term>SV_TYPE_PARMNUM</term>
	/// <term>sv*_type</term>
	/// </item>
	/// <item>
	/// <term>SV_COMMENT_PARMNUM</term>
	/// <term>sv*_comment</term>
	/// </item>
	/// <item>
	/// <term>SV_USERS_PARMNUM</term>
	/// <term>sv*_users</term>
	/// </item>
	/// <item>
	/// <term>SV_DISC_PARMNUM</term>
	/// <term>sv*_disc</term>
	/// </item>
	/// <item>
	/// <term>SV_HIDDEN_PARMNUM</term>
	/// <term>sv*_hidden</term>
	/// </item>
	/// <item>
	/// <term>SV_ANNOUNCE_PARMNUM</term>
	/// <term>sv*_announce</term>
	/// </item>
	/// <item>
	/// <term>SV_ANNDELTA_PARMNUM</term>
	/// <term>sv*_anndelta</term>
	/// </item>
	/// <item>
	/// <term>SV_USERPATH_PARMNUM</term>
	/// <term>sv*_userpath</term>
	/// </item>
	/// <item>
	/// <term>SV_ULIST_MTIME_PARMNUM</term>
	/// <term>sv*_ulist_mtime</term>
	/// </item>
	/// <item>
	/// <term>SV_GLIST_MTIME_PARMNUM</term>
	/// <term>sv*_glist_mtime</term>
	/// </item>
	/// <item>
	/// <term>SV_ALIST_MTIME_PARMNUM</term>
	/// <term>sv*_alist_mtime</term>
	/// </item>
	/// <item>
	/// <term>SV_ALERTS_PARMNUM</term>
	/// <term>sv*_alerts</term>
	/// </item>
	/// <item>
	/// <term>SV_SECURITY_PARMNUM</term>
	/// <term>sv*_security</term>
	/// </item>
	/// <item>
	/// <term>SV_NUMADMIN_PARMNUM</term>
	/// <term>sv*_numadmin</term>
	/// </item>
	/// <item>
	/// <term>SV_LANMASK_PARMNUM</term>
	/// <term>sv*_lanmask</term>
	/// </item>
	/// <item>
	/// <term>SV_GUESTACC_PARMNUM</term>
	/// <term>sv*_guestacc</term>
	/// </item>
	/// <item>
	/// <term>SV_CHDEVQ_PARMNUM</term>
	/// <term>sv*_chdevq</term>
	/// </item>
	/// <item>
	/// <term>SV_CHDEVJOBS_PARMNUM</term>
	/// <term>sv*_chdevjobs</term>
	/// </item>
	/// <item>
	/// <term>SV_CONNECTIONS_PARMNUM</term>
	/// <term>sv*_connections</term>
	/// </item>
	/// <item>
	/// <term>SV_SHARES_PARMNUM</term>
	/// <term>sv*_shares</term>
	/// </item>
	/// <item>
	/// <term>SV_OPENFILES_PARMNUM</term>
	/// <term>sv*_openfiles</term>
	/// </item>
	/// <item>
	/// <term>SV_SESSOPENS_PARMNUM</term>
	/// <term>sv*_sessopens</term>
	/// </item>
	/// <item>
	/// <term>SV_SESSVCS_PARMNUM</term>
	/// <term>sv*_sessvcs</term>
	/// </item>
	/// <item>
	/// <term>SV_SESSREQS_PARMNUM</term>
	/// <term>sv*_sessreqs</term>
	/// </item>
	/// <item>
	/// <term>SV_OPENSEARCH_PARMNUM</term>
	/// <term>sv*_opensearch</term>
	/// </item>
	/// <item>
	/// <term>SV_ACTIVELOCKS_PARMNUM</term>
	/// <term>sv*_activelocks</term>
	/// </item>
	/// <item>
	/// <term>SV_NUMREQBUF_PARMNUM</term>
	/// <term>sv*_numreqbuf</term>
	/// </item>
	/// <item>
	/// <term>SV_SIZREQBUF_PARMNUM</term>
	/// <term>sv*_sizreqbuf</term>
	/// </item>
	/// <item>
	/// <term>SV_NUMBIGBUF_PARMNUM</term>
	/// <term>sv*_numbigbuf</term>
	/// </item>
	/// <item>
	/// <term>SV_NUMFILETASKS_PARMNUM</term>
	/// <term>sv*_numfiletasks</term>
	/// </item>
	/// <item>
	/// <term>SV_ALERTSCHED_PARMNUM</term>
	/// <term>sv*_alertsched</term>
	/// </item>
	/// <item>
	/// <term>SV_ERRORALERT_PARMNUM</term>
	/// <term>sv*_erroralert</term>
	/// </item>
	/// <item>
	/// <term>SV_LOGONALERT_PARMNUM</term>
	/// <term>sv*_logonalert</term>
	/// </item>
	/// <item>
	/// <term>SV_ACCESSALERT_PARMNUM</term>
	/// <term>sv*_accessalert</term>
	/// </item>
	/// <item>
	/// <term>SV_DISKALERT_PARMNUM</term>
	/// <term>sv*_diskalert</term>
	/// </item>
	/// <item>
	/// <term>SV_NETIOALERT_PARMNUM</term>
	/// <term>sv*_netioalert</term>
	/// </item>
	/// <item>
	/// <term>SV_MAXAUDITSZ_PARMNUM</term>
	/// <term>sv*_maxauditsz</term>
	/// </item>
	/// <item>
	/// <term>SV_SRVHEURISTICS_PARMNUM</term>
	/// <term>sv*_srvheuristics</term>
	/// </item>
	/// <item>
	/// <term>SV_TIMESOURCE_PARMNUM</term>
	/// <term>sv*_timesource</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to call the <c>NetServerSetInfo</c> function. The sample calls
	/// <c>NetServerSetInfo</c>, specifying the level parameter as 1005 (required) to set the <c>sv1005_comment</c> member of the
	/// SERVER_INFO_1005 structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netserversetinfo NET_API_STATUS NET_API_FUNCTION
	// NetServerSetInfo( LMSTR servername, DWORD level, LPBYTE buf, LPDWORD ParmError );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "1a04a43d-34f9-4a08-ac66-750120792af0")]
	public static extern Win32Error NetServerSetInfo([Optional] string? servername, int level, IntPtr buf, out uint ParmError);

	/// <summary>
	/// <para>The <c>NetServerTransportAdd</c> function binds the server to the transport protocol.</para>
	/// <para>
	/// The extended function NetServerTransportAddEx allows the calling application to specify the SERVER_TRANSPORT_INFO_1,
	/// SERVER_TRANSPORT_INFO_2, and SERVER_TRANSPORT_INFO_3 information levels.
	/// </para>
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// A pointer to a string that specifies the name of the remote server on which the function is to execute. If this parameter is
	/// <c>NULL</c>, the local computer is used.
	/// </para>
	/// </param>
	/// <param name="level">
	/// <para>Specifies the information level of the data. This parameter can be the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Specifies information about the transport protocol, including name, address, and location on the network. The bufptr parameter
	/// points to a SERVER_TRANSPORT_INFO_0 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>A pointer to the buffer that contains the data.</para>
	/// <para>For more information, see Network Management Function Buffers.</para>
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
	/// <term>ERROR_DUP_NAME</term>
	/// <term>A duplicate name exists on the network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DOMAINNAME</term>
	/// <term>The domain name could not be found on the network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is invalid. This error is returned if the svti0_transportname or svti0_transportaddress member in the
	/// SERVER_TRANSPORT_INFO_0 structure pointed to by the bufptr parameter is NULL. This error is also returned if the
	/// svti0_transportaddresslength member in the SERVER_TRANSPORT_INFO_0 structure pointed to by the bufptr parameter is zero or larger
	/// than MAX_PATH (defined in the Windef.h header file). This error is also returned for other invalid parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerTransportAdd</c> function.
	/// </para>
	/// <para>
	/// If you add a transport protocol to a server using a call to the <c>NetServerTransportAdd</c> function, the connection will not
	/// remain after the server reboots or restarts.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netservertransportadd NET_API_STATUS NET_API_FUNCTION
	// NetServerTransportAdd( LMSTR servername, DWORD level, LPBYTE bufptr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "c8521aed-0762-4412-b117-c911fc77049b")]
	public static extern Win32Error NetServerTransportAdd([Optional] string? servername, int level, IntPtr bufptr);

	/// <summary>
	/// <para>
	/// The <c>NetServerTransportAddEx</c> function binds the specified server to the transport protocol. This extended function allows
	/// the calling application to specify the SERVER_TRANSPORT_INFO_0, SERVER_TRANSPORT_INFO_1, SERVER_TRANSPORT_INFO_2, or
	/// SERVER_TRANSPORT_INFO_3 information levels.
	/// </para>
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// A pointer to a string that specifies the name of the remote server on which the function is to execute. If this parameter is
	/// <c>NULL</c>, the local computer is used.
	/// </para>
	/// </param>
	/// <param name="level">
	/// <para>Specifies a value that indicates the information level of the data. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// Specifies information about the transport protocol, including name, address, and location on the network. The bufptr parameter
	/// points to a SERVER_TRANSPORT_INFO_0 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Specifies information about the transport protocol, including name, address, network location, and domain. The bufptr parameter
	/// points to a SERVER_TRANSPORT_INFO_1 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>2</term>
	/// <term>
	/// Specifies the same information as level 1, with the addition of an svti2_flags member. The bufptr parameter points to a
	/// SERVER_TRANSPORT_INFO_2 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>3</term>
	/// <term>
	/// Specifies the same information as level 2, with the addition of credential information. The bufptr parameter points to a
	/// SERVER_TRANSPORT_INFO_3 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>A pointer to the buffer that contains the data. The format of this data depends on the value of the level parameter.</para>
	/// <para>For more information, see Network Management Function Buffers.</para>
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
	/// <term>ERROR_DUP_NAME</term>
	/// <term>A duplicate name exists on the network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DOMAINNAME</term>
	/// <term>The domain name could not be found on the network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is invalid. This error is returned if the transport name or transport address member in the SERVER_TRANSPORT_INFO_0,
	/// SERVER_TRANSPORT_INFO_1, SERVER_TRANSPORT_INFO_2, or SERVER_TRANSPORT_INFO_3 structure pointed to by the bufptr parameter is
	/// NULL. This error is also returned if the transport address length member in the SERVER_TRANSPORT_INFO_0, SERVER_TRANSPORT_INFO_1,
	/// SERVER_TRANSPORT_INFO_2, or SERVER_TRANSPORT_INFO_3 structure pointed to by the bufptr parameter is zero or larger than MAX_PATH
	/// (defined in the Windef.h header file). This error is also returned if the flags member of the SERVER_TRANSPORT_INFO_2, or
	/// SERVER_TRANSPORT_INFO_3 structure pointed to by the bufptr parameter contains an illegal value. This error is also returned for
	/// other invalid parameters.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>Insufficient memory is available.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerTransportAddEx</c> function.
	/// </para>
	/// <para>
	/// If you add a transport protocol to a server using a call to the <c>NetServerTransportAddEx</c> function, the connection will not
	/// remain after the server reboots or restarts.
	/// </para>
	/// <para>
	/// The NetServerComputerNameAdd function is a utility function. It combines the features of the NetServerTransportEnum function and
	/// the <c>NetServerTransportAddEx</c> function, allowing you to specify an emulated server name.
	/// </para>
	/// <para>
	/// On Windows Server 2008 and Windows Vista with Service Pack 1 (SP1), every name registered with the Windows remote file server
	/// (SRV) is designated as either a scoped name or a non-scoped name. Every share that is added to the system will then either be
	/// attached to all of the non-scoped names, or to a single scoped name. Applications that wish to use the scoping features are
	/// responsible for both registering the new name as a scoped endpoint and then creating the shares with an appropriate scope. In
	/// this way, legacy uses of the Network Management and Network Share Management functions are not affected in any way since they
	/// continue to register shares and names as non-scoped names.
	/// </para>
	/// <para>
	/// A scoped endpoint is created by calling the <c>NetServerTransportAddEx</c> function with the level parameter set to 2 and the
	/// bufptr parameter pointed to a SERVER_TRANSPORT_INFO_2 structure with the <c>SVTI2_SCOPED_NAME</c> bit value set in
	/// <c>svti2_flags</c> member. A scoped endpoint is also created by calling the <c>NetServerTransportAddEx</c> function with the
	/// level parameter set to 3 and the bufptr parameter pointed to a SERVER_TRANSPORT_INFO_3 structure with the
	/// <c>SVTI2_SCOPED_NAME</c> bit value set in <c>svti3_flags</c> member.
	/// </para>
	/// <para>
	/// When the <c>SVTI2_SCOPED_NAME</c> bit value is set for a transport, then shares can be added with a corresponding server name
	/// (the <c>shi503_servername</c> member of the SHARE_INFO_503 structure) in a scoped fashion using the NetShareAdd function. If
	/// there is no transport registered with the <c>SVTI2_SCOPED_NAME</c> bit value and the name provided in <c>shi503_servername</c>
	/// member, then the share add in a scoped fashion will not succeed.
	/// </para>
	/// <para>
	/// The NetShareAdd function is used to add a scoped share on a remote server specified in the servername parameter. The remote
	/// server specified in the <c>shi503_servername</c> member of the SHARE_INFO_503 passed in the bufptr parameter must have been bound
	/// to a transport protocol using the <c>NetServerTransportAddEx</c> function as a scoped endpoint. The <c>SVTI2_SCOPED_NAME</c> flag
	/// must have been specified in the <c>shi503_servername</c> member of the SERVER_TRANSPORT_INFO_2 or SERVER_TRANSPORT_INFO_3
	/// structure for the transport protocol. The NetShareDelEx function is used to delete a scoped share. The NetShareGetInfo and
	/// NetShareSetInfo functions are to used to get and set information on a scoped share.
	/// </para>
	/// <para>Scoped endpoints are generally used by the cluster namespace.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netservertransportaddex NET_API_STATUS NET_API_FUNCTION
	// NetServerTransportAddEx( LMSTR servername, DWORD level, LPBYTE bufptr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "d1edc75d-8313-422c-a6fb-8b51a309a252")]
	public static extern Win32Error NetServerTransportAddEx([Optional] string? servername, int level, IntPtr bufptr);

	/// <summary>
	/// <para>
	/// The <c>NetServerTransportDel</c> function unbinds (or disconnects) the transport protocol from the server. Effectively, the
	/// server can no longer communicate with clients using the specified transport protocol (such as TCP or XNS).
	/// </para>
	/// </summary>
	/// <param name="servername">
	/// <para>
	/// Pointer to a string that specifies the DNS or NetBIOS name of the remote server on which the function is to execute. If this
	/// parameter is <c>NULL</c>, the local computer is used.
	/// </para>
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
	/// Specifies information about the transport protocol, including name, address, and location on the network. The bufptr parameter
	/// points to a SERVER_TRANSPORT_INFO_0 structure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Specifies information about the transport protocol, including name, address, network location, and domain. The bufptr parameter
	/// points to a SERVER_TRANSPORT_INFO_1 structure.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// <para>
	/// Pointer to the buffer that specifies the data. The format of this data depends on the value of the level parameter. For more
	/// information, see Network Management Function Buffers.
	/// </para>
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
	/// <term>The value specified for the level parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The specified parameter is invalid.</term>
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
	/// Only members of the Administrators or Server Operators local group can successfully execute the <c>NetServerTransportDel</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netservertransportdel NET_API_STATUS NET_API_FUNCTION
	// NetServerTransportDel( LMSTR servername, DWORD level, LPBYTE bufptr );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "69b22f30-62b1-4dcb-bbb0-aceae8d77f61")]
	public static extern Win32Error NetServerTransportDel([Optional] string? servername, int level, IntPtr bufptr);

	/// <summary>
	/// The <c>NetServerTransportEnum</c> function supplies information about transport protocols that are managed by the server.
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
	/// <term>
	/// Return information about the transport protocol, including name, address, and location on the network. The bufptr parameter
	/// points to an array of SERVER_TRANSPORT_INFO_0 structures.
	/// </term>
	/// </item>
	/// <item>
	/// <term>1</term>
	/// <term>
	/// Return information about the transport protocol, including name, address, network location, and domain. The bufptr parameter
	/// points to an array of SERVER_TRANSPORT_INFO_1 structures.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bufptr">
	/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is
	/// allocated by the system and must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the
	/// function fails with ERROR_MORE_DATA.
	/// </param>
	/// <param name="prefmaxlen">
	/// Specifies the preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates
	/// the amount of memory required for the data. If you specify another value in this parameter, it can restrict the number of bytes
	/// that the function returns. If the buffer size is insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more
	/// information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <param name="entriesread">Pointer to a value that receives the count of elements actually enumerated.</param>
	/// <param name="totalentries">
	/// Pointer to a value that receives the total number of entries that could have been enumerated from the current resume position.
	/// Note that applications should consider this value only as a hint.
	/// </param>
	/// <param name="resume_handle">The resume handle.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_LEVEL</term>
	/// <term>The value specified for the level parameter is invalid.</term>
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
	/// <para>
	/// Only Authenticated Users can successfully call this function. <c>Windows XP/2000:</c> No special group membership is required to
	/// successfully execute this function.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to retrieve information about transport protocols that are managed by the server,
	/// using a call to the <c>NetServerTransportEnum</c> function. The sample calls <c>NetServerTransportEnum</c>, specifying
	/// information level 0 ( SERVER_TRANSPORT_INFO_0). The sample prints the name of each transport protocol and the total number
	/// enumerated. Finally, the code sample frees the memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/nf-lmserver-netservertransportenum NET_API_STATUS NET_API_FUNCTION
	// NetServerTransportEnum( LMSTR servername, DWORD level, LPBYTE *bufptr, DWORD prefmaxlen, LPDWORD entriesread, LPDWORD
	// totalentries, LPDWORD resume_handle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmserver.h", MSDNShortId = "db42ac44-d70d-4b89-882a-6ac83fd611fd")]
	public static extern Win32Error NetServerTransportEnum([Optional] string? servername, int level, out SafeNetApiBuffer bufptr, uint prefmaxlen, out uint entriesread, out uint totalentries, ref uint resume_handle);

	/// <summary>The <c>SERVER_INFO_100</c> structure contains information about the specified server, including the name and platform.</summary>
	/// <seealso cref="INetServerInfo"/>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("lmserver.h", MSDNShortId = "aa370897")]
	public struct SERVER_INFO_100 : INetServerInfo
	{
		/// <summary>The information level to use for platform-specific information.</summary>
		public ServerPlatform sv100_platform_id;

		/// <summary>A pointer to a Unicode string that specifies the name of the server.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string sv100_name;
	}

	/// <summary>
	/// The <c>SERVER_INFO_101</c> structure contains information about the specified server, including name, platform, type of server,
	/// and associated software.
	/// </summary>
	/// <seealso cref="INetServerInfo"/>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("lmserver.h", MSDNShortId = "aa370903")]
	public struct SERVER_INFO_101 : INetServerInfo
	{
		/// <summary>The information level to use for platform-specific information.</summary>
		public ServerPlatform sv101_platform_id;

		/// <summary>A pointer to a Unicode string specifying the name of a server.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string sv101_name;

		/// <summary>
		/// The major version number and the server type.
		/// <para>
		/// The major release version number of the operating system is specified in the least significant 4 bits. The server type is
		/// specified in the most significant 4 bits. The <c>MAJOR_VERSION_MASK</c> bitmask defined in the Lmserver.h header should be
		/// used by an application to obtain the major version number from this member.
		/// </para>
		/// </summary>
		public int sv101_version_major;

		/// <summary>The minor release version number of the operating system.</summary>
		public int sv101_version_minor;

		/// <summary>The type of software the computer is running.</summary>
		public NetServerEnumFilter sv101_type;

		/// <summary>A pointer to a Unicode string specifying a comment describing the server. The comment can be null.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? sv101_comment;

		/// <summary>Gets the version composed of both <see cref="sv101_version_major"/> and <see cref="sv101_version_minor"/>.</summary>
		/// <value>The version.</value>
		public readonly Version Version => new(sv101_version_major, sv101_version_minor);
	}

	/// <summary>
	/// The SERVER_INFO_102 structure contains information about the specified server, including name, platform, type of server,
	/// attributes, and associated software.
	/// </summary>
	/// <seealso cref="INetServerInfo"/>
	[StructLayout(LayoutKind.Sequential)]
	[PInvokeData("lmserver.h", MSDNShortId = "aa370904")]
	public struct SERVER_INFO_102 : INetServerInfo
	{
		/// <summary>The information level to use for platform-specific information.</summary>
		public ServerPlatform sv102_platform_id;

		/// <summary>A pointer to a Unicode string specifying the name of a server.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string sv102_name;

		/// <summary>
		/// The major version number and the server type.
		/// <para>
		/// The major release version number of the operating system is specified in the least significant 4 bits. The server type is
		/// specified in the most significant 4 bits. The <c>MAJOR_VERSION_MASK</c> bitmask defined in the Lmserver.h header should be
		/// used by an application to obtain the major version number from this member.
		/// </para>
		/// </summary>
		public int sv102_version_major;

		/// <summary>The minor release version number of the operating system.</summary>
		public int sv102_version_minor;

		/// <summary>The type of software the computer is running.</summary>
		public NetServerEnumFilter sv102_type;

		/// <summary>A pointer to a Unicode string specifying a comment describing the server. The comment can be null.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string? sv102_comment;

		/// <summary>
		/// The number of users who can attempt to log on to the system server. Note that it is the license server that determines how
		/// many of these users can actually log on.
		/// </summary>
		public int sv102_users;

		/// <summary>
		/// The auto-disconnect time, in minutes. A session is disconnected if it is idle longer than the period of time specified by the
		/// sv102_disc member. If the value of sv102_disc is SV_NODISC, auto-disconnect is not enabled.
		/// </summary>
		public int sv102_disc;

		/// <summary>A value that indicates whether the server is visible to other computers in the same network domain.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool sv102_hidden;

		/// <summary>
		/// The network announce rate, in seconds. This rate determines how often the server is announced to other computers on the network.
		/// </summary>
		public int sv102_announce;

		/// <summary>
		/// The delta value for the announce rate, in milliseconds. This value specifies how much the announce rate can vary from the
		/// period of time specified in the sv102_announce member.
		/// <para>
		/// The delta value allows randomly varied announce rates. For example, if the sv102_announce member has the value 10 and the
		/// sv102_anndelta member has the value 1, the announce rate can vary from 9.999 seconds to 10.001 seconds.
		/// </para>
		/// </summary>
		public int sv102_anndelta;

		/// <summary>The number of users per license. By default, this number is SV_USERS_PER_LICENSE.</summary>
		public int sv102_licenses;

		/// <summary>A pointer to a Unicode string specifying the path to user directories.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string sv102_userpath;

		/// <summary>Gets the version composed of both <see cref="sv102_version_major"/> and <see cref="sv102_version_minor"/>.</summary>
		/// <value>The version.</value>
		public readonly Version Version => new(sv102_version_major, sv102_version_minor);
	}

	/// <summary>
	/// <para>The <c>SERVER_INFO_402</c> structure contains information about a specified server.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/ns-lmserver-_server_info_402 typedef struct _SERVER_INFO_402 { DWORD
	// sv402_ulist_mtime; DWORD sv402_glist_mtime; DWORD sv402_alist_mtime; LMSTR sv402_alerts; DWORD sv402_security; DWORD
	// sv402_numadmin; DWORD sv402_lanmask; LMSTR sv402_guestacct; DWORD sv402_chdevs; DWORD sv402_chdevq; DWORD sv402_chdevjobs; DWORD
	// sv402_connections; DWORD sv402_shares; DWORD sv402_openfiles; DWORD sv402_sessopens; DWORD sv402_sessvcs; DWORD sv402_sessreqs;
	// DWORD sv402_opensearch; DWORD sv402_activelocks; DWORD sv402_numreqbuf; DWORD sv402_sizreqbuf; DWORD sv402_numbigbuf; DWORD
	// sv402_numfiletasks; DWORD sv402_alertsched; DWORD sv402_erroralert; DWORD sv402_logonalert; DWORD sv402_accessalert; DWORD
	// sv402_diskalert; DWORD sv402_netioalert; DWORD sv402_maxauditsz; LMSTR sv402_srvheuristics; } SERVER_INFO_402, *PSERVER_INFO_402, *LPSERVER_INFO_402;
	[PInvokeData("lmserver.h", MSDNShortId = "51e5c27e-6a7d-45ac-9cfa-37b1f7f241f9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SERVER_INFO_402 : INetServerInfo
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The last time the user list was modified. The value is expressed as the number of seconds that have elapsed since 00:00:00,
		/// January 1, 1970, GMT, and applies to servers running with user-level security.
		/// </para>
		/// </summary>
		public uint sv402_ulist_mtime;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The last time the group list was modified. The value is expressed as the number of seconds that have elapsed since 00:00:00,
		/// January 1, 1970, GMT, and applies to servers running with user-level security.
		/// </para>
		/// </summary>
		public uint sv402_glist_mtime;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The last time the access control list was modified. The value is expressed as the number of seconds that have elapsed since
		/// 00:00:00, January 1, 1970, GMT, and applies to servers running with user-level security.
		/// </para>
		/// </summary>
		public uint sv402_alist_mtime;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A pointer to a Unicode string that specifies the list of user names on the server. Spaces separate the names.</para>
		/// </summary>
		public string sv402_alerts;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The security type of the server. This member can be one of the following values. Note that Windows NT, Windows 2000, Windows
		/// XP, and Windows Server 2003 operating systems do not support share-level security.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SV_SHARESECURITY</term>
		/// <term>Share-level security</term>
		/// </item>
		/// <item>
		/// <term>SV_USERSECURITY</term>
		/// <term>User-level security</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint sv402_security;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of administrators the server can accommodate at one time.</para>
		/// </summary>
		public uint sv402_numadmin;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The order in which the network device drivers are served.</para>
		/// </summary>
		public uint sv402_lanmask;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>
		/// A pointer to a Unicode string that specifies the name of a reserved account for guest users on the server. The constant UNLEN
		/// specifies the maximum number of characters in the string.
		/// </para>
		/// </summary>
		public string sv402_guestacct;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of character-oriented devices that can be shared on the server.</para>
		/// </summary>
		public uint sv402_chdevs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of character-oriented device queues that can coexist on the server.</para>
		/// </summary>
		public uint sv402_chdevq;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of character-oriented device jobs that can be pending at one time on the server.</para>
		/// </summary>
		public uint sv402_chdevjobs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of connections allowed on the server.</para>
		/// </summary>
		public uint sv402_connections;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of share names the server can accommodate.</para>
		/// </summary>
		public uint sv402_shares;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of files that can be open at once on the server.</para>
		/// </summary>
		public uint sv402_openfiles;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of files that one session can open.</para>
		/// </summary>
		public uint sv402_sessopens;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The maximum number of virtual circuits permitted per client.</para>
		/// </summary>
		public uint sv402_sessvcs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of simultaneous requests a client can make on a single virtual circuit.</para>
		/// </summary>
		public uint sv402_sessreqs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of search operations that can be carried out simultaneously.</para>
		/// </summary>
		public uint sv402_opensearch;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of file locks that can be active at the same time.</para>
		/// </summary>
		public uint sv402_activelocks;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of server buffers provided.</para>
		/// </summary>
		public uint sv402_numreqbuf;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of each server buffer.</para>
		/// </summary>
		public uint sv402_sizreqbuf;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of 64K server buffers provided.</para>
		/// </summary>
		public uint sv402_numbigbuf;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of processes that can access the operating system at one time.</para>
		/// </summary>
		public uint sv402_numfiletasks;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The interval, in seconds, for notifying an administrator of a network event.</para>
		/// </summary>
		public uint sv402_alertsched;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of entries that can be written to the error log, in any one interval, before notifying an administrator. The
		/// interval is specified by the <c>sv402_alertsched</c> member.
		/// </para>
		/// </summary>
		public uint sv402_erroralert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of invalid logon attempts to allow a user before notifying an administrator.</para>
		/// </summary>
		public uint sv402_logonalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of invalid file access attempts to allow before notifying an administrator.</para>
		/// </summary>
		public uint sv402_accessalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The point at which the system sends a message notifying an administrator that free space on a disk is low. This value is
		/// expressed as the number of kilobytes of free disk space remaining on the disk.
		/// </para>
		/// </summary>
		public uint sv402_diskalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The network I/O error ratio, in tenths of a percent, that is allowed before notifying an administrator.</para>
		/// </summary>
		public uint sv402_netioalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The maximum size, in kilobytes, of the audit file. The audit file traces user activity.</para>
		/// </summary>
		public uint sv402_maxauditsz;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A pointer to a Unicode string containing flags that control operations on a server.</para>
		/// </summary>
		public string sv402_srvheuristics;
	}

	/// <summary>
	/// <para>The <c>SERVER_INFO_403</c> structure contains information about a specified server.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/ns-lmserver-_server_info_403 typedef struct _SERVER_INFO_403 { DWORD
	// sv403_ulist_mtime; DWORD sv403_glist_mtime; DWORD sv403_alist_mtime; LMSTR sv403_alerts; DWORD sv403_security; DWORD
	// sv403_numadmin; DWORD sv403_lanmask; LMSTR sv403_guestacct; DWORD sv403_chdevs; DWORD sv403_chdevq; DWORD sv403_chdevjobs; DWORD
	// sv403_connections; DWORD sv403_shares; DWORD sv403_openfiles; DWORD sv403_sessopens; DWORD sv403_sessvcs; DWORD sv403_sessreqs;
	// DWORD sv403_opensearch; DWORD sv403_activelocks; DWORD sv403_numreqbuf; DWORD sv403_sizreqbuf; DWORD sv403_numbigbuf; DWORD
	// sv403_numfiletasks; DWORD sv403_alertsched; DWORD sv403_erroralert; DWORD sv403_logonalert; DWORD sv403_accessalert; DWORD
	// sv403_diskalert; DWORD sv403_netioalert; DWORD sv403_maxauditsz; LMSTR sv403_srvheuristics; DWORD sv403_auditedevents; DWORD
	// sv403_autoprofile; LMSTR sv403_autopath; } SERVER_INFO_403, *PSERVER_INFO_403, *LPSERVER_INFO_403;
	[PInvokeData("lmserver.h", MSDNShortId = "14309dbe-ad7b-4ae0-8acc-39e9999f411b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SERVER_INFO_403 : INetServerInfo
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The last time the user list was modified. The value is expressed as the number of seconds that have elapsed since 00:00:00,
		/// January 1, 1970, GMT, and applies to servers running with user-level security.
		/// </para>
		/// </summary>
		public uint sv403_ulist_mtime;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The last time the group list was modified. The value is expressed as the number of seconds that have elapsed since 00:00:00,
		/// January 1, 1970, GMT, and applies to servers running with user-level security.
		/// </para>
		/// </summary>
		public uint sv403_glist_mtime;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The last time the access control list was modified. The value is expressed as the number of seconds that have elapsed since
		/// 00:00:00, January 1, 1970, GMT, and applies to servers running with user-level security.
		/// </para>
		/// </summary>
		public uint sv403_alist_mtime;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A pointer to a Unicode string that specifies the list of user names on the server. Spaces separate the names.</para>
		/// </summary>
		public string sv403_alerts;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The security type of the server. This member can be one of the following values. Note that Windows NT, Windows 2000, Windows
		/// XP, and Windows Server 2003 operating systems do not support share-level security.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SV_SHARESECURITY</term>
		/// <term>Share-level security</term>
		/// </item>
		/// <item>
		/// <term>SV_USERSECURITY</term>
		/// <term>User-level security</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint sv403_security;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of administrators the server can accommodate at one time.</para>
		/// </summary>
		public uint sv403_numadmin;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The order in which the network device drivers are served.</para>
		/// </summary>
		public uint sv403_lanmask;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>
		/// A pointer to a Unicode string that specifies the name of a reserved account for guest users on the server. The constant UNLEN
		/// specifies the maximum number of characters in the string.
		/// </para>
		/// </summary>
		public string sv403_guestacct;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of character-oriented devices that can be shared on the server.</para>
		/// </summary>
		public uint sv403_chdevs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of character-oriented device queues that can coexist on the server.</para>
		/// </summary>
		public uint sv403_chdevq;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of character-oriented device jobs that can be pending at one time on the server.</para>
		/// </summary>
		public uint sv403_chdevjobs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of connections allowed on the server.</para>
		/// </summary>
		public uint sv403_connections;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of share names the server can accommodate.</para>
		/// </summary>
		public uint sv403_shares;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of files that can be open at once on the server.</para>
		/// </summary>
		public uint sv403_openfiles;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of files that one session can open.</para>
		/// </summary>
		public uint sv403_sessopens;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The maximum number of virtual circuits permitted per client.</para>
		/// </summary>
		public uint sv403_sessvcs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of simultaneous requests a client can make on a single virtual circuit.</para>
		/// </summary>
		public uint sv403_sessreqs;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of search operations that can be carried out simultaneously.</para>
		/// </summary>
		public uint sv403_opensearch;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of file locks that can be active at the same time.</para>
		/// </summary>
		public uint sv403_activelocks;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of server buffers provided.</para>
		/// </summary>
		public uint sv403_numreqbuf;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of each server buffer.</para>
		/// </summary>
		public uint sv403_sizreqbuf;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of 64K server buffers provided.</para>
		/// </summary>
		public uint sv403_numbigbuf;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of processes that can access the operating system at one time.</para>
		/// </summary>
		public uint sv403_numfiletasks;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The interval, in seconds, for notifying an administrator of a network event.</para>
		/// </summary>
		public uint sv403_alertsched;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of entries that can be written to the error log, in any one interval, before notifying an administrator. The
		/// interval is specified by the <c>sv403_alertsched</c> member.
		/// </para>
		/// </summary>
		public uint sv403_erroralert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of invalid logon attempts to allow a user before notifying an administrator.</para>
		/// </summary>
		public uint sv403_logonalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of invalid file access attempts to allow before notifying an administrator.</para>
		/// </summary>
		public uint sv403_accessalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The point at which the system sends a message notifying an administrator that free space on a disk is low. This value is
		/// expressed as the number of kilobytes of free disk space remaining on the disk.
		/// </para>
		/// </summary>
		public uint sv403_diskalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The network I/O error ratio, in tenths of a percent, that is allowed before notifying an administrator.</para>
		/// </summary>
		public uint sv403_netioalert;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The maximum size, in kilobytes, of the audit file. The audit file traces user activity.</para>
		/// </summary>
		public uint sv403_maxauditsz;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A pointer to a Unicode string containing flags that control operations on a server.</para>
		/// </summary>
		public string sv403_srvheuristics;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The audit event control mask.</para>
		/// </summary>
		public uint sv403_auditedevents;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A value that controls the action of the server on the profile. The following values are predefined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SW_AUTOPROF_LOAD_MASK</term>
		/// <term>The server loads the profile.</term>
		/// </item>
		/// <item>
		/// <term>SW_AUTOPROF_SAVE_MASK</term>
		/// <term>The server saves the profile.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint sv403_autoprofile;

		/// <summary>
		/// <para>Type: <c>StrPtrUni</c></para>
		/// <para>A pointer to a Unicode string that contains the path for the profile.</para>
		/// </summary>
		public string sv403_autopath;
	}

	/// <summary>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_0</c> structure contains information about the specified transport protocol, including name,
	/// address, and location on the network.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_0</c> structure is used by the NetServerTransportAdd or NetServerTransportAddEx function to bind the
	/// specified server to the transport protocol.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/ns-lmserver-_server_transport_info_0 typedef struct
	// _SERVER_TRANSPORT_INFO_0 { DWORD svti0_numberofvcs; LMSTR svti0_transportname; LPBYTE svti0_transportaddress; DWORD
	// svti0_transportaddresslength; LMSTR svti0_networkaddress; } SERVER_TRANSPORT_INFO_0, *PSERVER_TRANSPORT_INFO_0, *LPSERVER_TRANSPORT_INFO_0;
	[PInvokeData("lmserver.h", MSDNShortId = "5b94cf7a-74d1-4ae8-87bd-22b2daf292cb")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SERVER_TRANSPORT_INFO_0
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of clients connected to the server that are using the transport protocol specified by the
		/// <c>svti0_transportname</c> member.
		/// </para>
		/// </summary>
		public uint svti0_numberofvcs;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a null-terminated character string that contains the name of a transport device; for example,</para>
		/// <para>
		/// <code>
		/// \Device\NetBT_Tcpip_{2C9725F4-151A-11D3-AEEC-C3B211BD350B
		/// </code>
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti0_transportname;

		/// <summary>
		/// <para>Type: <c>LPBYTE</c></para>
		/// <para>
		/// A pointer to a variable that contains the address the server is using on the transport device specified by the
		/// <c>svti0_transportname</c> member.
		/// </para>
		/// <para>
		/// This member is usually the NetBIOS name that the server is using. In these instances, the name must be 16 characters long,
		/// and the last character must be a blank character (0x20).
		/// </para>
		/// </summary>
		public IntPtr svti0_transportaddress;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The length, in bytes, of the <c>svti0_transportaddress</c> member. For NetBIOS names, the value of this member is 16 (decimal).
		/// </para>
		/// </summary>
		public uint svti0_transportaddresslength;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a NULL-terminated character string that contains the address the network adapter is using. The string is transport-specific.
		/// </para>
		/// <para>
		/// You can retrieve this value only with a call to the NetServerTransportEnum function. You cannot set this value with a call to
		/// the NetServerTransportAdd function or the NetServerTransportAddEx function.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti0_networkaddress;
	}

	/// <summary>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_1</c> structure contains information about the specified transport protocol, including name and
	/// address. This information level is valid only for the NetServerTransportAddEx function.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_1</c> structure is used by the NetServerTransportAddEx function to bind the specified server to the
	/// transport protocol.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/ns-lmserver-_server_transport_info_1 typedef struct
	// _SERVER_TRANSPORT_INFO_1 { DWORD svti1_numberofvcs; LMSTR svti1_transportname; LPBYTE svti1_transportaddress; DWORD
	// svti1_transportaddresslength; LMSTR svti1_networkaddress; LMSTR svti1_domain; } SERVER_TRANSPORT_INFO_1,
	// *PSERVER_TRANSPORT_INFO_1, *LPSERVER_TRANSPORT_INFO_1;
	[PInvokeData("lmserver.h", MSDNShortId = "f21fed49-207a-4f64-becd-3d3c1e995eb0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SERVER_TRANSPORT_INFO_1
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of clients connected to the server that are using the transport protocol specified by the
		/// <c>svti1_transportname</c> member.
		/// </para>
		/// </summary>
		public uint svti1_numberofvcs;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a null-terminated character string that contains the name of a transport device; for example,</para>
		/// <para>
		/// <code>
		/// \Device\NetBT_Tcpip_{2C9725F4-151A-11D3-AEEC-C3B211BD350B
		/// </code>
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti1_transportname;

		/// <summary>
		/// <para>Type: <c>LPBYTE</c></para>
		/// <para>
		/// A pointer to a variable that contains the address the server is using on the transport device specified by the
		/// <c>svti1_transportname</c> member.
		/// </para>
		/// <para>
		/// This member is usually the NetBIOS name that the server is using. In these instances, the name must be 16 characters long,
		/// and the last character must be a blank character (0x20).
		/// </para>
		/// </summary>
		public IntPtr svti1_transportaddress;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The length, in bytes, of the <c>svti1_transportaddress</c> member. For NetBIOS names, the value of this member is 16 (decimal).
		/// </para>
		/// </summary>
		public uint svti1_transportaddresslength;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a NULL-terminated character string that contains the address the network adapter is using. The string is transport-specific.
		/// </para>
		/// <para>
		/// You can retrieve this value only with a call to the NetServerTransportEnum function. You cannot set this value with a call to
		/// the NetServerTransportAdd function or the NetServerTransportAddEx function.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti1_networkaddress;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a NULL-terminated character string that contains the name of the domain to which the server should announce its
		/// presence. (When you call NetServerTransportEnum, this member is the name of the domain to which the server is announcing its presence.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti1_domain;
	}

	/// <summary>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_2</c> structure contains information about the specified transport protocol, including the transport
	/// name and address. This information level is valid only for the NetServerTransportAddEx function.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_2</c> structure is used by the NetServerTransportAddEx function to bind the specified server to the
	/// transport protocol.
	/// </para>
	/// <para>
	/// An example of the use of the SVTI2_REMAP_PIPE_NAMES value follows. Call the NetServerTransportAddEx function to add a transport
	/// to the server, specifying the address of "MyServer" in the <c>svti2_transportaddress</c> member, and
	/// <c>SVTI2_REMAP_PIPE_NAMES</c> in the <c>svti2_flags</c> member. When a client attempts to open "Pipe" on "\MyServer" the client
	/// will actually open $$MyServer\Pipe instead.
	/// </para>
	/// <para>
	/// On Windows Server 2008 and Windows Vista with SP1, every name registered with the Windows remote file server (SRV) is designated
	/// as either a scoped name or a non-scoped name. Every share that is added to the system will then either be attached to all of the
	/// non-scoped names, or to a single scoped name. Applications that wish to use the scoping features are responsible for both
	/// registering the new name as a scoped endpoint and then creating the shares with an appropriate scope. In this way, legacy uses of
	/// the Network Management and Network Share Management functions are not affected in any way since they continue to register shares
	/// and names as non-scoped names.
	/// </para>
	/// <para>
	/// A scoped endpoint is created by calling the NetServerTransportAddEx function with the level parameter set to 2 and the bufptr
	/// parameter pointed to a <c>SERVER_TRANSPORT_INFO_2</c> structure with the <c>SVTI2_SCOPED_NAME</c> bit value set in
	/// <c>svti2_flags</c> member. A scoped endpoint is also created by calling the <c>NetServerTransportAddEx</c> function with the
	/// level parameter set to 3 and the bufptr parameter pointed to a SERVER_TRANSPORT_INFO_3 structure with the
	/// <c>SVTI2_SCOPED_NAME</c> bit value set in <c>svti3_flags</c> member.
	/// </para>
	/// <para>
	/// When the <c>SVTI2_SCOPED_NAME</c> bit value is set for a transport, then shares can be added with a corresponding server name
	/// (the <c>shi503_servername</c> member of the SHARE_INFO_503 structure) in a scoped fashion using the NetShareAdd function. If
	/// there is no transport registered with the <c>SVTI2_SCOPED_NAME</c> bit value and the name provided in <c>shi503_servername</c>
	/// member, then the share add in a scoped fashion will not succeed.
	/// </para>
	/// <para>
	/// The NetShareAdd function is used to add a scoped share on a remote server specified in the servername parameter. The remote
	/// server specified in the <c>shi503_servername</c> member of the SHARE_INFO_503 passed in the bufptr parameter must have been bound
	/// to a transport protocol using the NetServerTransportAddEx function as a scoped endpoint. The <c>SVTI2_SCOPED_NAME</c> flag must
	/// have been specified in the <c>shi503_servername</c> member of the <c>SERVER_TRANSPORT_INFO_2</c> or SERVER_TRANSPORT_INFO_3
	/// structure for the transport protocol. The NetShareDelEx function is used to delete a scoped share. The NetShareGetInfo and
	/// NetShareSetInfo functions are to used to get and set information on a scoped share.
	/// </para>
	/// <para>Scoped endpoints are generally used by the cluster namespace.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/ns-lmserver-_server_transport_info_2 typedef struct
	// _SERVER_TRANSPORT_INFO_2 { DWORD svti2_numberofvcs; LMSTR svti2_transportname; LPBYTE svti2_transportaddress; DWORD
	// svti2_transportaddresslength; LMSTR svti2_networkaddress; LMSTR svti2_domain; ULONG svti2_flags; } SERVER_TRANSPORT_INFO_2,
	// *PSERVER_TRANSPORT_INFO_2, *LPSERVER_TRANSPORT_INFO_2;
	[PInvokeData("lmserver.h", MSDNShortId = "b422eb71-1f93-432d-8283-81432edfe568")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SERVER_TRANSPORT_INFO_2
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of clients connected to the server that are using the transport protocol specified by the
		/// <c>svti2_transportname</c> member.
		/// </para>
		/// </summary>
		public uint svti2_numberofvcs;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a null-terminated character string that contains the name of a transport device; for example,</para>
		/// <para>
		/// <code>
		/// \Device\NetBT_Tcpip_{2C9725F4-151A-11D3-AEEC-C3B211BD350B
		/// </code>
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti2_transportname;

		/// <summary>
		/// <para>Type: <c>LPBYTE</c></para>
		/// <para>
		/// A pointer to a variable that contains the address the server is using on the transport device specified by the
		/// <c>svti2_transportname</c> member.
		/// </para>
		/// <para>
		/// This member is usually the NetBIOS name that the server is using. In these instances, the name must be 16 characters long,
		/// and the last character must be a blank character (0x20).
		/// </para>
		/// </summary>
		public IntPtr svti2_transportaddress;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The length, in bytes, of the <c>svti2_transportaddress</c> member. For NetBIOS names, the value of this member is 16 (decimal).
		/// </para>
		/// </summary>
		public uint svti2_transportaddresslength;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a NULL-terminated character string that contains the address the network adapter is using. The string is transport-specific.
		/// </para>
		/// <para>
		/// You can retrieve this value only with a call to the NetServerTransportEnum function. You cannot set this value with a call to
		/// the NetServerTransportAdd function or the NetServerTransportAddEx function.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti2_networkaddress;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a NULL-terminated character string that contains the name of the domain to which the server should announce its
		/// presence. (When you call NetServerTransportEnum, this member is the name of the domain to which the server is announcing its presence.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti2_domain;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>This member can be a combination of the following bit values defined in the Lmserver.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SVTI2_REMAP_PIPE_NAMES</term>
		/// <term>
		/// If this value is set for an endpoint, client requests arriving over the transport to open a named pipe are rerouted
		/// (remapped) to the following local pipe name: $$\ServerName\PipeName For more information on the use of this value, see the
		/// Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SVTI2_SCOPED_NAME</term>
		/// <term>
		/// If this value is set for an endpoint and there is an attempt to create a second transport with the same network address but a
		/// different transport name and conflicting settings for the SCOPED flag, this transport creation will fail. Thus, every
		/// registered transport for a given network address must have the same scoped setting. For more information on the use of this
		/// value, see the Remarks section. This value is defined on Windows Server 2008 and Windows Vista with SP1.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SERVER_TRANSPORT_FLAGS svti2_flags;
	}

	/// <summary>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_3</c> structure contains information about the specified transport protocol, including name, address
	/// and password (credentials). This information level is valid only for the NetServerTransportAddEx function.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>SERVER_TRANSPORT_INFO_3</c> structure is used by the NetServerTransportAddEx function to bind the specified server to the
	/// transport protocol.
	/// </para>
	/// <para>
	/// An example of the use of the SVTI2_REMAP_PIPE_NAMES value follows. Call the NetServerTransportAddEx function to add a transport
	/// to the server, specifying the address of "MyServer" in the <c>svti3_transportaddress</c> member, and
	/// <c>SVTI2_REMAP_PIPE_NAMES</c> in the <c>svti3_flags</c> member. When a client attempts to open "Pipe" on "\MyServer" the client
	/// will actually open $$MyServer\Pipe instead.
	/// </para>
	/// <para>
	/// The <c>svti3_passwordlength</c> and <c>svti3_password</c> members are necessary for a client and server to perform mutual authentication.
	/// </para>
	/// <para>
	/// On Windows Server 2008 and Windows Vista with SP1, every name registered with the Windows remote file server (SRV) is designated
	/// as either a scoped name or a non-scoped name. Every share that is added to the system will then either be attached to all of the
	/// non-scoped names, or to a single scoped name. Applications that wish to use the scoping features are responsible for both
	/// registering the new name as a scoped endpoint and then creating the shares with an appropriate scope. In this way, legacy uses of
	/// the Network Management and Network Share Management functions are not affected in any way since they continue to register shares
	/// and names as non-scoped names.
	/// </para>
	/// <para>
	/// A scoped endpoint is created by calling the NetServerTransportAddEx function with the level parameter set to 2 and the bufptr
	/// parameter pointed to a SERVER_TRANSPORT_INFO_2 structure with the <c>SVTI2_SCOPED_NAME</c> bit value set in <c>svti2_flags</c>
	/// member. A scoped endpoint is also created by calling the <c>NetServerTransportAddEx</c> function with the level parameter set to
	/// 3 and the bufptr parameter pointed to a <c>SERVER_TRANSPORT_INFO_3</c> structure with the <c>SVTI2_SCOPED_NAME</c> bit value set
	/// in <c>svti3_flags</c> member.
	/// </para>
	/// <para>
	/// When the <c>SVTI2_SCOPED_NAME</c> bit value is set for a transport, then shares can be added with a corresponding server name
	/// (the <c>shi503_servername</c> member of the SHARE_INFO_503 structure) in a scoped fashion using the NetShareAdd function. If
	/// there is no transport registered with the <c>SVTI2_SCOPED_NAME</c> bit value and the name provided in <c>shi503_servername</c>
	/// member, then the share add in a scoped fashion will not succeed.
	/// </para>
	/// <para>
	/// The NetShareAdd function is used to add a scoped share on a remote server specified in the servername parameter. The remote
	/// server specified in the <c>shi503_servername</c> member of the SHARE_INFO_503 passed in the bufptr parameter must have been bound
	/// to a transport protocol using the NetServerTransportAddEx function as a scoped endpoint. The <c>SVTI2_SCOPED_NAME</c> flag must
	/// have been specified in the <c>shi503_servername</c> member of the SERVER_TRANSPORT_INFO_2 or <c>SERVER_TRANSPORT_INFO_3</c>
	/// structure for the transport protocol. The NetShareDelEx function is used to delete a scoped share. The NetShareGetInfo and
	/// NetShareSetInfo functions are to used to get and set information on a scoped share.
	/// </para>
	/// <para>Scoped endpoints are generally used by the cluster namespace.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmserver/ns-lmserver-_server_transport_info_3 typedef struct
	// _SERVER_TRANSPORT_INFO_3 { DWORD svti3_numberofvcs; LMSTR svti3_transportname; LPBYTE svti3_transportaddress; DWORD
	// svti3_transportaddresslength; LMSTR svti3_networkaddress; LMSTR svti3_domain; ULONG svti3_flags; DWORD svti3_passwordlength; BYTE
	// svti3_password[256]; } SERVER_TRANSPORT_INFO_3, *PSERVER_TRANSPORT_INFO_3, *LPSERVER_TRANSPORT_INFO_3;
	[PInvokeData("lmserver.h", MSDNShortId = "045d60d4-518f-4ce4-b611-e23d1588d5d3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct SERVER_TRANSPORT_INFO_3
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The number of clients connected to the server that are using the transport protocol specified by the
		/// <c>svti3_transportname</c> member.
		/// </para>
		/// </summary>
		public uint svti3_numberofvcs;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>A pointer to a null-terminated character string that contains the name of a transport device; for example,</para>
		/// <para>
		/// <code>
		/// \Device\NetBT_Tcpip_{2C9725F4-151A-11D3-AEEC-C3B211BD350B
		/// </code>
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti3_transportname;

		/// <summary>
		/// <para>Type: <c>LPBYTE</c></para>
		/// <para>
		/// A pointer to a variable that contains the address the server is using on the transport device specified by the
		/// <c>svti3_transportname</c> member.
		/// </para>
		/// <para>
		/// This member is usually the NetBIOS name that the server is using. In these instances, the name must be 16 characters long,
		/// and the last character must be a blank character (0x20).
		/// </para>
		/// </summary>
		public IntPtr svti3_transportaddress;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The length, in bytes, of the <c>svti3_transportaddress</c> member. For NetBIOS names, the value of this member is 16 (decimal).
		/// </para>
		/// </summary>
		public uint svti3_transportaddresslength;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a NULL-terminated character string that contains the address the network adapter is using. The string is transport-specific.
		/// </para>
		/// <para>
		/// You can retrieve this value only with a call to the NetServerTransportEnum function. You cannot set this value with a call to
		/// the NetServerTransportAdd function or the NetServerTransportAddEx function.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti3_networkaddress;

		/// <summary>
		/// <para>Type: <c>LMSTR</c></para>
		/// <para>
		/// A pointer to a NULL-terminated character string that contains the name of the domain to which the server should announce its
		/// presence. (When you call NetServerTransportEnum, this member is the name of the domain to which the server is announcing its presence.)
		/// </para>
		/// <para>This string is Unicode if <c>_WIN32_WINNT</c> or <c>FORCE_UNICODE</c> are defined.</para>
		/// </summary>
		public string svti3_domain;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>This member can be a combination of the following bit values defined in the Lmserver.h header file.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SVTI2_REMAP_PIPE_NAMES</term>
		/// <term>
		/// If this value is set for an endpoint, client requests arriving over the transport to open a named pipe are rerouted
		/// (remapped) to the following local pipe name: $$\ServerName\PipeName For more information on the use of this value, see the
		/// Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SVTI2_SCOPED_NAME</term>
		/// <term>
		/// If this value is set for an endpoint and there is an attempt to create a second transport with the same network address but a
		/// different transport name and conflicting settings for the SCOPED flag, this transport creation will fail. Thus, every
		/// registered transport for a given network address must have the same scoped setting. For more information on the use of this
		/// value, see the Remarks section. This value is defined on Windows Server 2008 and Windows Vista with SP1.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public SERVER_TRANSPORT_FLAGS svti3_flags;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of valid bytes in the <c>svti3_password</c> member.</para>
		/// </summary>
		public uint svti3_passwordlength;

		/// <summary>
		/// <para>Type: <c>BYTE[256]</c></para>
		/// <para>
		/// The credentials to use for the new transport address. If the <c>svti3_passwordlength</c> member is zero, the credentials for
		/// the server are used.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] svti3_password;
	}

	/*
	SERVER_INFO_1005 structure
	SERVER_INFO_1010 structure
	SERVER_INFO_1016 structure
	SERVER_INFO_1017 structure
	SERVER_INFO_1018 structure
	SERVER_INFO_1107 structure
	SERVER_INFO_1501 structure
	SERVER_INFO_1502 structure
	SERVER_INFO_1503 structure
	SERVER_INFO_1506 structure
	SERVER_INFO_1509 structure
	SERVER_INFO_1510 structure
	SERVER_INFO_1511 structure
	SERVER_INFO_1512 structure
	SERVER_INFO_1513 structure
	SERVER_INFO_1515 structure
	SERVER_INFO_1516 structure
	SERVER_INFO_1518 structure
	SERVER_INFO_1523 structure
	SERVER_INFO_1528 structure
	SERVER_INFO_1529 structure
	SERVER_INFO_1530 structure
	SERVER_INFO_1533 structure
	SERVER_INFO_1536 structure
	SERVER_INFO_1538 structure
	SERVER_INFO_1539 structure
	SERVER_INFO_1540 structure
	SERVER_INFO_1541 structure
	SERVER_INFO_1542 structure
	SERVER_INFO_1544 structure
	SERVER_INFO_1550 structure
	SERVER_INFO_1552 structure
	SERVER_INFO_502 structure
	SERVER_INFO_503 structure*/
}