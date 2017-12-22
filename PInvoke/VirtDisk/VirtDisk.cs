using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	/// <summary>Platform invokable enumerated types, constants and functions from VirtDisk.h</summary>
	public static partial class VirtDisk
	{
		/// <summary>The virtual storage type vendor Microsoft</summary>
		public static readonly Guid VIRTUAL_STORAGE_TYPE_VENDOR_MICROSOFT = new Guid("EC984AEC-A0F9-47e9-901F-71415A66345B");

		/// <summary>Contains flags affecting the behavior of the ApplySnapshotVhdSet function.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "mt638035")]
		[Flags]
		public enum APPLY_SNAPSHOT_VHDSET_FLAG
		{
			/// <summary>No flag specified.</summary>
			APPLY_SNAPSHOT_VHDSET_FLAG_NONE = 0x00000000,
			/// <summary>Indicates that the snapshot to be applied was created as a writeable snapshot type.</summary>
			APPLY_SNAPSHOT_VHDSET_FLAG_WRITEABLE = 0x00000001
		}

		/// <summary>Enumerates the possible versions for parameters for the ApplySnapshotVhdSet function.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum APPLY_SNAPSHOT_VHDSET_VERSION
		{
			/// <summary>Not Supported.</summary>
			APPLY_SNAPSHOT_VHDSET_VERSION_UNSPECIFIED = 0,
			/// <summary>The Version1 member structure will be used.</summary>
			APPLY_SNAPSHOT_VHDSET_VERSION_1 = 1,
		}

		/// <summary>Contains virtual disk attach request flags.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum ATTACH_VIRTUAL_DISK_FLAG
		{
			/// <summary>No flags. Use system defaults.</summary>
			ATTACH_VIRTUAL_DISK_FLAG_NONE = 0x00000000,

			/// <summary>
			/// Attach the virtual disk as read-only.
			/// <para>
			/// <c>Windows 7 and Windows Server 2008 R2:</c> This flag is not supported for opening ISO virtual disks until Windows 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY = 0x00000001,

			/// <summary>
			/// No drive letters are assigned to the disk's volumes.
			/// <para>
			/// <c>Windows 7 and Windows Server 2008 R2:</c> This flag is not supported for opening ISO virtual disks until Windows 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			ATTACH_VIRTUAL_DISK_FLAG_NO_DRIVE_LETTER = 0x00000002,

			/// <summary>
			/// Will decouple the virtual disk lifetime from that of the VirtualDiskHandle. The virtual disk will be attached until the DetachVirtualDisk
			/// function is called, even if all open handles to the virtual disk are closed.
			/// <para>
			/// <c>Windows 7 and Windows Server 2008 R2:</c> This flag is not supported for opening ISO virtual disks until Windows 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			ATTACH_VIRTUAL_DISK_FLAG_PERMANENT_LIFETIME = 0x00000004,

			/// <summary>Reserved. This flag is not supported for ISO virtual disks.</summary>
			ATTACH_VIRTUAL_DISK_FLAG_NO_LOCAL_HOST = 0x00000008,

			/// <summary>Do not assign a custom security descriptor to the disk; use the system default.</summary>
			ATTACH_VIRTUAL_DISK_FLAG_NO_SECURITY_DESCRIPTOR = 0x00000010,
		}

		/// <summary>Contains the version of the virtual hard disk (VHD) ATTACH_VIRTUAL_DISK_PARAMETERS structure to use in calls to VHD functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum ATTACH_VIRTUAL_DISK_VERSION
		{
			/// <summary>Unspecified version.</summary>
			ATTACH_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,

			/// <summary>Version 1.</summary>
			ATTACH_VIRTUAL_DISK_VERSION_1 = 1
		}

		/// <summary>Contains virtual disk compact request flags.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323656")]
		[Flags]
		public enum COMPACT_VIRTUAL_DISK_FLAG
		{
			/// <summary>No flags are specified.</summary>
			COMPACT_VIRTUAL_DISK_FLAG_NONE = 0,
			/// <summary></summary>
			COMPACT_VIRTUAL_DISK_FLAG_NO_ZERO_SCAN = 1,
			/// <summary></summary>
			COMPACT_VIRTUAL_DISK_FLAG_NO_BLOCK_MOVES = 2,
		}

		/// <summary>Contains the version of the virtual hard disk (VHD) COMPACT_VIRTUAL_DISK_PARAMETERS structure to use in calls to VHD functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum COMPACT_VIRTUAL_DISK_VERSION
		{
			/// <summary>Unspecified.</summary>
			COMPACT_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,

			/// <summary>Version 1.</summary>
			COMPACT_VIRTUAL_DISK_VERSION_1 = 1
		}

		/// <summary>Contains virtual disk creation flags.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum CREATE_VIRTUAL_DISK_FLAG
		{
			/// <summary>No special creation conditions; system defaults are used.</summary>
			CREATE_VIRTUAL_DISK_FLAG_NONE = 0x0,

			/// <summary>Pre-allocate all physical space necessary for the virtual size of the disk (e.g. a fixed VHD).</summary>
			CREATE_VIRTUAL_DISK_FLAG_FULL_PHYSICAL_ALLOCATION = 0x1,

			/// <summary>
			/// Take ownership of the source disk during create from source disk, to insure the source disk does not change during the create operation. The
			/// source disk must also already be offline or read-only (or both). Ownership is released when create is done. This also has a side-effect of
			/// disallowing concurrent create from same source disk. Create will fail if ownership cannot be obtained or if the source disk is not already
			/// offline or read-only. This flag is optional, but highly recommended for creates from source disk. No effect for other types of create (no effect
			/// for create from source VHD; no effect for create without SourcePath).
			/// </summary>
			CREATE_VIRTUAL_DISK_FLAG_PREVENT_WRITES_TO_SOURCE_DISK = 0x2,

			/// <summary>
			/// Do not copy initial virtual disk metadata or block states from the parent VHD; this is useful if the parent VHD is a stand-in file and the real
			/// parent will be explicitly set later.
			/// </summary>
			CREATE_VIRTUAL_DISK_FLAG_DO_NOT_COPY_METADATA_FROM_PARENT = 0x4,

			/// <summary>Create the backing storage disk.</summary>
			CREATE_VIRTUAL_DISK_FLAG_CREATE_BACKING_STORAGE = 0x8,

			/// <summary>
			/// If set, the SourceLimitPath is an change tracking ID, and all data that has changed since that change tracking ID will be copied from the source.
			/// If clear, the SourceLimitPath is a VHD file path in the source VHD's chain, and all data that is present in the children of that VHD in the chain
			/// will be copied from the source.
			/// </summary>
			CREATE_VIRTUAL_DISK_FLAG_USE_CHANGE_TRACKING_SOURCE_LIMIT = 0x10,

			/// <summary>
			/// If set and the parent VHD has change tracking enabled, the child will have change tracking enabled and will recognize all change tracking IDs
			/// that currently exist in the parent. If clear or if the parent VHD does not have change tracking available, then change tracking will not be
			/// enabled in the new VHD.
			/// </summary>
			CREATE_VIRTUAL_DISK_FLAG_PRESERVE_PARENT_CHANGE_TRACKING_STATE = 0x20,

			/// <summary>
			/// When creating a VHD Set from source, don't copy the data in the original backing store, but instead use the file as is. If this flag is not
			/// specified and a source file is passed to CreateVirtualDisk for a VHDSet file, the data in the source file is copied. If this flag is set the data
			/// is moved. The name of the file may change.
			/// </summary>
			CREATE_VIRTUAL_DISK_FLAG_VHD_SET_USE_ORIGINAL_BACKING_STORAGE = 0x40,

			/// <summary>
			/// When creating a fixed virtual disk, take advantage of an underlying sparse file. Only supported on file systems that support sparse VDLs.
			/// </summary>
			CREATE_VIRTUAL_DISK_FLAG_SPARSE_FILE = 0x80,
		}

		/// <summary>Contains the version of the virtual hard disk (VHD) CREATE_VIRTUAL_DISK_PARAMETERS structure to use in calls to VHD functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum CREATE_VIRTUAL_DISK_VERSION
		{
			/// <summary>Unsupported</summary>
			CREATE_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,
			/// <summary></summary>
			CREATE_VIRTUAL_DISK_VERSION_1 = 1,
			/// <summary></summary>
			CREATE_VIRTUAL_DISK_VERSION_2 = 2,
			/// <summary></summary>
			CREATE_VIRTUAL_DISK_VERSION_3 = 3,
		}

		/// <summary>Contains flags affecting the behavior of the DeleteSnapshotVhdSet function.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum DELETE_SNAPSHOT_VHDSET_FLAG
		{
			/// <summary>No flag specified.</summary>
			DELETE_SNAPSHOT_VHDSET_FLAG_NONE = 0x00000000,
			/// <summary>A reference point should be persisted in the VHD Set after the snapshot is deleted.</summary>
			DELETE_SNAPSHOT_VHDSET_FLAG_PERSIST_RCT = 0x00000001
		}

		/// <summary>Contains the version of the DELETE_SNAPHSOT_VHDSET_PARAMETERS structure to use in calls to virtual disk functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum DELETE_SNAPSHOT_VHDSET_VERSION
		{
			/// <summary>Not supported.</summary>
			DELETE_SNAPSHOT_VHDSET_VERSION_UNSPECIFIED = 0x00000000,
			/// <summary>The Version1 member structure will be used.</summary>
			DELETE_SNAPSHOT_VHDSET_VERSION_1 = 0x00000001
		}

		/// <summary>Contains virtual disk dependency information flags.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum DEPENDENT_DISK_FLAG
		{
			/// <summary>No flags specified. Use system defaults.</summary>
			DEPENDENT_DISK_FLAG_NONE = 0x00000000,

			/// <summary>Multiple files backing the virtual disk.</summary>
			DEPENDENT_DISK_FLAG_MULT_BACKING_FILES = 0x00000001,

			/// <summary>Fully allocated virtual disk.</summary>
			DEPENDENT_DISK_FLAG_FULLY_ALLOCATED = 0x00000002,

			/// <summary>Read-only virtual disk.</summary>
			DEPENDENT_DISK_FLAG_READ_ONLY = 0x00000004,

			/// <summary>The backing file of the virtual disk is not on a local physical disk.</summary>
			DEPENDENT_DISK_FLAG_REMOTE = 0x00000008,

			/// <summary>Reserved.</summary>
			DEPENDENT_DISK_FLAG_SYSTEM_VOLUME = 0x00000010,

			/// <summary>The backing file of the virtual disk is on the system volume.</summary>
			DEPENDENT_DISK_FLAG_SYSTEM_VOLUME_PARENT = 0x00000020,

			/// <summary>The backing file of the virtual disk is on a removable physical disk.</summary>
			DEPENDENT_DISK_FLAG_REMOVABLE = 0x00000040,

			/// <summary>Drive letters are not automatically assigned to the volumes on the virtual disk.</summary>
			DEPENDENT_DISK_FLAG_NO_DRIVE_LETTER = 0x00000080,

			/// <summary>The virtual disk is a parent of a differencing chain.</summary>
			DEPENDENT_DISK_FLAG_PARENT = 0x00000100,

			/// <summary>The virtual disk is not surfaced on (attached to) the local host. For example, it is attached to a guest virtual machine.</summary>
			DEPENDENT_DISK_FLAG_NO_HOST_DISK = 0x00000200,

			/// <summary>The lifetime of the virtual disk is not tied to any application or process.</summary>
			DEPENDENT_DISK_FLAG_PERMANENT_LIFETIME = 0x00000400
		}

		/// <summary>Contains virtual disk detach request flags.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum DETACH_VIRTUAL_DISK_FLAG
		{
			/// <summary>No flags. Use system defaults.</summary>
			DETACH_VIRTUAL_DISK_FLAG_NONE = 0
		}

		/// <summary>Contains virtual hard disk (VHD) expand request flags.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum EXPAND_VIRTUAL_DISK_FLAG
		{
			/// <summary>No flags. Use system defaults.</summary>
			EXPAND_VIRTUAL_DISK_FLAG_NONE = 0x00000000
		}

		/// <summary>Contains the version of the virtual hard disk (VHD) EXPAND_VIRTUAL_DISK_PARAMETERS structure to use in calls to VHD functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum EXPAND_VIRTUAL_DISK_VERSION
		{
			/// <summary>Unspecified.</summary>
			EXPAND_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,

			/// <summary>Version 1.</summary>
			EXPAND_VIRTUAL_DISK_VERSION_1 = 1
		}

		/// <summary>Contains virtual hard disk (VHD) storage dependency request flags.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum GET_STORAGE_DEPENDENCY_FLAG
		{
			/// <summary>No flags specified.</summary>
			GET_STORAGE_DEPENDENCY_FLAG_NONE = 0x00000000,

			/// <summary>Return information for volumes or disks hosting the volume specified.</summary>
			GET_STORAGE_DEPENDENCY_FLAG_HOST_VOLUMES = 0x00000001,

			/// <summary>The handle provided is to a disk, not a volume or file.</summary>
			GET_STORAGE_DEPENDENCY_FLAG_DISK_HANDLE = 0x00000002
		}

		/// <summary>Contains virtual hard disk (VHD) information retrieval identifiers.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum GET_VIRTUAL_DISK_INFO_VERSION
		{
			/// <summary>Reserved. This value should not be used.</summary>
			[CorrespondingType(null)]
			GET_VIRTUAL_DISK_INFO_UNSPECIFIED = 0,

			/// <summary>Information related to the virtual disk size, including total size, physical allocation used, block size, and sector size.</summary>
			[CorrespondingType(typeof(GET_VIRTUAL_DISK_INFO_Size))]
			GET_VIRTUAL_DISK_INFO_SIZE = 1,

			/// <summary>The unique identifier. This identifier is persistently stored in the virtual disk and will not change even if the virtual disk file is copied to another file.</summary>
			[CorrespondingType(typeof(Guid))]
			GET_VIRTUAL_DISK_INFO_IDENTIFIER = 2,

			/// <summary>The paths to parent virtual disks. Valid only for differencing virtual disks.</summary>
			[CorrespondingType(typeof(GET_VIRTUAL_DISK_INFO_ParentLocation))]
			GET_VIRTUAL_DISK_INFO_PARENT_LOCATION = 3,

			/// <summary>The unique identifier of the parent virtual disk. Valid only for differencing virtual disks.</summary>
			[CorrespondingType(typeof(Guid))]
			GET_VIRTUAL_DISK_INFO_PARENT_IDENTIFIER = 4,

			/// <summary>The time stamp of the parent when the child virtual disk was created. Valid only for differencing virtual disks.</summary>
			[CorrespondingType(typeof(uint))]
			GET_VIRTUAL_DISK_INFO_PARENT_TIMESTAMP = 5,

			/// <summary>The device identifier and vendor identifier that identify the type of virtual disk.</summary>
			[CorrespondingType(typeof(VIRTUAL_STORAGE_TYPE))]
			GET_VIRTUAL_DISK_INFO_VIRTUAL_STORAGE_TYPE = 6,

			/// <summary>The type of virtual disk.</summary>
			[CorrespondingType(typeof(VIRTUAL_DISK_INFO_PROVIDER_SUBTYPE))]
			GET_VIRTUAL_DISK_INFO_PROVIDER_SUBTYPE = 7,

			/// <summary>Indicates whether the virtual disk is 4 KB aligned.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para></summary>
			[CorrespondingType(typeof(bool))]
			GET_VIRTUAL_DISK_INFO_IS_4K_ALIGNED = 8,

			/// <summary>Details about the physical disk on which the virtual disk resides.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para></summary>
			[CorrespondingType(typeof(GET_VIRTUAL_DISK_INFO_PhysicalDisk))]
			GET_VIRTUAL_DISK_INFO_PHYSICAL_DISK = 9,

			/// <summary>The physical sector size of the virtual disk.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para></summary>
			[CorrespondingType(typeof(uint))]
			GET_VIRTUAL_DISK_INFO_VHD_PHYSICAL_SECTOR_SIZE = 10,

			/// <summary>The smallest safe minimum size of the virtual disk.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para></summary>
			[CorrespondingType(typeof(ulong))]
			GET_VIRTUAL_DISK_INFO_SMALLEST_SAFE_VIRTUAL_SIZE = 11,

			/// <summary>The fragmentation level of the virtual disk.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para></summary>
			[CorrespondingType(typeof(uint))]
			GET_VIRTUAL_DISK_INFO_FRAGMENTATION = 12,

			/// <summary>Whether the virtual disk is currently mounted and in use.
			/// <para><c>Windows 8 and Windows Server 2012:</c> This value is not supported before Windows 8.1 and Windows Server 2012 R2.</para></summary>
			[CorrespondingType(typeof(bool))]
			GET_VIRTUAL_DISK_INFO_IS_LOADED = 13,

			/// <summary>The identifier that is uniquely created when a user first creates the virtual disk to attempt to uniquely identify that virtual disk.
			/// <para><c>Windows 8 and Windows Server 2012:</c> This value is not supported before Windows 8.1 and Windows Server 2012 R2.</para></summary>
			[CorrespondingType(typeof(Guid))]
			GET_VIRTUAL_DISK_INFO_VIRTUAL_DISK_ID = 14,

			/// <summary>The state of resilient change tracking (RCT) for the virtual disk.
			/// <para><c>Windows 8.1 and Windows Server 2012 R2:</c> This value is not supported before Windows 10 and Windows Server 2016.</para></summary>
			[CorrespondingType(typeof(GET_VIRTUAL_DISK_INFO_ChangeTrackingState))]
			GET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE = 15,
		}

		/// <summary>Contains virtual hard disk (VHD) merge request flags.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum MERGE_VIRTUAL_DISK_FLAG
		{
			/// <summary>None.</summary>
			MERGE_VIRTUAL_DISK_FLAG_NONE = 0x00000000
		}

		/// <summary>Contains the version of the virtual hard disk (VHD) MERGE_VIRTUAL_DISK_PARAMETERS structure to use in calls to VHD functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum MERGE_VIRTUAL_DISK_VERSION
		{
			/// <summary>Not supported.</summary>
			MERGE_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,

			/// <summary>The Version1 member structure will be used.</summary>
			MERGE_VIRTUAL_DISK_VERSION_1 = 1,

			/// <summary>The Version2 member structure will be used.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para></summary>
			MERGE_VIRTUAL_DISK_VERSION_2 = 2,
		}

		/// <summary>Contains the version of the virtual disk MIRROR_VIRTUAL_DISK_PARAMETERS structure used by the MirrorVirtualDisk function.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "hh448681")]
		public enum MIRROR_VIRTUAL_DISK_VERSION
		{
			/// <summary>Unsupported.</summary>
			MIRROR_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,
			/// <summary>Use the Version1 member.</summary>
			MIRROR_VIRTUAL_DISK_VERSION_1 = 1,
		}

		/// <summary>Contains flags affecting the behavior of the ModifyVhdSet function.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum MODIFY_VHDSET_FLAG
		{
			/// <summary>No flag specified.</summary>
			MODIFY_VHDSET_FLAG_NONE = 0x00000000
		}

		/// <summary>Contains the version of the MODIFY_VHDSET_PARAMETERS structure to use in calls to virtual disk functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum MODIFY_VHDSET_VERSION
		{
			/// <summary>Not Supported.</summary>
			MODIFY_VHDSET_UNSPECIFIED = 0,
			/// <summary>The SnapshotPath member structure will be used.</summary>
			MODIFY_VHDSET_SNAPSHOT_PATH = 1,
			/// <summary>The SnapshotId member structure will be used.</summary>
			MODIFY_VHDSET_REMOVE_SNAPSHOT = 2,
			/// <summary>The DefaultFilePath member structure will be used</summary>
			MODIFY_VHDSET_DEFAULT_SNAPSHOT_PATH = 3,
		}

		/// <summary>Contains virtual hard disk (VHD) mirror request flags.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "hh448679")]
		[Flags]
		public enum MIRROR_VIRTUAL_DISK_FLAG
		{
			/// <summary>The mirror virtual disk file does not exist, and needs to be created.</summary>
			MIRROR_VIRTUAL_DISK_FLAG_NONE = 0x00000000,
			/// <summary>Create the mirror using an existing file.</summary>
			MIRROR_VIRTUAL_DISK_FLAG_EXISTING_FILE = 0x00000001,
		}

		/// <summary>Contains virtual hard disk (VHD) or CD or DVD image file (ISO) open request flags.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323681")]
		[Flags]
		public enum OPEN_VIRTUAL_DISK_FLAG
		{
			/// <summary>No flag specified.</summary>
			OPEN_VIRTUAL_DISK_FLAG_NONE = 0x00000000,

			/// <summary>
			/// Open the VHD file (backing store) without opening any differencing-chain parents. Used to correct broken parent links. This flag is not supported
			/// for ISO virtual disks.
			/// </summary>
			OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS = 0x00000001,

			/// <summary>Reserved. This flag is not supported for ISO virtual disks.</summary>
			OPEN_VIRTUAL_DISK_FLAG_BLANK_FILE = 0x00000002,

			/// <summary>Reserved. This flag is not supported for ISO virtual disks.</summary>
			OPEN_VIRTUAL_DISK_FLAG_BOOT_DRIVE = 0x00000004,

			/// <summary>
			/// Indicates that the virtual disk should be opened in cached mode. By default the virtual disks are opened using FILE_FLAG_NO_BUFFERING and FILE_FLAG_WRITE_THROUGH.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			OPEN_VIRTUAL_DISK_FLAG_CACHED_IO = 0x00000008,

			/// <summary>
			/// Indicates the VHD file is to be opened without opening any differencing-chain parents and the parent chain is to be created manually using the
			/// AddVirtualDiskParent function.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			OPEN_VIRTUAL_DISK_FLAG_CUSTOM_DIFF_CHAIN = 0x00000010,

			/// <summary>This flag causes all backing stores except the leaf backing store to be opened in cached mode.</summary>
			OPEN_VIRTUAL_DISK_FLAG_PARENT_CACHED_IO = 0x00000020,

			/// <summary>This flag causes a Vhd Set file to be opened without any virtual disk.</summary>
			OPEN_VIRTUAL_DISK_FLAG_VHDSET_FILE_ONLY = 0x00000040,

			/// <summary>For differencing disks, relative parent locators are not used when determining the path of a parent VHD.</summary>
			OPEN_VIRTUAL_DISK_FLAG_IGNORE_RELATIVE_PARENT_LOCATOR = 0x00000080,

			/// <summary>Disable flushing and FUA (both for payload data and for metadata) for backing files associated with this virtual disk.</summary>
			OPEN_VIRTUAL_DISK_FLAG_NO_WRITE_HARDENING = 0x00000100,
		}

		/// <summary>Contains the version of the virtual disk OPEN_VIRTUAL_DISK_PARAMETERS structure to use in calls to virtual disk functions.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323683")]
		public enum OPEN_VIRTUAL_DISK_VERSION
		{
			/// <summary>Unspecified version.</summary>
			OPEN_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,

			/// <summary>Use the Version1 member of this structure.</summary>
			OPEN_VIRTUAL_DISK_VERSION_1 = 1,

			/// <summary>Use the Version2 member of this structure.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para></summary>
			OPEN_VIRTUAL_DISK_VERSION_2 = 2,

			/// <summary>Use the Version3 member of this structure.</summary>
			OPEN_VIRTUAL_DISK_VERSION_3 = 3,
		}

		/// <summary>Used by <see cref="QueryChangesVirtualDisk"/>.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum QUERY_CHANGES_VIRTUAL_DISK_FLAG
		{
			/// <summary>Default value.</summary>
			QUERY_CHANGES_VIRTUAL_DISK_FLAG_NONE = 0x00000000,
		}

		/// <summary>Contains flags affecting the behavior of the RawSCSIVirtualDisk function.</summary>
		[PInvokeData("VirtDisk.h")]
		[Flags]
		public enum RAW_SCSI_VIRTUAL_DISK_FLAG
		{
			/// <summary>No flag specified.</summary>
			RAW_SCSI_VIRTUAL_DISK_FLAG_NONE = 0X00000000
		}

		/// <summary>Contains the version of the RAW_SCSI_VIRTUAL_DISK_PARAMETERS structure to use in calls to virtual disk functions.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum RAW_SCSI_VIRTUAL_DISK_VERSION
		{
			/// <summary>Unspecified version.</summary>
			RAW_SCSI_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,
			/// <summary>Use the Version1 member of this structure.</summary>
			RAW_SCSI_VIRTUAL_DISK_VERSION_1 = 1
		}

		/// <summary>Enumerates the available flags for the ResizeVirtualDisk function.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323683")]
		[Flags]
		public enum RESIZE_VIRTUAL_DISK_FLAG
		{
			/// <summary>No flags are specified.</summary>
			RESIZE_VIRTUAL_DISK_FLAG_NONE = 0x0,

			/// <summary>
			/// If this flag is set, skip checking the virtual disk's partition table to ensure that this truncation is safe. Setting this flag can cause
			/// unrecoverable data loss; use with care.
			/// </summary>
			RESIZE_VIRTUAL_DISK_FLAG_ALLOW_UNSAFE_VIRTUAL_SIZE = 0x1,

			/// <summary>
			/// If this flag is set, resize the disk to the smallest virtual size possible without truncating past any existing partitions. If this is set,
			/// NewSize in RESIZE_VIRTUAL_DISK_PARAMETERS must be zero.
			/// </summary>
			RESIZE_VIRTUAL_DISK_FLAG_RESIZE_TO_SMALLEST_SAFE_VIRTUAL_SIZE = 0x2,
		}

		/// <summary>Enumerates the possible versions for parameters for the ResizeVirtualDisk function.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "hh832161")]
		public enum RESIZE_VIRTUAL_DISK_VERSION
		{
			/// <summary>The version is not valid.</summary>
			RESIZE_VIRTUAL_DISK_VERSION_UNSPECIFIED = 0,
			/// <summary>Version one of the parameters is used. This is the only supported value.</summary>
			RESIZE_VIRTUAL_DISK_VERSION_1 = 1,
		}
		
		/// <summary>Contains the version of the virtual hard disk (VHD) SET_VIRTUAL_DISK_INFO structure to use in calls to VHD functions.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323687")]
		public enum SET_VIRTUAL_DISK_INFO_VERSION
		{
			/// <summary>Not used. Will fail the operation.</summary>
			SET_VIRTUAL_DISK_INFO_UNSPECIFIED = 0,

			/// <summary>Parent information is being set.</summary>
			SET_VIRTUAL_DISK_INFO_PARENT_PATH = 1,

			/// <summary>A unique identifier is being set.</summary>
			SET_VIRTUAL_DISK_INFO_IDENTIFIER = 2,

			/// <summary>Sets the parent file path and the child depth.</summary>
			SET_VIRTUAL_DISK_INFO_PARENT_PATH_WITH_DEPTH = 3,

			/// <summary>Sets the physical sector size reported by the VHD.</summary>
			SET_VIRTUAL_DISK_INFO_PHYSICAL_SECTOR_SIZE = 4,

			/// <summary>The identifier that is uniquely created when a user first creates the virtual disk to attempt to uniquely identify that virtual disk.</summary>
			SET_VIRTUAL_DISK_INFO_VIRTUAL_DISK_ID = 5,

			/// <summary>Whether resilient change tracking (RCT) is turned on for the virtual disk.</summary>
			SET_VIRTUAL_DISK_INFO_CHANGE_TRACKING_STATE = 6,

			/// <summary>The parent linkage information that differencing VHDs store. Parent linkage information is metadata used to locate and correctly identify the next parent in the virtual disk chain.</summary>
			SET_VIRTUAL_DISK_INFO_PARENT_LOCATOR = 7,
		}

		/// <summary>Contains the version of the virtual hard disk (VHD) STORAGE_DEPENDENCY_INFO structure to use in calls to VHD functions.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323691")]
		public enum STORAGE_DEPENDENCY_INFO_VERSION
		{
			/// <summary>The version is not specified.</summary>
			STORAGE_DEPENDENCY_INFO_VERSION_UNSPECIFIED = 0,

			/// <summary>Specifies STORAGE_DEPENDENCY_INFO_TYPE_1.</summary>
			STORAGE_DEPENDENCY_INFO_VERSION_1 = 1,

			/// <summary>Specifies STORAGE_DEPENDENCY_INFO_TYPE_2.</summary>
			STORAGE_DEPENDENCY_INFO_VERSION_2 = 2
		}

		/// <summary>Contains flags affecting the behavior of the TakeSnapshotVhdSet function.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "mt414221")]
		[Flags]
		public enum TAKE_SNAPSHOT_VHDSET_FLAG
		{
			/// <summary>No flag specified.</summary>
			TAKE_SNAPSHOT_VHDSET_FLAG_NONE = 0x00000000
		}

		/// <summary>Enumerates the possible versions for parameters for the TakeSnapshotVhdSet function.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "mt414224")]
		public enum TAKE_SNAPSHOT_VHDSET_VERSION
		{
			/// <summary>Not Supported.</summary>
			TAKE_SNAPSHOT_VHDSET_VERSION_UNSPECIFIED = 0,
			/// <summary>The Version1 member structure will be used.</summary>
			TAKE_SNAPSHOT_VHDSET_VERSION_1 = 1
		}

		/// <summary>Contains the bitmask for specifying access rights to a virtual hard disk (VHD) or CD or DVD image file (ISO).</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323702")]
		[Flags]
		public enum VIRTUAL_DISK_ACCESS_MASK
		{
			/// <summary>
			/// Open the virtual disk with no access. This is the only supported value when calling CreateVirtualDisk and specifying
			/// CREATE_VIRTUAL_DISK_VERSION_2 in the VirtualDiskAccessMask parameter.
			/// </summary>
			VIRTUAL_DISK_ACCESS_NONE = 0x00000000,

			/// <summary>
			/// Open the virtual disk for read-only attach access. The caller must have READ access to the virtual disk image file.
			/// <para>
			/// If used in a request to open a virtual disk that is already open, the other handles must be limited to either VIRTUAL_DISK_ACCESS_DETACH or
			/// VIRTUAL_DISK_ACCESS_GET_INFO access, otherwise the open request with this flag will fail.
			/// </para>
			/// <para>
			/// <c>Windows 7 and Windows Server 2008 R2:</c> This access right is not supported for opening ISO virtual disks until Windows 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_ATTACH_RO = 0x00010000,

			/// <summary>
			/// Open the virtual disk for read/write attaching access. The caller must have (READ | WRITE) access to the virtual disk image file.
			/// <para>
			/// If used in a request to open a virtual disk that is already open, the other handles must be limited to either VIRTUAL_DISK_ACCESS_DETACH or
			/// VIRTUAL_DISK_ACCESS_GET_INFO access, otherwise the open request with this flag will fail.
			/// </para>
			/// <para>
			/// If the virtual disk is part of a differencing chain, the disk for this request cannot be less than the RWDepth specified during the prior open
			/// request for that differencing chain.
			/// </para>
			/// <para>This flag is not supported for ISO virtual disks.</para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_ATTACH_RW = 0x00020000,

			/// <summary>
			/// Open the virtual disk to allow detaching of an attached virtual disk. The caller must have (FILE_READ_ATTRIBUTES | FILE_READ_DATA) access to the
			/// virtual disk image file.
			/// <para>
			/// <c>Windows 7 and Windows Server 2008 R2:</c> This access right is not supported for opening ISO virtual disks until Windows 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_DETACH = 0x00040000,

			/// <summary>
			/// Information retrieval access to the virtual disk. The caller must have READ access to the virtual disk image file.
			/// <para>
			/// <c>Windows 7 and Windows Server 2008 R2:</c> This access right is not supported for opening ISO virtual disks until Windows 8 and Windows Server 2012.
			/// </para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_GET_INFO = 0x00080000,

			/// <summary>
			/// Virtual disk creation access.
			/// <para>This flag is not supported for ISO virtual disks.</para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_CREATE = 0x00100000,

			/// <summary>
			/// Open the virtual disk to perform offline meta-operations. The caller must have (READ | WRITE) access to the virtual disk image file, up to
			/// RWDepth if working with a differencing chain.
			/// <para>If the virtual disk is part of a differencing chain, the backing store (host volume) is opened in RW exclusive mode up to RWDepth.</para>
			/// <para>This flag is not supported for ISO virtual disks.</para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_METAOPS = 0x00200000,

			/// <summary>Reserved.</summary>
			VIRTUAL_DISK_ACCESS_READ = 0x000d0000,

			/// <summary>
			/// Allows unrestricted access to the virtual disk. The caller must have unrestricted access rights to the virtual disk image file.
			/// <para>This flag is not supported for ISO virtual disks.</para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_ALL = 0x003f0000,

			/// <summary>
			/// Reserved.
			/// <para>This flag is not supported for ISO virtual disks.</para>
			/// </summary>
			VIRTUAL_DISK_ACCESS_WRITABLE = 0x00320000
		}

		/// <summary>
		/// Provider-specific subtype. Set the Version member to GET_VIRTUAL_DISK_INFO_PROVIDER_SUBTYPE.
		/// </summary>
		[PInvokeData("VirtDisk.h")]
		public enum VIRTUAL_DISK_INFO_PROVIDER_SUBTYPE : uint
		{
			/// <summary>Fixed.</summary>
			Fixed = 2,
			/// <summary>Dynamically expandable (sparse).</summary>
			DynamicallyExpandable = 3,
			/// <summary>Differencing.</summary>
			Differencing = 4
		}

		/// <summary>Device type identifier.</summary>
		[PInvokeData("VirtDisk.h")]
		public enum VIRTUAL_STORAGE_TYPE_DEVICE_TYPE : uint
		{
			/// <summary>Device type is unknown or not valid.</summary>
			VIRTUAL_STORAGE_TYPE_DEVICE_UNKNOWN = 0,

			/// <summary>
			/// CD or DVD image file device type. (.iso file)
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			VIRTUAL_STORAGE_TYPE_DEVICE_ISO = 1,

			/// <summary>Virtual hard disk device type. (.vhd file)</summary>
			VIRTUAL_STORAGE_TYPE_DEVICE_VHD = 2,

			/// <summary>
			/// VHDX format virtual hard disk device type. (.vhdx file)
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This value is not supported before Windows 8 and Windows Server 2012.</para>
			/// </summary>
			VIRTUAL_STORAGE_TYPE_DEVICE_VHDX = 3,

			/// <summary></summary>
			VIRTUAL_STORAGE_TYPE_DEVICE_VHDSET = 4
		}

		/// <summary>Attaches a parent to a virtual disk opened with the OPEN_VIRTUAL_DISK_FLAG_CUSTOM_DIFF_CHAIN flag.</summary>
		/// <param name="VirtualDiskHandle">Handle to a virtual disk.</param>
		/// <param name="ParentPath">Address of a string containing a valid path to the virtual hard disk image to add as a parent.</param>
		/// <returns>
		/// Status of the request.
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is an error code. For more information, see System Error Codes.</para>
		/// </returns>
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		[PInvokeData("VirtDisk.h")]
		public static extern Win32Error AddVirtualDiskParent(SafeFileHandle VirtualDiskHandle, [MarshalAs(UnmanagedType.LPWStr)] string ParentPath);

		/// <summary>Applies a snapshot of the current virtual disk for VHD Set files.</summary>
		/// <param name="VirtualDiskHandle">A handle to an open virtual disk. For information on how to open a virtual disk, see the OpenVirtualDisk function.</param>
		/// <param name="Parameters">A pointer to a valid APPLY_SNAPSHOT_VHDSET_PARAMETERS structure that contains snapshot data.</param>
		/// <param name="Flags">A valid combination of values of the APPLY_SNAPSHOT_VHDSET_FLAG enumeration.</param>
		/// <returns>
		/// Status of the request.
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is an error code. For more information, see System Error Codes.</para>
		/// </returns>
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		[PInvokeData("VirtDisk.h")]
		public static extern Win32Error ApplySnapshotVhdSet(SafeFileHandle VirtualDiskHandle, ref APPLY_SNAPSHOT_VHDSET_PARAMETERS Parameters, APPLY_SNAPSHOT_VHDSET_FLAG Flags);

		/// <summary>Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.</summary>
		/// <param name="VirtualDiskHandle">A handle to an open virtual disk. For information on how to open a virtual disk, see the OpenVirtualDisk function.</param>
		/// <param name="SecurityDescriptor">
		/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the attached virtual disk. If this parameter is NULL, the security descriptor of the virtual
		/// disk image file is used.
		/// <para>
		/// Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write attributes permission for the user,
		/// or that the security descriptor of the virtual disk image file grants the write attributes permission for the user if you specify NULL for this
		/// parameter. If the security descriptor does not grant write attributes permission for a user, Shell displays the following error when the user
		/// accesses the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
		/// </para>
		/// </param>
		/// <param name="Flags">A valid combination of values of the ATTACH_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="ProviderSpecificFlags">Flags specific to the type of virtual disk being attached. May be zero if none are required.</param>
		/// <param name="Parameters">A pointer to a valid ATTACH_VIRTUAL_DISK_PARAMETERS structure that contains attachment parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// Status of the request.
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is an error code. For more information, see System Error Codes.</para>
		/// </returns>
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		[PInvokeData("VirtDisk.h")]
		public static extern Win32Error AttachVirtualDisk(SafeFileHandle VirtualDiskHandle, IntPtr SecurityDescriptor, ATTACH_VIRTUAL_DISK_FLAG Flags, uint ProviderSpecificFlags, ref ATTACH_VIRTUAL_DISK_PARAMETERS Parameters, [In] IntPtr Overlapped);

		/// <summary>Attaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate VHD provider to accomplish the attachment.</summary>
		/// <param name="VirtualDiskHandle">A handle to an open virtual disk. For information on how to open a virtual disk, see the OpenVirtualDisk function.</param>
		/// <param name="SecurityDescriptor">
		/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the attached virtual disk. If this parameter is NULL, the security descriptor of the virtual
		/// disk image file is used.
		/// <para>
		/// Ensure that the security descriptor that AttachVirtualDisk applies to the attached virtual disk grants the write attributes permission for the user,
		/// or that the security descriptor of the virtual disk image file grants the write attributes permission for the user if you specify NULL for this
		/// parameter. If the security descriptor does not grant write attributes permission for a user, Shell displays the following error when the user
		/// accesses the attached virtual disk: The Recycle Bin is corrupted. Do you want to empty the Recycle Bin for this drive?
		/// </para>
		/// </param>
		/// <param name="Flags">A valid combination of values of the ATTACH_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="ProviderSpecificFlags">Flags specific to the type of virtual disk being attached. May be zero if none are required.</param>
		/// <param name="Parameters">A pointer to a valid ATTACH_VIRTUAL_DISK_PARAMETERS structure that contains attachment parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// Status of the request.
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is an error code. For more information, see System Error Codes.</para>
		/// </returns>
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		[PInvokeData("VirtDisk.h")]
		public static extern Win32Error AttachVirtualDisk(SafeFileHandle VirtualDiskHandle, IntPtr SecurityDescriptor, ATTACH_VIRTUAL_DISK_FLAG Flags, uint ProviderSpecificFlags, ref ATTACH_VIRTUAL_DISK_PARAMETERS Parameters, ref NativeOverlapped Overlapped);

		/// <summary>
		/// Breaks a previously initiated mirror operation and sets the mirror to be the active virtual disk.
		/// </summary>
		/// <param name="VirtualDiskHandle">A handle to the open mirrored virtual disk. For information on how to open a virtual disk, see the OpenVirtualDisk function. For information on how to mirror a virtual disk, see the MirrorVirtualDisk function.</param>
		/// <returns>
		/// Status of the request.
		/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
		/// <para>If the function fails, the return value is an error code. For more information, see System Error Codes.</para>
		/// </returns>
		[PInvokeData("VirtDisk.h", MSDNShortId = "hh448676")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error BreakMirrorVirtualDisk(SafeFileHandle VirtualDiskHandle);

		/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
		/// <param name="VirtualDiskHandle">
		/// A handle to the open virtual disk, which must have been opened using the VIRTUAL_DISK_ACCESS_METAOPS flag in the VirtualDiskAccessMask parameter
		/// passed to OpenVirtualDisk. For information on how to open a virtual disk, see the OpenVirtualDisk function.
		/// </param>
		/// <param name="Flags">Must be the COMPACT_VIRTUAL_DISK_FLAG_NONE value (0) of the COMPACT_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">A optional pointer to a valid COMPACT_VIRTUAL_DISK_PARAMETERS structure that contains compaction parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code. For more information, see
		/// System Error Codes.
		/// </returns>
		/// <remarks>
		/// Compaction can be run only on a virtual disk that is dynamically expandable or differencing.
		/// <para>There are two different types of compaction.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The first type, file-system-aware compaction, uses the NTFS file system to determine free space. This is done by attaching the VHD as a read-only
		/// device by including the VIRTUAL_DISK_ACCESS_METAOPS and VIRTUAL_DISK_ACCESS_ATTACH_RO flags in the VirtualDiskAccessMask parameter passed to
		/// OpenVirtualDisk, attaching the VHD by calling AttachVirtualDisk, and while the VHD is attached calling CompactVirtualDisk. Detaching the VHD before
		/// compaction is done can cause compaction to return failure before it is done (similar to cancellation of compaction).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The second type, file-system-agnostic compaction, does not involve the file system but only looks for VHD blocks filled entirely with zeros (0). This
		/// is done by including the VIRTUAL_DISK_ACCESS_METAOPS flag in the VirtualDiskAccessMask parameter passed to OpenVirtualDisk, and calling CompactVirtualDisk.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// File-system-aware compaction is the most efficient compaction type but using first the file-system-aware compaction followed by the
		/// file-system-agnostic compaction will produce the smallest VHD.
		/// </para>
		/// <para>
		/// A compaction operation on a virtual disk can be safely interrupted and re-run later. Re-opening a virtual disk file that has been interrupted may
		/// result in the reduction of a virtual disk file's size at the time of opening.
		/// </para>
		/// <para>Compaction can be CPU-intensive and/or I/O-intensive, depending on how large the virtual disk is and how many blocks require movement.</para>
		/// <para>The CompactVirtualDisk function runs on the virtual disk in the same security context as the caller.</para>
		/// </remarks>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error CompactVirtualDisk(SafeFileHandle VirtualDiskHandle, COMPACT_VIRTUAL_DISK_FLAG Flags, ref COMPACT_VIRTUAL_DISK_PARAMETERS Parameters, ref NativeOverlapped Overlapped);

		/// <summary>Reduces the size of a virtual hard disk (VHD) backing store file.</summary>
		/// <param name="VirtualDiskHandle">
		/// A handle to the open virtual disk, which must have been opened using the VIRTUAL_DISK_ACCESS_METAOPS flag in the VirtualDiskAccessMask parameter
		/// passed to OpenVirtualDisk. For information on how to open a virtual disk, see the OpenVirtualDisk function.
		/// </param>
		/// <param name="Flags">Must be the COMPACT_VIRTUAL_DISK_FLAG_NONE value (0) of the COMPACT_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">A optional pointer to a valid COMPACT_VIRTUAL_DISK_PARAMETERS structure that contains compaction parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code. For more information, see
		/// System Error Codes.
		/// </returns>
		/// <remarks>
		/// Compaction can be run only on a virtual disk that is dynamically expandable or differencing.
		/// <para>There are two different types of compaction.</para>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// The first type, file-system-aware compaction, uses the NTFS file system to determine free space. This is done by attaching the VHD as a read-only
		/// device by including the VIRTUAL_DISK_ACCESS_METAOPS and VIRTUAL_DISK_ACCESS_ATTACH_RO flags in the VirtualDiskAccessMask parameter passed to
		/// OpenVirtualDisk, attaching the VHD by calling AttachVirtualDisk, and while the VHD is attached calling CompactVirtualDisk. Detaching the VHD before
		/// compaction is done can cause compaction to return failure before it is done (similar to cancellation of compaction).
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// The second type, file-system-agnostic compaction, does not involve the file system but only looks for VHD blocks filled entirely with zeros (0). This
		/// is done by including the VIRTUAL_DISK_ACCESS_METAOPS flag in the VirtualDiskAccessMask parameter passed to OpenVirtualDisk, and calling CompactVirtualDisk.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// File-system-aware compaction is the most efficient compaction type but using first the file-system-aware compaction followed by the
		/// file-system-agnostic compaction will produce the smallest VHD.
		/// </para>
		/// <para>
		/// A compaction operation on a virtual disk can be safely interrupted and re-run later. Re-opening a virtual disk file that has been interrupted may
		/// result in the reduction of a virtual disk file's size at the time of opening.
		/// </para>
		/// <para>Compaction can be CPU-intensive and/or I/O-intensive, depending on how large the virtual disk is and how many blocks require movement.</para>
		/// <para>The CompactVirtualDisk function runs on the virtual disk in the same security context as the caller.</para>
		/// </remarks>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error CompactVirtualDisk(SafeFileHandle VirtualDiskHandle, COMPACT_VIRTUAL_DISK_FLAG Flags, ref COMPACT_VIRTUAL_DISK_PARAMETERS Parameters, IntPtr Overlapped);

		/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
		/// <param name="VirtualStorageType">A pointer to a VIRTUAL_STORAGE_TYPE structure that contains the desired disk type and vendor information.</param>
		/// <param name="Path">A pointer to a valid string that represents the path to the new virtual disk image file.</param>
		/// <param name="VirtualDiskAccessMask">The VIRTUAL_DISK_ACCESS_MASK value to use when opening the newly created virtual disk file.</param>
		/// <param name="SecurityDescriptor">
		/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the virtual disk image file. If this parameter is NULL, the parent directory's security
		/// descriptor will be used.
		/// </param>
		/// <param name="Flags">Creation flags, which must be a valid combination of the CREATE_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="ProviderSpecificFlags">Flags specific to the type of virtual disk being created. May be zero if none are required.</param>
		/// <param name="Parameters">A pointer to a valid CREATE_VIRTUAL_DISK_PARAMETERS structure that contains creation parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <param name="Handle">A pointer to the handle object that represents the newly created virtual disk.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern Win32Error CreateVirtualDisk(ref VIRTUAL_STORAGE_TYPE VirtualStorageType, string Path, VIRTUAL_DISK_ACCESS_MASK VirtualDiskAccessMask, IntPtr SecurityDescriptor, CREATE_VIRTUAL_DISK_FLAG Flags, int ProviderSpecificFlags, ref CREATE_VIRTUAL_DISK_PARAMETERS Parameters, IntPtr Overlapped, out SafeFileHandle Handle);

		/// <summary>Creates a virtual hard disk (VHD) image file, either using default parameters or using an existing VHD or physical disk.</summary>
		/// <param name="VirtualStorageType">A pointer to a VIRTUAL_STORAGE_TYPE structure that contains the desired disk type and vendor information.</param>
		/// <param name="Path">A pointer to a valid string that represents the path to the new virtual disk image file.</param>
		/// <param name="VirtualDiskAccessMask">The VIRTUAL_DISK_ACCESS_MASK value to use when opening the newly created virtual disk file.</param>
		/// <param name="SecurityDescriptor">
		/// An optional pointer to a SECURITY_DESCRIPTOR to apply to the virtual disk image file. If this parameter is NULL, the parent directory's security
		/// descriptor will be used.
		/// </param>
		/// <param name="Flags">Creation flags, which must be a valid combination of the CREATE_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="ProviderSpecificFlags">Flags specific to the type of virtual disk being created. May be zero if none are required.</param>
		/// <param name="Parameters">A pointer to a valid CREATE_VIRTUAL_DISK_PARAMETERS structure that contains creation parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <param name="Handle">A pointer to the handle object that represents the newly created virtual disk.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern Win32Error CreateVirtualDisk(ref VIRTUAL_STORAGE_TYPE VirtualStorageType, string Path, VIRTUAL_DISK_ACCESS_MASK VirtualDiskAccessMask, IntPtr SecurityDescriptor, CREATE_VIRTUAL_DISK_FLAG Flags, int ProviderSpecificFlags, ref CREATE_VIRTUAL_DISK_PARAMETERS Parameters, ref NativeOverlapped Overlapped, out SafeFileHandle Handle);

		/// <summary>Deletes a snapshot from a VHD Set file.</summary>
		/// <param name="VirtualDiskHandle">A handle to the open virtual disk.</param>
		/// <param name="Parameters">A pointer to a valid DELETE_SNAPSHOT_VHDSET_PARAMETERS structure that contains snapshot deletion data.</param>
		/// <param name="Flags">Snapshot deletion flags, which must be a valid combination of the DELETE_SNAPSHOT_VHDSET_FLAG enumeration.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error DeleteSnapshotVhdSet(SafeFileHandle VirtualDiskHandle, ref DELETE_SNAPSHOT_VHDSET_PARAMETERS Parameters, DELETE_SNAPSHOT_VHDSET_FLAG Flags);

		/// <summary>Deletes metadata from a virtual disk.</summary>
		/// <param name="VirtualDiskHandle">A handle to the open virtual disk.</param>
		/// <param name="Item">The item to be deleted.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error DeleteVirtualDiskMetadata(SafeFileHandle VirtualDiskHandle, [MarshalAs(UnmanagedType.LPStruct)] Guid Item);

		/// <summary>
		/// Detaches a virtual hard disk (VHD) or CD or DVD image file (ISO) by locating an appropriate virtual disk provider to accomplish the operation.
		/// </summary>
		/// <param name="VirtualDiskHandle">
		/// A handle to an open virtual disk, which must have been opened using the VIRTUAL_DISK_ACCESS_DETACH flag set in the VirtualDiskAccessMask parameter to
		/// the OpenVirtualDisk function. For information on how to open a virtual disk, see the OpenVirtualDisk function.
		/// </param>
		/// <param name="Flags">A valid combination of values of the DETACH_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="ProviderSpecificFlags">Flags specific to the type of virtual disk being detached. May be zero if none are required.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code. For more information, see
		/// System Error Codes.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error DetachVirtualDisk(SafeFileHandle VirtualDiskHandle, DETACH_VIRTUAL_DISK_FLAG Flags, int ProviderSpecificFlags);

		/// <summary>Enumerates the metadata associated with a virtual disk.</summary>
		/// <param name="VirtualDiskHandle">Handle to an open virtual disk.</param>
		/// <param name="NumberOfItems">Address of a ULONG. On input, the value indicates the number of elements in the buffer pointed to by the Items parameter. On output, the value contains the number of items retrieved. If the buffer was too small, the API will fail and return ERROR_INSUFFICIENT_BUFFER and the ULONG will contain the required buffer size.</param>
		/// <param name="Items">Address of a buffer to be filled with the GUIDs representing the metadata. The GetVirtualDiskMetadata function can be used to retrieve the data represented by each GUID.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code. For more information, see
		/// System Error Codes.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error EnumerateVirtualDiskMetadata(SafeFileHandle VirtualDiskHandle, ref uint NumberOfItems, IntPtr Items);

		/// <summary>Increases the size of a fixed or dynamic virtual hard disk (VHD).</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_METAOPS flag.</param>
		/// <param name="Flags">Must be the EXPAND_VIRTUAL_DISK_FLAG_NONE value of the EXPAND_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">A pointer to a valid EXPAND_VIRTUAL_DISK_PARAMETERS structure that contains expansion parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error ExpandVirtualDisk(SafeFileHandle VirtualDiskHandle, EXPAND_VIRTUAL_DISK_FLAG Flags, ref EXPAND_VIRTUAL_DISK_PARAMETERS Parameters, IntPtr Overlapped);

		/// <summary>Increases the size of a fixed or dynamic virtual hard disk (VHD).</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_METAOPS flag.</param>
		/// <param name="Flags">Must be the EXPAND_VIRTUAL_DISK_FLAG_NONE value of the EXPAND_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">A pointer to a valid EXPAND_VIRTUAL_DISK_PARAMETERS structure that contains expansion parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error ExpandVirtualDisk(SafeFileHandle VirtualDiskHandle, EXPAND_VIRTUAL_DISK_FLAG Flags, ref EXPAND_VIRTUAL_DISK_PARAMETERS Parameters, ref NativeOverlapped Overlapped);

		/// <summary>
		/// Get the paths of all attached virtual disks.
		/// </summary>
		/// <param name="PathsBufferSizeInBytes">Size of the buffer supplied in <paramref name="PathsBuffer"/>.</param>
		/// <param name="PathsBuffer">Buffer of sufficient size to hold all returned paths.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error GetAllAttachedVirtualDiskPhysicalPaths(ref uint PathsBufferSizeInBytes, SafeCoTaskMemHandle PathsBuffer);

		/// <summary>Returns the relationships between virtual hard disks (VHDs) or the volumes contained within those disks and their parent disk or volume.</summary>
		/// <param name="ObjectHandle">A handle to an open VHD.</param>
		/// <param name="Flags">A valid combination of GET_STORAGE_DEPENDENCY_FLAG values.</param>
		/// <param name="StorageDependencyInfoSize">
		/// Size, in bytes, of the STORAGE_DEPENDENCY_INFO structure that the StorageDependencyInfo parameter refers to.
		/// </param>
		/// <param name="StorageDependencyInfo">A pointer to a valid STORAGE_DEPENDENCY_INFO structure, which is a variable-length structure.</param>
		/// <param name="SizeUsed">An optional pointer to a ULONG that receives the size used.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error GetStorageDependencyInformation(SafeFileHandle ObjectHandle, GET_STORAGE_DEPENDENCY_FLAG Flags, int StorageDependencyInfoSize, SafeHGlobalHandle StorageDependencyInfo, ref int SizeUsed);

		/// <summary>Retrieves information about a virtual hard disk (VHD).</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_GET_INFO flag.</param>
		/// <param name="VirtualDiskInfoSize">A pointer to a ULONG that contains the size of the VirtualDiskInfo parameter.</param>
		/// <param name="VirtualDiskInfo">
		/// A pointer to a valid <see cref="GET_VIRTUAL_DISK_INFO"/> structure. The format of the data returned is dependent on the value passed in the Version member by the caller.
		/// </param>
		/// <param name="SizeUsed">A pointer to a ULONG that contains the size used.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error GetVirtualDiskInformation(SafeFileHandle VirtualDiskHandle, ref uint VirtualDiskInfoSize, SafeHGlobalHandle VirtualDiskInfo, out uint SizeUsed);

		/// <summary>Retrieves the specified metadata from the virtual disk.</summary>
		/// <param name="VirtualDiskHandle">Handle to an open virtual disk.</param>
		/// <param name="Item">Address of a GUID identifying the metadata to retrieve.</param>
		/// <param name="MetaDataSize">
		/// Address of a ULONG. On input, the value indicates the size, in bytes, of the buffer pointed to by the MetaData parameter. On output, the value
		/// contains size, in bytes, of the retrieved metadata. If the buffer was too small, the API will fail and return ERROR_INSUFFICIENT_BUFFER, putting the
		/// required size in the ULONG and the buffer will contain the start of the metadata.
		/// </param>
		/// <param name="MetaData">Address of the buffer where the metadata is to be stored.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS. If the buffer pointed to by the Items parameter was too small, the return value is
		/// ERROR_INSUFFICIENT_BUFFER. If the function fails, the return value is an error code.For more information, see System Error Codes.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error GetVirtualDiskMetadata(SafeFileHandle VirtualDiskHandle, [MarshalAs(UnmanagedType.LPStruct)] Guid Item, ref uint MetaDataSize, SafeCoTaskMemHandle MetaData);

		/// <summary>Checks the progress of an asynchronous virtual hard disk (VHD) operation.</summary>
		/// <param name="VirtualDiskHandle">A valid handle to a virtual disk with a pending asynchronous operation.</param>
		/// <param name="Overlapped">
		/// A pointer to a valid OVERLAPPED structure. This parameter must reference the same structure previously sent to the virtual disk operation being
		/// checked for progress.
		/// </param>
		/// <param name="Progress">A pointer to a VIRTUAL_DISK_PROGRESS structure that receives the current virtual disk operation progress.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Progress parameter will be populated with the current virtual disk operation
		/// progress. If the function fails, the return value is an error code and the value of the Progress parameter is undefined. For more information, see
		/// System Error Codes.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error GetVirtualDiskOperationProgress(SafeFileHandle VirtualDiskHandle, ref NativeOverlapped Overlapped, ref VIRTUAL_DISK_PROGRESS Progress);

		/// <summary>Retrieves the path to the physical device object that contains a virtual hard disk (VHD).</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_GET_INFO flag.</param>
		/// <param name="DiskPathSizeInBytes">The size, in bytes, of the buffer pointed to by the DiskPath parameter.</param>
		/// <param name="DiskPath">A target buffer to receive the path of the physical disk device that contains the VHD.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, CharSet = CharSet.Unicode, ExactSpelling = true)]
		public static extern Win32Error GetVirtualDiskPhysicalPath(SafeFileHandle VirtualDiskHandle, ref int DiskPathSizeInBytes, StringBuilder DiskPath);

		/// <summary>Merges a child virtual hard disk (VHD) in a differencing chain with parent disks in the chain.</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_METAOPS flag.</param>
		/// <param name="Flags">Must be the MERGE_VIRTUAL_DISK_FLAG_NONE value of the MERGE_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">A pointer to a valid MERGE_VIRTUAL_DISK_PARAMETERS structure that contains merge parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error MergeVirtualDisk(SafeFileHandle VirtualDiskHandle, MERGE_VIRTUAL_DISK_FLAG Flags, ref MERGE_VIRTUAL_DISK_PARAMETERS Parameters, IntPtr Overlapped);

		/// <summary>Merges a child virtual hard disk (VHD) in a differencing chain with parent disks in the chain.</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_METAOPS flag.</param>
		/// <param name="Flags">Must be the MERGE_VIRTUAL_DISK_FLAG_NONE value of the MERGE_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">A pointer to a valid MERGE_VIRTUAL_DISK_PARAMETERS structure that contains merge parameter data.</param>
		/// <param name="Overlapped">An optional pointer to a valid OVERLAPPED structure if asynchronous operation is desired.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error MergeVirtualDisk(SafeFileHandle VirtualDiskHandle, MERGE_VIRTUAL_DISK_FLAG Flags, ref MERGE_VIRTUAL_DISK_PARAMETERS Parameters, ref NativeOverlapped Overlapped);

		/// <summary>
		/// Initiates a mirror operation for a virtual disk. Once the mirroring operation is initiated it will not complete until either CancelIo or CancelIoEx is called to cancel all I/O on the VirtualDiskHandle, leaving the original file as the current or BreakMirrorVirtualDisk is called to stop using the original file and only use the mirror. GetVirtualDiskOperationProgress can be used to determine if the disks are fully mirrored and writes go to both virtual disks.
		/// </summary>
		/// <param name="VirtualDiskHandle">A handle to the open virtual disk. For information on how to open a virtual disk, see the OpenVirtualDisk function.</param>
		/// <param name="Flags">A valid combination of values from the MIRROR_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">Address of a MIRROR_VIRTUAL_DISK_PARAMETERS structure containing mirror parameter data.</param>
		/// <param name="Overlapped">Address of an OVERLAPPEDstructure. This parameter is required.</param>
		/// <returns>If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code.For more information, see System Error Codes.</returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error MirrorVirtualDisk(SafeFileHandle VirtualDiskHandle, MIRROR_VIRTUAL_DISK_FLAG Flags, ref MIRROR_VIRTUAL_DISK_PARAMETERS Parameters, ref NativeOverlapped Overlapped);

		/// <summary>Modifies the internal contents of a virtual disk file. Can be used to set the active leaf, or to fix up snapshot entries.</summary>
		/// <param name="VirtualDiskHandle">A handle to the open virtual disk. This must be a VHD Set file.</param>
		/// <param name="Parameters">A pointer to a valid MODIFY_VHDSET_PARAMETERS structure that contains modification data.</param>
		/// <param name="Flags">Modification flags, which must be a valid combination of the MODIFY_VHDSET_FLAG enumeration.</param>
		/// <returns>Status of the request. If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code.For more information, see System Error Codes.</returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error ModifyVhdSet(SafeFileHandle VirtualDiskHandle, ref MODIFY_VHDSET_PARAMETERS Parameters, MODIFY_VHDSET_FLAG Flags);

		/// <summary>Opens a virtual hard disk (VHD) or CD or DVD image file (ISO) for use.</summary>
		/// <param name="VirtualStorageType">A pointer to a valid VIRTUAL_STORAGE_TYPE structure.</param>
		/// <param name="Path">A pointer to a valid path to the virtual disk image to open.</param>
		/// <param name="VirtualDiskAccessMask">A valid value of the VIRTUAL_DISK_ACCESS_MASK enumeration.</param>
		/// <param name="Flags">A valid combination of values of the OPEN_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">An optional pointer to a valid OPEN_VIRTUAL_DISK_PARAMETERS structure. Can be NULL.</param>
		/// <param name="Handle">A pointer to the handle object that represents the open virtual disk.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS (0) and the Handle parameter contains a valid pointer to the new virtual disk object.
		/// <para>
		/// If the function fails, the return value is an error code and the value of the Handle parameter is undefined. For more information, see System Error Codes.
		/// </para>
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true, ThrowOnUnmappableChar = true)]
		public static extern Win32Error OpenVirtualDisk([In] ref VIRTUAL_STORAGE_TYPE VirtualStorageType, [MarshalAs(UnmanagedType.LPWStr)] string Path, VIRTUAL_DISK_ACCESS_MASK VirtualDiskAccessMask, OPEN_VIRTUAL_DISK_FLAG Flags, [In] OPEN_VIRTUAL_DISK_PARAMETERS Parameters, out SafeFileHandle Handle);

		/// <summary>Retrieves information about changes to the specified areas of a virtual hard disk (VHD) that are tracked by resilient change tracking (RCT).</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_GET_INFO flag set in the VirtualDiskAccessMask parameter to the OpenVirtualDisk function. For information on how to open a VHD, see the OpenVirtualDisk function.</param>
		/// <param name="ChangeTrackingId">A pointer to a string that specifies the change tracking identifier for the change that identifies the state of the virtual disk that you want to use as the basis of comparison to determine whether the specified area of the VHD has changed.</param>
		/// <param name="ByteOffset">An unsigned long integer that specifies the distance from the start of the VHD to the beginning of the area of the VHD that you want to check for changes, in bytes.</param>
		/// <param name="ByteLength">An unsigned long integer that specifies the length of the area of the VHD that you want to check for changes, in bytes.</param>
		/// <param name="Flags">Reserved. Set to QUERY_CHANGES_VIRTUAL_DISK_FLAG_NONE.</param>
		/// <param name="Ranges">An array of QUERY_CHANGES_VIRTUAL_DISK_RANGE structures that indicates the areas of the virtual disk within the area that the ByteOffset and ByteLength parameters specify that have changed since the change tracking identifier that the ChangeTrackingId parameter specifies was sealed.</param>
		/// <param name="RangeCount">An address of an unsigned long integer. On input, the value indicates the number of QUERY_CHANGES_VIRTUAL_DISK_RANGE structures that the array that the Ranges parameter points to can hold. On output, the value contains the number of QUERY_CHANGES_VIRTUAL_DISK_RANGE structures that the method placed in the array.</param>
		/// <param name="ProcessedLength">A pointer to an unsigned long integer that indicates the total number of bytes that the method processed, which indicates for how much of the area that the BytesLength parameter specifies that changes were captured in the available space of the array that the Ranges parameter specifies.</param>
		/// <returns>The status of the request. If the function succeeds, the return value is ERROR_SUCCESS and the Ranges parameter contains the requested information. If the function fails, the return value is an error code.For more information, see System Error Codes.</returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error QueryChangesVirtualDisk(SafeFileHandle VirtualDiskHandle, [MarshalAs(UnmanagedType.LPWStr)] string ChangeTrackingId, ulong ByteOffset, ulong ByteLength, QUERY_CHANGES_VIRTUAL_DISK_FLAG Flags, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] QUERY_CHANGES_VIRTUAL_DISK_RANGE[] Ranges, ref uint RangeCount, out ulong ProcessedLength);

		/// <summary>Issues an embedded SCSI request directly to a virtual hard disk.</summary>
		/// <param name="VirtualDiskHandle">A handle to an open virtual disk. For information on how to open a virtual disk, see the OpenVirtualDisk function. This handle may also be a handle to a Remote Shared Virtual Disk. For information on how to open a Remote Shared Virtual Disk, see the Remote Shared Virtual Disk Protocol documentation.</param>
		/// <param name="Parameters">A pointer to a valid RAW_SCSI_VIRTUAL_DISK_PARAMETERS structure that contains snapshot deletion data.</param>
		/// <param name="Flags">SCSI virtual disk flags, which must be a valid combination of the RAW_SCSI_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Response">A pointer to a RAW_SCSI_VIRTUAL_DISK_RESPONSE structure that contains the results of processing the SCSI command.</param>
		/// <returns>Status of the request. If the function succeeds, the return value is ERROR_SUCCESS. A return of ERROR_SUCCESS only means the request was received by the virtual disk.The SCSI command itself could have failed due to an invalid device state, an unsupported SCSI command, or another error. If the function fails, the return value is an error code.For more information, see System Error Codes.</returns>
	   [PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error RawSCSIVirtualDisk(SafeFileHandle VirtualDiskHandle, ref RAW_SCSI_VIRTUAL_DISK_PARAMETERS Parameters, RAW_SCSI_VIRTUAL_DISK_FLAG Flags, out RAW_SCSI_VIRTUAL_DISK_RESPONSE Response);

		/// <summary>Resizes a virtual disk.</summary>
		/// <param name="VirtualDiskHandle">Handle to an open virtual disk.</param>
		/// <param name="Flags">Zero or more flags enumerated from the RESIZE_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">Address of a RESIZE_VIRTUAL_DISK_PARAMETERS structure containing the new size of the virtual disk.</param>
		/// <param name="Overlapped">If this is to be an asynchronous operation, the address of a valid OVERLAPPED structure.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS (0) and the Handle parameter contains a valid pointer to the new virtual disk object.
		/// <para>
		/// If the function fails, the return value is an error code and the value of the Handle parameter is undefined. For more information, see System Error Codes.
		/// </para>
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error ResizeVirtualDisk(SafeFileHandle VirtualDiskHandle, RESIZE_VIRTUAL_DISK_FLAG Flags, ref RESIZE_VIRTUAL_DISK_PARAMETERS Parameters, IntPtr Overlapped);

		/// <summary>Resizes a virtual disk.</summary>
		/// <param name="VirtualDiskHandle">Handle to an open virtual disk.</param>
		/// <param name="Flags">Zero or more flags enumerated from the RESIZE_VIRTUAL_DISK_FLAG enumeration.</param>
		/// <param name="Parameters">Address of a RESIZE_VIRTUAL_DISK_PARAMETERS structure containing the new size of the virtual disk.</param>
		/// <param name="Overlapped">If this is to be an asynchronous operation, the address of a valid OVERLAPPED structure.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS (0) and the Handle parameter contains a valid pointer to the new virtual disk object.
		/// <para>
		/// If the function fails, the return value is an error code and the value of the Handle parameter is undefined. For more information, see System Error Codes.
		/// </para>
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error ResizeVirtualDisk(SafeFileHandle VirtualDiskHandle, RESIZE_VIRTUAL_DISK_FLAG Flags, ref RESIZE_VIRTUAL_DISK_PARAMETERS Parameters, ref NativeOverlapped Overlapped);

		/// <summary>Sets information about a virtual hard disk (VHD).</summary>
		/// <param name="VirtualDiskHandle">A handle to the open VHD, which must have been opened using the VIRTUAL_DISK_ACCESS_METAOPS flag.</param>
		/// <param name="VirtualDiskInfo">A pointer to a valid SET_VIRTUAL_DISK_INFO structure.</param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS and the Handle parameter contains a valid pointer to the new virtual disk object. If the
		/// function fails, the return value is an error code and the value of the Handle parameter is undefined.
		/// </returns>
		[PInvokeData("VirtDisk.h")]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error SetVirtualDiskInformation(SafeFileHandle VirtualDiskHandle, ref SET_VIRTUAL_DISK_INFO VirtualDiskInfo);

		/// <summary>Sets a metadata item for a virtual disk.</summary>
		/// <param name="VirtualDiskHandle">Handle to an open virtual disk.</param>
		/// <param name="Item">A GUID identifying the metadata to retrieve.</param>
		/// <param name="MetaDataSize">Address of a ULONG containing the size, in bytes, of the buffer pointed to by the MetaData parameter.</param>
		/// <param name="MetaData">Address of the buffer containing the metadata to be stored.</param>
		/// <returns>Status of the request. If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code.For more information, see System Error Codes.</returns>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error SetVirtualDiskMetadata(SafeFileHandle VirtualDiskHandle, [MarshalAs(UnmanagedType.LPStruct)] Guid Item, uint MetaDataSize, IntPtr MetaData);

		/// <summary>Creates a snapshot of the current virtual disk for VHD Set files.</summary>
		/// <param name="VirtualDiskHandle">A handle to the open virtual disk. This must be a VHD Set file.</param>
		/// <param name="Parameters">A pointer to a valid TAKE_SNAPSHOT_VHDSET_PARAMETERS structure that contains snapshot data.</param>
		/// <param name="Flags">Snapshot flags, which must be a valid combination of the TAKE_SNAPSHOT_VHDSET_FLAG enumeration.</param>
		/// <returns>Status of the request. If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is an error code.For more information, see System Error Codes.</returns>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[DllImport(Lib.VirtDisk, ExactSpelling = true)]
		public static extern Win32Error TakeSnapshotVhdSet(SafeFileHandle VirtualDiskHandle, ref TAKE_SNAPSHOT_VHDSET_PARAMETERS Parameters, TAKE_SNAPSHOT_VHDSET_FLAG Flags);

		/// <summary>Contains snapshot parameters, indicating information about the new snapshot to be applied.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct APPLY_SNAPSHOT_VHDSET_PARAMETERS
		{
			/// <summary>
			/// An APPLY_SNAPSHOT_VHDSET_VERSION enumeration that specifies the version of the APPLY_SNAPSHOT_VHDSET_PARAMETERS structure being passed to or from
			/// the VHD functions.
			/// </summary>
			public APPLY_SNAPSHOT_VHDSET_VERSION Version;
			/// <summary>A structure with the following member.</summary>
			public APPLY_SNAPSHOT_VHDSET_PARAMETERS_Version1 Version1;
		}

		/// <summary>A structure with the following member.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct APPLY_SNAPSHOT_VHDSET_PARAMETERS_Version1
		{
			/// <summary>The ID of the new snapshot to be applied to the VHD set.</summary>
			public Guid SnapshotId;
			/// <summary>
			/// Indicates whether the current default leaf data should be retained as part of the apply operation. When a zero GUID is specified, the apply
			/// operation will discard the current default leaf data. When a non-zero GUID is specified, the apply operation will convert the default leaf data
			/// into a writeable snapshot with the specified ID.
			/// </summary>
			public Guid LeafSnapshotId;
		}

		/// <summary>Contains virtual hard disk (VHD) attach request parameters.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct ATTACH_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>
			/// A ATTACH_VIRTUAL_DISK_VERSION enumeration that specifies the version of the ATTACH_VIRTUAL_DISK_PARAMETERS structure being passed to or from the
			/// VHD functions.
			/// </summary>
			public ATTACH_VIRTUAL_DISK_VERSION Version;

			/// <summary>A structure with the following member.</summary>
			public ATTACH_VIRTUAL_DISK_PARAMETERS_Version1 Version1;

			/// <summary>Gets the default value for this structure. This is currently the only valid value for <see cref="ATTACH_VIRTUAL_DISK_PARAMETERS"/>.</summary>
			public static ATTACH_VIRTUAL_DISK_PARAMETERS Default => new ATTACH_VIRTUAL_DISK_PARAMETERS { Version = ATTACH_VIRTUAL_DISK_VERSION.ATTACH_VIRTUAL_DISK_VERSION_1 };
		}

		/// <summary>A structure with the following member.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct ATTACH_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>Reserved.</summary>
			public uint Reserved;
		}

		/// <summary>Contains virtual hard disk (VHD) compacting parameters.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct COMPACT_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>
			/// A COMPACT_VIRTUAL_DISK_VERSION enumeration that specifies the version of the COMPACT_VIRTUAL_DISK_PARAMETERS structure being passed to or from
			/// the virtual hard disk (VHD) functions.
			/// </summary>
			public COMPACT_VIRTUAL_DISK_VERSION Version;

			/// <summary>A structure with the following member.</summary>
			public COMPACT_VIRTUAL_DISK_PARAMETERS_Version1 Version1;

			/// <summary>Gets the default value for this structure. This is currently the only valid value for <see cref="COMPACT_VIRTUAL_DISK_PARAMETERS"/>.</summary>
			public static COMPACT_VIRTUAL_DISK_PARAMETERS Default => new COMPACT_VIRTUAL_DISK_PARAMETERS { Version = COMPACT_VIRTUAL_DISK_VERSION.COMPACT_VIRTUAL_DISK_VERSION_1 };
		}

		/// <summary>A structure with the following member.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct COMPACT_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>Reserved. Must be set to zero.</summary>
			public uint Reserved;
		}

		/// <summary>Contains virtual disk creation parameters, providing control over, and information about, the newly created virtual disk.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Explicit)]
		public struct CREATE_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>
			/// A CREATE_VIRTUAL_DISK_VERSION enumeration that specifies the version of the CREATE_VIRTUAL_DISK_PARAMETERS structure being passed to or from the
			/// virtual hard disk (VHD) functions.
			/// </summary>
			[FieldOffset(0)] public CREATE_VIRTUAL_DISK_VERSION Version;

			/// <summary>This structure is used if the Version member is CREATE_VIRTUAL_DISK_VERSION_1 (1).</summary>
			[FieldOffset(8)] public CREATE_VIRTUAL_DISK_PARAMETERS_Version1 Version1;
			/// <summary>This structure is used if the Version member is CREATE_VIRTUAL_DISK_VERSION_2 (2).</summary>
			[FieldOffset(8)] public CREATE_VIRTUAL_DISK_PARAMETERS_Version2 Version2;
			/// <summary>This structure is used if the Version member is CREATE_VIRTUAL_DISK_VERSION_3 (3).</summary>
			[FieldOffset(8)] public CREATE_VIRTUAL_DISK_PARAMETERS_Version3 Version3;

			/// <summary>
			/// Initializes a CREATE_VIRTUAL_DISK_PARAMETERS with a maximum size.
			/// </summary>
			/// <param name="maxSize">
			/// The maximum virtual size of the virtual disk object. Must be a multiple of 512. If a ParentPath is specified, this value must be zero. If a
			/// SourcePath is specified, this value can be zero to specify the size of the source VHD to be used, otherwise the size specified must be greater
			/// than or equal to the size of the source disk.
			/// </param>
			/// <param name="version">Set this number if you wish to force the version of this structure to something other than <see cref="CREATE_VIRTUAL_DISK_VERSION.CREATE_VIRTUAL_DISK_VERSION_1"/>.</param>
			/// <param name="blockSize">Internal size of the virtual disk object blocks, in bytes. This must be set to one of the following values: 0 (default), 0x80000 (512K), or 0x200000 (2MB).</param>
			/// <param name="logicalSectorSize">Internal size of the virtual disk object sectors. For VHDX must be set to 512 (0x200) or 4096 (0x1000). For VHD 1 must be set to 512.</param>
			public CREATE_VIRTUAL_DISK_PARAMETERS(ulong maxSize, uint version = 1, uint blockSize = 0, uint logicalSectorSize = 0) : this()
			{
				if (version < 1 || version > 3) throw new ArgumentOutOfRangeException(nameof(version));
				Version = (CREATE_VIRTUAL_DISK_VERSION)version;
				Version1.MaximumSize = maxSize;
				Version1.BlockSizeInBytes = blockSize;
				Version1.SectorSizeInBytes = logicalSectorSize;
			}
		}

		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct CREATE_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>Unique identifier to assign to the virtual disk object. If this member is set to zero, a unique identifier is created by the system.</summary>
			public Guid UniqueId;

			/// <summary>
			/// The maximum virtual size of the virtual disk object. Must be a multiple of 512. If a ParentPath is specified, this value must be zero. If a
			/// SourcePath is specified, this value can be zero to specify the size of the source VHD to be used, otherwise the size specified must be greater
			/// than or equal to the size of the source disk.
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// Internal size of the virtual disk object blocks. If value is 0, block size will be automatically matched to the parent or source disk's setting
			/// if ParentPath or SourcePath is specified (otherwise a block size of 2MB will be used).
			/// </summary>
			public uint BlockSizeInBytes;

			/// <summary>Internal size of the virtual disk object sectors. Must be set to 512.</summary>
			public uint SectorSizeInBytes;

			/// <summary>
			/// Optional path to a parent virtual disk object. Associates the new virtual disk with an existing virtual disk. If this parameter is not NULL,
			/// SourcePath must be NULL.
			/// </summary>
			public IntPtr ParentPath;

			/// <summary>
			/// Optional fully qualified path to pre-populate the new virtual disk object with block data from an existing disk. This path may refer to a virtual
			/// disk or a physical disk. If this parameter is not NULL, ParentPath must be NULL.
			/// </summary>
			public IntPtr SourcePath;
		}

		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential)]
		public struct CREATE_VIRTUAL_DISK_PARAMETERS_Version2
		{
			/// <summary>Unique identifier to assign to the virtual disk object. If this member is set to zero, a unique identifier is created by the system.</summary>
			public Guid UniqueId;

			/// <summary>
			/// The maximum virtual size of the virtual disk object. Must be a multiple of 512. If a ParentPath is specified, this value must be zero. If a
			/// SourcePath is specified, this value can be zero to specify the size of the source VHD to be used, otherwise the size specified must be greater
			/// than or equal to the size of the source disk.
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// Internal size of the virtual disk object blocks. If value is 0, block size will be automatically matched to the parent or source disk's setting
			/// if ParentPath or SourcePath is specified (otherwise a block size of 2MB will be used).
			/// </summary>
			public uint BlockSizeInBytes;

			/// <summary>Internal size of the virtual disk object sectors. Must be set to 512.</summary>
			public uint SectorSizeInBytes;

			/// <summary>Size of the physical disk object sectors.</summary>
			public uint PhysicalSectorSizeInBytes;

			/// <summary>
			/// Optional path to a parent virtual disk object. Associates the new virtual disk with an existing virtual disk. If this parameter is not NULL,
			/// SourcePath must be NULL.
			/// </summary>
			public IntPtr ParentPath;

			/// <summary>
			/// Optional fully qualified path to pre-populate the new virtual disk object with block data from an existing disk. This path may refer to a virtual
			/// disk or a physical disk. If this parameter is not NULL, ParentPath must be NULL.
			/// </summary>
			public IntPtr SourcePath;

			/// <summary>Zero or more flags from the OPEN_VIRTUAL_DISK_FLAG enumeration describing how the virtual disk is to be opened.</summary>
			public OPEN_VIRTUAL_DISK_FLAG OpenFlags;

			/// <summary>A VIRTUAL_STORAGE_TYPE structure describing the parent virtual disk specified in the ParentPath member.</summary>
			public VIRTUAL_STORAGE_TYPE ParentVirtualStorageType;

			/// <summary>A VIRTUAL_STORAGE_TYPE structure describing the source virtual disk specified in the SourcePath member.</summary>
			public VIRTUAL_STORAGE_TYPE SourceVirtualStorageType;

			/// <summary>Resiliency GUID for the file.</summary>
			public Guid ResiliencyGuid;
		}

		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct CREATE_VIRTUAL_DISK_PARAMETERS_Version3
		{
			/// <summary>Unique identifier to assign to the virtual disk object. If this member is set to zero, a unique identifier is created by the system.</summary>
			public Guid UniqueId;

			/// <summary>
			/// The maximum virtual size of the virtual disk object. Must be a multiple of 512. If a ParentPath is specified, this value must be zero. If a
			/// SourcePath is specified, this value can be zero to specify the size of the source VHD to be used, otherwise the size specified must be greater
			/// than or equal to the size of the source disk.
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// Internal size of the virtual disk object blocks. If value is 0, block size will be automatically matched to the parent or source disk's setting
			/// if ParentPath or SourcePath is specified (otherwise a block size of 2MB will be used).
			/// </summary>
			public uint BlockSizeInBytes;

			/// <summary>Internal size of the virtual disk object sectors. Must be set to 512.</summary>
			public uint SectorSizeInBytes;

			/// <summary>Size of the physical disk object sectors.</summary>
			public uint PhysicalSectorSizeInBytes;

			/// <summary>
			/// Optional path to a parent virtual disk object. Associates the new virtual disk with an existing virtual disk. If this parameter is not NULL,
			/// SourcePath must be NULL.
			/// </summary>
			public IntPtr ParentPath;

			/// <summary>
			/// Optional fully qualified path to pre-populate the new virtual disk object with block data from an existing disk. This path may refer to a virtual
			/// disk or a physical disk. If this parameter is not NULL, ParentPath must be NULL.
			/// </summary>
			public IntPtr SourcePath;

			/// <summary>Zero or more flags from the OPEN_VIRTUAL_DISK_FLAG enumeration describing how the virtual disk is to be opened.</summary>
			public OPEN_VIRTUAL_DISK_FLAG OpenFlags;

			/// <summary>A VIRTUAL_STORAGE_TYPE structure describing the parent virtual disk specified in the ParentPath member.</summary>
			public VIRTUAL_STORAGE_TYPE ParentVirtualStorageType;

			/// <summary>A VIRTUAL_STORAGE_TYPE structure describing the source virtual disk specified in the SourcePath member.</summary>
			public VIRTUAL_STORAGE_TYPE SourceVirtualStorageType;

			/// <summary>Resiliency GUID for the file.</summary>
			public Guid ResiliencyGuid;

			/// <summary></summary>
			public IntPtr SourceLimitPath;

			/// <summary></summary>
			public VIRTUAL_STORAGE_TYPE BackingStorageType;
		}

		/// <summary>Contains snapshot deletion parameters, designating which snapshot to delete from the VHD Set.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct DELETE_SNAPSHOT_VHDSET_PARAMETERS
		{
			/// <summary>A value from the DELETE_SNAPSHOT_VHDSET_VERSION enumeration that is the discriminant for the union.</summary>
			public DELETE_SNAPSHOT_VHDSET_VERSION Version;
			/// <summary>A structure with the following member.</summary>
			public DELETE_SNAPSHOT_VHDSET_PARAMETERS_Version1 Version1;
		}

		/// <summary>A structure with the following member.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct DELETE_SNAPSHOT_VHDSET_PARAMETERS_Version1
		{
			/// <summary>The Snapshot Id in GUID format indicating which snapshot is to be deleted from the VHD Set.</summary>
			public Guid SnapshotId;
		}

		/// <summary>Contains virtual disk expansion request parameters.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct EXPAND_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>
			/// An EXPAND_VIRTUAL_DISK_VERSION enumeration that specifies the version of the EXPAND_VIRTUAL_DISK_PARAMETERS structure being passed to or from the
			/// virtual hard disk (VHD) functions.
			/// </summary>
			public EXPAND_VIRTUAL_DISK_VERSION Version;

			/// <summary>New size, in bytes, for the expansion request.</summary>
			public EXPAND_VIRTUAL_DISK_PARAMETERS_Version1 Version1;

			/// <summary>Initializes with default version and <paramref name="newSize"/>.</summary>
			/// <param name="newSize">New size, in bytes, for the expansion request.</param>
			public EXPAND_VIRTUAL_DISK_PARAMETERS(ulong newSize)
			{
				Version = EXPAND_VIRTUAL_DISK_VERSION.EXPAND_VIRTUAL_DISK_VERSION_1;
				Version1.NewSize = newSize;
			}
		}

		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct EXPAND_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>New size, in bytes, for the expansion request.</summary>
			public ulong NewSize;
		}

		/// <summary>Contains virtual hard disk (VHD) information.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct GET_VIRTUAL_DISK_INFO
		{
			/// <summary>
			/// A GET_VIRTUAL_DISK_INFO_VERSION enumeration that specifies the version of the GET_VIRTUAL_DISK_INFO structure being passed to or from the VHD
			/// functions. This determines what parts of this structure will be used.
			/// </summary>
			[FieldOffset(0)]
			public GET_VIRTUAL_DISK_INFO_VERSION Version;

			/// <summary></summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			public GET_VIRTUAL_DISK_INFO_Size Size;

			/// <summary>Unique identifier of the VHD.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			public Guid Identifier;

			/// <summary>A structure with the following members</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			public GET_VIRTUAL_DISK_INFO_ParentLocation ParentLocation;

			/// <summary>Unique identifier of the parent disk backing store.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			public Guid ParentIdentifier;

			/// <summary>Internal time stamp of the parent disk backing store.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			public uint ParentTimestamp;

			/// <summary>VIRTUAL_STORAGE_TYPE structure containing information about the type of VHD.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			public VIRTUAL_STORAGE_TYPE VirtualStorageType;

			/// <summary>Provider-specific subtype.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			public VIRTUAL_DISK_INFO_PROVIDER_SUBTYPE ProviderSubtype;

			/// <summary>Indicates whether the virtual disk is 4 KB aligned.</summary>
			[FieldOffset(8), MarshalAs(UnmanagedType.Bool), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
			public bool Is4kAligned;

			/// <summary>Indicates whether the virtual disk is currently mounted and in use. TRUE if the virtual disk is currently mounted and in use; otherwise FALSE.</summary>
			[FieldOffset(8), MarshalAs(UnmanagedType.Bool), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows81)]
			public bool IsLoaded;

			/// <summary>Details about the physical disk on which the virtual disk resides.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
			public GET_VIRTUAL_DISK_INFO_PhysicalDisk PhysicalDisk;

			/// <summary>The physical sector size of the virtual disk.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
			public uint VhdPhysicalSectorSize;

			/// <summary>The smallest safe minimum size of the virtual disk.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
			public ulong SmallestSafeVirtualSize;

			/// <summary>The fragmentation level of the virtual disk.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
			public uint FragmentationPercentage;

			/// <summary>The identifier that is uniquely created when a user first creates the virtual disk to attempt to uniquely identify that virtual disk.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows81)]
			public Guid VirtualDiskId;

			/// <summary>The state of resilient change tracking (RCT) for the virtual disk.</summary>
			[FieldOffset(8), PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
			public GET_VIRTUAL_DISK_INFO_ChangeTrackingState ChangeTrackingState;
		}

		/// <summary>The state of resilient change tracking (RCT) for the virtual disk.
		/// <note type="warning">While this structure will fill, the value of MostRecentId will the be first character of a truncated string.</note>
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GET_VIRTUAL_DISK_INFO_ChangeTrackingState
		{
			/// <summary>Whether RCT is turned on. TRUE if RCT is turned on; otherwise FALSE.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool Enabled;

			/// <summary>Whether the virtual disk has changed since the change identified by the MostRecentId member occurred. TRUE if the virtual disk has changed since the change identified by the MostRecentId member occurred; otherwise FALSE.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool NewerChanges;

			/// <summary>The change tracking identifier for the change that identifies the state of the virtual disk that you want to use as the basis of comparison to determine whether the NewerChanges member reports new changes.</summary>
			public IntPtr MostRecentId;
		}

		/// <summary>A structure with the following members
		/// <note type="warning">While this structure will fill, the value of ParentLocationBuffer will the be first character of a truncated string.</note>
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct GET_VIRTUAL_DISK_INFO_ParentLocation
		{
			/// <summary>Parent resolution. TRUE if the parent backing store was successfully resolved, FALSE if not.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool ParentResolved;

			/// <summary>
			/// If the ParentResolved member is TRUE, contains the path of the parent backing store. If the ParentResolved member is FALSE, contains all of the
			/// parent paths present in the search list.
			/// </summary>
			public IntPtr ParentLocationBuffer;
		}

		/// <summary>Details about the physical disk on which the virtual disk resides.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct GET_VIRTUAL_DISK_INFO_PhysicalDisk
		{
			/// <summary>The logical sector size of the physical disk.</summary>
			public uint LogicalSectorSize;

			/// <summary>The physical sector size of the physical disk.</summary>
			public uint PhysicalSectorSize;

			/// <summary>Indicates whether the physical disk is remote.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool IsRemote;
		}

		/// <summary>Sizes of the virtual disk.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		public struct GET_VIRTUAL_DISK_INFO_Size
		{
			/// <summary>Virtual size of the VHD, in bytes.</summary>
			public ulong VirtualSize;

			/// <summary>Physical size of the VHD on disk, in bytes.</summary>
			public ulong PhysicalSize;

			/// <summary>Block size of the VHD, in bytes.</summary>
			public uint BlockSize;

			/// <summary>Sector size of the VHD, in bytes.</summary>
			public uint SectorSize;
		}

		/// <summary>Contains virtual disk merge request parameters.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Explicit)]
		public struct MERGE_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>
			/// A MERGE_VIRTUAL_DISK_VERSION enumeration that specifies the version of the MERGE_VIRTUAL_DISK_PARAMETERS structure being passed to or from the
			/// VHD functions.
			/// </summary>
			[FieldOffset(0)]
			public MERGE_VIRTUAL_DISK_VERSION Version;

			/// <summary>This structure is used when the Version member is MERGE_VIRTUAL_DISK_VERSION_1 (1).</summary>
			[FieldOffset(4)]
			public MERGE_VIRTUAL_DISK_PARAMETERS_V1 Version1;

			/// <summary>This structure is used when the Version member is MERGE_VIRTUAL_DISK_VERSION_2 (2).</summary>
			[FieldOffset(4)]
			public MERGE_VIRTUAL_DISK_PARAMETERS_V2 Version2;

			public MERGE_VIRTUAL_DISK_PARAMETERS(uint mergeDepth) : this()
			{
				Version = MERGE_VIRTUAL_DISK_VERSION.MERGE_VIRTUAL_DISK_VERSION_1;
				Version1.MergeDepth = mergeDepth;
			}

			public MERGE_VIRTUAL_DISK_PARAMETERS(uint mergeSourceDepth, uint mergeTargetDepth) : this()
			{
				Version = MERGE_VIRTUAL_DISK_VERSION.MERGE_VIRTUAL_DISK_VERSION_2;
				Version2.MergeSourceDepth = mergeSourceDepth;
				Version2.MergeTargetDepth = mergeTargetDepth;
			}
		}

		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct MERGE_VIRTUAL_DISK_PARAMETERS_V1
		{
			/// <summary>
			/// Depth of the merge request. This is the number of parent disks in the differencing chain to merge together.
			/// <note type="note">The RWDepth of the virtual disk must be greater than MergeDepth. For more information, see OPEN_VIRTUAL_DISK_PARAMETERS.</note>
			/// </summary>
			public uint MergeDepth;
		}

		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential)]
		public struct MERGE_VIRTUAL_DISK_PARAMETERS_V2
		{
			/// <summary>Depth from the leaf from which to begin the merge. The leaf is at depth 1.</summary>
			public uint MergeSourceDepth;

			/// <summary>Depth from the leaf to target the merge. The leaf is at depth 1.</summary>
			public uint MergeTargetDepth;
		}

		/// <summary>Contains virtual hard disk (VHD) mirror request parameters.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "hh448680", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MIRROR_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>Indicates the version of this structure to use. Set this to MIRROR_VIRTUAL_DISK_VERSION_1 (1).</summary>
			public MIRROR_VIRTUAL_DISK_VERSION Version;

			/// <summary>This structure is used if the Version member is set to MIRROR_VIRTUAL_DISK_VERSION_1.</summary>
			public MIRROR_VIRTUAL_DISK_PARAMETERS_Version1 Version1;
		}

		/// <summary>This structure is used if the Version member is set to MIRROR_VIRTUAL_DISK_VERSION_1.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "hh448680", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct MIRROR_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>
			/// Fully qualified path where the mirrored virtual disk will be located. If the Flags parameter to MirrorVirtualDisk is
			/// MIRROR_VIRTUAL_DISK_FLAG_NONE (0) then this file must not exist. If the Flags parameter to MirrorVirtualDisk is
			/// MIRROR_VIRTUAL_DISK_FLAG_EXISTING_FILE (1) then this file must exist.
			/// </summary>
			public IntPtr MirrorVirtualDiskPath;
		}

		/// <summary>
		/// Contains VHD Set modification parameters, indicating how the VHD Set should be altered.
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct MODIFY_VHDSET_PARAMETERS
		{
			/// <summary>A value from the MODIFY_VHDSET_VERSION enumeration that determines that is the discriminant for the union.</summary>
			public MODIFY_VHDSET_VERSION Version;

			/// <summary>A structure with the following members.</summary>
			public MODIFY_VHDSET_PARAMETERS_Version1 Version1;
		}

		/// <summary>
		/// A structure with the following members.
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Explicit)]
		public struct MODIFY_VHDSET_PARAMETERS_Version1
		{
			/// <summary>The snapshot path</summary>
			[FieldOffset(0)]
			public MODIFY_VHDSET_PARAMETERS_Version1_SnapshotPath SnapshotPath;
			/// <summary>The Snapshot Id in GUID format indicating which snapshot is to be removed from the VHD Set file.</summary>
			[FieldOffset(0)]
			public Guid SnapshotId;
			/// <summary>The file path for the default Snapshot of the Vhd Set.</summary>
			[FieldOffset(0)]
			[MarshalAs(UnmanagedType.LPWStr)]
			public string DefaultFilePath;
		}

		/// <summary>
		/// A structure with the following members.
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct MODIFY_VHDSET_PARAMETERS_Version1_SnapshotPath
		{
			/// <summary>The Snapshot Id in GUID format indicating which snapshot is to have its path altered in the VHD Set.</summary>
			public Guid SnapshotId;
			/// <summary>The new file path for the Snapshot indicated by the SnapshotId field.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string SnapshotFilePath;
		}

		/// <summary>Contains virtual disk open request parameters.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Explicit)]
		public class OPEN_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>
			/// An OPEN_VIRTUAL_DISK_VERSION enumeration that specifies the version of the OPEN_VIRTUAL_DISK_PARAMETERS structure being passed to or from the VHD functions.
			/// </summary>
			[FieldOffset(0)]
			public OPEN_VIRTUAL_DISK_VERSION Version;

			/// <summary>This structure is used if the Version member is OPEN_VIRTUAL_DISK_VERSION_1 (1).</summary>
			[FieldOffset(8)]
			public OPEN_VIRTUAL_DISK_PARAMETERS_Version1 Version1;

			/// <summary>This structure is used if the Version member is OPEN_VIRTUAL_DISK_VERSION_2 (2).</summary>
			[FieldOffset(8)]
			public OPEN_VIRTUAL_DISK_PARAMETERS_Version2 Version2;

			/// <summary>This structure is used if the Version member is OPEN_VIRTUAL_DISK_VERSION_3 (3).</summary>
			[FieldOffset(8)]
			public OPEN_VIRTUAL_DISK_PARAMETERS_Version3 Version3;

			/// <summary>Initializes a new instance of the <see cref="OPEN_VIRTUAL_DISK_PARAMETERS"/> struct setting Version to OPEN_VIRTUAL_DISK_VERSION_1.</summary>
			/// <param name="rwDepth">
			/// <para>
			/// Indicates the number of stores, beginning with the child, of the backing store chain to open as read/write. The remaining stores in the
			/// differencing chain will be opened read-only. This is necessary for merge operations to succeed.
			/// </para>
			/// <list type="table">
			/// <listheader><term>Value</term><term>Meaning</term></listheader>
			/// <item><term>0</term><term>Do not open for read/write at any depth. This value should be used for read-only operations.</term></item>
			/// <item><term>OPEN_VIRTUAL_DISK_RW_DEPTH_DEFAULT (1)</term><term>Default value to use if no other value is desired.</term></item>
			/// <item><term>n (user-defined)</term><term>This integer value should be the number of merge levels plus one, if a merge operation is intended.</term></item>
			/// </list>
			/// </param>
			public OPEN_VIRTUAL_DISK_PARAMETERS(uint rwDepth)
			{
				Version = OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_1;
				Version1.RWDepth = rwDepth;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="OPEN_VIRTUAL_DISK_PARAMETERS"/> struct setting Version to OPEN_VIRTUAL_DISK_VERSION_2.
			/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This constructor is not supported until Windows 8 and Windows Server 2012.</para>
			/// </summary>
			/// <param name="readOnly">If TRUE, indicates the file backing store is to be opened as read-only.</param>
			/// <param name="getInfoOnly">If TRUE, indicates the handle is only to be used to get information on the virtual disk.</param>
			/// <param name="resiliencyGuid">Resiliency GUID to specify when opening files.</param>
			public OPEN_VIRTUAL_DISK_PARAMETERS(bool readOnly, bool getInfoOnly = false, Guid resiliencyGuid = default(Guid))
			{
				if (Environment.OSVersion.Version < new Version(6, 2))
					throw new InvalidOperationException();
				Version = OPEN_VIRTUAL_DISK_VERSION.OPEN_VIRTUAL_DISK_VERSION_2;
				Version2.GetInfoOnly = getInfoOnly;
				Version2.ReadOnly = readOnly;
				Version2.ResiliencyGuid = resiliencyGuid;
			}

			/// <summary>Gets the default value for this structure. This is currently the only valid value for <see cref="ATTACH_VIRTUAL_DISK_PARAMETERS"/>.</summary>
			public static OPEN_VIRTUAL_DISK_PARAMETERS DefaultV2 => new OPEN_VIRTUAL_DISK_PARAMETERS(false);

			/// <inheritdoc/>
			public override string ToString()
			{
				var v = (int)Version;
				return $"v{v}," + (v == 1 ? $"RWDepth={Version1.RWDepth}" : $"RO={Version2.ReadOnly},GetInfo={Version2.GetInfoOnly},RID={Version2.ResiliencyGuid}");
			}
		}

		/// <summary>This value is used if the Version member is OPEN_VIRTUAL_DISK_VERSION_1 (1).</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct OPEN_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>
			/// Indicates the number of stores, beginning with the child, of the backing store chain to open as read/write. The remaining stores in the
			/// differencing chain will be opened read-only. This is necessary for merge operations to succeed.
			/// <list type="table">
			/// <listheader><term>Value</term><term>Meaning</term></listheader>
			/// <item><term>0</term><term>Do not open for read/write at any depth. This value should be used for read-only operations.</term></item>
			/// <item><term>OPEN_VIRTUAL_DISK_RW_DEPTH_DEFAULT (1)</term><term>Default value to use if no other value is desired.</term></item>
			/// <item><term>n (user-defined)</term><term>This integer value should be the number of merge levels plus one, if a merge operation is intended.</term></item>
			/// </list>
			/// </summary>
			public uint RWDepth;
		}

		/// <summary>
		/// This value is used if the Version member is OPEN_VIRTUAL_DISK_VERSION_2 (2).
		/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This structure is not supported until Windows 8 and Windows Server 2012.</para>
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential)]
		public struct OPEN_VIRTUAL_DISK_PARAMETERS_Version2
		{
			/// <summary>If TRUE, indicates the handle is only to be used to get information on the virtual disk.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool GetInfoOnly;

			/// <summary>If TRUE, indicates the file backing store is to be opened as read-only.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool ReadOnly;

			/// <summary>Resiliency GUID to specify when opening files.</summary>
			public Guid ResiliencyGuid;
		}

		/// <summary>
		/// This value is used if the Version member is OPEN_VIRTUAL_DISK_VERSION_3 (3).
		/// <para><c>Windows 7 and Windows Server 2008 R2:</c> This structure is not supported until Windows 8 and Windows Server 2012.</para>
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct OPEN_VIRTUAL_DISK_PARAMETERS_Version3
		{
			/// <summary>If TRUE, indicates the handle is only to be used to get information on the virtual disk.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool GetInfoOnly;

			/// <summary>If TRUE, indicates the file backing store is to be opened as read-only.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool ReadOnly;

			/// <summary>Resiliency GUID to specify when opening files.</summary>
			public Guid ResiliencyGuid;

			/// <summary></summary>
			public Guid SnapshotId;
		}

		/// <summary>Identifies an area on a virtual hard disk (VHD) that has changed as tracked by resilient change tracking (RCT).</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct QUERY_CHANGES_VIRTUAL_DISK_RANGE
		{
			/// <summary>The distance from the start of the virtual disk to the beginning of the area of the virtual disk that has changed, in bytes.</summary>
			public ulong ByteOffset;
			/// <summary>The length of the area of the virtual disk that has changed, in bytes.</summary>
			public ulong ByteLength;
			/// <summary>Reserved.</summary>
			public ulong Reserved;
		}

		/// <summary>Contains raw SCSI virtual disk request parameters.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct RAW_SCSI_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>A RAW_SCSI_VIRTUAL_DISK_VERSION enumeration that specifies the version of the RAW_SCSI_VIRTUAL_DISK_PARAMETERS structure being passed to or from the VHD functions.</summary>
			public RAW_SCSI_VIRTUAL_DISK_VERSION Version;
			/// <summary>A structure with the following members.</summary>
			public RAW_SCSI_VIRTUAL_DISK_PARAMETERS_Version1 Version1;
		}

		/// <summary>A structure with the following members.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct RAW_SCSI_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>If TRUE, indicates the operation will be transported to the virtual disk using the RSVD protocol.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool RSVDHandle;
			/// <summary>If TRUE, indicates the SCSI command will read data from the DataBuffer. If FALSE, indicates data may be written.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool DataIn;
			/// <summary>Length, in bytes, of the command descriptor block (CDB) contained in the CDB member.</summary>
			public byte CdbLength;
			/// <summary>Length, in bytes, of the sense buffer.</summary>
			public byte SenseInfoLength;
			/// <summary>Caller-supplied SRB_FLAGS-prefixed bit flag specifying the requested operation. Flags are defined in srb.h.</summary>
			public byte SrbFlags;
			/// <summary>Length, in bytes, of the buffer to be transferred.</summary>
			public uint DataTransferLength;
			/// <summary>A pointer to the SCSI data buffer.</summary>
			public IntPtr DataBuffer;
			/// <summary>A pointer to a buffer to receive SCSI sense info after completion of the command.</summary>
			public IntPtr SenseInfo;
			/// <summary>Caller-supplied CDB data. (The CDB structure is declared in scsi.h.)</summary>
			public IntPtr Cdb;
		}

		/// <summary>
		/// Contains raw SCSI virtual disk response parameters.
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct RAW_SCSI_VIRTUAL_DISK_RESPONSE
		{
			/// <summary>A RAW_SCSI_VIRTUAL_DISK_VERSION enumeration that specifies the version of the RAW_SCSI_VIRTUAL_DISK_PARAMETERS structure being passed to or from the VHD functions.</summary>
			public RAW_SCSI_VIRTUAL_DISK_VERSION Version;
			/// <summary>A structure with the following member.</summary>
			public RAW_SCSI_VIRTUAL_DISK_RESPONSE_Version1 Version1;
		}

		/// <summary>
		/// A structure with the following member.
		/// </summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct RAW_SCSI_VIRTUAL_DISK_RESPONSE_Version1
		{
			/// <summary>A SRB_STATUS-prefixed status value (defined in srb.h).</summary>
			public byte ScsiStatus;
			/// <summary>Length, in bytes, of the sense buffer.</summary>
			public byte SenseInfoLength;
			/// <summary>Length, in bytes, of the buffer to be transferred.</summary>
			public uint DataTransferLength;
		}

		/// <summary>Contains the parameters for a ResizeVirtualDisk function.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential)]
		public struct RESIZE_VIRTUAL_DISK_PARAMETERS
		{
			/// <summary>
			/// Discriminant for the union containing a value enumerated from the RESIZE_VIRTUAL_DISK_VERSION enumeration.
			/// </summary>
			public RESIZE_VIRTUAL_DISK_VERSION Version;

			/// <summary>If the Version member is RESIZE_VIRTUAL_DISK_VERSION_1 (1), this structure is used.</summary>
			public RESIZE_VIRTUAL_DISK_PARAMETERS_Version1 Version1;

			/// <summary>Initializes with default version and <paramref name="newSize"/>.</summary>
			/// <param name="newSize">Contains the new size of the virtual disk.</param>
			public RESIZE_VIRTUAL_DISK_PARAMETERS(ulong newSize)
			{
				Version = RESIZE_VIRTUAL_DISK_VERSION.RESIZE_VIRTUAL_DISK_VERSION_1;
				Version1.NewSize = newSize;
			}
		}

		/// <summary>If the Version member is RESIZE_VIRTUAL_DISK_VERSION_1 (1), this structure is used.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential)]
		public struct RESIZE_VIRTUAL_DISK_PARAMETERS_Version1
		{
			/// <summary>Contains the new size of the virtual disk.</summary>
			public ulong NewSize;
		}

		/// <summary>Contains virtual hard disk (VHD) information for set request.</summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323686", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
		public struct SET_VIRTUAL_DISK_INFO
		{
			/// <summary>
			/// A SET_VIRTUAL_DISK_INFO_VERSION enumeration that specifies the version of the SET_VIRTUAL_DISK_INFO structure being passed to or from the VHD
			/// functions. This determines the type of information set.
			/// </summary>
			[FieldOffset(0)] public SET_VIRTUAL_DISK_INFO_VERSION Version;

			/// <summary>Path to the parent backing store.</summary>
			[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			[FieldOffset(8)] public string ParentFilePath;

			/// <summary>Unique identifier of the VHD.</summary>
			[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
			[FieldOffset(8)] public Guid UniqueIdentifier;

			/// <summary>Sets the parent file path and the child depth.</summary>
			[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
			[FieldOffset(8)] public SET_VIRTUAL_DISK_INFO_ParentPathWithDepthInfo ParentPathWithDepthInfo;

			/// <summary>Sets the physical sector size reported by the VHD.</summary>
			[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows8)]
			[FieldOffset(8)] public uint VhdPhysicalSectorSize;

			/// <summary>The identifier that is uniquely created when a user first creates the virtual disk to attempt to uniquely identify that virtual disk.</summary>
			[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows81)]
			[FieldOffset(8)] public Guid VirtualDiskId;

			/// <summary>Turns resilient change tracking (RCT) on or off for the VHD. TRUE turns RCT on. FALSE turns RCT off.</summary>
			[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
			[FieldOffset(8), MarshalAs(UnmanagedType.Bool)] public bool ChangeTrackingEnabled;

			/// <summary>Sets the parent linkage information that differencing VHDs store. Parent linkage information is metadata used to locate and correctly identify the next parent in the virtual disk chain.</summary>
			[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
			[FieldOffset(8)] public SET_VIRTUAL_DISK_INFO_ParentLocator ParentLocator;
		}

		/// <summary>
		/// Sets the parent file path and the child depth.
		/// </summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323686", MinClient = PInvokeClient.Windows8)]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SET_VIRTUAL_DISK_INFO_ParentPathWithDepthInfo
		{
			/// <summary>Specifies the depth to the child from the leaf. The leaf itself is at depth 1.</summary>
			public uint ChildDepth;

			/// <summary>Specifies the depth to the parent from the leaf. The leaf itself is at depth 1.</summary>
			public IntPtr ParentFilePath;
		}

		/// <summary>
		/// Sets the parent linkage information that differencing VHDs store. Parent linkage information is metadata used to locate and correctly identify the next parent in the virtual disk chain.
		/// </summary>
		[PInvokeData("VirtDisk.h", MSDNShortId = "dd323686", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct SET_VIRTUAL_DISK_INFO_ParentLocator
		{
			/// <summary>The unique identifier for the parent linkage information.</summary>
			public Guid LinkageId;

			/// <summary>The path of the file for the parent VHD.</summary>
			public IntPtr ParentFilePath;
		}

		/// <summary>Contains storage dependency information.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct STORAGE_DEPENDENCY_INFO
		{
			/// <summary>
			/// A STORAGE_DEPENDENCY_INFO_VERSION enumeration that specifies the version of the information structure being passed to or from the VHD functions.
			/// Can be STORAGE_DEPENDENCY_INFO_TYPE_1 or STORAGE_DEPENDENCY_INFO_TYPE_2.
			/// </summary>
			public STORAGE_DEPENDENCY_INFO_VERSION Version;

			/// <summary>Number of entries returned in the following unioned members.</summary>
			public int NumberEntries;

			/// <summary>Variable-length array containing STORAGE_DEPENDENCY_INFO_TYPE_1 or STORAGE_DEPENDENCY_INFO_TYPE_2 structures.</summary>
			public IntPtr Entries;
		}

		/// <summary>Contains storage dependency information for type 1.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct STORAGE_DEPENDENCY_INFO_TYPE_1
		{
			/// <summary>A DEPENDENT_DISK_FLAG enumeration.</summary>
			public DEPENDENT_DISK_FLAG DependencyTypeFlags;

			/// <summary>Flags specific to the VHD provider.</summary>
			public uint ProviderSpecificFlags;

			/// <summary>A VIRTUAL_STORAGE_TYPE structure.</summary>
			public VIRTUAL_STORAGE_TYPE VirtualStorageType;
		}

		/// <summary>Contains storage dependency information for type 2.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STORAGE_DEPENDENCY_INFO_TYPE_2
		{
			/// <summary>A DEPENDENT_DISK_FLAG enumeration.</summary>
			public DEPENDENT_DISK_FLAG DependencyTypeFlags;

			/// <summary>Flags specific to the VHD provider.</summary>
			public uint ProviderSpecificFlags;

			/// <summary>A VIRTUAL_STORAGE_TYPE structure.</summary>
			public VIRTUAL_STORAGE_TYPE VirtualStorageType;

			/// <summary>The ancestor level.</summary>
			public uint AncestorLevel;

			/// <summary>The device name of the dependent device.</summary>
			public string DependencyDeviceName;

			/// <summary>The host disk volume name.</summary>
			public string HostVolumeName;

			/// <summary>The name of the dependent volume, if any.</summary>
			public string DependentVolumeName;

			/// <summary>The relative path to the dependent volume.</summary>
			public string DependentVolumeRelativePath;
		}

		/// <summary>Contains snapshot parameters, indicating information about the new snapshot to be created.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct TAKE_SNAPSHOT_VHDSET_PARAMETERS
		{
			/// <summary>A value from the TAKE_SNAPSHOT_VHDSET_VERSION enumeration that is the discriminant for the union.</summary>
			public TAKE_SNAPSHOT_VHDSET_VERSION Version;

			/// <summary>A structure with the following member.</summary>
			public TAKE_SNAPSHOT_VHDSET_PARAMETERS_Version1 Version1;
		}

		/// <summary>A structure with the following member.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows10)]
		[StructLayout(LayoutKind.Sequential)]
		public struct TAKE_SNAPSHOT_VHDSET_PARAMETERS_Version1
		{
			/// <summary>The Id of the new Snapshot to be added to the Vhd Set.</summary>
			public Guid SnapshotId;
		}

		/// <summary>Contains the progress and result data for the current virtual disk operation, used by the GetVirtualDiskOperationProgress function.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct VIRTUAL_DISK_PROGRESS
		{
			/// <summary>
			/// A system error code status value, this member will be ERROR_IO_PENDING if the operation is still in progress; otherwise, the value is the result
			/// code of the completed operation.
			/// </summary>
			public uint OperationStatus;

			/// <summary>
			/// The current progress of the operation, used in conjunction with the CompletionValue member. This value is meaningful only if OperationStatus is ERROR_IO_PENDING.
			/// </summary>
			public ulong CurrentValue;

			/// <summary>
			/// The value that the CurrentValue member would be if the operation were complete. This value is meaningful only if OperationStatus is ERROR_IO_PENDING.
			/// </summary>
			public ulong CompletionValue;
		}

		/// <summary>Device type identifier.</summary>
		[PInvokeData("VirtDisk.h", MinClient = PInvokeClient.Windows7)]
		[StructLayout(LayoutKind.Sequential)]
		public struct VIRTUAL_STORAGE_TYPE
		{
			/// <summary>The device identifier.</summary>
			public VIRTUAL_STORAGE_TYPE_DEVICE_TYPE DeviceId;

			/// <summary>Vendor-unique identifier.</summary>
			public Guid VendorId;

			/// <summary>
			/// Initializes a new instance of <see cref="VIRTUAL_STORAGE_TYPE"/>.
			/// </summary>
			/// <param name="type">The type of disk to create.</param>
			/// <param name="vendorIsMicrosoft"><c>true</c> if <see cref="VendorId"/> is to be assigned VIRTUAL_STORAGE_TYPE_VENDOR_MICROSOFT.</param>
			public VIRTUAL_STORAGE_TYPE(VIRTUAL_STORAGE_TYPE_DEVICE_TYPE type, bool vendorIsMicrosoft = true)
			{
				DeviceId = type;
				VendorId = vendorIsMicrosoft ? VIRTUAL_STORAGE_TYPE_VENDOR_MICROSOFT : Guid.Empty;
			}

			/// <summary>Gets an instance of <see cref="VIRTUAL_STORAGE_TYPE"/> that represents a Microsoft Virtual Hard Drive or .vhd file.</summary>
			public static VIRTUAL_STORAGE_TYPE VHD => new VIRTUAL_STORAGE_TYPE(VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_VHD);
		}
	}
}