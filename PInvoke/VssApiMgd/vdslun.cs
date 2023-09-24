namespace Vanara.PInvoke.VssApi;

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines the set of the valid address types of a physical interconnect.</para>
/// </summary>
/// <remarks>
/// <para>
/// The VDS_INTERCONNECT structure includes a <c>VDS_INTERCONNECT_ADDRESS_TYPE</c> value as a member to indicate an interconnect address type.
/// </para>
/// <para>
/// <c>Note</c> Additional constants might be added to the <c>VDS_INTERCONNECT_ADDRESS_TYPE</c> enumeration in future Windows versions.
/// For this reason, your application must be designed to gracefully handle an unrecognized <c>VDS_INTERCONNECT_ADDRESS_TYPE</c>
/// enumeration constant.
/// </para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ne-vdslun-vds_interconnect_address_type typedef enum
// _VDS_INTERCONNECT_ADDRESS_TYPE { VDS_IA_UNKNOWN, VDS_IA_FCFS, VDS_IA_FCPH, VDS_IA_FCPH3, VDS_IA_MAC, VDS_IA_SCSI } VDS_INTERCONNECT_ADDRESS_TYPE;
[PInvokeData("vdslun.h", MSDNShortId = "NE:vdslun._VDS_INTERCONNECT_ADDRESS_TYPE")]
public enum VDS_INTERCONNECT_ADDRESS_TYPE
{
	/// <summary>This value is reserved.</summary>
	VDS_IA_UNKNOWN = 0,

	/// <summary>The address type is FCFS.</summary>
	VDS_IA_FCFS,

	/// <summary>The address type is FCPH.</summary>
	VDS_IA_FCPH,

	/// <summary>The address type is FCPH3.</summary>
	VDS_IA_FCPH3,

	/// <summary>The address type is MAC.</summary>
	VDS_IA_MAC,

	/// <summary>The address type is SCSI.</summary>
	VDS_IA_SCSI,
}

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines the set of valid bus types of a storage device.</para>
/// </summary>
/// <remarks>
/// <para>
/// The VDS_LUN_INFORMATION, VDS_DISK_PROP, VDS_DISK_PROP2, and VDS_DRIVE_PROP2 structures include a <c>VDS_STORAGE_BUS_TYPE</c> value
/// as a member to specify the bus type of a LUN, disk, or drive.
/// </para>
/// <para>
/// <c>Note</c> The type specified in these structures matches the type that the driver or drivers reported and may not exactly match
/// the hardware.
/// </para>
/// <para>
/// <c>Note</c> Additional constants might be added to the <c>VDS_STORAGE_BUS_TYPE</c> enumeration in future Windows versions. For this
/// reason, your application must be designed to gracefully handle an unrecognized <c>VDS_STORAGE_BUS_TYPE</c> enumeration constant.
/// </para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ne-vdslun-vds_storage_bus_type typedef enum _VDS_STORAGE_BUS_TYPE {
// VDSBusTypeUnknown, VDSBusTypeScsi, VDSBusTypeAtapi, VDSBusTypeAta, VDSBusType1394, VDSBusTypeSsa, VDSBusTypeFibre, VDSBusTypeUsb,
// VDSBusTypeRAID, VDSBusTypeiScsi, VDSBusTypeSas, VDSBusTypeSata, VDSBusTypeSd, VDSBusTypeMmc, VDSBusTypeMax, VDSBusTypeVirtual,
// VDSBusTypeFileBackedVirtual, VDSBusTypeSpaces, VDSBusTypeNVMe, VDSBusTypeScm, VDSBusTypeUfs, VDSBusTypeMaxReserved } VDS_STORAGE_BUS_TYPE;
[PInvokeData("vdslun.h", MSDNShortId = "NE:vdslun._VDS_STORAGE_BUS_TYPE")]
public enum VDS_STORAGE_BUS_TYPE
{
	/// <summary>This value is reserved.</summary>
	VDSBusTypeUnknown = 0,

	/// <summary>The storage bus type is SCSI.</summary>
	VDSBusTypeScsi,

	/// <summary>The storage bus type is ATAPI.</summary>
	VDSBusTypeAtapi,

	/// <summary>The storage bus type is ATA.</summary>
	VDSBusTypeAta,

	/// <summary>The storage bus type is IEEE 1394.</summary>
	VDSBusType1394,

	/// <summary>The storage bus type is SSA.</summary>
	VDSBusTypeSsa,

	/// <summary>The storage bus type is Fibre Channel.</summary>
	VDSBusTypeFibre,

	/// <summary>The storage bus type is USB.</summary>
	VDSBusTypeUsb,

	/// <summary>The storage bus type is RAID.</summary>
	VDSBusTypeRAID,

	/// <summary>The storage bus type is iSCSI.</summary>
	VDSBusTypeiScsi,

	/// <summary>The storage bus type is Serial Attached SCSI (SAS).</summary>
	VDSBusTypeSas,

	/// <summary>The storage bus type is SATA.</summary>
	VDSBusTypeSata,

	/// <summary>
	/// <para>The storage bus type is Secure Digital (SD).</para>
	/// <para>Windows Server 2008, Windows Vista and Windows Server 2003:</para>
	/// <para>Not supported.</para>
	/// </summary>
	VDSBusTypeSd,

	/// <summary>
	/// <para>The storage bus type is MultiMedia Card (MMC).</para>
	/// <para>Windows Server 2008, Windows Vista and Windows Server 2003:</para>
	/// <para>Not supported.</para>
	/// </summary>
	VDSBusTypeMmc,

	/// <summary>
	/// <para>This value is reserved for system use.</para>
	/// <para>Windows Server 2008, Windows Vista and Windows Server 2003:</para>
	/// <para>Not supported.</para>
	/// </summary>
	VDSBusTypeMax,

	/// <summary/>
	VDSBusTypeVirtual = 0xe,

	/// <summary>
	/// <para>The storage bus type is file-backed virtual.</para>
	/// <para>Windows Server 2008, Windows Vista and Windows Server 2003:</para>
	/// <para>Not supported.</para>
	/// </summary>
	VDSBusTypeFileBackedVirtual,

	/// <summary/>
	VDSBusTypeSpaces,

	/// <summary/>
	VDSBusTypeNVMe,

	/// <summary/>
	VDSBusTypeScm,

	/// <summary/>
	VDSBusTypeUfs,

	/// <summary>The maximum value of the storage bus type range.</summary>
	VDSBusTypeMaxReserved = 0x7f,
}

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines the set of the valid code sets (encodings) of a storage identifier.</para>
/// </summary>
/// <remarks>
/// <para>
/// The VDS_STORAGE_IDENTIFIER structure includes a <c>VDS_STORAGE_IDENTIFIER_CODE_SET</c> value as a member to indicate the code set of
/// a storage identifier.
/// </para>
/// <para>
/// <c>Note</c> Additional constants might be added to the <c>VDS_STORAGE_IDENTIFIER_CODE_SET</c> enumeration in future Windows
/// versions. For this reason, your application must be designed to gracefully handle an unrecognized
/// <c>VDS_STORAGE_IDENTIFIER_CODE_SET</c> enumeration constant.
/// </para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ne-vdslun-vds_storage_identifier_code_set typedef enum
// _VDS_STORAGE_IDENTIFIER_CODE_SET { VDSStorageIdCodeSetReserved, VDSStorageIdCodeSetBinary, VDSStorageIdCodeSetAscii,
// VDSStorageIdCodeSetUtf8 } VDS_STORAGE_IDENTIFIER_CODE_SET;
[PInvokeData("vdslun.h", MSDNShortId = "NE:vdslun._VDS_STORAGE_IDENTIFIER_CODE_SET")]
public enum VDS_STORAGE_IDENTIFIER_CODE_SET
{
	/// <summary>This value is reserved.</summary>
	VDSStorageIdCodeSetReserved = 0,

	/// <summary>The storage identifier is encoded as binary data.</summary>
	VDSStorageIdCodeSetBinary,

	/// <summary>The storage identifier is encoded as ASCII data.</summary>
	VDSStorageIdCodeSetAscii,

	/// <summary>
	/// <para>The storage identifier is encoded as UTF-8.</para>
	/// <para>Windows Vista and Windows Server 2003:</para>
	/// <para>Not supported before Windows Vista with SP1 and Windows Server 2008.</para>
	/// </summary>
	VDSStorageIdCodeSetUtf8,
}

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines the set of valid types for a storage identifier.</para>
/// </summary>
/// <remarks>
/// <para>
/// The VDS_STORAGE_IDENTIFIER structure includes a <c>VDS_STORAGE_IDENTIFIER_TYPE</c> value as a member to indicate the storage
/// identifier type.
/// </para>
/// <para>
/// <c>Note</c> Additional constants might be added to the <c>VDS_STORAGE_IDENTIFIER_TYPE</c> enumeration in future Windows versions.
/// For this reason, your application must be designed to gracefully handle an unrecognized <c>VDS_STORAGE_IDENTIFIER_TYPE</c>
/// enumeration constant.
/// </para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ne-vdslun-vds_storage_identifier_type typedef enum
// _VDS_STORAGE_IDENTIFIER_TYPE { VDSStorageIdTypeVendorSpecific, VDSStorageIdTypeVendorId, VDSStorageIdTypeEUI64,
// VDSStorageIdTypeFCPHName, VDSStorageIdTypePortRelative, VDSStorageIdTypeTargetPortGroup, VDSStorageIdTypeLogicalUnitGroup,
// VDSStorageIdTypeMD5LogicalUnitIdentifier, VDSStorageIdTypeScsiNameString } VDS_STORAGE_IDENTIFIER_TYPE;
[PInvokeData("vdslun.h", MSDNShortId = "NE:vdslun._VDS_STORAGE_IDENTIFIER_TYPE")]
public enum VDS_STORAGE_IDENTIFIER_TYPE
{
	/// <summary>The storage identifier type is vendor specific.</summary>
	VDSStorageIdTypeVendorSpecific = 0,

	/// <summary>The storage identifier is the same as the vendor identifier.</summary>
	VDSStorageIdTypeVendorId,

	/// <summary>The storage identifier type follows the IEEE 64-bit Extended Unique Identifier (EUI-64) standard.</summary>
	VDSStorageIdTypeEUI64,

	/// <summary>
	/// <para>The storage identifier type follows the Fibre Channel Physical and Signaling Interface (FC-PH) naming</para>
	/// <para>convention.</para>
	/// </summary>
	VDSStorageIdTypeFCPHName,

	/// <summary>
	/// <para>VDS 1.1:</para>
	/// <para>The storage identifier type is dependent on the port.</para>
	/// </summary>
	VDSStorageIdTypePortRelative,

	/// <summary/>
	VDSStorageIdTypeTargetPortGroup,

	/// <summary/>
	VDSStorageIdTypeLogicalUnitGroup,

	/// <summary/>
	VDSStorageIdTypeMD5LogicalUnitIdentifier,

	/// <summary/>
	VDSStorageIdTypeScsiNameString,
}

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines the address data of a physical interconnect.</para>
/// </summary>
/// <remarks>
/// The VDS_LUN_INFORMATION structure includes this structure as a member to specify an interconnect by which a LUN can be accessed.
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ns-vdslun-vds_interconnect typedef struct _VDS_INTERCONNECT {
// VDS_INTERCONNECT_ADDRESS_TYPE m_addressType; ULONG m_cbPort; BYTE *m_pbPort; ULONG m_cbAddress; BYTE *m_pbAddress; } VDS_INTERCONNECT;
[PInvokeData("vdslun.h", MSDNShortId = "NS:vdslun._VDS_INTERCONNECT")]
[StructLayout(LayoutKind.Sequential)]
public struct VDS_INTERCONNECT
{
	/// <summary>The interconnect address type enumerated by VDS_INTERCONNECT_ADDRESS_TYPE.</summary>
	public VDS_INTERCONNECT_ADDRESS_TYPE m_addressType;

	/// <summary>The size of the interconnect address data for the LUN port ( <c>m_pbPort</c>), in bytes.</summary>
	public uint m_cbPort;

	/// <summary>Pointer to the interconnect address data for the LUN port.</summary>
	public IntPtr m_pbPort;

	/// <summary>The size of the interconnect address data for the LUN ( <c>m_pbAddress</c>), in bytes.</summary>
	public uint m_cbAddress;

	/// <summary>Pointer to the interconnect address data for the LUN.</summary>
	public IntPtr m_pbAddress;
}

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines information about a LUN or disk. Applications can use this structure to uniquely identify a LUN at all times.</para>
/// </summary>
/// <remarks>
/// <para>
/// The <c>VDS_LUN_INFORMATION</c> structure includes fields from the SCSI Inquiry Data and Vital Product Data pages 0x80 and 0x83. The
/// <c>GetIdentificationData</c> method on both the IVdsLun and IVdsDisk interfaces return this structure. It is also passed as an
/// argument in the IVdsHwProviderPrivate::QueryIfCreatedLun method to determine whether a given provider owns a specified LUN.
/// </para>
/// <para>
/// To get the LUN object, use the IVdsService::GetObject method. You can then use the IVdsLun::GetProperties method to get the LUN properties.
/// </para>
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ns-vdslun-vds_lun_information typedef struct _VDS_LUN_INFORMATION { ULONG
// m_version; BYTE m_DeviceType; BYTE m_DeviceTypeModifier; BOOL m_bCommandQueueing; VDS_STORAGE_BUS_TYPE m_BusType; char *m_szVendorId;
// char *m_szProductId; char *m_szProductRevision; char *m_szSerialNumber; GUID m_diskSignature; VDS_STORAGE_DEVICE_ID_DESCRIPTOR
// m_deviceIdDescriptor; ULONG m_cInterconnects; VDS_INTERCONNECT *m_rgInterconnects; } VDS_LUN_INFORMATION;
[PInvokeData("vdslun.h", MSDNShortId = "NS:vdslun._VDS_LUN_INFORMATION")]
[StructLayout(LayoutKind.Sequential)]
public struct VDS_LUN_INFORMATION
{
	/// <summary></summary>
	public const uint VER_VDS_LUN_INFORMATION = 1;

	/// <summary>The version of this structure. The current value is the constant <c>VER_VDS_LUN_INFORMATION</c>.</summary>
	public uint m_version;

	/// <summary>The SCSI-2 device type of the LUN.</summary>
	public byte m_DeviceType;

	/// <summary>The SCSI-2 device type modifier of the LUN. For LUNs that have no device type modifier, the value is zero.</summary>
	public byte m_DeviceTypeModifier;

	/// <summary>
	/// If <c>TRUE</c>, the LUN supports multiple outstanding commands; otherwise, <c>FALSE</c>. The synchronization of the queue is the
	/// responsibility of the port driver.
	/// </summary>
	[MarshalAs(UnmanagedType.Bool)]
	public bool m_bCommandQueueing;

	/// <summary>The bus type of the LUN enumerated by VDS_STORAGE_BUS_TYPE.</summary>
	public VDS_STORAGE_BUS_TYPE m_BusType;

	/// <summary>
	/// Pointer to the LUN vendor identifier; a zero-terminated, human-readable string. For devices that have no vendor identifier, the
	/// value is zero.
	/// </summary>
	[MarshalAs(UnmanagedType.LPStr)]
	public string m_szVendorId;

	/// <summary>
	/// Pointer to the LUN product identifier, typically a model number; a zero-terminated, human-readable string. For devices that have
	/// no product identifier, the value is zero.
	/// </summary>
	[MarshalAs(UnmanagedType.LPStr)]
	public string m_szProductId;

	/// <summary>
	/// Pointer to the LUN product revision; a zero-terminated, human-readable string. For devices that have no product revision, the
	/// value is zero.
	/// </summary>
	[MarshalAs(UnmanagedType.LPStr)]
	public string m_szProductRevision;

	/// <summary>
	/// Pointer to the LUN serial number; a zero-terminated, human-readable string. For devices that have no serial number, the value is zero.
	/// </summary>
	[MarshalAs(UnmanagedType.LPStr)]
	public string m_szSerialNumber;

	/// <summary>
	/// The signature of the LUN. For disks that use the Master Boot Record (MBR) partitioning structure, the first 32 bits of the GUID
	/// comprise the disk signature, and the remaining bits are zeros. For disks that use the GUID Partition Table (GPT) partitioning
	/// structure, the GUID consists of the GPT disk identifier. If this value is zero, the disk is uninitialized or the hardware
	/// provider was unable to retrieve the signature.
	/// </summary>
	public Guid m_diskSignature;

	/// <summary>
	/// Array containing the LUN descriptor in various formats, such as "VDSStorageIdTypeFCPHName" and "VDSStorageIdTypeVendorSpecific".
	/// Providers can use "VDSStorageIdTypeVendorSpecific" to store an arbitrary byte string of the vendor's choosing to uniquely
	/// identify the LUN. See the VDS_STORAGE_DEVICE_ID_DESCRIPTOR structure and the VDS_STORAGE_IDENTIFIER structure.
	/// </summary>
	public VDS_STORAGE_DEVICE_ID_DESCRIPTOR m_deviceIdDescriptor;

	/// <summary>The number of interconnect ports specified in <c>m_rgInterconnects</c>.</summary>
	public uint m_cInterconnects;

	/// <summary>
	/// Pointer to an array of the interconnect ports by which the LUN can be accessed. See the <see cref="VDS_INTERCONNECT"/> structure.
	/// </summary>
	public IntPtr m_rgInterconnects;
}

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines one or more storage identifiers for a storage device (typically an instance, as opposed to a class, of device).</para>
/// </summary>
/// <remarks>
/// Storage devices can have multiple identifiers, and each of these identifiers can have a different code set and type. The
/// VDS_LUN_INFORMATION structure includes this structure as a member to specify the storage device identifiers of a LUN.
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ns-vdslun-vds_storage_device_id_descriptor typedef struct
// _VDS_STORAGE_DEVICE_ID_DESCRIPTOR { ULONG m_version; ULONG m_cIdentifiers; VDS_STORAGE_IDENTIFIER *m_rgIdentifiers; } VDS_STORAGE_DEVICE_ID_DESCRIPTOR;
[PInvokeData("vdslun.h", MSDNShortId = "NS:vdslun._VDS_STORAGE_DEVICE_ID_DESCRIPTOR")]
[StructLayout(LayoutKind.Sequential)]
public struct VDS_STORAGE_DEVICE_ID_DESCRIPTOR
{
	/// <summary>The version of this structure.</summary>
	public uint m_version;

	/// <summary>The number of identifiers specified in <c>m_rgIdentifiers</c>.</summary>
	public uint m_cIdentifiers;

	/// <summary>Pointer to <see cref="VDS_STORAGE_IDENTIFIER"/> structure.</summary>
	public IntPtr m_rgIdentifiers;
}

/// <summary>
/// <para>
/// [Beginning with Windows 8 and Windows Server 2012, the Virtual Disk Service COM interface is superseded by the Windows Storage
/// Management API.]
/// </para>
/// <para>Defines a storage device using a particular code set and type.</para>
/// </summary>
/// <remarks>
/// The VDS_STORAGE_DEVICE_ID_DESCRIPTOR structure includes this structure as a member to specify a particular storage device identifier
/// for a LUN.
/// </remarks>
// https://docs.microsoft.com/en-us/windows/win32/api/vdslun/ns-vdslun-vds_storage_identifier typedef struct _VDS_STORAGE_IDENTIFIER {
// VDS_STORAGE_IDENTIFIER_CODE_SET m_CodeSet; VDS_STORAGE_IDENTIFIER_TYPE m_Type; ULONG m_cbIdentifier; BYTE *m_rgbIdentifier; } VDS_STORAGE_IDENTIFIER;
[PInvokeData("vdslun.h", MSDNShortId = "NS:vdslun._VDS_STORAGE_IDENTIFIER")]
[StructLayout(LayoutKind.Sequential)]
public struct VDS_STORAGE_IDENTIFIER
{
	/// <summary>The encoding type of <c>m_rgbIdentifier</c> enumerated by VDS_STORAGE_IDENTIFIER_CODE_SET.</summary>
	public VDS_STORAGE_IDENTIFIER_CODE_SET m_CodeSet;

	/// <summary>The type of <c>m_rgbIdentifier</c> enumerated by VDS_STORAGE_IDENTIFIER_TYPE.</summary>
	public VDS_STORAGE_IDENTIFIER_TYPE m_Type;

	/// <summary>The size of the <c>m_rgbIdentifier</c> array, in bytes.</summary>
	public uint m_cbIdentifier;

	/// <summary>Pointer to the identifier data.</summary>
	public IntPtr m_rgbIdentifier;
}