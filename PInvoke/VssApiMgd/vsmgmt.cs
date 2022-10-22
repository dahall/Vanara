using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Collections;

namespace Vanara.PInvoke.VssApi
{
	/// <summary>
	/// The <c>VSS_MGMT_OBJECT_TYPE</c> enumeration type is a discriminant for the VSS_MGMT_OBJECT_UNION union within the
	/// VSS_MGMT_OBJECT_PROP structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/ne-vsmgmt-vss_mgmt_object_type typedef enum _VSS_MGMT_OBJECT_TYPE {
	// VSS_MGMT_OBJECT_UNKNOWN, VSS_MGMT_OBJECT_VOLUME, VSS_MGMT_OBJECT_DIFF_VOLUME, VSS_MGMT_OBJECT_DIFF_AREA } VSS_MGMT_OBJECT_TYPE, *PVSS_MGMT_OBJECT_TYPE;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NE:vsmgmt._VSS_MGMT_OBJECT_TYPE")]
	public enum VSS_MGMT_OBJECT_TYPE
	{
		/// <summary>The object type is unknown.</summary>
		VSS_MGMT_OBJECT_UNKNOWN = 0,

		/// <summary>The object is a volume to be shadow copied.</summary>
		VSS_MGMT_OBJECT_VOLUME,

		/// <summary>The object is a volume to hold a shadow copy storage area.</summary>
		VSS_MGMT_OBJECT_DIFF_VOLUME,

		/// <summary>The object is an association between a volume to be shadow copied and a volume to hold the shadow copy storage area.</summary>
		VSS_MGMT_OBJECT_DIFF_AREA,
	}

	/// <summary>
	/// Defines the set of shadow copy protection faults. A shadow copy protection fault occurs when the VSS service is unable to perform a
	/// copy-on-write operation to the shadow copy storage area (also called the diff area).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/ne-vsmgmt-vss_protection_fault typedef enum _VSS_PROTECTION_FAULT {
	// VSS_PROTECTION_FAULT_NONE, VSS_PROTECTION_FAULT_DIFF_AREA_MISSING, VSS_PROTECTION_FAULT_IO_FAILURE_DURING_ONLINE,
	// VSS_PROTECTION_FAULT_META_DATA_CORRUPTION, VSS_PROTECTION_FAULT_MEMORY_ALLOCATION_FAILURE,
	// VSS_PROTECTION_FAULT_MAPPED_MEMORY_FAILURE, VSS_PROTECTION_FAULT_COW_READ_FAILURE, VSS_PROTECTION_FAULT_COW_WRITE_FAILURE,
	// VSS_PROTECTION_FAULT_DIFF_AREA_FULL, VSS_PROTECTION_FAULT_GROW_TOO_SLOW, VSS_PROTECTION_FAULT_GROW_FAILED,
	// VSS_PROTECTION_FAULT_DESTROY_ALL_SNAPSHOTS, VSS_PROTECTION_FAULT_FILE_SYSTEM_FAILURE, VSS_PROTECTION_FAULT_IO_FAILURE,
	// VSS_PROTECTION_FAULT_DIFF_AREA_REMOVED, VSS_PROTECTION_FAULT_EXTERNAL_WRITER_TO_DIFF_AREA,
	// VSS_PROTECTION_FAULT_MOUNT_DURING_CLUSTER_OFFLINE } VSS_PROTECTION_FAULT, *PVSS_PROTECTION_FAULT;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NE:vsmgmt._VSS_PROTECTION_FAULT")]
	public enum VSS_PROTECTION_FAULT
	{
		/// <summary>No shadow copy protection fault has occurred.</summary>
		VSS_PROTECTION_FAULT_NONE = 0,

		/// <summary>
		/// The volume that contains the shadow copy storage area could not be found. Usually this fault means that the volume has not yet
		/// arrived in the system.
		/// </summary>
		VSS_PROTECTION_FAULT_DIFF_AREA_MISSING,

		/// <summary>The volume that contains the shadow copy storage area could not be brought online because an I/O failure occurred.</summary>
		VSS_PROTECTION_FAULT_IO_FAILURE_DURING_ONLINE,

		/// <summary>The shadow copy metadata for the shadow copy storage area has been corrupted.</summary>
		VSS_PROTECTION_FAULT_META_DATA_CORRUPTION,

		/// <summary>
		/// A memory allocation failure occurred. This could be caused by a temporary low-memory condition that does not happen again after
		/// you clear the fault and restart the shadow copy operation.
		/// </summary>
		VSS_PROTECTION_FAULT_MEMORY_ALLOCATION_FAILURE,

		/// <summary>
		/// A memory mapping failure occurred. This fault could mean that the page file is too small, or it could be caused by a low-memory condition.
		/// </summary>
		VSS_PROTECTION_FAULT_MAPPED_MEMORY_FAILURE,

		/// <summary>
		/// A read failure occurred during the copy-on-write operation when data was being copied from the live volume to the shadow copy
		/// storage area volume.
		/// </summary>
		VSS_PROTECTION_FAULT_COW_READ_FAILURE,

		/// <summary>
		/// A read or write failure occurred during the copy-on-write operation when data was being copied from the live volume to the
		/// shadow copy storage area volume. One possible reason is that the shadow copy storage area volume has been removed from the system.
		/// </summary>
		VSS_PROTECTION_FAULT_COW_WRITE_FAILURE,

		/// <summary>
		/// <para>
		/// This failure means that either the shadow copy storage area is full or the shadow copy storage area volume is full. After
		/// clearing the protection fault, you can do one of the following:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Delete unused shadow copy storage areas by calling the IVssDifferentialSoftwareSnapshotMgmt3::DeleteUnusedDiffAreas method.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Increase the shadow copy storage area maximum size for the volume by calling the
		/// IVssDifferentialSoftwareSnapshotMgmt::ChangeDiffAreaMaximumSize method or the
		/// IVssDifferentialSoftwareSnapshotMgmt2::ChangeDiffAreaMaximumSizeEx method.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		VSS_PROTECTION_FAULT_DIFF_AREA_FULL,

		/// <summary>
		/// The size of the shadow copy storage area could not be increased because there was no longer enough space on the shadow copy
		/// storage area volume.
		/// </summary>
		VSS_PROTECTION_FAULT_GROW_TOO_SLOW,

		/// <summary>The size of the shadow copy storage area could not be increased.</summary>
		VSS_PROTECTION_FAULT_GROW_FAILED,

		/// <summary>An unexpected error occurred.</summary>
		VSS_PROTECTION_FAULT_DESTROY_ALL_SNAPSHOTS,

		/// <summary>
		/// Either the shadow copy storage area files could not be opened or the shadow copy storage area volume could not be mounted
		/// because of a file system operation failure.
		/// </summary>
		VSS_PROTECTION_FAULT_FILE_SYSTEM_FAILURE,

		/// <summary>A read or write failure occurred on the shadow copy storage area volume.</summary>
		VSS_PROTECTION_FAULT_IO_FAILURE,

		/// <summary>The shadow copy storage area volume was removed from the system or could not be accessed for some other reason.</summary>
		VSS_PROTECTION_FAULT_DIFF_AREA_REMOVED,

		/// <summary>Another application attempted to write to the shadow copy storage area.</summary>
		VSS_PROTECTION_FAULT_EXTERNAL_WRITER_TO_DIFF_AREA,

		/// <summary/>
		VSS_PROTECTION_FAULT_MOUNT_DURING_CLUSTER_OFFLINE,
	}

	/// <summary>Defines the set of volume shadow copy protection levels.</summary>
	/// <remarks>
	/// When a volume is in shadow copy protection mode, requesters must set shadow copy storage area (diff area) associations using the
	/// IVssDifferentialSoftwareSnapshotMgmt::AddDiffArea method.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/VsMgmt/ne-vsmgmt-vss_protection_level typedef enum _VSS_PROTECTION_LEVEL {
	// VSS_PROTECTION_LEVEL_ORIGINAL_VOLUME, VSS_PROTECTION_LEVEL_SNAPSHOT } VSS_PROTECTION_LEVEL, *PVSS_PROTECTION_LEVEL;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NE:vsmgmt._VSS_PROTECTION_LEVEL")]
	public enum VSS_PROTECTION_LEVEL
	{
		/// <summary>
		/// <para>
		/// Specifies that I/O to the original volume must be maintained at the expense of shadow copies. This is the default protection
		/// level. Shadow copies might be deleted if both of the following conditions occur:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>A write to the original volume occurs.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The integrity of the shadow copy cannot be maintained for some reason, such as a failure to write to the shadow copy storage
		/// area or a failure to allocate sufficient memory.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		VSS_PROTECTION_LEVEL_ORIGINAL_VOLUME = 0,

		/// <summary>
		/// <para>
		/// Specifies that shadow copies must be maintained at the expense of I/O to the original volume. This protection level is called
		/// "shadow copy protection mode." All I/O to the original volume will fail if both of the following conditions occur:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>A write to the original volume occurs.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The corresponding write to the shadow copy storage area cannot be completed for some reason, such as a failure to write to the
		/// shadow copy storage area or a failure to allocate sufficient memory.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		VSS_PROTECTION_LEVEL_SNAPSHOT,
	}

	/// <summary>
	/// The <c>IVssDifferentialSoftwareSnapshotMgmt</c> interface contains methods that allow applications to query and manage shadow copy
	/// storage areas generated by the system shadow copy provider.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nn-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt
	[PInvokeData("vsmgmt.h", MSDNShortId = "NN:vsmgmt.IVssDifferentialSoftwareSnapshotMgmt")]
	[ComImport, Guid("214A0F28-B737-4026-B847-4F9E37D79529"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssDifferentialSoftwareSnapshotMgmt
	{
		/// <summary>
		/// The <c>AddDiffArea</c> method adds a shadow copy storage area association for the specified volume. If the association is not
		/// supported, an error code will be returned.
		/// </summary>
		/// <param name="pwszVolumeName">
		/// <para>
		/// The name of the volume that will be the source of shadow copies. This volume is associated with a shadow copy storage area on
		/// the pwszDiffAreaVolumeName volume.
		/// </para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwszDiffAreaVolumeName">
		/// <para>The name of the volume that will contain the shadow copy storage area to be associated with the pwszVolumeName volume.</para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="llMaximumDiffSpace">
		/// <para>
		/// The maximum size, in bytes, of the shadow copy storage area on the volume. This value must be at least 320 MB, up to the
		/// system-wide limit. If this value is –1, the maximum size is unlimited.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003:</c> Prior to Windows Server 2003 with SP1, the shadow copy storage area size was fixed at 100 MB.
		/// </para>
		/// </param>
		/// <remarks>
		/// <para>
		/// A shadow copy storage area association cannot be created if any shadow copies already exist for the pwszVolumeName volume or if
		/// there is already a shadow copy storage area association for that volume.
		/// </para>
		/// <para>
		/// The shadow copy storage area for a virtual hard disk (VHD) source volume must reside on the same volume. Likewise, a shadow copy
		/// storage area can only be created on a VHD volume if the source volume is the same for both volumes.
		/// </para>
		/// <para><c>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> VHDs are not supported.</para>
		/// <para>
		/// To change the size of a shadow copy storage area, use the IVssDifferentialSoftwareSnapshotMgmt::ChangeDiffAreaMaximumSize or
		/// IVssDifferentialSoftwareSnapshotMgmt2::ChangeDiffAreaMaximumSizeEx method. You can delete a shadow copy storage area by changing
		/// its size to zero.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt-adddiffarea HRESULT
		// AddDiffArea( [in] VSS_PWSZ pwszVolumeName, [in] VSS_PWSZ pwszDiffAreaVolumeName, [in] LONGLONG llMaximumDiffSpace );
		void AddDiffArea([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName,
			 [MarshalAs(UnmanagedType.LPWStr)] string pwszDiffAreaVolumeName,
			 long llMaximumDiffSpace);

		/// <summary>
		/// The <c>ChangeDiffAreaMaximumSize</c> method updates the shadow copy storage area maximum size for a certain volume. This may not
		/// have an immediate effect.
		/// </summary>
		/// <param name="pwszVolumeName">
		/// <para>
		/// Name of the volume that is the source of shadow copies. This volume is associated with a shadow copy storage area on the
		/// pwszDiffAreaVolumeName volume.
		/// </para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwszDiffAreaVolumeName">
		/// <para>Name of the volume that contains the shadow copy storage area associated with the pwszVolumeName volume.</para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="llMaximumDiffSpace">
		/// Specifies the maximum size, in bytes, for the shadow copy storage area to use for the volume. If this value is zero, the shadow
		/// copy storage area will be deleted. If this value is –1, the maximum size is unlimited.
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>ChangeDiffAreaMaximumSize</c> method makes the shadow copy storage area explicit, which means that it is not deleted
		/// automatically when all shadow copies are deleted.
		/// </para>
		/// <para>If the shadow copy storage area does not exist, this method creates it.</para>
		/// <para>
		/// <c>Windows Server 2008, Windows Vista and Windows Server 2003:</c> If the shadow copy storage area does not exist, this method
		/// does not create it.
		/// </para>
		/// <para>To create a shadow copy storage area, use the IVssDifferentialSoftwareSnapshotMgmt::AddDiffArea method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt-changediffareamaximumsize
		// HRESULT ChangeDiffAreaMaximumSize( [in] VSS_PWSZ pwszVolumeName, [in] VSS_PWSZ pwszDiffAreaVolumeName, [in] LONGLONG
		// llMaximumDiffSpace );
		void ChangeDiffAreaMaximumSize([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName,
			[MarshalAs(UnmanagedType.LPWStr)] string pwszDiffAreaVolumeName, long llMaximumDiffSpace);

		/// <summary>
		/// The <c>QueryVolumesSupportedForDiffAreas</c> method queries volumes that support shadow copy storage areas (including volumes
		/// with disabled shadow copy storage areas).
		/// </summary>
		/// <param name="pwszOriginalVolumeName">
		/// <para>
		/// Name of the original volume that is the source of the shadow copies. The name of the volume must be in one of the following
		/// formats and must include a trailing backslash (\):
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// The address of an IVssEnumMgmtObject interface pointer, which is initialized on return. Callers must release the interface.
		/// </returns>
		/// <remarks>
		/// The returned IVssEnumMgmtObject enumerator object will contain VSS_DIFF_VOLUME_PROP structures inside the VSS_MGMT_OBJECT_UNION
		/// union inside the VSS_MGMT_OBJECT_PROP structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt-queryvolumessupportedfordiffareas
		// HRESULT QueryVolumesSupportedForDiffAreas( [in] VSS_PWSZ pwszOriginalVolumeName, [out] IVssEnumMgmtObject **ppEnum );
		IVssEnumMgmtObject QueryVolumesSupportedForDiffAreas([MarshalAs(UnmanagedType.LPWStr)] string pwszOriginalVolumeName);

		/// <summary>The <c>QueryDiffAreasForVolume</c> method queries shadow copy storage areas in use by the volume.</summary>
		/// <param name="pwszVolumeName">
		/// <para>Name of the volume that contains shadow copy storage areas.</para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// The address of an IVssEnumMgmtObject interface pointer, which is initialized on return. Callers must release the interface.
		/// </returns>
		/// <remarks>
		/// The returned IVssEnumMgmtObject enumerator object will contain VSS_DIFF_AREA_PROP structures inside the VSS_MGMT_OBJECT_UNION
		/// union inside the VSS_MGMT_OBJECT_PROP structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt-querydiffareasforvolume
		// HRESULT QueryDiffAreasForVolume( [in] VSS_PWSZ pwszVolumeName, [out] IVssEnumMgmtObject **ppEnum );
		IVssEnumMgmtObject QueryDiffAreasForVolume([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName);

		/// <summary>The <c>QueryDiffAreasOnVolume</c> method queries shadow copy storage areas that physically reside on the given volume.</summary>
		/// <param name="pwszVolumeName">
		/// <para>Name of the volume that contains shadow copy storage areas.</para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// The address of an IVssEnumMgmtObject interface pointer, which is initialized on return. Callers must release the interface.
		/// </returns>
		/// <remarks>
		/// The returned IVssEnumMgmtObject enumerator object will contain VSS_DIFF_AREA_PROP structures inside the VSS_MGMT_OBJECT_UNION
		/// union inside the VSS_MGMT_OBJECT_PROP structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt-querydiffareasonvolume
		// HRESULT QueryDiffAreasOnVolume( [in] VSS_PWSZ pwszVolumeName, [out] IVssEnumMgmtObject **ppEnum );
		IVssEnumMgmtObject QueryDiffAreasOnVolume([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName);

		/// <summary>
		/// The <c>QueryDiffAreasForSnapshot</c> method queries shadow copy storage areas in use by the original volume associated with the
		/// input shadow copy.
		/// </summary>
		/// <param name="SnapshotId">The <c>VSS_ID</c> of a shadow copy.</param>
		/// <returns>
		/// The address of an IVssEnumMgmtObject interface pointer, which is initialized on return. Callers must release the interface.
		/// </returns>
		/// <remarks>
		/// The returned IVssEnumMgmtObject enumerator object will contain VSS_DIFF_AREA_PROP structures inside the VSS_MGMT_OBJECT_UNION
		/// union inside the VSS_MGMT_OBJECT_PROP structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt-querydiffareasforsnapshot
		// HRESULT QueryDiffAreasForSnapshot( [in] VSS_ID SnapshotId, [out] IVssEnumMgmtObject **ppEnum );
		IVssEnumMgmtObject QueryDiffAreasForSnapshot(Guid SnapshotId);
	}

	/// <summary>
	/// <para>
	/// Defines additional methods that allow applications to query and manage shadow copy storage areas generated by the system shadow copy provider.
	/// </para>
	/// <para>
	/// To obtain an instance of the <c>IVssDifferentialSoftwareSnapshotMgmt2</c> interface, call the QueryInterface method of the
	/// IVssDifferentialSoftwareSnapshotMgmt interface, and pass the <c>IID_IVssDifferentialSoftwareSnapshotMgmt2</c> constant as the
	/// interface identifier (IID) parameter.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nn-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt2
	[PInvokeData("vsmgmt.h", MSDNShortId = "NN:vsmgmt.IVssDifferentialSoftwareSnapshotMgmt2")]
	[ComImport, Guid("949d7353-675f-4275-8969-f044c6277815"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssDifferentialSoftwareSnapshotMgmt2 : IVssDifferentialSoftwareSnapshotMgmt
	{
		/// <summary>
		/// Updates the shadow copy storage area maximum size for a certain volume. This may not have an immediate effect. If the bVolatile
		/// parameter is <c>FALSE</c>, the change continues even if the computer is rebooted.
		/// </summary>
		/// <param name="pwszVolumeName">
		/// <para>
		/// The name of the volume that is the source of shadow copies. This volume is associated with a shadow copy storage area on the
		/// pwszDiffAreaVolumeName volume.
		/// </para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pwszDiffAreaVolumeName">
		/// <para>The name of the volume that contains the shadow copy storage area that is associated with the pwszVolumeName volume.</para>
		/// <para>The name of the volume must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder</term>
		/// </item>
		/// <item>
		/// <term>A drive letter with, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path of the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="llMaximumDiffSpace">
		/// Specifies the maximum size, in bytes, for the shadow copy storage area to use for the volume. If this value is zero, the shadow
		/// copy storage area will be deleted. If this value is –1, the maximum size is unlimited.
		/// </param>
		/// <param name="bVolatile">
		/// <para>
		/// TRUE to indicate that the effect of calling the <c>ChangeDiffAreaMaximumSizeEx</c> method should not continue if the computer is
		/// rebooted; otherwise, <c>FALSE</c>.
		/// </para>
		/// <para>The default value is <c>FALSE</c>.</para>
		/// <para>If the llMaximumDiffSpace parameter is zero, the bVolatile parameter must be <c>FALSE</c>.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// The <c>ChangeDiffAreaMaximumSizeEx</c> method is identical to the
		/// IVssDifferentialSoftwareSnapshotMgmt::ChangeDiffAreaMaximumSize method except for the bVolatile parameter.
		/// </para>
		/// <para>
		/// Calling the <c>ChangeDiffAreaMaximumSizeEx</c> method with the bVolatile parameter set to <c>FALSE</c> is the same as calling
		/// the ChangeDiffAreaMaximumSize method.
		/// </para>
		/// <para>
		/// <c>ChangeDiffAreaMaximumSizeEx</c> makes the shadow copy storage area explicit, which means that it is not deleted automatically
		/// when all shadow copies are deleted.
		/// </para>
		/// <para>If the shadow copy storage area does not exist, this method creates it.</para>
		/// <para>
		/// <c>Windows Server 2008, Windows Vista and Windows Server 2003:</c> If the shadow copy storage area does not exist, this method
		/// does not create it.
		/// </para>
		/// <para>To create a shadow copy storage area, use the IVssDifferentialSoftwareSnapshotMgmt::AddDiffArea method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt2-changediffareamaximumsizeex
		// HRESULT ChangeDiffAreaMaximumSizeEx( [in] VSS_PWSZ pwszVolumeName, [in] VSS_PWSZ pwszDiffAreaVolumeName, [in] LONGLONG
		// llMaximumDiffSpace, [in] BOOL bVolatile );
		void ChangeDiffAreaMaximumSizeEx([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName,
			[MarshalAs(UnmanagedType.LPWStr)] string pwszDiffAreaVolumeName, long llMaximumDiffSpace,
			[MarshalAs(UnmanagedType.Bool)] bool bVolatile);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="pwszVolumeName"/>
		/// <param name="pwszDiffAreaVolumeName"/>
		/// <param name="pwszNewDiffAreaVolumeName"/>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt2-migratediffareas
		// HRESULT MigrateDiffAreas( [in] VSS_PWSZ pwszVolumeName, [in] VSS_PWSZ pwszDiffAreaVolumeName, [in] VSS_PWSZ
		// pwszNewDiffAreaVolumeName );
		void MigrateDiffAreas([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName,
			 [MarshalAs(UnmanagedType.LPWStr)] string pwszDiffAreaVolumeName,
			 [MarshalAs(UnmanagedType.LPWStr)] string pwszNewDiffAreaVolumeName);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="pwszVolumeName"/>
		/// <param name="pwszDiffAreaVolumeName"/>
		/// <returns></returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt2-querymigrationstatus
		// HRESULT QueryMigrationStatus( [in] VSS_PWSZ pwszVolumeName, [in] VSS_PWSZ pwszDiffAreaVolumeName, [out] IVssAsync **ppAsync );
		IVssAsync QueryMigrationStatus([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName,
			 [MarshalAs(UnmanagedType.LPWStr)] string pwszDiffAreaVolumeName);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="idSnapshot"/>
		/// <param name="priority"/>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt2-setsnapshotpriority
		// HRESULT SetSnapshotPriority( [in] VSS_ID idSnapshot, [in] BYTE priority );
		void SetSnapshotPriority(Guid idSnapshot, byte priority);
	}

	/// <summary>
	/// <para>Defines methods that allow applications to use the shadow copy protection feature of VSS.</para>
	/// <para>
	/// To obtain an instance of the <c>IVssDifferentialSoftwareSnapshotMgmt3</c> interface, call the QueryInterface method of the
	/// IVssDifferentialSoftwareSnapshotMgmt interface and pass the <c>IID_IVssDifferentialSoftwareSnapshotMgmt3</c> constant as the
	/// interface identifier (IID) parameter.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// An application with administrator privilege can use the SetVolumeProtectLevel method to specify a shadow copy protection level for a
	/// volume and the separate volume that contains its shadow copy storage area. The same protection level should be set for both volumes.
	/// The possible protection levels are defined by the VSS_PROTECTION_LEVEL enumeration.
	/// </para>
	/// <para>
	/// When a volume protection fault occurs, the application must call the GetVolumeProtectLevel method for the volume to identify the
	/// cause of the fault.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nn-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt3
	[PInvokeData("vsmgmt.h", MSDNShortId = "NN:vsmgmt.IVssDifferentialSoftwareSnapshotMgmt3")]
	[ComImport, Guid("383f7e71-a4c5-401f-b27f-f826289f8458"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssDifferentialSoftwareSnapshotMgmt3 : IVssDifferentialSoftwareSnapshotMgmt2
	{
		/// <summary>Sets the shadow copy protection level for an original volume or a shadow copy storage area volume.</summary>
		/// <param name="pwszVolumeName">
		/// <para>The name of the volume. This parameter is required and cannot be <c>NULL</c>.</para>
		/// <para>The name must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path in the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="protectionLevel">A value from the VSS_PROTECTION_LEVEL enumeration that specifies the shadow copy protection level.</param>
		/// <remarks>
		/// <para>
		/// The <c>SetVolumeProtectLevel</c> method checks the current shadow copy protection level of the volume. If the volume is in a
		/// faulted state and VSS_PROTECTION_LEVEL_ORIGINAL_VOLUME is specified for the protectionLevel parameter,
		/// <c>SetVolumeProtectLevel</c> dismounts the volume before setting the protection level.
		/// </para>
		/// <para>
		/// If the current protection level of the volume is the same as the value of the protectionLevel parameter,
		/// <c>SetVolumeProtectLevel</c> does nothing.
		/// </para>
		/// <para>
		/// If the value of the protectionLevel parameter is <c>VSS_PROTECTION_LEVEL_SNAPSHOT</c>, requesters must set shadow copy storage
		/// area (diff area) associations using the IVssDifferentialSoftwareSnapshotMgmt::AddDiffArea method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt3-setvolumeprotectlevel
		// HRESULT SetVolumeProtectLevel( [in] VSS_PWSZ pwszVolumeName, [in] VSS_PROTECTION_LEVEL protectionLevel );
		void SetVolumeProtectLevel([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName, VSS_PROTECTION_LEVEL protectionLevel);

		/// <summary>Gets the shadow copy protection level and status for the specified volume.</summary>
		/// <param name="pwszVolumeName">
		/// <para>The name of the volume. This parameter is required and cannot be <c>NULL</c>.</para>
		/// <para>The name must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path in the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// The address of a caller-allocated buffer that receives a VSS_VOLUME_PROTECTION_INFO structure containing information about the
		/// volume's shadow copy protection level.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetVolumeProtectLevel</c> method gets information about the volume's current protection level. If the volume is in a
		/// faulted state, the <c>m_protectionFault</c> member of the VSS_VOLUME_PROTECTION_INFO structure contains the current protection
		/// fault, and the <c>m_failureStatus</c> member contains the reason why the volume is in a faulted state. If the volume is not in a
		/// faulted state, the <c>m_protectionFault</c> and <c>m_failureStatus</c> members will be zero.
		/// </para>
		/// <para>
		/// If the value of the protectionLevel parameter is <c>VSS_PROTECTION_LEVEL_SNAPSHOT</c>, requesters must set shadow copy storage
		/// area (diff area) associations using the IVssDifferentialSoftwareSnapshotMgmt::AddDiffArea method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt3-getvolumeprotectlevel
		// HRESULT GetVolumeProtectLevel( [in] VSS_PWSZ pwszVolumeName, [out] VSS_VOLUME_PROTECTION_INFO *protectionLevel );
		VSS_VOLUME_PROTECTION_INFO GetVolumeProtectLevel([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName);

		/// <summary>Clears the protection fault state for the specified volume.</summary>
		/// <param name="pwszVolumeName">
		/// <para>The name of the volume. This parameter is required and cannot be <c>NULL</c>.</para>
		/// <para>The name must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path in the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// The <c>ClearVolumeProtectFault</c> method dismounts the volume and resets the volume's protection fault member to <c>FALSE</c>
		/// to allow normal I/O to continue on the volume. If the volume is not in a faulted state, this method does nothing.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt3-clearvolumeprotectfault
		// HRESULT ClearVolumeProtectFault( [in] VSS_PWSZ pwszVolumeName );
		void ClearVolumeProtectFault([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName);

		/// <summary>Deletes all shadow copy storage areas (also called diff areas) on the specified volume that are not in use.</summary>
		/// <param name="pwszDiffAreaVolumeName">
		/// <para>The name of the volume. This parameter is required and cannot be <c>NULL</c>.</para>
		/// <para>The name must be in one of the following formats and must include a trailing backslash (\):</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The path of a mounted folder, for example, Y:\MountX\</term>
		/// </item>
		/// <item>
		/// <term>A drive letter, for example, D:\</term>
		/// </item>
		/// <item>
		/// <term>A volume GUID path in the form \\?\Volume{GUID}\ (where GUID identifies the volume)</term>
		/// </item>
		/// </list>
		/// </param>
		/// <remarks>
		/// Unused shadow copy storage area files are found on storage area volumes when the associated original volume is offline due to a
		/// protection fault. In certain cases, the original volume may be permanently lost, and calling the <c>DeleteUnusedDiffAreas</c>
		/// method is the only way to recover the abandoned storage area space.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt3-deleteunuseddiffareas
		// HRESULT DeleteUnusedDiffAreas( [in] VSS_PWSZ pwszDiffAreaVolumeName );
		void DeleteUnusedDiffAreas([MarshalAs(UnmanagedType.LPWStr)] string pwszDiffAreaVolumeName);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>This method is reserved for future use.</para>
		/// </summary>
		/// <param name="idSnapshotOlder"/>
		/// <param name="idSnapshotYounger"/>
		/// <param name="pcBlockSizePerBit"/>
		/// <param name="pcBitmapLength"/>
		/// <param name="ppbBitmap"/>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssdifferentialsoftwaresnapshotmgmt3-querysnapshotdeltabitmap
		// HRESULT QuerySnapshotDeltaBitmap( [in] VSS_ID idSnapshotOlder, [in] VSS_ID idSnapshotYounger, [out] ULONG *pcBlockSizePerBit,
		// [out] ULONG *pcBitmapLength, [out] BYTE **ppbBitmap );
		void QuerySnapshotDeltaBitmap(Guid idSnapshotOlder, Guid idSnapshotYounger, out uint pcBlockSizePerBit,
			out uint pcBitmapLength, out IntPtr ppbBitmap);
	}

	/// <summary>
	/// <para>
	/// The <c>IVssEnumMgmtObject</c> interface contains methods to iterate over and perform other operations on a list of enumerated objects.
	/// </para>
	/// <para>
	/// The IVssDifferentialSoftwareSnapshotMgmt::QueryDiffAreasForSnapshot, IVssDifferentialSoftwareSnapshotMgmt::QueryDiffAreasForVolume,
	/// IVssDifferentialSoftwareSnapshotMgmt::QueryDiffAreasOnVolume, and
	/// IVssDifferentialSoftwareSnapshotMgmt::QueryVolumesSupportedForDiffAreas methods return an <c>IVssEnumMgmtObject</c> object.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nn-vsmgmt-ivssenummgmtobject
	[PInvokeData("vsmgmt.h", MSDNShortId = "NN:vsmgmt.IVssEnumMgmtObject")]
	[ComImport, Guid("01954E6B-9254-4e6e-808C-C9E05D007696"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IVssEnumMgmtObject : ICOMEnum<VSS_MGMT_OBJECT_PROP>
	{
		/// <summary>The <c>Next</c> method returns the specified number of objects from the specified list of enumerated objects.</summary>
		/// <param name="celt">The number of elements to be read from the list of enumerated objects into the rgelt buffer.</param>
		/// <param name="rgelt">
		/// The address of a caller-allocated buffer that receives celt VSS_MGMT_OBJECT_PROP structures that contain the returned objects.
		/// This parameter is required and cannot be <c>NULL</c>.
		/// </param>
		/// <param name="pceltFetched">The number of elements that were returned in the rgelt buffer.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssenummgmtobject-next HRESULT Next( [in] ULONG celt, [out]
		// VSS_MGMT_OBJECT_PROP *rgelt, [out] ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] VSS_MGMT_OBJECT_PROP[] rgelt, out uint pceltFetched);

		/// <summary>The <c>Skip</c> method skips the specified number of objects.</summary>
		/// <param name="celt">Number of elements to be skipped in the list of enumerated objects.</param>
		/// <returns>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssenummgmtobject-skip HRESULT Skip( [in] ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>The <c>Reset</c> method resets the enumerator so that IVssEnumMgmtObject starts at the first enumerated object.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssenummgmtobject-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The <c>Clone</c> method creates a copy of the specified list of enumerated elements by creating a copy of the IVssEnumMgmtObject
		/// enumerator object.
		/// </summary>
		/// <returns>
		/// Address of an IVssEnumMgmtObject interface pointer. Set the value of this parameter to <c>NULL</c> before calling this method.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivssenummgmtobject-clone HRESULT Clone( [in, out]
		// IVssEnumMgmtObject **ppenum );
		IVssEnumMgmtObject Clone();
	}

	/// <summary>
	/// The <c>IVssSnapshotMgmt</c> interface provides a method that returns an interface to further configure a shadow copy provider.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IVssSnapshotMgmt</c> interface can be invoked remotely using DCOM. The caller must be a member of the local administrators
	/// group on the remote machine.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// <code lang="cpp">
	///<![CDATA[#include "vss.h"
	///#include "vsmgmt.h"
	///
	///void main() {
	///  // software-provider id is {b5946137-7b9f-4925-af80-51abd60b20d5}
	///  const VSS_ID ProviderId = { 0xb5946137, 0x7b9f, 0x4925, { 0xaf,0x80,0x51,0xab,0xd6,0xb,0x20,0xd5 } }
	///  HRESULT hr = S_OK;
	///  IVssSnapshotMgmt* pMgmt = NULL;
	///  IVssDifferentialSoftwareSnapshotMgmt* pDiffMgmt = NULL;
	///  
	///  hr = CoCreateInstance(CLSID_VssSnapshotMgmt, NULL, CLSCTX_ALL, IID_IVssSnapshotMgmt, (void**)&(pMgmt));
	///  if (FAILED(hr))
	///  {
	///    // error handling code
	///  }
	///  hr = pMgmt->GetProviderMgmtInterface(ProviderId, IID_IVssDifferentialSoftwareSnapshotMgmt, (IUnknown**)&pDiffMgmt);
	///  if (FAILED(hr))
	///  {
	///    pMgmt->Release();
	///  }
	///  
	///  // processing code
	///  pDiffMgmt->Release();
	///  pMgmt->Release();
	///}]]>
	/// </code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nn-vsmgmt-ivsssnapshotmgmt
	[PInvokeData("vsmgmt.h", MSDNShortId = "NN:vsmgmt.IVssSnapshotMgmt")]
	[ComImport, Guid("FA7DF749-66E7-4986-A27F-E2F04AE53772"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(VssSnapshotMgmt))]
	public interface IVssSnapshotMgmt
	{
		/// <summary>The <c>GetProviderMgmtInterface</c> method returns an interface to further configure the system provider.</summary>
		/// <param name="ProviderId">
		/// This must be the system provider. The <c>VSS_ID</c> for the system provider
		/// <code>{b5946137-7b9f-4925-af80-51abd60b20d5}</code>
		/// .
		/// </param>
		/// <param name="InterfaceId">
		/// Must be <c>IID_IVssDifferentialSoftwareSnapshotMgmt</c>, which represents the IVssDifferentialSoftwareSnapshotMgmt interface.
		/// </param>
		/// <returns>Address of an interface pointer that is filled in with the returned interface pointer.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivsssnapshotmgmt-getprovidermgmtinterface HRESULT
		// GetProviderMgmtInterface( [in] VSS_ID ProviderId, [in] REFIID InterfaceId, [out] IUnknown **ppItf );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object GetProviderMgmtInterface(Guid ProviderId, in Guid InterfaceId);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>The <c>QueryVolumesSupportedForSnapshots</c> method is reserved for system use.</para>
		/// </summary>
		/// <param name="ProviderId">Reserved for system use. Do not use.</param>
		/// <param name="lContext">Reserved for system use. Do not use.</param>
		/// <returns>Reserved for system use. Do not use.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivsssnapshotmgmt-queryvolumessupportedforsnapshots HRESULT
		// QueryVolumesSupportedForSnapshots( [in] VSS_ID ProviderId, [in] LONG lContext, [out] IVssEnumMgmtObject **ppEnum );
		IVssEnumMgmtObject QueryVolumesSupportedForSnapshots(Guid ProviderId, int lContext);

		/// <summary>
		/// <para>Not supported.</para>
		/// <para>The <c>QuerySnapshotsByVolume</c> method is reserved for system use.</para>
		/// </summary>
		/// <param name="pwszVolumeName">Reserved for system use. Do not use.</param>
		/// <param name="ProviderId">Reserved for system use. Do not use.</param>
		/// <returns>Reserved for system use. Do not use.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivsssnapshotmgmt-querysnapshotsbyvolume HRESULT
		// QuerySnapshotsByVolume( [in] VSS_PWSZ pwszVolumeName, [in] VSS_ID ProviderId, [out] IVssEnumObject **ppEnum );
		IVssEnumObject QuerySnapshotsByVolume([MarshalAs(UnmanagedType.LPWStr)] string pwszVolumeName, Guid ProviderId);
	}

	/// <summary>The <c>IVssSnapshotMgmt2</c> interface provides a method to retrieve the minimum size of the shadow copy storage area.</summary>
	/// <remarks>
	/// To obtain an instance of the <c>IVssSnapshotMgmt2</c> interface, call the QueryInterface method of the IVssSnapshotMgmt interface,
	/// passing <c>IID_IVssSnapshotMgmt2</c> as the riid parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nn-vsmgmt-ivsssnapshotmgmt2
	[PInvokeData("vsmgmt.h", MSDNShortId = "NN:vsmgmt.IVssSnapshotMgmt2")]
	[ComImport, Guid("0f61ec39-fe82-45f2-a3f0-768b5d427102"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(VssSnapshotMgmt))]
	public interface IVssSnapshotMgmt2
	{
		/// <summary>Returns the current minimum size of the shadow copy storage area.</summary>
		/// <returns>A pointer to a variable that receives the minimum size, in bytes, of the shadow copy storage area.</returns>
		/// <remarks>
		/// The shadow copy storage area minimum size is a per-computer setting that is specified by the <c>MinDiffAreaFileSize</c> registry
		/// key. For more information, see the entry for <c>MinDiffAreaFileSize</c> in Registry Keys and Values for Backup and Restore.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/nf-vsmgmt-ivsssnapshotmgmt2-getmindiffareasize HRESULT
		// GetMinDiffAreaSize( [out] LONGLONG *pllMinDiffAreaSize );
		long GetMinDiffAreaSize();
	}

	/// <summary>
	/// The <c>VSS_DIFF_AREA_PROP</c> structure describes associations between volumes containing the original file data and volumes
	/// containing the shadow copy storage area (also known as the diff area).
	/// </summary>
	/// <remarks>
	/// The <c>m_llMaximumDiffSpace</c> member is passed as a parameter to the IVssDifferentialSoftwareSnapshotMgmt::AddDiffArea,
	/// IVssDifferentialSoftwareSnapshotMgmt::ChangeDiffAreaMaximumSize, and
	/// IVssDifferentialSoftwareSnapshotMgmt2::ChangeDiffAreaMaximumSizeEx methods.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/VsMgmt/ns-vsmgmt-vss_diff_area_prop typedef struct _VSS_DIFF_AREA_PROP { VSS_PWSZ
	// m_pwszVolumeName; VSS_PWSZ m_pwszDiffAreaVolumeName; LONGLONG m_llMaximumDiffSpace; LONGLONG m_llAllocatedDiffSpace; LONGLONG
	// m_llUsedDiffSpace; } VSS_DIFF_AREA_PROP, *PVSS_DIFF_AREA_PROP;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NS:vsmgmt._VSS_DIFF_AREA_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_DIFF_AREA_PROP
	{
		/// <summary>The original volume name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string m_pwszVolumeName;

		/// <summary>The shadow copy storage area volume name.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string m_pwszDiffAreaVolumeName;

		/// <summary>Maximum space used on the shadow copy storage area volume for this association.</summary>
		public long m_llMaximumDiffSpace;

		/// <summary>Allocated space on the shadow copy storage area volume by this association. This must be less than or equal to m_llMaximumDiffSpace.</summary>
		public long m_llAllocatedDiffSpace;

		/// <summary>Used space from the allocated area above. This must be less than or equal to m_llAllocatedDiffSpace.</summary>
		public long m_llUsedDiffSpace;
	}

	/// <summary>The <c>VSS_DIFF_VOLUME_PROP</c> structure describes a shadow copy storage area volume.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/ns-vsmgmt-vss_diff_volume_prop typedef struct _VSS_DIFF_VOLUME_PROP {
	// VSS_PWSZ m_pwszVolumeName; VSS_PWSZ m_pwszVolumeDisplayName; LONGLONG m_llVolumeFreeSpace; LONGLONG m_llVolumeTotalSpace; }
	// VSS_DIFF_VOLUME_PROP, *PVSS_DIFF_VOLUME_PROP;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NS:vsmgmt._VSS_DIFF_VOLUME_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_DIFF_VOLUME_PROP
	{
		/// <summary>The shadow copy storage area volume name, in <c>\\?\</c> Volume <c>{</c> GUID <c>}\</c> format.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string m_pwszVolumeName;

		/// <summary>
		/// Points to a null-terminated Unicode string that can be displayed to a user, for example C <c>:\</c>, for the shadow copy storage
		/// area volume.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string m_pwszVolumeDisplayName;

		/// <summary>Free space, in bytes, on the shadow copy storage area volume.</summary>
		public long m_llVolumeFreeSpace;

		/// <summary>Total space, in bytes, on the shadow copy storage area volume.</summary>
		public long m_llVolumeTotalSpace;
	}

	/// <summary>
	/// The <c>VSS_MGMT_OBJECT_PROP</c> structure defines the properties of a volume, shadow copy storage volume, or a shadow copy storage area.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/ns-vsmgmt-vss_mgmt_object_prop typedef struct _VSS_MGMT_OBJECT_PROP {
	// VSS_MGMT_OBJECT_TYPE Type; VSS_MGMT_OBJECT_UNION Obj; } VSS_MGMT_OBJECT_PROP, *PVSS_MGMT_OBJECT_PROP;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NS:vsmgmt._VSS_MGMT_OBJECT_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public class VSS_MGMT_OBJECT_PROP : IDisposable
	{
		/// <summary>Object type. For more information, see VSS_MGMT_OBJECT_TYPE.</summary>
		public VSS_MGMT_OBJECT_TYPE Type;

		/// <summary>
		/// <para>
		/// Management object properties: a union of VSS_VOLUME_PROP, VSS_DIFF_VOLUME_PROP, and VSS_DIFF_AREA_PROP structures. (For more
		/// information, see VSS_MGMT_OBJECT_UNION.)
		/// </para>
		/// <para>
		/// It contains information for an object of the type specified by the <c>Type</c> member. Management objects can be volumes, shadow
		/// copy storage volumes, or shadow copy storage areas.
		/// </para>
		/// </summary>
		public VSS_MGMT_OBJECT_UNION Obj;

		/// <summary>Frees the allocated memory for the strings in this structure.</summary>
		public void Dispose()
		{
			Marshal.FreeCoTaskMem((IntPtr)Obj.szOne);
			Marshal.FreeCoTaskMem((IntPtr)Obj.szTwo);
			Obj.szOne = Obj.szTwo = IntPtr.Zero;
		}
	}

	/// <summary>
	/// The VSS_MGMT_OBJECT_UNION specifies the union of object types that can be defined by the VSS_MGMT_OBJECT_PROP structure (section 2.2.3.6).
	/// </summary>
	[PInvokeData("vsmgmt.h", MSDNShortId = "NS:vsmgmt._VSS_MGMT_OBJECT_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_MGMT_OBJECT_UNION
	{
		internal InteropServices.StrPtrUni szOne;

		internal InteropServices.StrPtrUni szTwo;

		internal long lOne;

		internal long lTwo;

		internal long lThree;

		/// <summary>The structure specifies an original volume object as a VSS_VOLUME_PROP structure (section 2.2.3.7).</summary>
		public VSS_VOLUME_PROP Vol =>  new() { m_pwszVolumeName = szOne, m_pwszVolumeDisplayName = szTwo };

		/// <summary>The structure specifies a shadow copy storage volume as a VSS_DIFF_VOLUME_PROP structure.</summary>
		public VSS_DIFF_VOLUME_PROP DiffVol => new() { m_pwszVolumeName = szOne, m_pwszVolumeDisplayName = szTwo, m_llVolumeFreeSpace = lOne, m_llVolumeTotalSpace = lTwo };

		/// <summary>The structure specifies a shadow copy storage object as a VSS_DIFF_AREA_PROP.</summary>
		public VSS_DIFF_AREA_PROP DiffArea => new() { m_pwszVolumeName = szOne, m_pwszDiffAreaVolumeName = szTwo, m_llMaximumDiffSpace = lOne, m_llAllocatedDiffSpace = lTwo, m_llUsedDiffSpace = lThree };
	}

	/// <summary>The <c>VSS_VOLUME_PROP</c> structure contains the properties of a shadow copy source volume.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/ns-vsmgmt-vss_volume_prop typedef struct _VSS_VOLUME_PROP { VSS_PWSZ
	// m_pwszVolumeName; VSS_PWSZ m_pwszVolumeDisplayName; } VSS_VOLUME_PROP, *PVSS_VOLUME_PROP;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NS:vsmgmt._VSS_VOLUME_PROP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_VOLUME_PROP
	{
		/// <summary>The volume name, in \?\Volume{GUID}\ format.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string m_pwszVolumeName;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the shortest mount point that can be displayed to the user. The
		/// mount point can be a drive letter, for example, C:, or a mounted folder, for example, C:\WriterData\Archive.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string m_pwszVolumeDisplayName;
	}

	/// <summary>Contains information about a volume's shadow copy protection level.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/vsmgmt/ns-vsmgmt-vss_volume_protection_info typedef struct
	// _VSS_VOLUME_PROTECTION_INFO { VSS_PROTECTION_LEVEL m_protectionLevel; BOOL m_volumeIsOfflineForProtection; VSS_PROTECTION_FAULT
	// m_protectionFault; LONG m_failureStatus; BOOL m_volumeHasUnusedDiffArea; DWORD m_reserved; } VSS_VOLUME_PROTECTION_INFO, *PVSS_VOLUME_PROTECTION_INFO;
	[PInvokeData("vsmgmt.h", MSDNShortId = "NS:vsmgmt._VSS_VOLUME_PROTECTION_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VSS_VOLUME_PROTECTION_INFO
	{
		/// <summary>A value from the VSS_PROTECTION_LEVEL enumeration that specifies the target protection level for the volume.</summary>
		public VSS_PROTECTION_LEVEL m_protectionLevel;

		/// <summary>TRUE if the volume is offline due to a protection fault, or <c>FALSE</c> otherwise.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool m_volumeIsOfflineForProtection;

		/// <summary>
		/// A value from the VSS_PROTECTION_FAULT enumeration that describes the shadow copy protection fault that caused the volume to go offline.
		/// </summary>
		public VSS_PROTECTION_FAULT m_protectionFault;

		/// <summary>The internal failure status code.</summary>
		public int m_failureStatus;

		/// <summary>TRUE if the volume has unused shadow copy storage area files, or <c>FALSE</c> otherwise.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool m_volumeHasUnusedDiffArea;

		/// <summary>Reserved for system use.</summary>
		public uint m_reserved;
	}

	/// <summary>VSS extension methods.</summary>
	public static partial class Extensions
	{
		/// <summary>Enumerates the <see cref="VSS_MGMT_OBJECT_PROP"/> instances provided by an <see cref="IVssEnumMgmtObject"/>.</summary>
		/// <param name="emo">The <see cref="IVssEnumMgmtObject"/> instance.</param>
		/// <returns>A sequence of <see cref="VSS_MGMT_OBJECT_PROP"/> structures.</returns>
		public static IEnumerable<VSS_MGMT_OBJECT_PROP> Enumerate(this IVssEnumMgmtObject emo) =>
			new IEnumFromCom<VSS_MGMT_OBJECT_PROP>(emo.Next, emo.Reset, () => new VSS_MGMT_OBJECT_PROP());

		/// <summary>The <c>GetProviderMgmtInterface</c> method returns an interface to further configure the system provider.</summary>
		/// <param name="sm">The <see cref="IVssSnapshotMgmt"/> instance.</param>
		/// <param name="ProviderId">
		/// This must be the system provider. The <c>VSS_ID</c> for the system provider
		/// <code>{b5946137-7b9f-4925-af80-51abd60b20d5}</code>
		/// .
		/// </param>
		/// <returns>A IVssDifferentialSoftwareSnapshotMgmt interface instance.</returns>
		public static IVssDifferentialSoftwareSnapshotMgmt GetProviderMgmtInterface(this IVssSnapshotMgmt sm, Guid ProviderId) =>
			sm.GetProviderMgmtInterface<IVssDifferentialSoftwareSnapshotMgmt>(ProviderId);

		/// <summary>The <c>GetProviderMgmtInterface</c> method returns an interface to further configure the system provider.</summary>
		/// <typeparam name="T">
		/// Must be <c>IID_IVssDifferentialSoftwareSnapshotMgmt</c>, which represents the IVssDifferentialSoftwareSnapshotMgmt interface.
		/// </typeparam>
		/// <param name="sm">The <see cref="IVssSnapshotMgmt"/> instance.</param>
		/// <param name="ProviderId">
		/// This must be the system provider. The <c>VSS_ID</c> for the system provider <c>{b5946137-7b9f-4925-af80-51abd60b20d5}</c> .
		/// </param>
		/// <returns>An interface pointer that is filled in with the returned interface pointer.</returns>
		public static T GetProviderMgmtInterface<T>(this IVssSnapshotMgmt sm, Guid ProviderId) where T : class => (T)sm.GetProviderMgmtInterface(ProviderId, typeof(T).GUID);
	}

	/// <summary>CLSID_VssSnapshotMgmt</summary>
	[ComImport, Guid("0B5A2C52-3EB9-470a-96E2-6C6D4570E40F"), ClassInterface(ClassInterfaceType.None)]
	public class VssSnapshotMgmt
	{ }
}