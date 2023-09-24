using System.ComponentModel;
using System.Runtime.Serialization;

namespace Vanara.PInvoke;

/// <summary>Items from the mpr.dll</summary>
public static partial class Mpr
{
	/// <summary>Flags used in the CONNECTDLGSTRUCT.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/aa385332(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385332")]
	[Flags]
	public enum CONN_DLG
	{
		/// <summary>
		/// Display a read-only path instead of allowing the user to type in a path.
		/// <para>
		/// This flag should be set only if the lpRemoteName member of the NETRESOURCE structure pointed to by lpConnRes member is not
		/// NULL (or an empty string), and the CONNDLG_USE_MRU flag is not set.
		/// </para>
		/// </summary>
		CONNDLG_RO_PATH = 0x00000001,

		/// <summary>Internal flag. Do not use.</summary>
		CONNDLG_CONN_POINT = 0x00000002,

		/// <summary>
		/// Enter the most recently used paths into the combination box. Set this value to simulate the WNetConnectionDialog function.
		/// </summary>
		CONNDLG_USE_MRU = 0x00000004,

		/// <summary>Show the check box allowing the user to restore the connection at logon.</summary>
		CONNDLG_HIDE_BOX = 0x00000008,

		/// <summary>Restore the connection at logon.</summary>
		CONNDLG_PERSIST = 0x00000010,

		/// <summary>Do not restore the connection at logon.</summary>
		CONNDLG_NOT_PERSIST = 0x00000020,
	}

	/// <summary>Option flags used with WNetAddConnection2.</summary>
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385413")]
	[Flags]
	public enum CONNECT
	{
		/// <summary>
		/// The network resource connection should be remembered.
		/// <para>
		/// If this bit flag is set, the operating system automatically attempts to restore the connection when the user logs on.
		/// </para>
		/// <para>
		/// The operating system remembers only successful connections that redirect local devices. It does not remember connections that
		/// are unsuccessful or deviceless connections. (A deviceless connection occurs when the lpLocalName member is NULL or when it
		/// points to an empty string.)
		/// </para>
		/// <para>If this bit flag is clear, the operating system does not automatically restore the connection at logon.</para>
		/// </summary>
		CONNECT_UPDATE_PROFILE = 0x00000001,

		/// <summary>
		/// The network resource connection should not be put in the recent connection list. If this flag is set and the connection is
		/// successfully added, the network resource connection will be put in the recent connection list only if it has a redirected
		/// local device associated with it.
		/// </summary>
		CONNECT_UPDATE_RECENT = 0x00000002,

		/// <summary>
		/// The network resource connection should not be remembered. If this flag is set, the operating system will not attempt to
		/// restore the connection when the user logs on again.
		/// </summary>
		CONNECT_TEMPORARY = 0x00000004,

		/// <summary>If this flag is set, the operating system may interact with the user for authentication purposes.</summary>
		CONNECT_INTERACTIVE = 0x00000008,

		/// <summary>
		/// This flag instructs the system not to use any default settings for user names or passwords without offering the user the
		/// opportunity to supply an alternative. This flag is ignored unless CONNECT_INTERACTIVE is also set.
		/// </summary>
		CONNECT_PROMPT = 0x00000010,

		/// <summary/>
		CONNECT_NEED_DRIVE = 0x00000020,

		/// <summary/>
		CONNECT_REFCOUNT = 0x00000040,

		/// <summary>
		/// This flag forces the redirection of a local device when making the connection.
		/// <para>
		/// If the lpLocalName member of NETRESOURCE specifies a local device to redirect, this flag has no effect, because the operating
		/// system still attempts to redirect the specified device. When the operating system automatically chooses a local device, the
		/// dwType member must not be equal to RESOURCETYPE_ANY.
		/// </para>
		/// <para>
		/// If this flag is not set, a local device is automatically chosen for redirection only if the network requires a local device
		/// to be redirected.
		/// </para>
		/// <para>
		/// Windows Server 2003 and Windows XP: When the system automatically assigns network drive letters, letters are assigned
		/// beginning with Z:, then Y:, and ending with C:. This reduces collision between per-logon drive letters (such as network drive
		/// letters) and global drive letters (such as disk drives). Note that previous releases assigned drive letters beginning with C:
		/// and ending with Z:.
		/// </para>
		/// </summary>
		CONNECT_REDIRECT = 0x00000080,

		/// <summary>
		/// If this flag is set, the connection was made using a local device redirection. If the lpAccessName parameter points to a
		/// buffer, the local device name is copied to the buffer.
		/// </summary>
		CONNECT_LOCALDRIVE = 0x00000100,

		/// <summary>
		/// If this flag is set, then the operating system does not start to use a new media to try to establish the connection (initiate
		/// a new dial up connection, for example).
		/// </summary>
		CONNECT_CURRENT_MEDIA = 0x00000200,

		/// <summary/>
		CONNECT_DEFERRED = 0x00000400,

		/// <summary>
		/// If this flag is set, the operating system prompts the user for authentication using the command line instead of a graphical
		/// user interface (GUI). This flag is ignored unless CONNECT_INTERACTIVE is also set.
		/// <para>Windows 2000/NT and Windows Me/98/95: This value is not supported.</para>
		/// </summary>
		CONNECT_COMMANDLINE = 0x00000800,

		/// <summary>
		/// If this flag is set, and the operating system prompts for a credential, the credential should be saved by the credential
		/// manager. If the credential manager is disabled for the caller's logon session, or if the network provider does not support
		/// saving credentials, this flag is ignored. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.
		/// <para>Windows 2000/NT and Windows Me/98/95: This value is not supported.</para>
		/// </summary>
		CONNECT_CMD_SAVECRED = 0x00001000,

		/// <summary>
		/// If this flag is set, and the operating system prompts for a credential, the credential is reset by the credential manager. If
		/// the credential manager is disabled for the caller's logon session, or if the network provider does not support saving
		/// credentials, this flag is ignored. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.
		/// <para>Windows Vista: This value is supported on Windows Vista and later.</para>
		/// </summary>
		CONNECT_CRED_RESET = 0x00002000,

		/// <summary/>
		CONNECT_REQUIRE_INTEGRITY = 0x00004000,
		
		/// <summary/>
		CONNECT_REQUIRE_PRIVACY = 0x00008000
	}

	/// <summary>Used by DISCDLGSTRUCT</summary>
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385339")]
	[Flags]
	public enum DISC
	{
		/// <summary>
		/// If this value is set, the specified connection is no longer a persistent one (automatically restored every time the user logs on). This flag is valid only if the lpLocalName member specifies a local device.
		/// </summary>
		DISC_UPDATE_PROFILE = 0x00000001,
		/// <summary>
		/// If this value is not set, the system applies force when attempting to disconnect from the network resource.
		/// <para>This situation typically occurs when the user has files open over the connection. This value means that the user will be informed if there are open files on the connection, and asked if he or she still wants to disconnect. If the user wants to proceed, the disconnect procedure re-attempts with additional force.</para>
		/// </summary>
		DISC_NO_FORCE = 0x00000040,
	}

	/// <summary>Info level for WNetGetUniversalName.</summary>
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385474")]
	public enum INFO_LEVEL
	{
		/// <summary>The function stores a UNIVERSAL_NAME_INFO structure in the buffer.</summary>
		[CorrespondingType(typeof(UNIVERSAL_NAME_INFO))]
		UNIVERSAL_NAME_INFO_LEVEL = 0x00000001,

		/// <summary>The function stores a REMOTE_NAME_INFO structure in the buffer.</summary>
		[CorrespondingType(typeof(REMOTE_NAME_INFO))]
		REMOTE_NAME_INFO_LEVEL = 0x00000002
	}

	/// <summary>Characteristics of the network provider software.</summary>
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385349")]
	[Flags]
	public enum NETINFO
	{
		/// <summary>The network provider is running as a 16-bit Windows network driver.</summary>
		NETINFO_DLL16 = 0x00000001,

		/// <summary>The network provider requires a redirected local disk drive device to access server file systems.</summary>
		NETINFO_DISKRED = 0x00000004,

		/// <summary>The network provider requires a redirected local printer port to access server file systems.</summary>
		NETINFO_PRINTERRED = 0x00000008,
	}

	/// <summary>The display options for the network object in a network browsing user interface.</summary>
	public enum NETRESOURCEDisplayType : uint
	{
		/// <summary>The method used to display the object does not matter.</summary>
		RESOURCEDISPLAYTYPE_GENERIC = 0x00000000,

		/// <summary>The object should be displayed as a domain.</summary>
		RESOURCEDISPLAYTYPE_DOMAIN = 0x00000001,

		/// <summary>The object should be displayed as a server.</summary>
		RESOURCEDISPLAYTYPE_SERVER = 0x00000002,

		/// <summary>The object should be displayed as a share.</summary>
		RESOURCEDISPLAYTYPE_SHARE = 0x00000003,

		/// <summary>The object should be displayed as a file.</summary>
		RESOURCEDISPLAYTYPE_FILE = 0x00000004,

		/// <summary>The object should be displayed as a group.</summary>
		RESOURCEDISPLAYTYPE_GROUP = 0x00000005,

		/// <summary>The object should be displayed as a network.</summary>
		RESOURCEDISPLAYTYPE_NETWORK = 0x00000006,

		/// <summary>The object should be displayed as a logical root for the entire network.</summary>
		RESOURCEDISPLAYTYPE_ROOT = 0x00000007,

		/// <summary>The object should be displayed as a administrative share.</summary>
		RESOURCEDISPLAYTYPE_SHAREADMIN = 0x00000008,

		/// <summary>The object should be displayed as a directory.</summary>
		RESOURCEDISPLAYTYPE_DIRECTORY = 0x00000009,

		/// <summary>
		/// The object should be displayed as a tree. This display type was used for a NetWare Directory Service (NDS) tree by the
		/// NetWare Workstation service supported on Windows XP and earlier.
		/// </summary>
		RESOURCEDISPLAYTYPE_TREE = 0x0000000A,

		/// <summary>
		/// The object should be displayed as a Netware Directory Service container. This display type was used by the NetWare
		/// Workstation service supported on Windows XP and earlier.
		/// </summary>
		RESOURCEDISPLAYTYPE_NDSCONTAINER = 0x0000000B,
	}

	/// <summary>The scope of the enumeration.</summary>
	public enum NETRESOURCEScope : uint
	{
		/// <summary>Enumerate currently connected resources. The dwUsage member cannot be specified.</summary>
		RESOURCE_CONNECTED = 0x00000001,

		/// <summary>Enumerate all resources on the network. The dwUsage member is specified.</summary>
		RESOURCE_GLOBALNET = 0x00000002,

		/// <summary>Enumerate remembered (persistent) connections. The dwUsage member cannot be specified.</summary>
		RESOURCE_REMEMBERED = 0x00000003,

		/// <summary>Enumerate recent connections. The dwUsage member cannot be specified.</summary>
		RESOURCE_RECENT = 0x00000004,

		/// <summary>?</summary>
		RESOURCE_CONTEXT = 0x00000005,
	}

	/// <summary>The type of resource.</summary>
	public enum NETRESOURCEType : uint
	{
		/// <summary>All resources.</summary>
		RESOURCETYPE_ANY = 0x00000000,

		/// <summary>Disk resources.</summary>
		RESOURCETYPE_DISK = 0x00000001,

		/// <summary>Print resources.</summary>
		RESOURCETYPE_PRINT = 0x00000002,

		/// <summary>Reserved resources.</summary>
		RESOURCETYPE_RESERVED = 0x00000008,

		/// <summary>Neither a disk or print resource.</summary>
		RESOURCETYPE_UNKNOWN = 0xFFFFFFFF,
	}

	/// <summary>A set of bit flags describing how the resource can be used.</summary>
	[Flags]
	public enum NETRESOURCEUsage : uint
	{
		/// <summary>
		/// The resource is a connectable resource; the name pointed to by the lpRemoteName member can be passed to the WNetAddConnection
		/// function to make a network connection.
		/// </summary>
		RESOURCEUSAGE_CONNECTABLE = 0x00000001,

		/// <summary>
		/// The resource is a container resource; the name pointed to by the lpRemoteName member can be passed to the WNetOpenEnum
		/// function to enumerate the resources in the container.
		/// </summary>
		RESOURCEUSAGE_CONTAINER = 0x00000002,

		/// <summary>The resource is not a local device.</summary>
		RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,

		/// <summary>The resource is a sibling. This value is not used by Windows.</summary>
		RESOURCEUSAGE_SIBLING = 0x00000008,

		/// <summary>
		/// The resource must be attached. This value specifies that a function to enumerate resource this should fail if the caller is
		/// not authenticated, even if the network permits enumeration without authentication.
		/// </summary>
		RESOURCEUSAGE_ATTACHED = 0x00000010,

		/// <summary>All valid values.</summary>
		RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),

		/// <summary>Reserved</summary>
		RESOURCEUSAGE_RESERVED = 0x80000000
	}

	/// <summary>A set of bit flags describing the connection.</summary>
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385345")]
	[Flags]
	public enum WNCON : uint
	{
		/// <summary>
		/// In the absence of information about the actual connection, the information returned applies to the performance of the network
		/// card. If this flag is not set, information is being returned for the current connection with the resource, with any routing
		/// degradation taken into consideration.
		/// </summary>
		WNCON_FORNETCARD = 0x00000001,

		/// <summary>
		/// The connection is not being routed. If this flag is not set, the connection may be going through routers that limit
		/// performance. Consequently, if WNCON_FORNETCARD is set, actual performance may be much less than the information returned.
		/// </summary>
		WNCON_NOTROUTED = 0x00000002,

		/// <summary>
		/// The connection is over a medium that is typically slow (for example, over a modem using a normal quality phone line). You
		/// should not set the WNCON_SLOWLINK bit if the dwSpeed member is set to a nonzero value.
		/// </summary>
		WNCON_SLOWLINK = 0x00000004,

		/// <summary>
		/// Some of the information returned is calculated dynamically, so reissuing this request may return different (and more current) information.
		/// </summary>
		WNCON_DYNAMIC = 0x00000008,
	}

	/// <summary>Network types</summary>
	[PInvokeData("wnnc.h")]
	public enum WNNC_NET
	{
		WNNC_NET_MSNET = 0x00010000,
		WNNC_NET_SMB         = 0x00020000,
		WNNC_NET_NETWARE     = 0x00030000,
		WNNC_NET_VINES       = 0x00040000,
		WNNC_NET_10NET       = 0x00050000,
		WNNC_NET_LOCUS       = 0x00060000,
		WNNC_NET_SUN_PC_NFS  = 0x00070000,
		WNNC_NET_LANSTEP     = 0x00080000,
		WNNC_NET_9TILES      = 0x00090000,
		WNNC_NET_LANTASTIC   = 0x000A0000,
		WNNC_NET_AS400       = 0x000B0000,
		WNNC_NET_FTP_NFS     = 0x000C0000,
		WNNC_NET_PATHWORKS   = 0x000D0000,
		WNNC_NET_LIFENET     = 0x000E0000,
		WNNC_NET_POWERLAN    = 0x000F0000,
		WNNC_NET_BWNFS       = 0x00100000,
		WNNC_NET_COGENT      = 0x00110000,
		WNNC_NET_FARALLON    = 0x00120000,
		WNNC_NET_APPLETALK   = 0x00130000,
		WNNC_NET_INTERGRAPH  = 0x00140000,
		WNNC_NET_SYMFONET    = 0x00150000,
		WNNC_NET_CLEARCASE   = 0x00160000,
		WNNC_NET_FRONTIER    = 0x00170000,
		WNNC_NET_BMC         = 0x00180000,
		WNNC_NET_DCE         = 0x00190000,
		WNNC_NET_AVID        = 0x001A0000,
		WNNC_NET_DOCUSPACE   = 0x001B0000,
		WNNC_NET_MANGOSOFT   = 0x001C0000,
		WNNC_NET_SERNET      = 0x001D0000,
		WNNC_NET_RIVERFRONT1 = 0X001E0000,
		WNNC_NET_RIVERFRONT2 = 0x001F0000,
		WNNC_NET_DECORB      = 0x00200000,
		WNNC_NET_PROTSTOR    = 0x00210000,
		WNNC_NET_FJ_REDIR    = 0x00220000,
		WNNC_NET_DISTINCT    = 0x00230000,
		WNNC_NET_TWINS       = 0x00240000,
		WNNC_NET_RDR2SAMPLE  = 0x00250000,
		WNNC_NET_CSC         = 0x00260000,
		WNNC_NET_3IN1        = 0x00270000,
		WNNC_NET_EXTENDNET   = 0x00290000,
		WNNC_NET_STAC        = 0x002A0000,
		WNNC_NET_FOXBAT      = 0x002B0000,
		WNNC_NET_YAHOO       = 0x002C0000,
		WNNC_NET_EXIFS       = 0x002D0000,
		WNNC_NET_DAV         = 0x002E0000,
		WNNC_NET_KNOWARE     = 0x002F0000,
		WNNC_NET_OBJECT_DIRE = 0x00300000,
		WNNC_NET_MASFAX      = 0x00310000,
		WNNC_NET_HOB_NFS     = 0x00320000,
		WNNC_NET_SHIVA       = 0x00330000,
		WNNC_NET_IBMAL       = 0x00340000,
		WNNC_NET_LOCK        = 0x00350000,
		WNNC_NET_TERMSRV     = 0x00360000,
		WNNC_NET_SRT         = 0x00370000,
		WNNC_NET_QUINCY      = 0x00380000,
		WNNC_NET_OPENAFS     = 0x00390000,
		WNNC_NET_AVID1       = 0X003A0000,
		WNNC_NET_DFS         = 0x003B0000,
		WNNC_NET_KWNP        = 0x003C0000,
		WNNC_NET_ZENWORKS    = 0x003D0000,
		WNNC_NET_DRIVEONWEB  = 0x003E0000,
		WNNC_NET_VMWARE      = 0x003F0000,
		WNNC_NET_RSFX        = 0x00400000,
		WNNC_NET_MFILES      = 0x00410000,
		WNNC_NET_MS_NFS      = 0x00420000,
		WNNC_NET_GOOGLE      = 0x00430000,
		WNNC_NET_NDFS        = 0x00440000,
		WNNC_NET_DOCUSHARE   = 0x00450000,
		WNNC_NET_AURISTOR_FS = 0x00460000,
		WNNC_NET_SECUREAGENT = 0x00470000,
	}

	/// <summary>
	/// The <c>MultinetGetConnectionPerformance</c> function returns information about the expected performance of a connection used to
	/// access a network resource.
	/// </summary>
	/// <param name="lpNetResource">
	/// <para>
	/// A pointer to a <c>NETRESOURCE</c> structure that specifies the network resource. The following members have specific meanings in
	/// this context.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Member</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>lpLocalName</term>
	/// <term>
	/// A pointer to a buffer that specifies a local device, such as &amp;quot;F:&amp;quot; or &amp;quot;LPT1&amp;quot;, that is
	/// redirected to a network resource to be queried. If this member is NULL or an empty string, the network resource is specified in
	/// the lpRemoteName member. If this flag specifies a local device, lpRemoteName is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpRemoteName</term>
	/// <term>
	/// A pointer to a network resource to query. The resource must currently have an established connection. For example, if the
	/// resource is a file on a file server, then having the file open will ensure the connection.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpProvider</term>
	/// <term>
	/// Usually set to NULL, but can be a pointer to the owner (provider) of the resource if the network on which the resource resides is
	/// known. If the lpProvider member is not NULL, the system attempts to return information only about the named network.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpNetConnectInfoStruct">A pointer to the <c>NETCONNECTINFOSTRUCT</c> structure that receives the data.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>The network resource does not supply this information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_CONNECTED</term>
	/// <term>
	/// The lpLocalName member of the NETRESOURCE structure pointed to by the lpNetResource parameter does not specify a redirected
	/// device, or the lpRemoteName member does not specify the name of a resource that is currently connected.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>
	/// The operation could not be completed, either because a network component is not started, or because the specified resource name
	/// is not recognized.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEVICE</term>
	/// <term>The local device specified by the lpLocalName member is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_NET_NAME</term>
	/// <term>
	/// The network name cannot be found. This error is returned if the lpLocalName member of the NETRESOURCE structure pointed to by the
	/// lpNetResource parameter was NULL and the lpRemoteName member of the NETRESOURCE structure pointed to by the lpNetResource was
	/// also or NULL or could not recognized by any network.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_ADDRESS</term>
	/// <term>
	/// An attempt to access an invalid address. This error is returned if the lpNetResource or lpNetConnectInfoStruct parameters were NULL.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A bad parameter was passed. This error is returned if the lpNetConnectInfoStruct parameter does not point to a
	/// NETCONNECTINFOSTRUCT structure in which the cbStructure member is filled with the proper structure size.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call WNetGetLastError.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD MultinetGetConnectionPerformance( _In_ LPNETRESOURCE lpNetResource, _Out_ LPNETCONNECTINFOSTRUCT lpNetConnectInfoStruct); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385342(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385342")]
	public static extern Win32Error MultinetGetConnectionPerformance(NETRESOURCE lpNetResource, ref NETCONNECTINFOSTRUCT lpNetConnectInfoStruct);

	/// <summary>
	/// The <c>WNetAddConnection</c> function enables the calling application to connect a local device to a network resource. A
	/// successful connection is persistent, meaning that the system automatically restores the connection during subsequent logon operations.
	/// </summary>
	/// <param name="lpRemoteName">
	/// A pointer to a constant <c>null</c>-terminated string that specifies the network resource to connect to.
	/// </param>
	/// <param name="lpPassword">
	/// <para>
	/// A pointer to a constant <c>null</c>-terminated string that specifies the password to be used to make a connection. This parameter
	/// is usually the password associated with the current user.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the default password is used. If the string is empty, no password is used.</para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="lpLocalName">
	/// A pointer to a constant <c>null</c>-terminated string that specifies the name of a local device to be redirected, such as "F:" or
	/// "LPT1". The string is treated in a case-insensitive manner. If the string is <c>NULL</c>, a connection to the network resource is
	/// made without redirecting the local device.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have access to the network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ALREADY_ASSIGNED</term>
	/// <term>The device specified in the lpLocalName parameter is already connected.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEV_TYPE</term>
	/// <term>The device type and the resource type do not match.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEVICE</term>
	/// <term>The value specified in the lpLocalName parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_NET_NAME</term>
	/// <term>The value specified in the lpRemoteName parameter is not valid or cannot be located.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROFILE</term>
	/// <term>The user profile is in an incorrect format.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANNOT_OPEN_PROFILE</term>
	/// <term>The system is unable to open the user profile to process persistent connections.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_ALREADY_REMEMBERED</term>
	/// <term>An entry for the device specified in the lpLocalName parameter is already in the user profile.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PASSWORD</term>
	/// <term>The specified password is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>The operation cannot be performed because a network component is not started or because a specified name cannot be used.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetAddConnection( _In_ LPCTSTR lpRemoteName, _In_ LPCTSTR lpPassword, _In_ LPCTSTR lpLocalName); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385410(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385410")]
	public static extern Win32Error WNetAddConnection(string lpRemoteName, [Optional] string? lpPassword, [Optional] string? lpLocalName);

	/// <summary>
	/// <para>
	/// The <c>WNetAddConnection2</c> function makes a connection to a network resource and can redirect a local device to the network resource.
	/// </para>
	/// <para>
	/// The <c>WNetAddConnection2</c> function supersedes the <c>WNetAddConnection</c> function. If you can pass a handle to a window
	/// that the provider of network resources can use as an owner window for dialog boxes, call the <c>WNetAddConnection3</c> function instead.
	/// </para>
	/// </summary>
	/// <param name="lpNetResource">
	/// <para>
	/// A pointer to a <c>NETRESOURCE</c> structure that specifies details of the proposed connection, such as information about the
	/// network resource, the local device, and the network resource provider.
	/// </para>
	/// <para>You must specify the following members of the <c>NETRESOURCE</c> structure.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Member</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>dwType</term>
	/// <term>
	/// The type of network resource to connect to. If the lpLocalName member points to a nonempty string, this member can be equal to
	/// RESOURCETYPE_DISK or RESOURCETYPE_PRINT.If lpLocalName is NULL, or if it points to an empty string, dwType can be equal to
	/// RESOURCETYPE_DISK, RESOURCETYPE_PRINT, or RESOURCETYPE_ANY.Although this member is required, its information may be ignored by
	/// the network service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpLocalName</term>
	/// <term>
	/// A pointer to a null-terminated string that specifies the name of a local device to redirect, such as &amp;quot;F:&amp;quot; or
	/// &amp;quot;LPT1&amp;quot;. The string is treated in a case-insensitive manner.If the string is empty, or if lpLocalName is NULL,
	/// the function makes a connection to the network resource without redirecting a local device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpRemoteName</term>
	/// <term>
	/// A pointer to a null-terminated string that specifies the network resource to connect to. The string can be up to MAX_PATH
	/// characters in length, and must follow the network provider's naming conventions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpProvider</term>
	/// <term>
	/// A pointer to a null-terminated string that specifies the network provider to connect to. If lpProvider is NULL, or if it points
	/// to an empty string, the operating system attempts to determine the correct provider by parsing the string pointed to by the
	/// lpRemoteName member.If this member is not NULL, the operating system attempts to make a connection only to the named network
	/// provider.You should set this member only if you know the network provider you want to use. Otherwise, let the operating system
	/// determine which provider the network name maps to.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>The <c>WNetAddConnection2</c> function ignores the other members of the <c>NETRESOURCE</c> structure.</para>
	/// </param>
	/// <param name="lpPassword">
	/// <para>A pointer to a constant <c>null</c>-terminated string that specifies a password to be used in making the network connection.</para>
	/// <para>
	/// If lpPassword is <c>NULL</c>, the function uses the current default password associated with the user specified by the lpUserName parameter.
	/// </para>
	/// <para>If lpPassword points to an empty string, the function does not use a password.</para>
	/// <para>
	/// If the connection fails because of an invalid password and the CONNECT_INTERACTIVE value is set in the dwFlags parameter, the
	/// function displays a dialog box asking the user to type the password.
	/// </para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="lpUsername">
	/// <para>A pointer to a constant <c>null</c>-terminated string that specifies a user name for making the connection.</para>
	/// <para>
	/// If lpUserName is <c>NULL</c>, the function uses the default user name. (The user context for the process provides the default
	/// user name.)
	/// </para>
	/// <para>
	/// The lpUserName parameter is specified when users want to connect to a network resource for which they have been assigned a user
	/// name or account other than the default user name or account.
	/// </para>
	/// <para>The user-name string represents a security context. It may be specific to a network provider.</para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A set of connection options. The possible values for the connection options are defined in the Winnetwk.h header file. The
	/// following values can currently be used.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CONNECT_UPDATE_PROFILE0x00000001</term>
	/// <term>
	/// The network resource connection should be remembered. If this bit flag is set, the operating system automatically attempts to
	/// restore the connection when the user logs on. The operating system remembers only successful connections that redirect local
	/// devices. It does not remember connections that are unsuccessful or deviceless connections. (A deviceless connection occurs when
	/// the lpLocalName member is NULL or points to an empty string.)If this bit flag is clear, the operating system does not try to
	/// restore the connection when the user logs on.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_UPDATE_RECENT0x00000002</term>
	/// <term>
	/// The network resource connection should not be put in the recent connection list. If this flag is set and the connection is
	/// successfully added, the network resource connection will be put in the recent connection list only if it has a redirected local
	/// device associated with it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_TEMPORARY0x00000004</term>
	/// <term>
	/// The network resource connection should not be remembered. If this flag is set, the operating system will not attempt to restore
	/// the connection when the user logs on again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_INTERACTIVE0x00000008</term>
	/// <term>If this flag is set, the operating system may interact with the user for authentication purposes.</term>
	/// </item>
	/// <item>
	/// <term>CONNECT_PROMPT0x00000010</term>
	/// <term>
	/// This flag instructs the system not to use any default settings for user names or passwords without offering the user the
	/// opportunity to supply an alternative. This flag is ignored unless CONNECT_INTERACTIVE is also set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_REDIRECT0x00000080</term>
	/// <term>
	/// This flag forces the redirection of a local device when making the connection.If the lpLocalName member of NETRESOURCE specifies
	/// a local device to redirect, this flag has no effect, because the operating system still attempts to redirect the specified
	/// device. When the operating system automatically chooses a local device, the dwType member must not be equal to
	/// RESOURCETYPE_ANY.If this flag is not set, a local device is automatically chosen for redirection only if the network requires a
	/// local device to be redirected.Windows Server 2003 and Windows XP: When the system automatically assigns network drive letters,
	/// letters are assigned beginning with Z:, then Y:, and ending with C:. This reduces collision between per-logon drive letters (such
	/// as network drive letters) and global drive letters (such as disk drives). Note that earlier versions of Windows assigned drive
	/// letters beginning with C: and ending with Z:.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_CURRENT_MEDIA0x00000200</term>
	/// <term>
	/// If this flag is set, then the operating system does not start to use a new media to try to establish the connection (initiate a
	/// new dial up connection, for example).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_COMMANDLINE0x00000800</term>
	/// <term>
	/// If this flag is set, the operating system prompts the user for authentication using the command line instead of a graphical user
	/// interface (GUI). This flag is ignored unless CONNECT_INTERACTIVE is also set.Windows XP: This value is supported on Windows XP
	/// and later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_CMD_SAVECRED0x00001000</term>
	/// <term>
	/// If this flag is set, and the operating system prompts for a credential, the credential should be saved by the credential manager.
	/// If the credential manager is disabled for the caller's logon session, or if the network provider does not support saving
	/// credentials, this flag is ignored. This flag is ignored unless CONNECT_INTERACTIVE is also set. This flag is also ignored unless
	/// you set the CONNECT_COMMANDLINE flag.Windows XP: This value is supported on Windows XP and later.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_CRED_RESET0x00002000</term>
	/// <term>
	/// If this flag is set, and the operating system prompts for a credential, the credential is reset by the credential manager. If the
	/// credential manager is disabled for the caller's logon session, or if the network provider does not support saving
	/// credentials, this flag is ignored. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.Windows Vista: This
	/// value is supported on Windows Vista and later.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value can be one of the following error codes or one of the system error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have access to the network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ALREADY_ASSIGNED</term>
	/// <term>The local device specified by the lpLocalName member is already connected to a network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEV_TYPE</term>
	/// <term>The type of local device and the type of network resource do not match.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEVICE</term>
	/// <term>
	/// The specified device name is not valid. This error is returned if the lpLocalName member of the NETRESOURCE structure pointed to
	/// by the lpNetResource parameter specifies a device that is not redirectable.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_NET_NAME</term>
	/// <term>
	/// The network name cannot be found. This value is returned if the lpRemoteName member of the NETRESOURCE structure pointed to by
	/// the lpNetResource parameter specifies a resource that is not acceptable to any network resource provider, either because the
	/// resource name is empty, not valid, or because the named resource cannot be located.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROFILE</term>
	/// <term>The user profile is in an incorrect format.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROVIDER</term>
	/// <term>
	/// The specified network provider name is not valid. This error is returned if the lpProvider member of the NETRESOURCE structure
	/// pointed to by the lpNetResource parameter specifies a value that does not match any network provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_USERNAME</term>
	/// <term>The specified user name is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The router or provider is busy, possibly initializing. The caller should retry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>
	/// The attempt to make the connection was canceled by the user through a dialog box from one of the network resource providers, or
	/// by a called resource.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANNOT_OPEN_PROFILE</term>
	/// <term>The system is unable to open the user profile to process persistent connections.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_ALREADY_REMEMBERED</term>
	/// <term>
	/// The local device name has a remembered connection to another network resource. This error is returned if an entry for the device
	/// specified by lpLocalName member of the NETRESOURCE structure pointed to by the lpNetResource parameter specifies a value that is
	/// already in the user profile for a different connection than that specified in the lpNetResource parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. Call the WNetGetLastError function to obtain a description of the error.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_ADDRESS</term>
	/// <term>
	/// An attempt was made to access an invalid address. This error is returned if the dwFlags parameter specifies a value of
	/// CONNECT_REDIRECT, but the lpLocalName member of the NETRESOURCE structure pointed to by the lpNetResource parameter was unspecified.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// A parameter is incorrect. This error is returned if the dwType member of the NETRESOURCE structure pointed to by the
	/// lpNetResource parameter specifies a value other than RESOURCETYPE_DISK, RESOURCETYPE_PRINT, or RESOURCETYPE_ANY. This error is
	/// also returned if the dwFlags parameter specifies an incorrect or unknown value.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PASSWORD</term>
	/// <term>The specified password is invalid and the CONNECT_INTERACTIVE flag is not set.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_LOGON_FAILURE</term>
	/// <term>A logon failure because of an unknown user name or a bad password.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>
	/// No network provider accepted the given network path. This error is returned if no network provider recognized the lpRemoteName
	/// member of the NETRESOURCE structure pointed to by the lpNetResource parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>Other</term>
	/// <term>Use FormatMessage to obtain the message string for the returned error.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetAddConnection2( _In_ LPNETRESOURCE lpNetResource, _In_ LPCTSTR lpPassword, _In_ LPCTSTR lpUsername, _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385413(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385413")]
	public static extern Win32Error WNetAddConnection2(NETRESOURCE lpNetResource, [Optional] string? lpPassword, [Optional] string? lpUsername, [Optional] CONNECT dwFlags);

	/// <summary>
	/// <para>
	/// The <c>WNetAddConnection3</c> function makes a connection to a network resource. The function can redirect a local device to the
	/// network resource.
	/// </para>
	/// <para>
	/// The <c>WNetAddConnection3</c> function is similar to the <c>WNetAddConnection2</c> function. The main difference is that
	/// <c>WNetAddConnection3</c> has an additional parameter, a handle to a window that the provider of network resources can use as an
	/// owner window for dialog boxes. The <c>WNetAddConnection2</c> function and the <c>WNetAddConnection3</c> function supersede the
	/// <c>WNetAddConnection</c> function.
	/// </para>
	/// </summary>
	/// <param name="hwndOwner">
	/// <para>
	/// A handle to a window that the provider of network resources can use as an owner window for dialog boxes. Use this parameter if
	/// you set the CONNECT_INTERACTIVE value in the dwFlags parameter.
	/// </para>
	/// <para>
	/// The hwndOwner parameter can be <c>NULL</c>. If it is, a call to <c>WNetAddConnection3</c> is equivalent to calling the
	/// <c>WNetAddConnection2</c> function.
	/// </para>
	/// </param>
	/// <param name="lpNetResource">
	/// <para>
	/// A pointer to a <c>NETRESOURCE</c> structure that specifies details of the proposed connection, such as information about the
	/// network resource, the local device, and the network resource provider.
	/// </para>
	/// <para>You must specify the following members of the <c>NETRESOURCE</c> structure.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Member</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>dwType</term>
	/// <term>
	/// The type of network resource to connect to. If the lpLocalName member points to a nonempty string, this member can be equal to
	/// RESOURCETYPE_DISK or RESOURCETYPE_PRINT.If lpLocalName is NULL, or if it points to an empty string, dwType can be equal to
	/// RESOURCETYPE_DISK, RESOURCETYPE_PRINT, or RESOURCETYPE_ANY.Although this member is required, its information may be ignored by
	/// the network service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpLocalName</term>
	/// <term>
	/// A pointer to a null-terminated string that specifies the name of a local device to redirect, such as &amp;quot;F:&amp;quot; or
	/// &amp;quot;LPT1&amp;quot;. The string is treated in a case-insensitive manner.If the string is empty or if lpLocalName is NULL,
	/// the function makes a connection to the network resource without redirecting a local device.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpRemoteName</term>
	/// <term>
	/// A pointer to a null-terminated string that specifies the network resource to connect to. The string can be up to MAX_PATH
	/// characters in length, and must follow the network provider's naming conventions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpProvider</term>
	/// <term>
	/// A pointer to a null-terminated string that specifies the network provider to connect to.If lpProvider is NULL, or if it points to
	/// an empty string, the operating system attempts to determine the correct provider by parsing the string pointed to by the
	/// lpRemoteName member.If this member is not NULL, the operating system attempts to make a connection only to the named network
	/// provider.You should set this member only if you know which network provider you want to use. Otherwise, let the operating system
	/// determine which network provider the network name maps to.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>The <c>WNetAddConnection3</c> function ignores the other members of the <c>NETRESOURCE</c> structure.</para>
	/// </param>
	/// <param name="lpPassword">
	/// <para>A pointer to a <c>null</c>-terminated string that specifies a password to be used in making the network connection.</para>
	/// <para>
	/// If lpPassword is <c>NULL</c>, the function uses the current default password associated with the user specified by the lpUserName parameter.
	/// </para>
	/// <para>If lpPassword points to an empty string, the function does not use a password.</para>
	/// <para>
	/// If the connection fails because of an invalid password and the CONNECT_INTERACTIVE value is set in the dwFlags parameter, the
	/// function displays a dialog box asking the user to type the password.
	/// </para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="lpUserName">
	/// <para>A pointer to a <c>null</c>-terminated string that specifies a user name for making the connection.</para>
	/// <para>
	/// If lpUserName is <c>NULL</c>, the function uses the default user name. (The user context for the process provides the default
	/// user name.)
	/// </para>
	/// <para>
	/// The lpUserName parameter is specified when users want to connect to a network resource for which they have been assigned a user
	/// name or account other than the default user name or account.
	/// </para>
	/// <para>The user-name string represents a security context. It may be specific to a network provider.</para>
	/// <para><c>Windows Me/98/95:</c> This parameter must be <c>NULL</c> or an empty string.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>A set of connection options. The following values are currently defined.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CONNECT_INTERACTIVE</term>
	/// <term>If this flag is set, the operating system may interact with the user for authentication purposes.</term>
	/// </item>
	/// <item>
	/// <term>CONNECT_PROMPT</term>
	/// <term>
	/// This flag instructs the system not to use any default settings for user names or passwords without offering the user the
	/// opportunity to supply an alternative. This flag is ignored unless CONNECT_INTERACTIVE is also set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_REDIRECT</term>
	/// <term>
	/// This flag forces the redirection of a local device when making the connection. If the lpLocalName member of NETRESOURCE specifies
	/// a local device to redirect, this flag has no effect, because the operating system still attempts to redirect the specified
	/// device. When the operating system automatically chooses a local device, the dwType member must not be equal to
	/// RESOURCETYPE_ANY.If this flag is not set, a local device is automatically chosen for redirection only if the network requires a
	/// local device to be redirected.Windows Server 2003 and Windows XP: When the system automatically assigns network drive letters,
	/// letters are assigned beginning with Z:, then Y:, and ending with C:. This reduces collision between per-logon drive letters (such
	/// as network drive letters) and global drive letters (such as disk drives). Note that earlier versions of Windows assigned drive
	/// letters beginning with C: and ending with Z:.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_UPDATE_PROFILE</term>
	/// <term>
	/// The network resource connection should be remembered.If this bit flag is set, the operating system automatically attempts to
	/// restore the connection when the user logs on.The operating system remembers only successful connections that redirect local
	/// devices. It does not remember connections that are unsuccessful or deviceless connections. (A deviceless connection occurs when
	/// the lpLocalName member is NULL or when it points to an empty string.)If this bit flag is clear, the operating system does not
	/// automatically restore the connection at logon.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_COMMANDLINE</term>
	/// <term>
	/// If this flag is set, the operating system prompts the user for authentication using the command line instead of a graphical user
	/// interface (GUI). This flag is ignored unless CONNECT_INTERACTIVE is also set.Windows 2000/NT and Windows Me/98/95: This value is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_CMD_SAVECRED</term>
	/// <term>
	/// If this flag is set, and the operating system prompts for a credential, the credential should be saved by the credential manager.
	/// If the credential manager is disabled for the caller's logon session, or if the network provider does not support saving
	/// credentials, this flag is ignored. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.Windows 2000/NT and
	/// Windows Me/98/95: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have access to the network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ALREADY_ASSIGNED</term>
	/// <term>The local device specified by the lpLocalName member is already connected to a network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEV_TYPE</term>
	/// <term>The type of local device and the type of network resource do not match.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEVICE</term>
	/// <term>The value specified by lpLocalName is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_NET_NAME</term>
	/// <term>
	/// The value specified by the lpRemoteName member is not acceptable to any network resource provider, either because the resource
	/// name is invalid, or because the named resource cannot be located.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROFILE</term>
	/// <term>The user profile is in an incorrect format.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROVIDER</term>
	/// <term>The value specified by the lpProvider member does not match any provider.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The router or provider is busy, possibly initializing. The caller should retry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>
	/// The attempt to make the connection was canceled by the user through a dialog box from one of the network resource providers, or
	/// by a called resource.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANNOT_OPEN_PROFILE</term>
	/// <term>The system is unable to open the user profile to process persistent connections.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_ALREADY_REMEMBERED</term>
	/// <term>An entry for the device specified by the lpLocalName member is already in the user profile.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. Call the WNetGetLastError function to obtain a description of the error.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PASSWORD</term>
	/// <term>The specified password is invalid and the CONNECT_INTERACTIVE flag is not set.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>The operation cannot be performed because a network component is not started or because a specified name cannot be used.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetAddConnection3( _In_ HWND hwndOwner, _In_ LPNETRESOURCE lpNetResource, _In_ LPTSTR lpPassword, _In_ LPTSTR lpUserName,
	// _In_ DWORD dwFlags); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385418(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385418")]
	public static extern Win32Error WNetAddConnection3([Optional] HWND hwndOwner, NETRESOURCE lpNetResource, [Optional] string? lpPassword, [Optional] string? lpUserName, [Optional] CONNECT dwFlags);

	/// <summary>
	/// <para>
	/// The <c>WNetCancelConnection2</c> function cancels an existing network connection. You can also call the function to remove
	/// remembered network connections that are not currently connected.
	/// </para>
	/// <para>The <c>WNetCancelConnection2</c> function supersedes the <c>WNetCancelConnection</c> function.</para>
	/// </summary>
	/// <param name="lpName">
	/// <para>
	/// Pointer to a constant <c>null</c>-terminated string that specifies the name of either the redirected local device or the remote
	/// network resource to disconnect from.
	/// </para>
	/// <para>
	/// If this parameter specifies a redirected local device, the function cancels only the specified device redirection. If the
	/// parameter specifies a remote network resource, all connections without devices are canceled.
	/// </para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Connection type. The following values are defined.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>
	/// The system does not update information about the connection. If the connection was marked as persistent in the registry, the
	/// system continues to restore the connection at the next logon. If the connection was not marked as persistent, the function
	/// ignores the setting of the CONNECT_UPDATE_PROFILE flag.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_UPDATE_PROFILE</term>
	/// <term>
	/// The system updates the user profile with the information that the connection is no longer a persistent one. The system will not
	/// restore this connection during subsequent logon operations. (Disconnecting resources using remote names has no effect on
	/// persistent connections.)
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="fForce">
	/// Specifies whether the disconnection should occur if there are open files or jobs on the connection. If this parameter is
	/// <c>FALSE</c>, the function fails if there are open files or jobs.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_PROFILE</term>
	/// <term>The user profile is in an incorrect format.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANNOT_OPEN_PROFILE</term>
	/// <term>The system is unable to open the user profile to process persistent connections.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_IN_USE</term>
	/// <term>The device is in use by an active process and cannot be disconnected.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_CONNECTED</term>
	/// <term>
	/// The name specified by the lpName parameter is not a redirected device, or the system is not currently connected to the device
	/// specified by the parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_OPEN_FILES</term>
	/// <term>There are open files, and the fForce parameter is FALSE.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetCancelConnection2( _In_ LPCTSTR lpName, _In_ DWORD dwFlags, _In_ BOOL fForce); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385427(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385427")]
	public static extern Win32Error WNetCancelConnection2(string lpName, CONNECT dwFlags, [MarshalAs(UnmanagedType.Bool)] bool fForce);

	/// <summary>
	/// The <c>WNetCloseEnum</c> function ends a network resource enumeration started by a call to the <c>WNetOpenEnum</c> function.
	/// </summary>
	/// <param name="hEnum">
	/// Handle that identifies an enumeration instance. This handle must be returned by the <c>WNetOpenEnum</c> function.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>
	/// The network is unavailable. (This condition is tested before the handle specified in the hEnum parameter is tested for validity.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hEnum parameter does not specifiy a valid handle.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetCloseEnum( _In_ HANDLE hEnum); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385431(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385431")]
	public static extern Win32Error WNetCloseEnum(HANDLE hEnum);

	/// <summary>
	/// The <c>WNetConnectionDialog</c> function starts a general browsing dialog box for connecting to network resources. The function
	/// requires a handle to the owner window for the dialog box.
	/// </summary>
	/// <param name="hwnd">Handle to the owner window for the dialog box.</param>
	/// <param name="dwType">
	/// <para>Resource type to allow connections to. This parameter can be the following value.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCETYPE_DISK</term>
	/// <term>Connections to disk resources.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR. If the user cancels the dialog box, the function returns –1.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PASSWORD</term>
	/// <term>The specified password is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There is insufficient memory to start the dialog box.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetConnectionDialog( _In_ HWND hwnd, _In_ DWORD dwType); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385433(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385433")]
	public static extern Win32Error WNetConnectionDialog(HWND hwnd, NETRESOURCEType dwType = NETRESOURCEType.RESOURCETYPE_DISK);

	/// <summary>
	/// The <c>WNetConnectionDialog1</c> function brings up a general browsing dialog for connecting to network resources. The function
	/// requires a <c>CONNECTDLGSTRUCT</c> to establish the dialog box parameters.
	/// </summary>
	/// <param name="lpConnDlgStruct">
	/// Pointer to a <c>CONNECTDLGSTRUCT</c> structure. The structure establishes the browsing dialog parameters.
	/// </param>
	/// <returns>
	/// <para>
	/// If the user cancels the dialog box, the function returns –1. If the function is successful, it returns NO_ERROR. Also, if the
	/// call is successful, the <c>dwDevNum</c> member of the <c>CONNECTDLGSTRUCT</c> structure contains the number of the connected device.
	/// </para>
	/// <para>
	/// Typically this dialog returns an error only if the user cannot enter a dialog session. This is because errors that occur after a
	/// dialog session are reported to the user directly. If the function fails, the return value is a system error code, such as one of
	/// the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>
	/// Both the CONNDLG_RO_PATH and the CONNDLG_USE_MRU dialog box options are set. (Dialog box options are specified by the dwFlags
	/// member of the CONNECTDLGSTRUCT structure.) -or-Both the CONNDLG_PERSIST and the CONNDLG_NOT_PERSIST dialog box options are
	/// set.-or-The CONNDLG_RO_PATH dialog box option is set and the lpRemoteName member of the NETRESOURCE structure does not point to a
	/// remote network. (The CONNECTDLGSTRUCT structure points to a NETRESOURCE structure.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEV_TYPE</term>
	/// <term>The dwType member of the NETRESOURCE structure is not set to RESOURCETYPE_DISK.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The network provider is busy (possibly initializing). The caller should retry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There is insufficient memory to display the dialog box.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. Call WNetGetLastError to obtain a description of the error.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetConnectionDialog1( _Inout_ LPCONNECTDLGSTRUCT lpConnDlgStruct); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385436(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385436")]
	public static extern Win32Error WNetConnectionDialog1(in CONNECTDLGSTRUCT lpConnDlgStruct);

	/// <summary>
	/// The <c>WNetDisconnectDialog</c> function starts a general browsing dialog box for disconnecting from network resources. The
	/// function requires a handle to the owner window for the dialog box.
	/// </summary>
	/// <param name="hwnd">Handle to the owner window for the dialog box.</param>
	/// <param name="dwType">
	/// <para>Resource type to disconnect from. This parameter can have the following value.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCETYPE_DISK</term>
	/// <term>Disconnects from disk resources.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR. If the user cancels the dialog box, the return value is –1.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There is insufficient memory to start the dialog box.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetDisconnectDialog( _In_ HWND hwnd, _In_ DWORD dwType); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385440(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385440")]
	public static extern Win32Error WNetDisconnectDialog(HWND hwnd, NETRESOURCEType dwType = NETRESOURCEType.RESOURCETYPE_DISK);

	/// <summary>
	/// The <c>WNetDisconnectDialog1</c> function attempts to disconnect a network resource. If the underlying network returns
	/// ERROR_OPEN_FILES, the function prompts the user for confirmation. If there is any error, the function informs the user. The
	/// function requires a <c>DISCDLGSTRUCT</c> to specify the parameters for the disconnect attempt.
	/// </summary>
	/// <param name="lpConnDlgStruct">
	/// Pointer to a <c>DISCDLGSTRUCT</c> structure. The structure specifies the behavior for the disconnect attempt.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR. If the user cancels the dialog box, the return value is –1.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>When the system prompted the user for a decision about disconnecting, the user elected not to disconnect.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OPEN_FILES</term>
	/// <term>Unable to disconnect because the user is actively using the connection.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUSY</term>
	/// <term>The network provider is busy (possibly initializing). The caller should retry.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>There is insufficient memory to start the dialog box.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. Call the WNetGetLastError function to obtain a description of the error.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetDisconnectDialog1( _In_ LPDISCDLGSTRUCT lpConnDlgStruct); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385443(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385443")]
	public static extern Win32Error WNetDisconnectDialog1(in DISCDLGSTRUCT lpConnDlgStruct);

	/// <summary>
	/// The <c>WNetEnumResource</c> function continues an enumeration of network resources that was started by a call to the
	/// <c>WNetOpenEnum</c> function.
	/// </summary>
	/// <param name="hEnum">
	/// Handle that identifies an enumeration instance. This handle must be returned by the <c>WNetOpenEnum</c> function.
	/// </param>
	/// <param name="lpcCount">
	/// <para>
	/// Pointer to a variable specifying the number of entries requested. If the number requested is –1, the function returns as many
	/// entries as possible.
	/// </para>
	/// <para>
	/// If the function succeeds, on return the variable pointed to by this parameter contains the number of entries actually read.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>
	/// Pointer to the buffer that receives the enumeration results. The results are returned as an array of <c>NETRESOURCE</c>
	/// structures. Note that the buffer you allocate must be large enough to hold the structures, plus the strings to which their
	/// members point. For more information, see the following Remarks section.
	/// </para>
	/// <para>
	/// The buffer is valid until the next call using the handle specified by the hEnum parameter. The order of <c>NETRESOURCE</c>
	/// structures in the array is not predictable.
	/// </para>
	/// </param>
	/// <param name="lpBufferSize">
	/// Pointer to a variable that specifies the size of the lpBuffer parameter, in bytes. If the buffer is too small to receive even one
	/// entry, this parameter receives the required size of the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>NO_ERROR</term>
	/// <term>
	/// The enumeration succeeded, and the buffer contains the requested data. The calling application can continue to call
	/// WNetEnumResource to complete the enumeration.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There are no more entries. The buffer contents are undefined.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>More entries are available with subsequent calls. For more information, see the following Remarks section.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The handle specified by the hEnum parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable. (This condition is tested before hEnum is tested for validity.)</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetEnumResource( _In_ HANDLE hEnum, _Inout_ LPDWORD lpcCount, _Out_ LPVOID lpBuffer, _Inout_ LPDWORD lpBufferSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385449(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385449")]
	public static extern Win32Error WNetEnumResource(SafeWNetEnumHandle hEnum, ref int lpcCount, IntPtr lpBuffer, ref uint lpBufferSize);

	/// <summary>The <c>WNetGetConnection</c> function retrieves the name of the network resource associated with a local device.</summary>
	/// <param name="lpLocalName">
	/// Pointer to a constant null-terminated string that specifies the name of the local device to get the network name for.
	/// </param>
	/// <param name="lpRemoteName">Pointer to a null-terminated string that receives the remote name used to make the connection.</param>
	/// <param name="lpnLength">
	/// Pointer to a variable that specifies the size of the buffer pointed to by the lpRemoteName parameter, in characters. If the
	/// function fails because the buffer is not large enough, this parameter returns the required buffer size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_DEVICE</term>
	/// <term>The string pointed to by the lpLocalName parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_CONNECTED</term>
	/// <term>The device specified by lpLocalName is not a redirected device. For more information, see the following Remarks section.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The buffer is too small. The lpnLength parameter points to a variable that contains the required buffer size. More entries are
	/// available with subsequent calls.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_CONNECTION_UNAVAIL</term>
	/// <term>
	/// The device is not currently connected, but it is a persistent connection. For more information, see the following Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>
	/// None of the providers recognize the local name as having a connection. However, the network is not available for at least one
	/// provider to whom the connection may belong.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetGetConnection( _In_ LPCTSTR lpLocalName, _Out_ LPTSTR lpRemoteName, _Inout_ LPDWORD lpnLength); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385453(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385453")]
	public static extern Win32Error WNetGetConnection(string lpLocalName, StringBuilder? lpRemoteName, ref uint lpnLength);

	/// <summary>
	/// The <c>WNetGetLastError</c> function retrieves the most recent extended error code set by a WNet function. The network provider
	/// reported this error code; it will not generally be one of the errors included in the SDK header file WinError.h.
	/// </summary>
	/// <param name="lpError">
	/// Pointer to a variable that receives the error code reported by the network provider. The error code is specific to the network provider.
	/// </param>
	/// <param name="lpErrorBuf">Pointer to the buffer that receives the null-terminated string describing the error.</param>
	/// <param name="nErrorBufSize">
	/// Size of the buffer pointed to by the lpErrorBuf parameter, in characters. If the buffer is too small for the error string, the
	/// string is truncated but still null-terminated. A buffer of at least 256 characters is recommended.
	/// </param>
	/// <param name="lpNameBuf">
	/// Pointer to the buffer that receives the null-terminated string identifying the network provider that raised the error.
	/// </param>
	/// <param name="nNameBufSize">
	/// Size of the buffer pointed to by the lpNameBuf parameter, in characters. If the buffer is too small for the error string, the
	/// string is truncated but still null-terminated.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, and it obtains the last error that the network provider reported, the return value is NO_ERROR.</para>
	/// <para>If the caller supplies an invalid buffer, the return value is ERROR_INVALID_ADDRESS.</para>
	/// </returns>
	// DWORD WNetGetLastError( _Out_ LPDWORD lpError, _Out_ LPTSTR lpErrorBuf, _In_ DWORD nErrorBufSize, _Out_ LPTSTR lpNameBuf, _In_
	// DWORD nNameBufSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385459(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385459")]
	public static extern Win32Error WNetGetLastError(out uint lpError, StringBuilder lpErrorBuf, uint nErrorBufSize, StringBuilder lpNameBuf, uint nNameBufSize);

	/// <summary>
	/// The <c>WNetGetNetworkInformation</c> function returns extended information about a specific network provider whose name was
	/// returned by a previous network enumeration.
	/// </summary>
	/// <param name="lpProvider">
	/// Pointer to a constant null-terminated string that contains the name of the network provider for which information is required.
	/// </param>
	/// <param name="lpNetInfoStruct">Pointer to a <c>NETINFOSTRUCT</c> structure. The structure describes characteristics of the network.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_PROVIDER</term>
	/// <term>The lpProvider parameter does not match any running network provider.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_VALUE</term>
	/// <term>The cbStructure member of the NETINFOSTRUCT structure does not contain a valid structure size.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetGetNetworkInformation( _In_ LPCTSTR lpProvider, _Out_ LPNETINFOSTRUCT lpNetInfoStruct); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385461(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385461")]
	public static extern Win32Error WNetGetNetworkInformation(string lpProvider, ref NETINFOSTRUCT lpNetInfoStruct);

	/// <summary>The <c>WNetGetProviderName</c> function obtains the provider name for a specific type of network.</summary>
	/// <param name="dwNetType">
	/// <para>
	/// Network type that is unique to the network. If two networks claim the same type, the function returns the name of the provider
	/// loaded first. Only the high word of the network type is used. If a network reports a subtype in the low word, it is ignored.
	/// </para>
	/// <para>You can find a complete list of network types in the header file Winnetwk.h.</para>
	/// </param>
	/// <param name="lpProviderName">Pointer to a buffer that receives the network provider name.</param>
	/// <param name="lpBufferSize">
	/// <para>
	/// Size of the buffer passed to the function, in characters. If the return value is ERROR_MORE_DATA, lpBufferSize returns the buffer
	/// size required (in characters) to hold the provider name.
	/// </para>
	/// <para>
	/// <c>Windows Me/98/95:</c> The size of the buffer is in bytes, not characters. Also, the buffer must be at least 1 byte long.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer is too small to hold the network provider name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_ADDRESS</term>
	/// <term>The lpProviderName parameter or the lpBufferSize parameter is invalid.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetGetProviderName( _In_ DWORD dwNetType, _Out_ LPTSTR lpProviderName, _Inout_ LPDWORD lpBufferSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385464(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385464")]
	public static extern Win32Error WNetGetProviderName(WNNC_NET dwNetType, StringBuilder? lpProviderName, ref uint lpBufferSize);

	/// <summary>
	/// When provided with a remote path to a network resource, the <c>WNetGetResourceInformation</c> function identifies the network
	/// provider that owns the resource and obtains information about the type of the resource. The function is typically used in
	/// conjunction with the <c>WNetGetResourceParent</c> function to parse and interpret a network path typed in by a user.
	/// </summary>
	/// <param name="lpNetResource">
	/// <para>Pointer to a <c>NETRESOURCE</c> structure that specifies the network resource for which information is required.</para>
	/// <para>
	/// The <c>lpRemoteName</c> member of the structure should specify the remote path name of the resource, typically one typed in by a
	/// user. The <c>lpProvider</c> and <c>dwType</c> members should also be filled in if known, because this operation can be memory
	/// intensive, especially if you do not specify the <c>dwType</c> member. If you do not know the values for these members, you should
	/// set them to <c>NULL</c>. All other members of the <c>NETRESOURCE</c> structure are ignored.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>
	/// Pointer to the buffer to receive the result. On successful return, the first portion of the buffer is a <c>NETRESOURCE</c>
	/// structure representing that portion of the input resource path that is accessed through the WNet functions, rather than through
	/// system functions specific to the input resource type. (The remainder of the buffer contains the variable-length strings to which
	/// the members of the <c>NETRESOURCE</c> structure point.)
	/// </para>
	/// <para>
	/// For example, if the input remote resource path is \\server\share\dir1\dir2, then the output <c>NETRESOURCE</c> structure contains
	/// information about the resource \\server\share. The \dir1\dir2 portion of the path is accessed through the file management
	/// functions. The <c>lpRemoteName</c>, <c>lpProvider</c>, <c>dwType</c>, <c>dwDisplayType</c>, and <c>dwUsage</c> members of
	/// <c>NETRESOURCE</c> are returned, with all other members set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// The <c>lpRemoteName</c> member is returned in the same syntax as the one returned from an enumeration by the
	/// <c>WNetEnumResource</c> function. This allows the caller to perform a string comparison to determine whether the resource passed
	/// to <c>WNetGetResourceInformation</c> is the same as the resource returned by a separate call to <c>WNetEnumResource</c>.
	/// </para>
	/// </param>
	/// <param name="lpcbBuffer">
	/// Pointer to a location that, on entry, specifies the size of the lpBuffer buffer, in bytes. The buffer you allocate must be large
	/// enough to hold the <c>NETRESOURCE</c> structure, plus the strings to which its members point. If the buffer is too small for the
	/// result, this location receives the required buffer size, and the function returns ERROR_MORE_DATA.
	/// </param>
	/// <param name="lplpSystem">
	/// <para>
	/// If the function returns successfully, this parameter points to a string in the output buffer that specifies the part of the
	/// resource that is accessed through system functions. (This applies only to functions specific to the resource type rather than the
	/// WNet functions.)
	/// </para>
	/// <para>
	/// For example, if the input remote resource name is \\server\share\dir1\dir2, the <c>lpRemoteName</c> member of the output
	/// <c>NETRESOURCE</c> structure points to \\server\share. Also, the lplpSystem parameter points to \dir1\dir2. Both strings are
	/// stored in the buffer pointed to by the lpBuffer parameter.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_NET_NAME</term>
	/// <term>The input lpRemoteName member is not an existing network resource for any network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEV_TYPE</term>
	/// <term>The input dwType member does not match the type of resource specified by the lpRemoteName member.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. Call WNetGetLastError to obtain a description of the error.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer pointed to by the lpBuffer parameter is too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetGetResourceInformation( _In_ LPNETRESOURCE lpNetResource, _Out_ LPVOID lpBuffer, _Inout_ LPDWORD lpcbBuffer, _Out_
	// LPTSTR *lplpSystem); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385469(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385469")]
	public static extern Win32Error WNetGetResourceInformation(NETRESOURCE lpNetResource, IntPtr lpBuffer, ref uint lpcbBuffer, out StrPtrAuto lplpSystem);

	/// <summary>
	/// <para>
	/// The <c>WNetGetResourceParent</c> function returns the parent of a network resource in the network browse hierarchy. Browsing
	/// begins at the location of the specified network resource.
	/// </para>
	/// <para>
	/// Call the <c>WNetGetResourceInformation</c> and <c>WNetGetResourceParent</c> functions to move up the network hierarchy. Call the
	/// <c>WNetOpenEnum</c> function to move down the hierarchy.
	/// </para>
	/// </summary>
	/// <param name="lpNetResource">
	/// <para>Pointer to a <c>NETRESOURCE</c> structure that specifies the network resource for which the parent name is required.</para>
	/// <para>
	/// Specify the members of the input <c>NETRESOURCE</c> structure as follows. The caller typically knows the values to provide for
	/// the <c>lpProvider</c> and <c>dwType</c> members after previous calls to <c>WNetGetResourceInformation</c> or <c>WNetGetResourceParent</c>.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Member</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>dwType</term>
	/// <term>This member should be filled in if known; otherwise, it should be set to NULL.</term>
	/// </item>
	/// <item>
	/// <term>lpRemoteName</term>
	/// <term>This member should specify the remote name of the network resource whose parent is required.</term>
	/// </item>
	/// <item>
	/// <term>lpProvider</term>
	/// <term>
	/// This member should specify the network provider that owns the resource. This member is required; otherwise, the function could
	/// produce incorrect results.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>All other members of the <c>NETRESOURCE</c> structure are ignored.</para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>
	/// Pointer to a buffer to receive a single <c>NETRESOURCE</c> structure that represents the parent resource. The function returns
	/// the <c>lpRemoteName</c>, <c>lpProvider</c>, <c>dwType</c>, <c>dwDisplayType</c>, and <c>dwUsage</c> members of the structure; all
	/// other members are set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// The <c>lpRemoteName</c> member points to the remote name for the parent resource. This name uses the same syntax as the one
	/// returned from an enumeration by the <c>WNetEnumResource</c> function. The caller can perform a string comparison to determine
	/// whether the <c>WNetGetResourceParent</c> resource is the same as that returned by <c>WNetEnumResource</c>. If the input resource
	/// has no parent on any of the networks, the <c>lpRemoteName</c> member is returned as <c>NULL</c>.
	/// </para>
	/// <para>
	/// The presence of the RESOURCEUSAGE_CONNECTABLE bit in the <c>dwUsage</c> member indicates that you can connect to the parent
	/// resource, but only when it is available on the network.
	/// </para>
	/// </param>
	/// <param name="lpcbBuffer">
	/// Pointer to a location that, on entry, specifies the size of the lpBuffer buffer, in bytes. If the buffer is too small to hold the
	/// result, this location receives the required buffer size, and the function returns ERROR_MORE_DATA.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have access to the network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_NET_NAME</term>
	/// <term>The input lpRemoteName member is not an existing network resource for any network.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROVIDER</term>
	/// <term>The input lpProvider member does not match any installed network provider.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer pointed to by the lpBuffer parameter is too small.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_AUTHENTICATED</term>
	/// <term>The caller does not have the necessary permissions to obtain the name of the parent.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetGetResourceParent( _In_ LPNETRESOURCE lpNetResource, _Out_ LPVOID lpBuffer, _Inout_ LPDWORD lpcbBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385470(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385470")]
	public static extern Win32Error WNetGetResourceParent(NETRESOURCE lpNetResource, IntPtr lpBuffer, ref uint lpcbBuffer);

	/// <summary>
	/// The <c>WNetGetUniversalName</c> function takes a drive-based path for a network resource and returns an information structure
	/// that contains a more universal form of the name.
	/// </summary>
	/// <param name="lpLocalPath">
	/// <para>A pointer to a constant null-terminated string that is a drive-based path for a network resource.</para>
	/// <para>
	/// For example, if drive H has been mapped to a network drive share, and the network resource of interest is a file named Sample.doc
	/// in the directory \Win32\Examples on that share, the drive-based path is H:\Win32\Examples\Sample.doc.
	/// </para>
	/// </param>
	/// <param name="dwInfoLevel">
	/// <para>
	/// The type of structure that the function stores in the buffer pointed to by the lpBuffer parameter. This parameter can be one of
	/// the following values defined in the Winnetwk.h header file.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>UNIVERSAL_NAME_INFO_LEVEL</term>
	/// <term>The function stores a UNIVERSAL_NAME_INFO structure in the buffer.</term>
	/// </item>
	/// <item>
	/// <term>REMOTE_NAME_INFO_LEVEL</term>
	/// <term>The function stores a REMOTE_NAME_INFO structure in the buffer.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>The <c>UNIVERSAL_NAME_INFO</c> structure points to a Universal Naming Convention (UNC) name string.</para>
	/// <para>
	/// The <c>REMOTE_NAME_INFO</c> structure points to a UNC name string and two additional connection information strings. For more
	/// information, see the following Remarks section.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">A pointer to a buffer that receives the structure specified by the dwInfoLevel parameter.</param>
	/// <param name="lpBufferSize">
	/// <para>A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the lpBuffer parameter.</para>
	/// <para>
	/// If the function succeeds, it sets the variable pointed to by lpBufferSize to the number of bytes stored in the buffer. If the
	/// function fails because the buffer is too small, this location receives the required buffer size, and the function returns ERROR_MORE_DATA.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_DEVICE</term>
	/// <term>The string pointed to by the lpLocalPath parameter is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CONNECTION_UNAVAIL</term>
	/// <term>There is no current connection to the remote device, but there is a remembered (persistent) connection to it.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. Use the WNetGetLastError function to obtain a description of the error.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The buffer pointed to by the lpBuffer parameter is too small. The function sets the variable pointed to by the lpBufferSize
	/// parameter to the required buffer size. More entries are available with subsequent calls.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED</term>
	/// <term>
	/// The dwInfoLevel parameter is set to UNIVERSAL_NAME_INFO_LEVEL, but the network provider does not support UNC names. (None of the
	/// network providers support this function.)
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>
	/// None of the network providers recognize the local name as having a connection. However, the network is not available for at least
	/// one provider to whom the connection may belong.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_CONNECTED</term>
	/// <term>The device specified by the lpLocalPath parameter is not redirected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetGetUniversalName( _In_ LPCTSTR lpLocalPath, _In_ DWORD dwInfoLevel, _Out_ LPVOID lpBuffer, _Inout_ LPDWORD
	// lpBufferSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385474(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385474")]
	public static extern Win32Error WNetGetUniversalName(string lpLocalPath, INFO_LEVEL dwInfoLevel, IntPtr lpBuffer, ref uint lpBufferSize);

	/// <summary>
	/// The <c>WNetGetUser</c> function retrieves the current default user name, or the user name used to establish a network connection.
	/// </summary>
	/// <param name="lpName">
	/// <para>
	/// A pointer to a constant <c>null</c>-terminated string that specifies either the name of a local device that has been redirected
	/// to a network resource, or the remote name of a network resource to which a connection has been made without redirecting a local device.
	/// </para>
	/// <para>If this parameter is <c>NULL</c> or the empty string, the system returns the name of the current user for the process.</para>
	/// </param>
	/// <param name="lpUserName">A pointer to a buffer that receives the <c>null</c>-terminated user name.</param>
	/// <param name="lpnLength">
	/// A pointer to a variable that specifies the size of the lpUserName buffer, in characters. If the call fails because the buffer is
	/// not large enough, this variable contains the required buffer size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_CONNECTED</term>
	/// <term>The device specified by the lpName parameter is not a redirected device or a connected network name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>More entries are available with subsequent calls.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>
	/// None of the providers recognize the local name as having a connection. However, the network is not available for at least one
	/// provider to whom the connection may belong.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetGetUser( _In_ LPCTSTR lpName, _Out_ LPTSTR lpUserName, _Inout_ LPDWORD lpnLength); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385476(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385476")]
	public static extern Win32Error WNetGetUser([Optional] string? lpName, StringBuilder? lpUserName, ref uint lpnLength);

	/// <summary>
	/// The <c>WNetOpenEnum</c> function starts an enumeration of network resources or existing connections. You can continue the
	/// enumeration by calling the <c>WNetEnumResource</c> function.
	/// </summary>
	/// <param name="dwScope">
	/// <para>Scope of the enumeration. This parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCE_CONNECTED</term>
	/// <term>
	/// Enumerate all currently connected resources. The function ignores the dwUsage parameter. For more information, see the following
	/// Remarks section.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_CONTEXT</term>
	/// <term>
	/// Enumerate only resources in the network context of the caller. Specify this value for a Network Neighborhood view. The function
	/// ignores the dwUsage parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_GLOBALNET</term>
	/// <term>Enumerate all resources on the network.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCE_REMEMBERED</term>
	/// <term>Enumerate all remembered (persistent) connections. The function ignores the dwUsage parameter.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwType">
	/// <para>Resource types to be enumerated. This parameter can be a combination of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCETYPE_ANY</term>
	/// <term>All resources. This value cannot be combined with RESOURCETYPE_DISK or RESOURCETYPE_PRINT.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCETYPE_DISK</term>
	/// <term>All disk resources.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCETYPE_PRINT</term>
	/// <term>All print resources.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>If a network provider cannot distinguish between print and disk resources, it can enumerate all resources.</para>
	/// </param>
	/// <param name="dwUsage">
	/// <para>Resource usage type to be enumerated. This parameter can be a combination of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>All resources.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCEUSAGE_CONNECTABLE</term>
	/// <term>All connectable resources.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCEUSAGE_CONTAINER</term>
	/// <term>All container resources.</term>
	/// </item>
	/// <item>
	/// <term>RESOURCEUSAGE_ATTACHED</term>
	/// <term>
	/// Setting this value forces WNetOpenEnum to fail if the user is not authenticated. The function fails even if the network allows
	/// enumeration without authentication.
	/// </term>
	/// </item>
	/// <item>
	/// <term>RESOURCEUSAGE_ALL</term>
	/// <term>Setting this value is equivalent to setting RESOURCEUSAGE_CONNECTABLE, RESOURCEUSAGE_CONTAINER, and RESOURCEUSAGE_ATTACHED.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>
	/// This parameter is ignored unless the dwScope parameter is equal to RESOURCE_GLOBALNET. For more information, see the following
	/// Remarks section.
	/// </para>
	/// </param>
	/// <param name="lpNetResource">
	/// <para>
	/// Pointer to a <c>NETRESOURCE</c> structure that specifies the container to enumerate. If the dwScope parameter is not
	/// RESOURCE_GLOBALNET, this parameter must be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the root of the network is assumed. (The system organizes a network as a hierarchy; the root is
	/// the topmost container in the network.)
	/// </para>
	/// <para>
	/// If this parameter is not <c>NULL</c>, it must point to a <c>NETRESOURCE</c> structure. This structure can be filled in by the
	/// application or it can be returned by a call to the <c>WNetEnumResource</c> function. The <c>NETRESOURCE</c> structure must
	/// specify a container resource; that is, the RESOURCEUSAGE_CONTAINER value must be specified in the dwUsage parameter.
	/// </para>
	/// <para>
	/// To enumerate all network resources, an application can begin the enumeration by calling <c>WNetOpenEnum</c> with the
	/// lpNetResource parameter set to <c>NULL</c>, and then use the returned handle to call <c>WNetEnumResource</c> to enumerate
	/// resources. If one of the resources in the <c>NETRESOURCE</c> array returned by the <c>WNetEnumResource</c> function is a
	/// container resource, you can call <c>WNetOpenEnum</c> to open the resource for further enumeration.
	/// </para>
	/// </param>
	/// <param name="lphEnum">Pointer to an enumeration handle that can be used in a subsequent call to <c>WNetEnumResource</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_NOT_CONTAINER</term>
	/// <term>The lpNetResource parameter does not point to a container.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Either the dwScope or the dwType parameter is invalid, or there is an invalid combination of parameters.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_ADDRESS</term>
	/// <term>A remote network resource name supplied in the NETRESOURCE structure resolved to an invalid network address.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetOpenEnum( _In_ DWORD dwScope, _In_ DWORD dwType, _In_ DWORD dwUsage, _In_ LPNETRESOURCE lpNetResource, _Out_ LPHANDLE
	// lphEnum); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385478(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385478")]
	public static extern Win32Error WNetOpenEnum(NETRESOURCEScope dwScope, NETRESOURCEType dwType, NETRESOURCEUsage dwUsage, [Optional] NETRESOURCE? lpNetResource, out SafeWNetEnumHandle lphEnum);

	/// <summary>
	/// <para>Sets extended error information. Network providers should call this function instead of SetLastError.</para>
	/// <para>
	/// When necessary, the Multiple Provider Router (MPR) calls SetLastError to set the Windows error returned from a network provider.
	/// </para>
	/// </summary>
	/// <param name="err">
	/// <para>The error that occurred. This is a network-specific error code.</para>
	/// </param>
	/// <param name="lpError">
	/// <para>String that describes the network-specific error.</para>
	/// </param>
	/// <param name="lpProviders">
	/// <para>TBD</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function is implemented by the Windows operating system and can be called by network providers.</para>
	/// <para>
	/// A provider should use this function to report errors that contain provider-specific information. The error information is saved
	/// until it is overwritten by another call to <c>WNetSetLastError</c> in the same thread.
	/// </para>
	/// <para>The recommended way for a provider function to handle general errors is to use the following statement.</para>
	/// <para>
	/// In this statement, providerError is a Windows error code, such as one of the return codes listed for the provider API in this document.
	/// </para>
	/// <para>For provider-specific errors, a provider should do the following.</para>
	/// <para>In this case, providerError is the provider-specific error code.</para>
	/// <para>
	/// Providers do not need to call SetLastError before returning from a provider function. The MPR calls <c>SetLastError</c> to set
	/// the Windows error returned from a provider when necessary to satisfy applications.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/npapi/nf-npapi-wnetsetlasterrora void WNetSetLastErrorA( DWORD err, LPSTR
	// lpError, LPSTR lpProviders );
	[DllImport(Lib.Mpr, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("npapi.h", MSDNShortId = "ee472f01-de44-4c47-9ae5-8bbac74de78b")]
	public static extern void WNetSetLastError(uint err, string lpError, string lpProviders);

	/// <summary>Extension method for WNet function results that handles provider errors (ERROR_EXTENDED_ERROR).</summary>
	/// <param name="err">The error produced by a WNet function.</param>
	/// <param name="message">The message.</param>
	public static void WNetThrowIfFailed(this Win32Error err, string? message = null)
	{
		if (err == Win32Error.ERROR_EXTENDED_ERROR)
		{
			var sbErr = new StringBuilder(1024);
			var sbName = new StringBuilder(1024);
			if (WNetGetLastError(out var provErr, sbErr, (uint)sbErr.Capacity, sbName, (uint)sbName.Capacity).Succeeded)
				throw new NetworkProviderException(provErr, message, sbErr.ToString(), sbName.ToString());
		}
		err.ThrowIfFailed(message);
	}

	/// <summary>
	/// <para>
	/// The <c>WNetUseConnection</c> function makes a connection to a network resource. The function can redirect a local device to a
	/// network resource.
	/// </para>
	/// <para>
	/// The <c>WNetUseConnection</c> function is similar to the <c>WNetAddConnection3</c> function. The main difference is that
	/// <c>WNetUseConnection</c> can automatically select an unused local device to redirect to the network resource.
	/// </para>
	/// </summary>
	/// <param name="hwndOwner">
	/// Handle to a window that the provider of network resources can use as an owner window for dialog boxes. Use this parameter if you
	/// set the CONNECT_INTERACTIVE value in the dwFlags parameter.
	/// </param>
	/// <param name="lpNetResource">
	/// <para>
	/// Pointer to a <c>NETRESOURCE</c> structure that specifies details of the proposed connection. The structure contains information
	/// about the network resource, the local device, and the network resource provider.
	/// </para>
	/// <para>You must specify the following members of the <c>NETRESOURCE</c> structure.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Member</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>dwType</term>
	/// <term>
	/// Specifies the type of resource to connect to. It is most efficient to specify a resource type in this member, such as
	/// RESOURCETYPE_DISK or RESOURCETYPE_PRINT. However, if the lpLocalName member is NULL, or if it points to an empty string and
	/// CONNECT_REDIRECT is not set, dwType can be RESOURCETYPE_ANY.This method works only if the function does not automatically choose
	/// a device to redirect to the network resource.Although this member is required, its information may be ignored by the network
	/// service provider.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpLocalName</term>
	/// <term>
	/// Pointer to a null-terminated string that specifies the name of a local device to be redirected, such as &amp;quot;F:&amp;quot; or
	/// &amp;quot;LPT1&amp;quot;. The string is treated in a case-insensitive manner. If the string is empty, or if lpLocalName is NULL,
	/// a connection to the network occurs without redirection.If the CONNECT_REDIRECT value is set in the dwFlags parameter, or if the
	/// network requires a redirected local device, the function chooses a local device to redirect and returns the name of the device in
	/// the lpAccessName parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpRemoteName</term>
	/// <term>
	/// Pointer to a null-terminated string that specifies the network resource to connect to. The string can be up to MAX_PATH
	/// characters in length, and it must follow the network provider's naming conventions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>lpProvider</term>
	/// <term>
	/// Pointer to a null-terminated string that specifies the network provider to connect to. If lpProvider is NULL, or if it points to
	/// an empty string, the operating system attempts to determine the correct provider by parsing the string pointed to by the
	/// lpRemoteName member. If this member is not NULL, the operating system attempts to make a connection only to the named network
	/// provider.You should set this member only if you know the network provider you want to use. Otherwise, let the operating system
	/// determine which provider the network name maps to.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>
	/// The <c>WNetUseConnection</c> function ignores the other members of the <c>NETRESOURCE</c> structure. For more information, see
	/// the descriptions following for the dwFlags parameter.
	/// </para>
	/// </param>
	/// <param name="lpPassword">
	/// <para>Pointer to a constant <c>null</c>-terminated string that specifies a password to be used in making the network connection.</para>
	/// <para>If lpPassword is <c>NULL</c>, the function uses the current default password associated with the user specified by lpUserID.</para>
	/// <para>If lpPassword points to an empty string, the function does not use a password.</para>
	/// <para>
	/// If the connection fails because of an invalid password and the CONNECT_INTERACTIVE value is set in the dwFlags parameter, the
	/// function displays a dialog box asking the user to type the password.
	/// </para>
	/// </param>
	/// <param name="lpUserID">
	/// <para>Pointer to a constant <c>null</c>-terminated string that specifies a user name for making the connection.</para>
	/// <para>
	/// If lpUserID is <c>NULL</c>, the function uses the default user name. (The user context for the process provides the default user name.)
	/// </para>
	/// <para>
	/// The lpUserID parameter is specified when users want to connect to a network resource for which they have been assigned a user
	/// name or account other than the default user name or account.
	/// </para>
	/// <para>The user-name string represents a security context. It may be specific to a network provider.</para>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Set of bit flags describing the connection. This parameter can be any combination of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CONNECT_INTERACTIVE</term>
	/// <term>If this flag is set, the operating system may interact with the user for authentication purposes.</term>
	/// </item>
	/// <item>
	/// <term>CONNECT_PROMPT</term>
	/// <term>
	/// This flag instructs the system not to use any default settings for user names or passwords without offering the user the
	/// opportunity to supply an alternative. This flag is ignored unless CONNECT_INTERACTIVE is also set.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_REDIRECT</term>
	/// <term>
	/// This flag forces the redirection of a local device when making the connection. If the lpLocalName member of NETRESOURCE specifies
	/// a local device to redirect, this flag has no effect, because the operating system still attempts to redirect the specified
	/// device. When the operating system automatically chooses a local device, the dwType member must not be equal to
	/// RESOURCETYPE_ANY.If this flag is not set, a local device is automatically chosen for redirection only if the network requires a
	/// local device to be redirected.Windows XP: When the system automatically assigns network drive letters, letters are assigned
	/// beginning with Z:, then Y:, and ending with C:. This reduces collision between per-logon drive letters (such as network drive
	/// letters) and global drive letters (such as disk drives). Note that previous releases assigned drive letters beginning with C: and
	/// ending with Z:.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_UPDATE_PROFILE</term>
	/// <term>
	/// This flag instructs the operating system to store the network resource connection. If this bit flag is set, the operating system
	/// automatically attempts to restore the connection when the user logs on. The system remembers only successful connections that
	/// redirect local devices. It does not remember connections that are unsuccessful or deviceless connections. (A deviceless
	/// connection occurs when lpLocalName is NULL or when it points to an empty string.)If this bit flag is clear, the operating system
	/// does not automatically restore the connection at logon.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_COMMANDLINE</term>
	/// <term>
	/// If this flag is set, the operating system prompts the user for authentication using the command line instead of a graphical user
	/// interface (GUI). This flag is ignored unless CONNECT_INTERACTIVE is also set.Windows 2000/NT and Windows Me/98/95: This value is
	/// not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CONNECT_CMD_SAVECRED</term>
	/// <term>
	/// If this flag is set, and the operating system prompts for a credential, the credential should be saved by the credential manager.
	/// If the credential manager is disabled for the caller's logon session, or if the network provider does not support saving
	/// credentials, this flag is ignored. This flag is also ignored unless you set the CONNECT_COMMANDLINE flag.Windows 2000/NT and
	/// Windows Me/98/95: This value is not supported.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpAccessName">
	/// <para>Pointer to a buffer that receives system requests on the connection. This parameter can be <c>NULL</c>.</para>
	/// <para>
	/// If this parameter is specified, and the <c>lpLocalName</c> member of the <c>NETRESOURCE</c> structure specifies a local device,
	/// this buffer receives the local device name. If <c>lpLocalName</c> does not specify a device and the network requires a local
	/// device redirection, or if the CONNECT_REDIRECT value is set, this buffer receives the name of the redirected local device.
	/// </para>
	/// <para>
	/// Otherwise, the name copied into the buffer is that of a remote resource. If specified, this buffer must be at least as large as
	/// the string pointed to by the <c>lpRemoteName</c> member.
	/// </para>
	/// </param>
	/// <param name="lpBufferSize">
	/// Pointer to a variable that specifies the size of the lpAccessName buffer, in characters. If the call fails because the buffer is
	/// not large enough, the function returns the required buffer size in this location. For more information, see the descriptions of
	/// the lpAccessName parameter and the ERROR_MORE_DATA error code in the Return Values section.
	/// </param>
	/// <param name="lpResult">
	/// <para>Pointer to a variable that receives additional information about the connection. This parameter can be the following value.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CONNECT_LOCALDRIVE</term>
	/// <term>
	/// If this flag is set, the connection was made using a local device redirection. If the lpAccessName parameter points to a buffer,
	/// the local device name is copied to the buffer.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, the return value is a system error code, such as one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have access to the network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ALREADY_ASSIGNED</term>
	/// <term>The local device specified by the lpLocalName member is already connected to a network resource.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_DEVICE</term>
	/// <term>The value specified by lpLocalName is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_NET_NAME</term>
	/// <term>
	/// The value specified by the lpRemoteName member is not acceptable to any network resource provider because the resource name is
	/// invalid, or because the named resource cannot be located.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_PROVIDER</term>
	/// <term>The value specified by the lpProvider member does not match any provider.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CANCELLED</term>
	/// <term>
	/// The attempt to make the connection was canceled by the user through a dialog box from one of the network resource providers, or
	/// by a called resource.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_EXTENDED_ERROR</term>
	/// <term>A network-specific error occurred. To obtain a description of the error, call the WNetGetLastError function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_ADDRESS</term>
	/// <term>The caller passed in a pointer to a buffer that could not be accessed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>This error is a result of one of the following conditions:</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PASSWORD</term>
	/// <term>The specified password is invalid and the CONNECT_INTERACTIVE flag is not set.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// The lpAccessName buffer is too small. If a local device is redirected, the buffer needs to be large enough to contain the local
	/// device name. Otherwise, the buffer needs to be large enough to contain either the string pointed to by lpRemoteName, or the name
	/// of the connectable resource whose alias is pointed to by lpRemoteName. If this error is returned, then no connection has been made.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>The operating system cannot automatically choose a local redirection because all the valid local devices are in use.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NET_OR_BAD_PATH</term>
	/// <term>
	/// The operation could not be completed, either because a network component is not started, or because the specified resource name
	/// is not recognized.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_NETWORK</term>
	/// <term>The network is unavailable.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WNetUseConnection( _In_ HWND hwndOwner, _In_ LPNETRESOURCE lpNetResource, _In_ LPCTSTR lpPassword, _In_ LPCTSTR lpUserID,
	// _In_ DWORD dwFlags, _Out_ LPTSTR lpAccessName, _Inout_ LPDWORD lpBufferSize, _Out_ LPDWORD lpResult); https://msdn.microsoft.com/en-us/library/windows/desktop/aa385482(v=vs.85).aspx
	[DllImport(Lib.Mpr, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385482")]
	public static extern Win32Error WNetUseConnection([Optional] HWND hwndOwner, NETRESOURCE lpNetResource, [Optional] string? lpPassword,
		[Optional] string? lpUserID, [Optional] CONNECT dwFlags, [Optional] StringBuilder? lpAccessName, ref uint lpBufferSize, out CONNECT lpResult);

	/// <summary>
	/// The <c>CONNECTDLGSTRUCT</c> structure is used by the <c>WNetConnectionDialog1</c> function to establish browsing dialog box parameters.
	/// </summary>
	// typedef struct { DWORD cbStructure; HWND hwndOwner; LPNETRESOURCE lpConnRes; DWORD dwFlags; DWORD dwDevNum;} CONNECTDLGSTRUCT,
	// *LPCONNECTDLGSTRUCT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa385332(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385332")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CONNECTDLGSTRUCT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the <c>CONNECTDLGSTRUCT</c> structure. The caller must supply this value.</para>
		/// </summary>
		public uint cbStructure;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle to the owner window for the dialog box.</para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>LPNETRESOURCE</c></para>
		/// <para>A pointer to a <c>NETRESOURCE</c> structure.</para>
		/// <para>
		/// If the <c>lpRemoteName</c> member of <c>NETRESOURCE</c> is specified, it will be entered into the path field of the dialog
		/// box. With the exception of the <c>dwType</c> member, all other members of the <c>NETRESOURCE</c> structure must be set to
		/// <c>NULL</c>. The <c>dwType</c> member must be equal to RESOURCETYPE_DISK.
		/// </para>
		/// <para>The system does not support the <c>RESOURCETYPE_PRINT</c> flag for browsing and connecting to print resources.</para>
		/// </summary>
		public IntPtr lpConnRes;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that describe options for the dialog box display. This member can be a combination of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SidTypeUser</term>
		/// <term>The account is a user account.</term>
		/// </item>
		/// <item>
		/// <term>CONNDLG_RO_PATH</term>
		/// <term>
		/// Display a read-only path instead of allowing the user to type in a path. This flag should be set only if the lpRemoteName
		/// member of the NETRESOURCE structure pointed to by lpConnRes member is not NULL (or an empty string), and the CONNDLG_USE_MRU
		/// flag is not set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CONNDLG_CONN_POINT</term>
		/// <term>Internal flag. Do not use.</term>
		/// </item>
		/// <item>
		/// <term>CONNDLG_USE_MRU</term>
		/// <term>Enter the most recently used paths into the combination box. Set this value to simulate the WNetConnectionDialog function.</term>
		/// </item>
		/// <item>
		/// <term>CONNDLG_HIDE_BOX</term>
		/// <term>Show the check box allowing the user to restore the connection at logon.</term>
		/// </item>
		/// <item>
		/// <term>CONNDLG_PERSIST</term>
		/// <term>Restore the connection at logon.</term>
		/// </item>
		/// <item>
		/// <term>CONNDLG_NOT_PERSIST</term>
		/// <term>Do not restore the connection at logon.</term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>For more information, see the following Remarks section.</para>
		/// </summary>
		public CONN_DLG dwFlags;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// If the call to the <c>WNetConnectionDialog1</c> function is successful, this member returns the number of the connected
		/// device. The value is 1 for A:, 2 for B:, 3 for C:, and so on. If the user made a deviceless connection, the value is –1.
		/// </para>
		/// </summary>
		public int dwDevNum;

		/// <summary>Gets an empty instance of the structure with the cbStructure value set.</summary>
		public static CONNECTDLGSTRUCT Empty => new() { cbStructure = (uint)Marshal.SizeOf(typeof(CONNECTDLGSTRUCT)) };
	}

	/// <summary>
	/// The <c>DISCDLGSTRUCT</c> structure is used in the <c>WNetDisconnectDialog1</c> function. The structure contains required
	/// information for the disconnect attempt.
	/// </summary>
	// typedef struct _DISCDLGSTRUCT { DWORD cbStructure; HWND hwndOwner; LPTSTR lpLocalName; LPTSTR lpRemoteName; DWORD dwFlags;}
	// DISCDLGSTRUCT, *LPDISCDLGSTRUCT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa385339(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385339")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DISCDLGSTRUCT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the <c>DISCDLGSTRUCT</c> structure. The caller must supply this value.</para>
		/// </summary>
		public uint cbStructure;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the owner window of the dialog box.</para>
		/// </summary>
		public HWND hwndOwner;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a <c>NULL</c>-terminated string that specifies the local device name that is redirected to the network resource,
		/// such as "F:" or "LPT1".
		/// </para>
		/// </summary>
		public string lpLocalName;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to a <c>NULL</c>-terminated string that specifies the name of the network resource to disconnect. This member can
		/// be NULL if the <c>lpLocalName</c> member is specified. When <c>lpLocalName</c> is specified, the connection to the network
		/// resource redirected from <c>lpLocalName</c> is disconnected.
		/// </para>
		/// </summary>
		public string? lpRemoteName;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A set of bit flags describing the connection. This member can be a combination of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DISC_UPDATE_PROFILE</term>
		/// <term>
		/// If this value is set, the specified connection is no longer a persistent one (automatically restored every time the user logs
		/// on). This flag is valid only if the lpLocalName member specifies a local device.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DISC_NO_FORCE</term>
		/// <term>
		/// If this value is not set, the system applies force when attempting to disconnect from the network resource. This situation
		/// typically occurs when the user has files open over the connection. This value means that the user will be informed if there
		/// are open files on the connection, and asked if he or she still wants to disconnect. If the user wants to proceed, the
		/// disconnect procedure re-attempts with additional force.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public DISC dwFlags;

		/// <summary>Gets an empty instance of the structure with the cbStructure value set.</summary>
		public static DISCDLGSTRUCT Empty => new() { cbStructure = (uint)Marshal.SizeOf(typeof(DISCDLGSTRUCT)) };

		/// <summary>
		/// Initializes a new instance of the <see cref="DISCDLGSTRUCT"/> struct.
		/// </summary>
		/// <param name="localName">Name of the local device.</param>
		/// <param name="updateProfile">if set to <c>true</c> update profile.</param>
		/// <param name="force">if set to <c>true</c> force disconnect.</param>
		public DISCDLGSTRUCT(string localName, bool updateProfile = false, bool force = true)
		{
			cbStructure = (uint)Marshal.SizeOf(typeof(DISCDLGSTRUCT));
			hwndOwner = IntPtr.Zero;
			lpLocalName = localName;
			lpRemoteName = null;
			dwFlags = (updateProfile ? DISC.DISC_UPDATE_PROFILE : 0) | (force ? 0 : DISC.DISC_NO_FORCE);
		}
	}

	/// <summary>
	/// The <c>NETCONNECTINFOSTRUCT</c> structure contains information about the expected performance of a connection used to access a
	/// network resource. The information is returned by the <c>MultinetGetConnectionPerformance</c> function.
	/// </summary>
	// typedef struct _NETCONNECTINFOSTRUCT { DWORD cbStructure; DWORD dwFlags; DWORD dwSpeed; DWORD dwDelay; DWORD dwOptDataSize;}
	// NETCONNECTINFOSTRUCT, *LPNETCONNECTINFOSTRUCT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa385345(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385345")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NETCONNECTINFOSTRUCT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the <c>NETCONNECTINFOSTRUCT</c> structure. The caller must supply this value.</para>
		/// </summary>
		public uint cbStructure;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A set of bit flags describing the connection. This member can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WNCON_FORNETCARD</term>
		/// <term>
		/// In the absence of information about the actual connection, the information returned applies to the performance of the network
		/// card. If this flag is not set, information is being returned for the current connection with the resource, with any routing
		/// degradation taken into consideration.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WNCON_NOTROUTED</term>
		/// <term>
		/// The connection is not being routed. If this flag is not set, the connection may be going through routers that limit
		/// performance. Consequently, if WNCON_FORNETCARD is set, actual performance may be much less than the information returned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WNCON_SLOWLINK</term>
		/// <term>
		/// The connection is over a medium that is typically slow (for example, over a modem using a normal quality phone line). You
		/// should not set the WNCON_SLOWLINK bit if the dwSpeed member is set to a nonzero value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WNCON_DYNAMIC</term>
		/// <term>
		/// Some of the information returned is calculated dynamically, so reissuing this request may return different (and more current) information.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public WNCON dwFlags;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Speed of the media to the network resource, in 100 bits-per-second (bps).</para>
		/// <para>
		/// For example, a 1200 baud point-to-point link returns 12. A value of zero indicates that no information is available. A value
		/// of one indicates that the actual value is greater than the maximum that can be represented by the member.
		/// </para>
		/// </summary>
		public uint dwSpeed;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// One-way delay time that the network introduces when sending information, in milliseconds. (The delay is the time between when
		/// the network begins sending data and the time that the data starts being received.) This delay is in addition to any latency
		/// incorporated in the calculation of the <c>dwSpeed</c> member; therefore the value of this member is zero for most resources.
		/// </para>
		/// <para>
		/// A value of zero indicates that no information is available. A value of one indicates that the actual value is greater than
		/// the maximum that can be represented by the member.
		/// </para>
		/// </summary>
		public uint dwDelay;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Size of data that an application should use when making a single request to the network resource, in bytes.</para>
		/// <para>
		/// For example, for a disk network resource, this value might be 2048 or 512 when writing a block of data. A value of zero
		/// indicates that no information is available.
		/// </para>
		/// </summary>
		public uint dwOptDataSize;

		/// <summary>Gets an empty instance of the structure with the cbStructure value set.</summary>
		public static NETCONNECTINFOSTRUCT Empty => new() { cbStructure = (uint)Marshal.SizeOf(typeof(NETCONNECTINFOSTRUCT)) };
	}

	/// <summary>
	/// The <c>NETINFOSTRUCT</c> structure contains information describing the network provider returned by the
	/// <c>WNetGetNetworkInformation</c> function.
	/// </summary>
	// typedef struct _NETINFOSTRUCT { DWORD cbStructure; DWORD dwProviderVersion; DWORD dwStatus; DWORD dwCharacteristics; ULONG_PTR
	// dwHandle; WORD wNetType; DWORD dwPrinters; DWORD dwDrives;} NETINFOSTRUCT, *LPNETINFOSTRUCT; https://msdn.microsoft.com/en-us/library/windows/desktop/aa385349(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385349")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct NETINFOSTRUCT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in bytes, of the <c>NETINFOSTRUCT</c> structure. The caller must supply this value to indicate the size of the
		/// structure passed in. Upon return, it has the size of the structure filled in.
		/// </para>
		/// </summary>
		public uint cbStructure;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The version number of the network provider software.</para>
		/// </summary>
		public uint dwProviderVersion;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The current status of the network provider software. This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NO_ERROR</term>
		/// <term>The network is running.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_NETWORK</term>
		/// <term>The network is unavailable.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_BUSY</term>
		/// <term>
		/// The network is not currently able to service requests, but it should become available shortly. (This value typically
		/// indicates that the network is starting up.)
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public Win32Error dwStatus;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Characteristics of the network provider software. This value is zero.</para>
		/// <para><c>Windows Me/98/95:</c> This member can be one or more of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>NETINFO_DLL16</term>
		/// <term>The network provider is running as a 16-bit Windows network driver.</term>
		/// </item>
		/// <item>
		/// <term>NETINFO_DISKRED</term>
		/// <term>The network provider requires a redirected local disk drive device to access server file systems.</term>
		/// </item>
		/// <item>
		/// <term>NETINFO_PRINTERRED</term>
		/// <term>The network provider requires a redirected local printer port to access server file systems.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public NETINFO dwCharacteristics;

		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>An instance handle for the network provider or for the 16-bit Windows network driver.</para>
		/// </summary>
		public IntPtr dwHandle;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>
		/// The network type unique to the running network. This value associates resources with a specific network when the resources
		/// are persistent or stored in links. You can find a complete list of network types in the header file Winnetwk.h.
		/// </para>
		/// </summary>
		public ushort wNetType;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags indicating the valid print numbers for redirecting local printer devices, with the low-order bit
		/// corresponding to LPT1.
		/// </para>
		/// <para><c>Windows Me/98/95:</c> This value is always set to –1.</para>
		/// </summary>
		public uint dwPrinters;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags indicating the valid local disk devices for redirecting disk drives, with the low-order bit corresponding
		/// to A:.
		/// </para>
		/// <para><c>Windows Me/98/95:</c> This value is always set to –1.</para>
		/// </summary>
		public uint dwDrives;

		/// <summary>Gets an empty instance of the structure with the cbStructure value set.</summary>
		public static NETINFOSTRUCT Empty => new() { cbStructure = (uint)Marshal.SizeOf(typeof(NETINFOSTRUCT)) };
	}

	/// <summary>The <c>NETRESOURCE</c> structure contains information about a network resource.</summary>
	// typedef struct _NETRESOURCE { DWORD dwScope; DWORD dwType; DWORD dwDisplayType; DWORD dwUsage; LPTSTR lpLocalName; LPTSTR
	// lpRemoteName; LPTSTR lpComment; LPTSTR lpProvider;} NETRESOURCE; https://msdn.microsoft.com/en-us/library/windows/desktop/aa385353(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385353")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public class NETRESOURCE
	{
		/// <summary>The scope of the enumeration.</summary>
		public NETRESOURCEScope dwScope;

		/// <summary>The type of resource.</summary>
		public NETRESOURCEType dwType;

		/// <summary>The display options for the network object in a network browsing user interface.</summary>
		public NETRESOURCEDisplayType dwDisplayType;

		/// <summary>
		/// A set of bit flags describing how the resource can be used. Note that this member can be specified only if the dwScope member
		/// is equal to RESOURCE_GLOBALNET.
		/// </summary>
		public NETRESOURCEUsage dwUsage;

		/// <summary>
		/// If the dwScope member is equal to RESOURCE_CONNECTED or RESOURCE_REMEMBERED, this member is a pointer to a null-terminated
		/// character string that specifies the name of a local device. This member is NULL if the connection does not use a device.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]
		public string? lpLocalName;

		/// <summary>
		/// If the entry is a network resource, this member is a pointer to a null-terminated character string that specifies the remote
		/// network name.
		/// <para>
		/// If the entry is a current or persistent connection, lpRemoteName member points to the network name associated with the name
		/// pointed to by the lpLocalName member.
		/// </para>
		/// <para>The string can be MAX_PATH characters in length, and it must follow the network provider's naming conventions.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]
		public string lpRemoteName;

		/// <summary>A pointer to a NULL-terminated string that contains a comment supplied by the network provider.</summary>
		[MarshalAs(UnmanagedType.LPTStr, SizeConst = 1024)]
		public string? lpComment;

		/// <summary>
		/// A pointer to a NULL-terminated string that contains the name of the provider that owns the resource. This member can be NULL
		/// if the provider name is unknown. To retrieve the provider name, you can call the WNetGetProviderName function.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr, SizeConst = 260)]
		public string? lpProvider;

		/// <summary>The root network resource.</summary>
		public static readonly NETRESOURCE Root = new();

		/// <summary>Initializes a new instance of the <see cref="NETRESOURCE"/> class.</summary>
		public NETRESOURCE() => lpRemoteName = string.Empty;

		/// <summary>Initializes a new instance of the <see cref="NETRESOURCE"/> class.</summary>
		/// <param name="remoteName">
		/// The network resource to connect to. The string can be up to MAX_PATH characters in length, and must follow the network
		/// provider's naming conventions.
		/// </param>
		/// <param name="localName">
		/// The name of a local device to redirect, such as "F:" or "LPT1". The string is treated in a case-insensitive manner.
		/// <para>
		/// If the string is empty, or if lpLocalName is NULL, the function makes a connection to the network resource without
		/// redirecting a local device.
		/// </para>
		/// </param>
		/// <param name="provider">
		/// The network provider to connect to.
		/// <para>
		/// If lpProvider is NULL, or if it points to an empty string, the operating system attempts to determine the correct provider by
		/// parsing the string pointed to by the lpRemoteName member.
		/// </para>
		/// <para>If this member is not NULL, the operating system attempts to make a connection only to the named network provider.</para>
		/// <para>
		/// You should set this member only if you know the network provider you want to use.Otherwise, let the operating system
		/// determine which provider the network name maps to.
		/// </para>
		/// </param>
		public NETRESOURCE(string remoteName, string? localName = null, string? provider = null)
		{
			lpLocalName = localName;
			lpRemoteName = remoteName;
			lpProvider = provider;
			dwType = NETRESOURCEType.RESOURCETYPE_DISK;
		}
	}

	/// <summary>
	/// The <c>REMOTE_NAME_INFO</c> structure contains path and name information for a network resource. The structure contains a member
	/// that points to a Universal Naming Convention (UNC) name string for the resource, and two members that point to additional network
	/// connection information strings.
	/// </summary>
	// typedef struct _REMOTE_NAME_INFO { LPTSTR lpUniversalName; LPTSTR lpConnectionName; LPTSTR lpRemainingPath;} REMOTE_NAME_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/aa385366(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385366")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct REMOTE_NAME_INFO
	{
		/// <summary>Pointer to the null-terminated UNC name string that identifies a network resource.</summary>
		public string lpUniversalName;

		/// <summary>
		/// Pointer to a null-terminated string that is the name of a network connection. For more information, see the following Remarks section.
		/// </summary>
		public string lpConnectionName;

		/// <summary>Pointer to a null-terminated name string. For more information, see the following Remarks section.</summary>
		public string lpRemainingPath;
	}

	/// <summary>
	/// The <c>UNIVERSAL_NAME_INFO</c> structure contains a pointer to a Universal Naming Convention (UNC) name string for a network resource.
	/// </summary>
	// typedef struct _UNIVERSAL_NAME_INFO { LPTSTR lpUniversalName;} UNIVERSAL_NAME_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/aa385379(v=vs.85).aspx
	[PInvokeData("Winnetwk.h", MSDNShortId = "aa385379")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct UNIVERSAL_NAME_INFO
	{
		/// <summary>Pointer to the null-terminated UNC name string that identifies a network resource.</summary>
		public string lpUniversalName;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to a WNet enumeration that releases a created WNetEnumHandle instance at disposal using WNetCloseEnum.</summary>
	public class SafeWNetEnumHandle : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeWNetEnumHandle"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle"><see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).</param>
		public SafeWNetEnumHandle(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeWNetEnumHandle"/> class.</summary>
		private SafeWNetEnumHandle() : base() { }

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => WNetCloseEnum(handle).Succeeded;
	}

	/// <summary>A provider exception for WNet functions.</summary>
	/// <seealso cref="System.Exception"/>
	[Serializable]
	public class NetworkProviderException : Exception
	{
		private NetworkProviderException() { Description = Provider = string.Empty; }

		/// <summary>Initializes a new instance of the <see cref="NetworkProviderException"/> class.</summary>
		/// <param name="info">
		/// The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception
		/// being thrown.
		/// </param>
		/// <param name="context">
		/// The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.
		/// </param>
		protected NetworkProviderException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			Description = info.GetString("Description") ?? string.Empty;
			Provider = info.GetString("Provider") ?? string.Empty;
			ProviderErrorCode = info.GetUInt32("ProviderErrorCode");
		}

		internal NetworkProviderException(uint provErr, string? message, string description, string provider) :
			base(message, new Win32Exception(unchecked((int)Win32Error.ERROR_EXTENDED_ERROR)))
		{
			ProviderErrorCode = provErr;
			Description = description;
			Provider = provider;
		}

		/// <summary>Gets the provider's description of the error.</summary>
		/// <value>The description.</value>
		[DefaultValue("")]
		public string Description { get; }

		/// <summary>Gets the network provider's name.</summary>
		/// <value>The provider.</value>
		[DefaultValue("")]
		public string Provider { get; }

		/// <summary>Gets the error code reported by the provider.</summary>
		/// <value>The provider error code.</value>
		[DefaultValue(0)]
		public uint ProviderErrorCode { get; }

		/// <summary>
		/// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="ArgumentNullException">info</exception>
		/// <PermissionSet>
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
		/// </PermissionSet>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info is null) throw new ArgumentNullException(nameof(info));
			info.AddValue("Description", Description);
			info.AddValue("Provider", Provider);
			info.AddValue("ProviderErrorCode", ProviderErrorCode);
			base.GetObjectData(info, context);
		}
	}
}