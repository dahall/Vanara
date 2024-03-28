using System.ComponentModel;
using System.Linq;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke;

public static partial class IMAPI
{
	/// <summary/>
	public const uint IMAPI_SECTOR_SIZE = 2048;

	/// <summary>Defines values for the burn verification implemented by the IBurnVerification interface.</summary>
	/// <remarks>
	/// <para>
	/// Depending on the format used for the burned media, the values defined by this enumeration will elicit the following behavior during verification:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>MsftDiscFormat2Data</term>
	/// <term/>
	/// </listheader>
	/// <item>
	/// <term>None</term>
	/// <term>No burn verification.</term>
	/// </item>
	/// <item>
	/// <term>Quick Verification</term>
	/// <term/>
	/// </item>
	/// <item>
	/// <term>Full Verification</term>
	/// <term/>
	/// </item>
	/// </list>
	/// <list type="table">
	/// <listheader>
	/// <term>MsftDiscFormat2TrackAtOnce</term>
	/// <term/>
	/// </listheader>
	/// <item>
	/// <term>None</term>
	/// <term>No burn verification.</term>
	/// </item>
	/// <item>
	/// <term>Quick Verification</term>
	/// <term>After adding each track: When finishing the disc:</term>
	/// </item>
	/// <item>
	/// <term>Full Verification</term>
	/// <term>Full verification is not supported with this format.</term>
	/// </item>
	/// </list>
	/// <para>The time required for a full verification is relative to the read speed of the device and storage medium.</para>
	/// <para>
	/// This enumeration is supported in Windows Server 2003 with Service Pack 1 (SP1), Windows XP with Service Pack 2 (SP2), and Windows
	/// Vista via the Windows Feature Pack for Storage. All features provided by this update package are supported natively in Windows 7 and
	/// Windows Server 2008 R2.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_burn_verification_level typedef enum
	// _IMAPI_BURN_VERIFICATION_LEVEL { IMAPI_BURN_VERIFICATION_NONE, IMAPI_BURN_VERIFICATION_QUICK, IMAPI_BURN_VERIFICATION_FULL }
	// IMAPI_BURN_VERIFICATION_LEVEL, *PIMAPI_BURN_VERIFICATION_LEVEL;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_BURN_VERIFICATION_LEVEL")]
	[Serializable]
	public enum IMAPI_BURN_VERIFICATION_LEVEL
	{
		/// <summary>No burn verification.</summary>
		[Description("No write verification")] 
		IMAPI_BURN_VERIFICATION_NONE,

		/// <summary>A quick, heuristic burn verification.</summary>
		[Description("Quick write verification")] 
		IMAPI_BURN_VERIFICATION_QUICK,

		/// <summary>
		/// This verification compares the checksum to the referenced stream for either the last session or each track. A full verification
		/// includes the heuristic checks of a quick verification for both burn formats.
		/// </summary>
		[Description("Full write verification")] 
		IMAPI_BURN_VERIFICATION_FULL,
	}

	/// <summary>Defines the sector types that can be written to CD media.</summary>
	/// <remarks>
	/// <para>
	/// Some sector types are not compatible with other sector types within a single image. The following are typical examples of this condition:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>If the first track is audio, then all tracks must be audio.</term>
	/// </item>
	/// <item>
	/// <term>If the first track is Mode1, then all tracks must be Mode1.</term>
	/// </item>
	/// <item>
	/// <term>
	/// Only the three Mode2 (XA) sectors (Mode 2 Form 0, Mode 2 Form 1, and Mode 2 Form 2) may be mixed within a single disc image, and
	/// even then, only with other Mode 2 (XA) sector types.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_cd_sector_type typedef enum _IMAPI_CD_SECTOR_TYPE {
	// IMAPI_CD_SECTOR_AUDIO, IMAPI_CD_SECTOR_MODE_ZERO, IMAPI_CD_SECTOR_MODE1, IMAPI_CD_SECTOR_MODE2FORM0, IMAPI_CD_SECTOR_MODE2FORM1,
	// IMAPI_CD_SECTOR_MODE2FORM2, IMAPI_CD_SECTOR_MODE1RAW, IMAPI_CD_SECTOR_MODE2FORM0RAW, IMAPI_CD_SECTOR_MODE2FORM1RAW,
	// IMAPI_CD_SECTOR_MODE2FORM2RAW } IMAPI_CD_SECTOR_TYPE, *PIMAPI_CD_SECTOR_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_CD_SECTOR_TYPE")]
	[Serializable]
	public enum IMAPI_CD_SECTOR_TYPE : int
	{
		/// <summary>
		/// With this sector type, Audio data has 2352 bytes per sector/frame. This can be broken down into 588 contiguous samples, each
		/// sample being four bytes. The layout of a single sample matches the 16-bit stereo 44.1KHz WAV file data. This type of sector has
		/// no additional error correcting codes.
		/// </summary>
		[Description("2352 bytes per sector of audio data")] 
		IMAPI_CD_SECTOR_AUDIO,

		/// <summary>
		/// With this sector type, user data has 2336 bytes per sector/frame. This seldom-used sector type contains all zero data, and is
		/// almost never seen in media today.
		/// </summary>
		[Description("2336 bytes per sector of zeros, rare")] 
		IMAPI_CD_SECTOR_MODE_ZERO,

		/// <summary>
		/// With this sector type, user data has 2048 bytes per sector/frame. Mode1 data is the most common data form for pressed CD-ROM
		/// media. This data type also provides the greatest level of ECC/EDC among the standard sector types.
		/// </summary>
		[Description("2048 bytes per sector of user data")] 
		IMAPI_CD_SECTOR_MODE1,

		/// <summary>
		/// With this sector type, user data has 2336 bytes per sector/frame. All Mode 2 sector types are also known as "CD-ROM XA" modes,
		/// which allows mixing of audio and data tracks on a single disc. This sector type is also known as Mode 2 "Formless", is
		/// considered deprecated, and is very seldom used.
		/// </summary>
		[Description("2336 bytes per sector, rare XA form")] 
		IMAPI_CD_SECTOR_MODE2FORM0,

		/// <summary>
		/// With this sector type, user data has 2048 bytes per sector/frame. All Mode 2 sector types are also known as "CD-ROM XA" modes,
		/// which allows mixing of audio and data tracks on a single disc.
		/// </summary>
		[Description("2048 bytes per sector, data XA form")] 
		IMAPI_CD_SECTOR_MODE2FORM1,

		/// <summary>
		/// With this sector type, user data has 2336 bytes per sector/frame, of which the final four bytes are an optional CRC code (zero
		/// if not used). All Mode 2 sector types are also known as "CD-ROM XA" modes, which allows mixing of audio and data tracks on a
		/// single disc. This sector type is most often used when writing VideoCD discs.
		/// </summary>
		[Description("2336 bytes per sector, VideoCD form")] 
		IMAPI_CD_SECTOR_MODE2FORM2,

		/// <summary>
		/// With this sector type, user data has 2352 bytes per sector/frame. This is pre-processed Mode1Cooked data sectors, with sector
		/// header, ECC/EDC, and scrambling already added to the data stream.
		/// </summary>
		[Description("2352 bytes per sector, Mode1 data (with EDC/ECC/scrambling)")] 
		IMAPI_CD_SECTOR_MODE1RAW,

		/// <summary>
		/// With this sector type, user data has 2352 bytes per sector/frame. This is pre-processed Mode2Form0 data sectors, with sector
		/// header, ECC/EDC, and scrambling already added to the data stream.
		/// </summary>
		[Description("2352 bytes per sector, Mode2Form0 data (with EDC/ECC/scrambling)")] 
		IMAPI_CD_SECTOR_MODE2FORM0RAW,

		/// <summary>
		/// With this sector type, user data has 2352 bytes per sector/frame. This is pre-processed Mode2Form1 data sectors, with sector
		/// header, ECC/EDC, and scrambling already added to the data stream.
		/// </summary>
		[Description("2352 bytes per sector, Mode2Form1 data (with EDC/ECC/scrambling)")] 
		IMAPI_CD_SECTOR_MODE2FORM1RAW,

		/// <summary>
		/// With this sector type, user data has 2352 bytes per sector/frame. This is pre-processed Mode2Form2 data sectors, with sector
		/// header, ECC/EDC, and scrambling already added to the data stream.
		/// </summary>
		[Description("2352 bytes per sector, Mode2Form2 data (with EDC/ECC/scrambling)")] 
		IMAPI_CD_SECTOR_MODE2FORM2RAW,
	}

	/// <summary>Defines the digital copy setting values available for a given track.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_cd_track_digital_copy_setting typedef enum
	// _IMAPI_CD_TRACK_DIGITAL_COPY_SETTING { IMAPI_CD_TRACK_DIGITAL_COPY_PERMITTED, IMAPI_CD_TRACK_DIGITAL_COPY_PROHIBITED,
	// IMAPI_CD_TRACK_DIGITAL_COPY_SCMS } IMAPI_CD_TRACK_DIGITAL_COPY_SETTING, *PIMAPI_CD_TRACK_DIGITAL_COPY_SETTING;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_CD_TRACK_DIGITAL_COPY_SETTING")]
	[Serializable]
	public enum IMAPI_CD_TRACK_DIGITAL_COPY_SETTING : int
	{
		/// <summary>Digital copies of the given track are allowed.</summary>
		[Description("Digital Copies Allowed")] 
		IMAPI_CD_TRACK_DIGITAL_COPY_PERMITTED,

		/// <summary>
		/// Digital copies of the given track are not allowed using consumer electronics CD recorders. This condition typically has no
		/// effect on PC-based CD players.
		/// </summary>
		[Description("Digital Copies Not Allowed")] 
		IMAPI_CD_TRACK_DIGITAL_COPY_PROHIBITED,

		/// <summary>
		/// The given track is a digital copy of a copy protected track. No further copies using consumer electronics CD recorders will be
		/// allowed. This condition typically has no effect on PC-based CD players.
		/// </summary>
		[Description("Copy of an Original Copy Prohibited Track")] 
		IMAPI_CD_TRACK_DIGITAL_COPY_SCMS,
	}

	/// <summary>Defines values for the feature that are supported by the logical unit (CD and DVD device).</summary>
	/// <remarks>
	/// <para>
	/// Note that the range of feature type values is 0x0000 to 0xFFFF. This enumeration contains those features defined in the Multmedia
	/// Commands - 5 (MMC) specification. For a complete definition of each feature, see Feature Definitions in the latest release of the
	/// MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </para>
	/// <para>
	/// Other values not defined here may exist. Consumers of this enumeration should not presume this list to be the only set of valid values.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_feature_page_type typedef enum _IMAPI_FEATURE_PAGE_TYPE {
	// IMAPI_FEATURE_PAGE_TYPE_PROFILE_LIST, IMAPI_FEATURE_PAGE_TYPE_CORE, IMAPI_FEATURE_PAGE_TYPE_MORPHING,
	// IMAPI_FEATURE_PAGE_TYPE_REMOVABLE_MEDIUM, IMAPI_FEATURE_PAGE_TYPE_WRITE_PROTECT, IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_READABLE,
	// IMAPI_FEATURE_PAGE_TYPE_CD_MULTIREAD, IMAPI_FEATURE_PAGE_TYPE_CD_READ, IMAPI_FEATURE_PAGE_TYPE_DVD_READ,
	// IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_WRITABLE, IMAPI_FEATURE_PAGE_TYPE_INCREMENTAL_STREAMING_WRITABLE,
	// IMAPI_FEATURE_PAGE_TYPE_SECTOR_ERASABLE, IMAPI_FEATURE_PAGE_TYPE_FORMATTABLE, IMAPI_FEATURE_PAGE_TYPE_HARDWARE_DEFECT_MANAGEMENT,
	// IMAPI_FEATURE_PAGE_TYPE_WRITE_ONCE, IMAPI_FEATURE_PAGE_TYPE_RESTRICTED_OVERWRITE, IMAPI_FEATURE_PAGE_TYPE_CDRW_CAV_WRITE,
	// IMAPI_FEATURE_PAGE_TYPE_MRW, IMAPI_FEATURE_PAGE_TYPE_ENHANCED_DEFECT_REPORTING, IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_RW,
	// IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R, IMAPI_FEATURE_PAGE_TYPE_RIGID_RESTRICTED_OVERWRITE, IMAPI_FEATURE_PAGE_TYPE_CD_TRACK_AT_ONCE,
	// IMAPI_FEATURE_PAGE_TYPE_CD_MASTERING, IMAPI_FEATURE_PAGE_TYPE_DVD_DASH_WRITE, IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_READ,
	// IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_R_WRITE, IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_RW_WRITE,
	// IMAPI_FEATURE_PAGE_TYPE_LAYER_JUMP_RECORDING, IMAPI_FEATURE_PAGE_TYPE_CD_RW_MEDIA_WRITE_SUPPORT,
	// IMAPI_FEATURE_PAGE_TYPE_BD_PSEUDO_OVERWRITE, IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R_DUAL_LAYER, IMAPI_FEATURE_PAGE_TYPE_BD_READ,
	// IMAPI_FEATURE_PAGE_TYPE_BD_WRITE, IMAPI_FEATURE_PAGE_TYPE_HD_DVD_READ, IMAPI_FEATURE_PAGE_TYPE_HD_DVD_WRITE,
	// IMAPI_FEATURE_PAGE_TYPE_POWER_MANAGEMENT, IMAPI_FEATURE_PAGE_TYPE_SMART, IMAPI_FEATURE_PAGE_TYPE_EMBEDDED_CHANGER,
	// IMAPI_FEATURE_PAGE_TYPE_CD_ANALOG_PLAY, IMAPI_FEATURE_PAGE_TYPE_MICROCODE_UPDATE, IMAPI_FEATURE_PAGE_TYPE_TIMEOUT,
	// IMAPI_FEATURE_PAGE_TYPE_DVD_CSS, IMAPI_FEATURE_PAGE_TYPE_REAL_TIME_STREAMING, IMAPI_FEATURE_PAGE_TYPE_LOGICAL_UNIT_SERIAL_NUMBER,
	// IMAPI_FEATURE_PAGE_TYPE_MEDIA_SERIAL_NUMBER, IMAPI_FEATURE_PAGE_TYPE_DISC_CONTROL_BLOCKS, IMAPI_FEATURE_PAGE_TYPE_DVD_CPRM,
	// IMAPI_FEATURE_PAGE_TYPE_FIRMWARE_INFORMATION, IMAPI_FEATURE_PAGE_TYPE_AACS, IMAPI_FEATURE_PAGE_TYPE_VCPS } IMAPI_FEATURE_PAGE_TYPE, *PIMAPI_FEATURE_PAGE_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_FEATURE_PAGE_TYPE")]
	[Serializable]
	public enum IMAPI_FEATURE_PAGE_TYPE
	{
		/// <summary>Identifies profiles supported by the logical unit.</summary>
		IMAPI_FEATURE_PAGE_TYPE_PROFILE_LIST = 0x0,

		/// <summary>Identifies a logical unit that supports functionality common to all devices.</summary>
		IMAPI_FEATURE_PAGE_TYPE_CORE = 0x1,

		/// <summary>
		/// Identifies the ability of the logical unit to notify an initiator about operational changes and accept initiator requests to
		/// prevent operational changes.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_MORPHING = 0x2,

		/// <summary>Identifies a logical unit that has a medium that is removable.</summary>
		IMAPI_FEATURE_PAGE_TYPE_REMOVABLE_MEDIUM = 0x3,

		/// <summary>Identifies reporting capability and changing capability for write protection status of the logical unit.</summary>
		IMAPI_FEATURE_PAGE_TYPE_WRITE_PROTECT = 0x4,

		/// <summary>Identifies a logical unit that is able to read data from logical blocks specified by Logical Block Addresses.</summary>
		IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_READABLE = 0x10,

		/// <summary>
		/// Identifies a logical unit that conforms to the OSTA Multi-Read specification 1.00, with the exception of CD Play capability (the
		/// CD Audio Feature is not required).
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_CD_MULTIREAD = 0x1D,

		/// <summary>
		/// Identifies a logical unit that is able to read CD specific information from the media and is able to read user data from all
		/// types of CD blocks.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_CD_READ = 0x1E,

		/// <summary>Identifies a logical unit that is able to read DVD specific information from the media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DVD_READ = 0x1F,

		/// <summary>Identifies a logical unit that is able to write data to logical blocks specified by Logical Block Addresses.</summary>
		IMAPI_FEATURE_PAGE_TYPE_RANDOMLY_WRITABLE = 0x20,

		/// <summary>
		/// Identifies a logical unit that is able to write data to a contiguous region, and is able to append data to a limited number of
		/// locations on the media.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_INCREMENTAL_STREAMING_WRITABLE = 0x21,

		/// <summary>
		/// Identifies a logical unit that supports erasable media and media that requires an erase pass before overwrite, such as some
		/// magneto-optical technologies.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_SECTOR_ERASABLE = 0x22,

		/// <summary>Identifies a logical unit that can format media into logical blocks.</summary>
		IMAPI_FEATURE_PAGE_TYPE_FORMATTABLE = 0x23,

		/// <summary>Identifies a logical unit that has defect management available to provide a defect-free contiguous address space.</summary>
		IMAPI_FEATURE_PAGE_TYPE_HARDWARE_DEFECT_MANAGEMENT = 0x24,

		/// <summary>Identifies a logical unit that has the ability to record to any previously unrecorded logical block.</summary>
		IMAPI_FEATURE_PAGE_TYPE_WRITE_ONCE = 0x25,

		/// <summary>Identifies a logical unit that has the ability to overwrite logical blocks only in fixed sets at a time.</summary>
		IMAPI_FEATURE_PAGE_TYPE_RESTRICTED_OVERWRITE = 0x26,

		/// <summary>Identifies a logical unit that has the ability to write CD-RW media that is designed for CAV recording.</summary>
		IMAPI_FEATURE_PAGE_TYPE_CDRW_CAV_WRITE = 0x27,

		/// <summary>Indicates that the logical unit is capable of reading a disc with the MRW format.</summary>
		IMAPI_FEATURE_PAGE_TYPE_MRW = 0x28,

		/// <summary>
		/// Identifies a logical unit that has the ability to perform media certification and recovered error reporting for logical unit
		/// assisted software defect management.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_ENHANCED_DEFECT_REPORTING = 0x29,

		/// <summary>Indicates that the logical unit is capable of reading a recorded DVD+RW disc.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_RW = 0x2A,

		/// <summary>Indicates that the logical unit is capable of reading a recorded DVD+R disc.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R = 0x2B,

		/// <summary>Identifies a logical unit that has the ability to perform writing only on Blocking boundaries.</summary>
		IMAPI_FEATURE_PAGE_TYPE_RIGID_RESTRICTED_OVERWRITE = 0x2C,

		/// <summary>Identifies a logical unit that is able to write data to a CD track.</summary>
		IMAPI_FEATURE_PAGE_TYPE_CD_TRACK_AT_ONCE = 0x2D,

		/// <summary>Identifies a logical unit that is able to write a CD in Session at Once mode or Raw mode.</summary>
		IMAPI_FEATURE_PAGE_TYPE_CD_MASTERING = 0x2E,

		/// <summary>Identifies a logical unit that has the ability to write data to DVD-R/-RW in Disc at Once mode.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DVD_DASH_WRITE = 0x2F,

		/// <summary>Identifies a logical unit that has the ability to read double density CD specific information from the media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_READ = 0x30,

		/// <summary>Identifies a logical unit that has the ability to write to double density CD media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_R_WRITE = 0x31,

		/// <summary>Identifies a logical unit that has the ability to write to double density CD-RW media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DOUBLE_DENSITY_CD_RW_WRITE = 0x32,

		/// <summary>
		/// Identifies a drive that is able to write data to contiguous regions that are allocated on multiplelayers, and is able to append
		/// data to a limited number of locations on the media.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_LAYER_JUMP_RECORDING = 0x33,

		/// <summary>Identifies a logical unit that has the ability to perform writing CD-RW media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_CD_RW_MEDIA_WRITE_SUPPORT = 0x37,

		/// <summary>Identifies a drive that provides Logical Block overwrite service on BD-R discs that areformatted as SRM+POW.</summary>
		IMAPI_FEATURE_PAGE_TYPE_BD_PSEUDO_OVERWRITE = 0x38,

		/// <summary>Indicates that the drive is capable of reading a recorded DVD+R Double Layer disc</summary>
		IMAPI_FEATURE_PAGE_TYPE_DVD_PLUS_R_DUAL_LAYER = 0x3B,

		/// <summary>Identifies a logical unit that is able to read control structures and user data from the Blu-ray disc.</summary>
		IMAPI_FEATURE_PAGE_TYPE_BD_READ = 0x40,

		/// <summary>Identifies a drive that is able to write control structures and user data to writeable Blu-ray discs.</summary>
		IMAPI_FEATURE_PAGE_TYPE_BD_WRITE = 0x41,

		/// <summary>Identifies a drive that is able to read HD DVD specific information from the media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_HD_DVD_READ = 0x50,

		/// <summary>Indicates the ability to write to HD DVD-R/-RW media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_HD_DVD_WRITE = 0x51,

		/// <summary>Identifies a logical unit that is able to perform initiator and logical unit directed power management.</summary>
		IMAPI_FEATURE_PAGE_TYPE_POWER_MANAGEMENT = 0x100,

		/// <summary>Identifies a logical unit that is able to perform Self-Monitoring Analysis and Reporting Technology (S.M.A.R.T.).</summary>
		IMAPI_FEATURE_PAGE_TYPE_SMART,

		/// <summary>Identifies a logical unit that is able to move media from a storage area to a mechanism and back.</summary>
		IMAPI_FEATURE_PAGE_TYPE_EMBEDDED_CHANGER,

		/// <summary>Identifies a logical unit that is able to play CD Audio data directly to an external output.</summary>
		IMAPI_FEATURE_PAGE_TYPE_CD_ANALOG_PLAY,

		/// <summary>Identifies a logical unit that is able to upgrade its internal microcode via the interface.</summary>
		IMAPI_FEATURE_PAGE_TYPE_MICROCODE_UPDATE,

		/// <summary>Identifies a logical unit that is able to always respond to commands within a set time period.</summary>
		IMAPI_FEATURE_PAGE_TYPE_TIMEOUT,

		/// <summary>
		/// Identifies a logical unit that is able to perform DVD CSS/CPPM authentication and key management. This feature also indicates
		/// that the logical unit supports CSS for DVD-Video and CPPM for DVD-Audio.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_DVD_CSS,

		/// <summary>
		/// Identifies a logical unit that is able to perform reading and writing within initiator specified (and logical unit verified)
		/// performance ranges. This Feature also indicates whether the logical unit supports the stream playback operation.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_REAL_TIME_STREAMING,

		/// <summary>Identifies a logical unit that has a unique serial number.</summary>
		IMAPI_FEATURE_PAGE_TYPE_LOGICAL_UNIT_SERIAL_NUMBER,

		/// <summary>Identifies a logical unit that is capable of reading a media serial number of the currently installed media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_MEDIA_SERIAL_NUMBER,

		/// <summary>Identifies a logical unit that is able to read and/or write Disc Control Blocks from or to the media.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DISC_CONTROL_BLOCKS,

		/// <summary>Identifies a logical unit that is able to perform DVD CPRM and is able to perform CPRM authentication and key management.</summary>
		IMAPI_FEATURE_PAGE_TYPE_DVD_CPRM,

		/// <summary>
		/// Indicates that the logical unit provides the date and time of the creation of the current firmware revision loaded on the device.
		/// </summary>
		IMAPI_FEATURE_PAGE_TYPE_FIRMWARE_INFORMATION,

		/// <summary>Identifies a drive that supports AACS and is able to perform AACS authentication process.</summary>
		IMAPI_FEATURE_PAGE_TYPE_AACS,

		/// <summary>Identifies a Drive that is able to process disc data structures that are specified in theVCPS.</summary>
		IMAPI_FEATURE_PAGE_TYPE_VCPS = 0x110,
	}

	/// <summary>Reports information (but not errors) about the media state.</summary>
	[Description("Mask of 'supported/informational' media flags")]
	public const IMAPI_FORMAT2_DATA_MEDIA_STATE IMAPI_FORMAT2_DATA_MEDIA_STATE_INFORMATIONAL_MASK = (IMAPI_FORMAT2_DATA_MEDIA_STATE)0x000F;

	/// <summary>Reports an unsupported media state.</summary>
	[Description("Mask of 'not supported' media flags")]
	public const IMAPI_FORMAT2_DATA_MEDIA_STATE IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MASK = (IMAPI_FORMAT2_DATA_MEDIA_STATE)0xFC00;

	/// <summary>Defines values for the possible media states.</summary>
	/// <remarks>
	/// This enumeration should be treated as a bitmask. Nearly all of the values set one bit set to one and the other bits to zero. Three
	/// exceptions to this rule were added: unknown, unsupported media mask, and informational mask. For example, to test for unsupported
	/// media, check the value against IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MASK.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_format2_data_media_state typedef enum
	// _IMAPI_FORMAT2_DATA_MEDIA_STATE { IMAPI_FORMAT2_DATA_MEDIA_STATE_UNKNOWN, IMAPI_FORMAT2_DATA_MEDIA_STATE_INFORMATIONAL_MASK,
	// IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MASK, IMAPI_FORMAT2_DATA_MEDIA_STATE_OVERWRITE_ONLY,
	// IMAPI_FORMAT2_DATA_MEDIA_STATE_RANDOMLY_WRITABLE, IMAPI_FORMAT2_DATA_MEDIA_STATE_BLANK, IMAPI_FORMAT2_DATA_MEDIA_STATE_APPENDABLE,
	// IMAPI_FORMAT2_DATA_MEDIA_STATE_FINAL_SESSION, IMAPI_FORMAT2_DATA_MEDIA_STATE_DAMAGED, IMAPI_FORMAT2_DATA_MEDIA_STATE_ERASE_REQUIRED,
	// IMAPI_FORMAT2_DATA_MEDIA_STATE_NON_EMPTY_SESSION, IMAPI_FORMAT2_DATA_MEDIA_STATE_WRITE_PROTECTED,
	// IMAPI_FORMAT2_DATA_MEDIA_STATE_FINALIZED, IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MEDIA } IMAPI_FORMAT2_DATA_MEDIA_STATE, *PIMAPI_FORMAT2_DATA_MEDIA_STATE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_FORMAT2_DATA_MEDIA_STATE")]
	[Flags]
	[Serializable]
	public enum IMAPI_FORMAT2_DATA_MEDIA_STATE
	{
		/// <summary>Indicates that the interface does not know the media state.</summary>
		[Description("Unknown")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_UNKNOWN = 0x0,

		/// <summary>Write operations can occur on used portions of the disc.</summary>
		[Description("Media may only be overwritten")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_OVERWRITE_ONLY = 0x0001,

		/// <summary>Media has never been used, or has been erased.</summary>
		[Description("Media is blank")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_BLANK = 0x0002,

		/// <summary>Media is appendable (supports multiple sessions).</summary>
		[Description("Media is appendable")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_APPENDABLE = 0x0004,

		/// <summary>Media can have only one additional session added to it, or the media does not support multiple sessions.</summary>
		[Description("Media may only be written to one more time, or does not support multiple sessions")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_FINAL_SESSION = 0x0008,

		/// <summary>Media is not usable by this interface. The media might require an erase or other recovery.</summary>
		[Description("Media is not usable by data writer (may require erase or other recovery)")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_DAMAGED = 0x0400,

		/// <summary>Media must be erased prior to use by this interface.</summary>
		[Description("Media must be erased before use")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_ERASE_REQUIRED = 0x0800,

		/// <summary>Media has a partially written last session, which is not supported by this interface.</summary>
		[Description("Media has a partially written last session, which is not supported")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_NON_EMPTY_SESSION = 0x1000,

		/// <summary>Media or drive is write-protected.</summary>
		[Description("Media (or drive) is write protected")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_WRITE_PROTECTED = 0x2000,

		/// <summary>Media cannot be written to (finalized).</summary>
		[Description("Media cannot be written to (finalized)")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_FINALIZED = 0x4000,

		/// <summary>Media is not supported by this interface.</summary>
		[Description("Media is not supported by data writer")]
		IMAPI_FORMAT2_DATA_MEDIA_STATE_UNSUPPORTED_MEDIA = 0x8000,
	}

	/// <summary>Defines values that indicate the current state of the write operation when using the IDiscFormat2DataEventArgs interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_format2_data_write_action typedef enum
	// _IMAPI_FORMAT2_DATA_WRITE_ACTION { IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA,
	// IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA, IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE,
	// IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER, IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA,
	// IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION, IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED, IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING }
	// IMAPI_FORMAT2_DATA_WRITE_ACTION, *PIMAPI_FORMAT2_DATA_WRITE_ACTION;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_FORMAT2_DATA_WRITE_ACTION")]
	[Serializable]
	public enum IMAPI_FORMAT2_DATA_WRITE_ACTION
	{
		/// <summary>Validating that the current media is supported.</summary>
		[Description("Validating the current media is supported")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_VALIDATING_MEDIA,

		/// <summary>Formatting media, when required.</summary>
		[Description("Formatting media, when required (i.e. DVD+RW)")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_FORMATTING_MEDIA,

		/// <summary>Initializing the hardware, for example, setting drive write speeds.</summary>
		[Description("Initializing the drive")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_INITIALIZING_HARDWARE,

		/// <summary>Optimizing laser intensity for writing to the media.</summary>
		[Description("Calibrating the drive's write power")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_CALIBRATING_POWER,

		/// <summary>Writing data to the media.</summary>
		[Description("Writing user data to the media")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_WRITING_DATA,

		/// <summary>
		/// Finalizing the write. This state is media dependent and can include items such as closing the track or session, or finishing
		/// background formatting.
		/// </summary>
		[Description("Finalizing the media (synchronizing the cache, closing tracks/sessions, etc.")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_FINALIZATION,

		/// <summary>Successfully finished the write process.</summary>
		[Description("The write process has completed")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_COMPLETED,

		/// <summary>Verifying the integrity of the burned media.</summary>
		[Description("Performing requested burn verification")]
		IMAPI_FORMAT2_DATA_WRITE_ACTION_VERIFYING,
	}

	/// <summary>Defines values that indicate the type of sub-channel data.</summary>
	/// <remarks>
	/// For details on the format of the sub-channel data, see Sub-Channel Field Formats in the latest release of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_format2_raw_cd_data_sector_type typedef enum
	// _IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE { IMAPI_FORMAT2_RAW_CD_SUBCODE_PQ_ONLY, IMAPI_FORMAT2_RAW_CD_SUBCODE_IS_COOKED,
	// IMAPI_FORMAT2_RAW_CD_SUBCODE_IS_RAW } IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE, *PIMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE")]
	[Serializable]
	public enum IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE
	{
		/// <summary>The data contains P and Q sub-channel data.</summary>
		[Description("Raw Main Channel P an Q Sub-channel data (type 0x01)")]
		IMAPI_FORMAT2_RAW_CD_SUBCODE_PQ_ONLY = 1,

		/// <summary>The data contains corrected and de-interleaved R-W sub-channel data.</summary>
		[Description("Raw Main Channel With Cooked P-W Subcode (type 0x02)")]
		IMAPI_FORMAT2_RAW_CD_SUBCODE_IS_COOKED,

		/// <summary>The data contains raw P-W sub-channel data that is returned in the order received from the disc surface.</summary>
		[Description("Raw Main Channel With Raw P-W Subcode (type 0x03)")]
		IMAPI_FORMAT2_RAW_CD_SUBCODE_IS_RAW,
	}

	/// <summary>Defines values that indicate the current state of the write operation when using the IDiscFormat2RawCDEventArgs interface.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_format2_raw_cd_write_action typedef enum
	// _IMAPI_FORMAT2_RAW_CD_WRITE_ACTION { IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_UNKNOWN, IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_PREPARING,
	// IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_WRITING, IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_FINISHING } IMAPI_FORMAT2_RAW_CD_WRITE_ACTION, *PIMAPI_FORMAT2_RAW_CD_WRITE_ACTION;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_FORMAT2_RAW_CD_WRITE_ACTION")]
	[Serializable]
	public enum IMAPI_FORMAT2_RAW_CD_WRITE_ACTION
	{
		/// <summary>Indicates an unknown state.</summary>
		[Description("Unknown")]
		IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_UNKNOWN,

		/// <summary>Preparing to write the session.</summary>
		[Description("Preparing to write media")]
		IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_PREPARING,

		/// <summary>Writing session data.</summary>
		[Description("Writing the media")]
		IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_WRITING,

		/// <summary>Synchronizing the drive's cache with the end of the data written to disc.</summary>
		[Description("Finishing writing the media")]
		IMAPI_FORMAT2_RAW_CD_WRITE_ACTION_FINISHING,
	}

	/// <summary>
	/// Defines values that indicate the current state of the write operation when using the IDiscFormat2TrackAtOnceEventArgs interface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_format2_tao_write_action typedef enum
	// _IMAPI_FORMAT2_TAO_WRITE_ACTION { IMAPI_FORMAT2_TAO_WRITE_ACTION_UNKNOWN, IMAPI_FORMAT2_TAO_WRITE_ACTION_PREPARING,
	// IMAPI_FORMAT2_TAO_WRITE_ACTION_WRITING, IMAPI_FORMAT2_TAO_WRITE_ACTION_FINISHING, IMAPI_FORMAT2_TAO_WRITE_ACTION_VERIFYING }
	// IMAPI_FORMAT2_TAO_WRITE_ACTION, *PIMAPI_FORMAT2_TAO_WRITE_ACTION;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_FORMAT2_TAO_WRITE_ACTION")]
	[Serializable]
	public enum IMAPI_FORMAT2_TAO_WRITE_ACTION
	{
		/// <summary>Indicates an unknown state.</summary>
		[Description("Unknown")]
		IMAPI_FORMAT2_TAO_WRITE_ACTION_UNKNOWN,

		/// <summary>Preparing to write the track.</summary>
		[Description("Preparing to write track")]
		IMAPI_FORMAT2_TAO_WRITE_ACTION_PREPARING,

		/// <summary>Writing the track.</summary>
		[Description("writing the track")]
		IMAPI_FORMAT2_TAO_WRITE_ACTION_WRITING,

		/// <summary>Closing the track or closing the session.</summary>
		[Description("closing the track")]
		IMAPI_FORMAT2_TAO_WRITE_ACTION_FINISHING,

		/// <summary/>
		[Description("verifying track data")]
		IMAPI_FORMAT2_TAO_WRITE_ACTION_VERIFYING,
	}

	/// <summary>Defines values for the currently known media types supported by IMAPI.</summary>
	/// <remarks>
	/// The values in the range 0x00000000..0x0000FFFF inclusive are reserved for extension by Microsoft. If third parties wish to report a
	/// media type not in this list using this enumeration (for example, if implementing IDiscFormat2Data::get_CurrentPhysicalMediaType to
	/// support a non-listed format) they should define values only in the range 0x00010000..0xFFFFFFFF for these media types.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_media_physical_type typedef enum _IMAPI_MEDIA_PHYSICAL_TYPE
	// { IMAPI_MEDIA_TYPE_UNKNOWN, IMAPI_MEDIA_TYPE_CDROM, IMAPI_MEDIA_TYPE_CDR, IMAPI_MEDIA_TYPE_CDRW, IMAPI_MEDIA_TYPE_DVDROM,
	// IMAPI_MEDIA_TYPE_DVDRAM, IMAPI_MEDIA_TYPE_DVDPLUSR, IMAPI_MEDIA_TYPE_DVDPLUSRW, IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER,
	// IMAPI_MEDIA_TYPE_DVDDASHR, IMAPI_MEDIA_TYPE_DVDDASHRW, IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER, IMAPI_MEDIA_TYPE_DISK,
	// IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER, IMAPI_MEDIA_TYPE_HDDVDROM, IMAPI_MEDIA_TYPE_HDDVDR, IMAPI_MEDIA_TYPE_HDDVDRAM,
	// IMAPI_MEDIA_TYPE_BDROM, IMAPI_MEDIA_TYPE_BDR, IMAPI_MEDIA_TYPE_BDRE, IMAPI_MEDIA_TYPE_MAX } IMAPI_MEDIA_PHYSICAL_TYPE, *PIMAPI_MEDIA_PHYSICAL_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_MEDIA_PHYSICAL_TYPE")]
	[Serializable]
	public enum IMAPI_MEDIA_PHYSICAL_TYPE : int
	{
		/// <summary>The disc recorder contains an unknown media type or the recorder is empty.</summary>
		[Description("Media not present or unrecognized")]
		IMAPI_MEDIA_TYPE_UNKNOWN,

		/// <summary>The drive contains CD-ROM or CD-R/RW media.</summary>
		[Description("CD-ROM media")]
		IMAPI_MEDIA_TYPE_CDROM,

		/// <summary>The drive contains write once (CD-R) media.</summary>
		[Description("CD-R media")]
		IMAPI_MEDIA_TYPE_CDR,

		/// <summary>The drive contains rewritable (CD-RW) media.</summary>
		[Description("CD-RW media")]
		IMAPI_MEDIA_TYPE_CDRW,

		/// <summary>Either the DVD drive or DVD media is read-only.</summary>
		[Description("DVD-ROM media")]
		IMAPI_MEDIA_TYPE_DVDROM,

		/// <summary>The drive contains DVD-RAM media.</summary>
		[Description("DVD-RAM media")]
		IMAPI_MEDIA_TYPE_DVDRAM,

		/// <summary>The drive contains write once media that supports the DVD plus format (DVD+R) .</summary>
		[Description("DVD+R media")]
		IMAPI_MEDIA_TYPE_DVDPLUSR,

		/// <summary>The drive contains rewritable media that supports the DVD plus format (DVD+RW).</summary>
		[Description("DVD+RW media")]
		IMAPI_MEDIA_TYPE_DVDPLUSRW,

		/// <summary>The drive contains write once dual layer media that supports the DVD plus format (DVD+R DL).</summary>
		[Description("DVD+R dual layer media")]
		IMAPI_MEDIA_TYPE_DVDPLUSR_DUALLAYER,

		/// <summary>The drive contains write once media that supports the DVD dash format (DVD-R).</summary>
		[Description("DVD-R media")]
		IMAPI_MEDIA_TYPE_DVDDASHR,

		/// <summary>The drive contains rewritable media that supports the DVD dash format (DVD-RW).</summary>
		[Description("DVD-RW media")]
		IMAPI_MEDIA_TYPE_DVDDASHRW,

		/// <summary>The drive contains write once dual layer media that supports the DVD dash format (DVD-R DL).</summary>
		[Description("DVD-R dual layer media")]
		IMAPI_MEDIA_TYPE_DVDDASHR_DUALLAYER,

		/// <summary>
		/// The drive contains a media type that supports random-access writes. This media type supports hardware defect management that
		/// identifies and avoids using damaged tracks.
		/// </summary>
		[Description("Randomly writable media")]
		IMAPI_MEDIA_TYPE_DISK,

		/// <summary>The drive contains rewritable dual layer media that supports the DVD plus format (DVD+RW DL).</summary>
		[Description("DVD+RW dual layer media")]
		IMAPI_MEDIA_TYPE_DVDPLUSRW_DUALLAYER,

		/// <summary>The drive contains high definition read only DVD media (HD DVD-ROM).</summary>
		[Description("HD DVD-ROM media")]
		IMAPI_MEDIA_TYPE_HDDVDROM,

		/// <summary>The drive contains write once high definition media (HD DVD-R).</summary>
		[Description("HD DVD-R media")]
		IMAPI_MEDIA_TYPE_HDDVDR,

		/// <summary>The drive contains random access high definition media (HD DVD-RAM).</summary>
		[Description("HD DVD-RAM media")]
		IMAPI_MEDIA_TYPE_HDDVDRAM,

		/// <summary>The drive contains read only Blu-ray media (BD-ROM).</summary>
		[Description("BD-ROM media")]
		IMAPI_MEDIA_TYPE_BDROM,

		/// <summary>The drive contains write once Blu-ray media (BD-R).</summary>
		[Description("BD-R media")]
		IMAPI_MEDIA_TYPE_BDR,

		/// <summary>The drive contains rewritable Blu-ray media (BD-RE) media.</summary>
		[Description("BD-RE media")]
		IMAPI_MEDIA_TYPE_BDRE,

		/// <summary>This value is the maximum value defined in IMAPI_MEDIA_PHYSICAL_TYPE.</summary>
		[Description("Max value for a media type")]
		IMAPI_MEDIA_TYPE_MAX,
	}

	/// <summary>
	/// Defines values that indicate the media write protect status. One or more write protect values can be set on a given drive.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_media_write_protect_state typedef enum
	// _IMAPI_MEDIA_WRITE_PROTECT_STATE { IMAPI_WRITEPROTECTED_UNTIL_POWERDOWN, IMAPI_WRITEPROTECTED_BY_CARTRIDGE,
	// IMAPI_WRITEPROTECTED_BY_MEDIA_SPECIFIC_REASON, IMAPI_WRITEPROTECTED_BY_SOFTWARE_WRITE_PROTECT,
	// IMAPI_WRITEPROTECTED_BY_DISC_CONTROL_BLOCK, IMAPI_WRITEPROTECTED_READ_ONLY_MEDIA } IMAPI_MEDIA_WRITE_PROTECT_STATE, *PIMAPI_MEDIA_WRITE_PROTECT_STATE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_MEDIA_WRITE_PROTECT_STATE")]
	[Flags]
	[Serializable]
	public enum IMAPI_MEDIA_WRITE_PROTECT_STATE
	{
		/// <summary>Power to the drive needs to be cycled before allowing writes to the media.</summary>
		[Description("Software Write Protected Until Powerdown")]
		IMAPI_WRITEPROTECTED_UNTIL_POWERDOWN = 0x00001,

		/// <summary>The media is in a cartridge with the write protect tab set.</summary>
		[Description("Cartridge Write Protect")]
		IMAPI_WRITEPROTECTED_BY_CARTRIDGE = 0x00002,

		/// <summary>The drive is disallowing writes for a media-specific reason. For example:</summary>
		[Description("Media Specific Write Inhibit")]
		IMAPI_WRITEPROTECTED_BY_MEDIA_SPECIFIC_REASON = 0x00004,

		/// <summary>
		/// A write-protect flag on the media is set. Various media types, such as DVD-RAM and DVD-RW, support a special area on the media
		/// to indicate the disc's write protect status.
		/// </summary>
		[Description("Persistent Write Protect")]
		IMAPI_WRITEPROTECTED_BY_SOFTWARE_WRITE_PROTECT = 0x00008,

		/// <summary>
		/// A write-protect flag in the disc control block of a DVD+RW disc is set. DVD+RW media can persistently alter the write protect
		/// state of media by writing a device control block (DCB) to the media. This value has limited usefulness because some DVD+RW
		/// drives do not recognize or honor this setting.
		/// </summary>
		[Description("Write Inhibit by Disc Control Block")]
		IMAPI_WRITEPROTECTED_BY_DISC_CONTROL_BLOCK = 0x00010,

		/// <summary>The drive does not recognize write capability of the media.</summary>
		[Description("Read-only media")]
		IMAPI_WRITEPROTECTED_READ_ONLY_MEDIA = 0x04000,
	}

	/// <summary>Defines values that indicate requests sent to a device using the MODE_SENSE10 MMC command.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_mode_page_request_type typedef enum
	// _IMAPI_MODE_PAGE_REQUEST_TYPE { IMAPI_MODE_PAGE_REQUEST_TYPE_CURRENT_VALUES, IMAPI_MODE_PAGE_REQUEST_TYPE_CHANGEABLE_VALUES,
	// IMAPI_MODE_PAGE_REQUEST_TYPE_DEFAULT_VALUES, IMAPI_MODE_PAGE_REQUEST_TYPE_SAVED_VALUES } IMAPI_MODE_PAGE_REQUEST_TYPE, *PIMAPI_MODE_PAGE_REQUEST_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_MODE_PAGE_REQUEST_TYPE")]
	[Serializable]
	public enum IMAPI_MODE_PAGE_REQUEST_TYPE
	{
		/// <summary>
		/// Requests current settings of the mode page. This is the most common request type, and the most commonly supported type of this command.
		/// </summary>
		[Description("Request the current mode page")]
		IMAPI_MODE_PAGE_REQUEST_TYPE_CURRENT_VALUES,

		/// <summary>
		/// Requests a mask that indicates settings that are write enabled. A write-enabled setting has a corresponding bit that is set to
		/// one in the mask. A read-only setting has a corresponding bit that is set to zero in the mask .
		/// </summary>
		[Description("Request the changeable bitmask for a mode page")]
		IMAPI_MODE_PAGE_REQUEST_TYPE_CHANGEABLE_VALUES,

		/// <summary>Requests the power-on settings of the drive.</summary>
		[Description("Request the default mode page")]
		IMAPI_MODE_PAGE_REQUEST_TYPE_DEFAULT_VALUES,

		/// <summary>Requests a saved configuration for a drive. This functionality might not be supported on all devices.</summary>
		[Description("Request the saved mode page (if supported by device)")]
		IMAPI_MODE_PAGE_REQUEST_TYPE_SAVED_VALUES,
	}

	/// <summary>Defines values for the mode pages that are supported by CD and DVD devices.</summary>
	/// <remarks>
	/// Note that the range of mode page type values is 0x0000 to 0xFFFF. This enumeration contains those features defined in the Multmedia
	/// Commands - 5 (MMC) specification. For a complete definition of each feature, see Mode Parameters for Multi-Media Devices in the
	/// latest release of the MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_mode_page_type typedef enum _IMAPI_MODE_PAGE_TYPE {
	// IMAPI_MODE_PAGE_TYPE_READ_WRITE_ERROR_RECOVERY, IMAPI_MODE_PAGE_TYPE_MRW, IMAPI_MODE_PAGE_TYPE_WRITE_PARAMETERS,
	// IMAPI_MODE_PAGE_TYPE_CACHING, IMAPI_MODE_PAGE_TYPE_INFORMATIONAL_EXCEPTIONS, IMAPI_MODE_PAGE_TYPE_TIMEOUT_AND_PROTECT,
	// IMAPI_MODE_PAGE_TYPE_POWER_CONDITION, IMAPI_MODE_PAGE_TYPE_LEGACY_CAPABILITIES } IMAPI_MODE_PAGE_TYPE, *PIMAPI_MODE_PAGE_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_MODE_PAGE_TYPE")]
	[Serializable]
	public enum IMAPI_MODE_PAGE_TYPE
	{
		/// <summary>
		/// The mode page specifies the error recovery parameters thedrive uses during any command that performs a data read or write
		/// operation from the media.
		/// </summary>
		[Description("The parameters to use for error recovery during read and write operations")]
		IMAPI_MODE_PAGE_TYPE_READ_WRITE_ERROR_RECOVERY = 0x01,

		/// <summary>The mode page provides a method by which the host may control the special features of aMRW CD-RW Drive.</summary>
		[Description("Mt. Rainier (MRW) mode page for controlling MRW-specific features")]
		IMAPI_MODE_PAGE_TYPE_MRW = 0x03,

		/// <summary>The mode page provides parameters that are often needed in the execution ofcommands that write to the media.</summary>
		[Description("The parameters required to setup writing to and from some legacy media types")]
		IMAPI_MODE_PAGE_TYPE_WRITE_PARAMETERS = 0x05,

		/// <summary>The mode page contains parameters to enable or disable caching during read or write operations.</summary>
		[Description("The parameters to enable or disable the use of caching for read and/or write operations")]
		IMAPI_MODE_PAGE_TYPE_CACHING = 0x08,

		/// <summary>
		/// The mode page contains parameters for exception reporting mechanisms that result in specific sense code errors when failures are
		/// predicted. This mode page is related to the S.M.A.R.T. feature.
		/// </summary>
		[Description("The parameters for exception reporting mechanisms which result in specific sense codes errors when failures are predicted")]
		IMAPI_MODE_PAGE_TYPE_INFORMATIONAL_EXCEPTIONS = 0x1C, //?

		/// <summary>The mode page contains command time-out values that are suggested by the device.</summary>
		[Description("Default timeouts for commands")]
		IMAPI_MODE_PAGE_TYPE_TIMEOUT_AND_PROTECT = 0x1D,

		/// <summary>
		/// The mode page contains power management settings for the drive. The parameters define how long the logical unit delays before
		/// changing its internal power state.
		/// </summary>
		[Description("The parameters which define how long the logical unit delays before changing its power state")]
		IMAPI_MODE_PAGE_TYPE_POWER_CONDITION = 0x1A,

		/// <summary>
		/// The mode page contains legacy device capabilities. These are superseded by the feature pages returned through the
		/// GetConfiguration command.
		/// </summary>
		[Description("Legacy device capabilities, superceded by the feature pages returned by GetConfiguration command")]
		IMAPI_MODE_PAGE_TYPE_LEGACY_CAPABILITIES = 0x2A,
	}

	/// <summary>
	/// Defines values for the possible profiles of a CD and DVD device. A profile defines the type of media and features that the device supports.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Note that the range of feature type values is 0x0000 to 0xFFFF. This enumeration contains those features defined in the Multmedia
	/// Commands - 5 (MMC) specification. For a complete definition of each profile, see Profile Definitions in the latest release of the
	/// MMC specification at ftp://ftp.t10.org/t10/drafts/mmc5.
	/// </para>
	/// <para>
	/// Other values not defined here may exist. Consumers of this enumeration should not presume this list to be the only set of valid values.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_profile_type typedef enum _IMAPI_PROFILE_TYPE {
	// IMAPI_PROFILE_TYPE_INVALID, IMAPI_PROFILE_TYPE_NON_REMOVABLE_DISK, IMAPI_PROFILE_TYPE_REMOVABLE_DISK, IMAPI_PROFILE_TYPE_MO_ERASABLE,
	// IMAPI_PROFILE_TYPE_MO_WRITE_ONCE, IMAPI_PROFILE_TYPE_AS_MO, IMAPI_PROFILE_TYPE_CDROM, IMAPI_PROFILE_TYPE_CD_RECORDABLE,
	// IMAPI_PROFILE_TYPE_CD_REWRITABLE, IMAPI_PROFILE_TYPE_DVDROM, IMAPI_PROFILE_TYPE_DVD_DASH_RECORDABLE, IMAPI_PROFILE_TYPE_DVD_RAM,
	// IMAPI_PROFILE_TYPE_DVD_DASH_REWRITABLE, IMAPI_PROFILE_TYPE_DVD_DASH_RW_SEQUENTIAL, IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_SEQUENTIAL,
	// IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_LAYER_JUMP, IMAPI_PROFILE_TYPE_DVD_PLUS_RW, IMAPI_PROFILE_TYPE_DVD_PLUS_R,
	// IMAPI_PROFILE_TYPE_DDCDROM, IMAPI_PROFILE_TYPE_DDCD_RECORDABLE, IMAPI_PROFILE_TYPE_DDCD_REWRITABLE,
	// IMAPI_PROFILE_TYPE_DVD_PLUS_RW_DUAL, IMAPI_PROFILE_TYPE_DVD_PLUS_R_DUAL, IMAPI_PROFILE_TYPE_BD_ROM,
	// IMAPI_PROFILE_TYPE_BD_R_SEQUENTIAL, IMAPI_PROFILE_TYPE_BD_R_RANDOM_RECORDING, IMAPI_PROFILE_TYPE_BD_REWRITABLE,
	// IMAPI_PROFILE_TYPE_HD_DVD_ROM, IMAPI_PROFILE_TYPE_HD_DVD_RECORDABLE, IMAPI_PROFILE_TYPE_HD_DVD_RAM, IMAPI_PROFILE_TYPE_NON_STANDARD }
	// IMAPI_PROFILE_TYPE, *PIMAPI_PROFILE_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_PROFILE_TYPE")]
	[Serializable]
	public enum IMAPI_PROFILE_TYPE
	{
		/// <summary>The profile is not valid.</summary>
		IMAPI_PROFILE_TYPE_INVALID = 0,

		/// <summary>The hard disk it not removable.</summary>
		IMAPI_PROFILE_TYPE_NON_REMOVABLE_DISK,

		/// <summary>The hard disk is removable.</summary>
		IMAPI_PROFILE_TYPE_REMOVABLE_DISK,

		/// <summary>An Magneto-Optical Erasable drive.</summary>
		IMAPI_PROFILE_TYPE_MO_ERASABLE,

		/// <summary>A write once optical drive.</summary>
		IMAPI_PROFILE_TYPE_MO_WRITE_ONCE,

		/// <summary>An advance storage Magneto-Optical drive.</summary>
		IMAPI_PROFILE_TYPE_AS_MO,

		/// <summary>A CD-ROM drive.</summary>
		IMAPI_PROFILE_TYPE_CDROM = 0x08,

		/// <summary>A CD-R drive.</summary>
		IMAPI_PROFILE_TYPE_CD_RECORDABLE,

		/// <summary>A CD-RW or CD+RW drive.</summary>
		IMAPI_PROFILE_TYPE_CD_REWRITABLE,

		/// <summary>A DVD-ROM drive.</summary>
		IMAPI_PROFILE_TYPE_DVDROM = 0x10,

		/// <summary>A DVD-R sequential recording drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_DASH_RECORDABLE,

		/// <summary>A DVD-RAM drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_RAM,

		/// <summary>A DVD-RW restricted overwrite drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_DASH_REWRITABLE,

		/// <summary>A DVD-RW sequential recording drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_DASH_RW_SEQUENTIAL,

		/// <summary>A DVD-R dual layer sequential recording drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_SEQUENTIAL,

		/// <summary>A DVD-R dual layer jump recording drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_DASH_R_DUAL_LAYER_JUMP,

		/// <summary>A DVD+RW drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_PLUS_RW = 0x1a,

		/// <summary>A DVD+R drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_PLUS_R,

		/// <summary>A double density CD drive.</summary>
		IMAPI_PROFILE_TYPE_DDCDROM = 0x20,

		/// <summary>A double density CD-R drive.</summary>
		IMAPI_PROFILE_TYPE_DDCD_RECORDABLE,

		/// <summary>A double density CD-RW drive.</summary>
		IMAPI_PROFILE_TYPE_DDCD_REWRITABLE,

		/// <summary>A DVD+RW dual layer drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_PLUS_RW_DUAL = 0x2a,

		/// <summary>A DVD+R dual layer drive.</summary>
		IMAPI_PROFILE_TYPE_DVD_PLUS_R_DUAL,

		/// <summary>A Blu-ray read only drive.</summary>
		IMAPI_PROFILE_TYPE_BD_ROM = 0x40,

		/// <summary>A write once Blu-ray drive with sequential recording.</summary>
		IMAPI_PROFILE_TYPE_BD_R_SEQUENTIAL,

		/// <summary>A write once Blu-ray drive with random-access recording capability.</summary>
		IMAPI_PROFILE_TYPE_BD_R_RANDOM_RECORDING,

		/// <summary>A rewritable Blu-ray drive.</summary>
		IMAPI_PROFILE_TYPE_BD_REWRITABLE,

		/// <summary>A read only high density DVD drive.</summary>
		IMAPI_PROFILE_TYPE_HD_DVD_ROM = 0x50,

		/// <summary>A write once high density DVD drive.</summary>
		IMAPI_PROFILE_TYPE_HD_DVD_RECORDABLE,

		/// <summary>A high density DVD drive with random access positioning.</summary>
		IMAPI_PROFILE_TYPE_HD_DVD_RAM,

		/// <summary>Nonstandard drive.</summary>
		IMAPI_PROFILE_TYPE_NON_STANDARD = 0xffff,
	}

	/// <summary>
	/// Defines values that indicate how to interpret track addresses for the current disc profile of a randomly-writable,
	/// hardware-defect-managed media type.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/imapi2/ne-imapi2-imapi_read_track_address_type typedef enum
	// _IMAPI_READ_TRACK_ADDRESS_TYPE { IMAPI_READ_TRACK_ADDRESS_TYPE_LBA, IMAPI_READ_TRACK_ADDRESS_TYPE_TRACK,
	// IMAPI_READ_TRACK_ADDRESS_TYPE_SESSION } IMAPI_READ_TRACK_ADDRESS_TYPE, *PIMAPI_READ_TRACK_ADDRESS_TYPE;
	[PInvokeData("imapi2.h", MSDNShortId = "NE:imapi2._IMAPI_READ_TRACK_ADDRESS_TYPE")]
	[Serializable]
	public enum IMAPI_READ_TRACK_ADDRESS_TYPE
	{
		/// <summary>
		/// Interpret the address field as an LBA (sector address). The returned data should reflect the information for the track which
		/// contains the specified LBA.
		/// </summary>
		IMAPI_READ_TRACK_ADDRESS_TYPE_LBA,

		/// <summary>
		/// Interpret the address field as a track number. The returned data should reflect the information for the specified track. This
		/// version of the command has the greatest compatibility with legacy devices.
		/// </summary>
		IMAPI_READ_TRACK_ADDRESS_TYPE_TRACK,

		/// <summary>
		/// Interpret the address field as a session number. The returned data should reflect the information for the first track which
		/// exists in the specified session. Note that not all drives support this method.
		/// </summary>
		IMAPI_READ_TRACK_ADDRESS_TYPE_SESSION,
	}
}