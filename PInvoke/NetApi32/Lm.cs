using System;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from netapi32.h</summary>
	public static partial class NetApi32
	{
		/// <summary>
		/// A constant of type DWORD that is set to –1. This value is valid as an input parameter to any method that takes a PreferedMaximumLength parameter.
		/// When specified as an input parameter, this value indicates that the method MUST allocate as much space as the data requires.
		/// </summary>
		public const int MAX_PREFERRED_LENGTH = -1;

		/// <summary>Filters used by <see cref="NetServerEnum(string, int, out SafeNetApiBuffer, int, out int, out int, NetServerEnumFilter, string, IntPtr)"/>.</summary>
		[Flags]
		[PInvokeData("lm.h", MSDNShortId = "aa370623")]
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

		/// <summary>The information level to use for platform-specific information.</summary>
		[PInvokeData("lm.h", MSDNShortId = "aa370903")]
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

		/// <summary>
		/// The NetApiBufferFree function frees the memory that the NetApiBufferAllocate function allocates. Applications should also call NetApiBufferFree to
		/// free the memory that other network management functions use internally to return information.
		/// </summary>
		/// <param name="pBuf">
		/// A pointer to a buffer returned previously by another network management function or memory allocated by calling the NetApiBufferAllocate function.
		/// </param>
		/// <returns>If the function succeeds, the return value is NERR_Success. If the function fails, the return value is a system error code.</returns>
		[DllImport(Lib.NetApi32, ExactSpelling = true), SuppressUnmanagedCodeSecurity]
		[PInvokeData("lm.h", MSDNShortId = "aa370304")]
		public static extern Win32Error NetApiBufferFree(IntPtr pBuf);

		/// <summary>The NetServerEnum function lists all servers of the specified type that are visible in a domain.</summary>
		/// <param name="servernane">Reserved; must be NULL.</param>
		/// <param name="level">The information level of the data requested.</param>
		/// <param name="bufptr">
		/// A pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is allocated by the
		/// system and must be freed using the NetApiBufferFree function. Note that you must free the buffer even if the function fails with ERROR_MORE_DATA.
		/// </param>
		/// <param name="prefmaxlen">
		/// The preferred maximum length of returned data, in bytes. If you specify MAX_PREFERRED_LENGTH, the function allocates the amount of memory required
		/// for the data. If you specify another value in this parameter, it can restrict the number of bytes that the function returns. If the buffer size is
		/// insufficient to hold all entries, the function returns ERROR_MORE_DATA. For more information, see Network Management Function Buffers and Network
		/// Management Function Buffer Lengths.
		/// </param>
		/// <param name="entriesread">A pointer to a value that receives the count of elements actually enumerated.</param>
		/// <param name="totalentries">
		/// A pointer to a value that receives the total number of visible servers and workstations on the network. Note that applications should consider this
		/// value only as a hint.
		/// </param>
		/// <param name="servertype">A value that filters the server entries to return from the enumeration.</param>
		/// <param name="domain">
		/// A pointer to a constant string that specifies the name of the domain for which a list of servers is to be returned. The domain name must be a NetBIOS
		/// domain name (for example, microsoft). The NetServerEnum function does not support DNS-style names (for example, microsoft.com). If this parameter is
		/// NULL, the primary domain is implied.
		/// </param>
		/// <param name="resume_handle">Reserved; must be set to zero.</param>
		/// <returns>If the function succeeds, the return value is NERR_Success.</returns>
		[DllImport(Lib.NetApi32, ExactSpelling = true, CharSet = CharSet.Unicode), SuppressUnmanagedCodeSecurity]
		[PInvokeData("lm.h", MSDNShortId = "aa370623")]
		public static extern Win32Error NetServerEnum(
			[MarshalAs(UnmanagedType.LPWStr)] string servernane, // must be null
			int level,
			out SafeNetApiBuffer bufptr,
			int prefmaxlen,
			out int entriesread,
			out int totalentries,
			NetServerEnumFilter servertype,
			[MarshalAs(UnmanagedType.LPWStr)] string domain, // null for login domain
			IntPtr resume_handle // Must be IntPtr.Zero
			);

		/// <summary>The NetServerGetInfo function retrieves current configuration information for the specified server.</summary>
		/// <param name="servername">
		/// Pointer to a string that specifies the name of the remote server on which the function is to execute. If this parameter is NULL, the local computer
		/// is used.
		/// </param>
		/// <param name="level">Specifies the information level of the data.</param>
		/// <param name="bufptr">
		/// Pointer to the buffer that receives the data. The format of this data depends on the value of the level parameter. This buffer is allocated by the
		/// system and must be freed using the NetApiBufferFree function.
		/// </param>
		/// <returns>If the function succeeds, the return value is NERR_Success.</returns>
		[DllImport(Lib.NetApi32, ExactSpelling = true)]
		[PInvokeData("lm.h", MSDNShortId = "aa370624")]
		public static extern Win32Error NetServerGetInfo([MarshalAs(UnmanagedType.LPWStr)] string servername, int level, out SafeNetApiBuffer bufptr);

		/// <summary>The <c>SERVER_INFO_100</c> structure contains information about the specified server, including the name and platform.</summary>
		/// <seealso cref="INetServerInfo"/>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("lm.h", MSDNShortId = "aa370897")]
		public struct SERVER_INFO_100 : INetServerInfo
		{
			/// <summary>The information level to use for platform-specific information.</summary>
			public ServerPlatform sv100_platform_id;
			/// <summary>A pointer to a Unicode string that specifies the name of the server.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string sv100_name;
		}

		/// <summary>
		/// The <c>SERVER_INFO_101</c> structure contains information about the specified server, including name, platform, type of server, and associated software.
		/// </summary>
		/// <seealso cref="INetServerInfo"/>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("lm.h", MSDNShortId = "aa370903")]
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
			/// The major release version number of the operating system is specified in the least significant 4 bits. The server type is specified in the most
			/// significant 4 bits. The <c>MAJOR_VERSION_MASK</c> bitmask defined in the Lmserver.h header should be used by an application to obtain the major
			/// version number from this member.
			/// </para>
			/// </summary>
			public int sv101_version_major;
			/// <summary>The minor release version number of the operating system.</summary>
			public int sv101_version_minor;
			/// <summary>The type of software the computer is running.</summary>
			public NetServerEnumFilter sv101_type;
			/// <summary>A pointer to a Unicode string specifying a comment describing the server. The comment can be null.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string sv101_comment;

			/// <summary>Gets the version composed of both <see cref="sv101_version_major"/> and <see cref="sv101_version_minor"/>.</summary>
			/// <value>The version.</value>
			public Version Version => new Version(sv101_version_major, sv101_version_minor);
		}

		/// <summary>
		/// The SERVER_INFO_102 structure contains information about the specified server, including name, platform, type of server, attributes, and associated software.
		/// </summary>
		/// <seealso cref="INetServerInfo"/>
		[StructLayout(LayoutKind.Sequential)]
		[PInvokeData("lm.h", MSDNShortId = "aa370904")]
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
			/// The major release version number of the operating system is specified in the least significant 4 bits. The server type is specified in the most
			/// significant 4 bits. The <c>MAJOR_VERSION_MASK</c> bitmask defined in the Lmserver.h header should be used by an application to obtain the major
			/// version number from this member.
			/// </para>
			/// </summary>
			public int sv102_version_major;
			/// <summary>The minor release version number of the operating system.</summary>
			public int sv102_version_minor;
			/// <summary>The type of software the computer is running.</summary>
			public NetServerEnumFilter sv102_type;
			/// <summary>A pointer to a Unicode string specifying a comment describing the server. The comment can be null.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string sv102_comment;
			/// <summary>
			/// The number of users who can attempt to log on to the system server. Note that it is the license server that determines how many of these users
			/// can actually log on.
			/// </summary>
			public int sv102_users;
			/// <summary>
			/// The auto-disconnect time, in minutes. A session is disconnected if it is idle longer than the period of time specified by the sv102_disc member.
			/// If the value of sv102_disc is SV_NODISC, auto-disconnect is not enabled.
			/// </summary>
			public int sv102_disc;
			/// <summary>A value that indicates whether the server is visible to other computers in the same network domain.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool sv102_hidden;
			/// <summary>The network announce rate, in seconds. This rate determines how often the server is announced to other computers on the network.</summary>
			public int sv102_announce;
			/// <summary>
			/// The delta value for the announce rate, in milliseconds. This value specifies how much the announce rate can vary from the period of time
			/// specified in the sv102_announce member.
			/// <para>
			/// The delta value allows randomly varied announce rates. For example, if the sv102_announce member has the value 10 and the sv102_anndelta member
			/// has the value 1, the announce rate can vary from 9.999 seconds to 10.001 seconds.
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
			public Version Version => new Version(sv102_version_major, sv102_version_minor);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for buffers that must be freed using <see cref="NetApiBufferFree(IntPtr)"/>.</summary>
		/// <seealso cref="GenericSafeHandle"/>
		[PInvokeData("lm.h")]
		public class SafeNetApiBuffer : GenericSafeHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeNetApiBuffer"/> class.</summary>
			public SafeNetApiBuffer() : this(IntPtr.Zero) { }

			/// <summary>Initializes a new instance of the <see cref="SafeNetApiBuffer"/> class with an existing pointer.</summary>
			/// <param name="ptr">The pointer to the buffer.</param>
			/// <param name="own">if set to <c>true</c> this <see cref="SafeHandle"/> will release the buffer behind the pointer when its scope ends.</param>
			public SafeNetApiBuffer(IntPtr ptr, bool own = true) : base(ptr, h => NetApiBufferFree(h) == 0, own) { }

			/// <summary>Returns an extracted structure from this buffer.</summary>
			/// <typeparam name="T">The structure type to extract.</typeparam>
			/// <returns>Extracted structure or default(T) if the buffer is invalid.</returns>
			public T ToStructure<T>() where T : struct => IsInvalid ? default(T) : (T)Marshal.PtrToStructure(handle, typeof(T));
		}
	}
}