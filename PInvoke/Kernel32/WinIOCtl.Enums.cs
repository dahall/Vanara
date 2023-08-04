namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>The features supported by the changer.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_CHANGER_PARAMETERS")]
	[Flags]
	public enum CHANGER_FEATURES0 : uint
	{
		/// <summary>The changer supports a bar-code reader and the reader is installed.</summary>
		CHANGER_BAR_CODE_SCANNER_INSTALLED = 0x00000001,

		/// <summary>The changer uses removable cartridge magazines for some or all storage slots.</summary>
		CHANGER_CARTRIDGE_MAGAZINE = 0x00000100,

		/// <summary>
		/// The ELEMENT_STATUS_ACCESS flag in a CHANGER_ELEMENT_STATUS structure for a data transport element is invalid when the
		/// transport element contains a cleaning cartridge.
		/// </summary>
		CHANGER_CLEANER_ACCESS_NOT_VALID = 0x00040000,

		/// <summary>
		/// The changer has a slot designated for a cleaner cartridge. If this flag is set, NumberCleanerSlots must be 1 and
		/// FirstCleanerSlotAddress must specify the address of the cleaner slot.
		/// </summary>
		CHANGER_CLEANER_SLOT = 0x00000040,

		/// <summary>The changer has an insert/eject port and can retract the insert/eject port programmatically.</summary>
		CHANGER_CLOSE_IEPORT = 0x00000004,

		/// <summary>The changer can recalibrate its transport element in response to an explicit command.</summary>
		CHANGER_DEVICE_REINITIALIZE_CAPABLE = 0x08000000,

		/// <summary>
		/// The changer's drives require periodic cleaning, which must be initiated by either the user or an application, and the
		/// changer can use its transport element to mount a cleaner cartridge in a drive.
		/// </summary>
		CHANGER_DRIVE_CLEANING_REQUIRED = 0x00010000,

		/// <summary>The changer requires all drives to be empty (dismounted) before they can be accessed through its door.</summary>
		CHANGER_DRIVE_EMPTY_ON_DOOR_ACCESS = 0x20000000,

		/// <summary>
		/// The changer can exchange media between elements. For a SCSI changer, this flag indicates whether the changer supports the
		/// EXCHANGE MEDIUM command.
		/// </summary>
		CHANGER_EXCHANGE_MEDIA = 0x00000020,

		/// <summary>
		/// The changer can initialize elements within a specified range. For a SCSI changer, this flag indicates whether the changer
		/// supports the INITIALIZE ELEMENT STATUS WITH RANGE command.
		/// </summary>
		CHANGER_INIT_ELEM_STAT_WITH_RANGE = 0x00000002,

		/// <summary>The changer keypad can be enabled and disabled programmatically.</summary>
		CHANGER_KEYPAD_ENABLE_DISABLE = 0x10000000,

		/// <summary>
		/// The changer's door, insert/eject port, or keypad can be locked or unlocked programmatically. If this flag is set,
		/// LockUnlockCapabilities indicates which elements can be locked or unlocked.
		/// </summary>
		CHANGER_LOCK_UNLOCK = 0x00000080,

		/// <summary>
		/// The changer's transport element supports flipping (rotating) media. For a SCSI changer, this flag reflects the rotate bit in
		/// the transport geometry parameters page.
		/// </summary>
		CHANGER_MEDIUM_FLIP = 0x00000200,

		/// <summary>The changer has an insert/eject port and can extend the insert/eject port programmatically.</summary>
		CHANGER_OPEN_IEPORT = 0x00000008,

		/// <summary>
		/// The changer can position the transport to a particular destination. For a SCSI changer, this flag indicates whether the
		/// changer supports the POSITION TO ELEMENT command. If this flag is set, PositionCapabilities indicates the elements to which
		/// the transport can be positioned.
		/// </summary>
		CHANGER_POSITION_TO_ELEMENT = 0x00000400,

		/// <summary>
		/// The changer requires an explicit command issued through a mass-storage driver (tape, disk, or CDROM, for example) to eject
		/// media from a drive before the changer can move the media from a drive to a slot.
		/// </summary>
		CHANGER_PREDISMOUNT_EJECT_REQUIRED = 0x00020000,

		/// <summary>
		/// The changer requires an explicit command issued through a mass storage driver to eject a drive mechanism before the changer
		/// can move media from a slot to the drive. For example, a changer with CD-ROM drives might require the tray to be presented to
		/// the robotic transport so that a piece of media could be loaded onto the tray during a mount operation.
		/// </summary>
		CHANGER_PREMOUNT_EJECT_REQUIRED = 0x00080000,

		/// <summary>
		/// The changer can report whether media is present in the insert/eject port. Such a changer must have a sensor in the
		/// insert/eject port to detect the presence or absence of media.
		/// </summary>
		CHANGER_REPORT_IEPORT_STATE = 0x00000800,

		/// <summary>
		/// The serial number is valid and unique for all changers of this type. Serial numbers are not guaranteed to be unique across
		/// vendor and product lines.
		/// </summary>
		CHANGER_SERIAL_NUMBER_VALID = 0x04000000,

		/// <summary>The changer uses nonvolatile memory for element status information.</summary>
		CHANGER_STATUS_NON_VOLATILE = 0x00000010,

		/// <summary>
		/// The changer can use a drive as an independent storage element; that is, it can store media in the drive without reading it.
		/// For a SCSI changer, this flag reflects the state of the DT bit in the device capabilities page.
		/// </summary>
		CHANGER_STORAGE_DRIVE = 0x00001000,

		/// <summary>
		/// The changer can use an insert/eject port as an independent storage element. For a SCSI changer, this flag reflects the state
		/// of the I/E bit in the device capabilities page.
		/// </summary>
		CHANGER_STORAGE_IEPORT = 0x00002000,

		/// <summary>
		/// The changer can use a slot as an independent storage element for media. For a SCSI changer, this flag reflects the state of
		/// the ST bit in the device capabilities page. Slots are the normal storage location for media, so the changer must support
		/// this functionality.
		/// </summary>
		CHANGER_STORAGE_SLOT = 0x00004000,

		/// <summary>
		/// The changer can use a transport as an independent storage element. For a SCSI changer, this flag reflects the state of the
		/// MT bit in the device capabilities page.
		/// </summary>
		CHANGER_STORAGE_TRANSPORT = 0x00008000,

		/// <summary>
		/// The changer can verify volume information. For a SCSI changer, this flag indicates whether the changer supports the SEND
		/// VOLUME TAG command with a send action code of ASSERT.
		/// </summary>
		CHANGER_VOLUME_ASSERT = 0x00400000,

		/// <summary>
		/// The changer supports volume identification. For a SCSI changer, this flag indicates whether the changer supports the SEND
		/// VOLUME TAG and REQUEST VOLUME ELEMENT ADDRESS commands.
		/// </summary>
		CHANGER_VOLUME_IDENTIFICATION = 0x00100000,

		/// <summary>
		/// The changer can replace volume information. For a SCSI changer, this flag indicates whether the changer supports the SEND
		/// VOLUME TAG command with a send action code of REPLACE.
		/// </summary>
		CHANGER_VOLUME_REPLACE = 0x00800000,

		/// <summary>
		/// The changer can search for volume information. For a SCSI changer, this flag indicates whether the changer supports the
		/// supports the SEND VOLUME TAG command with a send action code of TRANSLATE.
		/// </summary>
		CHANGER_VOLUME_SEARCH = 0x00200000,

		/// <summary>
		/// The changer can clear existing volume information. For a SCSI changer, this flag indicates whether the changer supports the
		/// SEND VOLUME TAG command with a send action code of UNDEFINE.
		/// </summary>
		CHANGER_VOLUME_UNDEFINE = 0x01000000,
	}

	/// <summary>Additional features supported by the changer.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_CHANGER_PARAMETERS")]
	[Flags]
	public enum CHANGER_FEATURES1 : uint
	{
		/// <summary>The changer will move the cleaning cartridge back to its original slot automatically after cleaning is finished.</summary>
		CHANGER_CLEANER_AUTODISMOUNT = 0x80000004,

		/// <summary>The changer does not support automatic cleaning of its elements.</summary>
		CHANGER_CLEANER_OPS_NOT_SUPPORTED = 0x80000040,

		/// <summary>The changer requires the user to manually close an open insert/eject port.</summary>
		CHANGER_IEPORT_USER_CONTROL_CLOSE = 0x80000100,

		/// <summary>The changer requires the user to manually open a closed insert/eject port.</summary>
		CHANGER_IEPORT_USER_CONTROL_OPEN = 0x80000080,

		/// <summary>
		/// The changer will extend the tray automatically whenever a command is issued to move media to an insert/eject port.
		/// </summary>
		CHANGER_MOVE_EXTENDS_IEPORT = 0x80000200,

		/// <summary>
		/// The changer will retract the tray automatically whenever a command is issued to move media from an insert/eject port.
		/// </summary>
		CHANGER_MOVE_RETRACTS_IEPORT = 0x80000400,

		/// <summary>
		/// The changer requires an explicit command to position the transport element to a drive before it can eject media from the drive.
		/// </summary>
		CHANGER_PREDISMOUNT_ALIGN_TO_DRIVE = 0x80000002,

		/// <summary>
		/// The changer requires an explicit command to position the transport element to a slot before it can eject media from the slot.
		/// </summary>
		CHANGER_PREDISMOUNT_ALIGN_TO_SLOT = 0x80000001,

		/// <summary>The changer requires media to be returned to its original slot after it has been moved.</summary>
		CHANGER_RTN_MEDIA_TO_ORIGINAL_ADDR = 0x80000020,

		/// <summary>
		/// The changer uses removable trays in its slots, which require the media to be placed in a tray and the tray moved to the
		/// desired position.
		/// </summary>
		CHANGER_SLOTS_USE_TRAYS = 0x80000010,

		/// <summary>
		/// The changer can exchange media between a source and a destination in a single operation. This flag is valid only if
		/// CHANGER_EXCHANGE_MEDIA is also set in Features0.
		/// </summary>
		CHANGER_TRUE_EXCHANGE_CAPABLE = 0x80000008,
	}

	/// <summary>The elements of a changer that can be locked or unlocked programmatically.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_CHANGER_PARAMETERS")]
	[Flags]
	public enum CHANGER_LOCK : byte
	{
		/// <summary>The changer can lock or unlock its door.</summary>
		LOCK_UNLOCK_DOOR = 0x02,

		/// <summary>The changer can lock or unlock its insert/eject port.</summary>
		LOCK_UNLOCK_IEPORT = 0x01,

		/// <summary>The changer can lock or unlock its keypad.</summary>
		LOCK_UNLOCK_KEYPAD = 0x04,
	}

	/// <summary>
	/// ndicates whether the changer supports moving a piece of media from a transport element to another transport element, a storage
	/// slot, an insert/eject port, or a drive. For a SCSI changer, this is defined in the device capabilities page. The transport is
	/// not typically the source or destination for moving or exchanging media.
	/// </summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_CHANGER_PARAMETERS")]
	[Flags]
	public enum CHANGER_MOVE : byte
	{
		/// <summary>The changer can carry out the operation from the specified element to a drive.</summary>
		CHANGER_TO_DRIVE = 0x08,

		/// <summary>The changer can carry out the operation from the specified element to an insert/eject port.</summary>
		CHANGER_TO_IEPORT = 0x04,

		/// <summary>The changer can carry out the operation from the specified element to a storage slot.</summary>
		CHANGER_TO_SLOT = 0x02,

		/// <summary>The changer can carry out the operation from the specified element to a transport.</summary>
		CHANGER_TO_TRANSPORT = 0x01,
	}

	/// <summary>The operation to be performed.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_SET_ACCESS")]
	public enum CHANGER_SET_ACCESS_OP
	{
		/// <summary>
		/// The element is to be extended.
		/// <para>Requires that Features0 is CHANGER_OPEN_IEPORT.</para>
		/// </summary>
		EXTEND_IEPORT = 2,

		/// <summary>
		/// The element is to be locked.
		/// <para>Requires that Features0 is CHANGER_LOCK_UNLOCK.</para>
		/// </summary>
		LOCK_ELEMENT = 0,

		/// <summary>
		/// The element is to be retracted.
		/// <para>Requires that Features0 is CHANGER_CLOSE_IEPORT.</para>
		/// </summary>
		RETRACT_IEPORT = 3,

		/// <summary>
		/// The element is to be unlocked.
		/// <para>Requires that Features0 is CHANGER_LOCK_UNLOCK.</para>
		/// </summary>
		UNLOCK_ELEMENT = 1,
	}

	/// <summary>The action to be performed.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_SEND_VOLUME_TAG_INFORMATION")]
	public enum ChangerActionCode
	{
		/// <summary>
		/// Define the alternate volume tag of a volume that currently has none defined.
		/// <para>Requires that Features0 is CHANGER_VOLUME_ASSERT.</para>
		/// </summary>
		ASSERT_ALTERNATE = 0x9,

		/// <summary>
		/// Define the primary volume tag of a volume that currently has none defined.
		/// <para>Requires that Features0 is CHANGER_VOLUME_ASSERT.</para>
		/// </summary>
		ASSERT_PRIMARY = 0x8,

		/// <summary>
		/// Replace the alternate volume tag with a new tag.
		/// <para>Requires that Features0 is CHANGER_VOLUME_REPLACE.</para>
		/// </summary>
		REPLACE_ALTERNATE = 0xB,

		/// <summary>
		/// Replace the primary volume tag with a new tag.
		/// <para>Requires that Features0 is CHANGER_VOLUME_REPLACE.</para>
		/// </summary>
		REPLACE_PRIMARY = 0xA,

		/// <summary>
		/// Search all defined volume tags.
		/// <para>Requires that Features0 is CHANGER_VOLUME_SEARCH.</para>
		/// </summary>
		SEARCH_ALL = 0x0,

		/// <summary>
		/// Search all defined volume tags, but ignore sequence numbers.
		/// <para>Requires that Features0 is CHANGER_VOLUME_SEARCH.</para>
		/// </summary>
		SEARCH_ALL_NO_SEQ = 0x4,

		/// <summary>
		/// Search only alternate volume tags, but ignore sequence numbers.
		/// <para>Requires that Features0 is CHANGER_VOLUME_SEARCH.</para>
		/// </summary>
		SEARCH_ALT_NO_SEQ = 0x6,

		/// <summary>
		/// Search only alternate volume tags.
		/// <para>Requires that Features0 is CHANGER_VOLUME_SEARCH.</para>
		/// </summary>
		SEARCH_ALTERNATE = 02,

		/// <summary>
		/// Search only primary volume tags but ignore sequence numbers.
		/// <para>Requires that Features0 is CHANGER_VOLUME_SEARCH.</para>
		/// </summary>
		SEARCH_PRI_NO_SEQ = 05,

		/// <summary>
		/// Search only primary volume tags.
		/// <para>Requires that Features0 is CHANGER_VOLUME_SEARCH.</para>
		/// </summary>
		SEARCH_PRIMARY = 0x1,

		/// <summary>
		/// Clear the alternate volume tag.
		/// <para>Requires that Features0 is CHANGER_VOLUME_UNDEFINE.</para>
		/// </summary>
		UNDEFINE_ALTERNATE = 0xD,

		/// <summary>
		/// Clear the primary volume tag.
		/// <para>Requires that Features0 is CHANGER_VOLUME_UNDEFINE.</para>
		/// </summary>
		UNDEFINE_PRIMARY = 0xC,
	}

	/// <summary>The checksum algorithm used.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FSCTL_GET_INTEGRITY_INFORMATION_BUFFER")]
	public enum CHECKSUM_TYPE : short
	{
		/// <summary>The checksum algorithm is to remain the same.</summary>
		CHECKSUM_TYPE_UNCHANGED = -1,

		/// <summary>The file or directory is not configured to use integrity.</summary>
		CHECKSUM_TYPE_NONE = 0,

		/// <summary>The file or directory uses a CRC32 checksum to provide integrity.</summary>
		CHECKSUM_TYPE_CRC32 = 1,

		/// <summary>The file or directory uses a CRC64 checksum to provide integrity.</summary>
		CHECKSUM_TYPE_CRC64 = 2,

		/// <summary/>
		CHECKSUM_TYPE_ECC = 3,

		/// <summary/>
		CHECKSUM_TYPE_FIRST_UNUSED_TYPE = 4,
	}

	/// <summary>Specifies the type of CSV control operation to use with the FSCTL_CSV_CONTROL control code.</summary>
	/// <remarks>
	/// An alternative to calling the FSCTL_CSV_CONTROL control code with this enumeration is to use the CSV_CONTROL_PARAM structure,
	/// which encapsulates a member of this enumeration type.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-csv_control_op typedef enum _CSV_CONTROL_OP {
	// CsvControlStartRedirectFile, CsvControlStopRedirectFile, CsvControlQueryRedirectState, CsvControlQueryFileRevision,
	// CsvControlQueryMdsPath, CsvControlQueryFileRevisionFileId128, CsvControlQueryVolumeRedirectState,
	// CsvControlEnableUSNRangeModificationTracking, CsvControlMarkHandleLocalVolumeMount, CsvControlUnmarkHandleLocalVolumeMount,
	// CsvControlGetCsvFsMdsPathV2, CsvControlDisableCaching, CsvControlEnableCaching } CSV_CONTROL_OP, *PCSV_CONTROL_OP;
	[PInvokeData("winioctl.h", MSDNShortId = "77A2106F-2C07-4A30-BA46-651F74032609")]
	public enum CSV_CONTROL_OP
	{
		/// <summary>Start file redirection.</summary>
		CsvControlStartRedirectFile = 0x02,

		/// <summary>Stop file redirection.</summary>
		CsvControlStopRedirectFile,

		/// <summary>
		/// Search for state redirection. When this value is specified, the CSV_QUERY_REDIRECT_STATE structure must also be used.
		/// </summary>
		CsvControlQueryRedirectState,

		/// <summary>Search for file revision. When this value is specified, the CSV_QUERY_FILE_REVISION structure must also be used.</summary>
		CsvControlQueryFileRevision = 0x06,

		/// <summary/>
		CsvControlQueryMdsPath = 0x08,

		/// <summary/>
		CsvControlQueryFileRevisionFileId128,

		/// <summary/>
		CsvControlQueryVolumeRedirectState,

		/// <summary/>
		CsvControlEnableUSNRangeModificationTracking = 0x0d,

		/// <summary/>
		CsvControlMarkHandleLocalVolumeMount,

		/// <summary/>
		CsvControlUnmarkHandleLocalVolumeMount,

		/// <summary/>
		CsvControlGetCsvFsMdsPathV2 = 0x12,

		/// <summary/>
		CsvControlDisableCaching,

		/// <summary/>
		CsvControlEnableCaching,
	}

	/// <summary>The detected partition type.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "57ca68f4-f748-4bc4-90c3-13d545716d87")]
	public enum DETECTION_TYPE
	{
		/// <summary>The disk does not have an Int13 or an extended Int13 partition.</summary>
		DetectNone,

		/// <summary>The disk has a standard Int13 partition.</summary>
		DetectInt13,

		/// <summary>The disk has an extended Int13 partition.</summary>
		DetectExInt13
	}

	/// <summary>
	/// The following constant values are the set of possible values for the <c>DEVICE_DATA_MANAGEMENT_SET_ACTION</c> type, which is
	/// defined as type <c>DWORD</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/devio/device-data-management-set-action
	[PInvokeData("winioctl.h")]
	[Flags]
	public enum DEVICE_DSM_ACTION : uint
	{
		/// <summary/>
		DeviceDsmActionFlag_NonDestructive = 0x80000000,

		/// <summary>No action is performed.</summary>
		DeviceDsmAction_None = 0x00000000,

		/// <summary>A trim action is performed. This value is not supported for user-mode applications.</summary>
		DeviceDsmAction_Trim = 0x00000001,

		/// <summary>
		/// A notification action is performed. The additional parameters are in a DEVICE_DSM_NOTIFICATION_PARAMETERS structure. The
		/// DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver stack that this operation is non-destructive.
		/// </summary>
		DeviceDsmAction_Notification = 0x00000002 | DeviceDsmActionFlag_NonDestructive,

		/// <summary>
		/// An offload read action is performed. The additional parameters are in a DEVICE_DSM_OFFLOAD_READ_PARAMETERS structure. The
		/// DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver stack that this operation is
		/// non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </summary>
		DeviceDsmAction_OffloadRead = 0x00000003 | DeviceDsmActionFlag_NonDestructive,

		/// <summary>
		/// An offload write action is performed. The additional parameters are in a DEVICE_DSM_OFFLOAD_WRITE_PARAMETERS structure.
		/// Windows 7 and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </summary>
		DeviceDsmAction_OffloadWrite = 0x00000004,

		/// <summary>
		/// An allocation bitmap is retrieved for the first data set range specified. The DeviceDsmActionFlag_NonDestructive
		/// (0x80000000) is a bit flag to indicate to the driver stack that this operation is non-destructive. Windows 7 and Windows
		/// Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </summary>
		DeviceDsmAction_Allocation = 0x00000005 | DeviceDsmActionFlag_NonDestructive,

		/// <summary>
		/// A repair action is performed. The additional parameters are in a DEVICE_DATA_SET_REPAIR_PARAMETERS structure. The
		/// DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver stack that this operation is
		/// non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </summary>
		DeviceDsmAction_Repair = 0x00000006 | DeviceDsmActionFlag_NonDestructive,

		/// <summary>
		/// A scrub action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver
		/// stack that this operation is non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before
		/// Windows 8 and Windows Server 2012.
		/// </summary>
		DeviceDsmAction_Scrub = 0x00000007 | DeviceDsmActionFlag_NonDestructive,

		/// <summary>
		/// A resiliency action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the
		/// driver stack that this operation is non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported
		/// before Windows 8 and Windows Server 2012.
		/// </summary>
		DeviceDsmAction_DrtQuery = 0x00000008 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_DrtClear = 0x00000009 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_DrtDisable = 0x0000000A | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_TieringQuery = 0x0000000B | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_Map = 0x0000000C | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_RegenerateParity = 0x0000000D | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_NvCache_Change_Priority = 0x0000000E | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_NvCache_Evict = 0x0000000F | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_TopologyIdQuery = 0x00000010 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_GetPhysicalAddresses = 0x00000011 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_ScopeRegen = 0x00000012 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_ReportZones = 0x00000013 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_OpenZone = 0x00000014 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_FinishZone = 0x00000015 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_CloseZone = 0x00000016 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_ResetWritePointer = 0x00000017,

		/// <summary/>
		DeviceDsmAction_GetRangeErrorInfo = 0x00000018 | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_WriteZeroes = 0x00000019,

		/// <summary/>
		DeviceDsmAction_LostQuery = 0x0000001A | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_GetFreeSpace = 0x0000001B | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_ConversionQuery = 0x0000001C | DeviceDsmActionFlag_NonDestructive,

		/// <summary/>
		DeviceDsmAction_VdtSet = 0x0000001D,
	}

	/// <summary>Flags for the actions.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_MANAGE_DATA_SET_ATTRIBUTES")]
	[Flags]
	public enum DEVICE_DSM_FLAG : uint
	{
		/// <summary>
		/// If set then the described ranges are not allocated by a file system. This flag is specific to the DeviceDsmAction_Trim action.
		/// </summary>
		DEVICE_DSM_FLAG_TRIM_NOT_FS_ALLOCATED = 0x80000000,

		/// <summary>Starts a resync operation on the storage device. This flag is specific to the DeviceDsmAction_Resiliency action.</summary>
		DEVICE_DSM_FLAG_RESILIENCY_START_RESYNC = 0x10000000,

		/// <summary>
		/// Starts a load balancing operation on the storage device. This flag is specific to the DeviceDsmAction_Resiliency action.
		/// </summary>
		DEVICE_DSM_FLAG_RESILIENCY_START_LOAD_BALANCING = 0x20000000,
	}

	/// <summary>Flags specific to the notify operation</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_DSM_NOTIFICATION_PARAMETERS")]
	public enum DEVICE_DSM_NOTIFY_FLAG
	{
		/// <summary>
		/// The ranges specified in the DEVICE_DATA_SET_RANGE structures following the DEVICE_MANAGE_DATA_SET_ATTRIBUTES structure are
		/// currently being used by the file types that are specified in the FileTypeIDs member.
		/// </summary>
		DEVICE_DSM_NOTIFY_FLAG_BEGIN = 0x00000001,

		/// <summary>The ranges are no longer being used by the file types that are specified in the FileTypeIDs member.</summary>
		DEVICE_DSM_NOTIFY_FLAG_END = 0x00000002,
	}

	/// <summary>Device types defined by the system.</summary>
	[PInvokeData("WinIOCtl.h")]
	public enum DEVICE_TYPE : ushort
	{
		/// <summary/>
		FILE_DEVICE_BEEP = 0x00000001,
		/// <summary/>
		FILE_DEVICE_CD_ROM = 0x00000002,
		/// <summary/>
		FILE_DEVICE_CD_ROM_FILE_SYSTEM = 0x00000003,
		/// <summary/>
		FILE_DEVICE_CONTROLLER = 0x00000004,
		/// <summary/>
		FILE_DEVICE_DATALINK = 0x00000005,
		/// <summary/>
		FILE_DEVICE_DFS = 0x00000006,
		/// <summary/>
		FILE_DEVICE_DISK = 0x00000007,
		/// <summary/>
		FILE_DEVICE_DISK_FILE_SYSTEM = 0x00000008,
		/// <summary/>
		FILE_DEVICE_FILE_SYSTEM = 0x00000009,
		/// <summary/>
		FILE_DEVICE_INPORT_PORT = 0x0000000a,
		/// <summary/>
		FILE_DEVICE_KEYBOARD = 0x0000000b,
		/// <summary/>
		FILE_DEVICE_MAILSLOT = 0x0000000c,
		/// <summary/>
		FILE_DEVICE_MIDI_IN = 0x0000000d,
		/// <summary/>
		FILE_DEVICE_MIDI_OUT = 0x0000000e,
		/// <summary/>
		FILE_DEVICE_MOUSE = 0x0000000f,
		/// <summary/>
		FILE_DEVICE_MULTI_UNC_PROVIDER = 0x00000010,
		/// <summary/>
		FILE_DEVICE_NAMED_PIPE = 0x00000011,
		/// <summary/>
		FILE_DEVICE_NETWORK = 0x00000012,
		/// <summary/>
		FILE_DEVICE_NETWORK_BROWSER = 0x00000013,
		/// <summary/>
		FILE_DEVICE_NETWORK_FILE_SYSTEM = 0x00000014,
		/// <summary/>
		FILE_DEVICE_NULL = 0x00000015,
		/// <summary/>
		FILE_DEVICE_PARALLEL_PORT = 0x00000016,
		/// <summary/>
		FILE_DEVICE_PHYSICAL_NETCARD = 0x00000017,
		/// <summary/>
		FILE_DEVICE_PRINTER = 0x00000018,
		/// <summary/>
		FILE_DEVICE_SCANNER = 0x00000019,
		/// <summary/>
		FILE_DEVICE_SERIAL_MOUSE_PORT = 0x0000001a,
		/// <summary/>
		FILE_DEVICE_SERIAL_PORT = 0x0000001b,
		/// <summary/>
		FILE_DEVICE_SCREEN = 0x0000001c,
		/// <summary/>
		FILE_DEVICE_SOUND = 0x0000001d,
		/// <summary/>
		FILE_DEVICE_STREAMS = 0x0000001e,
		/// <summary/>
		FILE_DEVICE_TAPE = 0x0000001f,
		/// <summary/>
		FILE_DEVICE_TAPE_FILE_SYSTEM = 0x00000020,
		/// <summary/>
		FILE_DEVICE_TRANSPORT = 0x00000021,
		/// <summary/>
		FILE_DEVICE_UNKNOWN = 0x00000022,
		/// <summary/>
		FILE_DEVICE_VIDEO = 0x00000023,
		/// <summary/>
		FILE_DEVICE_VIRTUAL_DISK = 0x00000024,
		/// <summary/>
		FILE_DEVICE_WAVE_IN = 0x00000025,
		/// <summary/>
		FILE_DEVICE_WAVE_OUT = 0x00000026,
		/// <summary/>
		FILE_DEVICE_8042_PORT = 0x00000027,
		/// <summary/>
		FILE_DEVICE_NETWORK_REDIRECTOR = 0x00000028,
		/// <summary/>
		FILE_DEVICE_BATTERY = 0x00000029,
		/// <summary/>
		FILE_DEVICE_BUS_EXTENDER = 0x0000002a,
		/// <summary/>
		FILE_DEVICE_MODEM = 0x0000002b,
		/// <summary/>
		FILE_DEVICE_VDM = 0x0000002c,
		/// <summary/>
		FILE_DEVICE_MASS_STORAGE = 0x0000002d,
		/// <summary/>
		FILE_DEVICE_SMB = 0x0000002e,
		/// <summary/>
		FILE_DEVICE_KS = 0x0000002f,
		/// <summary/>
		FILE_DEVICE_CHANGER = 0x00000030,
		/// <summary/>
		FILE_DEVICE_SMARTCARD = 0x00000031,
		/// <summary/>
		FILE_DEVICE_ACPI = 0x00000032,
		/// <summary/>
		FILE_DEVICE_DVD = 0x00000033,
		/// <summary/>
		FILE_DEVICE_FULLSCREEN_VIDEO = 0x00000034,
		/// <summary/>
		FILE_DEVICE_DFS_FILE_SYSTEM = 0x00000035,
		/// <summary/>
		FILE_DEVICE_DFS_VOLUME = 0x00000036,
		/// <summary/>
		FILE_DEVICE_SERENUM = 0x00000037,
		/// <summary/>
		FILE_DEVICE_TERMSRV = 0x00000038,
		/// <summary/>
		FILE_DEVICE_KSEC = 0x00000039,
		/// <summary/>
		FILE_DEVICE_FIPS = 0x0000003A,
		/// <summary/>
		FILE_DEVICE_INFINIBAND = 0x0000003B,
		/// <summary/>
		FILE_DEVICE_AVIO = 0x0000003C,
		/// <summary/>
		FILE_DEVICE_VMBUS = 0x0000003E,
		/// <summary/>
		FILE_DEVICE_CRYPT_PROVIDER = 0x0000003F,
		/// <summary/>
		FILE_DEVICE_WPD = 0x00000040,
		/// <summary/>
		FILE_DEVICE_BLUETOOTH = 0x00000041,
		/// <summary/>
		FILE_DEVICE_MT_COMPOSITE = 0x00000042,
		/// <summary/>
		FILE_DEVICE_MT_TRANSPORT = 0x00000043,
		/// <summary/>
		FILE_DEVICE_BIOMETRIC = 0x00000044,
		/// <summary/>
		FILE_DEVICE_PMI = 0x00000045,
		/// <summary/>
		FILE_DEVICE_EHSTOR = 0x00000046,
		/// <summary/>
		FILE_DEVICE_DEVAPI = 0x00000047,
		/// <summary/>
		FILE_DEVICE_GPIO = 0x00000048,
		/// <summary/>
		FILE_DEVICE_USBEX = 0x00000049,
		/// <summary/>
		FILE_DEVICE_CONSOLE = 0x00000050,
		/// <summary/>
		FILE_DEVICE_NFP = 0x00000051,
		/// <summary/>
		FILE_DEVICE_SYSENV = 0x00000052,
		/// <summary/>
		FILE_DEVICE_VIRTUAL_BLOCK = 0x00000053,
		/// <summary/>
		FILE_DEVICE_POINT_OF_SERVICE = 0x00000054,
		/// <summary/>
		FILE_DEVICE_STORAGE_REPLICATION = 0x00000055,
		/// <summary/>
		FILE_DEVICE_TRUST_ENV = 0x00000056,
		/// <summary/>
		FILE_DEVICE_UCM = 0x00000057,
		/// <summary/>
		FILE_DEVICE_UCMTCPCI = 0x00000058,
		/// <summary/>
		FILE_DEVICE_PERSISTENT_MEMORY = 0x00000059,
		/// <summary/>
		FILE_DEVICE_NVDIMM = 0x0000005a,
		/// <summary/>
		FILE_DEVICE_HOLOGRAPHIC = 0x0000005b,
		/// <summary/>
		FILE_DEVICE_SDFXHCI = 0x0000005c,
		/// <summary/>
		FILE_DEVICE_UCMUCSI = 0x0000005d,
		/// <summary/>
		IOCTL_STORAGE_BASE = FILE_DEVICE_MASS_STORAGE,
		/// <summary/>
		IOCTL_CHANGER_BASE = FILE_DEVICE_CHANGER,
		/// <summary/>
		IOCTL_VOLUME_BASE = 0x00000056,
	}

	/// <summary>Disk attributes.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_DISK_ATTRIBUTES")]
	[Flags]
	public enum DISK_ATTRIBUTE : ulong
	{
		/// <summary>The disk is offline.</summary>
		DISK_ATTRIBUTE_OFFLINE = 0x0000000000000001,

		/// <summary>The disk is read-only.</summary>
		DISK_ATTRIBUTE_READ_ONLY = 0x0000000000000002,
	}

	/// <summary>
	/// Determines the likelihood of data cached from a read operation remaining in the cache. This data might be given a different
	/// priority than data cached under other circumstances, such as from a prefetch operation.
	/// </summary>
	[PInvokeData("winioctl.h", MSDNShortId = "ea175bea-5f2b-4f3e-9fe0-239b1d2e3d96")]
	public enum DISK_CACHE_RETENTION_PRIORITY
	{
		/// <summary>No data is held in the cache on a preferential basis.</summary>
		EqualPriority,

		/// <summary>A preference is to be given to prefetched data.</summary>
		KeepPrefetchedData,

		/// <summary>A preference is to be given to data cached from a read operation.</summary>
		KeepReadData
	}

	/// <summary>A combination of flags related to disks and clusters.</summary>
	[PInvokeData("Ntdddisk.h")]
	[Flags]
	public enum DISK_CLUSTER_FLAG : ulong
	{
		/// <summary>The disk is used as part of the cluster service.</summary>
		DISK_CLUSTER_FLAG_ENABLED = 1,

		/// <summary>Volumes on the disk are exposed by CSVFS on all nodes of the cluster.</summary>
		DISK_CLUSTER_FLAG_CSV = 2,

		/// <summary>The cluster resource associated with this disk is in maintenance mode.</summary>
		DISK_CLUSTER_FLAG_IN_MAINTENANCE = 4,

		/// <summary>The cluster disk driver for kernel mode (clusdisk) has received PnP notification of the arrival of the disk.</summary>
		DISK_CLUSTER_FLAG_PNP_ARRIVAL_COMPLETE = 8,
	}

	/// <summary>An exception code that indicates that the element is in an abnormal state.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_ELEMENT_STATUS")]
	[Flags]
	public enum ELEMENT_ERROR : uint
	{
		/// <summary>The drive at this element address is absent.</summary>
		ERROR_DRIVE_NOT_INSTALLED = 0x00000008,

		/// <summary>The label might be invalid due to a unit attention condition.</summary>
		ERROR_LABEL_QUESTIONABLE = 0x00000002,

		/// <summary>
		/// The changer's barcode reader could not read the bar code label on the piece of media in this element, because the media is
		/// missing, damaged, improperly positioned, or upside down.
		/// </summary>
		ERROR_LABEL_UNREADABLE = 0x00000001,

		/// <summary>
		/// The slot at this element address is currently not installed in the changer. Each slot in a removable magazine is reported
		/// not present to indicate that the magazine has been removed.
		/// </summary>
		ERROR_SLOT_NOT_PRESENT = 0x00000004,

		/// <summary>
		/// The drive at this element address has a tray that must be extended to load or remove media, and the tray is not extending as required.
		/// </summary>
		ERROR_TRAY_MALFUNCTION = 0x00000010,

		/// <summary>An Initialize Element Status command is needed.</summary>
		ERROR_INIT_STATUS_NEEDED = 0x00000011,

		/// <summary>Unknown error condition.</summary>
		ERROR_UNHANDLED_ERROR = 0xFFFFFFFF,
	}

	/// <summary>The element status.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_ELEMENT_STATUS")]
	[Flags]
	public enum ELEMENT_STATUS : uint
	{
		/// <summary>
		/// The changer's transport element can access the piece of media in this element. The media is not accessible in the following
		/// circumstances: (1) If the element type is ChangerSlot, the slot is not present in the changer (for example, the magazine
		/// containing the slot has been physically removed). (2) If the element type is ChangerDrive, the drive is broken or has been
		/// removed. (3) If the element type is ChangerIEPort, the changer's insert/eject port is extended.
		/// </summary>
		ELEMENT_STATUS_ACCESS = 0x00000008,

		/// <summary>Alternate volume information in the AlternateVolumeID member is valid.</summary>
		ELEMENT_STATUS_AVOLTAG = 0x20000000,

		/// <summary>The element is in an abnormal state. Check the ExceptionCode member for more information.</summary>
		ELEMENT_STATUS_EXCEPT = 0x00000004,

		/// <summary>The element supports export of media through the changer's insert/eject port.</summary>
		ELEMENT_STATUS_EXENAB = 0x00000010,

		/// <summary>
		/// The element contains a piece of media.
		/// <para>
		/// Note that this value is valid only if the element type is ChangerDrive, ChangerSlot, or ChangerTransport. If ElementType is
		/// ChangerIEPort, this value is valid only if the Features0 member of GET_CHANGER_PARAMETERS includes CHANGER_REPORT_IEPORT_STATE.
		/// </para>
		/// </summary>
		ELEMENT_STATUS_FULL = 0x00000001,

		/// <summary>
		/// The SCSI target ID in the TargetID member is valid.
		/// <para>This value is valid only if the element type is ChangerDrive.</para>
		/// </summary>
		ELEMENT_STATUS_ID_VALID = 0x00002000,

		/// <summary>
		/// The media in this element was placed there by an operator.
		/// <para>This value is valid only if the element type is ChangerIEPort.</para>
		/// </summary>
		ELEMENT_STATUS_IMPEXP = 0x00000002,

		/// <summary>The element supports import of media through the changer's insert/eject port.</summary>
		ELEMENT_STATUS_INENAB = 0x00000020,

		/// <summary>
		/// The media in the element was flipped.
		/// <para>This value is valid only if ELEMENT_STATUS_SVALID is also included.</para>
		/// </summary>
		ELEMENT_STATUS_INVERT = 0x00400000,

		/// <summary>The logical unit number in the Lun member is valid. This value is valid only if the element type is ChangerDrive.</summary>
		ELEMENT_STATUS_LUN_VALID = 0x00001000,

		/// <summary>The drive at the address indicated by Lun and TargetID is on a different SCSI bus than the changer itself.</summary>
		ELEMENT_STATUS_NOT_BUS = 0x00008000,

		/// <summary>Primary volume information in the PrimaryVolumeID member is valid.</summary>
		ELEMENT_STATUS_PVOLTAG = 0x10000000,

		/// <summary>The SourceElement member and ELEMENT_STATUS_INVERT are both valid.</summary>
		ELEMENT_STATUS_SVALID = 0x00800000,
	}

	/// <summary>Specifies the element type of a changer device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-element_type typedef enum _ELEMENT_TYPE { AllElements,
	// ChangerTransport, ChangerSlot, ChangerIEPort, ChangerDrive, ChangerDoor, ChangerKeypad, ChangerMaxElement } ELEMENT_TYPE, *PELEMENT_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "b026d0f5-133d-4138-a727-80bf4480bb74")]
	public enum ELEMENT_TYPE
	{
		/// <summary>
		/// All elements of a changer, including its robotic transport, drives, slots, and insert/eject ports. This value is valid only
		/// with IOCTL_CHANGER_GET_ELEMENT_STATUS or IOCTL_CHANGER_INITIALIZE_ELEMENT_STATUS.
		/// </summary>
		AllElements,

		/// <summary>Robotic transport element, which is used to move media between insert/eject ports, slots, and drives.</summary>
		ChangerTransport,

		/// <summary>Storage element, which is a slot in the changer in which media is stored when not mounted in a drive.</summary>
		ChangerSlot,

		/// <summary>
		/// Insert/eject port, which is a single- or multiple-cartridge access port in some changers. An element is an insert/eject port
		/// only if it is possible to move a piece of media from a slot to the insert/eject port.
		/// </summary>
		ChangerIEPort,

		/// <summary>Data transfer element where data can be read from and written to media.</summary>
		ChangerDrive,

		/// <summary>
		/// Mechanism that provides access to all media in a changer at one time (as compared to an IEport that provides access to one or
		/// more, but not all, media). For example, a large front door or a magazine that contains all media in the changer is an element
		/// of this type. This value is valid only with IOCTL_CHANGER_SET_ACCESS.
		/// </summary>
		ChangerDoor,

		/// <summary>Keypad or other input control on the front panel of a changer. This value is valid only with IOCTL_CHANGER_SET_ACCESS.</summary>
		ChangerKeypad,
	}

	/// <summary>Defines values for the type of desired storage class.</summary>
	// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/ntifs/ne-ntifs-_file_storage_tier_class typedef enum
	// _FILE_STORAGE_TIER_CLASS { FileStorageTierClassUnspecified, FileStorageTierClassCapacity, FileStorageTierClassPerformance,
	// FileStorageTierClassMax } FILE_STORAGE_TIER_CLASS, *PFILE_STORAGE_TIER_CLASS;
	[PInvokeData("ntifs.h", MSDNShortId = "d969fc78-2517-4b9c-b2ce-489af3ff4e5f")]
	// public enum FILE_STORAGE_TIER_CLASS{FileStorageTierClassUnspecified, FileStorageTierClassCapacity,
	// FileStorageTierClassPerformance, FileStorageTierClassMax, FILE_STORAGE_TIER_CLASS, *PFILE_STORAGE_TIER_CLASS}
	public enum FILE_STORAGE_TIER_CLASS
	{
		/// <summary>Unspecified class type.</summary>
		FileStorageTierClassUnspecified,

		/// <summary>Class capacity.</summary>
		FileStorageTierClassCapacity,

		/// <summary>Class performance.</summary>
		FileStorageTierClassPerformance,
	}

	/// <summary>The file storage tier flags.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_STORAGE_TIER")]
	[Flags]
	public enum FILE_STORAGE_TIER_FLAG : uint
	{
		/// <summary>Tier does not suffer a seek penalty on IO operations, which indicates that is an SSD (solid state drive).</summary>
		FILE_STORAGE_TIER_FLAG_NO_SEEK_PENALTY = 0x00020000,

		/// <summary/>
		FILE_STORAGE_TIER_FLAG_WRITE_BACK_CACHE = 0x00200000,

		/// <summary/>
		FILE_STORAGE_TIER_FLAG_READ_CACHE = 0x00400000,

		/// <summary/>
		FILE_STORAGE_TIER_FLAG_PARITY = 0x00800000,

		/// <summary/>
		FILE_STORAGE_TIER_FLAG_SMR = 0x01000000,
	}

	/// <summary>Specifies the storage media type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-file_storage_tier_media_type typedef enum
	// _FILE_STORAGE_TIER_MEDIA_TYPE { FileStorageTierMediaTypeUnspecified, FileStorageTierMediaTypeDisk, FileStorageTierMediaTypeSsd,
	// FileStorageTierMediaTypeScm, FileStorageTierMediaTypeMax } FILE_STORAGE_TIER_MEDIA_TYPE, *PFILE_STORAGE_TIER_MEDIA_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "6D580AC6-5E3C-4F0B-A922-E81E6B8D8658")]
	public enum FILE_STORAGE_TIER_MEDIA_TYPE
	{
		/// <summary>Media type is unspecified.</summary>
		FileStorageTierMediaTypeUnspecified = 0,

		/// <summary>Media type is an HDD (hard disk drive).</summary>
		FileStorageTierMediaTypeDisk,

		/// <summary>Media type is an SSD (solid state drive).</summary>
		FileStorageTierMediaTypeSsd,

		/// <summary/>
		FileStorageTierMediaTypeScm = 4,
	}

	/// <summary>Flags for FSCTL_GET_INTEGRITY_INFORMATION_BUFFER.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FSCTL_GET_INTEGRITY_INFORMATION_BUFFER")]
	[Flags]
	public enum FSCTL_INTEGRITY_FLAG : uint
	{
		/// <summary>If set, the checksum enforcement is disabled.</summary>
		FSCTL_INTEGRITY_FLAG_CHECKSUM_ENFORCEMENT_OFF = 1
	}

	/// <summary>
	/// Specifies the partition entry attributes used for diagnostics, recovery tools, and other firmware essential to the operation of
	/// the device.
	/// </summary>
	[PInvokeData("winioctl.h", MSDNShortId = "373b4eb3-af6d-4112-9787-f14c19972189")]
	[Flags]
	public enum GPT_ATTRIBUTE : ulong
	{
		/// <summary>
		/// If this attribute is set, the partition is required by a computer to function properly.
		/// <para>
		/// For example, this attribute must be set for OEM partitions. Note that if this attribute is set, you can use the DiskPart.exe
		/// utility to perform partition operations such as deleting the partition. However, because the partition is not a volume, you
		/// cannot use the DiskPart.exe utility to perform volume operations on the partition.
		/// </para>
		/// <para>
		/// This attribute can be set for basic and dynamic disks. If it is set for a partition on a basic disk and the disk is converted
		/// to a dynamic disk, the partition remains a basic partition, even though the rest of the disk is a dynamic disk. This is
		/// because the partition is considered to be an OEM partition on a GPT disk.
		/// </para>
		/// </summary>
		GPT_ATTRIBUTE_PLATFORM_REQUIRED = 0x0000000000000001,

		/// <summary>
		/// If this attribute is set, the partition does not receive a drive letter by default when the disk is moved to another computer
		/// or when the disk is seen for the first time by a computer.
		/// <para>This attribute is useful in storage area network (SAN) environments.</para>
		/// <para>Despite its name, this attribute can be set for basic and dynamic disks.</para>
		/// </summary>
		GPT_BASIC_DATA_ATTRIBUTE_NO_DRIVE_LETTER = 0x8000000000000000,

		/// <summary>
		/// If this attribute is set, the partition is not detected by the Mount Manager.
		/// <para>
		/// As a result, the partition does not receive a drive letter, does not receive a volume GUID path, does not host mounted
		/// folders (also called volume mount points), and is not enumerated by calls to FindFirstVolume and FindNextVolume.This ensures
		/// that applications such as Disk Defragmenter do not access the partition. The Volume Shadow Copy Service (VSS) uses this attribute.
		/// </para>
		/// <para>Despite its name, this attribute can be set for basic and dynamic disks.</para>
		/// </summary>
		GPT_BASIC_DATA_ATTRIBUTE_HIDDEN = 0x4000000000000000,

		/// <summary>
		/// If this attribute is set, the partition is a shadow copy of another partition.
		/// <para>
		/// VSS uses this attribute. This attribute is an indication for file system filter driver-based software (such as antivirus
		/// programs) to avoid attaching to the volume.
		/// </para>
		/// <para>
		/// An application can use the attribute to differentiate a shadow copy volume from a production volume.An application that does
		/// a fast recovery, for example, will break a shadow copy LUN and clear the read-only and hidden attributes and this
		/// attribute.This attribute is set when the shadow copy is created and cleared when the shadow copy is broken.
		/// </para>
		/// <para>Despite its name, this attribute can be set for basic and dynamic disks.</para>
		/// <para>Windows Server 2003: This attribute is not supported before Windows Server 2003 with SP1.</para>
		/// </summary>
		GPT_BASIC_DATA_ATTRIBUTE_SHADOW_COPY = 0x2000000000000000,

		/// <summary>
		/// If this attribute is set, the partition is read-only.
		/// <para>
		/// Writes to the partition will fail. IOCTL_DISK_IS_WRITABLE will fail with the ERROR_WRITE_PROTECT Win32 error code, which
		/// causes the file system to mount as read only, if a file system is present.
		/// </para>
		/// <para>VSS uses this attribute.</para>
		/// <para>
		/// Do not set this attribute for dynamic disks. Setting it can cause I/O errors and prevent the file system from mounting properly.
		/// </para>
		/// </summary>
		GPT_BASIC_DATA_ATTRIBUTE_READ_ONLY = 0x1000000000000000,

		/// <summary>Undocumented.</summary>
		GPT_BASIC_DATA_ATTRIBUTE_OFFLINE = 0x0800000000000000,

		/// <summary>Undocumented.</summary>
		GPT_BASIC_DATA_ATTRIBUTE_DAX = 0x0400000000000000,

		/// <summary>Undocumented.</summary>
		GPT_BASIC_DATA_ATTRIBUTE_SERVICE = 0x0200000000000000,

		/// <summary>Undocumented.</summary>
		GPT_SPACES_ATTRIBUTE_NO_METADATA = 0x8000000000000000,
	}

	/// <summary>Specifies all of the attributes associated with a volume.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._VOLUME_GET_GPT_ATTRIBUTES_INFORMATION")]
	[Flags]
	public enum GPT_BASIC_DATA_ATTRIBUTE : ulong
	{
		/// <summary>The volume is read-only.</summary>
		GPT_BASIC_DATA_ATTRIBUTE_READ_ONLY = 0x1000000000000000,

		/// <summary>The volume is a shadow copy of another volume. For more information, see Volume Shadow Copy Service Overview.</summary>
		GPT_BASIC_DATA_ATTRIBUTE_SHADOW_COPY = 0x2000000000000000,

		/// <summary>The volume is hidden.</summary>
		GPT_BASIC_DATA_ATTRIBUTE_HIDDEN = 0x4000000000000000,

		/// <summary>The volume is not assigned a default drive letter.</summary>
		GPT_BASIC_DATA_ATTRIBUTE_NO_DRIVE_LETTER = 0x8000000000000000,
	}

	/// <summary>
	/// Defined access check value for any access within an I/O control code (IOCTL). The FILE_ACCESS_ANY is generally the correct value.
	/// </summary>
	[Flags]
	[PInvokeData("WinIOCtl.h")]
	public enum IOAccess : byte
	{
		/// <summary>Request all access.</summary>
		FILE_ANY_ACCESS = 0,

		/// <summary>Request read access. Can be used with FILE_WRITE_ACCESS.</summary>
		FILE_READ_ACCESS = 1,

		/// <summary>Request write access. Can be used with FILE_READ_ACCESS.</summary>
		FILE_WRITE_ACCESS = 2,

		/// <summary>Request read and write access. This value is equivalent to (FILE_READ_ACCESS | FILE_WRITE_ACCESS).</summary>
		FILE_READ_WRITE_ACCESS = 3,
	}

	/// <summary>Defined method codes for how buffers are passed for I/O and file system controls within an I/O control code (IOCTL).</summary>
	[PInvokeData("WinIOCtl.h")]
	public enum IOMethod : byte
	{
		/// <summary>The method buffered</summary>
		METHOD_BUFFERED = 0,
		/// <summary>The method in direct</summary>
		METHOD_IN_DIRECT = 1,
		/// <summary>The method out direct</summary>
		METHOD_OUT_DIRECT = 2,
		/// <summary>The method neither</summary>
		METHOD_NEITHER = 3,
	}

	/// <summary>Flags describing characteristics about this stream.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._LOOKUP_STREAM_FROM_CLUSTER_ENTRY")]
	[Flags]
	public enum LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG : uint
	{
		/// <summary>The stream is part of the system pagefile.</summary>
		LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_PAGE_FILE = 0x00000001,

		/// <summary>
		/// The stream is locked from defragmentation. The HandleInfo member of the MARK_HANDLE_INFO structure for this stream has the
		/// MARK_HANDLE_PROTECT_CLUSTERS flag set.
		/// </summary>
		LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_DENY_DEFRAG_SET = 0x00000002,

		/// <summary>The stream is part of a file that is internal to the filesystem.</summary>
		LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_FS_SYSTEM_FILE = 0x00000004,

		/// <summary>The stream is part of a file that is internal to TxF.</summary>
		LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_TXF_SYSTEM_FILE = 0x00000008,

		/// <summary>The stream is part of a $DATA attribute for the file (data stream).</summary>
		LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_DATA = 0x01000000,

		/// <summary>The stream is part of the $INDEX_ALLOCATION attribute for the file.</summary>
		LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_INDEX = 0x02000000,

		/// <summary>The stream is part of another attribute for the file.</summary>
		LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_SYSTEM = 0x03000000,
	}

	/// <summary>
	/// The flag that specifies additional information about the file or directory identified by the handle value in the
	/// <c>VolumeHandle</c> member.
	/// </summary>
	[PInvokeData("winioctl.h", MSDNShortId = "ns-winioctl-mark_handle_info")]
	[Flags]
	public enum MARK_HANDLE_INFO_FLAG : uint
	{
		/// <summary>
		/// The file is marked as unable to be defragmented until the handle is closed.
		/// <para>
		/// Once a handle marked MARK_HANDLE_PROTECT_CLUSTERS is closed, there is no guarantee that the file's clusters won't move.
		/// </para>
		/// </summary>
		MARK_HANDLE_PROTECT_CLUSTERS = 0x00000001,

		/// <summary>
		/// The file is marked as unable to be defragmented until the handle is closed.
		/// <para>Windows Server 2003: This flag is not supported until Windows Server 2003 with SP1.</para>
		/// <para>Windows XP: This flag is not supported.</para>
		/// </summary>
		MARK_HANDLE_TXF_SYSTEM_LOG = 0x00000004,

		/// <summary>
		/// The file is marked as unable to be defragmented until the handle is closed.
		/// <para>Windows Server 2003: This flag is not supported until Windows Server 2003 with SP1.</para>
		/// <para>Windows XP: This flag is not supported.</para>
		/// </summary>
		MARK_HANDLE_NOT_TXF_SYSTEM_LOG = 0x00000008,

		/// <summary>
		/// The file is marked for real-time read behavior regardless of the actual file type. Files marked with this flag must be
		/// opened for unbuffered I/O.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.</para>
		/// </summary>
		MARK_HANDLE_REALTIME = 0x00000020,

		/// <summary>
		/// The file previously marked for real-time read behavior using the MARK_HANDLE_REALTIME flag can be unmarked using this flag,
		/// removing the real-time behavior. Files marked with this flag must be opened for unbuffered I/O.
		/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.</para>
		/// </summary>
		MARK_HANDLE_NOT_REALTIME = 0x00000040,

		/// <summary>
		/// Indicates the copy number specified in the CopyNumber member should be used for reads. Files marked with this flag must be
		/// opened for unbuffered I/O.
		/// <para>
		/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not
		/// supported until Windows 8 and Windows Server 2012.
		/// </para>
		/// </summary>
		MARK_HANDLE_READ_COPY = 0x00000080,

		/// <summary>
		/// The file previously marked for read-copy behavior using the MARK_HANDLE_READ_COPY flag can be unmarked using this flag,
		/// removing the read-copy behavior. Files marked with this flag must be opened for unbuffered I/O.
		/// <para>
		/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not
		/// supported until Windows 8 and Windows Server 2012.
		/// </para>
		/// </summary>
		MARK_HANDLE_NOT_READ_COPY = 0x00000100,

		/// <summary>
		/// When intermixing memory mapped/cached IO with non-cached IO the system attempts, when a non-cached io is issued, to purge
		/// memory mappings for the range of the non-cached IO. If these purges fail the system normally does not return the failure to
		/// the caller which can lead to corrupted state (which is why the documentation says to not do this). This flag tells the
		/// system to return purge failures for the given handle so the application can better handle this situation
		/// <para>This flag is not supported until Windows 8 and Windows Server 2012.</para>
		/// </summary>
		MARK_HANDLE_RETURN_PURGE_FAILURE = 0x00000400,

		/// <summary>
		/// A highly fragmented file in NTFS uses multiple MFT records to describe all of the extents for a file. This list of child MFT
		/// records (also known as FRS records) are controlled by a structure known as an attribute list. An attribute list is limited
		/// to 128K in size. When the size of an attribute list hits a certain threshold NTFS will trigger a background compaction on
		/// the extents so the minimum number of child FRS records will be used. This flag disables this FRS compaction feature for the
		/// given file.
		/// <para>This flag is not supported until Windows 10.</para>
		/// </summary>
		MARK_HANDLE_DISABLE_FILE_METADATA_OPTIMIZATION = 0x00001000,

		/// <summary>
		/// Tells NTFS to set the given UsnSourceInfo value on Paging writes in the USN Journal. Traditionally this was not done on
		/// paging writes since the system did not know what thread made the given changes. This is an override. This only works if the
		/// FileObject the memory manager is using has this state associated with it.
		/// <para>This flag is not supported until Windows 10.</para>
		/// </summary>
		MARK_HANDLE_ENABLE_USN_SOURCE_ON_PAGING_IO = 0x00002000,

		/// <summary>
		/// Setting this flag tells the system that writes are not allowed on this file. If an application tries to open the file for
		/// write access, the operation is failed with STATUS_ACCESS_DENIED. If a write is seen the operation is failed with STATUS_MARKED_TO_DISALLOW_WRITES
		/// <para>This flag is not supported until Windows 10.</para>
		/// </summary>
		MARK_HANDLE_SKIP_COHERENCY_SYNC_DISALLOW_WRITES = 0x00004000,

		/// <summary/>
		MARK_HANDLE_CLOUD_SYNC = 0x00000800,

		/// <summary/>
		MARK_HANDLE_ENABLE_CPU_CACHE = 0x10000000,
	}

	/// <summary/>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CLASS_MEDIA_CHANGE_CONTEXT")]
	public enum MEDIA_CHANGE_DETECTION_STATE
	{
		/// <summary/>
		MediaUnknown = 0,

		/// <summary/>
		MediaPresent = 1,

		/// <summary/>
		MediaNotPresent = 2,

		/// <summary/>
		MediaUnavailable = 3,
	}

	/// <summary>The characteristics of the media.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_MEDIA_INFO")]
	[Flags]
	public enum MEDIA_CHARACTER : uint
	{
		/// <summary/>
		MEDIA_ERASEABLE = 0x00000001,

		/// <summary/>
		MEDIA_WRITE_ONCE = 0x00000002,

		/// <summary/>
		MEDIA_READ_ONLY = 0x00000004,

		/// <summary/>
		MEDIA_READ_WRITE = 0x00000008,

		/// <summary/>
		MEDIA_WRITE_PROTECTED = 0x00000100,

		/// <summary/>
		MEDIA_CURRENTLY_MOUNTED = 0x80000000,
	}

	/// <summary>Represents the various forms of device media.</summary>
	/// <remarks>
	/// The <c>MediaType</c> member of the DISK_GEOMETRY data structure is of type <c>MEDIA_TYPE</c>. The DeviceIoControl function
	/// receives a <c>DISK_GEOMETRY</c> structure in response to an IOCTL_DISK_GET_DRIVE_GEOMETRY control code. The
	/// <c>DeviceIoControl</c> function receives an array of <c>DISK_GEOMETRY</c> structures in response to an
	/// IOCTL_STORAGE_GET_MEDIA_TYPES control code. The STORAGE_MEDIA_TYPE enumeration type extends this enumeration type.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-media_type typedef enum _MEDIA_TYPE { Unknown,
	// F5_1Pt2_512, F3_1Pt44_512, F3_2Pt88_512, F3_20Pt8_512, F3_720_512, F5_360_512, F5_320_512, F5_320_1024, F5_180_512, F5_160_512,
	// RemovableMedia, FixedMedia, F3_120M_512, F3_640_512, F5_640_512, F5_720_512, F3_1Pt2_512, F3_1Pt23_1024, F5_1Pt23_1024,
	// F3_128Mb_512, F3_230Mb_512, F8_256_128, F3_200Mb_512, F3_240M_512, F3_32M_512 } MEDIA_TYPE, *PMEDIA_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "183cf8fc-c17b-4def-b590-0aa4b67488f6")]
	public enum MEDIA_TYPE
	{
		/// <summary>Format is unknown</summary>
		Unknown,

		/// <summary>A 5.25" floppy, with 1.2MB and 512 bytes/sector.</summary>
		F5_1Pt2_512,

		/// <summary>A 3.5" floppy, with 1.44MB and 512 bytes/sector.</summary>
		F3_1Pt44_512,

		/// <summary>A 3.5" floppy, with 2.88MB and 512 bytes/sector.</summary>
		F3_2Pt88_512,

		/// <summary>A 3.5" floppy, with 20.8MB and 512 bytes/sector.</summary>
		F3_20Pt8_512,

		/// <summary>A 3.5" floppy, with 720KB and 512 bytes/sector.</summary>
		F3_720_512,

		/// <summary>A 5.25" floppy, with 360KB and 512 bytes/sector.</summary>
		F5_360_512,

		/// <summary>A 5.25" floppy, with 320KB and 512 bytes/sector.</summary>
		F5_320_512,

		/// <summary>A 5.25" floppy, with 320KB and 1024 bytes/sector.</summary>
		F5_320_1024,

		/// <summary>A 5.25" floppy, with 180KB and 512 bytes/sector.</summary>
		F5_180_512,

		/// <summary>A 5.25" floppy, with 160KB and 512 bytes/sector.</summary>
		F5_160_512,

		/// <summary>Removable media other than floppy.</summary>
		RemovableMedia,

		/// <summary>Fixed hard disk media.</summary>
		FixedMedia,

		/// <summary>A 3.5" floppy, with 120MB and 512 bytes/sector.</summary>
		F3_120M_512,

		/// <summary>A 3.5" floppy, with 640KB and 512 bytes/sector.</summary>
		F3_640_512,

		/// <summary>A 5.25" floppy, with 640KB and 512 bytes/sector.</summary>
		F5_640_512,

		/// <summary>A 5.25" floppy, with 720KB and 512 bytes/sector.</summary>
		F5_720_512,

		/// <summary>A 3.5" floppy, with 1.2MB and 512 bytes/sector.</summary>
		F3_1Pt2_512,

		/// <summary>A 3.5" floppy, with 1.23MB and 1024 bytes/sector.</summary>
		F3_1Pt23_1024,

		/// <summary>A 5.25" floppy, with 1.23MB and 1024 bytes/sector.</summary>
		F5_1Pt23_1024,

		/// <summary>A 3.5" floppy, with 128MB and 512 bytes/sector.</summary>
		F3_128Mb_512,

		/// <summary>A 3.5" floppy, with 230MB and 512 bytes/sector.</summary>
		F3_230Mb_512,

		/// <summary>An 8" floppy, with 256KB and 128 bytes/sector.</summary>
		F8_256_128,

		/// <summary>A 3.5" floppy, with 200MB and 512 bytes/sector. (HiFD).</summary>
		F3_200Mb_512,

		/// <summary>A 3.5" floppy, with 240MB and 512 bytes/sector. (HiFD).</summary>
		F3_240M_512,

		/// <summary>A 3.5" floppy, with 32MB and 512 bytes/sector.</summary>
		F3_32M_512,
	}

	/// <summary/>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REQUEST_OPLOCK_INPUT_BUFFER")]
	[Flags]
	public enum OPLOCK_INPUT_FLAG : uint
	{
		/// <summary>
		/// Request for a new oplock. Setting this flag together with REQUEST_OPLOCK_INPUT_FLAG_ACK is not valid and will cause the
		/// request to fail with ERROR_INVALID_PARAMETER.
		/// </summary>
		REQUEST_OPLOCK_INPUT_FLAG_REQUEST = 0x00000001,

		/// <summary>
		/// Acknowledgment of an oplock break. Setting this flag together with REQUEST_OPLOCK_ INPUT_FLAG_REQUEST is not valid and will
		/// cause the request to fail with ERROR_INVALID_PARAMETER.
		/// </summary>
		REQUEST_OPLOCK_INPUT_FLAG_ACK = 0x00000002,

		/// <summary/>
		REQUEST_OPLOCK_INPUT_FLAG_COMPLETE_ACK_ON_CLOSE = 0x00000004,
	}

	/// <summary/>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REQUEST_OPLOCK_INPUT_BUFFER")]
	[Flags]
	public enum OPLOCK_LEVEL_CACHE : uint
	{
		/// <summary>Allows clients to cache reads. May be granted to multiple clients.</summary>
		OPLOCK_LEVEL_CACHE_READ = 0x00000001,

		/// <summary>Allows clients to cache open handles. May be granted to multiple clients.</summary>
		OPLOCK_LEVEL_CACHE_HANDLE = 0x00000002,

		/// <summary>Allows clients to cache writes and byte range locks. May be granted only to a single client.</summary>
		OPLOCK_LEVEL_CACHE_WRITE = 0x00000004,
	}

	/// <summary>Flags for REQUEST_OPLOCK_OUTPUT_BUFFER.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REQUEST_OPLOCK_OUTPUT_BUFFER")]
	[Flags]
	public enum OPLOCK_OUTPUT_FLAG : uint
	{
		/// <summary>
		/// Indicates that an acknowledgment is required, and the oplock described in OriginalOplockLevel will continue to remain in
		/// force until the break is successfully acknowledged.
		/// </summary>
		REQUEST_OPLOCK_OUTPUT_FLAG_ACK_REQUIRED = 0x00000001,

		/// <summary>
		/// Indicates that the ShareMode and AccessMode members contain the share and access flags, respectively, of the request causing
		/// the oplock break. For more information, see the Remarks section.
		/// </summary>
		REQUEST_OPLOCK_OUTPUT_FLAG_MODES_PROVIDED = 0x00000002,
	}

	/// <summary>Represents the format of a partition.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-partition_style typedef enum _PARTITION_STYLE {
	// PARTITION_STYLE_MBR, PARTITION_STYLE_GPT, PARTITION_STYLE_RAW } PARTITION_STYLE;
	[PInvokeData("winioctl.h", MSDNShortId = "254e4ea1-d0c8-4033-b8af-e5dbfb7c7da8")]
	public enum PARTITION_STYLE
	{
		/// <summary>Master boot record (MBR) format. This corresponds to standard AT-style MBR partitions.</summary>
		PARTITION_STYLE_MBR,

		/// <summary>GUID Partition Table (GPT) format.</summary>
		PARTITION_STYLE_GPT,

		/// <summary>Partition not formatted in either of the recognized formats—MBR or GPT.</summary>
		PARTITION_STYLE_RAW,
	}

	/// <summary>Partition types.</summary>
	[PInvokeData("winioctl.h")]
	public enum PartitionType : byte
	{
		/// <summary>Unused entry</summary>
		PARTITION_ENTRY_UNUSED = 0,

		/// <summary>Specifies a partition with 12-bit FAT entries</summary>
		PARTITION_FAT_12,

		/// <summary>Specifies a XENIX Type 1 partition</summary>
		PARTITION_XENIX_1,

		/// <summary>Specifies a XENIX Type 2 partition</summary>
		PARTITION_XENIX_2,

		/// <summary>Specifies a partition with 16-bit FAT entries.</summary>
		PARTITION_FAT_16,

		/// <summary>Specifies an MS-DOS V4 extended partition</summary>
		PARTITION_EXTENDED,

		/// <summary>Specifies an MS-DOS V4 huge partition</summary>
		PARTITION_HUGE,

		/// <summary>Specifies an IFS partition</summary>
		PARTITION_IFS,

		/// <summary>OS/2 Boot Manager/OPUS/Coherent swap</summary>
		PARTITION_OS2BOOTMGR = 0x0A,

		/// <summary>Specifies a FAT32 partition</summary>
		PARTITION_FAT32,

		/// <summary>Win95 partition using extended int13 services</summary>
		PARTITION_XINT13 = 0x0E,

		/// <summary>Windows 95/98: Specifies a partition that uses extended INT 13 services</summary>
		PARTITION_FAT32_XINT13,

		/// <summary>Windows 95/98: Same as PARTITION_EXTENDED, but uses extended INT 13 services</summary>
		PARTITION_XINT13_EXTENDED,

		/// <summary>Microsoft recovery partition</summary>
		PARTITION_MSFT_RECOVERY = 0x27,

		/// <summary>Main OS partition</summary>
		PARTITION_MAIN_OS = 0x28,

		/// <summary>OS data partition</summary>
		PARTIITON_OS_DATA = 0x29,

		/// <summary>PreInstalled partition</summary>
		PARTITION_PRE_INSTALLED = 0x2a,

		/// <summary>BSP partition</summary>
		PARTITION_BSP = 0x2b,

		/// <summary>DPP partition</summary>
		PARTITION_DPP = 0x2c,

		/// <summary>Windows system partition</summary>
		PARTITION_WINDOWS_SYSTEM = 0x2d,

		/// <summary>Specifies a PowerPC Reference Platform partition</summary>
		PARTITION_PREP = 0x41,

		/// <summary>Specifies a logical disk manager partition</summary>
		PARTITION_LDM,

		/// <summary>OnTrack Disk Manager partition</summary>
		PARTITION_DM = 0x54,

		/// <summary>EZ-Drive partition</summary>
		PARTITION_EZDRIVE = 0x55,

		/// <summary>Specifies a UNIX partition</summary>
		PARTITION_UNIX = 0x63,

		/// <summary>Storage Spaces protective partition</summary>
		PARTITION_SPACES_DATA = 0xD7,

		/// <summary>Storage Spaces protective partition</summary>
		PARTITION_SPACES = 0xE7,

		/// <summary>Gpt protective partition</summary>
		PARTITION_GPT = 0xEE,

		/// <summary>System partition</summary>
		PARTITION_SYSTEM = 0xEF,

		/// <summary>
		/// Specifies an NTFT partition. This value is used in combination (that is, bitwise logically ORed) with the other values in
		/// this table
		/// </summary>
		PARTITION_NTFT = 0x80,
	}

	/// <summary>Indicates the operation to perform.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._SHRINK_VOLUME_INFORMATION")]
	public enum SHRINK_VOLUME_REQUEST_TYPES
	{
		/// <summary>Volume should perform any steps necessary to prepare for a shrink operation.</summary>
		ShrinkPrepare = 1,

		/// <summary>Volume should commit the shrink operation changes.</summary>
		ShrinkCommit,

		/// <summary>Volume should terminate the shrink operation.</summary>
		ShrinkAbort
	}

	/// <summary>Specifies the SCSI request block (SRB) type used by the HBA.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_ADAPTER_DESCRIPTOR")]
	public enum SRB_TYPE : byte
	{
		/// <summary>The HBA uses SCSI request blocks.</summary>
		SRB_TYPE_SCSI_REQUEST_BLOCK = 0,

		/// <summary>The HBA uses extended SCSI request blocks.</summary>
		SRB_TYPE_STORAGE_REQUEST_BLOCK = 1
	}

	/// <summary>Specifies the address type of the HBA.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_ADAPTER_DESCRIPTOR")]
	public enum STORAGE_ADDRESS_TYPE : byte
	{
		/// <summary>The HBA uses 8-bit bus, target, and LUN addressing.</summary>
		STORAGE_ADDRESS_TYPE_BTL8 = 0
	}

	/// <summary>Specifies the various types of storage buses.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_bus_type typedef enum _STORAGE_BUS_TYPE {
	// BusTypeUnknown, BusTypeScsi, BusTypeAtapi, BusTypeAta, BusType1394, BusTypeSsa, BusTypeFibre, BusTypeUsb, BusTypeRAID,
	// BusTypeiScsi, BusTypeSas, BusTypeSata, BusTypeSd, BusTypeMmc, BusTypeVirtual, BusTypeFileBackedVirtual, BusTypeSpaces,
	// BusTypeNvme, BusTypeSCM, BusTypeUfs, BusTypeMax, BusTypeMaxReserved } STORAGE_BUS_TYPE, *PSTORAGE_BUS_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "fb5a17f7-8ddb-4738-83e1-f00abc3555d2")]
	public enum STORAGE_BUS_TYPE
	{
		/// <summary>Unknown bus type.</summary>
		BusTypeUnknown,

		/// <summary>SCSI bus.</summary>
		BusTypeScsi,

		/// <summary>ATAPI bus.</summary>
		BusTypeAtapi,

		/// <summary>ATA bus.</summary>
		BusTypeAta,

		/// <summary>IEEE-1394 bus.</summary>
		BusType1394,

		/// <summary>SSA bus.</summary>
		BusTypeSsa,

		/// <summary>Fibre Channel bus.</summary>
		BusTypeFibre,

		/// <summary>USB bus.</summary>
		BusTypeUsb,

		/// <summary>RAID bus.</summary>
		BusTypeRAID,

		/// <summary/>
		BusTypeiScsi,

		/// <summary>Serial Attached SCSI (SAS) bus. Windows Server 2003: This is not supported before Windows Server 2003 with SP1.</summary>
		BusTypeSas,

		/// <summary>SATA bus. Windows Server 2003: This is not supported before Windows Server 2003 with SP1.</summary>
		BusTypeSata,

		/// <summary/>
		BusTypeSd,

		/// <summary/>
		BusTypeMmc,

		/// <summary/>
		BusTypeVirtual,

		/// <summary/>
		BusTypeFileBackedVirtual,

		/// <summary/>
		BusTypeSpaces,

		/// <summary/>
		BusTypeNvme,

		/// <summary/>
		BusTypeSCM,

		/// <summary/>
		BusTypeUfs,

		/// <summary/>
		BusTypeMaxReserved = 0x7f,
	}

	/// <summary>Specifies the health status of a storage component.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_component_health_status typedef enum
	// _STORAGE_COMPONENT_HEALTH_STATUS { HealthStatusUnknown, HealthStatusNormal, HealthStatusThrottled, HealthStatusWarning,
	// HealthStatusDisabled, HealthStatusFailed } STORAGE_COMPONENT_HEALTH_STATUS, *PSTORAGE_COMPONENT_HEALTH_STATUS;
	[PInvokeData("winioctl.h", MSDNShortId = "ECC5A745-EA8B-4FBE-840D-0D959C9ED5BA")]
	public enum STORAGE_COMPONENT_HEALTH_STATUS
	{
		/// <summary/>
		HealthStatusUnknown,

		/// <summary/>
		HealthStatusNormal,

		/// <summary/>
		HealthStatusThrottled,

		/// <summary/>
		HealthStatusWarning,

		/// <summary/>
		HealthStatusDisabled,

		/// <summary/>
		HealthStatusFailed,
	}

	/// <summary>Specifies the form factor of a device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_device_form_factor typedef enum
	// _STORAGE_DEVICE_FORM_FACTOR { FormFactorUnknown, FormFactor3_5, FormFactor2_5, FormFactor1_8, FormFactor1_8Less,
	// FormFactorEmbedded, FormFactorMemoryCard, FormFactormSata, FormFactorM_2, FormFactorPCIeBoard, FormFactorDimm }
	// STORAGE_DEVICE_FORM_FACTOR, *PSTORAGE_DEVICE_FORM_FACTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "B8FCDC58-D599-4EEE-8096-818345FCD75F")]
	public enum STORAGE_DEVICE_FORM_FACTOR
	{
		/// <summary/>
		FormFactorUnknown,

		/// <summary>3.5-inch nominal form factor.</summary>
		FormFactor3_5,

		/// <summary>2.5-inch nominal form factor.</summary>
		FormFactor2_5,

		/// <summary>1.8-inch nominal form factor.</summary>
		FormFactor1_8,

		/// <summary>Less than 1.8-inch nominal form factor.</summary>
		FormFactor1_8Less,

		/// <summary>Embedded on board.</summary>
		FormFactorEmbedded,

		/// <summary>Memory card such as SD, CF.</summary>
		FormFactorMemoryCard,

		/// <summary>mSATA</summary>
		FormFactormSata,

		/// <summary>M.2</summary>
		FormFactorM_2,

		/// <summary>PCIe card plug into slot.</summary>
		FormFactorPCIeBoard,

		/// <summary>DIMM slot.</summary>
		FormFactorDimm,
	}

	/// <summary>The units of the maximum power threshold.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_device_power_cap_units typedef enum
	// _STORAGE_DEVICE_POWER_CAP_UNITS { StorageDevicePowerCapUnitsPercent, StorageDevicePowerCapUnitsMilliwatts }
	// STORAGE_DEVICE_POWER_CAP_UNITS, *PSTORAGE_DEVICE_POWER_CAP_UNITS;
	[PInvokeData("winioctl.h", MSDNShortId = "A6C48765-9A18-4F77-8B0F-9653CE6FDE23")]
	public enum STORAGE_DEVICE_POWER_CAP_UNITS
	{
		/// <summary>Units in percent.</summary>
		StorageDevicePowerCapUnitsPercent,

		/// <summary>Units in milliwatts.</summary>
		StorageDevicePowerCapUnitsMilliwatts,
	}

	/// <summary>The flags associated with the activation request.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_HW_FIRMWARE_ACTIVATE")]
	[Flags]
	public enum STORAGE_HW_FIRMWARE_REQUEST_FLAG : uint
	{
		/// <summary>
		/// Indicates that the target of the request is a controller or adapter, different than the device handle or object itself (e.g.
		/// NVMe SSD or HBA).
		/// </summary>
		STORAGE_HW_FIRMWARE_REQUEST_FLAG_CONTROLLER = 0x00000001,

		/// <summary>Indicates that current firmware image segment is the last one.</summary>
		STORAGE_HW_FIRMWARE_REQUEST_FLAG_LAST_SEGMENT = 0x00000002,

		/// <summary>Indicates that current firmware image segment is the first one.</summary>
		STORAGE_HW_FIRMWARE_REQUEST_FLAG_FIRST_SEGMENT = 0x00000004,

		/// <summary>Indicates that the existing firmware image in the specified slot should be activated.</summary>
		STORAGE_HW_FIRMWARE_REQUEST_FLAG_SWITCH_TO_EXISTING_FIRMWARE = 0x80000000,
	}

	/// <summary>
	/// Specifies various types of storage media. Parameters and members of type <c>STORAGE_MEDIA_TYPE</c> also accept values from the
	/// MEDIA_TYPE enumeration type.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_media_type typedef enum _STORAGE_MEDIA_TYPE {
	// DDS_4mm, MiniQic, Travan, QIC, MP_8mm, AME_8mm, AIT1_8mm, DLT, NCTP, IBM_3480, IBM_3490E, IBM_Magstar_3590, IBM_Magstar_MP,
	// STK_DATA_D3, SONY_DTF, DV_6mm, DMI, SONY_D2, CLEANER_CARTRIDGE, CD_ROM, CD_R, CD_RW, DVD_ROM, DVD_R, DVD_RW, MO_3_RW, MO_5_WO,
	// MO_5_RW, MO_5_LIMDOW, PC_5_WO, PC_5_RW, PD_5_RW, ABL_5_WO, PINNACLE_APEX_5_RW, SONY_12_WO, PHILIPS_12_WO, HITACHI_12_WO,
	// CYGNET_12_WO, KODAK_14_WO, MO_NFR_525, NIKON_12_RW, IOMEGA_ZIP, IOMEGA_JAZ, SYQUEST_EZ135, SYQUEST_EZFLYER, SYQUEST_SYJET,
	// AVATAR_F2, MP2_8mm, DST_S, DST_M, DST_L, VXATape_1, VXATape_2, STK_EAGLE, LTO_Ultrium, LTO_Accelis, DVD_RAM, AIT_8mm, ADR_1,
	// ADR_2, STK_9940, SAIT, VXATape } STORAGE_MEDIA_TYPE, *PSTORAGE_MEDIA_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "f584d766-0d4d-49b8-b58a-09556c494270")]
	public enum STORAGE_MEDIA_TYPE
	{
		/// <summary>One of the following tape types: DAT, DDS1, DDS2, and so on.</summary>
		DDS_4mm = 0x20,

		/// <summary>MiniQIC tape.</summary>
		MiniQic,

		/// <summary>Travan tape (TR-1, TR-2, TR-3, and so on).</summary>
		Travan,

		/// <summary>QIC tape.</summary>
		QIC,

		/// <summary>An 8mm Exabyte metal particle tape.</summary>
		MP_8mm,

		/// <summary>An 8mm Exabyte advanced metal evaporative tape.</summary>
		AME_8mm,

		/// <summary>An 8mm Sony AIT1 tape.</summary>
		AIT1_8mm,

		/// <summary>DLT compact tape (IIIxt or IV).</summary>
		DLT,

		/// <summary>Philips NCTP tape.</summary>
		NCTP,

		/// <summary>IBM 3480 tape.</summary>
		IBM_3480,

		/// <summary>IBM 3490E tape.</summary>
		IBM_3490E,

		/// <summary>IBM Magstar 3590 tape.</summary>
		IBM_Magstar_3590,

		/// <summary>IBM Magstar MP tape.</summary>
		IBM_Magstar_MP,

		/// <summary>STK data D3 tape.</summary>
		STK_DATA_D3,

		/// <summary>Sony DTF tape.</summary>
		SONY_DTF,

		/// <summary>A 6mm digital videotape.</summary>
		DV_6mm,

		/// <summary>Exabyte DMI tape (or compatible).</summary>
		DMI,

		/// <summary>Sony D2S or D2L tape.</summary>
		SONY_D2,

		/// <summary>Cleaner (all drive types that support cleaners).</summary>
		CLEANER_CARTRIDGE,

		/// <summary>CD.</summary>
		CD_ROM,

		/// <summary>CD (write once).</summary>
		CD_R,

		/// <summary>CD (rewritable).</summary>
		CD_RW,

		/// <summary>DVD.</summary>
		DVD_ROM,

		/// <summary>DVD (write once).</summary>
		DVD_R,

		/// <summary>DVD (rewritable).</summary>
		DVD_RW,

		/// <summary>Magneto-optical 3.5" (rewritable).</summary>
		MO_3_RW,

		/// <summary>Magneto-optical 5.25" (write once).</summary>
		MO_5_WO,

		/// <summary>Magneto-optical 5.25" (rewritable; not LIMDOW).</summary>
		MO_5_RW,

		/// <summary>Magneto-optical 5.25" (rewritable; LIMDOW).</summary>
		MO_5_LIMDOW,

		/// <summary>Phase change 5.25" (write once)</summary>
		PC_5_WO,

		/// <summary>Phase change 5.25" (rewritable)</summary>
		PC_5_RW,

		/// <summary>Phase change dual (rewritable)</summary>
		PD_5_RW,

		/// <summary>Ablative 5.25" (write once).</summary>
		ABL_5_WO,

		/// <summary>Pinnacle Apex 4.6GB (rewritable)</summary>
		PINNACLE_APEX_5_RW,

		/// <summary>Sony 12" (write once).</summary>
		SONY_12_WO,

		/// <summary>Philips/LMS 12" (write once).</summary>
		PHILIPS_12_WO,

		/// <summary>Hitachi 12" (write once)</summary>
		HITACHI_12_WO,

		/// <summary>Cygnet/ATG 12" (write once)</summary>
		CYGNET_12_WO,

		/// <summary>Kodak 14" (write once)</summary>
		KODAK_14_WO,

		/// <summary>MO near field recording (Terastor)</summary>
		MO_NFR_525,

		/// <summary>Nikon 12" (rewritable).</summary>
		NIKON_12_RW,

		/// <summary>Iomega Zip.</summary>
		IOMEGA_ZIP,

		/// <summary>Iomega Jaz.</summary>
		IOMEGA_JAZ,

		/// <summary>Syquest EZ135.</summary>
		SYQUEST_EZ135,

		/// <summary>Syquest EzFlyer.</summary>
		SYQUEST_EZFLYER,

		/// <summary>Syquest SyJet.</summary>
		SYQUEST_SYJET,

		/// <summary>Avatar 2.5" floppy.</summary>
		AVATAR_F2,

		/// <summary>An 8mm Hitachi tape.</summary>
		MP2_8mm,

		/// <summary>Ampex DST small tape.</summary>
		DST_S,

		/// <summary>Ampex DST medium tape.</summary>
		DST_M,

		/// <summary>Ampex DST large tape.</summary>
		DST_L,

		/// <summary>Ecrix 8mm tape.</summary>
		VXATape_1,

		/// <summary>Ecrix 8mm tape.</summary>
		VXATape_2,

		/// <summary/>
		STK_EAGLE,

		/// <summary>LTO Ultrium (IBM, HP, Seagate).</summary>
		LTO_Ultrium,

		/// <summary>LTO Accelis (IBM, HP, Seagate).</summary>
		LTO_Accelis,

		/// <summary>DVD-RAM.</summary>
		DVD_RAM,

		/// <summary>AIT tape (AIT2 or higher).</summary>
		AIT_8mm,

		/// <summary>OnStream ADR1.</summary>
		ADR_1,

		/// <summary>OnStream ADR2.</summary>
		ADR_2,

		/// <summary>STK 9940.</summary>
		STK_9940,

		/// <summary>SAIT tape. Windows Server 2003: This is not supported before Windows Server 2003 with SP1.</summary>
		SAIT,

		/// <summary>Exabyte VXA tape. Windows Server 2008: This is not supported before Windows Server 2008.</summary>
		VXATape,
	}

	/// <summary>Output flags.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_OFFLOAD_READ_OUTPUT")]
	[Flags]
	public enum STORAGE_OFFLOAD_READ : uint
	{
		/// <summary>
		/// The ranges represented by the token is smaller than the ranges specified in the DEVICE_DATA_SET_RANGE structures passed in
		/// the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code input buffer. In other words the LengthProtected member is less
		/// than the sum of all of the LengthInBytes members of the DEVICE_DATA_SET_RANGE structures passed.
		/// </summary>
		STORAGE_OFFLOAD_READ_RANGE_TRUNCATED = 0x00000001
	}

	/// <summary>Out flags</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_OFFLOAD_WRITE_OUTPUT")]
	[Flags]
	public enum STORAGE_OFFLOAD_WRITE : uint
	{
		/// <summary>The range written is less than the range specified.</summary>
		STORAGE_OFFLOAD_WRITE_RANGE_TRUNCATED = 0x0001,

		/// <summary>The token specified is not valid.</summary>
		STORAGE_OFFLOAD_TOKEN_INVALID = 0x0002,
	}

	/// <summary>Reserved for system use.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_port_code_set typedef enum _STORAGE_PORT_CODE_SET
	// { StoragePortCodeSetReserved, StoragePortCodeSetStorport, StoragePortCodeSetSCSIport, StoragePortCodeSetSpaceport,
	// StoragePortCodeSetATAport, StoragePortCodeSetUSBport, StoragePortCodeSetSBP2port, StoragePortCodeSetSDport }
	// STORAGE_PORT_CODE_SET, *PSTORAGE_PORT_CODE_SET;
	[PInvokeData("winioctl.h", MSDNShortId = "1c1032e8-30b8-45ad-973a-c7616139b26e")]
	public enum STORAGE_PORT_CODE_SET
	{
		/// <summary>Indicates an unknown storage adapter driver type.</summary>
		StoragePortCodeSetReserved,

		/// <summary>Storage adapter driver is a Storport-miniport driver.</summary>
		StoragePortCodeSetStorport,

		/// <summary>Storage adapter driver is a SCSI Port-miniport driver.</summary>
		StoragePortCodeSetSCSIport,

		/// <summary>Storage adapter driver is the Spaceport driver.</summary>
		StoragePortCodeSetSpaceport,

		/// <summary>Storage adapter driver is an ATA-port miniport driver.</summary>
		StoragePortCodeSetATAport,

		/// <summary>Storage adapter driver is the USB-storage port driver.</summary>
		StoragePortCodeSetUSBport,

		/// <summary>Storage adapter driver is the SBP2 port driver.</summary>
		StoragePortCodeSetSBP2port,

		/// <summary>Storage adapter driver is an SD-port miniport driver.</summary>
		StoragePortCodeSetSDport,
	}

	/// <summary>
	/// Enumerates the possible values of the <c>PropertyId</c> member of the STORAGE_PROPERTY_QUERY structure passed as input to the
	/// IOCTL_STORAGE_QUERY_PROPERTY request to retrieve the properties of a storage device or adapter.
	/// </summary>
	/// <remarks>
	/// The optional output buffer returned through the lpOutBuffer parameter of the IOCTL_STORAGE_QUERY_PROPERTY control code request
	/// can be one of several structures depending on the value of the <c>PropertyId</c> member of the STORAGE_PROPERTY_QUERY structure
	/// pointed to by the lpInBuffer parameter. If the <c>QueryType</c> member of the <c>STORAGE_PROPERTY_QUERY</c> is set to
	/// <c>PropertyExistsQuery</c>, then no structure is returned.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_property_id typedef enum _STORAGE_PROPERTY_ID {
	// StorageDeviceProperty, StorageAdapterProperty, StorageDeviceIdProperty, StorageDeviceUniqueIdProperty,
	// StorageDeviceWriteCacheProperty, StorageMiniportProperty, StorageAccessAlignmentProperty, StorageDeviceSeekPenaltyProperty,
	// StorageDeviceTrimProperty, StorageDeviceWriteAggregationProperty, StorageDeviceDeviceTelemetryProperty,
	// StorageDeviceLBProvisioningProperty, StorageDevicePowerProperty, StorageDeviceCopyOffloadProperty,
	// StorageDeviceResiliencyProperty, StorageDeviceMediumProductType, StorageAdapterRpmbProperty, StorageAdapterCryptoProperty,
	// StorageDeviceIoCapabilityProperty, StorageAdapterProtocolSpecificProperty, StorageDeviceProtocolSpecificProperty,
	// StorageAdapterTemperatureProperty, StorageDeviceTemperatureProperty, StorageAdapterPhysicalTopologyProperty,
	// StorageDevicePhysicalTopologyProperty, StorageDeviceAttributesProperty, StorageDeviceManagementStatus,
	// StorageAdapterSerialNumberProperty, StorageDeviceLocationProperty, StorageDeviceNumaProperty, StorageDeviceZonedDeviceProperty,
	// StorageDeviceUnsafeShutdownCount, StorageDeviceEnduranceProperty } STORAGE_PROPERTY_ID, *PSTORAGE_PROPERTY_ID;
	[PInvokeData("winioctl.h", MSDNShortId = "9747be01-7c70-4697-97f7-e3830b54ba0a")]
	public enum STORAGE_PROPERTY_ID
	{
		/// <summary>Indicates that the caller is querying for the device descriptor, STORAGE_DEVICE_DESCRIPTOR.</summary>
		[CorrespondingType(typeof(STORAGE_DEVICE_DESCRIPTOR_MGD))]
		StorageDeviceProperty = 0,

		/// <summary>Indicates that the caller is querying for the adapter descriptor, STORAGE_ADAPTER_DESCRIPTOR.</summary>
		[CorrespondingType(typeof(STORAGE_ADAPTER_DESCRIPTOR))]
		StorageAdapterProperty,

		/// <summary>
		/// Indicates that the caller is querying for the device identifiers provided with the SCSI vital product data pages. Data is
		/// returned using the STORAGE_DEVICE_ID_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_DEVICE_ID_DESCRIPTOR))]
		StorageDeviceIdProperty,

		/// <summary>
		/// Intended for driver usage. Indicates that the caller is querying for the unique device identifiers. Data is returned using
		/// the STORAGE_DEVICE_UNIQUE_IDENTIFIER structure (see the storduid.h header in the DDK). Windows Server 2003 and Windows XP:
		/// This value is not supported before Windows Vista and Windows Server 2008.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_DEVICE_UNIQUE_IDENTIFIER_MGD))]
		StorageDeviceUniqueIdProperty,

		/// <summary>
		/// Indicates that the caller is querying for the write cache property. Data is returned using the STORAGE_WRITE_CACHE_PROPERTY
		/// structure. Windows Server 2003 and Windows XP: This value is not supported before Windows Vista and Windows Server 2008.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_WRITE_CACHE_PROPERTY))]
		StorageDeviceWriteCacheProperty,

		/// <summary>Reserved for system use.</summary>
		StorageMiniportProperty,

		/// <summary>
		/// Indicates that the caller is querying for the access alignment descriptor, STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR. Windows
		/// Server 2003 and Windows XP: This value is not supported before Windows Vista and Windows Server 2008.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR))]
		StorageAccessAlignmentProperty,

		/// <summary>
		/// Indicates that the caller is querying for the trim descriptor, DEVICE_TRIM_DESCRIPTOR. Windows Server 2008, Windows Vista,
		/// Windows Server 2003 and Windows XP: This value is not supported before Windows 7 and Windows Server 2008 R2.
		/// </summary>
		[CorrespondingType(typeof(DEVICE_TRIM_DESCRIPTOR))]
		StorageDeviceTrimProperty,

		/// <summary>
		/// Indicates that the caller is querying for the device power descriptor. Data is returned using the DEVICE_POWER_DESCRIPTOR
		/// structure. Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This
		/// value is not supported before Windows 8 and Windows Server 2012.
		/// </summary>
		[CorrespondingType(typeof(DEVICE_POWER_DESCRIPTOR))]
		StorageDevicePowerProperty,

		/// <summary>Reserved for system use.</summary>
		StorageDeviceResiliencyProperty,

		/// <summary>
		/// Indicates that the caller is querying for the medium product type. Data is returned using the
		/// STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR))]
		StorageDeviceMediumProductType,

		/// <summary>
		/// Indicates that the caller is querying for RPMB support and properties. Data is returned using the STORAGE_RPMB_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_RPMB_DESCRIPTOR))]
		StorageAdapterRpmbProperty,

		/// <summary>
		/// Provides info on the storage adapter encryption capabilities. This is currently supported on UFS (Universal Flash Storage) adapters.
		/// </summary>
		StorageAdapterCryptoProperty,

		/// <summary>
		/// Indicates that the caller is querying for the device I/O capability property. Data is returned using the
		/// DEVICE_IO_CAPABILITY_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_DEVICE_IO_CAPABILITY_DESCRIPTOR))]
		StorageDeviceIoCapabilityProperty = 48,

		/// <summary>
		/// Indicates that the caller is querying for protocol-specific data from the adapter. Data is returned using the
		/// STORAGE_PROTOCOL_DATA_DESCRIPTOR structure. See the remarks for more info.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_PROTOCOL_DATA_DESCRIPTOR))]
		StorageAdapterProtocolSpecificProperty,

		/// <summary>
		/// Indicates that the caller is querying for protocol-specific data from the device. Data is returned using the
		/// STORAGE_PROTOCOL_DATA_DESCRIPTOR structure. See the remarks for more info.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_PROTOCOL_DATA_DESCRIPTOR))]
		StorageDeviceProtocolSpecificProperty,

		/// <summary>
		/// Indicates that the caller is querying temperature data from the adapter. Data is returned using the
		/// STORAGE_TEMPERATURE_DATA_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_TEMPERATURE_DATA_DESCRIPTOR))]
		StorageAdapterTemperatureProperty,

		/// <summary>
		/// Indicates that the caller is querying for temperature data from the device. Data is returned using the
		/// STORAGE_TEMPERATURE_DATA_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_TEMPERATURE_DATA_DESCRIPTOR))]
		StorageDeviceTemperatureProperty,

		/// <summary>
		/// Indicates that the caller is querying for topology information from the adapter. Data is returned using the
		/// STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR))]
		StorageAdapterPhysicalTopologyProperty,

		/// <summary>
		/// Indicates that the caller is querying for topology information from the device. Data is returned using the
		/// STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR))]
		StorageDevicePhysicalTopologyProperty,

		/// <summary>Reserved for future use.</summary>
		StorageDeviceAttributesProperty,

		/// <summary>Provides health information about the storage device (specifically for the persistent memory stack).</summary>
		[CorrespondingType(typeof(STORAGE_DEVICE_MANAGEMENT_STATUS))]
		StorageDeviceManagementStatus,

		/// <summary>
		/// Indicates that the caller is querying for the adapter serial number. Data is returned using the STORAGE_ADAPTER_SERIAL_NUMBER structure.
		/// </summary>
		[CorrespondingType(typeof(STORAGE_ADAPTER_SERIAL_NUMBER))]
		StorageAdapterSerialNumberProperty,

		/// <summary>Reserved for system use.</summary>
		StorageDeviceLocationProperty,

		/// <summary>Provides the non-uniform memory access (NUMA) node of the storage device.</summary>
		StorageDeviceNumaProperty,

		/// <summary>Reserved for system use.</summary>
		StorageDeviceZonedDeviceProperty,

		/// <summary>
		/// Provides the unsafe shutdown count value used to determine if the device data might have been lost during a power loss event
		/// (specifically for the persistent memory stack).
		/// </summary>
		StorageDeviceUnsafeShutdownCount,

		/// <summary>
		/// Provides info on how many bytes have been read/write from a solid-state drive (SSD). This property is supported only for
		/// Non-Volatile Memory Express (NVMe) devices that implement a certain NVMe feature.
		/// </summary>
		StorageDeviceEnduranceProperty,

		/// <summary>Provides info on the state of the LED associated with a storage device. This is a server-oriented feature.</summary>
		StorageDeviceLedStateProperty,

		/// <summary>Reserved for system use.</summary>
		StorageDeviceSelfEncryptionProperty = 64,

		/// <summary>Provides identification info for a storage device that can be physically replaced with a Field Replacement Unit (FRU).</summary>
		StorageFruIdProperty
	}

	/// <summary>
	/// <para>
	/// [Some information relates to pre-released product which may be substantially modified before it's commercially released.
	/// Microsoft makes no warranties, express or implied, with respect to the information provided here.]
	/// </para>
	/// <para>The ATA protocol data type.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// When using IOCTL_STORAGE_QUERY_PROPERTY to retrieve protocol-specific information in the STORAGE_PROTOCOL_DATA_DESCRIPTOR,
	/// configure the STORAGE_PROPERTY_QUERY structure as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Allocate a buffer that can contains both a STORAGE_PROPERTY_QUERY and a STORAGE_PROTOCOL_SPECIFIC_DATA structure.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Set the <c>PropertyID</c> field to <c>StorageAdapterProtocolSpecificProperty</c> or <c>StorageDeviceProtocolSpecificProperty</c>
	/// for a controller or device/namespace request, respectively.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Set the <c>QueryType</c> field to <c>PropertyStandardQuery</c>.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Fill the STORAGE_PROTOCOL_SPECIFIC_DATA structure with the desired values. The start of the <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c>
	/// is the <c>AdditionalParameters</c> field of STORAGE_PROPERTY_QUERY.
	/// </term>
	/// </item>
	/// </list>
	/// <para>To specify a type of ATA protocol-specific information, configure the STORAGE_PROTOCOL_SPECIFIC_DATA structure as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the <c>ProtocolType</c> field to <c>ProtocolTypeAta</c>.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DataType</c> field to an enumeration value defined by <c>STORAGE_PROTOCOL_ATA_DATA_TYPE</c>:</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_protocol_ata_data_type typedef enum
	// _STORAGE_PROTOCOL_ATA_DATA_TYPE { AtaDataTypeUnknown, AtaDataTypeIdentify, AtaDataTypeLogPage } STORAGE_PROTOCOL_ATA_DATA_TYPE, *PSTORAGE_PROTOCOL_ATA_DATA_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "999CB5EB-9D19-41B9-B4ED-001B63C1A7EA")]
	public enum STORAGE_PROTOCOL_ATA_DATA_TYPE
	{
		/// <summary>Unknown data type.</summary>
		AtaDataTypeUnknown,

		/// <summary>Identify device data type.</summary>
		AtaDataTypeIdentify,

		/// <summary>Log page data type.</summary>
		AtaDataTypeLogPage,
	}

	/// <summary>Flags set for this request.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PROTOCOL_COMMAND")]
	[Flags]
	public enum STORAGE_PROTOCOL_COMMAND_FLAG : uint
	{
		/// <summary>This flag indicates the request to target an adapter instead of device.</summary>
		STORAGE_PROTOCOL_COMMAND_FLAG_ADAPTER_REQUEST = 0x80000000
	}

	/// <summary>Describes the type of NVMe protocol-specific data that's to be queried during an IOCTL_STORAGE_QUERY_PROPERTY request.</summary>
	/// <remarks>
	/// <para>
	/// When using IOCTL_STORAGE_QUERY_PROPERTY to retrieve protocol-specific information in the STORAGE_PROTOCOL_DATA_DESCRIPTOR,
	/// configure the STORAGE_PROPERTY_QUERY structure as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Allocate a buffer that can contains both a STORAGE_PROPERTY_QUERY and a STORAGE_PROTOCOL_SPECIFIC_DATA structure.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Set the <c>PropertyID</c> field to <c>StorageAdapterProtocolSpecificProperty</c> or <c>StorageDeviceProtocolSpecificProperty</c>
	/// for a controller or device/namespace request, respectively.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Set the <c>QueryType</c> field to <c>PropertyStandardQuery</c>.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Fill the STORAGE_PROTOCOL_SPECIFIC_DATA structure with the desired values. The start of the <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c>
	/// is the <c>AdditionalParameters</c> field of STORAGE_PROPERTY_QUERY.
	/// </term>
	/// </item>
	/// </list>
	/// <para>To specify a type of NVMe protocol-specific information, configure the STORAGE_PROTOCOL_SPECIFIC_DATA structure as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the <c>ProtocolType</c> field to <c>ProtocolTypeNVMe</c>.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DataType</c> field to an enumeration value defined by <c>STORAGE_PROTOCOL_NVME_DATA_TYPE</c>:</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_protocol_nvme_data_type typedef enum
	// _STORAGE_PROTOCOL_NVME_DATA_TYPE { NVMeDataTypeUnknown, NVMeDataTypeIdentify, NVMeDataTypeLogPage, NVMeDataTypeFeature }
	// STORAGE_PROTOCOL_NVME_DATA_TYPE, *PSTORAGE_PROTOCOL_NVME_DATA_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "BB171CEE-1CB7-44AC-9F39-87394EFAFAEC")]
	public enum STORAGE_PROTOCOL_NVME_DATA_TYPE
	{
		/// <summary>Unknown data type.</summary>
		NVMeDataTypeUnknown,

		/// <summary>
		/// Identify data type. This can be either Identify Controller data or Identify Namespace data. When this type of data is being
		/// queried, the ProtocolDataRequestValue field of STORAGE_PROTOCOL_SPECIFIC_DATA will have a value of
		/// NVME_IDENTIFY_CNS_CONTROLLER for adapter or NVME_IDENTIFY_CNS_SPECIFIC_NAMESPACE for namespace. If the
		/// ProtocolDataRequestValue is NVME_IDENTIFY_CNS_SPECIFIC_NAMESPACE, the ProtocolDataRequestSubValue field from the
		/// STORAGE_PROTOCOL_SPECIFIC_DATA structure will have a value of the namespace ID.
		/// </summary>
		NVMeDataTypeIdentify,

		/// <summary>Log page data type.</summary>
		NVMeDataTypeLogPage,

		/// <summary>Feature data type.</summary>
		NVMeDataTypeFeature,
	}

	/// <summary>The status of the request made to the storage device.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PROTOCOL_COMMAND")]
	[Flags]
	public enum STORAGE_PROTOCOL_STATUS : uint
	{
		/// <summary>The request is pending.</summary>
		STORAGE_PROTOCOL_STATUS_PENDING = 0x0,

		/// <summary>The request has completed successfully.</summary>
		STORAGE_PROTOCOL_STATUS_SUCCESS = 0x1,

		/// <summary>The request has encountered an error.</summary>
		STORAGE_PROTOCOL_STATUS_ERROR = 0x2,

		/// <summary>The request is not valid.</summary>
		STORAGE_PROTOCOL_STATUS_INVALID_REQUEST = 0x3,

		/// <summary>A device is not available to make a request to.</summary>
		STORAGE_PROTOCOL_STATUS_NO_DEVICE = 0x4,

		/// <summary>The device is busy acting on the request.</summary>
		STORAGE_PROTOCOL_STATUS_BUSY = 0x5,

		/// <summary>The device encountered a data overrun while acting on the request.</summary>
		STORAGE_PROTOCOL_STATUS_DATA_OVERRUN = 0x6,

		/// <summary>The device cannot complete the request due to insufficient resources.</summary>
		STORAGE_PROTOCOL_STATUS_INSUFFICIENT_RESOURCES = 0x7,

		/// <summary/>
		STORAGE_PROTOCOL_STATUS_THROTTLED_REQUEST = 0x8,

		/// <summary>The request is not supported.</summary>
		STORAGE_PROTOCOL_STATUS_NOT_SUPPORTED = 0xFF,
	}

	/// <summary>Specifies the protocol of a storage device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_protocol_type typedef enum _STORAGE_PROTOCOL_TYPE
	// { ProtocolTypeUnknown, ProtocolTypeScsi, ProtocolTypeAta, ProtocolTypeNvme, ProtocolTypeSd, ProtocolTypeUfs,
	// ProtocolTypeProprietary, ProtocolTypeMaxReserved } STORAGE_PROTOCOL_TYPE, *PSTORAGE_PROTOCOL_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "8055B633-99EF-4AAE-AA80-FC09F357BEAB")]
	public enum STORAGE_PROTOCOL_TYPE
	{
		/// <summary>Unknown protocol type.</summary>
		ProtocolTypeUnknown,

		/// <summary>SCSI protocol type.</summary>
		ProtocolTypeScsi,

		/// <summary>ATA protocol type.</summary>
		ProtocolTypeAta,

		/// <summary>NVMe protocol type.</summary>
		ProtocolTypeNvme,

		/// <summary>SD protocol type.</summary>
		ProtocolTypeSd,

		/// <summary/>
		ProtocolTypeUfs,

		/// <summary>Vendor-specific protocol type.</summary>
		ProtocolTypeProprietary = 0x7E,

		/// <summary>Reserved.</summary>
		ProtocolTypeMaxReserved = 0x7F,
	}

	/// <summary>
	/// Used by the STORAGE_PROPERTY_QUERY structure passed to the IOCTL_STORAGE_QUERY_PROPERTY control code to indicate what information
	/// is returned about a property of a storage device or adapter.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-storage_query_type typedef enum _STORAGE_QUERY_TYPE {
	// PropertyStandardQuery, PropertyExistsQuery, PropertyMaskQuery, PropertyQueryMaxDefined } STORAGE_QUERY_TYPE, *PSTORAGE_QUERY_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "0bce42d2-9d42-4881-9e33-4b3858a40353")]
	public enum STORAGE_QUERY_TYPE
	{
		/// <summary>Instructs the driver to return an appropriate descriptor.</summary>
		PropertyStandardQuery,

		/// <summary>Instructs the driver to report whether the descriptor is supported.</summary>
		PropertyExistsQuery,

		/// <summary>Not currently supported. Do not use.</summary>
		PropertyMaskQuery,

		/// <summary>Specifies the upper limit of the list of query types. This is used to validate the query type.</summary>
		PropertyQueryMaxDefined,
	}

	/// <summary/>
	[PInvokeData("winioctl.h")]
	public enum STORAGE_RPMB_FRAME_TYPE
	{
		/// <summary/>
		StorageRpmbFrameTypeUnknown = 0,

		/// <summary/>
		StorageRpmbFrameTypeStandard,

		/// <summary/>
		StorageRpmbFrameTypeMax,
	}

	/// <summary>Flags set for this request.</summary>
	[Flags]
	public enum STORAGE_TEMPERATURE_THRESHOLD_FLAG : ushort
	{
		/// <summary>This flag indicates the request to target an adapter instead of device.</summary>
		STORAGE_TEMPERATURE_THRESHOLD_FLAG_ADAPTER_REQUEST = 1
	}

	/// <summary>The current logging mode.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_MODIFY_RM")]
	public enum TXFS_LOGGING_MODE : ushort
	{
		/// <summary>Simple logging is used.</summary>
		TXFS_LOGGING_MODE_SIMPLE = 1,

		/// <summary>Full logging is used</summary>
		TXFS_LOGGING_MODE_FULL = 2,
	}

	/// <summary>The log parameters to be set.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_MODIFY_RM")]
	[Flags]
	public enum TXFS_RM_FLAG : uint
	{
		/// <summary>
		/// If this flag is set, the LoggingMode member of this structure is being used. If the flag is not set, the LoggingMode member
		/// is ignored.
		/// </summary>
		TXFS_RM_FLAG_LOGGING_MODE = 0x00000001,

		/// <summary>If this flag is set, the RM is instructed to rename itself (creating a new GUID).</summary>
		TXFS_RM_FLAG_RENAME_RM = 0x00000002,

		/// <summary>
		/// If this flag is set, the LogContainerCountMax member is being used. If the flag is not set, the LogContainerCountMax member
		/// is ignored. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN.
		/// </summary>
		TXFS_RM_FLAG_LOG_CONTAINER_COUNT_MAX = 0x00000004,

		/// <summary>
		/// If this flag is set, the LogContainerCountMin member is being used. If the flag is not set, the LogContainerCountMin member
		/// is ignored. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX.
		/// </summary>
		TXFS_RM_FLAG_LOG_CONTAINER_COUNT_MIN = 0x00000008,

		/// <summary>
		/// If this flag is set, the LogGrowthIncrement member is being used. If the flag is not set, the LogGrowthIncrement member is
		/// ignored. This flag indicates that the log should grow by the number of containers specified in the LogGrowthIncrement
		/// member. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_PERCENT.
		/// </summary>
		TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_NUM_CONTAINERS = 0x00000010,

		/// <summary>
		/// If this flag is set, the LogGrowthIncrement member is being used. If the flag is not set, the LogGrowthIncrement member is
		/// ignored. This flag indicates that the log should grow by the percentage of the log size specified in the LogGrowthIncrement
		/// member. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_NUM_CONTAINERS.
		/// </summary>
		TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_PERCENT = 0x00000020,

		/// <summary>
		/// If this flag is set, the LogAutoShrinkPercentage member is being used. If the flag is not set, the LogAutoShrinkPercentage
		/// is ignored.
		/// </summary>
		TXFS_RM_FLAG_LOG_AUTO_SHRINK_PERCENTAGE = 0x00000040,

		/// <summary>
		/// If this flag is set, the RM is instructed to allow its log to grow without bounds. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN.
		/// </summary>
		TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX = 0x00000080,

		/// <summary>
		/// If this flag is set, the RM is instructed to allow its log to shrink the log to only two containers. This flag is mutually
		/// exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX.
		/// </summary>
		TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN = 0x00000100,

		/// <summary>
		/// If this flag is set, the log is instructed to immediately increase its size to the size specified in LogContainerCount. If
		/// the flag is not set, the LogContainerCount is ignored.
		/// </summary>
		TXFS_RM_FLAG_GROW_LOG = 0x00000400,

		/// <summary>
		/// If this flag is set, the log is instructed to immediately decrease its size to the size specified in LogContainerCount. If
		/// this flag and TXFS_RM_FLAG_ENFORCE_MINIMUM_SIZE are set, the log is instructed to shrink to its minimum allowable size, and
		/// LogContainerCount is ignored.
		/// </summary>
		TXFS_RM_FLAG_SHRINK_LOG = 0x00000800,

		/// <summary>
		/// If this flag and TXFS_RM_FLAG_SHRINK_LOG are set, the log is instructed to shrink to its minimum allowable size, and
		/// LogContainerCount is ignored. If this flag is set, the TXFS_RM_FLAG_SHRINK_LOG must be set.
		/// </summary>
		TXFS_RM_FLAG_ENFORCE_MINIMUM_SIZE = 0x00001000,

		/// <summary>
		/// If this flag is set, the log is instructed to preserve the changes on disk. If this flag is not set, any changes made are
		/// temporary (that is, until the RM is shut down and restarted).
		/// </summary>
		TXFS_RM_FLAG_PRESERVE_CHANGES = 0x00002000,

		/// <summary>
		/// This flag is only valid for default RMs, not secondary RMs. If this flag is set, the RM is instructed to reset itself the
		/// next time it is started. The log and the associated metadata are deleted.
		/// </summary>
		TXFS_RM_FLAG_RESET_RM_AT_NEXT_START = 0x00004000,

		/// <summary>
		/// This flag is only valid for default RMs, not secondary RMs. If this flag is set, a previous call to FSCTL_TXFS_MODIFY_RM is
		/// canceled with the TXFS_RM_FLAG_RESET_RM_AT_NEXT_START flag set.
		/// </summary>
		TXFS_RM_FLAG_DO_NOT_RESET_RM_AT_NEXT_START = 0x00008000,

		/// <summary>
		/// Indicates that the RM is to prefer transaction consistency over system availability. This flag is mutually exclusive with
		/// TXFS_RM_FLAG_PREFER_AVAILABILITY and is not supported by the default RM on the system volume.
		/// </summary>
		TXFS_RM_FLAG_PREFER_CONSISTENCY = 0x00010000,

		/// <summary>
		/// Indicates that the RM is to prefer system availability over transaction consistency. This flag is mutually exclusive with
		/// TXFS_RM_FLAG_PREFER_CONSISTENCY and is forced by the default RM on the system volume.
		/// </summary>
		TXFS_RM_FLAG_PREFER_AVAILABILITY = 0x00020000,
	}

	/// <summary>The state of the RM.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_QUERY_RM_INFORMATION")]
	public enum TXFS_RM_STATE
	{
		/// <summary>The RM is not yet started.</summary>
		TXFS_RM_STATE_NOT_STARTED = 0,

		/// <summary>The RM is starting.</summary>
		TXFS_RM_STATE_STARTING = 1,

		/// <summary>The RM is active and ready to accept transactions.</summary>
		TXFS_RM_STATE_ACTIVE = 2,

		/// <summary>The RM is shutting down.</summary>
		TXFS_RM_STATE_SHUTTING_DOWN = 3,
	}

	/// <summary>Indicates the state of the transaction that has locked the file.</summary>
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_GET_METADATA_INFO_OUT")]
	public enum TXFS_TRANSACTION_STATE
	{
		/// <summary/>
		TXFS_TRANSACTION_STATE_NONE = 0x00,

		/// <summary/>
		TXFS_TRANSACTION_STATE_ACTIVE = 0x01,

		/// <summary/>
		TXFS_TRANSACTION_STATE_PREPARED = 0x02,

		/// <summary/>
		TXFS_TRANSACTION_STATE_NOTACTIVE = 0x03,
	}
	/// <summary>
	/// <para>
	/// The flags that identify reasons for changes that have accumulated in this file or directory journal record since the file or
	/// directory opened.
	/// </para>
	/// <para>
	/// When a file or directory closes, then a final USN record is generated with the <c>USN_REASON_CLOSE</c> flag set. The next change
	/// (for example, after the next open operation or deletion) starts a new record with a new set of reason flags.
	/// </para>
	/// <para>
	/// A rename or move operation generates two USN records, one that records the old parent directory for the item, and one that
	/// records a new parent.
	/// </para>
	/// </summary>
	[PInvokeData("winioctl.h", MSDNShortId = "1747453d-fd18-4853-a953-47131f3067ae")]
	[Flags]
	public enum USN_REASON : uint
	{
		/// <summary>
		/// A user has either changed one or more file or directory attributes (for example, the read-only, hidden, system, archive, or
		/// sparse attribute), or one or more time stamps.
		/// </summary>
		USN_REASON_BASIC_INFO_CHANGE = 0x00008000,

		/// <summary>The file or directory is closed.</summary>
		USN_REASON_CLOSE = 0x80000000,

		/// <summary>The compression state of the file or directory is changed from or to compressed.</summary>
		USN_REASON_COMPRESSION_CHANGE = 0x00020000,

		/// <summary>The file or directory is extended (added to).</summary>
		USN_REASON_DATA_EXTEND = 0x00000002,

		/// <summary>The data in the file or directory is overwritten.</summary>
		USN_REASON_DATA_OVERWRITE = 0x00000001,

		/// <summary>The file or directory is truncated.</summary>
		USN_REASON_DATA_TRUNCATION = 0x00000004,

		/// <summary>
		/// The user made a change to the extended attributes of a file or directory.
		/// <para>These NTFS file system attributes are not accessible to Windows-based applications.</para>
		/// </summary>
		USN_REASON_EA_CHANGE = 0x00000400,

		/// <summary>The file or directory is encrypted or decrypted.</summary>
		USN_REASON_ENCRYPTION_CHANGE = 0x00040000,

		/// <summary>The file or directory is created for the first time.</summary>
		USN_REASON_FILE_CREATE = 0x00000100,

		/// <summary>The file or directory is deleted.</summary>
		USN_REASON_FILE_DELETE = 0x00000200,

		/// <summary>
		/// An NTFS file system hard link is added to or removed from the file or directory.
		/// <para>
		/// An NTFS file system hard link, similar to a POSIX hard link, is one of several directory entries that see the same file or directory.
		/// </para>
		/// </summary>
		USN_REASON_HARD_LINK_CHANGE = 0x00010000,

		/// <summary>
		/// A user changes the FILE_ATTRIBUTE_NOT_CONTENT_INDEXED attribute.
		/// <para>
		/// That is, the user changes the file or directory from one where content can be indexed to one where content cannot be indexed,
		/// or vice versa. Content indexing permits rapid searching of data by building a database of selected content.
		/// </para>
		/// </summary>
		USN_REASON_INDEXABLE_CHANGE = 0x00004000,

		/// <summary>
		/// A user changed the state of the FILE_ATTRIBUTE_INTEGRITY_STREAM attribute for the given stream.
		/// <para>
		/// On the ReFS file system, integrity streams maintain a checksum of all data for that stream, so that the contents of the file
		/// can be validated during read or write operations.
		/// </para>
		/// </summary>
		USN_REASON_INTEGRITY_CHANGE = 0x00800000,

		/// <summary>The one or more named data streams for a file are extended (added to).</summary>
		USN_REASON_NAMED_DATA_EXTEND = 0x00000020,

		/// <summary>The data in one or more named data streams for a file is overwritten.</summary>
		USN_REASON_NAMED_DATA_OVERWRITE = 0x00000010,

		/// <summary>The one or more named data streams for a file is truncated.</summary>
		USN_REASON_NAMED_DATA_TRUNCATION = 0x00000040,

		/// <summary>The object identifier of a file or directory is changed.</summary>
		USN_REASON_OBJECT_ID_CHANGE = 0x00080000,

		/// <summary>A file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the new name.</summary>
		USN_REASON_RENAME_NEW_NAME = 0x00002000,

		/// <summary>The file or directory is renamed, and the file name in the USN_RECORD_V2 structure is the previous name.</summary>
		USN_REASON_RENAME_OLD_NAME = 0x00001000,

		/// <summary>
		/// The reparse point that is contained in a file or directory is changed, or a reparse point is added to or deleted from a file
		/// or directory.
		/// </summary>
		USN_REASON_REPARSE_POINT_CHANGE = 0x00100000,

		/// <summary>A change is made in the access rights to a file or directory.</summary>
		USN_REASON_SECURITY_CHANGE = 0x00000800,

		/// <summary>A named stream is added to or removed from a file, or a named stream is renamed.</summary>
		USN_REASON_STREAM_CHANGE = 0x00200000,

		/// <summary>The given stream is modified through a TxF transaction.</summary>
		USN_REASON_TRANSACTED_CHANGE = 0x00400000,
	}

	/// <summary>
	/// <para>Additional information about the source of the change, set by the FSCTL_MARK_HANDLE of the DeviceIoControl operation.</para>
	/// <para>
	/// When a thread writes a new USN record, the source information flags in the prior record continues to be present only if the
	/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that are
	/// set only by a known source, for example, an antivirus filter.
	/// </para>
	/// </summary>
	[PInvokeData("winioctl.h", MSDNShortId = "1747453d-fd18-4853-a953-47131f3067ae")]
	[Flags]
	public enum USN_SOURCE
	{
		/// <summary>
		/// The operation adds a private data stream to a file or directory.
		/// <para>
		/// An example might be a virus detector adding checksum information. As the virus detector modifies the item, the system
		/// generates USN records. USN_SOURCE_AUXILIARY_DATA indicates that the modifications did not change the application data.
		/// </para>
		/// </summary>
		USN_SOURCE_AUXILIARY_DATA = 0x00000002,

		/// <summary>
		/// The operation provides information about a change to the file or directory made by the operating system.
		/// <para>
		/// A typical use is when the Remote Storage system moves data from external to local storage. Remote Storage is the hierarchical
		/// storage management software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record.
		/// However, the data has not changed from the user's point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo
		/// member, you can determine that although a write operation is performed on the item, data has not changed.
		/// </para>
		/// </summary>
		USN_SOURCE_DATA_MANAGEMENT = 0x00000001,

		/// <summary>
		/// The operation is modifying a file to match the contents of the same file which exists in another member of the replica set.
		/// </summary>
		USN_SOURCE_REPLICATION_MANAGEMENT = 0x00000004,

		/// <summary>
		/// The operation is modifying a file on client systems to match the contents of the same file that exists in the cloud.
		/// </summary>
		USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT = 0x00000008,
	}
	/// <summary>Indicates whether the write cache features of a device are changeable.</summary>
	/// <remarks>
	/// The IOCTL_STORAGE_QUERY_PROPERTY request returns a <c>WRITE_CACHE_CHANGE</c> value in the STORAGE_WRITE_CACHE_PROPERTY structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-write_cache_change typedef enum _WRITE_CACHE_CHANGE {
	// WriteCacheChangeUnknown, WriteCacheNotChangeable, WriteCacheChangeable } WRITE_CACHE_CHANGE;
	[PInvokeData("winioctl.h", MSDNShortId = "a6974092-fa4f-4524-96ec-b4fad0b8c5ea")]
	public enum WRITE_CACHE_CHANGE
	{
		/// <summary>The system cannot report the write cache change capability of the device.</summary>
		WriteCacheChangeUnknown,

		/// <summary>Host software cannot change the characteristics of the device's write cache.</summary>
		WriteCacheNotChangeable,

		/// <summary>Host software can change the characteristics of the device's write cache.</summary>
		WriteCacheChangeable,
	}

	/// <summary>Indicates whether the write cache is enabled or disabled.</summary>
	/// <remarks>
	/// The IOCTL_STORAGE_QUERY_PROPERTY control code reports a <c>WRITE_CACHE_ENABLE</c> value in the STORAGE_WRITE_CACHE_PROPERTY structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-write_cache_enable typedef enum _WRITE_CACHE_ENABLE {
	// WriteCacheEnableUnknown, WriteCacheDisabled, WriteCacheEnabled } WRITE_CACHE_ENABLE;
	[PInvokeData("winioctl.h", MSDNShortId = "3ed8bc79-d8f9-4a57-a37c-46202d639a63")]
	public enum WRITE_CACHE_ENABLE
	{
		/// <summary>The system cannot report whether the device's write cache is enabled or disabled.</summary>
		WriteCacheEnableUnknown,

		/// <summary>The device's write cache is disabled.</summary>
		WriteCacheDisabled,

		/// <summary>The device's write cache is enabled.</summary>
		WriteCacheEnabled,
	}

	/// <summary>Specifies the cache type.</summary>
	/// <remarks>
	/// <para>
	/// There are two main types of write cache: write back and write through. With a write-back cache, the device does not copy cache
	/// data to nonvolatile media until absolutely necessary. This type of operation improves the performance of write operations. With a
	/// write-through cache, the device writes data to the cache and the media in parallel. This type of operation does not improve write
	/// performance, but it makes subsequent read operations faster.
	/// </para>
	/// <para>
	/// The IOCTL_STORAGE_QUERY_PROPERTY control code reports a <c>WRITE_CACHE_TYPE</c> value in the STORAGE_WRITE_CACHE_PROPERTY structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-write_cache_type typedef enum _WRITE_CACHE_TYPE {
	// WriteCacheTypeUnknown, WriteCacheTypeNone, WriteCacheTypeWriteBack, WriteCacheTypeWriteThrough } WRITE_CACHE_TYPE;
	[PInvokeData("winioctl.h", MSDNShortId = "fb861a65-5207-4af3-b994-0883febcbb0a")]
	public enum WRITE_CACHE_TYPE
	{
		/// <summary>The system cannot report the type of the write cache.</summary>
		WriteCacheTypeUnknown,

		/// <summary>The device does not have a write cache.</summary>
		WriteCacheTypeNone,

		/// <summary>The device has a write-back cache.</summary>
		WriteCacheTypeWriteBack,

		/// <summary>The device has a write-through cache.</summary>
		WriteCacheTypeWriteThrough,
	}

	/// <summary>Specifies whether a storage device supports write-through caching.</summary>
	/// <remarks>The IOCTL_STORAGE_QUERY_PROPERTY control code reports this value in the STORAGE_WRITE_CACHE_PROPERTY structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ne-winioctl-write_through typedef enum _WRITE_THROUGH {
	// WriteThroughUnknown, WriteThroughNotSupported, WriteThroughSupported } WRITE_THROUGH;
	[PInvokeData("winioctl.h", MSDNShortId = "8bb26be1-ad02-4cf0-8505-021f922f34bf")]
	public enum WRITE_THROUGH
	{
		/// <summary>Indicates that no information is available about the write-through capabilities of the device.</summary>
		WriteThroughUnknown,

		/// <summary>Indicates that the device does not support write-through caching.</summary>
		WriteThroughNotSupported,

		/// <summary>Indicates that the device supports write-through caching.</summary>
		WriteThroughSupported,
	}
}