using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class IpHlpApi
	{
		/// <summary>
		/// <para>
		/// The <c>TCP_TABLE_CLASS</c> enumeration defines the set of values used to indicate the type of table returned by calls to GetExtendedTcpTable.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>TCP_TABLE_CLASS</c> enumeration is defined in the Iprtrmib.h header file, not in the Iphlpapi.h header
		/// file. Note that the Iprtrmib.h header file is automatically included in Iphlpapi.h header file. The Iprtrmib.h header files
		/// should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iprtrmib/ne-iprtrmib-_tcp_table_class typedef enum _TCP_TABLE_CLASS {
		// TCP_TABLE_BASIC_LISTENER , TCP_TABLE_BASIC_CONNECTIONS , TCP_TABLE_BASIC_ALL , TCP_TABLE_OWNER_PID_LISTENER ,
		// TCP_TABLE_OWNER_PID_CONNECTIONS , TCP_TABLE_OWNER_PID_ALL , TCP_TABLE_OWNER_MODULE_LISTENER , TCP_TABLE_OWNER_MODULE_CONNECTIONS ,
		// TCP_TABLE_OWNER_MODULE_ALL } TCP_TABLE_CLASS, *PTCP_TABLE_CLASS;
		[PInvokeData("iprtrmib.h", MSDNShortId = "abfaf7e5-7739-4f23-bfb4-09206111599f")]
		public enum TCP_TABLE_CLASS
		{
			/// <summary>
			/// A MIB_TCPTABLE table that contains all listening (receiving only) TCP endpoints on the local computer is returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_TCPTABLE), CorrespondingAction.Get)]
			TCP_TABLE_BASIC_LISTENER,

			/// <summary>A MIB_TCPTABLE table that contains all connected TCP endpoints on the local computer is returned to the caller.</summary>
			[CorrespondingType(typeof(MIB_TCPTABLE), CorrespondingAction.Get)]
			TCP_TABLE_BASIC_CONNECTIONS,

			/// <summary>A MIB_TCPTABLE table that contains all TCP endpoints on the local computer is returned to the caller.</summary>
			[CorrespondingType(typeof(MIB_TCPTABLE), CorrespondingAction.Get)]
			TCP_TABLE_BASIC_ALL,

			/// <summary>
			/// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID that contains all listening (receiving only) TCP endpoints on the local
			/// computer is returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_PID), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_PID), CorrespondingAction.Get)]
			TCP_TABLE_OWNER_PID_LISTENER,

			/// <summary>
			/// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID that structure that contains all connected TCP endpoints on the local
			/// computer is returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_PID), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_PID), CorrespondingAction.Get)]
			TCP_TABLE_OWNER_PID_CONNECTIONS,

			/// <summary>
			/// A MIB_TCPTABLE_OWNER_PID or MIB_TCP6TABLE_OWNER_PID structure that contains all TCP endpoints on the local computer is
			/// returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_PID), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_PID), CorrespondingAction.Get)]
			TCP_TABLE_OWNER_PID_ALL,

			/// <summary>
			/// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains all listening (receiving only) TCP
			/// endpoints on the local computer is returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_MODULE), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_MODULE), CorrespondingAction.Get)]
			TCP_TABLE_OWNER_MODULE_LISTENER,

			/// <summary>
			/// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains all connected TCP endpoints on the local
			/// computer is returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_MODULE), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_MODULE), CorrespondingAction.Get)]
			TCP_TABLE_OWNER_MODULE_CONNECTIONS,

			/// <summary>
			/// A MIB_TCPTABLE_OWNER_MODULE or MIB_TCP6TABLE_OWNER_MODULE structure that contains all TCP endpoints on the local computer is
			/// returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_TCPTABLE_OWNER_MODULE), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_TCP6TABLE_OWNER_MODULE), CorrespondingAction.Get)]
			TCP_TABLE_OWNER_MODULE_ALL
		}

		/// <summary>
		/// The <c>TCPIP_OWNER_MODULE_INFO_CLASS</c> enumeration defines the type of module information structure passed to calls of the
		/// <c>GetOwnerModuleFromXXXEntry</c> family.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iprtrmib/ne-iprtrmib-_tcpip_owner_module_info_class typedef enum
		// _TCPIP_OWNER_MODULE_INFO_CLASS { TCPIP_OWNER_MODULE_INFO_BASIC } TCPIP_OWNER_MODULE_INFO_CLASS, *PTCPIP_OWNER_MODULE_INFO_CLASS;
		[PInvokeData("iprtrmib.h", MSDNShortId = "8529dd62-8516-47d0-8118-95e6d33fc799")]
		public enum TCPIP_OWNER_MODULE_INFO_CLASS
		{
			/// <summary>A <see cref="TCPIP_OWNER_MODULE_BASIC_INFO"/> structure is passed to the GetOwnerModuleFromXXXEntry function.</summary>
			[CorrespondingType(typeof(TCPIP_OWNER_MODULE_BASIC_INFO))]
			TCPIP_OWNER_MODULE_INFO_BASIC,
		}

		/// <summary>
		/// <para>
		/// The <c>UDP_TABLE_CLASS</c> enumeration defines the set of values used to indicate the type of table returned by calls to GetExtendedUdpTable.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// On the Microsoft Windows Software Development Kit (SDK) released for Windows Vista and later, the organization of header files
		/// has changed and the <c>UDP_TABLE_CLASS</c> enumeration is defined in the Iprtrmib.h header file, not in the Iphlpapi.h header
		/// file. Note that the Iprtrmib.h header file is automatically included in Iphlpapi.h header file. The Iprtrmib.h header files
		/// should never be used directly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iprtrmib/ne-iprtrmib-_udp_table_class typedef enum _UDP_TABLE_CLASS {
		// UDP_TABLE_BASIC , UDP_TABLE_OWNER_PID , UDP_TABLE_OWNER_MODULE } UDP_TABLE_CLASS, *PUDP_TABLE_CLASS;
		[PInvokeData("iprtrmib.h", MSDNShortId = "2e7304d1-b89c-46d4-9121-936a1c38cc51")]
		public enum UDP_TABLE_CLASS
		{
			/// <summary>A MIB_UDPTABLE structure that contains all UDP endpoints on the local computer is returned to the caller.</summary>
			[CorrespondingType(typeof(MIB_UDPTABLE), CorrespondingAction.Get)]
			UDP_TABLE_BASIC,

			/// <summary>
			/// A MIB_UDPTABLE_OWNER_PID or MIB_UDP6TABLE_OWNER_PID structure that contains all UDP endpoints on the local computer is
			/// returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_UDPTABLE_OWNER_PID), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_UDP6TABLE_OWNER_PID), CorrespondingAction.Get)]
			UDP_TABLE_OWNER_PID,

			/// <summary>
			/// A MIB_UDPTABLE_OWNER_MODULE or MIB_UDP6TABLE_OWNER_MODULE structure that contains all UDP endpoints on the local computer is
			/// returned to the caller.
			/// </summary>
			[CorrespondingType(typeof(MIB_UDPTABLE_OWNER_MODULE), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MIB_UDP6TABLE_OWNER_MODULE), CorrespondingAction.Get)]
			UDP_TABLE_OWNER_MODULE,
		}

		/// <summary>
		/// The <c>TCPIP_OWNER_MODULE_BASIC_INFO</c> structure contains pointers to the module name and module path values associated with a
		/// TCP connection. The <c>TCPIP_OWNER_MODULE_BASIC_INFO</c> structure is returned by the GetOwnerModuleFromTcpEntry and
		/// GetOwnerModuleFromTcp6Entry functions.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the module owner is the system kernel, the <c>lpModuleName</c> and <c>lpModulePath</c> members point to a wide character
		/// string that contains "System".
		/// </para>
		/// <para>
		/// On Windows Vista and later as well as on the Microsoft Windows Software Development Kit (SDK), the organization of header files
		/// has changed and the <c>TCPIP_OWNER_MODULE_BASIC_INFO</c> structure is defined in the Iprtrmib.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iprtrmib/ns-iprtrmib-tcpip_owner_module_basic_info typedef struct
		// _TCPIP_OWNER_MODULE_BASIC_INFO { PWCHAR pModuleName; PWCHAR pModulePath; } TCPIP_OWNER_MODULE_BASIC_INFO, *PTCPIP_OWNER_MODULE_BASIC_INFO;
		[PInvokeData("iprtrmib.h", MSDNShortId = "cce3e0ff-31f2-454b-8aae-3b35f72f47ed")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TCPIP_OWNER_MODULE_BASIC_INFO
		{
			/// <summary>
			/// A pointer to the name of the module. This field should be a <c>NULL</c> pointer when passed to GetOwnerModuleFromTcpEntry or
			/// GetOwnerModuleFromTcp6Entry function.
			/// </summary>
			public string pModuleName;

			/// <summary>
			/// A pointer to the full path of the module, including the module name. This field should be a <c>NULL</c> pointer when passed
			/// to GetOwnerModuleFromTcpEntry or GetOwnerModuleFromTcp6Entry function.
			/// </summary>
			public string pModulePath;
		}

		/// <summary>
		/// The <c>TCPIP_OWNER_MODULE_BASIC_INFO</c> structure contains pointers to the module name and module path values associated with a
		/// TCP connection. The <c>TCPIP_OWNER_MODULE_BASIC_INFO</c> structure is returned by the GetOwnerModuleFromTcpEntry and
		/// GetOwnerModuleFromTcp6Entry functions.
		/// </summary>
		/// <remarks>
		/// <para>
		/// If the module owner is the system kernel, the <c>lpModuleName</c> and <c>lpModulePath</c> members point to a wide character
		/// string that contains "System".
		/// </para>
		/// <para>
		/// On Windows Vista and later as well as on the Microsoft Windows Software Development Kit (SDK), the organization of header files
		/// has changed and the <c>TCPIP_OWNER_MODULE_BASIC_INFO</c> structure is defined in the Iprtrmib.h header file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/iprtrmib/ns-iprtrmib-tcpip_owner_module_basic_info typedef struct
		// _TCPIP_OWNER_MODULE_BASIC_INFO { PWCHAR pModuleName; PWCHAR pModulePath; } TCPIP_OWNER_MODULE_BASIC_INFO, *PTCPIP_OWNER_MODULE_BASIC_INFO;
		[PInvokeData("iprtrmib.h", MSDNShortId = "cce3e0ff-31f2-454b-8aae-3b35f72f47ed")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TCPIP_OWNER_MODULE_BASIC_INFO_UNMGD
		{
			/// <summary>
			/// A pointer to the name of the module. This field should be a <c>NULL</c> pointer when passed to GetOwnerModuleFromTcpEntry or
			/// GetOwnerModuleFromTcp6Entry function.
			/// </summary>
			public StrPtrUni pModuleName;

			/// <summary>
			/// A pointer to the full path of the module, including the module name. This field should be a <c>NULL</c> pointer when passed
			/// to GetOwnerModuleFromTcpEntry or GetOwnerModuleFromTcp6Entry function.
			/// </summary>
			public StrPtrUni pModulePath;

			/// <summary>Performs an implicit conversion from <see cref="TCPIP_OWNER_MODULE_BASIC_INFO_UNMGD"/> to <see cref="TCPIP_OWNER_MODULE_BASIC_INFO"/>.</summary>
			/// <param name="unmgd">The unmanaged structure.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator TCPIP_OWNER_MODULE_BASIC_INFO(TCPIP_OWNER_MODULE_BASIC_INFO_UNMGD unmgd) => new TCPIP_OWNER_MODULE_BASIC_INFO { pModuleName = unmgd.pModuleName, pModulePath = unmgd.pModulePath };
		}
	}
}