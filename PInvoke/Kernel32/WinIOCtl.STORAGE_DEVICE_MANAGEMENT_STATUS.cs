using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	private const int STORAGE_ADAPTER_SERIAL_NUMBER_V1_MAX_LENGTH = 128;

	private const int STORAGE_DEVICE_MAX_OPERATIONAL_STATUS = 16;

	/// <summary>Constants for StorageDeviceManagementStatus</summary>
	[PInvokeData("winioctl.h")]
	public enum STORAGE_DISK_HEALTH_STATUS
	{
		DiskHealthUnknown = 0,
		DiskHealthUnhealthy,
		DiskHealthWarning,
		DiskHealthHealthy,
		DiskHealthMax,
	}

	/// <summary>Operational States</summary>
	[PInvokeData("winioctl.h")]
	public enum STORAGE_DISK_OPERATIONAL_STATUS
	{
		DiskOpStatusNone = 0,
		DiskOpStatusUnknown,
		DiskOpStatusOk,
		DiskOpStatusPredictingFailure,
		DiskOpStatusInService,
		DiskOpStatusHardwareError,
		DiskOpStatusNotUsable,
		DiskOpStatusTransientError,
		DiskOpStatusMissing,
	}

	/// <summary>Operational Reasons</summary>
	[PInvokeData("winioctl.h")]
	public enum STORAGE_OPERATIONAL_STATUS_REASON
	{
		DiskOpReasonUnknown = 0,
		DiskOpReasonScsiSenseCode,
		DiskOpReasonMedia,
		DiskOpReasonIo,
		DiskOpReasonThresholdExceeded,
		DiskOpReasonLostData,
		DiskOpReasonEnergySource,
		DiskOpReasonConfiguration,
		DiskOpReasonDeviceController,
		DiskOpReasonMediaController,
		DiskOpReasonComponent,
		DiskOpReasonNVDIMM_N,
		DiskOpReasonBackgroundOperation,
		DiskOpReasonInvalidFirmware,
		DiskOpReasonHealthCheck,
		DiskOpReasonLostDataPersistence,
		DiskOpReasonDisabledByPlatform,
		DiskOpReasonLostWritePersistence,
		DiskOpReasonDataPersistenceLossImminent,
		DiskOpReasonWritePersistenceLossImminent,
		DiskOpReasonMax,
	}

	/// <summary>
	/// The NULL-terminated Unicode string of the adapter serial number for the StorageAdapterSerialNumberProperty as defined in STORAGE_PROPERTY_ID.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_adapter_serial_number typedef struct
	// _STORAGE_ADAPTER_SERIAL_NUMBER { DWORD Version; DWORD Size; WCHAR SerialNumber[STORAGE_ADAPTER_SERIAL_NUMBER_V1_MAX_LENGTH]; }
	// STORAGE_ADAPTER_SERIAL_NUMBER, *PSTORAGE_ADAPTER_SERIAL_NUMBER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_ADAPTER_SERIAL_NUMBER")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STORAGE_ADAPTER_SERIAL_NUMBER
	{
		/// <summary>The version of this structure. The Size serves as the version.</summary>
		public uint Version;

		/// <summary>The size of this structure.</summary>
		public uint Size;

		/// <summary>The serial number.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = STORAGE_ADAPTER_SERIAL_NUMBER_V1_MAX_LENGTH)]
		public string SerialNumber;
	}

	/// <summary>Structure for STORAGE_PROPERTY_ID.StorageDeviceManagementStatus</summary>
	[PInvokeData("winioctl.h")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<STORAGE_DEVICE_MANAGEMENT_STATUS>), nameof(NumberOfAdditionalReasons))]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_MANAGEMENT_STATUS
	{
		/// <summary>Sizeof() of this structure serves as the version.</summary>
		public uint Version;

		/// <summary>
		/// The total size of the structure, including operational status reasons that didn't fit in the caller's array. Callers should use
		/// this field to learn how big the input buffer should be to contain all the available information.
		/// </summary>
		public uint Size;

		/// <summary>Health status.</summary>
		public STORAGE_DISK_HEALTH_STATUS Health;

		/// <summary>The number of operational status returned.</summary>
		public uint NumberOfOperationalStatus;

		/// <summary>The number of additional reasons returned.</summary>
		public uint NumberOfAdditionalReasons;

		/// <summary>
		/// Operational statuses. The primary operational status is the first element in the array. There are NumberOfOperationalStatus valid
		/// elements in the array.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = STORAGE_DEVICE_MAX_OPERATIONAL_STATUS)]
		public STORAGE_DISK_OPERATIONAL_STATUS[] OperationalStatus;

		/// <summary>Additional reasons. There are NumberOfAdditionalReasons valid elements in the array.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public STORAGE_OPERATIONAL_REASON[] AdditionalReasons;
	}

	/// <summary>The STORAGE_DEVICE_UNIQUE_IDENTIFIER structure defines a device unique identifier (DUID).</summary>
	// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/storduid/ns-storduid-_storage_device_unique_identifier typedef struct
	// _STORAGE_DEVICE_UNIQUE_IDENTIFIER { ULONG Version; ULONG Size; ULONG StorageDeviceIdOffset; ULONG StorageDeviceOffset; ULONG
	// DriveLayoutSignatureOffset; } STORAGE_DEVICE_UNIQUE_IDENTIFIER, *PSTORAGE_DEVICE_UNIQUE_IDENTIFIER;
	[PInvokeData("storduid.h", MSDNShortId = "NS:storduid._STORAGE_DEVICE_UNIQUE_IDENTIFIER")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct STORAGE_DEVICE_UNIQUE_IDENTIFIER
	{
		/// <summary>The version of the DUID.</summary>
		public uint Version;

		/// <summary>The size, in bytes, of the identifier header and the identifiers (IDs) that follow the header.</summary>
		public uint Size;

		/// <summary>
		/// The offset, in bytes, from the beginning of the header to the device ID descriptor (STORAGE_DEVICE_ID_DESCRIPTOR). The device ID
		/// descriptor contains the IDs that are extracted from page 0x83 of the device's vital product data (VPD).
		/// </summary>
		public uint StorageDeviceIdOffset;

		/// <summary>
		/// The offset, in bytes, from the beginning of the header to the device descriptor (STORAGE_DEVICE_DESCRIPTOR). The device
		/// descriptor contains IDs that are extracted from non-VPD inquiry data.
		/// </summary>
		public uint StorageDeviceOffset;

		/// <summary>The offset, in bytes, to the drive layout signature (STORAGE_DEVICE_LAYOUT_SIGNATURE).</summary>
		public uint DriveLayoutSignatureOffset;
	}

	/// <summary>Additional reasons.</summary>
	[PInvokeData("winioctl.h")]
	[StructLayout(LayoutKind.Explicit)]
	public struct STORAGE_OPERATIONAL_REASON
	{
		[FieldOffset(0)]
		public uint Version;

		[FieldOffset(4)]
		public uint Size;

		[FieldOffset(8)]
		public STORAGE_OPERATIONAL_STATUS_REASON Reason;

		[FieldOffset(12)]
		public RawBytesUnion RawBytes;

		/// <summary>This is the format if Reason == DiskOpReasonScsiSenseCode.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct ScsiSenseKeyStruct
		{
			public byte SenseKey;
			public byte ASC;
			public byte ASCQ;
			public byte Reserved;
		}

		/// <summary>This is the format if Reason == DiskOpReasonNVDIMM_N.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct NVDIMM_NStruct
		{
			public byte CriticalHealth;
			public byte ModuleHealth[2];
			public byte ErrorThresholdStatus;
		}

		[StructLayout(LayoutKind.Explicit)]
		public struct RawBytesUnion
		{
			/// <summary>This is the format if Reason == DiskOpReasonScsiSenseCode.</summary>
			[FieldOffset(0)]
			public ScsiSenseKeyStruct ScsiSenseKey;

			/// <summary>This is the format if Reason == DiskOpReasonNVDIMM_N.</summary>
			[FieldOffset(0)]
			public NVDIMM_NStruct NVDIMM_N;

			[FieldOffset(0)]
			public uint AsUlong;
		}
	}
}