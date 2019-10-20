namespace Vanara.PInvoke
{
	public static partial class Kernel32
	{
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
			StorageDeviceProperty,

			/// <summary>Indicates that the caller is querying for the adapter descriptor, STORAGE_ADAPTER_DESCRIPTOR.</summary>
			StorageAdapterProperty,

			/// <summary>
			/// Indicates that the caller is querying for the device identifiers provided with the SCSI vital product data pages. Data is
			/// returned using the STORAGE_DEVICE_ID_DESCRIPTOR structure.
			/// </summary>
			StorageDeviceIdProperty,

			/// <summary>
			/// Intended for driver usage. Indicates that the caller is querying for the unique device identifiers. Data is returned using
			/// the STORAGE_DEVICE_UNIQUE_IDENTIFIER structure (see the storduid.h header in the DDK). Windows Server 2003 and Windows XP:
			/// This value is not supported before Windows Vista and Windows Server 2008.
			/// </summary>
			StorageDeviceUniqueIdProperty,

			/// <summary>
			/// Indicates that the caller is querying for the write cache property. Data is returned using the STORAGE_WRITE_CACHE_PROPERTY
			/// structure. Windows Server 2003 and Windows XP: This value is not supported before Windows Vista and Windows Server 2008.
			/// </summary>
			StorageDeviceWriteCacheProperty,

			/// <summary>Reserved for system use.</summary>
			StorageMiniportProperty,

			/// <summary>
			/// Indicates that the caller is querying for the access alignment descriptor, STORAGE_ACCESS_ALIGNMENT_DESCRIPTOR. Windows
			/// Server 2003 and Windows XP: This value is not supported before Windows Vista and Windows Server 2008.
			/// </summary>
			StorageAccessAlignmentProperty,

			/// <summary>
			/// Indicates that the caller is querying for the trim descriptor, DEVICE_TRIM_DESCRIPTOR. Windows Server 2008, Windows Vista,
			/// Windows Server 2003 and Windows XP: This value is not supported before Windows 7 and Windows Server 2008 R2.
			/// </summary>
			StorageDeviceTrimProperty,

			/// <summary>
			/// Indicates that the caller is querying for the device power descriptor. Data is returned using the DEVICE_POWER_DESCRIPTOR
			/// structure. Windows 7, Windows Server 2008 R2, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: This
			/// value is not supported before Windows 8 and Windows Server 2012.
			/// </summary>
			StorageDevicePowerProperty,

			/// <summary>Reserved for system use.</summary>
			StorageDeviceResiliencyProperty,

			/// <summary>
			/// Indicates that the caller is querying for the medium product type. Data is returned using the
			/// STORAGE_MEDIUM_PRODUCT_TYPE_DESCRIPTOR structure.
			/// </summary>
			StorageDeviceMediumProductType,

			/// <summary>
			/// Indicates that the caller is querying for RPMB support and properties. Data is returned using the STORAGE_RPMB_DESCRIPTOR structure.
			/// </summary>
			StorageAdapterRpmbProperty,

			/// <summary/>
			StorageAdapterCryptoProperty,

			/// <summary>
			/// Indicates that the caller is querying for the device I/O capability property. Data is returned using the
			/// DEVICE_IO_CAPABILITY_DESCRIPTOR structure.
			/// </summary>
			StorageDeviceIoCapabilityProperty,

			/// <summary>
			/// Indicates that the caller is querying for protocol-specific data from the adapter. Data is returned using the
			/// STORAGE_PROTOCOL_DATA_DESCRIPTOR structure. See the remarks for more info.
			/// </summary>
			StorageAdapterProtocolSpecificProperty,

			/// <summary>
			/// Indicates that the caller is querying for protocol-specific data from the device. Data is returned using the
			/// STORAGE_PROTOCOL_DATA_DESCRIPTOR structure. See the remarks for more info.
			/// </summary>
			StorageDeviceProtocolSpecificProperty,

			/// <summary>
			/// Indicates that the caller is querying temperature data from the adapter. Data is returned using the
			/// STORAGE_TEMPERATURE_DATA_DESCRIPTOR structure.
			/// </summary>
			StorageAdapterTemperatureProperty,

			/// <summary>
			/// Indicates that the caller is querying for temperature data from the device. Data is returned using the
			/// STORAGE_TEMPERATURE_DATA_DESCRIPTOR structure.
			/// </summary>
			StorageDeviceTemperatureProperty,

			/// <summary>
			/// Indicates that the caller is querying for topology information from the adapter. Data is returned using the
			/// STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR structure.
			/// </summary>
			StorageAdapterPhysicalTopologyProperty,

			/// <summary>
			/// Indicates that the caller is querying for topology information from the device. Data is returned using the
			/// STORAGE_PHYSICAL_TOPOLOGY_DESCRIPTOR structure.
			/// </summary>
			StorageDevicePhysicalTopologyProperty,

			/// <summary>Reserved for future use.</summary>
			StorageDeviceAttributesProperty,

			/// <summary/>
			StorageDeviceManagementStatus,

			/// <summary/>
			StorageAdapterSerialNumberProperty,

			/// <summary/>
			StorageDeviceLocationProperty,

			/// <summary/>
			StorageDeviceNumaProperty,

			/// <summary/>
			StorageDeviceZonedDeviceProperty,

			/// <summary/>
			StorageDeviceUnsafeShutdownCount,

			/// <summary/>
			StorageDeviceEnduranceProperty,
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
}