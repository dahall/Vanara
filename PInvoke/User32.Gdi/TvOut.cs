using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32_Gdi
	{
		/// <summary>Specifies whether to retrieve or set the values that are indicated by the other members of <see cref="VIDEOPARAMETERS"/>.</summary>
		[PInvokeData("Tvout.h")]
		public enum VP_COMMAND : uint
		{
			/// <summary>Gets current video capabilities. If capability is not supported, dwFlags is 0.</summary>
			VP_COMMAND_GET = 0x0001,

			/// <summary>Sets video parameters.</summary>
			VP_COMMAND_SET = 0x0002,
		}

		/// <summary>The copy protection command.</summary>
		[PInvokeData("Tvout.h")]
		public enum VP_CP_CMD : uint
		{
			/// <summary>Activate copy protection.</summary>
			VP_CP_CMD_ACTIVATE = 0x0001,

			/// <summary>Deactivate copy protection.</summary>
			VP_CP_CMD_DEACTIVATE = 0x0002,

			/// <summary>Change copy protection.</summary>
			VP_CP_CMD_CHANGE = 0x0004,
		}

		/// <summary>The copy protection type. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.</summary>
		[PInvokeData("Tvout.h")]
		public enum VP_CP_TYPE : uint
		{
			/// <summary>Only DVD trigger bits available.</summary>
			VP_CP_TYPE_APS_TRIGGER = 0x0001,

			/// <summary>Full Macrovision data is available.</summary>
			VP_CP_TYPE_MACROVISION = 0x0002,
		}

		/// <summary>
		/// Indicates which fields of <see cref="VIDEOPARAMETERS"/> contain valid data. For VP_COMMAND_GET, this should be zero. For
		/// VP_COMMAND_SET, these are the fields to set.
		/// </summary>
		[PInvokeData("Tvout.h")]
		public enum VP_FLAGS : uint
		{
			/// <summary>dwMode (for VP_COMMAND_GET and VP_COMMAND_SET) and dwAvailableModes (for VP_COMMAND_GET).</summary>
			VP_FLAGS_TV_MODE = 0x0001,

			/// <summary>dwTVStandard (for VP_COMMAND_GET and VP_COMMAND_SET) and dwAvailableTVStandard (for VP_COMMAND_GET).</summary>
			VP_FLAGS_TV_STANDARD = 0x0002,

			/// <summary>dwFlickerFilter (for VP_COMMAND_GET and VP_COMMAND_SET).</summary>
			VP_FLAGS_FLICKER = 0x0004,

			/// <summary>dwOverScanX, dwOverScanY (for VP_COMMAND_GET and VP_COMMAND_SET).</summary>
			VP_FLAGS_OVERSCAN = 0x0008,

			/// <summary>dwMaxUnscaledX, dwMaxUnscaledY (for VP_COMMAND_GET).</summary>
			VP_FLAGS_MAX_UNSCALED = 0x0010,

			/// <summary>dwPositionX, dwPositionY (for VP_COMMAND_GET and VP_COMMAND_SET).</summary>
			VP_FLAGS_POSITION = 0x0020,

			/// <summary>dwBrightness (for VP_COMMAND_GET and VP_COMMAND_SET).</summary>
			VP_FLAGS_BRIGHTNESS = 0x0040,

			/// <summary>dwContrast (for VP_COMMAND_GET and VP_COMMAND_SET).</summary>
			VP_FLAGS_CONTRAST = 0x0080,

			/// <summary>
			/// dwCPType (for VP_COMMAND_GET and VP_COMMAND_SET), dwCPCommand (for VP_COMMAND_SET), dwCPStandard (for VP_COMMAND_GET),
			/// dwCPKey (for VP_COMMAND_SET), bCP_APSTriggerBits, bOEMCopyProtection (for VP_COMMAND_GET and VP_COMMAND_SET).
			/// </summary>
			VP_FLAGS_COPYPROTECT = 0x0100,
		}

		/// <summary>The current playback mode. This member is valid for both VP_COMMAND_GET and VP_COMMAND_SET.</summary>
		[PInvokeData("Tvout.h")]
		public enum VP_MODE : uint
		{
			/// <summary>
			/// Describes a set of display settings that are optimal for Windows display, with the flicker filter on and any overscan display off.
			/// </summary>
			VP_MODE_WIN_GRAPHICS = 0x0001,

			/// <summary>
			/// Describes a set of display settings for video playback, with the flicker filter off and the overscan display on.
			/// </summary>
			VP_MODE_TV_PLAYBACK = 0x0002,
		}

		/// <summary>The TV standard. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.</summary>
		[PInvokeData("Tvout.h")]
		public enum VP_TV : uint
		{
			/// <summary>NTSC m</summary>
			VP_TV_STANDARD_NTSC_M = 0x0001,

			/// <summary>NTSC m j</summary>
			VP_TV_STANDARD_NTSC_M_J = 0x0002,

			/// <summary>pal b</summary>
			VP_TV_STANDARD_PAL_B = 0x0004,

			/// <summary>pal d</summary>
			VP_TV_STANDARD_PAL_D = 0x0008,

			/// <summary>pal h</summary>
			VP_TV_STANDARD_PAL_H = 0x0010,

			/// <summary>pal i</summary>
			VP_TV_STANDARD_PAL_I = 0x0020,

			/// <summary>pal m</summary>
			VP_TV_STANDARD_PAL_M = 0x0040,

			/// <summary>pal n</summary>
			VP_TV_STANDARD_PAL_N = 0x0080,

			/// <summary>secam b</summary>
			VP_TV_STANDARD_SECAM_B = 0x0100,

			/// <summary>secam d</summary>
			VP_TV_STANDARD_SECAM_D = 0x0200,

			/// <summary>secam g</summary>
			VP_TV_STANDARD_SECAM_G = 0x0400,

			/// <summary>secam h</summary>
			VP_TV_STANDARD_SECAM_H = 0x0800,

			/// <summary>secam k</summary>
			VP_TV_STANDARD_SECAM_K = 0x1000,

			/// <summary>secam k1</summary>
			VP_TV_STANDARD_SECAM_K1 = 0x2000,

			/// <summary>secam l</summary>
			VP_TV_STANDARD_SECAM_L = 0x4000,

			/// <summary>win vga</summary>
			VP_TV_STANDARD_WIN_VGA = 0x8000,

			/// <summary>NTSC 433</summary>
			VP_TV_STANDARD_NTSC_433 = 0x00010000,

			/// <summary>pal g</summary>
			VP_TV_STANDARD_PAL_G = 0x00020000,

			/// <summary>pal 60</summary>
			VP_TV_STANDARD_PAL_60 = 0x00040000,

			/// <summary>secam l1</summary>
			VP_TV_STANDARD_SECAM_L1 = 0x00080000,
		}

		/// <summary>The <c>VIDEOPARAMETERS</c> structure contains information for a video connection.</summary>
		// https://docs.microsoft.com/en-us/previous-versions//dd145196(v=vs.85) typedef struct _VIDEOPARAMETERS { GUID guid; ULONG dwOffset;
		// ULONG dwCommand; ULONG dwFlags; ULONG dwMode; ULONG dwTVStandard; ULONG dwAvailableModes; ULONG dwAvailableTVStandard; ULONG
		// dwFlickerFilter; ULONG dwOverScanX; ULONG dwOverScanY; ULONG dwMaxUnscaledX; ULONG dwMaxUnscaledY; ULONG dwPositionX; ULONG
		// dwPositionY; ULONG dwBrightness; ULONG dwContrast; ULONG dwCPType; ULONG dwCPCommand; ULONG dwCPStandard; ULONG dwCPKey; ULONG
		// bCP_APSTriggerBits; UCHAR bOEMCopyProtection[256]; } VIDOEPARAMETERS, *PVIDEOPARAMETERS;
		[PInvokeData("Tvout.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct VIDEOPARAMETERS
		{
			/// <summary>
			/// The GUID for this structure. {02C62061-1097-11d1-920F-00A024DF156E}. Display drivers should verify the GUID at the start of
			/// the structure before processing the structure.
			/// </summary>
			public Guid guid;

			/// <summary>Reserved; must be zero.</summary>
			public uint dwOffset;

			/// <summary>Specifies whether to retrieve or set the values that are indicated by the other members of this structure.</summary>
			public VP_COMMAND dwCommand;

			/// <summary>
			/// Indicates which fields contain valid data. For VP_COMMAND_GET, this should be zero. For VP_COMMAND_SET, these are the fields
			/// to set.
			/// </summary>
			public VP_FLAGS dwFlags;

			/// <summary>The current playback mode. This member is valid for both VP_COMMAND_GET and VP_COMMAND_SET.</summary>
			public VP_MODE dwMode;

			/// <summary>The TV standard. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.</summary>
			public VP_TV dwTVStandard;

			/// <summary>
			/// Specifies which modes are available. This is valid only for VP_COMMAND_GET. It can be any combination of the values specified
			/// in dwMode.
			/// </summary>
			public VP_MODE dwAvailableModes;

			/// <summary>
			/// The TV standards that are available. This is valid only for VP_COMMAND_GET. It can be any combination of the values specified
			/// in dwTVStandard.
			/// </summary>
			public VP_TV dwAvailableTVStandard;

			/// <summary>
			/// The flicker reduction provided by the hardware. This is a percentage value in tenths of a percent, from 0 to 1,000, where 0
			/// is no flicker reduction and 1,000 is maximum flicker reduction. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.
			/// </summary>
			public uint dwFlickerFilter;

			/// <summary>
			/// The amount of overscan in the horizontal direction. This is a percentage value in tenths of a percent, from 0 to 1,000. A
			/// value of 0 indicates no overscan, ensuring that the entire display is visible. A value of 1,000 is maximum overscan and
			/// typically causes some of the image to be off the edge of the screen. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.
			/// </summary>
			public uint dwOverScanX;

			/// <summary>
			/// The amount of overscan in the vertical direction. This is a percentage value in tenths of a percent, from 0 to 1,000. A value
			/// of 0 indicates no overscan, ensuring that the entire display is visible. A value of 1,000 is maximum overscan and typically
			/// causes some of the image to be off the edge of the screen. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.
			/// </summary>
			public uint dwOverScanY;

			/// <summary>
			/// The maximum horizontal resolution, in pixels, that is supported when the video is not scaled. This field is valid for both VP_COMMAND_GET.
			/// </summary>
			public uint dwMaxUnscaledX;

			/// <summary>
			/// The maximum vertical resolution, in pixels, that is supported when the video is not scaled. This field is valid for both VP_COMMAND_GET.
			/// </summary>
			public uint dwMaxUnscaledY;

			/// <summary>
			/// The horizontal adjustment to the center of the image. Units are in pixels. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.
			/// </summary>
			public uint dwPositionX;

			/// <summary>
			/// The vertical adjustment to the center of the image. Units are in scan lines. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.
			/// </summary>
			public uint dwPositionY;

			/// <summary>
			/// Adjustment to the DC offset of the video signal to increase brightness on the television. It is a percentage value, 0 to 100,
			/// where 0 means no adjustment and 100 means maximum adjustment. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.
			/// </summary>
			public uint dwBrightness;

			/// <summary>
			/// Adjustment to the gain of the video signal to increase the intensity of whiteness on the television. It is a percentage
			/// value, 0 to 100, where 0 means no adjustment and 100 means maximum adjustment. This field is valid for both VP_COMMAND_GET
			/// and VP_COMMAND_SET.
			/// </summary>
			public uint dwContrast;

			/// <summary>The copy protection type. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.</summary>
			public VP_CP_TYPE dwCPType;

			/// <summary>The copy protection command. This field is only valid for VP_COMMAND_SET.</summary>
			public VP_CP_CMD dwCPCommand;

			/// <summary>Specifies TV standards for which copy protection types are available. This field is valid only for VP_COMMAND_GET.</summary>
			public uint dwCPStandard;

			/// <summary>
			/// The copy protection key returned if dwCPCommand is set to VP_CP_CMD_ACTIVATE. The caller must set this key when the
			/// dwCPCommand field is either VP_CP_CMD_DEACTIVATE or VP_CP_CMD_CHANGE. If the caller sets an incorrect key, the driver must
			/// not change the current copy protection settings. This field is valid only for VP_COMMAND_SET.
			/// </summary>
			public uint dwCPKey;

			/// <summary>The DVD APS trigger bit flag. This is valid only for VP_COMMAND_SET. Currently, only bits 0 and 1 are valid.</summary>
			public uint bCP_APSTriggerBits;

			/// <summary>
			/// The OEM-specific copy protection data. Maximum of 256 characters. This field is valid for both VP_COMMAND_GET and VP_COMMAND_SET.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
			public string bOEMCopyProtection;
		}
	}
}