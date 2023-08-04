using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke;

/// <summary>Items from the WinBio.dll</summary>
public static partial class WinBio
{
	/// <summary>The winbio anti spoof turn side to side</summary>
	public const WINBIO_REJECT_DETAIL WINBIO_ANTI_SPOOF_TURN_SIDE_TO_SIDE = (WINBIO_REJECT_DETAIL)0x01000000;

	/// <summary>Represents a mask for all of the _FLAG_ bits.</summary>
	public const WINBIO_DATABASE WINBIO_DATABASE_FLAG_MASK = (WINBIO_DATABASE)0xFFFF0000;

	/// <summary>Represents a mask for all of the _TYPE_ bits.</summary>
	public const WINBIO_DATABASE WINBIO_DATABASE_TYPE_MASK = (WINBIO_DATABASE)0x0000FFFF;

	/// <summary>
	/// This mask covers the upper 8 bits of the reject detail value where the proof-of-liveness behaviors are located. This value is
	/// supported starting in Windows 10.
	/// </summary>
	public const WINBIO_REJECT_DETAIL WINBIO_REJECT_DETAIL_ANTI_SPOOF_MASK = (WINBIO_REJECT_DETAIL)0xFF000000;

	/// <summary>This mask covers the range of bits devoted to position errors. This value is supported starting in Windows 10.</summary>
	public const WINBIO_REJECT_DETAIL WINBIO_REJECT_DETAIL_POSITION_MASK = (WINBIO_REJECT_DETAIL)0x00FF0000;

	/// <summary>
	/// This mask covers the lower 16 bits where the enumerated reason for the rejection is located. This value is supported starting in
	/// Windows 10.
	/// </summary>
	public const WINBIO_REJECT_DETAIL WINBIO_REJECT_DETAIL_REASON_MASK = (WINBIO_REJECT_DETAIL)0x0000FFFF;

	/// <summary>Bitmask that specifies the supported set of biometric factors.</summary>
	public const WINBIO_BIOMETRIC_TYPE WINBIO_STANDARD_TYPE_MASK = (WINBIO_BIOMETRIC_TYPE)0x00FFFFFF;

	/// <summary>The following constants are reserved for future use.</summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum BIO_UNIT : ushort
	{
		/// <summary>Reserved for future use.</summary>
		BIO_UNIT_RAW = 0x0001,

		/// <summary>Reserved for future use.</summary>
		BIO_UNIT_MAINTENANCE = 0x0002,

		/// <summary>Reserved for future use.</summary>
		BIO_UNIT_OPEN_SESSION = 0x0004,

		/// <summary>Reserved for future use.</summary>
		BIO_UNIT_EXTENDED_ACCESS = 0x0008,

		/// <summary>Reserved for future use.</summary>
		BIO_UNIT_ENROLL = 0x0010,

		/// <summary>Reserved for future use.</summary>
		BIO_UNIT_DELETE_TEMPLATE = 0x0020,

		/// <summary>Reserved for future use.</summary>
		BIO_UNIT_CONTROL_UNIT = 0x0040,
	}

	/// <summary>The following values can be used in the WINBIO_REGISTERED_FORMAT structure.</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_381_FORMAT : ushort
	{
		/// <summary>InterNational Committee for Information Technology Standards (INCITS) technical committee M1 (biometrics).</summary>
		WINBIO_ANSI_381_FORMAT_OWNER = 0x001B,

		/// <summary>ANSI INCITS 381 finger image based data interchange format.</summary>
		WINBIO_ANSI_381_FORMAT_TYPE = 0x0401,
	}

	/// <summary>The following constants can be used to specify the type of image compression used by a sensor:</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_381_IMG : byte
	{
		/// <summary></summary>
		WINBIO_ANSI_381_IMG_UNCOMPRESSED = 0,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_BIT_PACKED = 1,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_COMPRESSED_WSQ = 2,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_COMPRESSED_JPEG = 3,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_COMPRESSED_JPEG2000 = 4,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_COMPRESSED_PNG = 5,
	}

	/// <summary>The following constants can be used to specify image acquisition levels:</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_381_IMG_ACQ : byte
	{
		/// <summary></summary>
		WINBIO_ANSI_381_IMG_ACQ_LEVEL_10 = 10,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_ACQ_LEVEL_20 = 20,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_ACQ_LEVEL_30 = 30,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_ACQ_LEVEL_31 = 31,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_ACQ_LEVEL_40 = 40,

		/// <summary></summary>
		WINBIO_ANSI_381_IMG_ACQ_LEVEL_41 = 41,
	}

	/// <summary>The following constants can be used to specify finger and palm impression types:</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_381_IMP_TYPE : byte
	{
		/// <summary></summary>
		WINBIO_ANSI_381_IMP_TYPE_LIVE_SCAN_PLAIN = 0,

		/// <summary></summary>
		WINBIO_ANSI_381_IMP_TYPE_LIVE_SCAN_ROLLED = 1,

		/// <summary></summary>
		WINBIO_ANSI_381_IMP_TYPE_NONLIVE_SCAN_PLAIN = 2,

		/// <summary></summary>
		WINBIO_ANSI_381_IMP_TYPE_NONLIVE_SCAN_ROLLED = 3,

		/// <summary></summary>
		WINBIO_ANSI_381_IMP_TYPE_LATENT = 7,

		/// <summary></summary>
		WINBIO_ANSI_381_IMP_TYPE_SWIPE = 8,

		/// <summary></summary>
		WINBIO_ANSI_381_IMP_TYPE_LIVE_SCAN_CONTACTLESS = 9,
	}

	/// <summary>The following constants can be used to specify scale units:</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_381_PIXELS : byte
	{
		/// <summary></summary>
		WINBIO_ANSI_381_PIXELS_PER_INCH = 0x01,

		/// <summary></summary>
		WINBIO_ANSI_381_PIXELS_PER_CM = 0x02,
	}

	/// <summary>The following constants can be used to specify the fingers scanned by a sensor:</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_381_POS_FINGER : byte
	{
		/// <summary></summary>
		WINBIO_ANSI_381_POS_UNKNOWN = 0,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_THUMB = 1,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_INDEX_FINGER = 2,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER = 3,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_RING_FINGER = 4,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_LITTLE_FINGER = 5,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_THUMB = 6,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_INDEX_FINGER = 7,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER = 8,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_RING_FINGER = 9,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_LITTLE_FINGER = 10,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_FOUR_FINGERS = 13,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_FOUR_FINGERS = 14,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_TWO_THUMBS = 15,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_01 = 0xF5,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_02 = 0xF6,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_03 = 0xF7,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_04 = 0xF8,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_05 = 0xF9,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_06 = 0xFA,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_07 = 0xFB,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_08 = 0xFC,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_09 = 0xFD,

		/// <summary></summary>
		WINBIO_FINGER_UNSPECIFIED_POS_10 = 0xFE,
	}

	/// <summary>The following constants can be used to specify the palm and palm areas scanned by a sensor:</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_381_POS_PALM : byte
	{
		/// <summary></summary>
		WINBIO_ANSI_381_POS_UNKNOWN_PALM = 20,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_FULL_PALM = 21,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_WRITERS_PALM = 22,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_FULL_PALM = 23,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_WRITERS_PALM = 24,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_LOWER_PALM = 25,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_UPPER_PALM = 26,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_LOWER_PALM = 27,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_UPPER_PALM = 28,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_OTHER = 29,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_OTHER = 30,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_INTERDIGITAL = 31,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_THENAR = 32,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_RH_HYPOTHENAR = 33,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_INTERDIGITAL = 34,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_THENAR = 35,

		/// <summary></summary>
		WINBIO_ANSI_381_POS_LH_HYPOTHENAR = 36,
	}

	/// <summary>
	/// The following constants are WINBIO_BIOMETRIC_SUBTYPE values that can be used to specify the two types of frontal face images as
	/// defined by ANSI INCITS 385-2004: "Face Recognition Format for Data Interchange": full resolution and low resolution. In
	/// practice, the biometric framework will use only full resolution images for facial recognition.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANSI_385_FACE : byte
	{
		/// <summary>The frontal face image type is unknown.</summary>
		WINBIO_ANSI_385_FACE_TYPE_UNKNOWN = 0,

		/// <summary>The frontal face image type is full resolution.</summary>
		WINBIO_ANSI_385_FACE_FRONTAL_FULL = 1,

		/// <summary>The frontal face image type is low resolution.</summary>
		WINBIO_ANSI_385_FACE_FRONTAL_TOKEN = 2,
	}

	/// <summary>Specifies the types of actions you take for the antispoofing policy of a user.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-anti-spoof-policy-action typedef enum
	// _WINBIO_ANTI_SPOOF_POLICY_ACTION { WINBIO_ANTI_SPOOF_DISABLE = 0x00000000, WINBIO_ANTI_SPOOF_ENABLE = 0x00000001,
	// WINBIO_ANTI_SPOOF_REMOVE = 0x00000002 } WINBIO_ANTI_SPOOF_POLICY_ACTION, *PWINBIO_ANTI_SPOOF_POLICY;
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ANTI_SPOOF_POLICY_ACTION
	{
		/// <summary>Turns off the detection of spoofing for a biometric factor.</summary>
		WINBIO_ANTI_SPOOF_DISABLE,

		/// <summary>Turns on the detection of spoofing for a biometric factor.</summary>
		WINBIO_ANTI_SPOOF_ENABLE,

		/// <summary>Removes the entire antispoofing policy for the biometric factor from the account.</summary>
		WINBIO_ANTI_SPOOF_REMOVE,
	}

	/// <summary>
	/// The following constants can be used as a bitmask for the Capabilities parameter of the WINBIO_UNIT_SCHEMA structure. These refer
	/// to the onboard sensor capabilities.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_BIOMETRIC_SENSOR_SUBTYPE : uint
	{
		/// <summary>The sensor sub types is not known.</summary>
		WINBIO_SENSOR_SUBTYPE_UNKNOWN = 0x00000000,

		/// <summary>The sensor supports fingerprint swipes.</summary>
		WINBIO_FP_SENSOR_SUBTYPE_SWIPE = 0x00000001,

		/// <summary>The sensor supports finger touches.</summary>
		WINBIO_FP_SENSOR_SUBTYPE_TOUCH = 0x00000002,
	}

	/// <summary>
	/// WINBIO_BIOMETRIC_SUBTYPE constants are used throughout the Windows Biometric Framework to provide additional information about a
	/// biometric measurement. The following constants can be used when no subtype is required or when any subtype is required.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_BIOMETRIC_SUBTYPE : byte
	{
		/// <summary>No subtype information.</summary>
		WINBIO_SUBTYPE_NO_INFORMATION = 0x00,

		/// <summary>Any subtype.</summary>
		WINBIO_SUBTYPE_ANY = 0xFF,
	}

	/// <summary>
	/// The following constants represent the standard biometric types defined by National Institute of Standards and Technology
	/// Information (NISTIR) 6529-A, otherwise known as the Common Biometric Exchange Formats Framework (CBEFF) Patron Format A. Only
	/// WINBIO_TYPE_FINGERPRINT is currently supported.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_BIOMETRIC_TYPE : uint
	{
		/// <summary>No biometric type is available.</summary>
		WINBIO_NO_TYPE_AVAILABLE = 0x00000000,

		/// <summary>Multiple types are specified.</summary>
		WINBIO_TYPE_MULTIPLE = 0x00000001,

		/// <summary>Facial features are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_FACIAL_FEATURES = 0x00000002,

		/// <summary>Frequency and volume patterns in the voice of an individual are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_VOICE = 0x00000004,

		/// <summary>Fingerprint patterns are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_FINGERPRINT = 0x00000008,

		/// <summary>
		/// Iris patterns are used to determine the identity of an individual. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_TYPE_IRIS = 0x00000010,

		/// <summary>Vein patterns in the retina are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_RETINA = 0x00000020,

		/// <summary>The shape of a hand of an individual is used to determine the identity of an individual.</summary>
		WINBIO_TYPE_HAND_GEOMETRY = 0x00000040,

		/// <summary>
		/// The patterns of force that the individual uses when they sign their name are used to determine the identity of an individual.
		/// </summary>
		WINBIO_TYPE_SIGNATURE_DYNAMICS = 0x00000080,

		/// <summary>The speed and error patterns in typing by an individual are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_KEYSTROKE_DYNAMICS = 0x00000100,

		/// <summary>
		/// The changes in the lips of an individual that occur when they speak are used to determine the identity of an individual.
		/// </summary>
		WINBIO_TYPE_LIP_MOVEMENT = 0x00000200,

		/// <summary>The temperature patterns in the face of an individual are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_THERMAL_FACE_IMAGE = 0x00000400,

		/// <summary>The temperature patterns in the hand of an individual are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_THERMAL_HAND_IMAGE = 0x00000800,

		/// <summary>The patterns of movement that occur when the individual walks are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_GAIT = 0x00001000,

		/// <summary>The scent of an individual is used to determine the identity of an individual.</summary>
		WINBIO_TYPE_SCENT = 0x00002000,

		/// <summary>Deoxyribonucleic acid (DNA) sequences are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_DNA = 0x00004000,

		/// <summary>The shape of an ear of the individual is used to determine the identity of an individual.</summary>
		WINBIO_TYPE_EAR_SHAPE = 0x00008000,

		/// <summary>The shapes of the fingers of an individual are used to determine the identity of an individual.</summary>
		WINBIO_TYPE_FINGER_GEOMETRY = 0x00010000,

		/// <summary>The shape of the palm is used to determine the identity of an individual.</summary>
		WINBIO_TYPE_PALM_PRINT = 0x00020000,

		/// <summary>
		/// Patterns in the veins underneath the skin of the hand of an individual are used to determine the identity of an individual.
		/// </summary>
		WINBIO_TYPE_VEIN_PATTERN = 0x00040000,

		/// <summary>The shape of the foot is used to determine the identity of an individual.</summary>
		WINBIO_TYPE_FOOT_PRINT = 0x00080000,

		/// <summary>The supported biometric data is not defined by the current constants.</summary>
		WINBIO_TYPE_OTHER = 0x40000000,

		/// <summary>Password data is used to determine the identity of an individual.</summary>
		WINBIO_TYPE_PASSWORD = 0x80000000,

		/// <summary>Any type of data is used to determine the identity of an individual.</summary>
		WINBIO_TYPE_ANY = WINBIO_STANDARD_TYPE_MASK | WINBIO_TYPE_OTHER | WINBIO_TYPE_PASSWORD,
	}

	/// <summary>The following constants are used by the DataFlags member of the WINBIO_BIR_HEADER structure.</summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_BIR_DATA_FLAGS : byte
	{
		/// <summary>The data is encrypted.</summary>
		WINBIO_DATA_FLAG_PRIVACY = 0x02,

		/// <summary>The data is digitally signed or is protected by a message authentication code (MAC).</summary>
		WINBIO_DATA_FLAG_INTEGRITY = 0x01,

		/// <summary>
		/// If this flag and the WINBIO_DATA_FLAG_INTEGRITY flag are set, the data is signed. If this flag is not set but the
		/// WINBIO_DATA_FLAG_INTEGRITY flag is set, a MAC is computed on the data.
		/// </summary>
		WINBIO_DATA_FLAG_SIGNED = 0x04,

		/// <summary>The data is in the format with which it was captured.</summary>
		WINBIO_DATA_FLAG_RAW = 0x20,

		/// <summary>The data is not raw but has not been completely processed.</summary>
		WINBIO_DATA_FLAG_INTERMEDIATE = 0x40,

		/// <summary>The data has been processed.</summary>
		WINBIO_DATA_FLAG_PROCESSED = 0x80,

		/// <summary>The flag mask. This value is always one (1).</summary>
		WINBIO_DATA_FLAG_OPTION_MASK_PRESENT = 0x08,
	}

	/// <summary>
	/// The following constants are used to create a bitmask for the <c>ValidFields</c> member of the <c>WINBIO_BIR_HEADER</c> structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-bir-field-constants
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_BIR_FIELD : ushort
	{
		/// <summary>
		/// Provided for conformity with NISTIR 6529-A, the Common Biometric Exchange Formats Framework (CBEFF) Patron Format A, but not used.
		/// </summary>
		WINBIO_BIR_FIELD_SUBHEAD_COUNT = 0x0001,

		/// <summary>The ProductId member is valid.</summary>
		WINBIO_BIR_FIELD_PRODUCT_ID = 0x0002,

		/// <summary>Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.</summary>
		WINBIO_BIR_FIELD_PATRON_ID = 0x0004,

		/// <summary>Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.</summary>
		WINBIO_BIR_FIELD_INDEX = 0x0008,

		/// <summary>The CreationDate member is valid.</summary>
		WINBIO_BIR_FIELD_CREATION_DATE = 0x0010,

		/// <summary>The ValidityPeriod member is valid.</summary>
		WINBIO_BIR_FIELD_VALIDITY_PERIOD = 0x0020,

		/// <summary>The Type member is valid.</summary>
		WINBIO_BIR_FIELD_BIOMETRIC_TYPE = 0x0040,

		/// <summary>The Subtype member is valid.</summary>
		WINBIO_BIR_FIELD_BIOMETRIC_SUBTYPE = 0x0080,

		/// <summary>The HeaderVersion member is valid.</summary>
		WINBIO_BIR_FIELD_CBEFF_HEADER_VERSION = 0x0100,

		/// <summary>The PatronHeaderVersion member is valid.</summary>
		WINBIO_BIR_FIELD_PATRON_HEADER_VERSION = 0x0200,

		/// <summary>The Purpose member is valid.</summary>
		WINBIO_BIR_FIELD_BIOMETRIC_PURPOSE = 0x0400,

		/// <summary>Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.</summary>
		WINBIO_BIR_FIELD_BIOMETRIC_CONDITION = 0x0800,

		/// <summary>The DataQuality member is valid.</summary>
		WINBIO_BIR_FIELD_QUALITY = 0x1000,

		/// <summary>Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.</summary>
		WINBIO_BIR_FIELD_CREATOR = 0x2000,

		/// <summary>Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.</summary>
		WINBIO_BIR_FIELD_CHALLENGE = 0x4000,

		/// <summary>Provided for conformity with NISTIR 6529-A, CBEFF Patron Format A, but not used.</summary>
		WINBIO_BIR_FIELD_PAYLOAD = 0x8000,
	}

	/// <summary>
	/// The following flags are used by the Purpose member of the WINBIO_BIR_HEADER structure to specify the purpose for which the
	/// biometric information record (BIR) is intended or for which it is suitable.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_BIR_PURPOSE : byte
	{
		/// <summary>No purpose is specified.</summary>
		WINBIO_NO_PURPOSE_AVAILABLE = 0x00,

		/// <summary>Verify the identity of a user.</summary>
		WINBIO_PURPOSE_VERIFY = 0x01,

		/// <summary>Identify a user.</summary>
		WINBIO_PURPOSE_IDENTIFY = 0x02,

		/// <summary>Enroll a user.</summary>
		WINBIO_PURPOSE_ENROLL = 0x04,

		/// <summary>Capture a biometric sample and determine whether the sample corresponds to the specified user identity.</summary>
		WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION = 0x08,

		/// <summary>Capture a biometric sample and determine whether it matches an existing biometric template.</summary>
		WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION = 0x10,

		/// <summary>
		/// Extra information that can be used for logging or for display. This value is ignored on input by all functions. On output,
		/// it will only be available if supported by the biometric unit and you specify WINBIO_DATA_FLAG_RAW in the Flags parameter of
		/// the WinBioCaptureSample function.
		/// </summary>
		WINBIO_PURPOSE_AUDIT = 0x80,
	}

	/// <summary>
	/// The following flags are used by the DataQuality member of the WINBIO_BIR_HEADER structure to specify the relative quality of
	/// biometric data in the BIR if an integer value from 0 to 100 has not been specified.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_BIR_QUALITY : sbyte
	{
		/// <summary>Quality measurements are supported by the BIR creator, but no value is set in the BIR.</summary>
		WINBIO_DATA_QUALITY_NOT_SET = -1,

		/// <summary>Quality measurements are not supported by the BIR creator.</summary>
		WINBIO_DATA_QUALITY_NOT_SUPPORTED = -2,
	}

	/// <summary>
	/// The following flags are used by the HeaderVersion and PatronHeaderVersion members of the WINBIO_BIR_HEADER structure to specify
	/// the version.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_BIR_VERSION : byte
	{
		/// <summary></summary>
		WINBIO_CBEFF_HEADER_VERSION = 0x11,

		/// <summary></summary>
		WINBIO_PATRON_HEADER_VERSION = 0x11,
	}

	/// <summary>
	/// The following fingerprint sensor sub types are WINBIO_CAPABILITIES values that can be used as a bitmask for the Capabilities
	/// parameter of the WINBIO_UNIT_SCHEMA structure. These refer to the onboard sensor capabilities.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_CAPABILITIES : uint
	{
		/// <summary>The sensor can capture biometric data.</summary>
		WINBIO_CAPABILITY_SENSOR = 0x00000001,

		/// <summary>The sensor can match biometric data to an identity.</summary>
		WINBIO_CAPABILITY_MATCHING = 0x00000002,

		/// <summary>The sensor contains an onboard database.</summary>
		WINBIO_CAPABILITY_DATABASE = 0x00000004,

		/// <summary>The sensor can perform biometric processing.</summary>
		WINBIO_CAPABILITY_PROCESSING = 0x00000008,

		/// <summary>The sensor can encrypt biometric data.</summary>
		WINBIO_CAPABILITY_ENCRYPTION = 0x00000010,

		/// <summary>The sensor can act as a mouse pad. This is currently not supported.</summary>
		WINBIO_CAPABILITY_NAVIGATION = 0x00000020,

		/// <summary>The sensor contains an indicator light.</summary>
		WINBIO_CAPABILITY_INDICATOR = 0x00000040,

		/// <summary>The sensor adapter manages its own connection to the biometric hardware.</summary>
		WINBIO_CAPABILITY_VIRTUAL_SENSOR = 0x00000080,
	}

	/// <summary>
	/// The following constants can be used when calling WinBioControlUnit or WinBioControlUnitPrivileged to specify the type of adapter
	/// being used.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_COMPONENT
	{
		/// <summary>Specifies a sensor adapter.</summary>
		WINBIO_COMPONENT_SENSOR = 1,

		/// <summary>Specifies a engine adapter.</summary>
		WINBIO_COMPONENT_ENGINE = 2,

		/// <summary>Specifies a storage adapter.</summary>
		WINBIO_COMPONENT_STORAGE = 3,
	}

	/// <summary>
	/// Defines flags that can be used to specify the end-user credential format. This enumeration is used by the
	/// <c>WinBioSetCredential</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-credential-format typedef enum _WINBIO_CREDENTIAL_FORMAT {
	// WINBIO_PASSWORD_GENERIC = 0x00000001, WINBIO_PASSWORD_PACKED = 0x00000002, WINBIO_PASSWORD_PROTECTED = 0x00000003 } WINBIO_CREDENTIAL_FORMAT;
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_CREDENTIAL_FORMAT
	{
		/// <summary>The password is in a generic format.</summary>
		WINBIO_PASSWORD_GENERIC = 1,

		/// <summary>The password is in a compressed format.</summary>
		WINBIO_PASSWORD_PACKED,

		/// <summary>The password credential was wrapped with <c>CredProtect</c>.</summary>
		WINBIO_PASSWORD_PROTECTED,
	}

	/// <summary>
	/// Defines values that specify whether a credential has been associated with the biometric data for an end user. This enumeration
	/// is used by the <c>WinBioGetCredentialState</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-credential-state typedef enum _WINBIO_CREDENTIAL_STATE {
	// WINBIO_CREDENTIAL_NOT_SET = 0x00000001, WINBIO_CREDENTIAL_SET = 0x00000002 } WINBIO_CREDENTIAL_STATE, *PWINBIO_CREDENTIAL_STATE;
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_CREDENTIAL_STATE : uint
	{
		/// <summary>A credential has been associated with the end user.</summary>
		WINBIO_CREDENTIAL_NOT_SET = 0x00000001,

		/// <summary>A credential has not been associated with the end user.</summary>
		WINBIO_CREDENTIAL_SET = 0x00000002,
	}

	/// <summary>
	/// Defines flags that can be used to filter on the credential type. This enumeration is used by the <c>WinBioSetCredential</c>,
	/// <c>WinBioRemoveCredential</c>, and <c>WinBioGetCredentialState</c> functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-credential-type typedef enum _WINBIO_CREDENTIAL_TYPE {
	// WINBIO_CREDENTIAL_PASSWORD = 0x00000001, WINBIO_CREDENTIAL_ALL = 0xffffffff } WINBIO_CREDENTIAL_TYPE;
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_CREDENTIAL_TYPE : uint
	{
		/// <summary>Filters password credentials.</summary>
		WINBIO_CREDENTIAL_PASSWORD = 0x01,

		/// <summary>Filters all credentials.</summary>
		WINBIO_CREDENTIAL_ALL = 0xffffffff,
	}

	/// <summary>The following flags can be used for the Attributes member of the WINBIO_STORAGE_SCHEMA structure.</summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_DATABASE : uint
	{
		/// <summary>The database is contained in a file.</summary>
		WINBIO_DATABASE_TYPE_FILE = 0x00000001,

		/// <summary>The database is managed by an external database management system (DBMS) component, such as Microsoft SQL Server.</summary>
		WINBIO_DATABASE_TYPE_DBMS = 0x00000002,

		/// <summary>The database resides on the biometric sensor.</summary>
		WINBIO_DATABASE_TYPE_ONCHIP = 0x00000003,

		/// <summary>The database resides on a smart card.</summary>
		WINBIO_DATABASE_TYPE_SMARTCARD = 0x00000004,

		/// <summary>The storage medium containing the database can be physically removed from the computer.</summary>
		WINBIO_DATABASE_FLAG_REMOVABLE = 0x00010000,

		/// <summary>The database resides on a remote computer.</summary>
		WINBIO_DATABASE_FLAG_REMOTE = 0x00020000,
	}

	/// <summary>
	/// The following constants are WINBIO_CAPABILITIES values that can be used to specify generic capabilities of the engine component
	/// that is connected to a specific biometric unit. You specify these capabilities in GenericEngineCapabilities member of the
	/// WINBIO_EXTENDED_ENGINE_INFO structure.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_ENG_CAP : uint
	{
		/// <summary>The biometric engine component can perform iterative improvement.</summary>
		WINBIO_ENG_CAP_ITERATIVE_IMPROVEMENT = 0x00000001,

		/// <summary>The biometric engine component can perform spoof detection.</summary>
		WINBIO_ENG_CAP_SPOOF_DETECTION = 0x00000002,
	}

	/// <summary>
	/// The following constants can be used in the WinBioRegisterEventMonitor function to specify the types of service provider event
	/// notifications to monitor.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_EVENT_TYPE
	{
		/// <summary>
		/// The sensor detected a finger swipe that was not requested by the application or by the window that currently has focus. The
		/// Windows Biometric Framework calls into your callback function to indicate that a finger swipe has occurred but does not try
		/// to identify the fingerprint.
		/// </summary>
		WINBIO_EVENT_FP_UNCLAIMED = 0x00000001,

		/// <summary>
		/// The sensor detected a finger swipe that was not requested by the application or by the window that currently has focus. The
		/// Windows Biometric Framework attempts to identify the fingerprint and passes the result of that process to your callback function.
		/// </summary>
		WINBIO_EVENT_FP_UNCLAIMED_IDENTIFY = 0x00000002,
	}

	/// <summary>
	/// The following constants can be used in the WinBioAsyncMonitorFrameworkChanges function to identify the type of change that
	/// occurred in the framework.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_FRAMEWORK_CHANGE_TYPE : uint
	{
		/// <summary>A biometric unit was attached to or detached from the computer.</summary>
		WINBIO_FRAMEWORK_CHANGE_UNIT = 0x00000001,

		/// <summary></summary>
		WINBIO_FRAMEWORK_CHANGE_UNIT_STATUS = 0x00000002,
	}

	/// <summary>
	/// The following WINBIO_IDENTITY_TYPE constants can be used to specify the format of the identity information contained in the
	/// WINBIO_IDENTITY structure.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_IDENTITY_TYPE
	{
		/// <summary>The template has no associated ID.</summary>
		WINBIO_ID_TYPE_NULL = 0,

		/// <summary>The structure matches all template identities.</summary>
		WINBIO_ID_TYPE_WILDCARD = 1,

		/// <summary>A GUID identifies the template.</summary>
		WINBIO_ID_TYPE_GUID = 2,

		/// <summary>An account SID identifies the template.</summary>
		WINBIO_ID_TYPE_SID = 3,

		/// <summary/>
		WINBIO_ID_TYPE_SECURE_ID = 4,
	}

	/// <summary>
	/// <para>
	/// The following values can be used to set an indicator light. By default, sensors will not have a light on, but applications can
	/// use these values to enable or disable indicator lights. The <c>WINBIO_SENSOR_STATUS</c> value provides more detail about the
	/// status of an indicator light that is on. For more information, see the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>SensorAdapterSetIndicatorStatus</c></term>
	/// </item>
	/// <item>
	/// <term><c>SensorAdapterGetIndicatorStatus</c></term>
	/// </item>
	/// <item>
	/// <term><c>SensorAdapterQueryStatus</c></term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-indicator-status-constants
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_INDICATOR_STATUS
	{
		/// <summary>The sensor indicator light is on.</summary>
		WINBIO_INDICATOR_ON = 1,

		/// <summary>The sensor indicator light is off.</summary>
		WINBIO_INDICATOR_OFF = 2,
	}

	/// <summary>
	/// The following WINBIO_IDENTITY_TYPE constants can be used to specify the format of the identity information contained in the
	/// WINBIO_IDENTITY structure.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_OPERATION_TYPE
	{
		/// <summary>No operation has been identified.</summary>
		WINBIO_OPERATION_NONE = 0,

		/// <summary>A biometric session was opened. For more information see WinBioAsyncOpenSession.</summary>
		WINBIO_OPERATION_OPEN = 1,

		/// <summary>A biometric session was closed. For more information, see WinBioCloseSession.</summary>
		WINBIO_OPERATION_CLOSE = 2,

		/// <summary>A biometric sample was verified against a user identity. For more information, see WinBioVerify.</summary>
		WINBIO_OPERATION_VERIFY = 3,

		/// <summary>A biometric sample was captured and compared to an existing template. For more information, see WinBioIdentify.</summary>
		WINBIO_OPERATION_IDENTIFY = 4,

		/// <summary>The ID number of a biometric unit was retrieved. For more information, see WinBioLocateSensor.</summary>
		WINBIO_OPERATION_LOCATE_SENSOR = 5,

		/// <summary>A biometric enrollment sequence was initiated. For more information, see WinBioEnrollBegin.</summary>
		WINBIO_OPERATION_ENROLL_BEGIN = 6,

		/// <summary>A biometric sample was captured and added to the template. For more information, see WinBioEnrollCapture.</summary>
		WINBIO_OPERATION_ENROLL_CAPTURE = 7,

		/// <summary>A pending biometric template was finalized. For more information, see WinBioEnrollCommit.</summary>
		WINBIO_OPERATION_ENROLL_COMMIT = 8,

		/// <summary>A pending biometric template was discarded. For more information, see WinBioEnrollDiscard.</summary>
		WINBIO_OPERATION_ENROLL_DISCARD = 9,

		/// <summary>The sub-factors for a given template were enumerated. For more information, see WinBioEnumEnrollments.</summary>
		WINBIO_OPERATION_ENUM_ENROLLMENTS = 10,

		/// <summary>A biometric template was deleted from the store. For more information, see WinBioDeleteTemplate.</summary>
		WINBIO_OPERATION_DELETE_TEMPLATE = 11,

		/// <summary>A biometric sample was captured. For more information, see WinBioCaptureSample.</summary>
		WINBIO_OPERATION_CAPTURE_SAMPLE = 12,

		/// <summary>A biometric session, unit, or template property was retrieved. For more information, see WinBioGetProperty.</summary>
		WINBIO_OPERATION_GET_PROPERTY = 13,

		/// <summary>A biometric session, unit, template, or account property was set. For more information, see WinBioSetProperty.</summary>
		WINBIO_OPERATION_SET_PROPERTY = 14,

		/// <summary>Not used.</summary>
		WINBIO_OPERATION_GET_EVENT = 15,

		/// <summary>A biometric unit was locked for exclusive use by a session. For more information, see WinBioLockUnit.</summary>
		WINBIO_OPERATION_LOCK_UNIT = 16,

		/// <summary>The session lock on a biometric unit was released. For more information, see WinBioUnlockUnit.</summary>
		WINBIO_OPERATION_UNLOCK_UNIT = 17,

		/// <summary>Vendor defined operations were performed on a control unit. For more information, see WinBioControlUnit.</summary>
		WINBIO_OPERATION_CONTROL_UNIT = 18,

		/// <summary>Privileged vendor defined operations were performed on a control unit. For more information, see WinBioControlUnitPrivileged.</summary>
		WINBIO_OPERATION_CONTROL_UNIT_PRIVILEGED = 19,

		/// <summary>A handle to the biometric framework was opened.</summary>
		WINBIO_OPERATION_OPEN_FRAMEWORK = 20,

		/// <summary>A handle to the biometric framework was closed. For more information, see WinBioCloseFramework.</summary>
		WINBIO_OPERATION_CLOSE_FRAMEWORK = 21,

		/// <summary>The installed biometric service providers were enumerated. For more information, see WinBioEnumServiceProviders.</summary>
		WINBIO_OPERATION_ENUM_SERVICE_PROVIDERS = 22,

		/// <summary>The attached biometric units were enumerated. For more information, see WinBioAsyncEnumBiometricUnits.</summary>
		WINBIO_OPERATION_ENUM_BIOMETRIC_UNITS = 23,

		/// <summary>The registered databases were enumerated. For more information, see WinBioEnumDatabases.</summary>
		WINBIO_OPERATION_ENUM_DATABASES = 24,

		/// <summary>A biometric unit was created. For more information, see WinBioAsyncMonitorFrameworkChanges.</summary>
		WINBIO_OPERATION_UNIT_ARRIVAL = 25,

		/// <summary>A biometric unit was deleted. For more information, see WinBioAsyncMonitorFrameworkChanges.</summary>
		WINBIO_OPERATION_UNIT_REMOVAL = 26,

		/// <summary>Reserved. This value is supported starting in Windows 10.</summary>
		WINBIO_OPERATION_IDENTIFY_AND_RELEASE_TICKET = 27,

		/// <summary>Reserved. This value is supported starting in Windows 10.</summary>
		WINBIO_OPERATION_VERIFY_AND_RELEASE_TICKET = 28,

		/// <summary>
		/// The facial recognition or iris monitoring mechanism was turned on. For more information, see WinBioMonitorPresence. This
		/// value is supported starting in Windows 10.
		/// </summary>
		WINBIO_OPERATION_MONITOR_PRESENCE = 29,

		/// <summary>
		/// An individual from a group of individuals that are represented by data in the sample buffer was specified as the individual
		/// to enroll. For more information, see WinBioEnrollSelect. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_OPERATION_ENROLL_SELECT = 30,
	}

	/// <summary>The following constants specify the possible camera orientations that the sensor component specifies as mandatory.</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_ORIENTATION
	{
		/// <summary>A mandatory orientation for the camera is not specified.</summary>
		WINBIO_ORIENTATION_UNSPECIFIED = 0,

		/// <summary>The landscape orientation is required for the camera.</summary>
		WINBIO_ORIENTATION_LANDSCAPE = 1,

		/// <summary>The portrait orientation is required for the camera.</summary>
		WINBIO_ORIENTATION_PORTRAIT = 2,

		/// <summary>Any orientation is permitted for the camera.</summary>
		WINBIO_ORIENTATION_ANY = 3,
	}

	/// <summary>Lists the possible sources of policy information for the detection of spoofing for biometric factors.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-policy-source typedef enum _WINBIO_POLICY_SOURCE {
	// WINBIO_POLICY_UNKNOWN = 0x00000000, WINBIO_POLICY_DEFAULT = 0x00000001, WINBIO_POLICY_LOCAL = 0x00000002, WINBIO_POLICY_ADMIN =
	// 0x00000003 } WINBIO_POLICY_SOURCE, *PWINBIO_POLICY_SOURCE;
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_POLICY_SOURCE
	{
		/// <summary>The source of the policy is unknown.</summary>
		WINBIO_POLICY_UNKNOWN,

		/// <summary>The policy is the default policy that the Windows Biometric Framework provides.</summary>
		WINBIO_POLICY_DEFAULT,

		/// <summary>
		/// The policy that the individual user set for their account by using the <c>Settings</c> app. This policy overrides the
		/// default policy.
		/// </summary>
		WINBIO_POLICY_LOCAL,

		/// <summary>A group policy that the IT administrator set for the enterprise. Individual users cannot override this policy.</summary>
		WINBIO_POLICY_ADMIN,
	}

	/// <summary>
	/// The following constants can be used in the WinBioOpenSession function to specify the type of biometric unit pool to be used in
	/// the session.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_POOL_TYPE
	{
		/// <summary>The pool type is unknown.</summary>
		WINBIO_POOL_UNKNOWN = 0,

		/// <summary>Specifies a shared collection of biometric units managed by the service provider.</summary>
		WINBIO_POOL_SYSTEM = 1,

		/// <summary>Specifies a collection of biometric units that are managed by the caller.</summary>
		WINBIO_POOL_PRIVATE = 2,

		/// <summary>Reserved for Microsoft - do not use.</summary>
		WINBIO_POOL_UNASSIGNED = 3,
	}

	/// <summary>Describes the types of changes that can occur when the Windows Biometric Framework monitors the presence of individuals.</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_PRESENCE_CHANGE
	{
		/// <summary>The type of event is unknown. This value is used for the uninitialized structure.</summary>
		WINBIO_PRESENCE_CHANGE_TYPE_UNKNOWN = 0,

		/// <summary>Provides information about all of the faces current in the camera frame.</summary>
		WINBIO_PRESENCE_CHANGE_TYPE_UPDATE_ALL = 1,

		/// <summary>A new face entered the camera frame.</summary>
		WINBIO_PRESENCE_CHANGE_TYPE_ARRIVE = 2,

		/// <summary>A face was matched to an enrolled user.</summary>
		WINBIO_PRESENCE_CHANGE_TYPE_RECOGNIZE = 3,

		/// <summary>A previously detected face has been out of the camera frame for a period of time.</summary>
		WINBIO_PRESENCE_CHANGE_TYPE_DEPART = 4,

		/// <summary>
		/// Provides updates information about the bounding box and reject detail values for a subset of the faces that are currently in
		/// the camera frame.
		/// </summary>
		WINBIO_PRESENCE_CHANGE_TYPE_TRACK = 5,
	}

	/// <summary>
	/// The following constants are WINBIO_PROPERTY_ID values that can be used to specify the property to be queried in the PropertyId
	/// parameter of the WinBioGetProperty function. Some properties can also be set using the same parameter in the WinBioSetProperty
	/// function. The results of the query are returned or specified in the PropertyBuffer parameter of those functions, and the type
	/// and size of the result vary depending on what property is queried.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_PROPERTY_ID
	{
		/// <summary>
		/// This read-only biometric property estimates the maximum number of good biometric samples that are required to complete an
		/// enrollment template. The result of the property query is returned as a ULONG value that contains the hint.
		/// <para>
		/// When this property is queried, the passed SessionHandle and UnitId parameters must be valid, the Identity parameter must be
		/// NULL, and the SubFactor parameter must be WINBIO_SUBTYPE_NO_INFORMATION.
		/// </para>
		/// </summary>
		WINBIO_PROPERTY_SAMPLE_HINT = 1,

		/// <summary>
		/// This read-only biometric property contains extended information about the capabilities and attributes of the sensor
		/// component that is connected to a specific biometric unit. The result of the property query is returned as a
		/// WINBIO_EXTENDED_SENSOR_INFO structure.
		/// <para>
		/// When this property is queried, the passed SessionHandle and UnitId parameters must be valid, the Identity parameter must be
		/// NULL, and the SubFactor parameter must be WINBIO_SUBTYPE_NO_INFORMATION.
		/// </para>
		/// </summary>
		WINBIO_PROPERTY_EXTENDED_SENSOR_INFO = 2,

		/// <summary>
		/// This read-only biometric property contains extended information about the capabilities and attributes of the engine
		/// component that is connected to a specific biometric unit. The result of the property query is returned as a
		/// WINBIO_EXTENDED_ENGINE_INFO structure.
		/// <para>
		/// When this property is queried, the passed SessionHandle and UnitId parameters must be valid, the Identity parameter must be
		/// NULL, and the SubFactor parameter must be WINBIO_SUBTYPE_NO_INFORMATION.
		/// </para>
		/// </summary>
		WINBIO_PROPERTY_EXTENDED_ENGINE_INFO = 3,

		/// <summary>
		/// This read-only biometric property contains extended information about the capabilities and attributes of the storage
		/// component that is connected to a specific biometric unit. The result of the property query is returned as a
		/// WINBIO_EXTENDED_STORAGE_INFO structure.
		/// <para>
		/// When this property is queried, the passed SessionHandle and UnitId parameters must be valid, the Identity parameter must be
		/// NULL, and the SubFactor parameter must be WINBIO_SUBTYPE_NO_INFORMATION.
		/// </para>
		/// </summary>
		WINBIO_PROPERTY_EXTENDED_STORAGE_INFO = 4,

		/// <summary>
		/// This read-only biometric property contains extended information about the status of an in-progress enrollment on a specific
		/// biometric unit. The result of the property query is returned as a WINBIO_EXTENDED_STORAGE_INFO structure. If no enrollment
		/// is in progress on the BU, the TemplateStatus member of the returned structure has a value of WINBIO_E_INVALID_OPERATION.
		/// <para>
		/// When this property is queried, the passed SessionHandle and UnitId parameters must be valid, the Identity parameter must be
		/// NULL, and the SubFactor parameter must be WINBIO_SUBTYPE_NO_INFORMATION.
		/// </para>
		/// </summary>
		WINBIO_PROPERTY_EXTENDED_ENROLLMENT_STATUS = 5,

		/// <summary>
		/// This read-write biometric property contains the values of the antispoofing policy for a specific user account. The property
		/// operation is specified or returned as a WINBIO_ANTI_SPOOF_POLICY structure.
		/// <para>
		/// When this property is queried, the passed SessionHandle parameter must be valid, the UnitId parameter must be zero, the
		/// Identity parameter must be the account security identifier (SID) value to be queried or changed (to use the SID value
		/// associated with SessionHandle, specify NULL), and the SubFactor parameter must be WINBIO_SUBTYPE_NO_INFORMATION.
		/// </para>
		/// <para>
		/// If this property is queried using the wildcard identity, the system default value of this policy is returned. Nonprivileged
		/// users can only modify their own policy setting. If a nonprivileged user attempts to call the WinBioSetProperty function with
		/// an Identity parameter that represents another user account or contains a wildcard identifier value, the property write
		/// attempt will fail.
		/// </para>
		/// </summary>
		WINBIO_PROPERTY_ANTI_SPOOF_POLICY = 1,
	}

	/// <summary>
	/// The following WINBIO_PROPERTY_TYPE constants can be used to specify the source of the property information in the
	/// WinBioGetProperty function.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_PROPERTY_TYPE
	{
		/// <summary></summary>
		WINBIO_PROPERTY_TYPE_SESSION = 1,

		/// <summary></summary>
		WINBIO_PROPERTY_TYPE_UNIT = 2,

		/// <summary></summary>
		WINBIO_PROPERTY_TYPE_TEMPLATE = 3,

		/// <summary></summary>
		WINBIO_PROPERTY_TYPE_ACCOUNT = 4,
	}

	/// <summary>
	/// The following constants can be used to specify the reason a biometric fingerprint capture or identification procedure did not succeed.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_REJECT_DETAIL : uint
	{
		/// <summary>The finger scan began too high on the finger.</summary>
		WINBIO_FP_TOO_HIGH = 1,

		/// <summary>The finger scan began too low on the finger.</summary>
		WINBIO_FP_TOO_LOW = 2,

		/// <summary>The finger was too far left during scanning.</summary>
		WINBIO_FP_TOO_LEFT = 3,

		/// <summary>The finger was too far right during scanning.</summary>
		WINBIO_FP_TOO_RIGHT = 4,

		/// <summary>The finger was swiped too quickly on the sensor.</summary>
		WINBIO_FP_TOO_FAST = 5,

		/// <summary>The finger was swiped too slowly on the sensor.</summary>
		WINBIO_FP_TOO_SLOW = 6,

		/// <summary>The scan quality was too poor.</summary>
		WINBIO_FP_POOR_QUALITY = 7,

		/// <summary>The finger did not pass straight across the sensor.</summary>
		WINBIO_FP_TOO_SKEWED = 8,

		/// <summary>Not enough of the finger was scanned.</summary>
		WINBIO_FP_TOO_SHORT = 9,

		/// <summary>The fingerprint captures could not be combined.</summary>
		WINBIO_FP_MERGE_FAILURE = 10,

		/// <summary>
		/// The conditions caused the camera to capture a poor image. Instruct the user to clean the sensor and scan again. This value
		/// is supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_POOR_QUALITY = 1,

		/// <summary>
		/// The image includes too much ambient light to get a good match. Instruct the user to ensure that they are no facing another
		/// bright light source. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_BRIGHT = 2,

		/// <summary>
		/// The image is too dark to get a good match. Instruct the user to ensure that their iris is not obscured by items such as a
		/// veil, dark glasses, or colored contacts. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_DARK = 3,

		/// <summary>
		/// The recognition component believes that the iris is not live, but is coming from a replayed video feed, a photo, or a 3-D
		/// sculpture. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_SPOOF_DETECTED = 4,

		/// <summary>
		/// The user is not looking directly at the camera. Instruct the user to look directly at the camera and scan again. This value
		/// is supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_SKEWED = 5,

		/// <summary>
		/// The user's eyelids are obscuring the iris. Instruct the user to open their eyes a little more and scan again. This value is
		/// supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_CLOSED = 6,

		/// <summary>
		/// The image includes lens glare. Instruct the user to remove their glasses and scan again. This value is supported starting in
		/// Windows 10.
		/// </summary>
		WINBIO_IRIS_GLARE = 7,

		/// <summary>
		/// The camera lens was dirty. Instruct the user to clean the lens and scan again. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_DIRTY_LENS = 8,

		/// <summary>This iris is out of focus. This value is supported starting in Windows 10.</summary>
		WINBIO_IRIS_POOR_FOCUS = 9,

		/// <summary>
		/// The camera orientation does not match the mandatory orientation that the WINBIO_EXTENDED_SENSOR_INFO structure specifies.
		/// Instruct the user to change the camera orientation and scan again. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_WRONG_ORIENTATION = 10,

		/// <summary>
		/// The iris is facing up. Instruct the user to look down a little bit and scan again. This value is supported starting in
		/// Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_HIGH = 0x00010000,

		/// <summary>
		/// The iris is facing down. Instruct the user to look up a little bit and scan again. This value is supported starting in
		/// Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_LOW = 0x00020000,

		/// <summary>
		/// The iris is too far to the left. Instruct the user to look a little more to the right and scan again. This value is
		/// supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_LEFT = 0x00040000,

		/// <summary>
		/// The iris is too far to the right. Instruct the user to look a little more to the left and scan again. This value is
		/// supported starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_RIGHT = 0x00080000,

		/// <summary>
		/// The iris is too close to the camera. Instruct the user to move a little further away and scan again. This value is supported
		/// starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_NEAR = 0x00100000,

		/// <summary>
		/// The iris is too far from the camera. Instruct the user to move a little closer and scan again. This value is supported
		/// starting in Windows 10.
		/// </summary>
		WINBIO_IRIS_TOO_FAR = 0x00200000,

		/// <summary>
		/// The conditions caused the camera to capture a poor image. Instruct the user to clean the sensor and scan again. This value
		/// is supported starting in Windows 10.
		/// </summary>
		WINBIO_FACE_POOR_QUALITY = 1,

		/// <summary>
		/// The image includes too much ambient light to get a good match. Instruct the user to ensure that they are no facing another
		/// bright light source. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_FACE_TOO_BRIGHT = 2,

		/// <summary>The image is too dark to get a good match. This value is supported starting in Windows 10.</summary>
		WINBIO_FACE_TOO_DARK = 3,

		/// <summary>
		/// The recognition component believes that the face is not live, but is coming from a replayed video feed, a photo, or a 3-D
		/// sculpture. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_FACE_SPOOF_DETECTED = 4,

		/// <summary>Two or more faces are overlapping in camera frame. This value is supported starting in Windows 10.</summary>
		WINBIO_FACE_AMBIGUOUS_TARGET = 5,

		/// <summary>
		/// The user's eyes are occluded. Instruct the user to ensure that their eyes are not obscured by items such as a veil, dark
		/// glasses, or colored contacts. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_FACE_EYES_OCCLUDED = 6,

		/// <summary>
		/// The camera orientation does not match the mandatory orientation that the WINBIO_EXTENDED_SENSOR_INFO structure specifies.
		/// Instruct the user to change the camera orientation and scan again. This value is supported starting in Windows 10.
		/// </summary>
		WINBIO_FACE_WRONG_ORIENTATION = 7,

		/// <summary>
		/// The face is facing up. Instruct the user to look down a little bit and scan again. This value is supported starting in
		/// Windows 10.
		/// </summary>
		WINBIO_FACE_TOO_HIGH = 0x00010000,

		/// <summary>
		/// The face is facing down. Instruct the user to look up a little bit and scan again. This value is supported starting in
		/// Windows 10.
		/// </summary>
		WINBIO_FACE_TOO_LOW = 0x00020000,

		/// <summary>
		/// The face is too far to the left. Instruct the user to move a little more to the right and scan again. This value is
		/// supported starting in Windows 10.
		/// </summary>
		WINBIO_FACE_TOO_LEFT = 0x00040000,

		/// <summary>
		/// The face is too far to the right. Instruct the user to move a little more to the left and scan again. This value is
		/// supported starting in Windows 10.
		/// </summary>
		WINBIO_FACE_TOO_RIGHT = 0x00080000,

		/// <summary>
		/// The face is too close to the camera. Instruct the user to move a little further away and scan again. This value is supported
		/// starting in Windows 10.
		/// </summary>
		WINBIO_FACE_TOO_NEAR = 0x00100000,

		/// <summary>
		/// The face is too far from the camera. Instruct the user to move a little closer and scan again. This value is supported
		/// starting in Windows 10.
		/// </summary>
		WINBIO_FACE_TOO_FAR = 0x00200000,

		/// <summary></summary>
		WINBIO_VOICE_POOR_QUALITY = 1,

		/// <summary></summary>
		WINBIO_VOICE_TOO_SLOW = 2,

		/// <summary></summary>
		WINBIO_VOICE_TOO_FAST = 3,

		/// <summary></summary>
		WINBIO_VOICE_NO_KEYWORD = 4,

		/// <summary></summary>
		WINBIO_VOICE_PROCESSING_ERROR = 5,
	}

	/// <summary>The following values are used in the SensorAdapterSetMode function to set the sensor adapter mode.</summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_SENSOR_MODE : uint
	{
		/// <summary>The operating mode is not known.</summary>
		WINBIO_SENSOR_UNKNOWN_MODE = 0,

		/// <summary>
		/// Operate the sensor in basic mode. The sensor acts only as a capture device. Any onboard processing or storage capabilities
		/// that exist are not used.
		/// </summary>
		WINBIO_SENSOR_BASIC_MODE = 1,

		/// <summary>Operate the sensor in advanced mode. The sensor can capture samples and perform matching and storage functions.</summary>
		WINBIO_SENSOR_ADVANCED_MODE = 2,

		/// <summary>Operate the sensor as a mouse pad. This is not currently supported.</summary>
		WINBIO_SENSOR_NAVIGATION_MODE = 3,

		/// <summary>Operate the sensor in sleep mode.</summary>
		WINBIO_SENSOR_SLEEP_MODE = 4,
	}

	/// <summary>
	/// The WINBIO_SENSOR_STATUS status of the sensor after the capture has occurred. It specifies the operating status of the sensor.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_SENSOR_STATUS
	{
		/// <summary></summary>
		WINBIO_SENSOR_STATUS_UNKNOWN = 0,

		/// <summary>
		/// The sensor just successfully completed a capture operation. This should only be returned immediately after a capture
		/// operation. The sensor will then return to WINBIO_SENSOR_READY or WINBIO_SENSOR_BUSY.
		/// </summary>
		WINBIO_SENSOR_ACCEPT = 1,

		/// <summary>
		/// The sensor rejected the previous capture operation. This should only be returned immediately following a capture operation.
		/// The sensor will then return to WINBIO_SENSOR_READY or WINBIO_SENSOR_BUSY.
		/// </summary>
		WINBIO_SENSOR_REJECT = 2,

		/// <summary>
		/// The sensor is ready to capture data. If there is a pending data capture IOCTL, the sensor is ready to accept data.
		/// </summary>
		WINBIO_SENSOR_READY = 3,

		/// <summary>
		/// The sensor is busy or in a state where it cannot capture data. For example, the device could still be initializing after it
		/// has been turned on.
		/// </summary>
		WINBIO_SENSOR_BUSY = 4,

		/// <summary>The sensor must be calibrated before it is put into data collection mode.</summary>
		WINBIO_SENSOR_NOT_CALIBRATED = 5,

		/// <summary>The sensor device failed.</summary>
		WINBIO_SENSOR_FAILURE = 6,

		/// <summary></summary>
		WINBIO_SENSOR_AVAILABLE = 7,

		/// <summary></summary>
		WINBIO_SENSOR_UNAVAILABLE = 8,
	}

	/// <summary>
	/// The following constants can be used in the WinBioOpenSession function to specify biometric unit configuration and access
	/// characteristics for the new session.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	[Flags]
	public enum WINBIO_SESSION_FLAGS : uint
	{
		/// <summary>Sensor configuration flag. The biometric units operate in the manner specified during installation.</summary>
		WINBIO_FLAG_DEFAULT = 0x00000000,

		/// <summary>Sensor configuration flag. The biometric units operate only as basic capture devices.</summary>
		WINBIO_FLAG_BASIC = ((WINBIO_SENSOR_MODE.WINBIO_SENSOR_BASIC_MODE & 0xFFFF) << 16),

		/// <summary>Sensor configuration flag. The biometric units use internal processing and storage capabilities.</summary>
		WINBIO_FLAG_ADVANCED = ((WINBIO_SENSOR_MODE.WINBIO_SENSOR_ADVANCED_MODE & 0xFFFF) << 16),

		/// <summary>Desired access flag. The client application captures raw biometric data using WinBioCaptureSample.</summary>
		WINBIO_FLAG_RAW = BIO_UNIT.BIO_UNIT_RAW,

		/// <summary>Desired access flag. The client performs vendor-defined control operations on a biometric unit by calling WinBioControlUnitPrivileged.</summary>
		WINBIO_FLAG_MAINTENANCE = BIO_UNIT.BIO_UNIT_MAINTENANCE,
	}

	/// <summary>
	/// The following constants are used by the WinBioGetEnabledSetting function to determine whether the Windows Biometric Framework is
	/// currently enabled. The constants specify where the setting originated.
	/// </summary>
	[PInvokeData("winbio_types.h")]
	public enum WINBIO_SETTING_SOURCE_TYPE
	{
		/// <summary>The setting is not valid.</summary>
		WINBIO_SETTING_SOURCE_INVALID = 0,

		/// <summary>The setting originated from built-in policy.</summary>
		WINBIO_SETTING_SOURCE_DEFAULT = 1,

		/// <summary>The setting originated in the local computer registry.</summary>
		WINBIO_SETTING_SOURCE_POLICY = 2,

		/// <summary>The setting was created by Group Policy</summary>
		WINBIO_SETTING_SOURCE_LOCAL = 3,
	}

	/// <summary>Represents the antispoofing policy for a user.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-anti-spoof-policy typedef struct _WINBIO_ANTI_SPOOF_POLICY {
	// WINBIO_ANTI_SPOOF_POLICY_ACTION Action; WINBIO_POLICY_SOURCE Source; } WINBIO_ANTI_SPOOF_POLICY, *PWINBIO_ANTI_SPOOF_POLICY;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_ANTI_SPOOF_POLICY
	{
		/// <summary>The type of action to take for the antispoofing policy.</summary>
		public WINBIO_ANTI_SPOOF_POLICY_ACTION Action;

		/// <summary>The source for the antispoofing policy.</summary>
		public WINBIO_POLICY_SOURCE Source;
	}

	/// <summary>The <c>WINBIO_BDB_ANSI_381_HEADER</c> structure specifies information about a series of fingerprint or palm samples.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-bdb-ansi-381-header typedef struct _WINBIO_BDB_ANSI_381_HEADER {
	// ULONG64 RecordLength; ULONG FormatIdentifier; ULONG VersionNumber; WINBIO_REGISTERED_FORMAT ProductId; USHORT CaptureDeviceId;
	// USHORT ImageAcquisitionLevel; USHORT HorizontalScanResolution; USHORT VerticalScanResolution; USHORT HorizontalImageResolution;
	// USHORT VerticalImageResolution; UCHAR ElementCount; UCHAR ScaleUnits; UCHAR PixelDepth; UCHAR ImageCompressionAlg; USHORT
	// Reserved; } WINBIO_BDB_ANSI_381_HEADER;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_BDB_ANSI_381_HEADER
	{
		/// <summary>
		/// The size, in bytes, of this structure plus the size of all <c>WINBIO_BDB_ANSI_381_RECORD</c> structures for the fingerprint
		/// or palm samples captured from an end user. Only the low six bytes are valid.
		/// </summary>
		public ulong RecordLength;

		/// <summary>Specifies the format. Currently, this must be 0x46495200.</summary>
		public uint FormatIdentifier;

		/// <summary>Specifies the version number. Currently this must be 0x30313000 which corresponds internally to 0.1.0.0.</summary>
		public uint VersionNumber;

		/// <summary>A <c>WINBIO_REGISTERED_FORMAT</c> structure that contains the registered data format as an owner/type pair.</summary>
		public WINBIO_REGISTERED_FORMAT ProductId;

		/// <summary>Contains the unit ID of the device used to capture the sample.</summary>
		public ushort CaptureDeviceId;

		/// <summary>Specifies the resolution level at which the sample is captured.</summary>
		public ushort ImageAcquisitionLevel;

		/// <summary>Specifies the horizontal resolution of the scan.</summary>
		public ushort HorizontalScanResolution;

		/// <summary>Specifies the vertical resolution of the scan.</summary>
		public ushort VerticalScanResolution;

		/// <summary>Specifies the horizontal resolution of the captured fingerprint or palm image.</summary>
		public ushort HorizontalImageResolution;

		/// <summary>Specifies the vertical resolution of the captured fingerprint or palm image.</summary>
		public ushort VerticalImageResolution;

		/// <summary>Number of finger or palm records in this structure.</summary>
		public byte ElementCount;

		/// <summary>Contains the unit of measure, 1 for inches and 2 for centimeters.</summary>
		public byte ScaleUnits;

		/// <summary>Specifies the number of bits in a pixel. This can be 1 to 16 bits per pixel for color.</summary>
		public byte PixelDepth;

		/// <summary>Specifies the algorithm used to compress the finger or palm image.</summary>
		public byte ImageCompressionAlg;

		/// <summary/>
		public ushort Reserved;
	}

	/// <summary>
	/// The <c>WINBIO_BDB_ANSI_381_RECORD</c> structure contains information about a single fingerprint or palm sample from an end user.
	/// A collection of these structures is included in each <c>WINBIO_BDB_ANSI_381_HEADER</c> structure.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The Position member specifies the area of the hand or palm used to make the biometric sample. The Windows Biometric Framework
	/// (WBF) currently supports only fingerprint capture and uses the following constants to represent position information.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_UNKNOWN</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_TWO_THUMBS</term>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Important</para>
	/// <para>
	/// Do not attempt to validate the value supplied for the Position value. The Windows Biometrics Service will validate the supplied
	/// value before passing it through to your implementation. If the value is <c>WINBIO_SUBTYPE_NO_INFORMATION</c> or
	/// <c>WINBIO_SUBTYPE_ANY</c>, then validate where appropriate.
	/// </para>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-bdb-ansi-381-record typedef struct _WINBIO_BDB_ANSI_381_RECORD {
	// ULONG BlockLength; USHORT HorizontalLineLength; USHORT VerticalLineLength; WINBIO_BIOMETRIC_SUBTYPE Position; UCHAR CountOfViews;
	// UCHAR ViewNumber; UCHAR ImageQuality; UCHAR ImpressionType; UCHAR Reserved; } WINBIO_BDB_ANSI_381_RECORD;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_BDB_ANSI_381_RECORD
	{
		/// <summary>Contains the number of bytes in this structure plus the number of bytes of sample image data.</summary>
		public uint BlockLength;

		/// <summary>Specifies the number of pixels in a horizontal line of the sample.</summary>
		public ushort HorizontalLineLength;

		/// <summary>Specifies the number of pixels in a vertical line of the sample.</summary>
		public ushort VerticalLineLength;

		/// <summary>
		/// A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that specifies the finger or palm used to generate the biometric sample. For more
		/// information, see Remarks.
		/// </summary>
		public WINBIO_BIOMETRIC_SUBTYPE Position;

		/// <summary>This must be set to one (1);</summary>
		public byte CountOfViews;

		/// <summary>This must be set to one (1);</summary>
		public byte ViewNumber;

		/// <summary>Reserved. This must be 254 (0xFE).</summary>
		public byte ImageQuality;

		/// <summary>Reserved.</summary>
		public byte ImpressionType;

		/// <summary>Reserved. Must be set to zero (0).</summary>
		public byte Reserved;
	}

	/// <summary>
	/// The <c>WINBIO_BIR</c> structure represents a biometric information record (BIR). The information record contains header, data,
	/// and signature blocks.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The use of offsets rather than pointers allows for easy serialization of the BIR and for less complicated translation between 32
	/// and 64-bit environments or between user and kernel mode.
	/// </para>
	/// <para>The BIR is compatible with the Common Biometric Exchange Format Framework (CBEFF) defined by NIST 6529-A.</para>
	/// <para>
	/// If this structure contains a StandardDataBlock value, the Type parameter of the header specified by the HeaderBlock parameter
	/// must be set to <c>WINBIO_ANSI_381_FORMAT_TYPE</c>. This is the only standard data format supported by the current version of the
	/// Windows Biometric Framework.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-bir typedef struct _WINBIO_BIR { WINBIO_BIR_DATA HeaderBlock;
	// WINBIO_BIR_DATA StandardDataBlock; WINBIO_BIR_DATA VendorDataBlock; WINBIO_BIR_DATA SignatureBlock; } WINBIO_BIR;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_BIR
	{
		/// <summary>
		/// A <c>WINBIO_BIR_DATA</c> structure that contains the size, in bytes, and offset of the BIR header. The header contains
		/// information that describes the contents of the information record.
		/// </summary>
		public WINBIO_BIR_DATA HeaderBlock;

		/// <summary>
		/// A <c>WINBIO_BIR_DATA</c> structure that contains the size, in bytes, and offset of processed or unprocessed biometric
		/// information created by the Windows Biometric Framework (WBF).
		/// </summary>
		public WINBIO_BIR_DATA StandardDataBlock;

		/// <summary>
		/// A <c>WINBIO_BIR_DATA</c> structure that contains the size, in bytes, and offset of processed or unprocessed biometric
		/// information provided by vendor sensors and software.
		/// </summary>
		public WINBIO_BIR_DATA VendorDataBlock;

		/// <summary>
		/// An optional <c>WINBIO_BIR_DATA</c> structure that contains the size, in bytes, and offset of the digital signature message
		/// authentication code (MAC) that can be used to verify the integrity of the BIR. If present, the signature or MAC must cover
		/// the header and data blocks.
		/// </summary>
		public WINBIO_BIR_DATA SignatureBlock;
	}

	/// <summary>
	/// The <c>WINBIO_BIR_DATA</c> structure specifies the size, in bytes, and the offset of a block of biometric information. This
	/// structure is used by the <c>WINBIO_BIR</c> structure to specify where the various parts of a biometric information record are located.
	/// </summary>
	/// <remarks>
	/// The use of offsets rather than pointers allows for easy serialization of the BIR and for less complicated translation between 32
	/// and 64-bit environments or between user and kernel mode.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-bir-data typedef struct _WINBIO_BIR_DATA { ULONG Size; ULONG
	// Offset; } WINBIO_BIR_DATA;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_BIR_DATA
	{
		/// <summary>Size, in bytes, of the biometric information.</summary>
		public uint Size;

		/// <summary>Offset, in bytes from the beginning of the <c>WINBIO_BIR</c> structure, of the biometric information.</summary>
		public uint Offset;
	}

	/// <summary>The <c>WINBIO_BIR_HEADER</c> structure contains the header of a biometric information record (BIR).</summary>
	/// <remarks>
	/// <para>
	/// The Subtype parameter specifies the sub-factor associated with the biometric data. Currently, the Windows Biometric Framework
	/// (WBF) supports only fingerprint capture and uses the following constants to represent sub-type information:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_UNKNOWN</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_THUMB</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_INDEX_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_MIDDLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_RING_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_LITTLE_FINGER</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_RH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_LH_FOUR_FINGERS</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_POS_TWO_THUMBS</term>
	/// </item>
	/// </list>
	/// <para>
	/// <para>Important</para>
	/// <para>
	/// Do not attempt to validate the value supplied for the Subtype parameter value. The Windows Biometrics Service will validate the
	/// supplied value before passing it through to your implementation. If the value is <c>WINBIO_SUBTYPE_NO_INFORMATION</c> or
	/// <c>WINBIO_SUBTYPE_ANY</c>, then validate where appropriate.
	/// </para>
	/// </para>
	/// <para>If any of the following bits are asserted, the <c>WINBIO_BIR_HEADER</c> structure is not correctly formed.</para>
	/// <para>
	/// <code>#define WINBIO_BIR_FIELD_NEVER_VALID (WINBIO_BIR_FIELD_SUBHEAD_COUNT | \ WINBIO_BIR_FIELD_PATRON_ID | \ WINBIO_BIR_FIELD_INDEX | \ WINBIO_BIR_FIELD_CHALLENGE | \ WINBIO_BIR_FIELD_PAYLOAD )</code>
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-bir-header typedef struct _WINBIO_BIR_HEADER { USHORT
	// ValidFields; WINBIO_BIR_VERSION HeaderVersion; WINBIO_BIR_VERSION PatronHeaderVersion; WINBIO_BIR_DATA_FLAGS DataFlags;
	// WINBIO_BIOMETRIC_TYPE Type; WINBIO_BIOMETRIC_SUBTYPE Subtype; WINBIO_BIR_PURPOSE Purpose; WINBIO_BIR_QUALITY DataQuality;
	// LARGE_INTEGER CreationDate; struct { LARGE_INTEGER BeginDate; LARGE_INTEGER EndDate; } ValidityPeriod; WINBIO_REGISTERED_FORMAT
	// BiometricDataFormat; WINBIO_REGISTERED_FORMAT ProductId; } WINBIO_BIR_HEADER;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_BIR_HEADER
	{
		/// <summary>
		/// Bitmask that specifies which fields in this structure are valid. For more information, see <c>WINBIO_BIR_FIELD Constants</c>.
		/// </summary>
		public WINBIO_BIR_FIELD ValidFields;

		/// <summary>
		/// A <c>WINBIO_BIR_VERSION</c> constant that specifies the header version. Version numbers are 8-bit values where the upper
		/// four bits specify the major number and the low four bits specify the minor version number. Currently this must be
		/// WINBIO_CBEFF_HEADER_VERSION (0x11).
		/// </summary>
		public WINBIO_BIR_VERSION HeaderVersion;

		/// <summary>
		/// A <c>WINBIO_BIR_VERSION</c> constant that specifies the header version. Version numbers are 8-bit values where the upper
		/// four bits specify the major number and the low four bits specify the minor version number. Currently this must be
		/// WINBIO_PATRON_HEADER_VERSION (0x11).
		/// </summary>
		public WINBIO_BIR_VERSION PatronHeaderVersion;

		/// <summary>
		/// <para>
		/// A value that specifies the format of the header data. This can be a bitwise <c>OR</c> of the following security and
		/// processing level flags. For more information, see <c>WINBIO_BIR_DATA_FLAGS Constants</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINBIO_DATA_FLAG_PRIVACY ((UCHAR)0x02)</term>
		/// <term>The data is encrypted.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATA_FLAG_INTEGRITY ((UCHAR)0x01)</term>
		/// <term>The data is digitally signed or protected by a message authentication code (MAC).</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATA_FLAG_SIGNED ((UCHAR)0x04)</term>
		/// <term>
		/// If this flag and the WINBIO_DATA_FLAG_INTEGRITY flag are set, the data is signed. If this flag is not set but the
		/// WINBIO_DATA_FLAG_INTEGRITY flag is set, a MAC is computed over the data.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATA_FLAG_RAW ((UCHAR)0x20)</term>
		/// <term>The data is in the format with which it was captured.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATA_FLAG_INTERMEDIATE ((UCHAR)0x40)</term>
		/// <term>The data is not raw but has not been completely processed.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATA_FLAG_PROCESSED ((UCHAR)0x80)</term>
		/// <term>The data has been processed.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATA_FLAG_OPTION_MASK_PRESENT ((UCHAR)0x08)</term>
		/// <term>This value is always 1.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_BIR_DATA_FLAGS DataFlags;

		/// <summary>
		/// A WINBIO_BIOMETRIC_TYPE value that specifies the type of biometric data referenced in the biometric information record.
		/// Currently only <c>WINBIO_TYPE_FINGERPRINT</c> is supported. For more information, see <c>WINBIO_BIOMETRIC_TYPE Constants</c>.
		/// </summary>
		public WINBIO_BIOMETRIC_TYPE Type;

		/// <summary>
		/// A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that specifies the sub-factor associated with the biometric data. For more
		/// information, see Remarks and <c>WINBIO_BIOMETRIC_SUBTYPE Constants</c>.
		/// </summary>
		public WINBIO_BIOMETRIC_SUBTYPE Subtype;

		/// <summary>
		/// <para>
		/// A <c>WINBIO_BIR_PURPOSE</c> mask that specifies the intended use of the data. This can be a bitwise <c>OR</c> of the
		/// following values. For more information, see <c>WINBIO_BIR_PURPOSE Constants</c>.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WINBIO_PURPOSE_VERIFY</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_PURPOSE_IDENTIFY</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_PURPOSE_ENROLL</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_PURPOSE_ENROLL_FOR_VERIFICATION</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_PURPOSE_ENROLL_FOR_IDENTIFICATION</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_PURPOSE_AUDIT</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_BIR_PURPOSE Purpose;

		/// <summary>
		/// <para>
		/// A value that specifies the relative quality of the biometric data in the biometric information record (BIR). This can be an
		/// integer from 0 to 100 or one of the following values. For more information, see <c>WINBIO_BIR_QUALITY Constants</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINBIO_DATA_QUALITY_NOT_SET ((WINBIO_BIR_QUALITY)-1)</term>
		/// <term>Quality measurements are supported by the BIR creator but no value is set in the BIR.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATA_QUALITY_NOT_SUPPORTED ((WINBIO_BIR_QUALITY)-2)</term>
		/// <term>Quality measurements are not supported by the BIR creator.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_BIR_QUALITY DataQuality;

		/// <summary>The date and time, in Coordinated Universal Time (Greenwich Mean Time), that the BIR was created.</summary>
		public long CreationDate;

		/// <summary>
		/// <para>The period for which the BIR is valid.</para>
		/// <list>
		/// <item>
		/// <term>
		/// <para><c>BeginDate</c></para>
		/// </term>
		/// <term>
		/// <para><c>EndDate</c></para>
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public VALIDITYPERIOD ValidityPeriod;

		/// <summary>The period for which the BIR is valid.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct VALIDITYPERIOD
		{
			/// <summary>The date and time, in Coordinated Universal Time, that the validity period starts.</summary>
			public long BeginDate;

			/// <summary>The date and time, in Coordinated Universal Time, at which the BIR ceases to be valid.</summary>
			public long EndDate;
		}

		/// <summary>
		/// <para>
		/// A <c>WINBIO_REGISTERED_FORMAT</c> structure that specifies the data format of the standard data block in the
		/// <c>WINBIO_BIR</c> structure. The <c>WINBIO_REGISTERED_FORMAT</c> members cannot be zero. You can use the following constants
		/// to simplify error checking.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINBIO_NO_FORMAT_OWNER_AVAILABLE ((USHORT)0)</term>
		/// <term>No IBIA (International Biometric Industry Association) assigned owner value has been specified.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_NO_FORMAT_TYPE_AVAILABLE ((USHORT)0)</term>
		/// <term>No format type has been specified.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_REGISTERED_FORMAT BiometricDataFormat;

		/// <summary>
		/// A <c>WINBIO_REGISTERED_FORMAT</c> structure that specifies the product ID of the component that generated the standard data
		/// block in the BIR. The <c>WINBIO_REGISTERED_FORMAT</c> members can be zero.
		/// </summary>
		public WINBIO_REGISTERED_FORMAT ProductId;
	}

	/// <summary>
	/// The <c>WINBIO_BSP_SCHEMA</c> structure describes the capabilities of a biometric service provider. This structure is used by the
	/// <c>WinBioEnumServiceProviders</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-bsp-schema typedef struct _WINBIO_BSP_SCHEMA {
	// WINBIO_BIOMETRIC_TYPE BiometricFactor; WINBIO_UUID BspId; WINBIO_STRING Description; WINBIO_STRING Vendor; WINBIO_VERSION
	// Version; } WINBIO_BSP_SCHEMA, *PWINBIO_BSP_SCHEMA;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WINBIO_BSP_SCHEMA
	{
		/// <summary>The type of biometric measurement used by this device. Currently this must be <c>WINBIO_TYPE_FINGERPRINT</c>.</summary>
		public WINBIO_BIOMETRIC_TYPE BiometricFactor;

		/// <summary>A value that uniquely identifies this biometric service provider component.</summary>
		public Guid BspId;

		/// <summary>A <c>NULL</c>-terminated Unicode string that contains a description of the biometric service provider.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Description;

		/// <summary>
		/// A <c>NULL</c>-terminated Unicode string that contains the name of the vendor supplying the biometric service provider.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Vendor;

		/// <summary>A <c>WINBIO_VERSION</c> structure the contains the software version of the biometric service provider component.</summary>
		public WINBIO_VERSION Version;
	}

	/// <summary>
	/// The <c>WINBIO_EVENT</c> structure contains status information sent to the callback routine when an event notice is raised.
	/// </summary>
	/// <remarks>
	/// Call the <c>WinBioRegisterEventMonitor</c> function to register a callback routine to receive event notifications from the
	/// Windows Biometric Framework. The callback is a custom function that you must define for your application.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-event typedef struct _WINBIO_EVENT { WINBIO_EVENT_TYPE Type;
	// union { struct { WINBIO_UNIT_ID UnitId; WINBIO_REJECT_DETAIL RejectDetail; } Unclaimed; struct { WINBIO_UNIT_ID UnitId;
	// WINBIO_IDENTITY Identity; WINBIO_BIOMETRIC_SUBTYPE SubFactor; WINBIO_REJECT_DETAIL RejectDetail; } UnclaimedIdentify; struct {
	// HRESULT ErrorCode; } Error; } Parameters; } WINBIO_EVENT, *PWINBIO_EVENT;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_EVENT
	{
		/// <summary>
		/// <para>
		/// A value that specifies the type of service provider event notice raised. The only provider currently supported is the
		/// fingerprint sensor. This sensor supports the following flags.
		/// </para>
		/// <list/>
		/// </summary>
		public WINBIO_EVENT_TYPE Type;

		/// <summary></summary>
		public PARAMETERS Parameters;

		/// <summary></summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct PARAMETERS
		{
			/// <summary>Structure returned for biometric sample capture.</summary>
			[FieldOffset(0)]
			public UNCLAIMED Unclaimed;

			/// <summary>Structure returned for biometric sample capture.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct UNCLAIMED
			{
				/// <summary>The biometric unit that generated the sample.</summary>
				public uint UnitId;

				/// <summary>
				/// A ULONG value that contains additional information regarding failure to capture a biometric sample. If a capture
				/// succeeded, this parameter is set to zero.
				/// </summary>
				public WINBIO_REJECT_DETAIL RejectDetail;
			}

			/// <summary>
			/// Structure returned for biometric capture and identification. Identification determines whether a sample can be
			/// associated with an existing biometric template.
			/// </summary>
			[FieldOffset(0)]
			public UNCLAIMEDIDENTIFY UnclaimedIdentify;

			/// <summary>
			/// Structure returned for biometric capture and identification. Identification determines whether a sample can be
			/// associated with an existing biometric template.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct UNCLAIMEDIDENTIFY
			{
				/// <summary>The biometric unit that generated the sample.</summary>
				public uint UnitId;

				/// <summary>A WINBIO_IDENTITY structure that contains the GUID or SID of the user providing the biometric sample.</summary>
				public WINBIO_IDENTITY Identity;

				/// <summary>
				/// A WINBIO_BIOMETRIC_SUBTYPE value that specifies the sub-factor associated with a biometric sample. The Windows
				/// Biometric Framework (WBF) currently supports only fingerprint capture and uses the following constants to represent
				/// sub-type information.
				/// </summary>
				public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

				/// <summary>
				/// A ULONG value that contains additional information about the failure to capture a biometric sample. If the capture
				/// succeeded, this parameter is set to zero.
				/// </summary>
				public WINBIO_REJECT_DETAIL RejectDetail;
			}

			/// <summary>Structure that identifies the success or failure of the operation being monitored.</summary>
			[FieldOffset(0)]
			public ERROR Error;

			/// <summary>Structure that identifies the success or failure of the operation being monitored.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct ERROR
			{
				/// <summary>
				/// HRESULT value that contains S_OK or an error code that resulted from computations performed by the Windows Biometric Framework.
				/// </summary>
				public HRESULT ErrorCode;
			}
		}
	}

	/// <summary>Contains information about the capabilities and enrollment requirements of the engine adapter for a biometric unit.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-extended-engine-info typedef struct _WINBIO_EXTENDED_ENGINE_INFO
	// { WINBIO_CAPABILITIES GenericEngineCapabilities; WINBIO_BIOMETRIC_TYPE Factor; union { ULONG32 Null; struct { WINBIO_CAPABILITIES
	// Capabilities; struct { ULONG32 Null; } EnrollmentRequirements; } FacialFeatures; struct { WINBIO_CAPABILITIES Capabilities;
	// struct { ULONG GeneralSamples; ULONG Center; ULONG TopEdge; ULONG BottomEdge; ULONG LeftEdge; ULONG RightEdge; }
	// EnrollmentRequirements; } Fingerprint; struct { WINBIO_CAPABILITIES Capabilities; struct { ULONG32 Null; }
	// EnrollmentRequirements; } Iris; struct { WINBIO_CAPABILITIES Capabilities; struct { ULONG32 Null; } EnrollmentRequirements; }
	// Voice; } Specific; } WINBIO_EXTENDED_ENGINE_INFO, *PWINBIO_EXTENDED_ENGINE_INFO;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_EXTENDED_ENGINE_INFO
	{
		/// <summary>The generic capabilities of the engine component that is connected to a specific biometric unit.</summary>
		public WINBIO_CAPABILITIES GenericEngineCapabilities;

		/// <summary>
		/// The type of biometric unit for which this structure contains information about capabilities and enrollment requirements of
		/// the engine adapter. For example, if the value of the <c>Factor</c> member is <c>WINBIO_TYPE_FINGERPRINT</c>, the
		/// <c>WINBIO_EXTENDED_ENGINE_INFO</c> structure applies to a fingerprint reader and contains the relevant information in the
		/// <c>Specifc.Fingerprint</c> structure.
		/// </summary>
		public WINBIO_BIOMETRIC_TYPE Factor;

		/// <summary>
		/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to a
		/// specific biometric factor.
		/// </summary>
		public SPECIFIC Specific;

		/// <summary>
		/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to a
		/// specific biometric factor.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct SPECIFIC
		{
			/// <summary>Reserved. Must be zero.</summary>
			[FieldOffset(0)]
			public uint Null;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// facial features.
			/// </summary>
			[FieldOffset(0)]
			public FACIALFEATURES FacialFeatures;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// facial features.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FACIALFEATURES
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;

				/// <summary>The enrollment requirements</summary>
				public ENROLLMENTREQUIREMENTS EnrollmentRequirements;

				/// <summary></summary>
				[StructLayout(LayoutKind.Sequential)]
				public struct ENROLLMENTREQUIREMENTS
				{
					/// <summary>Reserved. Must be zero.</summary>
					public uint Null;
				}
			}

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// fingerprint patterns.
			/// </summary>
			[FieldOffset(0)]
			public FINGERPRINT Fingerprint;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// fingerprint patterns.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FINGERPRINT
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;

				/// <summary>The number of good samples required to create a new fingerprint template.</summary>
				public ENROLLMENTREQUIREMENTS EnrollmentRequirements;

				/// <summary>The number of good samples required to create a new fingerprint template.</summary>
				[StructLayout(LayoutKind.Sequential)]
				public struct ENROLLMENTREQUIREMENTS
				{
					/// <summary>The total number of good samples required to create a new fingerprint template.</summary>
					public uint GeneralSamples;

					/// <summary>
					/// The number of good samples for the center of the fingerprint required to create a new fingerprint template.
					/// </summary>
					public uint Center;

					/// <summary>
					/// The number of good samples for the top edge of the fingerprint required to create a new fingerprint template.
					/// </summary>
					public uint TopEdge;

					/// <summary>
					/// The number of good samples for the bottom edge of the fingerprint required to create a new fingerprint template.
					/// </summary>
					public uint BottomEdge;

					/// <summary>
					/// The number of good samples for the left edge of the fingerprint required to create a new fingerprint template.
					/// </summary>
					public uint LeftEdge;

					/// <summary>
					/// The number of good samples for the right edge of the fingerprint required to create a new fingerprint template.
					/// </summary>
					public uint RightEdge;
				}
			}

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// iris patterns.
			/// </summary>
			[FieldOffset(0)]
			public IRIS Iris;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// iris patterns.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct IRIS
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;

				/// <summary/>
				public ENROLLMENTREQUIREMENTS EnrollmentRequirements;

				/// <summary/>
				[StructLayout(LayoutKind.Sequential)]
				public struct ENROLLMENTREQUIREMENTS
				{
					/// <summary>Reserved. Must be zero.</summary>
					public uint Null;
				}
			}

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// voice patterns.
			/// </summary>
			[FieldOffset(0)]
			public VOICE Voice;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// voice patterns.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct VOICE
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;

				/// <summary/>
				public ENROLLMENTREQUIREMENTS EnrollmentRequirements;

				/// <summary/>
				[StructLayout(LayoutKind.Sequential)]
				public struct ENROLLMENTREQUIREMENTS
				{
					/// <summary>Reserved. Must be zero.</summary>
					public uint Null;
				}
			}
		}
	}

	/// <summary>Contains additional information about the status of an enrollment that is in progress.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-extended-enrollment-status typedef struct
	// _WINBIO_EXTENDED_ENROLLMENT_STATUS { HRESULT TemplateStatus; WINBIO_REJECT_DETAIL RejectDetail; ULONG PercentComplete;
	// WINBIO_BIOMETRIC_TYPE Factor; WINBIO_BIOMETRIC_SUBTYPE SubFactor; union { ULONG32 Null; struct { RECT BoundingBox; LONG Distance;
	// } FacialFeatures; struct { ULONG GeneralSamples; ULONG Center; ULONG TopEdge; ULONG BottomEdge; ULONG LeftEdge; ULONG RightEdge;
	// } Fingerprint; struct { RECT EyeBoundingBox_1; RECT EyeBoundingBox_2; POINT PupilCenter_1; POINT PupilCenter_2; LONG Distance; }
	// Iris; struct { ULONG32 Reserved; } Voice; } Specific; } WINBIO_EXTENDED_ENROLLMENT_STATUS, *PWINBIO_EXTENDED_ENROLLMENT_STATUS;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_EXTENDED_ENROLLMENT_STATUS
	{
		/// <summary>
		/// <para>The status of sample collection for the enrollment template. The following values are possible for this member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The enrollment is ready to be saved.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_E_INVALID_OPERATION</term>
		/// <term>No enrollment is in progress.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_I_MORE_DATA</term>
		/// <term>More samples are required to complete the template.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_E_BAD_CAPTURE</term>
		/// <term>The most recent sample is not usable.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HRESULT TemplateStatus;

		/// <summary>The reason that the most recent sample is unusable, if the value of the <c>TemplateStatus</c> member is <c>WINBIO_E_BAD_CAPTURE</c>.</summary>
		public WINBIO_REJECT_DETAIL RejectDetail;

		/// <summary>
		/// The best estimate from the engine adapter for the percentage of the template that is complete, as a value from 0 to 100.
		/// </summary>
		public uint PercentComplete;

		/// <summary>
		/// The type of biometric unit for which this structure contains information about capabilities and enrollment requirements of
		/// the engine adapter. For example, if the value of the <c>Factor</c> member is <c>WINBIO_TYPE_FINGERPRINT</c>, the
		/// <c>WINBIO_EXTENDED_ENGINE_INFO</c> structure applies to a fingerprint reader and contains the relevant information in the
		/// <c>Specifc.Fingerprint</c> structure.
		/// </summary>
		public WINBIO_BIOMETRIC_TYPE Factor;

		/// <summary>A <c>WINBIO_BIOMETRIC_SUBTYPE</c> value that provides additional information about the enrollment.</summary>
		public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

		/// <summary>Information about the status of an enrollment that is in progress for a specific biometric factor.</summary>
		public SPECIFIC Specific;

		/// <summary>Information about the status of an enrollment that is in progress for a specific biometric factor.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct SPECIFIC
		{
			/// <summary>Reserved. Must be zero.</summary>
			[FieldOffset(0)]
			public uint Null;

			/// <summary>Information about the status of an enrollment that is in progress for facial features.</summary>
			[FieldOffset(0)]
			public FACIALFEATURES FacialFeatures;

			/// <summary>Information about the status of an enrollment that is in progress for facial features.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FACIALFEATURES
			{
				/// <summary>
				/// The position within the camera frame of the face of the individual to enroll, in pixels. The size of the camera
				/// frame determines the upper limit on the number of pixels for this position. Get the
				/// WINBIO_PROPERTY_EXTENDED_SENSOR_INFO property to determine the size of the camera frame. A client that uses the
				/// presence monitor must perform the scaling operation to map the position to the camera frame.
				/// </summary>
				public RECT BoundingBox;

				/// <summary>
				/// The distance between the actual location of the face and the ideal focal distance for the face. This value ranges
				/// from -100 to 100. 0 indicates the ideal distance, positive values indicate that the actual location of the face is
				/// too far away, and negative values indicate that the actual location is too close.
				/// </summary>
				public int Distance;

				/// <summary/>
				public OPAQUEENGINEDATA OpaqueEngineData;

				/// <summary/>
				[StructLayout(LayoutKind.Sequential, Size = 16 + (4 * 77))]
				public struct OPAQUEENGINEDATA
				{
					/// <summary/>
					public Guid AdapterId;

					/// <summary/>
					public uint Data;
				}
			}

			/// <summary>Information about the status of an enrollment that is in progress for fingerprint patterns.</summary>
			[FieldOffset(0)]
			public FINGERPRINT Fingerprint;

			/// <summary>Information about the status of an enrollment that is in progress for fingerprint patterns.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FINGERPRINT
			{
				/// <summary>The total number of good samples required to create a new fingerprint template.</summary>
				public uint GeneralSamples;

				/// <summary>The number of good samples for the center of the fingerprint required to create a new fingerprint template.</summary>
				public uint Center;

				/// <summary>
				/// The number of good samples for the top edge of the fingerprint required to create a new fingerprint template.
				/// </summary>
				public uint TopEdge;

				/// <summary>
				/// The number of good samples for the bottom edge of the fingerprint required to create a new fingerprint template.
				/// </summary>
				public uint BottomEdge;

				/// <summary>
				/// The number of good samples for the left edge of the fingerprint required to create a new fingerprint template.
				/// </summary>
				public uint LeftEdge;

				/// <summary>
				/// The number of good samples for the right edge of the fingerprint required to create a new fingerprint template.
				/// </summary>
				public uint RightEdge;
			}

			/// <summary>Information about the status of an enrollment that is in progress for iris patterns.</summary>
			[FieldOffset(0)]
			public IRIS Iris;

			/// <summary>Information about the status of an enrollment that is in progress for iris patterns.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct IRIS
			{
				/// <summary>
				/// The position within the camera frame of one of the irises of the individual to enroll, in pixels. If the
				/// iris-recognition system is only monitoring one eye, this position is of the iris of that eye. If the
				/// iris-recognition system is monitoring both eyes, but only one eye is in the camera frame, this position is of the
				/// iris of the eye in the camera frame. If the iris-recognition system is monitoring both eyes, and both eyes are in
				/// the camera frame, this position is probably of the iris of the right eye of the individual.
				/// <para>
				/// The size of the camera frame determines the upper limit on the number of pixels for this position.Get the
				/// WINBIO_PROPERTY_EXTENDED_SENSOR_INFO property to determine the size of the camera frame.A client that uses the
				/// presence monitor must perform the scaling operation to map the position to the camera frame.
				/// </para>
				/// </summary>
				public RECT EyeBoundingBox_1;

				/// <summary>
				/// The position within the camera frame of one of the irises of the individual to enroll, in pixels. If the
				/// iris-recognition system is only monitoring one eye, or if only one eye is in the camera frame, this value is empty.
				/// If the iris-recognition system is monitoring both eyes, and both eyes are in the camera frame, this position is
				/// probably of iris of the left eye of the individual.
				/// <para>
				/// The size of the camera frame determines the upper limit on the number of pixels for this position.Get the
				/// WINBIO_PROPERTY_EXTENDED_SENSOR_INFO property to determine the size of the camera frame.A client that uses the
				/// presence monitor must perform the scaling operation to map the position to the camera frame.
				/// </para>
				/// </summary>
				public RECT EyeBoundingBox_2;

				/// <summary>
				/// The position of the center of one of the pupils of the individual to enroll. If the iris-recognition system is only
				/// monitoring one eye, this position is of the center of the pupil of that eye. If the iris-recognition system is
				/// monitoring both eyes, but only one eye is in the camera frame, this position is of the center of the pupil of the
				/// eye in the camera frame. If the iris-recognition system is monitoring both eyes, and both eyes are in the camera
				/// frame, this position is probably of the center of the pupil of the right eye of the individual.
				/// </summary>
				public POINT PupilCenter_1;

				/// <summary>
				/// The position of the center of one of the pupils of the individual to enroll. If the iris-recognition system is only
				/// monitoring one eye, or if only one eye is in the camera frame, this value is empty. If the iris-recognition system
				/// is monitoring both eyes, and both eyes are in the camera frame, this position is probably of the center of the pupil
				/// of the left eye of the individual.
				/// </summary>
				public POINT PupilCenter_2;

				/// <summary>
				/// The distance between the actual location of the iris and the ideal focal distance for the iris. This value ranges
				/// from -100 to 100. 0 indicates the ideal distance, positive values indicate that the actual location of the iris is
				/// too far away, and negative values indicate that the actual location is too close.
				/// </summary>
				public int Distance;

				/// <summary/>
				public uint GridPointCompletionPercent;

				/// <summary/>
				public ushort GridPointIndex;

				/// <summary/>
				public POINT3D Point3D;

				/// <summary/>
				public BOOL StopCaptureAndShowCriticalFeedback;

				/// <summary/>
				[StructLayout(LayoutKind.Sequential)]
				public struct POINT3D
				{
					/// <summary/>
					public double X;

					/// <summary/>
					public double Y;

					/// <summary/>
					public double Z;
				}
			}

			/// <summary>Information about the status of an enrollment that is in progress for voice patterns.</summary>
			[FieldOffset(0)]
			public VOICE Voice;

			/// <summary>Information about the status of an enrollment that is in progress for voice patterns.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct VOICE
			{
				/// <summary>Reserved. Must be zero.</summary>
				public uint Reserved;
			}
		}
	}

	/// <summary>Contains information about the capabilities and enrollment requirements of the sensor adapter for a biometric unit.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-extended-sensor-info typedef struct _WINBIO_EXTENDED_SENSOR_INFO
	// { WINBIO_CAPABILITIES GenericSensorCapabilities; WINBIO_BIOMETRIC_TYPE Factor; union { ULONG32 Null; struct { RECT FrameSize;
	// POINT FrameOffset; WINBIO_ORIENTATION MandatoryOrientation; } FacialFeatures; struct { ULONG32 Reserved; } Fingerprint; struct {
	// RECT FrameSize; POINT FrameOffset; WINBIO_ORIENTATION MandatoryOrientation; } Iris; struct { ULONG32 Reserved; } Voice; }
	// Specific; } WINBIO_EXTENDED_SENSOR_INFO, *PWINBIO_EXTENDED_SENSOR_INFO;
	[PInvokeData("")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_EXTENDED_SENSOR_INFO
	{
		/// <summary>The generic capabilities of the sensor component that is connected to a specific biometric unit.</summary>
		public WINBIO_CAPABILITIES GenericSensorCapabilities;

		/// <summary>
		/// The type of biometric unit for which this structure contains information about capabilities and enrollment requirements of
		/// the sensor adapter. For example, if the value of the <c>Factor</c> member is <c>WINBIO_TYPE_FINGERPRINT</c>, the
		/// <c>WINBIO_EXTENDED_SENSOR_INFO</c> structure applies to a fingerprint reader and contains the relevant information in the
		/// <c>Specifc.Fingerprint</c> structure.
		/// </summary>
		public WINBIO_BIOMETRIC_TYPE Factor;

		/// <summary>
		/// Information about the capabilities and enrollment requirements of the sensor adapter for a biometric unit related to a
		/// specific biometric factor.
		/// </summary>
		public SPECIFIC Specific;

		/// <summary>
		/// Information about the capabilities and enrollment requirements of the sensor adapter for a biometric unit related to a
		/// specific biometric factor.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct SPECIFIC
		{
			/// <summary>Reserved. Must be zero.</summary>
			[FieldOffset(0)]
			public uint Null;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the sensor adapter for a biometric unit related to
			/// facial features.
			/// </summary>
			[FieldOffset(0)]
			public FACIALFEATURES FacialFeatures;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the sensor adapter for a biometric unit related to
			/// facial features.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FACIALFEATURES
			{
				/// <summary>
				/// The size of the camera frame, indicated as a length and width in pixels by the right and bottom members of the RECT
				/// structure. The point (0, 0) represents the top-left corner of the frame.
				/// </summary>
				public RECT FrameSize;

				/// <summary>
				/// The offset of the camera frame for the face from the video camera, in pixels. A value of (0, 0) indicates that the
				/// camera frame for the face and the video camera completely overlap.
				/// </summary>
				public POINT FrameOffset;

				/// <summary>The preferred orientation for the camera.</summary>
				public WINBIO_ORIENTATION MandatoryOrientation;

				/// <summary/>
				public HARDWAREINFO HardwareInfo;

				/// <summary/>
				[StructLayout(LayoutKind.Sequential, Size = 260 * 2 * 2 + 4)]
				public struct HARDWAREINFO
				{
					private readonly byte first;

					/// <summary/>
					public string ColorSensorId
					{
						get
						{
							unsafe
							{
								fixed (byte* ptr = &first)
								{
									return StringHelper.GetString((IntPtr)(ptr + 0), CharSet.Unicode, 260 * 2);
								}
							}
						}
					}

					/// <summary/>
					public string InfraredSensorId
					{
						get
						{
							unsafe
							{
								fixed (byte* ptr = &first)
								{
									return StringHelper.GetString((IntPtr)(ptr + 260 * 2), CharSet.Unicode, 260 * 2);
								}
							}
						}
					}

					/// <summary/>
					public uint InfraredSensorRotationAngle
					{
						get
						{
							unsafe
							{
								fixed (byte* ptr = &first)
								{
									return *(uint*)(ptr + 260 * 4);
								}
							}
						}
					}
				}
			}

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the sensor adapter for a biometric unit related to
			/// fingerprint patterns.
			/// </summary>
			[FieldOffset(0)]
			public FINGERPRINT Fingerprint;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the sensor adapter for a biometric unit related to
			/// fingerprint patterns.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FINGERPRINT
			{
				/// <summary>Reserved.</summary>
				public uint Reserved;
			}

			/// <summary>Information about the status of an enrollment that is in progress for iris patterns.</summary>
			[FieldOffset(0)]
			public IRIS Iris;

			/// <summary>Information about the status of an enrollment that is in progress for iris patterns.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct IRIS
			{
				/// <summary>
				/// The size of the camera frame, indicated as a length and width in pixels by the right and bottom members of the RECT
				/// structure. The point (0, 0) represents the top-left corner of the frame.
				/// </summary>
				public RECT FrameSize;

				/// <summary>
				/// The offset of the camera frame for the face from the video camera, in pixels. A value of (0, 0) indicates that the
				/// camera frame for the face and the video camera completely overlap.
				/// </summary>
				public POINT FrameOffset;

				/// <summary>The preferred orientation for the camera.</summary>
				public WINBIO_ORIENTATION MandatoryOrientation;
			}

			/// <summary>Information about the status of an enrollment that is in progress for voice patterns.</summary>
			[FieldOffset(0)]
			public VOICE Voice;

			/// <summary>Information about the status of an enrollment that is in progress for voice patterns.</summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct VOICE
			{
				/// <summary>Reserved.</summary>
				public uint Reserved;
			}
		}
	}

	/// <summary>Contains information about the capabilities and enrollment requirements of the storage adapter for a biometric unit.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-extended-storage-info typedef struct
	// _WINBIO_EXTENDED_STORAGE_INFO { WINBIO_CAPABILITIES GenericStorageCapabilities; WINBIO_BIOMETRIC_TYPE Factor; union { ULONG32
	// Null; struct { WINBIO_CAPABILITIES Capabilities; } FacialFeatures; struct { WINBIO_CAPABILITIES Capabilities; } Fingerprint;
	// struct { WINBIO_CAPABILITIES Capabilities; } Iris; struct { WINBIO_CAPABILITIES Capabilities; } Voice; } Specific; }
	// WINBIO_EXTENDED_STORAGE_INFO, *PWINBIO_EXTENDED_STORAGE_INFO;
	[PInvokeData("")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_EXTENDED_STORAGE_INFO
	{
		/// <summary>The generic capabilities of the storage component that is connected to a specific biometric unit.</summary>
		public WINBIO_CAPABILITIES GenericStorageCapabilities;

		/// <summary>
		/// The type of biometric unit for which this structure contains information about capabilities and enrollment requirements of
		/// the storage adapter. For example, if the value of the <c>Factor</c> member is <c>WINBIO_TYPE_FINGERPRINT</c>, the
		/// <c>WINBIO_EXTENDED_STORAGE_INFO</c> structure applies to a fingerprint reader and contains the relevant information in the
		/// <c>Specifc.Fingerprint</c> structure.
		/// </summary>
		public WINBIO_BIOMETRIC_TYPE Factor;

		/// <summary>
		/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to a
		/// specific biometric factor.
		/// </summary>
		public SPECIFIC Specific;

		/// <summary>
		/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to a
		/// specific biometric factor.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct SPECIFIC
		{
			/// <summary>Reserved. Must be zero.</summary>
			[FieldOffset(0)]
			public uint Null;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// facial features.
			/// </summary>
			[FieldOffset(0)]
			public FACIALFEATURES FacialFeatures;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// facial features.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FACIALFEATURES
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;
			}

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// fingerprint patterns.
			/// </summary>
			[FieldOffset(0)]
			public FINGERPRINT Fingerprint;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// fingerprint patterns.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct FINGERPRINT
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;
			}

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// iris patterns.
			/// </summary>
			[FieldOffset(0)]
			public IRIS Iris;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// iris patterns.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct IRIS
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;
			}

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// voice patterns.
			/// </summary>
			[FieldOffset(0)]
			public VOICE Voice;

			/// <summary>
			/// Information about the capabilities and enrollment requirements of the engine adapter for a biometric unit related to
			/// voice patterns.
			/// </summary>
			[StructLayout(LayoutKind.Sequential)]
			public struct VOICE
			{
				/// <summary>Reserved. Must be zero.</summary>
				public WINBIO_CAPABILITIES Capabilities;
			}
		}
	}

	/// <summary></summary>
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_EXTENDED_UNIT_STATUS
	{
		/// <summary></summary>
		public WINBIO_SENSOR_STATUS Availability;

		/// <summary></summary>
		public uint ReasonCode;
	}

	/// <summary>The <c>WINBIO_IDENTITY</c> structure contains an identifying value associated with a biometric template.</summary>
	/// <remarks>
	/// <para>This structure is used in the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term><c>WinBioDeleteTemplate</c></term>
	/// </item>
	/// <item>
	/// <term><c>WinBioEnrollCommit</c></term>
	/// </item>
	/// <item>
	/// <term><c>WinBioEnumEnrollments</c></term>
	/// </item>
	/// <item>
	/// <term><c>WinBioGetCredentialState</c></term>
	/// </item>
	/// <item>
	/// <term><c>WinBioIdentify</c></term>
	/// </item>
	/// <item>
	/// <term><c>WinBioRemoveCredential</c></term>
	/// </item>
	/// <item>
	/// <term><c>WinBioVerify</c></term>
	/// </item>
	/// <item>
	/// <term><c>WinBioVerifyWithCallback</c></term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-identity typedef struct _WINBIO_IDENTITY { WINBIO_IDENTITY_TYPE
	// Type; union { ULONG Null; ULONG Wildcard; GUID TemplateGuid; struct { ULONG Size; UCHAR Data[SECURITY_MAX_SID_SIZE]; }
	// AccountSid; } Value; } WINBIO_IDENTITY;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_IDENTITY
	{
		/// <summary>
		/// <para>Specifies the format of the identity information contained in this structure. This can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINBIO_ID_TYPE_NULL</term>
		/// <term>The template has no associated ID.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_ID_TYPE_WILDCARD</term>
		/// <term>The structure matches all template identities.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_ID_TYPE_GUID</term>
		/// <term>The structure contains a GUID associated with the template.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_ID_TYPE_SID</term>
		/// <term>The structure contains the account SID associated with the template.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_IDENTITY_TYPE Type;

		/// <summary>A union that can contain one of the following values:</summary>
		public VALUE Value;

		/// <summary>A union that can contain one of the following values:</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct VALUE
		{
			private const int SECURITY_MAX_SID_SIZE = 68;
			private const int WINBIO_IDENTITY_SECURE_ID_SIZE = 32;

			/// <summary>Contains 1 if the Type member is WINBIO_ID_TYPE_NULL.</summary>
			[FieldOffset(0)]
			public uint Null;

			/// <summary>Contains 1 if the Type member is WINBIO_ID_TYPE_WILDCARD.</summary>
			[FieldOffset(0)]
			public uint Wildcard;

			/// <summary>Contains a 128-bit GUID value that identifies the template if the Type member is WINBIO_ID_TYPE_GUID.</summary>
			[FieldOffset(0)]
			public Guid TemplateGuid;

			/// <summary>A structure that contains an account SID if the Type member is WINBIO_ID_TYPE_SID.</summary>
			[FieldOffset(0)]
			public ACCOUNTSID AccountSid;

			/// <summary/>
			public byte[] SecureId
			{
				get
				{
					unsafe
					{
						fixed (void* d = &Null)
						{
							var ret = new byte[WINBIO_IDENTITY_SECURE_ID_SIZE];
							Marshal.Copy((IntPtr)d, ret, 0, WINBIO_IDENTITY_SECURE_ID_SIZE);
							return ret;
						}
					}
				}
			}

			/// <summary>A structure that contains an account SID if the Type member is WINBIO_ID_TYPE_SID.</summary>
			[StructLayout(LayoutKind.Sequential, Size = 4 + SECURITY_MAX_SID_SIZE)]
			public struct ACCOUNTSID
			{
				/// <summary>The number of characters in the SID.</summary>
				public uint Size;

				private readonly byte _Data;

				/// <summary>An array of unsigned characters that contain the SID. The current maximum size of the array is 68 characters.</summary>
				public byte[] Data
				{
					get
					{
						unsafe
						{
							fixed (void* d = &_Data)
							{
								var ret = new byte[SECURITY_MAX_SID_SIZE];
								Marshal.Copy((IntPtr)d, ret, 0, SECURITY_MAX_SID_SIZE);
								return ret;
							}
						}
					}
				}
			}
		}
	}

	/// <summary>Contains information about the presence of an individual whose presence is being monitored.</summary>
	/// <remarks>
	/// <para>
	/// The <c>EngineAdapterIdentifyAll</c> function creates an array of <c>WINBIO_PRESENCE</c> structures and sends this array to the
	/// biometric service. The biometric service uses the array to update its internal model of humans near the computer.
	/// </para>
	/// <para>
	/// Depending on the results of this update, the biometric service may generate a <c>WINBIO_ASYNC_RESULT</c> structure for the
	/// <c>WinBioMonitorPresence</c> function for any clients with active presence monitors. The <c>WINBIO_ASYNC_RESULT.Operation</c>
	/// member of the structure contains <c>WINBIO_OPERATION_MONITOR_PRESENCE</c>, and the
	/// <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member provides additional information about the state of the individual.
	/// </para>
	/// <para>
	/// When an individual that the engine adapter associates with a particular tracking identifier appears in the input stream for the
	/// first time, the biometric service generates a client-side <c>WINBIO_ASYNC_RESULT</c> structure where the
	/// <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is <c>WINBIO_CHANGE_TYPE_ARRIVAL</c>. This structure is
	/// sent to your application callback function or application message queue before any other <c>WINBIO_ASYNC_RESULT</c> structures
	/// where the <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.PresenceArray</c> includes a <c>WINBIO_PRESENCE</c> structure with
	/// the same value for <c>WINBIO_PRESENCE.TrackingId</c>.
	/// </para>
	/// <para>
	/// The following combinations of values in the array of <c>WINBIO_PRESENCE</c> structures that the
	/// <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.PresenceArray</c> member indicate specific kinds of changes in the state of an individual.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// <para>
	/// When an individual is visible in the camera frame, but the engine is still trying to identify the individual, the members of the
	/// <c>WINBIO_PRESENCE</c> structure have the values in the following table.
	/// </para>
	/// <para>
	/// In this case, the biometric service extends the expiry time for the individual, and does not generate a client-side
	/// <c>WINBIO_ASYNC_RESULT</c> structure for the tracking identifier where the
	/// <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is <c>WINBIO_CHANGE_TYPE_RECOGNIZE</c>.
	/// </para>
	/// <para>
	/// The first time that a <c>WINBIO_ASYNC_RESULT</c> structure includes <c>WINBIO_PRESENCE</c> structure where the <c>Status</c>
	/// member is <c>S_OK</c> and the <c>Identity.Type</c> member is <c>WINBIO_ID_TYPE_NULL</c> after one or more
	/// <c>WINBIO_ASYNC_RESULT</c> structures included a <c>WINBIO_PRESENCE</c> structure with a <c>Status</c> member of
	/// <c>WINBIO_E_BAD_CAPTURE</c>, the presence monitor generates a single <c>WINBIO_ASYNC_RESULT</c> structure for the tracking
	/// identifier where the <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is <c>WINBIO_CHANGE_TYPE_TRACK</c>.
	/// This <c>WINBIO_ASYNC_RESULT</c> structure where the <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is
	/// <c>WINBIO_CHANGE_TYPE_TRACK</c> informs the client that the problem that caused the <c>WINBIO_E_BAD_CAPTURE</c> error has
	/// resolved. For more information about the circumstances where a <c>WINBIO_PRESENCE</c> structure has <c>Status</c> member of
	/// <c>WINBIO_E_BAD_CAPTURE</c>, see the description about how the engine adapter provides feedback to the user to correct
	/// recognition failures later in these Remarks.
	/// </para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>
	/// When an individual is visible in the camera frame, but the engine is still trying to identify the individual and wants to
	/// provide feedback to the user about how to correct a recognition failure, the members of the <c>WINBIO_PRESENCE</c> structure
	/// have the values in the following table.
	/// </para>
	/// <para>
	/// In this case, the biometric service extends the expiry time for for the individual and generates a <c>WINBIO_ASYNC_RESULT</c>
	/// structure for the tracking identifier where the <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is <c>WINBIO_CHANGE_TYPE_TRACK</c>.
	/// </para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>
	/// When an individual is visible in the camera frame, and the engine adapter determines the identity of the individual, the members
	/// of the <c>WINBIO_PRESENCE</c> structure have the values in the following table.
	/// </para>
	/// <para>
	/// In this case, the biometric service associates the tracking identifier with the SID for the individual and generates a
	/// client-side <c>WINBIO_ASYNC_RESULT</c> structure for the tracking identifier where the
	/// <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is <c>WINBIO_CHANGE_TYPE_RECOGNIZE</c>. The biometric
	/// service does not generate additional client-side <c>WINBIO_ASYNC_RESULT</c> structures for the tracking identifier unless the
	/// individual leaves the camera frame.
	/// </para>
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// <para>
	/// When an individual is visible in the camera frame, but the engine adapter determines for certain that the individual is not
	/// enrolled, the members of the <c>WINBIO_PRESENCE</c> structure have the values in the following table.
	/// </para>
	/// <para>
	/// In this case, the biometric service associates the tracking identifier of the individual with an identity of UNKNOWN, and
	/// generates a client-side <c>WINBIO_ASYNC_RESULT</c> structure for the tracking identifier where the
	/// <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is <c>WINBIO_CHANGE_TYPE_RECOGNIZE</c>. The biometric
	/// service does not generate additional client-side <c>WINBIO_ASYNC_RESULT</c> structures for the tracking identifier unless the
	/// individual leaves the camera frame.
	/// </para>
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// When an individual that the engine adapter associates with a particular tracking identifier leaves the camera frame and stops
	/// appearing in the values that the <c>EngineAdapterIdentifyAll</c> function returns, the tracking identifier eventually expires.
	/// When the tracking identifier expires, the biometric service generates a client-side <c>WINBIO_ASYNC_RESULT</c> structure where
	/// the <c>WINBIO_ASYNC_RESULT.Parameters.MonitorPresence.ChangeType</c> member is <c>WINBIO_CHANGE_TYPE_DEPART</c>. The engine
	/// adapter can prevent the biometric service from generating this structure with the <c>WINBIO_CHANGE_TYPE_DEPART</c> value by
	/// including a <c>WINBIO_PRESENCE</c> structure in the array that <c>EngineAdapterIdentifyAll</c> returns, where the
	/// <c>WINBIO_PRESENCE.Status</c> member is <c>S_OK</c> and the <c>WINBIO_PRESENCE.Identity.Type</c> member is
	/// <c>WINBIO_ID_TYPE_NULL</c> as described earlier in these Remarks. This action extends the expiry time for the tracking
	/// identifier without causing any client-side activity.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-presence typedef struct _WINBIO_PRESENCE { WINBIO_BIOMETRIC_TYPE
	// Factor; WINBIO_BIOMETRIC_SUBTYPE SubFactor; HRESULT Status; WINBIO_REJECT_DETAIL RejectDetail; WINBIO_IDENTITY Identity;
	// ULONGLONG TrackingId; ulong Ticket; WINBIO_PRESENCE_PROPERTIES Properties; } WINBIO_PRESENCE, *PWINBIO_PRESENCE;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct WINBIO_PRESENCE
	{
		/// <summary>The biometric factor used to monitor the presence of the individual.</summary>
		public WINBIO_BIOMETRIC_TYPE Factor;

		/// <summary>The biometric subfactor qualifier for the biometric factor used to monitor the presence of the individual.</summary>
		public WINBIO_BIOMETRIC_SUBTYPE SubFactor;

		/// <summary>The status of the identification procedure for the individual.</summary>
		public HRESULT Status;

		/// <summary>
		/// Additional information about the failure to recognize an individual, including feedback that explains how to correct the failure.
		/// </summary>
		public WINBIO_REJECT_DETAIL RejectDetail;

		/// <summary>The identity of the individual whose presence is being monitored, once that individual has been identified.</summary>
		public WINBIO_IDENTITY Identity;

		private readonly uint pad1;

		/// <summary>
		/// An integer that is generated by the adapter and uniquely identifies the individual. The tracking identifier that the adapter
		/// assigns to a particular individual is guaranteed to be constant as long as that person remains in the camera frame.
		/// </summary>
		public ulong TrackingId;

		/// <summary>Reserved. Set to 0 by the adapter.</summary>
		public ulong Ticket;

		/// <summary>Factor-specific information about the position of an individual.</summary>
		public WINBIO_PRESENCE_PROPERTIES Properties;

		/// <summary/>
		public AUTHORIZATION Authorization;

		private readonly uint pad2;

		/// <summary/>
		[StructLayout(LayoutKind.Sequential, Size = 4 + DATASIZE)]
		public struct AUTHORIZATION
		{
			private const int DATASIZE = 32;

			/// <summary/>
			public uint Size;

			private readonly byte _Data;

			/// <summary/>
			public byte[] Data
			{
				get
				{
					unsafe
					{
						fixed (void* d = &_Data)
						{
							var ret = new byte[DATASIZE];
							Marshal.Copy((IntPtr)d, ret, 0, DATASIZE);
							return ret;
						}
					}
				}
			}
		}

	}

	/// <summary>Contains biometric values that the Windows Biometric Framework used to determine that an individual was present.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-presence-properties typedef union _WINBIO_PRESENCE_PROPERTIES {
	// struct { RECT BoundingBox; LONG Distance; } FacialFeatures; struct { RECT EyeBoundingBox_1; RECT EyeBoundingBox_2; POINT
	// PupilCenter_1; POINT PupilCenter_2; LONG Distance; } Iris; } WINBIO_PRESENCE_PROPERTIES, *PWINBIO_PRESENCE_PROPERTIES;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Explicit)]
	public struct WINBIO_PRESENCE_PROPERTIES
	{
		/// <summary>
		/// Values for the location of facial features that the Windows Biometric Framework used to determine that an individual was present.
		/// </summary>
		[FieldOffset(0)]
		public FACIALFEATURES FacialFeatures;

		/// <summary>Values for iris location that the Windows Biometric Framework used to determine that an individual was present.</summary>
		[FieldOffset(0)]
		public IRIS Iris;

		/// <summary>
		/// Values for the location of facial features that the Windows Biometric Framework used to determine that an individual was present.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct FACIALFEATURES
		{
			/// <summary>
			/// The position within the camera frame of the face of the individual, in pixels. The size of the camera frame determines
			/// the upper limit on the number of pixels for this position. Get the WINBIO_PROPERTY_EXTENDED_SENSOR_INFO property to
			/// determine the size of the camera frame. A client that uses the presence monitor must perform the scaling operation to
			/// map the position to the camera frame .
			/// </summary>
			public RECT BoundingBox;

			/// <summary>
			/// The distance between the actual location of the face and the ideal focal distance for the face. This value ranges from
			/// -100 to 100. 0 indicates the ideal distance, positive values indicate that the actual location of the face is too far
			/// away, and negative values indicate that the actual location is too close.
			/// </summary>
			public int Distance;

			/// <summary/>
			public OPAQUEENGINEDATA OpaqueEngineData;

			/// <summary/>
			[StructLayout(LayoutKind.Sequential, Size = 16 + (WINBIO_OPAQUE_ENGINE_DATA_ITEM_COUNT * 4))]
			public struct OPAQUEENGINEDATA
			{
				private const int WINBIO_OPAQUE_ENGINE_DATA_ITEM_COUNT = 77;

				/// <summary/>
				public Guid AdapterId;

				/// <summary/>
				private readonly uint _Data;

				/// <summary/>
				public uint[] Data
				{
					get
					{
						unsafe
						{
							fixed (void* d = &_Data)
							{
								var ret = new SafeCoTaskMemHandle(WINBIO_OPAQUE_ENGINE_DATA_ITEM_COUNT * 4);
								InteropExtensions.CopyTo((IntPtr)d, ret, ret.Size);
								return ret.ToArray<uint>(WINBIO_OPAQUE_ENGINE_DATA_ITEM_COUNT);
							}
						}
					}
				}
			}
		}

		/// <summary>Values for iris location that the Windows Biometric Framework used to determine that an individual was present.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct IRIS
		{
			/// <summary>
			/// The position within the camera frame of one of the irises of the individual to enroll, in pixels. If the
			/// iris-recognition system is only monitoring one eye, this position is of the iris of that eye. If the iris-recognition
			/// system is monitoring both eyes, but only one eye is in the camera frame, this position is of the iris of the eye in the
			/// camera frame. If the iris-recognition system is monitoring both eyes, and both eyes are in the camera frame, this
			/// position is probably of the iris of the right eye of the individual.
			/// <para>
			/// The size of the camera frame determines the upper limit on the number of pixels for this position.Get the
			/// WINBIO_PROPERTY_EXTENDED_SENSOR_INFO property to determine the size of the camera frame.A client that uses the presence
			/// monitor must perform the scaling operation to map the position to the camera frame.
			/// </para>
			/// </summary>
			public RECT EyeBoundingBox_1;

			/// <summary>
			/// The position within the camera frame of one of the irises of the individual to enroll, in pixels. If the
			/// iris-recognition system is only monitoring one eye, or if only one eye is in the camera frame, this value is empty. If
			/// the iris-recognition system is monitoring both eyes, and both eyes are in the camera frame, this position is probably of
			/// iris of the left eye of the individual.
			/// <para>
			/// The size of the camera frame determines the upper limit on the number of pixels for this position.Get the
			/// WINBIO_PROPERTY_EXTENDED_SENSOR_INFO property to determine the size of the camera frame.A client that uses the presence
			/// monitor must perform the scaling operation to map the position to the camera frame.
			/// </para>
			/// </summary>
			public RECT EyeBoundingBox_2;

			/// <summary>
			/// The position of the center of one of the pupils of the individual to enroll. If the iris-recognition system is only
			/// monitoring one eye, this position is of the center of the pupil of that eye. If the iris-recognition system is
			/// monitoring both eyes, but only one eye is in the camera frame, this position is of the center of the pupil of the eye in
			/// the camera frame. If the iris-recognition system is monitoring both eyes, and both eyes are in the camera frame, this
			/// position is probably of the center of the pupil of the right eye of the individual.
			/// </summary>
			public POINT PupilCenter_1;

			/// <summary>
			/// The position of the center of one of the pupils of the individual to enroll. If the iris-recognition system is only
			/// monitoring one eye, or if only one eye is in the camera frame, this value is empty. If the iris-recognition system is
			/// monitoring both eyes, and both eyes are in the camera frame, this position is probably of the center of the pupil of the
			/// left eye of the individual.
			/// </summary>
			public POINT PupilCenter_2;

			/// <summary>
			/// The distance between the actual location of the iris and the ideal focal distance for the iris. This value ranges from
			/// -100 to 100. 0 indicates the ideal distance, positive values indicate that the actual location of the iris is too far
			/// away, and negative values indicate that the actual location is too close.
			/// </summary>
			public int Distance;
		}
	}

	/// <summary/>
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct WINBIO_PROTECTION_POLICY
	{
		/// <summary/>
		public uint Version;

		/// <summary/>
		public WINBIO_IDENTITY Identity;

		/// <summary/>
		public Guid DatabaseId;

		/// <summary/>
		public ulong UserState;

		/// <summary/>
		public SizeT PolicySize;

		private readonly Guid _Policy1;
		private readonly Guid _Policy2;
		private readonly Guid _Policy3;
		private readonly Guid _Policy4;
		private readonly Guid _Policy5;
		private readonly Guid _Policy6;
		private readonly Guid _Policy7;
		private readonly Guid _Policy8;
		private readonly uint pad;

		/// <summary/>
		public byte[] Policy
		{
			get
			{
				unsafe
				{
					fixed (void* d = &_Policy1)
					{
						var ret = new byte[128];
						Marshal.Copy((IntPtr)d, ret, 0, 128);
						return ret;
					}
				}
			}
		}
	}

	/// <summary>The <c>WINBIO_REGISTERED_FORMAT</c> structure specifies a registered data format as an owner/format pair.</summary>
	/// <remarks>
	/// <para>
	/// Because Windows currently supports only fingerprint readers, the following values should be used in the
	/// <c>WINBIO_REGISTERED_FORMAT</c> structure.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>WINBIO_ANSI_381_FORMAT_OWNER</term>
	/// <term>InterNational Committee for Information Technology Standards (INCITS) technical committee M1 (biometrics).</term>
	/// </item>
	/// <item>
	/// <term>WINBIO_ANSI_381_FORMAT_TYPE</term>
	/// <term>ANSI INCITS 381 finger image based data interchange format.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-registered-format typedef struct _WINBIO_REGISTERED_FORMAT {
	// USHORT Owner; USHORT Type; } WINBIO_REGISTERED_FORMAT, *PWINBIO_REGISTERED_FORMAT;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_REGISTERED_FORMAT
	{
		/// <summary>An IBIA (International Biometric Industry Association) assigned owner value.</summary>
		public ushort Owner;

		/// <summary>An owner assigned format.</summary>
		public ushort Type;
	}

	/// <summary>
	/// The <c>WINBIO_STORAGE_SCHEMA</c> structure describes the capabilities of a biometric storage adapter. This structure is used by
	/// the <c>WinBioEnumDatabases</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-storage-schema typedef struct _WINBIO_STORAGE_SCHEMA {
	// WINBIO_BIOMETRIC_TYPE BiometricFactor; WINBIO_UUID DatabaseId; WINBIO_UUID DataFormat; ULONG Attributes; WINBIO_STRING FilePath;
	// WINBIO_STRING ConnectionString; } WINBIO_STORAGE_SCHEMA, *PWINBIO_STORAGE_SCHEMA;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WINBIO_STORAGE_SCHEMA
	{
		/// <summary>The type of biometric measurement saved in the database.</summary>
		public WINBIO_BIOMETRIC_TYPE BiometricFactor;

		/// <summary>A GUID that identifies the database.</summary>
		public Guid DatabaseId;

		/// <summary>A GUID that identifies the format of the templates in the database.</summary>
		public Guid DataFormat;

		/// <summary>
		/// <para>Information about the characteristics of the database. This can be a bitwise <c>OR</c> of the following constants.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINBIO_DATABASE_FLAG_MASK 0xFFFF0000</term>
		/// <term>Represents a mask for the flag bits.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATABASE_FLAG_REMOTE 0x00020000</term>
		/// <term>The database resides on a remote computer.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATABASE_FLAG_REMOVABLE 0x00010000</term>
		/// <term>The database resides on a removable drive.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATABASE_TYPE_DBMS 0x00000002</term>
		/// <term>The database is managed by a database management system.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATABASE_TYPE_FILE 0x00000001</term>
		/// <term>The database is contained in a file.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATABASE_TYPE_MASK 0x0000FFFF</term>
		/// <term>Represents a mask for the type bits.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATABASE_TYPE_ONCHIP 0x00000003</term>
		/// <term>The database resides on the biometric sensor.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_DATABASE_TYPE_SMARTCARD 0x00000004</term>
		/// <term>The database resides on a smart card.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_DATABASE Attributes;

		/// <summary>The path and file name of the database if it resides on the computer disk.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string FilePath;

		/// <summary>A string value that can be sent to a database server to identify the database.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string ConnectionString;
	}

	/// <summary>
	/// The <c>WINBIO_UNIT_SCHEMA</c> structure describes the capabilities of a biometric unit. It is used by the
	/// <c>WinBioEnumBiometricUnits</c> function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-unit-schema typedef struct _WINBIO_UNIT_SCHEMA { WINBIO_UNIT_ID
	// UnitId; WINBIO_POOL_TYPE PoolType; WINBIO_BIOMETRIC_TYPE BiometricFactor; WINBIO_BIOMETRIC_SENSOR_SUBTYPE SensorSubType;
	// WINBIO_CAPABILITIES Capabilities; WINBIO_STRING DeviceInstanceId; WINBIO_STRING Description; WINBIO_STRING Manufacturer;
	// WINBIO_STRING Model; WINBIO_STRING SerialNumber; WINBIO_VERSION FirmwareVersion; } WINBIO_UNIT_SCHEMA, *PWINBIO_UNIT_SCHEMA;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct WINBIO_UNIT_SCHEMA
	{
		/// <summary>A value that identifies the biometric unit.</summary>
		public uint UnitId;

		/// <summary>
		/// <para>A <c>ULONG</c> value that specifies the type of the biometric unit. This can be one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINBIO_POOL_UNKNOWN</term>
		/// <term>The type is unknown.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_POOL_SYSTEM</term>
		/// <term>The session connects to a shared collection of biometric units managed by the service provider.</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_POOL_PRIVATE</term>
		/// <term>The session connects to a collection of biometric units that are managed by the caller.</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_POOL_TYPE PoolType;

		/// <summary>A value that specifies the type of the biometric unit. Only <c>WINBIO_TYPE_FINGERPRINT</c> is currently supported.</summary>
		public WINBIO_BIOMETRIC_TYPE BiometricFactor;

		/// <summary>
		/// <para>
		/// A sensor subtype defined for the biometric type specified by the <c>BiometricFactor</c> member. Only fingerprint types (
		/// <c>WINBIO_TYPE_FINGERPRINT</c>) are currently supported. The following subtypes are currently defined for fingerprints:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WINBIO_SENSOR_SUBTYPE_UNKNOWN</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_FP_SENSOR_SUBTYPE_SWIPE</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_FP_SENSOR_SUBTYPE_TOUCH</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_BIOMETRIC_SENSOR_SUBTYPE SensorSubType;

		/// <summary>
		/// <para>A bitmask of the biometric sensor capabilities. This can be a bitwise <c>OR</c> of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>WINBIO_CAPABILITY_SENSOR</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_CAPABILITY_MATCHING</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_CAPABILITY_DATABASE</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_CAPABILITY_PROCESSING</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_CAPABILITY_ENCRYPTION</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_CAPABILITY_NAVIGATION</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_CAPABILITY_INDICATOR</term>
		/// </item>
		/// <item>
		/// <term>WINBIO_CAPABILITY_VIRTUAL_SENSOR</term>
		/// </item>
		/// </list>
		/// </summary>
		public WINBIO_CAPABILITIES Capabilities;

		/// <summary>
		/// A string value that contains the device ID. The string can contain up to 256 Unicode characters including a terminating
		/// <c>NULL</c> character.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string DeviceInstanceId;

		/// <summary>
		/// A string value that contains a description of the biometric unit. The string can contain up to 256 Unicode characters
		/// including a terminating <c>NULL</c> character.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Description;

		/// <summary>
		/// A string value that contains the name of the manufacturer. The string can contain up to 256 Unicode characters including a
		/// terminating <c>NULL</c> character.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Manufacturer;

		/// <summary>
		/// A string value that contains the model number of the biometric unit. The string can contain up to 256 Unicode characters
		/// including a terminating <c>NULL</c> character.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Model;

		/// <summary>
		/// A <c>NULL</c>-terminated Unicode string that contains the serial number of the biometric unit. The string can contain up to
		/// 256 Unicode characters including a terminating <c>NULL</c> character.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string SerialNumber;

		/// <summary>A <c>WINBIO_VERSION</c> structure that contains the major and minor version numbers for the biometric unit.</summary>
		public WINBIO_VERSION FirmwareVersion;
	}

	/// <summary>The <c>WINBIO_VERSION</c> structure contains the software version number of a biometric service provider component.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/secbiomet/winbio-version typedef struct _WINBIO_VERSION { DWORD MajorVersion;
	// DWORD MinorVersion; } WINBIO_VERSION, *PWINBIO_VERSION;
	[PInvokeData("winbio_types.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WINBIO_VERSION
	{
		/// <summary>A <c>DWORD</c> that contains the major version number.</summary>
		public uint MajorVersion;

		/// <summary>A <c>DWORD</c> that contains the minor version number.</summary>
		public uint MinorVersion;

		/// <inheritdoc/>
		public override string ToString() => $"{MajorVersion}.{MinorVersion}";
	}
}