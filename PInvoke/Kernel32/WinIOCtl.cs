using System;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
		/// <summary>Device types defined by the system.</summary>
		[PInvokeData("WinIOCtl.h")]
		public enum DEVICE_TYPE : ushort
		{
			FILE_DEVICE_BEEP = 0x00000001,
			FILE_DEVICE_CD_ROM = 0x00000002,
			FILE_DEVICE_CD_ROM_FILE_SYSTEM = 0x00000003,
			FILE_DEVICE_CONTROLLER = 0x00000004,
			FILE_DEVICE_DATALINK = 0x00000005,
			FILE_DEVICE_DFS = 0x00000006,
			FILE_DEVICE_DISK = 0x00000007,
			FILE_DEVICE_DISK_FILE_SYSTEM = 0x00000008,
			FILE_DEVICE_FILE_SYSTEM = 0x00000009,
			FILE_DEVICE_INPORT_PORT = 0x0000000a,
			FILE_DEVICE_KEYBOARD = 0x0000000b,
			FILE_DEVICE_MAILSLOT = 0x0000000c,
			FILE_DEVICE_MIDI_IN = 0x0000000d,
			FILE_DEVICE_MIDI_OUT = 0x0000000e,
			FILE_DEVICE_MOUSE = 0x0000000f,
			FILE_DEVICE_MULTI_UNC_PROVIDER = 0x00000010,
			FILE_DEVICE_NAMED_PIPE = 0x00000011,
			FILE_DEVICE_NETWORK = 0x00000012,
			FILE_DEVICE_NETWORK_BROWSER = 0x00000013,
			FILE_DEVICE_NETWORK_FILE_SYSTEM = 0x00000014,
			FILE_DEVICE_NULL = 0x00000015,
			FILE_DEVICE_PARALLEL_PORT = 0x00000016,
			FILE_DEVICE_PHYSICAL_NETCARD = 0x00000017,
			FILE_DEVICE_PRINTER = 0x00000018,
			FILE_DEVICE_SCANNER = 0x00000019,
			FILE_DEVICE_SERIAL_MOUSE_PORT = 0x0000001a,
			FILE_DEVICE_SERIAL_PORT = 0x0000001b,
			FILE_DEVICE_SCREEN = 0x0000001c,
			FILE_DEVICE_SOUND = 0x0000001d,
			FILE_DEVICE_STREAMS = 0x0000001e,
			FILE_DEVICE_TAPE = 0x0000001f,
			FILE_DEVICE_TAPE_FILE_SYSTEM = 0x00000020,
			FILE_DEVICE_TRANSPORT = 0x00000021,
			FILE_DEVICE_UNKNOWN = 0x00000022,
			FILE_DEVICE_VIDEO = 0x00000023,
			FILE_DEVICE_VIRTUAL_DISK = 0x00000024,
			FILE_DEVICE_WAVE_IN = 0x00000025,
			FILE_DEVICE_WAVE_OUT = 0x00000026,
			FILE_DEVICE_8042_PORT = 0x00000027,
			FILE_DEVICE_NETWORK_REDIRECTOR = 0x00000028,
			FILE_DEVICE_BATTERY = 0x00000029,
			FILE_DEVICE_BUS_EXTENDER = 0x0000002a,
			FILE_DEVICE_MODEM = 0x0000002b,
			FILE_DEVICE_VDM = 0x0000002c,
			FILE_DEVICE_MASS_STORAGE = 0x0000002d,
			FILE_DEVICE_SMB = 0x0000002e,
			FILE_DEVICE_KS = 0x0000002f,
			FILE_DEVICE_CHANGER = 0x00000030,
			FILE_DEVICE_SMARTCARD = 0x00000031,
			FILE_DEVICE_ACPI = 0x00000032,
			FILE_DEVICE_DVD = 0x00000033,
			FILE_DEVICE_FULLSCREEN_VIDEO = 0x00000034,
			FILE_DEVICE_DFS_FILE_SYSTEM = 0x00000035,
			FILE_DEVICE_DFS_VOLUME = 0x00000036,
			FILE_DEVICE_SERENUM = 0x00000037,
			FILE_DEVICE_TERMSRV = 0x00000038,
			FILE_DEVICE_KSEC = 0x00000039,
			FILE_DEVICE_FIPS = 0x0000003A,
			FILE_DEVICE_INFINIBAND = 0x0000003B,
			FILE_DEVICE_AVIO = 0x0000003C,
			FILE_DEVICE_VMBUS = 0x0000003E,
			FILE_DEVICE_CRYPT_PROVIDER = 0x0000003F,
			FILE_DEVICE_WPD = 0x00000040,
			FILE_DEVICE_BLUETOOTH = 0x00000041,
			FILE_DEVICE_MT_COMPOSITE = 0x00000042,
			FILE_DEVICE_MT_TRANSPORT = 0x00000043,
			FILE_DEVICE_BIOMETRIC = 0x00000044,
			FILE_DEVICE_PMI = 0x00000045,
			FILE_DEVICE_EHSTOR = 0x00000046,
			FILE_DEVICE_DEVAPI = 0x00000047,
			FILE_DEVICE_GPIO = 0x00000048,
			FILE_DEVICE_USBEX = 0x00000049,
			FILE_DEVICE_CONSOLE = 0x00000050,
			FILE_DEVICE_NFP = 0x00000051,
			FILE_DEVICE_SYSENV = 0x00000052,
			FILE_DEVICE_VIRTUAL_BLOCK = 0x00000053,
			FILE_DEVICE_POINT_OF_SERVICE = 0x00000054,
			FILE_DEVICE_STORAGE_REPLICATION = 0x00000055,
			FILE_DEVICE_TRUST_ENV = 0x00000056,
			FILE_DEVICE_UCM = 0x00000057,
			FILE_DEVICE_UCMTCPCI = 0x00000058,
			FILE_DEVICE_PERSISTENT_MEMORY = 0x00000059,
			FILE_DEVICE_NVDIMM = 0x0000005a,
			FILE_DEVICE_HOLOGRAPHIC = 0x0000005b,
			FILE_DEVICE_SDFXHCI = 0x0000005c,
			FILE_DEVICE_UCMUCSI = 0x0000005d,
			IOCTL_STORAGE_BASE = FILE_DEVICE_MASS_STORAGE,
			IOCTL_CHANGER_BASE = FILE_DEVICE_CHANGER,
			IOCTL_VOLUME_BASE = 0x00000056,
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
			METHOD_BUFFERED = 0,
			METHOD_IN_DIRECT = 1,
			METHOD_OUT_DIRECT = 2,
			METHOD_NEITHER = 3,
		}

		/// <summary>Represents IO control codes.</summary>
		[PInvokeData("WinIOCtl.h")]
		public static class IOControlCode
		{
			private const ushort IOCTL_SCM_LOGICAL_DEVICE_FUNCTION_BASE = 0x300;
			private const ushort IOCTL_SCM_PHYSICAL_DEVICE_FUNCTION_BASE = 0x600;
			private const ushort IOCTL_SCMBUS_DEVICE_FUNCTION_BASE = 0x0;
			public static uint FSCTL_ADD_OVERLAY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 204, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_ADVANCE_FILE_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 177, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_ALLOW_EXTENDED_DASD_IO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 32, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CLEAN_VOLUME_METADATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 223, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CORRUPTION_HANDLING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 152, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CREATE_OR_GET_OBJECT_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 48, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>
			/// Creates an update sequence number (USN) change journal stream on a target volume, or modifies an existing change journal stream.
			/// </para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>For the implications of overlapped I/O on this operation, see the Remarks section of the DeviceIoControl topic.</para>
			/// <para>
			/// You can use <c>FSCTL_CREATE_USN_JOURNAL</c> to create a new change journal stream for a volume. After the creation of the
			/// stream, the NTFS file system maintains a change journal for that volume.
			/// </para>
			/// <para>
			/// You can also use <c>FSCTL_CREATE_USN_JOURNAL</c> to modify an existing change journal stream. If a change journal stream
			/// already exists, <c>FSCTL_CREATE_USN_JOURNAL</c> sets it to the characteristics provided in the CREATE_USN_JOURNAL_DATA
			/// structure. The change journal stream eventually gets larger or is trimmed to the new size limit that CREATE_USN_JOURNAL_DATA imposes.
			/// </para>
			/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
			/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
			/// <para>\.&lt;i&gt;X:</para>
			/// <para>
			/// In the preceding string, X is the letter identifying the drive on which the volume appears. The volume must be NTFS 3.0 or
			/// later. To obtain the NTFS version of a volume, open a command prompt with Administrator access rights and execute the
			/// following command:
			/// </para>
			/// <para><c>fsutil fsinfo ntfsinfo</c> X <c>:</c></para>
			/// <para>where X is the drive letter of the volume.</para>
			/// <para>In Windows Server 2012, this function is supported by the following technologies.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Technology</term>
			/// <term>Supported</term>
			/// </listheader>
			/// <item>
			/// <term>Server Message Block (SMB) 3.0 protocol</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 Transparent Failover (TFO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Cluster Shared Volume File System (CsvFS)</term>
			/// <term>Yes</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_create_usn_journal?redirectedfrom=MSDN
			[PInvokeData("winioctl.h", MSDNShortId = "92e737e6-dba6-47f1-a077-e303039e12eb")]
			[CorrespondingType(typeof(CREATE_USN_JOURNAL_DATA), CorrespondingAction.Get)]
			public static uint FSCTL_CREATE_USN_JOURNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 57, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_CSC_INTERNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 107, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_CONTROL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 181, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_GET_VOLUME_NAME_FOR_VOLUME_MOUNT_POINT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 149, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_GET_VOLUME_PATH_NAME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 148, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_GET_VOLUME_PATH_NAMES_FOR_VOLUME_NAME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 150, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_H_BREAKING_SYNC_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 185, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_INTERNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 155, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_MGMT_LOCK => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 175, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_QUERY_DOWN_LEVEL_FILE_SYSTEM_CHARACTERISTICS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 176, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_QUERY_VETO_FILE_DIRECT_IO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 179, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_SYNC_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 178, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_CSV_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 145, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_DELETE_CORRUPTED_REFS_CONTAINER => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 253, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_DELETE_EXTERNAL_BACKING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 197, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_DELETE_OBJECT_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 40, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_DELETE_REPARSE_POINT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 43, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Deletes the update sequence number (USN) change journal on a volume, or waits for notification of change journal deletion.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>For the implications of overlapped I/O on this operation, see the Remarks section of the DeviceIoControl topic.</para>
			/// <para>
			/// You can use <c>FSCTL_DELETE_USN_JOURNAL</c> to delete a change journal. The NTFS file system starts a deletion operation and
			/// returns immediately to the calling process, unless the <c>USN_DELETE_FLAG_NOTIFY</c> flag is set in the <c>DeleteFlags</c>
			/// member of DELETE_USN_JOURNAL_DATA.
			/// </para>
			/// <para>
			/// If the <c>USN_DELETE_FLAG_NOTIFY</c> and <c>USN_DELETE_FLAG_DELETE</c> flags are both set, a call to
			/// <c>FSCTL_DELETE_USN_JOURNAL</c> begins the deletion process. Then the call either blocks the calling thread and waits for the
			/// deletion (on a synchronous or non-overlapped call), or sets up event notification by using an I/O completion port or other
			/// mechanism, and returns (on an asynchronous or overlapped call).
			/// </para>
			/// <para>
			/// You can also use <c>FSCTL_DELETE_USN_JOURNAL</c> to receive notification that a change journal deletion is complete, by
			/// setting only <c>USN_DELETE_FLAG_NOTIFY</c>. If you do so, the <c>FSCTL_DELETE_USN_JOURNAL</c> operation either waits until
			/// the deletion completes before returning (on a synchronous or non-overlapped call), or sets up event notification by using an
			/// I/O completion port or other mechanism (on an asynchronous or overlapped call).
			/// </para>
			/// <para>
			/// The deletion on which an application receives notification may have been initiated by the current process, or some other
			/// process. For example, when an application is started, it can use <c>FSCTL_DELETE_USN_JOURNAL</c> to determine if a deletion
			/// started by some other process is in progress and if it is, exit.
			/// </para>
			/// <para>
			/// Complete deletion of a change journal requires a scan of the volume where the change journal resides, which may take a long
			/// time on a volume with many files. The operation continues to completion even across system restarts. Attempts to create,
			/// modify, delete, or query the change journal while deletion is in progress fail and return the error code <c>ERROR_JOURNAL_DELETE_IN_PROGRESS</c>.
			/// </para>
			/// <para>
			/// The <c>FSCTL_DELETE_USN_JOURNAL</c> operation has a significant performance cost, so it should be used sparingly. An
			/// administrator should delete a journal when the current USN value approaches that of the maximum possible USN value.
			/// </para>
			/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
			/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
			/// <para>\.&lt;i&gt;X:</para>
			/// <para>In the preceding string, X is the letter identifying the drive on which the volume appears. The volume must be NTFS.</para>
			/// <para>In Windows 8 and Windows Server 2012, this code is supported by the following technologies.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Technology</term>
			/// <term>Supported</term>
			/// </listheader>
			/// <item>
			/// <term>Server Message Block (SMB) 3.0 protocol</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 Transparent Failover (TFO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Cluster Shared Volume File System (CsvFS)</term>
			/// <term>Yes</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_delete_usn_journal
			[PInvokeData("winioctl.h", MSDNShortId = "6c85464d-019b-4923-9acf-152b4ee8c31b")]
			[CorrespondingType(typeof(DELETE_USN_JOURNAL_DATA), CorrespondingAction.Get)]
			public static uint FSCTL_DELETE_USN_JOURNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 62, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_DFSR_SET_GHOST_HANDLE_STATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 110, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_DISABLE_LOCAL_BUFFERING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 174, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_DISMOUNT_VOLUME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 8, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_DUPLICATE_EXTENTS_TO_FILE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 209, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_DUPLICATE_EXTENTS_TO_FILE_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 250, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_ENABLE_PER_IO_FLAGS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 267, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_ENABLE_UPGRADE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 52, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_ENCRYPTION_FSCTL_IO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 54, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_ENCRYPTION_KEY_CONTROL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 257, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_ENUM_EXTERNAL_BACKING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 198, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_ENUM_OVERLAY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 199, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>
			/// Enumerates the update sequence number (USN) data between two specified boundaries to obtain master file table (MFT) records.
			/// </para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>For the implications of overlapped I/O on this operation, see the Remarks section of the DeviceIoControl topic.</para>
			/// <para>
			/// To enumerate files on a volume, use the <c>FSCTL_ENUM_USN_DATA</c> operation one or more times. On the first call, set the
			/// starting point, the <c>StartFileReferenceNumber</c> member of the MFT_ENUM_DATA structure, to . Each call to
			/// <c>FSCTL_ENUM_USN_DATA</c> retrieves the starting point for the subsequent call as the first entry in the output buffer.
			/// </para>
			/// <para>By comparing To identify recent changes to a volume, use the FSCTL_READ_USN_JOURNAL control code.</para>
			/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
			/// <para>\.&lt;i&gt;X:</para>
			/// <para>In the preceding string, X is the letter identifying the drive on which the volume appears. The volume must be NTFS.</para>
			/// <para>In Windows 8 and Windows Server 2012, this code is supported by the following technologies.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Technology</term>
			/// <term>Supported</term>
			/// </listheader>
			/// <item>
			/// <term>Server Message Block (SMB) 3.0 protocol</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 Transparent Failover (TFO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Cluster Shared Volume File System (CsvFS)</term>
			/// <term>Yes</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_enum_usn_data
			[PInvokeData("winioctl.h", MSDNShortId = "44d20401-a2ed-4756-9fda-878a24eab7c3")]
			[CorrespondingType(typeof(MFT_ENUM_DATA_V0), CorrespondingAction.Get)]
			[CorrespondingType(typeof(MFT_ENUM_DATA_V1), CorrespondingAction.Get)]
			public static uint FSCTL_ENUM_USN_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 44, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_EXTEND_VOLUME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 60, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_FILE_LEVEL_TRIM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 130, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_FILE_PREFETCH => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 72, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_FILE_TYPE_NOTIFICATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 129, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_FILESYSTEM_GET_STATISTICS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 24, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_FILESYSTEM_GET_STATISTICS_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 227, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_FIND_FILES_BY_SID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 35, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Retrieves the locations of boot sectors for a volume.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>In Windows 8 and Windows Server 2012, this code is supported by the following technologies.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Technology</term>
			/// <term>Supported</term>
			/// </listheader>
			/// <item>
			/// <term>Server Message Block (SMB) 3.0 protocol</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 Transparent Failover (TFO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Cluster Shared Volume File System (CsvFS)</term>
			/// <term>Yes</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_get_boot_area_info
			[PInvokeData("winioctl.h", MSDNShortId = "5739354b-5342-4be9-ac50-bb983d51587c")]
			[CorrespondingType(typeof(BOOT_AREA_INFO), CorrespondingAction.Get)]
			public static uint FSCTL_GET_BOOT_AREA_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 140, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_GET_COMPRESSION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 15, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_EXTERNAL_BACKING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 196, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_INTEGRITY_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 159, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_NTFS_FILE_RECORD => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 26, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_NTFS_VOLUME_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 25, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_OBJECT_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 39, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_REFS_VOLUME_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 182, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_REPAIR => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 103, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_REPARSE_POINT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 42, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_RETRIEVAL_POINTER_BASE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 141, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_RETRIEVAL_POINTER_COUNT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 266, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_RETRIEVAL_POINTERS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 28, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_RETRIEVAL_POINTERS_AND_REFCOUNT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 244, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_VOLUME_BITMAP => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 27, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GET_WOF_VERSION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 218, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_GHOST_FILE_EXTENTS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 235, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_HCS_ASYNC_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 220, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_HCS_SYNC_NO_WRITE_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 238, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_HCS_SYNC_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 219, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_INITIATE_FILE_METADATA_OPTIMIZATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 215, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_INITIATE_REPAIR => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 106, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_INVALIDATE_VOLUMES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 21, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_IS_CSV_FILE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 146, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_IS_FILE_ON_CSV_VOLUME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 151, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_IS_PATHNAME_VALID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 11, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_IS_VOLUME_DIRTY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 30, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_IS_VOLUME_MOUNTED => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 10, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_IS_VOLUME_OWNED_BYCSVFS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 158, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_LOCK_VOLUME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 6, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_LOOKUP_STREAM_FROM_CLUSTER => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 127, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_MAKE_MEDIA_COMPATIBLE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 76, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_MARK_HANDLE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 63, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_MARK_VOLUME_DIRTY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 12, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_MOVE_FILE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 29, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_NOTIFY_DATA_CHANGE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 255, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_NOTIFY_STORAGE_SPACE_ALLOCATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 231, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_OFFLOAD_READ => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 153, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_OFFLOAD_WRITE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 154, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_OPBATCH_ACK_CLOSE_PENDING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 4, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_OPLOCK_BREAK_ACK_NO_2 => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 20, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_OPLOCK_BREAK_ACKNOWLEDGE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 3, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_OPLOCK_BREAK_NOTIFY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 5, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_ALLOCATED_RANGES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 51, IOMethod.METHOD_NEITHER, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_QUERY_BAD_RANGES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 251, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_DEPENDENT_VOLUME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 124, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_DIRECT_ACCESS_EXTENTS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 230, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_DIRECT_IMAGE_ORIGINAL_BASE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 233, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_EXTENT_READ_CACHE_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 221, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_FAT_BPB => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 22, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_FILE_LAYOUT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 157, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_FILE_METADATA_OPTIMIZATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 216, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_FILE_REGIONS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 161, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_FILE_SYSTEM_RECOGNITION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 147, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_GHOSTED_FILE_EXTENTS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 236, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_ON_DISK_VOLUME_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 79, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_PAGEFILE_ENCRYPTION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 122, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_PERSISTENT_VOLUME_STATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 143, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_REFS_SMR_VOLUME_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 247, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_REFS_VOLUME_COUNTER_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 222, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_REGION_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 188, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_RETRIEVAL_POINTERS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 14, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_SHARED_VIRTUAL_DISK_SUPPORT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 192, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_SPARING_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 78, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_STORAGE_CLASSES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 187, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Queries for information on the current update sequence number (USN) change journal, its records, and its capacity.</para>
			/// <para>To perform this operation, call the DeviceIoControl function using the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>For the implications of overlapped I/O on this operation, see the Remarks section of the DeviceIoControl topic.</para>
			/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
			/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
			/// <para>\.&lt;i&gt;X:</para>
			/// <para>
			/// In the preceding string, X is the letter identifying the drive on which the volume appears. The volume must be formatted with
			/// the NTFS filesystem.
			/// </para>
			/// <para>In Windows 8 and Windows Server 2012, this code is supported by the following technologies.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Technology</term>
			/// <term>Supported</term>
			/// </listheader>
			/// <item>
			/// <term>Server Message Block (SMB) 3.0 protocol</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 Transparent Failover (TFO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Cluster Shared Volume File System (CsvFS)</term>
			/// <term>Yes</term>
			/// </item>
			/// </list>
			/// <para>An application may experience false positives on CsvFs pause/resume.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_query_usn_journal
			[PInvokeData("winioctl.h", MSDNShortId = "9491b054-934a-4b76-bf77-f397b6386f82")]
			[CorrespondingType(typeof(USN_JOURNAL_DATA_V0), CorrespondingAction.Get)]
			[CorrespondingType(typeof(USN_JOURNAL_DATA_V1), CorrespondingAction.Get)]
			[CorrespondingType(typeof(USN_JOURNAL_DATA_V2), CorrespondingAction.Get)]
			[CorrespondingType(typeof(READ_USN_JOURNAL_DATA_V0), CorrespondingAction.Get)]
			[CorrespondingType(typeof(READ_USN_JOURNAL_DATA_V1), CorrespondingAction.Get)]
			public static uint FSCTL_QUERY_USN_JOURNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 61, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_QUERY_VOLUME_CONTAINER_STATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 228, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_QUERY_VOLUME_NUMA_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 245, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Retrieves the update sequence number (USN) change-journal information for the specified file or directory.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// If the call succeeds, the members of the returned USN_RECORD_V2 or USN_RECORD_V3 structure are valid except for the following
			/// members: <c>TimeStamp</c>, <c>Reason</c>, and <c>SourceInfo</c>. The <c>Usn</c> member represents the last USN written to the
			/// journal for this file or directory.
			/// </para>
			/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
			/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
			/// <para>\.&lt;i&gt;X:</para>
			/// <para>
			/// In the preceding string, X is the letter identifying the drive on which the volume appears. The volume must be ReFS or NTFS
			/// 3.0 or later. To obtain the NTFS version of a volume, open a command prompt with Administrator access rights and execute the
			/// following command:
			/// </para>
			/// <para><c>FSUtil.exe FSInfo NTFSInfo</c> X <c>:</c></para>
			/// <para>where X is the drive letter of the volume.</para>
			/// <para>In Windows 8 and Windows Server 2012, this code is supported by the following technologies.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Technology</term>
			/// <term>Supported</term>
			/// </listheader>
			/// <item>
			/// <term>Server Message Block (SMB) 3.0 protocol</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 Transparent Failover (TFO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Cluster Shared Volume File System (CsvFS)</term>
			/// <term>Yes</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_read_file_usn_data?redirectedfrom=MSDN
			[PInvokeData("winioctl.h", MSDNShortId = "22c797c8-87c8-4d45-b163-4573e6ed17e1")]
			[CorrespondingType(typeof(READ_FILE_USN_DATA), CorrespondingAction.Get)]
			public static uint FSCTL_READ_FILE_USN_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 58, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_READ_FROM_PLEX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 71, IOMethod.METHOD_OUT_DIRECT, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_READ_RAW_ENCRYPTED => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 56, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_READ_UNPRIVILEGED_USN_JOURNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 234, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Retrieves the set of update sequence number (USN) change journal records between two specified USN values.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>For the implications of overlapped I/O on this operation, see the Remarks section of the DeviceIoControl topic.</para>
			/// <para>
			/// There are two DeviceIoControl control codes that return USN records, <c>FSCTL_READ_USN_JOURNAL</c> and FSCTL_ENUM_USN_DATA.
			/// Use the latter when you want a listing (enumeration) of the USN records between two USNs. Use the former when you want to
			/// select by USN.
			/// </para>
			/// <para>For more information, see Creating, Modifying, and Deleting a Change Journal.</para>
			/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
			/// <para>\.&lt;i&gt;X:</para>
			/// <para>In the preceding string, X is the letter identifying the drive on which the volume appears. The volume must be NTFS.</para>
			/// <para>In Windows 8 and Windows Server 2012, this code is supported by the following technologies.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Technology</term>
			/// <term>Supported</term>
			/// </listheader>
			/// <item>
			/// <term>Server Message Block (SMB) 3.0 protocol</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 Transparent Failover (TFO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>SMB 3.0 with Scale-out File Shares (SO)</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Cluster Shared Volume File System (CsvFS)</term>
			/// <term>See comment</term>
			/// </item>
			/// </list>
			/// <para>An application may experience false positives on CsvFs pause/resume.</para>
			/// <para>Examples</para>
			/// <para>For an example, see Walking a Buffer of Change Journal Records.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_read_usn_journal
			[PInvokeData("winioctl.h", MSDNShortId = "205de464-7e96-477b-9115-e819719b160e")]
			[CorrespondingType(typeof(READ_USN_JOURNAL_DATA_V0), CorrespondingAction.Get)]
			[CorrespondingType(typeof(READ_USN_JOURNAL_DATA_V1), CorrespondingAction.Get)]
			public static uint FSCTL_READ_USN_JOURNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 46, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_REARRANGE_FILE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 264, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_RECALL_FILE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 69, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_REFS_DEALLOCATE_RANGES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 246, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_REMOVE_OVERLAY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 205, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_REPAIR_COPIES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 173, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_REQUEST_BATCH_OPLOCK => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 2, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_REQUEST_FILTER_OPLOCK => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 23, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_REQUEST_OPLOCK => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 144, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_REQUEST_OPLOCK_LEVEL_1 => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 0, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_REQUEST_OPLOCK_LEVEL_2 => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 1, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_RESET_VOLUME_ALLOCATION_HINTS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 123, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_RKF_INTERNAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 171, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SCRUB_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 172, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SCRUB_UNDISCOVERABLE_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 254, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SD_GLOBAL_CHANGE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 125, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SECURITY_ID_CHECK => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 45, IOMethod.METHOD_NEITHER, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_SET_BOOTLOADER_ACCESSED => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 19, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_COMPRESSION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 16, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint FSCTL_SET_DAX_ALLOC_ALIGNMENT_HINT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 252, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_DEFECT_MANAGEMENT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 77, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_SET_ENCRYPTION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 53, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_EXTERNAL_BACKING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 195, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_INTEGRITY_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 160, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_SET_INTEGRITY_INFORMATION_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 224, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_LAYER_ROOT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 229, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_OBJECT_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 38, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_OBJECT_ID_EXTENDED => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 47, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_PERSISTENT_VOLUME_STATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 142, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_PURGE_FAILURE_MODE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 156, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_REFS_FILE_STRICTLY_SEQUENTIAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 249, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_REFS_SMR_VOLUME_GC_PARAMETERS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 248, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_REPAIR => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 102, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_REPARSE_POINT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 41, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_REPARSE_POINT_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 259, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_SHORT_NAME_BEHAVIOR => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 109, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_SPARSE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 49, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_VOLUME_COMPRESSION_STATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 80, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SET_ZERO_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 50, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_SET_ZERO_ON_DEALLOCATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 101, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SHRINK_VOLUME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 108, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SHUFFLE_FILE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 208, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_SIS_COPYFILE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 64, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SIS_LINK_FILES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 65, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_SPARSE_OVERALLOCATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 211, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SSDI_STORAGE_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 232, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_START_VIRTUALIZATION_INSTANCE_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 256, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_STORAGE_QOS_CONTROL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 212, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_STREAMS_ASSOCIATE_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 242, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_STREAMS_QUERY_ID => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 243, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_STREAMS_QUERY_PARAMETERS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 241, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SUSPEND_OVERLAY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 225, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SVHDX_ASYNC_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 217, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SVHDX_SET_INITIATOR_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 194, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_SVHDX_SYNC_TUNNEL_REQUEST => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 193, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_TXFS_CREATE_MINIVERSION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 95, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_CREATE_SECONDARY_RM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 90, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_GET_METADATA_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 91, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_TXFS_GET_TRANSACTED_VERSION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 92, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_TXFS_LIST_TRANSACTION_LOCKED_FILES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 120, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_TXFS_LIST_TRANSACTIONS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 121, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_TXFS_MODIFY_RM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 81, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_QUERY_RM_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 82, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_TXFS_READ_BACKUP_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 88, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_TXFS_READ_BACKUP_INFORMATION2 => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 126, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_TXFS_ROLLFORWARD_REDO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 84, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_ROLLFORWARD_UNDO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 85, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_SAVEPOINT_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 94, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_SHUTDOWN_RM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 87, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_START_RM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 86, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_TRANSACTION_ACTIVE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 99, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint FSCTL_TXFS_WRITE_BACKUP_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 89, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint FSCTL_TXFS_WRITE_BACKUP_INFORMATION2 => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 128, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_UNLOCK_VOLUME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 7, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_UNMAP_SPACE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 237, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_UPDATE_OVERLAY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 206, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);

			/// <summary>
			/// <para>
			/// Enables range tracking feature for update sequence number (USN) change journal stream on a target volume, or modifies already
			/// enabled range tracking parameters.
			/// </para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>For the implications of overlapped I/O on this operation, see the Remarks section of the DeviceIoControl topic.</para>
			/// <para>
			/// You can use <c>FSCTL_USN_TRACK_MODIFIED_RANGES</c> to enable range tracking for the first time for a volume. After the
			/// enabling range tracking, the state and parameters will be persisted for that volume and on next reboot the range tracking
			/// will be initialized read from the persisted parameters.
			/// </para>
			/// <para>
			/// You can also use <c>FSCTL_USN_TRACK_MODIFIED_RANGES</c> to modify an existing change journal stream range track parameter. If
			/// range tracking is already exists, <c>FSCTL_USN_TRACK_MODIFIED_RANGES</c> sets it to the parameters provided in the
			/// USN_TRACK_MODIFIED_RANGES structure. The chunk size or file size threshold can only be lowered from previous values. Once
			/// enabled, range tracking feature cannot be disabled unless the journal is deleted.
			/// </para>
			/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
			/// <para>\.\X:</para>
			/// <para>
			/// In the preceding string, X is the letter identifying the drive on which the volume appears. The volume must be NTFS 3.0 or
			/// later. To obtain the NTFS version of a volume, open a command prompt with Administrator access rights and execute the
			/// following command:
			/// </para>
			/// <para><c>fsutil fsinfo ntfsinfo</c> X <c>:</c></para>
			/// <para>where X is the drive letter of the volume.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_usn_track_modified_ranges
			[PInvokeData("winioctl.h", MSDNShortId = "258E16B2-B6E8-44BB-8073-B1BEDD4FA86A")]
			[CorrespondingType(typeof(USN_RANGE_TRACK_OUTPUT), CorrespondingAction.Get)]
			[CorrespondingType(typeof(USN_TRACK_MODIFIED_RANGES), CorrespondingAction.Get)]
			public static uint FSCTL_USN_TRACK_MODIFIED_RANGES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 189, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint FSCTL_VIRTUAL_STORAGE_PASSTHROUGH => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 265, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_VIRTUAL_STORAGE_QUERY_PROPERTY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 226, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_VIRTUAL_STORAGE_SET_BEHAVIOR => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 258, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_WAIT_FOR_REPAIR => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 104, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_WRITE_RAW_ENCRYPTED => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 55, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_WRITE_USN_CLOSE_RECORD => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 59, IOMethod.METHOD_NEITHER, IOAccess.FILE_ANY_ACCESS);
			public static uint FSCTL_WRITE_USN_REASON => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_FILE_SYSTEM, 180, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_AVIO_ALLOCATE_STREAM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_AVIO, 1, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_AVIO_FREE_STREAM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_AVIO, 2, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_AVIO_MODIFY_STREAM => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_AVIO, 3, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_CHANGER_EXCHANGE_MEDIUM => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0008, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_CHANGER_GET_ELEMENT_STATUS => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0005, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_CHANGER_GET_PARAMETERS => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0000, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_CHANGER_GET_PRODUCT_DATA => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0002, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_CHANGER_GET_STATUS => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0001, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_CHANGER_INITIALIZE_ELEMENT_STATUS => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0006, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_CHANGER_MOVE_MEDIUM => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0009, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_CHANGER_QUERY_VOLUME_TAGS => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x000B, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_CHANGER_REINITIALIZE_TRANSPORT => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x000A, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_CHANGER_SET_ACCESS => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0004, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_CHANGER_SET_POSITION => CTL_CODE(DEVICE_TYPE.IOCTL_CHANGER_BASE, 0x0007, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_CHECK_VERIFY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0200, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_CONTROLLER_NUMBER => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0011, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Initializes the specified disk and disk partition table using the information in the CREATE_DISK structure.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// When specifying a GUID partition table (GPT) as the PARTITION_STYLE of the CREATE_DISK structure, an application should wait
			/// for the MSR partition arrival before sending the IOCTL_DISK_SET_DRIVE_LAYOUT_EX control code. For more information about
			/// device notification, see RegisterDeviceNotification.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_create_disk
			[PInvokeData("winioctl.h", MSDNShortId = "c8215a00-ea39-4268-bb66-68cf3d37baef")]
			[CorrespondingType(typeof(CREATE_DISK), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_CREATE_DISK => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0016, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			public static uint IOCTL_DISK_DELETE_DRIVE_LAYOUT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0040, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_EJECT_MEDIA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0202, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_FIND_NEW_DEVICES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0206, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_FORMAT_DRIVE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x00f3, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_FORMAT_TRACKS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0006, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_FORMAT_TRACKS_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x000b, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			/// <summary>
			/// <para>Retrieves the disk cache configuration data.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>To set the disk cache information, use the IOCTL_DISK_SET_CACHE_INFORMATION control code.</remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_cache_information
			[PInvokeData("winioctl.h", MSDNShortId = "025a92e8-6169-4d7e-9029-f22acb2bdc9f")]
			[CorrespondingType(typeof(DISK_CACHE_INFORMATION), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GET_CACHE_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0035, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			public static uint IOCTL_DISK_GET_DISK_ATTRIBUTES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x003c, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>
			/// Retrieves information about the physical disk's geometry: type, number of cylinders, tracks per cylinder, sectors per track,
			/// and bytes per sector.
			/// </para>
			/// <para>
			/// <c>Note</c><c>IOCTL_DISK_GET_DRIVE_GEOMETRY</c> has been superseded by IOCTL_DISK_GET_DRIVE_GEOMETRY_EX, which retrieves
			/// additional information.
			/// </para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_drive_geometry
			[PInvokeData("winioctl.h", MSDNShortId = "574efc29-112b-42fe-ad1b-72543f20e831")]
			[CorrespondingType(typeof(DISK_GEOMETRY), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GET_DRIVE_GEOMETRY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0000, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>
			/// Retrieves extended information about the physical disk's geometry: type, number of cylinders, tracks per cylinder, sectors
			/// per track, and bytes per sector.
			/// </para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// When specifying a GUID partition table (GPT) as the PARTITION_STYLE of the CREATE_DISK structure, an application should wait
			/// for the MSR partition arrival before sending the IOCTL_DISK_SET_DRIVE_LAYOUT_EX control code. For more information about
			/// device notification, see RegisterDeviceNotification.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_drive_geometry_ex
			[PInvokeData("winioctl.h", MSDNShortId = "8a0667c8-b182-4851-af8e-411d95da0e3b")]
			[CorrespondingType(typeof(DISK_GEOMETRY_EX), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GET_DRIVE_GEOMETRY_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0028, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Retrieves information for each entry in the partition tables for a disk.</para>
			/// <para>
			/// <c>Note</c><c>IOCTL_DISK_GET_DRIVE_LAYOUT</c> has been superseded by IOCTL_DISK_GET_DRIVE_LAYOUT_EX, which retrieves layout
			/// information for AT and EFI (Extensible Firmware Interface) partitions.
			/// </para>
			/// <para>
			/// To perform this operation, call the DeviceIoControl function with the following parameters. You must have read access to the
			/// drive in order to use this control code.
			/// </para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// This operation retrieves information for each primary partition as well as each logical drive. To determine whether the entry
			/// is an extended or unused partition, check the disk partition type.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_drive_layout
			[PInvokeData("winioctl.h", MSDNShortId = "6c1bc445-3cd1-4f86-a36b-f74ad8f4d2e5")]
			[CorrespondingType(typeof(DRIVE_LAYOUT_INFORMATION), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GET_DRIVE_LAYOUT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0003, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			/// <summary>
			/// <para>Retrieves extended information for each entry in the partition tables for a disk.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// This operation retrieves information for each primary partition as well as each logical drive. To determine whether the entry
			/// is an extended or unused partition, check the disk partition type.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_drive_layout_ex
			[PInvokeData("winioctl.h", MSDNShortId = "21507182-5a33-4e58-b5ed-3724feefa4ed")]
			[CorrespondingType(typeof(DRIVE_LAYOUT_INFORMATION_EX), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GET_DRIVE_LAYOUT_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0014, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_DISK_GET_LENGTH_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0017, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_GET_MEDIA_TYPES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0300, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			/// <summary>
			/// <para>Retrieves extended information about the type, size, and nature of a disk partition.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// The <c>IOCTL_DISK_GET_PARTITION_INFO_EX</c> control code is supported on basic disks. It is only supported on dynamic disks
			/// that are boot or system disks, or have retained entries in the partition table. The DiskPart.exe command <c>RETAIN</c> can be
			/// used to do this for other dynamic simple partitions.
			/// </para>
			/// <para>The disk support can be summarized as follows.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Disk type</term>
			/// <term>IOCTL_DISK_GET_PARTITION_INFO</term>
			/// <term>IOCTL_DISK_GET_PARTITION_INFO_EX</term>
			/// </listheader>
			/// <item>
			/// <term>Basic master boot record (MBR)</term>
			/// <term>Yes</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Basic GUID partition table (GPT)</term>
			/// <term>No</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Dynamic MBR boot/system</term>
			/// <term>Yes</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Dynamic MBR data</term>
			/// <term>Yes</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Dynamic GPT boot/system</term>
			/// <term>No</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Dynamic GPT data</term>
			/// <term>No</term>
			/// <term>No</term>
			/// </item>
			/// </list>
			/// <para>Currently, GPT is supported only on 64-bit systems.</para>
			/// <para>
			/// If the partition is on a disk formatted as type master boot record (MBR), partition size totals are limited. For more
			/// information, see the Remarks section of IOCTL_DISK_SET_DRIVE_LAYOUT.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_partition_info_ex
			[PInvokeData("winioctl.h", MSDNShortId = "f84f8be6-2b01-4a20-8669-cb1a55c32907")]
			[CorrespondingType(typeof(PARTITION_INFORMATION), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GET_PARTITION_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0001, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			/// <summary>
			/// <para>Retrieves extended information about the type, size, and nature of a disk partition.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// The <c>IOCTL_DISK_GET_PARTITION_INFO_EX</c> control code is supported on basic disks. It is only supported on dynamic disks
			/// that are boot or system disks, or have retained entries in the partition table. The DiskPart.exe command <c>RETAIN</c> can be
			/// used to do this for other dynamic simple partitions.
			/// </para>
			/// <para>The disk support can be summarized as follows.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Disk type</term>
			/// <term>IOCTL_DISK_GET_PARTITION_INFO</term>
			/// <term>IOCTL_DISK_GET_PARTITION_INFO_EX</term>
			/// </listheader>
			/// <item>
			/// <term>Basic master boot record (MBR)</term>
			/// <term>Yes</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Basic GUID partition table (GPT)</term>
			/// <term>No</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Dynamic MBR boot/system</term>
			/// <term>Yes</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Dynamic MBR data</term>
			/// <term>Yes</term>
			/// <term>No</term>
			/// </item>
			/// <item>
			/// <term>Dynamic GPT boot/system</term>
			/// <term>No</term>
			/// <term>Yes</term>
			/// </item>
			/// <item>
			/// <term>Dynamic GPT data</term>
			/// <term>No</term>
			/// <term>No</term>
			/// </item>
			/// </list>
			/// <para>Currently, GPT is supported only on 64-bit systems.</para>
			/// <para>
			/// If the partition is on a disk formatted as type master boot record (MBR), partition size totals are limited. For more
			/// information, see the Remarks section of IOCTL_DISK_SET_DRIVE_LAYOUT.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_partition_info_ex
			[PInvokeData("winioctl.h", MSDNShortId = "f84f8be6-2b01-4a20-8669-cb1a55c32907")]
			[CorrespondingType(typeof(PARTITION_INFORMATION_EX), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GET_PARTITION_INFO_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0012, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_DISK_GET_WRITE_CACHE_STATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0037, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			/// <summary>
			/// <para>Enlarges the specified partition.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>You can extend or shrink a live partition, and the partition can be open for sharing during the extend or shrink operation.</para>
			/// <para>
			/// You do not need to lock a partition that you are extending, nor do you need to shut down other applications or services
			/// during the extend operation.
			/// </para>
			/// <para>For more information, see DISK_GROW_PARTITION.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_grow_partition
			[PInvokeData("winioctl.h", MSDNShortId = "bbcb0bee-a507-4abb-83df-328f3aa6caaa")]
			[CorrespondingType(typeof(DISK_GROW_PARTITION), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_GROW_PARTITION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0034, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			public static uint IOCTL_DISK_HISTOGRAM_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x000d, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_HISTOGRAM_RESET => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x000e, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_HISTOGRAM_STRUCTURE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x000c, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_IS_WRITABLE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0009, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_LOAD_MEDIA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0203, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_LOGGING => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x000a, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_MEDIA_REMOVAL => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0201, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

			/// <summary>
			/// <para>Enables performance counters that provide disk performance information.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// To disable the performance counters enabled by this control code, use the IOCTL_DISK_PERFORMANCE_OFF control code.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_performance
			[PInvokeData("winioctl.h", MSDNShortId = "e182282c-17e9-442a-8742-437052cfed03")]
			[CorrespondingType(typeof(DISK_PERFORMANCE), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_PERFORMANCE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0008, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);

			public static uint IOCTL_DISK_PERFORMANCE_OFF => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0018, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_REASSIGN_BLOCKS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0007, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_REASSIGN_BLOCKS_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0029, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_RELEASE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0205, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_REQUEST_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0010, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_REQUEST_STRUCTURE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x000f, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_RESERVE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0204, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_DISK_RESET_SNAPSHOT_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0084, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_SENSE_DEVICE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x00f8, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_SET_CACHE_INFORMATION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0036, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_SET_DISK_ATTRIBUTES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x003d, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			/// <summary>
			/// <para>Partitions a disk as specified by drive layout and partition information data.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the parameters specified below.</para>
			/// <para>
			/// <c>IOCTL_DISK_SET_DRIVE_LAYOUT</c> has been superseded by IOCTL_DISK_SET_DRIVE_LAYOUT_EX, which retrieves layout information
			/// for AT and EFI (Extensible Firmware Interface) partitions.
			/// </para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// If the partition is on a disk formatted as type master boot record (MBR), partition size totals cannot exceed 2 TB per MBR
			/// disk. For example, a disk of type MBR can have a single 2-TB partition, two 1-TB partitions, or any combination that does not
			/// total more than 2 TB. If more space is required, a disk formatted as type GUID partition table (GPT) should be used. If
			/// third-party partitioning tools are used to work around this limitation on disks of type MBR larger than 2 TB, configuration
			/// operations via the disk partitioning IOCTL control codes will be limited.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_set_drive_layout
			[PInvokeData("winioctl.h", MSDNShortId = "8cace6a5-666a-4d35-a557-6bf0564dbe58")]
			[CorrespondingType(typeof(DRIVE_LAYOUT_INFORMATION), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_SET_DRIVE_LAYOUT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0004, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			/// <summary>
			/// <para>Partitions a disk according to the specified drive layout and partition information data.</para>
			/// <para>To perform this operation, call the DeviceIoControl function with the following parameters.</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>Input Buffer Length</para>
			/// <para>Output Buffer</para>
			/// <para>Output Buffer Length</para>
			/// <para>Input / Output Buffer</para>
			/// <para>Input / Output Buffer Length</para>
			/// <para>Status Block</para>
			/// <para>Irp-&gt;IoStatus.Status is set to STATUS_SUCCESS if the request is successful.</para>
			/// <para>Otherwise, Status to the appropriate error condition as a NTSTATUS code.</para>
			/// <para>For more information, see NTSTATUS Values.</para>
			/// </summary>
			/// <remarks>
			/// <para>
			/// When specifying a <c>GUID</c> partition table (GPT) as the PARTITION_STYLE of the CREATE_DISK structure, an application
			/// should wait for the MSR partition arrival before sending the <c>IOCTL_DISK_SET_DRIVE_LAYOUT_EX</c> control code. For more
			/// information about device notification, see RegisterDeviceNotification.
			/// </para>
			/// <para>
			/// When creating and manipulating an Extended Boot Record (EBR), the first entry of the EBR should point to the logical drive
			/// that immediately follows the EBR and the next EBR should lie after the end of the current logical drive and before the start
			/// of the next logical drive.
			/// </para>
			/// <para>
			/// If the partition is on a disk formatted as type master boot record (MBR), partition size totals are limited. For more
			/// information, see the Remarks section of IOCTL_DISK_SET_DRIVE_LAYOUT.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_set_drive_layout_ex
			[PInvokeData("winioctl.h", MSDNShortId = "a600e841-c692-4aa4-bea2-a33931d9b007")]
			[CorrespondingType(typeof(DRIVE_LAYOUT_INFORMATION_EX), CorrespondingAction.Get)]
			public static uint IOCTL_DISK_SET_DRIVE_LAYOUT_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0015, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			/// <summary>
			/// <para>Changes the partition type of the specified disk partition. (Floppy drivers need not handle this request.)</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>The buffer at <c>Irp-&gt;AssociatedIrp.SystemBuffer</c> contains the SET_PARTITION_INFORMATION to be set.</para>
			/// <para>Input Buffer Length</para>
			/// <para>
			/// <c>Parameters.DeviceIoControl.InputBufferLength</c> in the I/O stack location of the IRP indicates the size, in bytes, of the
			/// buffer, which must be &gt;= <c>sizeof</c>(SET_PARTITION_INFORMATION).
			/// </para>
			/// <para>Output Buffer</para>
			/// <para>None.</para>
			/// <para>Output Buffer Length</para>
			/// <para>None.</para>
			/// <para>Status Block</para>
			/// <para>
			/// The <c>Information</c> field is set to zero. The <c>Status</c> field can be set to STATUS_SUCCESS, or possibly to
			/// STATUS_INVALID_PARAMETER, STATUS_INVALID_DEVICE_REQUEST, STATUS_UNSUCCESSFUL, STATUS_INFO_LENGTH_MISMATCH,
			/// STATUS_INSUFFICIENT_RESOURCES, or STATUS_BUFFER_TOO_SMALL.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdddisk/ni-ntdddisk-ioctl_disk_set_partition_info
			[PInvokeData("ntdddisk.h", MSDNShortId = "3ff5a328-04b0-4de9-abe1-759c36f31899")]
			[CorrespondingType(typeof(PARTITION_INFORMATION), CorrespondingAction.Set)]
			public static uint IOCTL_DISK_SET_PARTITION_INFO => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0002, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			/// <summary>
			/// <para>Changes the partition type of the specified disk partition. (Floppy drivers need not handle this request.)</para>
			/// <para>Major Code</para>
			/// <para>IRP_MJ_DEVICE_CONTROL</para>
			/// <para>Input Buffer</para>
			/// <para>The buffer at <c>Irp-&gt;AssociatedIrp.SystemBuffer</c> contains the SET_PARTITION_INFORMATION_EX to be set.</para>
			/// <para>Input Buffer Length</para>
			/// <para>
			/// <c>Parameters.DeviceIoControl.InputBufferLength</c> in the I/O stack location of the IRP indicates the size, in bytes, of the
			/// buffer, which must be &gt;= <c>sizeof</c>(SET_PARTITION_INFORMATION_EX).
			/// </para>
			/// <para>Output Buffer</para>
			/// <para>None.</para>
			/// <para>Output Buffer Length</para>
			/// <para>None.</para>
			/// <para>Status Block</para>
			/// <para>
			/// The <c>Information</c> field is set to zero. The <c>Status</c> field can be set to STATUS_SUCCESS, or possibly to
			/// STATUS_INVALID_PARAMETER, STATUS_INVALID_DEVICE_REQUEST, STATUS_UNSUCCESSFUL, STATUS_INFO_LENGTH_MISMATCH,
			/// STATUS_INSUFFICIENT_RESOURCES, or STATUS_BUFFER_TOO_SMALL.
			/// </para>
			/// </summary>
			// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/ntdddisk/ni-ntdddisk-ioctl_disk_set_partition_info_ex
			[PInvokeData("ntdddisk.h", MSDNShortId = "80558175-4d34-4011-a5b3-b6475b5e0d15")]
			[CorrespondingType(typeof(PARTITION_INFORMATION_EX), CorrespondingAction.Set)]
			public static uint IOCTL_DISK_SET_PARTITION_INFO_EX => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0013, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			public static uint IOCTL_DISK_UPDATE_DRIVE_SIZE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0032, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_DISK_UPDATE_PROPERTIES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0050, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_DISK_VERIFY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0005, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SCM_BUS_GET_LOGICAL_DEVICES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCMBUS_FUNCTION(0x00), IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SCM_BUS_GET_PHYSICAL_DEVICES => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCMBUS_FUNCTION(0x01), IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SCM_BUS_GET_REGIONS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCMBUS_FUNCTION(0x02), IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SCM_LD_GET_INTERLEAVE_SET => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCM_LOGICAL_DEVICE_FUNCTION(0x00), IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SCM_PD_FIRMWARE_ACTIVATE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCM_PHYSICAL_DEVICE_FUNCTION(0x02), IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_SCM_PD_FIRMWARE_DOWNLOAD => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCM_PHYSICAL_DEVICE_FUNCTION(0x01), IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_SCM_PD_PASSTHROUGH => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCM_PHYSICAL_DEVICE_FUNCTION(0x03), IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_SCM_PD_QUERY_PROPERTY => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCM_PHYSICAL_DEVICE_FUNCTION(0x00), IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SCM_PD_REINITIALIZE_MEDIA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCM_PHYSICAL_DEVICE_FUNCTION(0x05), IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_SCM_PD_UPDATE_MANAGEMENT_STATUS => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_PERSISTENT_MEMORY, SCM_PHYSICAL_DEVICE_FUNCTION(0x04), IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SERENUM_EXPOSE_HARDWARE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_SERENUM, 128, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SERENUM_GET_PORT_NAME => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_SERENUM, 131, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SERENUM_PORT_DESC => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_SERENUM, 130, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SERENUM_REMOVE_HARDWARE => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_SERENUM, 129, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_SERIAL_LSRMST_INSERT => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_SERIAL_PORT, 31, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_ALLOCATE_BC_STREAM => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0601, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_ATTRIBUTE_MANAGEMENT => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0727, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_BREAK_RESERVATION => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0405, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_CHECK_PRIORITY_HINT_SUPPORT => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0620, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_CHECK_VERIFY => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0200, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_CHECK_VERIFY2 => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0200, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_DEVICE_POWER_CAP => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0725, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_DEVICE_TELEMETRY_NOTIFY => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0471, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_DEVICE_TELEMETRY_QUERY_CAPS => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0472, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_DIAGNOSTIC => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0728, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_EJECT_MEDIA => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0202, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_EJECTION_CONTROL => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0250, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_ENABLE_IDLE_POWER => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0720, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_EVENT_NOTIFICATION => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0724, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_FAILURE_PREDICTION_CONFIG => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0441, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_FIND_NEW_DEVICES => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0206, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_FIRMWARE_ACTIVATE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0702, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_FIRMWARE_DOWNLOAD => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0701, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_FIRMWARE_GET_INFO => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0700, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_FREE_BC_STREAM => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0602, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_GET_BC_PROPERTIES => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0600, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_GET_COUNTERS => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x442, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_GET_DEVICE_NUMBER => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0420, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_GET_DEVICE_TELEMETRY => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0470, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_GET_DEVICE_TELEMETRY_RAW => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0473, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_GET_HOTPLUG_INFO => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0305, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_GET_IDLE_POWERUP_REASON => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0721, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_GET_LB_PROVISIONING_MAP_RESOURCES => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0502, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_GET_MEDIA_SERIAL_NUMBER => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0304, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_GET_MEDIA_TYPES => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0300, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_GET_MEDIA_TYPES_EX => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0301, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_GET_PHYSICAL_ELEMENT_STATUS => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0729, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_LOAD_MEDIA => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0203, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_LOAD_MEDIA2 => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0203, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0501, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_MCN_CONTROL => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0251, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_MEDIA_REMOVAL => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0201, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_PERSISTENT_RESERVE_IN => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0406, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_PERSISTENT_RESERVE_OUT => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0407, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_POWER_ACTIVE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0722, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_POWER_IDLE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0723, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_PREDICT_FAILURE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0440, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_PROTOCOL_COMMAND => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x04F0, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_QUERY_PROPERTY => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0500, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_READ_CAPACITY => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0450, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_REINITIALIZE_MEDIA => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0590, IOMethod.METHOD_BUFFERED, IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_RELEASE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0205, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_REMOVE_ELEMENT_AND_TRUNCATE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0730, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_RESERVE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0204, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_RESET_BUS => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0400, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_RESET_DEVICE => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0401, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint IOCTL_STORAGE_RPMB_COMMAND => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0726, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_STORAGE_SET_HOTPLUG_INFO => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0306, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_SET_TEMPERATURE_THRESHOLD => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0480, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_START_DATA_INTEGRITY_CHECK => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0621, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_STORAGE_STOP_DATA_INTEGRITY_CHECK => CTL_CODE(DEVICE_TYPE.IOCTL_STORAGE_BASE, 0x0622, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_WRITE_ACCESS);
			public static uint IOCTL_VOLUME_GET_GPT_ATTRIBUTES => CTL_CODE(DEVICE_TYPE.IOCTL_VOLUME_BASE, 14, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS => CTL_CODE(DEVICE_TYPE.IOCTL_VOLUME_BASE, 0, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_VOLUME_IS_CLUSTERED => CTL_CODE(DEVICE_TYPE.IOCTL_VOLUME_BASE, 12, IOMethod.METHOD_BUFFERED, IOAccess.FILE_ANY_ACCESS);
			public static uint IOCTL_VOLUME_OFFLINE => CTL_CODE(DEVICE_TYPE.IOCTL_VOLUME_BASE, 3, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint IOCTL_VOLUME_ONLINE => CTL_CODE(DEVICE_TYPE.IOCTL_VOLUME_BASE, 2, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint SMART_GET_VERSION => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0020, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);
			public static uint SMART_RCV_DRIVE_DATA => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0022, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);
			public static uint SMART_SEND_DRIVE_COMMAND => CTL_CODE(DEVICE_TYPE.FILE_DEVICE_DISK, 0x0021, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

			private static ushort SCM_LOGICAL_DEVICE_FUNCTION(ushort x) => (ushort)(IOCTL_SCM_LOGICAL_DEVICE_FUNCTION_BASE + x);

			private static ushort SCM_PHYSICAL_DEVICE_FUNCTION(ushort x) => (ushort)(IOCTL_SCM_PHYSICAL_DEVICE_FUNCTION_BASE + x);

			private static ushort SCMBUS_FUNCTION(ushort x) => (ushort)(IOCTL_SCMBUS_DEVICE_FUNCTION_BASE + x);
		}
	}
}