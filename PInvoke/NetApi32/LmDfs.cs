using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>
	/// <para>
	/// The <c>FSCTL_DFS_GET_PKT_ENTRY_STATE</c> control code can get the same information as the <c>NetDfsGetClientInfo</c> function but can
	/// provide better performance in some configurations with high latencies to the DFS servers. It is not recommended to use the
	/// <c>FSCTL_DFS_GET_PKT_ENTRY_STATE</c> control code unless there are performance issues.
	/// </para>
	/// <para>To perform this operation, call the <c>DeviceIoControl</c> function with the following parameters.</para>
	/// <para><em>hDevice</em></para>
	/// <para>A handle to the device. To obtain a device handle, call the <c>CreateFile</c> function.</para>
	/// <para><em>dwIoControlCode</em></para>
	/// <para>The control code for the operation. Use <c>FSCTL_DFS_GET_PKT_ENTRY_STATE</c> for this operation.</para>
	/// <para><em>lpInBuffer</em></para>
	/// <para>Address of a <c>DFS_GET_PKT_ENTRY_STATE_ARG</c> structure and the 1-3 Unicode strings that follow.</para>
	/// <para><em>nInBufferSize</em></para>
	/// <para>Size, in bytes, of the buffer pointed to by the lpInBuffer parameter.</para>
	/// <para>lpOutBuffer</para>
	/// <para>
	/// Address of a <c>DFS_INFO_#</c> structure and any strings and structures pointed to by the <c>DFS_INFO_#</c> structure. The specific
	/// structure returned depends on the <c>Level</c> member in the <c>DFS_GET_PKT_ENTRY_STATE_ARG</c> structure passed in the input buffer.
	/// </para>
	/// <para><em>nOutBufferSize</em></para>
	/// <para>
	/// Size, in bytes, of the buffer pointed to by the lpOutBuffer parameter. Due to the strings and structures referenced by the returned
	/// <c>DFS_INFO_#</c> structure that are also in the output buffer, this buffer should be larger than the <c>DFS_INFO_#</c> structure specified.
	/// </para>
	/// <para><em>lpBytesReturned</em></para>
	/// <para>A pointer to a variable that receives the size of the data stored in the output buffer, in bytes.</para>
	/// <para>
	/// If the output buffer is too small, but at least large enough to hold a <c>DWORD</c>, the call fails, <c>GetLastError</c> returns
	/// <c>ERROR_MORE_DATA</c>, and the first <c>DWORD</c> of the output buffer contains the size that would have been required. If the
	/// output buffer cannot hold a <c>DWORD</c> then the call fails with <c>ERROR_INSUFFICIENT_BUFFER</c>, and lpBytesReturned is zero.
	/// </para>
	/// <para>
	/// If lpOverlapped is <c>NULL</c>, lpBytesReturned cannot be <c>NULL</c>. Even when an operation returns no output data and lpOutBuffer
	/// is <c>NULL</c>, <c>DeviceIoControl</c> makes use of lpBytesReturned. After such an operation, the value of lpBytesReturned is meaningless.
	/// </para>
	/// <para>
	/// If lpOverlapped is not <c>NULL</c>, lpBytesReturned can be <c>NULL</c>. If this parameter is not <c>NULL</c> and the operation
	/// returns data, lpBytesReturned is meaningless until the overlapped operation has completed. To retrieve the number of bytes returned,
	/// call <c>GetOverlappedResult</c>. If the hDevice parameter is associated with an I/O completion port, you can retrieve the number of
	/// bytes returned by calling <c>GetQueuedCompletionStatus</c>.
	/// </para>
	/// <para><em>lpOverlapped</em></para>
	/// <para>A pointer to an <c>OVERLAPPED</c> structure.</para>
	/// <para>If hDevice was opened without specifying <c>FILE_FLAG_OVERLAPPED</c>, lpOverlapped is ignored.</para>
	/// <para>
	/// If hDevice was opened with the <c>FILE_FLAG_OVERLAPPED</c> flag, the operation is performed as an overlapped (asynchronous)
	/// operation. In this case, lpOverlapped must point to a valid <c>OVERLAPPED</c> structure that contains a handle to an event object.
	/// Otherwise, the function fails in unpredictable ways.
	/// </para>
	/// <para>
	/// For overlapped operations, <c>DeviceIoControl</c> returns immediately, and the event object is signaled when the operation has been
	/// completed. Otherwise, the function does not return until the operation has been completed or an error occurs.
	/// </para>
	/// </summary>
	/// <returns>
	/// <para>If the operation completes successfully, <c>DeviceIoControl</c> returns a nonzero value.</para>
	/// <para>If the operation fails or is pending, <c>DeviceIoControl</c> returns zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/dfs/fsctl-dfs-get-pkt-entry-state
	[PInvokeData("LmDfs.h")]
	[CorrespondingType(typeof(DFS_GET_PKT_ENTRY_STATE_ARG))]
	public static uint FSCTL_DFS_GET_PKT_ENTRY_STATE => Kernel32.CTL_CODE(6 /*FSCTL_DFS_BASE*/, 2031, (byte)Kernel32.IOMethod.METHOD_BUFFERED, (byte)Kernel32.IOAccess.FILE_ANY_ACCESS);

	/// <summary>Identifies the origin of DFS namespace version information.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ne-lmdfs-dfs_namespace_version_origin typedef enum {
	// DFS_NAMESPACE_VERSION_ORIGIN_COMBINED, DFS_NAMESPACE_VERSION_ORIGIN_SERVER, DFS_NAMESPACE_VERSION_ORIGIN_DOMAIN } *PDFS_NAMESPACE_VERSION_ORIGIN;
	[PInvokeData("lmdfs.h", MSDNShortId = "b260e132-41fd-460b-87e6-c6e0490dc8b4")]
	public enum DFS_NAMESPACE_VERSION_ORIGIN
	{
		/// <summary>
		/// The version information specifies the maximum version that the server and the Active Directory Domain Service (AD DS) domain
		/// can support.
		/// </summary>
		DFS_NAMESPACE_VERSION_ORIGIN_COMBINED,

		/// <summary>The version information specifies the maximum version that the server can support.</summary>
		DFS_NAMESPACE_VERSION_ORIGIN_SERVER,

		/// <summary>The version information specifies the maximum version that the AD DS domain can support.</summary>
		DFS_NAMESPACE_VERSION_ORIGIN_DOMAIN,
	}

	/// <summary>Defines the set of possible DFS target priority class settings.</summary>
	/// <remarks>
	/// <para>The order of priority classes from highest to lowest is as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>DfsGlobalHighPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsSiteCostHighPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsSiteCostNormalPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsSiteCostLowPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsGlobalLowPriorityClass</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// Server targets are initially grouped into global high priority, normal priority, and low priority classes. The normal priority
	/// class is then subdivided, based on Active Directory site cost, into site-cost high priority, site-cost normal priority, and
	/// site-cost low priority classes.
	/// </para>
	/// <para>
	/// For example, all of the server targets with a site-cost value of 0 are first grouped into site-cost high, normal, and low
	/// priority classes. Then, all server targets with lower site costs are likewise separated into site-cost high, normal, and low
	/// priority classes. Thus, a server target with a site-cost value of 0 and a site-cost low priority class is still ranked higher
	/// than a server target with a site-cost value of 1 and site-cost high priority class.
	/// </para>
	/// <para>For more information about how server target priority is determined, see DFS Server Target Prioritization.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ne-lmdfs-_dfs_target_priority_class typedef enum
	// _DFS_TARGET_PRIORITY_CLASS { DfsInvalidPriorityClass, DfsSiteCostNormalPriorityClass, DfsGlobalHighPriorityClass,
	// DfsSiteCostHighPriorityClass, DfsSiteCostLowPriorityClass, DfsGlobalLowPriorityClass, v1_enum } DFS_TARGET_PRIORITY_CLASS;
	[PInvokeData("lmdfs.h", MSDNShortId = "4aac4575-630f-4cb6-8312-edd1fad8f128")]
	public enum DFS_TARGET_PRIORITY_CLASS
	{
		/// <summary>The priority class is not valid.</summary>
		DfsInvalidPriorityClass = -1,

		/// <summary>The middle or "normal" site cost priority class for a DFS target.</summary>
		DfsSiteCostNormalPriorityClass = 0,

		/// <summary>The highest priority class for a DFS target. Targets assigned this class receive global preference.</summary>
		DfsGlobalHighPriorityClass,

		/// <summary>
		/// The highest site cost priority class for a DFS target. Targets assigned this class receive the most preference among targets
		/// of the same site cost for a given DFS client.
		/// </summary>
		DfsSiteCostHighPriorityClass,

		/// <summary>
		/// The lowest site cost priority class for a DFS target. Targets assigned this class receive the least preference among targets
		/// of the same site cost for a given DFS client.
		/// </summary>
		DfsSiteCostLowPriorityClass,

		/// <summary>
		/// The lowest level of priority class for a DFS target. Targets assigned this class receive the least preference globally.
		/// </summary>
		DfsGlobalLowPriorityClass,
	}

	/// <summary>Flags for <see cref="NetDfsAdd"/>.</summary>
	[PInvokeData("lmdfs.h", MSDNShortId = "2c8816b2-5489-486e-b749-605932ba9fe9")]
	[Flags]
	public enum DfsAddFlags
	{
		/// <summary>
		/// Create a DFS link. If the DFS link already exists, the NetDfsAdd function fails. For more information, see the Remarks section.
		/// </summary>
		DFS_ADD_VOLUME = 1,

		/// <summary>Volume/Replica is being restored - do not verify share etc.</summary>
		DFS_RESTORE_VOLUME = 2,
	}

	/// <summary>A set of flags that describe specific capabilities of a DFS namespace.</summary>
	[PInvokeData("lmdfs.h", MSDNShortId = "ee75c500-70c6-4dce-9d38-36cacd695746")]
	[Flags]
	public enum DfsCapabilities : ulong
	{
		/// <summary>
		/// The DFS namespace supports associating a security descriptor with a DFS link for Access-Based Directory Enumeration (ABDE) purposes.
		/// </summary>
		DFS_NAMESPACE_CAPABILITY_ABDE = 1
	}

	/// <summary>Flags that describe actions to take when moving the link.</summary>
	[PInvokeData("lmdfs.h", MSDNShortId = "d9d225ac-26b9-4074-93b6-6294538a3504")]
	[Flags]
	public enum DfsMoveFlags
	{
		/// <summary>If the destination path is already an existing DFS link, replace it as part of the move operation.</summary>
		DFS_MOVE_FLAG_REPLACE_IF_EXISTS = 0x00000001
	}

	/// <summary>
	/// Bitfield, with each bit responsible for a specific property applicable to the whole DFS namespace, the DFS root, or an individual
	/// DFS link, depending on the actual property.
	/// </summary>
	[PInvokeData("lmdfs.h", MSDNShortId = "d3d31087-770e-4434-8ee0-6183102a9a6b")]
	[Flags]
	public enum DfsPropertyFlag
	{
		/// <summary>
		/// Referral response from a DFS server for a DFS root or link that contains only those targets in the same site as the client
		/// requesting the referral. Targets in the two global priority classes are always returned, regardless of their site location.
		/// This flag applies to domain-based DFS roots, stand-alone DFS roots, and DFS links. If this flag is set at the DFS root, it
		/// applies to all links; otherwise, it applies to an individual link. The setting at the link does not override the root setting.
		/// </summary>
		DFS_PROPERTY_FLAG_INSITE_REFERRALS = 0x00000001,

		/// <summary>
		/// If this flag is set, the DFS server polls the nearest domain controller (DC) instead of the primary domain controller (PDC)
		/// to check for DFS namespace changes for that namespace. Any modification to the DFS metadata by the DFS server is not
		/// controlled by this flag but is sent to the PDC. This flag is valid for the entire namespace and applies only to domain-based
		/// DFS namespaces.
		/// </summary>
		DFS_PROPERTY_FLAG_ROOT_SCALABILITY = 0x00000002,

		/// <summary>
		/// Set this flag to enable Active Directory site costing of targets. Targets returned from the DFS server to the requesting DFS
		/// client are grouped by inter-site cost with respect to the DFS client. The groups are ordered in terms of increasing site cost
		/// with the first group consisting of targets in the same site as the client. Targets within each group are ordered randomly.
		/// <para>
		/// If this flag is not enabled, the default return is two sets: one set of targets in the same site as the client, and one set
		/// of all remaining targets. This flag is valid for the entire DFS namespace and applies to both domain-based and stand-alone
		/// DFS namespaces.
		/// </para>
		/// <para>
		/// Target priorities can further influence target ordering.For more information on how site-costing is used to prioritize
		/// targets, see DFS Server Target Prioritization.
		/// </para>
		/// </summary>
		DFS_PROPERTY_FLAG_SITE_COSTING = 0x00000004,

		/// <summary>
		/// Set this flag to enable V4 DFS clients to fail back to a more optimal (lower cost or higher priority) target. If this flag is
		/// set at the DFS root, it applies to all links; otherwise, it applies to an individual link. An individual link setting will
		/// not override a root setting. The target failback setting is provided to the DFS client in a V4 referral response by the DFS
		/// server. This flag applies to domain-based roots, stand-alone roots, and links.
		/// </summary>
		DFS_PROPERTY_FLAG_TARGET_FAILBACK = 0x00000008,

		/// <summary>
		/// If this flag is set, the DFS root is clustered to provide high availability for storage failover. This flag cannot be set
		/// using the NetDfsSetInfo function and applies only to stand-alone DFS roots and links.
		/// </summary>
		DFS_PROPERTY_FLAG_CLUSTER_ENABLED = 0x00000010,

		/// <summary>
		/// Scope: Domain-based DFS roots and stand-alone DFS roots.
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace.This flag is valid only for DFS namespaces for which the DFS_NAMESPACE_CAPABILITY_ABDE capability flag
		/// is set.For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The DFS_PROPERTY_FLAG_ABDE flag is valid only on the DFS namespace root and not on root targets, links, or link targets.This
		/// flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		DFS_PROPERTY_FLAG_ABDE = 0x00000020,
	}

	/// <summary>Specifies the type of removal operation.</summary>
	[PInvokeData("lmdfs.h", MSDNShortId = "9a8c78f4-3170-4568-940c-1c51aebad3ae")]
	[Flags]
	public enum DfsRemoveFlags : uint
	{
		/// <summary>If this flag is specified for a domain-based DFS namespace, the root target is removed even if it is not accessible.</summary>
		DFS_FORCE_REMOVE = 0x80000000,
	}

	/// <summary>Specifies a set of bit flags that describe the DFS root or link.</summary>
	[PInvokeData("lmdfs.h", MSDNShortId = "c5fe27be-fd6e-4cf0-abf6-8363c78edf5b")]
	[Flags]
	public enum DfsState
	{
		/// <summary>Used to extract the DFS root or DFS link state from this enum.</summary>
		DFS_VOLUME_STATES = 0xF,

		/// <summary>The specified DFS root or DFS link is in the normal state.</summary>
		DFS_VOLUME_STATE_OK = 1,

		/// <summary>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </summary>
		DFS_VOLUME_STATE_INCONSISTENT = 2,

		/// <summary>
		/// The DFS link is offline, and none of the DFS targets will be included in the referral response. This flag is valid only for a
		/// DFS link and cannot be set on a DFS root. This state is persisted to the DFS metadata.
		/// </summary>
		DFS_VOLUME_STATE_OFFLINE = 3,

		/// <summary>
		/// The DFS link is online and available for referral request. This flag is valid only for a DFS link and cannot be set on a DFS
		/// root. This state is persisted to the DFS metadata.
		/// </summary>
		DFS_VOLUME_STATE_ONLINE = 4,

		/// <summary>Forces a resynchronization on the DFS root target. This flag is valid only for a DFS root target, and is write-only.</summary>
		DFS_VOLUME_STATE_RESYNCHRONIZE = 0x10,

		/// <summary>Puts a root volume in standby mode. This flag is valid for a clustered DFS namespace only.</summary>
		DFS_VOLUME_STATE_STANDBY = 0x20,

		/// <summary>
		/// Forces a full resynchronization operation on the DFS root target of a specified domainv2-based DFS namespace or stand-alone
		/// DFS namespace to identify DFS links that have been added or deleted. This is not supported on a domainv1-based DFS namespace.
		/// DFS links MUST NOT be specified.
		/// <para>This state is used to perform a server operation. It is not persisted to the DFS metadata.</para>
		/// </summary>
		DFS_VOLUME_STATE_FORCE_SYNC = 0x40,

		/// <summary>Used to extract the DFS namespace flavor.</summary>
		DFS_VOLUME_FLAVORS = 0x0300,

		/// <summary>The system sets this flag if the root is associated with a stand-alone DFS namespace.</summary>
		DFS_VOLUME_FLAVOR_STANDALONE = 0x0100,

		/// <summary>The system sets this flag if the root is associated with a domain-based DFS namespace.</summary>
		DFS_VOLUME_FLAVOR_AD_BLOB = 0x0200,
	}

	/// <summary>State of the storage target.</summary>
	[PInvokeData("lmdfs.h", MSDNShortId = "f50f32d8-1745-4ff6-97a6-ddd6fff95955")]
	[Flags]
	public enum DfsStorageState
	{
		/// <summary>The DFS root or link target is offline.</summary>
		DFS_STORAGE_STATE_OFFLINE = 1,

		/// <summary>The DFS root or link target is online.</summary>
		DFS_STORAGE_STATE_ONLINE = 2,

		/// <summary>The DFS root or link target is the active target.</summary>
		DFS_STORAGE_STATE_ACTIVE = 4,

		/// <summary>The DFS storage state mask.</summary>
		DFS_STORAGE_STATES = 0xF,
	}

	/// <summary>Creates a new Distributed File System (DFS) link or adds targets to an existing link in a DFS namespace.</summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS link in a DFS namespace.</para>
	/// <para>The string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts a stand-alone DFS namespace; DfsName is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts a domain-based DFS namespace; DomDfsname is the name of the domain-based
	/// DFS namespace; and link_path is a DFS link.
	/// </para>
	/// <para>This parameter is required.</para>
	/// </param>
	/// <param name="ServerName">Pointer to a string that specifies the link target server name. This parameter is required.</param>
	/// <param name="ShareName">
	/// Pointer to a string that specifies the link target share name. This can also be a share name with a path relative to the share.
	/// For example, share1\mydir1\mydir2. This parameter is required.
	/// </param>
	/// <param name="Comment">
	/// Pointer to a string that specifies an optional comment associated with the DFS link. This parameter is ignored when the function
	/// adds a target to an existing link.
	/// </param>
	/// <param name="Flags">
	/// <para>This parameter can specify the following value, or you can specify zero for no flags.</para>
	/// <para>DFS_ADD_VOLUME (0x00000001)</para>
	/// <para>
	/// Create a DFS link. If the DFS link already exists, the <c>NetDfsAdd</c> function fails. For more information, see the Remarks section.
	/// </para>
	/// <para>DFS_RESTORE_VOLUME (0x00000002)</para>
	/// <para>This flag is not supported.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>The DFS namespace must already exist. This function does not create a new DFS namespace.</para>
	/// <para>
	/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
	/// administrator privileges, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// Use of the <c>DFS_ADD_VOLUME</c> flag is optional. If you specify <c>DFS_ADD_VOLUME</c> and the link already exists,
	/// <c>NetDfsAdd</c> fails. If you do not specify <c>DFS_ADD_VOLUME</c>, <c>NetDfsAdd</c> creates the link, if required, and adds the
	/// target to the link. You should specify this value when you need to determine when new links are created.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to create a new DFS link using a call to the <c>NetDfsAdd</c> function. Because the
	/// sample specifies the value <c>DFS_ADD_VOLUME</c> in the Flags parameter, the call to <c>NetDfsAdd</c> fails if the DFS link
	/// already exists. To add additional targets to an existing DFS link, you can specify zero in the Flags parameter.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsadd NET_API_STATUS NET_API_FUNCTION NetDfsAdd( LPWSTR
	// DfsEntryPath, LPWSTR ServerName, LPWSTR ShareName, LPWSTR Comment, DWORD Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "2c8816b2-5489-486e-b749-605932ba9fe9")]
	public static extern Win32Error NetDfsAdd(string DfsEntryPath, string ServerName, string ShareName, [Optional] string? Comment, DfsAddFlags Flags);

	/// <summary>
	/// Creates a new domain-based Distributed File System (DFS) namespace. If the namespace already exists, the function adds the
	/// specified root target to it.
	/// </summary>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the name of the server that will host the new DFS root target. This value cannot be an IP
	/// address. This parameter is required.
	/// </param>
	/// <param name="RootShare">
	/// Pointer to a string that specifies the name of the shared folder on the server that will host the new DFS root target. This
	/// parameter is required.
	/// </param>
	/// <param name="FtDfsName">
	/// Pointer to a string that specifies the name of the new or existing domain-based DFS namespace. This parameter is required. For
	/// compatibility reasons, it should specify the same string as the RootShare parameter.
	/// </param>
	/// <param name="Comment">Pointer to a string that contains an optional comment associated with the DFS namespace.</param>
	/// <param name="Flags">This parameter is reserved and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The share specified by the RootShare parameter must already exist on the server that will host the new DFS root target. This
	/// function does not create a new share.
	/// </para>
	/// <para>
	/// The caller must have permission to update the DFS container in the directory service and must have Administrator privilege on the
	/// DFS host (root) server.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsaddftroot NET_API_STATUS NET_API_FUNCTION
	// NetDfsAddFtRoot( LPWSTR ServerName, LPWSTR RootShare, LPWSTR FtDfsName, LPWSTR Comment, DWORD Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "df3192f8-f8fc-40ad-a5ff-fb991befff09")]
	public static extern Win32Error NetDfsAddFtRoot(string ServerName, string RootShare, string FtDfsName, [Optional] string? Comment, uint Flags = 0);

	/// <summary>Creates a domain-based or stand-alone DFS namespace or adds a new root target to an existing domain-based namespace.</summary>
	/// <param name="pDfsPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS namespace.</para>
	/// <para>For a stand-alone DFS namespace, this string should be in the following format:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>where ServerName is the name of the server that will host the new DFS root target and DfsName is the name of the DFS namespace.</para>
	/// <para>For a domain-based DFS namespace, this string should be in the following format:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsName</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace and DomDfsName is the name of the new or
	/// existing domain-based DFS namespace. For compatibility reasons, DomDfsName should be the same as the name of the shared folder on
	/// the server that will host the new DFS root target.
	/// </para>
	/// </param>
	/// <param name="pTargetPath">
	/// <para>
	/// Pointer to a null-terminated Unicode string that specifies the UNC path of a DFS root target for the DFS namespace that is
	/// specified in the pDfsPath parameter.
	/// </para>
	/// <para>
	/// For a stand-alone DFS namespace, this parameter must be <c>NULL</c>. For a domain-based DFS namespace, the string should be in
	/// the following format:
	/// </para>
	/// <para>\ServerName&lt;i&gt;RootShare</para>
	/// <para>
	/// where ServerName is the name of the server that will host the new DFS root target and RootShare is the name of the shared folder
	/// on the server. The share specified by RootShare must already exist on the server that will host the new DFS root target. This
	/// function does not create a new share.
	/// </para>
	/// </param>
	/// <param name="MajorVersion">
	/// <para>Specifies the DFS metadata version for the namespace.</para>
	/// <para><c>Note</c> This parameter is only for use when creating a new namespace.</para>
	/// <para>If a stand-alone DFS namespace is being created, this parameter must be set to 1.</para>
	/// <para>If a domain-based namespace is being created, this parameter should be set as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set it to 1 to specify Windows 2000 mode.</term>
	/// </item>
	/// <item>
	/// <term>Set it to 2 or higher to specify Windows Server 2008 mode.</term>
	/// </item>
	/// </list>
	/// <para>If a new root target is being added to an existing domain-based DFS namespace, this parameter must be set to zero.</para>
	/// </param>
	/// <param name="pComment">Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root.</param>
	/// <param name="Flags">This parameter is reserved and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>
	/// If the domain is not at the required functional level for the specified MajorVersion, the return value is
	/// <c>ERROR_DS_INCOMPATIBLE</c>. This return value applies only to domain roots and a MajorVersion of 2.
	/// </para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have Administrator privilege on the DFS server.</para>
	/// <para>
	/// To determine the DFS metadata version that can be specified in the MajorVersion parameter, use the
	/// NetDfsGetSupportedNamespaceVersion function.
	/// </para>
	/// <para>The following table shows which parameter values you should specify, according to the desired result.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>pDfsPath parameter</term>
	/// <term>pTargetPath parameter</term>
	/// <term>MajorVersion parameter</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>\\DomainName\DomDfsName</term>
	/// <term>\\ServerName\RootShare</term>
	/// <term>1</term>
	/// <term>Create a Windows 2000 mode domain-based DFS namespace or add a new root target to an existing one.</term>
	/// </item>
	/// <item>
	/// <term>\\DomainName\DomDfsName</term>
	/// <term>\\ServerName\RootShare</term>
	/// <term>2</term>
	/// <term>Create a Windows Server 2008 mode domain-based DFS namespace or add a new root target to an existing one.</term>
	/// </item>
	/// <item>
	/// <term>\\DomainName\DomDfsName</term>
	/// <term>\\ServerName\RootShare</term>
	/// <term>0</term>
	/// <term>Add a new root target to an existing Windows 2000 mode or Windows Server 2008 mode domain-based DFS namespace.</term>
	/// </item>
	/// <item>
	/// <term>\\ServerName\DfsName</term>
	/// <term>NULL</term>
	/// <term>Must be 1.</term>
	/// <term>Create a stand-alone DFS namespace.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsaddroottarget NET_API_STATUS NET_API_FUNCTION
	// NetDfsAddRootTarget( LPWSTR pDfsPath, LPWSTR pTargetPath, ULONG MajorVersion, LPWSTR pComment, ULONG Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "c4ce8f50-f090-4783-b6c9-834d9e0c33de")]
	public static extern Win32Error NetDfsAddRootTarget(string pDfsPath, [Optional] string? pTargetPath, uint MajorVersion, [Optional] string? pComment, uint Flags = 0);

	/// <summary>Creates a new stand-alone Distributed File System (DFS) namespace.</summary>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the name of the server that will host the new stand-alone DFS namespace. This parameter is required.
	/// </param>
	/// <param name="RootShare">
	/// Pointer to a string that specifies the name of the shared folder for the new stand-alone DFS namespace on the server that will
	/// host the namespace. This parameter is required.
	/// </param>
	/// <param name="Comment">Pointer to a string that contains an optional comment associated with the DFS namespace.</param>
	/// <param name="Flags">This parameter is reserved and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The share specified by the RootShare parameter must already exist on the server that will host the new DFS root target. This
	/// function does not create a new share.
	/// </para>
	/// <para>
	/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
	/// administrator privileges, see Running with Special Privileges.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsaddstdroot NET_API_STATUS NET_API_FUNCTION
	// NetDfsAddStdRoot( LPWSTR ServerName, LPWSTR RootShare, LPWSTR Comment, DWORD Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "e59236ac-06d7-4b2f-b318-ec13e6c662ac")]
	public static extern Win32Error NetDfsAddStdRoot(string ServerName, string RootShare, [Optional] string? Comment, uint Flags = 0);

	/// <summary>
	/// <para>
	/// [This function is obsolete. You can create the root for a new stand-alone DFS namespace by calling the <c>NetDfsAddStdRoot</c> function.]
	/// </para>
	/// <para>
	/// Creates a new stand-alone Distributed File System (DFS) namespace without checking for the availability or accessibility of the
	/// share corresponding to the DFS namespace. This allows an offline share to host a clustered DFS namespace.
	/// </para>
	/// </summary>
	/// <param name="ServerName">
	/// NamePointer to a string that specifies the name of the server that will host the new stand-alone DFS namespace. This parameter is required.
	/// </param>
	/// <param name="RootShare">
	/// Pointer to a string that specifies the name of the shared folder for the new stand-alone DFS namespace on the server that will
	/// host the namespace. This parameter is required.
	/// </param>
	/// <param name="Comment">Pointer to a string that contains an optional comment associated with the DFS namespace.</param>
	/// <param name="Store">
	/// Pointer to a string that specifies the local file system path corresponding to the share that will host the new DFS namespace.
	/// This parameter is required and must be of the form:
	/// <para>
	/// <code>
	/// drive:\directory
	/// </code>
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
	/// administrator privileges, see Running with Special Privileges.
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/bb524808(v=vs.85)
	// NET_API_STATUS NetDfsAddStdRootForced( _In_ LPWSTR ServerName, _In_ LPWSTR RootShare, _In_opt_ LPWSTR Comment, _In_ LPWSTR Store );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("LmDfs.h", MSDNShortId = "")]
	public static extern Win32Error NetDfsAddStdRootForced(string ServerName, string RootShare, [Optional] string? Comment, string Store);

	/// <summary>
	/// Enumerates the Distributed File System (DFS) namespaces hosted on a server or DFS links of a namespace hosted by a server.
	/// </summary>
	/// <param name="DfsName">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of the DFS root or link.</para>
	/// <para>
	/// When you specify information level 200 (DFS_INFO_200), this parameter is the name of a domain. When you specify information level
	/// 300 (DFS_INFO_300), this parameter is the name of a server.
	/// </para>
	/// <para>For all other levels, the string can be in one of the following four forms:</para>
	/// <para>ServerName&lt;i&gt;DfsName</para>
	/// <para>or</para>
	/// <para>ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; Dfsname is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>The string can also be of the following forms:</para>
	/// <para>DomainName&lt;i&gt;DomainName\DomDfsName</para>
	/// <para>or</para>
	/// <para>DomainName&lt;i&gt;DomDfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS root; DomDfsName is the name of the DFS namespace; and
	/// link_path is a DFS link.
	/// </para>
	/// <para>You can precede the string with backslashes (\), but they are not required. This parameter is required.</para>
	/// </param>
	/// <param name="Level">
	/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
	/// <para>1</para>
	/// <para>Return the name of the DFS root and all links under the root. The Buffer parameter points to an array of DFS_INFO_1 structures.</para>
	/// <para>2</para>
	/// <para>
	/// Return the name, comment, status, and the number of targets for the DFS root and all links under the root. The Buffer parameter
	/// points to an array of DFS_INFO_2 structures.
	/// </para>
	/// <para>3</para>
	/// <para>
	/// Return the name, comment, status, number of targets, and information about each target for the DFS root and all links under the
	/// root. The Buffer parameter points to an array of DFS_INFO_3 structures.
	/// </para>
	/// <para>4</para>
	/// <para>
	/// Return the name, comment, status, <c>GUID</c>, time-out, number of targets, and information about each target for the DFS root
	/// and all links under the root. The Buffer parameter points to an array of DFS_INFO_4 structures.
	/// </para>
	/// <para>5</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, and number of targets for a DFS root and all links
	/// under the root. The Buffer parameter points to an array of DFS_INFO_5 structures.
	/// </para>
	/// <para>6</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information for a root or link, and a
	/// list of DFS targets. The Buffer parameter points to an array of DFS_INFO_6 structures.
	/// </para>
	/// <para>8</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, number of targets, and link reparse point security
	/// descriptors for a DFS root and all links under the root. The Buffer parameter points to an array of DFS_INFO_8 structures.
	/// </para>
	/// <para>9</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information, link reparse point
	/// security descriptors, and a list of DFS targets for a root or link. The Buffer parameter points to an array of DFS_INFO_9 structures.
	/// </para>
	/// <para>200</para>
	/// <para>
	/// Return the list of domain-based DFS namespaces in the domain. The Buffer parameter points to an array of DFS_INFO_200 structures.
	/// </para>
	/// <para>300</para>
	/// <para>
	/// Return the stand-alone and domain-based DFS namespaces hosted by a server. The Buffer parameter points to an array of
	/// DFS_INFO_300 structures.
	/// </para>
	/// </param>
	/// <param name="PrefMaxLen">
	/// Specifies the number of bytes that should be returned by this function in the information structure buffer. If this parameter is
	/// <c>MAX_PREFERRED_LENGTH</c>, the function allocates the amount of memory required for the data. For more information, see the
	/// following Remarks section. This parameter is ignored if you specify level 200 or level 300.
	/// </param>
	/// <param name="Buffer">
	/// Pointer to a buffer that receives the requested information structures. The format of this data depends on the value of the Level
	/// parameter. This buffer is allocated by the system and must be freed using the NetApiBufferFree function.
	/// </param>
	/// <param name="EntriesRead">Pointer to a value that receives the actual number of entries returned in the response.</param>
	/// <param name="ResumeHandle">
	/// Pointer to a value that contains a handle to be used for continuing an enumeration when more data is available than can be
	/// returned in a single call to this function. The handle should be zero on the first call and left unchanged for subsequent calls.
	/// For more information, see the following Remarks section.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If no more entries are available to be enumerated, the return value is <c>ERROR_NO_MORE_ITEMS</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required for using the <c>NetDfsEnum</c> function.</para>
	/// <para>
	/// Call the <c>NetDfsEnum</c> function with the ResumeHandle parameter set to zero to begin the enumeration. To continue the
	/// enumeration operation, call this function with the ResumeHandle returned by the previous call to <c>NetDfsEnum</c>. If this
	/// function does not return <c>ERROR_NO_MORE_ITEMS</c>, subsequent calls to this API will return the remaining links. Once
	/// <c>ERROR_NO_MORE_ITEMS</c> is returned, all available DFS links have been retrieved.
	/// </para>
	/// <para>
	/// The <c>NetDfsEnum</c> function allocates the memory required for the information structure buffer. If you specify an amount in
	/// the PrefMaxLen parameter, it restricts the memory that the function returns. However, the actual size of the memory that the
	/// <c>NetDfsEnum</c> function allocates can be greater than the amount you specify. For additional information see Network
	/// Management Function Buffer Lengths.
	/// </para>
	/// <para>
	/// Due to the possibility of concurrent updates to the DFS namespace, the caller should not assume completeness or uniqueness of the
	/// results returned when resuming an enumeration operation.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to list the DFS links in a named DFS root with a call to the <c>NetDfsEnum</c>
	/// function. The sample calls <c>NetDfsEnum</c>, specifying information level 3 ( DFS_INFO_3). The sample code loops through the
	/// entries and prints the retrieved data and the status of each host server referenced by the DFS link. Finally, the sample frees
	/// the memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsenum NET_API_STATUS NET_API_FUNCTION NetDfsEnum( LPWSTR
	// DfsName, DWORD Level, DWORD PrefMaxLen, LPBYTE *Buffer, LPDWORD EntriesRead, LPDWORD ResumeHandle );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "c05a8d78-41f4-4c19-a25e-ef4885869584")]
	public static extern Win32Error NetDfsEnum(string DfsName, uint Level, uint PrefMaxLen, out SafeNetApiBuffer Buffer, out uint EntriesRead, ref uint ResumeHandle);

	/// <summary>Retrieves information about a Distributed File System (DFS) root or link from the cache maintained by the DFS client.</summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
	/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>For a root, the string can be in one of two forms:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>or</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname</para>
	/// <para>where the values of the names are the same as those described previously.</para>
	/// <para>This parameter is required.</para>
	/// </param>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the name of the DFS root target or link target server. This parameter is optional.
	/// </param>
	/// <param name="ShareName">
	/// Pointer to a string that specifies the name of the share corresponding to the DFS root target or link target. This parameter is optional.
	/// </param>
	/// <param name="Level">
	/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
	/// <para>1</para>
	/// <para>Return the DFS root or DFS link name. The Buffer parameter points to a DFS_INFO_1 structure.</para>
	/// <para>2</para>
	/// <para>
	/// Return the DFS root or DFS link name, status, and the number of DFS targets. The Buffer parameter points to a DFS_INFO_2 structure.
	/// </para>
	/// <para>3</para>
	/// <para>Return the DFS root or DFS link name, status, and target information. The Buffer parameter points to a DFS_INFO_3 structure.</para>
	/// <para>4</para>
	/// <para>
	/// Return the DFS root or DFS link name, status, <c>GUID</c>, time-out, and target information. The Buffer parameter points to a
	/// DFS_INFO_4 structure.
	/// </para>
	/// </param>
	/// <param name="Buffer">
	/// Pointer to the address of a buffer that receives the requested information. This buffer is allocated by the system and must be
	/// freed using the NetApiBufferFree function. For more information, see Network Management Function Buffers and Network Management
	/// Function Buffer Lengths.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>No special group membership is required for using the <c>NetDfsGetClientInfo</c> function.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsgetclientinfo NET_API_STATUS NET_API_FUNCTION
	// NetDfsGetClientInfo( LPWSTR DfsEntryPath, LPWSTR ServerName, LPWSTR ShareName, DWORD Level, LPBYTE *Buffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "065ec002-cb90-4d78-a70c-6ac37f71994f")]
	public static extern Win32Error NetDfsGetClientInfo(string DfsEntryPath, [Optional] string? ServerName, [Optional] string? ShareName, uint Level, out SafeNetApiBuffer Buffer);

	/// <summary>
	/// Retrieves the security descriptor of the container object for the domain-based DFS namespaces in the specified Active Directory domain.
	/// </summary>
	/// <param name="DomainName">Pointer to a string that specifies the Active Directory domain name.</param>
	/// <param name="SecurityInformation">
	/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to retrieve.
	/// </param>
	/// <param name="ppSecurityDescriptor">
	/// <para>
	/// Pointer to a list SECURITY_DESCRIPTOR structures that contain the security items requested in the SecurityInformation parameter.
	/// </para>
	/// <para><c>Note</c> This buffer must be freed by calling the NetApiBufferFree function.</para>
	/// </param>
	/// <param name="lpcbSecurityDescriptor">The size of ppSecurityDescriptor, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// The security descriptor is retrieved from the "CN=DFS-Configuration,CN=System,DC=domain" object in Active Directory from the
	/// primary domain controller (PDC) of the domain specified in the DomainName parameter, where domain is the distinguished name of
	/// the domain specified in the DomainName parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsgetftcontainersecurity NET_API_STATUS NET_API_FUNCTION
	// NetDfsGetFtContainerSecurity( LPWSTR DomainName, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR
	// *ppSecurityDescriptor, LPDWORD lpcbSecurityDescriptor );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "88e988db-1418-49d5-8cac-1ea6144474a5")]
	public static extern Win32Error NetDfsGetFtContainerSecurity(string DomainName, SECURITY_INFORMATION SecurityInformation, out SafeNetApiBuffer ppSecurityDescriptor, out uint lpcbSecurityDescriptor);

	/// <summary>Retrieves information about a specified Distributed File System (DFS) root or link in a DFS namespace.</summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
	/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>For a root, the string can be in one of two forms:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>or</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname</para>
	/// <para>where the values of the names are the same as those described previously.</para>
	/// <para>This parameter is required.</para>
	/// </param>
	/// <param name="ServerName">This parameter is currently ignored and should be <c>NULL</c>.</param>
	/// <param name="ShareName">This parameter is currently ignored and should be <c>NULL</c>.</param>
	/// <param name="Level">
	/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
	/// <para>1</para>
	/// <para>Return the DFS root or DFS link name. The Buffer parameter points to a DFS_INFO_1 structure.</para>
	/// <para>2</para>
	/// <para>
	/// Return the DFS root or DFS link name, status, and the number of DFS targets. The Buffer parameter points to a DFS_INFO_2 structure.
	/// </para>
	/// <para>3</para>
	/// <para>Return the DFS root or DFS link name, status, and target information. The Buffer parameter points to a DFS_INFO_3 structure.</para>
	/// <para>4</para>
	/// <para>
	/// Return the DFS root or DFS link name, status, GUID, time-out, and target information. The Buffer parameter points to a DFS_INFO_4 structure.
	/// </para>
	/// <para>5</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, and number of targets for a DFS root and all links
	/// under the root. The Buffer parameter points to an array of DFS_INFO_5 structures.
	/// </para>
	/// <para>6</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information for a root or link, and a
	/// list of DFS targets. The Buffer parameter points to an array of DFS_INFO_6 structures.
	/// </para>
	/// <para>7</para>
	/// <para>Return the version number <c>GUID</c> of the DFS metadata. The Buffer parameter points to an array of DFS_INFO_7 structures.</para>
	/// <para>8</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, number of targets, and link reparse point security
	/// descriptors for a DFS root and all links under the root. The Buffer parameter points to an array of DFS_INFO_8 structures.
	/// </para>
	/// <para>9</para>
	/// <para>
	/// Return the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information, link reparse point
	/// security descriptors, and a list of DFS targets for a root or link. The Buffer parameter points to an array of DFS_INFO_9 structures.
	/// </para>
	/// <para>50</para>
	/// <para>
	/// Return the DFS metadata version and capabilities of an existing DFS namespace. The Buffer parameter points to a DFS_INFO_50 structure.
	/// </para>
	/// <para>100</para>
	/// <para>Return a comment about the DFS root or DFS link. The Buffer parameter points to a DFS_INFO_100 structure.</para>
	/// <para>150</para>
	/// <para>Return the security descriptor for the DFS link's reparse point. The Buffer parameter points to a DFS_INFO_150 structure.</para>
	/// <para>
	/// <c>Note</c> This value is natively supported only if the DFS link resides on a server that is running Windows Server 2008 or later.
	/// </para>
	/// </param>
	/// <param name="Buffer">
	/// Pointer to the address of a buffer that receives the requested information structures. The format of this data depends on the
	/// value of the Level parameter. This buffer is allocated by the system and must be freed using the NetApiBufferFree function. For
	/// more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required for using the <c>NetDfsGetInfo</c> function.</para>
	/// <para>
	/// An application calling the <c>NetDfsGetInfo</c> function may indirectly cause the local DFS Namespace server servicing the
	/// function call to perform a full synchronization of the related namespace metadata from the PDC emulator master for that domain.
	/// This full synchronization could happen even when root scalability mode is configured for that namespace. In order to avoid this
	/// side-effect, if the intent is to only retrieve the physical UNC pathname used by a specific DFSN client machine corresponding a
	/// given DFS namespace path, then one alternative is to use the WDK API ZwQueryInformationFile, passing
	/// <c>FileNetworkPhysicalNameInformation</c> as the FileInformationClass parameter and passing the address of a caller-allocated
	/// FILE_NETWORK_PHYSICAL_NAME_INFORMATION structure as the FileInformation parameter. Please see the WDK for more information on
	/// calling WDK APIs.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to retrieve information about a DFS link using a call to the <c>NetDfsGetInfo</c>
	/// function. The sample calls <c>NetDfsGetInfo</c>, specifying information level 3 (DFS_INFO_3). If the call succeeds, the sample
	/// prints information about the DFS link, including the name and status of each target referenced by the link. Finally, the code
	/// sample frees the memory allocated for the information buffer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsgetinfo NET_API_STATUS NET_API_FUNCTION NetDfsGetInfo(
	// LPWSTR DfsEntryPath, LPWSTR ServerName, LPWSTR ShareName, DWORD Level, LPBYTE *Buffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "bbb2f24d-1c49-4016-a16b-60fde4a78193")]
	public static extern Win32Error NetDfsGetInfo(string DfsEntryPath, [Optional] string? ServerName, [Optional] string? ShareName, uint Level, out SafeNetApiBuffer Buffer);

	/// <summary>Retrieves the security descriptor for the root object of the specified DFS namespace.</summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS namespace root.</para>
	/// <para>The string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace and Dfsname is the name of the
	/// DFS namespace.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsName</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace and DomDfsName is the name of the DFS namespace.
	/// </para>
	/// </param>
	/// <param name="SecurityInformation">
	/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to retrieve from the root object.
	/// </param>
	/// <param name="ppSecurityDescriptor">
	/// <para>
	/// Pointer to a list of SECURITY_DESCRIPTOR structures that contain the security items requested in the SecurityInformation parameter.
	/// </para>
	/// <para><c>Note</c> This buffer must be freed by calling the NetApiBufferFree function.</para>
	/// </param>
	/// <param name="lpcbSecurityDescriptor">The size of the buffer that ppSecurityDescriptor points to, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For domain-based DFS namespaces, the security descriptor is retrieved from the
	/// "CN=DomDfsName,CN=DFS-Configuration,CN=System,DC=domain" object in Active Directory from the primary domain controller (PDC) of
	/// the domain that hosts the DFS namespace, where DomDfsName is the name of the domain-based DFS namespace and &lt;domain&gt; is the
	/// distinguished name of the Active Directory domain that hosts the namespace.
	/// </para>
	/// <para>
	/// For stand-alone roots, the security descriptor is retrieved from the object specified by the
	/// <c>HKLM</c>&lt;b&gt;Software&lt;b&gt;Microsoft&lt;b&gt;Dfs&lt;b&gt;Standalone&lt;b&gt;&lt;root-name&gt; registry entry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsgetsecurity NET_API_STATUS NET_API_FUNCTION
	// NetDfsGetSecurity( LPWSTR DfsEntryPath, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR *ppSecurityDescriptor,
	// LPDWORD lpcbSecurityDescriptor );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "a6db7c82-c2ec-464a-8c05-2360622880b4")]
	public static extern Win32Error NetDfsGetSecurity(string DfsEntryPath, SECURITY_INFORMATION SecurityInformation, out SafeNetApiBuffer ppSecurityDescriptor, out uint lpcbSecurityDescriptor);

	/// <summary>Retrieves the security descriptor for the container object of the specified stand-alone DFS namespace.</summary>
	/// <param name="MachineName">Pointer to a string that specifies the name of the server that hosts the stand-alone DFS namespace.</param>
	/// <param name="SecurityInformation">
	/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to retrieve.
	/// </param>
	/// <param name="ppSecurityDescriptor">
	/// <para>
	/// Pointer to a list of SECURITY_DESCRIPTOR structures that contain the security items requested in the SecurityInformation parameter.
	/// </para>
	/// <para><c>Note</c> This buffer must be freed by calling the NetApiBufferFree function.</para>
	/// </param>
	/// <param name="lpcbSecurityDescriptor">The size of the buffer that ppSecurityDescriptor points to, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// The security descriptor is retrieved from the object specified by the
	/// <c>HKLM</c>&lt;b&gt;Software&lt;b&gt;Microsoft&lt;b&gt;Dfs&lt;b&gt;Standalone key in the registry of the server specified in the
	/// MachineName parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsgetstdcontainersecurity NET_API_STATUS NET_API_FUNCTION
	// NetDfsGetStdContainerSecurity( LPWSTR MachineName, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR
	// *ppSecurityDescriptor, LPDWORD lpcbSecurityDescriptor );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "63ad610e-c66f-4fad-b3b6-2ee15e90a723")]
	public static extern Win32Error NetDfsGetStdContainerSecurity(string MachineName, SECURITY_INFORMATION SecurityInformation, out SafeNetApiBuffer ppSecurityDescriptor, out uint lpcbSecurityDescriptor);

	/// <summary>Determines the supported metadata version number.</summary>
	/// <param name="Origin">A DFS_NAMESPACE_VERSION_ORIGIN enumeration value that specifies the origin of the DFS namespace version.</param>
	/// <param name="pName">
	/// A string that specifies the server name or domain name. If the value of the Origin parameter is
	/// <c>DFS_NAMESPACE_VERSION_ORIGIN_DOMAIN</c>, this string must be an AD DS domain name. Otherwise, it must be a server name. This
	/// parameter is required and cannot be <c>NULL</c>.
	/// </param>
	/// <param name="ppVersionInfo">
	/// A pointer to a DFS_SUPPORTED_NAMESPACE_VERSION_INFO structure that receives the DFS metadata version number.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function is useful in determining an appropriate version number to pass to the NetDfsAddRootTarget function.</para>
	/// <para>The version number of the DFS metadata that can be used for a new DFS namespace depends on the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>For domain-based DFS namespaces, the version supported by the DFS metadata schema that is being used in the AD DS domain.</term>
	/// </item>
	/// <item>
	/// <term>The version supported by the server that is to host the DFS root target.</term>
	/// </item>
	/// </list>
	/// <para>
	/// Thus, the maximum DFS metadata version number that can be used for a new DFS namespace is the minimum of the version supported by
	/// the AD DS domain and the version supported by the server. This maximum can be determined by calling the
	/// <c>NetDfsGetSupportedNamespaceVersion</c> function with the pName parameter set to the name of the server that is to host the new
	/// DFS root target and the Origin parameter set to <c>DFS_NAMESPACE_VERSION_ORIGIN_COMBINED</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsgetsupportednamespaceversion NET_API_STATUS
	// NET_API_FUNCTION NetDfsGetSupportedNamespaceVersion( DFS_NAMESPACE_VERSION_ORIGIN Origin, PWSTR pName,
	// PDFS_SUPPORTED_NAMESPACE_VERSION_INFO *ppVersionInfo );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "32ccf4a7-9d07-45e1-93db-29eddee01680")]
	public static extern Win32Error NetDfsGetSupportedNamespaceVersion(DFS_NAMESPACE_VERSION_ORIGIN Origin, string pName, out DFS_SUPPORTED_NAMESPACE_VERSION_INFO ppVersionInfo);

	/// <summary>Renames or moves a DFS link.</summary>
	/// <param name="OldDfsEntryPath">
	/// Pointer to a string that specifies the source path for the move operation. This value must be a DFS link or the path prefix of
	/// any DFS link in the DFS namespace.
	/// </param>
	/// <param name="NewDfsEntryPath">
	/// Pointer to a string that specifies the destination path for the move operation. This value must be a path or a DFS link in the
	/// same DFS namespace.
	/// </param>
	/// <param name="Flags">
	/// <para>A set of flags that describe actions to take when moving the link.</para>
	/// <para>DFS_MOVE_FLAG_REPLACE_IF_EXISTS (0x00000001)</para>
	/// <para>If the destination path is already an existing DFS link, replace it as part of the move operation.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>NetDfsMove</c> function conveniently moves a link from an old name to a new one. In the past, it has been necessary to
	/// perform the non-trivial action of deleting an incorrect or old link and creating a new one, which becomes cumbersome when the
	/// link has a significant number of targets or has per-target properties (like priority) set. It is also common for administrators
	/// to regularly rename or move links.
	/// </para>
	/// <para>
	/// DFS paths supplied to <c>NetDfsMove</c> can be either an actual DFS link or just a DFS link path prefix. Wildcards are not
	/// allowed and only absolute paths can be specified. Relative paths and special path name syntax (such as "." or "..") are not allowed.
	/// </para>
	/// <para>
	/// When a DFS link path prefix is specified instead of a complete DFS path, the move operation is performed on all DFS links which
	/// contain that prefix. Therefore, a single call to <c>NetDfsMove</c> can "move" multiple links. However, the path prefix must
	/// resolve to at least one valid DFS link or the move operation will fail.
	/// </para>
	/// <para>The following examples demonstrate different move operations and the results.</para>
	/// <list type="number">
	/// <item>
	/// <term>After the move, \\MyDfsServer\MyDfsShare\dir1\dir2\link1 is replaced with \\MyDfsServer\MyDfsShare\dir1\dir2\link2.</term>
	/// </item>
	/// <item>
	/// <term>
	/// After the move, \\MyDfsServer\MyDfsShare\dir1\dir2\link1 is replaced with \\MyDfsServer\MyDfsShare\dir3\dir4\dir5\link2. Note
	/// that both the leaf and non-leaf components have been renamed, and that the number of components in the new path has changed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// After the move, all links prefixed with \\MyDfsServer\MyDfsShare\dir1 have that prefix replaced with
	/// \\MyDfsServer\MyDfsShare\dir3. Therefore, \\MyDfsServer\MyDfsShare\dir1\dir2\link1 and \\MyDfsServer\MyDfsShare\dir1\dir2\link2
	/// are now \\MyDfsServer\MyDfsShare\dir3\dir2\link1 and \\MyDfsServer\MyDfsShare\dir3\dir2\link1, respectively.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// After the move, all links prefixed with \\MyDfsServer\MyDfsShare\dir1 have that prefix replaced with \\MyDfsServer\MyDfsShare.
	/// Therefore, \\MyDfsServer\MyDfsShare\dir1\dir2\link1 and \\MyDfsServer\MyDfsShare\dir1\dir2\link2 are now
	/// \\MyDfsServer\MyDfsShare\dir2\link1 and \\MyDfsServer\MyDfsShare\dir2\link1, respectively.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the new path already has an existing entry, <c>DFS_MOVE_FLAG_REPLACE_IF_EXISTS</c> must be specified if the new path should
	/// overwrite the old one. When this flag is set, the collided path is deleted and replaced by the new link. Note that any operation
	/// which can potentially result in DFS links that completely overlap will fail, whether or not
	/// <c>DFS_MOVE_FLAG_REPLACE_IF_EXISTS</c> is specified. For example:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Existing links: \\MyDfsServer\MyDfsShare\dir1\link1, \\MyDfsServer\MyDfsShare\link3</term>
	/// </item>
	/// <item>
	/// <term>Old path:\\MyDfsServer\MyDfsShare\dir1</term>
	/// </item>
	/// <item>
	/// <term>New path: \\MyDfsServer\MyDfsShare\link3</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the move operation were allowed to succeed, the result would be two completely overlapping links:
	/// \\MyDfsServer\MyDfsShare\link3\link1 and \\MyDfsServer\MyDfsShare\link3. Therefore, the move operation must fail.
	/// </para>
	/// <para>
	/// With domain-based DFS servers, the move operation is atomic; that is, either the whole operation is performed or it fails.
	/// However, with stand-alone DFS servers, the move operation is not guaranteed to be atomic. In this situation, a failure may result
	/// in a partially completed move operation and will require cleanup on behalf of the calling application.
	/// </para>
	/// <para>
	/// When the move operation succeeds, it is guaranteed that the DFS metadata was successfully modified. This does not guarantee that
	/// the DFS links were actually created on the root targets or that DFS links can be created on the root targets' storage.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsmove NET_API_STATUS NET_API_FUNCTION NetDfsMove( LPWSTR
	// OldDfsEntryPath, LPWSTR NewDfsEntryPath, ULONG Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "d9d225ac-26b9-4074-93b6-6294538a3504")]
	public static extern Win32Error NetDfsMove(string OldDfsEntryPath, string NewDfsEntryPath, DfsMoveFlags Flags);

	/// <summary>
	/// Removes a Distributed File System (DFS) link or a specific link target of a DFS link in a DFS namespace. When removing a specific
	/// link target, the link itself is removed if the last link target of the link is removed.
	/// </summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of the DFS link.</para>
	/// <para>The string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ShareName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where ShareName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>This parameter is required.</para>
	/// </param>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the server name of the link target. For more information, see the following Remarks section.
	/// Set this parameter to <c>NULL</c> if the link and all link targets are to be removed.
	/// </param>
	/// <param name="ShareName">
	/// Pointer to a string that specifies the share name of the link target. Set this parameter to <c>NULL</c> if the link and all link
	/// targets are to be removed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
	/// administrator privileges, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// When you call <c>NetDfsRemove</c> to remove a target from a link, you must specify the same target server name in the ServerName
	/// parameter that you specified when you created the link. For example, if you specified the target server's DNS name when you added
	/// the target to the link, you must specify the same DNS name when you remove the link. You cannot specify the NetBIOS name.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to remove a target from a DFS link using a call to the <c>NetDfsRemove</c> function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsremove NET_API_STATUS NET_API_FUNCTION NetDfsRemove(
	// LPWSTR DfsEntryPath, LPWSTR ServerName, LPWSTR ShareName );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "c879ba56-cc42-4fa3-960f-ddc65a75dbe3")]
	public static extern Win32Error NetDfsRemove(string DfsEntryPath, [Optional] string? ServerName, [Optional] string? ShareName);

	/// <summary>
	/// Removes the specified root target from a domain-based Distributed File System (DFS) namespace. If the last root target of the DFS
	/// namespace is being removed, the function also deletes the DFS namespace. A DFS namespace can be deleted without first deleting
	/// all the links in it.
	/// </summary>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the server name of the root target to be removed. The server must host the root of a
	/// domain-based DFS namespace. This parameter is required.
	/// </param>
	/// <param name="RootShare">
	/// Pointer to a string that specifies the name of the DFS root target share to be removed. This parameter is required.
	/// </param>
	/// <param name="FtDfsName">
	/// Pointer to a string that specifies the name of the domain-based DFS namespace from which to remove the root target. This
	/// parameter is required. Typically, it is the same as the RootShare parameter.
	/// </param>
	/// <param name="Flags">This parameter is reserved and must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The root target server must be available and accessible; otherwise, the call to the <c>NetDfsRemoveFtRoot</c> function will fail.
	/// </para>
	/// <para>
	/// The caller must have permission to update the DFS container in the directory service and must have Administrator privilege on the
	/// DFS host (root) server.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsremoveftroot NET_API_STATUS NET_API_FUNCTION
	// NetDfsRemoveFtRoot( LPWSTR ServerName, LPWSTR RootShare, LPWSTR FtDfsName, DWORD Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "aa5c9991-ca8e-48ba-922d-feadaff45cc2")]
	public static extern Win32Error NetDfsRemoveFtRoot(string ServerName, string RootShare, string FtDfsName, uint Flags = 0);

	/// <summary>
	/// <para>
	/// Removes the specified root target from a domain-based Distributed File System (DFS) namespace, even if the root target server is
	/// offline. If the last root target of the DFS namespace is being removed, the function also deletes the DFS namespace. A DFS
	/// namespace can be deleted without first deleting all the links in it.
	/// </para>
	/// <para>
	/// <c>Note</c> The <c>NetDfsRemoveFtRootForced</c> function does not update the registry on the DFS root target server. For more
	/// information, see the Remarks section.
	/// </para>
	/// </summary>
	/// <param name="DomainName">
	/// Pointer to a string that specifies the name of the Active Directory domain that contains the domain-based DFS namespace to be
	/// removed. This parameter is required.
	/// </param>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the name of the DFS root target server to be removed. The server must host a root of the
	/// domain-based DFS namespace. This parameter is required.
	/// </param>
	/// <param name="RootShare">
	/// Pointer to a string that specifies the name of the DFS root target share to be removed. This parameter is required.
	/// </param>
	/// <param name="FtDfsName">
	/// Pointer to a string that specifies the name of the domain-based DFS namespace from which to remove the root target. This
	/// parameter is required. Typically, it is the same as the RootShare parameter.
	/// </param>
	/// <param name="Flags">Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must have permission to update the DFS container in the directory service and must have Administrator privilege on the
	/// DFS host (root) server.
	/// </para>
	/// <para>
	/// The <c>NetDfsRemoveFtRootForced</c> function forcibly removes a domain-based DFS root target from a DFS namespace. It is used to
	/// delete a domain-based DFS namespace when the root target servers of the namespace are no longer available (for example, because
	/// they have been decommissioned).
	/// </para>
	/// <para>
	/// Because the DFS root target is removed by contacting the primary domain controller (PDC) and not by removing the DFS root target
	/// server, <c>NetDfsRemoveFtRootForced</c> does not update the registry of the root target server. Under normal circumstances, you
	/// can remove the root target from a DFS domain root by calling the NetDfsRemoveFtRoot function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsremoveftrootforced NET_API_STATUS NET_API_FUNCTION
	// NetDfsRemoveFtRootForced( LPWSTR DomainName, LPWSTR ServerName, LPWSTR RootShare, LPWSTR FtDfsName, DWORD Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "4eaa0e2a-fa09-4a20-98e1-4c0c4ff5d0ef")]
	public static extern Win32Error NetDfsRemoveFtRootForced(string DomainName, string ServerName, string RootShare, string FtDfsName, uint Flags = 0);

	/// <summary>
	/// Removes a DFS root target from a domain-based DFS namespace. If the root target is the last root target in the DFS namespace,
	/// this function removes the DFS namespace. This function can also be used to remove a stand-alone DFS namespace.
	/// </summary>
	/// <param name="pDfsPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS namespace.</para>
	/// <para>For a stand-alone DFS namespace, this string should be in the following form:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>where ServerName is the name of the server that hosts the DFS root target and DfsName is the name of the DFS namespace.</para>
	/// <para>For a domain-based DFS namespace, this string should be in the following form:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsName</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace and DomDfsName is the name of the DFS namespace.
	/// </para>
	/// </param>
	/// <param name="pTargetPath">
	/// <para>
	/// Pointer to a null-terminated Unicode string that specifies the UNC path of a DFS root target for the DFS namespace that is
	/// specified in the pDfsPath parameter.
	/// </para>
	/// <para>
	/// For a stand-alone DFS namespace, this parameter must be <c>NULL</c>. For a domain-based DFS namespace, the string should be in
	/// the following form:
	/// </para>
	/// <para>\ServerName&lt;i&gt;RootShare</para>
	/// <para>
	/// where ServerName is the name of the server that hosts the DFS root target and RootShare is the name of the folder on the server.
	/// </para>
	/// </param>
	/// <param name="Flags">
	/// <para>
	/// A flag that specifies the type of removal operation. For a stand-alone DFS namespace, this parameter must be zero. For a
	/// domain-based DFS namespace, it can be zero or the following value. If it is zero, this indicates a normal removal operation.
	/// </para>
	/// <para>DFS_FORCE_REMOVE (0x80000000)</para>
	/// <para>If this flag is specified for a domain-based DFS namespace, the root target is removed even if it is not accessible.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>The caller must have Administrator privileges on the DFS server.</para>
	/// <para>The following list shows which parameter values you should specify, according to the desired result.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>pDfsPath parameter</term>
	/// <term>pTargetPath parameter</term>
	/// <term>Result</term>
	/// </listheader>
	/// <item>
	/// <term>\\DomainName\DomDfsName</term>
	/// <term>\\ServerName\RootShare</term>
	/// <term>
	/// Delete a Windows 2000 mode or Windows Server 2008 mode domain-based DFS root target. If the target is the last root target for
	/// the DFS namespace, the function also deletes the DFS namespace.
	/// </term>
	/// </item>
	/// <item>
	/// <term>\\ServerName\DfsName</term>
	/// <term>NULL</term>
	/// <term>Delete a stand-alone DFS namespace.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsremoveroottarget NET_API_STATUS NET_API_FUNCTION
	// NetDfsRemoveRootTarget( LPWSTR pDfsPath, LPWSTR pTargetPath, ULONG Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "9a8c78f4-3170-4568-940c-1c51aebad3ae")]
	public static extern Win32Error NetDfsRemoveRootTarget(string pDfsPath, [Optional] string? pTargetPath, DfsRemoveFlags Flags);

	/// <summary>Deletes a stand-alone Distributed File System (DFS) namespace.</summary>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the DFS root target server name of the stand-alone DFS namespace to be removed. This parameter
	/// is required.
	/// </param>
	/// <param name="RootShare">
	/// Pointer to a string that specifies the DFS root target share name of the stand-alone DFS namespace to be removed. This parameter
	/// is required.
	/// </param>
	/// <param name="Flags">Must be zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
	/// administrator privileges, see Running with Special Privileges.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfsremovestdroot NET_API_STATUS NET_API_FUNCTION
	// NetDfsRemoveStdRoot( LPWSTR ServerName, LPWSTR RootShare, DWORD Flags );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "850427cc-56da-45cc-8833-e242acc53589")]
	public static extern Win32Error NetDfsRemoveStdRoot(string ServerName, string RootShare, uint Flags = 0);

	/// <summary>Modifies information about a Distributed File System (DFS) root or link in the cache maintained by the DFS client.</summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
	/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>For a root, the string can be in one of two forms:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>or</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname</para>
	/// <para>where the values of the names are the same as those described previously.</para>
	/// <para>This parameter is required.</para>
	/// </param>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the DFS link target server name. This parameter is optional. For more information, see the
	/// Remarks section.
	/// </param>
	/// <param name="ShareName">
	/// Pointer to a string that specifies the DFS link target share name. This parameter is optional. For additional information, see
	/// the following Remarks section.
	/// </param>
	/// <param name="Level">
	/// <para>Specifies the information level of the request. This parameter can be one of the following values.</para>
	/// <para>101</para>
	/// <para>Set the local DFS link's storage status. The Buffer parameter points to a DFS_INFO_101 structure.</para>
	/// <para>102</para>
	/// <para>
	/// Set the local DFS link time-out. The Buffer parameter points to a DFS_INFO_102 structure. For more information, see the following
	/// Remarks section.
	/// </para>
	/// </param>
	/// <param name="Buffer">
	/// Pointer to a buffer that contains the information to be set. The format of this information depends on the value of the Level
	/// parameter. For more information, see Network Management Function Buffers.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
	/// administrator privileges, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// Setting the time-out to zero may not immediately delete the local cached copy of the DFS link, because threads may be referencing
	/// the entry.
	/// </para>
	/// <para>Because there is only one time-out on a DFS link, the ServerName and ShareName parameters are ignored for level 102.</para>
	/// <para>
	/// The <c>DFS_STORAGE_STATE_ONLINE</c> and <c>DFS_STORAGE_STATE_OFFLINE</c> bits will be ignored. The
	/// <c>DFS_STORAGE_STATE_ACTIVE</c> bit is valid only if no files are open to the active computer.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfssetclientinfo NET_API_STATUS NET_API_FUNCTION
	// NetDfsSetClientInfo( LPWSTR DfsEntryPath, LPWSTR ServerName, LPWSTR ShareName, DWORD Level, LPBYTE Buffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "4c95dffb-a092-45ad-9a3f-37d3abbf4427")]
	public static extern Win32Error NetDfsSetClientInfo(string DfsEntryPath, [Optional] string? ServerName, [Optional] string? ShareName, uint Level, IntPtr Buffer);

	/// <summary>
	/// Sets the security descriptor of the container object for the domain-based DFS namespaces in the specified Active Directory domain.
	/// </summary>
	/// <param name="DomainName">Pointer to a string that specifies the Active Directory domain name.</param>
	/// <param name="SecurityInformation">
	/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to set.
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// Pointer to a SECURITY_DESCRIPTOR structure that contains the security attributes to set as specified in the SecurityInformation parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// The security descriptor is set on the "CN=DFS-Configuration,CN=System,DC=domain" object in Active Directory from the primary
	/// domain controller (PDC) of the domain specified in the DomainName parameter, where &lt;domain&gt; is the distinguished name of
	/// the domain specified in the DomainName parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfssetftcontainersecurity NET_API_STATUS NET_API_FUNCTION
	// NetDfsSetFtContainerSecurity( LPWSTR DomainName, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR
	// pSecurityDescriptor );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "84300e38-b263-4c38-bc31-5221621b89f1")]
	public static extern Win32Error NetDfsSetFtContainerSecurity(string DomainName, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>Sets or modifies information about a specific Distributed File System (DFS) root, root target, link, or link target.</summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.</para>
	/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
	/// namespace; and link_path is a DFS link.
	/// </para>
	/// <para>For a root, the string can be in one of two forms:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>or</para>
	/// <para>\DomainName&lt;i&gt;DomDfsname</para>
	/// <para>where the values of the names are the same as those described previously.</para>
	/// </param>
	/// <param name="ServerName">
	/// Pointer to a string that specifies the DFS link target server name. This parameter is optional. For more information, see the
	/// Remarks section.
	/// </param>
	/// <param name="ShareName">
	/// Pointer to a string that specifies the DFS link target share name. This may also be a share name with a path relative to the
	/// share. For example, "share1\mydir1\mydir2". This parameter is optional. For more information, see the Remarks section.
	/// </param>
	/// <param name="Level">
	/// <para>Specifies the information level of the data. This parameter can be one of the following values.</para>
	/// <para>100</para>
	/// <para>
	/// Set the comment associated with the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points to a
	/// DFS_INFO_100 structure.
	/// </para>
	/// <para>101</para>
	/// <para>
	/// Set the storage state associated with the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points
	/// to a DFS_INFO_101 structure.
	/// </para>
	/// <para>102</para>
	/// <para>
	/// Set the time-out value associated with the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points
	/// to a DFS_INFO_102 structure.
	/// </para>
	/// <para>103</para>
	/// <para>
	/// Set the property flags for the DFS root or link specified in the DfsEntryPath parameter. The Buffer parameter points to a
	/// DFS_INFO_103 structure.
	/// </para>
	/// <para>104</para>
	/// <para>
	/// Set the target priority rank and class for the root target or link target specified in the DfsEntryPath parameter. The Buffer
	/// parameter points to a DFS_INFO_104 structure.
	/// </para>
	/// <para>105</para>
	/// <para>
	/// Set the comment, state, and time-out information, as well as property flags, for the DFS root or link specified in the
	/// DfsEntryPath parameter. The Buffer parameter points to a DFS_INFO_105 structure.
	/// </para>
	/// <para>106</para>
	/// <para>
	/// Set the target state and priority for the root target or link target specified in the DfsEntryPath parameter. This information
	/// cannot be set for a DFS namespace root or link, only for a root target or link target. The Buffer parameter points to a
	/// DFS_INFO_106 structure.
	/// </para>
	/// <para>107</para>
	/// <para>
	/// Set the comment, state, time-out information, and property flags for the DFS root or link specified in the DfsEntryPath
	/// parameter. For DFS links, you can also set the security descriptor for the link's reparse point. The Buffer parameter points to a
	/// DFS_INFO_107 structure.
	/// </para>
	/// <para>150</para>
	/// <para>Set the security descriptor for a DFS link's reparse point. The Buffer parameter points to a DFS_INFO_150 structure.</para>
	/// </param>
	/// <param name="Buffer">
	/// Pointer to a buffer that specifies the data. The format of this data depends on the value of the Level parameter. For more
	/// information, see Network Management Function Buffers.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The caller must have Administrator privilege on the DFS server. For more information about calling functions that require
	/// administrator privileges, see Running with Special Privileges.
	/// </para>
	/// <para>
	/// If you specify both the ServerName and ShareName parameters, the <c>NetDfsSetInfo</c> function sets or modifies information
	/// specific to that root target or link target. If the parameters are <c>NULL</c>, the function sets or modifies information that is
	/// specific to the DFS namespace root or the DFS link instead of a specific DFS root target or link target.
	/// </para>
	/// <para>
	/// Because only one comment and one time-out can be set for a DFS root or link, the ServerName and ShareName parameters are ignored
	/// for information levels 100 and 102. These parameters are required for level 101.
	/// </para>
	/// <para>
	/// For information level 101, the <c>DFS_VOLUME_STATE_RESYNCHRONIZE</c> and <c>DFS_VOLUME_STATE_STANDBY</c> state values can be set
	/// as follows for a specific domain-based DFS root when there is more than one DFS root target for the DFS namespace:
	/// </para>
	/// <para>
	/// The DfsEntryPath parameter specifies the domain-based DFS namespace, and the ServerName and ShareName parameters taken together
	/// specify the DFS root target on which the set-information operation is to be performed.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// The following code sample demonstrates how to associate a comment with a DFS link using a call to the <c>NetDfsSetInfo</c>
	/// function. The sample specifies information level 100 (DFS_INFO_100).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfssetinfo NET_API_STATUS NET_API_FUNCTION NetDfsSetInfo(
	// LPWSTR DfsEntryPath, LPWSTR ServerName, LPWSTR ShareName, DWORD Level, LPBYTE Buffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "5526afa7-82bc-47c7-99d6-44e41ef772b1")]
	public static extern Win32Error NetDfsSetInfo(string DfsEntryPath, [Optional] string? ServerName, [Optional] string? ShareName, uint Level, IntPtr Buffer);

	/// <summary>Sets the security descriptor for the root object of the specified DFS namespace.</summary>
	/// <param name="DfsEntryPath">
	/// <para>Pointer to a string that specifies the Universal Naming Convention (UNC) path of a DFS namespace root.</para>
	/// <para>The string can be in one of two forms. The first form is as follows:</para>
	/// <para>\ServerName&lt;i&gt;DfsName</para>
	/// <para>
	/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace and Dfsname is the name of the
	/// DFS namespace.
	/// </para>
	/// <para>The second form is as follows:</para>
	/// <para>\DomainName&lt;i&gt;DomDfsName</para>
	/// <para>
	/// where DomainName is the name of the domain that hosts the domain-based DFS namespace and DomDfsName is the name of the DFS namespace.
	/// </para>
	/// </param>
	/// <param name="SecurityInformation">
	/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to set on the root object.
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// SECURITY_DESCRIPTOR structure that contains the security descriptor to set as specified in the SecurityInformation parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For domain-based DFS namespaces, the security descriptor is set on the "CN=DomDfsName,CN=DFS-Configuration,CN=System,DC=domain"
	/// object in Active Directory at the primary domain controller (PDC) of the domain that hosts the DFS namespace, where
	/// &lt;DomDfsName&gt; is the name of the domain-based DFS namespace and &lt;domain&gt; is the distinguished name of the Active
	/// Directory domain that hosts the namespace.
	/// </para>
	/// <para>
	/// For stand-alone roots, the security descriptor is set on the object specified by the
	/// <c>HKLM</c>&lt;b&gt;Software&lt;b&gt;Microsoft&lt;b&gt;Dfs&lt;b&gt;Standalone&lt;b&gt;&lt;root-name&gt; registry entry.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfssetsecurity NET_API_STATUS NET_API_FUNCTION
	// NetDfsSetSecurity( LPWSTR DfsEntryPath, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "7ee81f67-face-498f-b5bd-ca2636408012")]
	public static extern Win32Error NetDfsSetSecurity(string DfsEntryPath, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>Sets the security descriptor for the container object of the specified stand-alone DFS namespace.</summary>
	/// <param name="MachineName">
	/// The name of the stand-alone DFS root's host machine. Pointer to a string that specifies the name of the server that hosts the
	/// stand-alone DFS namespace.
	/// </param>
	/// <param name="SecurityInformation">
	/// SECURITY_INFORMATION structure that contains bit flags that indicate the type of security information to set on the root object.
	/// </param>
	/// <param name="pSecurityDescriptor">
	/// Pointer to a SECURITY_DESCRIPTOR structure that contains the security attributes to set as specified in the SecurityInformation parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>NERR_Success</c>.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// The security descriptor is set for the object specified by the
	/// <c>HKLM</c>&lt;b&gt;Software&lt;b&gt;Microsoft&lt;b&gt;Dfs&lt;b&gt;Standalone key in the registry of the server specified in the
	/// MachineName parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/nf-lmdfs-netdfssetstdcontainersecurity NET_API_STATUS NET_API_FUNCTION
	// NetDfsSetStdContainerSecurity( LPWSTR MachineName, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR
	// pSecurityDescriptor );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("lmdfs.h", MSDNShortId = "BC408A12-5106-45A0-BBED-0468D51708BC")]
	public static extern Win32Error NetDfsSetStdContainerSecurity(string MachineName, SECURITY_INFORMATION SecurityInformation, PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>
	/// <para>Input buffer used with the FSCTL_DFS_GET_PKT_ENTRY_STATE control code.</para>
	/// <note type="important">This structure does not match the native Win32 structure and can only be used when using a Vanara memory
	/// allocator that supports IVanaraMarshaler. This is done automatically when calling DeviceIOControl generic overloads.</note>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-__unnamed_struct_2 typedef struct { USHORT DfsEntryPathLen;
	// USHORT ServerNameLen; USHORT ShareNameLen; ULONG Level; WCHAR Buffer[1]; } DFS_GET_PKT_ENTRY_STATE_ARG, *PDFS_GET_PKT_ENTRY_STATE_ARG;
	[PInvokeData("lmdfs.h", MSDNShortId = "eb69d346-d88c-48e8-abd7-5cbb5976f41f")]
	[VanaraMarshaler(typeof(DFS_GET_PKT_ENTRY_STATE_ARG_Marshaler))]
	public struct DFS_GET_PKT_ENTRY_STATE_ARG
	{
		/// <summary>The DFS Entry Path Unicode string.</summary>
		public string DfsEntryPath;

		/// <summary>The Server Name Unicode string.</summary>
		public string? ServerName;

		/// <summary>The Share Name Unicode string.</summary>
		public string? ShareName;

		/// <summary>
		/// <para>Length of the Level string in bytes.</para>
		/// <para>1</para>
		/// <para>
		/// Return the DFS root or DFS link name. On return the output buffer for the FSCTL_DFS_GET_PKT_ENTRY_STATE control code contains
		/// a DFS_INFO_1 structure.
		/// </para>
		/// <para>2</para>
		/// <para>
		/// Return the DFS root or DFS link name, status, and the number of DFS targets. On return the output buffer for the
		/// FSCTL_DFS_GET_PKT_ENTRY_STATE control code contains a DFS_INFO_2 structure.
		/// </para>
		/// <para>3</para>
		/// <para>
		/// Return the DFS root or DFS link name, status, and target information. On return output buffer for the
		/// FSCTL_DFS_GET_PKT_ENTRY_STATE control code contains a DFS_INFO_3 structure.
		/// </para>
		/// <para>4</para>
		/// <para>
		/// Return the DFS root or DFS link name, status, <c>GUID</c>, time-out, and target information. On return the output buffer for
		/// the FSCTL_DFS_GET_PKT_ENTRY_STATE control code contains a DFS_INFO_4 structure.
		/// </para>
		/// <para>101</para>
		/// <para>
		/// Set the storage state associated with the DFS root or link specified in the DFS Entry Path string. On the return output
		/// buffer for the FSCTL_DFS_GET_PKT_ENTRY_STATE control code contains a DFS_INFO_101 structure.
		/// </para>
		/// </summary>
		public uint Level;

		[StructLayout(LayoutKind.Sequential)]
		private struct DFS_GET_PKT_ENTRY_STATE_ARG_NATIVE
		{
			public ushort DfsEntryPathLen;
			public ushort ServerNameLen;
			public ushort ShareNameLen;
			public uint Level;
			public ushort Buffer;
		}

		private class DFS_GET_PKT_ENTRY_STATE_ARG_Marshaler : IVanaraMarshaler
		{
			static readonly long bufferOffset = Marshal.OffsetOf(typeof(DFS_GET_PKT_ENTRY_STATE_ARG_NATIVE), "Buffer").ToInt64();
			public SizeT GetNativeSize() => Marshal.SizeOf(typeof(DFS_GET_PKT_ENTRY_STATE_ARG_NATIVE));
			SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject)
			{
				if (managedObject is not DFS_GET_PKT_ENTRY_STATE_ARG arg)
					throw new ArgumentException("Managed object must be a DFS_GET_PKT_ENTRY_STATE_ARG struct.", nameof(managedObject));
				DFS_GET_PKT_ENTRY_STATE_ARG_NATIVE narg = new()
				{
					DfsEntryPathLen = (ushort)StringHelper.GetByteCount(arg.DfsEntryPath, false, CharSet.Unicode),
					ServerNameLen = (ushort)StringHelper.GetByteCount(arg.ServerName, false, CharSet.Unicode),
					ShareNameLen = (ushort)StringHelper.GetByteCount(arg.ShareName, false, CharSet.Unicode),
					Level = arg.Level,
				};
				string buffer = string.Concat(arg.DfsEntryPath, arg.ServerName, arg.ShareName);
				var mem = new SafeHGlobalHandle(GetNativeSize() + StringHelper.GetByteCount(buffer, false, CharSet.Unicode) - sizeof(ushort));
				mem.Write(narg, false);
				StringHelper.Write(buffer, ((IntPtr)mem).Offset(bufferOffset), out _, false, CharSet.Unicode);
				return mem;
			}
			object? IVanaraMarshaler.MarshalNativeToManaged(nint pNativeData, SizeT allocatedBytes) => throw new NotImplementedException();
		}
	}

	/// <summary>
	/// Contains the name of a Distributed File System (DFS) root or link. This structure is only for use with the NetDfsEnum,
	/// NetDfsGetClientInfo, and NetDfsGetInfo functions and the FSCTL_DFS_GET_PKT_ENTRY_STATE control code.
	/// </summary>
	/// <remarks>The DFS functions use the <c>DFS_INFO_1</c> structure to retrieve information about a DFS root or link.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_1 typedef struct _DFS_INFO_1 { LPWSTR EntryPath; }
	// DFS_INFO_1, *PDFS_INFO_1, *LPDFS_INFO_1;
	[PInvokeData("lmdfs.h", MSDNShortId = "96647570-BADD-4925-AB90-054A00BA04C4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_1
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;
	}

	/// <summary>Contains a comment associated with a Distributed File System (DFS) root or link.</summary>
	/// <remarks>The DFS functions use the <c>DFS_INFO_100</c> structure to retrieve and set information about a DFS root or link.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_100 typedef struct _DFS_INFO_100 { LPWSTR Comment; }
	// DFS_INFO_100, *PDFS_INFO_100, *LPDFS_INFO_100;
	[PInvokeData("lmdfs.h", MSDNShortId = "763ba0f0-01e9-47cf-bbe5-93e13aa83aa0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_100
	{
		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the comment associated with the specified DFS root or link. The
		/// comment is associated with the DFS namespace root or link and not with a specific DFS root target or link target.
		/// </summary>
		public string Comment;
	}

	/// <summary>Describes the state of storage on a DFS root, link, root target, or link target.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_101 typedef struct _DFS_INFO_101 { DWORD State; }
	// DFS_INFO_101, *PDFS_INFO_101, *LPDFS_INFO_101;
	[PInvokeData("lmdfs.h", MSDNShortId = "506aaf68-2f23-4dd2-b43c-aeb86334a3d8")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_101
	{
		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the status of the host server. Following are valid values for this member. Note
		/// that the <c>DFS_STORAGE_STATE_OFFLINE</c> and <c>DFS_STORAGE_STATE_ONLINE</c> values are mutually exclusive.
		/// </para>
		/// <para>
		/// The storage states can only be set on DFS root targets or DFS link targets. The DFS volume states can only be set on a DFS
		/// namespace root or DFS link and not on individual targets.
		/// </para>
		/// <para>DFS_STORAGE_STATE_OFFLINE (0x00000001)</para>
		/// <para>The DFS storage is offline.</para>
		/// <para>DFS_STORAGE_STATE_ONLINE (0x00000002)</para>
		/// <para>The DFS storage is online.</para>
		/// <para>DFS_STORAGE_STATE_ACTIVE (0x00000004)</para>
		/// <para>The DFS storage is active. This value is only for use with the NetDfsSetClientInfo function.</para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have
		/// failed. This value is read-only.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_STATE_RESYNCHRONIZE (0x00000010)</para>
		/// <para>Forces a resynchronization on the DFS root target. This flag is valid only for a DFS root target, and is write-only.</para>
		/// <para>DFS_VOLUME_STATE_STANDBY (0x00000020)</para>
		/// <para>Puts a root volume in standby mode. This flag is valid for a clustered DFS namespace only.</para>
		/// </summary>
		public DfsState State;
	}

	/// <summary>Contains a time-out value to associate with a Distributed File System (DFS) root or a link in a named DFS root.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_102 typedef struct _DFS_INFO_102 { ULONG Timeout; }
	// DFS_INFO_102, *PDFS_INFO_102, *LPDFS_INFO_102;
	[PInvokeData("lmdfs.h", MSDNShortId = "ca4da0a2-d5b3-4ad6-bc00-6629b9bf13e7")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_102
	{
		/// <summary>Specifies the time-out, in seconds, to apply to the specified DFS root or link.</summary>
		public uint Timeout;
	}

	/// <summary>
	/// Contains properties that set specific behaviors for a DFS root or link. This structure can only be used with the NetDfsSetInfo function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_103 typedef struct _DFS_INFO_103 { ULONG
	// PropertyFlagMask; ULONG PropertyFlags; } DFS_INFO_103, *PDFS_INFO_103, *LPDFS_INFO_103;
	[PInvokeData("lmdfs.h", MSDNShortId = "d3d31087-770e-4434-8ee0-6183102a9a6b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_103
	{
		/// <summary>Specifies a mask value that indicates which flags are valid for evaluation in the <c>PropertyFlags</c> field.</summary>
		public DfsPropertyFlag PropertyFlagMask;

		/// <summary>
		/// <para>
		/// Bitfield, with each bit responsible for a specific property applicable to the whole DFS namespace, the DFS root, or an
		/// individual DFS link, depending on the actual property. Any combination of bits is allowed unless indicated otherwise.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_INSITE_REFERRALS (0x00000001)</para>
		/// <para>
		/// Referral response from a DFS server for a DFS root or link that contains only those targets in the same site as the client
		/// requesting the referral. Targets in the two global priority classes are always returned, regardless of their site location.
		/// This flag applies to domain-based DFS roots, stand-alone DFS roots, and DFS links. If this flag is set at the DFS root, it
		/// applies to all links; otherwise, it applies to an individual link. The setting at the link does not override the root setting.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ROOT_SCALABILITY (0x00000002)</para>
		/// <para>
		/// If this flag is set, the DFS server polls the nearest domain controller (DC) instead of the primary domain controller (PDC)
		/// to check for DFS namespace changes for that namespace. Any modification to the DFS metadata by the DFS server is not
		/// controlled by this flag but is sent to the PDC. This flag is valid for the entire namespace and applies only to domain-based
		/// DFS namespaces.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_SITE_COSTING (0x00000004)</para>
		/// <para>
		/// Set this flag to enable Active Directory site costing of targets. Targets returned from the DFS server to the requesting DFS
		/// client are grouped by inter-site cost with respect to the DFS client. The groups are ordered in terms of increasing site cost
		/// with the first group consisting of targets in the same site as the client. Targets within each group are ordered randomly.
		/// </para>
		/// <para>
		/// If this flag is not enabled, the default return is two sets: one set of targets in the same site as the client, and one set
		/// of all remaining targets. This flag is valid for the entire DFS namespace and applies to both domain-based and stand-alone
		/// DFS namespaces.
		/// </para>
		/// <para>
		/// Target priorities can further influence target ordering. For more information on how site-costing is used to prioritize
		/// targets, see DFS Server Target Prioritization.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_TARGET_FAILBACK (0x00000008)</para>
		/// <para>
		/// Set this flag to enable V4 DFS clients to fail back to a more optimal (lower cost or higher priority) target. If this flag is
		/// set at the DFS root, it applies to all links; otherwise, it applies to an individual link. An individual link setting will
		/// not override a root setting. The target failback setting is provided to the DFS client in a V4 referral response by the DFS
		/// server. This flag applies to domain-based roots, stand-alone roots, and links.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_CLUSTER_ENABLED (0x00000010)</para>
		/// <para>
		/// If this flag is set, the DFS root is clustered to provide high availability for storage failover. This flag cannot be set
		/// using the NetDfsSetInfo function and applies only to stand-alone DFS roots and links.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ABDE (0x00000020)</para>
		/// <para>Scope: Domain-based DFS roots and stand-alone DFS roots.</para>
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace. This flag is valid only for DFS namespaces for which the <c>DFS_NAMESPACE_CAPABILITY_ABDE</c>
		/// capability flag is set. For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The <c>DFS_PROPERTY_FLAG_ABDE</c> flag is valid only on the DFS namespace root and not on root targets, links, or link
		/// targets. This flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		public DfsPropertyFlag PropertyFlags;
	}

	/// <summary>
	/// Contains the priority of a DFS root target or link target. This structure is only for use with the NetDfsSetInfo function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_104 typedef struct _DFS_INFO_104 {
	// DFS_TARGET_PRIORITY TargetPriority; } DFS_INFO_104, *PDFS_INFO_104, *LPDFS_INFO_104;
	[PInvokeData("lmdfs.h", MSDNShortId = "95b2cd36-4933-440d-889d-ebf36d7b9cc7")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_104
	{
		/// <summary>DFS_TARGET_PRIORITY structure that contains the specific priority class and rank of a DFS target.</summary>
		public DFS_TARGET_PRIORITY TargetPriority;
	}

	/// <summary>
	/// Contains information about a DFS root or link, including comment, state, time-out, and DFS behaviors specified by property flags.
	/// This structure is only for use with the NetDfsSetInfo function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_105 typedef struct _DFS_INFO_105 { LPWSTR Comment;
	// DWORD State; ULONG Timeout; ULONG PropertyFlagMask; ULONG PropertyFlags; } DFS_INFO_105, *PDFS_INFO_105, *LPDFS_INFO_105;
	[PInvokeData("lmdfs.h", MSDNShortId = "b9ad9e41-d5b4-446f-ac99-a51808344f77")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_105
	{
		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the state of the DFS root or link; the state of the DFS namespace root cannot be
		/// changed. One <c>DFS_VOLUME_STATE</c> flag is set, and one <c>DFS_VOLUME_FLAVOR</c> flag is set. For an example that describes
		/// the interpretation of these flags, see the Remarks section of DFS_INFO_2.
		/// </para>
		/// <para>Default (0x00000000)</para>
		/// <para>Keep the existing state.</para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the time-out, in seconds, of the DFS root or link.</summary>
		public uint Timeout;

		/// <summary>Specifies a mask value that indicates which flags are valid for evaluation in the <c>PropertyFlags</c> field.</summary>
		public DfsPropertyFlag PropertyFlagMask;

		/// <summary>
		/// <para>
		/// Bitfield, with each bit responsible for a specific property applicable to the whole DFS namespace, the DFS root, or an
		/// individual DFS link, depending on the actual property. Any combination of bits is allowed unless indicated otherwise.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_INSITE_REFERRALS (0x00000001)</para>
		/// <para>
		/// Referral response from a DFS server for a DFS root or link that contains only those targets in the same site as the client
		/// requesting the referral. Targets in the two global priority classes are always returned, independent of their site location.
		/// This flag applies to domain-based DFS roots, stand-alone roots, and links. If this flag is set at the DFS root, it applies to
		/// all links; otherwise, it applies to an individual link. Setting at the link does not override the root setting.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ROOT_SCALABILITY (0x00000002)</para>
		/// <para>
		/// If this flag is set, the DFS server polls the nearest domain controller (DC) instead of the primary domain controller (PDC)
		/// to check for DFS namespace changes for that namespace. Any modification to the DFS metadata by the DFS server is not
		/// controlled by this flag but is sent to the PDC automatically. This flag applies to the entire namespace and is valid only for
		/// domain-based DFS namespaces.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_SITE_COSTING (0x00000004)</para>
		/// <para>
		/// Set this flag to enable Active Directory site costing of targets. Targets returned from the DFS server to the requesting DFS
		/// client are grouped by inter-site cost with respect to the DFS client. The groups are ordered in terms of increasing site cost
		/// with first group consisting of targets in the same site as the client. Targets within each group are ordered randomly.
		/// </para>
		/// <para>
		/// If this flag is not enabled, the default return is two sets: one set of targets in the same site as the client, and one set
		/// of all remaining targets. This flag applies to the entire DFS namespace and is valid for both domain-based and stand-alone
		/// DFS namespaces.
		/// </para>
		/// <para>
		/// Target priorities can further influence target ordering. For more information about how site-costing is used to prioritize
		/// targets, see DFS Server Target Prioritization.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_TARGET_FAILBACK (0x00000008)</para>
		/// <para>
		/// Set this flag to enable V4 DFS clients to fail back to a more optimal (lower cost or higher priority) target. If this flag is
		/// set at the DFS root, it applies to all links; otherwise, it applies to an individual link. An individual link setting will
		/// not override a root setting. The target failback setting is provided to the DFS client in a V4 referral response by the DFS
		/// server. This flag applies to domain-based DFS roots, stand-alone roots, and links.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_CLUSTER_ENABLED (0x00000010)</para>
		/// <para>Scope: Stand-alone roots and links only.</para>
		/// <para>
		/// If this flag is set, the DFS root is clustered to provide high availability for storage failover. This flag cannot be set
		/// using the NetDfsSetInfo function.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ABDE (0x00000020)</para>
		/// <para>Scope: Domain-based DFS roots and stand-alone DFS roots.</para>
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace. This flag is valid only for DFS namespaces for which the <c>DFS_NAMESPACE_CAPABILITY_ABDE</c>
		/// capability flag is set. For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The <c>DFS_PROPERTY_FLAG_ABDE</c> flag is valid only on the DFS namespace root and not on root targets, links, or link
		/// targets. This flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		public DfsPropertyFlag PropertyFlags;
	}

	/// <summary>
	/// Contains the storage state and priority for a DFS root target or link target. This structure is only for use with the
	/// NetDfsSetInfo function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_106 typedef struct _DFS_INFO_106 { DWORD State;
	// DFS_TARGET_PRIORITY TargetPriority; } DFS_INFO_106, *PDFS_INFO_106, *LPDFS_INFO_106;
	[PInvokeData("lmdfs.h", MSDNShortId = "12c114e4-f978-4423-85a8-ec0cf9c9e8c5")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_106
	{
		/// <summary>
		/// <para>State of the target as one of the following values.</para>
		/// <para>DFS_STORAGE_STATE_OFFLINE (0x00000001)</para>
		/// <para>The DFS storage is offline.</para>
		/// <para>DFS_STORAGE_STATE_ONLINE (0x00000002)</para>
		/// <para>The DFS storage is online.</para>
		/// <para>DFS_STORAGE_STATES (0x0000000F)</para>
		/// <para>Mask value that indicates which storage flags are set.</para>
		/// </summary>
		public DfsState State;

		/// <summary>DFS_TARGET_PRIORITY structure that contains the specific priority class and rank of a DFS target.</summary>
		public DFS_TARGET_PRIORITY TargetPriority;
	}

	/// <summary>
	/// Contains information about a DFS root or link, including the comment, state, time-out, property flags, and link reparse point
	/// security descriptor. This structure is only for use with the NetDfsGetInfo and NetDfsSetInfo functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_107 typedef struct _DFS_INFO_107 { LPWSTR Comment;
	// DWORD State; ULONG Timeout; ULONG PropertyFlagMask; ULONG PropertyFlags; ULONG SecurityDescriptorLength; #if ... PUCHAR
	// pSecurityDescriptor; ULONG SdLengthReserved; #else PSECURITY_DESCRIPTOR pSecurityDescriptor; #endif } DFS_INFO_107,
	// *PDFS_INFO_107, *LPDFS_INFO_107;
	[PInvokeData("lmdfs.h", MSDNShortId = "38afc682-bb37-42ad-9e92-a1b0aa277f29")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_107
	{
		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. The <c>DFS_VOLUME_FLAVORS</c> bitmask (0x00000300) must be used to extract the DFS
		/// namespace flavor, and the <c>DFS_VOLUME_STATES</c> bitmask (0x0000000F) must be used to extract the DFS root or link state
		/// from this member. For an example that describes the interpretation of the flags, see the Remarks section of DFS_INFO_2.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the time-out, in seconds, of the DFS root or link.</summary>
		public uint Timeout;

		/// <summary>Specifies a mask value that indicates which flags are valid for evaluation in the <c>PropertyFlags</c> field.</summary>
		public DfsPropertyFlag PropertyFlagMask;

		/// <summary>
		/// <para>
		/// Bitfield, with each bit responsible for a specific property applicable to the whole DFS namespace, the DFS root, or an
		/// individual DFS link, depending on the actual property. Any combination of bits is allowed unless indicated otherwise.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_INSITE_REFERRALS (0x00000001)</para>
		/// <para>
		/// Referral response from a DFS server for a DFS root or link that contains only those targets in the same site as the client
		/// requesting the referral. Targets in the two global priority classes are always returned, regardless of their site location.
		/// This flag applies to domain-based DFS roots, stand-alone DFS roots, and DFS links. If this flag is set at the DFS root, it
		/// applies to all links; otherwise, it applies to an individual link. The setting at the link does not override the root setting.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ROOT_SCALABILITY (0x00000002)</para>
		/// <para>
		/// If this flag is set, the DFS server polls the nearest domain controller (DC) instead of the primary domain controller (PDC)
		/// to check for DFS namespace changes for that namespace. Any modification to the DFS metadata by the DFS server is not
		/// controlled by this flag but is sent to the PDC. This flag is valid for the entire namespace and applies only to domain-based
		/// DFS namespaces.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_SITE_COSTING (0x00000004)</para>
		/// <para>
		/// Set this flag to enable Active Directory site costing of targets. Targets returned from the DFS server to the requesting DFS
		/// client are grouped by inter-site cost with respect to the DFS client. The groups are ordered in terms of increasing site cost
		/// with the first group consisting of targets in the same site as the client. Targets within each group are ordered randomly.
		/// </para>
		/// <para>
		/// If this flag is not enabled, the default return is two sets: one set of targets in the same site as the client, and one set
		/// of all remaining targets. This flag is valid for the entire DFS namespace and applies to both domain-based and stand-alone
		/// DFS namespaces.
		/// </para>
		/// <para>
		/// Target priorities can further influence target ordering. For more information on how site-costing is used to prioritize
		/// targets, see DFS Server Target Prioritization.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_TARGET_FAILBACK (0x00000008)</para>
		/// <para>
		/// Set this flag to enable V4 DFS clients to fail back to a more optimal (lower cost or higher priority) target. If this flag is
		/// set at the DFS root, it applies to all links; otherwise, it applies to an individual link. An individual link setting will
		/// not override a root setting. The target failback setting is provided to the DFS client in a V4 referral response by the DFS
		/// server. This flag applies to domain-based roots, stand-alone roots, and links.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_CLUSTER_ENABLED (0x00000010)</para>
		/// <para>
		/// If this flag is set, the DFS root is clustered to provide high availability for storage failover. This flag cannot be set
		/// using the NetDfsSetInfo function and applies only to stand-alone DFS roots and links.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ABDE (0x00000020)</para>
		/// <para>Scope: Domain-based DFS roots and stand-alone DFS roots.</para>
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace. This flag is valid only for DFS namespaces for which the <c>DFS_NAMESPACE_CAPABILITY_ABDE</c>
		/// capability flag is set. For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The <c>DFS_PROPERTY_FLAG_ABDE</c> flag is valid only on the DFS namespace root and not on root targets, links, or link
		/// targets. This flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		public DfsPropertyFlag PropertyFlags;

		/// <summary>The length, in bytes, of the buffer that the pSecurityDescriptor field points to.</summary>
		public uint SecurityDescriptorLength;

		/// <summary>
		/// A self-relative security descriptor to be associated with a DFS link.For more information on security descriptors, see[MS -
		/// DTYP] section 2.4.6.
		/// </summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;
	}

	/// <summary>
	/// Contains the security descriptor for a DFS link's reparse point. This structure is only for use with the NetDfsGetInfo and
	/// NetDfsSetInfo functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_150 typedef struct _DFS_INFO_150 { ULONG
	// SecurityDescriptorLength; #if ... PUCHAR pSecurityDescriptor; ULONG SdLengthReserved; #else PSECURITY_DESCRIPTOR
	// pSecurityDescriptor; #endif } DFS_INFO_150, *PDFS_INFO_150, *LPDFS_INFO_150;
	[PInvokeData("lmdfs.h", MSDNShortId = "b0fa6fca-8e60-447d-9334-c4df04f13439")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_150
	{
		/// <summary>The length, in bytes, of the buffer that the pSecurityDescriptor field points to.</summary>
		public uint SecurityDescriptorLength;

		/// <summary>
		/// A self-relative security descriptor to be associated with a DFS link.For more information on security descriptors, see[MS -
		/// DTYP] section 2.4.6.
		/// </summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;
	}

	/// <summary>
	/// Contains information about a Distributed File System (DFS) root or link. This structure contains the name, status, and number of
	/// DFS targets for the root or link. This structure is only for use with the NetDfsEnum, NetDfsGetClientInfo, and NetDfsGetInfo
	/// functions and the FSCTL_DFS_GET_PKT_ENTRY_STATE control code.
	/// </summary>
	/// <remarks>
	/// <para>The DFS functions use the <c>DFS_INFO_2</c> structure to retrieve information about a DFS root or link.</para>
	/// <para>Following is an example that describes interpretation of the flags that can be returned in the <c>State</c> member:</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_2 typedef struct _DFS_INFO_2 { LPWSTR EntryPath;
	// LPWSTR Comment; DWORD State; DWORD NumberOfStorages; } DFS_INFO_2, *PDFS_INFO_2, *LPDFS_INFO_2;
	[PInvokeData("lmdfs.h", MSDNShortId = "c5fe27be-fd6e-4cf0-abf6-8363c78edf5b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_2
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;

		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. The <c>DFS_VOLUME_FLAVORS</c> bitmask (0x00000300) must be used to extract the DFS
		/// namespace flavor, and the <c>DFS_VOLUME_STATES</c> bitmask (0x0000000F) must be used to extract the DFS root or link state
		/// from this member. For an example that describes the interpretation of the flags, see the following Remarks section.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the number of DFS targets.</summary>
		public uint NumberOfStorages;
	}

	/// <summary>Contains the name of a domain-based Distributed File System (DFS) namespace.</summary>
	/// <remarks>The <c>DFS_INFO_200</c> structure is used to enumerate domain-based DFS namespaces in a domain.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_200 typedef struct _DFS_INFO_200 { LPWSTR FtDfsName;
	// } DFS_INFO_200, *PDFS_INFO_200, *LPDFS_INFO_200;
	[PInvokeData("lmdfs.h", MSDNShortId = "a37a97b2-f2f2-45fc-9466-da75e273b075")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_200
	{
		/// <summary>Pointer to a null-terminated Unicode string that contains the name of a domain-based DFS namespace.</summary>
		public string FtDfsName;
	}

	/// <summary>
	/// Contains information about a Distributed File System (DFS) root or link. This structure contains the name, status, number of DFS
	/// targets, and information about each target of the root or link. This structure is only for use with the NetDfsEnum,
	/// NetDfsGetClientInfo, and NetDfsGetInfo functions and the FSCTL_DFS_GET_PKT_ENTRY_STATE control code.
	/// </summary>
	/// <remarks>A <c>DFS_INFO_3</c> structure contains one or more DFS_STORAGE_INFO structures, one for each DFS target.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_3 typedef struct _DFS_INFO_3 { LPWSTR EntryPath;
	// LPWSTR Comment; DWORD State; DWORD NumberOfStorages; #if ... LPDFS_STORAGE_INFO Storage; #else LPDFS_STORAGE_INFO Storage; #endif
	// } DFS_INFO_3, *PDFS_INFO_3, *LPDFS_INFO_3;
	[PInvokeData("lmdfs.h", MSDNShortId = "fd60cb52-fa17-4cac-a7e8-9803303336dc")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_3
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;

		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. The <c>DFS_VOLUME_FLAVORS</c> bitmask (0x00000300) must be used to extract the DFS
		/// namespace flavor, and the <c>DFS_VOLUME_STATES</c> bitmask (0x0000000F) must be used to extract the DFS root or link state
		/// from this member. For an example that describes the interpretation of the flags, see the Remarks section of DFS_INFO_2.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the number of DFS targets.</summary>
		public uint NumberOfStorages;

		/// <summary>
		/// A pointer to an array of DFS_STORAGE_INFO structures containing information about each target. (For more information, see
		/// section 2.2.2.5). The NumberOfStorages member specifies the number of structures within this storage array.
		/// </summary>
		public IntPtr Storage;
	}

	/// <summary>Contains the name and type (domain-based or stand-alone) of a DFS namespace.</summary>
	/// <remarks>The DFS functions use the <c>DFS_INFO_300</c> structure to enumerate DFS namespaces hosted on a machine.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_300 typedef struct _DFS_INFO_300 { DWORD Flags;
	// LPWSTR DfsName; } DFS_INFO_300, *PDFS_INFO_300, *LPDFS_INFO_300;
	[PInvokeData("lmdfs.h", MSDNShortId = "b418517a-9313-49e9-a679-69b02f4ee37f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_300
	{
		/// <summary>
		/// <para>Value that specifies the type of the DFS namespace. This member can be one of the following values.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>Specifies a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>Specifies a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState Flags;

		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that contains the name of a DFS namespace. This member can have one of the
		/// following two formats.
		/// </para>
		/// <para>The first format is:</para>
		/// <para>&lt;i&gt;ServerName&lt;i&gt;DfsName</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace and DfsName is the name of
		/// the DFS namespace.
		/// </para>
		/// <para>The second format is:</para>
		/// <para>&lt;i&gt;DomainName&lt;i&gt;DomDfsName</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace and DomDfsname is the name of the DFS namespace.
		/// </para>
		/// </summary>
		public string DfsName;
	}

	/// <summary>
	/// Contains information about a Distributed File System (DFS) root or link. This structure contains the name, status, <c>GUID</c>,
	/// time-out, number of targets, and information about each target of the root or link. This structure is only for use with the
	/// NetDfsEnum, NetDfsGetClientInfo, and NetDfsGetInfo functions and the FSCTL_DFS_GET_PKT_ENTRY_STATE control code.
	/// </summary>
	/// <remarks>A <c>DFS_INFO_4</c> structure contains one or more DFS_STORAGE_INFO structures, one for each DFS target.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_4 typedef struct _DFS_INFO_4 { LPWSTR EntryPath;
	// LPWSTR Comment; DWORD State; ULONG Timeout; GUID Guid; DWORD NumberOfStorages; #if ... LPDFS_STORAGE_INFO Storage; #else
	// LPDFS_STORAGE_INFO Storage; #endif } DFS_INFO_4, *PDFS_INFO_4, *LPDFS_INFO_4;
	[PInvokeData("lmdfs.h", MSDNShortId = "0b255be8-b719-4f40-9051-7e8a1bffa0e0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_4
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;

		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. The <c>DFS_VOLUME_FLAVORS</c> bitmask (0x00000300) must be used to extract the DFS
		/// namespace flavor, and the <c>DFS_VOLUME_STATES</c> bitmask (0x0000000F) must be used to extract the DFS root or link state
		/// from this field. For an example that describes the interpretation of the flags, see the Remarks section of DFS_INFO_2.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the time-out, in seconds, of the DFS root or link.</summary>
		public uint Timeout;

		/// <summary>Specifies the GUID of the DFS root or link.</summary>
		public Guid Guid;

		/// <summary>Specifies the number of DFS targets.</summary>
		public uint NumberOfStorages;

		/// <summary>
		/// A pointer to an array of DFS_STORAGE_INFO structures containing information about each target. (For more information, see
		/// section 2.2.2.5). The NumberOfStorages member specifies the number of structures within this storage array.
		/// </summary>
		public IntPtr Storage;
	}

	/// <summary>
	/// <para>
	/// Contains information about a Distributed File System (DFS) root or link. This structure contains the name, status, <c>GUID</c>,
	/// time-out, namespace/root/link properties, metadata size, and number of targets for the root or link. This structure is only for
	/// use with the NetDfsEnum, NetDfsGetClientInfo, and NetDfsGetInfo functions.
	/// </para>
	/// <para>To retrieve information about the targets of the DFS namespace, use DFS_INFO_6 instead.</para>
	/// </summary>
	/// <remarks>
	/// To retrieve information about targets and target priorities, use the DFS_INFO_6 structure. <c>DFS_INFO_5</c> is used to specify
	/// information about a DFS namespace without target information.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_5 typedef struct _DFS_INFO_5 { LPWSTR EntryPath;
	// LPWSTR Comment; DWORD State; ULONG Timeout; GUID Guid; ULONG PropertyFlags; ULONG MetadataSize; DWORD NumberOfStorages; }
	// DFS_INFO_5, *PDFS_INFO_5, *LPDFS_INFO_5;
	[PInvokeData("lmdfs.h", MSDNShortId = "bd68d7bf-94e1-41f9-84e9-e58ab34378a1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_5
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;

		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. For an example that describes the interpretation of the flags, see the Remarks section
		/// of DFS_INFO_2.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the time-out, in seconds, of the DFS root or link.</summary>
		public uint Timeout;

		/// <summary>Specifies the GUID of the DFS root or link.</summary>
		public Guid Guid;

		/// <summary>
		/// <para>Specifies a set of flags describing specific properties of a DFS namespace, root, or link.</para>
		/// <para>DFS_PROPERTY_FLAG_INSITE_REFERRALS (0x00000001)</para>
		/// <para>
		/// Only targets in the same site as the client are returned. This flag is valid for both domain and stand-alone roots and links.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ROOT_SCALABILITY (0x00000002)</para>
		/// <para>
		/// The nearest domain controller is polled instead of the PDC for DFS namespace changes. This flag is only valid for domain roots.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_SITE_COSTING (0x00000004)</para>
		/// <para>
		/// Active Directory site costing of targets is enabled, grouping targets into sets of increasing site costs from DFS client to
		/// target. Each set has targets with the same cost. This flag is only valid for domain and stand-alone roots.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_TARGET_FAILBACK (0x00000008)</para>
		/// <para>
		/// The DFS client fails back to a closer available target after failing over to a non-optimal target. This flag is valid for
		/// both domain and stand-alone roots and links.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_CLUSTER_ENABLED (0x00000010)</para>
		/// <para>The DFS root is clustered. This flag cannot be set using the NetDfsSetInfo function.</para>
		/// <para>DFS_PROPERTY_FLAG_ABDE (0x00000020)</para>
		/// <para>Scope: Domain-based DFS roots and stand-alone DFS roots.</para>
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace. This flag is valid only for DFS namespaces for which the <c>DFS_NAMESPACE_CAPABILITY_ABDE</c>
		/// capability flag is set. For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The <c>DFS_PROPERTY_FLAG_ABDE</c> flag is valid only on the DFS namespace root and not on root targets, links, or link
		/// targets. This flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		public DfsPropertyFlag PropertyFlags;

		/// <summary>
		/// <para>
		/// For domain-based DFS namespaces, this member specifies the size of the corresponding Active Directory data blob, in bytes.
		/// For stand-alone DFS namespaces, this member specifies the size of the metadata stored in the registry, including the key
		/// names and value names as well as the specific data items associated with them.
		/// </para>
		/// <para>This member is valid for DFS roots only.</para>
		/// </summary>
		public uint MetadataSize;

		/// <summary>Specifies the number of targets for the DFS root or link.</summary>
		public uint NumberOfStorages;
	}

	/// <summary>
	/// Contains the DFS metadata version and capabilities of an existing DFS namespace. This structure is only for use with the
	/// NetDfsGetInfo function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_50 typedef struct _DFS_INFO_50 { ULONG
	// NamespaceMajorVersion; ULONG NamespaceMinorVersion; ULONGLONG NamespaceCapabilities; } DFS_INFO_50, *PDFS_INFO_50, *LPDFS_INFO_50;
	[PInvokeData("lmdfs.h", MSDNShortId = "1af2866c-fe83-43fc-b4cc-9976157fb269")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_50
	{
		/// <summary>The major version of the DFS metadata.</summary>
		public uint NamespaceMajorVersion;

		/// <summary>The minor version of the DFS metadata.</summary>
		public uint NamespaceMinorVersion;

		/// <summary>
		/// <para>Specifies a set of flags that describe specific capabilities of a DFS namespace.</para>
		/// <para>DFS_NAMESPACE_CAPABILITY_ABDE (0x0000000000000001)</para>
		/// <para>
		/// The DFS namespace supports associating a security descriptor with a DFS link for Access-Based Directory Enumeration (ABDE) purposes.
		/// </para>
		/// </summary>
		public DfsCapabilities NamespaceCapabilities;
	}

	/// <summary>
	/// <para>
	/// Contains information about a Distributed File System (DFS) root or link. This structure contains the name, status, <c>GUID</c>,
	/// time-out, namespace/root/link properties, metadata size, number of targets, and information about each target of the root or
	/// link. This structure is only for use with the NetDfsEnum, NetDfsGetClientInfo, and NetDfsGetInfo functions.
	/// </para>
	/// <para>To obtain information about the DFS namespace without target information, use DFS_INFO_5 instead.</para>
	/// </summary>
	/// <remarks>For more information about how server target priority is determined, see DFS Server Target Prioritization.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_6 typedef struct _DFS_INFO_6 { LPWSTR EntryPath;
	// LPWSTR Comment; DWORD State; ULONG Timeout; GUID Guid; ULONG PropertyFlags; ULONG MetadataSize; DWORD NumberOfStorages; #if ...
	// LPDFS_STORAGE_INFO_1 Storage; #else LPDFS_STORAGE_INFO_1 Storage; #endif } DFS_INFO_6, *PDFS_INFO_6, *LPDFS_INFO_6;
	[PInvokeData("lmdfs.h", MSDNShortId = "96a9c5eb-f79f-4577-b320-ebacff84fcc4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_6
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;

		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. The <c>DFS_VOLUME_FLAVORS</c> bitmask (0x00000300) must be used to extract the DFS
		/// namespace flavor, and the <c>DFS_VOLUME_STATES</c> bitmask (0x0000000F) must be used to extract the DFS root or link state
		/// from this member. For an example that describes the interpretation of the flags, see the Remarks section of DFS_INFO_2.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the time-out, in seconds, of the DFS root or link.</summary>
		public uint Timeout;

		/// <summary>Specifies the <c>GUID</c> of the DFS root or link.</summary>
		public Guid Guid;

		/// <summary>
		/// <para>Specifies a set of flags describing specific properties of a DFS namespace, root, or link.</para>
		/// <para>DFS_PROPERTY_FLAG_INSITE_REFERRALS (0x00000001)</para>
		/// <para>
		/// Scope: Domain roots, stand-alone roots, and links. If this flag is set at the DFS root, it applies to all links; otherwise,
		/// the value of this flag is considered for each individual link.
		/// </para>
		/// <para>
		/// When this flag is set, a DFS referral response from a DFS server for a DFS root or link with the "INSITE" option enabled
		/// contains only those targets which are in the same site as the DFS client requesting the referral. Targets in the two global
		/// priority classes are always returned, regardless of their site location.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ROOT_SCALABILITY (0x00000002)</para>
		/// <para>Scope: The entire DFS namespace for a domain-based DFS namespace only.</para>
		/// <para>
		/// By default, a DFS root target server polls the PDS to detect changes to the DFS metadata. To prevent heavy server load on the
		/// PDC, root scalability can be enabled for the DFS namespace. Setting this flag will cause the DFS server to poll the nearest
		/// domain controller instead of the PDC for DFS metadata changes for the common namespace. Note that any changes made to the
		/// metadata must still occur on the PDC, however.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_SITE_COSTING (0x00000004)</para>
		/// <para>Scope: The entire DFS namespace for both domain-based and stand-alone DFS namespaces.</para>
		/// <para>
		/// By default, targets returned in a referral response from a DFS server to a DFS client for a DFS root or link consists of two
		/// groups: targets in the same site as the client, and targets outside the site.
		/// </para>
		/// <para>
		/// If site-costing is enabled for the Active Directory, the response can have more than two groups, with each group containing
		/// targets with the same site cost for the specific DFS client requesting the referral. The groups are ordered by increasing
		/// site cost. For more information about how site-costing is used to prioritize targets, see DFS Server Target Prioritization.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_TARGET_FAILBACK (0x00000008)</para>
		/// <para>
		/// Scope: Domain-based DFS roots, stand-alone DFS roots, and DFS links. If this flag is set at the DFS root, it applies to all
		/// links; otherwise, the value of this flag is considered for each individual link.
		/// </para>
		/// <para>
		/// When this flag is set, optimal target failback is enabled for V4 DFS clients, allowing them to fail back to an optimal target
		/// after failing over to a non-optimal one. The target failback setting is provided to the DFS client in a V4 referral response
		/// by a DFS server.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_CLUSTER_ENABLED (0x00000010)</para>
		/// <para>Scope: Stand-alone DFS roots and links only.</para>
		/// <para>
		/// The DFS root is clustered to provide high availability for storage failover. This flag cannot be set using the NetDfsSetInfo function.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ABDE (0x00000020)</para>
		/// <para>Scope: Domain-based DFS roots and stand-alone DFS roots.</para>
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace. This flag is valid only for DFS namespaces for which the <c>DFS_NAMESPACE_CAPABILITY_ABDE</c>
		/// capability flag is set. For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The <c>DFS_PROPERTY_FLAG_ABDE</c> flag is valid only on the DFS namespace root and not on root targets, links, or link
		/// targets. This flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		public DfsPropertyFlag PropertyFlags;

		/// <summary>
		/// <para>
		/// For domain-based DFS namespaces, this member specifies the size of the corresponding Active Directory data blob, in bytes.
		/// For stand-alone DFS namespaces, this field specifies the size of the metadata stored in the registry, including the key names
		/// and value names as well as the specific data items associated with them.
		/// </para>
		/// <para>This field is valid for DFS roots only.</para>
		/// </summary>
		public uint MetadataSize;

		/// <summary>
		/// Specifies the number of targets for the DFS root or link. These targets are contained in the <c>Storage</c> member of this structure.
		/// </summary>
		public uint NumberOfStorages;

		/// <summary>
		/// A pointer to an array of DFS_STORAGE_INFO_1 structures containing information about each target. The NumberOfStorages member
		/// specifies the number of structures within this storage array.
		/// </summary>
		public IntPtr Storage;
	}

	/// <summary>
	/// <para>Contains information about a DFS namespace. This structure contains the version <c>GUID</c> for the metadata for the namespace.</para>
	/// <para>This information level is available to DFS roots only.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// This structure is used to detect when the metadata of a DFS namespace has changed. It is currently supported only for
	/// domain-based DFS namespace servers.
	/// </para>
	/// <para>
	/// If a DFS namespace server does not support generation <c>GUID</c> s, the <c>GUID</c> value returned by NetDfsGetInfo contains a
	/// null <c>GUID</c> (all zeros). This structure cannot be used with NetDfsGetClientInfo.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_7 typedef struct _DFS_INFO_7 { GUID GenerationGuid;
	// } DFS_INFO_7, *PDFS_INFO_7, *LPDFS_INFO_7;
	[PInvokeData("lmdfs.h", MSDNShortId = "03bcd93d-e3ec-49aa-be6c-399922f67c28")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_7
	{
		/// <summary>The value of this <c>GUID</c> changes each time the DFS metadata is changed.</summary>
		public Guid GenerationGuid;
	}

	/// <summary>
	/// Contains the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information, and link reparse point
	/// security descriptor for a root or link. This structure is only for use with the NetDfsGetInfo and NetDfsEnum functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_8 typedef struct _DFS_INFO_8 { LPWSTR EntryPath;
	// LPWSTR Comment; DWORD State; ULONG Timeout; GUID Guid; ULONG PropertyFlags; ULONG MetadataSize; ULONG SecurityDescriptorLength;
	// #if ... PUCHAR pSecurityDescriptor; ULONG SdLengthReserved; #else PSECURITY_DESCRIPTOR pSecurityDescriptor; #endif DWORD
	// NumberOfStorages; } DFS_INFO_8, *PDFS_INFO_8, *LPDFS_INFO_8;
	[PInvokeData("lmdfs.h", MSDNShortId = "d1f1051e-fe4d-4771-9665-85d6f718b081")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_8
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;

		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. The <c>DFS_VOLUME_FLAVORS</c> bitmask (0x00000300) must be used to extract the DFS
		/// namespace flavor, and the <c>DFS_VOLUME_STATES</c> bitmask (0x0000000F) must be used to extract the DFS root or link state
		/// from this member. For an example that describes the interpretation of the flags, see the Remarks section of DFS_INFO_2.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the time-out, in seconds, of the DFS root or link.</summary>
		public uint Timeout;

		/// <summary>Specifies the <c>GUID</c> of the DFS root or link.</summary>
		public Guid Guid;

		/// <summary>
		/// <para>Specifies a set of flags that describe specific properties of a DFS namespace, root, or link.</para>
		/// <para>DFS_PROPERTY_FLAG_INSITE_REFERRALS (0x00000001)</para>
		/// <para>
		/// Scope: Domain roots, stand-alone roots, and links. If this flag is set at the DFS root, it applies to all links; otherwise,
		/// the value of this flag is considered for each individual link.
		/// </para>
		/// <para>
		/// When this flag is set, a DFS referral response from a DFS server for a DFS root or link with the "INSITE" option enabled
		/// contains only those targets which are in the same site as the DFS client requesting the referral. Targets in the two global
		/// priority classes are always returned, regardless of their site location.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ROOT_SCALABILITY (0x00000002)</para>
		/// <para>Scope: The entire DFS namespace for a domain-based DFS namespace only.</para>
		/// <para>
		/// By default, a DFS root target server polls the PDS to detect changes to the DFS metadata. To prevent heavy server load on the
		/// PDC, root scalability can be enabled for the DFS namespace. Setting this flag will cause the DFS server to poll the nearest
		/// domain controller instead of the PDC for DFS metadata changes for the common namespace. Note that any changes made to the
		/// metadata must still occur on the PDC, however.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_SITE_COSTING (0x00000004)</para>
		/// <para>Scope: The entire DFS namespace for both domain-based and stand-alone DFS namespaces.</para>
		/// <para>
		/// By default, targets returned in a referral response from a DFS server to a DFS client for a DFS root or link consists of two
		/// groups: targets in the same site as the client, and targets outside the site.
		/// </para>
		/// <para>
		/// If site-costing is enabled for the Active Directory, the response can have more than two groups, with each group containing
		/// targets with the same site cost for the specific DFS client requesting the referral. The groups are ordered by increasing
		/// site cost. For more information about how site-costing is used to prioritize targets, see DFS Server Target Prioritization.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_TARGET_FAILBACK (0x00000008)</para>
		/// <para>
		/// Scope: Domain-based DFS roots, stand-alone DFS roots, and DFS links. If this flag is set at the DFS root, it applies to all
		/// links; otherwise, the value of this flag is considered for each individual link.
		/// </para>
		/// <para>
		/// When this flag is set, optimal target failback is enabled for V4 DFS clients, allowing them to fail back to an optimal target
		/// after failing over to a non-optimal one. The target failback setting is provided to the DFS client in a V4 referral response
		/// by a DFS server.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_CLUSTER_ENABLED (0x00000010)</para>
		/// <para>Scope: Stand-alone DFS roots and links only.</para>
		/// <para>
		/// The DFS root is clustered to provide high availability for storage failover. This flag cannot be set using the NetDfsSetInfo function.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ABDE (0x00000020)</para>
		/// <para>Scope: Domain-based DFS roots and stand-alone DFS roots.</para>
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace. This flag is valid only for DFS namespaces for which the <c>DFS_NAMESPACE_CAPABILITY_ABDE</c>
		/// capability flag is set. For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The <c>DFS_PROPERTY_FLAG_ABDE</c> flag is valid only on the DFS namespace root and not on root targets, links, or link
		/// targets. This flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		public DfsPropertyFlag PropertyFlags;

		/// <summary>
		/// <para>
		/// For domain-based DFS namespaces, this member specifies the size of the corresponding Active Directory data blob, in bytes.
		/// For stand-alone DFS namespaces, this field specifies the size of the metadata stored in the registry, including the key names
		/// and value names, in addition to the specific data items associated with them.
		/// </para>
		/// <para>This field is valid for DFS roots only.</para>
		/// </summary>
		public uint MetadataSize;

		/// <summary>The length, in bytes, of the buffer that the pSecurityDescriptor field points to.</summary>
		public uint SecurityDescriptorLength;

		/// <summary>
		/// A self-relative security descriptor to be associated with a DFS link.For more information on security descriptors, see[MS -
		/// DTYP] section 2.4.6.
		/// </summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;

		/// <summary>Specifies the number of storage servers for the volume that contains the DFS root or link.</summary>
		public uint NumberOfStorages;
	}

	/// <summary>
	/// Contains the name, status, <c>GUID</c>, time-out, property flags, metadata size, DFS target information, link reparse point
	/// security descriptor, and a list of DFS targets for a root or link. This structure is only for use with the NetDfsGetInfo and
	/// NetDfsEnum functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_info_9 typedef struct _DFS_INFO_9 { LPWSTR EntryPath;
	// LPWSTR Comment; DWORD State; ULONG Timeout; GUID Guid; ULONG PropertyFlags; ULONG MetadataSize; ULONG SecurityDescriptorLength;
	// #if ... PUCHAR pSecurityDescriptor; ULONG SdLengthReserved; #else PSECURITY_DESCRIPTOR pSecurityDescriptor; #endif DWORD
	// NumberOfStorages; #if ... LPDFS_STORAGE_INFO_1 Storage; #else LPDFS_STORAGE_INFO_1 Storage; #endif } DFS_INFO_9, *PDFS_INFO_9, *LPDFS_INFO_9;
	[PInvokeData("lmdfs.h", MSDNShortId = "d09ebaa7-4ec7-4d25-8b77-fe568264e6b9")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_INFO_9
	{
		/// <summary>
		/// <para>
		/// Pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) path of a DFS root or link.
		/// </para>
		/// <para>For a link, the string can be in one of two forms. The first form is as follows:</para>
		/// <para>\ServerName&lt;i&gt;DfsName&lt;i&gt;link_path</para>
		/// <para>
		/// where ServerName is the name of the root target server that hosts the stand-alone DFS namespace; DfsName is the name of the
		/// DFS namespace; and link_path is a DFS link.
		/// </para>
		/// <para>The second form is as follows:</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname&lt;i&gt;link_path</para>
		/// <para>
		/// where DomainName is the name of the domain that hosts the domain-based DFS namespace; DomDfsname is the name of the DFS
		/// namespace; and link_path is a DFS link.
		/// </para>
		/// <para>For a root, the string can be in one of two forms:</para>
		/// <para>\ServerName&lt;i&gt;DfsName</para>
		/// <para>or</para>
		/// <para>\DomainName&lt;i&gt;DomDfsname</para>
		/// <para>where the values of the names are the same as those described previously.</para>
		/// </summary>
		public string EntryPath;

		/// <summary>Pointer to a null-terminated Unicode string that contains a comment associated with the DFS root or link.</summary>
		public string Comment;

		/// <summary>
		/// <para>
		/// Specifies a set of bit flags that describe the DFS root or link. One <c>DFS_VOLUME_STATE</c> flag is set, and one
		/// <c>DFS_VOLUME_FLAVOR</c> flag is set. The <c>DFS_VOLUME_FLAVORS</c> bitmask (0x00000300) must be used to extract the DFS
		/// namespace flavor, and the <c>DFS_VOLUME_STATES</c> bitmask (0x0000000F) must be used to extract the DFS root or link state
		/// from this member. For an example that describes the interpretation of the flags, see the Remarks section of DFS_INFO_2.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OK (0x00000001)</para>
		/// <para>The specified DFS root or link is in the normal state.</para>
		/// <para>DFS_VOLUME_STATE_INCONSISTENT (0x00000002)</para>
		/// <para>
		/// The internal DFS database is inconsistent with the specified DFS root or link. Attempts to repair the inconsistency have failed.
		/// </para>
		/// <para>DFS_VOLUME_STATE_OFFLINE (0x00000003)</para>
		/// <para>The specified DFS root or link is offline or unavailable.</para>
		/// <para>DFS_VOLUME_STATE_ONLINE (0x00000004)</para>
		/// <para>The specified DFS root or link is available.</para>
		/// <para>DFS_VOLUME_FLAVOR_STANDALONE (0x00000100)</para>
		/// <para>The system sets this flag if the root is associated with a stand-alone DFS namespace.</para>
		/// <para>DFS_VOLUME_FLAVOR_AD_BLOB (0x00000200)</para>
		/// <para>The system sets this flag if the root is associated with a domain-based DFS namespace.</para>
		/// </summary>
		public DfsState State;

		/// <summary>Specifies the time-out, in seconds, of the DFS root or link.</summary>
		public uint Timeout;

		/// <summary>Specifies the <c>GUID</c> of the DFS root or link.</summary>
		public Guid Guid;

		/// <summary>
		/// <para>Specifies a set of flags that describe specific properties of a DFS namespace, root, or link.</para>
		/// <para>DFS_PROPERTY_FLAG_INSITE_REFERRALS (0x00000001)</para>
		/// <para>
		/// Scope: Domain roots, stand-alone roots, and links. If this flag is set at the DFS root, it applies to all links; otherwise,
		/// the value of this flag is considered for each individual link.
		/// </para>
		/// <para>
		/// When this flag is set, a DFS referral response from a DFS server for a DFS root or link with the "INSITE" option enabled
		/// contains only those targets which are in the same site as the DFS client requesting the referral. Targets in the two global
		/// priority classes are always returned, regardless of their site location.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ROOT_SCALABILITY (0x00000002)</para>
		/// <para>Scope: The entire DFS namespace for a domain-based DFS namespace only.</para>
		/// <para>
		/// By default, a DFS root target server polls the PDS to detect changes to the DFS metadata. To prevent heavy server load on the
		/// PDC, root scalability can be enabled for the DFS namespace. Setting this flag will cause the DFS server to poll the nearest
		/// domain controller instead of the PDC for DFS metadata changes for the common namespace. Note that any changes made to the
		/// metadata must still occur on the PDC, however.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_SITE_COSTING (0x00000004)</para>
		/// <para>Scope: The entire DFS namespace for both domain-based and stand-alone DFS namespaces.</para>
		/// <para>
		/// By default, targets returned in a referral response from a DFS server to a DFS client for a DFS root or link consists of two
		/// groups: targets in the same site as the client, and targets outside the site.
		/// </para>
		/// <para>
		/// If site-costing is enabled for the Active Directory, the response can have more than two groups, with each group containing
		/// targets with the same site cost for the specific DFS client requesting the referral. The groups are ordered by increasing
		/// site cost. For more information about how site-costing is used to prioritize targets, see DFS Server Target Prioritization.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_TARGET_FAILBACK (0x00000008)</para>
		/// <para>
		/// Scope: Domain-based DFS roots, stand-alone DFS roots, and DFS links. If this flag is set at the DFS root, it applies to all
		/// links; otherwise, the value of this flag is considered for each individual link.
		/// </para>
		/// <para>
		/// When this flag is set, optimal target failback is enabled for V4 DFS clients, allowing them to fail back to an optimal target
		/// after failing over to a non-optimal one. The target failback setting is provided to the DFS client in a V4 referral response
		/// by a DFS server.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_CLUSTER_ENABLED (0x00000010)</para>
		/// <para>Scope: Stand-alone DFS roots and links only.</para>
		/// <para>
		/// The DFS root is clustered to provide high availability for storage failover. This flag cannot be set using the NetDfsSetInfo function.
		/// </para>
		/// <para>DFS_PROPERTY_FLAG_ABDE (0x00000020)</para>
		/// <para>Scope: Domain-based DFS roots and stand-alone DFS roots.</para>
		/// <para>
		/// When this flag is set, Access-Based Directory Enumeration (ABDE) mode support is enabled on the entire DFS root target share
		/// of the DFS namespace. This flag is valid only for DFS namespaces for which the <c>DFS_NAMESPACE_CAPABILITY_ABDE</c>
		/// capability flag is set. For more information, see DFS_INFO_50 and DFS_SUPPORTED_NAMESPACE_VERSION_INFO.
		/// </para>
		/// <para>
		/// The <c>DFS_PROPERTY_FLAG_ABDE</c> flag is valid only on the DFS namespace root and not on root targets, links, or link
		/// targets. This flag must be enabled to associate a security descriptor with a DFS link.
		/// </para>
		/// </summary>
		public DfsPropertyFlag PropertyFlags;

		/// <summary>
		/// <para>
		/// For domain-based DFS namespaces, this member specifies the size of the corresponding Active Directory data blob, in bytes.
		/// For stand-alone DFS namespaces, this field specifies the size of the metadata stored in the registry, including the key names
		/// and value names, in addition to the specific data items associated with them.
		/// </para>
		/// <para>This field is valid for DFS roots only.</para>
		/// </summary>
		public uint MetadataSize;

		/// <summary>The length, in bytes, of the buffer that the pSecurityDescriptor field points to.</summary>
		public uint SecurityDescriptorLength;

		/// <summary>
		/// A self-relative security descriptor to be associated with a DFS link.For more information on security descriptors, see[MS -
		/// DTYP] section 2.4.6.
		/// </summary>
		public PSECURITY_DESCRIPTOR pSecurityDescriptor;

		/// <summary>Specifies the number of storage servers for the volume that contains the DFS root or link.</summary>
		public uint NumberOfStorages;

		/// <summary>
		/// A pointer to an array of DFS_STORAGE_INFO_1 structures containing information about each target. The NumberOfStorages member
		/// specifies the number of structures within this storage array.
		/// </summary>
		public IntPtr Storage;
	}

	/// <summary>
	/// Contains information about a DFS root or link target in a DFS namespace or from the cache maintained by the DFS client.
	/// Information about a DFS root or link target in a DFS namespace is retrieved by calling the NetDfsGetInfo function. Information
	/// about a DFS root or link target from the cache maintained by the DFS client is retrieved by calling the NetDfsGetClientInfo function.
	/// </summary>
	/// <remarks>
	/// The DFS_INFO_3 and DFS_INFO_4 structures each contain one or more <c>DFS_STORAGE_INFO</c> structures, one for each DFS target.
	/// Only one target can be marked as the active target. It is possible that no targets will be marked active.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_storage_info typedef struct _DFS_STORAGE_INFO { ULONG
	// State; LPWSTR ServerName; LPWSTR ShareName; } DFS_STORAGE_INFO, *PDFS_STORAGE_INFO, *LPDFS_STORAGE_INFO;
	[PInvokeData("lmdfs.h", MSDNShortId = "f50f32d8-1745-4ff6-97a6-ddd6fff95955")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_STORAGE_INFO
	{
		/// <summary>
		/// <para>State of the target.</para>
		/// <para>
		/// When this structure is returned as a result of calling the NetDfsGetInfo function, this member can be one of the following values.
		/// </para>
		/// <para>DFS_STORAGE_STATE_OFFLINE (0x00000001)</para>
		/// <para>The DFS root or link target is offline.</para>
		/// <para>DFS_STORAGE_STATE_ONLINE (0x00000002)</para>
		/// <para>The DFS root or link target is online.</para>
		/// <para>
		/// When this structure is returned as a result of calling the NetDfsGetClientInfo function, the <c>DFS_STORAGE_STATE_ONLINE</c>
		/// (0x00000002) state is set by default. If the target is the active target in the DFS client cache, the following value is
		/// logically combined with the default value via the <c>OR</c> operator.
		/// </para>
		/// <para>DFS_STORAGE_STATE_ACTIVE (0x00000004)</para>
		/// <para>The DFS root or link target is the active target.</para>
		/// </summary>
		public DfsStorageState State;

		/// <summary>Pointer to a null-terminated Unicode string that specifies the DFS root target or link target server name.</summary>
		public string ServerName;

		/// <summary>Pointer to a null-terminated Unicode string that specifies the DFS root target or link target share name.</summary>
		public string ShareName;
	}

	/// <summary>
	/// Contains information about a DFS target, including the DFS target server name and share name as well as the target's state and priority.
	/// </summary>
	/// <remarks>This structure is used as the <c>Storage</c> member of the DFS_INFO_6 structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_storage_info_1 typedef struct _DFS_STORAGE_INFO_1 { ULONG
	// State; LPWSTR ServerName; LPWSTR ShareName; DFS_TARGET_PRIORITY TargetPriority; } DFS_STORAGE_INFO_1, *PDFS_STORAGE_INFO_1, *LPDFS_STORAGE_INFO_1;
	[PInvokeData("lmdfs.h", MSDNShortId = "777b9688-9e34-48dd-bc8c-df17bef396d0")]
	public struct DFS_STORAGE_INFO_1
	{
		/// <summary>Pointer to a null-terminated Unicode string that specifies the DFS root target or link target server name.</summary>
		public string ServerName;

		/// <summary>Pointer to a null-terminated Unicode string that specifies the DFS root target or link target share name.</summary>
		public string ShareName;

		/// <summary>
		/// <para>State of the target.</para>
		/// <para>
		/// When this structure is returned as a result of calling the NetDfsGetInfo function, this member can be one of the following values.
		/// </para>
		/// <para>DFS_STORAGE_STATE_OFFLINE (0x00000001)</para>
		/// <para>The DFS root or link target is offline.</para>
		/// <para>DFS_STORAGE_STATE_ONLINE (0x00000002)</para>
		/// <para>The DFS root or link target is online.</para>
		/// <para>
		/// When this structure is returned as a result of calling the NetDfsGetClientInfo function, the <c>DFS_STORAGE_STATE_ONLINE</c>
		/// (0x00000002) state is set by default. If the target is the active target in the DFS client cache, the following value is
		/// logically combined with the default value via the <c>OR</c> operator.
		/// </para>
		/// <para>DFS_STORAGE_STATE_ACTIVE (0x00000004)</para>
		/// <para>The DFS root or link target is the active target.</para>
		/// </summary>
		public DfsStorageState State;

		/// <summary>DFS_TARGET_PRIORITY structure that contains a DFS target's priority class and rank.</summary>
		public DFS_TARGET_PRIORITY TargetPriority;
	}

	/// <summary>Contains the priority class and rank of a specific DFS target.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used as the <c>TargetPriority</c> member of the DFS_INFO_104, DFS_INFO_106, and DFS_STORAGE_INFO_1 structures.
	/// There are no functions that use this structure directly.
	/// </para>
	/// <para>The order of priority classes from highest to lowest is as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>DfsGlobalHighPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsSiteCostHighPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsSiteCostNormalPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsSiteCostLowPriorityClass</c></term>
	/// </item>
	/// <item>
	/// <term><c>DfsGlobalLowPriorityClass</c></term>
	/// </item>
	/// </list>
	/// <para>
	/// Server targets are initially grouped into global high priority, normal priority, and low priority classes. The normal priority
	/// class is then subdivided, based on Active Directory site cost, into site-cost high priority, site-cost normal priority, and
	/// site-cost low priority classes.
	/// </para>
	/// <para>
	/// For example, all of the server targets with a site-cost value of 0 are first grouped into site-cost high, normal, and low
	/// priority classes. Then, all server targets with higher site costs are likewise separated into site-cost high, normal, and low
	/// priority classes. Thus, a server target with a site-cost value of 0 and a site-cost low priority class is still ranked higher
	/// than a server target with a site-cost value of 1 and site-cost high priority class.
	/// </para>
	/// <para>
	/// Note that the value for a "normal priority class" is set to 0 even though it is lower in priority than
	/// <c>DfsGlobalHighPriorityClass</c> and <c>DfsSiteCostHighPriorityClass</c>. This is the default setting for priority class.
	/// Priority rank can be used to discriminate within a priority class for added granularity.
	/// </para>
	/// <para>For more information about how server target priority is determined, see DFS Server Target Prioritization.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_target_priority typedef struct _DFS_TARGET_PRIORITY {
	// DFS_TARGET_PRIORITY_CLASS TargetPriorityClass; USHORT TargetPriorityRank; USHORT Reserved; } DFS_TARGET_PRIORITY, *PDFS_TARGET_PRIORITY;
	[PInvokeData("lmdfs.h", MSDNShortId = "b8f645ab-e3b4-4e0f-809a-57e27ab1e641")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DFS_TARGET_PRIORITY
	{
		/// <summary>DFS_TARGET_PRIORITY_CLASS enumeration value that specifies the priority class of the target.</summary>
		public DFS_TARGET_PRIORITY_CLASS TargetPriorityClass;

		/// <summary>
		/// Specifies the priority rank value of the target. The default value is 0, which indicates the highest priority rank within a
		/// priority class.
		/// </summary>
		public ushort TargetPriorityRank;

		/// <summary>This member is reserved and must be zero.</summary>
		public ushort Reserved;
	}

	/// <summary>Contains version information for a DFS namespace.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmdfs/ns-lmdfs-_dfs_supported_namespace_version_info typedef struct
	// _DFS_SUPPORTED_NAMESPACE_VERSION_INFO { ULONG DomainDfsMajorVersion; ULONG DomainDfsMinorVersion; ULONGLONG DomainDfsCapabilities;
	// ULONG StandaloneDfsMajorVersion; ULONG StandaloneDfsMinorVersion; ULONGLONG StandaloneDfsCapabilities; }
	// DFS_SUPPORTED_NAMESPACE_VERSION_INFO, *PDFS_SUPPORTED_NAMESPACE_VERSION_INFO;
	[PInvokeData("lmdfs.h", MSDNShortId = "ee75c500-70c6-4dce-9d38-36cacd695746")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public class DFS_SUPPORTED_NAMESPACE_VERSION_INFO
	{
		/// <summary>The major version of the domain-based DFS namespace.</summary>
		public uint DomainDfsMajorVersion;

		/// <summary>The domain DFS minor version</summary>
		public uint DomainDfsMinorVersion;

		/// <summary>
		/// <para>Specifies a set of flags that describe specific capabilities of a domain-based DFS namespace.</para>
		/// <para>DFS_NAMESPACE_CAPABILITY_ABDE (0x0000000000000001)</para>
		/// <para>
		/// The DFS namespace supports associating a security descriptor with a DFS link for Access-Based Directory Enumeration (ABDE) purposes.
		/// </para>
		/// </summary>
		public DfsCapabilities DomainDfsCapabilities;

		/// <summary>The major version of the stand-alone DFS namespace.</summary>
		public uint StandaloneDfsMajorVersion;

		/// <summary>The minor version of the stand-alone DFS namespace.</summary>
		public uint StandaloneDfsMinorVersion;

		/// <summary>
		/// <para>Specifies a set of flags that describe specific capabilities of a stand-alone DFS namespace.</para>
		/// <para>DFS_NAMESPACE_CAPABILITY_ABDE (0x0000000000000001)</para>
		/// <para>The DFS namespace supports associating a security descriptor with a DFS link for ABDE purposes.</para>
		/// </summary>
		public DfsCapabilities StandaloneDfsCapabilities;
	}
}