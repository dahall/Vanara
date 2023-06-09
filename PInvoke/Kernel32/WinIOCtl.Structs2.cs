using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/*
	https://docs.microsoft.com/en-us/windows/win32/api/winioctl/
	*/

	/// <summary/>
	public const uint CSV_NAMESPACE_INFO_V1 = 24;

	/// <summary/>
	public const int FILE_STORAGE_TIER_DESCRIPTION_LENGTH = 512;

	/// <summary/>
	public const int FILE_STORAGE_TIER_NAME_LENGTH = 256;

	/// <summary/>
	public const int MAX_VOLUME_ID_SIZE = 36;

	/// <summary/>
	public const int MAX_VOLUME_TEMPLATE_SIZE = 40;

	/// <summary/>
	public const int PRODUCT_ID_LENGTH = 16;

	/// <summary/>
	public const ushort REQUEST_OPLOCK_CURRENT_VERSION = 1;

	/// <summary/>
	public const int REVISION_LENGTH = 4;

	/// <summary/>
	public const int SERIAL_NUMBER_LENGTH = 32;

	/// <summary/>
	public const int STORAGE_OFFLOAD_TOKEN_ID_LENGTH = 0x1f8;

	/// <summary>
	/// The <c>Token</c> member uses a well-known format. The first two bytes of the <c>Token</c> member are a 16-bit unsigned integer
	/// that describes the region. The possible values are either <c>STORAGE_OFFLOAD_PATTERN_ZERO</c> or
	/// <c>STORAGE_OFFLOAD_PATTERN_ZERO_WITH_PROTECTION_INFO</c>. <c>STORAGE_OFFLOAD_PATTERN_ZERO</c> (0x0001) is a well-known token
	/// that indicates that the region represented has all bits set to zero. <c>STORAGE_OFFLOAD_PATTERN_ZERO_WITH_PROTECTION_INFO</c> is
	/// a well-known token that indicates that the data in the region represented has all bits set to zero and the corresponding
	/// protection information is valid.
	/// </summary>
	public const uint STORAGE_OFFLOAD_TOKEN_TYPE_WELL_KNOWN = 0xFFFFFFFF;

	/// <summary/>
	public const uint STORAGE_PROTOCOL_STRUCTURE_VERSION = 0x1;

	/// <summary/>
	public const uint STORAGE_RPMB_DESCRIPTOR_VERSION_1 = 1;

	/// <summary>The file is not a transacted file.</summary>
	public const uint TXFS_TRANSACTED_VERSION_NONTRANSACTED = 0xFFFFFFFE;

	/// <summary>The file has been opened as a transacted writer.</summary>
	public const uint TXFS_TRANSACTED_VERSION_UNCOMMITTED = 0xFFFFFFFF;

	/// <summary/>
	public const int VENDOR_ID_LENGTH = 8;

	/// <summary>Represents the status of the specified element.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_element_status typedef struct
	// _CHANGER_ELEMENT_STATUS { CHANGER_ELEMENT Element; CHANGER_ELEMENT SrcElementAddress; DWORD Flags; DWORD ExceptionCode; BYTE
	// TargetId; BYTE Lun; WORD Reserved; BYTE PrimaryVolumeID[MAX_VOLUME_ID_SIZE]; BYTE AlternateVolumeID[MAX_VOLUME_ID_SIZE]; }
	// CHANGER_ELEMENT_STATUS, *PCHANGER_ELEMENT_STATUS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_ELEMENT_STATUS")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CHANGER_ELEMENT_STATUS
	{
		/// <summary>A CHANGER_ELEMENT structure that represents the element.</summary>
		public CHANGER_ELEMENT Element;

		/// <summary>
		/// <para>
		/// A CHANGER_ELEMENT structure that represents the element from which the media currently in this element was most recently moved.
		/// </para>
		/// <para>This member is valid only if the <c>Flags</c> member includes ELEMENT_STATUS_SVALID.</para>
		/// </summary>
		public CHANGER_ELEMENT SrcElementAddress;

		/// <summary>
		/// <para>The element status. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ELEMENT_STATUS_ACCESS 0x00000008</term>
		/// <term>
		/// The changer's transport element can access the piece of media in this element. The media is not accessible in the following
		/// circumstances: (1) If the element type is ChangerSlot, the slot is not present in the changer (for example, the magazine
		/// containing the slot has been physically removed). (2) If the element type is ChangerDrive, the drive is broken or has been
		/// removed. (3) If the element type is ChangerIEPort, the changer's insert/eject port is extended.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_AVOLTAG 0x20000000</term>
		/// <term>Alternate volume information in the AlternateVolumeID member is valid.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_EXCEPT 0x00000004</term>
		/// <term>The element is in an abnormal state. Check the ExceptionCode member for more information.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_EXENAB 0x00000010</term>
		/// <term>The element supports export of media through the changer's insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_FULL 0x00000001</term>
		/// <term>
		/// The element contains a piece of media. Note that this value is valid only if the element type is ChangerDrive, ChangerSlot,
		/// or ChangerTransport. If ElementType is ChangerIEPort, this value is valid only if the Features0 member of
		/// GET_CHANGER_PARAMETERS includes CHANGER_REPORT_IEPORT_STATE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_ID_VALID 0x00002000</term>
		/// <term>The SCSI target ID in the TargetID member is valid. This value is valid only if the element type is ChangerDrive.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_IMPEXP 0x00000002</term>
		/// <term>The media in this element was placed there by an operator. This value is valid only if the element type is ChangerIEPort.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_INENAB 0x00000020</term>
		/// <term>The element supports import of media through the changer's insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_INVERT 0x00400000</term>
		/// <term>The media in the element was flipped. This value is valid only if ELEMENT_STATUS_SVALID is also included.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_LUN_VALID 0x00001000</term>
		/// <term>The logical unit number in the Lun member is valid. This value is valid only if the element type is ChangerDrive.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_NOT_BUS 0x00008000</term>
		/// <term>The drive at the address indicated by Lun and TargetID is on a different SCSI bus than the changer itself.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_PVOLTAG 0x10000000</term>
		/// <term>Primary volume information in the PrimaryVolumeID member is valid.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_SVALID 0x00800000</term>
		/// <term>The SourceElement member and ELEMENT_STATUS_INVERT are both valid.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ELEMENT_STATUS Flags;

		/// <summary>
		/// <para>
		/// An exception code that indicates that the element is in an abnormal state. This member is valid only if the <c>Flags</c>
		/// member includes ELEMENT_STATUS_EXCEPT. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_DRIVE_NOT_INSTALLED 0x00000008</term>
		/// <term>The drive at this element address is absent.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_LABEL_QUESTIONABLE 0x00000002</term>
		/// <term>The label might be invalid due to a unit attention condition.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_LABEL_UNREADABLE 0x00000001</term>
		/// <term>
		/// The changer's barcode reader could not read the bar code label on the piece of media in this element, because the media is
		/// missing, damaged, improperly positioned, or upside down.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_SLOT_NOT_PRESENT 0x00000004</term>
		/// <term>
		/// The slot at this element address is currently not installed in the changer. Each slot in a removable magazine is reported
		/// not present to indicate that the magazine has been removed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_TRAY_MALFUNCTION 0x00000010</term>
		/// <term>
		/// The drive at this element address has a tray that must be extended to load or remove media, and the tray is not extending as required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNHANDLED_ERROR 0xFFFFFFFF</term>
		/// <term>Unknown error condition.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ELEMENT_ERROR ExceptionCode;

		/// <summary>
		/// For a SCSI changer, specifies the SCSI target ID of the drive at this element address. This member is valid only if the
		/// <c>ElementType</c> member of the <c>Element</c> structure is ChangerDrive and the <c>Flags</c> member includes ELEMENT_STATUS_ID_VALID.
		/// </summary>
		public byte TargetId;

		/// <summary>
		/// The SCSI logical unit number of the drive at this element address. This member is valid only if the <c>ElementType</c>
		/// member of the <c>Element</c> structure is ChangerDrive and the <c>Flags</c> member includes ELEMENT_STATUS_LUN_VALID.
		/// </summary>
		public byte Lun;

		/// <summary>Reserved for future use. The value of this member must be zero.</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>
		/// The primary volume identifier for the media. If the changer supports a barcode reader and the reader is installed (as
		/// indicated by CHANGER_BAR_CODE_SCANNER_INSTALLED in the <c>Features0</c> member of GET_CHANGER_PARAMETERS),
		/// <c>PrimaryVolumeID</c> is the bar code of the media. If the changer does not support a barcode reader,
		/// <c>PrimaryVolumeID</c> is the value previously assigned to the media.
		/// </para>
		/// <para>This member is valid only if the <c>Flags</c> member includes ELEMENT_STATUS_PVOLTAG.</para>
		/// <para>If the volume identifier is missing or unreadable, this member is cleared.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_VOLUME_ID_SIZE)]
		public string PrimaryVolumeID;

		/// <summary>
		/// <para>
		/// An alternate volume identification for the media. This member is valid only for two-sided media, and pertains to the ID of
		/// the inverted side. It never represents a bar code.
		/// </para>
		/// <para>This member is valid only if the <c>Flags</c> member includes ELEMENT_STATUS_AVOLTAG.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_VOLUME_ID_SIZE)]
		public string AlternateVolumeID;
	}

	/// <summary>Represents the status of the specified element.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_element_status_ex typedef struct
	// _CHANGER_ELEMENT_STATUS_EX { CHANGER_ELEMENT Element; CHANGER_ELEMENT SrcElementAddress; DWORD Flags; DWORD ExceptionCode; BYTE
	// TargetId; BYTE Lun; WORD Reserved; BYTE PrimaryVolumeID[MAX_VOLUME_ID_SIZE]; BYTE AlternateVolumeID[MAX_VOLUME_ID_SIZE]; BYTE
	// VendorIdentification[VENDOR_ID_LENGTH]; BYTE ProductIdentification[PRODUCT_ID_LENGTH]; BYTE SerialNumber[SERIAL_NUMBER_LENGTH]; }
	// CHANGER_ELEMENT_STATUS_EX, *PCHANGER_ELEMENT_STATUS_EX;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_ELEMENT_STATUS_EX")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CHANGER_ELEMENT_STATUS_EX
	{
		/// <summary>A CHANGER_ELEMENT structure that represents the element to which this structure refers.</summary>
		public CHANGER_ELEMENT Element;

		/// <summary>
		/// <para>
		/// A CHANGER_ELEMENT structure that represents the element from which the media currently in this element was most recently moved.
		/// </para>
		/// <para>This member is valid only if the <c>Flags</c> member includes ELEMENT_STATUS_SVALID.</para>
		/// </summary>
		public CHANGER_ELEMENT SrcElementAddress;

		/// <summary>
		/// <para>The element status. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ELEMENT_STATUS_ACCESS 0x00000008</term>
		/// <term>
		/// The changer's transport element can access the piece of media in this element. The media is not accessible in the following
		/// circumstances: (1) If the element type is ChangerSlot, the slot is not present in the changer (for example, the magazine
		/// containing the slot has been physically removed). (2) If the element type is ChangerDrive, the drive is broken or has been
		/// removed. (3) If the element type is ChangerIEPort, the changer's insert/eject port is extended.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_AVOLTAG 0x20000000</term>
		/// <term>Alternate volume information in the AlternateVolumeID member is valid.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_EXCEPT 0x00000004</term>
		/// <term>The element is in an abnormal state. Check the ExceptionCode member for more information.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_EXENAB 0x00000010</term>
		/// <term>The element supports export of media through the changer's insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_FULL 0x00000001</term>
		/// <term>
		/// The element contains a piece of media. Note that this value is valid only if the element type is ChangerDrive, ChangerSlot,
		/// or ChangerTransport. If the element type is ChangerIEPort, this value is valid only if the Features0 member of
		/// GET_CHANGER_PARAMETERS includes CHANGER_REPORT_IEPORT_STATE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_ID_VALID 0x00002000</term>
		/// <term>The SCSI target ID in the TargetID member is valid. This value is valid only if the element type is ChangerDrive.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_IMPEXP 0x00000002</term>
		/// <term>The media in this element was placed there by an operator. This value is valid only if the element type is ChangerIEPort.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_INENAB 0x00000020</term>
		/// <term>The element supports import of media through the changer's insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_INVERT 0x00400000</term>
		/// <term>The media in the element was flipped. This value is valid only if ELEMENT_STATUS_SVALID is also included.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_LUN_VALID 0x00001000</term>
		/// <term>The logical unit number in the Lun member is valid. This value is valid only if the element type is ChangerDrive.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_NOT_BUS 0x00008000</term>
		/// <term>The drive at the address indicated by Lun and TargetID is on a different SCSI bus than the changer itself.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_PRODUCT_DATA 0x00000040</term>
		/// <term>The serial number in the SerialNumber member is valid.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_PVOLTAG 0x10000000</term>
		/// <term>Primary volume information in the PrimaryVolumeID member is valid.</term>
		/// </item>
		/// <item>
		/// <term>ELEMENT_STATUS_SVALID 0x00800000</term>
		/// <term>The SourceElement member and ELEMENT_STATUS_INVERT are both valid.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ELEMENT_STATUS Flags;

		/// <summary>
		/// <para>
		/// An exception code that indicates that the element is in an abnormal state. This member is valid only if the <c>Flags</c>
		/// member includes ELEMENT_STATUS_EXCEPT. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ERROR_DRIVE_NOT_INSTALLED 0x00000008</term>
		/// <term>The drive at this element address is absent.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_INIT_STATUS_NEEDED 0x00000011</term>
		/// <term>An Initialize Element Status command is needed.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_LABEL_QUESTIONABLE 0x00000002</term>
		/// <term>The label might be invalid due to a unit attention condition.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_LABEL_UNREADABLE 0x00000001</term>
		/// <term>
		/// The changer's barcode reader could not read the bar code label on the piece of media in this element, because the media is
		/// missing, damaged, improperly positioned, or upside down.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_SLOT_NOT_PRESENT 0x00000004</term>
		/// <term>
		/// The slot at this element address is currently not installed in the changer. Each slot in a removable magazine is reported
		/// not present to indicate that the magazine has been removed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_TRAY_MALFUNCTION 0x00000010</term>
		/// <term>
		/// The drive at this element address has a tray that must be extended to load or remove media, and the tray is not extending as required.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ERROR_UNHANDLED_ERROR 0xFFFFFFFF</term>
		/// <term>Unknown error condition.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ELEMENT_ERROR ExceptionCode;

		/// <summary>
		/// For a SCSI changer, specifies the SCSI target ID of the drive at this element address. This member is valid only if the
		/// <c>ElementType</c> member of the <c>Element</c> structure is ChangerDrive and the <c>Flags</c> member includes ELEMENT_STATUS_ID_VALID.
		/// </summary>
		public byte TargetId;

		/// <summary>
		/// The SCSI logical unit number of the drive at this element address. This member is valid only if the <c>ElementType</c>
		/// member of the <c>Element</c> structure is ChangerDrive and the <c>Flags</c> member includes ELEMENT_STATUS_LUN_VALID.
		/// </summary>
		public byte Lun;

		/// <summary>Reserved for future use. The value of this member must be zero.</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>
		/// The primary volume identifier for the media. If the changer supports a barcode reader and the reader is installed (as
		/// indicated by CHANGER_BAR_CODE_SCANNER_INSTALLED in the <c>Features0</c> member of GET_CHANGER_PARAMETERS),
		/// <c>PrimaryVolumeID</c> is the bar code of the media. If the changer does not support a barcode reader,
		/// <c>PrimaryVolumeID</c> is the value previously assigned to the media.
		/// </para>
		/// <para>This member is valid only if the <c>Flags</c> member includes ELEMENT_STATUS_PVOLTAG.</para>
		/// <para>If the volume identifier is missing or unreadable, this member is cleared.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_VOLUME_ID_SIZE)]
		public string PrimaryVolumeID;

		/// <summary>
		/// <para>
		/// An alternate volume identification for the media. This member is valid for two-sided media only, and pertains to the ID of
		/// the inverted side. It never represents a bar code.
		/// </para>
		/// <para>This member is valid only if the <c>Flags</c> member includes ELEMENT_STATUS_AVOLTAG.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_VOLUME_ID_SIZE)]
		public string AlternateVolumeID;

		/// <summary>The vendor identifier.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = VENDOR_ID_LENGTH)]
		public string VendorIdentification;

		/// <summary>The product identifier.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = PRODUCT_ID_LENGTH)]
		public string ProductIdentification;

		/// <summary>The serial number for the drive.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SERIAL_NUMBER_LENGTH)]
		public string SerialNumber;
	}

	/// <summary>
	/// Contains information the IOCTL_CHANGER_EXCHANGE_MEDIUM control code uses to move a piece of media to a destination, and the
	/// piece of media originally in the first destination to a second destination.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_exchange_medium typedef struct
	// _CHANGER_EXCHANGE_MEDIUM { CHANGER_ELEMENT Transport; CHANGER_ELEMENT Source; CHANGER_ELEMENT Destination1; CHANGER_ELEMENT
	// Destination2; BOOLEAN Flip1; BOOLEAN Flip2; } CHANGER_EXCHANGE_MEDIUM, *PCHANGER_EXCHANGE_MEDIUM;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_EXCHANGE_MEDIUM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHANGER_EXCHANGE_MEDIUM
	{
		/// <summary>
		/// A CHANGER_ELEMENT structure that indicates which transport element to use for the exchange operation. The <c>ElementType</c>
		/// member of this structure must be ChangerTransport.
		/// </summary>
		public CHANGER_ELEMENT Transport;

		/// <summary>A CHANGER_ELEMENT structure that indicates the element that contains the media that is to be moved.</summary>
		public CHANGER_ELEMENT Source;

		/// <summary>A CHANGER_ELEMENT structure that indicates the element that is the destination of the media originally at <c>Source</c>.</summary>
		public CHANGER_ELEMENT Destination1;

		/// <summary>A CHANGER_ELEMENT structure that indicates the element that is the destination of the media originally at <c>Destination1</c>.</summary>
		public CHANGER_ELEMENT Destination2;

		/// <summary>
		/// If this member is <c>TRUE</c>, the medium at <c>Destination1</c> should be flipped. Otherwise, it should not. This member is
		/// valid only if the <c>Features0</c> member of the GET_CHANGER_PARAMETERS structure is CHANGER_MEDIUM_FLIP.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool Flip1;

		/// <summary>
		/// If this member is <c>TRUE</c>, the medium at <c>Destination2</c> should be flipped. Otherwise, it should not. This member is
		/// valid only if the <c>Features0</c> member of the GET_CHANGER_PARAMETERS structure is CHANGER_MEDIUM_FLIP.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool Flip2;
	}

	/// <summary>Represents the status of all media changer elements or the specified elements of a particular type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_initialize_element_status typedef struct
	// _CHANGER_INITIALIZE_ELEMENT_STATUS { CHANGER_ELEMENT_LIST ElementList; BOOLEAN BarCodeScan; } CHANGER_INITIALIZE_ELEMENT_STATUS, *PCHANGER_INITIALIZE_ELEMENT_STATUS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_INITIALIZE_ELEMENT_STATUS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHANGER_INITIALIZE_ELEMENT_STATUS
	{
		/// <summary>
		/// <para>A CHANGER_ELEMENT_LIST structure that lists the elements and range on which to initialize.</para>
		/// <para>
		/// If CHANGER_INIT_ELEM_STAT_WITH_RANGE is set in the <c>Features0</c> member of GET_CHANGER_PARAMETERS, the changer supports
		/// initializing a range of elements. In this case, the <c>ElementType</c> member can be one of the following: ChangerTransport,
		/// ChangerSlot, ChangerDrive, or ChangerIEPort. Otherwise, the element type must be AllElements and the <c>NumberOfElements</c>
		/// member is ignored.
		/// </para>
		/// </summary>
		public CHANGER_ELEMENT_LIST ElementList;

		/// <summary>
		/// <para>
		/// If this member is <c>TRUE</c>, a bar-code scan should be used. Otherwise, it should not. If the changer has nonvolatile RAM,
		/// using a bar-code scan is an optimization.
		/// </para>
		/// <para>This member is applicable only if CHANGER_BAR_CODE_SCANNER_INSTALLED is set in the <c>Features0</c> member of GET_CHANGER_PARAMETERS.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool BarCodeScan;
	}

	/// <summary>Contains information that the IOCTL_CHANGER_MOVE_MEDIUM control code uses to move a piece of media to a destination.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_move_medium typedef struct _CHANGER_MOVE_MEDIUM {
	// CHANGER_ELEMENT Transport; CHANGER_ELEMENT Source; CHANGER_ELEMENT Destination; BOOLEAN Flip; } CHANGER_MOVE_MEDIUM, *PCHANGER_MOVE_MEDIUM;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_MOVE_MEDIUM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHANGER_MOVE_MEDIUM
	{
		/// <summary>A CHANGER_ELEMENT structure that indicates which transport element to use for the move operation.</summary>
		public CHANGER_ELEMENT Transport;

		/// <summary>A CHANGER_ELEMENT structure that indicates the element that contains the media that is to be moved.</summary>
		public CHANGER_ELEMENT Source;

		/// <summary>A CHANGER_ELEMENT structure that indicates the element that is the destination of the media originally at <c>Source</c>.</summary>
		public CHANGER_ELEMENT Destination;

		/// <summary>
		/// If this member is <c>TRUE</c>, the media should be flipped. Otherwise, it should not. This member is valid only if the
		/// <c>Features0</c> member of the GET_CHANGER_PARAMETERS structure is CHANGER_MEDIUM_FLIP.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool Flip;
	}

	/// <summary>Represents product data for a changer device. It is used by the IOCTL_CHANGER_GET_PRODUCT_DATA control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_product_data typedef struct _CHANGER_PRODUCT_DATA
	// { BYTE VendorId[VENDOR_ID_LENGTH]; BYTE ProductId[PRODUCT_ID_LENGTH]; BYTE Revision[REVISION_LENGTH]; BYTE
	// SerialNumber[SERIAL_NUMBER_LENGTH]; BYTE DeviceType; } CHANGER_PRODUCT_DATA, *PCHANGER_PRODUCT_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_PRODUCT_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CHANGER_PRODUCT_DATA
	{
		/// <summary>The device manufacturer's name. This is acquired directly from the device inquiry data.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = VENDOR_ID_LENGTH)]
		public string VendorId;

		/// <summary>The product identification, as defined by the vendor. This is acquired directly from the device inquiry data.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = PRODUCT_ID_LENGTH)]
		public string ProductId;

		/// <summary>The product revision, as defined by the vendor.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = REVISION_LENGTH)]
		public string Revision;

		/// <summary>A unique value used to globally identify this device, as defined by the vendor.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = SERIAL_NUMBER_LENGTH)]
		public string SerialNumber;

		/// <summary>The device type of data transports, as defined by SCSI-2. This member must be <c>FILE_DEVICE_CHANGER</c>.</summary>
		public byte DeviceType;
	}

	/// <summary>
	/// Contains information that the IOCTL_CHANGER_GET_ELEMENT_STATUS control code needs to determine the elements whose status is to
	/// be retrieved.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_read_element_status typedef struct
	// _CHANGER_READ_ELEMENT_STATUS { CHANGER_ELEMENT_LIST ElementList; BOOLEAN VolumeTagInfo; } CHANGER_READ_ELEMENT_STATUS, *PCHANGER_READ_ELEMENT_STATUS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_READ_ELEMENT_STATUS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHANGER_READ_ELEMENT_STATUS
	{
		/// <summary>
		/// A CHANGER_ELEMENT_LIST structure that contains an array of structures that represents the range of elements for which
		/// information is to be retrieved. The <c>ElementType</c> member of each structure can be one of the following values:
		/// ChangerDrive, ChangerSlot, ChangerTransport, ChangerIEPort, or AllElements.
		/// </summary>
		public CHANGER_ELEMENT_LIST ElementList;

		/// <summary>
		/// If this member is <c>TRUE</c>, volume tag information is to be retrieved. Otherwise, no volume information is retrieved. A
		/// volume tag can be a bar code or an application-defined value. This member is valid only if the <c>Features0</c> member of
		/// the GET_CHANGER_PARAMETERS structure is CHANGER_BAR_CODE_SCANNER_INSTALLED or CHANGER_VOLUME_IDENTIFICATION.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool VolumeTagInfo;
	}

	/// <summary>
	/// Contains information that the IOCTL_CHANGER_QUERY_VOLUME_TAGS control code uses to determine the volume information to be retrieved.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_send_volume_tag_information typedef struct
	// _CHANGER_SEND_VOLUME_TAG_INFORMATION { CHANGER_ELEMENT StartingElement; DWORD ActionCode; BYTE
	// VolumeIDTemplate[MAX_VOLUME_TEMPLATE_SIZE]; } CHANGER_SEND_VOLUME_TAG_INFORMATION, *PCHANGER_SEND_VOLUME_TAG_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_SEND_VOLUME_TAG_INFORMATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CHANGER_SEND_VOLUME_TAG_INFORMATION
	{
		/// <summary>A CHANGER_ELEMENT structure that represents the starting element for which information is to be retrieved.</summary>
		public CHANGER_ELEMENT StartingElement;

		/// <summary>
		/// <para>The action to be performed.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ASSERT_ALTERNATE 0x9</term>
		/// <term>Define the alternate volume tag of a volume that currently has none defined. Requires that Features0 is CHANGER_VOLUME_ASSERT.</term>
		/// </item>
		/// <item>
		/// <term>ASSERT_PRIMARY 0x8</term>
		/// <term>Define the primary volume tag of a volume that currently has none defined. Requires that Features0 is CHANGER_VOLUME_ASSERT.</term>
		/// </item>
		/// <item>
		/// <term>REPLACE_ALTERNATE 0xB</term>
		/// <term>Replace the alternate volume tag with a new tag. Requires that Features0 is CHANGER_VOLUME_REPLACE.</term>
		/// </item>
		/// <item>
		/// <term>REPLACE_PRIMARY 0xA</term>
		/// <term>Replace the primary volume tag with a new tag. Requires that Features0 is CHANGER_VOLUME_REPLACE.</term>
		/// </item>
		/// <item>
		/// <term>SEARCH_ALL 0x0</term>
		/// <term>Search all defined volume tags. Requires that Features0 is CHANGER_VOLUME_SEARCH.</term>
		/// </item>
		/// <item>
		/// <term>SEARCH_ALL_NO_SEQ 0x4</term>
		/// <term>Search all defined volume tags, but ignore sequence numbers. Requires that Features0 is CHANGER_VOLUME_SEARCH.</term>
		/// </item>
		/// <item>
		/// <term>SEARCH_ALT_NO_SEQ 0x6</term>
		/// <term>Search only alternate volume tags, but ignore sequence numbers. Requires that Features0 is CHANGER_VOLUME_SEARCH.</term>
		/// </item>
		/// <item>
		/// <term>SEARCH_ALTERNATE 02</term>
		/// <term>Search only alternate volume tags. Requires that Features0 is CHANGER_VOLUME_SEARCH.</term>
		/// </item>
		/// <item>
		/// <term>SEARCH_PRI_NO_SEQ 05</term>
		/// <term>Search only primary volume tags but ignore sequence numbers. Requires that Features0 is CHANGER_VOLUME_SEARCH.</term>
		/// </item>
		/// <item>
		/// <term>SEARCH_PRIMARY 0x1</term>
		/// <term>Search only primary volume tags. Requires that Features0 is CHANGER_VOLUME_SEARCH.</term>
		/// </item>
		/// <item>
		/// <term>UNDEFINE_ALTERNATE 0xD</term>
		/// <term>Clear the alternate volume tag. Requires that Features0 is CHANGER_VOLUME_UNDEFINE.</term>
		/// </item>
		/// <item>
		/// <term>UNDEFINE_PRIMARY 0xC</term>
		/// <term>Clear the primary volume tag. Requires that Features0 is CHANGER_VOLUME_UNDEFINE.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ChangerActionCode ActionCode;

		/// <summary>
		/// The template that the device uses to search for volume IDs. For search operations, the template can include wildcard
		/// characters to search for volumes that match the template. Supported wildcard characters include the asterisk (*) and
		/// question mark (?). For other operations, the template must specify a single volume.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_VOLUME_TEMPLATE_SIZE)]
		public string VolumeIDTemplate;
	}

	/// <summary>
	/// Contains information that the IOCTL_CHANGER_SET_ACCESS control code needs to set the state of the device's insert/eject port,
	/// door, or keypad.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_set_access typedef struct _CHANGER_SET_ACCESS {
	// CHANGER_ELEMENT Element; DWORD Control; } CHANGER_SET_ACCESS, *PCHANGER_SET_ACCESS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_SET_ACCESS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHANGER_SET_ACCESS
	{
		/// <summary>
		/// A CHANGER_ELEMENT structure that represents the changer element. The <c>ElementType</c> member can be one of the following
		/// values: ChangerDoor, ChangerIEPort, or ChangerKeypad.
		/// </summary>
		public CHANGER_ELEMENT Element;

		/// <summary>
		/// <para>The operation to be performed.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>EXTEND_IEPORT 2</term>
		/// <term>The element is to be extended. Requires that Features0 is CHANGER_OPEN_IEPORT.</term>
		/// </item>
		/// <item>
		/// <term>LOCK_ELEMENT 0</term>
		/// <term>The element is to be locked. Requires that Features0 is CHANGER_LOCK_UNLOCK.</term>
		/// </item>
		/// <item>
		/// <term>RETRACT_IEPORT 3</term>
		/// <term>The element is to be retracted. Requires that Features0 is CHANGER_CLOSE_IEPORT.</term>
		/// </item>
		/// <item>
		/// <term>UNLOCK_ELEMENT 1</term>
		/// <term>The element is to be unlocked. Requires that Features0 is CHANGER_LOCK_UNLOCK.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CHANGER_SET_ACCESS_OP Control;
	}

	/// <summary>
	/// Contains information needed by the IOCTL_CHANGER_SET_POSITION control code to set the changer's robotic transport mechanism to
	/// the specified element address.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-changer_set_position typedef struct _CHANGER_SET_POSITION
	// { CHANGER_ELEMENT Transport; CHANGER_ELEMENT Destination; BOOLEAN Flip; } CHANGER_SET_POSITION, *PCHANGER_SET_POSITION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CHANGER_SET_POSITION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CHANGER_SET_POSITION
	{
		/// <summary>
		/// A CHANGER_ELEMENT structure that indicates the transport to be moved. The <c>ElementType</c> member must be ChangerTransport.
		/// </summary>
		public CHANGER_ELEMENT Transport;

		/// <summary>
		/// A CHANGER_ELEMENT structure that indicates the final destination of the transport. The <c>ElementType</c> member must be one
		/// of the following values: ChangerSlot, ChangerDrive, or ChangerIEPort.
		/// </summary>
		public CHANGER_ELEMENT Destination;

		/// <summary>
		/// If this member is <c>TRUE</c>, the media currently carried by <c>Transport</c> should be flipped. Otherwise, it should not.
		/// This member is valid only if the <c>Features0</c> member of the GET_CHANGER_PARAMETERS structure is CHANGER_MEDIUM_FLIP.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool Flip;
	}

	/// <summary>Contains information associated with a media change event.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-class_media_change_context typedef struct
	// _CLASS_MEDIA_CHANGE_CONTEXT { DWORD MediaChangeCount; DWORD NewState; } CLASS_MEDIA_CHANGE_CONTEXT, *PCLASS_MEDIA_CHANGE_CONTEXT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CLASS_MEDIA_CHANGE_CONTEXT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLASS_MEDIA_CHANGE_CONTEXT
	{
		/// <summary>The number of times that media has been changed since system startup.</summary>
		public uint MediaChangeCount;

		/// <summary>
		/// <para>
		/// The state information. This member can be one of the following values from the <c>MEDIA_CHANGE_DETECTION_STATE</c>
		/// enumeration type.
		/// </para>
		/// <para>MediaUnknown (0)</para>
		/// <para>MediaPresent (1)</para>
		/// <para>MediaNotPresent (2)</para>
		/// <para>MediaUnavailable (3)</para>
		/// </summary>
		public MEDIA_CHANGE_DETECTION_STATE NewState;
	}

	/// <summary>Represents a type of CSV control operation.</summary>
	/// <remarks>
	/// This structure is used with the FSCTL_CSV_CONTROL control code to indicate what kind of CSV control operation is being
	/// undertaken. It is an alternative to calling that control code by just passing a CSV_CONTROL_OP enumeration value, as the
	/// structure encapsulates an enumeration value of that type.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-csv_control_param typedef struct _CSV_CONTROL_PARAM {
	// CSV_CONTROL_OP Operation; LONGLONG Unused; } CSV_CONTROL_PARAM, *PCSV_CONTROL_PARAM;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CSV_CONTROL_PARAM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CSV_CONTROL_PARAM
	{
		/// <summary>The type of CSV control operation to undertake.</summary>
		public CSV_CONTROL_OP Operation;

		/// <summary>Unused.</summary>
		public long Unused;
	}

	/// <summary>
	/// Contains the output for the FSCTL_IS_VOLUME_OWNED_BYCSVFS control code that determines whether a volume is owned by CSVFS.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-csv_is_owned_by_csvfs typedef struct
	// _CSV_IS_OWNED_BY_CSVFS { BOOLEAN OwnedByCSVFS; } CSV_IS_OWNED_BY_CSVFS, *PCSV_IS_OWNED_BY_CSVFS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CSV_IS_OWNED_BY_CSVFS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CSV_IS_OWNED_BY_CSVFS
	{
		/// <summary><c>TRUE</c> if a volume is owned by CSVFS; otherwise, <c>FALSE</c>.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool OwnedByCSVFS;
	}

	/// <summary>Contains the output for the FSCTL_IS_CSV_FILE control code that retrieves namespace information for a file.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-csv_namespace_info typedef struct _CSV_NAMESPACE_INFO {
	// DWORD Version; DWORD DeviceNumber; LARGE_INTEGER StartingOffset; DWORD SectorSize; } CSV_NAMESPACE_INFO, *PCSV_NAMESPACE_INFO;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CSV_NAMESPACE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CSV_NAMESPACE_INFO
	{
		/// <summary>
		/// <para>The version number. This value must be set to <c>CSV_NAMESPACE_INFO_V1</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CSV_NAMESPACE_INFO_V1</term>
		/// <term>Version 1.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Version;

		/// <summary>The device number of the disk.</summary>
		public uint DeviceNumber;

		/// <summary>The starting offset of the volume.</summary>
		public long StartingOffset;

		/// <summary>The sector size of the disk.</summary>
		public uint SectorSize;
	}

	/// <summary>Contains information about whether files in a stream have been modified.</summary>
	/// <remarks>
	/// <para>
	/// This structure is used if the FSCTL_CSV_CONTROL control code is called with a CSV_CONTROL_OP enumeration value of
	/// <c>CsvControlQueryFileRevision</c>, or if the control code is used with an CSV_CONTROL_PARAM structure containing that
	/// enumeration value.
	/// </para>
	/// <para>Revision tracking is per file, not per stream, so the output changes whenever the stream changes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-csv_query_file_revision typedef struct
	// _CSV_QUERY_FILE_REVISION { LONGLONG FileId; LONGLONG FileRevision[3]; } CSV_QUERY_FILE_REVISION, *PCSV_QUERY_FILE_REVISION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CSV_QUERY_FILE_REVISION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CSV_QUERY_FILE_REVISION
	{
		/// <summary>The identifier of an NTFS file.</summary>
		public long FileId;

		/// <summary>
		/// <c>FileRevision</c>[0] increases every time the CSV MDS stack is rebuilt and CSVFLT loses its state.
		/// <para>If any of the numbers are 0, the function caller should assume that the file was modified.</para>
		/// </summary>
		public long FileRevision0;

		/// <summary><c>FileRevision</c>[1] increases every time the CSV MDS stack purges the cached revision number for the file.</summary>
		public long FileRevision1;

		/// <summary>
		/// <c>FileRevision</c>[2] increases every time the CSV MDS observes that file sizes might have changed or the file might have
		/// been written to. The element is also incremented whenever one of the nodes performs the first direct input/output operation
		/// on a stream that is associated with this file after opening this stream.
		/// </summary>
		public long FileRevision2;
	}

	/// <summary>Contains the path that is used by CSV to communicate to the MDS.</summary>
	/// <remarks>
	/// This structure is used if the FSCTL_CSV_CONTROL control code is called with a CSV_CONTROL_OP enumeration value of
	/// <c>CsvControlQueryMdsPath</c>, or if the control code is used with an CSV_CONTROL_PARAM structure containing that enumeration value.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-csv_query_mds_path typedef struct _CSV_QUERY_MDS_PATH {
	// DWORD MdsNodeId; DWORD DsNodeId; DWORD PathLength; WCHAR Path[1]; } CSV_QUERY_MDS_PATH, *PCSV_QUERY_MDS_PATH;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CSV_QUERY_MDS_PATH")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<CSV_QUERY_MDS_PATH>), nameof(PathLength) + ":cn")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CSV_QUERY_MDS_PATH
	{
		/// <summary>The identifier of an MDS node.</summary>
		public uint MdsNodeId;

		/// <summary>The identifier of a DS node.</summary>
		public uint DsNodeId;

		/// <summary>The length of the path.</summary>
		public uint PathLength;

		/// <summary>The path.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string Path;
	}

	/// <summary>Contains information about whether files in a stream have been redirected.</summary>
	/// <remarks>
	/// This structure is used if the FSCTL_CSV_CONTROL control code is called with a CSV_CONTROL_OP enumeration value of
	/// <c>CsvControlQueryRedirectState</c>, or if the control code is used with an CSV_CONTROL_PARAM structure containing that
	/// enumeration value.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-csv_query_redirect_state typedef struct
	// _CSV_QUERY_REDIRECT_STATE { DWORD MdsNodeId; DWORD DsNodeId; BOOLEAN FileRedirected; } CSV_QUERY_REDIRECT_STATE, *PCSV_QUERY_REDIRECT_STATE;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CSV_QUERY_REDIRECT_STATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CSV_QUERY_REDIRECT_STATE
	{
		/// <summary>The identifier of an MDS node.</summary>
		public uint MdsNodeId;

		/// <summary>The identifier of a DS node.</summary>
		public uint DsNodeId;

		/// <summary><c>TRUE</c> if the file has been redirected; otherwise, <c>FALSE</c>.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool FileRedirected;
	}

	/// <summary>Contains troubleshooting information about why a volume is in redirected mode.</summary>
	/// <remarks>
	/// CSV writes the troubleshooting strings to a diagnostic log that, when filtered, can provide hints as to why a volume is in a
	/// redirected mode.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-csv_query_veto_file_direct_io_output typedef struct
	// _CSV_QUERY_VETO_FILE_DIRECT_IO_OUTPUT { DWORDLONG VetoedFromAltitudeIntegral; DWORDLONG VetoedFromAltitudeDecimal; WCHAR
	// Reason[256]; } CSV_QUERY_VETO_FILE_DIRECT_IO_OUTPUT, *PCSV_QUERY_VETO_FILE_DIRECT_IO_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._CSV_QUERY_VETO_FILE_DIRECT_IO_OUTPUT")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CSV_QUERY_VETO_FILE_DIRECT_IO_OUTPUT
	{
		/// <summary>The integer portion of VetoedFromAltitude.</summary>
		public ulong VetoedFromAltitudeIntegral;

		/// <summary>The decimal portion of VetoedFromAltitude.</summary>
		public ulong VetoedFromAltitudeDecimal;

		/// <summary>The reason why volume is in a redirected mode.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Reason;
	}

	/// <summary>
	/// The <c>DEVICE_COPY_OFFLOAD_DESCRIPTOR</c> structure is one of the query result structures returned from an
	/// IOCTL_STORAGE_QUERY_PROPERTY request. This structure contains the copy offload capabilities for a storage device.
	/// </summary>
	/// <remarks>
	/// This structure is returned from a IOCTL_STORAGE_QUERY_PROPERTY request when the <c>PropertyId</c> member of
	/// STORAGE_PROPERTY_QUERY is set to <c>StorageDeviceCopyOffloadProperty</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_copy_offload_descriptor typedef struct
	// _DEVICE_COPY_OFFLOAD_DESCRIPTOR { DWORD Version; DWORD Size; DWORD MaximumTokenLifetime; DWORD DefaultTokenLifetime; DWORDLONG
	// MaximumTransferSize; DWORDLONG OptimalTransferCount; DWORD MaximumDataDescriptors; DWORD MaximumTransferLengthPerDescriptor;
	// DWORD OptimalTransferLengthPerDescriptor; WORD OptimalTransferLengthGranularity; BYTE Reserved[2]; }
	// DEVICE_COPY_OFFLOAD_DESCRIPTOR, *PDEVICE_COPY_OFFLOAD_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_COPY_OFFLOAD_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_COPY_OFFLOAD_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>The maximum lifetime of the token, in seconds.</summary>
		public uint MaximumTokenLifetime;

		/// <summary>The default lifetime of the token, in seconds.</summary>
		public uint DefaultTokenLifetime;

		/// <summary>The maximum transfer size, in bytes.</summary>
		public ulong MaximumTransferSize;

		/// <summary>The optimal transfer size, in bytes.</summary>
		public ulong OptimalTransferCount;

		/// <summary>The maximum number of data descriptors.</summary>
		public uint MaximumDataDescriptors;

		/// <summary>The maximum transfer length, in blocks, per descriptor.</summary>
		public uint MaximumTransferLengthPerDescriptor;

		/// <summary>The optimal transfer length per descriptor.</summary>
		public uint OptimalTransferLengthPerDescriptor;

		/// <summary>
		/// The granularity of the optimal transfer length, in blocks. Transfer lengths that are not an even multiple of this length may
		/// be delayed.
		/// </summary>
		public ushort OptimalTransferLengthGranularity;

		/// <summary>Reserved.</summary>
		public ushort Reserved;
	}

	/// <summary>
	/// Output structure for the <c>DeviceDsmAction_Allocation</c> action of the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Provisioning state information is returned when the <c>Action</c> member of the DEVICE_MANAGE_DATA_SET_ATTRIBUTES structure is
	/// set to <c>DeviceDsmAction_Allocation</c>. The caller should include only one data set range in the system buffer at <c>DataSetRangesOffset</c>.
	/// </para>
	/// <para>
	/// On return, the system buffer contains a DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT structure followed by the
	/// <c>DEVICE_DATA_SET_LB_PROVISIONING_STATE</c> structure. The <c>DEVICE_DATA_SET_LB_PROVISIONING_STATE</c> structure begins at an
	/// offset from the beginning of the system buffer specified by <c>OutputBlockOffset</c> in <c>DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT</c>.
	/// </para>
	/// <para>
	/// Each bit in the allocation bitmap represents a slab mapping within the data set range requested. The bits correspond directly to
	/// the slabs in the data set range. This means that bit 0 in the bitmap marks the first slab in the range. A slab is mapped if the
	/// bit value = 1 and unmapped if the bit value = 0.
	/// </para>
	/// <para>
	/// Space for <c>SlabAllocationBitMap</c> should be allocated based on the number of possible slabs in the requested data set range.
	/// The <c>SlabAllocationBitMapLength</c> of the bitmap returned is
	/// <code>(number_of_slabs / 32) + ((number_of_slabs MOD 32) &gt; 0 ? 1 : 0)</code>
	/// .
	/// </para>
	/// <para>
	/// Slab size is determined by the <c>OptimalUnmapGranularity</c> member of the DEVICE_LB_PROVISIONING_DESCRIPTOR structure returned
	/// from an IOCTL_STORAGE_QUERY_PROPERTY control code. The length of the data set range provided should be a multiple of
	/// <c>OptimalUnmapGranularity</c>. When the range length is not a multiple of <c>OptimalUnmapGranularity</c>, it is reduced to be a multiple.
	/// </para>
	/// <para>
	/// If the starting offset in the data set range is not aligned on a slab boundary, a multiple of <c>OptimalUnmapGranularity</c>,
	/// the offset will be adjusted to the next boundary. The difference between the requested offset and the adjusted offset is
	/// returned in <c>SlabOffsetDeltaInBytes</c>.
	/// </para>
	/// <para>
	/// If the slab allocation total returned in <c>SlabAllocationBitMapBitCount</c> is not as expected because of data set range
	/// alignment or length adjustments, an additional request may be submitted with a data set range modified according to the values
	/// in both <c>SlabAllocationBitMapBitCount</c> and <c>SlabOffsetDeltaInBytes</c>. The new range will properly select the slabs left
	/// out of the bitmap returned by the previous request.
	/// </para>
	/// <para>
	/// If the requested slab size is too large (for example if it is larger than the maximum transfer length of the HBA) then the
	/// IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES can fail with <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_data_set_lb_provisioning_state typedef struct
	// _DEVICE_DATA_SET_LB_PROVISIONING_STATE { DWORD Size; DWORD Version; DWORDLONG SlabSizeInBytes; DWORD SlabOffsetDeltaInBytes;
	// DWORD SlabAllocationBitMapBitCount; DWORD SlabAllocationBitMapLength; DWORD SlabAllocationBitMap[ANYSIZE_ARRAY]; }
	// DEVICE_DATA_SET_LB_PROVISIONING_STATE, *PDEVICE_DATA_SET_LB_PROVISIONING_STATE, DEVICE_DSM_ALLOCATION_OUTPUT, *PDEVICE_DSM_ALLOCATION_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_DATA_SET_LB_PROVISIONING_STATE")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DEVICE_DATA_SET_LB_PROVISIONING_STATE>), nameof(SlabAllocationBitMapLength))]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_DATA_SET_LB_PROVISIONING_STATE
	{
		/// <summary>The size of this structure, including the bitmap, in bytes.</summary>
		public uint Size;

		/// <summary>The version of this structure.</summary>
		public uint Version;

		/// <summary>The size of a slab, in bytes.</summary>
		public ulong SlabSizeInBytes;

		/// <summary>
		/// If the range specified is not aligned to the <c>OptimalUnmapGranularity</c> as returned in DEVICE_LB_PROVISIONING_DESCRIPTOR
		/// structure then the data represented in the <c>SlabAllocationBitMap</c> is offset from the specified range by this amount.
		/// </summary>
		public uint SlabOffsetDeltaInBytes;

		/// <summary>The number of relevant bits in the bitmap.</summary>
		public uint SlabAllocationBitMapBitCount;

		/// <summary>The number of <c>DWORD</c> s in the bitmap array.</summary>
		public uint SlabAllocationBitMapLength;

		/// <summary>
		/// The allocation bitmap containing one bit for each slab. If a bit is set then the corresponding slab is allocated. Otherwise,
		/// if a bit is clear, the corresponding slab is unallocated.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] SlabAllocationBitMap;
	}

	/// <summary>Provides data set range information for use with the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_data_set_range typedef struct
	// _DEVICE_DATA_SET_RANGE { LONGLONG StartingOffset; DWORDLONG LengthInBytes; } DEVICE_DATA_SET_RANGE, *PDEVICE_DATA_SET_RANGE,
	// DEVICE_DSM_RANGE, *PDEVICE_DSM_RANGE;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_DATA_SET_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_DATA_SET_RANGE
	{
		/// <summary>
		/// Starting offset of the data set range in bytes, relative to the start of the volume. Must align to disk logical sector size.
		/// </summary>
		public long StartingOffset;

		/// <summary>Length of the data set range, in bytes. Must be a multiple of disk logical sector size.</summary>
		public ulong LengthInBytes;
	}

	/// <summary>
	/// Specifies parameters for the repair operation. A repair operation is initiated by specifying <c>DeviceDsmAction_Repair</c> in
	/// the <c>Action</c> member of the DEVICE_MANAGE_DATA_SET_ATTRIBUTES structure passed in a IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES
	/// control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_data_set_repair_parameters typedef struct
	// _DEVICE_DATA_SET_REPAIR_PARAMETERS { DWORD NumberOfRepairCopies; DWORD SourceCopy; DWORD RepairCopies[ANYSIZE_ARRAY]; }
	// DEVICE_DATA_SET_REPAIR_PARAMETERS, *PDEVICE_DATA_SET_REPAIR_PARAMETERS, DEVICE_DSM_REPAIR_PARAMETERS, *PDEVICE_DSM_REPAIR_PARAMETERS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_DATA_SET_REPAIR_PARAMETERS")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DEVICE_DATA_SET_REPAIR_PARAMETERS>), nameof(NumberOfRepairCopies))]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_DATA_SET_REPAIR_PARAMETERS
	{
		/// <summary>The number of copies that will be repaired.</summary>
		public uint NumberOfRepairCopies;

		/// <summary>The copy number of the source copy.</summary>
		public uint SourceCopy;

		/// <summary>The copy numbers of all the copies that will be repaired.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] RepairCopies;
	}

	/// <summary>
	/// Contains parameters for the <c>DeviceDsmAction_Notification</c> action for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_dsm_notification_parameters typedef struct
	// _DEVICE_DSM_NOTIFICATION_PARAMETERS { DWORD Size; DWORD Flags; DWORD NumFileTypeIDs; GUID FileTypeID[ANYSIZE_ARRAY]; }
	// DEVICE_DSM_NOTIFICATION_PARAMETERS, *PDEVICE_DSM_NOTIFICATION_PARAMETERS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_DSM_NOTIFICATION_PARAMETERS")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<DEVICE_DSM_NOTIFICATION_PARAMETERS>), nameof(NumFileTypeIDs))]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_DSM_NOTIFICATION_PARAMETERS
	{
		/// <summary>
		/// Specifies the total size, in bytes, of this structure. The value of this member must include the total size, in bytes, of
		/// the <c>FileTypeIDs</c> member.
		/// </summary>
		public uint Size;

		/// <summary>
		/// <para>Flags specific to the notify operation</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DEVICE_DSM_NOTIFY_FLAG_BEGIN 0x00000001</term>
		/// <term>
		/// The ranges specified in the DEVICE_DATA_SET_RANGE structures following the DEVICE_MANAGE_DATA_SET_ATTRIBUTES structure are
		/// currently being used by the file types that are specified in the FileTypeIDs member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DEVICE_DSM_NOTIFY_FLAG_END 0x00000002</term>
		/// <term>The ranges are no longer being used by the file types that are specified in the FileTypeIDs member.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DEVICE_DSM_NOTIFY_FLAG Flags;

		/// <summary>The number of entries in the <c>FileTypeIDs</c> member.</summary>
		public uint NumFileTypeIDs;

		/// <summary>
		/// <para>One or more <c>GUID</c> values that specify the file type for the notification operation.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_TYPE_NOTIFICATION_GUID_PAGE_FILE 0d0a64a1-38fc-4db8-9fe7-3f4352cd7c5c</term>
		/// <term>Specifies a notification operation for a page file.</term>
		/// </item>
		/// <item>
		/// <term>FILE_TYPE_NOTIFICATION_GUID_HIBERNATION_FILE b7624d64-b9a3-4cf8-8011-5b86c940e7b7</term>
		/// <term>Specifies a notification operation for the system hibernation file.</term>
		/// </item>
		/// <item>
		/// <term>FILE_TYPE_NOTIFICATION_GUID_CRASHDUMP_FILE 9d453eb7-d2a6-4dbd-a2e3-fbd0ed9109a9</term>
		/// <term>Specifies a notification operation for a system crash dump file.</term>
		/// </item>
		/// </list>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public Guid[] FileTypeID;

		/// <summary>
		/// Initializes a new instance of the <see cref="DEVICE_DSM_NOTIFICATION_PARAMETERS"/> struct setting all values appropriately
		/// based on parameters.
		/// </summary>
		/// <param name="fileTypeID">One or more <c>GUID</c> values that specify the file type for the notification operation.</param>
		/// <param name="flags">Flags specific to the notify operation.</param>
		public DEVICE_DSM_NOTIFICATION_PARAMETERS(Guid[] fileTypeID, DEVICE_DSM_NOTIFY_FLAG flags)
		{
			FileTypeID = fileTypeID;
			NumFileTypeIDs = (uint)fileTypeID.Length;
			Flags = flags;
			Size = (uint)(Marshal.SizeOf(typeof(DEVICE_DSM_NOTIFICATION_PARAMETERS)) + Marshal.SizeOf(typeof(Guid)) * (NumFileTypeIDs - 1));
		}
	}

	/// <summary>
	/// Contains parameters for the <c>DeviceDsmAction_OffloadRead</c> action for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_dsm_offload_read_parameters typedef struct
	// _DEVICE_DSM_OFFLOAD_READ_PARAMETERS { DWORD Flags; DWORD TimeToLive; DWORD Reserved[2]; } DEVICE_DSM_OFFLOAD_READ_PARAMETERS, *PDEVICE_DSM_OFFLOAD_READ_PARAMETERS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_DSM_OFFLOAD_READ_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_DSM_OFFLOAD_READ_PARAMETERS
	{
		/// <summary>Set to 0.</summary>
		public uint Flags;

		/// <summary>The time to live (TTL) for the token, in milliseconds.</summary>
		public uint TimeToLive;

		/// <summary>Set to 0.</summary>
		public ulong Reserved;
	}

	/// <summary>
	/// Specifies parameters for the offload write operation. An offload write operation is initiated by specifying
	/// <c>DeviceDsmAction_OffloadWrite</c> in the <c>Action</c> member of the DEVICE_MANAGE_DATA_SET_ATTRIBUTES structure passed in a
	/// IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_dsm_offload_write_parameters typedef struct
	// _DEVICE_DSM_OFFLOAD_WRITE_PARAMETERS { DWORD Flags; DWORD Reserved; DWORDLONG TokenOffset; STORAGE_OFFLOAD_TOKEN Token; }
	// DEVICE_DSM_OFFLOAD_WRITE_PARAMETERS, *PDEVICE_DSM_OFFLOAD_WRITE_PARAMETERS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_DSM_OFFLOAD_WRITE_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_DSM_OFFLOAD_WRITE_PARAMETERS
	{
		/// <summary>Set to 0.</summary>
		public uint Flags;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>The starting offset to copy from the range bound to the token</summary>
		public ulong TokenOffset;

		/// <summary>STORAGE_OFFLOAD_TOKEN structure containing the token returned from the offload read operation.</summary>
		public STORAGE_OFFLOAD_TOKEN Token;
	}

	/// <summary>
	/// The <c>DEVICE_LB_PROVISIONING_DESCRIPTOR</c> structure is one of the query result structures returned from an
	/// IOCTL_STORAGE_QUERY_PROPERTY request. This structure contains the thin provisioning capabilities for a storage device.
	/// </summary>
	/// <remarks>
	/// <para>
	/// This structure is returned from a IOCTL_STORAGE_QUERY_PROPERTY request when the <c>PropertyId</c> member of
	/// STORAGE_PROPERTY_QUERY is set to <c>StorageDeviceLBProvisioningProperty</c>.
	/// </para>
	/// <para>
	/// If <c>UnmapGranularityAlignmentValid</c> = 0, then any code using <c>UnmapGranularityAlignment</c> should assume it has a value
	/// of 0.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_lb_provisioning_descriptor typedef struct
	// _DEVICE_LB_PROVISIONING_DESCRIPTOR { DWORD Version; DWORD Size; BYTE ThinProvisioningEnabled : 1; BYTE ThinProvisioningReadZeros
	// : 1; BYTE AnchorSupported : 3; BYTE UnmapGranularityAlignmentValid : 1; BYTE Reserved0 : 2; BYTE Reserved1[7]; DWORDLONG
	// OptimalUnmapGranularity; DWORDLONG UnmapGranularityAlignment; DWORD MaxUnmapLbaCount; DWORD MaxUnmapBlockDescriptorCount; }
	// DEVICE_LB_PROVISIONING_DESCRIPTOR, *PDEVICE_LB_PROVISIONING_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_LB_PROVISIONING_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_LB_PROVISIONING_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		private byte flags;

		/// <summary>
		/// <para>The thin provisioning–enabled status.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Thin provisioning is disabled.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Thin provisioning is enabled.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool ThinProvisioningEnabled { get => BitHelper.GetBit(flags, 0); set => BitHelper.SetBit(ref flags, 0, value); }

		/// <summary>
		/// <para>Reads to unmapped regions return zeros.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Data read from unmapped regions is undefined.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Reads return zeros.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool ThinProvisioningReadZeros { get => BitHelper.GetBit(flags, 1); set => BitHelper.SetBit(ref flags, 1, value); }

		/// <summary>
		/// <para>Deterministic read after trim support.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Deterministic read after trim is not supported.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Deterministic read after trim is supported.</term>
		/// </item>
		/// </list>
		/// </summary>
		public byte AnchorSupported { get => BitHelper.GetBits(flags, 2, 3); set => BitHelper.SetBits(ref flags, 2, 3, value); }

		/// <summary>
		/// <para>The validity of unmap granularity alignment for the device.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Unmap granularity alignment is not valid.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Unmap granularity alignment is valid.</term>
		/// </item>
		/// </list>
		/// </summary>
		public bool UnmapGranularityAlignmentValid { get => BitHelper.GetBit(flags, 5); set => BitHelper.SetBit(ref flags, 5, value); }

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
		public byte[] Reserved1;

		/// <summary>The optimal number of logical sectors for unmap granularity for the device.</summary>
		public ulong OptimalUnmapGranularity;

		/// <summary>The current value, in logical sectors, set for unmap granularity alignment on the device.</summary>
		public ulong UnmapGranularityAlignment;

		/// <summary>
		/// <c>Starting in Windows 10:</c> The maximum number of LBAs that can be unmapped in a single unmap command, in logical blocks.
		/// </summary>
		public uint MaxUnmapLbaCount;

		/// <summary><c>Starting in Windows 10:</c> The maximum number of descriptors allowed in a single unmap command.</summary>
		public uint MaxUnmapBlockDescriptorCount;
	}

	/// <summary>Input structure for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.</summary>
	/// <remarks>
	/// The total length of the buffer that contains this structure must be at least
	/// <code>(sizeof(DEVICE_MANAGE_DATA_SET_ATTRIBUTES) + ParameterBlockLength + DataSetRangesLength)</code>
	/// .
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_manage_data_set_attributes typedef struct
	// _DEVICE_MANAGE_DATA_SET_ATTRIBUTES { DWORD Size; DEVICE_DSM_ACTION Action; DWORD Flags; DWORD ParameterBlockOffset; DWORD
	// ParameterBlockLength; DWORD DataSetRangesOffset; DWORD DataSetRangesLength; } DEVICE_MANAGE_DATA_SET_ATTRIBUTES,
	// *PDEVICE_MANAGE_DATA_SET_ATTRIBUTES, DEVICE_DSM_INPUT, *PDEVICE_DSM_INPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_MANAGE_DATA_SET_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_MANAGE_DATA_SET_ATTRIBUTES
	{
		/// <summary>
		/// Size of this data structure. Must be set to
		/// <code>sizeof(DEVICE_MANAGE_DATA_SET_ATTRIBUTES)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>
		/// <para>A valid value of type DEVICE_DATA_MANAGEMENT_SET_ACTION.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DeviceDsmAction_Trim 1</term>
		/// <term>A trim action is performed. This value is not supported for user-mode applications.</term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Notification 2 | DeviceDsmActionFlag_NonDestructive (0x80000002)</term>
		/// <term>
		/// A notification action is performed. The additional parameters are in a DEVICE_DSM_NOTIFICATION_PARAMETERS structure. The
		/// DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver stack that this operation is non-destructive.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_OffloadRead 3 | DeviceDsmActionFlag_NonDestructive (0x80000003)</term>
		/// <term>
		/// An offload read action is performed. The additional parameters are in a DEVICE_DSM_OFFLOAD_READ_PARAMETERS structure. The
		/// DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver stack that this operation is
		/// non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_OffloadWrite 4</term>
		/// <term>
		/// An offload write action is performed. The additional parameters are in a DEVICE_DSM_OFFLOAD_WRITE_PARAMETERS structure.
		/// Windows 7 and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Allocation 5 | DeviceDsmActionFlag_NonDestructive (0x80000005)</term>
		/// <term>
		/// An allocation bitmap is retrieved for the first data set range specified. The DeviceDsmActionFlag_NonDestructive
		/// (0x80000000) is a bit flag to indicate to the driver stack that this operation is non-destructive. Windows 7 and Windows
		/// Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Repair 6 | DeviceDsmActionFlag_NonDestructive (0x80000006)</term>
		/// <term>
		/// A repair action is performed. The additional parameters are in a DEVICE_DATA_SET_REPAIR_PARAMETERS structure. The
		/// DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver stack that this operation is
		/// non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Scrub 7 | DeviceDsmActionFlag_NonDestructive (0x80000007)</term>
		/// <term>
		/// A scrub action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver
		/// stack that this operation is non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before
		/// Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Resiliency 8 | DeviceDsmActionFlag_NonDestructive (0x80000008)</term>
		/// <term>
		/// A resiliency action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the
		/// driver stack that this operation is non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported
		/// before Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public DEVICE_DSM_ACTION Action;

		/// <summary>
		/// <para>Flags for the actions.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DEVICE_DSM_FLAG_TRIM_NOT_FS_ALLOCATED 0x80000000</term>
		/// <term>
		/// If set then the described ranges are not allocated by a file system. This flag is specific to the DeviceDsmAction_Trim action.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DEVICE_DSM_FLAG_RESILIENCY_START_RESYNC 0x10000000</term>
		/// <term>Starts a resync operation on the storage device. This flag is specific to the DeviceDsmAction_Resiliency action.</term>
		/// </item>
		/// <item>
		/// <term>DEVICE_DSM_FLAG_RESILIENCY_START_LOAD_BALANCING 0x20000000</term>
		/// <term>Starts a load balancing operation on the storage device. This flag is specific to the DeviceDsmAction_Resiliency action.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint Flags;

		/// <summary>
		/// Byte offset to the start of the parameter block stored in the buffer contiguous to this structure. Must be aligned to the
		/// corresponding structure alignment. A value of zero indicates there is no parameter block and the <c>ParameterBlockLength</c>
		/// member must also be zero.
		/// </summary>
		public uint ParameterBlockOffset;

		/// <summary>
		/// Length of the parameter block, in bytes. A value of zero indicates there is no parameter block and the
		/// <c>ParameterBlockOffset</c> member must also be zero.
		/// </summary>
		public uint ParameterBlockLength;

		/// <summary>
		/// Byte offset to the start of the data set ranges block made up of an array of DEVICE_DATA_SET_RANGE structures stored in the
		/// buffer contiguous to this structure. Must be aligned to the <c>DEVICE_DATA_SET_RANGE</c> structure alignment. A value of
		/// zero indicates there is no data set ranges block and the <c>DataSetRangesLength</c> member must also be zero.
		/// </summary>
		public uint DataSetRangesOffset;

		/// <summary>
		/// Length of the data set ranges block, in bytes. A value of zero indicates there is no data set ranges block and the
		/// <c>DataSetRangesOffset</c> member must also be zero.
		/// </summary>
		public uint DataSetRangesLength;
	}

	/// <summary>Output structure for the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_manage_data_set_attributes_output typedef struct
	// _DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT { DWORD Size; DEVICE_DSM_ACTION Action; DWORD Flags; DWORD OperationStatus; DWORD
	// ExtendedError; DWORD TargetDetailedError; DWORD ReservedStatus; DWORD OutputBlockOffset; DWORD OutputBlockLength; }
	// DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT, *PDEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT, DEVICE_DSM_OUTPUT, *PDEVICE_DSM_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT
	{
		/// <summary>
		/// Size of the structure. This is set to
		/// <code>sizeof(DEVICE_MANAGE_DATA_SET_ATTRIBUTES_OUTPUT)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>
		/// <para>
		/// The action related to the instance of this structure. This is a value for the DEVICE_DATA_MANAGEMENT_SET_ACTION data type.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DeviceDsmAction_Trim 1</term>
		/// <term>A trim action is performed. This value is not supported for user-mode applications.</term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Notification 2 | DeviceDsmActionFlag_NonDestructive (0x80000002)</term>
		/// <term>
		/// A notification action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the
		/// driver stack that this operation is non-destructive.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_OffloadRead 3 | DeviceDsmActionFlag_NonDestructive (0x80000003)</term>
		/// <term>
		/// An offload read action is performed. The output described by the OutputBlockOffset and OutputBlockLength members is a
		/// STORAGE_OFFLOAD_READ_OUTPUT structure. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the
		/// driver stack that this operation is non-destructive.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_OffloadWrite 4</term>
		/// <term>
		/// An offload write action is performed. The output described by the OutputBlockOffset and OutputBlockLength members is a
		/// STORAGE_OFFLOAD_WRITE_OUTPUT structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Allocation 5 | DeviceDsmActionFlag_NonDestructive (0x80000005)</term>
		/// <term>
		/// An allocation bitmap is returned for the first data set range passed in. The output is in a
		/// DEVICE_DATA_SET_LB_PROVISIONING_STATE structure. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to
		/// indicate to the driver stack that this operation is non-destructive.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Repair 6 | DeviceDsmActionFlag_NonDestructive (0x80000006)</term>
		/// <term>
		/// A repair action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver
		/// stack that this operation is non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before
		/// Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Scrub 7 | DeviceDsmActionFlag_NonDestructive (0x80000007)</term>
		/// <term>
		/// A scrub action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the driver
		/// stack that this operation is non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported before
		/// Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DeviceDsmAction_Resiliency 8 | DeviceDsmActionFlag_NonDestructive (0x80000008)</term>
		/// <term>
		/// A resiliency action is performed. The DeviceDsmActionFlag_NonDestructive (0x80000000) is a bit flag to indicate to the
		/// driver stack that this operation is non-destructive. Windows 7 and Windows Server 2008 R2: This value is not supported
		/// before Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public DEVICE_DSM_ACTION Action;

		/// <summary>Not used.</summary>
		public uint Flags;

		/// <summary>Not used.</summary>
		public uint OperationStatus;

		/// <summary>Extended error information.</summary>
		public uint ExtendedError;

		/// <summary>Target specific error.</summary>
		public uint TargetDetailedError;

		/// <summary>Reserved.</summary>
		public uint ReservedStatus;

		/// <summary>The offset, in bytes, from the beginning of this structure to where any action-specific data is located.</summary>
		public uint OutputBlockOffset;

		/// <summary>The length, in bytes, of the action-specific data.</summary>
		public uint OutputBlockLength;
	}

	/// <summary>Provides information about the media supported by a device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_media_info typedef struct _DEVICE_MEDIA_INFO {
	// union { struct { LARGE_INTEGER Cylinders; STORAGE_MEDIA_TYPE MediaType; DWORD TracksPerCylinder; DWORD SectorsPerTrack; DWORD
	// BytesPerSector; DWORD NumberMediaSides; DWORD MediaCharacteristics; } DiskInfo; struct { LARGE_INTEGER Cylinders;
	// STORAGE_MEDIA_TYPE MediaType; DWORD TracksPerCylinder; DWORD SectorsPerTrack; DWORD BytesPerSector; DWORD NumberMediaSides; DWORD
	// MediaCharacteristics; } RemovableDiskInfo; struct { STORAGE_MEDIA_TYPE MediaType; DWORD MediaCharacteristics; DWORD
	// CurrentBlockSize; STORAGE_BUS_TYPE BusType; union { struct { BYTE MediumType; BYTE DensityCode; } ScsiInformation; }
	// BusSpecificData; } TapeInfo; } DeviceSpecific; } DEVICE_MEDIA_INFO, *PDEVICE_MEDIA_INFO;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_MEDIA_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_MEDIA_INFO
	{
		/// <summary>A union that contains the following members.</summary>
		public DEVICESPECIFIC DeviceSpecific;

		/// <summary>A union that contains the following members.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct DEVICESPECIFIC
		{
			/// <summary>A structure that contains the following members.</summary>
			[FieldOffset(0)]
			public DISKINFO DiskInfo;

			/// <summary>A structure that contains the following members.</summary>
			[FieldOffset(0)]
			public DISKINFO RemovableDiskInfo;

			/// <summary>A structure that contains the following members.</summary>
			[FieldOffset(0)]
			public TAPEINFO TapeInfo;

			/// <summary>A structure that contains the following members.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct DISKINFO
			{
				/// <summary>The number of cylinders on this disk.</summary>
				public long Cylinders;

				/// <summary>
				/// The media type. This member can be one of the values from the STORAGE_MEDIA_TYPE or MEDIA_TYPE enumeration types.
				/// </summary>
				public STORAGE_MEDIA_TYPE MediaType;

				/// <summary>The number of tracks per cylinder.</summary>
				public uint TracksPerCylinder;

				/// <summary>The number of sectors per track.</summary>
				public uint SectorsPerTrack;

				/// <summary>The number of bytes per sector.</summary>
				public uint BytesPerSector;

				/// <summary>
				/// The number of sides of the disk that can contain data. This member is 1 for one-sided media or 2 for two-sided media.
				/// </summary>
				public uint NumberMediaSides;

				/// <summary>
				/// <para>The characteristics of the media. This member can be one or more of the following values.</para>
				/// <para>DiskInfo.MediaCharacteristics.MEDIA_CURRENTLY_MOUNTED (0x80000000)</para>
				/// <para>DiskInfo.MediaCharacteristics.MEDIA_ERASEABLE (0x00000001)</para>
				/// <para>DiskInfo.MediaCharacteristics.MEDIA_READ_ONLY (0x00000004)</para>
				/// <para>DiskInfo.MediaCharacteristics.MEDIA_READ_WRITE (0x00000008)</para>
				/// <para>DiskInfo.MediaCharacteristics.MEDIA_WRITE_ONCE (0x00000002)</para>
				/// <para>DiskInfo.MediaCharacteristics.MEDIA_WRITE_PROTECTED (0x00000100)</para>
				/// </summary>
				public MEDIA_CHARACTER MediaCharacteristics;
			}

			/// <summary>A structure that contains the following members.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct TAPEINFO
			{
				/// <summary>
				/// The media type. This member can be one of the values from the STORAGE_MEDIA_TYPE or MEDIA_TYPE enumeration types.
				/// </summary>
				public STORAGE_MEDIA_TYPE MediaType;

				/// <summary>
				/// <para>The characteristics of the media. This member can be one or more of the following values.</para>
				/// <para>TapeInfo.MediaCharacteristics.MEDIA_CURRENTLY_MOUNTED (0x80000000)</para>
				/// <para>TapeInfo.MediaCharacteristics.MEDIA_ERASEABLE (0x00000001)</para>
				/// <para>TapeInfo.MediaCharacteristics.MEDIA_READ_ONLY (0x00000004)</para>
				/// <para>TapeInfo.MediaCharacteristics.MEDIA_READ_WRITE (0x00000008)</para>
				/// <para>TapeInfo.MediaCharacteristics.MEDIA_WRITE_ONCE (0x00000002)</para>
				/// <para>TapeInfo.MediaCharacteristics.MEDIA_WRITE_PROTECTED (0x00000100)</para>
				/// </summary>
				public MEDIA_CHARACTER MediaCharacteristics; // Bitmask of MEDIA_XXX values.

				/// <summary>The current block size, in bytes.</summary>
				public uint CurrentBlockSize;

				/// <summary>
				/// The type of bus to which the tape drive is connected. This members can be one of the STORAGE_BUS_TYPE enumeration values.
				/// </summary>
				public STORAGE_BUS_TYPE BusType;

				/// <summary>A union that contains the following members.</summary>
				public BUSSPECIFICDATA BusSpecificData;

				/// <summary>A union that contains the following members.</summary>
				[StructLayout(LayoutKind.Explicit)]
				public struct BUSSPECIFICDATA
				{
					/// <summary/>
					[FieldOffset(0)]
					public SCSIINFORMATION ScsiInformation;

					/// <summary/>
					[StructLayout(LayoutKind.Sequential)]
					public struct SCSIINFORMATION
					{
						/// <summary>The SCSI-specific medium type.</summary>
						public byte MediumType;

						/// <summary>The SCSI-specific current operating density for read/write operations.</summary>
						public byte DensityCode;
					}
				}
			}
		}
	}

	/// <summary>The <c>DEVICE_POWER_DESCRIPTOR</c> structure describes the power capabilities of a storage device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_power_descriptor typedef struct
	// _DEVICE_POWER_DESCRIPTOR { DWORD Version; DWORD Size; BOOLEAN DeviceAttentionSupported; BOOLEAN
	// AsynchronousNotificationSupported; BOOLEAN IdlePowerManagementEnabled; BOOLEAN D3ColdEnabled; BOOLEAN D3ColdSupported; BOOLEAN
	// NoVerifyDuringIdlePower; BYTE Reserved[2]; DWORD IdleTimeoutInMS; } DEVICE_POWER_DESCRIPTOR, *PDEVICE_POWER_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_POWER_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_POWER_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>True if device attention is supported. Otherwise, false.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool DeviceAttentionSupported;

		/// <summary>
		/// True if the device supports asynchronous notifications, delivered via <c>IOCTL_STORAGE_EVENT_NOTIFICATION</c>. Otherwise, false.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool AsynchronousNotificationSupported;

		/// <summary>True if the device has been registered for runtime idle power management. Otherwise, false.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool IdlePowerManagementEnabled;

		/// <summary>True if the device will be powered off when put into D3 power state. Otherwise, false.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool D3ColdEnabled;

		/// <summary>True if the platform supports <c>D3ColdEnabled</c> for this device. Otherwise, false.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool D3ColdSupported;

		/// <summary/>
		[MarshalAs(UnmanagedType.U1)]
		public bool NoVerifyDuringIdlePower;

		/// <summary>Reserved.</summary>
		public ushort Reserved;

		/// <summary>The idle timeout value in milliseconds. This member is ignored unless <c>IdlePowerManagementEnabled</c> is true.</summary>
		public uint IdleTimeoutInMS;
	}

	/// <summary>
	/// Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY request to retrieve the seek penalty descriptor data for a device.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_seek_penalty_descriptor typedef struct
	// _DEVICE_SEEK_PENALTY_DESCRIPTOR { DWORD Version; DWORD Size; BOOLEAN IncursSeekPenalty; } DEVICE_SEEK_PENALTY_DESCRIPTOR, *PDEVICE_SEEK_PENALTY_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_SEEK_PENALTY_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_SEEK_PENALTY_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>Specifies whether the device incurs a seek penalty.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool IncursSeekPenalty;
	}

	/// <summary>Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY request to retrieve the trim descriptor data for a device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_trim_descriptor typedef struct
	// _DEVICE_TRIM_DESCRIPTOR { DWORD Version; DWORD Size; BOOLEAN TrimEnabled; } DEVICE_TRIM_DESCRIPTOR, *PDEVICE_TRIM_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_TRIM_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_TRIM_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>Specifies whether trim is enabled for the device.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool TrimEnabled;
	}

	/// <summary>Reserved for system use.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-device_write_aggregation_descriptor typedef struct
	// _DEVICE_WRITE_AGGREGATION_DESCRIPTOR { DWORD Version; DWORD Size; BOOLEAN BenefitsFromWriteAggregation; }
	// DEVICE_WRITE_AGGREGATION_DESCRIPTOR, *PDEVICE_WRITE_AGGREGATION_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DEVICE_WRITE_AGGREGATION_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DEVICE_WRITE_AGGREGATION_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size, in bytes, of this structure. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the descriptor, in bytes.</summary>
		public uint Size;

		/// <summary><c>TRUE</c> if the device benefits from write aggregation.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool BenefitsFromWriteAggregation;
	}

	/// <summary>Contains parameters for the FSCTL_DUPLICATE_EXTENTS control code that performs the Block Cloning operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-duplicate_extents_data typedef struct
	// _DUPLICATE_EXTENTS_DATA { HANDLE FileHandle; LARGE_INTEGER SourceFileOffset; LARGE_INTEGER TargetFileOffset; LARGE_INTEGER
	// ByteCount; } DUPLICATE_EXTENTS_DATA, *PDUPLICATE_EXTENTS_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._DUPLICATE_EXTENTS_DATA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DUPLICATE_EXTENTS_DATA
	{
		/// <summary>
		/// A handle to the source file from which the byte range is to be copied. To retrieve a file handle, use the CreateFile function.
		/// </summary>
		public HFILE FileHandle;

		/// <summary>The offset, in bytes, to the beginning of the range to copy from the source file.</summary>
		public long SourceFileOffset;

		/// <summary>The offset, in bytes, to place the copied byte range in the destination file.</summary>
		public long TargetFileOffset;

		/// <summary>The length, in bytes, of the range to copy.</summary>
		public long ByteCount;
	}

	/// <summary>
	/// Indicates a range of bytes in a file. This structure is used with the FSCTL_QUERY_ALLOCATED_RANGES control code. On input, the
	/// structure indicates the range of the file to search. On output, the operation retrieves an array of
	/// <c>FILE_ALLOCATED_RANGE_BUFFER</c> structures to indicate the allocated ranges within the search range.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_allocated_range_buffer typedef struct
	// _FILE_ALLOCATED_RANGE_BUFFER { LARGE_INTEGER FileOffset; LARGE_INTEGER Length; } FILE_ALLOCATED_RANGE_BUFFER, *PFILE_ALLOCATED_RANGE_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_ALLOCATED_RANGE_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_ALLOCATED_RANGE_BUFFER
	{
		/// <summary>The file offset of the start of a range of bytes in a file, in bytes.</summary>
		public long FileOffset;

		/// <summary>The size of the range, in bytes.</summary>
		public long Length;
	}

	/// <summary>Used as input to the FSCTL_FILE_LEVEL_TRIM control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_level_trim typedef struct _FILE_LEVEL_TRIM { DWORD
	// Key; DWORD NumRanges; FILE_LEVEL_TRIM_RANGE Ranges[1]; } FILE_LEVEL_TRIM, *PFILE_LEVEL_TRIM;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_LEVEL_TRIM")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<FILE_LEVEL_TRIM>), nameof(NumRanges))]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_LEVEL_TRIM
	{
		/// <summary>Reserved. Set to zero (0).</summary>
		public uint Key;

		/// <summary>
		/// Number of FILE_LEVEL_TRIM_RANGE entries in the <c>Ranges</c> member. On return should be compared with the
		/// <c>NumRangesProcessed</c> member of the FILE_LEVEL_TRIM_OUTPUT structure.
		/// </summary>
		public uint NumRanges;

		/// <summary>Array of ranges that describe the portions of the file that are to be trimmed.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public FILE_LEVEL_TRIM_RANGE[] Ranges;
	}

	/// <summary>Used as output to the FSCTL_FILE_LEVEL_TRIM control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_level_trim_output typedef struct
	// _FILE_LEVEL_TRIM_OUTPUT { DWORD NumRangesProcessed; } FILE_LEVEL_TRIM_OUTPUT, *PFILE_LEVEL_TRIM_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_LEVEL_TRIM_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_LEVEL_TRIM_OUTPUT
	{
		/// <summary>
		/// Contains the number of ranges that were successfully processed. This may be less than the value passed in the
		/// <c>NumRanges</c> member of the FILE_LEVEL_TRIM structure. If it is then the last ranges in the array were not processed.
		/// </summary>
		public uint NumRangesProcessed;
	}

	/// <summary>Specifies a range of a file that is to be trimmed.</summary>
	/// <remarks>
	/// Before the trim operation is passed to the underlying storage system the input ranges are reduced to be aligned to page
	/// boundaries (4,096 bytes on 32-bit and x64-based editions of Windows, 8,192 bytes on Itanium-Based editions of Windows).
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_level_trim_range typedef struct
	// _FILE_LEVEL_TRIM_RANGE { DWORDLONG Offset; DWORDLONG Length; } FILE_LEVEL_TRIM_RANGE, *PFILE_LEVEL_TRIM_RANGE;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_LEVEL_TRIM_RANGE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_LEVEL_TRIM_RANGE
	{
		/// <summary>Offset, in bytes, from the start of the file for the range to be trimmed.</summary>
		public ulong Offset;

		/// <summary>Length, in bytes, for the range to be trimmed.</summary>
		public ulong Length;
	}

	/// <summary>
	/// Specifies the disc to close the current session for. This control code is used for UDF file systems. This structure is used for
	/// input when calling FSCTL_MAKE_MEDIA_COMPATIBLE.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_make_compatible_buffer typedef struct
	// _FILE_MAKE_COMPATIBLE_BUFFER { BOOLEAN CloseDisc; } FILE_MAKE_COMPATIBLE_BUFFER, *PFILE_MAKE_COMPATIBLE_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_MAKE_COMPATIBLE_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_MAKE_COMPATIBLE_BUFFER
	{
		/// <summary>If <c>TRUE</c>, indicates the media should be finalized. No new data can be appended to the media.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool CloseDisc;
	}

	/// <summary>Contains an object identifier and user-defined metadata associated with the object identifier.</summary>
	/// <remarks>
	/// Object identifiers are used to track files and directories. They are invisible to most applications and should never be modified
	/// by applications. Modifying an object identifier can result in the loss of data from portions of a file, up to and including
	/// entire volumes of data.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_objectid_buffer typedef struct _FILE_OBJECTID_BUFFER
	// { BYTE ObjectId[16]; union { struct { BYTE BirthVolumeId[16]; BYTE BirthObjectId[16]; BYTE DomainId[16]; } DUMMYSTRUCTNAME; BYTE
	// ExtendedInfo[48]; } DUMMYUNIONNAME; } FILE_OBJECTID_BUFFER, *PFILE_OBJECTID_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_OBJECTID_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_OBJECTID_BUFFER
	{
		/// <summary>The identifier that uniquely identifies the file or directory within the volume on which it resides.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] ObjectId;

		/// <summary>
		/// User-defined extended data to be set with FSCTL_SET_OBJECT_ID_EXTENDED. Use this data as an alternative to the
		/// <c>BirthVolumeId</c>, <c>BirthObjectId</c>, and <c>DomainId</c> members.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
		public byte[] ExtendedInfo;

		/// <summary>
		/// The identifier of the volume on which the object resided when the object identifier was created, or zero if the volume had
		/// no object identifier at that time. After copy operations, move operations, or other file operations, this may not be the
		/// same as the object identifier of the volume on which the object presently resides.
		/// </summary>
		public byte[] BirthVolumeId { get => ExtendedInfo.Take(16).ToArray(); set => Buffer.BlockCopy(value, 0, ExtendedInfo, 0, 16); }

		/// <summary>
		/// The object identifier of the object at the time it was created. After copy operations, move operations, or other file
		/// operations, this may not be the same as the <c>ObjectId</c> member at present.
		/// </summary>
		public byte[] BirthObjectId { get => ExtendedInfo.Skip(16).Take(16).ToArray(); set => Buffer.BlockCopy(value, 0, ExtendedInfo, 16, 16); }

		/// <summary>Reserved; must be zero.</summary>
		public byte[] DomainId { get => ExtendedInfo.Skip(32).Take(16).ToArray(); set => Buffer.BlockCopy(value, 0, ExtendedInfo, 32, 16); }
	}

	/// <summary>Receives the volume information from a call to FSCTL_QUERY_ON_DISK_VOLUME_INFO.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_query_on_disk_vol_info_buffer typedef struct
	// _FILE_QUERY_ON_DISK_VOL_INFO_BUFFER { LARGE_INTEGER DirectoryCount; LARGE_INTEGER FileCount; WORD FsFormatMajVersion; WORD
	// FsFormatMinVersion; WCHAR FsFormatName[12]; LARGE_INTEGER FormatTime; LARGE_INTEGER LastUpdateTime; WCHAR CopyrightInfo[34];
	// WCHAR AbstractInfo[34]; WCHAR FormattingImplementationInfo[34]; WCHAR LastModifyingImplementationInfo[34]; }
	// FILE_QUERY_ON_DISK_VOL_INFO_BUFFER, *PFILE_QUERY_ON_DISK_VOL_INFO_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_QUERY_ON_DISK_VOL_INFO_BUFFER")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FILE_QUERY_ON_DISK_VOL_INFO_BUFFER
	{
		/// <summary>
		/// <para>The number of directories on the specified disk. This member is -1 if the number is unknown.</para>
		/// <para>
		/// For UDF file systems with a virtual allocation table, this information is available only if the UDF revision is greater than 1.50.
		/// </para>
		/// </summary>
		public long DirectoryCount;

		/// <summary>
		/// <para>The number of files on the specified disk. Returns -1 if the number is unknown.</para>
		/// <para>
		/// For UDF file systems with a virtual allocation table, this information is available only if the UDF revision is greater than 1.50.
		/// </para>
		/// </summary>
		public long FileCount;

		/// <summary>
		/// The major version number of the file system. Returns -1 if the number is unknown or not applicable. On UDF 1.02 file
		/// systems, 1 is returned.
		/// </summary>
		public ushort FsFormatMajVersion;

		/// <summary>
		/// The minor version number of the file system. Returns -1 if the number is unknown or not applicable. On UDF 1.02 file
		/// systems, 02 is returned.
		/// </summary>
		public ushort FsFormatMinVersion;

		/// <summary>Always returns UDF.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
		public string FsFormatName;

		/// <summary>The time the media was formatted.</summary>
		public long FormatTime;

		/// <summary>The time the media was last updated.</summary>
		public long LastUpdateTime;

		/// <summary>Any copyright information associated with the volume.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
		public string CopyrightInfo;

		/// <summary>Any abstract information written on the media.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
		public string AbstractInfo;

		/// <summary>
		/// Implementation-specific information; in some cases, it is the operating system version that the media was formatted by.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
		public string FormattingImplementationInfo;

		/// <summary>
		/// The last implementation that modified the disk. This information is implementation specific; in some cases, it is the
		/// operating system version that the media was last modified by.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 34)]
		public string LastModifyingImplementationInfo;
	}

	/// <summary>Contains defect management properties.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_query_sparing_buffer typedef struct
	// _FILE_QUERY_SPARING_BUFFER { DWORD SparingUnitBytes; BOOLEAN SoftwareSparing; DWORD TotalSpareBlocks; DWORD FreeSpareBlocks; }
	// FILE_QUERY_SPARING_BUFFER, *PFILE_QUERY_SPARING_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_QUERY_SPARING_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_QUERY_SPARING_BUFFER
	{
		/// <summary>The size of a sparing packet and the underlying error check and correction (ECC) block size of the volume.</summary>
		public uint SparingUnitBytes;

		/// <summary>If <c>TRUE</c>, indicates that sparing behavior is software-based; if <c>FALSE</c>, it is hardware-based.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool SoftwareSparing;

		/// <summary>The total number of blocks allocated for sparing.</summary>
		public uint TotalSpareBlocks;

		/// <summary>The number of blocks available for sparing.</summary>
		public uint FreeSpareBlocks;
	}

	/// <summary>Specifies the defect management state to be set.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_set_defect_mgmt_buffer typedef struct
	// _FILE_SET_DEFECT_MGMT_BUFFER { BOOLEAN Disable; } FILE_SET_DEFECT_MGMT_BUFFER, *PFILE_SET_DEFECT_MGMT_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_SET_DEFECT_MGMT_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_SET_DEFECT_MGMT_BUFFER
	{
		/// <summary>If <c>TRUE</c>, indicates that defect management is disabled.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool Disable;
	}

	/// <summary>
	/// Specifies the sparse state to be set. <c>Windows Server 2003 and Windows XP:</c> This structure is optional. For more
	/// information, see FSCTL_SET_SPARSE.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_set_sparse_buffer typedef struct
	// _FILE_SET_SPARSE_BUFFER { BOOLEAN SetSparse; } FILE_SET_SPARSE_BUFFER, *PFILE_SET_SPARSE_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_SET_SPARSE_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_SET_SPARSE_BUFFER
	{
		/// <summary>
		/// <para>If <c>TRUE</c>, makes the file sparse.</para>
		/// <para>If <c>FALSE</c>, makes the file not sparse.</para>
		/// <para>
		/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> A value of <c>FALSE</c> for this member is
		/// valid only on files that no longer have any sparse regions. For more information, see FSCTL_SET_SPARSE.
		/// </para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> A value of <c>FALSE</c> for this member is not supported. Specifying <c>FALSE</c>
		/// will cause the FSCTL_SET_SPARSE call to fail.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool SetSparse;
	}

	/// <summary>Represents an identifier for the storage tier relative to the volume.</summary>
	/// <remarks>
	/// The storage tier ID for a particular volume has no relationship to the storage tier ID with the same value on a different volume.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_storage_tier typedef struct _FILE_STORAGE_TIER {
	// GUID Id; WCHAR Name[FILE_STORAGE_TIER_NAME_LENGTH]; WCHAR Description[FILE_STORAGE_TIER_NAME_LENGTH]; DWORDLONG Flags; DWORDLONG
	// ProvisionedCapacity; FILE_STORAGE_TIER_MEDIA_TYPE MediaType; FILE_STORAGE_TIER_CLASS Class; } FILE_STORAGE_TIER, *PFILE_STORAGE_TIER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_STORAGE_TIER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_STORAGE_TIER
	{
		/// <summary>Tier ID.</summary>
		public Guid Id;

		/// <summary>Name for the tier.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = FILE_STORAGE_TIER_NAME_LENGTH)]
		public string Name;

		/// <summary>Note for the tier.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = FILE_STORAGE_TIER_NAME_LENGTH)]
		public string Description;

		/// <summary>
		/// <para>The file storage tier flags. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_STORAGE_TIER_FLAG_NO_SEEK_PENALTY 0x00020000</term>
		/// <term>Tier does not suffer a seek penalty on IO operations, which indicates that is an SSD (solid state drive).</term>
		/// </item>
		/// </list>
		/// </summary>
		public FILE_STORAGE_TIER_FLAG Flags;

		/// <summary>Provisioned capacity of the tier.</summary>
		public ulong ProvisionedCapacity;

		/// <summary>Media type of the tier.</summary>
		public FILE_STORAGE_TIER_MEDIA_TYPE MediaType;

		/// <summary/>
		public FILE_STORAGE_TIER_CLASS Class;
	}

	/// <summary>Describes a single storage tier region.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_storage_tier_region typedef struct
	// _FILE_STORAGE_TIER_REGION { GUID TierId; DWORDLONG Offset; DWORDLONG Length; } FILE_STORAGE_TIER_REGION, *PFILE_STORAGE_TIER_REGION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_STORAGE_TIER_REGION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_STORAGE_TIER_REGION
	{
		/// <summary>Tier ID.</summary>
		public Guid TierId;

		/// <summary>Offset from the beginning of the volume of this region, in bytes.</summary>
		public ulong Offset;

		/// <summary>Length of region in bytes.</summary>
		public ulong Length;
	}

	/// <summary>Describes a single storage tier region.</summary>
	/// <summary>Contains file system recognition information retrieved by the FSCTL_QUERY_FILE_SYSTEM_RECOGNITION control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_system_recognition_information typedef struct
	// _FILE_SYSTEM_RECOGNITION_INFORMATION { CHAR FileSystem[9]; } FILE_SYSTEM_RECOGNITION_INFORMATION, *PFILE_SYSTEM_RECOGNITION_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_SYSTEM_RECOGNITION_INFORMATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct FILE_SYSTEM_RECOGNITION_INFORMATION
	{
		/// <summary>
		/// The file system name stored on the disk. This is a null-terminated string of 8 ASCII characters that represents the
		/// nonlocalizable human-readable name of the file system the volume is formatted with.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		public string FileSystem;
	}

	/// <summary>Contains a range of a file to set to zeros. This structure is used by the FSCTL_SET_ZERO_DATA control code</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-file_zero_data_information typedef struct
	// _FILE_ZERO_DATA_INFORMATION { LARGE_INTEGER FileOffset; LARGE_INTEGER BeyondFinalZero; } FILE_ZERO_DATA_INFORMATION, *PFILE_ZERO_DATA_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FILE_ZERO_DATA_INFORMATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FILE_ZERO_DATA_INFORMATION
	{
		/// <summary>The file offset of the start of the range to set to zeros, in bytes.</summary>
		public long FileOffset;

		/// <summary>The byte offset of the first byte beyond the last zeroed byte.</summary>
		public long BeyondFinalZero;
	}

	/// <summary>Contains data for the FSCTL_FIND_FILES_BY_SID control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-find_by_sid_data typedef struct { DWORD Restart; SID Sid;
	// } FIND_BY_SID_DATA, *PFIND_BY_SID_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_12")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<FIND_BY_SID_DATA>), nameof(SubAuthorityCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct FIND_BY_SID_DATA
	{
		/// <summary>
		/// Indicates whether to restart the search. This member should be 1 on first call, so the search will start from the root. For
		/// subsequent calls, this member should be zero so the search will resume at the point where it stopped.
		/// </summary>
		public uint Restart;

		private byte Revision;
		private byte SubAuthorityCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		private readonly byte[] IdentifierAuthority;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		private readonly uint[] SubAuthority;

		/// <summary>A SID structure that specifies the desired creator owner.</summary>
		public byte[] Sid
		{
			get
			{
				var value = new byte[8 + SubAuthorityCount * 4];
				value[0] = Revision;
				value[1] = SubAuthorityCount;
				for (int i = 0; i < 6; i++)
					value[i + 2] = IdentifierAuthority[i];
				for (int i = 0; i < SubAuthorityCount; i++)
				{
					var sa = BitConverter.GetBytes(SubAuthority[i]);
					for (int j = 0; j < 4; j++)
						value[8 + (i * 4) + j] = sa[j];
				}
				return value;
			}
			set
			{
				if (value is null || value.Length < 12) throw new ArgumentException();
				Revision = value[0];
				SubAuthorityCount = value[1];
				if (value.Length < 8 + 4 * SubAuthorityCount) throw new ArgumentException();
				for (int i = 0; i < 6; i++)
					IdentifierAuthority[i] = value[i + 2];
				for (int i = 0; i < SubAuthorityCount; i++)
					SubAuthority[i] = BitConverter.ToUInt32(value, 8 + (i * 4));
			}
		}
	}

	/// <summary>Represents a file name.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-find_by_sid_output typedef struct { DWORD
	// NextEntryOffset; DWORD FileIndex; DWORD FileNameLength; WCHAR FileName[1]; } FIND_BY_SID_OUTPUT, *PFIND_BY_SID_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_13")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<FIND_BY_SID_OUTPUT>), nameof(FileNameLength) + ":br")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct FIND_BY_SID_OUTPUT
	{
		/// <summary/>
		public uint NextEntryOffset;

		/// <summary/>
		public uint FileIndex;

		/// <summary>The size of the file name, in bytes. This size does not include the NULL character.</summary>
		public uint FileNameLength;

		/// <summary>A pointer to a null-terminated string that specifies the file name.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string FileName;
	}

	/// <summary>
	/// Contains information used in formatting a contiguous set of disk tracks. It is used by the IOCTL_DISK_FORMAT_TRACKS_EX control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-format_ex_parameters typedef struct _FORMAT_EX_PARAMETERS
	// { MEDIA_TYPE MediaType; DWORD StartCylinderNumber; DWORD EndCylinderNumber; DWORD StartHeadNumber; DWORD EndHeadNumber; WORD
	// FormatGapLength; WORD SectorsPerTrack; WORD SectorNumber[1]; } FORMAT_EX_PARAMETERS, *PFORMAT_EX_PARAMETERS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FORMAT_EX_PARAMETERS")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<FORMAT_EX_PARAMETERS>), nameof(SectorsPerTrack))]
	[StructLayout(LayoutKind.Sequential)]
	public struct FORMAT_EX_PARAMETERS
	{
		/// <summary>The media type. For a list of values, see MEDIA_TYPE.</summary>
		public MEDIA_TYPE MediaType;

		/// <summary>The cylinder number at which to begin the format.</summary>
		public uint StartCylinderNumber;

		/// <summary>The cylinder number at which to end the format.</summary>
		public uint EndCylinderNumber;

		/// <summary>The beginning head location.</summary>
		public uint StartHeadNumber;

		/// <summary>The ending head location.</summary>
		public uint EndHeadNumber;

		/// <summary>The length of the gap between two successive sectors on a track.</summary>
		public ushort FormatGapLength;

		/// <summary>The number of sectors in each track.</summary>
		public ushort SectorsPerTrack;

		/// <summary>An array of values specifying the sector numbers of the sectors to be included in the track to be formatted.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public ushort[] SectorNumber;
	}

	/// <summary>
	/// Contains information used in formatting a contiguous set of disk tracks. It is used by the IOCTL_DISK_FORMAT_TRACKS control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-format_parameters typedef struct _FORMAT_PARAMETERS {
	// MEDIA_TYPE MediaType; DWORD StartCylinderNumber; DWORD EndCylinderNumber; DWORD StartHeadNumber; DWORD EndHeadNumber; }
	// FORMAT_PARAMETERS, *PFORMAT_PARAMETERS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FORMAT_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FORMAT_PARAMETERS
	{
		/// <summary>The media type. For a list of values, see MEDIA_TYPE.</summary>
		public MEDIA_TYPE MediaType;

		/// <summary>The cylinder number at which to begin the format.</summary>
		public uint StartCylinderNumber;

		/// <summary>The cylinder number at which to end the format.</summary>
		public uint EndCylinderNumber;

		/// <summary>The beginning head location.</summary>
		public uint StartHeadNumber;

		/// <summary>The ending head location.</summary>
		public uint EndHeadNumber;
	}

	/// <summary>
	/// Contains the integrity information for a file or directory. Returned from the FSCTL_GET_INTEGRITY_INFORMATION control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-fsctl_get_integrity_information_buffer typedef struct
	// _FSCTL_GET_INTEGRITY_INFORMATION_BUFFER { WORD ChecksumAlgorithm; WORD Reserved; DWORD Flags; DWORD ChecksumChunkSizeInBytes;
	// DWORD ClusterSizeInBytes; } FSCTL_GET_INTEGRITY_INFORMATION_BUFFER, *PFSCTL_GET_INTEGRITY_INFORMATION_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FSCTL_GET_INTEGRITY_INFORMATION_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FSCTL_GET_INTEGRITY_INFORMATION_BUFFER
	{
		/// <summary>
		/// <para>The checksum algorithm used.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CHECKSUM_TYPE_NONE 0x0000</term>
		/// <term>The file or directory is not configured to use integrity.</term>
		/// </item>
		/// <item>
		/// <term>CHECKSUM_TYPE_CRC64 0x0002</term>
		/// <term>The file or directory uses a CRC64 checksum to provide integrity.</term>
		/// </item>
		/// <item>
		/// <term>3–0xffff</term>
		/// <term>Reserved for future use.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CHECKSUM_TYPE ChecksumAlgorithm;

		/// <summary>Reserved for future use. Set to 0.</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>Contains one or more flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FSCTL_INTEGRITY_FLAG_CHECKSUM_ENFORCEMENT_OFF 0x00000001</term>
		/// <term>If set, the checksum enforcement is disabled.</term>
		/// </item>
		/// </list>
		/// </summary>
		public FSCTL_INTEGRITY_FLAG Flags;

		/// <summary>Size in bytes of the chunks used to calculate checksums.</summary>
		public uint ChecksumChunkSizeInBytes;

		/// <summary>
		/// Size in bytes of a cluster for this volume. This value must be a power of 2, must be greater than or equal to the sector
		/// size of the underlying hardware and must be a power of 2 multiple of the sector size.
		/// </summary>
		public uint ClusterSizeInBytes;
	}

	/// <summary>Contains the storage tier regions from the storage stack for a particular volume.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-fsctl_query_region_info_input typedef struct
	// _FSCTL_QUERY_REGION_INFO_INPUT { DWORD Version; DWORD Size; DWORD Flags; DWORD NumberOfTierIds; GUID TierIds[ANYSIZE_ARRAY]; }
	// FSCTL_QUERY_REGION_INFO_INPUT, *PFSCTL_QUERY_REGION_INFO_INPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FSCTL_QUERY_REGION_INFO_INPUT")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<FSCTL_QUERY_REGION_INFO_INPUT>), nameof(NumberOfTierIds))]
	[StructLayout(LayoutKind.Sequential)]
	public struct FSCTL_QUERY_REGION_INFO_INPUT
	{
		/// <summary>The size of this structure serves as the version. Set it to <c>sizeof</c>( <c>FSCTL_QUERY_REGION_INFO_INPUT</c>).</summary>
		public uint Version;

		/// <summary>The size of this structure in bytes.</summary>
		public uint Size;

		/// <summary>Reserved for future use.</summary>
		public uint Flags;

		/// <summary>Number of entries in <c>TierIds</c>, 0 to request IDs for the entire volume.</summary>
		public uint NumberOfTierIds;

		/// <summary>Array of storage tiers (represented by GUID values) for which to return information.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public Guid[] TierIds;
	}

	/// <summary>Contains information for one or more regions.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-fsctl_query_region_info_output typedef struct
	// _FSCTL_QUERY_REGION_INFO_OUTPUT { DWORD Version; DWORD Size; DWORD Flags; DWORD Reserved; DWORDLONG Alignment; DWORD
	// TotalNumberOfRegions; DWORD NumberOfRegionsReturned; FILE_STORAGE_TIER_REGION Regions[ANYSIZE_ARRAY]; }
	// FSCTL_QUERY_REGION_INFO_OUTPUT, *PFSCTL_QUERY_REGION_INFO_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FSCTL_QUERY_REGION_INFO_OUTPUT")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<FSCTL_QUERY_REGION_INFO_OUTPUT>), nameof(NumberOfRegionsReturned))]
	[StructLayout(LayoutKind.Sequential)]
	public struct FSCTL_QUERY_REGION_INFO_OUTPUT
	{
		/// <summary>The size of this structure serves as the version. Set it to <c>sizeof</c>( <c>FSCTL_QUERY_REGION_INFO_OUTPUT</c>).</summary>
		public uint Version;

		/// <summary>The size of this structure in bytes.</summary>
		public uint Size;

		/// <summary>Reserved for future use.</summary>
		public uint Flags;

		/// <summary>Reserved for future use.</summary>
		public uint Reserved;

		/// <summary>
		/// Offset from the beginning of the volume to the first slab of the tiered volume. If the logical disk is made up of multiple
		/// tiers and each tier maps to a set of regions then the first tier for the volume contained on the logical disk has a certain
		/// offset within the tier that represents the offset of the volume on the logical disk. The <c>Alignment</c> member contains
		/// this value.
		/// </summary>
		public ulong Alignment;

		/// <summary>Total number of available regions.</summary>
		public uint TotalNumberOfRegions;

		/// <summary>Number of regions that fit in the output.</summary>
		public uint NumberOfRegionsReturned;

		/// <summary>FILE_STORAGE_TIER_REGION struct that contains detailed information for each region.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public FILE_STORAGE_TIER_REGION[] Regions;
	}

	/// <summary>Contains information for all tiers of a specific volume.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-fsctl_query_storage_classes_output typedef struct
	// _FSCTL_QUERY_STORAGE_CLASSES_OUTPUT { DWORD Version; DWORD Size; DWORD Flags; DWORD TotalNumberOfTiers; DWORD
	// NumberOfTiersReturned; FILE_STORAGE_TIER Tiers[ANYSIZE_ARRAY]; } FSCTL_QUERY_STORAGE_CLASSES_OUTPUT, *PFSCTL_QUERY_STORAGE_CLASSES_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FSCTL_QUERY_STORAGE_CLASSES_OUTPUT")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<FSCTL_QUERY_STORAGE_CLASSES_OUTPUT>), nameof(NumberOfTiersReturned))]
	[StructLayout(LayoutKind.Sequential)]
	public struct FSCTL_QUERY_STORAGE_CLASSES_OUTPUT
	{
		/// <summary>The size of this structure serves as the version. Set it to <c>sizeof</c>( <c>FSCTL_QUERY_STORAGE_CLASSES_OUTPUT</c>).</summary>
		public uint Version;

		/// <summary>Size of this structure plus all the variable sized fields.</summary>
		public uint Size;

		/// <summary>
		/// <para>The element status. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FILE_STORAGE_TIER_FLAG_NO_SEEK_PENALTY 0x00020000</term>
		/// <term>Tier does not suffer a seek penalty on IO operations, which indicates that is an SSD (solid state drive).</term>
		/// </item>
		/// </list>
		/// </summary>
		public FILE_STORAGE_TIER_FLAG Flags;

		/// <summary>Total number of available tiers for this disk.</summary>
		public uint TotalNumberOfTiers;

		/// <summary>Number of tiers that fit in the output.</summary>
		public uint NumberOfTiersReturned;

		/// <summary>FILE_STORAGE_TIER structure that contains detailed info on the storage tiers.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public FILE_STORAGE_TIER[] Tiers;
	}

	/// <summary>Input buffer passed with the FSCTL_SET_INTEGRITY_INFORMATION control code.</summary>
	/// <remarks>
	/// If <c>FSCTL_INTEGRITY_FLAG_CHECKSUM_ENFORCEMENT_OFF</c> is specified and the file is opened with sharing permissions such that
	/// subsequent opens can succeed, it's possible for corrupt data to be read by an application that did not specify <c>FSCTL_INTEGRITY_FLAG_CHECKSUM_ENFORCEMENT_OFF</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-fsctl_set_integrity_information_buffer typedef struct
	// _FSCTL_SET_INTEGRITY_INFORMATION_BUFFER { WORD ChecksumAlgorithm; WORD Reserved; DWORD Flags; }
	// FSCTL_SET_INTEGRITY_INFORMATION_BUFFER, *PFSCTL_SET_INTEGRITY_INFORMATION_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._FSCTL_SET_INTEGRITY_INFORMATION_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FSCTL_SET_INTEGRITY_INFORMATION_BUFFER
	{
		/// <summary>
		/// <para>Specifies the checksum algorithm.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CHECKSUM_TYPE_NONE 0x0000</term>
		/// <term>The file or directory is not configured to use integrity.</term>
		/// </item>
		/// <item>
		/// <term>CHECKSUM_TYPE_CRC64 0x0002</term>
		/// <term>The file or directory uses a CRC64 checksum to provide integrity.</term>
		/// </item>
		/// <item>
		/// <term>3–0xfffe</term>
		/// <term>Reserved for future use. Must not be used.</term>
		/// </item>
		/// <item>
		/// <term>CHECKSUM_TYPE_UNCHANGED 0xffff</term>
		/// <term>The checksum algorithm is to remain the same.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CHECKSUM_TYPE ChecksumAlgorithm;

		/// <summary>Must be 0</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>Contains zero or more flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>FSCTL_INTEGRITY_FLAG_CHECKSUM_ENFORCEMENT_OFF 0x00000001</term>
		/// <term>
		/// If set, the checksum enforcement is disabled and reads will succeed even if the checksums do not match. This flag is valid
		/// only if the file has an integrity algorithm set. If there is no algorithm set or the CheckSum member is set to
		/// CHECKSUM_TYPE_NONE, then the operation fails with ERROR_INVALID_PARAMETER.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public FSCTL_INTEGRITY_FLAG Flags;
	}

	/// <summary>Represents the parameters of a changer.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-get_changer_parameters typedef struct
	// _GET_CHANGER_PARAMETERS { DWORD Size; WORD NumberTransportElements; WORD NumberStorageElements; WORD NumberCleanerSlots; WORD
	// NumberIEElements; WORD NumberDataTransferElements; WORD NumberOfDoors; WORD FirstSlotNumber; WORD FirstDriveNumber; WORD
	// FirstTransportNumber; WORD FirstIEPortNumber; WORD FirstCleanerSlotAddress; WORD MagazineSize; DWORD DriveCleanTimeout; DWORD
	// Features0; DWORD Features1; BYTE MoveFromTransport; BYTE MoveFromSlot; BYTE MoveFromIePort; BYTE MoveFromDrive; BYTE
	// ExchangeFromTransport; BYTE ExchangeFromSlot; BYTE ExchangeFromIePort; BYTE ExchangeFromDrive; BYTE LockUnlockCapabilities; BYTE
	// PositionCapabilities; BYTE Reserved1[2]; DWORD Reserved2[2]; } GET_CHANGER_PARAMETERS, *PGET_CHANGER_PARAMETERS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_CHANGER_PARAMETERS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GET_CHANGER_PARAMETERS
	{
		/// <summary>
		/// The size of this structure, in bytes. The caller must set this member to
		/// <code>sizeof(GET_CHANGER_PARAMETERS)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>
		/// The number of transport elements in the changer. For a SCSI changer, this is defined in the element address page. This value
		/// is almost always 1, because most changers have a single transport element with one or two picker mechanisms. A changer that
		/// has two picker mechanisms on its transport must not be represented as having two transports, because pickers are not
		/// individually addressable. High-end media libraries can have dual and multiple transport elements for fault tolerance.
		/// </summary>
		public ushort NumberTransportElements;

		/// <summary>
		/// The number of storage elements (slots) in the changer. For a SCSI changer, this is defined in the element address page. This
		/// value represents the maximum number of slots available for this changer including those in removable magazines, whether or
		/// not the magazines are installed. If <c>NumberCleanerSlots</c> is 1, then <c>NumberStorageElements</c> is 1 less than the
		/// maximum number of slots in the changer.
		/// </summary>
		public ushort NumberStorageElements;

		/// <summary>
		/// The number of storage elements (slots) for cleaner cartridges in the changer. If <c>NumberCleanerSlots</c> is 1, then
		/// <c>FirstCleanerSlotAddress</c> indicates the zero-based address of the slot in which a drive cleaner should be inserted. If
		/// the changer does not support drive cleaning by programmatically moving the cleaner cartridge from its slot to a drive,
		/// <c>NumberCleanerSlots</c> is 0. <c>NumberCleanerSlots</c> cannot be greater than 1.
		/// </summary>
		public ushort NumberCleanerSlots;

		/// <summary>
		/// The number of import/export elements (insert/eject ports) the changer has for inserting and ejecting media. For a SCSI
		/// changer, this is defined in the element address page. An import/export element must not be part of the storage element
		/// (slot) space, and it must be possible to transport media between the import/export element and a slot using a MOVE MEDIUM
		/// command. If the changer has a door and not a true import/export element, <c>NumberIEElements</c> is 0.
		/// </summary>
		public ushort NumberIEElements;

		/// <summary>
		/// The number of data transfer elements (drives) in the changer. For a SCSI changer, this is defined in the element address
		/// page. Unlike <c>NumberStorageElements</c>, which indicates the total number of possible slots whether or not the slots are
		/// actually present, <c>NumberDataTransferElements</c> indicates the number of drives that are actually present in the changer.
		/// </summary>
		public ushort NumberDataTransferElements;

		/// <summary>
		/// The number of doors in the changer. A door provides access to all media in the changer at once, unlike an insert/eject port,
		/// which provides access to one or more, but not all, media. A changer's door can be a physical front door or a single magazine
		/// that contains all media. If a changer supports only an insert/eject port for inserting and ejecting media,
		/// <c>NumberOfDoors</c> is 0.
		/// </summary>
		public ushort NumberOfDoors;

		/// <summary>
		/// The number used by the changer vendor to identify the first storage element (slot) in the changer to the end user, either by
		/// marking a magazine or by defining a slot numbering scheme in the changer's operators guide. <c>FirstSlotNumber</c> is
		/// typically 0 or 1, but it can be the first address in a consecutive range of slot addresses defined by the vendor.
		/// </summary>
		public ushort FirstSlotNumber;

		/// <summary>
		/// The number used by the changer vendor to identify the first data transfer element (drive) in the changer to the end user.
		/// <c>FirstDriveNumber</c> is typically 0 or 1, but it can be the first address in a consecutive range of drive addresses
		/// defined by the vendor.
		/// </summary>
		public ushort FirstDriveNumber;

		/// <summary>
		/// The number used by the changer vendor to identify the first (and usually only) transport element in the changer to the end
		/// user. <c>FirstTransportNumber</c> is typically 0 or 1, but it can be the first address in a consecutive range of transport
		/// addresses defined by the vendor.
		/// </summary>
		public ushort FirstTransportNumber;

		/// <summary>
		/// The number used by the changer vendor to identify the first (and usually only) insert/eject port in the changer to the end
		/// user. <c>FirstIEPortNumber</c> is typically 0 or 1, but it can be the first address in a consecutive range of insert/eject
		/// port addresses defined by the vendor. If <c>NumberIEElements</c> is 0, <c>FirstIEPortNumber</c> must also be 0.
		/// </summary>
		public ushort FirstIEPortNumber;

		/// <summary>
		/// The number used by the changer vendor to identify the first (and only) slot address assigned to a drive cleaner cartridge to
		/// the end user. This must be the value defined by the vendor in the changer's operators guide. For example, if a changer has 8
		/// slots numbered 1 through 8 and its operator's guide designates slot 8 as the drive cleaner slot, <c>FirstSlotNumber</c>
		/// would be 1 and <c>FirstCleanerSlotAddress</c> would be 8. If the same 8 slots were numbered 0 through 7,
		/// <c>FirstSlotNumber</c> would be 0 and <c>FirstCleanerSlotAddress</c> would be 7. If <c>NumberCleanerSlots</c> is 0,
		/// <c>FirstCleanerSlotAddress</c> must be 0.
		/// </summary>
		public ushort FirstCleanerSlotAddress;

		/// <summary>
		/// The number of slots in the removable magazines in the changer. This member is valid only if CHANGER_CARTRIDGE_MAGAZINE is
		/// set in <c>Features0</c>.
		/// </summary>
		public ushort MagazineSize;

		/// <summary>
		/// Twice the maximum number of seconds a cleaning is expected to take. The changer's drives should be cleaned by its cleaner
		/// cartridge in half the time specified by <c>DriveCleanTimeout</c>. For example, if a drive is typically cleaned in 300
		/// seconds (5 minutes), <c>DriveCleanTimeout</c> should be set to 600.
		/// </summary>
		public uint DriveCleanTimeout;

		/// <summary>
		/// <para>The features supported by the changer. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CHANGER_BAR_CODE_SCANNER_INSTALLED 0x00000001</term>
		/// <term>The changer supports a bar-code reader and the reader is installed.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_CARTRIDGE_MAGAZINE 0x00000100</term>
		/// <term>The changer uses removable cartridge magazines for some or all storage slots.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_CLEANER_ACCESS_NOT_VALID 0x00040000</term>
		/// <term>
		/// The ELEMENT_STATUS_ACCESS flag in a CHANGER_ELEMENT_STATUS structure for a data transport element is invalid when the
		/// transport element contains a cleaning cartridge.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_CLEANER_SLOT 0x00000040</term>
		/// <term>
		/// The changer has a slot designated for a cleaner cartridge. If this flag is set, NumberCleanerSlots must be 1 and
		/// FirstCleanerSlotAddress must specify the address of the cleaner slot.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_CLOSE_IEPORT 0x00000004</term>
		/// <term>The changer has an insert/eject port and can retract the insert/eject port programmatically.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_DEVICE_REINITIALIZE_CAPABLE 0x08000000</term>
		/// <term>The changer can recalibrate its transport element in response to an explicit command.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_DRIVE_CLEANING_REQUIRED 0x00010000</term>
		/// <term>
		/// The changer's drives require periodic cleaning, which must be initiated by either the user or an application, and the
		/// changer can use its transport element to mount a cleaner cartridge in a drive.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_DRIVE_EMPTY_ON_DOOR_ACCESS 0x20000000</term>
		/// <term>The changer requires all drives to be empty (dismounted) before they can be accessed through its door.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_EXCHANGE_MEDIA 0x00000020</term>
		/// <term>
		/// The changer can exchange media between elements. For a SCSI changer, this flag indicates whether the changer supports the
		/// EXCHANGE MEDIUM command.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_INIT_ELEM_STAT_WITH_RANGE 0x00000002</term>
		/// <term>
		/// The changer can initialize elements within a specified range. For a SCSI changer, this flag indicates whether the changer
		/// supports the INITIALIZE ELEMENT STATUS WITH RANGE command.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_KEYPAD_ENABLE_DISABLE 0x10000000</term>
		/// <term>The changer keypad can be enabled and disabled programmatically.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_LOCK_UNLOCK 0x00000080</term>
		/// <term>
		/// The changer's door, insert/eject port, or keypad can be locked or unlocked programmatically. If this flag is set,
		/// LockUnlockCapabilities indicates which elements can be locked or unlocked.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_MEDIUM_FLIP 0x00000200</term>
		/// <term>
		/// The changer's transport element supports flipping (rotating) media. For a SCSI changer, this flag reflects the rotate bit in
		/// the transport geometry parameters page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_OPEN_IEPORT 0x00000008</term>
		/// <term>The changer has an insert/eject port and can extend the insert/eject port programmatically.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_POSITION_TO_ELEMENT 0x00000400</term>
		/// <term>
		/// The changer can position the transport to a particular destination. For a SCSI changer, this flag indicates whether the
		/// changer supports the POSITION TO ELEMENT command. If this flag is set, PositionCapabilities indicates the elements to which
		/// the transport can be positioned.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_PREDISMOUNT_EJECT_REQUIRED 0x00020000</term>
		/// <term>
		/// The changer requires an explicit command issued through a mass-storage driver (tape, disk, or CDROM, for example) to eject
		/// media from a drive before the changer can move the media from a drive to a slot.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_PREMOUNT_EJECT_REQUIRED 0x00080000</term>
		/// <term>
		/// The changer requires an explicit command issued through a mass storage driver to eject a drive mechanism before the changer
		/// can move media from a slot to the drive. For example, a changer with CD-ROM drives might require the tray to be presented to
		/// the robotic transport so that a piece of media could be loaded onto the tray during a mount operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_REPORT_IEPORT_STATE 0x00000800</term>
		/// <term>
		/// The changer can report whether media is present in the insert/eject port. Such a changer must have a sensor in the
		/// insert/eject port to detect the presence or absence of media.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_SERIAL_NUMBER_VALID 0x04000000</term>
		/// <term>
		/// The serial number is valid and unique for all changers of this type. Serial numbers are not guaranteed to be unique across
		/// vendor and product lines.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_STATUS_NON_VOLATILE 0x00000010</term>
		/// <term>The changer uses nonvolatile memory for element status information.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_STORAGE_DRIVE 0x00001000</term>
		/// <term>
		/// The changer can use a drive as an independent storage element; that is, it can store media in the drive without reading it.
		/// For a SCSI changer, this flag reflects the state of the DT bit in the device capabilities page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_STORAGE_IEPORT 0x00002000</term>
		/// <term>
		/// The changer can use an insert/eject port as an independent storage element. For a SCSI changer, this flag reflects the state
		/// of the I/E bit in the device capabilities page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_STORAGE_SLOT 0x00004000</term>
		/// <term>
		/// The changer can use a slot as an independent storage element for media. For a SCSI changer, this flag reflects the state of
		/// the ST bit in the device capabilities page. Slots are the normal storage location for media, so the changer must support
		/// this functionality.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_STORAGE_TRANSPORT 0x00008000</term>
		/// <term>
		/// The changer can use a transport as an independent storage element. For a SCSI changer, this flag reflects the state of the
		/// MT bit in the device capabilities page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_VOLUME_ASSERT 0x00400000</term>
		/// <term>
		/// The changer can verify volume information. For a SCSI changer, this flag indicates whether the changer supports the SEND
		/// VOLUME TAG command with a send action code of ASSERT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_VOLUME_IDENTIFICATION 0x00100000</term>
		/// <term>
		/// The changer supports volume identification. For a SCSI changer, this flag indicates whether the changer supports the SEND
		/// VOLUME TAG and REQUEST VOLUME ELEMENT ADDRESS commands.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_VOLUME_REPLACE 0x00800000</term>
		/// <term>
		/// The changer can replace volume information. For a SCSI changer, this flag indicates whether the changer supports the SEND
		/// VOLUME TAG command with a send action code of REPLACE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_VOLUME_SEARCH 0x00200000</term>
		/// <term>
		/// The changer can search for volume information. For a SCSI changer, this flag indicates whether the changer supports the
		/// supports the SEND VOLUME TAG command with a send action code of TRANSLATE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_VOLUME_UNDEFINE 0x01000000</term>
		/// <term>
		/// The changer can clear existing volume information. For a SCSI changer, this flag indicates whether the changer supports the
		/// SEND VOLUME TAG command with a send action code of UNDEFINE.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CHANGER_FEATURES0 Features0;

		/// <summary>
		/// <para>Any additional features supported by the changer. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CHANGER_CLEANER_AUTODISMOUNT 0x80000004</term>
		/// <term>The changer will move the cleaning cartridge back to its original slot automatically after cleaning is finished.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_CLEANER_OPS_NOT_SUPPORTED 0x80000040</term>
		/// <term>The changer does not support automatic cleaning of its elements.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_IEPORT_USER_CONTROL_CLOSE 0x80000100</term>
		/// <term>The changer requires the user to manually close an open insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_IEPORT_USER_CONTROL_OPEN 0x80000080</term>
		/// <term>The changer requires the user to manually open a closed insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_MOVE_EXTENDS_IEPORT 0x80000200</term>
		/// <term>The changer will extend the tray automatically whenever a command is issued to move media to an insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_MOVE_RETRACTS_IEPORT 0x80000400</term>
		/// <term>The changer will retract the tray automatically whenever a command is issued to move media from an insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_PREDISMOUNT_ALIGN_TO_DRIVE 0x80000002</term>
		/// <term>
		/// The changer requires an explicit command to position the transport element to a drive before it can eject media from the drive.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_PREDISMOUNT_ALIGN_TO_SLOT 0x80000001</term>
		/// <term>
		/// The changer requires an explicit command to position the transport element to a slot before it can eject media from the slot.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_RTN_MEDIA_TO_ORIGINAL_ADDR 0x80000020</term>
		/// <term>The changer requires media to be returned to its original slot after it has been moved.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_SLOTS_USE_TRAYS 0x80000010</term>
		/// <term>
		/// The changer uses removable trays in its slots, which require the media to be placed in a tray and the tray moved to the
		/// desired position.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CHANGER_TRUE_EXCHANGE_CAPABLE 0x80000008</term>
		/// <term>
		/// The changer can exchange media between a source and a destination in a single operation. This flag is valid only if
		/// CHANGER_EXCHANGE_MEDIA is also set in Features0.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CHANGER_FEATURES1 Features1;

		/// <summary>
		/// <para>
		/// Indicates whether the changer supports moving a piece of media from a transport element to another transport element, a
		/// storage slot, an insert/eject port, or a drive. For a SCSI changer, this is defined in the device capabilities page. The
		/// transport is not typically the source or destination for moving or exchanging media.
		/// </para>
		/// <para>To determine whether the changer can move media to a given element, use the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CHANGER_TO_DRIVE 0x08</term>
		/// <term>The changer can carry out the operation from the specified element to a drive.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_TO_IEPORT 0x04</term>
		/// <term>The changer can carry out the operation from the specified element to an insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_TO_SLOT 0x02</term>
		/// <term>The changer can carry out the operation from the specified element to a storage slot.</term>
		/// </item>
		/// <item>
		/// <term>CHANGER_TO_TRANSPORT 0x01</term>
		/// <term>The changer can carry out the operation from the specified element to a transport.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CHANGER_MOVE MoveFromTransport;

		/// <summary>
		/// Indicates whether the changer supports moving medium from a storage slot to a transport element, another storage slot, an
		/// insert/eject port, or a drive. Use the flags described under <c>MoveFromTransport</c> to determine whether the changer
		/// supports the move.
		/// </summary>
		public byte MoveFromSlot;

		/// <summary>
		/// Indicates whether the changer supports moving medium from an insert/eject port to a transport element, a storage slot,
		/// another insert/eject port, or a drive. For a SCSI changer, this is defined in the device capabilities page. Use the flags
		/// described under <c>MoveFromTransport</c> to determine whether the changer supports the move.
		/// </summary>
		public byte MoveFromIePort;

		/// <summary>
		/// Indicates whether the changer supports moving medium from a drive to a transport element, a storage slot, an insert/eject
		/// port, or another drive. Use the flags described under <c>MoveFromTransport</c> to determine whether the changer supports the move.
		/// </summary>
		public byte MoveFromDrive;

		/// <summary>
		/// Indicates whether the changer supports exchanging medium between a transport element and another transport element, a
		/// storage slot, an insert/eject port, or a drive. Use the flags described under <c>MoveFromTransport</c> to determine whether
		/// the changer supports the exchange.
		/// </summary>
		public byte ExchangeFromTransport;

		/// <summary>
		/// Indicates whether the changer supports exchanging medium between a storage slot and a transport element, another storage
		/// slot, an insert/eject port, or a drive. Use the flags described under <c>MoveFromTransport</c> to determine whether the
		/// changer supports the exchange.
		/// </summary>
		public byte ExchangeFromSlot;

		/// <summary>
		/// Indicates whether the changer supports exchanging medium between an insert/eject port and a transport element, a storage
		/// slot, another insert/eject port, or a drive. Use the flags described under <c>MoveFromTransport</c> to determine whether the
		/// changer supports the exchange.
		/// </summary>
		public byte ExchangeFromIePort;

		/// <summary>
		/// Indicates whether the changer supports exchanging medium between a drive and a transport element, a storage slot, an
		/// insert/eject port, or another drive. Use the flags described under <c>MoveFromTransport</c> to determine whether the changer
		/// supports the exchange.
		/// </summary>
		public byte ExchangeFromDrive;

		/// <summary>
		/// <para>
		/// The elements of a changer that can be locked or unlocked programmatically. This member is valid only if CHANGER_LOCK_UNLOCK
		/// is set in <c>Features0</c>.
		/// </para>
		/// <para>To determine whether the changer can lock or unlock a particular element, use one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LOCK_UNLOCK_DOOR 0x02</term>
		/// <term>The changer can lock or unlock its door.</term>
		/// </item>
		/// <item>
		/// <term>LOCK_UNLOCK_IEPORT 0x01</term>
		/// <term>The changer can lock or unlock its insert/eject port.</term>
		/// </item>
		/// <item>
		/// <term>LOCK_UNLOCK_KEYPAD 0x04</term>
		/// <term>The changer can lock or unlock its keypad.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CHANGER_LOCK LockUnlockCapabilities;

		/// <summary>
		/// The elements to which a changer can position its transport. Use the flags described under <c>MoveFromTransport</c> to
		/// determine whether the changer supports positioning the transport to a particular element. This member is valid only if
		/// CHANGER_POSITION_TO_ELEMENT is set in <c>Features0</c>.
		/// </summary>
		public byte PositionCapabilities;

		/// <summary>Reserved for future use.</summary>
		public ushort Reserved1;

		/// <summary>Reserved for future use.</summary>
		public ulong Reserved2;
	}

	/// <summary>
	/// Contains the attributes of a disk device. Returned as the output buffer from the IOCTL_DISK_GET_DISK_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-get_disk_attributes typedef struct _GET_DISK_ATTRIBUTES {
	// DWORD Version; DWORD Reserved1; DWORDLONG Attributes; } GET_DISK_ATTRIBUTES, *PGET_DISK_ATTRIBUTES;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_DISK_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GET_DISK_ATTRIBUTES
	{
		/// <summary>
		/// Set to
		/// <code>sizeof(GET_DISK_ATTRIBUTES)</code>
		/// .
		/// </summary>
		public uint Version;

		/// <summary>Reserved.</summary>
		public uint Reserved1;

		/// <summary>
		/// <para>Contains attributes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DISK_ATTRIBUTE_OFFLINE 0x0000000000000001</term>
		/// <term>The disk is offline.</term>
		/// </item>
		/// <item>
		/// <term>DISK_ATTRIBUTE_READ_ONLY 0x0000000000000002</term>
		/// <term>The disk is read-only.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DISK_ATTRIBUTE Attributes;
	}

	/// <summary>Contains disk, volume, or partition length information used by the IOCTL_DISK_GET_LENGTH_INFO control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-get_length_information typedef struct
	// _GET_LENGTH_INFORMATION { LARGE_INTEGER Length; } GET_LENGTH_INFORMATION, *PGET_LENGTH_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_LENGTH_INFORMATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct GET_LENGTH_INFORMATION
	{
		/// <summary>The length of the disk, volume, or partition, in bytes.</summary>
		public long Length;
	}

	/// <summary>Contains information about the media types supported by a device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-get_media_types typedef struct _GET_MEDIA_TYPES { DWORD
	// DeviceType; DWORD MediaInfoCount; DEVICE_MEDIA_INFO MediaInfo[1]; } GET_MEDIA_TYPES, *PGET_MEDIA_TYPES;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._GET_MEDIA_TYPES")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<GET_MEDIA_TYPES>), nameof(MediaInfoCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct GET_MEDIA_TYPES
	{
		/// <summary>
		/// <para>
		/// The type of device. Values from 0 through 32,767 are reserved for use by Microsoft Corporation. Values from 32,768 through
		/// 65,535 are reserved for use by other vendors. The following values are defined by Microsoft:
		/// </para>
		/// <para>FILE_DEVICE_8042_PORT</para>
		/// <para>FILE_DEVICE_ACPI</para>
		/// <para>FILE_DEVICE_BATTERY</para>
		/// <para>FILE_DEVICE_BEEP</para>
		/// <para>FILE_DEVICE_BLUETOOTH</para>
		/// <para>FILE_DEVICE_BUS_EXTENDER</para>
		/// <para>FILE_DEVICE_CD_ROM</para>
		/// <para>FILE_DEVICE_CD_ROM_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_CHANGER</para>
		/// <para>FILE_DEVICE_CONTROLLER</para>
		/// <para>FILE_DEVICE_CRYPT_PROVIDER</para>
		/// <para>FILE_DEVICE_DATALINK</para>
		/// <para>FILE_DEVICE_DFS</para>
		/// <para>FILE_DEVICE_DFS_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_DFS_VOLUME</para>
		/// <para>FILE_DEVICE_DISK</para>
		/// <para>FILE_DEVICE_DISK_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_DVD</para>
		/// <para>FILE_DEVICE_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_FIPS</para>
		/// <para>FILE_DEVICE_FULLSCREEN_VIDEO</para>
		/// <para>FILE_DEVICE_INFINIBAND</para>
		/// <para>FILE_DEVICE_INPORT_PORT</para>
		/// <para>FILE_DEVICE_KEYBOARD</para>
		/// <para>FILE_DEVICE_KS</para>
		/// <para>FILE_DEVICE_KSEC</para>
		/// <para>FILE_DEVICE_MAILSLOT</para>
		/// <para>FILE_DEVICE_MASS_STORAGE</para>
		/// <para>FILE_DEVICE_MIDI_IN</para>
		/// <para>FILE_DEVICE_MIDI_OUT</para>
		/// <para>FILE_DEVICE_MODEM</para>
		/// <para>FILE_DEVICE_MOUSE</para>
		/// <para>FILE_DEVICE_MULTI_UNC_PROVIDER</para>
		/// <para>FILE_DEVICE_NAMED_PIPE</para>
		/// <para>FILE_DEVICE_NETWORK</para>
		/// <para>FILE_DEVICE_NETWORK_BROWSER</para>
		/// <para>FILE_DEVICE_NETWORK_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_NETWORK_REDIRECTOR</para>
		/// <para>FILE_DEVICE_NULL</para>
		/// <para>FILE_DEVICE_PARALLEL_PORT</para>
		/// <para>FILE_DEVICE_PHYSICAL_NETCARD</para>
		/// <para>FILE_DEVICE_PRINTER</para>
		/// <para>FILE_DEVICE_SCANNER</para>
		/// <para>FILE_DEVICE_SCREEN</para>
		/// <para>FILE_DEVICE_SERENUM</para>
		/// <para>FILE_DEVICE_SERIAL_MOUSE_PORT</para>
		/// <para>FILE_DEVICE_SERIAL_PORT</para>
		/// <para>FILE_DEVICE_SMARTCARD</para>
		/// <para>FILE_DEVICE_SMB</para>
		/// <para>FILE_DEVICE_SOUND</para>
		/// <para>FILE_DEVICE_STREAMS</para>
		/// <para>FILE_DEVICE_TAPE</para>
		/// <para>FILE_DEVICE_TAPE_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_TERMSRV</para>
		/// <para>FILE_DEVICE_TRANSPORT</para>
		/// <para>FILE_DEVICE_UNKNOWN</para>
		/// <para>FILE_DEVICE_VDM</para>
		/// <para>FILE_DEVICE_VIDEO</para>
		/// <para>FILE_DEVICE_VIRTUAL_DISK</para>
		/// <para>FILE_DEVICE_VMBUS</para>
		/// <para>FILE_DEVICE_WAVE_IN</para>
		/// <para>FILE_DEVICE_WAVE_OUT</para>
		/// <para>FILE_DEVICE_WPD</para>
		/// </summary>
		public DEVICE_TYPE DeviceType;

		private readonly ushort Reserved;

		/// <summary>The number of elements in the <c>MediaInfo</c> array.</summary>
		public uint MediaInfoCount;

		/// <summary>
		/// A pointer to the first DEVICE_MEDIA_INFO structure in the array. There is one structure for each media type supported by the device.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public DEVICE_MEDIA_INFO[] MediaInfo;
	}

	/// <summary>
	/// Returned from the FSCTL_LOOKUP_STREAM_FROM_CLUSTER control code. Zero or more of these structures follow the
	/// LOOKUP_STREAM_FROM_CLUSTER_OUTPUT structure in the output buffer returned.
	/// </summary>
	/// <remarks>
	/// The name in the <c>FileName</c> member can be very long and in a format not recognized by a customer with the stream name and
	/// attribute type name following the filename. While it's appropriate to log the entire filename for diagnostic purposes, if it is
	/// to be presented to an end-user it should be reformatted to be more understandable (for example, remove the attribute type name
	/// and if the <c>Flags</c> member has any flag other than <c>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_DATA</c> set then an
	/// appropriate message should be displayed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-lookup_stream_from_cluster_entry typedef struct
	// _LOOKUP_STREAM_FROM_CLUSTER_ENTRY { DWORD OffsetToNext; DWORD Flags; LARGE_INTEGER Reserved; LARGE_INTEGER Cluster; WCHAR
	// FileName[1]; } LOOKUP_STREAM_FROM_CLUSTER_ENTRY, *PLOOKUP_STREAM_FROM_CLUSTER_ENTRY;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._LOOKUP_STREAM_FROM_CLUSTER_ENTRY")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<LOOKUP_STREAM_FROM_CLUSTER_ENTRY>), "*")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LOOKUP_STREAM_FROM_CLUSTER_ENTRY
	{
		/// <summary>
		/// Offset in bytes from the beginning of this structure to the next <c>LOOKUP_STREAM_FROM_CLUSTER_ENTRY</c> structure returned.
		/// If there are no more entries, this value is zero.
		/// </summary>
		public uint OffsetToNext;

		/// <summary>
		/// <para>
		/// Flags describing characteristics about this stream. The value will consist of one or more of these values. At least one of
		/// the <c>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_*</c> values that fall within the
		/// <c>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_MASK</c> (0xff000000) will be set; one or more of the other flag values may be set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_PAGE_FILE 0x00000001</term>
		/// <term>The stream is part of the system pagefile.</term>
		/// </item>
		/// <item>
		/// <term>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_DENY_DEFRAG_SET 0x00000002</term>
		/// <term>
		/// The stream is locked from defragmentation. The HandleInfo member of the MARK_HANDLE_INFO structure for this stream has the
		/// MARK_HANDLE_PROTECT_CLUSTERS flag set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_FS_SYSTEM_FILE 0x00000004</term>
		/// <term>The stream is part of a file that is internal to the filesystem.</term>
		/// </item>
		/// <item>
		/// <term>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG_TXF_SYSTEM_FILE 0x00000008</term>
		/// <term>The stream is part of a file that is internal to TxF.</term>
		/// </item>
		/// <item>
		/// <term>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_DATA 0x01000000</term>
		/// <term>The stream is part of a $DATA attribute for the file (data stream).</term>
		/// </item>
		/// <item>
		/// <term>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_INDEX 0x02000000</term>
		/// <term>The stream is part of the $INDEX_ALLOCATION attribute for the file.</term>
		/// </item>
		/// <item>
		/// <term>LOOKUP_STREAM_FROM_CLUSTER_ENTRY_ATTRIBUTE_SYSTEM 0x03000000</term>
		/// <term>The stream is part of another attribute for the file.</term>
		/// </item>
		/// </list>
		/// </summary>
		public LOOKUP_STREAM_FROM_CLUSTER_ENTRY_FLAG Flags;

		/// <summary>This value is reserved and is currently zero.</summary>
		public long Reserved;

		/// <summary>This is the cluster that this entry refers to. It will be one of the clusters passed in the input structure.</summary>
		public long Cluster;

		/// <summary>
		/// A <c>NULL</c>-terminated Unicode string containing the path of the object relative to the root of the volume. This string
		/// will refer to the attribute or stream represented by the cluster. This string is not limited by <c>MAX_PATH</c> and may be
		/// up to 32,768 characters (65,536 bytes) in length. Not all of the filenames returned can be opened; some are internal to NTFS
		/// and always opened exclusively. The string returned includes the full path including filename, stream name, and attribute
		/// type name in the form "full\path\to\file\filename.ext:streamname:typename".
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string FileName;
	}

	/// <summary>Passed as input to the FSCTL_LOOKUP_STREAM_FROM_CLUSTER control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-lookup_stream_from_cluster_input typedef struct
	// _LOOKUP_STREAM_FROM_CLUSTER_INPUT { DWORD Flags; DWORD NumberOfClusters; LARGE_INTEGER Cluster[1]; }
	// LOOKUP_STREAM_FROM_CLUSTER_INPUT, *PLOOKUP_STREAM_FROM_CLUSTER_INPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._LOOKUP_STREAM_FROM_CLUSTER_INPUT")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<LOOKUP_STREAM_FROM_CLUSTER_INPUT>), nameof(NumberOfClusters))]
	[StructLayout(LayoutKind.Sequential)]
	public struct LOOKUP_STREAM_FROM_CLUSTER_INPUT
	{
		/// <summary>Flags for the operation. Currently no flags are defined.</summary>
		public uint Flags;

		/// <summary>
		/// Number of clusters in the following array of clusters. The input buffer must be large enough to contain this number or the
		/// operation will fail.
		/// </summary>
		public uint NumberOfClusters;

		/// <summary>An array of one or more clusters to look up.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public long[] Cluster;
	}

	/// <summary>Received as output from the FSCTL_LOOKUP_STREAM_FROM_CLUSTER control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-lookup_stream_from_cluster_output typedef struct
	// _LOOKUP_STREAM_FROM_CLUSTER_OUTPUT { DWORD Offset; DWORD NumberOfMatches; DWORD BufferSizeRequired; }
	// LOOKUP_STREAM_FROM_CLUSTER_OUTPUT, *PLOOKUP_STREAM_FROM_CLUSTER_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._LOOKUP_STREAM_FROM_CLUSTER_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LOOKUP_STREAM_FROM_CLUSTER_OUTPUT
	{
		/// <summary>
		/// Offset from the beginning of this structure to the first entry returned. If no entries are returned, this value is zero.
		/// </summary>
		public uint Offset;

		/// <summary>
		/// Number of matches to the input criteria. Note that more matches may be found than entries returned if the buffer provided is
		/// not large enough.
		/// </summary>
		public uint NumberOfMatches;

		/// <summary>Minimum size of the buffer, in bytes, which would be needed to contain all matching entries to the input criteria.</summary>
		public uint BufferSizeRequired;
	}

	/// <summary>
	/// Contains information that is used to mark a specified file or directory, and its update sequence number (USN) change journal
	/// record with data about changes. It is used by the FSCTL_MARK_HANDLE control code.
	/// </summary>
	/// <remarks>
	/// <para>To retrieve a handle to a volume, call CreateFile with the lpFileName parameter set to a string in the following form:</para>
	/// <para>"\.\X:"</para>
	/// <para>In the preceding string, X is the letter identifying the drive on which the volume appears.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-mark_handle_info typedef struct { union { DWORD
	// UsnSourceInfo; DWORD CopyNumber; } DUMMYUNIONNAME; DWORD UsnSourceInfo; HANDLE VolumeHandle; DWORD HandleInfo; }
	// MARK_HANDLE_INFO, *PMARK_HANDLE_INFO;
	[PInvokeData("winioctl.h", MSDNShortId = "ns-winioctl-mark_handle_info")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MARK_HANDLE_INFO
	{
		/// <summary>
		/// <para>The type of changes being made.</para>
		/// <para>
		/// The operation does not modify the file or directory externally from the point of view of the application that created it.
		/// </para>
		/// <para>
		/// When a thread writes a new USN record, the source information flags in the prior record continues to be present only if the
		/// thread also sets those flags. Therefore, the source information structure allows applications to filter out USN records that
		/// are set only by a known source, such as an antivirus filter.
		/// </para>
		/// <para>The following values are defined.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>USN_SOURCE_DATA_MANAGEMENT 0x00000001</term>
		/// <term>
		/// The operation provides information about a change to the file or directory made by the operating system. A typical use is
		/// when Remote Storage moves data from external to local storage. Remote Storage is the hierarchical storage management
		/// software. Such a move usually at a minimum adds the USN_REASON_DATA_OVERWRITE flag to a USN record. However, the data has
		/// not changed from the user point of view. By noting USN_SOURCE_DATA_MANAGEMENT in the SourceInfo member of the USN_RECORD
		/// structure that holds the record, you can determine that although a write operation is performed on the item, data has not changed.
		/// </term>
		/// </item>
		/// <item>
		/// <term>USN_SOURCE_AUXILIARY_DATA 0x00000002</term>
		/// <term>
		/// The operation adds a private data stream to a file or directory. An example might be a virus detector adding checksum
		/// information. As the virus detector modifies the item, the system generates USN records. USN_SOURCE_AUXILIARY_DATA indicates
		/// that the modifications did not change the application data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>USN_SOURCE_REPLICATION_MANAGEMENT 0x00000004</term>
		/// <term>
		/// The operation creates or updates the contents of a replicated file. For example, the file replication service sets this flag
		/// when it creates or updates a file in a replicated directory.
		/// </term>
		/// </item>
		/// <item/>
		/// <item>
		/// <term>USN_SOURCE_CLIENT_REPLICATION_MANAGEMENT 0x00000008</term>
		/// <term>Replication is being performed on client systems either from the cloud or servers.</term>
		/// </item>
		/// </list>
		/// </summary>
		public USN_SOURCE UsnSourceInfo { get => (USN_SOURCE)CopyNumber; set => CopyNumber = (uint)value; }


		/// <summary/>
		public uint CopyNumber;

		/// <summary>
		/// <para>
		/// The volume handle to the volume where the file or directory resides. For more information on obtaining a volume handle, see
		/// the Remarks section.
		/// </para>
		/// <para>This handle is required to check the privileges for this operation.</para>
		/// <para>The caller must have the <c>SE_MANAGE_VOLUME_NAME</c> privilege. For more information, see Privileges.</para>
		/// </summary>
		public HFILE VolumeHandle;

		/// <summary>
		/// <para>
		/// The flag that specifies additional information about the file or directory identified by the handle value in the
		/// <c>VolumeHandle</c> member.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MARK_HANDLE_PROTECT_CLUSTERS 0x00000001</term>
		/// <term>
		/// The file is marked as unable to be defragmented until the handle is closed. Once a handle marked
		/// MARK_HANDLE_PROTECT_CLUSTERS is closed, there is no guarantee that the file's clusters won't move.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_TXF_SYSTEM_LOG 0x00000004</term>
		/// <term>
		/// The file is marked as unable to be defragmented until the handle is closed. Windows Server 2003: This flag is not supported
		/// until Windows Server 2003 with SP1. Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_NOT_TXF_SYSTEM_LOG 0x00000008</term>
		/// <term>
		/// The file is marked as unable to be defragmented until the handle is closed. Windows Server 2003: This flag is not supported
		/// until Windows Server 2003 with SP1. Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_REALTIME 0x00000020</term>
		/// <term>
		/// The file is marked for real-time read behavior regardless of the actual file type. Files marked with this flag must be
		/// opened for unbuffered I/O. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_NOT_REALTIME 0x00000040</term>
		/// <term>
		/// The file previously marked for real-time read behavior using the MARK_HANDLE_REALTIME flag can be unmarked using this flag,
		/// removing the real-time behavior. Files marked with this flag must be opened for unbuffered I/O. Windows Server 2008, Windows
		/// Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_READ_COPY 0x00000080</term>
		/// <term>
		/// Indicates the copy number specified in the CopyNumber member should be used for reads. Files marked with this flag must be
		/// opened for unbuffered I/O. Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and
		/// Windows XP: This flag is not supported until Windows 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_NOT_READ_COPY 0x00000100</term>
		/// <term>
		/// The file previously marked for read-copy behavior using the MARK_HANDLE_READ_COPY flag can be unmarked using this flag,
		/// removing the read-copy behavior. Files marked with this flag must be opened for unbuffered I/O. Windows Server 2008 R2,
		/// Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This flag is not supported until Windows
		/// 8 and Windows Server 2012.
		/// </term>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_DISABLE_FILE_METADATA_OPTIMIZATION 0x00001000</term>
		/// <term>
		/// A highly fragmented file in NTFS uses multiple MFT records to describe all of the extents for a file. This list of child MFT
		/// records (also known as FRS records) are controlled by a structure known as an attribute list. An attribute list is limited
		/// to 128K in size. When the size of an attribute list hits a certain threshold NTFS will trigger a background compaction on
		/// the extents so the minimum number of child FRS records will be used. This flag disables this FRS compaction feature for the
		/// given file. This flag is not supported until Windows 10.
		/// </term>
		/// </item>
		/// <item>
		/// <term/>
		/// </item>
		/// <item>
		/// <term>MARK_HANDLE_SKIP_COHERENCY_SYNC_DISALLOW_WRITES 0x00004000</term>
		/// <term>
		/// Setting this flag tells the system that writes are not allowed on this file. If an application tries to open the file for
		/// write access, the operation is failed with STATUS_ACCESS_DENIED. If a write is seen the operation is failed with
		/// STATUS_MARKED_TO_DISALLOW_WRITES This flag is not supported until Windows 10.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public MARK_HANDLE_INFO_FLAG HandleInfo;
	}

	/// <summary>Contains input data for the FSCTL_MOVE_FILE control code.</summary>
	/// <remarks>
	/// <para>
	/// To retrieve data to fill in this structure, use the DeviceIoControl function with the FSCTL_GET_RETRIEVAL_POINTERS control code.
	/// </para>
	/// <para>The first cluster of a directory on a FAT file system volume cannot be moved.</para>
	/// <para>
	/// When possible, move data in blocks aligned relative to each other in 16-kilobyte (KB) increments. This reduces copy-on-write
	/// overhead when shadow copies are enabled, because shadow copy space is increased and performance is reduced when the following
	/// conditions occur:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The move request block size is less than or equal to 16 KB.</term>
	/// </item>
	/// <item>
	/// <term>The move delta is not in increments of 16 KB.</term>
	/// </item>
	/// </list>
	/// <para>
	/// The move delta is the number of bytes between the start of the source block and the start of the target block. In other words, a
	/// block starting at offset X (on-disk) can be moved to a starting offset Y if the absolute value of X minus Y is an even multiple
	/// of 16 KB. So, assuming 4-KB clusters, a move from cluster 3 to cluster 27 will be optimized, but a move from cluster 18 to
	/// cluster 24 will not. Note that mod(3,4) = 3 = mod(27,4). Mod 4 is chosen because four clusters at 4 KB each is equivalent to 16
	/// KB. Therefore, a volume formatted to a 16-KB cluster size will result in all move files being optimized.
	/// </para>
	/// <para>For more information about shadow copies, see Volume Shadow Copy Service.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-move_file_data typedef struct { HANDLE FileHandle;
	// LARGE_INTEGER StartingVcn; LARGE_INTEGER StartingLcn; DWORD ClusterCount; } MOVE_FILE_DATA, *PMOVE_FILE_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_10")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct MOVE_FILE_DATA
	{
		/// <summary>
		/// <para>A handle to the file to be moved.</para>
		/// <para>To retrieve a handle to a file, use CreateFile.</para>
		/// <para>
		/// If the file is encrypted, the handle must have the <c>FILE_READ_DATA</c>, <c>FILE_WRITE_DATA</c>, <c>FILE_APPEND_DATA</c>,
		/// or <c>FILE_EXECUTE</c> access right. For more information, see File Security and Access Rights.
		/// </para>
		/// </summary>
		public HFILE FileHandle;

		/// <summary>A VCN (cluster number relative to the beginning of a file) of the first cluster to be moved.</summary>
		public long StartingVcn;

		/// <summary>An LCN (cluster number on a volume) to which the VCN is to be moved.</summary>
		public long StartingLcn;

		/// <summary>The count of clusters to be moved.</summary>
		public uint ClusterCount;
	}

	/// <summary>Represents volume data. This structure is passed to the FSCTL_GET_NTFS_VOLUME_DATA control code.</summary>
	/// <remarks>
	/// <para>Reserved clusters are the free clusters reserved for later use by Windows.</para>
	/// <para>
	/// The <c>NTFS_VOLUME_DATA_BUFFER</c> structure represents the basic information returned by FSCTL_GET_NTFS_VOLUME_DATA. For
	/// extended volume information, pass a buffer that is the combined size of the <c>NTFS_VOLUME_DATA_BUFFER</c> and
	/// <c>NTFS_EXTENDED_VOLUME_DATA</c> structures. Upon success, the buffer returned by <c>FSCTL_GET_NTFS_VOLUME_DATA</c> will contain
	/// the information associated with both structures. The <c>NTFS_VOLUME_DATA_BUFFER</c> structure will always be filled starting at
	/// the beginning of the buffer, with the <c>NTFS_EXTENDED_VOLUME_DATA</c> structure immediately following. The
	/// <c>NTFS_EXTENDED_VOLUME_DATA</c> structure is defined as follows:
	/// </para>
	/// <para>
	/// This structure contains the major and minor version information for an NTFS volume. The <c>ByteCount</c> member will return the
	/// total bytes of the output buffer used for this structure by the call to FSCTL_GET_NTFS_VOLUME_DATA. This value should be
	/// <code>sizeof(NTFS_EXTENDED_VOLUME_DATA)</code>
	/// if the buffer passed was large enough to hold it, otherwise the value will be less than
	/// <code>sizeof(NTFS_EXTENDED_VOLUME_DATA)</code>
	/// .
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-ntfs_extended_volume_data typedef struct { DWORD
	// ByteCount; WORD MajorVersion; WORD MinorVersion; DWORD BytesPerPhysicalSector; WORD LfsMajorVersion; WORD LfsMinorVersion; DWORD
	// MaxDeviceTrimExtentCount; DWORD MaxDeviceTrimByteCount; DWORD MaxVolumeTrimExtentCount; DWORD MaxVolumeTrimByteCount; }
	// NTFS_EXTENDED_VOLUME_DATA, *PNTFS_EXTENDED_VOLUME_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NTFS_EXTENDED_VOLUME_DATA
	{
		/// <summary/>
		public uint ByteCount;

		/// <summary/>
		public ushort MajorVersion;

		/// <summary/>
		public ushort MinorVersion;

		/// <summary/>
		public uint BytesPerPhysicalSector;

		/// <summary/>
		public ushort LfsMajorVersion;

		/// <summary/>
		public ushort LfsMinorVersion;

		/// <summary/>
		public uint MaxDeviceTrimExtentCount;

		/// <summary/>
		public uint MaxDeviceTrimByteCount;

		/// <summary/>
		public uint MaxVolumeTrimExtentCount;

		/// <summary/>
		public uint MaxVolumeTrimByteCount;
	}

	/// <summary>Contains data for the FSCTL_GET_NTFS_FILE_RECORD control code.</summary>
	/// <remarks>Pass this structure as input to the FSCTL_GET_NTFS_FILE_RECORD control code.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-ntfs_file_record_input_buffer typedef struct {
	// LARGE_INTEGER FileReferenceNumber; } NTFS_FILE_RECORD_INPUT_BUFFER, *PNTFS_FILE_RECORD_INPUT_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NTFS_FILE_RECORD_INPUT_BUFFER
	{
		/// <summary>
		/// The file identifier of the file record to be retrieved. This is not necessarily the file identifier returned in the
		/// <c>FileReferenceNumber</c> member of the NTFS_FILE_RECORD_OUTPUT_BUFFER structure. Refer to the Remarks section of the
		/// reference page for FSCTL_GET_NTFS_FILE_RECORD for more information.
		/// </summary>
		public long FileReferenceNumber;
	}

	/// <summary>Receives output data from the FSCTL_GET_NTFS_FILE_RECORD control code.</summary>
	/// <remarks>To retrieve data to fill in this structure, use the DeviceIoControl FSCTL_GET_NTFS_FILE_RECORD control code.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-ntfs_file_record_output_buffer typedef struct {
	// LARGE_INTEGER FileReferenceNumber; DWORD FileRecordLength; BYTE FileRecordBuffer[1]; } NTFS_FILE_RECORD_OUTPUT_BUFFER, *PNTFS_FILE_RECORD_OUTPUT_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_9")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<NTFS_FILE_RECORD_OUTPUT_BUFFER>), nameof(FileRecordLength))]
	[StructLayout(LayoutKind.Sequential)]
	public struct NTFS_FILE_RECORD_OUTPUT_BUFFER
	{
		/// <summary>
		/// The file identifier of the returned file record. This is not necessarily the file identifier specified in the
		/// <c>FileReferenceNumber</c> member of the NTFS_FILE_RECORD_INPUT_BUFFER structure. Refer to the Remarks section of the
		/// reference page for FSCTL_GET_NTFS_FILE_RECORD for more information.
		/// </summary>
		public long FileReferenceNumber;

		/// <summary>The length of the returned file record, in bytes.</summary>
		public uint FileRecordLength;

		/// <summary>The starting location of the buffer for the returned file record.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] FileRecordBuffer;
	}

	/// <summary>Represents volume data. This structure is passed to the FSCTL_GET_NTFS_VOLUME_DATA control code.</summary>
	/// <remarks>
	/// <para>Reserved clusters are the free clusters reserved for later use by Windows.</para>
	/// <para>
	/// The <c>NTFS_VOLUME_DATA_BUFFER</c> structure represents the basic information returned by FSCTL_GET_NTFS_VOLUME_DATA. For
	/// extended volume information, pass a buffer that is the combined size of the <c>NTFS_VOLUME_DATA_BUFFER</c> and
	/// <c>NTFS_EXTENDED_VOLUME_DATA</c> structures. Upon success, the buffer returned by <c>FSCTL_GET_NTFS_VOLUME_DATA</c> will contain
	/// the information associated with both structures. The <c>NTFS_VOLUME_DATA_BUFFER</c> structure will always be filled starting at
	/// the beginning of the buffer, with the <c>NTFS_EXTENDED_VOLUME_DATA</c> structure immediately following. The
	/// <c>NTFS_EXTENDED_VOLUME_DATA</c> structure is defined as follows:
	/// </para>
	/// <para>
	/// This structure contains the major and minor version information for an NTFS volume. The <c>ByteCount</c> member will return the
	/// total bytes of the output buffer used for this structure by the call to FSCTL_GET_NTFS_VOLUME_DATA. This value should be
	/// <code>sizeof(NTFS_EXTENDED_VOLUME_DATA)</code>
	/// if the buffer passed was large enough to hold it, otherwise the value will be less than
	/// <code>sizeof(NTFS_EXTENDED_VOLUME_DATA)</code>
	/// .
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-ntfs_volume_data_buffer typedef struct { LARGE_INTEGER
	// VolumeSerialNumber; LARGE_INTEGER NumberSectors; LARGE_INTEGER TotalClusters; LARGE_INTEGER FreeClusters; LARGE_INTEGER
	// TotalReserved; DWORD BytesPerSector; DWORD BytesPerCluster; DWORD BytesPerFileRecordSegment; DWORD ClustersPerFileRecordSegment;
	// LARGE_INTEGER MftValidDataLength; LARGE_INTEGER MftStartLcn; LARGE_INTEGER Mft2StartLcn; LARGE_INTEGER MftZoneStart;
	// LARGE_INTEGER MftZoneEnd; } NTFS_VOLUME_DATA_BUFFER, *PNTFS_VOLUME_DATA_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct NTFS_VOLUME_DATA_BUFFER
	{
		/// <summary>The serial number of the volume. This is a unique number assigned to the volume media by the operating system.</summary>
		public long VolumeSerialNumber;

		/// <summary>The number of sectors in the specified volume.</summary>
		public long NumberSectors;

		/// <summary>The number of used and free clusters in the specified volume.</summary>
		public long TotalClusters;

		/// <summary>The number of free clusters in the specified volume.</summary>
		public long FreeClusters;

		/// <summary>The number of reserved clusters in the specified volume.</summary>
		public long TotalReserved;

		/// <summary>The number of bytes in a sector on the specified volume.</summary>
		public uint BytesPerSector;

		/// <summary>The number of bytes in a cluster on the specified volume. This value is also known as the cluster factor.</summary>
		public uint BytesPerCluster;

		/// <summary>The number of bytes in a file record segment.</summary>
		public uint BytesPerFileRecordSegment;

		/// <summary>The number of clusters in a file record segment.</summary>
		public uint ClustersPerFileRecordSegment;

		/// <summary>The length of the master file table, in bytes.</summary>
		public long MftValidDataLength;

		/// <summary>The starting logical cluster number of the master file table.</summary>
		public long MftStartLcn;

		/// <summary>The starting logical cluster number of the master file table mirror.</summary>
		public long Mft2StartLcn;

		/// <summary>The starting logical cluster number of the master file table zone.</summary>
		public long MftZoneStart;

		/// <summary>The ending logical cluster number of the master file table zone.</summary>
		public long MftZoneEnd;
	}

	/// <summary>Indicates the range of the read operation to perform and the plex from which to read.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-plex_read_data_request typedef struct
	// _PLEX_READ_DATA_REQUEST { LARGE_INTEGER ByteOffset; DWORD ByteLength; DWORD PlexNumber; } PLEX_READ_DATA_REQUEST, *PPLEX_READ_DATA_REQUEST;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._PLEX_READ_DATA_REQUEST")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PLEX_READ_DATA_REQUEST
	{
		/// <summary>
		/// The offset of the range to be read. The offset can be the virtual offset to a file or volume. File offsets should be cluster
		/// aligned and volume offsets should be sector aligned.
		/// </summary>
		public long ByteOffset;

		/// <summary>The length of the range to be read. The maximum value is 64 KB.</summary>
		public uint ByteLength;

		/// <summary>
		/// The plex from which to read. A value of zero indicates the primary copy, a value of one indicates the secondary copy, and so on.
		/// </summary>
		public uint PlexNumber;
	}

	/// <summary>Provides removable media locking data. It is used by the IOCTL_STORAGE_MEDIA_REMOVAL control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-prevent_media_removal typedef struct
	// _PREVENT_MEDIA_REMOVAL { BOOLEAN PreventMediaRemoval; } PREVENT_MEDIA_REMOVAL, *PPREVENT_MEDIA_REMOVAL;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._PREVENT_MEDIA_REMOVAL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PREVENT_MEDIA_REMOVAL
	{
		/// <summary>If this member is <c>TRUE</c>, the media is to be locked. Otherwise, it is not.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool PreventMediaRemoval;
	}

	/// <summary>Represents the volume tag information. It is used by the IOCTL_CHANGER_QUERY_VOLUME_TAGS control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-read_element_address_info typedef struct
	// _READ_ELEMENT_ADDRESS_INFO { DWORD NumberOfElements; CHANGER_ELEMENT_STATUS ElementStatus[1]; } READ_ELEMENT_ADDRESS_INFO, *PREAD_ELEMENT_ADDRESS_INFO;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._READ_ELEMENT_ADDRESS_INFO")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<READ_ELEMENT_ADDRESS_INFO>), nameof(NumberOfElements))]
	[StructLayout(LayoutKind.Sequential)]
	public struct READ_ELEMENT_ADDRESS_INFO
	{
		/// <summary>
		/// <para>The number of elements matching criteria set forth by the <c>ActionCode</c> member of CHANGER_SEND_VOLUME_TAG_INFORMATION.</para>
		/// <para>For information on compatibility with the current device, see the <c>Features0</c> member of GET_CHANGER_PARAMETERS.</para>
		/// </summary>
		public uint NumberOfElements;

		/// <summary>
		/// An array of CHANGER_ELEMENT_STATUS structures, one for each element that corresponded with the information passed in with
		/// the CHANGER_SEND_VOLUME_TAG_INFORMATION structure.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public CHANGER_ELEMENT_STATUS[] ElementStatus;
	}

	/// <summary>
	/// Contains disk block reassignment data. This is a variable length structure where the last member is an array of block numbers to
	/// be reassigned. It is used by the IOCTL_DISK_REASSIGN_BLOCKS control code.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>REASSIGN_BLOCKS</c> structure only supports drives where the Logical Block Address (LBA) is a 4-byte value (typically up
	/// to 2 TB).
	/// </para>
	/// <para>
	/// For larger drives the REASSIGN_BLOCKS_EX structure that is used with the IOCTL_DISK_REASSIGN_BLOCKS_EX control code supports
	/// 8-byte LBAs.
	/// </para>
	/// <para>
	/// For device compatibility, the IOCTL_DISK_REASSIGN_BLOCKS control code and <c>REASSIGN_BLOCKS</c> structure should be used where possible.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-reassign_blocks typedef struct _REASSIGN_BLOCKS { WORD
	// Reserved; WORD Count; DWORD BlockNumber[1]; } REASSIGN_BLOCKS, *PREASSIGN_BLOCKS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REASSIGN_BLOCKS")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<REASSIGN_BLOCKS>), nameof(Count))]
	[StructLayout(LayoutKind.Sequential)]
	public struct REASSIGN_BLOCKS
	{
		/// <summary>This member is reserved. Do not use it. Set it to zero.</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>The number of blocks to be reassigned.</para>
		/// <para>This is the number of elements that are in the <c>BlockNumber</c> member array.</para>
		/// </summary>
		public ushort Count;

		/// <summary>An array of <c>Count</c> block numbers, one for each block to be reassigned.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] BlockNumber;
	}

	/// <summary>
	/// Contains disk block reassignment data. This is a variable length structure where the last member is an array of block numbers to
	/// be reassigned. It is used by the IOCTL_DISK_REASSIGN_BLOCKS_EX control code.
	/// </summary>
	/// <remarks>
	/// The <c>REASSIGN_BLOCKS_EX</c> structure supports drives that have an 8-byte Logical Block Address (LBA), which is typically
	/// required for storage devices larger than 2 TB. The REASSIGN_BLOCKS structure used with the IOCTL_DISK_REASSIGN_BLOCKS control
	/// code supports devices with up to a 4-byte LBA should be used where possible.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-reassign_blocks_ex typedef struct _REASSIGN_BLOCKS_EX {
	// WORD Reserved; WORD Count; LARGE_INTEGER BlockNumber[1]; } REASSIGN_BLOCKS_EX, *PREASSIGN_BLOCKS_EX;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REASSIGN_BLOCKS_EX")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<REASSIGN_BLOCKS_EX>), nameof(Count))]
	[StructLayout(LayoutKind.Sequential)]
	public struct REASSIGN_BLOCKS_EX
	{
		/// <summary>This member is reserved. Do not use it. Set it to 0 (zero).</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>The number of blocks to be reassigned.</para>
		/// <para>This is the number of elements that are in the <c>BlockNumber</c> member array.</para>
		/// </summary>
		public ushort Count;

		/// <summary>An array of <c>Count</c> block numbers, one for each block to be reassigned.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public long[] BlockNumber;
	}

	/// <summary>
	/// Input structure for the FSCTL_REPAIR_COPIES control code. It describes a single block of data and indicates which of the copies
	/// is to be copied to the specified copies of the data. The
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-repair_copies_input typedef struct _REPAIR_COPIES_INPUT {
	// DWORD Size; DWORD Flags; LARGE_INTEGER FileOffset; DWORD Length; DWORD SourceCopy; DWORD NumberOfRepairCopies; DWORD
	// RepairCopies[ANYSIZE_ARRAY]; } REPAIR_COPIES_INPUT, *PREPAIR_COPIES_INPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REPAIR_COPIES_INPUT")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<REPAIR_COPIES_INPUT>), nameof(NumberOfRepairCopies))]
	[StructLayout(LayoutKind.Sequential)]
	public struct REPAIR_COPIES_INPUT
	{
		/// <summary>
		/// Set to
		/// <code>sizeof(REPAIR_COPIES_INPUT)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>Reserved (must be zero)</summary>
		public uint Flags;

		/// <summary>The file position to start the repair operation.</summary>
		public long FileOffset;

		/// <summary>The number of bytes to be repaired.</summary>
		public uint Length;

		/// <summary>The zero-based copy number of the source copy.</summary>
		public uint SourceCopy;

		/// <summary>The number of copies that will be repaired. This is the size of the <c>RepairCopies</c> array.</summary>
		public uint NumberOfRepairCopies;

		/// <summary>The zero-based copy numbers of the copies that will be repaired.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public uint[] RepairCopies;
	}

	/// <summary>Contains output of a repair copies operation returned from the FSCTL_REPAIR_COPIES control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-repair_copies_output typedef struct _REPAIR_COPIES_OUTPUT
	// { DWORD Size; DWORD Status; LARGE_INTEGER ResumeFileOffset; } REPAIR_COPIES_OUTPUT, *PREPAIR_COPIES_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REPAIR_COPIES_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REPAIR_COPIES_OUTPUT
	{
		/// <summary>
		/// Set to
		/// <code>sizeof(REPAIR_COPIES_OUTPUT)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>
		/// Indicates the status of the repair operation. The value is a <c>NTSTATUS</c> value. See
		/// http://msdn.microsoft.com/en-us/library/cc704588(PROT.10).aspx for a list of <c>NTSTATUS</c> values.
		/// </summary>
		public NTStatus Status;

		/// <summary>
		/// If the <c>Status</c> member indicates the operation was not successful, this is the file offset to use to resume repair
		/// operations, skipping the range where errors were found.
		/// </summary>
		public long ResumeFileOffset;
	}

	/// <summary>
	/// Contains the information to request an opportunistic lock (oplock) or to acknowledge an oplock break with the
	/// FSCTL_REQUEST_OPLOCK control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-request_oplock_input_buffer typedef struct
	// _REQUEST_OPLOCK_INPUT_BUFFER { WORD StructureVersion; WORD StructureLength; DWORD RequestedOplockLevel; DWORD Flags; }
	// REQUEST_OPLOCK_INPUT_BUFFER, *PREQUEST_OPLOCK_INPUT_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REQUEST_OPLOCK_INPUT_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REQUEST_OPLOCK_INPUT_BUFFER
	{
		/// <summary>The version of the <c>REQUEST_OPLOCK_INPUT_BUFFER</c> structure that is being used. Set this member to <c>REQUEST_OPLOCK_CURRENT_VERSION</c>.</summary>
		public ushort StructureVersion;

		/// <summary>
		/// The length of this structure, in bytes. Must be set to
		/// <code>sizeof(REQUEST_OPLOCK_INPUT_BUFFER)</code>
		/// .
		/// </summary>
		public ushort StructureLength;

		/// <summary>
		/// <para>A valid combination of the following oplock level values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>OPLOCK_LEVEL_CACHE_READ</term>
		/// <term>Allows clients to cache reads. May be granted to multiple clients.</term>
		/// </item>
		/// <item>
		/// <term>OPLOCK_LEVEL_CACHE_HANDLE</term>
		/// <term>Allows clients to cache open handles. May be granted to multiple clients.</term>
		/// </item>
		/// <item>
		/// <term>OPLOCK_LEVEL_CACHE_WRITE</term>
		/// <term>Allows clients to cache writes and byte range locks. May be granted only to a single client.</term>
		/// </item>
		/// </list>
		/// <para>Valid combinations of these values are as follows:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// <code>OPLOCK_LEVEL_CACHE_READ</code>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>OPLOCK_LEVEL_CACHE_READ | OPLOCK_LEVEL_CACHE_HANDLE</code>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>OPLOCK_LEVEL_CACHE_READ | OPLOCK_LEVEL_CACHE_WRITE</code>
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>OPLOCK_LEVEL_CACHE_READ | OPLOCK_LEVEL_CACHE_WRITE | OPLOCK_LEVEL_CACHE_HANDLE</code>
		/// </term>
		/// </item>
		/// </list>
		/// <para>For more information about these value combinations, see <c>FSCTL_REQUEST_OPLOCK</c>.</para>
		/// </summary>
		public OPLOCK_LEVEL_CACHE RequestedOplockLevel;

		/// <summary>
		/// <para>A valid combination of the following request flag values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>REQUEST_OPLOCK_INPUT_FLAG_REQUEST</term>
		/// <term>
		/// Request for a new oplock. Setting this flag together with REQUEST_OPLOCK_INPUT_FLAG_ACK is not valid and will cause the
		/// request to fail with ERROR_INVALID_PARAMETER.
		/// </term>
		/// </item>
		/// <item>
		/// <term>REQUEST_OPLOCK_INPUT_FLAG_ACK</term>
		/// <term>
		/// Acknowledgment of an oplock break. Setting this flag together with REQUEST_OPLOCK_ INPUT_FLAG_REQUEST is not valid and will
		/// cause the request to fail with ERROR_INVALID_PARAMETER.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public OPLOCK_INPUT_FLAG Flags;
	}

	/// <summary>Contains the opportunistic lock (oplock) information returned by the FSCTL_REQUEST_OPLOCK control code.</summary>
	/// <remarks>
	/// The <c>REQUEST_OPLOCK_OUTPUT_FLAG_MODES_PROVIDED</c> flag indicates that the <c>ShareMode</c> and <c>AccessMode</c> fields
	/// contain the share and access flags, respectively, of the request causing the oplock break. This information may be provided on
	/// breaks where the <c>OPLOCK_LEVEL_CACHE_HANDLE</c> level is being lost and may be useful to callers who can close handles whose
	/// share and access modes conflict with the handle causing the break. This may enable them to maintain at least some handle cache
	/// state. Note that not all breaks where the <c>OPLOCK_LEVEL_CACHE_HANDLE</c> level is being lost will have this flag set. The
	/// primary case where this flag will be set is if the break is a result of a create operation that needs the
	/// <c>OPLOCK_LEVEL_CACHE_HANDLE</c> oplock to be broken to avoid failing with <c>ERROR_SHARING_VIOLATION</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-request_oplock_output_buffer typedef struct
	// _REQUEST_OPLOCK_OUTPUT_BUFFER { WORD StructureVersion; WORD StructureLength; DWORD OriginalOplockLevel; DWORD NewOplockLevel;
	// DWORD Flags; ACCESS_MASK AccessMode; WORD ShareMode; } REQUEST_OPLOCK_OUTPUT_BUFFER, *PREQUEST_OPLOCK_OUTPUT_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._REQUEST_OPLOCK_OUTPUT_BUFFER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct REQUEST_OPLOCK_OUTPUT_BUFFER
	{
		/// <summary>The version of the <c>REQUEST_OPLOCK_OUTPUT_BUFFER</c> structure that is being used.</summary>
		public ushort StructureVersion;

		/// <summary>The length of this structure, in bytes.</summary>
		public ushort StructureLength;

		/// <summary>
		/// <para>One or more <c>OPLOCK_LEVEL_CACHE_</c> XXX values that indicate the level of the oplock that was broken.</para>
		/// <para>For possible values, see the <c>RequestedOplockLevel</c> member of the REQUEST_OPLOCK_INPUT_BUFFER structure.</para>
		/// </summary>
		public OPLOCK_LEVEL_CACHE OriginalOplockLevel;

		/// <summary>
		/// <para>
		/// One or more <c>OPLOCK_LEVEL_CACHE_</c> XXX values that indicate the level to which an oplock is being broken, or an oplock
		/// level that may be available for granting, depending on the operation returning this buffer.
		/// </para>
		/// <para>For possible values, see the <c>RequestedOplockLevel</c> member of the REQUEST_OPLOCK_INPUT_BUFFER structure.</para>
		/// </summary>
		public OPLOCK_LEVEL_CACHE NewOplockLevel;

		/// <summary>
		/// <para>One or more <c>REQUEST_OPLOCK_OUTPUT_FLAG_</c> XXX values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>REQUEST_OPLOCK_OUTPUT_FLAG_ACK_REQUIRED</term>
		/// <term>
		/// Indicates that an acknowledgment is required, and the oplock described in OriginalOplockLevel will continue to remain in
		/// force until the break is successfully acknowledged.
		/// </term>
		/// </item>
		/// <item>
		/// <term>REQUEST_OPLOCK_OUTPUT_FLAG_MODES_PROVIDED</term>
		/// <term>
		/// Indicates that the ShareMode and AccessMode members contain the share and access flags, respectively, of the request causing
		/// the oplock break. For more information, see the Remarks section.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public OPLOCK_OUTPUT_FLAG Flags;

		/// <summary>
		/// If the <c>REQUEST_OPLOCK_OUTPUT_FLAG_MODES_PROVIDED</c> flag is set and the <c>OPLOCK_LEVEL_CACHE_HANDLE</c> level is being
		/// lost in an oplock break, contains the access mode mode of the request that is causing the break.
		/// </summary>
		public ACCESS_MASK AccessMode;

		/// <summary>
		/// If the <c>REQUEST_OPLOCK_OUTPUT_FLAG_MODES_PROVIDED</c> flag is set and the <c>OPLOCK_LEVEL_CACHE_HANDLE</c> level is being
		/// lost in an oplock break, contains the share mode of the request that is causing the break.
		/// </summary>
		public ushort ShareMode;
	}

	/// <summary>Contains the output for the FSCTL_GET_RETRIEVAL_POINTER_BASE control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-retrieval_pointer_base typedef struct
	// _RETRIEVAL_POINTER_BASE { LARGE_INTEGER FileAreaOffset; } RETRIEVAL_POINTER_BASE, *PRETRIEVAL_POINTER_BASE;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._RETRIEVAL_POINTER_BASE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RETRIEVAL_POINTER_BASE
	{
		/// <summary>
		/// The volume-relative sector offset to the first allocatable unit on the file system, also referred to as the base of the
		/// cluster heap.
		/// </summary>
		public long FileAreaOffset;
	}

	/// <summary>Contains the output for the FSCTL_GET_RETRIEVAL_POINTERS control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-retrieval_pointers_buffer typedef struct
	// RETRIEVAL_POINTERS_BUFFER { DWORD ExtentCount; LARGE_INTEGER StartingVcn; struct { LARGE_INTEGER NextVcn; LARGE_INTEGER Lcn; };
	// __unnamed_struct_17d0_54 Extents[1]; } RETRIEVAL_POINTERS_BUFFER, *PRETRIEVAL_POINTERS_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.RETRIEVAL_POINTERS_BUFFER")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<RETRIEVAL_POINTERS_BUFFER>), nameof(ExtentCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct RETRIEVAL_POINTERS_BUFFER
	{
		/// <summary>The count of elements in the <c>Extents</c> array.</summary>
		public uint ExtentCount;

		/// <summary>
		/// The starting VCN returned by the function call. This is not necessarily the VCN requested by the function call, as the file
		/// system driver may round down to the first VCN of the extent in which the requested starting VCN is found.
		/// </summary>
		public long StartingVcn;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential)]
		public struct EXTENT
		{
			/// <summary/>
			public long NextVcn;

			/// <summary/>
			public long Lcn;
		}

		/// <summary>
		/// <para>
		/// Array of <c>Extents</c> structures. For the number of members in the array, see <c>ExtentCount</c>. Each member of the array
		/// has the following members.
		/// </para>
		/// <para>NextVcn</para>
		/// <para>
		/// The VCN at which the next extent begins. This value minus either <c>StartingVcn</c> (for the first <c>Extents</c> array
		/// member) or the <c>NextVcn</c> of the previous member of the array (for all other <c>Extents</c> array members) is the
		/// length, in clusters, of the current extent. The length is an input to the FSCTL_MOVE_FILE operation.
		/// </para>
		/// <para>Lcn</para>
		/// <para>
		/// The LCN at which the current extent begins on the volume. This value is an input to the FSCTL_MOVE_FILE operation. On the
		/// NTFS file system, the value (LONGLONG) –1 indicates either a compression unit that is partially allocated, or an unallocated
		/// region of a sparse file.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public EXTENT[] Extents;
	}

	/// <summary>
	/// Specifies the attributes to be set on a disk device. Passed as the input buffer to the IOCTL_DISK_SET_DISK_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-set_disk_attributes typedef struct _SET_DISK_ATTRIBUTES {
	// DWORD Version; BOOLEAN Persist; BYTE Reserved1[3]; DWORDLONG Attributes; DWORDLONG AttributesMask; DWORD Reserved2[4]; }
	// SET_DISK_ATTRIBUTES, *PSET_DISK_ATTRIBUTES;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._SET_DISK_ATTRIBUTES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SET_DISK_ATTRIBUTES
	{
		/// <summary>
		/// Set to
		/// <code>sizeof(GET_DISK_ATTRIBUTES)</code>
		/// .
		/// </summary>
		public uint Version;

		/// <summary>If <c>TRUE</c>, these settings are persisted across reboots.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool Persist;

		/// <summary>Reserved. Must be set to <c>FALSE</c> (0).</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)] public byte[] Reserved1;

		/// <summary>
		/// <para>Specifies attributes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DISK_ATTRIBUTE_OFFLINE 0x0000000000000001</term>
		/// <term>The disk is offline.</term>
		/// </item>
		/// <item>
		/// <term>DISK_ATTRIBUTE_READ_ONLY 0x0000000000000002</term>
		/// <term>The disk is read-only.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DISK_ATTRIBUTE Attributes;

		/// <summary>
		/// <para>Indicates which attributes are being changed.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DISK_ATTRIBUTE_OFFLINE 0x0000000000000001</term>
		/// <term>The offline attribute is being changed.</term>
		/// </item>
		/// <item>
		/// <term>DISK_ATTRIBUTE_READ_ONLY 0x0000000000000002</term>
		/// <term>The read-only attribute is being changed.</term>
		/// </item>
		/// </list>
		/// </summary>
		public DISK_ATTRIBUTE AttributesMask;

		/// <summary>Reserved. Must be set to 0.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)] public uint[] Reserved2;
	}

	/// <summary>
	/// <para>Contains information used to set a disk partition's type.</para>
	/// <para><c>Note</c><c>SET_PARTITION_INFORMATION</c> has been superseded by the <see cref="PARTITION_INFORMATION_EX"/> structure.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-set_partition_information typedef struct
	// _SET_PARTITION_INFORMATION { BYTE PartitionType; } SET_PARTITION_INFORMATION, *PSET_PARTITION_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._SET_PARTITION_INFORMATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SET_PARTITION_INFORMATION
	{
		/// <summary>The type of partition. For a list of values, see Disk Partition Types.</summary>
		public byte PartitionType;
	}

	/// <summary>Specifies the volume shrink operation to perform.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-shrink_volume_information typedef struct
	// _SHRINK_VOLUME_INFORMATION { SHRINK_VOLUME_REQUEST_TYPES ShrinkRequestType; DWORDLONG Flags; LONGLONG NewNumberOfSectors; }
	// SHRINK_VOLUME_INFORMATION, *PSHRINK_VOLUME_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._SHRINK_VOLUME_INFORMATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SHRINK_VOLUME_INFORMATION
	{
		/// <summary>
		/// <para>Indicates the operation to perform. The valid values are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ShrinkPrepare</term>
		/// <term>Volume should perform any steps necessary to prepare for a shrink operation.</term>
		/// </item>
		/// <item>
		/// <term>ShrinkCommit</term>
		/// <term>Volume should commit the shrink operation changes.</term>
		/// </item>
		/// <item>
		/// <term>ShrinkAbort</term>
		/// <term>Volume should terminate the shrink operation.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SHRINK_VOLUME_REQUEST_TYPES ShrinkRequestType;

		/// <summary>This member must be zero.</summary>
		public ulong Flags;

		/// <summary>
		/// The number of sectors that should be in the shrunken volume. Used only when the <c>ShrinkRequestType</c> member is
		/// <c>ShrinkPrepare</c>, otherwise this member should be initialized to zero.
		/// </summary>
		public long NewNumberOfSectors;
	}

	/// <summary>Contains the starting LCN to the FSCTL_GET_VOLUME_BITMAP control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-starting_lcn_input_buffer typedef struct { LARGE_INTEGER
	// StartingLcn; } STARTING_LCN_INPUT_BUFFER, *PSTARTING_LCN_INPUT_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STARTING_LCN_INPUT_BUFFER
	{
		/// <summary>
		/// The LCN from which the operation should start when describing a bitmap. This member will be rounded down to a
		/// file-system-dependent rounding boundary, and that value will be returned. Its value should be an integral multiple of eight.
		/// </summary>
		public long StartingLcn;
	}

	/// <summary>Contains the starting VCN to the FSCTL_GET_RETRIEVAL_POINTERS control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-starting_vcn_input_buffer typedef struct { LARGE_INTEGER
	// StartingVcn; } STARTING_VCN_INPUT_BUFFER, *PSTARTING_VCN_INPUT_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_7")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STARTING_VCN_INPUT_BUFFER
	{
		/// <summary>
		/// The VCN at which the operation will begin enumerating extents in the file. This value may be rounded down to the first VCN
		/// of the extent in which the specified extent is found.
		/// </summary>
		public long StartingVcn;
	}

	/// <summary>
	/// Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the storage access alignment descriptor data
	/// for a device.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_access_alignment_descriptor typedef struct
	// _STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR { DWORD Version; DWORD Size; DWORD BytesPerCacheLine; DWORD BytesOffsetForCacheAlignment;
	// DWORD BytesPerLogicalSector; DWORD BytesPerPhysicalSector; DWORD BytesOffsetForSectorAlignment; }
	// STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR, *PSTORAGE_ACCESS_ALIGNMENT_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>The number of bytes in a cache line of the device.</summary>
		public uint BytesPerCacheLine;

		/// <summary>The address offset necessary for proper cache access alignment, in bytes.</summary>
		public uint BytesOffsetForCacheAlignment;

		/// <summary>The number of bytes in a logical sector of the device.</summary>
		public uint BytesPerLogicalSector;

		/// <summary>The number of bytes in a physical sector of the device.</summary>
		public uint BytesPerPhysicalSector;

		/// <summary>
		/// <para>The logical sector offset within the first physical sector where the first logical sector is placed, in bytes.</para>
		/// <para>Example: Offset = 3 Logical sectors</para>
		/// <code lang="txt">
		///+---------+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		///|LBA      |##|##|##|00|01|02|03|04|05|06|07|08|09|10|11|12|13|14|15|16|17|
		///+---------+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+
		///|Physical |                       |                       |                ...
		///|Sector   |           0           |           1           |           2
		///+---------+-----------------------+-----------------------+---------------
		/// </code>
		/// <para>In this example, <c>BytesOffsetForSectorAlignment = 3 * BytesPerLogicalSector</c></para>
		/// </summary>
		public uint BytesOffsetForSectorAlignment;
	}

	/// <summary>Used with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the storage adapter descriptor data for a device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_adapter_descriptor typedef struct
	// _STORAGE_ADAPTER_DESCRIPTOR { DWORD Version; DWORD Size; DWORD MaximumTransferLength; DWORD MaximumPhysicalPages; DWORD
	// AlignmentMask; BOOLEAN AdapterUsesPio; BOOLEAN AdapterScansDown; BOOLEAN CommandQueueing; BOOLEAN AcceleratedTransfer; #if ...
	// BOOLEAN BusType; #else BYTE BusType; #endif WORD BusMajorVersion; WORD BusMinorVersion; BYTE SrbType; BYTE AddressType; }
	// STORAGE_ADAPTER_DESCRIPTOR, *PSTORAGE_ADAPTER_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_ADAPTER_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_ADAPTER_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>Specifies the maximum number of bytes the storage adapter can transfer in a single operation.</summary>
		public uint MaximumTransferLength;

		/// <summary>
		/// Specifies the maximum number of discontinuous physical pages the storage adapter can manage in a single transfer (in other
		/// words, the extent of its scatter/gather support).
		/// </summary>
		public uint MaximumPhysicalPages;

		/// <summary>
		/// <para>
		/// Specifies the storage adapter's alignment requirements for transfers. The alignment mask indicates alignment restrictions
		/// for buffers required by the storage adapter for transfer operations. Valid mask values are also restricted by
		/// characteristics of the memory managers on different versions of Windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Buffers must be aligned on BYTE boundaries.</term>
		/// </item>
		/// <item>
		/// <term>1</term>
		/// <term>Buffers must be aligned on WORD boundaries.</term>
		/// </item>
		/// <item>
		/// <term>3</term>
		/// <term>Buffers must be aligned on DWORD32 boundaries.</term>
		/// </item>
		/// <item>
		/// <term>7</term>
		/// <term>Buffers must be aligned on DWORD64 boundaries.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint AlignmentMask;

		/// <summary>
		/// If this member is <c>TRUE</c>, the storage adapter uses programmed I/O (PIO) and requires the use of system-space virtual
		/// addresses mapped to physical memory for data buffers. When this member is <c>FALSE</c>, the storage adapter does not use PIO.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool AdapterUsesPio;

		/// <summary>
		/// If this member is <c>TRUE</c>, the storage adapter scans down for BIOS devices, that is, the storage adapter begins scanning
		/// with the highest device number rather than the lowest. When this member is <c>FALSE</c>, the storage adapter begins scanning
		/// with the lowest device number. This member is reserved for legacy miniport drivers.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool AdapterScansDown;

		/// <summary>
		/// If this member is <c>TRUE</c>, the storage adapter supports SCSI tagged queuing and/or per-logical-unit internal queues, or
		/// the non-SCSI equivalent. When this member is <c>FALSE</c>, the storage adapter neither supports SCSI-tagged queuing nor
		/// per-logical-unit internal queues.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool CommandQueueing;

		/// <summary>
		/// If this member is <c>TRUE</c>, the storage adapter supports synchronous transfers as a way of speeding up I/O. When this
		/// member is <c>FALSE</c>, the storage adapter does not support synchronous transfers as a way of speeding up I/O.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool AcceleratedTransfer;

		/// <summary>Specifies a value of type STORAGE_BUS_TYPE that indicates the type of the bus to which the device is connected.</summary>
		public byte BusType;

		/// <summary>Specifies the major version number, if any, of the storage adapter.</summary>
		public ushort BusMajorVersion;

		/// <summary>Specifies the minor version number, if any, of the storage adapter.</summary>
		public ushort BusMinorVersion;

		/// <summary>
		/// <para>Specifies the SCSI request block (SRB) type used by the HBA.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SRB_TYPE_SCSI_REQUEST_BLOCK</term>
		/// <term>The HBA uses SCSI request blocks.</term>
		/// </item>
		/// <item>
		/// <term>SRB_TYPE_STORAGE_REQUEST_BLOCK</term>
		/// <term>The HBA uses extended SCSI request blocks.</term>
		/// </item>
		/// </list>
		/// <para>This member is valid starting with Windows 8.</para>
		/// </summary>
		public SRB_TYPE SrbType;

		/// <summary>
		/// <para>Specifies the address type of the HBA.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_ADDRESS_TYPE_BTL8</term>
		/// <term>The HBA uses 8-bit bus, target, and LUN addressing.</term>
		/// </item>
		/// </list>
		/// <para>This member is valid starting with Windows 8.</para>
		/// </summary>
		public STORAGE_ADDRESS_TYPE AddressType;
	}

	/// <summary>
	/// Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the properties of a storage device or adapter.
	/// </summary>
	/// <remarks>The data retrieved by IOCTL_STORAGE_QUERY_PROPERTY is reported in the buffer immediately following this structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_descriptor_header typedef struct
	// _STORAGE_DESCRIPTOR_HEADER { DWORD Version; DWORD Size; } STORAGE_DESCRIPTOR_HEADER, *PSTORAGE_DESCRIPTOR_HEADER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DESCRIPTOR_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DESCRIPTOR_HEADER
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;
	}

	/// <summary>Reserved for future use.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_attributes_descriptor typedef struct
	// _STORAGE_DEVICE_ATTRIBUTES_DESCRIPTOR { DWORD Version; DWORD Size; DWORD64 Attributes; } STORAGE_DEVICE_ATTRIBUTES_DESCRIPTOR, *PSTORAGE_DEVICE_ATTRIBUTES_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_ATTRIBUTES_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_ATTRIBUTES_DESCRIPTOR
	{
		/// <summary>Contains the version of the data reported.</summary>
		public uint Version;

		/// <summary>
		/// Indicates the quantity of data reported, in bytes. This is the
		/// <code>sizeof(STORAGE_DEVICE_ATTRIBUTES_DESCRIPTOR)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>Reserved for future use.</summary>
		public ulong Attributes;
	}

	/// <summary>
	/// Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve the storage device descriptor data for a device.
	/// </summary>
	/// <remarks>
	/// An application can determine the required buffer size by issuing a IOCTL_STORAGE_QUERY_PROPERTY control code passing a
	/// <see cref="STORAGE_DESCRIPTOR_HEADER"/> structure for the output buffer, and then using the returned <c>Size</c> member of the
	/// <c>STORAGE_DESCRIPTOR_HEADER</c> structure to allocate a buffer of the proper size.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_descriptor typedef struct
	// _STORAGE_DEVICE_DESCRIPTOR { DWORD Version; DWORD Size; BYTE DeviceType; BYTE DeviceTypeModifier; BOOLEAN RemovableMedia; BOOLEAN
	// CommandQueueing; DWORD VendorIdOffset; DWORD ProductIdOffset; DWORD ProductRevisionOffset; DWORD SerialNumberOffset;
	// STORAGE_BUS_TYPE BusType; DWORD RawPropertiesLength; BYTE RawDeviceProperties[1]; } STORAGE_DEVICE_DESCRIPTOR, *PSTORAGE_DEVICE_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_DESCRIPTOR")]
	[VanaraMarshaler(typeof(STORAGE_DEVICE_DESCRIPTOR_Marshaler))]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_DESCRIPTOR_MGD
	{
		/// <summary>Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.</summary>
		public uint Version;

		/// <summary>Specifies the device type as defined by the Small Computer Systems Interface (SCSI) specification.</summary>
		public byte DeviceType;

		/// <summary>
		/// Specifies the device type modifier, if any, as defined by the SCSI specification. If no device type modifier exists, this member
		/// is zero.
		/// </summary>
		public byte DeviceTypeModifier;

		/// <summary>
		/// Indicates when <c>TRUE</c> that the device's media (if any) is removable. If the device has no media, this member should be
		/// ignored. When <c>FALSE</c> the device's media is not removable.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool RemovableMedia;

		/// <summary>
		/// Indicates when <c>TRUE</c> that the device supports multiple outstanding commands (SCSI tagged queuing or equivalent). When
		/// <c>FALSE</c>, the device does not support SCSI-tagged queuing or the equivalent.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool CommandQueueing;

		/// <summary>
		/// A null-terminated ASCII string that contains the device's vendor ID. If the device has no vendor ID, this member is <see langword="null"/>.
		/// </summary>
		public string? VendorId;

		/// <summary>
		/// A null-terminated ASCII string that contains the device's product ID. If the device has no product ID, this member is <see langword="null"/>.
		/// </summary>
		public string? ProductId;

		/// <summary>
		/// A null-terminated ASCII string that contains the device's product revision string. If the device has no product revision string,
		/// this member is <see langword="null"/>.
		/// </summary>
		public string? ProductRevision;

		/// <summary>
		/// A null-terminated ASCII string that contains the device's serial number. If the device has no serial number, this member is null.
		/// </summary>
		public string? SerialNumber;

		/// <summary>
		/// Specifies an enumerator value of type STORAGE_BUS_TYPE that indicates the type of bus to which the device is connected. This
		/// should be used to interpret the raw device properties at the end of this structure (if any).
		/// </summary>
		public STORAGE_BUS_TYPE BusType;

		/// <summary>Contains a byte array of the bus specific property data.</summary>
		public byte[]? RawDeviceProperties;
	}

	/// <summary>
	/// Used with the IOCTL_STORAGE_QUERY_PROPERTY control code request to retrieve the device ID descriptor data for a device.
	/// </summary>
	/// <remarks>
	/// The device ID descriptor consists of an array of device IDs taken from the SCSI-3 vital product data (VPD) page 0x83 that was
	/// retrieved during discovery.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_id_descriptor typedef struct
	// _STORAGE_DEVICE_ID_DESCRIPTOR { DWORD Version; DWORD Size; DWORD NumberOfIdentifiers; BYTE Identifiers[1]; }
	// STORAGE_DEVICE_ID_DESCRIPTOR, *PSTORAGE_DEVICE_ID_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_ID_DESCRIPTOR")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<STORAGE_DEVICE_ID_DESCRIPTOR>), nameof(NumberOfIdentifiers))]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_ID_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>Contains the number of identifiers reported by the device in the <c>Identifiers</c> array.</summary>
		public uint NumberOfIdentifiers;

		/// <summary>Contains a variable-length array of identification descriptors.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Identifiers;
	}

	/// <summary>The output buffer for the StorageDeviceIoCapabilityProperty as defined in STORAGE_PROPERTY_ID.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_io_capability_descriptor typedef struct
	// _STORAGE_DEVICE_IO_CAPABILITY_DESCRIPTOR { DWORD Version; DWORD Size; DWORD LunMaxIoCount; DWORD AdapterMaxIoCount; }
	// STORAGE_DEVICE_IO_CAPABILITY_DESCRIPTOR, *PSTORAGE_DEVICE_IO_CAPABILITY_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_IO_CAPABILITY_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_IO_CAPABILITY_DESCRIPTOR
	{
		/// <summary>The version of this structure. The Size serves as the version.</summary>
		public uint Version;

		/// <summary>The size of this structure.</summary>
		public uint Size;

		/// <summary>The logical unit number (LUN) max outstanding I/O count.</summary>
		public uint LunMaxIoCount;

		/// <summary>The adapter max outstanding I/O count.</summary>
		public uint AdapterMaxIoCount;
	}

	/// <summary>Contains information about a device. This structure is used by the IOCTL_STORAGE_GET_DEVICE_NUMBER control code.</summary>
	/// <remarks>
	/// The values in the <c>STORAGE_DEVICE_NUMBER</c> structure are guaranteed to remain unchanged until the device is removed or the
	/// system is restarted. They are not guaranteed to be persistent across device or system restarts.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_number typedef struct
	// _STORAGE_DEVICE_NUMBER { DEVICE_TYPE DeviceType; DWORD DeviceNumber; DWORD PartitionNumber; } STORAGE_DEVICE_NUMBER, *PSTORAGE_DEVICE_NUMBER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_NUMBER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_NUMBER
	{
		/// <summary>
		/// <para>
		/// The type of device. Values from 0 through 32,767 are reserved for use by Microsoft. Values from 32,768 through 65,535 are
		/// reserved for use by other vendors. The following values are defined by Microsoft:
		/// </para>
		/// <para>FILE_DEVICE_8042_PORT</para>
		/// <para>FILE_DEVICE_ACPI</para>
		/// <para>FILE_DEVICE_BATTERY</para>
		/// <para>FILE_DEVICE_BEEP</para>
		/// <para>FILE_DEVICE_BLUETOOTH</para>
		/// <para>FILE_DEVICE_BUS_EXTENDER</para>
		/// <para>FILE_DEVICE_CD_ROM</para>
		/// <para>FILE_DEVICE_CD_ROM_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_CHANGER</para>
		/// <para>FILE_DEVICE_CONTROLLER</para>
		/// <para>FILE_DEVICE_CRYPT_PROVIDER</para>
		/// <para>FILE_DEVICE_DATALINK</para>
		/// <para>FILE_DEVICE_DFS</para>
		/// <para>FILE_DEVICE_DFS_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_DFS_VOLUME</para>
		/// <para>FILE_DEVICE_DISK</para>
		/// <para>FILE_DEVICE_DISK_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_DVD</para>
		/// <para>FILE_DEVICE_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_FIPS</para>
		/// <para>FILE_DEVICE_FULLSCREEN_VIDEO</para>
		/// <para>FILE_DEVICE_INFINIBAND</para>
		/// <para>FILE_DEVICE_INPORT_PORT</para>
		/// <para>FILE_DEVICE_KEYBOARD</para>
		/// <para>FILE_DEVICE_KS</para>
		/// <para>FILE_DEVICE_KSEC</para>
		/// <para>FILE_DEVICE_MAILSLOT</para>
		/// <para>FILE_DEVICE_MASS_STORAGE</para>
		/// <para>FILE_DEVICE_MIDI_IN</para>
		/// <para>FILE_DEVICE_MIDI_OUT</para>
		/// <para>FILE_DEVICE_MODEM</para>
		/// <para>FILE_DEVICE_MOUSE</para>
		/// <para>FILE_DEVICE_MULTI_UNC_PROVIDER</para>
		/// <para>FILE_DEVICE_NAMED_PIPE</para>
		/// <para>FILE_DEVICE_NETWORK</para>
		/// <para>FILE_DEVICE_NETWORK_BROWSER</para>
		/// <para>FILE_DEVICE_NETWORK_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_NETWORK_REDIRECTOR</para>
		/// <para>FILE_DEVICE_NULL</para>
		/// <para>FILE_DEVICE_PARALLEL_PORT</para>
		/// <para>FILE_DEVICE_PHYSICAL_NETCARD</para>
		/// <para>FILE_DEVICE_PRINTER</para>
		/// <para>FILE_DEVICE_SCANNER</para>
		/// <para>FILE_DEVICE_SCREEN</para>
		/// <para>FILE_DEVICE_SERENUM</para>
		/// <para>FILE_DEVICE_SERIAL_MOUSE_PORT</para>
		/// <para>FILE_DEVICE_SERIAL_PORT</para>
		/// <para>FILE_DEVICE_SMARTCARD</para>
		/// <para>FILE_DEVICE_SMB</para>
		/// <para>FILE_DEVICE_SOUND</para>
		/// <para>FILE_DEVICE_STREAMS</para>
		/// <para>FILE_DEVICE_TAPE</para>
		/// <para>FILE_DEVICE_TAPE_FILE_SYSTEM</para>
		/// <para>FILE_DEVICE_TERMSRV</para>
		/// <para>FILE_DEVICE_TRANSPORT</para>
		/// <para>FILE_DEVICE_UNKNOWN</para>
		/// <para>FILE_DEVICE_VDM</para>
		/// <para>FILE_DEVICE_VIDEO</para>
		/// <para>FILE_DEVICE_VIRTUAL_DISK</para>
		/// <para>FILE_DEVICE_VMBUS</para>
		/// <para>FILE_DEVICE_WAVE_IN</para>
		/// <para>FILE_DEVICE_WAVE_OUT</para>
		/// <para>FILE_DEVICE_WPD</para>
		/// </summary>
		public DEVICE_TYPE DeviceType;

		/// <summary>The number of this device.</summary>
		public uint DeviceNumber;

		/// <summary>The partition number of the device, if the device can be partitioned. Otherwise, this member is –1.</summary>
		public uint PartitionNumber;
	}

	/// <summary>This structure is used as an input and output buffer for the IOCTL_STORAGE_DEVICE_POWER_CAP.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_power_cap typedef struct
	// _STORAGE_DEVICE_POWER_CAP { DWORD Version; DWORD Size; STORAGE_DEVICE_POWER_CAP_UNITS Units; DWORDLONG MaxPower; }
	// STORAGE_DEVICE_POWER_CAP, *PSTORAGE_DEVICE_POWER_CAP;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_POWER_CAP")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_POWER_CAP
	{
		/// <summary>The version of this structure. This should be set to STORAGE_DEVICE_POWER_CAP_VERSION_V1.</summary>
		public uint Version;

		/// <summary>The size of this structure.</summary>
		public uint Size;

		/// <summary>The units of the MaxPower value, of type STORAGE_DEVICE_POWER_CAP_UNITS.</summary>
		public STORAGE_DEVICE_POWER_CAP_UNITS Units;

		/// <summary>
		/// Contains the value of the actual maximum power consumption level of the device. This may be equal to, less than, or greater
		/// than the desired threshold, depending on what the device supports.
		/// </summary>
		public ulong MaxPower;
	}

	/// <summary>Reserved for system use.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_device_resiliency_descriptor typedef struct
	// _STORAGE_DEVICE_RESILIENCY_DESCRIPTOR { DWORD Version; DWORD Size; DWORD NameOffset; DWORD NumberOfLogicalCopies; DWORD
	// NumberOfPhysicalCopies; DWORD PhysicalDiskRedundancy; DWORD NumberOfColumns; DWORD Interleave; }
	// STORAGE_DEVICE_RESILIENCY_DESCRIPTOR, *PSTORAGE_DEVICE_RESILIENCY_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_DEVICE_RESILIENCY_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_DEVICE_RESILIENCY_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// Set to
		/// <code>sizeof(STORAGE_DEVICE_RESILIENCY_DESCRIPTOR)</code>
		/// .
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>
		/// Byte offset to the null-terminated ASCII string containing the resiliency properties Name. For devices with no Name
		/// property, this will be zero.
		/// </summary>
		public uint NameOffset;

		/// <summary>Number of logical copies of data that are available.</summary>
		public uint NumberOfLogicalCopies;

		/// <summary>Number of complete copies of data that are stored.</summary>
		public uint NumberOfPhysicalCopies;

		/// <summary>Number of disks that can fail without leading to data loss.</summary>
		public uint PhysicalDiskRedundancy;

		/// <summary>Number of columns in the storage device.</summary>
		public uint NumberOfColumns;

		/// <summary>
		/// Size of a stripe unit of the storage device, in bytes. This is also referred to as the stripe width or interleave of the
		/// storage device.
		/// </summary>
		public uint Interleave;
	}

	/// <summary>Provides information about the hotplug information of a device.</summary>
	/// <remarks>
	/// <para>
	/// The value of the <c>Size</c> member also identifies the version of this structure, as members will be added to this structure in
	/// the future. If the value of the <c>Size</c> member is
	/// <code>sizeof(STORAGE_HOTPLUG_INFO)</code>
	/// , the current version of the structure is the same as the version you compiled with. If the value is not
	/// <code>sizeof(STORAGE_HOTPLUG_INFO)</code>
	/// , then the current version contains additional members.
	/// </para>
	/// <para>
	/// A hotplug device refers to a device whose <c>RemovalPolicy</c> value displayed in the Device Manager is
	/// <c>ExpectSurpriseRemoval</c>. To query whether a particular device is a hotplug device, use the IOCTL_STORAGE_GET_HOTPLUG_INFO
	/// operation. To set the hotplug properties of a device, use the IOCTL_STORAGE_SET_HOTPLUG_INFO operation.
	/// </para>
	/// <para>
	/// The IOCTL_STORAGE_SET_HOTPLUG_INFO operation only sets the value of the <c>DeviceHotplug</c> member of this structure. If the
	/// value of that member is set, the removal policy of the specified device is set to <c>ExpectSurpriseRemoval</c> and all levels of
	/// caching are disabled. If the value of that member is not set, the removal policy of the specified device is set to
	/// <c>ExpectOrderlyRemoval</c>, and caching may be selectively enabled.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_hotplug_info typedef struct _STORAGE_HOTPLUG_INFO
	// { DWORD Size; BOOLEAN MediaRemovable; BOOLEAN MediaHotplug; BOOLEAN DeviceHotplug; BOOLEAN WriteCacheEnableOverride; }
	// STORAGE_HOTPLUG_INFO, *PSTORAGE_HOTPLUG_INFO;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_HOTPLUG_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_HOTPLUG_INFO
	{
		/// <summary>
		/// The size of this structure, in bytes. The caller must set this member to
		/// <code>sizeof(STORAGE_HOTPLUG_INFO)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>
		/// If this member is set to a nonzero value, the device media is removable. Otherwise, the device media is not removable.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool MediaRemovable;

		/// <summary>If this member is set to a nonzero value, the media is not lockable. Otherwise, the device media is lockable.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool MediaHotplug;

		/// <summary>
		/// If this member is set to a nonzero value, the device is a hotplug device. Otherwise, the device is not a hotplug device.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool DeviceHotplug;

		/// <summary>Reserved; set the value to <c>NULL</c>.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool WriteCacheEnableOverride;
	}

	/// <summary>This structure contains information about the downloaded firmware to activate.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_hw_firmware_activate typedef struct
	// _STORAGE_HW_FIRMWARE_ACTIVATE { DWORD Version; DWORD Size; DWORD Flags; BYTE Slot; BYTE Reserved0[3]; }
	// STORAGE_HW_FIRMWARE_ACTIVATE, *PSTORAGE_HW_FIRMWARE_ACTIVATE;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_HW_FIRMWARE_ACTIVATE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_HW_FIRMWARE_ACTIVATE
	{
		/// <summary>The version of this structure. This should be set to sizeof(STORAGE_HW_FIRMWARE_ACTIVATE).</summary>
		public uint Version;

		/// <summary>The size of this structure. This should be set to sizeof(STORAGE_HW_FIRMWARE_ACTIVATE).</summary>
		public uint Size;

		/// <summary>
		/// <para>The flags associated with the activation request. The following are valid flags that can be set in this member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_HW_FIRMWARE_REQUEST_FLAG_CONTROLLER</term>
		/// <term>
		/// Indicates that the target of the request is a controller or adapter, different than the device handle or object itself (e.g.
		/// NVMe SSD or HBA).
		/// </term>
		/// </item>
		/// <item>
		/// <term>STORAGE_HW_FIRMWARE_REQUEST_FLAG_SWITCH_TO_EXISTING_FIRMWARE</term>
		/// <term>Indicates that the existing firmware image in the specified slot should be activated.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_HW_FIRMWARE_REQUEST_FLAG Flags;

		/// <summary>The slot with the firmware image that is to be activated.</summary>
		public byte Slot;

		/// <summary>Reserved for future use.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] Reserved0;
	}

	/// <summary>This structure contains a firmware image payload to be downloaded to the target.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_hw_firmware_download typedef struct
	// _STORAGE_HW_FIRMWARE_DOWNLOAD { DWORD Version; DWORD Size; DWORD Flags; BYTE Slot; BYTE Reserved[3]; DWORDLONG Offset; DWORDLONG
	// BufferSize; BYTE ImageBuffer[ANYSIZE_ARRAY]; } STORAGE_HW_FIRMWARE_DOWNLOAD, *PSTORAGE_HW_FIRMWARE_DOWNLOAD;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_HW_FIRMWARE_DOWNLOAD")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<STORAGE_HW_FIRMWARE_DOWNLOAD>), nameof(BufferSize))]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_HW_FIRMWARE_DOWNLOAD
	{
		/// <summary>The version of this structure. This should be set to sizeof(STORAGE_HW_FIRMWARE_DOWNLOAD).</summary>
		public uint Version;

		/// <summary>The size of this structure and the download image buffer.</summary>
		public uint Size;

		/// <summary>
		/// <para>Flags associated with this download. The following are valid flags that this member can hold.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_HW_FIRMWARE_REQUEST_FLAG_CONTROLLER</term>
		/// <term>
		/// Indicates that the target of the request is a controller or adapter, different than the device handler or object itself
		/// (e.g. NVMe SSD or HBA).
		/// </term>
		/// </item>
		/// <item>
		/// <term>STORAGE_HW_FIRMWARE_REQUEST_FLAG_LAST_SEGMENT</term>
		/// <term>Indicates that the current firmware image segment is the last one.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_HW_FIRMWARE_REQUEST_FLAG Flags;

		/// <summary>The slot number that the firmware image will be downloaded to.</summary>
		public byte Slot;

		/// <summary>Reserved for future use.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] Reserved;

		/// <summary>
		/// The offset in this buffer of where the Image file begins. This should be aligned to <c>ImagePayloadAlignment</c> from STORAGE_HW_FIRMWARE_INFO.
		/// </summary>
		public ulong Offset;

		/// <summary>The buffer size of the ImageBuffer. This should be a multiple of <c>ImagePayloadAlignment</c> from STORAGE_HW_FIRMWARE_INFO.</summary>
		public ulong BufferSize;

		/// <summary>The firmware image file.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] ImageBuffer;
	}

	/// <summary>Used in conjunction with the IOCTL_STORAGE_QUERY_PROPERTY request to describe the product type of a storage device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_medium_product_type_descriptor typedef struct
	// _STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR { DWORD Version; DWORD Size; DWORD MediumProductType; }
	// STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR, *PSTORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes, as defined by
		/// <code>Sizeof(STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR)</code>
		/// . The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>
		/// <para>Specifies the product type of the storage device.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>MediumProductType value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>
		/// <code>00h</code>
		/// </term>
		/// <term>Not indicated</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>01h</code>
		/// </term>
		/// <term>CFast</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>02h</code>
		/// </term>
		/// <term>CompactFlash</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>03h</code>
		/// </term>
		/// <term>Memory Stick</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>04h</code>
		/// </term>
		/// <term>MultiMediaCard</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>05h</code>
		/// </term>
		/// <term>Secure Digital Card (SD Card)</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>06h</code>
		/// </term>
		/// <term>QXD</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>07h</code>
		/// </term>
		/// <term>Universal Flash Storage</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>08h</code>
		/// to
		/// <code>EFh</code>
		/// </term>
		/// <term>Reserved</term>
		/// </item>
		/// <item>
		/// <term>
		/// <code>F0h</code>
		/// to
		/// <code>FFh</code>
		/// </term>
		/// <term>Vendor-specific</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint MediumProductType;
	}

	/// <summary>Reserved for system use.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_miniport_descriptor typedef struct
	// _STORAGE_MINIPORT_DESCRIPTOR { DWORD Version; DWORD Size; STORAGE_PORT_CODE_SET Portdriver; BOOLEAN LUNResetSupported; BOOLEAN
	// TargetResetSupported; WORD IoTimeoutValue; BOOLEAN ExtraIoInfoSupported; BYTE Reserved0[3]; DWORD Reserved1; }
	// STORAGE_MINIPORT_DESCRIPTOR, *PSTORAGE_MINIPORT_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_MINIPORT_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_MINIPORT_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>
		/// <para>Type of port driver as enumerated by the STORAGE_PORT_CODE_SET enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>StoragePortCodeSetReserved 0</term>
		/// <term>Indicates an unknown storage adapter driver type.</term>
		/// </item>
		/// <item>
		/// <term>StoragePortCodeSetStorport 1</term>
		/// <term>Storage adapter driver is a Storport-miniport driver.</term>
		/// </item>
		/// <item>
		/// <term>StoragePortCodeSetSCSIport 2</term>
		/// <term>Storage adapter driver is a SCSI Port-miniport driver.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_PORT_CODE_SET Portdriver;

		/// <summary>Indicates whether a LUN reset is supported.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool LUNResetSupported;

		/// <summary>Indicates whether a target reset is supported.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool TargetResetSupported;

		/// <summary/>
		public ushort IoTimeoutValue;

		/// <summary/>
		[MarshalAs(UnmanagedType.U1)]
		public bool ExtraIoInfoSupported;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] Reserved0;

		/// <summary/>
		public uint Reserved1;
	}

	/// <summary>
	/// Output structure for the <c>DeviceDsmAction_OffloadRead</c> action of the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_offload_read_output typedef struct
	// _STORAGE_OFFLOAD_READ_OUTPUT { DWORD OffloadReadFlags; DWORD Reserved; DWORDLONG LengthProtected; DWORD TokenLength;
	// STORAGE_OFFLOAD_TOKEN Token; } STORAGE_OFFLOAD_READ_OUTPUT, *PSTORAGE_OFFLOAD_READ_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_OFFLOAD_READ_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_OFFLOAD_READ_OUTPUT
	{
		/// <summary>
		/// <para>Output flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_OFFLOAD_READ_RANGE_TRUNCATED 0x0001</term>
		/// <term>
		/// The ranges represented by the token is smaller than the ranges specified in the DEVICE_DATA_SET_RANGE structures passed in
		/// the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code input buffer. In other words the LengthProtected member is less
		/// than the sum of all of the LengthInBytes members of the DEVICE_DATA_SET_RANGE structures passed.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_OFFLOAD_READ OffloadReadFlags;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>The total length of the snapshot represented by the token.</summary>
		public ulong LengthProtected;

		/// <summary>Length of the token in bytes.</summary>
		public uint TokenLength;

		/// <summary>A STORAGE_OFFLOAD_TOKEN containing the token created.</summary>
		public STORAGE_OFFLOAD_TOKEN Token;
	}

	/// <summary>
	/// Contains the token used to represent a portion of a file used in by offload read and write operations specified by
	/// <c>DeviceDsmAction_OffloadRead</c> or <c>DeviceDsmAction_OffloadWrite</c> actions for the
	/// IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_offload_token typedef struct
	// _STORAGE_OFFLOAD_TOKEN { BYTE TokenType[4]; BYTE Reserved[2]; BYTE TokenIdLength[2]; union { struct { BYTE
	// Reserved2[STORAGE_OFFLOAD_TOKEN_ID_LENGTH]; } StorageOffloadZeroDataToken; BYTE Token[STORAGE_OFFLOAD_TOKEN_ID_LENGTH]; }
	// DUMMYUNIONNAME; } STORAGE_OFFLOAD_TOKEN, *PSTORAGE_OFFLOAD_TOKEN;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_OFFLOAD_TOKEN")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_OFFLOAD_TOKEN
	{
		/// <summary>
		/// <para>A 32-bit unsigned integer which defines the type of <c>Token</c>.</para>
		/// <para>STORAGE_OFFLOAD_TOKEN_TYPE_WELL_KNOWN (0xFFFFFFFF)</para>
		/// <para>
		/// The <c>Token</c> member uses a well-known format. The first two bytes of the <c>Token</c> member are a 16-bit unsigned
		/// integer that describes the region. The possible values are either <c>STORAGE_OFFLOAD_PATTERN_ZERO</c> or
		/// <c>STORAGE_OFFLOAD_PATTERN_ZERO_WITH_PROTECTION_INFO</c>. <c>STORAGE_OFFLOAD_PATTERN_ZERO</c> (0x0001) is a well-known token
		/// that indicates that the region represented has all bits set to zero.
		/// <c>STORAGE_OFFLOAD_PATTERN_ZERO_WITH_PROTECTION_INFO</c> is a well-known token that indicates that the data in the region
		/// represented has all bits set to zero and the corresponding protection information is valid.
		/// </para>
		/// <para>0x00000000–0xFFFFFFFE</para>
		/// <para>The <c>Token</c> member uses a vendor-specific format.</para>
		/// </summary>
		public uint TokenType;

		/// <summary>Reserved.</summary>
		public ushort Reserved;

		/// <summary>The length of the token data in <c>Token</c>.</summary>
		public ushort TokenIdLength;

		/// <summary>
		/// If the <c>TokenType</c> member is <c>STORAGE_OFFLOAD_TOKEN_TYPE_WELL_KNOWN</c> then the first two bytes are a 16-bit
		/// unsigned integer that describes the range. Otherwise this is a vendor-specific format.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = STORAGE_OFFLOAD_TOKEN_ID_LENGTH)]
		public byte[] Token;
	}

	/// <summary>
	/// Output structure for the <c>DeviceDsmAction_OffloadWrite</c> action of the IOCTL_STORAGE_MANAGE_DATA_SET_ATTRIBUTES control code.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_offload_write_output typedef struct
	// _STORAGE_OFFLOAD_WRITE_OUTPUT { DWORD OffloadWriteFlags; DWORD Reserved; DWORDLONG LengthCopied; } STORAGE_OFFLOAD_WRITE_OUTPUT, *PSTORAGE_OFFLOAD_WRITE_OUTPUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_OFFLOAD_WRITE_OUTPUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_OFFLOAD_WRITE_OUTPUT
	{
		/// <summary>
		/// <para>Out flags</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_OFFLOAD_WRITE_RANGE_TRUNCATED 0x0001</term>
		/// <term>The range written is less than the range specified.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_OFFLOAD_TOKEN_INVALID 0x0002</term>
		/// <term>The token specified is not valid.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_OFFLOAD_WRITE OffloadWriteFlags;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>The length of the copied content.</summary>
		public ulong LengthCopied;
	}

	/// <summary>Describes a physical storage adapter.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_physical_adapter_data typedef struct
	// _STORAGE_PHYSICAL_ADAPTER_DATA { DWORD AdapterId; STORAGE_COMPONENT_HEALTH_STATUS HealthStatus; STORAGE_PROTOCOL_TYPE
	// CommandProtocol; STORAGE_SPEC_VERSION SpecVersion; BYTE Vendor[8]; BYTE Model[40]; BYTE FirmwareRevision[16]; BYTE
	// PhysicalLocation[32]; BOOLEAN ExpanderConnected; BYTE Reserved0[3]; DWORD Reserved1[3]; } STORAGE_PHYSICAL_ADAPTER_DATA, *PSTORAGE_PHYSICAL_ADAPTER_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PHYSICAL_ADAPTER_DATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct STORAGE_PHYSICAL_ADAPTER_DATA
	{
		/// <summary>Specifies the adapter ID.</summary>
		public uint AdapterId;

		/// <summary>A STORAGE_COMPONENT_HEALTH_STATUS-typed value.</summary>
		public STORAGE_COMPONENT_HEALTH_STATUS HealthStatus;

		/// <summary>A STORAGE_PROTOCOL_TYPE-typed value.</summary>
		public STORAGE_PROTOCOL_TYPE CommandProtocol;

		/// <summary>A STORAGE_SPEC_VERSION-typed value that specifies the supported storage spec version (for example, AHCI 1.3.1).</summary>
		public STORAGE_SPEC_VERSION SpecVersion;

		/// <summary>Specifies the adapter vendor.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
		public string Vendor;

		/// <summary>Specifies the adapter model.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
		public string Model;

		/// <summary>Specifies the firmware revision.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string FirmwareRevision;

		/// <summary>Reserved for future use.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string PhysicalLocation;

		/// <summary>Indicates whether an expander is connected.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool ExpanderConnected;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] Reserved0;

		/// <summary>Reserved.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public uint[] Reserved1;
	}

	/// <summary>Describes a physical storage device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_physical_device_data typedef struct
	// _STORAGE_PHYSICAL_DEVICE_DATA { DWORD DeviceId; DWORD Role; STORAGE_COMPONENT_HEALTH_STATUS HealthStatus; STORAGE_PROTOCOL_TYPE
	// CommandProtocol; STORAGE_SPEC_VERSION SpecVersion; STORAGE_DEVICE_FORM_FACTOR FormFactor; BYTE Vendor[8]; BYTE Model[40]; BYTE
	// FirmwareRevision[16]; DWORDLONG Capacity; BYTE PhysicalLocation[32]; DWORD Reserved[2]; } STORAGE_PHYSICAL_DEVICE_DATA, *PSTORAGE_PHYSICAL_DEVICE_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PHYSICAL_DEVICE_DATA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_PHYSICAL_DEVICE_DATA
	{
		/// <summary>Specifies the device ID.</summary>
		public uint DeviceId;

		/// <summary>Value(s) of bitmask from STORAGE_COMPONENT_ROLE_xxx</summary>
		public uint Role;

		/// <summary>A STORAGE_COMPONENT_HEALTH_STATUS enumeration.</summary>
		public STORAGE_COMPONENT_HEALTH_STATUS HealthStatus;

		/// <summary>A STORAGE_PROTOCOL_TYPE enumeration.</summary>
		public STORAGE_PROTOCOL_TYPE CommandProtocol;

		/// <summary>
		/// A STORAGE_SPEC_VERSION structure that specifies the supported storage spec version. For example: SBC 3, SATA 3.2, NVMe 1.2
		/// </summary>
		public STORAGE_SPEC_VERSION SpecVersion;

		/// <summary>A STORAGE_DEVICE_FORM_FACTOR enumeration.</summary>
		public STORAGE_DEVICE_FORM_FACTOR FormFactor;

		/// <summary>Specifies the device vendor.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
		public string Vendor;

		/// <summary>Specifies the device model.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
		public string Model;

		/// <summary>Specifies the firmware revision of the device.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
		public string FirmwareRevision;

		/// <summary>In units of kilobytes (1024 bytes).</summary>
		public ulong Capacity;

		/// <summary/>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string PhysicalLocation;

		/// <summary/>
		public ulong Reserved;
	}

	/// <summary>Specifies the physical device data of a storage node.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_physical_node_data typedef struct
	// _STORAGE_PHYSICAL_NODE_DATA { DWORD NodeId; DWORD AdapterCount; DWORD AdapterDataLength; DWORD AdapterDataOffset; DWORD
	// DeviceCount; DWORD DeviceDataLength; DWORD DeviceDataOffset; DWORD Reserved[3]; } STORAGE_PHYSICAL_NODE_DATA, *PSTORAGE_PHYSICAL_NODE_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PHYSICAL_NODE_DATA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_PHYSICAL_NODE_DATA
	{
		/// <summary>The hardware ID of the storage node.</summary>
		public uint NodeId;

		/// <summary>A value of 0 or 1 that indicates the adapter count in the storage node.</summary>
		public uint AdapterCount;

		/// <summary>The data length of the storage adapter in the storage node, in units of kilobytes (1024 bytes).</summary>
		public uint AdapterDataLength;

		/// <summary>The data offset from the beginning of the data structure. The buffer contains an array of STORAGE_PHYSICAL_ADAPTER_DATA.</summary>
		public uint AdapterDataOffset;

		/// <summary>A value less than or equal to 1.</summary>
		public uint DeviceCount;

		/// <summary>The data length of the storage device in the storage node, in units of kilobytes (1024 bytes).</summary>
		public uint DeviceDataLength;

		/// <summary>The data offset from the beginning of the data structure. The buffer contains an array of STORAGE_PHYSICAL_DEVICE_DATA.</summary>
		public uint DeviceDataOffset;

		/// <summary>Specifies if the storage adapter is reserved.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public uint[] Reserved;
	}

	/// <summary>
	/// The <c>STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR</c> structure is one of the query result structures returned from an
	/// IOCTL_STORAGE_QUERY_PROPERTY request. This structure describes storage device physical topology.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_physical_topology_descriptor typedef struct
	// _STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR { DWORD Version; DWORD Size; DWORD NodeCount; DWORD Reserved; STORAGE_PHYSICAL_NODE_DATA
	// Node[ANYSIZE_ARRAY]; } STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR, *PSTORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR>), nameof(NodeCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. Set to
		/// <code>sizeof(STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR)</code>
		/// .
		/// </summary>
		public uint Version;

		/// <summary>
		/// Specifies the total size of the data, in bytes. Should be &gt;=
		/// <code>sizeof(STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR)</code>
		/// .
		/// </summary>
		public uint Size;

		/// <summary>Specifies the number of nodes.</summary>
		public uint NodeCount;

		/// <summary>Reserved.</summary>
		public uint Reserved;

		/// <summary>A node as specified by a STORAGE_PHYSICAL_NODE_DATA structure.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public STORAGE_PHYSICAL_NODE_DATA[] Node;
	}

	/// <summary>
	/// Indicates the properties of a storage device or adapter to retrieve as the input buffer passed to the
	/// IOCTL_STORAGE_QUERY_PROPERTY control code.
	/// </summary>
	/// <remarks>
	/// The optional output buffer returned through the lpOutBuffer parameter of the IOCTL_STORAGE_QUERY_PROPERTY control code can be
	/// one of several structures depending on the value of the <c>PropertyId</c> member. If the <c>QueryType</c> member is set to
	/// <c>PropertyExistsQuery</c>, then no structure is returned.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_property_query typedef struct
	// _STORAGE_PROPERTY_QUERY { STORAGE_PROPERTY_ID PropertyId; STORAGE_QUERY_TYPE QueryType; BYTE AdditionalParameters[1]; }
	// STORAGE_PROPERTY_QUERY, *PSTORAGE_PROPERTY_QUERY;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PROPERTY_QUERY")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<STORAGE_PROPERTY_QUERY>), "*")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_PROPERTY_QUERY
	{
		/// <summary>
		/// Indicates whether the caller is requesting a device descriptor, an adapter descriptor, a write cache property, a device
		/// unique ID (DUID), or the device identifiers provided in the device's SCSI vital product data (VPD) page. For a list of the
		/// property IDs that can be assigned to this member, see STORAGE_PROPERTY_ID.
		/// </summary>
		public STORAGE_PROPERTY_ID PropertyId;

		/// <summary>
		/// <para>Contains flags indicating the type of query to be performed as enumerated by the STORAGE_QUERY_TYPE enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PropertyStandardQuery 0</term>
		/// <term>Instructs the port driver to report a device descriptor, an adapter descriptor or a unique hardware device ID (DUID).</term>
		/// </item>
		/// <item>
		/// <term>PropertyExistsQuery 1</term>
		/// <term>Instructs the port driver to report whether the descriptor is supported.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_QUERY_TYPE QueryType;

		/// <summary>Contains an array of bytes that can be used to retrieve additional parameters for specific queries.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] AdditionalParameters;

		/// <summary>Initializes a new instance of the <see cref="STORAGE_PROPERTY_QUERY"/> struct.</summary>
		/// <param name="propertyId">The property identifier.</param>
		/// <param name="queryType">Type of the query.</param>
		public STORAGE_PROPERTY_QUERY(STORAGE_PROPERTY_ID propertyId, STORAGE_QUERY_TYPE queryType = STORAGE_QUERY_TYPE.PropertyStandardQuery)
		{
			PropertyId = propertyId;
			QueryType = queryType;
			AdditionalParameters = new byte[1];
		}
	}

	/// <summary>
	/// This structure is used as an input buffer when using the pass-through mechanism to issue a vendor-specific command to a storage
	/// device (via IOCTL_STORAGE_PROTOCOL_COMMAND).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_protocol_command typedef struct
	// _STORAGE_PROTOCOL_COMMAND { DWORD Version; DWORD Length; STORAGE_PROTOCOL_TYPE ProtocolType; DWORD Flags; DWORD ReturnStatus;
	// DWORD ErrorCode; DWORD CommandLength; DWORD ErrorInfoLength; DWORD DataToDeviceTransferLength; DWORD
	// DataFromDeviceTransferLength; DWORD TimeOutValue; DWORD ErrorInfoOffset; DWORD DataToDeviceBufferOffset; DWORD
	// DataFromDeviceBufferOffset; DWORD CommandSpecific; DWORD Reserved0; DWORD FixedProtocolReturnData; DWORD Reserved1[3]; BYTE
	// Command[ANYSIZE_ARRAY]; } STORAGE_PROTOCOL_COMMAND, *PSTORAGE_PROTOCOL_COMMAND;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PROTOCOL_COMMAND")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<STORAGE_PROTOCOL_COMMAND>), nameof(CommandLength))]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_PROTOCOL_COMMAND
	{
		/// <summary>The version of this structure. This should be set to <c>STORAGE_PROTOCOL_STRUCTURE_VERSION</c>.</summary>
		public uint Version;

		/// <summary>The size of this structure. This should be set to sizeof( <c>STORAGE_PROTOCOL_COMMAND</c>).</summary>
		public uint Length;

		/// <summary>The protocol type, of type STORAGE_PROTOCOL_TYPE.</summary>
		public STORAGE_PROTOCOL_TYPE ProtocolType;

		/// <summary>
		/// <para>Flags set for this request. The following are valid flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_PROTOCOL_COMMAND_FLAG_ADAPTER_REQUEST</term>
		/// <term>This flag indicates the request to target an adapter instead of device.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_PROTOCOL_COMMAND_FLAG Flags;

		private readonly ushort FlagsPadding;

		/// <summary>
		/// <para>The status of the request made to the storage device. In Windows 10, possible values include:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Status value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_PENDING</term>
		/// <term>The request is pending.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_SUCCESS</term>
		/// <term>The request has completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_ERROR</term>
		/// <term>The request has encountered an error.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_INVALID_REQUEST</term>
		/// <term>The request is not valid.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_NO_DEVICE</term>
		/// <term>A device is not available to make a request to.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_BUSY</term>
		/// <term>The device is busy acting on the request.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_DATA_OVERRUN</term>
		/// <term>The device encountered a data overrun while acting on the request.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_INSUFFICIENT_RESOURCES</term>
		/// <term>The device cannot complete the request due to insufficient resources.</term>
		/// </item>
		/// <item>
		/// <term>STORAGE_PROTOCOL_STATUS_NOT_SUPPORTED</term>
		/// <term>The request is not supported.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_PROTOCOL_STATUS ReturnStatus;

		/// <summary>The error code for this request. This is optionally set.</summary>
		public uint ErrorCode;

		/// <summary>The length of the command. A non-zero value must be set by the caller.</summary>
		public uint CommandLength;

		/// <summary>The length of the error buffer. This is optionally set and can be set to 0.</summary>
		public uint ErrorInfoLength;

		/// <summary>The size of the buffer that is to be transferred to the device. This is only used with a WRITE request.</summary>
		public uint DataToDeviceTransferLength;

		/// <summary>The size of the buffer this is to be transferred from the device. This is only used with a READ request.</summary>
		public uint DataFromDeviceTransferLength;

		/// <summary>How long to wait for the device until timing out. This is set in units of seconds.</summary>
		public uint TimeOutValue;

		/// <summary>The offset of the error buffer. This must be pointer-aligned.</summary>
		public uint ErrorInfoOffset;

		/// <summary>
		/// The offset of the buffer that is to be transferred to the device. This must be pointer-aligned and is only used with a WRITE request.
		/// </summary>
		public uint DataToDeviceBufferOffset;

		/// <summary>
		/// The offset of the buffer that is to be transferred from the device. This must be pointer-aligned and is only used with a
		/// READ request.
		/// </summary>
		public uint DataFromDeviceBufferOffset;

		/// <summary>
		/// Command-specific data passed along with the command. This depends on the command from the driver, and is optionally set.
		/// </summary>
		public uint CommandSpecific;

		/// <summary>Reserved for future use.</summary>
		public uint Reserved0;

		/// <summary>
		/// The return data. This is optionally set. Some protocols such as NVMe, may return a small amount of data (DWORD0 from
		/// completion queue entry) without the need of a separate device data transfer.
		/// </summary>
		public uint FixedProtocolReturnData;

		/// <summary>Reserved for future use.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public uint[] Reserved1;

		/// <summary>The vendor-specific command that is to be passed-through to the device.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Command;
	}

	/// <summary>
	/// This structure is used in conjunction with IOCTL_STORAGE_QUERY_PROPERTY to return protocol-specific data from a storage device
	/// or adapter. .
	/// </summary>
	/// <remarks>
	/// <para>
	/// When using IOCTL_STORAGE_QUERY_PROPERTY to retrieve protocol-specific information in the
	/// <c>STORAGE_PROTOCOL_DATA_DESCRIPTOR</c>, configure the STORAGE_PROPERTY_QUERY structure as follows:
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
	/// Fill the STORAGE_PROTOCOL_SPECIFIC_DATA structure with the desired values. The start of the
	/// <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c> is the <c>AdditionalParameters</c> field of STORAGE_PROPERTY_QUERY.
	/// </term>
	/// </item>
	/// </list>
	/// <para>To specify a type of NVMe protocol-specific information, configure the STORAGE_PROTOCOL_SPECIFIC_DATA structure as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the <c>ProtocolType</c> field to <c>ProtocolTypeNVMe</c>.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DataType</c> field to an enumeration value defined by STORAGE_PROTOCOL_NVME_DATA_TYPE:</term>
	/// </item>
	/// </list>
	/// <para>To specify a type of ATA protocol-specific information, configure the STORAGE_PROTOCOL_SPECIFIC_DATA structure as follows:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the <c>ProtocolType</c> field to <c>ProtocolTypeAta</c>.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DataType</c> field to an enumeration value defined by STORAGE_PROTOCOL_ATA_DATA_TYPE:</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_protocol_data_descriptor typedef struct
	// _STORAGE_PROTOCOL_DATA_DESCRIPTOR { DWORD Version; DWORD Size; STORAGE_PROTOCOL_SPECIFIC_DATA ProtocolSpecificData; }
	// STORAGE_PROTOCOL_DATA_DESCRIPTOR, *PSTORAGE_PROTOCOL_DATA_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PROTOCOL_DATA_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_PROTOCOL_DATA_DESCRIPTOR
	{
		/// <summary>The version of this structure.</summary>
		public uint Version;

		/// <summary>The total size of the descriptor, including the space for all protocol data.</summary>
		public uint Size;

		/// <summary>The protocol-specific data, of type STORAGE_PROTOCOL_SPECIFIC_DATA.</summary>
		public STORAGE_PROTOCOL_SPECIFIC_DATA ProtocolSpecificData;
	}

	/// <summary>
	/// Describes protocol-specific device data, provided in the input and output buffer of an IOCTL_STORAGE_QUERY_PROPERTY request.
	/// </summary>
	/// <remarks>
	/// <para>
	/// When using IOCTL_STORAGE_QUERY_PROPERTY to retrieve protocol-specific information in the STORAGE_PROTOCOL_DATA_DESCRIPTOR,
	/// configure the STORAGE_PROPERTY_QUERY structure as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Allocate a buffer that can contains both a STORAGE_PROPERTY_QUERY and a <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c> structure.</term>
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
	/// Fill the <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c> structure with the desired values. The start of the
	/// <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c> is the <c>AdditionalParameters</c> field of STORAGE_PROPERTY_QUERY.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// To specify a type of NVMe protocol-specific information, configure the <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c> structure as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the <c>ProtocolType</c> field to <c>ProtocolTypeNVMe</c>.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DataType</c> field to an enumeration value defined by STORAGE_PROTOCOL_NVME_DATA_TYPE:</term>
	/// </item>
	/// </list>
	/// <para>
	/// To specify a type of ATA protocol-specific information, configure the <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c> structure as follows:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Set the <c>ProtocolType</c> field to <c>ProtocolTypeAta</c>.</term>
	/// </item>
	/// <item>
	/// <term>Set the <c>DataType</c> field to an enumeration value defined by STORAGE_PROTOCOL_ATA_DATA_TYPE:</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_protocol_specific_data typedef struct
	// _STORAGE_PROTOCOL_SPECIFIC_DATA { STORAGE_PROTOCOL_TYPE ProtocolType; DWORD DataType; DWORD ProtocolDataRequestValue; DWORD
	// ProtocolDataRequestSubValue; DWORD ProtocolDataOffset; DWORD ProtocolDataLength; DWORD FixedProtocolReturnData; DWORD
	// ProtocolDataRequestSubValue2; DWORD ProtocolDataRequestSubValue3; DWORD Reserved; } STORAGE_PROTOCOL_SPECIFIC_DATA, *PSTORAGE_PROTOCOL_SPECIFIC_DATA;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_PROTOCOL_SPECIFIC_DATA")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_PROTOCOL_SPECIFIC_DATA
	{
		/// <summary>The protocol type. Values for this member are defined in the STORAGE_PROTOCOL_TYPE enumeration.</summary>
		public STORAGE_PROTOCOL_TYPE ProtocolType;

		/// <summary>
		/// The protocol data type. Data types are defined in the STORAGE_PROTOCOL_NVME_DATA_TYPE and STORAGE_PROTOCOL_ATA_DATA_TYPE enumerations.
		/// </summary>
		public uint DataType;

		/// <summary>The protocol data request value.</summary>
		public uint ProtocolDataRequestValue;

		/// <summary>The sub value of the protocol data request.</summary>
		public uint ProtocolDataRequestSubValue;

		/// <summary>
		/// The offset of the data buffer that is from the beginning of this structure. The typical value can be sizeof( <c>STORAGE_PROTOCOL_SPECIFIC_DATA</c>).
		/// </summary>
		public uint ProtocolDataOffset;

		/// <summary>The length of the protocol data.</summary>
		public uint ProtocolDataLength;

		/// <summary>The returned data.</summary>
		public uint FixedProtocolReturnData;

		/// <summary/>
		public uint ProtocolDataRequestSubValue2;

		/// <summary/>
		public uint ProtocolDataRequestSubValue3;

		/// <summary>Reserved for future use.</summary>
		public uint Reserved;
	}

	/// <summary>
	/// Using the information from IOCTL_STORAGE_QUERY_PROPERTY, an application can create an RPMB frame to perform one of the following
	/// actions: • Program Authentication Key • Query RPMB Write Counter • Authenticated Write • Authenticated Read • Authenticated
	/// Device Configuration Write • Authenticated Device Configuration Read
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_rpmb_data_frame typedef struct
	// _STORAGE_RPMB_DATA_FRAME { BYTE Stuff[196]; BYTE KeyOrMAC[32]; BYTE Data[256]; BYTE Nonce[16]; BYTE WriteCounter[4]; BYTE
	// Address[2]; BYTE BlockCount[2]; BYTE OperationResult[2]; BYTE RequestOrResponseType[2]; } STORAGE_RPMB_DATA_FRAME, *PSTORAGE_RPMB_DATA_FRAME;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_RPMB_DATA_FRAME")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_RPMB_DATA_FRAME
	{
		/// <summary>Reserved space.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 196)]
		public byte[] Stuff;

		/// <summary>Either the key to be programmed or the MAC authenticating this frame or series of frames.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
		public byte[] KeyOrMAC;

		/// <summary>The data input or output.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		public byte[] Data;

		/// <summary>Random 128-bit number generated by host. Only required for reads.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] Nonce;

		/// <summary>32-bit counter. Only required for writes.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] WriteCounter;

		/// <summary>The half-sector address to operate on.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] Address;

		/// <summary>The count of half-sector blocks to read/write.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] BlockCount;

		/// <summary>The result of the operation.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] OperationResult;

		/// <summary>The type of request or response.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public byte[] RequestOrResponseType;
	}

	/// <summary>
	/// To interface with the Replay Protected Memory Block (RPMB), applications first need to query whether the device contains an RPMB
	/// and the max payload size the RPMB supports. To do this, the application sends IOCTL_STORAGE_QUERY_PROPERTY IOCTL with
	/// STORAGE_PROPERTY_ID enumeration set to StorageAdapterRpmbProperty (defined in STORAGE_PROPERTY_QUERY in ntddstor.h). Storport
	/// then responds with the following payload (defined in ntddstor.h) when STORAGE_QUERY_TYPE enumeration is set to PropertyStandardQuery.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_rpmb_descriptor typedef struct
	// _STORAGE_RPMB_DESCRIPTOR { DWORD Version; DWORD Size; DWORD SizeInBytes; DWORD MaxReliableWriteSizeInBytes;
	// STORAGE_RPMB_FRAME_TYPE FrameFormat; } STORAGE_RPMB_DESCRIPTOR, *PSTORAGE_RPMB_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_RPMB_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_RPMB_DESCRIPTOR
	{
		/// <summary>Shall be set to STORAGE_RPMB_DESCRIPTOR_VERSION_1</summary>
		public uint Version;

		/// <summary>Shall be set to sizeof(STORAGE_RPMB_DESCRIPTOR)</summary>
		public uint Size;

		/// <summary>The size of the RPMB, in bytes. 0 if not supported, RPMB size in bytes otherwise.</summary>
		public uint SizeInBytes;

		/// <summary>The maximum amount of data supported in one transaction in bytes. 0 if not supported, minimum 512 bytes.</summary>
		public uint MaxReliableWriteSizeInBytes;

		/// <summary>
		/// To support different RPMB frame formats, specifies which frame format the payload will be in so the port driver can take the
		/// appropriate action.
		/// </summary>
		public STORAGE_RPMB_FRAME_TYPE FrameFormat;
	}

	/// <summary>Storage specification version.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_spec_version typedef union _STORAGE_SPEC_VERSION
	// { struct { union { struct { BYTE SubMinor; BYTE Minor; } DUMMYSTRUCTNAME; WORD AsUshort; } MinorVersion; WORD MajorVersion; }
	// DUMMYSTRUCTNAME; DWORD AsUlong; } STORAGE_SPEC_VERSION, *PSTORAGE_SPEC_VERSION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_SPEC_VERSION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_SPEC_VERSION
	{
		/// <summary/>
		public byte SubMinor;

		/// <summary/>
		public byte Minor;

		/// <summary/>
		public ushort MajorVersion;
	}

	/// <summary>
	/// This structure is used in conjunction with IOCTL_STORAGE_QUERY_PROPERTY to return temperature data from a storage device or adapter.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_temperature_data_descriptor typedef struct
	// _STORAGE_TEMPERATURE_DATA_DESCRIPTOR { DWORD Version; DWORD Size; SHORT CriticalTemperature; SHORT WarningTemperature; WORD
	// InfoCount; BYTE Reserved0[2]; DWORD Reserved1[2]; STORAGE_TEMPERATURE_INFO TemperatureInfo[ANYSIZE_ARRAY]; }
	// STORAGE_TEMPERATURE_DATA_DESCRIPTOR, *PSTORAGE_TEMPERATURE_DATA_DESCRIPTOR;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_TEMPERATURE_DATA_DESCRIPTOR")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<STORAGE_TEMPERATURE_DATA_DESCRIPTOR>), nameof(InfoCount))]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_TEMPERATURE_DATA_DESCRIPTOR
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>
		/// Indicates the minimum temperature in degrees Celsius that may prevent normal operation. Exceeding this temperature may
		/// result in possible data loss, automatic device shutdown, extreme performance throttling, or permanent damage.
		/// </summary>
		public short CriticalTemperature;

		/// <summary>
		/// Indicates the maximum temperature in degrees Celsius at which the device is capable of operating continuously without
		/// degrading operation or reliability.
		/// </summary>
		public short WarningTemperature;

		/// <summary>
		/// Specifies the number of STORAGE_TEMPERATURE_INFO structures reported in <c>TemperatureInfo</c>. More than one set of
		/// temperature data may be returned when there are multiple sensors in the drive.
		/// </summary>
		public ushort InfoCount;

		/// <summary>Reserved for future use.</summary>
		public ushort Reserved0;

		/// <summary>Reserved for future use.</summary>
		public ulong Reserved1;

		/// <summary>Device temperature data, of type STORAGE_TEMPERATURE_INFO.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public STORAGE_TEMPERATURE_INFO[] TemperatureInfo;
	}

	/// <summary>
	/// Describes device temperature data. Returned as part of STORAGE_TEMPERATURE_DATA_DESCRIPTOR when querying for temperature data
	/// with an IOCTL_STORAGE_QUERY_PROPERTY request.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_temperature_info typedef struct
	// _STORAGE_TEMPERATURE_INFO { WORD Index; SHORT Temperature; SHORT OverThreshold; SHORT UnderThreshold; BOOLEAN
	// OverThresholdChangable; BOOLEAN UnderThresholdChangable; BOOLEAN EventGenerated; BYTE Reserved0; DWORD Reserved1; }
	// STORAGE_TEMPERATURE_INFO, *PSTORAGE_TEMPERATURE_INFO;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_TEMPERATURE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_TEMPERATURE_INFO
	{
		/// <summary>Identifies the instance of temperature information. Starts from 0. Index 0 may indicate a composite value.</summary>
		public ushort Index;

		/// <summary>A signed value that indicates the current temperature, in degrees Celsius.</summary>
		public short Temperature;

		/// <summary>A signed value that specifies the maximum temperature within the desired threshold, in degrees Celsius.</summary>
		public short OverThreshold;

		/// <summary>A signed value that specifies the minimum temperature within the desired threshold, in degrees Celsius.</summary>
		public short UnderThreshold;

		/// <summary>Indicates if OverThreshold can be changed by using IOCTL_STORAGE_SET_TEMPERATURE_THRESHOLD.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool OverThresholdChangable;

		/// <summary>Indicates if UnderThreshold can be changed by using IOCTL_STORAGE_SET_TEMPERATURE_THRESHOLD.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool UnderThresholdChangable;

		/// <summary>Indicates if a notification will be generated when the current temperature crosses a threshold.</summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool EventGenerated;

		/// <summary>Reserved for future use.</summary>
		public byte Reserved0;

		/// <summary>Reserved for future use.</summary>
		public uint Reserved1;
	}

	/// <summary>This structure is used to set the over or under temperature threshold of a storage device (via IOCTL_STORAGE_SET_TEMPERATURE_THRESHOLD).</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_temperature_threshold typedef struct
	// _STORAGE_TEMPERATURE_THRESHOLD { DWORD Version; DWORD Size; WORD Flags; WORD Index; SHORT Threshold; BOOLEAN OverThreshold; BYTE
	// Reserved; } STORAGE_TEMPERATURE_THRESHOLD, *PSTORAGE_TEMPERATURE_THRESHOLD;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_TEMPERATURE_THRESHOLD")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_TEMPERATURE_THRESHOLD
	{
		/// <summary>The version of the structure.</summary>
		public uint Version;

		/// <summary>The size of this structure. This should be set to sizeof( <c>STORAGE_TEMPERATURE_THRESHOLD</c>).</summary>
		public uint Size;

		/// <summary>
		/// <para>Flags set for this request. The following are valid flags.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STORAGE_TEMPERATURE_THRESHOLD_FLAG_ADAPTER_REQUEST</term>
		/// <term>This flag indicates the request to target an adapter instead of device.</term>
		/// </item>
		/// </list>
		/// </summary>
		public STORAGE_TEMPERATURE_THRESHOLD_FLAG Flags;

		/// <summary>Identifies the instance of temperature information. Starts from 0. Index 0 may indicate a composite value.</summary>
		public ushort Index;

		/// <summary>A signed value that indicates the temperature of the threshold, in degrees Celsius.</summary>
		public short Threshold;

		/// <summary>
		/// Indicates if the Threshold specifies the over or under temperature threshold. If <c>true</c>, set the <c>OverThreshold</c>
		/// temperature value of the device; otherwise, set the <c>UnderThreshold</c> temperature value.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool OverThreshold;

		/// <summary>Reserved for future use.</summary>
		public byte Reserved;
	}

	/// <summary>Used with the IOCTL_STORAGE_QUERY_PROPERTY control code to retrieve information about a device's write cache property.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-storage_write_cache_property typedef struct
	// _STORAGE_WRITE_CACHE_PROPERTY { DWORD Version; DWORD Size; WRITE_CACHE_TYPE WriteCacheType; WRITE_CACHE_ENABLE WriteCacheEnabled;
	// WRITE_CACHE_CHANGE WriteCacheChangeable; WRITE_THROUGH WriteThroughSupported; BOOLEAN FlushCacheSupported; BOOLEAN
	// UserDefinedPowerProtection; BOOLEAN NVCacheEnabled; } STORAGE_WRITE_CACHE_PROPERTY, *PSTORAGE_WRITE_CACHE_PROPERTY;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._STORAGE_WRITE_CACHE_PROPERTY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct STORAGE_WRITE_CACHE_PROPERTY
	{
		/// <summary>
		/// Contains the size of this structure, in bytes. The value of this member will change as members are added to the structure.
		/// </summary>
		public uint Version;

		/// <summary>Specifies the total size of the data returned, in bytes. This may include data that follows this structure.</summary>
		public uint Size;

		/// <summary>
		/// <para>A value from the WRITE_CACHE_TYPE enumeration that indicates the current write cache type.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WriteCacheTypeUnknown 0</term>
		/// <term>The system cannot report the type of the write cache.</term>
		/// </item>
		/// <item>
		/// <term>WriteCacheTypeNone 1</term>
		/// <term>The device does not have a write cache.</term>
		/// </item>
		/// <item>
		/// <term>WriteCacheTypeWriteBack 2</term>
		/// <term>The device has a write-back cache.</term>
		/// </item>
		/// <item>
		/// <term>WriteCacheTypeWriteThrough 3</term>
		/// <term>The device has a write-through cache.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WRITE_CACHE_TYPE WriteCacheType;

		/// <summary>
		/// <para>A value from the WRITE_CACHE_ENABLE enumeration that indicates whether the write cache is enabled.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WriteCacheEnableUnknown 0</term>
		/// <term>The system cannot report whether the device's write cache is enabled or disabled.</term>
		/// </item>
		/// <item>
		/// <term>WriteCacheDisabled 1</term>
		/// <term>The device's write cache is disabled.</term>
		/// </item>
		/// <item>
		/// <term>WriteCacheEnabled 2</term>
		/// <term>The device's write cache is enabled.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WRITE_CACHE_ENABLE WriteCacheEnabled;

		/// <summary>
		/// <para>A value from the WRITE_CACHE_CHANGE enumeration that indicates whether if the host can change the write cache characteristics.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WriteCacheChangeUnknown 0</term>
		/// <term>The system cannot report the write cache change capability of the device.</term>
		/// </item>
		/// <item>
		/// <term>WriteCacheNotChangeable 1</term>
		/// <term>Host software cannot change the characteristics of the device's write cache</term>
		/// </item>
		/// <item>
		/// <term>WriteCacheChangeable 2</term>
		/// <term>Host software can change the characteristics of the device's write cache</term>
		/// </item>
		/// </list>
		/// </summary>
		public WRITE_CACHE_CHANGE WriteCacheChangeable;

		/// <summary>
		/// <para>A value from the WRITE_THROUGH enumeration that indicates whether the device supports write-through caching.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WriteThroughUnknown 0</term>
		/// <term>Indicates that no information is available concerning the write-through capabilities of the device.</term>
		/// </item>
		/// <item>
		/// <term>WriteThroughNotSupported 1</term>
		/// <term>Indicates that the device does not support write-through operations.</term>
		/// </item>
		/// <item>
		/// <term>WriteThroughSupported 2</term>
		/// <term>Indicates that the device supports write-through operations.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WRITE_THROUGH WriteThroughSupported;

		/// <summary>
		/// A <c>BOOLEAN</c> value that indicates whether the device allows host software to flush the device cache. If <c>TRUE</c>, the
		/// device allows host software to flush the device cache. If <c>FALSE</c>, host software cannot flush the device cache.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool FlushCacheSupported;

		/// <summary>
		/// A <c>BOOLEAN</c> value that indicates whether a user can configure the device's power protection characteristics in the
		/// registry. If <c>TRUE</c>, a user can configure the device's power protection characteristics in the registry. If
		/// <c>FALSE</c>, the user cannot configure the device's power protection characteristics in the registry.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool UserDefinedPowerProtection;

		/// <summary>
		/// A <c>BOOLEAN</c> value that indicates whether the device has a battery backup for the write cache. If <c>TRUE</c>, the
		/// device has a battery backup for the write cache. If <c>FALSE</c>, the device does not have a battery backup for the writer cache.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool NVCacheEnabled;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains the version information about the miniversion that is created.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_get_metadata_info_out typedef struct
	// _TXFS_GET_METADATA_INFO_OUT { struct { LONGLONG LowPart; LONGLONG HighPart; } TxfFileId; GUID LockingTransaction; DWORDLONG
	// LastLsn; DWORD TransactionState; } TXFS_GET_METADATA_INFO_OUT, *PTXFS_GET_METADATA_INFO_OUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_GET_METADATA_INFO_OUT")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_GET_METADATA_INFO_OUT
	{
		/// <summary>Returns the TxfId of the file referenced by the handle used to call this routine.</summary>
		public TXFFILEID TxfFileId;

		/// <summary>The TxfId of the file referenced by the handle used to call this routine.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct TXFFILEID
		{
			/// <summary>
			/// The lower half of the TxfId of the file referenced by the handle used to call FSCTL_TXFS_GET_METADATA_INFO. It is unique
			/// within a resource manager.
			/// </summary>
			public long LowPart;

			/// <summary>
			/// The higher half of the TxfId of the file referenced by the handle used to call FSCTL_TXFS_GET_METADATA_INFO. It is
			/// unique within a resource manager.
			/// </summary>
			public long HighPart;
		}

		/// <summary>The <c>GUID</c> of the transaction that locked the specified file locked, if the file is locked.</summary>
		public Guid LockingTransaction;

		/// <summary>
		/// Receives the last LSN for the most recent log record written for file. It is a property of the file that refers to the log,
		/// and references the last log entry of the file.
		/// </summary>
		public ulong LastLsn;

		/// <summary>
		/// <para>Indicates the state of the transaction that has locked the file. Valid values are:</para>
		/// <para>TXFS_TRANSACTION_STATE_ACTIVE</para>
		/// <para>TXFS_TRANSACTION_STATE_NONE</para>
		/// <para>TXFS_TRANSACTION_STATE_NOTACTIVETXFS_TRANSACTION_STATE_NOTACTIVE</para>
		/// <para>TXFS_TRANSACTION_STATE_PREPARED</para>
		/// </summary>
		public TXFS_TRANSACTION_STATE TransactionState;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains the information about the base and latest versions of the specified file.</para>
	/// </summary>
	/// <remarks>
	/// The base version number remains the same for the lifetime of a handle. The latest version number increases as long as a handle
	/// is still open to a file and a change is committed. When the handle is closed, the version number is reset to zero.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_get_transacted_version typedef struct
	// _TXFS_GET_TRANSACTED_VERSION { DWORD ThisBaseVersion; DWORD LatestVersion; WORD ThisMiniVersion; WORD FirstMiniVersion; WORD
	// LatestMiniVersion; } TXFS_GET_TRANSACTED_VERSION, *PTXFS_GET_TRANSACTED_VERSION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_GET_TRANSACTED_VERSION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_GET_TRANSACTED_VERSION
	{
		/// <summary>
		/// <para>The version of the file that this handle is opened with. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_TRANSACTED_VERSION_NONTRANSACTED 0xFFFFFFFE</term>
		/// <term>The file is not a transacted file.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_TRANSACTED_VERSION_UNCOMMITTED 0xFFFFFFFF</term>
		/// <term>The file has been opened as a transacted writer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the handle has been opened as a transacted reader, the value returned for this member is a positive integer that
		/// represents the version number of the file the handle is associated with.
		/// </para>
		/// </summary>
		public uint ThisBaseVersion;

		/// <summary>The most recently committed version of the file.</summary>
		public uint LatestVersion;

		/// <summary>
		/// If the handle to a miniversion is open, this member contains the ID of the miniversion. If the handle is not open, this
		/// member is zero (0).
		/// </summary>
		public ushort ThisMiniVersion;

		/// <summary>
		/// The first available miniversion for this file. If there are no miniversions, or they are not visible to the transaction
		/// bound to the file handle, this field is zero (0).
		/// </summary>
		public ushort FirstMiniVersion;

		/// <summary>
		/// The latest available miniversion for this file. If there are no miniversions, or they are not visible to the transaction
		/// bound to the file handle, this field is zero (0).
		/// </summary>
		public ushort LatestMiniVersion;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains a list of files locked by a transacted writer.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_list_transaction_locked_files typedef struct
	// _TXFS_LIST_TRANSACTION_LOCKED_FILES { GUID KtmTransaction; DWORDLONG NumberOfFiles; DWORDLONG BufferSizeRequired; DWORDLONG
	// Offset; } TXFS_LIST_TRANSACTION_LOCKED_FILES, *PTXFS_LIST_TRANSACTION_LOCKED_FILES;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_LIST_TRANSACTION_LOCKED_FILES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_LIST_TRANSACTION_LOCKED_FILES
	{
		/// <summary>The KTM transaction to enumerate locked files for in this RM.</summary>
		public Guid KtmTransaction;

		/// <summary>The number of files involved for the specified transaction on this resource manager.</summary>
		public ulong NumberOfFiles;

		/// <summary>
		/// The length of the buffer required to hold the complete list of files at the time of this call. This is not guaranteed to be
		/// the same length as any other subsequent call.
		/// </summary>
		public ulong BufferSizeRequired;

		/// <summary>
		/// The offset from the beginning of this structure to the beginning of the first TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY structure.
		/// </summary>
		public ulong Offset;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains information about a locked transaction.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_list_transaction_locked_files_entry typedef struct
	// _TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY { DWORDLONG Offset; DWORD NameFlags; LONGLONG FileId; DWORD Reserved1; DWORD Reserved2;
	// LONGLONG Reserved3; WCHAR FileName[1]; } TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY, *PTXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY")]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY>), "*")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY
	{
		/// <summary>The offset, in bytes, from the beginning of the TXFS_LIST_TRANSACTION_LOCKED_FILES structure to the next <c>TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY</c>.</summary>
		public ulong Offset;

		/// <summary>
		/// <para>
		/// Indicates whether the current name was deleted or created in the current transaction. Note that both flags may appear if the
		/// name was both created and deleted in the same transaction. In that case, the <c>FileName</c> member will contain only an
		/// empty string with a terminating null character ("\0") because there is no meaningful name to report.
		/// </para>
		/// <para>TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY_FLAG_CREATED (0x00000001)</para>
		/// <para>TXFS_LIST_TRANSACTION_LOCKED_FILES_ENTRY_FLAG_DELETED (0x00000002)</para>
		/// </summary>
		public uint NameFlags;

		/// <summary>The NTFS File ID of the file.</summary>
		public long FileId;

		/// <summary>Reserved. Specify zero.</summary>
		public uint Reserved1;

		/// <summary>Reserved. Specify zero.</summary>
		public uint Reserved2;

		/// <summary>Reserved. Specify zero.</summary>
		public long Reserved3;

		/// <summary>The path to the file, relative to the volume root. The file name is a NULL-terminated Unicode string.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string FileName;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains a list of transactions.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_list_transactions typedef struct
	// _TXFS_LIST_TRANSACTIONS { DWORDLONG NumberOfTransactions; DWORDLONG BufferSizeRequired; } TXFS_LIST_TRANSACTIONS, *PTXFS_LIST_TRANSACTIONS;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_LIST_TRANSACTIONS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_LIST_TRANSACTIONS
	{
		/// <summary>The number of transactions for this resource manager.</summary>
		public ulong NumberOfTransactions;

		/// <summary>
		/// The length of the buffer required to hold the complete list of transactions at the time of this call. The number of
		/// transactions returned from one call to the next can change depending on the number of active transactions at any given point
		/// in time. If this call returns a request for a larger buffer, that size may or may not be adequate for the next call, based
		/// on the number of active transactions at the time of the next call.
		/// </summary>
		public ulong BufferSizeRequired;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains information about a transaction.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_list_transactions_entry typedef struct
	// _TXFS_LIST_TRANSACTIONS_ENTRY { GUID TransactionId; DWORD TransactionState; DWORD Reserved1; DWORD Reserved2; LONGLONG Reserved3;
	// } TXFS_LIST_TRANSACTIONS_ENTRY, *PTXFS_LIST_TRANSACTIONS_ENTRY;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_LIST_TRANSACTIONS_ENTRY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_LIST_TRANSACTIONS_ENTRY
	{
		/// <summary>The GUID of the transaction.</summary>
		public Guid TransactionId;

		/// <summary>The current state of the transaction.</summary>
		public uint TransactionState;

		/// <summary>Reserved.</summary>
		public uint Reserved1;

		/// <summary>Reserved.</summary>
		public uint Reserved2;

		/// <summary>Reserved.</summary>
		public long Reserved3;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains the information required when modifying log parameters and logging mode for a secondary resource manager.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_modify_rm typedef struct _TXFS_MODIFY_RM { DWORD
	// Flags; DWORD LogContainerCountMax; DWORD LogContainerCountMin; DWORD LogContainerCount; DWORD LogGrowthIncrement; DWORD
	// LogAutoShrinkPercentage; DWORDLONG Reserved; WORD LoggingMode; } TXFS_MODIFY_RM, *PTXFS_MODIFY_RM;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_MODIFY_RM")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_MODIFY_RM
	{
		/// <summary>
		/// <para>The log parameters to be set.</para>
		/// <para>This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOGGING_MODE 0x00000001</term>
		/// <term>
		/// If this flag is set, the LoggingMode member of this structure is being used. If the flag is not set, the LoggingMode member
		/// is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_RENAME_RM 0x00000002</term>
		/// <term>If this flag is set, the RM is instructed to rename itself (creating a new GUID).</term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_CONTAINER_COUNT_MAX 0x00000004</term>
		/// <term>
		/// If this flag is set, the LogContainerCountMax member is being used. If the flag is not set, the LogContainerCountMax member
		/// is ignored. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_CONTAINER_COUNT_MIN 0x00000008</term>
		/// <term>
		/// If this flag is set, the LogContainerCountMin member is being used. If the flag is not set, the LogContainerCountMin member
		/// is ignored. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_NUM_CONTAINERS 0x00000010</term>
		/// <term>
		/// If this flag is set, the LogGrowthIncrement member is being used. If the flag is not set, the LogGrowthIncrement member is
		/// ignored. This flag indicates that the log should grow by the number of containers specified in the LogGrowthIncrement
		/// member. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_PERCENT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_PERCENT 0x00000020</term>
		/// <term>
		/// If this flag is set, the LogGrowthIncrement member is being used. If the flag is not set, the LogGrowthIncrement member is
		/// ignored. This flag indicates that the log should grow by the percentage of the log size specified in the LogGrowthIncrement
		/// member. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_NUM_CONTAINERS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_AUTO_SHRINK_PERCENTAGE 0x00000040</term>
		/// <term>
		/// If this flag is set, the LogAutoShrinkPercentage member is being used. If the flag is not set, the LogAutoShrinkPercentage
		/// is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX 0x00000080</term>
		/// <term>
		/// If this flag is set, the RM is instructed to allow its log to grow without bounds. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN 0x00000100</term>
		/// <term>
		/// If this flag is set, the RM is instructed to allow its log to shrink the log to only two containers. This flag is mutually
		/// exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_GROW_LOG 0x00000400</term>
		/// <term>
		/// If this flag is set, the log is instructed to immediately increase its size to the size specified in LogContainerCount. If
		/// the flag is not set, the LogContainerCount is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_SHRINK_LOG 0x00000800</term>
		/// <term>
		/// If this flag is set, the log is instructed to immediately decrease its size to the size specified in LogContainerCount. If
		/// this flag and TXFS_RM_FLAG_ENFORCE_MINIMUM_SIZE are set, the log is instructed to shrink to its minimum allowable size, and
		/// LogContainerCount is ignored.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_ENFORCE_MINIMUM_SIZE 0x00001000</term>
		/// <term>
		/// If this flag and TXFS_RM_FLAG_SHRINK_LOG are set, the log is instructed to shrink to its minimum allowable size, and
		/// LogContainerCount is ignored. If this flag is set, the TXFS_RM_FLAG_SHRINK_LOG must be set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_PRESERVE_CHANGES 0x00002000</term>
		/// <term>
		/// If this flag is set, the log is instructed to preserve the changes on disk. If this flag is not set, any changes made are
		/// temporary (that is, until the RM is shut down and restarted).
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_RESET_RM_AT_NEXT_START 0x00004000</term>
		/// <term>
		/// This flag is only valid for default RMs, not secondary RMs. If this flag is set, the RM is instructed to reset itself the
		/// next time it is started. The log and the associated metadata are deleted.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_DO_NOT_RESET_RM_AT_NEXT_START 0x00008000</term>
		/// <term>
		/// This flag is only valid for default RMs, not secondary RMs. If this flag is set, a previous call to FSCTL_TXFS_MODIFY_RM is
		/// canceled with the TXFS_RM_FLAG_RESET_RM_AT_NEXT_START flag set.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_PREFER_CONSISTENCY 0x00010000</term>
		/// <term>
		/// Indicates that the RM is to prefer transaction consistency over system availability. This flag is mutually exclusive with
		/// TXFS_RM_FLAG_PREFER_AVAILABILITY and is not supported by the default RM on the system volume.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_PREFER_AVAILABILITY 0x00020000</term>
		/// <term>
		/// Indicates that the RM is to prefer system availability over transaction consistency. This flag is mutually exclusive with
		/// TXFS_RM_FLAG_PREFER_CONSISTENCY and is forced by the default RM on the system volume.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public TXFS_RM_FLAG Flags;

		/// <summary>The maximum size of the log, in containers.</summary>
		public uint LogContainerCountMax;

		/// <summary>The minimum size of the log, in containers.</summary>
		public uint LogContainerCountMin;

		/// <summary>The actual size of the log, in containers.</summary>
		public uint LogContainerCount;

		/// <summary>The number of containers or percentage of space that should be added to the log.</summary>
		public uint LogGrowthIncrement;

		/// <summary>
		/// The percentage of log space to keep free. This member is used when the <c>TXFS_RM_FLAG_LOG_AUTO_SHRINK_PERCENTAGE</c> flag
		/// is used, and instructs the log to automatically shrink itself, so no more than <c>LogAutoShrinkPercentage</c> of the log is
		/// free at any given time.
		/// </summary>
		public uint LogAutoShrinkPercentage;

		/// <summary>Reserved.</summary>
		public ulong Reserved;

		/// <summary>
		/// <para>The current logging mode.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_LOGGING_MODE_SIMPLE 1</term>
		/// <term>Simple logging is used.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_LOGGING_MODE_FULL 2</term>
		/// <term>Full logging is used</term>
		/// </item>
		/// </list>
		/// </summary>
		public TXFS_LOGGING_MODE LoggingMode;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains information about the resource manager (RM).</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_query_rm_information typedef struct
	// _TXFS_QUERY_RM_INFORMATION { DWORD BytesRequired; DWORDLONG TailLsn; DWORDLONG CurrentLsn; DWORDLONG ArchiveTailLsn; DWORDLONG
	// LogContainerSize; LARGE_INTEGER HighestVirtualClock; DWORD LogContainerCount; DWORD LogContainerCountMax; DWORD
	// LogContainerCountMin; DWORD LogGrowthIncrement; DWORD LogAutoShrinkPercentage; DWORD Flags; WORD LoggingMode; WORD Reserved;
	// DWORD RmState; DWORDLONG LogCapacity; DWORDLONG LogFree; DWORDLONG TopsSize; DWORDLONG TopsUsed; DWORDLONG TransactionCount;
	// DWORDLONG OnePCCount; DWORDLONG TwoPCCount; DWORDLONG NumberLogFileFull; DWORDLONG OldestTransactionAge; GUID RMName; DWORD
	// TmLogPathOffset; } TXFS_QUERY_RM_INFORMATION, *PTXFS_QUERY_RM_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_QUERY_RM_INFORMATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_QUERY_RM_INFORMATION
	{
		/// <summary>
		/// If FSCTL_TXFS_QUERY_RM_INFORMATION returns <c>ERROR_BUFFER_TOO_SMALL</c>, this member specifies the minimum number of bytes
		/// needed to return the information requested, including the <c>NULL</c> terminating character.
		/// </summary>
		public uint BytesRequired;

		/// <summary>The oldest log sequence number (LSN) currently used by the RM.</summary>
		public ulong TailLsn;

		/// <summary>The LSN most recently used by the RM in its log.</summary>
		public ulong CurrentLsn;

		/// <summary>The LSN of the archive tail of the log.</summary>
		public ulong ArchiveTailLsn;

		/// <summary>The actual size of a log container, in bytes.</summary>
		public ulong LogContainerSize;

		/// <summary>The highest timestamp associated with a log record.</summary>
		public long HighestVirtualClock;

		/// <summary>The number of log containers.</summary>
		public uint LogContainerCount;

		/// <summary>The maximum number of log containers.</summary>
		public uint LogContainerCountMax;

		/// <summary>The minimum number of containers allowed in the log.</summary>
		public uint LogContainerCountMin;

		/// <summary>
		/// The amount the log will grow by, which is either a number of containers or percentage of the log size; the growth type used
		/// is specified by the flags set in <c>Flags</c> member.
		/// </summary>
		public uint LogGrowthIncrement;

		/// <summary>
		/// If the auto-shrink policy is active, this member specifies the maximum allowable amount of free space in the log. If this
		/// member is zero, the auto-shrink policy is not active.
		/// </summary>
		public uint LogAutoShrinkPercentage;

		/// <summary>
		/// <para>This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_CONTAINER_COUNT_MIN 0x00000008</term>
		/// <term>If the flag is set, the RM's log is allowed to shrink as far as possible. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_NUM_CONTAINERS 0x00000010</term>
		/// <term>
		/// Indicates the type of value in LogGrowthIncrement. If this flag is set, LogGrowthIncrement is a number of containers. This
		/// flag is mutually exclusive with TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_PERCENT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_PERCENT 0x00000020</term>
		/// <term>
		/// Indicates the type of value in LogGrowthIncrement. If this flag is set, LogGrowthIncrement is a percentage. This flag is
		/// mutually exclusive with TXFS_RM_FLAG_LOG_GROWTH_INCREMENT_NUM_CONTAINERS.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MAX 0x00000080</term>
		/// <term>Indicates that the RM's log can grow without bounds. This flag is mutually exclusive with TXFS_RM_FLAG_LOG_NO_CONTAINER_COUNT_MIN.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_RESET_RM_AT_NEXT_START 0x00004000</term>
		/// <term>
		/// Indicates the current state of the RM reset flag. If this is set, the RM will reset itself the next time it is started. This
		/// flag is only valid for default RMs, not secondary RMs. This flag is mutually exclusive with TXFS_RM_FLAG_DO_NOT_RESET_RM_AT_NEXT_START.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_DO_NOT_RESET_RM_AT_NEXT_START 0x00008000</term>
		/// <term>
		/// Indicates the current state of the RM reset flag. If this is set, the RM will not reset itself the next time it is started.
		/// This flag is only valid for default RMs, not secondary RMs. This flag is mutually exclusive with TXFS_RM_FLAG_RESET_RM_AT_NEXT_START.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_PREFER_CONSISTENCY 0x00010000</term>
		/// <term>
		/// Indicates that the RM is to prefer transaction consistency over system availability. This flag is mutually exclusive with
		/// TXFS_RM_FLAG_PREFER_AVAILABILITY and is not supported by the default RM on the system volume.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_FLAG_PREFER_AVAILABILITY 0x00020000</term>
		/// <term>
		/// Indicates that the RM is to prefer system availability over transaction consistency. This flag is mutually exclusive with
		/// TXFS_RM_FLAG_PREFER_CONSISTENCY and is forced by the default RM on the system volume.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public TXFS_RM_FLAG Flags;

		/// <summary>
		/// <para>The current logging mode.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_LOGGING_MODE_SIMPLE 1</term>
		/// <term>Simple logging is used.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_LOGGING_MODE_FULL 2</term>
		/// <term>Full logging is used</term>
		/// </item>
		/// </list>
		/// </summary>
		public TXFS_LOGGING_MODE LoggingMode;

		/// <summary>Reserved.</summary>
		public ushort Reserved;

		/// <summary>
		/// <para>The state of the RM. Valid values are as follows.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TXFS_RM_STATE_NOT_STARTED 0</term>
		/// <term>The RM is not yet started.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_STATE_STARTING 1</term>
		/// <term>The RM is starting.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_STATE_ACTIVE 2</term>
		/// <term>The RM is active and ready to accept transactions.</term>
		/// </item>
		/// <item>
		/// <term>TXFS_RM_STATE_SHUTTING_DOWN 3</term>
		/// <term>The RM is shutting down.</term>
		/// </item>
		/// </list>
		/// </summary>
		public TXFS_RM_STATE RmState;

		/// <summary>The total capacity of the log, in bytes.</summary>
		public ulong LogCapacity;

		/// <summary>The number of bytes free in the log.</summary>
		public ulong LogFree;

		/// <summary>The size of the $Tops file, in bytes.</summary>
		public ulong TopsSize;

		/// <summary>The amount of the $Tops file that is in use, in bytes.</summary>
		public ulong TopsUsed;

		/// <summary>The number of active transactions, at the time the query was issued.</summary>
		public ulong TransactionCount;

		/// <summary>The number of single-phase commit operations that have occurred on this RM.</summary>
		public ulong OnePCCount;

		/// <summary>The number of two-phase commit operations that have occurred on this RM.</summary>
		public ulong TwoPCCount;

		/// <summary>The number of times this RM's log has become full.</summary>
		public ulong NumberLogFileFull;

		/// <summary>The length of the oldest active transaction, in milliseconds.</summary>
		public ulong OldestTransactionAge;

		/// <summary>The <c>GUID</c> that indicates the name of this RM.</summary>
		public Guid RMName;

		/// <summary>
		/// The offset from the beginning of this structure to a <c>NULL</c>-terminated Unicode string that contains the path to the
		/// TM's log.
		/// </summary>
		public uint TmLogPathOffset;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains a Transactional NTFS (TxF) specific structure. This information should only be used when calling TXFS_WRITE_BACKUP_INFORMATION.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_read_backup_information_out typedef struct
	// _TXFS_READ_BACKUP_INFORMATION_OUT { union { DWORD BufferLength; BYTE Buffer[1]; } DUMMYUNIONNAME; }
	// TXFS_READ_BACKUP_INFORMATION_OUT, *PTXFS_READ_BACKUP_INFORMATION_OUT;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_READ_BACKUP_INFORMATION_OUT")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<TXFS_READ_BACKUP_INFORMATION_OUT>), "*")]
	[StructLayout(LayoutKind.Sequential, Size = 4)]
	public struct TXFS_READ_BACKUP_INFORMATION_OUT
	{
		/// <summary>The buffer for the data.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Buffer;

		/// <summary>If the buffer is not large enough, this member receives the required buffer size.</summary>
		public uint BufferLength => Buffer?.Length >= 4 ? BitConverter.ToUInt32(Buffer, 0) : 0;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains the flag that indicates whether transactions were active or not when a snapshot was taken.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_transaction_active_info typedef struct
	// _TXFS_TRANSACTION_ACTIVE_INFO { BOOLEAN TransactionsActiveAtSnapshot; } TXFS_TRANSACTION_ACTIVE_INFO, *PTXFS_TRANSACTION_ACTIVE_INFO;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_TRANSACTION_ACTIVE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_TRANSACTION_ACTIVE_INFO
	{
		/// <summary>
		/// This member is <c>TRUE</c> if the mounted snapshot volume had active transactions when the snapshot was taken; and
		/// <c>FALSE</c> otherwise.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)]
		public bool TransactionsActiveAtSnapshot;
	}

	/// <summary>
	/// <para>
	/// [Microsoft strongly recommends developers utilize alternative means to achieve your application’s needs. Many scenarios that TxF
	/// was developed for can be achieved through simpler and more readily available techniques. Furthermore, TxF may not be available
	/// in future versions of Microsoft Windows. For more information, and alternatives to TxF, please see Alternatives to using
	/// Transactional NTFS.]
	/// </para>
	/// <para>Contains a Transactional NTFS (TxF) specific structure. This information should only be used when calling TXFS_WRITE_BACKUP_INFORMATION.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-txfs_write_backup_information typedef struct
	// _TXFS_WRITE_BACKUP_INFORMATION { BYTE Buffer[1]; } TXFS_WRITE_BACKUP_INFORMATION, *PTXFS_WRITE_BACKUP_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._TXFS_WRITE_BACKUP_INFORMATION")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<TXFS_WRITE_BACKUP_INFORMATION>), "*")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TXFS_WRITE_BACKUP_INFORMATION
	{
		/// <summary>The buffer for the data.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Buffer;
	}

	/// <summary>Contains information used to verify a disk extent. It is the output buffer for the IOCTL_DISK_VERIFY control code.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-verify_information typedef struct _VERIFY_INFORMATION {
	// LARGE_INTEGER StartingOffset; DWORD Length; } VERIFY_INFORMATION, *PVERIFY_INFORMATION;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl._VERIFY_INFORMATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct VERIFY_INFORMATION
	{
		/// <summary>The starting offset of the disk extent.</summary>
		public long StartingOffset;

		/// <summary>The length of the disk extent, in bytes.</summary>
		public uint Length;
	}

	/// <summary>
	/// Represents the occupied and available clusters on a disk. This structure is the output buffer for the FSCTL_GET_VOLUME_BITMAP
	/// control code.
	/// </summary>
	/// <remarks>
	/// The <c>BitmapSize</c> member is the number of clusters on the volume starting from the starting LCN returned in the
	/// <c>StartingLcn</c> member of this structure. For example, suppose there are 0xD3F7 clusters on the volume. If you start the
	/// bitmap query at LCN 0xA007, then both the FAT and NTFS file systems will round down the returned starting LCN to LCN 0xA000. The
	/// value returned in the <c>BitmapSize</c> member will be (0xD3F7 – 0xA000), or 0x33F7.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-volume_bitmap_buffer typedef struct { LARGE_INTEGER
	// StartingLcn; LARGE_INTEGER BitmapSize; BYTE Buffer[1]; } VOLUME_BITMAP_BUFFER, *PVOLUME_BITMAP_BUFFER;
	[PInvokeData("winioctl.h", MSDNShortId = "NS:winioctl.__unnamed_struct_6")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<VOLUME_BITMAP_BUFFER>), nameof(BitmapSize))]
	[StructLayout(LayoutKind.Sequential)]
	public struct VOLUME_BITMAP_BUFFER
	{
		/// <summary>Starting LCN requested as an input to the operation.</summary>
		public long StartingLcn;

		/// <summary>
		/// The number of clusters on the volume, starting from the starting LCN returned in the <c>StartingLcn</c> member of this
		/// structure. See the following Remarks section for details.
		/// </summary>
		public long BitmapSize;

		/// <summary>
		/// Array of bytes containing the bitmap that the operation returns. The bitmap is bitwise from bit zero of the bitmap to the
		/// end. Thus, starting at the requested cluster, the bitmap goes from bit 0 of byte 0, bit 1 of byte 0 ... bit 7 of byte 0, bit
		/// 0 of byte 1, and so on. The value 1 indicates that the cluster is allocated (in use). The value 0 indicates that the cluster
		/// is not allocated (free).
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Buffer;
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct STORAGE_DEVICE_DESCRIPTOR
	{
		public uint Version;

		public uint Size;

		public byte DeviceType;

		public byte DeviceTypeModifier;

		[MarshalAs(UnmanagedType.U1)]
		public bool RemovableMedia;

		[MarshalAs(UnmanagedType.U1)]
		public bool CommandQueueing;

		public uint VendorIdOffset;

		public uint ProductIdOffset;

		public uint ProductRevisionOffset;

		public uint SerialNumberOffset;

		public STORAGE_BUS_TYPE BusType;

		public uint RawPropertiesLength;

		public byte RawDeviceProperties;
	}

	private class STORAGE_DEVICE_DESCRIPTOR_Marshaler : IVanaraMarshaler
	{
		static readonly Lazy<long> propOffset = new (() => Marshal.OffsetOf(typeof(STORAGE_DEVICE_DESCRIPTOR), nameof(STORAGE_DEVICE_DESCRIPTOR.RawDeviceProperties)).ToInt64());

		SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(STORAGE_DEVICE_DESCRIPTOR));

		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object? managedObject) => new SafeCoTaskMemHandle(1024);

		object? IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
		{
			if (pNativeData == IntPtr.Zero) return null;
			var sdd = (STORAGE_DEVICE_DESCRIPTOR)Marshal.PtrToStructure(pNativeData, typeof(STORAGE_DEVICE_DESCRIPTOR))!;
			return new STORAGE_DEVICE_DESCRIPTOR_MGD
			{
				Version = sdd.Version,
				DeviceType = sdd.DeviceType,
				DeviceTypeModifier = sdd.DeviceTypeModifier,
				RemovableMedia = sdd.RemovableMedia,
				CommandQueueing = sdd.CommandQueueing,
				VendorId = sdd.VendorIdOffset == 0 ? null : Marshal.PtrToStringAnsi(pNativeData.Offset(sdd.VendorIdOffset))!,
				ProductId = sdd.ProductIdOffset == 0 ? null : Marshal.PtrToStringAnsi(pNativeData.Offset(sdd.ProductIdOffset))!,
				ProductRevision = sdd.ProductRevisionOffset == 0 ? null : Marshal.PtrToStringAnsi(pNativeData.Offset(sdd.ProductRevisionOffset))!,
				SerialNumber = sdd.SerialNumberOffset == 0 ? null : Marshal.PtrToStringAnsi(pNativeData.Offset(sdd.SerialNumberOffset))!,
				BusType = sdd.BusType,
				RawDeviceProperties = pNativeData.Offset(propOffset.Value).ToArray<byte>((int)sdd.RawPropertiesLength)!,
			};
		}
	}
}