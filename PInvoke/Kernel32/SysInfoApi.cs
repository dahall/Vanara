using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static Vanara.PInvoke.FunctionHelper;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The maximum computername length.</summary>
	public const uint MAX_COMPUTERNAME_LENGTH = 15;

	/// <summary>Specifies a type of computer name.</summary>
	// typedef enum _COMPUTER_NAME_FORMAT { ComputerNameNetBIOS, ComputerNameDnsHostname, ComputerNameDnsDomain,
	// ComputerNameDnsFullyQualified, ComputerNamePhysicalNetBIOS, ComputerNamePhysicalDnsHostname, ComputerNamePhysicalDnsDomain,
	// ComputerNamePhysicalDnsFullyQualified, ComputerNameMax} COMPUTER_NAME_FORMAT; https://msdn.microsoft.com/en-us/library/windows/desktop/ms724224(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "ms724224")]
	public enum COMPUTER_NAME_FORMAT
	{
		/// <summary>
		/// The NetBIOS name of the local computer or the cluster associated with the local computer. This name is limited to
		/// MAX_COMPUTERNAME_LENGTH + 1 characters and may be a truncated version of the DNS host name. For example, if the DNS host name
		/// is "corporate-mail-server", the NetBIOS name would be "corporate-mail-".
		/// </summary>
		ComputerNameNetBIOS,

		/// <summary>The DNS name of the local computer or the cluster associated with the local computer.</summary>
		ComputerNameDnsHostname,

		/// <summary>The name of the DNS domain assigned to the local computer or the cluster associated with the local computer.</summary>
		ComputerNameDnsDomain,

		/// <summary>
		/// <para>
		/// The fully qualified DNS name that uniquely identifies the local computer or the cluster associated with the local computer.
		/// </para>
		/// <para>
		/// This name is a combination of the DNS host name and the DNS domain name, using the form HostName.DomainName. For example, if
		/// the DNS host name is "corporate-mail-server" and the DNS domain name is "microsoft.com", the fully qualified DNS name is "corporate-mail-server.microsoft.com".
		/// </para>
		/// </summary>
		ComputerNameDnsFullyQualified,

		/// <summary>The NetBIOS name of the local computer. On a cluster, this is the NetBIOS name of the local node on the cluster.</summary>
		ComputerNamePhysicalNetBIOS,

		/// <summary>The DNS host name of the local computer. On a cluster, this is the DNS host name of the local node on the cluster.</summary>
		ComputerNamePhysicalDnsHostname,

		/// <summary>
		/// The name of the DNS domain assigned to the local computer. On a cluster, this is the DNS domain of the local node on the cluster.
		/// </summary>
		ComputerNamePhysicalDnsDomain,

		/// <summary>
		/// The fully qualified DNS name that uniquely identifies the computer. On a cluster, this is the fully qualified DNS name of the
		/// local node on the cluster. The fully qualified DNS name is a combination of the DNS host name and the DNS domain name, using
		/// the form HostName.DomainName.
		/// </summary>
		ComputerNamePhysicalDnsFullyQualified,

		/// <summary>Not used.</summary>
		ComputerNameMax,
	}

	/// <summary>An enum of possible values for the developer drive enablement state.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/ne-sysinfoapi-developer_drive_enablement_state typedef enum
	// DEVELOPER_DRIVE_ENABLEMENT_STATE { DeveloperDriveEnablementStateError, DeveloperDriveEnabled, DeveloperDriveDisabledBySystemPolicy,
	// DeveloperDriveDisabledByGroupPolicy } ;
	[PInvokeData("sysinfoapi.h", MSDNShortId = "NE:sysinfoapi.DEVELOPER_DRIVE_ENABLEMENT_STATE")]
	public enum DEVELOPER_DRIVE_ENABLEMENT_STATE
	{
		/// <summary>
		/// <para>Indicates that there was an error determining the developer drive enablement state. After this is returned, call</para>
		/// <para>GetLastError</para>
		/// <para>to get the error value.</para>
		/// </summary>
		DeveloperDriveEnablementStateError,

		/// <summary>Indicates that the developer drive is enabled.</summary>
		DeveloperDriveEnabled,

		/// <summary>Indicates that the developer drive is disabled by system policy.</summary>
		DeveloperDriveDisabledBySystemPolicy,

		/// <summary>Indicates that the developer drive is disabled by group policy.</summary>
		DeveloperDriveDisabledByGroupPolicy,
	}

	/// <summary>Identifier of a firmware table provider for calls to <c>EnumSystemFirmwareTables</c>.</summary>
	public enum FirmwareTableProviderId : uint
	{
		/// <summary>The ACPI firmware table provider.</summary>
		ACPI = (byte)'A' << 24 | (byte)'C' << 16 | (byte)'P' << 8 | (byte)'I',

		/// <summary>The raw firmware table provider. Not supported for UEFI systems; use 'RSMB' instead.</summary>
		FIRM = (byte)'F' << 24 | (byte)'I' << 16 | (byte)'R' << 8 | (byte)'M',

		/// <summary>The raw SMBIOS firmware table provider.</summary>
		RSMB = (byte)'R' << 24 | (byte)'S' << 16 | (byte)'M' << 8 | (byte)'B'
	}

	/// <summary>
	/// Represents the relationship between the processor set identified in the corresponding <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION</c>
	/// or <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX</c> structure.
	/// </summary>
	// typedef enum _LOGICAL_PROCESSOR_RELATIONSHIP { RelationProcessorCore, RelationNumaNode, RelationCache, RelationProcessorPackage,
	// RelationGroup, RelationAll = 0xffff} LOGICAL_PROCESSOR_RELATIONSHIP; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684197(v=vs.85).aspx
	[PInvokeData("WinNT.h", MSDNShortId = "ms684197")]
	public enum LOGICAL_PROCESSOR_RELATIONSHIP : uint
	{
		/// <summary>The specified logical processors share a single processor core.</summary>
		[CorrespondingType(typeof(PROCESSOR_RELATIONSHIP))]
		RelationProcessorCore,

		/// <summary>The specified logical processors are part of the same NUMA node.</summary>
		[CorrespondingType(typeof(NUMA_NODE_RELATIONSHIP))]
		RelationNumaNode,

		/// <summary>
		/// <para>The specified logical processors share a cache.</para>
		/// <para>
		/// <c>Windows Server 2003:</c> This value is not supported until Windows Server 2003 with SP1 and Windows XP Professional x64 Edition.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(CACHE_RELATIONSHIP))]
		RelationCache,

		/// <summary>
		/// <para>
		/// The specified logical processors share a physical package (a single package socketed or soldered onto a motherboard may
		/// contain multiple processor cores or threads, each of which is treated as a separate processor by the operating system).
		/// </para>
		/// <para>
		/// <c>Windows Server 2003:</c> This value is not supported until Windows Server 2003 with SP1 and Windows XP Professional x64 Edition.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(PROCESSOR_RELATIONSHIP))]
		RelationProcessorPackage,

		/// <summary>
		/// <para>The specified logical processors share a single processor group.</para>
		/// <para>
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP Professional x64 Edition:</c> This value is not
		/// supported until Windows Server 2008 R2.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(GROUP_RELATIONSHIP))]
		RelationGroup,

		/// <summary>
		/// <para>On input, retrieves information about all possible relationship types. This value is not used on output.</para>
		/// <para>
		/// <c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP Professional x64 Edition:</c> This value is not
		/// supported until Windows Server 2008 R2.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(PROCESSOR_RELATIONSHIP), CorrespondingAction.Set)]
		[CorrespondingType(typeof(NUMA_NODE_RELATIONSHIP), CorrespondingAction.Set)]
		[CorrespondingType(typeof(CACHE_RELATIONSHIP), CorrespondingAction.Set)]
		[CorrespondingType(typeof(GROUP_RELATIONSHIP), CorrespondingAction.Set)]
		RelationAll = 0xffff,
	}

	/// <summary>Represents the type of processor cache identified in the corresponding <c>CACHE_DESCRIPTOR</c> structure.</summary>
	// typedef enum _PROCESSOR_CACHE_TYPE { CacheUnified, CacheInstruction, CacheData, CacheTrace} PROCESSOR_CACHE_TYPE; https://msdn.microsoft.com/en-us/library/windows/desktop/ms684844(v=vs.85).aspx
	[PInvokeData("WinNT.h", MSDNShortId = "ms684844")]
	public enum PROCESSOR_CACHE_TYPE
	{
		/// <summary>The cache is unified.</summary>
		CacheUnified,

		/// <summary>The cache is for processor instructions.</summary>
		CacheInstruction,

		/// <summary>The cache is for data.</summary>
		CacheData,

		/// <summary>The cache is for traces.</summary>
		CacheTrace,
	}

	/// <summary>The product type.</summary>
	[PInvokeData("Winbase.h")]
	public enum PRODUCT_TYPE : uint
	{
		/// <summary>Business</summary>
		PRODUCT_BUSINESS = 0x00000006,

		/// <summary>Business N</summary>
		PRODUCT_BUSINESS_N = 0x00000010,

		/// <summary>HPC Edition</summary>
		PRODUCT_CLUSTER_SERVER = 0x00000012,

		/// <summary>Server Hyper Core V</summary>
		PRODUCT_CLUSTER_SERVER_V = 0x00000040,

		/// <summary>Windows 10 Home</summary>
		PRODUCT_CORE = 0x00000065,

		/// <summary>Windows 10 Home China</summary>
		PRODUCT_CORE_COUNTRYSPECIFIC = 0x00000063,

		/// <summary>Windows 10 Home N</summary>
		PRODUCT_CORE_N = 0x00000062,

		/// <summary>Windows 10 Home Single Language</summary>
		PRODUCT_CORE_SINGLELANGUAGE = 0x00000064,

		/// <summary>Server Datacenter (evaluation installation)</summary>
		PRODUCT_DATACENTER_EVALUATION_SERVER = 0x00000050,

		/// <summary>Server Datacenter (full installation)</summary>
		PRODUCT_DATACENTER_SERVER = 0x00000008,

		/// <summary>Server Datacenter (core installation)</summary>
		PRODUCT_DATACENTER_SERVER_CORE = 0x0000000C,

		/// <summary>Server Datacenter without Hyper-V (core installation)</summary>
		PRODUCT_DATACENTER_SERVER_CORE_V = 0x00000027,

		/// <summary>Server Datacenter without Hyper-V (full installation)</summary>
		PRODUCT_DATACENTER_SERVER_V = 0x00000025,

		/// <summary>Windows 10 Education</summary>
		PRODUCT_EDUCATION = 0x00000079,

		/// <summary>Windows 10 Education N</summary>
		PRODUCT_EDUCATION_N = 0x0000007A,

		/// <summary>Windows 10 Enterprise</summary>
		PRODUCT_ENTERPRISE = 0x00000004,

		/// <summary>Windows 10 Enterprise E</summary>
		PRODUCT_ENTERPRISE_E = 0x00000046,

		/// <summary>Windows 10 Enterprise Evaluation</summary>
		PRODUCT_ENTERPRISE_EVALUATION = 0x00000048,

		/// <summary>Windows 10 Enterprise N</summary>
		PRODUCT_ENTERPRISE_N = 0x0000001B,

		/// <summary>Windows 10 Enterprise N Evaluation</summary>
		PRODUCT_ENTERPRISE_N_EVALUATION = 0x00000054,

		/// <summary>Windows 10 Enterprise 2015 LTSB</summary>
		PRODUCT_ENTERPRISE_S = 0x0000007D,

		/// <summary>Windows 10 Enterprise 2015 LTSB Evaluation</summary>
		PRODUCT_ENTERPRISE_S_EVALUATION = 0x00000081,

		/// <summary>Windows 10 Enterprise 2015 LTSB N</summary>
		PRODUCT_ENTERPRISE_S_N = 0x0000007E,

		/// <summary>Windows 10 Enterprise 2015 LTSB N Evaluation</summary>
		PRODUCT_ENTERPRISE_S_N_EVALUATION = 0x00000082,

		/// <summary>Server Enterprise (full installation)</summary>
		PRODUCT_ENTERPRISE_SERVER = 0x0000000A,

		/// <summary>Server Enterprise (core installation)</summary>
		PRODUCT_ENTERPRISE_SERVER_CORE = 0x0000000E,

		/// <summary>Server Enterprise without Hyper-V (core installation)</summary>
		PRODUCT_ENTERPRISE_SERVER_CORE_V = 0x00000029,

		/// <summary>Server Enterprise for Itanium-based Systems</summary>
		PRODUCT_ENTERPRISE_SERVER_IA64 = 0x0000000F,

		/// <summary>Server Enterprise without Hyper-V (full installation)</summary>
		PRODUCT_ENTERPRISE_SERVER_V = 0x00000026,

		/// <summary>Windows Essential Server Solution Additional</summary>
		PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL = 0x0000003C,

		/// <summary>Windows Essential Server Solution Additional SVC</summary>
		PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC = 0x0000003E,

		/// <summary>Windows Essential Server Solution Management</summary>
		PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT = 0x0000003B,

		/// <summary>Windows Essential Server Solution Management SVC</summary>
		PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC = 0x0000003D,

		/// <summary>Home Basic</summary>
		PRODUCT_HOME_BASIC = 0x00000002,

		/// <summary>Not supported</summary>
		PRODUCT_HOME_BASIC_E = 0x00000043,

		/// <summary>Home Basic N</summary>
		PRODUCT_HOME_BASIC_N = 0x00000005,

		/// <summary>Home Premium</summary>
		PRODUCT_HOME_PREMIUM = 0x00000003,

		/// <summary>Not supported</summary>
		PRODUCT_HOME_PREMIUM_E = 0x00000044,

		/// <summary>Home Premium N</summary>
		PRODUCT_HOME_PREMIUM_N = 0x0000001A,

		/// <summary>Windows Home Server 2011</summary>
		PRODUCT_HOME_PREMIUM_SERVER = 0x00000022,

		/// <summary>Windows Storage Server 2008 R2 Essentials</summary>
		PRODUCT_HOME_SERVER = 0x00000013,

		/// <summary></summary>
		PRODUCT_HYPERV = 0x0000002A,

		/// <summary>Windows 10 IoT Core</summary>
		PRODUCT_IOTUAP = 0x0000007B,

		/// <summary>Windows 10 IoT Core Commercial</summary>
		PRODUCT_IOTUAPCOMMERCIAL = 0x00000083,

		/// <summary>Windows Essential Business Server Management Server</summary>
		PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT = 0x0000001E,

		/// <summary>Windows Essential Business Server Messaging Server</summary>
		PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING = 0x00000020,

		/// <summary>Windows Essential Business Server Security Server</summary>
		PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY = 0x0000001F,

		/// <summary>Windows 10 Mobile</summary>
		PRODUCT_MOBILE_CORE = 0x00000068,

		/// <summary>Windows 10 Mobile Enterprise</summary>
		PRODUCT_MOBILE_ENTERPRISE = 0x00000085,

		/// <summary>Windows MultiPoint Server Premium (full installation)</summary>
		PRODUCT_MULTIPOINT_PREMIUM_SERVER = 0x0000004D,

		/// <summary>Windows MultiPoint Server Standard (full installation)</summary>
		PRODUCT_MULTIPOINT_STANDARD_SERVER = 0x0000004C,

		/// <summary>Windows 10 Pro for Workstations</summary>
		PRODUCT_PRO_WORKSTATION = 0x000000A1,

		/// <summary>Windows 10 Pro for Workstations N</summary>
		PRODUCT_PRO_WORKSTATION_N = 0x000000A2,

		/// <summary>Windows 10 Pro</summary>
		PRODUCT_PROFESSIONAL = 0x00000030,

		/// <summary>Not supported</summary>
		PRODUCT_PROFESSIONAL_E = 0x00000045,

		/// <summary>Windows 10 Pro N</summary>
		PRODUCT_PROFESSIONAL_N = 0x00000031,

		/// <summary>Professional with Media Center</summary>
		PRODUCT_PROFESSIONAL_WMC = 0x00000067,

		/// <summary>Windows Small Business Server 2011 Essentials</summary>
		PRODUCT_SB_SOLUTION_SERVER = 0x00000032,

		/// <summary>Server For SB Solutions EM</summary>
		PRODUCT_SB_SOLUTION_SERVER_EM = 0x00000036,

		/// <summary>Server For SB Solutions</summary>
		PRODUCT_SERVER_FOR_SB_SOLUTIONS = 0x00000033,

		/// <summary>Server For SB Solutions EM</summary>
		PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM = 0x00000037,

		/// <summary>Windows Server 2008 for Windows Essential Server Solutions</summary>
		PRODUCT_SERVER_FOR_SMALLBUSINESS = 0x00000018,

		/// <summary>Windows Server 2008 without Hyper-V for Windows Essential Server Solutions</summary>
		PRODUCT_SERVER_FOR_SMALLBUSINESS_V = 0x00000023,

		/// <summary>Server Foundation</summary>
		PRODUCT_SERVER_FOUNDATION = 0x00000021,

		/// <summary>Windows Small Business Server</summary>
		PRODUCT_SMALLBUSINESS_SERVER = 0x00000009,

		/// <summary>Small Business Server Premium</summary>
		PRODUCT_SMALLBUSINESS_SERVER_PREMIUM = 0x00000019,

		/// <summary>Small Business Server Premium (core installation)</summary>
		PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE = 0x0000003F,

		/// <summary>Windows MultiPoint Server</summary>
		PRODUCT_SOLUTION_EMBEDDEDSERVER = 0x00000038,

		/// <summary>Server Standard (evaluation installation)</summary>
		PRODUCT_STANDARD_EVALUATION_SERVER = 0x0000004F,

		/// <summary>Server Standard</summary>
		PRODUCT_STANDARD_SERVER = 0x00000007,

		/// <summary>Server Standard (core installation)</summary>
		PRODUCT_STANDARD_SERVER_CORE = 0x0000000D,

		/// <summary>Server Standard without Hyper-V (core installation)</summary>
		PRODUCT_STANDARD_SERVER_CORE_V = 0x00000028,

		/// <summary>Server Standard without Hyper-V</summary>
		PRODUCT_STANDARD_SERVER_V = 0x00000024,

		/// <summary>Server Solutions Premium</summary>
		PRODUCT_STANDARD_SERVER_SOLUTIONS = 0x00000034,

		/// <summary>Server Solutions Premium (core installation)</summary>
		PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE = 0x00000035,

		/// <summary>Starter</summary>
		PRODUCT_STARTER = 0x0000000B,

		/// <summary>Not supported</summary>
		PRODUCT_STARTER_E = 0x00000042,

		/// <summary>Starter N</summary>
		PRODUCT_STARTER_N = 0x0000002F,

		/// <summary>Storage Server Enterprise</summary>
		PRODUCT_STORAGE_ENTERPRISE_SERVER = 0x00000017,

		/// <summary>Storage Server Enterprise (core installation)</summary>
		PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE = 0x0000002E,

		/// <summary>Storage Server Express</summary>
		PRODUCT_STORAGE_EXPRESS_SERVER = 0x00000014,

		/// <summary>Storage Server Express (core installation)</summary>
		PRODUCT_STORAGE_EXPRESS_SERVER_CORE = 0x0000002B,

		/// <summary>Storage Server Standard (evaluation installation)</summary>
		PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER = 0x00000060,

		/// <summary>Storage Server Standard</summary>
		PRODUCT_STORAGE_STANDARD_SERVER = 0x00000015,

		/// <summary>Storage Server Standard (core installation)</summary>
		PRODUCT_STORAGE_STANDARD_SERVER_CORE = 0x0000002C,

		/// <summary>Storage Server Workgroup (evaluation installation)</summary>
		PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER = 0x0000005F,

		/// <summary>Storage Server Workgroup</summary>
		PRODUCT_STORAGE_WORKGROUP_SERVER = 0x00000016,

		/// <summary>Storage Server Workgroup (core installation)</summary>
		PRODUCT_STORAGE_WORKGROUP_SERVER_CORE = 0x0000002D,

		/// <summary>Ultimate</summary>
		PRODUCT_ULTIMATE = 0x00000001,

		/// <summary>Not supported</summary>
		PRODUCT_ULTIMATE_E = 0x00000047,

		/// <summary>Ultimate N</summary>
		PRODUCT_ULTIMATE_N = 0x0000001C,

		/// <summary>An unknown product</summary>
		PRODUCT_UNDEFINED = 0x00000000,

		/// <summary>Web Server (full installation)</summary>
		PRODUCT_WEB_SERVER = 0x00000011,

		/// <summary>Web Server (core installation)</summary>
		PRODUCT_WEB_SERVER_CORE = 0x0000001D,
	}

	/// <summary>Any additional information about the system.</summary>
	[PInvokeData("Winnt.h", MSDNShortId = "ms724833")]
	public enum ProductType : byte
	{
		/// <summary>
		/// The system is a domain controller and the operating system is Windows Server 2012 , Windows Server 2008 R2, Windows Server
		/// 2008, Windows Server 2003, or Windows 2000 Server.
		/// </summary>
		VER_NT_DOMAIN_CONTROLLER = 0x0000002,

		/// <summary>
		/// The operating system is Windows Server 2012, Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows
		/// 2000 Server.
		/// <para>Note that a server that is also a domain controller is reported as VER_NT_DOMAIN_CONTROLLER, not VER_NT_SERVER.</para>
		/// </summary>
		VER_NT_SERVER = 0x0000003,

		/// <summary>
		/// The operating system is Windows 8, Windows 7, Windows Vista, Windows XP Professional, Windows XP Home Edition, or Windows
		/// 2000 Professional.
		/// </summary>
		VER_NT_WORKSTATION = 0x0000001,
	}

	/// <summary>Flags for <c>SetComputerNameEx2</c>.</summary>
	public enum SCEX2
	{
		/// <summary>Undocumented.</summary>
		SCEX2_ALT_NETBIOS_NAME = 0x00000001,
	}

	/// <summary>A bit mask that identifies the product suites available on the system.</summary>
	[PInvokeData("Winnt.h", MSDNShortId = "ms724833")]
	[Flags]
	public enum SuiteMask : ushort
	{
		/// <summary>Microsoft BackOffice components are installed.</summary>
		VER_SUITE_BACKOFFICE = 0x00000004,

		/// <summary>Windows Server 2003, Web Edition is installed.</summary>
		VER_SUITE_BLADE = 0x00000400,

		/// <summary>Windows Server 2003, Compute Cluster Edition is installed.</summary>
		VER_SUITE_COMPUTE_SERVER = 0x00004000,

		/// <summary>
		/// Windows Server 2008 Datacenter, Windows Server 2003, Datacenter Edition, or Windows 2000 Datacenter Server is installed.
		/// </summary>
		VER_SUITE_DATACENTER = 0x00000080,

		/// <summary>
		/// Windows Server 2008 Enterprise, Windows Server 2003, Enterprise Edition, or Windows 2000 Advanced Server is installed. Refer
		/// to the Remarks section for more information about this bit flag.
		/// </summary>
		VER_SUITE_ENTERPRISE = 0x00000002,

		/// <summary>Windows XP Embedded is installed.</summary>
		VER_SUITE_EMBEDDEDNT = 0x00000040,

		/// <summary>Windows Vista Home Premium, Windows Vista Home Basic, or Windows XP Home Edition is installed.</summary>
		VER_SUITE_PERSONAL = 0x00000200,

		/// <summary>
		/// Remote Desktop is supported, but only one interactive session is supported. This value is set unless the system is running in
		/// application server mode.
		/// </summary>
		VER_SUITE_SINGLEUSERTS = 0x00000100,

		/// <summary>
		/// Microsoft Small Business Server was once installed on the system, but may have been upgraded to another version of Windows.
		/// Refer to the Remarks section for more information about this bit flag.
		/// </summary>
		VER_SUITE_SMALLBUSINESS = 0x00000001,

		/// <summary>
		/// Microsoft Small Business Server is installed with the restrictive client license in force. Refer to the Remarks section for
		/// more information about this bit flag.
		/// </summary>
		VER_SUITE_SMALLBUSINESS_RESTRICTED = 0x00000020,

		/// <summary>Windows Storage Server 2003 R2 or Windows Storage Server 2003is installed.</summary>
		VER_SUITE_STORAGE_SERVER = 0x00002000,

		/// <summary>
		/// Terminal Services is installed. This value is always set.
		/// <para>If VER_SUITE_TERMINAL is set but VER_SUITE_SINGLEUSERTS is not set, the system is running in application server mode.</para>
		/// </summary>
		VER_SUITE_TERMINAL = 0x00000010,

		/// <summary>Windows Home Server is installed.</summary>
		VER_SUITE_WH_SERVER = 0x00008000,
	}

	/// <summary>The environment to query.</summary>
	[PInvokeData("sysinfoapi.h", MSDNShortId = "NF:sysinfoapi.IsUserCetAvailableInEnvironment")]
	[Flags]
	public enum USER_CET_ENVIRONMENT
	{
		/// <summary>The Win32 environment.</summary>
		USER_CET_ENVIRONMENT_WIN32_PROCESS = 0x00000000,

		/// <summary>The Intel Software Guard Extensions 2 (SGX2) enclave environment.</summary>
		USER_CET_ENVIRONMENT_SGX2_ENCLAVE = 0x00000002,

		/// <summary>The virtualization-based security (VBS) enclave environment.</summary>
		USER_CET_ENVIRONMENT_VBS_ENCLAVE = 0x00000010,

		/// <summary>The virtualization-based security (VBS) basic enclave environment.</summary>
		USER_CET_ENVIRONMENT_VBS_BASIC_ENCLAVE = 0x00000011,
	}

	/// <summary>Converts a DNS-style host name to a NetBIOS-style computer name.</summary>
	/// <param name="Hostname">
	/// The DNS name. If the DNS name is not a valid, translatable name, the function fails. For more information, see Computer Names.
	/// </param>
	/// <param name="ComputerName">
	/// A pointer to a buffer that receives the computer name. The buffer size should be large enough to contain MAX_COMPUTERNAME_LENGTH
	/// + 1 characters.
	/// </param>
	/// <param name="nSize">
	/// <para>
	/// On input, specifies the size of the buffer, in <c>TCHARs</c>. On output, receives the number of <c>TCHARs</c> copied to the
	/// destination buffer, not including the terminating null character.
	/// </para>
	/// <para>
	/// If the buffer is too small, the function fails, GetLastError returns ERROR_MORE_DATA, and nSize receives the required buffer
	/// size, not including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. Possible values include
	/// the following.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The ComputerName buffer is too small. The nSize parameter contains the number of bytes required to receive the name.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function performs a textual mapping of the name. This convention limits the names of computers to be the common subset of
	/// the names. (Specifically, the leftmost label of the DNS name is truncated to 15-bytes of OEM characters.) Therefore, do not use
	/// this function to convert a DNS domain name to a NetBIOS domain name. There is no textual mapping for domain names.
	/// </para>
	/// <para>
	/// To compile an application that uses this function, define _WIN32_WINNT as 0x0500 or later. For more information, see Using the
	/// Windows Headers.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-dnshostnametocomputernamea BOOL DnsHostnameToComputerNameA(
	// LPCSTR Hostname, LPSTR ComputerName, LPDWORD nSize );
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winbase.h", MSDNShortId = "d5646fe6-9112-42cd-ace9-00dd1b590ecb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DnsHostnameToComputerName(string Hostname, [SizeDef(nameof(nSize))] StringBuilder? ComputerName,
		[Range(0, MAX_COMPUTERNAME_LENGTH + 1)] ref uint nSize);

	/// <summary>Enumerates all system firmware tables of the specified type.</summary>
	/// <param name="FirmwareTableProviderSignature">
	/// <para>
	/// The identifier of the firmware table provider to which the query is to be directed. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>'ACPI'</term>
	/// <term>The ACPI firmware table provider.</term>
	/// </item>
	/// <item>
	/// <term>'FIRM'</term>
	/// <term>The raw firmware table provider. Not supported for UEFI systems; use 'RSMB' instead.</term>
	/// </item>
	/// <item>
	/// <term>'RSMB'</term>
	/// <term>The raw SMBIOS firmware table provider.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="pFirmwareTableBuffer">
	/// <para>
	/// A pointer to a buffer that receives the list of firmware tables. If this parameter is <c>NULL</c>, the return value is the
	/// required buffer size.
	/// </para>
	/// <para>For more information on the contents of this buffer, see the Remarks section.</para>
	/// </param>
	/// <param name="BufferSize">The size of the pFirmwareTableBuffer buffer, in bytes.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the number of bytes written to the buffer. This value will always be less than or
	/// equal to BufferSize.
	/// </para>
	/// <para>
	/// If the function fails because the buffer is not large enough, the return value is the required buffer size, in bytes. This value
	/// is always greater than BufferSize.
	/// </para>
	/// <para>If the function fails for any other reason, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// UINT WINAPI EnumSystemFirmwareTables( _In_ DWORD FirmwareTableProviderSignature, _Out_ PVOID pFirmwareTableBuffer, _In_ DWORD
	// BufferSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724259(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724259")]
	[SuppressAutoGen]
	public static extern uint EnumSystemFirmwareTables(FirmwareTableProviderId FirmwareTableProviderSignature,
		[Optional, SizeDef(nameof(BufferSize), SizingMethod.QueryResultInReturn)] IntPtr pFirmwareTableBuffer, uint BufferSize);

	/// <summary>Enumerates all system firmware tables of the specified type.</summary>
	/// <param name="FirmwareTableProviderSignature">
	/// <para>
	/// The identifier of the firmware table provider to which the query is to be directed. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>'ACPI'</term>
	/// <term>The ACPI firmware table provider.</term>
	/// </item>
	/// <item>
	/// <term>'FIRM'</term>
	/// <term>The raw firmware table provider. Not supported for UEFI systems; use 'RSMB' instead.</term>
	/// </item>
	/// <item>
	/// <term>'RSMB'</term>
	/// <term>The raw SMBIOS firmware table provider.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="tableIdentifiers">
	/// <para>A list of firmware tables.</para>
	/// <para>For more information on the contents of this buffer, see the Remarks section.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the number of bytes written to the buffer. This value will always be less than or
	/// equal to BufferSize.
	/// </para>
	/// <para>
	/// If the function fails because the buffer is not large enough, the return value is the required buffer size, in bytes. This value
	/// is always greater than BufferSize.
	/// </para>
	/// <para>If the function fails for any other reason, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	public static Win32Error EnumSystemFirmwareTables(FirmwareTableProviderId FirmwareTableProviderSignature, out uint[]? tableIdentifiers) =>
		CallMethodWithTypedBuf(
			(ref uint sz) => BoolToLastErr((sz = EnumSystemFirmwareTables(FirmwareTableProviderSignature, IntPtr.Zero, 0)) > 0),
			(IntPtr p, ref uint sz) => BoolToLastErr((sz = EnumSystemFirmwareTables(FirmwareTableProviderSignature, p, sz)) > 0),
			out tableIdentifiers,
			(p, sz) => p.ToArray<uint>((int)sz / Marshal.SizeOf<uint>()));

	/// <summary>
	/// <para>
	/// Retrieves the NetBIOS name of the local computer. This name is established at system startup, when the system reads it from the registry.
	/// </para>
	/// <para>
	/// <c>GetComputerName</c> retrieves only the NetBIOS name of the local computer. To retrieve the DNS host name, DNS domain name, or
	/// the fully qualified DNS name, call the <c>GetComputerNameEx</c> function. Additional information is provided by the
	/// <c>IADsADSystemInfo</c> interface.
	/// </para>
	/// <para>
	/// The behavior of this function can be affected if the local computer is a node in a cluster. For more information, see
	/// <c>ResUtilGetEnvironmentWithNetName</c> and <c>UseNetworkName</c>.
	/// </para>
	/// </summary>
	/// <param name="lpBuffer">
	/// A pointer to a buffer that receives the computer name or the cluster virtual server name. The buffer size should be large enough
	/// to contain MAX_COMPUTERNAME_LENGTH + 1 characters.
	/// </param>
	/// <param name="lpnSize">
	/// <para>
	/// On input, specifies the size of the buffer, in <c>TCHARs</c>. On output, the number of <c>TCHARs</c> copied to the destination
	/// buffer, not including the terminating null character.
	/// </para>
	/// <para>
	/// If the buffer is too small, the function fails and <c>GetLastError</c> returns ERROR_BUFFER_OVERFLOW. The lpnSize parameter
	/// specifies the size of the buffer required, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetComputerName( _Out_ LPTSTR lpBuffer, _Inout_ LPDWORD lpnSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724295(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724295")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetComputerName([SizeDef(nameof(lpnSize))] StringBuilder? lpBuffer, [Range(0, MAX_COMPUTERNAME_LENGTH + 1)] ref uint lpnSize);

	/// <summary>
	/// Retrieves a NetBIOS or DNS name associated with the local computer. The names are established at system startup, when the system
	/// reads them from the registry.
	/// </summary>
	/// <param name="NameType">
	/// <para>
	/// The type of name to be retrieved. This parameter is a value from the <c>COMPUTER_NAME_FORMAT</c> enumeration type. The following
	/// table provides additional information.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ComputerNameDnsDomain</term>
	/// <term>
	/// The name of the DNS domain assigned to the local computer. If the local computer is a node in a cluster, lpBuffer receives the
	/// DNS domain name of the cluster virtual server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNameDnsFullyQualified</term>
	/// <term>
	/// The fully qualified DNS name that uniquely identifies the local computer. This name is a combination of the DNS host name and the
	/// DNS domain name, using the form HostName.DomainName. If the local computer is a node in a cluster, lpBuffer receives the fully
	/// qualified DNS name of the cluster virtual server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNameDnsHostname</term>
	/// <term>
	/// The DNS host name of the local computer. If the local computer is a node in a cluster, lpBuffer receives the DNS host name of the
	/// cluster virtual server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNameNetBIOS</term>
	/// <term>
	/// The NetBIOS name of the local computer. If the local computer is a node in a cluster, lpBuffer receives the NetBIOS name of the
	/// cluster virtual server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalDnsDomain</term>
	/// <term>
	/// The name of the DNS domain assigned to the local computer. If the local computer is a node in a cluster, lpBuffer receives the
	/// DNS domain name of the local computer, not the name of the cluster virtual server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalDnsFullyQualified</term>
	/// <term>
	/// The fully qualified DNS name that uniquely identifies the computer. If the local computer is a node in a cluster, lpBuffer
	/// receives the fully qualified DNS name of the local computer, not the name of the cluster virtual server. The fully qualified DNS
	/// name is a combination of the DNS host name and the DNS domain name, using the form HostName.DomainName.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalDnsHostname</term>
	/// <term>
	/// The DNS host name of the local computer. If the local computer is a node in a cluster, lpBuffer receives the DNS host name of the
	/// local computer, not the name of the cluster virtual server.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalNetBIOS</term>
	/// <term>
	/// The NetBIOS name of the local computer. If the local computer is a node in a cluster, lpBuffer receives the NetBIOS name of the
	/// local computer, not the name of the cluster virtual server.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpBuffer">
	/// <para>A pointer to a buffer that receives the computer name or the cluster virtual server name.</para>
	/// <para>
	/// The length of the name may be greater than MAX_COMPUTERNAME_LENGTH characters because DNS allows longer names. To ensure that
	/// this buffer is large enough, set this parameter to <c>NULL</c> and use the required buffer size returned in the lpnSize parameter.
	/// </para>
	/// </param>
	/// <param name="lpnSize">
	/// <para>
	/// On input, specifies the size of the buffer, in <c>TCHARs</c>. On output, receives the number of <c>TCHARs</c> copied to the
	/// destination buffer, not including the terminating <c>null</c> character.
	/// </para>
	/// <para>
	/// If the buffer is too small, the function fails and <c>GetLastError</c> returns ERROR_MORE_DATA. This parameter receives the size
	/// of the buffer required, including the terminating <c>null</c> character.
	/// </para>
	/// <para>If lpBuffer is <c>NULL</c>, this parameter must be zero.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. Possible values
	/// include the following.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The lpBuffer buffer is too small. The lpnSize parameter contains the number of bytes required to receive the name.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// BOOL WINAPI GetComputerNameEx( _In_ COMPUTER_NAME_FORMAT NameType, _Out_ LPTSTR lpBuffer, _Inout_ LPDWORD lpnSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724301(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724301")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetComputerNameEx(COMPUTER_NAME_FORMAT NameType, [SizeDef(nameof(lpnSize))] StringBuilder? lpBuffer, [Range(0, MAX_COMPUTERNAME_LENGTH + 1)] ref uint lpnSize);

	/// <summary>Gets a value indicating whether the developer drive is enabled.</summary>
	/// <returns>Returns a DEVELOPER_DRIVE_ENABLEMENT_STATE value indicating the developer drive enablement state.</returns>
	/// <remarks>
	/// <para>
	/// <c>GetDeveloperDriveEnablementState</c> returns information indicating whether the developer drive feature is enabled. If the
	/// developer drive feature is disabled, the <c>DEVELOPER_DRIVE_ENABLEMENT_STATE</c> returned indicates whether developer drive is
	/// disabled via group policy or via local policy.
	/// </para>
	/// <para>If <c>GetDeveloperDriveEnablementState</c> fails, it returns <c>DeveloperDriveEnablementStateError</c> and sets the last error.</para>
	/// <para>Examples</para>
	/// <para>
	/// The following example shows how to use <c>GetDeveloperDriveEnablementState</c> to determine whether the developer drive is enabled.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getdeveloperdriveenablementstate
	// DEVELOPER_DRIVE_ENABLEMENT_STATE GetDeveloperDriveEnablementState();
	[PInvokeData("sysinfoapi.h", MSDNShortId = "NF:sysinfoapi.GetDeveloperDriveEnablementState")]
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	public static extern DEVELOPER_DRIVE_ENABLEMENT_STATE GetDeveloperDriveEnablementState();

	/// <summary>Retrieves the value of the specified firmware environment variable.</summary>
	/// <param name="lpName">The name of the firmware environment variable. The pointer must not be <c>NULL</c>.</param>
	/// <param name="lpGuid">
	/// The GUID that represents the namespace of the firmware environment variable. The GUID can be a Guid value or a string in the format
	/// "{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}" where 'x' represents a hexadecimal value.
	/// </param>
	/// <param name="pBuffer">A pointer to a buffer that receives the value of the specified firmware environment variable.</param>
	/// <param name="nSize">The size of the pBuffer buffer, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is the number of bytes stored in the pBuffer buffer.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. Possible error codes
	/// include ERROR_INVALID_FUNCTION.
	/// </para>
	/// </returns>
	// DWORD WINAPI GetFirmwareEnvironmentVariable( _In_ LPCTSTR lpName, _In_ LPCTSTR lpGuid, _Out_ PVOID pBuffer, _In_ DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724325(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724325")]
	public static extern uint GetFirmwareEnvironmentVariable(string lpName,
		[In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(GuidToStringMarshaler), MarshalCookie = "B")] object lpGuid,
		[Out, SizeDef(nameof(nSize))] IntPtr pBuffer, uint nSize);

	/// <summary>
	/// <para>Retrieves the best estimate of the diagonal size of the built-in screen, in inches.</para>
	/// </summary>
	/// <param name="sizeInInches">The best estimate of the diagonal size of the built-in screen, in inches.</param>
	/// <returns>The result code indicating if the function succeeded or failed.</returns>
	// WINAPI GetIntegratedDisplaySize( _Out_ double *sizeInInches); https://msdn.microsoft.com/en-us/library/windows/desktop/dn904185(v=vs.85).aspx
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "dn904185")]
	public static extern HRESULT GetIntegratedDisplaySize(out double sizeInInches);

	/// <summary>
	/// <para>Retrieves the current local date and time.</para>
	/// <para>To retrieve the current date and time in Coordinated Universal Time (UTC) format, use the <c>GetSystemTime</c> function.</para>
	/// </summary>
	/// <param name="lpSystemTime">A pointer to a <c>SYSTEMTIME</c> structure to receive the current local date and time.</param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI GetLocalTime( _Out_ LPSYSTEMTIME lpSystemTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724338(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724338")]
	public static extern void GetLocalTime(out SYSTEMTIME lpSystemTime);

	/// <summary>
	/// <para>Retrieves information about logical processors and related hardware.</para>
	/// <para>
	/// To retrieve information about logical processors and related hardware, including processor groups, use the
	/// <c>GetLogicalProcessorInformationEx</c> function.
	/// </para>
	/// </summary>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives an array of <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION</c> structures. If the function fails,
	/// the contents of this buffer are undefined.
	/// </param>
	/// <param name="ReturnLength">
	/// On input, specifies the length of the buffer pointed to by Buffer, in bytes. If the buffer is large enough to contain all of the
	/// data, this function succeeds and ReturnLength is set to the number of bytes returned. If the buffer is not large enough to
	/// contain all of the data, the function fails, <c>GetLastError</c> returns ERROR_INSUFFICIENT_BUFFER, and ReturnLength is set to
	/// the buffer length required to contain all of the data. If the function fails with an error other than ERROR_INSUFFICIENT_BUFFER,
	/// the value of ReturnLength is undefined.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is TRUE and at least one <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION</c> structure is
	/// written to the output buffer.
	/// </para>
	/// <para>If the function fails, the return value is FALSE. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetLogicalProcessorInformation( _Out_ PSYSTEM_LOGICAL_PROCESSOR_INFORMATION Buffer, _Inout_ PDWORD ReturnLength); https://msdn.microsoft.com/en-us/library/windows/desktop/ms683194(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "ms683194")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLogicalProcessorInformation([SizeDef(nameof(ReturnLength), SizingMethod.Query | SizingMethod.Bytes | SizingMethod.CheckLastError)] ArrayPointer<SYSTEM_LOGICAL_PROCESSOR_INFORMATION> Buffer,
		ref uint ReturnLength);

	/// <summary>
	/// <para>Retrieves information about logical processors and related hardware.</para>
	/// <para>
	/// To retrieve information about logical processors and related hardware, including processor groups, use the
	/// <c>GetLogicalProcessorInformationEx</c> function.
	/// </para>
	/// </summary>
	/// <param name="info">
	/// An array of <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION</c> structures. If the function fails, the contents of this buffer are undefined.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is ERROR_SUCCESS and at least one <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION</c>
	/// structure is written to the output buffer.
	/// </para>
	/// <para>If the function fails, the return value has error information.</para>
	/// </returns>
	public static Win32Error GetLogicalProcessorInformation(out SYSTEM_LOGICAL_PROCESSOR_INFORMATION[]? info) => CallMethodWithTypedBuf(
			(ref uint sz) => BoolToLastErr(GetLogicalProcessorInformation(IntPtr.Zero, ref sz) || sz > 0),
			(IntPtr p, ref uint sz) => BoolToLastErr(GetLogicalProcessorInformation(p, ref sz)),
			out info,
			(p, sz) => p.ToArray<SYSTEM_LOGICAL_PROCESSOR_INFORMATION>((int)sz / Marshal.SizeOf<SYSTEM_LOGICAL_PROCESSOR_INFORMATION>()));

	/// <summary>Retrieves information about the relationships of logical processors and related hardware.</summary>
	/// <param name="RelationshipType">
	/// <para>
	/// The type of relationship to retrieve. This parameter can be one of the following <c>LOGICAL_PROCESSOR_RELATIONSHIP</c> values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RelationCache2</term>
	/// <term>Retrieves information about logical processors that share a cache.</term>
	/// </item>
	/// <item>
	/// <term>RelationNumaNode1</term>
	/// <term>Retrieves information about logical processors that are part of the same NUMA node.</term>
	/// </item>
	/// <item>
	/// <term>RelationProcessorCore0</term>
	/// <term>Retrieves information about logical processors that share a single processor core.</term>
	/// </item>
	/// <item>
	/// <term>RelationProcessorPackage3</term>
	/// <term>Retrieves information about logical processors that share a physical package.</term>
	/// </item>
	/// <item>
	/// <term>RelationGroup4</term>
	/// <term>Retrieves information about logical processors that share a processor group.</term>
	/// </item>
	/// <item>
	/// <term>RelationAll0xffff</term>
	/// <term>
	/// Retrieves information about logical processors for all relationship types (cache, NUMA node, processor core, physical package,
	/// and processor group).
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="Buffer">
	/// A pointer to a buffer that receives an array of <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX</c> structures. If the function fails,
	/// the contents of this buffer are undefined.
	/// </param>
	/// <param name="ReturnedLength">
	/// On input, specifies the length of the buffer pointed to by Buffer, in bytes. If the buffer is large enough to contain all of the
	/// data, this function succeeds and ReturnedLength is set to the number of bytes returned. If the buffer is not large enough to
	/// contain all of the data, the function fails, <c>GetLastError</c> returns ERROR_INSUFFICIENT_BUFFER, and ReturnedLength is set to
	/// the buffer length required to contain all of the data. If the function fails with an error other than ERROR_INSUFFICIENT_BUFFER,
	/// the value of ReturnedLength is undefined.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is TRUE and at least one <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX</c> structure is
	/// written to the output buffer.
	/// </para>
	/// <para>If the function fails, the return value is FALSE. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL GetLogicalProcessorInformationEx( _In_ LOGICAL_PROCESSOR_RELATIONSHIP RelationshipType, _Out_opt_
	// PSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX Buffer, _Inout_ PDWORD ReturnedLength); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405488(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405488")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP RelationshipType,
		[SizeDef(nameof(ReturnedLength), SizingMethod.Query | SizingMethod.Bytes | SizingMethod.CheckLastError)] ArrayPointer<SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX> Buffer, ref uint ReturnedLength);

	/// <summary>Retrieves information about the relationships of logical processors and related hardware.</summary>
	/// <param name="RelationshipType">
	/// <para>
	/// The type of relationship to retrieve. This parameter can be one of the following <c>LOGICAL_PROCESSOR_RELATIONSHIP</c> values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RelationCache2</term>
	/// <term>Retrieves information about logical processors that share a cache.</term>
	/// </item>
	/// <item>
	/// <term>RelationNumaNode1</term>
	/// <term>Retrieves information about logical processors that are part of the same NUMA node.</term>
	/// </item>
	/// <item>
	/// <term>RelationProcessorCore0</term>
	/// <term>Retrieves information about logical processors that share a single processor core.</term>
	/// </item>
	/// <item>
	/// <term>RelationProcessorPackage3</term>
	/// <term>Retrieves information about logical processors that share a physical package.</term>
	/// </item>
	/// <item>
	/// <term>RelationGroup4</term>
	/// <term>Retrieves information about logical processors that share a processor group.</term>
	/// </item>
	/// <item>
	/// <term>RelationAll0xffff</term>
	/// <term>
	/// Retrieves information about logical processors for all relationship types (cache, NUMA node, processor core, physical package,
	/// and processor group).
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="info">
	/// A safe handle that holds an array of <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX</c> pointers. If the function fails, the
	/// contents of this buffer are undefined.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is ERROR_SUCCESS and at least one <c>SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX</c>
	/// structure is written to the output buffer.
	/// </para>
	/// <para>If the function fails, the return value has error information.</para>
	/// </returns>
	public static Win32Error GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP RelationshipType, out SafeSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX_List info)
	{
		info = new SafeSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX_List(0);
		uint sz = 0;
		var err = BoolToLastErr(GetLogicalProcessorInformationEx(RelationshipType, IntPtr.Zero, ref sz) || sz > 0);
		if (err.Failed && err != Win32Error.ERROR_INSUFFICIENT_BUFFER) return err;
		var iinfo = new SafeSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX_List(sz);
		if ((err = BoolToLastErr(GetLogicalProcessorInformationEx(RelationshipType, iinfo, ref sz))).Succeeded)
			info = iinfo;
		else
			iinfo.Dispose();
		return err;
	}

	/// <summary>
	/// Retrieves information about the current system to an application running under WOW64. If the function is called from a 64-bit
	/// application, it is equivalent to the <c>GetSystemInfo</c> function.
	/// </summary>
	/// <param name="lpSystemInfo">A pointer to a <c>SYSTEM_INFO</c> structure that receives the information.</param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI GetNativeSystemInfo( _Out_ LPSYSTEM_INFO lpSystemInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724340(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724340")]
	public static extern void GetNativeSystemInfo(out SYSTEM_INFO lpSystemInfo);

	/// <summary>Determine whether the device is in Manufacturing Mode or not.</summary>
	/// <param name="pbEnabled">if set to <c>true</c> the device is in Manufacturing Mode.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetOsManufacturingMode([MarshalAs(UnmanagedType.Bool)] out bool pbEnabled);

	/// <summary>Undocumented.</summary>
	/// <param name="Flags">Undocumented flags.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetOsSafeBootMode(out uint Flags);

	/// <summary>Retrieves the amount of RAM that is physically installed on the computer.</summary>
	/// <param name="TotalMemoryInKilobytes">A pointer to a variable that receives the amount of physically installed RAM, in kilobytes.</param>
	/// <returns>
	/// <para>If the function succeeds, it returns <c>TRUE</c> and sets the TotalMemoryInKilobytes parameter to a nonzero value.</para>
	/// <para>
	/// If the function fails, it returns <c>FALSE</c> and does not modify the TotalMemoryInKilobytes parameter. To get extended error
	/// information, use the <c>GetLastError</c> function. Common errors are listed in the following table.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The TotalMemoryInKilobytes parameter is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>The System Management BIOS (SMBIOS) data is malformed.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// BOOL WINAPI GetPhysicallyInstalledSystemMemory( _Out_ PULONGLONG TotalMemoryInKilobytes); https://msdn.microsoft.com/en-us/library/windows/desktop/cc300158(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "cc300158")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetPhysicallyInstalledSystemMemory(out ulong TotalMemoryInKilobytes);

	/// <summary>
	/// Retrieves the cycle time each processor in the specified processor group spent executing deferred procedure calls (DPCs) and
	/// interrupt service routines (ISRs) since the processor became active.
	/// </summary>
	/// <param name="Group">The number of the processor group for which to retrieve the cycle time.</param>
	/// <param name="Buffer">
	/// A pointer to a buffer to receive a SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION structure for each processor in the group. On output,
	/// the DWORD64 <c>CycleTime</c> member of this structure is set to the cycle time for one processor.
	/// </param>
	/// <param name="ReturnedLength">
	/// The size of the buffer, in bytes. When the function returns, this parameter contains the number of bytes written to Buffer. If
	/// the buffer is too small for the data, the function fails with ERROR_INSUFFICIENT_BUFFER and sets the ReturnedLength parameter to
	/// the required buffer size.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use <c>GetLastError</c>.</para>
	/// <para>If the error value is ERROR_INSUFFICIENT_BUFFER, the ReturnedLength parameter contains the required buffer size.</para>
	/// </returns>
	// BOOL GetProcessorSystemCycleTime( _In_ USHORT Group, _Out_ PSYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION Buffer, _Inout_ PDWORD
	// ReturnedLength); https://msdn.microsoft.com/en-us/library/windows/desktop/dd405497(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "dd405497")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetProcessorSystemCycleTime(ushort Group,
		[SizeDef(nameof(ReturnedLength), SizingMethod.Query | SizingMethod.Bytes)] ArrayPointer<SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION> Buffer, ref uint ReturnedLength);

	/// <summary>
	/// Retrieves the cycle time each processor in the specified processor group spent executing deferred procedure calls (DPCs) and
	/// interrupt service routines (ISRs) since the processor became active.
	/// </summary>
	/// <param name="Group">The number of the processor group for which to retrieve the cycle time.</param>
	/// <param name="cycleTimes">
	/// A SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION structure for each processor in the group. On output, the DWORD64 <c>CycleTime</c>
	/// member of this structure is set to the cycle time for one processor.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, use <c>GetLastError</c>.</para>
	/// <para>If the error value is ERROR_INSUFFICIENT_BUFFER, the ReturnedLength parameter contains the required buffer size.</para>
	/// </returns>
	public static Win32Error GetProcessorSystemCycleTime(ushort Group, out SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION[]? cycleTimes) => CallMethodWithTypedBuf(
			(ref uint sz) => BoolToLastErr(GetProcessorSystemCycleTime(Group, IntPtr.Zero, ref sz) || sz > 0),
			(IntPtr p, ref uint sz) => BoolToLastErr(GetProcessorSystemCycleTime(Group, p, ref sz)),
			out cycleTimes,
			(p, sz) => p.ToArray<SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION>((int)sz / Marshal.SizeOf<SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION>()));

	/// <summary>
	/// <para>
	/// Retrieves the product type for the operating system on the local computer, and maps the type to the product types supported by
	/// the specified operating system.
	/// </para>
	/// <para>
	/// To retrieve product type information on versions of Windows prior to the minimum supported operating systems specified in the
	/// Requirements section, use the <c>GetVersionEx</c> function. You can also use the <c>OperatingSystemSKU</c> property of the
	/// <c>Win32_OperatingSystem</c> WMI class.
	/// </para>
	/// </summary>
	/// <param name="dwOSMajorVersion">
	/// <para>The major version number of the operating system. The minimum value is 6.</para>
	/// <para>
	/// The combination of the dwOSMajorVersion, dwOSMinorVersion, dwSpMajorVersion, and dwSpMinorVersion parameters describes the
	/// maximum target operating system version for the application. For example, Windows Vista and Windows Server 2008 are version
	/// 6.0.0.0 and Windows 7 and Windows Server 2008 R2 are version 6.1.0.0.
	/// </para>
	/// </param>
	/// <param name="dwOSMinorVersion">The minor version number of the operating system. The minimum value is 0.</param>
	/// <param name="dwSpMajorVersion">The major version number of the operating system service pack. The minimum value is 0.</param>
	/// <param name="dwSpMinorVersion">The minor version number of the operating system service pack. The minimum value is 0.</param>
	/// <param name="pdwReturnedProductType">
	/// <para>
	/// The product type. This parameter cannot be <c>NULL</c>. If the specified operating system is less than the current operating
	/// system, this information is mapped to the types supported by the specified operating system. If the specified operating system is
	/// greater than the highest supported operating system, this information is mapped to the types supported by the current operating system.
	/// </para>
	/// <para>This parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PRODUCT_BUSINESS0x00000006</term>
	/// <term>Business</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_BUSINESS_N0x00000010</term>
	/// <term>Business N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_CLUSTER_SERVER0x00000012</term>
	/// <term>HPC Edition</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_CLUSTER_SERVER_V0x00000040</term>
	/// <term>Server Hyper Core V</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_CORE0x00000065</term>
	/// <term>Windows 10 Home</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_CORE_COUNTRYSPECIFIC0x00000063</term>
	/// <term>Windows 10 Home China</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_CORE_N0x00000062</term>
	/// <term>Windows 10 Home N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_CORE_SINGLELANGUAGE0x00000064</term>
	/// <term>Windows 10 Home Single Language</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_DATACENTER_EVALUATION_SERVER0x00000050</term>
	/// <term>Server Datacenter (evaluation installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_DATACENTER_SERVER0x00000008</term>
	/// <term>Server Datacenter (full installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_DATACENTER_SERVER_CORE0x0000000C</term>
	/// <term>Server Datacenter (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_DATACENTER_SERVER_CORE_V0x00000027</term>
	/// <term>Server Datacenter without Hyper-V (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_DATACENTER_SERVER_V0x00000025</term>
	/// <term>Server Datacenter without Hyper-V (full installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_EDUCATION0x00000079</term>
	/// <term>Windows 10 Education</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_EDUCATION_N0x0000007A</term>
	/// <term>Windows 10 Education N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE0x00000004</term>
	/// <term>Windows 10 Enterprise</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_E0x00000046</term>
	/// <term>Windows 10 Enterprise E</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_EVALUATION0x00000048</term>
	/// <term>Windows 10 Enterprise Evaluation</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_N0x0000001B</term>
	/// <term>Windows 10 Enterprise N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_N_EVALUATION0x00000054</term>
	/// <term>Windows 10 Enterprise N Evaluation</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_S0x0000007D</term>
	/// <term>Windows 10 Enterprise 2015 LTSB</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_S_EVALUATION0x00000081</term>
	/// <term>Windows 10 Enterprise 2015 LTSB Evaluation</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_S_N0x0000007E</term>
	/// <term>Windows 10 Enterprise 2015 LTSB N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_S_N_EVALUATION0x00000082</term>
	/// <term>Windows 10 Enterprise 2015 LTSB N Evaluation</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_SERVER0x0000000A</term>
	/// <term>Server Enterprise (full installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_SERVER_CORE0x0000000E</term>
	/// <term>Server Enterprise (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_SERVER_CORE_V0x00000029</term>
	/// <term>Server Enterprise without Hyper-V (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_SERVER_IA640x0000000F</term>
	/// <term>Server Enterprise for Itanium-based Systems</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ENTERPRISE_SERVER_V0x00000026</term>
	/// <term>Server Enterprise without Hyper-V (full installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ESSENTIALBUSINESS_SERVER_ADDL0x0000003C</term>
	/// <term>Windows Essential Server Solution Additional</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ESSENTIALBUSINESS_SERVER_ADDLSVC0x0000003E</term>
	/// <term>Windows Essential Server Solution Additional SVC</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ESSENTIALBUSINESS_SERVER_MGMT0x0000003B</term>
	/// <term>Windows Essential Server Solution Management</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ESSENTIALBUSINESS_SERVER_MGMTSVC0x0000003D</term>
	/// <term>Windows Essential Server Solution Management SVC</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_BASIC0x00000002</term>
	/// <term>Home Basic</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_BASIC_E0x00000043</term>
	/// <term>Not supported</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_BASIC_N0x00000005</term>
	/// <term>Home Basic N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_PREMIUM0x00000003</term>
	/// <term>Home Premium</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_PREMIUM_E0x00000044</term>
	/// <term>Not supported</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_PREMIUM_N0x0000001A</term>
	/// <term>Home Premium N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_PREMIUM_SERVER0x00000022</term>
	/// <term>Windows Home Server 2011</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HOME_SERVER0x00000013</term>
	/// <term>Windows Storage Server 2008 R2 Essentials</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_HYPERV0x0000002A</term>
	/// <term>Microsoft Hyper-V Server</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_IOTUAP0x0000007B</term>
	/// <term>Windows 10 IoT Core</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_IOTUAPCOMMERCIAL0x00000083</term>
	/// <term>Windows 10 IoT Core Commercial</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_MEDIUMBUSINESS_SERVER_MANAGEMENT0x0000001E</term>
	/// <term>Windows Essential Business Server Management Server</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_MEDIUMBUSINESS_SERVER_MESSAGING0x00000020</term>
	/// <term>Windows Essential Business Server Messaging Server</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_MEDIUMBUSINESS_SERVER_SECURITY0x0000001F</term>
	/// <term>Windows Essential Business Server Security Server</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_MOBILE_CORE0x00000068</term>
	/// <term>Windows 10 Mobile</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_MOBILE_ENTERPRISE0x00000085</term>
	/// <term>Windows 10 Mobile Enterprise</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_MULTIPOINT_PREMIUM_SERVER0x0000004D</term>
	/// <term>Windows MultiPoint Server Premium (full installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_MULTIPOINT_STANDARD_SERVER0x0000004C</term>
	/// <term>Windows MultiPoint Server Standard (full installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_PRO_WORKSTATION0x000000A1</term>
	/// <term>Windows 10 Pro for Workstations</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_PRO_WORKSTATION_N0x000000A2</term>
	/// <term>Windows 10 Pro for Workstations N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_PROFESSIONAL0x00000030</term>
	/// <term>Windows 10 Pro</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_PROFESSIONAL_E0x00000045</term>
	/// <term>Not supported</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_PROFESSIONAL_N0x00000031</term>
	/// <term>Windows 10 Pro N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_PROFESSIONAL_WMC0x00000067</term>
	/// <term>Professional with Media Center</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SB_SOLUTION_SERVER0x00000032</term>
	/// <term>Windows Small Business Server 2011 Essentials</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SB_SOLUTION_SERVER_EM0x00000036</term>
	/// <term>Server For SB Solutions EM</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SERVER_FOR_SB_SOLUTIONS0x00000033</term>
	/// <term>Server For SB Solutions</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SERVER_FOR_SB_SOLUTIONS_EM0x00000037</term>
	/// <term>Server For SB Solutions EM</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SERVER_FOR_SMALLBUSINESS0x00000018</term>
	/// <term>Windows Server 2008 for Windows Essential Server Solutions</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SERVER_FOR_SMALLBUSINESS_V0x00000023</term>
	/// <term>Windows Server 2008 without Hyper-V for Windows Essential Server Solutions</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SERVER_FOUNDATION0x00000021</term>
	/// <term>Server Foundation</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SMALLBUSINESS_SERVER0x00000009</term>
	/// <term>Windows Small Business Server</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SMALLBUSINESS_SERVER_PREMIUM0x00000019</term>
	/// <term>Small Business Server Premium</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SMALLBUSINESS_SERVER_PREMIUM_CORE0x0000003F</term>
	/// <term>Small Business Server Premium (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_SOLUTION_EMBEDDEDSERVER0x00000038</term>
	/// <term>Windows MultiPoint Server</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STANDARD_EVALUATION_SERVER0x0000004F</term>
	/// <term>Server Standard (evaluation installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STANDARD_SERVER0x00000007</term>
	/// <term>Server Standard</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STANDARD_SERVER_CORE 0x0000000D</term>
	/// <term>Server Standard (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STANDARD_SERVER_CORE_V0x00000028</term>
	/// <term>Server Standard without Hyper-V (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STANDARD_SERVER_V0x00000024</term>
	/// <term>Server Standard without Hyper-V</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STANDARD_SERVER_SOLUTIONS0x00000034</term>
	/// <term>Server Solutions Premium</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STANDARD_SERVER_SOLUTIONS_CORE0x00000035</term>
	/// <term>Server Solutions Premium (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STARTER0x0000000B</term>
	/// <term>Starter</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STARTER_E0x00000042</term>
	/// <term>Not supported</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STARTER_N0x0000002F</term>
	/// <term>Starter N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_ENTERPRISE_SERVER0x00000017</term>
	/// <term>Storage Server Enterprise</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_ENTERPRISE_SERVER_CORE0x0000002E</term>
	/// <term>Storage Server Enterprise (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_EXPRESS_SERVER0x00000014</term>
	/// <term>Storage Server Express</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_EXPRESS_SERVER_CORE0x0000002B</term>
	/// <term>Storage Server Express (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_STANDARD_EVALUATION_SERVER0x00000060</term>
	/// <term>Storage Server Standard (evaluation installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_STANDARD_SERVER0x00000015</term>
	/// <term>Storage Server Standard</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_STANDARD_SERVER_CORE0x0000002C</term>
	/// <term>Storage Server Standard (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_WORKGROUP_EVALUATION_SERVER0x0000005F</term>
	/// <term>Storage Server Workgroup (evaluation installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_WORKGROUP_SERVER0x00000016</term>
	/// <term>Storage Server Workgroup</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_STORAGE_WORKGROUP_SERVER_CORE0x0000002D</term>
	/// <term>Storage Server Workgroup (core installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ULTIMATE0x00000001</term>
	/// <term>Ultimate</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ULTIMATE_E0x00000047</term>
	/// <term>Not supported</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_ULTIMATE_N0x0000001C</term>
	/// <term>Ultimate N</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_UNDEFINED0x00000000</term>
	/// <term>An unknown product</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_WEB_SERVER0x00000011</term>
	/// <term>Web Server (full installation)</term>
	/// </item>
	/// <item>
	/// <term>PRODUCT_WEB_SERVER_CORE0x0000001D</term>
	/// <term>Web Server (core installation)</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. This function fails if one of the input parameters is invalid.</para>
	/// </returns>
	// BOOL WINAPI GetProductInfo( _In_ DWORD dwOSMajorVersion, _In_ DWORD dwOSMinorVersion, _In_ DWORD dwSpMajorVersion, _In_ DWORD
	// dwSpMinorVersion, _Out_ PDWORD pdwReturnedProductType); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724358(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724358")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetProductInfo(uint dwOSMajorVersion, uint dwOSMinorVersion, uint dwSpMajorVersion, uint dwSpMinorVersion, out PRODUCT_TYPE pdwReturnedProductType);

	/// <summary>
	/// <para>
	/// Retrieves the path of the system directory. The system directory contains system files such as dynamic-link libraries and drivers.
	/// </para>
	/// <para>
	/// This function is provided primarily for compatibility. Applications should store code in the Program Files folder and persistent
	/// data in the Application Data folder in the user's profile. For more information, see <c>ShGetFolderPath</c>.
	/// </para>
	/// </summary>
	/// <param name="lpBuffer">
	/// A pointer to the buffer to receive the path. This path does not end with a backslash unless the system directory is the root
	/// directory. For example, if the system directory is named Windows\System32 on drive C, the path of the system directory retrieved
	/// by this function is C:\Windows\System32.
	/// </param>
	/// <param name="uSize">The maximum size of the buffer, in <c>TCHARs</c>.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the length, in <c>TCHARs</c>, of the string copied to the buffer, not including the
	/// terminating null character. If the length is greater than the size of the buffer, the return value is the size of the buffer
	/// required to hold the path, including the terminating null character.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// UINT WINAPI GetSystemDirectory( _Out_ LPTSTR lpBuffer, _In_ UINT uSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724373(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724373")]
	public static extern uint GetSystemDirectory([Optional, SizeDef(nameof(uSize), SizingMethod.QueryResultInReturn)] StringBuilder? lpBuffer, uint uSize);

	/// <summary>
	/// <para>
	/// Retrieves the path of the system directory. The system directory contains system files such as dynamic-link libraries and drivers.
	/// </para>
	/// <para>
	/// This function is provided primarily for compatibility. Applications should store code in the Program Files folder and persistent
	/// data in the Application Data folder in the user's profile. For more information, see <c>ShGetFolderPath</c>.
	/// </para>
	/// </summary>
	/// <returns>
	/// Receives the path. This path does not end with a backslash unless the system directory is the root directory. For example, if the
	/// system directory is named Windows\System32 on drive C, the path of the system directory retrieved by this function is C:\Windows\System32.
	/// </returns>
	public static string GetSystemDirectory() => CallMethodWithStrBuf(GetSystemDirectory, (uint)MAX_PATH, out var sysDir) != 0 ? sysDir : throw Win32Error.GetLastError().GetException()!;

	/// <summary>Retrieves the specified firmware table from the firmware table provider.</summary>
	/// <param name="FirmwareTableProviderSignature">
	/// <para>
	/// The identifier of the firmware table provider to which the query is to be directed. This parameter can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>'ACPI'</term>
	/// <term>The ACPI firmware table provider.</term>
	/// </item>
	/// <item>
	/// <term>'FIRM'</term>
	/// <term>The raw firmware table provider.</term>
	/// </item>
	/// <item>
	/// <term>'RSMB'</term>
	/// <term>The raw SMBIOS firmware table provider.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="FirmwareTableID">
	/// <para>The identifier of the firmware table. This identifier is little endian, you must reverse the characters in the string.</para>
	/// <para>
	/// For example, FACP is an ACPI provider, as described in the Signature field of the DESCRIPTION_HEADER structure in the ACPI
	/// specification (see http://www.acpi.info). Therefore, use 'PCAF' to specify the FACP table, as shown in the following example:
	/// </para>
	/// <para>For more information, see the Remarks section of the <c>EnumSystemFirmwareTables</c> function.</para>
	/// </param>
	/// <param name="pFirmwareTableBuffer">
	/// <para>
	/// A pointer to a buffer that receives the requested firmware table. If this parameter is <c>NULL</c>, the return value is the
	/// required buffer size.
	/// </para>
	/// <para>For more information on the contents of this buffer, see the Remarks section.</para>
	/// </param>
	/// <param name="BufferSize">The size of the pFirmwareTableBuffer buffer, in bytes.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the number of bytes written to the buffer. This value will always be less than or
	/// equal to BufferSize.
	/// </para>
	/// <para>
	/// If the function fails because the buffer is not large enough, the return value is the required buffer size, in bytes. This value
	/// is always greater than BufferSize.
	/// </para>
	/// <para>If the function fails for any other reason, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// UINT WINAPI GetSystemFirmwareTable( _In_ DWORD FirmwareTableProviderSignature, _In_ DWORD FirmwareTableID, _Out_ PVOID
	// pFirmwareTableBuffer, _In_ DWORD BufferSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724379(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724379")]
	public static extern uint GetSystemFirmwareTable(FirmwareTableProviderId FirmwareTableProviderSignature, uint FirmwareTableID,
		[Optional, SizeDef(nameof(BufferSize), SizingMethod.QueryResultInReturn)] IntPtr pFirmwareTableBuffer, [Optional] uint BufferSize);

	/// <summary>
	/// <para>Retrieves information about the current system.</para>
	/// <para>To retrieve accurate information for an application running on WOW64, call the <c>GetNativeSystemInfo</c> function.</para>
	/// </summary>
	/// <param name="lpSystemInfo">A pointer to a <c>SYSTEM_INFO</c> structure that receives the information.</param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI GetSystemInfo( _Out_ LPSYSTEM_INFO lpSystemInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724381(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724381")]
	public static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

	/// <summary>Retrieves the current size of the registry and the maximum size that the registry is allowed to attain on the system.</summary>
	/// <param name="pdwQuotaAllowed">
	/// A pointer to a variable that receives the maximum size that the registry is allowed to attain on this system, in bytes.
	/// </param>
	/// <param name="pdwQuotaUsed">A pointer to a variable that receives the current size of the registry, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetSystemRegistryQuota( _Out_opt_ PDWORD pdwQuotaAllowed, _Out_opt_ PDWORD pdwQuotaUsed); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724387(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724387")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetSystemRegistryQuota(out uint pdwQuotaAllowed, out uint pdwQuotaUsed);

	/// <summary>
	/// <para>Retrieves the current system date and time. The system time is expressed in Coordinated Universal Time (UTC).</para>
	/// <para>To retrieve the current system date and time in local time, use the <c>GetLocalTime</c> function.</para>
	/// </summary>
	/// <param name="lpSystemTime">
	/// A pointer to a <c>SYSTEMTIME</c> structure to receive the current system date and time. The lpSystemTime parameter must not be
	/// <c>NULL</c>. Using <c>NULL</c> will result in an access violation.
	/// </param>
	/// <returns>This function does not return a value or provide extended error information.</returns>
	// void WINAPI GetSystemTime( _Out_ LPSYSTEMTIME lpSystemTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724390(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724390")]
	public static extern void GetSystemTime(out SYSTEMTIME lpSystemTime);

	/// <summary>
	/// Determines whether the system is applying periodic time adjustments to its time-of-day clock, and obtains the value and period of
	/// any such adjustments.
	/// </summary>
	/// <param name="lpTimeAdjustment">
	/// A pointer to a variable that the function sets to the number of lpTimeIncrement100-nanosecond units added to the time-of-day
	/// clock for every period of time which actually passes as counted by the system. This value only has meaning if
	/// lpTimeAdjustmentDisabled is <c>FALSE</c>.
	/// </param>
	/// <param name="lpTimeIncrement">
	/// A pointer to a variable that the function sets to the interval in 100-nanosecond units at which the system will add
	/// lpTimeAdjustment to the time-of-day clock. This value only has meaning if lpTimeAdjustmentDisabled is <c>FALSE</c>.
	/// </param>
	/// <param name="lpTimeAdjustmentDisabled">
	/// <para>A pointer to a variable that the function sets to indicate whether periodic time adjustment is in effect.</para>
	/// <para>
	/// A value of <c>TRUE</c> indicates that periodic time adjustment is disabled, and the system time-of-day clock advances at the
	/// normal rate. In this mode, the system may adjust the time of day using its own internal time synchronization mechanisms. These
	/// internal time synchronization mechanisms may cause the time-of-day clock to change during the normal course of the system
	/// operation, which can include noticeable jumps in time as deemed necessary by the system.
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> indicates that periodic time adjustment is being used to adjust the time-of-day clock. For each
	/// lpTimeIncrement period of time that actually passes, lpTimeAdjustment will be added to the time of day. If the lpTimeAdjustment
	/// value is smaller than lpTimeIncrement, the system time-of-day clock will advance at a rate slower than normal. If the
	/// lpTimeAdjustment value is larger than lpTimeIncrement, the time-of-day clock will advance at a rate faster than normal. If
	/// lpTimeAdjustment equals lpTimeIncrement, the time-of-day clock will advance at its normal speed. The lpTimeAdjustment value can
	/// be set by calling <c>SetSystemTimeAdjustment</c>. The lpTimeIncrement value is fixed by the system upon start, and does not
	/// change during system operation. In this mode, the system will not interfere with the time adjustment scheme, and will not attempt
	/// to synchronize time of day on its own via other techniques.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GetSystemTimeAdjustment( _Out_ PDWORD lpTimeAdjustment, _Out_ PDWORD lpTimeIncrement, _Out_ PBOOL
	// lpTimeAdjustmentDisabled); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724394(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724394")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetSystemTimeAdjustment(out uint lpTimeAdjustment, out uint lpTimeIncrement, [MarshalAs(UnmanagedType.Bool)] out bool lpTimeAdjustmentDisabled);

	/// <summary>
	/// <para>
	/// Determines whether the system is applying periodic, programmed time adjustments to its time-of-day clock, and obtains the value
	/// and period of any such adjustments.
	/// </para>
	/// </summary>
	/// <param name="lpTimeAdjustment">
	/// <para>Returns the adjusted clock update frequency.</para>
	/// </param>
	/// <param name="lpTimeIncrement">
	/// <para>Returns the clock update frequency.</para>
	/// </param>
	/// <param name="lpTimeAdjustmentDisabled">
	/// <para>Returns an indicator which specifies whether the time adjustment is enabled.</para>
	/// <para>
	/// A value of <c>TRUE</c> indicates that periodic adjustment is disabled. In this case, the system may attempt to keep the
	/// time-of-day clock in sync using its own internal mechanisms. This may cause time-of-day to periodically jump to the "correct time."
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> indicates that periodic, programmed time adjustment is being used to serialize time-of-day, and the
	/// system will not interfere or attempt to synchronize time-of-day on its own.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is used in algorithms that synchronize the time-of-day with another time source, using a programmed clock
	/// adjustment. To do this, the system computes the adjusted clock update frequency, and then this function allows the caller to
	/// obtain that value.
	/// </para>
	/// <para>
	/// <c>Note</c> For a complete code sample on how to enable system-time privileges, adjust the system clock, and display clock
	/// values, see SetSystemTimeAdjustmentPrecise.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/sysinfoapi/nf-sysinfoapi-getsystemtimeadjustmentprecise BOOL
	// GetSystemTimeAdjustmentPrecise( PDWORD64 lpTimeAdjustment, PDWORD64 lpTimeIncrement, PBOOL lpTimeAdjustmentDisabled );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("sysinfoapi.h", MSDNShortId = "95EEE23D-01D8-49E1-BA64-49C07E8B1619")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetSystemTimeAdjustmentPrecise(out ulong lpTimeAdjustment, out ulong lpTimeIncrement, [MarshalAs(UnmanagedType.Bool)] out bool lpTimeAdjustmentDisabled);

	/// <summary>Retrieves the current system date and time. The information is in Coordinated Universal Time (UTC) format.</summary>
	/// <param name="lpSystemTimeAsFileTime">
	/// A pointer to a <c>FILETIME</c> structure to receive the current system date and time in UTC format.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI GetSystemTimeAsFileTime( _Out_ LPFILETIME lpSystemTimeAsFileTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724397(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724397")]
	public static extern void GetSystemTimeAsFileTime(out FILETIME lpSystemTimeAsFileTime);

	/// <summary>
	/// The <c>GetSystemTimePreciseAsFileTime</c> function retrieves the current system date and time with the highest possible level of
	/// precision (&lt;1us). The retrieved information is in Coordinated Universal Time (UTC) format.
	/// </summary>
	/// <param name="lpSystemTimeAsFileTime">
	/// <para>Type: <c>LPFILETIME</c></para>
	/// <para>A pointer to a <c>FILETIME</c> structure that contains the current system date and time in UTC format.</para>
	/// </param>
	/// <returns>This function doesn't return a value.</returns>
	// VOID WINAPI GetSystemTimePreciseAsFileTime( _Out_ LPFILETIME lpSystemTimeAsFileTime); https://msdn.microsoft.com/en-us/library/windows/desktop/hh706895(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "hh706895")]
	public static extern void GetSystemTimePreciseAsFileTime(out FILETIME lpSystemTimeAsFileTime);

	/// <summary>
	/// <para>Retrieves the path of the shared Windows directory on a multi-user system.</para>
	/// <para>
	/// This function is provided primarily for compatibility. Applications should store code in the Program Files folder and persistent
	/// data in the Application Data folder in the user's profile. For more information, see <c>ShGetFolderPath</c>.
	/// </para>
	/// </summary>
	/// <param name="lpBuffer">
	/// A pointer to the buffer to receive the path. This path does not end with a backslash unless the Windows directory is the root
	/// directory. For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this
	/// function is C:\Windows. If the system was installed in the root directory of drive C, the path retrieved is C:\.
	/// </param>
	/// <param name="uSize">The maximum size of the buffer specified by the lpBuffer parameter, in <c>TCHARs</c>.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the length of the string copied to the buffer, in <c>TCHARs</c>, not including the
	/// terminating null character.
	/// </para>
	/// <para>
	/// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// UINT WINAPI GetSystemWindowsDirectory( _Out_ LPTSTR lpBuffer, _In_ UINT uSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724403(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724403")]
	public static extern uint GetSystemWindowsDirectory([Optional, SizeDef(nameof(uSize), SizingMethod.QueryResultInReturn)] StringBuilder? lpBuffer, uint uSize);

	/// <summary>
	/// <para>Retrieves the path of the shared Windows directory on a multi-user system.</para>
	/// <para>
	/// This function is provided primarily for compatibility. Applications should store code in the Program Files folder and persistent
	/// data in the Application Data folder in the user's profile. For more information, see <c>ShGetFolderPath</c>.
	/// </para>
	/// </summary>
	/// <returns>
	/// A pointer to the buffer to receive the path. This path does not end with a backslash unless the Windows directory is the root
	/// directory. For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this
	/// function is C:\Windows. If the system was installed in the root directory of drive C, the path retrieved is C:\.
	/// </returns>
	public static string GetSystemWindowsDirectory() => CallMethodWithStrBuf(GetSystemWindowsDirectory, (uint)MAX_PATH, out var sysDir) != 0 ? sysDir : throw Win32Error.GetLastError().GetException()!;

	/// <summary>Retrieves the number of milliseconds that have elapsed since the system was started, up to 49.7 days.</summary>
	/// <returns>The return value is the number of milliseconds that have elapsed since the system was started.</returns>
	// DWORD WINAPI GetTickCount(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724408%28v=vs.85%29.aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724408")]
	public static extern uint GetTickCount();

	/// <summary>Retrieves the number of milliseconds that have elapsed since the system was started.</summary>
	/// <returns>The number of milliseconds.</returns>
	// ULONGLONG WINAPI GetTickCount64(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724411(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724411")]
	public static extern ulong GetTickCount64();

	/// <summary>
	/// <para>[ <c>GetVersion</c> may be altered or unavailable for releases after Windows 8.1. Instead, use the Version Helper functions]</para>
	/// <para>
	/// With the release of Windows 8.1, the behavior of the <c>GetVersion</c> API has changed in the value it will return for the
	/// operating system version. The value returned by the <c>GetVersion</c> function now depends on how the application is manifested.
	/// </para>
	/// <para>
	/// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2). Once an application
	/// is manifested for a given operating system version, <c>GetVersion</c> will always return the version that the application is
	/// manifested for in future releases. To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your
	/// application for Windows.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value includes the major and minor version numbers of the operating system in the low-order
	/// word, and information about the operating system platform in the high-order word.
	/// </para>
	/// <para>
	/// For all platforms, the low-order word contains the version number of the operating system. The low-order byte of this word
	/// specifies the major version number, in hexadecimal notation. The high-order byte specifies the minor version (revision) number,
	/// in hexadecimal notation. The high-order bit is zero, the next 7 bits represent the build number, and the low-order byte is 5.
	/// </para>
	/// </returns>
	// DWORD WINAPI GetVersion(void); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724439(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724439")]
	public static extern uint GetVersion();

	/// <summary>
	/// <para>[ <c>GetVersionEx</c> may be altered or unavailable for releases after Windows 8.1. Instead, use the Version Helper functions]</para>
	/// <para>
	/// With the release of Windows 8.1, the behavior of the <c>GetVersionEx</c> API has changed in the value it will return for the
	/// operating system version. The value returned by the <c>GetVersionEx</c> function now depends on how the application is manifested.
	/// </para>
	/// <para>
	/// Applications not manifested for Windows 8.1 or Windows 10 will return the Windows 8 OS version value (6.2). Once an application
	/// is manifested for a given operating system version, <c>GetVersionEx</c> will always return the version that the application is
	/// manifested for in future releases. To manifest your applications for Windows 8.1 or Windows 10, refer to Targeting your
	/// application for Windows.
	/// </para>
	/// </summary>
	/// <param name="lpVersionInfo">
	/// <para>An <c>OSVERSIONINFO</c> or <c>OSVERSIONINFOEX</c> structure that receives the operating system information.</para>
	/// <para>
	/// Before calling the <c>GetVersionEx</c> function, set the <c>dwOSVersionInfoSize</c> member of the structure as appropriate to
	/// indicate which data structure is being passed to this function.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. The function fails
	/// if you specify an invalid value for the <c>dwOSVersionInfoSize</c> member of the <c>OSVERSIONINFO</c> or <c>OSVERSIONINFOEX</c> structure.
	/// </para>
	/// </returns>
	// BOOL WINAPI GetVersionEx( _Inout_ LPOSVERSIONINFO lpVersionInfo); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724451(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724451")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetVersionEx(ref OSVERSIONINFOEX lpVersionInfo);

	/// <summary>
	/// <para>Retrieves the path of the Windows directory.</para>
	/// <para>
	/// This function is provided primarily for compatibility with legacy applications. New applications should store code in the Program
	/// Files folder and persistent data in the Application Data folder in the user's profile. For more information, see <c>ShGetFolderPath</c>.
	/// </para>
	/// </summary>
	/// <param name="lpBuffer">
	/// A pointer to a buffer that receives the path. This path does not end with a backslash unless the Windows directory is the root
	/// directory. For example, if the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this
	/// function is C:\Windows. If the system was installed in the root directory of drive C, the path retrieved is C:\.
	/// </param>
	/// <param name="uSize">
	/// The maximum size of the buffer specified by the lpBuffer parameter, in <c>TCHARs</c>. This value should be set to <c>MAX_PATH</c>.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is the length of the string copied to the buffer, in <c>TCHARs</c>, not including the
	/// terminating null character.
	/// </para>
	/// <para>
	/// If the length is greater than the size of the buffer, the return value is the size of the buffer required to hold the path.
	/// </para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// UINT WINAPI GetWindowsDirectory( _Out_ LPTSTR lpBuffer, _In_ UINT uSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724454(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724454")]
	public static extern uint GetWindowsDirectory([Optional, SizeDef(nameof(uSize), SizingMethod.QueryResultInReturn)] StringBuilder? lpBuffer, uint uSize);

	/// <summary>
	/// <para>Retrieves the path of the Windows directory.</para>
	/// <para>
	/// This function is provided primarily for compatibility with legacy applications. New applications should store code in the Program
	/// Files folder and persistent data in the Application Data folder in the user's profile. For more information, see <c>ShGetFolderPath</c>.
	/// </para>
	/// </summary>
	/// <returns>
	/// Receives the path. This path does not end with a backslash unless the Windows directory is the root directory. For example, if
	/// the Windows directory is named Windows on drive C, the path of the Windows directory retrieved by this function is C:\Windows. If
	/// the system was installed in the root directory of drive C, the path retrieved is C:\.
	/// </returns>
	public static string GetWindowsDirectory() => CallMethodWithStrBuf(GetWindowsDirectory, (uint)MAX_PATH, out var sysDir) != 0 ? sysDir : throw Win32Error.GetLastError().GetException()!;

	/// <summary>
	/// <para>[ <c>GlobalMemoryStatus</c> can return incorrect information. Use the <c>GlobalMemoryStatusEx</c> function instead.]</para>
	/// <para>Retrieves information about the system's current usage of both physical and virtual memory.</para>
	/// </summary>
	/// <param name="lpBuffer">
	/// A pointer to a <c>MEMORYSTATUS</c> structure. The <c>GlobalMemoryStatus</c> function stores information about current memory
	/// availability into this structure.
	/// </param>
	/// <returns>This function does not return a value.</returns>
	// void WINAPI GlobalMemoryStatus( _Out_ LPMEMORYSTATUS lpBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366586(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366586")]
	public static extern void GlobalMemoryStatus(out MEMORYSTATUS lpBuffer);

	/// <summary>Retrieves information about the system's current usage of both physical and virtual memory.</summary>
	/// <param name="lpBuffer">A pointer to a <c>MEMORYSTATUSEX</c> structure that receives information about current memory availability.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI GlobalMemoryStatusEx( _Inout_ LPMEMORYSTATUSEX lpBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/aa366589(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("WinBase.h", MSDNShortId = "aa366589")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GlobalMemoryStatusEx(ref MEMORYSTATUSEX lpBuffer);

	/// <summary>Queries whether user-mode Hardware-enforced Stack Protection is available for the specified environment.</summary>
	/// <param name="UserCetEnvironment">
	/// <para>The environment to query. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>USER_CET_ENVIRONMENT_WIN32_PROCESS 0x00000000UL</term>
	/// <term>The Win32 environment.</term>
	/// </item>
	/// <item>
	/// <term>USER_CET_ENVIRONMENT_SGX2_ENCLAVE 0x00000002UL</term>
	/// <term>The Intel Software Guard Extensions 2 (SGX2) enclave environment.</term>
	/// </item>
	/// <item>
	/// <term>USER_CET_ENVIRONMENT_VBS_ENCLAVE 0x00000010UL</term>
	/// <term>The virtualization-based security (VBS) enclave environment.</term>
	/// </item>
	/// <item>
	/// <term>USER_CET_ENVIRONMENT_VBS_BASIC_ENCLAVE 0x00000011UL</term>
	/// <term>The virtualization-based security (VBS) basic enclave environment.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>TRUE if user-mode Hardware-enforced Stack Protection is available for the specified environment, FALSE otherwise.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-isusercetavailableinenvironment
	// BOOL IsUserCetAvailableInEnvironment( DWORD UserCetEnvironment );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("sysinfoapi.h", MSDNShortId = "NF:sysinfoapi.IsUserCetAvailableInEnvironment")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsUserCetAvailableInEnvironment(USER_CET_ENVIRONMENT UserCetEnvironment);

	/// <summary>
	/// Installs the certificate information specified in the resource file, which is linked into the ELAM driver at build time. This API
	/// is used by anti-malware vendors to launch the anti-malware software's user-mode service as protected. For more information, see
	/// Protecting Anti-Malware Services.
	/// </summary>
	/// <param name="ELAMFile">
	/// A handle to an ELAM driver file which contains the resource file with the certificate information. The handle to the ELAM driver
	/// file must be opened for read access only and must not be shared for write access.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is TRUE.</para>
	/// <para>If the function fails, the return value is FALSE. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI InstallELAMCertificateInfo( _In_ HANDLE ELAMFile); https://msdn.microsoft.com/en-us/library/windows/desktop/dn369255(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Windows.h", MSDNShortId = "dn369255")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool InstallELAMCertificateInfo([In] HFILE ELAMFile);

	/// <summary>
	/// <para>
	/// Sets a new NetBIOS name for the local computer. The name is stored in the registry and the name change takes effect the next time
	/// the user restarts the computer.
	/// </para>
	/// <para>
	/// If the local computer is a node in a cluster, <c>SetComputerName</c> sets NetBIOS name of the local computer, not that of the
	/// cluster virtual server.
	/// </para>
	/// <para>To set the DNS host name or the DNS domain name, call the <c>SetComputerNameEx</c> function.</para>
	/// </summary>
	/// <param name="lpComputerName">
	/// <para>
	/// The computer name that will take effect the next time the computer is started. The name must not be longer than
	/// MAX_COMPUTERNAME_LENGTH characters.
	/// </para>
	/// <para>
	/// The standard character set includes letters, numbers, and the following symbols: ! @ # $ % ^ &amp; ' ) ( . - _ { } ~ . If this
	/// parameter contains one or more characters that are outside the standard character set, <c>SetComputerName</c> returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetComputerName( _In_ LPCTSTR lpComputerName); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724930(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724930")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetComputerName([MaxLength((int)MAX_COMPUTERNAME_LENGTH)] string lpComputerName);

	/// <summary>
	/// Sets a new NetBIOS or DNS name for the local computer. Name changes made by <c>SetComputerNameEx</c> do not take effect until the
	/// user restarts the computer.
	/// </summary>
	/// <param name="NameType">
	/// <para>
	/// The type of name to be set. This parameter can be one of the following values from the <c>COMPUTER_NAME_FORMAT</c> enumeration type.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ComputerNamePhysicalDnsDomain</term>
	/// <term>Sets the primary DNS suffix of the computer.</term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalDnsHostname</term>
	/// <term>
	/// Sets the NetBIOS and the Computer Name (the first label of the full DNS name) to the name specified in lpBuffer. If the name
	/// exceeds MAX_COMPUTERNAME_LENGTH characters, the NetBIOS name is truncated to MAX_COMPUTERNAME_LENGTH characters, not including
	/// the terminating null character.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalNetBIOS</term>
	/// <term>
	/// Sets the NetBIOS name to the name specified in lpBuffer. The name cannot exceed MAX_COMPUTERNAME_LENGTH characters, not including
	/// the terminating null character. Warning: Using this option to set the NetBIOS name breaks the convention of interdependent
	/// NetBIOS and DNS names. Applications that use the DnsHostnameToComputerName function to derive the NetBIOS name from the first
	/// label of the DNS name will fail if this convention is broken.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpBuffer">
	/// The new name. The name cannot include control characters, leading or trailing spaces, or any of the following characters: " / \ [
	/// ] : | &lt; &gt; + = ; , ?
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetComputerNameEx( _In_ COMPUTER_NAME_FORMAT NameType, _In_ LPCTSTR lpBuffer); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724931(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724931")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetComputerNameEx(COMPUTER_NAME_FORMAT NameType, string lpBuffer);

	/// <summary>
	/// Sets a new NetBIOS or DNS name for the local computer. Name changes made by <c>SetComputerNameEx</c> do not take effect until the
	/// user restarts the computer.
	/// </summary>
	/// <param name="NameType">
	/// <para>
	/// The type of name to be set. This parameter can be one of the following values from the <c>COMPUTER_NAME_FORMAT</c> enumeration type.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ComputerNamePhysicalDnsDomain</term>
	/// <term>Sets the primary DNS suffix of the computer.</term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalDnsHostname</term>
	/// <term>
	/// Sets the NetBIOS and the Computer Name (the first label of the full DNS name) to the name specified in lpBuffer. If the name
	/// exceeds MAX_COMPUTERNAME_LENGTH characters, the NetBIOS name is truncated to MAX_COMPUTERNAME_LENGTH characters, not including
	/// the terminating null character.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ComputerNamePhysicalNetBIOS</term>
	/// <term>
	/// Sets the NetBIOS name to the name specified in lpBuffer. The name cannot exceed MAX_COMPUTERNAME_LENGTH characters, not including
	/// the terminating null character. Warning: Using this option to set the NetBIOS name breaks the convention of interdependent
	/// NetBIOS and DNS names. Applications that use the DnsHostnameToComputerName function to derive the NetBIOS name from the first
	/// label of the DNS name will fail if this convention is broken.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="Flags">The flags.</param>
	/// <param name="lpBuffer">
	/// The new name. The name cannot include control characters, leading or trailing spaces, or any of the following characters: " / \ [
	/// ] : | &lt; &gt; + = ; , ?
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	[DllImport(Lib.Kernel32, SetLastError = true, EntryPoint = "SetComputerNameEx2W", CharSet = CharSet.Unicode)]
	[PInvokeData("Winbase.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetComputerNameEx2(COMPUTER_NAME_FORMAT NameType, SCEX2 Flags, string lpBuffer);

	/// <summary>Sets the value of the specified firmware environment variable.</summary>
	/// <param name="lpName">The name of the firmware environment variable. The pointer must not be <c>NULL</c>.</param>
	/// <param name="lpGuid">
	/// The GUID that represents the namespace of the firmware environment variable. The GUID can be a Guid value or a string in the format
	/// "{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}" where 'x' represents a hexadecimal value.
	/// </param>
	/// <param name="pBuffer">A pointer to the new value for the firmware environment variable.</param>
	/// <param name="nSize">
	/// The size of the pBuffer buffer, in bytes. If this parameter is zero, the firmware environment variable is deleted.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a nonzero value.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>. Possible error
	/// codes include ERROR_INVALID_FUNCTION.
	/// </para>
	/// </returns>
	// BOOL WINAPI SetFirmwareEnvironmentVariable( _In_ LPCTSTR lpName, _In_ LPCTSTR lpGuid, _In_ PVOID pBuffer, _In_ DWORD nSize); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724934(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724934")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetFirmwareEnvironmentVariable(string lpName, [In, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(GuidToStringMarshaler), MarshalCookie = "B")] object lpGuid,
		[In, SizeDef(nameof(nSize))] IntPtr pBuffer, uint nSize);

	/// <summary>Sets the current local time and date.</summary>
	/// <param name="lpSystemTime">
	/// <para>A pointer to a <c>SYSTEMTIME</c> structure that contains the new local date and time.</para>
	/// <para>The <c>wDayOfWeek</c> member of the <c>SYSTEMTIME</c> structure is ignored.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetLocalTime( _In_ const SYSTEMTIME *lpSystemTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724936(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724936")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetLocalTime(in SYSTEMTIME lpSystemTime);

	/// <summary>Sets the current system time and date. The system time is expressed in Coordinated Universal Time (UTC).</summary>
	/// <param name="lpSystemTime">
	/// <para>A pointer to a <c>SYSTEMTIME</c> structure that contains the new system date and time.</para>
	/// <para>The <c>wDayOfWeek</c> member of the <c>SYSTEMTIME</c> structure is ignored.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL WINAPI SetSystemTime( _In_ const SYSTEMTIME *lpSystemTime); https://msdn.microsoft.com/en-us/library/windows/desktop/ms724942(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms724942")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetSystemTime(in SYSTEMTIME lpSystemTime);

	/// <summary>
	/// Enables or disables periodic time adjustments to the system's time-of-day clock. When enabled, such time adjustments can be used to
	/// synchronize the time of day with some other source of time information.
	/// </summary>
	/// <param name="dwTimeAdjustment">
	/// <para>
	/// This value represents the number of 100-nanosecond units added to the system time-of-day for each <c>lpTimeIncrement</c> period of
	/// time that actually passes. Call GetSystemTimeAdjustment to obtain the <c>lpTimeIncrement</c> value. See remarks.
	/// </para>
	/// <para><c>Note</c>
	/// <para></para>
	/// Currently, Windows Vista and Windows 7 machines will lose any time adjustments set less than 16.
	/// </para>
	/// </param>
	/// <param name="bTimeAdjustmentDisabled">
	/// <para>The time adjustment mode that the system is to use. Periodic system time adjustments can be disabled or enabled.</para>
	/// <para>
	/// A value of <c>TRUE</c> specifies that periodic time adjustment is to be disabled. When disabled, the value of <c>dwTimeAdjustment</c>
	/// is ignored, and the system may adjust the time of day using its own internal time synchronization mechanisms. These internal time
	/// synchronization mechanisms may cause the time-of-day clock to change during the normal course of the system operation, which can
	/// include noticeable jumps in time as deemed necessary by the system.
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> specifies that periodic time adjustment is to be enabled, and will be used to adjust the time-of-day clock.
	/// The system will not interfere with the time adjustment scheme, and will not attempt to synchronize time of day on its own.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is non-zero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. One way the function can fail
	/// is if the caller does not possess the SE_SYSTEMTIME_NAME privilege.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The GetSystemTimeAdjustment and <c>SetSystemTimeAdjustment</c> functions support algorithms that synchronize the time-of-day clock,
	/// reported via GetSystemTime and GetLocalTime, with another time source using a periodic time adjustment.
	/// </para>
	/// <para>The <c>SetSystemTimeAdjustment</c> function supports two modes of time synchronization:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Mode</term>
	/// <term>Behavior</term>
	/// </listheader>
	/// <item>
	/// <definition>Time-Adjustment Disabled</definition>
	/// <definition>
	/// For this mode, <c>bTimeAdjustmentDisabled</c> is set to <c>TRUE</c>. In this mode, the value of <c>dwTimeAdjustment</c> is ignored,
	/// and the system may adjust the time of day using its own internal time synchronization mechanisms. These internal time synchronization
	/// mechanisms may cause the time-of-day clock to change during the normal course of the system operation, which can include noticeable
	/// jumps in time as deemed necessary by the system.
	/// </definition>
	/// </item>
	/// <item>
	/// <definition>Time-Adjustment Enabled</definition>
	/// <definition>
	/// For this mode, <c>bTimeAdjustmentDisabled</c> is set to <c>FALSE</c>. For each <c>lpTimeIncrement</c> period of time that actually
	/// passes, <c>dwTimeAdjustment</c> will be added to the time of day. The period of time represented by <c>lpTimeIncrement</c> can be
	/// determined by calling GetSystemTimeAdjustment. The <c>lpTimeIncrement</c> value is fixed by the system upon start and does not change
	/// during system operation and is completely independent of the system’s internal clock interrupt resolution at any given time. Given
	/// this, the <c>lpTimeIncrement</c> value simply expresses a period of time for which <c>dwTimeAdjustment</c> will be applied to the
	/// system’s time-of-day clock. If the <c>dwTimeAdjustment</c> value is smaller than <c>lpTimeIncrement</c>, the time-of-day clock will
	/// advance at a rate slower than normal. If the <c>dwTimeAdjustment</c> value is larger than <c>lpTimeIncrement</c>, the time-of-day
	/// clock will advance at a rate faster than normal. The degree to which the time-of-day-clock will run faster or slower depends on how
	/// far the <c>dwTimeAdjustment</c> value is above or below the <c>lpTimeIncrement</c> value. If <c>dwTimeAdjustment</c> equals
	/// <c>lpTimeIncrement</c>, the time-of-day clock will advance at normal speed.
	/// </definition>
	/// </item>
	/// </list>
	/// <para>
	/// An application must have system-time privilege (the SE_SYSTEMTIME_NAME privilege) for this function to succeed. The
	/// SE_SYSTEMTIME_NAME privilege is disabled by default. Use the AdjustTokenPrivileges function to enable the privilege before calling
	/// <c>SetSystemTimeAdjustment</c>, and then to disable the privilege after the <c>SetSystemTimeAdjustment</c> call. For more
	/// information, see Running with Special Privileges.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-setsystemtimeadjustment
	// BOOL SetSystemTimeAdjustment( [in] DWORD dwTimeAdjustment, [in] BOOL bTimeAdjustmentDisabled );
	[PInvokeData("sysinfoapi.h", MSDNShortId = "NF:sysinfoapi.SetSystemTimeAdjustment")]
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetSystemTimeAdjustment(uint dwTimeAdjustment, [MarshalAs(UnmanagedType.Bool)] bool bTimeAdjustmentDisabled);

	/// <summary>
	/// Enables or disables periodic time adjustments to the system's time-of-day clock. When enabled, such time adjustments can be used
	/// to synchronize the time of day with some other source of time information.
	/// </summary>
	/// <param name="dwTimeAdjustment">Supplies the adjusted clock update frequency.</param>
	/// <param name="bTimeAdjustmentDisabled">
	/// <para>Supplies a flag which specifies the time adjustment mode that the system is to use.</para>
	/// <para>
	/// A value of <c>TRUE</c> indicates that the system should synchronize time-of-day using its own internal mechanisms. In this case,
	/// the value of dwTimeAdjustment is ignored.
	/// </para>
	/// <para>
	/// A value of <c>FALSE</c> indicates that the application is in control, and that the specified value of dwTimeAdjustment is to be
	/// added to the time-of-day clock at each clock update interrupt.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is non-zero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. One way the function can
	/// fail is if the caller does not possess the SE_SYSTEMTIME_NAME privilege.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To use this function, the caller must have system-time privilege (SE_SYSTEMTIME_NAME). This privilege is disabled by default. Use
	/// the AdjustTokenPrivileges function to enable the privilege before calling this function, then disable the privilege after the
	/// function call. For more information, see the code example below.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// This sample demonstrates how to enable system-time privileges, adjust the system clock using GetSystemTimeAdjustmentPrecise and
	/// <c>SetSystemTimeAdjustmentPrecise</c>, and how to neatly print the current system-time adjustments.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/sysinfoapi/nf-sysinfoapi-setsystemtimeadjustmentprecise BOOL
	// SetSystemTimeAdjustmentPrecise( DWORD64 dwTimeAdjustment, BOOL bTimeAdjustmentDisabled );
	[DllImport(Lib.KernelBase, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("sysinfoapi.h", MSDNShortId = "8B429BFC-9781-4434-9A2F-9E50E2BF299A")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetSystemTimeAdjustmentPrecise(ulong dwTimeAdjustment, [MarshalAs(UnmanagedType.Bool)] bool bTimeAdjustmentDisabled);

	/// <summary>
	/// Compares a set of operating system version requirements to the corresponding values for the currently running version of the
	/// system. This function is subject to manifest-based behavior. For more information, see the Remarks section.
	/// </summary>
	/// <param name="lpVersionInfo">
	/// <para>
	/// A pointer to an <c>OSVERSIONINFOEX</c> structure containing the operating system version requirements to compare. The dwTypeMask
	/// parameter indicates the members of this structure that contain information to compare.
	/// </para>
	/// <para>
	/// You must set the <c>dwOSVersionInfoSize</c> member of this structure to . You must also specify valid data for the members
	/// indicated by dwTypeMask. The function ignores structure members for which the corresponding dwTypeMask bit is not set.
	/// </para>
	/// </param>
	/// <param name="dwTypeMask">
	/// <para>
	/// A mask that indicates the members of the <c>OSVERSIONINFOEX</c> structure to be tested. This parameter can be one or more of the
	/// following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VER_BUILDNUMBER0x0000004</term>
	/// <term>dwBuildNumber</term>
	/// </item>
	/// <item>
	/// <term>VER_MAJORVERSION0x0000002</term>
	/// <term>
	/// dwMajorVersionIf you are testing the major version, you must also test the minor version and the service pack major and minor versions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>VER_MINORVERSION0x0000001</term>
	/// <term>dwMinorVersion</term>
	/// </item>
	/// <item>
	/// <term>VER_PLATFORMID0x0000008</term>
	/// <term>dwPlatformId</term>
	/// </item>
	/// <item>
	/// <term>VER_SERVICEPACKMAJOR0x0000020</term>
	/// <term>wServicePackMajor</term>
	/// </item>
	/// <item>
	/// <term>VER_SERVICEPACKMINOR0x0000010</term>
	/// <term>wServicePackMinor</term>
	/// </item>
	/// <item>
	/// <term>VER_SUITENAME0x0000040</term>
	/// <term>wSuiteMask</term>
	/// </item>
	/// <item>
	/// <term>VER_PRODUCT_TYPE0x0000080</term>
	/// <term>wProductType</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwlConditionMask">
	/// The type of comparison to be used for each <c>lpVersionInfo</c> member being compared. To build this value, call the
	/// <c>VerSetConditionMask</c> function or the <c>VER_SET_CONDITION</c> macro once for each <c>OSVERSIONINFOEX</c> member being compared.
	/// </param>
	/// <returns>
	/// <para>If the currently running operating system satisfies the specified requirements, the return value is a nonzero value.</para>
	/// <para>If the current system does not satisfy the requirements, the return value is zero and <c>GetLastError</c> returns ERROR_OLD_WIN_VERSION.</para>
	/// <para>If the function fails, the return value is zero and <c>GetLastError</c> returns an error code other than ERROR_OLD_WIN_VERSION.</para>
	/// </returns>
	// BOOL WINAPI VerifyVersionInfo( _In_ LPOSVERSIONINFOEX lpVersionInfo, _In_ DWORD dwTypeMask, _In_ DWORDLONG dwlConditionMask); https://msdn.microsoft.com/en-us/library/windows/desktop/ms725492(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("Winbase.h", MSDNShortId = "ms725492")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool VerifyVersionInfo(ref OSVERSIONINFOEX lpVersionInfo, VERSION_MASK dwTypeMask, ulong dwlConditionMask);

	/// <summary>
	/// Sets the bits of a 64-bit value to indicate the comparison operator to use for a specified operating system version attribute.
	/// This function is used to build the dwlConditionMask parameter of the <c>VerifyVersionInfo</c> function.
	/// </summary>
	/// <param name="dwlConditionMask">
	/// <para>
	/// A value to be passed as the dwlConditionMask parameter of the <c>VerifyVersionInfo</c> function. The function stores the
	/// comparison information in the bits of this variable.
	/// </para>
	/// <para>
	/// Before the first call to <c>VerSetCondition</c>, initialize this variable to zero. For subsequent calls, pass in the variable
	/// used in the previous call.
	/// </para>
	/// </param>
	/// <param name="dwTypeBitMask">
	/// <para>
	/// A mask that indicates the member of the <c>OSVERSIONINFOEX</c> structure whose comparison operator is being set. This value
	/// corresponds to one of the bits specified in the dwTypeMask parameter for the <c>VerifyVersionInfo</c> function. This parameter
	/// can be one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VER_BUILDNUMBER0x0000004</term>
	/// <term>dwBuildNumber</term>
	/// </item>
	/// <item>
	/// <term>VER_MAJORVERSION0x0000002</term>
	/// <term>dwMajorVersion</term>
	/// </item>
	/// <item>
	/// <term>VER_MINORVERSION0x0000001</term>
	/// <term>dwMinorVersion</term>
	/// </item>
	/// <item>
	/// <term>VER_PLATFORMID0x0000008</term>
	/// <term>dwPlatformId</term>
	/// </item>
	/// <item>
	/// <term>VER_PRODUCT_TYPE0x0000080</term>
	/// <term>wProductType</term>
	/// </item>
	/// <item>
	/// <term>VER_SERVICEPACKMAJOR0x0000020</term>
	/// <term>wServicePackMajor</term>
	/// </item>
	/// <item>
	/// <term>VER_SERVICEPACKMINOR0x0000010</term>
	/// <term>wServicePackMinor</term>
	/// </item>
	/// <item>
	/// <term>VER_SUITENAME0x0000040</term>
	/// <term>wSuiteMask</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwConditionMask">
	/// <para>
	/// The operator to be used for the comparison. The <c>VerifyVersionInfo</c> function uses this operator to compare a specified
	/// attribute value to the corresponding value for the currently running system.
	/// </para>
	/// <para>For all values of dwTypeBitMask other than VER_SUITENAME, this parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VER_EQUAL1</term>
	/// <term>The current value must be equal to the specified value.</term>
	/// </item>
	/// <item>
	/// <term>VER_GREATER2</term>
	/// <term>The current value must be greater than the specified value.</term>
	/// </item>
	/// <item>
	/// <term>VER_GREATER_EQUAL3</term>
	/// <term>The current value must be greater than or equal to the specified value.</term>
	/// </item>
	/// <item>
	/// <term>VER_LESS4</term>
	/// <term>The current value must be less than the specified value.</term>
	/// </item>
	/// <item>
	/// <term>VER_LESS_EQUAL5</term>
	/// <term>The current value must be less than or equal to the specified value.</term>
	/// </item>
	/// </list>
	/// </para>
	/// <para>If dwTypeBitMask is VER_SUITENAME, this parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>VER_AND6</term>
	/// <term>All product suites specified in the wSuiteMask member must be present in the current system.</term>
	/// </item>
	/// <item>
	/// <term>VER_OR7</term>
	/// <term>At least one of the specified product suites must be present in the current system.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <returns>The function returns the condition mask value.</returns>
	// ULONGLONG WINAPI VerSetConditionMask( _In_ ULONGLONG dwlConditionMask, _In_ DWORD dwTypeBitMask, _In_ BYTE dwConditionMask); https://msdn.microsoft.com/en-us/library/windows/desktop/ms725493(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winnt.h", MSDNShortId = "ms725493")]
	public static extern ulong VerSetConditionMask(ulong dwlConditionMask, VERSION_MASK dwTypeBitMask, VERSION_CONDITION dwConditionMask);

	/// <summary>Describes the cache attributes.</summary>
	// typedef struct _CACHE_DESCRIPTOR { BYTE Level; BYTE Associativity; WORD LineSize; DWORD Size; PROCESSOR_CACHE_TYPE Type;} CACHE_DESCRIPTOR,
	// *PCACHE_DESCRIPTOR; https://msdn.microsoft.com/en-us/library/windows/desktop/ms681979(v=vs.85).aspx
	[PInvokeData("WinNT.h", MSDNShortId = "ms681979")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct CACHE_DESCRIPTOR
	{
		/// <summary>
		/// <para>The cache level. This member can currently be one of the following values; other values may be supported in the future.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>L1</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>L2</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>L3</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public byte Level;

		/// <summary>The cache associativity. If this member is CACHE_FULLY_ASSOCIATIVE (0xFF), the cache is fully associative.</summary>
		public byte Associativity;

		/// <summary>The cache line size, in bytes.</summary>
		public ushort LineSize;

		/// <summary>The cache size, in bytes.</summary>
		public uint Size;

		/// <summary>The cache type. This member is a <c>PROCESSOR_CACHE_TYPE</c> value.</summary>
		public PROCESSOR_CACHE_TYPE Type;
	}

	/// <summary>Describes cache attributes. This structure is used with the GetLogicalProcessorInformationEx function.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_cache_relationship typedef struct _CACHE_RELATIONSHIP { BYTE
	// Level; BYTE Associativity; WORD LineSize; DWORD CacheSize; PROCESSOR_CACHE_TYPE Type; BYTE Reserved[20]; GROUP_AFFINITY
	// GroupMask; } CACHE_RELATIONSHIP, *PCACHE_RELATIONSHIP;
	[PInvokeData("winnt.h", MSDNShortId = "f8fe521b-02d6-4c58-8ef8-653280add111")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct CACHE_RELATIONSHIP
	{
		/// <summary>
		/// <para>The cache level. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>L1</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>L2</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>L3</term>
		/// </item>
		/// </list>
		/// </summary>
		public byte Level;

		/// <summary>The cache associativity. If this member is CACHE_FULLY_ASSOCIATIVE (0xFF), the cache is fully associative.</summary>
		public byte Associativity;

		/// <summary>The cache line size, in bytes.</summary>
		public ushort LineSize;

		/// <summary>The cache size, in bytes.</summary>
		public uint CacheSize;

		/// <summary>The cache type. This member is a PROCESSOR_CACHE_TYPE value.</summary>
		public PROCESSOR_CACHE_TYPE Type;

		/// <summary>This member is reserved.</summary>
		private readonly uint Reserved1;
		private readonly uint Reserved2;
		private readonly uint Reserved3;
		private readonly uint Reserved4;
		private readonly uint Reserved5;

		/// <summary>A GROUP_AFFINITY structure that specifies a group number and processor affinity within the group.</summary>
		public GROUP_AFFINITY GroupMask;
	}

	/// <summary>
	/// Represents information about processor groups. This structure is used with the GetLogicalProcessorInformationEx function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_group_relationship typedef struct _GROUP_RELATIONSHIP { WORD
	// MaximumGroupCount; WORD ActiveGroupCount; BYTE Reserved[20]; PROCESSOR_GROUP_INFO GroupInfo[ANYSIZE_ARRAY]; } GROUP_RELATIONSHIP, *PGROUP_RELATIONSHIP;
	[PInvokeData("winnt.h", MSDNShortId = "3529ddef-04c5-4573-877d-c225da684e38")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<GROUP_RELATIONSHIP>), nameof(ActiveGroupCount))]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct GROUP_RELATIONSHIP
	{
		/// <summary>The maximum number of processor groups on the system.</summary>
		public ushort MaximumGroupCount;

		/// <summary>
		/// The number of active groups on the system. This member indicates the number of PROCESSOR_GROUP_INFO structures in the
		/// <c>GroupInfo</c> array.
		/// </summary>
		public ushort ActiveGroupCount;

		/// <summary>This member is reserved.</summary>
		private readonly uint Reserved1;
		private readonly uint Reserved2;
		private readonly uint Reserved3;
		private readonly uint Reserved4;
		private readonly uint Reserved5;

		/// <summary>
		/// An array of PROCESSOR_GROUP_INFO structures. Each structure represents the number and affinity of processors in an active
		/// group on the system.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public PROCESSOR_GROUP_INFO[] GroupInfo;
	}

	/// <summary>
	/// Contains information about the current state of both physical and virtual memory. The <c>GlobalMemoryStatus</c> function stores
	/// information in a <c>MEMORYSTATUS</c> structure.
	/// </summary>
	// typedef struct _MEMORYSTATUS { DWORD dwLength; DWORD dwMemoryLoad; SIZE_T dwTotalPhys; SIZE_T dwAvailPhys; SIZE_T dwTotalPageFile;
	// SIZE_T dwAvailPageFile; SIZE_T dwTotalVirtual; SIZE_T dwAvailVirtual;} MEMORYSTATUS, *LPMEMORYSTATUS; https://msdn.microsoft.com/en-us/library/windows/desktop/aa366772(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "aa366772")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MEMORYSTATUS
	{
		/// <summary>
		/// The size of the <c>MEMORYSTATUS</c> data structure, in bytes. You do not need to set this member before calling the
		/// <c>GlobalMemoryStatus</c> function; the function sets it.
		/// </summary>
		public uint dwLength;

		/// <summary>
		/// A number between 0 and 100 that specifies the approximate percentage of physical memory that is in use (0 indicates no memory
		/// use and 100 indicates full memory use).
		/// </summary>
		public uint dwMemoryLoad;

		/// <summary>The amount of actual physical memory, in bytes.</summary>
		public SIZE_T dwTotalPhys;

		/// <summary>
		/// The amount of physical memory currently available, in bytes. This is the amount of physical memory that can be immediately
		/// reused without having to write its contents to disk first. It is the sum of the size of the standby, free, and zero lists.
		/// </summary>
		public SIZE_T dwAvailPhys;

		/// <summary>
		/// The current size of the committed memory limit, in bytes. This is physical memory plus the size of the page file, minus a
		/// small overhead.
		/// </summary>
		public SIZE_T dwTotalPageFile;

		/// <summary>
		/// The maximum amount of memory the current process can commit, in bytes. This value should be smaller than the system-wide
		/// available commit. To calculate this value, call <c>GetPerformanceInfo</c> and subtract the value of <c>CommitTotal</c> from <c>CommitLimit</c>.
		/// </summary>
		public SIZE_T dwAvailPageFile;

		/// <summary>
		/// The size of the user-mode portion of the virtual address space of the calling process, in bytes. This value depends on the
		/// type of process, the type of processor, and the configuration of the operating system. For example, this value is
		/// approximately 2 GB for most 32-bit processes on an x86 processor and approximately 3 GB for 32-bit processes that are large
		/// address aware running on a system with 4 GT RAM Tuning enabled.
		/// </summary>
		public SIZE_T dwTotalVirtual;

		/// <summary>
		/// The amount of unreserved and uncommitted memory currently in the user-mode portion of the virtual address space of the
		/// calling process, in bytes.
		/// </summary>
		public SIZE_T dwAvailVirtual;

		/// <summary>Gets a default instance with the size pre-set.</summary>
		public static readonly MEMORYSTATUS Default = new() { dwLength = (uint)Marshal.SizeOf<MEMORYSTATUS>() };
	}

	/// <summary>
	/// Contains information about the current state of both physical and virtual memory, including extended memory. The
	/// <c>GlobalMemoryStatusEx</c> function stores information in this structure.
	/// </summary>
	// typedef struct _MEMORYSTATUSEX { DWORD dwLength; DWORD dwMemoryLoad; DWORDLONG ullTotalPhys; DWORDLONG ullAvailPhys; DWORDLONG
	// ullTotalPageFile; DWORDLONG ullAvailPageFile; DWORDLONG ullTotalVirtual; DWORDLONG ullAvailVirtual; DWORDLONG
	// ullAvailExtendedVirtual;} MEMORYSTATUSEX,
	// *LPMEMORYSTATUSEX; https://msdn.microsoft.com/en-us/library/windows/desktop/aa366770(v=vs.85).aspx
	[PInvokeData("WinBase.h", MSDNShortId = "aa366770")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MEMORYSTATUSEX()
	{
		/// <summary>The size of the structure, in bytes. You must set this member before calling <c>GlobalMemoryStatusEx</c>.</summary>
		public uint dwLength = (uint)Marshal.SizeOf<MEMORYSTATUSEX>();

		/// <summary>
		/// A number between 0 and 100 that specifies the approximate percentage of physical memory that is in use (0 indicates no memory
		/// use and 100 indicates full memory use).
		/// </summary>
		public uint dwMemoryLoad;

		/// <summary>The amount of actual physical memory, in bytes.</summary>
		public ulong ullTotalPhys;

		/// <summary>
		/// The amount of physical memory currently available, in bytes. This is the amount of physical memory that can be immediately
		/// reused without having to write its contents to disk first. It is the sum of the size of the standby, free, and zero lists.
		/// </summary>
		public ulong ullAvailPhys;

		/// <summary>
		/// The current committed memory limit for the system or the current process, whichever is smaller, in bytes. To get the
		/// system-wide committed memory limit, call <c>GetPerformanceInfo</c>.
		/// </summary>
		public ulong ullTotalPageFile;

		/// <summary>
		/// The maximum amount of memory the current process can commit, in bytes. This value is equal to or smaller than the system-wide
		/// available commit value. To calculate the system-wide available commit value, call <c>GetPerformanceInfo</c> and subtract the
		/// value of <c>CommitTotal</c> from the value of <c>CommitLimit</c>.
		/// </summary>
		public ulong ullAvailPageFile;

		/// <summary>
		/// The size of the user-mode portion of the virtual address space of the calling process, in bytes. This value depends on the
		/// type of process, the type of processor, and the configuration of the operating system. For example, this value is
		/// approximately 2 GB for most 32-bit processes on an x86 processor and approximately 3 GB for 32-bit processes that are large
		/// address aware running on a system with 4-gigabyte tuning enabled.
		/// </summary>
		public ulong ullTotalVirtual;

		/// <summary>
		/// The amount of unreserved and uncommitted memory currently in the user-mode portion of the virtual address space of the
		/// calling process, in bytes.
		/// </summary>
		public ulong ullAvailVirtual;

		/// <summary>Reserved. This value is always 0.</summary>
		public ulong ullAvailExtendedVirtual;

		/// <summary>Gets a default instance with the size pre-set.</summary>
		public static readonly MEMORYSTATUSEX Default = new();
	}

	/// <summary>
	/// Represents information about a NUMA node in a processor group. This structure is used with the GetLogicalProcessorInformationEx function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_numa_node_relationship typedef struct
	// _NUMA_NODE_RELATIONSHIP { DWORD NodeNumber; BYTE Reserved[20]; GROUP_AFFINITY GroupMask; } NUMA_NODE_RELATIONSHIP, *PNUMA_NODE_RELATIONSHIP;
	[PInvokeData("winnt.h", MSDNShortId = "a4e4c994-c4af-4b4f-8684-6037bcba35a9")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct NUMA_NODE_RELATIONSHIP
	{
		/// <summary>The number of the NUMA node.</summary>
		public uint NodeNumber;

		/// <summary>This member is reserved.</summary>
		private readonly uint Reserved1;
		private readonly uint Reserved2;
		private readonly uint Reserved3;
		private readonly uint Reserved4;
		private readonly uint Reserved5;

		/// <summary>A GROUP_AFFINITY structure that specifies a group number and processor affinity within the group.</summary>
		public GROUP_AFFINITY GroupMask;
	}

	/// <summary>
	/// Contains operating system version information. The information includes major and minor version numbers, a build number, a
	/// platform identifier, and information about product suites and the latest Service Pack installed on the system. This structure is
	/// used with the <c>GetVersionEx</c> and <c>VerifyVersionInfo</c> functions.
	/// </summary>
	// typedef struct _OSVERSIONINFOEX { DWORD dwOSVersionInfoSize; DWORD dwMajorVersion; DWORD dwMinorVersion; DWORD dwBuildNumber;
	// DWORD dwPlatformId; TCHAR szCSDVersion[128]; WORD wServicePackMajor; WORD wServicePackMinor; WORD wSuiteMask; BYTE wProductType;
	// BYTE wReserved;} OSVERSIONINFOEX,
	// *POSVERSIONINFOEX, *LPOSVERSIONINFOEX; https://msdn.microsoft.com/en-us/library/windows/desktop/ms724833(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "ms724833")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
	public struct OSVERSIONINFOEX(uint majorVer = 0, uint minorVer = 0, ushort spMajor = 0)
	{
		/// <summary>The size of this data structure, in bytes. Set this member to .</summary>
		public uint dwOSVersionInfoSize = (uint)Marshal.SizeOf<OSVERSIONINFOEX>();

		/// <summary>The major version number of the operating system. For more information, see Remarks.</summary>
		public uint dwMajorVersion = majorVer;

		/// <summary>The minor version number of the operating system. For more information, see Remarks.</summary>
		public uint dwMinorVersion = minorVer;

		/// <summary>The build number of the operating system.</summary>
		public uint dwBuildNumber;

		/// <summary>The operating system platform. This member can be <c>VER_PLATFORM_WIN32_NT</c> (2).</summary>
		public PlatformID dwPlatformId;

		/// <summary>
		/// A null-terminated string, such as "Service Pack 3", that indicates the latest Service Pack installed on the system. If no
		/// Service Pack has been installed, the string is empty.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string szCSDVersion = "";

		/// <summary>
		/// The major version number of the latest Service Pack installed on the system. For example, for Service Pack 3, the major
		/// version number is 3. If no Service Pack has been installed, the value is zero.
		/// </summary>
		public ushort wServicePackMajor = spMajor;

		/// <summary>
		/// The minor version number of the latest Service Pack installed on the system. For example, for Service Pack 3, the minor
		/// version number is 0.
		/// </summary>
		public ushort wServicePackMinor;

		/// <summary>
		/// <para>
		/// A bit mask that identifies the product suites available on the system. This member can be a combination of the following values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>VER_SUITE_BACKOFFICE0x00000004</term>
		/// <term>Microsoft BackOffice components are installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_BLADE0x00000400</term>
		/// <term>Windows Server 2003, Web Edition is installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_COMPUTE_SERVER0x00004000</term>
		/// <term>Windows Server 2003, Compute Cluster Edition is installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_DATACENTER0x00000080</term>
		/// <term>Windows Server 2008 Datacenter, Windows Server 2003, Datacenter Edition, or Windows 2000 Datacenter Server is installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_ENTERPRISE0x00000002</term>
		/// <term>
		/// Windows Server 2008 Enterprise, Windows Server 2003, Enterprise Edition, or Windows 2000 Advanced Server is installed. Refer
		/// to the Remarks section for more information about this bit flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_EMBEDDEDNT0x00000040</term>
		/// <term>Windows XP Embedded is installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_PERSONAL0x00000200</term>
		/// <term>Windows Vista Home Premium, Windows Vista Home Basic, or Windows XP Home Edition is installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_SINGLEUSERTS0x00000100</term>
		/// <term>
		/// Remote Desktop is supported, but only one interactive session is supported. This value is set unless the system is running in
		/// application server mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_SMALLBUSINESS0x00000001</term>
		/// <term>
		/// Microsoft Small Business Server was once installed on the system, but may have been upgraded to another version of Windows.
		/// Refer to the Remarks section for more information about this bit flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_SMALLBUSINESS_RESTRICTED0x00000020</term>
		/// <term>
		/// Microsoft Small Business Server is installed with the restrictive client license in force. Refer to the Remarks section for
		/// more information about this bit flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_STORAGE_SERVER0x00002000</term>
		/// <term>Windows Storage Server 2003 R2 or Windows Storage Server 2003is installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_TERMINAL0x00000010</term>
		/// <term>
		/// Terminal Services is installed. This value is always set.If VER_SUITE_TERMINAL is set but VER_SUITE_SINGLEUSERTS is not set,
		/// the system is running in application server mode.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_WH_SERVER0x00008000</term>
		/// <term>Windows Home Server is installed.</term>
		/// </item>
		/// <item>
		/// <term>VER_SUITE_MULTIUSERTS0x00020000</term>
		/// <term>AppServer mode is enabled.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public SuiteMask wSuiteMask;

		/// <summary>
		/// <para>Any additional information about the system. This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>VER_NT_DOMAIN_CONTROLLER0x0000002</term>
		/// <term>
		/// The system is a domain controller and the operating system is Windows Server 2012 , Windows Server 2008 R2, Windows Server
		/// 2008, Windows Server 2003, or Windows 2000 Server.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VER_NT_SERVER0x0000003</term>
		/// <term>
		/// The operating system is Windows Server 2012, Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows
		/// 2000 Server.Note that a server that is also a domain controller is reported as VER_NT_DOMAIN_CONTROLLER, not VER_NT_SERVER.
		/// </term>
		/// </item>
		/// <item>
		/// <term>VER_NT_WORKSTATION0x0000001</term>
		/// <term>
		/// The operating system is Windows 8, Windows 7, Windows Vista, Windows XP Professional, Windows XP Home Edition, or Windows
		/// 2000 Professional.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public ProductType wProductType;

		/// <summary>Reserved for future use.</summary>
		public byte wReserved;

		/// <summary>Gets a default instance with the size pre-set.</summary>
		public static readonly OSVERSIONINFOEX Default = new(0, 0, 0);
	}

	/// <summary>Represents the number and affinity of processors in a processor group.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_processor_group_info typedef struct _PROCESSOR_GROUP_INFO {
	// BYTE MaximumProcessorCount; BYTE ActiveProcessorCount; BYTE Reserved[38]; KAFFINITY ActiveProcessorMask; } PROCESSOR_GROUP_INFO, *PPROCESSOR_GROUP_INFO;
	[PInvokeData("winnt.h", MSDNShortId = "6ff9cc3c-34e7-4dc4-94cd-6ed278dfaa03")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct PROCESSOR_GROUP_INFO
	{
		/// <summary>The maximum number of processors in the group.</summary>
		public byte MaximumProcessorCount;

		/// <summary>The number of active processors in the group.</summary>
		public byte ActiveProcessorCount;

		/// <summary>This member is reserved.</summary>
		private readonly ushort Reserved1;
		private readonly uint Reserved2;
		private readonly uint Reserved3;
		private readonly uint Reserved4;
		private readonly uint Reserved5;
		private readonly uint Reserved6;
		private readonly uint Reserved7;
		private readonly uint Reserved8;
		private readonly uint Reserved9;
		private readonly uint Reserved10;

		/// <summary>A bitmap that specifies the affinity for zero or more active processors within the group.</summary>
		public nuint ActiveProcessorMask;
	}

	/// <summary>
	/// <para>
	/// Represents information about affinity within a processor group. This structure is used with the GetLogicalProcessorInformationEx function.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>PROCESSOR_RELATIONSHIP</c> structure describes the logical processors associated with either a processor core or a
	/// processor package.
	/// </para>
	/// <para>If the <c>PROCESSOR_RELATIONSHIP</c> structure represents a processor core, the <c>GroupCount</c> member is always 1.</para>
	/// <para>
	/// If the <c>PROCESSOR_RELATIONSHIP</c> structure represents a processor package, the <c>GroupCount</c> member is 1 only if all
	/// processors are in the same processor group. If the package contains more than one NUMA node, the system might assign different
	/// NUMA nodes to different processor groups. In this case, the <c>GroupCount</c> member is the number of groups to which NUMA nodes
	/// in the package are assigned.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_processor_relationship typedef struct _PROCESSOR_RELATIONSHIP
	// { BYTE Flags; BYTE EfficiencyClass; BYTE Reserved[20]; WORD GroupCount; GROUP_AFFINITY GroupMask[ANYSIZE_ARRAY]; }
	// PROCESSOR_RELATIONSHIP, *PPROCESSOR_RELATIONSHIP;
	[PInvokeData("winnt.h", MSDNShortId = "1efda80d-cf5b-4312-801a-ea3585b152ac")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PROCESSOR_RELATIONSHIP>), nameof(GroupCount))]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct PROCESSOR_RELATIONSHIP
	{
		/// <summary>
		/// <para>
		/// If the <c>Relationship</c> member of the SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX structure is <c>RelationProcessorCore</c>,
		/// this member is LTP_PC_SMT if the core has more than one logical processor, or 0 if the core has one logical processor.
		/// </para>
		/// <para>
		/// If the <c>Relationship</c> member of the SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX structure is
		/// <c>RelationProcessorPackage</c>, this member is always 0.
		/// </para>
		/// </summary>
		public byte Flags;

		/// <summary>
		/// <para>
		/// If the <c>Relationship</c> member of the SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX structure is <c>RelationProcessorCore</c>,
		/// <c>EfficiencyClass</c> specifies the intrinsic tradeoff between performance and power for the applicable core. A core with a
		/// higher value for the efficiency class has intrinsically greater performance and less efficiency than a core with a lower
		/// value for the efficiency class. <c>EfficiencyClass</c> is only nonzero on systems with a heterogeneous set of cores.
		/// </para>
		/// <para>
		/// If the <c>Relationship</c> member of the SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX structure is
		/// <c>RelationProcessorPackage</c>, <c>EfficiencyClass</c> is always 0.
		/// </para>
		/// <para>The minimum operating system version that supports this member is Windows 10.</para>
		/// </summary>
		public byte EfficiencyClass;

		/// <summary>This member is reserved.</summary>
		private readonly ushort Reserved1;
		private readonly uint Reserved2;
		private readonly uint Reserved3;
		private readonly uint Reserved4;
		private readonly uint Reserved5;
		private readonly ushort Reserved6;

		/// <summary>This member specifies the number of entries in the <c>GroupMask</c> array. For more information, see Remarks.</summary>
		public ushort GroupCount;

		/// <summary>
		/// An array of GROUP_AFFINITY structures. The <c>GroupCount</c> member specifies the number of structures in the array. Each
		/// structure in the array specifies a group number and processor affinity within the group.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public GROUP_AFFINITY[] GroupMask;
	}

	/// <summary>
	/// Contains information about the current computer system. This includes the architecture and type of the processor, the number of
	/// processors in the system, the page size, and other such information.
	/// </summary>
	// typedef struct _SYSTEM_INFO { union { DWORD dwOemId; struct { WORD wProcessorArchitecture; WORD wReserved; }; }; DWORD dwPageSize;
	// LPVOID lpMinimumApplicationAddress; LPVOID lpMaximumApplicationAddress; DWORD_PTR dwActiveProcessorMask; DWORD
	// dwNumberOfProcessors; DWORD dwProcessorType; DWORD dwAllocationGranularity; WORD wProcessorLevel; WORD wProcessorRevision;}
	// SYSTEM_INFO; https://msdn.microsoft.com/en-us/library/windows/desktop/ms724958(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "ms724958")]
	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	public struct SYSTEM_INFO
	{
		/// <summary>
		/// <para>The processor architecture of the installed operating system. This member can be one of the following values.</para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PROCESSOR_ARCHITECTURE_AMD649</term>
		/// <term>x64 (AMD or Intel)</term>
		/// </item>
		/// <item>
		/// <term>PROCESSOR_ARCHITECTURE_ARM5</term>
		/// <term>ARM</term>
		/// </item>
		/// <item>
		/// <term>PROCESSOR_ARCHITECTURE_ARM6412</term>
		/// <term>ARM64</term>
		/// </item>
		/// <item>
		/// <term>PROCESSOR_ARCHITECTURE_IA646</term>
		/// <term>Intel Itanium-based</term>
		/// </item>
		/// <item>
		/// <term>PROCESSOR_ARCHITECTURE_INTEL0</term>
		/// <term>x86</term>
		/// </item>
		/// <item>
		/// <term>PROCESSOR_ARCHITECTURE_UNKNOWN0xffff</term>
		/// <term>Unknown architecture.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public ProcessorArchitecture wProcessorArchitecture;

		/// <summary>This member is reserved for future use.</summary>
		public ushort wReserved;

		/// <summary>
		/// The page size and the granularity of page protection and commitment. This is the page size used by the <c>VirtualAlloc</c> function.
		/// </summary>
		public uint dwPageSize;

		/// <summary>A pointer to the lowest memory address accessible to applications and dynamic-link libraries (DLLs).</summary>
		public IntPtr lpMinimumApplicationAddress;

		/// <summary>A pointer to the highest memory address accessible to applications and DLLs.</summary>
		public IntPtr lpMaximumApplicationAddress;

		/// <summary>
		/// A mask representing the set of processors configured into the system. Bit 0 is processor 0; bit 31 is processor 31.
		/// </summary>
		public nuint dwActiveProcessorMask;

		/// <summary>
		/// The number of logical processors in the current group. To retrieve this value, use the <c>GetLogicalProcessorInformation</c> function.
		/// </summary>
		public uint dwNumberOfProcessors;

		/// <summary>
		/// An obsolete member that is retained for compatibility. Use the <c>wProcessorArchitecture</c>, <c>wProcessorLevel</c>, and
		/// <c>wProcessorRevision</c> members to determine the type of processor.
		/// </summary>
		public uint dwProcessorType;

		/// <summary>
		/// The granularity for the starting address at which virtual memory can be allocated. For more information, see <c>VirtualAlloc</c>.
		/// </summary>
		public uint dwAllocationGranularity;

		/// <summary>
		/// <para>
		/// The architecture-dependent processor level. It should be used only for display purposes. To determine the feature set of a
		/// processor, use the <c>IsProcessorFeaturePresent</c> function.
		/// </para>
		/// <para>If <c>wProcessorArchitecture</c> is PROCESSOR_ARCHITECTURE_INTEL, <c>wProcessorLevel</c> is defined by the CPU vendor.</para>
		/// <para>If <c>wProcessorArchitecture</c> is PROCESSOR_ARCHITECTURE_IA64, <c>wProcessorLevel</c> is set to 1.</para>
		/// </summary>
		public ushort wProcessorLevel;

		/// <summary>
		/// <para>
		/// The architecture-dependent processor revision. The following table shows how the revision value is assembled for each type of
		/// processor architecture.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Processor</term>
		/// <term>Value</term>
		/// </listheader>
		/// <item>
		/// <term>Intel Pentium, Cyrix, or NextGen 586</term>
		/// <term>
		/// The high byte is the model and the low byte is the stepping. For example, if the value is xxyy, the model number and stepping
		/// can be displayed as
		/// follows: Model xx, Stepping yy
		/// </term>
		/// </item>
		/// <item>
		/// <term>Intel 80386 or 80486</term>
		/// <term>
		/// A value of the form xxyz. If xx is equal to 0xFF, y - 0xA is the model number, and z is the stepping identifier.If xx is not
		/// equal to 0xFF, xx + 'A' is the stepping letter and yz is the minor stepping.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ARM</term>
		/// <term>Reserved.</term>
		/// </item>
		/// </list>
		/// </para>
		/// </summary>
		public ushort wProcessorRevision;
	}

	/// <summary>
	/// Describes the relationship between the specified processor set. This structure is used with the
	/// <c>GetLogicalProcessorInformation</c> function.
	/// </summary>
	// typedef struct _SYSTEM_LOGICAL_PROCESSOR_INFORMATION { ULONG_PTR ProcessorMask; LOGICAL_PROCESSOR_RELATIONSHIP Relationship; union
	// { struct { BYTE Flags; } ProcessorCore; struct { DWORD NodeNumber; } NumaNode; CACHE_DESCRIPTOR Cache; ULONGLONG Reserved[2]; };}
	// SYSTEM_LOGICAL_PROCESSOR_INFORMATION, *PSYSTEM_LOGICAL_PROCESSOR_INFORMATION; https://msdn.microsoft.com/en-us/library/windows/desktop/ms686694(v=vs.85).aspx
	[PInvokeData("WinNT.h", MSDNShortId = "ms686694")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION
	{
		/// <summary>
		/// <para>
		/// The processor mask identifying the processors described by this structure. A processor mask is a bit vector in which each set
		/// bit represents an active processor in the relationship. At least one bit will be set.
		/// </para>
		/// <para>On a system with more than 64 processors, the processor mask identifies processors in a single processor group.</para>
		/// </summary>
		public nuint ProcessorMask;

		/// <summary>
		/// <para>
		/// The relationship between the processors identified by the value of the <c>ProcessorMask</c> member. This member can be one of
		/// the following <c>LOGICAL_PROCESSOR_RELATIONSHIP</c> values.
		/// </para>
		/// <para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RelationCache2</term>
		/// <term>
		/// The specified logical processors share a cache. The Cache member contains additional information.Windows Server 2003: This
		/// value is not supported until Windows Server 2003 with SP1 and Windows XP Professional x64 Edition.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RelationNumaNode1</term>
		/// <term>The specified logical processors are part of the same NUMA node. The NumaNode member contains additional information.</term>
		/// </item>
		/// <item>
		/// <term>RelationProcessorCore0</term>
		/// <term>The specified logical processors share a single processor core. The ProcessorCore member contains additional information.</term>
		/// </item>
		/// <item>
		/// <term>RelationProcessorPackage3</term>
		/// <term>
		/// The specified logical processors share a physical package. There is no additional information available.Windows Server 2003
		/// and Windows XP Professional x64 Edition: This value is not supported until Windows Server 2003 with SP1 and Windows XP with SP3.
		/// </term>
		/// </item>
		/// </list>
		/// </para>
		/// <para>Future versions of Windows may support additional values for the <c>Relationship</c> member.</para>
		/// </summary>
		public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;

		/// <summary>The relationship union.</summary>
		public ProcessorRelationUnion RelationUnion;

		/// <summary>Union tied to the relationship.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct ProcessorRelationUnion
		{
			/// <summary>This structure contains valid data only if the <c>Relationship</c> member is RelationProcessorCore.</summary>
			[FieldOffset(0)] public byte ProcessorCoreFlags;

			/// <summary>This structure contains valid data only if the <c>Relationship</c> member is RelationNumaNode.</summary>
			[FieldOffset(0)] public uint NumaNodeNumber;

			/// <summary>
			/// <para>
			/// A <c>CACHE_DESCRIPTOR</c> structure that identifies the characteristics of a particular cache. There is one record
			/// returned for each cache reported. Some or all caches may not be reported, depending on the mechanism used by the
			/// processor to identify its caches. Therefore, do not assume the absence of any particular caches. Caches are not
			/// necessarily shared among logical processors.
			/// </para>
			/// <para>This structure contains valid data only if the <c>Relationship</c> member is RelationCache.</para>
			/// <para>
			/// <c>Windows Server 2003:</c> This member is not supported until Windows Server 2003 with SP1 and Windows XP Professional
			/// x64 Edition.
			/// </para>
			/// </summary>
			[FieldOffset(0)] public CACHE_DESCRIPTOR Cache;

			/// <summary>Reserved. Do not use.</summary>
			[FieldOffset(0)] private unsafe fixed ulong Reserved[2];
		}
	}

	/// <summary>
	/// Contains information about the relationships of logical processors and related hardware. The GetLogicalProcessorInformationEx
	/// function uses this structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winnt/ns-winnt-_system_logical_processor_information_ex typedef struct
	// _SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX { LOGICAL_PROCESSOR_RELATIONSHIP Relationship; DWORD Size; union { PROCESSOR_RELATIONSHIP
	// Processor; NUMA_NODE_RELATIONSHIP NumaNode; CACHE_RELATIONSHIP Cache; GROUP_RELATIONSHIP Group; } DUMMYUNIONNAME; }
	// SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX, *PSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX;
	[PInvokeData("winnt.h", MSDNShortId = "6ff16cda-c1dc-4d5c-ac60-756653cd6b07")]
	[StructLayout(LayoutKind.Sequential, Size = 76)]
	public struct SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX
	{
		/// <summary>
		/// <para>
		/// The type of relationship between the logical processors. This parameter can be one of the following
		/// LOGICAL_PROCESSOR_RELATIONSHIP values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RelationCache 2</term>
		/// <term>The specified logical processors share a cache. The Cache member contains additional information.</term>
		/// </item>
		/// <item>
		/// <term>RelationGroup 4</term>
		/// <term>The specified logical processors share a processor group. The Group member contains additional information.</term>
		/// </item>
		/// <item>
		/// <term>RelationNumaNode 1</term>
		/// <term>The specified logical processors are part of the same NUMA node. The NumaNode member contains additional information.</term>
		/// </item>
		/// <item>
		/// <term>RelationProcessorCore 0</term>
		/// <term>The specified logical processors share a single processor core. The Processor member contains additional information.</term>
		/// </item>
		/// <item>
		/// <term>RelationProcessorPackage 3</term>
		/// <term>The specified logical processors share a physical package. The Processor member contains additional information.</term>
		/// </item>
		/// </list>
		/// </summary>
		public LOGICAL_PROCESSOR_RELATIONSHIP Relationship;

		/// <summary>The size of the structure.</summary>
		public uint Size;

		/// <summary>The relationship union.</summary>
		private readonly ulong dummy;

		/// <summary>
		/// A NUMA_NODE_RELATIONSHIP structure that describes a NUMA node. This structure contains valid data only if the
		/// <c>Relationship</c> member is <c>RelationNumaNode</c>.
		/// </summary>
		public readonly NUMA_NODE_RELATIONSHIP NumaNode => GetField<NUMA_NODE_RELATIONSHIP>(LOGICAL_PROCESSOR_RELATIONSHIP.RelationNumaNode);

		/// <summary>
		/// A NUMA_NODE_RELATIONSHIP structure that describes a NUMA node. This structure contains valid data only if the
		/// <c>Relationship</c> member is <c>RelationNumaNode</c>.
		/// </summary>
		public ref NUMA_NODE_RELATIONSHIP NumaNodeRef => ref GetFieldRef<NUMA_NODE_RELATIONSHIP>(LOGICAL_PROCESSOR_RELATIONSHIP.RelationNumaNode);

		/// <summary>
		/// A CACHE_RELATIONSHIP structure that describes cache attributes. This structure contains valid data only if the
		/// <c>Relationship</c> member is <c>RelationCache</c>.
		/// </summary>
		public readonly CACHE_RELATIONSHIP Cache => GetField<CACHE_RELATIONSHIP>(LOGICAL_PROCESSOR_RELATIONSHIP.RelationCache);

		/// <summary>
		/// A CACHE_RELATIONSHIP structure that describes cache attributes. This structure contains valid data only if the
		/// <c>Relationship</c> member is <c>RelationCache</c>.
		/// </summary>
		public ref CACHE_RELATIONSHIP CacheRef => ref GetFieldRef<CACHE_RELATIONSHIP>(LOGICAL_PROCESSOR_RELATIONSHIP.RelationCache);

		/// <summary>
		/// A PROCESSOR_RELATIONSHIP structure that describes processor affinity. This structure contains valid data only if the
		/// <c>Relationship</c> member is <c>RelationProcessorCore</c> or <c>RelationProcessorPackage</c>.
		/// </summary>
		public readonly PROCESSOR_RELATIONSHIP Processor => GetField<PROCESSOR_RELATIONSHIP>(LOGICAL_PROCESSOR_RELATIONSHIP.RelationProcessorCore, LOGICAL_PROCESSOR_RELATIONSHIP.RelationProcessorPackage);

		/// <summary>
		/// A GROUP_RELATIONSHIP structure that contains information about the processor groups. This structure contains valid data
		/// only if the <c>Relationship</c> member is <c>RelationGroup</c>.
		/// </summary>
		public readonly GROUP_RELATIONSHIP Group => GetField<GROUP_RELATIONSHIP>(LOGICAL_PROCESSOR_RELATIONSHIP.RelationGroup);

		private readonly T GetField<T>(params LOGICAL_PROCESSOR_RELATIONSHIP[] r) where T : struct
		{
			if (!r.Contains(Relationship))
				return default;
			unsafe
			{
				fixed (void* p = &dummy)
					return ((IntPtr)p).ToStructure<T>();
			}
		}

		private ref T GetFieldRef<T>(params LOGICAL_PROCESSOR_RELATIONSHIP[] r) where T : struct
		{
			if (!r.Contains(Relationship))
				throw new Exception($"Invalid relationship type: {Relationship}");
			unsafe
			{
				fixed (void* p = &dummy)
					return ref ((IntPtr)p).AsRef<T>();
			}
		}
	}

	/// <summary>Used by GetProcessorSystemCycleTime.</summary>
	[PInvokeData("WinNT.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SYSTEM_PROCESSOR_CYCLE_TIME_INFORMATION
	{
		/// <summary>The cycle time for a processor.</summary>
		public ulong CycleTime;
	}

	/// <summary>Holds a list of <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> structures retrived from <see cref="GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP, out SafeSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX_List)"/>.</summary>
	public class SafeSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX_List : SafeMemoryHandle<CoTaskMemoryMethods>
	{
		internal SafeSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX_List(SIZE_T size) : base(size)
		{
		}

		/// <summary>Gets the number of elements available.</summary>
		/// <value>The number of elements available.</value>
		public int Count => Items.Count;

		/// <summary>Gets a reference to a <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/> at the specified index.</summary>
		/// <param name="index">The index.</param>
		/// <returns>A reference to <see cref="SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX"/>.</returns>
		public ref SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX this[int index]
		{
			get
			{
				var ptrs = Items;
				if (index < 0 || index >= ptrs.Count)
					throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
				return ref ptrs[index].AsRef<SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX>();
			}
		}

		private List<IntPtr> Items
		{
			get
			{
				var ret = new List<IntPtr>();
				for (IntPtr pCurrent = handle, pEnd = pCurrent.Offset(sz); pCurrent != IntPtr.Zero && pCurrent.ToInt64() < pEnd.ToInt64();)
				{
					var cSz = pCurrent.AsRef<SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX>().Size;
					if (cSz == 0) break;
					ret.Add(pCurrent);
					pCurrent = pCurrent.Offset(cSz);
				}
				return ret;
			}
		}
	}
}