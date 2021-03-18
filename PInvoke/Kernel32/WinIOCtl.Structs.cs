using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>
		/// The data partition type that is created and recognized by Windows.
		/// <para>
		/// Only partitions of this type can be assigned drive letters, receive volume GUID paths, host mounted folders (also called volume
		/// mount points), and be enumerated by calls to FindFirstVolume and FindNextVolume.
		/// </para>
		/// <para>
		/// This value can be set only for basic disks, with one exception. If both PARTITION_BASIC_DATA_GUID and
		/// GPT_ATTRIBUTE_PLATFORM_REQUIRED are set for a partition on a basic disk that is subsequently converted to a dynamic disk, the
		/// partition remains a basic partition, even though the rest of the disk is a dynamic disk.This is because the partition is
		/// considered to be an OEM partition on a GPT disk.
		/// </para>
		/// </summary>
		public static readonly Guid PARTITION_BASIC_DATA_GUID = new Guid(0xEBD0A0A2, 0xB9E5, 0x4433, 0x87, 0xC0, 0x68, 0xB6, 0xB7, 0x26, 0x99, 0xC7);

		/// <summary>BSP partition</summary>
		public static readonly Guid PARTITION_BSP_GUID = new Guid(0x57434F53, 0x4DF9, 0x45B9, 0x8E, 0x9E, 0x23, 0x70, 0xF0, 0x06, 0x45, 0x7C);

		/// <summary>Cluster metadata partition</summary>
		public static readonly Guid PARTITION_CLUSTER_GUID = new Guid(0xDB97DBA9, 0x0840, 0x4BAE, 0x97, 0xF0, 0xFF, 0xB9, 0xA3, 0x27, 0xC7, 0xE1);

		/// <summary>DPP partition</summary>
		public static readonly Guid PARTITION_DPP_GUID = new Guid(0x57434F53, 0x94CB, 0x43F0, 0xA5, 0x33, 0xD7, 0x3C, 0x10, 0xCF, 0xA5, 0x7D);

		/// <summary>There is no partition. This value can be set for basic and dynamic disks.</summary>
		public static readonly Guid PARTITION_ENTRY_UNUSED_GUID = new Guid(0x00000000, 0x0000, 0x0000, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

		/// <summary>The partition is an LDM data partition on a dynamic disk. This value can be set only for dynamic disks.</summary>
		public static readonly Guid PARTITION_LDM_DATA_GUID = new Guid(0xAF9B60A0, 0x1431, 0x4F62, 0xBC, 0x68, 0x33, 0x11, 0x71, 0x4A, 0x69, 0xAD);

		/// <summary>
		/// The partition is a Logical Disk Manager (LDM) metadata partition on a dynamic disk. This value can be set only for dynamic disks.
		/// </summary>
		public static readonly Guid PARTITION_LDM_METADATA_GUID = new Guid(0x5808C8AA, 0x7E8F, 0x42E0, 0x85, 0xD2, 0xE1, 0xE9, 0x04, 0x34, 0xCF, 0xB3);

		/// <summary>Main OS partition</summary>
		public static readonly Guid PARTITION_MAIN_OS_GUID = new Guid(0x57434F53, 0x8F45, 0x405E, 0x8A, 0x23, 0x18, 0x6D, 0x8A, 0x43, 0x30, 0xD3);

		/// <summary>The partition is a Microsoft recovery partition. This value can be set for basic and dynamic disks.</summary>
		public static readonly Guid PARTITION_MSFT_RECOVERY_GUID = new Guid(0xDE94BBA4, 0x06D1, 0x4D40, 0xA1, 0x6A, 0xBF, 0xD5, 0x01, 0x79, 0xD6, 0xAC);

		/// <summary>The partition is a Microsoft reserved partition. This value can be set for basic and dynamic disks.</summary>
		public static readonly Guid PARTITION_MSFT_RESERVED_GUID = new Guid(0xE3C9E316, 0x0B5C, 0x4DB8, 0x81, 0x7D, 0xF9, 0x2D, 0xF0, 0x02, 0x15, 0xAE);

		/// <summary>Microsoft shadow copy partition</summary>
		public static readonly Guid PARTITION_MSFT_SNAPSHOT_GUID = new Guid(0xCADDEBF1, 0x4400, 0x4DE8, 0xB1, 0x03, 0x12, 0x11, 0x7D, 0xCF, 0x3C, 0xCF);

		/// <summary>OS data partition</summary>
		public static readonly Guid PARTITION_OS_DATA_GUID = new Guid(0x57434F53, 0x23F2, 0x44D5, 0xA8, 0x30, 0x67, 0xBB, 0xDA, 0xA6, 0x09, 0xF9);

		/// <summary>Patch partition</summary>
		public static readonly Guid PARTITION_PATCH_GUID = new Guid(0x8967A686, 0x96AA, 0x6AA8, 0x95, 0x89, 0xA8, 0x42, 0x56, 0x54, 0x10, 0x90);

		/// <summary>PreInstalled partition</summary>
		public static readonly Guid PARTITION_PRE_INSTALLED_GUID = new Guid(0x57434F53, 0x7FE0, 0x4196, 0x9B, 0x42, 0x42, 0x7B, 0x51, 0x64, 0x34, 0x84);

		/// <summary>Storage Spaces protective partition</summary>
		public static readonly Guid PARTITION_SPACES_DATA_GUID = new Guid(0xE7ADDCB4, 0xDC34, 0x4539, 0x9A, 0x76, 0xEB, 0xBD, 0x07, 0xBE, 0x6F, 0x7E);

		/// <summary>Storage Spaces protective partition</summary>
		public static readonly Guid PARTITION_SPACES_GUID = new Guid(0xE75CAF8F, 0xF680, 0x4CEE, 0xAF, 0xA3, 0xB0, 0x01, 0xE5, 0x6E, 0xFC, 0x2D);

		/// <summary>The partition is an EFI system partition. This value can be set for basic and dynamic disks.</summary>
		public static readonly Guid PARTITION_SYSTEM_GUID = new Guid(0xC12A7328, 0xF81F, 0x11D2, 0xBA, 0x4B, 0x00, 0xA0, 0xC9, 0x3E, 0xC9, 0x3B);

		/// <summary>Windows system partition</summary>
		public static readonly Guid PARTITION_WINDOWS_SYSTEM_GUID = new Guid(0x57434F53, 0xE3E3, 0x4631, 0xA5, 0xC5, 0x26, 0xD2, 0x24, 0x38, 0x73, 0xAA);

		/// <summary>Contains the output for the FSCTL_GET_BOOT_AREA_INFO control code.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-boot_area_info typedef struct _BOOT_AREA_INFO { DWORD
		// BootSectorCount; struct { LARGE_INTEGER Offset; } BootSectors[2]; } BOOT_AREA_INFO, *PBOOT_AREA_INFO;
		[PInvokeData("winioctl.h", MSDNShortId = "e6ec156d-6a20-4b00-89fb-a27421fffbc0")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct BOOT_AREA_INFO
		{
			/// <summary>Number of elements in the <c>BootSectors</c> array.</summary>
			public uint BootSectorCount;

			/// <summary>
			/// <para>A variable length array of structures each containing the following member.</para>
			/// <para>Offset</para>
			/// <para>The location of a boot sector or a copy of a boot sector.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
			public long[] BootSectors;
		}

		/// <summary>Represents a changer element.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_element typedef struct _CHANGER_ELEMENT {
		// ELEMENT_TYPE ElementType; DWORD ElementAddress; } CHANGER_ELEMENT, *PCHANGER_ELEMENT;
		[PInvokeData("winioctl.h", MSDNShortId = "96e9803b-16c4-415c-940a-f5df3edff3b3")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CHANGER_ELEMENT
		{
			/// <summary>The element type. This parameter can be one of the values from the ELEMENT_TYPE enumeration type.</summary>
			public ELEMENT_TYPE ElementType;

			/// <summary>The zero-based address of the element.</summary>
			public uint ElementAddress;
		}

		/// <summary>
		/// Represents a range of elements of a single type, typically for an operation such as getting or initializing the status of
		/// multiple elements.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_element_list typedef struct _CHANGER_ELEMENT_LIST
		// { CHANGER_ELEMENT Element; DWORD NumberOfElements; } CHANGER_ELEMENT_LIST, *PCHANGER_ELEMENT_LIST;
		[PInvokeData("winioctl.h", MSDNShortId = "cb1fcf78-b36a-4551-8eeb-da58edc80890")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CHANGER_ELEMENT_LIST
		{
			/// <summary>A CHANGER_ELEMENT structure that represent the first element in the range.</summary>
			public CHANGER_ELEMENT Element;

			/// <summary>The number of elements in the range.</summary>
			public uint NumberOfElements;
		}

		/// <summary>
		/// Contains information that the IOCTL_DISK_CREATE_DISK control code uses to initialize GUID partition table (GPT), master boot
		/// record (MBR), or raw disks.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-create_disk typedef struct _CREATE_DISK { PARTITION_STYLE
		// PartitionStyle; union { CREATE_DISK_MBR Mbr; CREATE_DISK_GPT Gpt; } DUMMYUNIONNAME; } CREATE_DISK, *PCREATE_DISK;
		[PInvokeData("winioctl.h", MSDNShortId = "ec4a1ef9-ff2e-41b3-951b-241c545f256b")]
		[StructLayout(LayoutKind.Explicit)]
		public struct CREATE_DISK
		{
			/// <summary>
			/// <para>The format of a partition.</para>
			/// <para>For more information, see PARTITION_STYLE.</para>
			/// </summary>
			[FieldOffset(0)]
			public PARTITION_STYLE PartitionStyle;

			/// <summary>A CREATE_DISK_MBR structure that contains disk information when an MBR disk is to be initialized.</summary>
			[FieldOffset(4)]
			public CREATE_DISK_MBR Mbr;

			/// <summary>A CREATE_DISK_GPT structure that contains disk information when a GPT disk is to be initialized.</summary>
			[FieldOffset(4)]
			public CREATE_DISK_GPT Gpt;
		}

		/// <summary>Contains information used by the IOCTL_DISK_CREATE_DISK control code to initialize GUID partition table (GPT) disks.</summary>
		/// <remarks>
		/// <para>The <c>CREATE_DISK_GPT</c> structure is defined as part of the CREATE_DISK structure.</para>
		/// <para>
		/// If a maximum partition count of less than 128 is specified, it will be reset to 128. This is in compliance with the EFI specification.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-create_disk_gpt typedef struct _CREATE_DISK_GPT { GUID
		// DiskId; DWORD MaxPartitionCount; } CREATE_DISK_GPT, *PCREATE_DISK_GPT;
		[PInvokeData("winioctl.h", MSDNShortId = "526a265b-e15e-4cd2-adaf-c955a8cb92e5")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CREATE_DISK_GPT
		{
			/// <summary>The disk identifier (GUID) of the GPT disk to be initialized.</summary>
			public Guid DiskId;

			/// <summary>The maximum number of partitions allowed on the GPT disk to be initialized without repartitioning the disk.</summary>
			public uint MaxPartitionCount;
		}

		/// <summary>Contains information that the IOCTL_DISK_CREATE_DISK control code uses to initialize master boot record (MBR) disks.</summary>
		/// <remarks>The <c>CREATE_DISK_MBR</c> structure is part of the CREATE_DISK structure.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-create_disk_mbr typedef struct _CREATE_DISK_MBR { DWORD
		// Signature; } CREATE_DISK_MBR, *PCREATE_DISK_MBR;
		[PInvokeData("winioctl.h", MSDNShortId = "6b475622-371d-4097-9de1-6ef31af76322")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CREATE_DISK_MBR
		{
			/// <summary>The disk signature of the MBR disk to be initialized.</summary>
			public uint Signature;
		}

		/// <summary>Contains information that describes an update sequence number (USN) change journal.</summary>
		/// <remarks>For more information, see Creating, Modifying, and Deleting a Change Journal.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-create_usn_journal_data typedef struct { DWORDLONG
		// MaximumSize; DWORDLONG AllocationDelta; } CREATE_USN_JOURNAL_DATA, *PCREATE_USN_JOURNAL_DATA;
		[PInvokeData("winioctl.h", MSDNShortId = "84d00427-c6eb-41aa-a594-8c57bdd56202")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CREATE_USN_JOURNAL_DATA
		{
			/// <summary>
			/// <para>The target maximum size that the NTFS file system allocates for the change journal, in bytes.</para>
			/// <para>
			/// The change journal can grow larger than this value, but it is then truncated at the next NTFS file system checkpoint to less
			/// than this value.
			/// </para>
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// <para>The size of memory allocation that is added to the end and removed from the beginning of the change journal, in bytes.</para>
			/// <para>
			/// The change journal can grow to more than the sum of the values of <c>MaximumSize</c> and <c>AllocationDelta</c> before being trimmed.
			/// </para>
			/// </summary>
			public ulong AllocationDelta;
		}

		/// <summary>
		/// Contains information on the deletion of an update sequence number (USN) change journal using the FSCTL_DELETE_USN_JOURNAL control code.
		/// </summary>
		/// <remarks>For more information, see Creating, Modifying, and Deleting a Change Journal.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-delete_usn_journal_data typedef struct { DWORDLONG
		// UsnJournalID; DWORD DeleteFlags; } DELETE_USN_JOURNAL_DATA, *PDELETE_USN_JOURNAL_DATA;
		[PInvokeData("winioctl.h", MSDNShortId = "06db4b46-fc91-40e0-ab0b-1e014622ae22")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DELETE_USN_JOURNAL_DATA
		{
			/// <summary>
			/// <para>The identifier of the change journal to be deleted.</para>
			/// <para>
			/// If the journal is active and deletion is requested by setting the USN_DELETE_FLAG_DELETE flag in the <c>DeleteFlags</c>
			/// member, then this identifier must specify the change journal for the current volume. Use FSCTL_QUERY_USN_JOURNAL to retrieve
			/// the identifier of this change journal. If in this case the identifier is not for the current volume's change journal,
			/// FSCTL_DELETE_USN_JOURNAL fails.
			/// </para>
			/// <para>
			/// If notification instead of deletion is requested by setting only the USN_DELETE_FLAG_NOTIFY flag in <c>DeleteFlags</c>,
			/// <c>UsnJournalID</c> is ignored.
			/// </para>
			/// </summary>
			public ulong UsnJournalID;

			/// <summary>
			/// <para>
			/// Indicates whether deletion or notification regarding deletion is performed, or both. The <c>DeleteFlags</c> member must
			/// contain one or both of the following values.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_DELETE_FLAG_DELETE 0x00000001</term>
			/// <term>
			/// If this flag is set and the USN_DELETE_FLAG_NOTIFY flag is not set, the FSCTL_DELETE_USN_JOURNAL operation starts the journal
			/// deletion process and returns immediately. The journal deletion process continues, if necessary, across system restarts. If
			/// this flag is set and the USN_DELETE_FLAG_NOTIFY flag is also set, both deletion and notification occur. If this flag is set
			/// and the journal is active, you must provide the identifier for the change journal for the current volume in UsnJournalID or
			/// the operation fails. If the journal is not active, then UsnJournalID is ignored and the journal is deleted.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_DELETE_FLAG_NOTIFY 0x00000002</term>
			/// <term>
			/// If this flag is set, the call sets up notification about when deletion is complete. The journal deletion request is completed
			/// when the journal deletion process is complete. If this flag is set and the USN_DELETE_FLAG_DELETE flag is not set, then the
			/// call sets up notification of a deletion that may already be in progress. For example, when your application starts, it might
			/// use this flag to determine if a deletion is in progress. If this flag is set and the USN_DELETE_FLAG_DELETE flag is also set,
			/// both deletion and notification occur. The notification is performed using an I/O completion port or another mechanism for
			/// asynchronous event notification.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public uint DeleteFlags;
		}

		/// <summary>
		/// Provides information about the disk cache.This structure is used by the IOCTL_DISK_GET_CACHE_INFORMATION and
		/// IOCTL_DISK_SET_CACHE_INFORMATION control codes.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_cache_information typedef struct
		// _DISK_CACHE_INFORMATION { BOOLEAN ParametersSavable; BOOLEAN ReadCacheEnabled; BOOLEAN WriteCacheEnabled;
		// DISK_CACHE_RETENTION_PRIORITY ReadRetentionPriority; DISK_CACHE_RETENTION_PRIORITY WriteRetentionPriority; WORD
		// DisablePrefetchTransferLength; BOOLEAN PrefetchScalar; union { struct { WORD Minimum; WORD Maximum; WORD MaximumBlocks; }
		// ScalarPrefetch; struct { WORD Minimum; WORD Maximum; } BlockPrefetch; } DUMMYUNIONNAME; } DISK_CACHE_INFORMATION, *PDISK_CACHE_INFORMATION;
		[PInvokeData("winioctl.h", MSDNShortId = "ea175bea-5f2b-4f3e-9fe0-239b1d2e3d96")]
		[StructLayout(LayoutKind.Sequential, Size = 24, Pack = 8)]
		public struct DISK_CACHE_INFORMATION
		{
			/// <summary>Indicates whether the device is capable of saving any parameters in nonvolatile storage.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool ParametersSavable;

			/// <summary>Indicates whether the read cache is enabled.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool ReadCacheEnabled;

			/// <summary>Indicates whether the write cache is enabled.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool WriteCacheEnabled;

			/// <summary>
			/// <para>
			/// Determines the likelihood of data cached from a read operation remaining in the cache. This data might be given a different
			/// priority than data cached under other circumstances, such as from a prefetch operation.
			/// </para>
			/// <para>This member can be one of the following values from the <c>DISK_CACHE_RETENTION_PRIORITY</c> enumeration type.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>EqualPriority 0</term>
			/// <term>No data is held in the cache on a preferential basis.</term>
			/// </item>
			/// <item>
			/// <term>KeepPrefetchedData 1</term>
			/// <term>A preference is to be given to prefetched data.</term>
			/// </item>
			/// <item>
			/// <term>KeepReadData 2</term>
			/// <term>A preference is to be given to data cached from a read operation.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DISK_CACHE_RETENTION_PRIORITY ReadRetentionPriority;

			/// <summary>
			/// Determines the likelihood of data cached from a write operation remaining in the cache. This data might be given a different
			/// priority than data cached under other circumstances, such as from a prefetch operation.
			/// </summary>
			public DISK_CACHE_RETENTION_PRIORITY WriteRetentionPriority;

			/// <summary>
			/// Disables prefetching. Prefetching might be disabled whenever the number of blocks requested exceeds the value in
			/// DisablePrefetchTransferLength. When zero, prefetching is disabled no matter what the size of the block request.
			/// </summary>
			public ushort DisablePrefetchTransferLength;

			/// <summary>
			/// If this member is <c>TRUE</c>, the union is a <c>ScalarPrefetch</c> structure. Otherwise, the union is a <c>BlockPrefetch</c> structure.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool PrefetchScalar;

			/// <summary>
			/// The scalar multiplier of the transfer length of the request, when <c>PrefetchScalar</c> is <c>TRUE</c>. When
			/// <c>PrefetchScalar</c> is <c>TRUE</c>, this value is multiplied by the transfer length to obtain the minimum amount of data
			/// that can be prefetched into the cache on a disk operation.
			/// <para>
			/// The minimum amount of data that can be prefetched into the cache on a disk operation, as an absolute number of disk blocks
			/// when PrefetchScalar is <see langword="false"/>.
			/// </para>
			/// </summary>
			public ushort Minimum;

			/// <summary>
			/// The scalar multiplier of the transfer length of the request when <c>PrefetchScalar</c> is <c>TRUE</c>. When
			/// <c>PrefetchScalar</c> is <c>TRUE</c>, this value is multiplied by the transfer length to obtain the maximum amount of data
			/// that can be prefetched into the cache on a disk operation.
			/// <para>
			/// The maximum amount of data that can be prefetched into the cache on a disk operation, as an absolute number of disk blocks
			/// when PrefetchScalar is <see langword="false"/>.
			/// </para>
			/// </summary>
			public ushort Maximum;

			/// <summary>The maximum number of blocks which can be prefetched when <c>PrefetchScalar</c> is <c>TRUE</c>.</summary>
			public ushort MaximumBlocks;
		}

		/// <summary>Contains detected drive parameters.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_detection_info typedef struct _DISK_DETECTION_INFO {
		// DWORD SizeOfDetectInfo; DETECTION_TYPE DetectionType; union { struct { DISK_INT13_INFO Int13; DISK_EX_INT13_INFO ExInt13; }
		// DUMMYSTRUCTNAME; } DUMMYUNIONNAME; } DISK_DETECTION_INFO, *PDISK_DETECTION_INFO;
		[PInvokeData("winioctl.h", MSDNShortId = "57ca68f4-f748-4bc4-90c3-13d545716d87")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISK_DETECTION_INFO
		{
			/// <summary>The size of the structure, in bytes.</summary>
			public uint SizeOfDetectInfo;

			/// <summary>
			/// <para>The detected partition type.</para>
			/// <para>This member can be one of the following values from the <c>DETECTION_TYPE</c> enumeration.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>DetectExInt13 2</term>
			/// <term>The disk has an extended Int13 partition.</term>
			/// </item>
			/// <item>
			/// <term>DetectInt13 1</term>
			/// <term>The disk has a standard Int13 partition.</term>
			/// </item>
			/// <item>
			/// <term>DetectNone 0</term>
			/// <term>The disk does not have an Int13 or an extended Int13 partition.</term>
			/// </item>
			/// </list>
			/// </summary>
			public DETECTION_TYPE DetectionType;

			/// <summary>If <c>DetectionType</c> is DetectInt13, the union is a DISK_INT13_INFO structure.</summary>
			public DISK_INT13_INFO Int13;

			/// <summary>If <c>DetectionType</c> is DetectExInt13, the union is a DISK_EX_INT13_INFO structure.</summary>
			public DISK_EX_INT13_INFO ExInt13;
		}

		/// <summary>Contains extended Int13 drive parameters.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_ex_int13_info typedef struct _DISK_EX_INT13_INFO {
		// WORD ExBufferSize; WORD ExFlags; DWORD ExCylinders; DWORD ExHeads; DWORD ExSectorsPerTrack; DWORD64 ExSectorsPerDrive; WORD
		// ExSectorSize; WORD ExReserved; } DISK_EX_INT13_INFO, *PDISK_EX_INT13_INFO;
		[PInvokeData("winioctl.h", MSDNShortId = "efde6ede-b921-4d1d-ab4a-b9f85ae6aea1")]
		[StructLayout(LayoutKind.Sequential, Pack = 8, Size = 32)]
		public struct DISK_EX_INT13_INFO
		{
			/// <summary>The size of the extended drive parameter buffer for this partition or disk. For valid values, see the BIOS documentation.</summary>
			public ushort ExBufferSize;

			/// <summary>The information flags for this partition or disk. For valid values, see the BIOS documentation.</summary>
			public ushort ExFlags;

			/// <summary>The number of cylinders per head. For valid values, see the BIOS documentation.</summary>
			public uint ExCylinders;

			/// <summary>The maximum number of heads for this hard disk. For valid values, see the BIOS documentation.</summary>
			public uint ExHeads;

			/// <summary>The number of sectors per track. For valid values, see the BIOS documentation.</summary>
			public uint ExSectorsPerTrack;

			/// <summary>The total number of sectors for this disk. For valid values, see the BIOS documentation.</summary>
			public ulong ExSectorsPerDrive;

			/// <summary>The sector size for this disk. For valid values, see the BIOS documentation.</summary>
			public ushort ExSectorSize;

			/// <summary>Reserved for future use.</summary>
			public ushort ExReserved;
		}

		/// <summary>Represents a disk extent.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_extent typedef struct _DISK_EXTENT { DWORD
		// DiskNumber; LARGE_INTEGER StartingOffset; LARGE_INTEGER ExtentLength; } DISK_EXTENT, *PDISK_EXTENT;
		[PInvokeData("winioctl.h", MSDNShortId = "1b8dc6fa-e60b-4490-b439-44c93b6f4ce5")]
		[StructLayout(LayoutKind.Sequential, Pack = 8, Size = 24)]
		public struct DISK_EXTENT
		{
			/// <summary>
			/// <para>The number of the disk that contains this extent.</para>
			/// <para>
			/// This is the same number that is used to construct the name of the disk, for example, the X in "\?\PhysicalDriveX" or "\?\HarddiskX".
			/// </para>
			/// </summary>
			public uint DiskNumber;

			/// <summary>The offset from the beginning of the disk to the extent, in bytes.</summary>
			public long StartingOffset;

			/// <summary>The number of bytes in this extent.</summary>
			public long ExtentLength;
		}

		/// <summary>Describes the geometry of disk devices and media.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_geometry typedef struct _DISK_GEOMETRY {
		// LARGE_INTEGER Cylinders; MEDIA_TYPE MediaType; DWORD TracksPerCylinder; DWORD SectorsPerTrack; DWORD BytesPerSector; }
		// DISK_GEOMETRY, *PDISK_GEOMETRY;
		[PInvokeData("winioctl.h", MSDNShortId = "5e5955b4-1319-42c9-9df8-9910c05dec69")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISK_GEOMETRY
		{
			/// <summary>The number of cylinders. See LARGE_INTEGER.</summary>
			public long Cylinders;

			/// <summary>The type of media. For a list of values, see MEDIA_TYPE.</summary>
			public MEDIA_TYPE MediaType;

			/// <summary>The number of tracks per cylinder.</summary>
			public uint TracksPerCylinder;

			/// <summary>The number of sectors per track.</summary>
			public uint SectorsPerTrack;

			/// <summary>The number of bytes per sector.</summary>
			public uint BytesPerSector;
		}

		/// <summary>Describes the extended geometry of disk devices and media.</summary>
		/// <remarks>
		/// <para>
		/// <c>DISK_GEOMETRY_EX</c> is a variable-length structure composed of a DISK_GEOMETRY structure followed by a DISK_PARTITION_INFO
		/// structure and a DISK_DETECTION_INFO structure. Because the detection information is not at a fixed location within the
		/// <c>DISK_GEOMETRY_EX</c> structure, use the following macro to access the <c>DISK_DETECTION_INFO</c> structure.
		/// </para>
		/// <para>Similarly, use the following macro to access the DISK_PARTITION_INFO structure.</para>
		/// <para>
		/// The information returned does not include the number of partitions nor the partition information contained in the
		/// PARTITION_INFORMATION structure. To obtain this information, use the IOCTL_DISK_GET_DRIVE_LAYOUT_EX control code.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_geometry_ex typedef struct _DISK_GEOMETRY_EX {
		// DISK_GEOMETRY Geometry; LARGE_INTEGER DiskSize; BYTE Data[1]; } DISK_GEOMETRY_EX, *PDISK_GEOMETRY_EX;
		[PInvokeData("winioctl.h", MSDNShortId = "2b8b2021-8650-452d-a975-54249620d72f")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct DISK_GEOMETRY_EX
		{
			/// <summary>A DISK_GEOMETRY structure.</summary>
			public DISK_GEOMETRY Geometry;

			/// <summary>The disk size, in bytes. See LARGE_INTEGER.</summary>
			public long DiskSize;

			/// <summary>Any additional data. For more information, see Remarks.</summary>
			public byte Data;
		}

		/// <summary>
		/// Contains information used to increase the size of a partition.This structure is used by the IOCTL_DISK_GROW_PARTITION control code.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_grow_partition typedef struct _DISK_GROW_PARTITION {
		// DWORD PartitionNumber; LARGE_INTEGER BytesToGrow; } DISK_GROW_PARTITION, *PDISK_GROW_PARTITION;
		[PInvokeData("winioctl.h", MSDNShortId = "17ff8bbb-45a6-4ddd-a871-8519500c03a9")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct DISK_GROW_PARTITION
		{
			/// <summary>The identifier of the partition to be enlarged.</summary>
			public uint PartitionNumber;

			/// <summary>
			/// The number of bytes by which the partition is to be enlarged (positive value) or reduced (negative value). Note that this
			/// value is not the new size of the partition.
			/// </summary>
			public long BytesToGrow;
		}

		/// <summary>Contains standard Int13 drive geometry parameters.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_int13_info typedef struct _DISK_INT13_INFO { WORD
		// DriveSelect; DWORD MaxCylinders; WORD SectorsPerTrack; WORD MaxHeads; WORD NumberDrives; } DISK_INT13_INFO, *PDISK_INT13_INFO;
		[PInvokeData("winioctl.h", MSDNShortId = "a6991ad1-da8a-4df6-a055-ead3c30938df")]
		[StructLayout(LayoutKind.Sequential, Pack = 8, Size = 16)]
		public struct DISK_INT13_INFO
		{
			/// <summary>The letter that is related to the specified partition or hard disk. For valid values, see the BIOS documentation.</summary>
			public ushort DriveSelect;

			/// <summary>The maximum number of cylinders per head. For valid values, see the BIOS documentation.</summary>
			public uint MaxCylinders;

			/// <summary>The number of sectors per track. For valid values, see the BIOS documentation.</summary>
			public ushort SectorsPerTrack;

			/// <summary>The maximum number of heads for this hard disk. For valid values, see the BIOS documentation.</summary>
			public ushort MaxHeads;

			/// <summary>The number of drives. For valid values, see the BIOS documentation.</summary>
			public ushort NumberDrives;
		}

		/// <summary>Contains the disk partition information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_partition_info typedef struct _DISK_PARTITION_INFO {
		// DWORD SizeOfPartitionInfo; PARTITION_STYLE PartitionStyle; union { struct { DWORD Signature; DWORD CheckSum; } Mbr; struct { GUID
		// DiskId; } Gpt; } DUMMYUNIONNAME; } DISK_PARTITION_INFO, *PDISK_PARTITION_INFO;
		[PInvokeData("winioctl.h", MSDNShortId = "34a086fc-72ea-46ed-adb3-c084abcb3c74")]
		[StructLayout(LayoutKind.Explicit)]
		public struct DISK_PARTITION_INFO
		{
			/// <summary>The size of this structure, in bytes.</summary>
			[FieldOffset(0)]
			public uint SizeOfPartitionInfo;

			/// <summary>
			/// <para>The format of a partition.</para>
			/// <para>For more information, see PARTITION_STYLE.</para>
			/// </summary>
			[FieldOffset(4)]
			public PARTITION_STYLE PartitionStyle;

			/// <summary>The MBR partition info</summary>
			[FieldOffset(8)]
			public MBR Mbr;

			/// <summary>The GPT partition info</summary>
			[FieldOffset(8)]
			public GPT Gpt;

			/// <summary>The MBR partition info</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct MBR
			{
				/// <summary>MBR signature of the partition.</summary>
				public uint Signature;

				/// <summary/>
				public uint CheckSum;
			}

			/// <summary>The GPT partition info</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct GPT
			{
				/// <summary><c>GUID</c> of the GPT partition.</summary>
				public Guid DiskId;
			}
		}

		/// <summary>Provides disk performance information. It is used by the IOCTL_DISK_PERFORMANCE control code.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_performance typedef struct _DISK_PERFORMANCE {
		// LARGE_INTEGER BytesRead; LARGE_INTEGER BytesWritten; LARGE_INTEGER ReadTime; LARGE_INTEGER WriteTime; LARGE_INTEGER IdleTime;
		// DWORD ReadCount; DWORD WriteCount; DWORD QueueDepth; DWORD SplitCount; LARGE_INTEGER QueryTime; DWORD StorageDeviceNumber; WCHAR
		// StorageManagerName[8]; } DISK_PERFORMANCE, *PDISK_PERFORMANCE;
		[PInvokeData("winioctl.h", MSDNShortId = "938ec37b-450e-4ebf-ad2b-9f1ac5f56112")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DISK_PERFORMANCE
		{
			/// <summary>The number of bytes read.</summary>
			public long BytesRead;

			/// <summary>The number of bytes written.</summary>
			public long BytesWritten;

			/// <summary>The time it takes to complete a read.</summary>
			public long ReadTime;

			/// <summary>The time it takes to complete a write.</summary>
			public long WriteTime;

			/// <summary>The idle time.</summary>
			public long IdleTime;

			/// <summary>The number of read operations.</summary>
			public uint ReadCount;

			/// <summary>The number of write operations.</summary>
			public uint WriteCount;

			/// <summary>The depth of the queue.</summary>
			public uint QueueDepth;

			/// <summary>
			/// <para>The cumulative count of I/Os that are associated I/Os.</para>
			/// <para>
			/// An associated I/O is a fragmented I/O, where multiple I/Os to a disk are required to fulfill the original logical I/O
			/// request. The most common example of this scenario is a file that is fragmented on a disk. The multiple I/Os are counted as
			/// split I/O counts.
			/// </para>
			/// </summary>
			public uint SplitCount;

			/// <summary>
			/// <para>The system time stamp when a query for this structure is returned.</para>
			/// <para>Use this member to synchronize between the file system driver and a caller.</para>
			/// </summary>
			public long QueryTime;

			/// <summary>
			/// The unique number for a device that identifies it to the storage manager that is indicated in the <c>StorageManagerName</c> member.
			/// </summary>
			public uint StorageDeviceNumber;

			/// <summary>
			/// <para>The name of the storage manager that controls this device.</para>
			/// <para>Examples of storage managers are "PhysDisk," "FTDISK," and "DMIO".</para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
			public string StorageManagerName;
		}

		/// <summary>
		/// <para>Contains information about the partitions of a drive.</para>
		/// <para><c>Note</c><c>DRIVE_LAYOUT_INFORMATION</c> is superseded by the DRIVE_LAYOUT_INFORMATION_EX structure.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-drive_layout_information typedef struct
		// _DRIVE_LAYOUT_INFORMATION { DWORD PartitionCount; DWORD Signature; PARTITION_INFORMATION PartitionEntry[1]; }
		// DRIVE_LAYOUT_INFORMATION, *PDRIVE_LAYOUT_INFORMATION;
		[PInvokeData("winioctl.h", MSDNShortId = "e67ccaa7-a735-4695-8385-28f57b41821c")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DRIVE_LAYOUT_INFORMATION>), nameof(PartitionCount))]
		[StructLayout(LayoutKind.Sequential)]
		public struct DRIVE_LAYOUT_INFORMATION
		{
			/// <summary>
			/// <para>The number of partitions on a drive.</para>
			/// <para>
			/// On disks with the MBR layout, this value is always a multiple of 4. Any partitions that are unused have a partition type of
			/// <c>PARTITION_ENTRY_UNUSED</c> (0).
			/// </para>
			/// </summary>
			public uint PartitionCount;

			/// <summary>The drive signature value.</summary>
			public uint Signature;

			/// <summary>A variable-sized array of PARTITION_INFORMATION structures, one structure for each partition on a drive.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public PARTITION_INFORMATION[] PartitionEntry;
		}

		/// <summary>Contains extended information about a drive's partitions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-drive_layout_information_ex typedef struct
		// _DRIVE_LAYOUT_INFORMATION_EX { DWORD PartitionStyle; DWORD PartitionCount; union { DRIVE_LAYOUT_INFORMATION_MBR Mbr;
		// DRIVE_LAYOUT_INFORMATION_GPT Gpt; } DUMMYUNIONNAME; PARTITION_INFORMATION_EX PartitionEntry[1]; } DRIVE_LAYOUT_INFORMATION_EX, *PDRIVE_LAYOUT_INFORMATION_EX;
		[PInvokeData("winioctl.h", MSDNShortId = "381c87a8-fe40-4251-a4df-dddc9e2a126d")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DRIVE_LAYOUT_INFORMATION_EX>), nameof(PartitionCount))]
		[StructLayout(LayoutKind.Explicit)]
		public struct DRIVE_LAYOUT_INFORMATION_EX
		{
			/// <summary>
			/// <para>The style of the partitions on the drive enumerated by the PARTITION_STYLE enumeration.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PARTITION_STYLE_MBR 0</term>
			/// <term>Master boot record (MBR) format.</term>
			/// </item>
			/// <item>
			/// <term>PARTITION_STYLE_GPT 1</term>
			/// <term>GUID Partition Table (GPT) format.</term>
			/// </item>
			/// <item>
			/// <term>PARTITION_STYLE_RAW 2</term>
			/// <term>Partition not formatted in either of the recognized formats—MBR or GPT.</term>
			/// </item>
			/// </list>
			/// </summary>
			[FieldOffset(0)]
			public uint PartitionStyle;

			/// <summary>
			/// The number of partitions on the drive. On hard disks with the MBR layout, this value will always be a multiple of 4. Any
			/// partitions that are actually unused will have a partition type of <c>PARTITION_ENTRY_UNUSED</c> (0) set in the
			/// <c>PartitionType</c> member of the PARTITION_INFORMATION_MBR structure of the <c>Mbr</c> member of the
			/// PARTITION_INFORMATION_EX structure of the <c>PartitionEntry</c> member of this structure.
			/// </summary>
			[FieldOffset(4)]
			public uint PartitionCount;

			/// <summary>
			/// A DRIVE_LAYOUT_INFORMATION_MBR structure containing information about the master boot record type partitioning on the drive.
			/// </summary>
			[FieldOffset(8)]
			public DRIVE_LAYOUT_INFORMATION_MBR Mbr;

			/// <summary>
			/// A DRIVE_LAYOUT_INFORMATION_GPT structure containing information about the GUID disk partition type partitioning on the drive.
			/// </summary>
			[FieldOffset(8)]
			public DRIVE_LAYOUT_INFORMATION_GPT Gpt;

			/// <summary>A variable-sized array of PARTITION_INFORMATION_EX structures, one structure for each partition on the drive.</summary>
			[FieldOffset(48)]
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public PARTITION_INFORMATION_EX[] PartitionEntry;
		}

		/// <summary>Contains information about a drive's GUID partition table (GPT) partitions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-drive_layout_information_gpt typedef struct
		// _DRIVE_LAYOUT_INFORMATION_GPT { GUID DiskId; LARGE_INTEGER StartingUsableOffset; LARGE_INTEGER UsableLength; DWORD
		// MaxPartitionCount; } DRIVE_LAYOUT_INFORMATION_GPT, *PDRIVE_LAYOUT_INFORMATION_GPT;
		[PInvokeData("winioctl.h", MSDNShortId = "763b0d64-6dcc-411c-aca1-3beea0890124")]
		[StructLayout(LayoutKind.Sequential, Pack = 8, Size = 40)]
		public struct DRIVE_LAYOUT_INFORMATION_GPT
		{
			/// <summary>The <c>GUID</c> of the disk.</summary>
			public Guid DiskId;

			/// <summary>The starting byte offset of the first usable block.</summary>
			public long StartingUsableOffset;

			/// <summary>The size of the usable blocks on the disk, in bytes.</summary>
			public long UsableLength;

			/// <summary>The maximum number of partitions that can be defined in the usable block.</summary>
			public uint MaxPartitionCount;
		}

		/// <summary>Provides information about a drive's master boot record (MBR) partitions.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-drive_layout_information_mbr typedef struct
		// _DRIVE_LAYOUT_INFORMATION_MBR { DWORD Signature; DWORD CheckSum; } DRIVE_LAYOUT_INFORMATION_MBR, *PDRIVE_LAYOUT_INFORMATION_MBR;
		[PInvokeData("winioctl.h", MSDNShortId = "71c361fe-8c85-4915-9776-8ad3f5837e11")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DRIVE_LAYOUT_INFORMATION_MBR
		{
			/// <summary>The signature of the drive.</summary>
			public uint Signature;

			/// <summary/>
			public uint CheckSum;
		}

		/// <summary>Contains statistical information from the exFAT file system.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-exfat_statistics typedef struct _EXFAT_STATISTICS { DWORD
		// CreateHits; DWORD SuccessfulCreates; DWORD FailedCreates; DWORD NonCachedReads; DWORD NonCachedReadBytes; DWORD NonCachedWrites;
		// DWORD NonCachedWriteBytes; DWORD NonCachedDiskReads; DWORD NonCachedDiskWrites; } EXFAT_STATISTICS, *PEXFAT_STATISTICS;
		[PInvokeData("winioctl.h", MSDNShortId = "fc33e967-fbc0-4f98-9b6c-2d6ac103a256")]
		[StructLayout(LayoutKind.Sequential)]
		public struct EXFAT_STATISTICS
		{
			/// <summary>The number of create operations.</summary>
			public uint CreateHits;

			/// <summary>The number of successful create operations.</summary>
			public uint SuccessfulCreates;

			/// <summary>The number of failed create operations.</summary>
			public uint FailedCreates;

			/// <summary>The number of read operations that were not cached.</summary>
			public uint NonCachedReads;

			/// <summary>The number of bytes read from a file that were not cached.</summary>
			public uint NonCachedReadBytes;

			/// <summary>The number of write operations that were not cached.</summary>
			public uint NonCachedWrites;

			/// <summary>The number of bytes written to a file that were not cached.</summary>
			public uint NonCachedWriteBytes;

			/// <summary>The number of read operations that were not cached. This value includes sub-read operations.</summary>
			public uint NonCachedDiskReads;

			/// <summary>The number of write operations that were not cached. This value includes sub-write operations.</summary>
			public uint NonCachedDiskWrites;
		}

		/// <summary>Contains statistical information from the FAT file system.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-fat_statistics typedef struct _FAT_STATISTICS { DWORD
		// CreateHits; DWORD SuccessfulCreates; DWORD FailedCreates; DWORD NonCachedReads; DWORD NonCachedReadBytes; DWORD NonCachedWrites;
		// DWORD NonCachedWriteBytes; DWORD NonCachedDiskReads; DWORD NonCachedDiskWrites; } FAT_STATISTICS, *PFAT_STATISTICS;
		[PInvokeData("winioctl.h", MSDNShortId = "98d293e8-e708-48f5-99b1-603f27e6ef16")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FAT_STATISTICS
		{
			/// <summary>The number of create operations.</summary>
			public uint CreateHits;

			/// <summary>The number of successful create operations.</summary>
			public uint SuccessfulCreates;

			/// <summary>The number of failed create operations.</summary>
			public uint FailedCreates;

			/// <summary>The number of read operations that were not cached.</summary>
			public uint NonCachedReads;

			/// <summary>The number of bytes read from a file that were not cached.</summary>
			public uint NonCachedReadBytes;

			/// <summary>The number of write operations that were not cached.</summary>
			public uint NonCachedWrites;

			/// <summary>The number of bytes written to a file that were not cached.</summary>
			public uint NonCachedWriteBytes;

			/// <summary>The number of read operations that were not cached. This value includes sub-read operations.</summary>
			public uint NonCachedDiskReads;

			/// <summary>The number of write operations that were not cached. This value includes sub-write operations.</summary>
			public uint NonCachedDiskWrites;
		}

		/// <summary>
		/// <para>Contains statistical information from the file system.</para>
		/// <para><c>Tip</c> Applications targeting Windows 10 can access additional statistics through FILESYSTEM_STATISTICS_EX.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// There are two types of files: user and metadata. User files are available for the user. Metadata files are system files that
		/// contain information, which the file system uses for its internal organization.
		/// </para>
		/// <para>The number of read and write operations measured is the number of paging operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-filesystem_statistics typedef struct
		// _FILESYSTEM_STATISTICS { WORD FileSystemType; WORD Version; DWORD SizeOfCompleteStructure; DWORD UserFileReads; DWORD
		// UserFileReadBytes; DWORD UserDiskReads; DWORD UserFileWrites; DWORD UserFileWriteBytes; DWORD UserDiskWrites; DWORD MetaDataReads;
		// DWORD MetaDataReadBytes; DWORD MetaDataDiskReads; DWORD MetaDataWrites; DWORD MetaDataWriteBytes; DWORD MetaDataDiskWrites; }
		// FILESYSTEM_STATISTICS, *PFILESYSTEM_STATISTICS;
		[PInvokeData("winioctl.h", MSDNShortId = "ff8c7dfe-da7f-4ee2-9a54-613e0cd3e1e2")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILESYSTEM_STATISTICS
		{
			/// <summary>
			/// <para>The type of file system.</para>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FILESYSTEM_STATISTICS_TYPE_EXFAT 3</term>
			/// <term>
			/// The file system is an exFAT file system. If this value is set, this structure is followed by an EXFAT_STATISTICS structure.
			/// Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Vista with SP1.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILESYSTEM_STATISTICS_TYPE_FAT 2</term>
			/// <term>The file system is a FAT file system. If this value is set, this structure is followed by a FAT_STATISTICS structure.</term>
			/// </item>
			/// <item>
			/// <term>FILESYSTEM_STATISTICS_TYPE_NTFS 1</term>
			/// <term>The file system is the NTFS file system. If this value is set, this structure is followed by an NTFS_STATISTICS structure.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort FileSystemType;

			/// <summary>This member is set to 1 (one).</summary>
			public ushort Version;

			/// <summary>
			/// <para>
			/// The size of this structure plus the size of the file system-specific structure that follows this structure, multiplied by the
			/// number of processors.
			/// </para>
			/// <para>
			/// This value must be a multiple of 64. For example, if the size of <c>FILESYSTEM_STATISTICS</c> is 0x38, the size of
			/// NTFS_STATISTICS is 0xD8, and if there are 2 processors, the buffer allocated must be 0x280.
			/// </para>
			/// <para>sizeof( <c>FILESYSTEM_STATISTICS</c>) = 0x38</para>
			/// <para>sizeof(NTFS_STATISTICS) = 0xD8</para>
			/// <para>Total Size = 0x110</para>
			/// <para>size of the complete structure = 0x140 (which is the aligned length, a multiple of 64)</para>
			/// <para>multiplied by 2 (the number of processors) = 0x280</para>
			/// </summary>
			public uint SizeOfCompleteStructure;

			/// <summary>The number of read operations on user files.</summary>
			public uint UserFileReads;

			/// <summary>The number of bytes read from user files.</summary>
			public uint UserFileReadBytes;

			/// <summary>
			/// <para>The number of read operations on user files.</para>
			/// <para>This value includes sub-read operations.</para>
			/// </summary>
			public uint UserDiskReads;

			/// <summary>The number of write operations on user files.</summary>
			public uint UserFileWrites;

			/// <summary>The number of bytes written to user files.</summary>
			public uint UserFileWriteBytes;

			/// <summary>
			/// <para>The number of write operations on user files.</para>
			/// <para>This value includes sub-write operations.</para>
			/// </summary>
			public uint UserDiskWrites;

			/// <summary>The number of read operations on metadata files.</summary>
			public uint MetaDataReads;

			/// <summary>The number of bytes read from metadata files.</summary>
			public uint MetaDataReadBytes;

			/// <summary>
			/// <para>The number of read operations on metadata files.</para>
			/// <para>This value includes sub-read operations.</para>
			/// </summary>
			public uint MetaDataDiskReads;

			/// <summary>The number of write operations on metadata files.</summary>
			public uint MetaDataWrites;

			/// <summary>The number of bytes written to metadata files.</summary>
			public uint MetaDataWriteBytes;

			/// <summary>
			/// <para>The number of write operations on metadata files.</para>
			/// <para>This value includes sub-write operations.</para>
			/// </summary>
			public uint MetaDataDiskWrites;
		}

		/// <summary>Contains statistical information from the file system.Support for this structure started with Windows 10.</summary>
		/// <remarks>
		/// <para>
		/// There are two types of files: user and metadata. User files are available for the user. Metadata files are system files that
		/// contain information, which the file system uses for its internal organization.
		/// </para>
		/// <para>The number of read and write operations measured is the number of paging operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-filesystem_statistics_ex typedef struct
		// _FILESYSTEM_STATISTICS_EX { WORD FileSystemType; WORD Version; DWORD SizeOfCompleteStructure; DWORDLONG UserFileReads; DWORDLONG
		// UserFileReadBytes; DWORDLONG UserDiskReads; DWORDLONG UserFileWrites; DWORDLONG UserFileWriteBytes; DWORDLONG UserDiskWrites;
		// DWORDLONG MetaDataReads; DWORDLONG MetaDataReadBytes; DWORDLONG MetaDataDiskReads; DWORDLONG MetaDataWrites; DWORDLONG
		// MetaDataWriteBytes; DWORDLONG MetaDataDiskWrites; } FILESYSTEM_STATISTICS_EX, *PFILESYSTEM_STATISTICS_EX;
		[PInvokeData("winioctl.h", MSDNShortId = "E869CF11-E321-478A-948F-226B04D61492")]
		[StructLayout(LayoutKind.Sequential)]
		public struct FILESYSTEM_STATISTICS_EX
		{
			/// <summary>
			/// <para>The type of file system.</para>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>FILESYSTEM_STATISTICS_TYPE_EXFAT 3</term>
			/// <term>
			/// The file system is an exFAT file system. If this value is set, this structure is followed by an EXFAT_STATISTICS structure.
			/// Windows Vista, Windows Server 2003 and Windows XP: This value is not supported until Windows Vista with SP1.
			/// </term>
			/// </item>
			/// <item>
			/// <term>FILESYSTEM_STATISTICS_TYPE_FAT 2</term>
			/// <term>The file system is a FAT file system. If this value is set, this structure is followed by a FAT_STATISTICS structure.</term>
			/// </item>
			/// <item>
			/// <term>FILESYSTEM_STATISTICS_TYPE_NTFS 1</term>
			/// <term>
			/// The file system is the NTFS file system. If this value is set, this structure is followed by an NTFS_STATISTICS_EX structure.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort FileSystemType;

			/// <summary>This member is set to 1 (one).</summary>
			public ushort Version;

			/// <summary>
			/// <para>
			/// The size of this structure plus the size of the file system-specific structure that follows this structure, multiplied by the
			/// number of processors.
			/// </para>
			/// <para>
			/// This value must be a multiple of 64. For example, if the size of <c>FILESYSTEM_STATISTICS_EX</c> is 0x68, the size of
			/// NTFS_STATISTICS_EX is 0x1D8, and if there are 2 processors, the buffer allocated must be 0x480.
			/// </para>
			/// <para>sizeof( <c>FILESYSTEM_STATISTICS_EX</c>) = 0x68</para>
			/// <para>sizeof(NTFS_STATISTICS_EX) = 0x1D8</para>
			/// <para>Total Size = 0x240</para>
			/// <para>size of the complete structure = 0x240 (which is the aligned length, a multiple of 64)</para>
			/// <para>multiplied by 2 (the number of processors) = 0x480</para>
			/// </summary>
			public uint SizeOfCompleteStructure;

			/// <summary>The number of read operations on user files.</summary>
			public ulong UserFileReads;

			/// <summary>The number of bytes read from user files.</summary>
			public ulong UserFileReadBytes;

			/// <summary>
			/// <para>The number of read operations on user files.</para>
			/// <para>This value includes sub-read operations.</para>
			/// </summary>
			public ulong UserDiskReads;

			/// <summary>The number of write operations on user files.</summary>
			public ulong UserFileWrites;

			/// <summary>The number of bytes written to user files.</summary>
			public ulong UserFileWriteBytes;

			/// <summary>
			/// <para>The number of write operations on user files.</para>
			/// <para>This value includes sub-write operations.</para>
			/// </summary>
			public ulong UserDiskWrites;

			/// <summary>The number of read operations on metadata files.</summary>
			public ulong MetaDataReads;

			/// <summary>The number of bytes read from metadata files.</summary>
			public ulong MetaDataReadBytes;

			/// <summary>
			/// <para>The number of read operations on metadata files.</para>
			/// <para>This value includes sub-read operations.</para>
			/// </summary>
			public ulong MetaDataDiskReads;

			/// <summary>The number of write operations on metadata files.</summary>
			public ulong MetaDataWrites;

			/// <summary>The number of bytes written to metadata files.</summary>
			public ulong MetaDataWriteBytes;

			/// <summary>
			/// <para>The number of write operations on metadata files.</para>
			/// <para>This value includes sub-write operations.</para>
			/// </summary>
			public ulong MetaDataDiskWrites;
		}

		/// <summary>
		/// Contains information defining the boundaries for and starting place of an enumeration of update sequence number (USN) change
		/// journal records. It is used as the input buffer for the FSCTL_ENUM_USN_DATA control code. Prior to Windows Server 2012 this
		/// structure was named <c>MFT_ENUM_DATA</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-mft_enum_data_v0 typedef struct { DWORDLONG
		// StartFileReferenceNumber; USN LowUsn; USN HighUsn; } MFT_ENUM_DATA_V0, *PMFT_ENUM_DATA_V0;
		[PInvokeData("winioctl.h", MSDNShortId = "bd098d10-b30f-44b0-a379-2d57e33fe1c9")]
		[StructLayout(LayoutKind.Sequential)]
		public struct MFT_ENUM_DATA_V0
		{
			/// <summary>
			/// <para>The ordinal position within the files on the current volume at which the enumeration is to begin.</para>
			/// <para>
			/// The first call to FSCTL_ENUM_USN_DATA during an enumeration must have the <c>StartFileReferenceNumber</c> member set to .
			/// Each call to <c>FSCTL_ENUM_USN_DATA</c> retrieves the starting point for the subsequent call as the first entry in the output
			/// buffer. Subsequent calls must be made with <c>StartFileReferenceNumber</c> set to this value. For more information, see <c>FSCTL_ENUM_USN_DATA</c>.
			/// </para>
			/// </summary>
			public ulong StartFileReferenceNumber;

			/// <summary>
			/// The lower boundary of the range of USN values used to filter which records are returned. Only records whose last change
			/// journal USN is between or equal to the <c>LowUsn</c> and <c>HighUsn</c> member values are returned.
			/// </summary>
			public long LowUsn;

			/// <summary>The upper boundary of the range of USN values used to filter which files are returned.</summary>
			public long HighUsn;
		}

		/// <summary>
		/// Contains information defining the boundaries for and starting place of an enumeration of update sequence number (USN) change
		/// journal records for ReFS volumes. It is used as the input buffer for the FSCTL_ENUM_USN_DATA control code.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-mft_enum_data_v1 typedef struct { DWORDLONG
		// StartFileReferenceNumber; USN LowUsn; USN HighUsn; WORD MinMajorVersion; WORD MaxMajorVersion; } MFT_ENUM_DATA_V1, *PMFT_ENUM_DATA_V1;
		[PInvokeData("winioctl.h", MSDNShortId = "6d7b50e3-60cf-4eaf-9d22-fbb20c7e0bba")]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct MFT_ENUM_DATA_V1
		{
			/// <summary>
			/// <para>The ordinal position within the files on the current volume at which the enumeration is to begin.</para>
			/// <para>
			/// The first call to FSCTL_ENUM_USN_DATA during an enumeration must have the <c>StartFileReferenceNumber</c> member set to .
			/// Each call to <c>FSCTL_ENUM_USN_DATA</c> retrieves the starting point for the subsequent call as the first entry in the output
			/// buffer. Subsequent calls must be made with <c>StartFileReferenceNumber</c> set to this value. For more information, see <c>FSCTL_ENUM_USN_DATA</c>.
			/// </para>
			/// </summary>
			public ulong StartFileReferenceNumber;

			/// <summary>
			/// The lower boundary of the range of USN values used to filter which records are returned. Only records whose last change
			/// journal USN is between or equal to the <c>LowUsn</c> and <c>HighUsn</c> member values are returned.
			/// </summary>
			public long LowUsn;

			/// <summary>The upper boundary of the range of USN values used to filter which files are returned.</summary>
			public long HighUsn;

			/// <summary>Indicates the minimum supported major version for the USN change journal.</summary>
			public ushort MinMajorVersion;

			/// <summary>
			/// <para>Indicates the maximum supported major version for the USN change journal.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The data returned from the FSCTL_ENUM_USN_DATA control code will contain USN_RECORD_V2 structures.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The data returned from the FSCTL_ENUM_USN_DATA control code will contain USN_RECORD_V2 or USN_RECORD_V3 structures.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MaxMajorVersion;
		}

		/// <summary>
		/// <para>Contains statistical information from the NTFS file system.</para>
		/// <para><c>Tip</c> Applications targeting Windows 10 can access additional statistics through NTFS_STATISTICS_EX.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MFT, MFT mirror, root index, user index, bitmap, and MFT bitmap are counted as metadata files. The log file is not counted as
		/// a metadata file.
		/// </para>
		/// <para>The number of read and write operations measured is the number of paging operations.</para>
		/// <para>For additional statistics that are only available with Windows 10, use NTFS_STATISTICS_EX.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-ntfs_statistics typedef struct _NTFS_STATISTICS { DWORD
		// LogFileFullExceptions; DWORD OtherExceptions; DWORD MftReads; DWORD MftReadBytes; DWORD MftWrites; DWORD MftWriteBytes; struct {
		// WORD Write; WORD Create; WORD SetInfo; WORD Flush; } MftWritesUserLevel; WORD MftWritesFlushForLogFileFull; WORD
		// MftWritesLazyWriter; WORD MftWritesUserRequest; DWORD Mft2Writes; DWORD Mft2WriteBytes; struct { WORD Write; WORD Create; WORD
		// SetInfo; WORD Flush; } Mft2WritesUserLevel; WORD Mft2WritesFlushForLogFileFull; WORD Mft2WritesLazyWriter; WORD
		// Mft2WritesUserRequest; DWORD RootIndexReads; DWORD RootIndexReadBytes; DWORD RootIndexWrites; DWORD RootIndexWriteBytes; DWORD
		// BitmapReads; DWORD BitmapReadBytes; DWORD BitmapWrites; DWORD BitmapWriteBytes; WORD BitmapWritesFlushForLogFileFull; WORD
		// BitmapWritesLazyWriter; WORD BitmapWritesUserRequest; struct { WORD Write; WORD Create; WORD SetInfo; } BitmapWritesUserLevel;
		// DWORD MftBitmapReads; DWORD MftBitmapReadBytes; DWORD MftBitmapWrites; DWORD MftBitmapWriteBytes; WORD
		// MftBitmapWritesFlushForLogFileFull; WORD MftBitmapWritesLazyWriter; WORD MftBitmapWritesUserRequest; struct { WORD Write; WORD
		// Create; WORD SetInfo; WORD Flush; } MftBitmapWritesUserLevel; DWORD UserIndexReads; DWORD UserIndexReadBytes; DWORD
		// UserIndexWrites; DWORD UserIndexWriteBytes; DWORD LogFileReads; DWORD LogFileReadBytes; DWORD LogFileWrites; DWORD
		// LogFileWriteBytes; struct { DWORD Calls; DWORD Clusters; DWORD Hints; DWORD RunsReturned; DWORD HintsHonored; DWORD HintsClusters;
		// DWORD Cache; DWORD CacheClusters; DWORD CacheMiss; DWORD CacheMissClusters; } Allocate; DWORD DiskResourcesExhausted; }
		// NTFS_STATISTICS, *PNTFS_STATISTICS;
		[PInvokeData("winioctl.h", MSDNShortId = "9b5cffc5-386d-4333-9a37-cc27b8f9b187")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NTFS_STATISTICS
		{
			/// <summary>The number of exceptions generated due to the log file being full.</summary>
			public uint LogFileFullExceptions;

			/// <summary>The number of other exceptions generated.</summary>
			public uint OtherExceptions;

			/// <summary>The number of read operations on the master file table (MFT).</summary>
			public uint MftReads;

			/// <summary>The number of bytes read from the MFT.</summary>
			public uint MftReadBytes;

			/// <summary>The number of write operations on the MFT.</summary>
			public uint MftWrites;

			/// <summary>The number of bytes written to the MFT.</summary>
			public uint MftWriteBytes;

			/// <summary/>
			public MFTWRITESUSERLEVEL MftWritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct MFTWRITESUSERLEVEL
			{
				/// <summary>The number of MFT writes due to a write operation.</summary>
				public ushort Write;

				/// <summary>The number of MFT writes due to a create operation.</summary>
				public ushort Create;

				/// <summary>The number of MFT writes due to setting file information.</summary>
				public ushort SetInfo;

				/// <summary>The number of MFT writes due to a flush operation.</summary>
				public ushort Flush;
			}

			/// <summary>The number of flushes of the MFT performed because the log file was full.</summary>
			public ushort MftWritesFlushForLogFileFull;

			/// <summary>The number of MFT write operations performed by the lazy writer thread.</summary>
			public ushort MftWritesLazyWriter;

			/// <summary>Reserved.</summary>
			public ushort MftWritesUserRequest;

			/// <summary>The number of write operations on the MFT mirror.</summary>
			public uint Mft2Writes;

			/// <summary>The number of bytes written to the MFT mirror.</summary>
			public uint Mft2WriteBytes;

			/// <summary/>
			public MFT2WRITESUSERLEVEL Mft2WritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct MFT2WRITESUSERLEVEL
			{
				/// <summary>The number of MFT mirror writes due to a write operation.</summary>
				public ushort Write;

				/// <summary>The number of MFT mirror writes due to a create operation.</summary>
				public ushort Create;

				/// <summary>The number of MFT mirror writes due to setting file information.</summary>
				public ushort SetInfo;

				/// <summary>The number of MFT mirror writes due to a flush operation.</summary>
				public ushort Flush;
			}

			/// <summary>The number of flushes of the MFT mirror performed because the log file was full.</summary>
			public ushort Mft2WritesFlushForLogFileFull;

			/// <summary>The number of MFT mirror write operations performed by the lazy writer thread.</summary>
			public ushort Mft2WritesLazyWriter;

			/// <summary>Reserved.</summary>
			public ushort Mft2WritesUserRequest;

			/// <summary>The number of read operations on the root index.</summary>
			public uint RootIndexReads;

			/// <summary>The number of bytes read from the root index.</summary>
			public uint RootIndexReadBytes;

			/// <summary>The number of write operations on the root index.</summary>
			public uint RootIndexWrites;

			/// <summary>The number of bytes written to the root index.</summary>
			public uint RootIndexWriteBytes;

			/// <summary>The number of read operations on the cluster allocation bitmap.</summary>
			public uint BitmapReads;

			/// <summary>The number of bytes read from the cluster allocation bitmap.</summary>
			public uint BitmapReadBytes;

			/// <summary>The number of write operations on the cluster allocation bitmap.</summary>
			public uint BitmapWrites;

			/// <summary>The number of bytes written to the cluster allocation bitmap.</summary>
			public uint BitmapWriteBytes;

			/// <summary>The number of flushes of the bitmap performed because the log file was full.</summary>
			public ushort BitmapWritesFlushForLogFileFull;

			/// <summary>The number of bitmap write operations performed by the lazy writer thread.</summary>
			public ushort BitmapWritesLazyWriter;

			/// <summary>Reserved.</summary>
			public ushort BitmapWritesUserRequest;

			/// <summary/>
			public BITMAPWRITESUSERLEVEL BitmapWritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct BITMAPWRITESUSERLEVEL
			{
				/// <summary>The number of bitmap writes due to a write operation.</summary>
				public ushort Write;

				/// <summary>The number of bitmap writes due to a create operation.</summary>
				public ushort Create;

				/// <summary>The number of bitmap writes due to setting file information.</summary>
				public ushort SetInfo;
			}

			/// <summary>The number of read operations on the MFT bitmap.</summary>
			public uint MftBitmapReads;

			/// <summary>The number of bytes read from the MFT bitmap.</summary>
			public uint MftBitmapReadBytes;

			/// <summary>The number of write operations on the MFT bitmap.</summary>
			public uint MftBitmapWrites;

			/// <summary>The number of bytes written to the MFT bitmap.</summary>
			public uint MftBitmapWriteBytes;

			/// <summary>The number of flushes of the MFT bitmap performed because the log file was full.</summary>
			public ushort MftBitmapWritesFlushForLogFileFull;

			/// <summary>The number of MFT bitmap write operations performed by the lazy writer thread.</summary>
			public ushort MftBitmapWritesLazyWriter;

			/// <summary>Reserved.</summary>
			public ushort MftBitmapWritesUserRequest;

			/// <summary/>
			public MFTBITMAPWRITESUSERLEVEL MftBitmapWritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct MFTBITMAPWRITESUSERLEVEL
			{
				/// <summary>The number of MFT bitmap writes due to a write operation.</summary>
				public ushort Write;

				/// <summary>The number of bitmap writes due to a create operation.</summary>
				public ushort Create;

				/// <summary>The number of bitmap writes due to setting file information.</summary>
				public ushort SetInfo;

				/// <summary>The number of bitmap writes due to a flush operation.</summary>
				public ushort Flush;
			}

			/// <summary>The number of read operations on the user index.</summary>
			public uint UserIndexReads;

			/// <summary>The number of bytes read from the user index.</summary>
			public uint UserIndexReadBytes;

			/// <summary>The number of write operations on the user index.</summary>
			public uint UserIndexWrites;

			/// <summary>The number of bytes written to the user index.</summary>
			public uint UserIndexWriteBytes;

			/// <summary>The number of read operations on the log file.</summary>
			public uint LogFileReads;

			/// <summary>The number of bytes read from the log file.</summary>
			public uint LogFileReadBytes;

			/// <summary>The number of write operations on the log file.</summary>
			public uint LogFileWrites;

			/// <summary>The number of bytes written to the log file.</summary>
			public uint LogFileWriteBytes;

			/// <summary/>
			public ALLOCATE Allocate;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct ALLOCATE
			{
				/// <summary>The number of individual calls to allocate clusters.</summary>
				public uint Calls;

				/// <summary>The number of clusters allocated.</summary>
				public uint Clusters;

				/// <summary>The number of times a hint was specified.</summary>
				public uint Hints;

				/// <summary>The number of runs used to satisfy all the requests.</summary>
				public uint RunsReturned;

				/// <summary>The number of times the hint was useful.</summary>
				public uint HintsHonored;

				/// <summary>The number of clusters allocated through the hint.</summary>
				public uint HintsClusters;

				/// <summary>The number of times the cache was useful other than the hint.</summary>
				public uint Cache;

				/// <summary>The number of clusters allocated through the cache other than the hint.</summary>
				public uint CacheClusters;

				/// <summary>The number of times the cache was not useful.</summary>
				public uint CacheMiss;

				/// <summary>The number of clusters allocated without the cache.</summary>
				public uint CacheMissClusters;
			}

			/// <summary>
			/// <para>The number of failed attempts made to acquire a slab of storage for use on the current thinly provisioned volume.</para>
			/// <para>Support for this member started with Windows 8.1.</para>
			/// </summary>
			public uint DiskResourcesExhausted;
		}

		/// <summary>
		/// <para>
		/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
		/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
		/// </para>
		/// <para>Contains statistical information from the NTFS file system.Support for this structure started with Windows 10.</para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// The MFT, MFT mirror, root index, user index, bitmap, and MFT bitmap are counted as metadata files. The log file is not counted as
		/// a metadata file.
		/// </para>
		/// <para>The number of read and write operations measured is the number of paging operations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-ntfs_statistics_ex typedef struct _NTFS_STATISTICS_EX {
		// DWORD LogFileFullExceptions; DWORD OtherExceptions; DWORDLONG MftReads; DWORDLONG MftReadBytes; DWORDLONG MftWrites; DWORDLONG
		// MftWriteBytes; struct { DWORD Write; DWORD Create; DWORD SetInfo; DWORD Flush; } MftWritesUserLevel; DWORD
		// MftWritesFlushForLogFileFull; DWORD MftWritesLazyWriter; DWORD MftWritesUserRequest; DWORDLONG Mft2Writes; DWORDLONG
		// Mft2WriteBytes; struct { DWORD Write; DWORD Create; DWORD SetInfo; DWORD Flush; } Mft2WritesUserLevel; DWORD
		// Mft2WritesFlushForLogFileFull; DWORD Mft2WritesLazyWriter; DWORD Mft2WritesUserRequest; DWORDLONG RootIndexReads; DWORDLONG
		// RootIndexReadBytes; DWORDLONG RootIndexWrites; DWORDLONG RootIndexWriteBytes; DWORDLONG BitmapReads; DWORDLONG BitmapReadBytes;
		// DWORDLONG BitmapWrites; DWORDLONG BitmapWriteBytes; DWORD BitmapWritesFlushForLogFileFull; DWORD BitmapWritesLazyWriter; DWORD
		// BitmapWritesUserRequest; struct { DWORD Write; DWORD Create; DWORD SetInfo; DWORD Flush; } BitmapWritesUserLevel; DWORDLONG
		// MftBitmapReads; DWORDLONG MftBitmapReadBytes; DWORDLONG MftBitmapWrites; DWORDLONG MftBitmapWriteBytes; DWORD
		// MftBitmapWritesFlushForLogFileFull; DWORD MftBitmapWritesLazyWriter; DWORD MftBitmapWritesUserRequest; struct { DWORD Write; DWORD
		// Create; DWORD SetInfo; DWORD Flush; } MftBitmapWritesUserLevel; DWORDLONG UserIndexReads; DWORDLONG UserIndexReadBytes; DWORDLONG
		// UserIndexWrites; DWORDLONG UserIndexWriteBytes; DWORDLONG LogFileReads; DWORDLONG LogFileReadBytes; DWORDLONG LogFileWrites;
		// DWORDLONG LogFileWriteBytes; struct { DWORD Calls; DWORD RunsReturned; DWORD Hints; DWORD HintsHonored; DWORD Cache; DWORD
		// CacheMiss; DWORDLONG Clusters; DWORDLONG HintsClusters; DWORDLONG CacheClusters; DWORDLONG CacheMissClusters; } Allocate; DWORD
		// DiskResourcesExhausted; DWORDLONG VolumeTrimCount; DWORDLONG VolumeTrimTime; DWORDLONG VolumeTrimByteCount; DWORDLONG
		// FileLevelTrimCount; DWORDLONG FileLevelTrimTime; DWORDLONG FileLevelTrimByteCount; DWORDLONG VolumeTrimSkippedCount; DWORDLONG
		// VolumeTrimSkippedByteCount; DWORDLONG NtfsFillStatInfoFromMftRecordCalledCount; DWORDLONG
		// NtfsFillStatInfoFromMftRecordBailedBecauseOfAttributeListCount; DWORDLONG
		// NtfsFillStatInfoFromMftRecordBailedBecauseOfNonResReparsePointCount; } NTFS_STATISTICS_EX, *PNTFS_STATISTICS_EX;
		[PInvokeData("winioctl.h", MSDNShortId = "D1A6995C-A4BA-4ECC-892A-196581FA41CE")]
		[StructLayout(LayoutKind.Sequential)]
		public struct NTFS_STATISTICS_EX
		{
			/// <summary>The number of exceptions generated due to the log file being full.</summary>
			public uint LogFileFullExceptions;

			/// <summary>The number of other exceptions generated.</summary>
			public uint OtherExceptions;

			/// <summary>The number of read operations on the master file table (MFT).</summary>
			public ulong MftReads;

			/// <summary>The number of bytes read from the MFT.</summary>
			public ulong MftReadBytes;

			/// <summary>The number of write operations on the MFT.</summary>
			public ulong MftWrites;

			/// <summary>The number of bytes written to the MFT.</summary>
			public ulong MftWriteBytes;

			/// <summary/>
			public MFTWRITESUSERLEVEL MftWritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct MFTWRITESUSERLEVEL
			{
				/// <summary>The number of MFT writes due to a write operation.</summary>
				public uint Write;

				/// <summary>The number of MFT writes due to a create operation.</summary>
				public uint Create;

				/// <summary>The number of MFT writes due to setting file information.</summary>
				public uint SetInfo;

				/// <summary>The number of MFT writes due to a flush operation.</summary>
				public uint Flush;
			}

			/// <summary>The number of flushes of the MFT performed because the log file was full.</summary>
			public uint MftWritesFlushForLogFileFull;

			/// <summary>The number of MFT write operations performed by the lazy writer thread.</summary>
			public uint MftWritesLazyWriter;

			/// <summary>Reserved.</summary>
			public uint MftWritesUserRequest;

			/// <summary>The number of write operations on the MFT mirror.</summary>
			public ulong Mft2Writes;

			/// <summary>The number of bytes written to the MFT mirror.</summary>
			public ulong Mft2WriteBytes;

			/// <summary/>
			public MFT2WRITESUSERLEVEL Mft2WritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct MFT2WRITESUSERLEVEL
			{
				/// <summary>The number of MFT mirror writes due to a write operation.</summary>
				public uint Write;

				/// <summary>The number of MFT mirror writes due to a create operation.</summary>
				public uint Create;

				/// <summary>The number of MFT mirror writes due to setting file information.</summary>
				public uint SetInfo;

				/// <summary>The number of MFT mirror writes due to a flush operation.</summary>
				public uint Flush;
			}

			/// <summary>The number of flushes of the MFT mirror performed because the log file was full.</summary>
			public uint Mft2WritesFlushForLogFileFull;

			/// <summary>The number of MFT mirror write operations performed by the lazy writer thread.</summary>
			public uint Mft2WritesLazyWriter;

			/// <summary>Reserved.</summary>
			public uint Mft2WritesUserRequest;

			/// <summary>The number of read operations on the root index.</summary>
			public ulong RootIndexReads;

			/// <summary>The number of bytes read from the root index.</summary>
			public ulong RootIndexReadBytes;

			/// <summary>The number of write operations on the root index.</summary>
			public ulong RootIndexWrites;

			/// <summary>The number of bytes written to the root index.</summary>
			public ulong RootIndexWriteBytes;

			/// <summary>The number of read operations on the cluster allocation bitmap.</summary>
			public ulong BitmapReads;

			/// <summary>The number of bytes read from the cluster allocation bitmap.</summary>
			public ulong BitmapReadBytes;

			/// <summary>The number of write operations on the cluster allocation bitmap.</summary>
			public ulong BitmapWrites;

			/// <summary>The number of bytes written to the cluster allocation bitmap.</summary>
			public ulong BitmapWriteBytes;

			/// <summary>The number of flushes of the bitmap performed because the log file was full.</summary>
			public uint BitmapWritesFlushForLogFileFull;

			/// <summary>The number of bitmap write operations performed by the lazy writer thread.</summary>
			public uint BitmapWritesLazyWriter;

			/// <summary>Reserved.</summary>
			public uint BitmapWritesUserRequest;

			/// <summary/>
			public BITMAPWRITESUSERLEVEL BitmapWritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct BITMAPWRITESUSERLEVEL
			{
				/// <summary>The number of bitmap writes due to a write operation.</summary>
				public uint Write;

				/// <summary>The number of bitmap writes due to a create operation.</summary>
				public uint Create;

				/// <summary>The number of bitmap writes due to setting file information.</summary>
				public uint SetInfo;

				/// <summary>The number of bitmap writes due to a flush operation.</summary>
				public uint Flush;
			}

			/// <summary>The number of read operations on the MFT bitmap.</summary>
			public ulong MftBitmapReads;

			/// <summary>The number of bytes read from the MFT bitmap.</summary>
			public ulong MftBitmapReadBytes;

			/// <summary>The number of write operations on the MFT bitmap.</summary>
			public ulong MftBitmapWrites;

			/// <summary>The number of bytes written to the MFT bitmap.</summary>
			public ulong MftBitmapWriteBytes;

			/// <summary>The number of flushes of the MFT bitmap performed because the log file was full.</summary>
			public uint MftBitmapWritesFlushForLogFileFull;

			/// <summary>The number of MFT bitmap write operations performed by the lazy writer thread.</summary>
			public uint MftBitmapWritesLazyWriter;

			/// <summary>Reserved.</summary>
			public uint MftBitmapWritesUserRequest;

			/// <summary/>
			public MFTBITMAPWRITESUSERLEVEL MftBitmapWritesUserLevel;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct MFTBITMAPWRITESUSERLEVEL
			{
				/// <summary>The number of MFT bitmap writes due to a write operation.</summary>
				public uint Write;

				/// <summary>The number of bitmap writes due to a create operation.</summary>
				public uint Create;

				/// <summary>The number of bitmap writes due to setting file information.</summary>
				public uint SetInfo;

				/// <summary>The number of bitmap writes due to a flush operation.</summary>
				public uint Flush;
			}

			/// <summary>The number of read operations on the user index.</summary>
			public ulong UserIndexReads;

			/// <summary>The number of bytes read from the user index.</summary>
			public ulong UserIndexReadBytes;

			/// <summary>The number of write operations on the user index.</summary>
			public ulong UserIndexWrites;

			/// <summary>The number of bytes written to the user index.</summary>
			public ulong UserIndexWriteBytes;

			/// <summary>The number of read operations on the log file.</summary>
			public ulong LogFileReads;

			/// <summary>The number of bytes read from the log file.</summary>
			public ulong LogFileReadBytes;

			/// <summary>The number of write operations on the log file.</summary>
			public ulong LogFileWrites;

			/// <summary>The number of bytes written to the log file.</summary>
			public ulong LogFileWriteBytes;

			/// <summary/>
			public ALLOCATE Allocate;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential)]
			public struct ALLOCATE
			{
				/// <summary>The number of individual calls to allocate clusters.</summary>
				public uint Calls;

				/// <summary>The number of runs used to satisfy all the requests.</summary>
				public uint RunsReturned;

				/// <summary>The number of times a hint was specified.</summary>
				public uint Hints;

				/// <summary>The number of times the hint was useful.</summary>
				public uint HintsHonored;

				/// <summary>The number of times the cache was useful other than the hint.</summary>
				public uint Cache;

				/// <summary>The number of times the cache was not useful.</summary>
				public uint CacheMiss;

				/// <summary>The number of clusters allocated.</summary>
				public ulong Clusters;

				/// <summary>The number of clusters allocated through the hint.</summary>
				public ulong HintsClusters;

				/// <summary>The number of clusters allocated through the cache other than the hint.</summary>
				public ulong CacheClusters;

				/// <summary>The number of clusters allocated without the cache.</summary>
				public ulong CacheMissClusters;
			}

			/// <summary>The number of failed attempts made to acquire a slab of storage for use on the current thinly provisioned volume.</summary>
			public uint DiskResourcesExhausted;

			/// <summary>The number of volume level trim operations issued.</summary>
			public ulong VolumeTrimCount;

			/// <summary>
			/// The total time elapsed during all volume level trim operations. This value, divided by the frequency value from
			/// QueryPerformanceFrequency or KeQueryPerformanceCounter, will give the time in seconds.
			/// </summary>
			public ulong VolumeTrimTime;

			/// <summary>The total number of bytes issued by all volume level trim operations.</summary>
			public ulong VolumeTrimByteCount;

			/// <summary>The number of file level trim operations issued.</summary>
			public ulong FileLevelTrimCount;

			/// <summary>
			/// The total time elapsed during all file level trim operations. This value, divided by the frequency value from
			/// QueryPerformanceFrequency or KeQueryPerformanceCounter, will give the time in seconds.
			/// </summary>
			public ulong FileLevelTrimTime;

			/// <summary>The total number of bytes issued by all file level trim operations.</summary>
			public ulong FileLevelTrimByteCount;

			/// <summary>The number of times a volume level trim operation was aborted before being sent down through the storage stack.</summary>
			public ulong VolumeTrimSkippedCount;

			/// <summary>The number of bytes that were not sent through a volume level trim operation because they were skipped.</summary>
			public ulong VolumeTrimSkippedByteCount;

			/// <summary/>
			public ulong NtfsFillStatInfoFromMftRecordCalledCount;

			/// <summary/>
			public ulong NtfsFillStatInfoFromMftRecordBailedBecauseOfAttributeListCount;

			/// <summary/>
			public ulong NtfsFillStatInfoFromMftRecordBailedBecauseOfNonResReparsePointCount;
		}

		/// <summary>
		/// <para>Contains information about a disk partition.</para>
		/// <para><c>Note</c><c>PARTITION_INFORMATION</c> has been superseded by the PARTITION_INFORMATION_EX structure.</para>
		/// </summary>
		/// <remarks>
		/// If the partition is on a disk formatted as type master boot record (MBR), partition size totals are limited. For more
		/// information, see the Remarks section of IOCTL_DISK_SET_DRIVE_LAYOUT.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-partition_information typedef struct
		// _PARTITION_INFORMATION { LARGE_INTEGER StartingOffset; LARGE_INTEGER PartitionLength; DWORD HiddenSectors; DWORD PartitionNumber;
		// BYTE PartitionType; BOOLEAN BootIndicator; BOOLEAN RecognizedPartition; BOOLEAN RewritePartition; } PARTITION_INFORMATION, *PPARTITION_INFORMATION;
		[PInvokeData("winioctl.h", MSDNShortId = "2c8fa83a-0694-4e17-a9e4-87f839a0d458")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct PARTITION_INFORMATION
		{
			/// <summary>The starting offset of the partition.</summary>
			public long StartingOffset;

			/// <summary>The length of the partition, in bytes.</summary>
			public long PartitionLength;

			/// <summary>The number of hidden sectors in the partition.</summary>
			public uint HiddenSectors;

			/// <summary>The number of the partition (1-based).</summary>
			public uint PartitionNumber;

			/// <summary>The type of partition. For a list of values, see Disk Partition Types.</summary>
			public PartitionType PartitionType;

			/// <summary>If this member is <c>TRUE</c>, the partition is bootable.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool BootIndicator;

			/// <summary>If this member is <c>TRUE</c>, the partition is of a recognized type.</summary>
			[MarshalAs(UnmanagedType.U1)] public bool RecognizedPartition;

			/// <summary>
			/// If this member is <c>TRUE</c>, the partition information has changed. When you change a partition (with
			/// IOCTL_DISK_SET_DRIVE_LAYOUT), the system uses this member to determine which partitions have changed and need their
			/// information rewritten.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool RewritePartition;
		}

		/// <summary>
		/// Contains partition information for standard AT-style master boot record (MBR) and Extensible Firmware Interface (EFI) disks.
		/// </summary>
		/// <remarks>
		/// If the partition is on a disk formatted as type master boot record (MBR), partition size totals are limited. For more
		/// information, see the Remarks section of IOCTL_DISK_SET_DRIVE_LAYOUT.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-partition_information_ex typedef struct
		// _PARTITION_INFORMATION_EX { PARTITION_STYLE PartitionStyle; LARGE_INTEGER StartingOffset; LARGE_INTEGER PartitionLength; DWORD
		// PartitionNumber; BOOLEAN RewritePartition; BOOLEAN IsServicePartition; union { PARTITION_INFORMATION_MBR Mbr;
		// PARTITION_INFORMATION_GPT Gpt; } DUMMYUNIONNAME; } PARTITION_INFORMATION_EX, *PPARTITION_INFORMATION_EX;
		[PInvokeData("winioctl.h", MSDNShortId = "3c88ebae-274e-403a-8f57-58fdf863f511")]
		[StructLayout(LayoutKind.Explicit)]
		public struct PARTITION_INFORMATION_EX
		{
			/// <summary>The format of the partition. For a list of values, see PARTITION_STYLE.</summary>
			[FieldOffset(0)]
			public PARTITION_STYLE PartitionStyle;

			/// <summary>The starting offset of the partition.</summary>
			[FieldOffset(8)]
			public long StartingOffset;

			/// <summary>The size of the partition, in bytes.</summary>
			[FieldOffset(16)]
			public long PartitionLength;

			/// <summary>The number of the partition (1-based).</summary>
			[FieldOffset(24)]
			public uint PartitionNumber;

			/// <summary>If this member is <c>TRUE</c>, the partition is rewritable. The value of this parameter should be set to <c>TRUE</c>.</summary>
			[FieldOffset(28)]
			[MarshalAs(UnmanagedType.U1)] public bool RewritePartition;

			/// <summary/>
			[FieldOffset(29)]
			[MarshalAs(UnmanagedType.U1)] public bool IsServicePartition;

			/// <summary>
			/// A PARTITION_INFORMATION_MBR structure that specifies partition information specific to master boot record (MBR) disks. The
			/// MBR partition format is the standard AT-style format.
			/// </summary>
			[FieldOffset(32)]
			public PARTITION_INFORMATION_MBR Mbr;

			/// <summary>
			/// A PARTITION_INFORMATION_GPT structure that specifies partition information specific to GUID partition table (GPT) disks. The
			/// GPT format corresponds to the EFI partition format.
			/// </summary>
			[FieldOffset(32)]
			public PARTITION_INFORMATION_GPT Gpt;
		}

		/// <summary>Contains <c>GUID</c> partition table (GPT) partition information.</summary>
		/// <remarks>
		/// <para>
		/// The GPT partition format is required for disks that are used to boot computers that use Extended Firmware Interface (EFI)
		/// firmware. GPT data disks can reside on x86, x64, and Itanium-based architectures.
		/// </para>
		/// <para>Starting with Windows Server 2003 with SP1, GPT is supported on all Windows platforms, not only platforms that use EFI.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-partition_information_gpt typedef struct
		// _PARTITION_INFORMATION_GPT { GUID PartitionType; GUID PartitionId; DWORD64 Attributes; WCHAR Name[36]; }
		// PARTITION_INFORMATION_GPT, *PPARTITION_INFORMATION_GPT;
		[PInvokeData("winioctl.h", MSDNShortId = "373b4eb3-af6d-4112-9787-f14c19972189")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct PARTITION_INFORMATION_GPT
		{
			private const int nameBytes = 36 * 2;

			/// <summary>
			/// <para>A <c>GUID</c> that identifies the partition type.</para>
			/// <para>
			/// Each partition type that the EFI specification supports is identified by its own <c>GUID</c>, which is published by the
			/// developer of the partition.
			/// </para>
			/// <para>This member can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>PARTITION_BASIC_DATA_GUID ebd0a0a2-b9e5-4433-87c0-68b6b72699c7</term>
			/// <term>
			/// The data partition type that is created and recognized by Windows. Only partitions of this type can be assigned drive
			/// letters, receive volume GUID paths, host mounted folders (also called volume mount points), and be enumerated by calls to
			/// FindFirstVolume and FindNextVolume. This value can be set only for basic disks, with one exception. If both
			/// PARTITION_BASIC_DATA_GUID and GPT_ATTRIBUTE_PLATFORM_REQUIRED are set for a partition on a basic disk that is subsequently
			/// converted to a dynamic disk, the partition remains a basic partition, even though the rest of the disk is a dynamic disk.
			/// This is because the partition is considered to be an OEM partition on a GPT disk.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PARTITION_ENTRY_UNUSED_GUID 00000000-0000-0000-0000-000000000000</term>
			/// <term>There is no partition. This value can be set for basic and dynamic disks.</term>
			/// </item>
			/// <item>
			/// <term>PARTITION_SYSTEM_GUID c12a7328-f81f-11d2-ba4b-00a0c93ec93b</term>
			/// <term>The partition is an EFI system partition. This value can be set for basic and dynamic disks.</term>
			/// </item>
			/// <item>
			/// <term>PARTITION_MSFT_RESERVED_GUID e3c9e316-0b5c-4db8-817d-f92df00215ae</term>
			/// <term>The partition is a Microsoft reserved partition. This value can be set for basic and dynamic disks.</term>
			/// </item>
			/// <item>
			/// <term>PARTITION_LDM_METADATA_GUID 5808c8aa-7e8f-42e0-85d2-e1e90434cfb3</term>
			/// <term>
			/// The partition is a Logical Disk Manager (LDM) metadata partition on a dynamic disk. This value can be set only for dynamic disks.
			/// </term>
			/// </item>
			/// <item>
			/// <term>PARTITION_LDM_DATA_GUID af9b60a0-1431-4f62-bc68-3311714a69ad</term>
			/// <term>The partition is an LDM data partition on a dynamic disk. This value can be set only for dynamic disks.</term>
			/// </item>
			/// <item>
			/// <term>PARTITION_MSFT_RECOVERY_GUID de94bba4-06d1-4d40-a16a-bfd50179d6ac</term>
			/// <term>The partition is a Microsoft recovery partition. This value can be set for basic and dynamic disks.</term>
			/// </item>
			/// </list>
			/// </summary>
			public Guid PartitionType;

			/// <summary>The GUID of the partition.</summary>
			public Guid PartitionId;

			/// <summary>
			/// <para>The Extensible Firmware Interface (EFI) attributes of the partition.</para>
			/// <para>This member can be one or more of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>GPT_ATTRIBUTE_PLATFORM_REQUIRED 0x0000000000000001</term>
			/// <term>
			/// If this attribute is set, the partition is required by a computer to function properly. For example, this attribute must be
			/// set for OEM partitions. Note that if this attribute is set, you can use the DiskPart.exe utility to perform partition
			/// operations such as deleting the partition. However, because the partition is not a volume, you cannot use the DiskPart.exe
			/// utility to perform volume operations on the partition. This attribute can be set for basic and dynamic disks. If it is set
			/// for a partition on a basic disk and the disk is converted to a dynamic disk, the partition remains a basic partition, even
			/// though the rest of the disk is a dynamic disk. This is because the partition is considered to be an OEM partition on a GPT disk.
			/// </term>
			/// </item>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_NO_DRIVE_LETTER 0x8000000000000000</term>
			/// <term>
			/// If this attribute is set, the partition does not receive a drive letter by default when the disk is moved to another computer
			/// or when the disk is seen for the first time by a computer. This attribute is useful in storage area network (SAN)
			/// environments. Despite its name, this attribute can be set for basic and dynamic disks.
			/// </term>
			/// </item>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_HIDDEN 0x4000000000000000</term>
			/// <term>
			/// If this attribute is set, the partition is not detected by the Mount Manager. As a result, the partition does not receive a
			/// drive letter, does not receive a volume GUID path, does not host mounted folders (also called volume mount points), and is
			/// not enumerated by calls to FindFirstVolume and FindNextVolume. This ensures that applications such as Disk Defragmenter do
			/// not access the partition. The Volume Shadow Copy Service (VSS) uses this attribute. Despite its name, this attribute can be
			/// set for basic and dynamic disks.
			/// </term>
			/// </item>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_SHADOW_COPY 0x2000000000000000</term>
			/// <term>
			/// If this attribute is set, the partition is a shadow copy of another partition. VSS uses this attribute. This attribute is an
			/// indication for file system filter driver-based software (such as antivirus programs) to avoid attaching to the volume. An
			/// application can use the attribute to differentiate a shadow copy volume from a production volume. An application that does a
			/// fast recovery, for example, will break a shadow copy LUN and clear the read-only and hidden attributes and this attribute.
			/// This attribute is set when the shadow copy is created and cleared when the shadow copy is broken. Despite its name, this
			/// attribute can be set for basic and dynamic disks. Windows Server 2003: This attribute is not supported before Windows Server
			/// 2003 with SP1.
			/// </term>
			/// </item>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_READ_ONLY 0x1000000000000000</term>
			/// <term>
			/// If this attribute is set, the partition is read-only. Writes to the partition will fail. IOCTL_DISK_IS_WRITABLE will fail
			/// with the ERROR_WRITE_PROTECT Win32 error code, which causes the file system to mount as read only, if a file system is
			/// present. VSS uses this attribute. Do not set this attribute for dynamic disks. Setting it can cause I/O errors and prevent
			/// the file system from mounting properly.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public GPT_ATTRIBUTE Attributes;

			// Little hack to get 72 blittable bytes for 'Name'.
			private readonly ulong ul1;
			private readonly ulong ul2;
			private readonly ulong ul3;
			private readonly ulong ul4;
			private readonly ulong ul5;
			private readonly ulong ul6;
			private readonly ulong ul7;
			private readonly ulong ul8;
			private readonly ulong ul9;

			/// <summary>A wide-character string that describes the partition.</summary>
			public string Name
			{
				get
				{
					unsafe
					{
						fixed (ulong* p = &ul1)
						{
							return Vanara.Extensions.StringHelper.GetString((IntPtr)p, CharSet.Unicode, nameBytes);
						}
					}
				}
				set
				{
					unsafe
					{
						fixed (ulong* p = &ul1)
						{
							Vanara.Extensions.StringHelper.Write(value, (IntPtr)p, out _, true, CharSet.Unicode, nameBytes);
						}
					}
				}
			}
		}

		/// <summary>Contains partition information specific to master boot record (MBR) disks.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-partition_information_mbr typedef struct
		// _PARTITION_INFORMATION_MBR { BYTE PartitionType; BOOLEAN BootIndicator; BOOLEAN RecognizedPartition; DWORD HiddenSectors; GUID
		// PartitionId; } PARTITION_INFORMATION_MBR, *PPARTITION_INFORMATION_MBR;
		[PInvokeData("winioctl.h", MSDNShortId = "5b74b06f-ef4c-44ab-95c6-49c050faf1f4")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct PARTITION_INFORMATION_MBR
		{
			/// <summary>The type of partition. For a list of values, see Disk Partition Types.</summary>
			public PartitionType PartitionType;

			/// <summary>
			/// If the member is <c>TRUE</c>, the partition is a boot partition. When this structure is used with the
			/// IOCTL_DISK_SET_PARTITION_INFO_EX control code, the value of this parameter is ignored.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool BootIndicator;

			/// <summary>
			/// If this member is <c>TRUE</c>, the partition is of a recognized type. When this structure is used with the
			/// IOCTL_DISK_SET_PARTITION_INFO_EX control code, the value of this parameter is ignored.
			/// </summary>
			[MarshalAs(UnmanagedType.U1)] public bool RecognizedPartition;

			/// <summary>The number of hidden sectors to be allocated when the partition table is created.</summary>
			public uint HiddenSectors;

			/// <summary/>
			public Guid PartitionId;
		}

		/// <summary>
		/// Specifies the versions of the update sequence number (USN) change journal supported by the application. This structure is the
		/// input structure to the FSCTL_READ_FILE_USN_DATA control code.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-read_file_usn_data typedef struct { WORD MinMajorVersion;
		// WORD MaxMajorVersion; } READ_FILE_USN_DATA, *PREAD_FILE_USN_DATA;
		[PInvokeData("winioctl.h", MSDNShortId = "8c403eec-7504-4a69-9f05-7a3a164557a6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct READ_FILE_USN_DATA
		{
			/// <summary>
			/// The lowest version of the USN change journal accepted by the application. If the input buffer is not specified this defaults
			/// to 2.
			/// </summary>
			public ushort MinMajorVersion;

			/// <summary>
			/// The highest version of the USN change journal accepted by the application. If the input buffer is not specified this defaults
			/// to 2. To support 128-bit file identifiers used by ReFS this must be 3 or higher.
			/// </summary>
			public ushort MaxMajorVersion;
		}

		/// <summary>
		/// Contains information defining a set of update sequence number (USN) change journal records to return to the calling process. It
		/// is used by the FSCTL_QUERY_USN_JOURNAL and FSCTL_READ_USN_JOURNAL control codes. Prior to Windows 8 and Windows Server 2012 this
		/// structure was named <c>READ_USN_JOURNAL_DATA</c>. Use that name to compile with older SDKs and compilers. Windows Server 2012
		/// introduced READ_USN_JOURNAL_DATA_V1 to support 128-bit file identifiers used by ReFS.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-read_usn_journal_data_v0 typedef struct { USN StartUsn;
		// DWORD ReasonMask; DWORD ReturnOnlyOnClose; DWORDLONG Timeout; DWORDLONG BytesToWaitFor; DWORDLONG UsnJournalID; }
		// READ_USN_JOURNAL_DATA_V0, *PREAD_USN_JOURNAL_DATA_V0;
		[PInvokeData("winioctl.h", MSDNShortId = "f88e71ba-6099-4928-9d71-732a4ca809bc")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct READ_USN_JOURNAL_DATA_V0
		{
			/// <summary>
			/// <para>The USN at which to begin reading the change journal.</para>
			/// <para>
			/// To start the read operation at the first record in the journal, set the <c>StartUsn</c> member to zero. Because a USN is
			/// contained in every journal record, the output buffer tells at which record the read operation actually started.
			/// </para>
			/// <para>To start the read operation at a specific record, set <c>StartUsn</c> to that record USN.</para>
			/// <para>
			/// If a nonzero USN is specified that is less than the first USN in the change journal, then an error occurs and the
			/// <c>ERROR_JOURNAL_ENTRY_DELETED</c> error code is returned. This code may indicate a case in which the specified USN is valid
			/// at one time but has since been deleted.
			/// </para>
			/// <para>
			/// For more information on navigating the change journal buffer returned in <c>READ_USN_JOURNAL_DATA_V0</c>, see Walking a
			/// Buffer of Change Journal Records.
			/// </para>
			/// </summary>
			public long StartUsn;

			/// <summary>
			/// <para>
			/// A mask of flags, each flag noting a change for which the file or directory has a record in the change journal. To be returned
			/// in a FSCTL_READ_USN_JOURNAL operation, a change journal record must have at least one of these flags set.
			/// </para>
			/// <para>The list of valid flags is as follows. Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (such as the read-only, hidden, system, archive, or sparse
			/// attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is added to.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>Data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user makes a change to the file or directory extended attributes. These NTFS file system attributes are not accessible to
			/// Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changed the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changed the file or directory from one
			/// that can be content indexed to one that cannot, or vice versa. (Content indexing permits rapid searching of data by building
			/// a database of selected content.)
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>One or more named data streams for the file were added to.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>Data in one or more named data streams for the file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>One or more named data streams for the file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of the file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>
			/// The file or directory is renamed, and the file name in the USN_RECORD_V2 or USN_RECORD_V3 structure holding this journal
			/// record is the new name.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>
			/// The file or directory is renamed, and the file name in the USN_RECORD_V2 or USN_RECORD_V3 structure holding this journal
			/// record is the previous name.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point contained in the file or directory is changed, or a reparse point is added to or deleted from the file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access permissions to the file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from the file or directory, or a named stream is renamed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint ReasonMask;

			/// <summary>
			/// <para>A value that specifies when to return change journal records.</para>
			/// <para>
			/// To receive notification when the final handle for the changed file or directory is closed, rather than at the time a change
			/// occurs, set <c>ReturnOnlyOnClose</c> to any nonzero value and specify the <c>USN_REASON_CLOSE</c> flag in the
			/// <c>ReasonMask</c> member.
			/// </para>
			/// <para>
			/// All changes indicated by <c>ReasonMask</c> flags eventually generate a call to the change journal software when the file is
			/// closed. If your DeviceIoControl call is waiting for the file to be closed, that call in turn will allow your
			/// <c>DeviceIoControl</c> call to return. In the event that a file or directory is not closed prior to a volume failure,
			/// operating system failure, or shutdown, a cleanup call to the change journal software occurs the next time the volume is
			/// mounted. The call occurs even if there is an intervening system restart.
			/// </para>
			/// <para>
			/// To receive notification the first time each change is logged, as well as at cleanup, set <c>ReturnOnlyOnClose</c> to zero.
			/// </para>
			/// <para>
			/// Whether <c>ReturnOnlyOnClose</c> is zero or nonzero, the records generated at cleanup log within the change journal all
			/// reasons for USN changes that occurred to the file or directory. Each time a final close operation occurs for an item, a USN
			/// close record is written to the change journal, and the <c>ReasonMask</c> flags for the item are all reset.
			/// </para>
			/// <para>
			/// For a file or directory for which no user data exists (for example, a mounted folder), the final close operation occurs when
			/// the CloseHandle function is called on the last user handle to the item.
			/// </para>
			/// </summary>
			public uint ReturnOnlyOnClose;

			/// <summary>
			/// <para>
			/// The time-out value, in seconds, used with the <c>BytesToWaitFor</c> member to tell the operating system what to do if the
			/// FSCTL_READ_USN_JOURNAL operation requests more data than exists in the change journal.
			/// </para>
			/// <para>
			/// If <c>Timeout</c> is zero and <c>BytesToWaitFor</c> is nonzero, and the FSCTL_READ_USN_JOURNAL operation call reaches the end
			/// of the change journal without finding data to return, <c>FSCTL_READ_USN_JOURNAL</c> waits until <c>BytesToWaitFor</c> bytes
			/// of unfiltered data have been added to the change journal and then retrieves the specified records.
			/// </para>
			/// <para>
			/// If <c>Timeout</c> is nonzero and <c>BytesToWaitFor</c> is nonzero, and the FSCTL_READ_USN_JOURNAL operation call reaches the
			/// end of the change journal without finding data to return, <c>FSCTL_READ_USN_JOURNAL</c> waits <c>Timeout</c> seconds and then
			/// attempts to return the specified records. After <c>Timeout</c> seconds, <c>FSCTL_READ_USN_JOURNAL</c> retrieves any records
			/// available within the specified range.
			/// </para>
			/// <para>
			/// In either case, after the time-out period any new data appended to the change journal is processed. If there are still no
			/// records to return from the specified set, the time-out period is repeated. In this mode, FSCTL_READ_USN_JOURNAL remains
			/// outstanding until at least one record is returned or I/O is canceled.
			/// </para>
			/// <para>
			/// If <c>BytesToWaitFor</c> is zero, then <c>Timeout</c> is ignored. <c>Timeout</c> is also ignored for asynchronously opened handles.
			/// </para>
			/// </summary>
			public ulong Timeout;

			/// <summary>
			/// <para>
			/// The number of bytes of unfiltered data added to the change journal. Use this value with <c>Timeout</c> to tell the operating
			/// system what to do if the FSCTL_READ_USN_JOURNAL operation requests more data than exists in the change journal.
			/// </para>
			/// <para>
			/// If <c>BytesToWaitFor</c> is zero, then <c>Timeout</c> is ignored. In this case, the FSCTL_READ_USN_JOURNAL operation always
			/// returns successfully when the end of the change journal file is encountered. It also retrieves the USN that should be used
			/// for the next <c>FSCTL_READ_USN_JOURNAL</c> operation. When the returned next USN is the same as the <c>StartUsn</c> supplied,
			/// there are no records available. The calling process should not use <c>FSCTL_READ_USN_JOURNAL</c> again immediately.
			/// </para>
			/// <para>
			/// Because the amount of data returned cannot be predicted when <c>BytesToWaitFor</c> is zero, you run a risk of overflowing the
			/// output buffer. To reduce this risk, specify a nonzero <c>BytesToWaitFor</c> value in repeated FSCTL_READ_USN_JOURNAL
			/// operations until all records in the change journal are exhausted. Then specify zero to await new records.
			/// </para>
			/// <para>
			/// Alternatively, use the lpBytesReturned parameter of DeviceIoControl in the FSCTL_READ_USN_JOURNAL operation call to determine
			/// the amount of data available, reallocate the output buffer (with room to spare for new records), and call
			/// <c>DeviceIoControl</c> again.
			/// </para>
			/// </summary>
			public ulong BytesToWaitFor;

			/// <summary>
			/// <para>The identifier for the instance of the journal that is current for the volume.</para>
			/// <para>
			/// The NTFS file system can miss putting events in the change journal if the change journal is stopped and restarted or deleted
			/// and re-created. If either of these events occurs, the NTFS file system gives the journal a new identifier. If the journal
			/// identifier does not agree with the current journal identifier, the call to DeviceIoControl fails and returns an appropriate
			/// error code. To retrieve the new journal identifier, call <c>DeviceIoControl</c> with the FSCTL_QUERY_USN_JOURNAL operation.
			/// </para>
			/// </summary>
			public ulong UsnJournalID;
		}

		/// <summary>
		/// Contains information defining a set of update sequence number (USN) change journal records to return to the calling process. It
		/// is used by the FSCTL_QUERY_USN_JOURNAL and FSCTL_READ_USN_JOURNAL control codes. Prior to Windows 8 and Windows Server 2012 this
		/// structure was named <c>READ_USN_JOURNAL_DATA</c>. Use that name to compile with older SDKs and compilers. Windows Server 2012
		/// introduced READ_USN_JOURNAL_DATA_V1 to support 128-bit file identifiers used by ReFS.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-read_usn_journal_data_v1 typedef struct { USN StartUsn;
		// DWORD ReasonMask; DWORD ReturnOnlyOnClose; DWORDLONG Timeout; DWORDLONG BytesToWaitFor; DWORDLONG UsnJournalID; WORD
		// MinMajorVersion; WORD MaxMajorVersion; } READ_USN_JOURNAL_DATA_V1, *PREAD_USN_JOURNAL_DATA_V1;
		[PInvokeData("winioctl.h", MSDNShortId = "f88e71ba-6099-4928-9d71-732a4ca809bc")]
		[StructLayout(LayoutKind.Sequential, Pack = 8, Size = 48)]
		public struct READ_USN_JOURNAL_DATA_V1
		{
			/// <summary>
			/// <para>The USN at which to begin reading the change journal.</para>
			/// <para>
			/// To start the read operation at the first record in the journal, set the <c>StartUsn</c> member to zero. Because a USN is
			/// contained in every journal record, the output buffer tells at which record the read operation actually started.
			/// </para>
			/// <para>To start the read operation at a specific record, set <c>StartUsn</c> to that record USN.</para>
			/// <para>
			/// If a nonzero USN is specified that is less than the first USN in the change journal, then an error occurs and the
			/// <c>ERROR_JOURNAL_ENTRY_DELETED</c> error code is returned. This code may indicate a case in which the specified USN is valid
			/// at one time but has since been deleted.
			/// </para>
			/// <para>
			/// For more information on navigating the change journal buffer returned in <c>READ_USN_JOURNAL_DATA_V0</c>, see Walking a
			/// Buffer of Change Journal Records.
			/// </para>
			/// </summary>
			public long StartUsn;

			/// <summary>
			/// <para>
			/// A mask of flags, each flag noting a change for which the file or directory has a record in the change journal. To be returned
			/// in a FSCTL_READ_USN_JOURNAL operation, a change journal record must have at least one of these flags set.
			/// </para>
			/// <para>The list of valid flags is as follows. Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (such as the read-only, hidden, system, archive, or sparse
			/// attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is added to.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>Data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user makes a change to the file or directory extended attributes. These NTFS file system attributes are not accessible to
			/// Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changed the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changed the file or directory from one
			/// that can be content indexed to one that cannot, or vice versa. (Content indexing permits rapid searching of data by building
			/// a database of selected content.)
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>One or more named data streams for the file were added to.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>Data in one or more named data streams for the file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>One or more named data streams for the file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of the file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>
			/// The file or directory is renamed, and the file name in the USN_RECORD_V2 or USN_RECORD_V3 structure holding this journal
			/// record is the new name.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>
			/// The file or directory is renamed, and the file name in the USN_RECORD_V2 or USN_RECORD_V3 structure holding this journal
			/// record is the previous name.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point contained in the file or directory is changed, or a reparse point is added to or deleted from the file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access permissions to the file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from the file or directory, or a named stream is renamed.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint ReasonMask;

			/// <summary>
			/// <para>A value that specifies when to return change journal records.</para>
			/// <para>
			/// To receive notification when the final handle for the changed file or directory is closed, rather than at the time a change
			/// occurs, set <c>ReturnOnlyOnClose</c> to any nonzero value and specify the <c>USN_REASON_CLOSE</c> flag in the
			/// <c>ReasonMask</c> member.
			/// </para>
			/// <para>
			/// All changes indicated by <c>ReasonMask</c> flags eventually generate a call to the change journal software when the file is
			/// closed. If your DeviceIoControl call is waiting for the file to be closed, that call in turn will allow your
			/// <c>DeviceIoControl</c> call to return. In the event that a file or directory is not closed prior to a volume failure,
			/// operating system failure, or shutdown, a cleanup call to the change journal software occurs the next time the volume is
			/// mounted. The call occurs even if there is an intervening system restart.
			/// </para>
			/// <para>
			/// To receive notification the first time each change is logged, as well as at cleanup, set <c>ReturnOnlyOnClose</c> to zero.
			/// </para>
			/// <para>
			/// Whether <c>ReturnOnlyOnClose</c> is zero or nonzero, the records generated at cleanup log within the change journal all
			/// reasons for USN changes that occurred to the file or directory. Each time a final close operation occurs for an item, a USN
			/// close record is written to the change journal, and the <c>ReasonMask</c> flags for the item are all reset.
			/// </para>
			/// <para>
			/// For a file or directory for which no user data exists (for example, a mounted folder), the final close operation occurs when
			/// the CloseHandle function is called on the last user handle to the item.
			/// </para>
			/// </summary>
			public uint ReturnOnlyOnClose;

			/// <summary>
			/// <para>
			/// The time-out value, in seconds, used with the <c>BytesToWaitFor</c> member to tell the operating system what to do if the
			/// FSCTL_READ_USN_JOURNAL operation requests more data than exists in the change journal.
			/// </para>
			/// <para>
			/// If <c>Timeout</c> is zero and <c>BytesToWaitFor</c> is nonzero, and the FSCTL_READ_USN_JOURNAL operation call reaches the end
			/// of the change journal without finding data to return, <c>FSCTL_READ_USN_JOURNAL</c> waits until <c>BytesToWaitFor</c> bytes
			/// of unfiltered data have been added to the change journal and then retrieves the specified records.
			/// </para>
			/// <para>
			/// If <c>Timeout</c> is nonzero and <c>BytesToWaitFor</c> is nonzero, and the FSCTL_READ_USN_JOURNAL operation call reaches the
			/// end of the change journal without finding data to return, <c>FSCTL_READ_USN_JOURNAL</c> waits <c>Timeout</c> seconds and then
			/// attempts to return the specified records. After <c>Timeout</c> seconds, <c>FSCTL_READ_USN_JOURNAL</c> retrieves any records
			/// available within the specified range.
			/// </para>
			/// <para>
			/// In either case, after the time-out period any new data appended to the change journal is processed. If there are still no
			/// records to return from the specified set, the time-out period is repeated. In this mode, FSCTL_READ_USN_JOURNAL remains
			/// outstanding until at least one record is returned or I/O is canceled.
			/// </para>
			/// <para>
			/// If <c>BytesToWaitFor</c> is zero, then <c>Timeout</c> is ignored. <c>Timeout</c> is also ignored for asynchronously opened handles.
			/// </para>
			/// </summary>
			public ulong Timeout;

			/// <summary>
			/// <para>
			/// The number of bytes of unfiltered data added to the change journal. Use this value with <c>Timeout</c> to tell the operating
			/// system what to do if the FSCTL_READ_USN_JOURNAL operation requests more data than exists in the change journal.
			/// </para>
			/// <para>
			/// If <c>BytesToWaitFor</c> is zero, then <c>Timeout</c> is ignored. In this case, the FSCTL_READ_USN_JOURNAL operation always
			/// returns successfully when the end of the change journal file is encountered. It also retrieves the USN that should be used
			/// for the next <c>FSCTL_READ_USN_JOURNAL</c> operation. When the returned next USN is the same as the <c>StartUsn</c> supplied,
			/// there are no records available. The calling process should not use <c>FSCTL_READ_USN_JOURNAL</c> again immediately.
			/// </para>
			/// <para>
			/// Because the amount of data returned cannot be predicted when <c>BytesToWaitFor</c> is zero, you run a risk of overflowing the
			/// output buffer. To reduce this risk, specify a nonzero <c>BytesToWaitFor</c> value in repeated FSCTL_READ_USN_JOURNAL
			/// operations until all records in the change journal are exhausted. Then specify zero to await new records.
			/// </para>
			/// <para>
			/// Alternatively, use the lpBytesReturned parameter of DeviceIoControl in the FSCTL_READ_USN_JOURNAL operation call to determine
			/// the amount of data available, reallocate the output buffer (with room to spare for new records), and call
			/// <c>DeviceIoControl</c> again.
			/// </para>
			/// </summary>
			public ulong BytesToWaitFor;

			/// <summary>
			/// <para>The identifier for the instance of the journal that is current for the volume.</para>
			/// <para>
			/// The NTFS file system can miss putting events in the change journal if the change journal is stopped and restarted or deleted
			/// and re-created. If either of these events occurs, the NTFS file system gives the journal a new identifier. If the journal
			/// identifier does not agree with the current journal identifier, the call to DeviceIoControl fails and returns an appropriate
			/// error code. To retrieve the new journal identifier, call <c>DeviceIoControl</c> with the FSCTL_QUERY_USN_JOURNAL operation.
			/// </para>
			/// </summary>
			public ulong UsnJournalID;

			/// <summary/>
			public ushort MinMajorVersion;

			/// <summary/>
			public ushort MaxMajorVersion;
		}

		/// <summary>
		/// Represents an update sequence number (USN) change journal, its records, and its capacity. This structure is the output buffer for
		/// the FSCTL_QUERY_USN_JOURNAL control code. Prior to Windows 8 and Windows Server 2012 this structure was named
		/// <c>USN_JOURNAL_DATA</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_journal_data_v0 typedef struct { DWORDLONG
		// UsnJournalID; USN FirstUsn; USN NextUsn; USN LowestValidUsn; USN MaxUsn; DWORDLONG MaximumSize; DWORDLONG AllocationDelta; }
		// USN_JOURNAL_DATA_V0, *PUSN_JOURNAL_DATA_V0;
		[PInvokeData("winioctl.h", MSDNShortId = "6b75eab2-aa10-4b48-8918-e4b03b5d8564")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_JOURNAL_DATA_V0
		{
			/// <summary>
			/// The current journal identifier. A journal is assigned a new identifier on creation and can be stamped with a new identifier
			/// in the course of its existence. The NTFS file system uses this identifier for an integrity check.
			/// </summary>
			public ulong UsnJournalID;

			/// <summary>The number of first record that can be read from the journal.</summary>
			public long FirstUsn;

			/// <summary>The number of next record to be written to the journal.</summary>
			public long NextUsn;

			/// <summary>
			/// The first record that was written into the journal for this journal instance. Enumerating the files or directories on a
			/// volume can return a USN lower than this value (in other words, a <c>FirstUsn</c> member value less than the
			/// <c>LowestValidUsn</c> member value). If it does, the journal has been stamped with a new identifier since the last USN was
			/// written. In this case, <c>LowestValidUsn</c> may indicate a discontinuity in the journal, in which changes to some or all
			/// files or directories on the volume may have occurred that are not recorded in the change journal.
			/// </summary>
			public long LowestValidUsn;

			/// <summary>
			/// The largest USN that the change journal supports. An administrator must delete the change journal as the value of
			/// <c>NextUsn</c> approaches this value.
			/// </summary>
			public long MaxUsn;

			/// <summary>
			/// The target maximum size for the change journal, in bytes. The change journal can grow larger than this value, but it is then
			/// truncated at the next NTFS file system checkpoint to less than this value.
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// The number of bytes of disk memory added to the end and removed from the beginning of the change journal each time memory is
			/// allocated or deallocated. In other words, allocation and deallocation take place in units of this size. An integer multiple
			/// of a cluster size is a reasonable value for this member.
			/// </summary>
			public ulong AllocationDelta;
		}

		/// <summary>
		/// Represents an update sequence number (USN) change journal, its records, and its capacity. This structure is the output buffer for
		/// the FSCTL_QUERY_USN_JOURNAL control code. Prior to Windows 8 and Windows Server 2012 this structure was named
		/// <c>USN_JOURNAL_DATA</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_journal_data_v1 typedef struct { DWORDLONG
		// UsnJournalID; USN FirstUsn; USN NextUsn; USN LowestValidUsn; USN MaxUsn; DWORDLONG MaximumSize; DWORDLONG AllocationDelta; WORD
		// MinSupportedMajorVersion; WORD MaxSupportedMajorVersion; } USN_JOURNAL_DATA_V1, *PUSN_JOURNAL_DATA_V1;
		[PInvokeData("winioctl.h", MSDNShortId = "6b75eab2-aa10-4b48-8918-e4b03b5d8564")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_JOURNAL_DATA_V1
		{
			/// <summary>
			/// The current journal identifier. A journal is assigned a new identifier on creation and can be stamped with a new identifier
			/// in the course of its existence. The NTFS file system uses this identifier for an integrity check.
			/// </summary>
			public ulong UsnJournalID;

			/// <summary>The number of first record that can be read from the journal.</summary>
			public long FirstUsn;

			/// <summary>The number of next record to be written to the journal.</summary>
			public long NextUsn;

			/// <summary>
			/// The first record that was written into the journal for this journal instance. Enumerating the files or directories on a
			/// volume can return a USN lower than this value (in other words, a <c>FirstUsn</c> member value less than the
			/// <c>LowestValidUsn</c> member value). If it does, the journal has been stamped with a new identifier since the last USN was
			/// written. In this case, <c>LowestValidUsn</c> may indicate a discontinuity in the journal, in which changes to some or all
			/// files or directories on the volume may have occurred that are not recorded in the change journal.
			/// </summary>
			public long LowestValidUsn;

			/// <summary>
			/// The largest USN that the change journal supports. An administrator must delete the change journal as the value of
			/// <c>NextUsn</c> approaches this value.
			/// </summary>
			public long MaxUsn;

			/// <summary>
			/// The target maximum size for the change journal, in bytes. The change journal can grow larger than this value, but it is then
			/// truncated at the next NTFS file system checkpoint to less than this value.
			/// </summary>
			public ulong MaximumSize;

			/// <summary>
			/// The number of bytes of disk memory added to the end and removed from the beginning of the change journal each time memory is
			/// allocated or deallocated. In other words, allocation and deallocation take place in units of this size. An integer multiple
			/// of a cluster size is a reasonable value for this member.
			/// </summary>
			public ulong AllocationDelta;

			/// <summary/>
			public ushort MinSupportedMajorVersion;

			/// <summary/>
			public ushort MaxSupportedMajorVersion;
		}

		/// <summary>
		/// Represents an update sequence number (USN) change journal, its records, and its capacity. This structure is the output buffer for
		/// the FSCTL_QUERY_USN_JOURNAL control code.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_journal_data_v2 typedef struct { DWORDLONG
		// UsnJournalID; USN FirstUsn; USN NextUsn; USN LowestValidUsn; USN MaxUsn; DWORDLONG MaximumSize; DWORDLONG AllocationDelta; WORD
		// MinSupportedMajorVersion; WORD MaxSupportedMajorVersion; DWORD Flags; DWORDLONG RangeTrackChunkSize; LONGLONG
		// RangeTrackFileSizeThreshold; } USN_JOURNAL_DATA_V2, *PUSN_JOURNAL_DATA_V2;
		[PInvokeData("winioctl.h", MSDNShortId = "BBFA6D14-1423-45B0-83A0-62019D08507F")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_JOURNAL_DATA_V2
		{
			/// <summary>
			/// The current journal identifier. A journal is assigned a new identifier on creation and can be stamped with a new identifier
			/// in the course of its existence. The NTFS file system uses this identifier for an integrity check.
			/// </summary>
			public ulong UsnJournalID;

			/// <summary>The number of first record that can be read from the journal.</summary>
			public long FirstUsn;

			/// <summary>The number of next record to be written to the journal.</summary>
			public long NextUsn;

			/// <summary>
			/// The first record that was written into the journal for this journal instance. Enumerating the files or directories on a
			/// volume can return a USN lower than this value (in other words, a <c>FirstUsn</c> member value less than the
			/// <c>LowestValidUsn</c> member value). If it does, the journal has been stamped with a new identifier since the last USN was
			/// written. In this case, <c>LowestValidUsn</c> may indicate a discontinuity in the journal, in which changes to some or all
			/// files or directories on the volume may have occurred that are not recorded in the change journal.
			/// </summary>
			public long LowestValidUsn;

			/// <summary>
			/// The largest USN that the change journal supports. An administrator must delete the change journal as the value of
			/// <c>NextUsn</c> approaches this value.
			/// </summary>
			public long MaxUsn;

			/// <summary>
			/// The target maximum size for the change journal, in bytes. The change journal can grow larger than this value, but it is then
			/// truncated at the next NTFS file system checkpoint to less than this value.
			/// </summary>
			public long MaximumSize;

			/// <summary>
			/// The number of bytes of disk memory added to the end and removed from the beginning of the change journal each time memory is
			/// allocated or deallocated. In other words, allocation and deallocation take place in units of this size. An integer multiple
			/// of a cluster size is a reasonable value for this member.
			/// </summary>
			public ulong AllocationDelta;

			/// <summary>The minimum version of the USN change journal that the file system supports.</summary>
			public ushort MinSupportedMajorVersion;

			/// <summary>The maximum version of the USN change journal that the file system supports.</summary>
			public ushort MaxSupportedMajorVersion;

			/// <summary>
			/// <para>Whether or not range tracking is turned on. The following are the possible values for the <c>Flags</c> member.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>0x00000000</term>
			/// <term>Range tracking is not turned on for the volume.</term>
			/// </item>
			/// <item>
			/// <term>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE 0x00000001</term>
			/// <term>Range tracking is turned on for the volume.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags;

			/// <summary>The granularity of tracked ranges. Valid only when you also set the <c>Flags</c> member to <c>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE</c>.</summary>
			public ulong RangeTrackChunkSize;

			/// <summary>
			/// File size threshold to start tracking range for files with equal or larger size. Valid only when you also set the
			/// <c>Flags</c> member to <c>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE</c>.
			/// </summary>
			public long RangeTrackFileSizeThreshold;
		}

		/// <summary>Contains returned update sequence number (USN) from FSCTL_USN_TRACK_MODIFIED_RANGES control code.</summary>
		/// <remarks>This structure is optional.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_range_track_output typedef struct { USN Usn; }
		// USN_RANGE_TRACK_OUTPUT, *PUSN_RANGE_TRACK_OUTPUT;
		[PInvokeData("winioctl.h", MSDNShortId = "E10ECB50-A506-4836-81D2-3073FBB844CA")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_RANGE_TRACK_OUTPUT
		{
			/// <summary>
			/// Returned update sequence number (USN) that identifies at what point in the USN Journal that range tracking was enabled.
			/// </summary>
			public long Usn;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) common header which is common through USN_RECORD_V2, USN_RECORD_V3
		/// and USN_RECORD_V4.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_common_header typedef struct { DWORD
		// RecordLength; WORD MajorVersion; WORD MinorVersion; } USN_RECORD_COMMON_HEADER, *PUSN_RECORD_COMMON_HEADER;
		[PInvokeData("winioctl.h", MSDNShortId = "7B193D8E-FEED-4289-B40F-33BC27889F15")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_RECORD_COMMON_HEADER
		{
			/// <summary>
			/// <para>The total length of a record, in bytes.</para>
			/// <para>
			/// Because USN record is a variable size, the <c>RecordLength</c> member should be used when calculating the address of the next
			/// record in an output buffer, for example, a buffer that is returned from operations for the DeviceIoControl function that work
			/// with different USN record types.
			/// </para>
			/// <para>
			/// For USN_RECORD_V4, the size in bytes of any change journal record is at most the size of the structure, plus
			/// (NumberOfExtents-1) times size of the USN_RECORD_EXTENT.
			/// </para>
			/// </summary>
			public uint RecordLength;

			/// <summary>
			/// <para>The major version number of the change journal software for this record.</para>
			/// <para>For example, if the change journal software is version 4.0, the major version number is 4.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The structure is a USN_RECORD_V2 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The structure is a USN_RECORD_V3 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The structure is a USN_RECORD_V4 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MajorVersion;

			/// <summary>
			/// The minor version number of the change journal software for this record. For example, if the change journal software is
			/// version 4.0, the minor version number is zero.
			/// </summary>
			public ushort MinorVersion;
		}

		/// <summary>Contains the offset and length for an update sequence number (USN) record extent.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_extent typedef struct { LONGLONG Offset;
		// LONGLONG Length; } USN_RECORD_EXTENT, *PUSN_RECORD_EXTENT;
		[PInvokeData("winioctl.h", MSDNShortId = "7D569FCB-06D4-4348-B75A-D087D1D37851")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_RECORD_EXTENT
		{
			/// <summary>The offset of the extent, in bytes.</summary>
			public long Offset;

			/// <summary>The length of the extent, in bytes.</summary>
			public long Length;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) change journal version 2.0 record. Applications should not attempt
		/// to work with change journal versions earlier than 2.0. Prior to Windows 8 and Windows Server 2012 this structure was named
		/// <c>USN_RECORD</c>. Use that name to compile with older SDKs and compilers.
		/// </summary>
		/// <remarks>
		/// <para>
		/// In output buffers returned from DeviceIoControl operations that work with <c>USN_RECORD_V2</c>, all records are aligned on 64-bit
		/// boundaries from the start of the buffer.
		/// </para>
		/// <para>
		/// To provide a path for upward compatibility in change journal clients, Microsoft provides a major and minor version number of the
		/// change journal software in the <c>USN_RECORD_V2</c> structure. Your code should examine these values, detect its own
		/// compatibility with the change journal software, and if necessary gracefully handle any incompatibility.
		/// </para>
		/// <para>
		/// A change in the minor version number indicates that the existing <c>USN_RECORD_V2</c> structure members are still valid, but that
		/// new members may have been added between the penultimate member and the last, which is a variable-length string.
		/// </para>
		/// <para>
		/// To handle such a change gracefully, your code should not do any compile-time pointer arithmetic that relies on the location of
		/// the last member. For example, this makes the C code unreliable. Instead, rely on run-time calculations by using the
		/// <c>RecordLength</c> member.
		/// </para>
		/// <para>
		/// An increase in the major version number of the change journal software indicates that the <c>USN_RECORD_V2</c> structure may have
		/// undergone major changes, and that the current definition may not be reliable. If your code detects a change in the major version
		/// number of the change journal software, it should not work with the change journal.
		/// </para>
		/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_v2 typedef struct { DWORD RecordLength; WORD
		// MajorVersion; WORD MinorVersion; DWORDLONG FileReferenceNumber; DWORDLONG ParentFileReferenceNumber; USN Usn; LARGE_INTEGER
		// TimeStamp; DWORD Reason; DWORD SourceInfo; DWORD SecurityId; DWORD FileAttributes; WORD FileNameLength; WORD FileNameOffset; WCHAR
		// FileName[1]; } USN_RECORD_V2, *PUSN_RECORD_V2;
		[PInvokeData("winioctl.h", MSDNShortId = "1747453d-fd18-4853-a953-47131f3067ae")]
		[StructLayout(LayoutKind.Sequential, Size = 64, CharSet = CharSet.Unicode)]
		public struct USN_RECORD_V2
		{
			/// <summary>
			/// <para>The total length of a record, in bytes.</para>
			/// <para>
			/// Because <c>USN_RECORD_V2</c> is a variable size, the <c>RecordLength</c> member should be used when calculating the address
			/// of the next record in an output buffer, for example, a buffer that is returned from operations for the DeviceIoControl
			/// function that work with <c>USN_RECORD_V2</c>.
			/// </para>
			/// <para>
			/// The size in bytes of any change journal record is at most the size of the <c>USN_RECORD_V2</c> structure, plus
			/// MaximumComponentLength characters minus 1 (for the character declared in the structure) times the size of a wide character.
			/// The value of MaximumComponentLength may be determined by calling the GetVolumeInformation function. In C, you can determine a
			/// record size by using the following code example.
			/// </para>
			/// <para>
			/// To maintain compatibility across version changes of the change journal software, use a run-time calculation to determine the
			/// size of the
			/// </para>
			/// <para>USN_RECORD_V2</para>
			/// <para>structure. For more information about compatibility across version changes, see the Remarks section in this topic.</para>
			/// </summary>
			public uint RecordLength;

			/// <summary>
			/// <para>The major version number of the change journal software for this record.</para>
			/// <para>For example, if the change journal software is version 2.0, the major version number is 2.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The structure is a USN_RECORD_V2 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The structure is a USN_RECORD_V3 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The structure is a USN_RECORD_V4 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MajorVersion;

			/// <summary>
			/// The minor version number of the change journal software for this record. For example, if the change journal software is
			/// version 2.0, the minor version number is zero.
			/// </summary>
			public ushort MinorVersion;

			/// <summary>
			/// <para>The ordinal number of the file or directory for which this record notes changes.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a file.</para>
			/// </summary>
			public ulong FileReferenceNumber;

			/// <summary>
			/// <para>The ordinal number of the directory where the file or directory that is associated with this record is located.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a parent directory.</para>
			/// </summary>
			public ulong ParentFileReferenceNumber;

			/// <summary>The USN of this record.</summary>
			public long Usn;

			/// <summary>The standard UTC time stamp (FILETIME) of this record, in 64-bit format.</summary>
			public FILETIME TimeStamp;

			/// <summary>
			/// <para>
			/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
			/// directory opened.
			/// </para>
			/// <para>
			/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next
			/// change (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
			/// </para>
			/// <para>
			/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
			/// records a new parent.
			/// </para>
			/// <para>The following table identifies the possible flags.</para>
			/// <para><c>Note</c> Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
			/// sparse attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>The data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user made a change to the extended attributes of a file or directory. These NTFS file system attributes are not
			/// accessible to Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changes the file or directory from one
			/// where content can be indexed to one where content cannot be indexed, or vice versa. Content indexing permits rapid searching
			/// of data by building a database of selected content.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INTEGRITY_CHANGE 0x00800000</term>
			/// <term>
			/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream. On the ReFS file system,
			/// integrity streams maintain a checksum of all data for that stream, so that the contents of the file can be validated during
			/// read or write operations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>The one or more named data streams for a file are extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>The data in one or more named data streams for a file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>The one or more named data streams for a file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of a file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>A file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the new name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>The file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the previous name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
			/// or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access rights to a file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from a file, or a named stream is renamed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_TRANSACTED_CHANGE 0x00400000</term>
			/// <term>The given stream is modified through a TxF transaction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_REASON Reason;

			/// <summary>
			/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
			/// <para>
			/// When a thread writes a new USN record, the source information flags in the prior record continues to be present only if the
			/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that
			/// are set only by a known source, for example, an antivirus filter.
			/// </para>
			/// <para>One of the two following values can be set.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_SOURCE_AUXILIARY_DATA 0x00000002</term>
			/// <term>
			/// The operation adds a private data stream to a file or directory. An example might be a virus detector adding checksum
			/// information. As the virus detector modifies the item, the system generates USN records. USN_SOURCE_AUXILIARY_DATA indicates
			/// that the modifications did not change the application data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_DATA_MANAGEMENT 0x00000001</term>
			/// <term>
			/// The operation provides information about a change to the file or directory made by the operating system. A typical use is
			/// when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical storage
			/// management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record. However, the
			/// data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo member, you can
			/// determine that although a write operation is performed on the item, data has not changed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_REPLICATION_MANAGEMENT 0x00000004</term>
			/// <term>
			/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT 0x00000008</term>
			/// <term>The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_SOURCE SourceInfo;

			/// <summary>The unique security identifier assigned to the file or directory associated with this record.</summary>
			public uint SecurityId;

			/// <summary>
			/// The attributes for the file or directory associated with this record, as returned by the GetFileAttributes function.
			/// Attributes of streams associated with the file or directory are excluded.
			/// </summary>
			public uint FileAttributes;

			/// <summary>
			/// The length of the name of the file or directory associated with this record, in bytes. The <c>FileName</c> member contains
			/// this name. Use this member to determine file name length, rather than depending on a trailing '\0' to delimit the file name
			/// in <c>FileName</c>.
			/// </summary>
			public ushort FileNameLength;

			/// <summary>The offset of the <c>FileName</c> member from the beginning of the structure.</summary>
			public ushort FileNameOffset;

			/// <summary>
			/// <para>
			/// The name of the file or directory associated with this record in Unicode format. This file or directory name is of variable length.
			/// </para>
			/// <para>
			/// When working with <c>FileName</c>, do not count on the file name that contains a trailing '\0' delimiter, but instead
			/// determine the length of the file name by using <c>FileNameLength</c>.
			/// </para>
			/// <para>
			/// Do not perform any compile-time pointer arithmetic using <c>FileName</c>. Instead, make necessary calculations at run time by
			/// using the value of the <c>FileNameOffset</c> member. Doing so helps make your code compatible with any future versions of <c>USN_RECORD_V2</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string FileName;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) change journal version 3.0 record. The version 2.0 record is defined
		/// by the USN_RECORD_V2 structure (also called <c>USN_RECORD</c> structure).
		/// </summary>
		/// <remarks>
		/// <para>
		/// In output buffers returned from DeviceIoControl operations that work with <c>USN_RECORD_V3</c>, all records are aligned on 64-bit
		/// boundaries from the start of the buffer.
		/// </para>
		/// <para>When range tracking is turned on, NTFS switches to producing only <c>USN_RECORD_V3</c> records as output.</para>
		/// <para>
		/// To provide a path for upward compatibility in change journal clients, Microsoft provides a major and minor version number of the
		/// change journal software in the <c>USN_RECORD_V3</c> structure. Your code should examine these values, detect its own
		/// compatibility with the change journal software, and if necessary gracefully handle any incompatibility.
		/// </para>
		/// <para>
		/// A change in the minor version number indicates that the existing <c>USN_RECORD_V3</c> structure members are still valid, but that
		/// new members may have been added between the penultimate member and the last, which is a variable-length string.
		/// </para>
		/// <para>
		/// To handle such a change gracefully, your code should not do any compile-time pointer arithmetic that relies on the location of
		/// the last member. For example, this makes the C code unreliable. Instead, rely on run-time calculations by using the
		/// <c>RecordLength</c> member.
		/// </para>
		/// <para>
		/// An increase in the major version number of the change journal software indicates that the <c>USN_RECORD_V3</c> structure may have
		/// undergone major changes, and that the current definition may not be reliable. If your code detects a change in the major version
		/// number of the change journal software, it should not work with the change journal.
		/// </para>
		/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_v3 typedef struct { DWORD RecordLength; WORD
		// MajorVersion; WORD MinorVersion; FILE_ID_128 FileReferenceNumber; FILE_ID_128 ParentFileReferenceNumber; USN Usn; LARGE_INTEGER
		// TimeStamp; DWORD Reason; DWORD SourceInfo; DWORD SecurityId; DWORD FileAttributes; WORD FileNameLength; WORD FileNameOffset; WCHAR
		// FileName[1]; } USN_RECORD_V3, *PUSN_RECORD_V3;
		[PInvokeData("winioctl.h", MSDNShortId = "6d95c5d1-6c6b-498f-a00d-eaa540e8b15b")]
		[StructLayout(LayoutKind.Sequential, Size = 80, CharSet = CharSet.Unicode)]
		public struct USN_RECORD_V3
		{
			/// <summary>
			/// <para>The total length of a record, in bytes.</para>
			/// <para>
			/// Because <c>USN_RECORD_V3</c> is a variable size, the <c>RecordLength</c> member should be used when calculating the address
			/// of the next record in an output buffer, for example, a buffer that is returned from operations for the DeviceIoControl
			/// function that work with <c>USN_RECORD_V3</c>.
			/// </para>
			/// <para>
			/// The size in bytes of any change journal record is at most the size of the <c>USN_RECORD_V3</c> structure, plus
			/// MaximumComponentLength characters minus 1 (for the character declared in the structure) times the size of a wide character.
			/// The value of MaximumComponentLength may be determined by calling the GetVolumeInformation function. In C, you can determine a
			/// record size by using the following code example.
			/// </para>
			/// <para>
			/// To maintain compatibility across version changes of the change journal software, use a run-time calculation to determine the
			/// size of the
			/// </para>
			/// <para>USN_RECORD_V3</para>
			/// <para>structure. For more information about compatibility across version changes, see the Remarks section in this topic.</para>
			/// </summary>
			public uint RecordLength;

			/// <summary>
			/// <para>The major version number of the change journal software for this record.</para>
			/// <para>For example, if the change journal software is version 3.0, the major version number is 3.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>2</term>
			/// <term>The structure is a USN_RECORD_V2 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>3</term>
			/// <term>The structure is a USN_RECORD_V3 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// <item>
			/// <term>4</term>
			/// <term>The structure is a USN_RECORD_V4 structure and the remainder of the structure should be parsed using that layout.</term>
			/// </item>
			/// </list>
			/// </summary>
			public ushort MajorVersion;

			/// <summary>
			/// The minor version number of the change journal software for this record. For example, if the change journal software is
			/// version 3.0, the minor version number is zero.
			/// </summary>
			public ushort MinorVersion;

			/// <summary>
			/// <para>The 128-bit ordinal number of the file or directory for which this record notes changes.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a file.</para>
			/// </summary>
			public FILE_ID_128 FileReferenceNumber;

			/// <summary>
			/// <para>The 128-bit ordinal number of the directory where the file or directory that is associated with this record is located.</para>
			/// <para>This is an arbitrarily assigned value that associates a journal record with a parent directory.</para>
			/// </summary>
			public FILE_ID_128 ParentFileReferenceNumber;

			/// <summary>The USN of this record.</summary>
			public long Usn;

			/// <summary>The standard UTC time stamp (FILETIME) of this record, in 64-bit format.</summary>
			public FILETIME TimeStamp;

			/// <summary>
			/// <para>
			/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
			/// directory opened.
			/// </para>
			/// <para>
			/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next
			/// change (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
			/// </para>
			/// <para>
			/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
			/// records a new parent.
			/// </para>
			/// <para>The following table identifies the possible flags.</para>
			/// <para><c>Note</c> Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
			/// sparse attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>The data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user made a change to the extended attributes of a file or directory. These NTFS file system attributes are not
			/// accessible to Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changes the file or directory from one
			/// where content can be indexed to one where content cannot be indexed, or vice versa. Content indexing permits rapid searching
			/// of data by building a database of selected content.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INTEGRITY_CHANGE 0x00800000</term>
			/// <term>
			/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream. On the ReFS file system,
			/// integrity streams maintain a checksum of all data for that stream, so that the contents of the file can be validated during
			/// read or write operations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>The one or more named data streams for a file are extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>The data in one or more named data streams for a file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>The one or more named data streams for a file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of a file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>A file or directory is renamed, and the file name in the USN_RECORD_V3 structure is the new name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>The file or directory is renamed, and the file name in the USN_RECORD_V3 structure is the previous name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
			/// or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access rights to a file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from a file, or a named stream is renamed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_TRANSACTED_CHANGE 0x00400000</term>
			/// <term>The given stream is modified through a TxF transaction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_REASON Reason;

			/// <summary>
			/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
			/// <para>
			/// When a thread writes a new USN record, the source information flags in the prior record continues to be present only if the
			/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that
			/// are set only by a known source, for example, an antivirus filter.
			/// </para>
			/// <para>One of the two following values can be set.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_SOURCE_AUXILIARY_DATA 0x00000002</term>
			/// <term>
			/// The operation adds a private data stream to a file or directory. An example might be a virus detector adding checksum
			/// information. As the virus detector modifies the item, the system generates USN records. USN_SOURCE_AUXILIARY_DATA indicates
			/// that the modifications did not change the application data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_DATA_MANAGEMENT 0x00000001</term>
			/// <term>
			/// The operation provides information about a change to the file or directory made by the operating system. A typical use is
			/// when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical storage
			/// management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record. However, the
			/// data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo member, you can
			/// determine that although a write operation is performed on the item, data has not changed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_REPLICATION_MANAGEMENT 0x00000004</term>
			/// <term>
			/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT 0x00000008</term>
			/// <term>The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_SOURCE SourceInfo;

			/// <summary>The unique security identifier assigned to the file or directory associated with this record.</summary>
			public uint SecurityId;

			/// <summary>
			/// The attributes for the file or directory associated with this record, as returned by the GetFileAttributes function.
			/// Attributes of streams associated with the file or directory are excluded.
			/// </summary>
			public uint FileAttributes;

			/// <summary>
			/// The length of the name of the file or directory associated with this record, in bytes. The <c>FileName</c> member contains
			/// this name. Use this member to determine file name length, rather than depending on a trailing '\0' to delimit the file name
			/// in <c>FileName</c>.
			/// </summary>
			public ushort FileNameLength;

			/// <summary>The offset of the <c>FileName</c> member from the beginning of the structure.</summary>
			public ushort FileNameOffset;

			/// <summary>
			/// <para>
			/// The name of the file or directory associated with this record in Unicode format. This file or directory name is of variable length.
			/// </para>
			/// <para>
			/// When working with <c>FileName</c>, do not count on the file name that contains a trailing '\0' delimiter, but instead
			/// determine the length of the file name by using <c>FileNameLength</c>.
			/// </para>
			/// <para>
			/// Do not perform any compile-time pointer arithmetic using <c>FileName</c>. Instead, make necessary calculations at run time by
			/// using the value of the <c>FileNameOffset</c> member. Doing so helps make your code compatible with any future versions of <c>USN_RECORD_V3</c>.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string FileName;
		}

		/// <summary>
		/// Contains the information for an update sequence number (USN) change journal version 4.0 record. The version 2.0 and 3.0 records
		/// are defined by the USN_RECORD_V2 (also called <c>USN_RECORD</c>) and USN_RECORD_V3 structures respectively.
		/// </summary>
		/// <remarks>
		/// <para>
		/// A <c>USN_RECORD_V4</c> record is only output when range tracking is turned on and the file size is equal or larger than the value
		/// of the <c>RangeTrackFileSizeThreshold</c> member. The user always receives one or more <c>USN_RECORD_V4</c> records followed by
		/// one USN_RECORD_V3 record.
		/// </para>
		/// <para>
		/// To provide a path forward compatibility in change journal clients, Microsoft provides a major and minor version number of the
		/// change journal software in the <c>USN_RECORD_V4</c> structure. Your code should examine these values, examine its own
		/// compatibility with the change journal software, and gracefully handle any incompatibility if necessary.
		/// </para>
		/// <para>
		/// A change in the minor version number indicates that the existing <c>USN_RECORD_V4</c> structure members are still valid, but that
		/// new members may have been added between the penultimate member and the last, which is a variable-length string.
		/// </para>
		/// <para>
		/// To handle such a change gracefully, your code should not do any compile-time pointer arithmetic that relies on the location of
		/// the last member. For example, a change in the minor version number makes the call unreliable. Instead, rely on run-time
		/// calculations that use the <c>RecordLength</c> member.
		/// </para>
		/// <para>
		/// An increase in the major version number of the change journal software indicates that the <c>USN_RECORD_V4</c> structure may have
		/// undergone major changes, and that the current definition may not be reliable. If your code detects a change in the major version
		/// number of the change journal software, the code should not work with the change journal.
		/// </para>
		/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_record_v4 typedef struct { USN_RECORD_COMMON_HEADER
		// Header; FILE_ID_128 FileReferenceNumber; FILE_ID_128 ParentFileReferenceNumber; USN Usn; DWORD Reason; DWORD SourceInfo; DWORD
		// RemainingExtents; WORD NumberOfExtents; WORD ExtentSize; USN_RECORD_EXTENT Extents[1]; } USN_RECORD_V4, *PUSN_RECORD_V4;
		[PInvokeData("winioctl.h", MSDNShortId = "2636D1A1-6FD1-4F84-954C-499DCCE6E390")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<USN_RECORD_V4>), nameof(NumberOfExtents))]
		[StructLayout(LayoutKind.Sequential, Size = 80)]
		public struct USN_RECORD_V4
		{
			/// <summary>
			/// A USN_RECORD_COMMON_HEADER structure that describes the record length, major version, and minor version for the record.
			/// </summary>
			public USN_RECORD_COMMON_HEADER Header;

			/// <summary>
			/// <para>The 128-bit ordinal number of the file or directory for which this record notes changes.</para>
			/// <para>This value is an arbitrarily assigned value that associates a journal record with a file.</para>
			/// </summary>
			public FILE_ID_128 FileReferenceNumber;

			/// <summary>
			/// <para>The 128-bit ordinal number of the directory where the file or directory that is associated with this record is located.</para>
			/// <para>This value is an arbitrarily assigned value that associates a journal record with a parent directory.</para>
			/// </summary>
			public FILE_ID_128 ParentFileReferenceNumber;

			/// <summary>The USN of this record.</summary>
			public long Usn;

			/// <summary>
			/// <para>
			/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
			/// directory opened.
			/// </para>
			/// <para>
			/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next
			/// change (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
			/// </para>
			/// <para>
			/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
			/// records a new parent.
			/// </para>
			/// <para>The following table identifies the possible flags.</para>
			/// <para><c>Note</c> Unused bits are reserved.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_REASON_BASIC_INFO_CHANGE 0x00008000</term>
			/// <term>
			/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
			/// sparse attribute), or one or more time stamps.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_CLOSE 0x80000000</term>
			/// <term>The file or directory is closed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_COMPRESSION_CHANGE 0x00020000</term>
			/// <term>The compression state of the file or directory is changed from or to compressed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_EXTEND 0x00000002</term>
			/// <term>The file or directory is extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_OVERWRITE 0x00000001</term>
			/// <term>The data in the file or directory is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_DATA_TRUNCATION 0x00000004</term>
			/// <term>The file or directory is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_EA_CHANGE 0x00000400</term>
			/// <term>
			/// The user made a change to the extended attributes of a file or directory. These NTFS file system attributes are not
			/// accessible to Windows-based applications.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_ENCRYPTION_CHANGE 0x00040000</term>
			/// <term>The file or directory is encrypted or decrypted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_CREATE 0x00000100</term>
			/// <term>The file or directory is created for the first time.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_FILE_DELETE 0x00000200</term>
			/// <term>The file or directory is deleted.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_HARD_LINK_CHANGE 0x00010000</term>
			/// <term>
			/// An NTFS file system hard link is added to or removed from the file or directory. An NTFS file system hard link, similar to a
			/// POSIX hard link, is one of several directory entries that see the same file or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INDEXABLE_CHANGE 0x00004000</term>
			/// <term>
			/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute. That is, the user changes the file or directory from one
			/// where content can be indexed to one where content cannot be indexed, or vice versa. Content indexing permits rapid searching
			/// of data by building a database of selected content.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_INTEGRITY_CHANGE 0x00800000</term>
			/// <term>
			/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream. On the ReFS file system,
			/// integrity streams maintain a checksum of all data for that stream, so that the contents of the file can be validated during
			/// read or write operations.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_EXTEND 0x00000020</term>
			/// <term>The one or more named data streams for a file are extended (added to).</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_OVERWRITE 0x00000010</term>
			/// <term>The data in one or more named data streams for a file is overwritten.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_NAMED_DATA_TRUNCATION 0x00000040</term>
			/// <term>The one or more named data streams for a file is truncated.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_OBJECT_ID_CHANGE 0x00080000</term>
			/// <term>The object identifier of a file or directory is changed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_NEW_NAME 0x00002000</term>
			/// <term>A file or directory is renamed, and the file name in the USN_RECORD_V4 structure is the new name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_RENAME_OLD_NAME 0x00001000</term>
			/// <term>The file or directory is renamed, and the file name in the USN_RECORD_V4 structure is the previous name.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_REPARSE_POINT_CHANGE 0x00100000</term>
			/// <term>
			/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
			/// or directory.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_SECURITY_CHANGE 0x00000800</term>
			/// <term>A change is made in the access rights to a file or directory.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_STREAM_CHANGE 0x00200000</term>
			/// <term>A named stream is added to or removed from a file, or a named stream is renamed.</term>
			/// </item>
			/// <item>
			/// <term>USN_REASON_TRANSACTED_CHANGE 0x00400000</term>
			/// <term>The given stream is modified through a committed TxF transaction.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_REASON Reason;

			/// <summary>
			/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
			/// <para>
			/// When a thread writes a new USN record, the source information flags in the prior record continue to be present only if the
			/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that
			/// are set only by a known source, for example, an antivirus filter.
			/// </para>
			/// <para>One of the following values can be set.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>USN_SOURCE_AUXILIARY_DATA 0x00000002</term>
			/// <term>
			/// The operation adds a private data stream to a file or directory. One example is a virus detector adding checksum information.
			/// As the virus detector modifies the item, the system generates USN records. USN_SOURCE_AUXILIARY_DATA indicates that the
			/// modifications did not change the application data.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_DATA_MANAGEMENT 0x00000001</term>
			/// <term>
			/// The operation provides information about a change to the file or directory made by the operating system. A typical use is
			/// when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical storage
			/// management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record. However, the
			/// data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo member, you can
			/// determine that although a write operation is performed on the item, data has not changed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_REPLICATION_MANAGEMENT 0x00000004</term>
			/// <term>
			/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT 0x00000008</term>
			/// <term>The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.</term>
			/// </item>
			/// </list>
			/// </summary>
			public USN_SOURCE SourceInfo;

			/// <summary>
			/// The number of extents that remain after the current <c>USN_RECORD_V4</c> record. Multiple version 4.0 records may be required
			/// to describe all of the modified extents for a given file. When the <c>RemainingExtents</c> member is 0, the current
			/// <c>USN_RECORD_V4</c> record is the last <c>USN_RECORD_V4</c> record for the file. The last <c>USN_RECORD_V4</c> entry for a
			/// given file is always followed by a USN_RECORD_V3 record with at least the <c>USN_REASON_CLOSE</c> flag set.
			/// </summary>
			public uint RemainingExtents;

			/// <summary>The number of extents in current <c>USN_RECORD_V4</c> entry.</summary>
			public ushort NumberOfExtents;

			/// <summary>The size of each USN_RECORD_EXTENT structure in the <c>Extents</c> member, in bytes.</summary>
			public ushort ExtentSize;

			/// <summary>An array of USN_RECORD_EXTENT structures that represent the extents in the <c>USN_RECORD_V4</c> entry.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public USN_RECORD_EXTENT[] Extents;
		}

		/// <summary>
		/// Contains information on range tracking parameters for an update sequence number (USN) change journal using the
		/// FSCTL_USN_TRACK_MODIFIED_RANGES control code.
		/// </summary>
		/// <remarks>
		/// Once range tracking is enabled for a given volume it cannot be disabled except by deleting the USN Journal and recreating it.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-usn_track_modified_ranges typedef struct { DWORD Flags;
		// DWORD Unused; DWORDLONG ChunkSize; LONGLONG FileSizeThreshold; } USN_TRACK_MODIFIED_RANGES, *PUSN_TRACK_MODIFIED_RANGES;
		[PInvokeData("winioctl.h", MSDNShortId = "00254BBD-8F38-46AB-8B0A-3094020A48C5")]
		[StructLayout(LayoutKind.Sequential)]
		public struct USN_TRACK_MODIFIED_RANGES
		{
			/// <summary>
			/// <para>Indicates enabling range tracking.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>FLAG_USN_TRACK_MODIFIED_RANGES_ENABLE 0x00000001</term>
			/// <term>This flag is mandatory with FSCTL_USN_TRACK_MODIFIED_RANGES and is used to enable range tracking on the volume.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint Flags;

			/// <summary>Reserved.</summary>
			public uint Unused;

			/// <summary>Chunk size for tracking ranges. A single byte modification will be reflected as the whole chunk being modified.</summary>
			public ulong ChunkSize;

			/// <summary>
			/// File size threshold to start outputting USN_RECORD_V4 record(s) for modified file, i.e. if the modified file size is less
			/// than this threshold, then no <c>USN_RECORD_V4</c> record will be output.
			/// </summary>
			public long FileSizeThreshold;
		}

		/// <summary>
		/// Represents a physical location on a disk. It is the output buffer for the IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS control code.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-volume_disk_extents
		// typedef struct _VOLUME_DISK_EXTENTS { DWORD NumberOfDiskExtents; DISK_EXTENT Extents[ANYSIZE_ARRAY]; } VOLUME_DISK_EXTENTS, *PVOLUME_DISK_EXTENTS;
		[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._VOLUME_DISK_EXTENTS")]
		[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<VOLUME_DISK_EXTENTS>), nameof(NumberOfDiskExtents))]
		[StructLayout(LayoutKind.Sequential)]
		public struct VOLUME_DISK_EXTENTS
		{
			/// <summary>
			/// <para>The number of disks in the volume (a volume can span multiple disks).</para>
			/// <para>
			/// An extent is a contiguous run of sectors on one disk. When the number of extents returned is greater than one (1), the error
			/// code <c>ERROR_MORE_DATA</c> is returned. You should call DeviceIoControl again, allocating enough buffer space based on the
			/// value of <c>NumberOfDiskExtents</c> after the first <c>DeviceIoControl</c> call.
			/// </para>
			/// </summary>
			public uint NumberOfDiskExtents;

			/// <summary>An array of DISK_EXTENT structures.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public DISK_EXTENT[] Extents;
		}

		/// <summary>Contains volume attributes retrieved with the IOCTL_VOLUME_GET_GPT_ATTRIBUTES control code.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-volume_get_gpt_attributes_information typedef struct
		// _VOLUME_GET_GPT_ATTRIBUTES_INFORMATION { DWORDLONG GptAttributes; } VOLUME_GET_GPT_ATTRIBUTES_INFORMATION, *PVOLUME_GET_GPT_ATTRIBUTES_INFORMATION;
		[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._VOLUME_GET_GPT_ATTRIBUTES_INFORMATION")]
		[StructLayout(LayoutKind.Sequential)]
		public struct VOLUME_GET_GPT_ATTRIBUTES_INFORMATION
		{
			/// <summary>
			/// <para>Specifies all of the attributes associated with a volume.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_READ_ONLY 0x1000000000000000</term>
			/// <term>The volume is read-only.</term>
			/// </item>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_SHADOW_COPY 0x2000000000000000</term>
			/// <term>The volume is a shadow copy of another volume. For more information, see Volume Shadow Copy Service Overview.</term>
			/// </item>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_HIDDEN 0x4000000000000000</term>
			/// <term>The volume is hidden.</term>
			/// </item>
			/// <item>
			/// <term>GPT_BASIC_DATA_ATTRIBUTE_NO_DRIVE_LETTER 0x8000000000000000</term>
			/// <term>The volume is not assigned a default drive letter.</term>
			/// </item>
			/// </list>
			/// </summary>
			public GPT_BASIC_DATA_ATTRIBUTE GptAttributes;
		}
	}
}