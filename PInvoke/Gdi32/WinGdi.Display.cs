using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Gdi32
	{
		/// <summary>Undocumented.</summary>
		[PInvokeData("wingdi.h")]
		public enum DISPLAYCONFIG_COLOR_ENCODING : uint
		{
			/// <summary>Undocumented.</summary>
			DISPLAYCONFIG_COLOR_ENCODING_RGB = 0,

			/// <summary>Undocumented.</summary>
			DISPLAYCONFIG_COLOR_ENCODING_YCBCR444 = 1,

			/// <summary>Undocumented.</summary>
			DISPLAYCONFIG_COLOR_ENCODING_YCBCR422 = 2,

			/// <summary>Undocumented.</summary>
			DISPLAYCONFIG_COLOR_ENCODING_YCBCR420 = 3,

			/// <summary>Undocumented.</summary>
			DISPLAYCONFIG_COLOR_ENCODING_INTENSITY = 4,
		}

		/// <summary>
		/// <para>
		/// The DISPLAYCONFIG_DEVICE_INFO_TYPE enumeration specifies the type of display device info to configure or obtain through the
		/// DisplayConfigSetDeviceInfo or DisplayConfigGetDeviceInfo function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-displayconfig_device_info_type typedef enum {
		// DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME, DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME,
		// DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE, DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME,
		// DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE, DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE,
		// DISPLAYCONFIG_DEVICE_INFO_GET_SUPPORT_VIRTUAL_RESOLUTION, DISPLAYCONFIG_DEVICE_INFO_SET_SUPPORT_VIRTUAL_RESOLUTION,
		// DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO, DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_STATE,
		// DISPLAYCONFIG_DEVICE_INFO_GET_SDR_WHITE_LEVEL, DISPLAYCONFIG_DEVICE_INFO_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "40cc67c0-1508-4b67-b297-5a8dabaabb16")]
		public enum DISPLAYCONFIG_DEVICE_INFO_TYPE : uint
		{
			/// <summary>
			/// Specifies the source name of the display device. If the DisplayConfigGetDeviceInfo function is successful,
			/// DisplayConfigGetDeviceInfo returns the source name in the DISPLAYCONFIG_SOURCE_DEVICE_NAME structure.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_SOURCE_DEVICE_NAME), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME = 1,

			/// <summary>
			/// Specifies information about the monitor. If the DisplayConfigGetDeviceInfo function is successful, DisplayConfigGetDeviceInfo
			/// returns info about the monitor in the DISPLAYCONFIG_TARGET_DEVICE_NAME structure.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_TARGET_DEVICE_NAME), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME,

			/// <summary>
			/// Specifies information about the preferred mode of a monitor. If the DisplayConfigGetDeviceInfo function is successful,
			/// DisplayConfigGetDeviceInfo returns info about the preferred mode of a monitor in the DISPLAYCONFIG_TARGET_PREFERRED_MODE structure.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_TARGET_PREFERRED_MODE), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE,

			/// <summary>
			/// Specifies the graphics adapter name. If the DisplayConfigGetDeviceInfo function is successful, DisplayConfigGetDeviceInfo
			/// returns the adapter name in the DISPLAYCONFIG_ADAPTER_NAME structure.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_ADAPTER_NAME), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME,

			/// <summary>
			/// Specifies how to set the monitor. If the DisplayConfigSetDeviceInfo function is successful, DisplayConfigSetDeviceInfo uses
			/// info in the DISPLAYCONFIG_SET_TARGET_PERSISTENCE structure to force the output in a boot-persistent manner.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_SET_TARGET_PERSISTENCE), CorrepsondingAction.Set)]
			DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE,

			/// <summary>
			/// Specifies how to set the base output technology for a given target ID. If the DisplayConfigGetDeviceInfo function is
			/// successful, DisplayConfigGetDeviceInfo returns base output technology info in the DISPLAYCONFIG_TARGET_BASE_TYPE structure.
			/// Supported by WDDM 1.3 and later user-mode display drivers running on Windows 8.1 and later.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_TARGET_BASE_TYPE), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE,

			/// <summary>
			/// Specifies the state of virtual mode support. If the DisplayConfigGetDeviceInfo function is successful,
			/// DisplayConfigGetDeviceInfo returns virtual mode support information in the DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION
			/// structure. Supported starting in Windows 10.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_SUPPORT_VIRTUAL_RESOLUTION,

			/// <summary>
			/// Specifies how to set the state of virtual mode support. If the DisplayConfigGetDeviceInfo function is successful,
			/// DisplayConfigGetDeviceInfo uses info in the DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION structure to change the state of virtual
			/// mode support. Supported starting in Windows 10.
			/// </summary>
			[CorrespondingType(typeof(DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION), CorrepsondingAction.Set)]
			DISPLAYCONFIG_DEVICE_INFO_SET_SUPPORT_VIRTUAL_RESOLUTION,

			/// <summary/>
			[CorrespondingType(typeof(DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_ADVANCED_COLOR_INFO,

			/// <summary/>
			[CorrespondingType(typeof(DISPLAYCONFIG_SET_ADVANCED_COLOR_STATE), CorrepsondingAction.Set)]
			DISPLAYCONFIG_DEVICE_INFO_SET_ADVANCED_COLOR_STATE,

			/// <summary/>
			[CorrespondingType(typeof(DISPLAYCONFIG_SDR_WHITE_LEVEL), CorrepsondingAction.Get)]
			DISPLAYCONFIG_DEVICE_INFO_GET_SDR_WHITE_LEVEL,
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("wingdi.h")]
		[Flags]
		public enum DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO_VALUE
		{
			/// <summary>A type of advanced color is supported</summary>
			advancedColorSupported = 1,

			/// <summary>A type of advanced color is enabled</summary>
			advancedColorEnabled = 2,

			/// <summary>Wide color gamut is enabled</summary>
			wideColorEnforced = 4,

			/// <summary>Advanced color is force disabled due to system/OS policy</summary>
			advancedColorForceDisabled = 8,
		}

		/// <summary>
		/// The DISPLAYCONFIG_MODE_INFO_TYPE enumeration specifies that the information that is contained within the DISPLAYCONFIG_MODE_INFO
		/// structure is either source or target mode.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-__unnamed_enum_4 typedef enum {
		// DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE, DISPLAYCONFIG_MODE_INFO_TYPE_TARGET, DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE,
		// DISPLAYCONFIG_MODE_INFO_TYPE_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "d5ddb1d5-6b74-471f-86f0-fee72f30b648")]
		public enum DISPLAYCONFIG_MODE_INFO_TYPE : uint
		{
			/// <summary>Indicates that the DISPLAYCONFIG_MODE_INFO structure contains source mode information.</summary>
			DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE = 1,

			/// <summary>Indicates that the DISPLAYCONFIG_MODE_INFO structure contains target mode information.</summary>
			DISPLAYCONFIG_MODE_INFO_TYPE_TARGET,

			/// <summary>
			/// Indicates that the DISPLAYCONFIG_MODE_INFO structure contains a valid DISPLAYCONFIG_DESKTOP_IMAGE_INFO structure. Supported
			/// starting in Windows 10.
			/// </summary>
			DISPLAYCONFIG_MODE_INFO_TYPE_DESKTOP_IMAGE,
		}

		/// <summary>The DISPLAYCONFIG_PIXELFORMAT enumeration specifies pixel format in various bits per pixel (BPP) values.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-displayconfig_pixelformat typedef enum {
		// DISPLAYCONFIG_PIXELFORMAT_8BPP, DISPLAYCONFIG_PIXELFORMAT_16BPP, DISPLAYCONFIG_PIXELFORMAT_24BPP, DISPLAYCONFIG_PIXELFORMAT_32BPP,
		// DISPLAYCONFIG_PIXELFORMAT_NONGDI, DISPLAYCONFIG_PIXELFORMAT_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "dca8433d-89a9-492c-bebb-6a28f485896c")]
		public enum DISPLAYCONFIG_PIXELFORMAT : uint
		{
			/// <summary>Indicates 8 BPP format.</summary>
			DISPLAYCONFIG_PIXELFORMAT_8BPP = 1,

			/// <summary>Indicates 16 BPP format.</summary>
			DISPLAYCONFIG_PIXELFORMAT_16BPP,

			/// <summary>Indicates 24 BPP format.</summary>
			DISPLAYCONFIG_PIXELFORMAT_24BPP,

			/// <summary>Indicates 32 BPP format.</summary>
			DISPLAYCONFIG_PIXELFORMAT_32BPP,

			/// <summary>
			/// Indicates that the current display is not an 8, 16, 24, or 32 BPP GDI desktop mode. For example, a call to the
			/// QueryDisplayConfig function returns DISPLAYCONFIG_PIXELFORMAT_NONGDI if a DirectX application previously set the desktop to
			/// A2R10G10B10 format. A call to the SetDisplayConfig function fails if any pixel formats for active paths are set to DISPLAYCONFIG_PIXELFORMAT_NONGDI.
			/// </summary>
			DISPLAYCONFIG_PIXELFORMAT_NONGDI,
		}

		/// <summary>The DISPLAYCONFIG_ROTATION enumeration specifies the clockwise rotation of the display.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-displayconfig_rotation typedef enum {
		// DISPLAYCONFIG_ROTATION_IDENTITY, DISPLAYCONFIG_ROTATION_ROTATE90, DISPLAYCONFIG_ROTATION_ROTATE180,
		// DISPLAYCONFIG_ROTATION_ROTATE270, DISPLAYCONFIG_ROTATION_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "82709d44-45e6-47ec-9caa-5a947a568c52")]
		public enum DISPLAYCONFIG_ROTATION : uint
		{
			/// <summary>Indicates that rotation is 0 degrees—landscape mode.</summary>
			DISPLAYCONFIG_ROTATION_IDENTITY = 1,

			/// <summary>Indicates that rotation is 90 degrees clockwise—portrait mode.</summary>
			DISPLAYCONFIG_ROTATION_ROTATE90,

			/// <summary>Indicates that rotation is 180 degrees clockwise—inverted landscape mode.</summary>
			DISPLAYCONFIG_ROTATION_ROTATE180,

			/// <summary>Indicates that rotation is 270 degrees clockwise—inverted portrait mode.</summary>
			DISPLAYCONFIG_ROTATION_ROTATE270,
		}

		/// <summary>
		/// The DISPLAYCONFIG_SCALING enumeration specifies the scaling transformation applied to content displayed on a video present
		/// network (VidPN) present path.
		/// </summary>
		/// <remarks>For more information about scaling, see Scaling the Desktop Image.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-displayconfig_scaling typedef enum {
		// DISPLAYCONFIG_SCALING_IDENTITY, DISPLAYCONFIG_SCALING_CENTERED, DISPLAYCONFIG_SCALING_STRETCHED,
		// DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX, DISPLAYCONFIG_SCALING_CUSTOM, DISPLAYCONFIG_SCALING_PREFERRED,
		// DISPLAYCONFIG_SCALING_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "6f073aa6-2647-4a51-9256-b2da488fd382")]
		public enum DISPLAYCONFIG_SCALING : uint
		{
			/// <summary>
			/// Indicates the identity transformation; the source content is presented with no change. This transformation is available only
			/// if the path's source mode has the same spatial resolution as the path's target mode.
			/// </summary>
			DISPLAYCONFIG_SCALING_IDENTITY = 1,

			/// <summary>
			/// Indicates the centering transformation; the source content is presented unscaled, centered with respect to the spatial
			/// resolution of the target mode.
			/// </summary>
			DISPLAYCONFIG_SCALING_CENTERED,

			/// <summary>Indicates the content is scaled to fit the path's target.</summary>
			DISPLAYCONFIG_SCALING_STRETCHED,

			/// <summary>Indicates the aspect-ratio centering transformation.</summary>
			DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX,

			/// <summary>
			/// Indicates that the caller requests a custom scaling that the caller cannot describe with any of the other
			/// DISPLAYCONFIG_SCALING_XXX values. Only a hardware vendor's value-add application should use DISPLAYCONFIG_SCALING_CUSTOM,
			/// because the value-add application might require a private interface to the driver. The application can then use
			/// DISPLAYCONFIG_SCALING_CUSTOM to indicate additional context for the driver for the custom value on the specified path.
			/// </summary>
			DISPLAYCONFIG_SCALING_CUSTOM,

			/// <summary>
			/// Indicates that the caller does not have any preference for the scaling. The SetDisplayConfig function will use the scaling
			/// value that was last saved in the database for the path. If such a scaling value does not exist, SetDisplayConfig will use the
			/// default scaling for the computer. For example, stretched (DISPLAYCONFIG_SCALING_STRETCHED) for tablet computers and
			/// aspect-ratio centered (DISPLAYCONFIG_SCALING_ASPECTRATIOCENTEREDMAX) for non-tablet computers.
			/// </summary>
			DISPLAYCONFIG_SCALING_PREFERRED = 128,
		}

		/// <summary>
		/// The DISPLAYCONFIG_SCANLINE_ORDERING enumeration specifies the method that the display uses to create an image on a screen.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-__unnamed_enum_1 typedef enum {
		// DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED, DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE,
		// DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED, DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST,
		// DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST, DISPLAYCONFIG_SCANLINE_ORDERING_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "5b8d6c83-e8fb-4529-8d61-557ed0e4da37")]
		public enum DISPLAYCONFIG_SCANLINE_ORDERING : uint
		{
			/// <summary>
			/// Indicates that scan-line ordering of the output is unspecified. The caller can only set the scanLineOrdering member of the
			/// DISPLAYCONFIG_PATH_TARGET_INFO structure in a call to the SetDisplayConfig function to
			/// DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED if the caller also set the refresh rate denominator and numerator of the
			/// refreshRate member both to zero. In this case, SetDisplayConfig uses the best refresh rate it can find.
			/// </summary>
			DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED = 0,

			/// <summary>Indicates that the output is a progressive image.</summary>
			DISPLAYCONFIG_SCANLINE_ORDERING_PROGRESSIVE = 1,

			/// <summary>Indicates that the output is an interlaced image that is created beginning with the upper field.</summary>
			DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED = 2,

			/// <summary>Indicates that the output is an interlaced image that is created beginning with the upper field.</summary>
			DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_UPPERFIELDFIRST = DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED,

			/// <summary>Indicates that the output is an interlaced image that is created beginning with the lower field.</summary>
			DISPLAYCONFIG_SCANLINE_ORDERING_INTERLACED_LOWERFIELDFIRST = 3,
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("wingdi.h")]
		public enum DISPLAYCONFIG_SET_ADVANCED_COLOR_STATE_VALUE
		{
			/// <summary>Undocumented.</summary>
			enableAdvancedColor = 1
		}

		/// <summary>
		/// A member in the union that DISPLAYCONFIG_SET_TARGET_PERSISTENCE contains that can hold a 32-bit value that identifies information
		/// about setting the display.
		/// </summary>
		[PInvokeData("wingdi.h", MSDNShortId = "4798a1e1-8685-40c2-917a-0ee071bc780c")]
		[Flags]
		public enum DISPLAYCONFIG_SET_TARGET_PERSISTENCE_VALUE : uint
		{
			/// <summary>
			/// <para>
			/// A UINT32 value that specifies whether the SetDisplayConfig function should enable or disable boot persistence for the
			/// specified target.
			/// </para>
			/// <para>Setting this member is equivalent to setting the first bit of the 32-bit <c>value</c> member (0x00000001).</para>
			/// </summary>
			bootPersistenceOn = 1,
		}

		/// <summary>Reflects the value of <c>disableMonitorVirtualResolution</c> in cases where debugging is utilized.</summary>
		[PInvokeData("wingdi.h", MSDNShortId = "D9208D00-F437-4B2E-8C39-044F75088659")]
		[Flags]
		public enum DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION_VALUE : uint
		{
			/// <summary>Setting this bit disables virtual mode for the monitor using information found in <c>header</c>.</summary>
			disableMonitorVirtualResolution = 1
		}

		/// <summary>The <c>DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS</c> enum contains information about a target device.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_target_device_name_flags typedef struct
		// DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS { union { struct { UINT32 friendlyNameFromEdid : 1; UINT32 friendlyNameForced : 1; UINT32
		// edidIdsValid : 1; UINT32 reserved : 29; } DUMMYSTRUCTNAME; UINT32 value; } DUMMYUNIONNAME; } DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS;
		[PInvokeData("wingdi.h", MSDNShortId = "f0318dd3-4350-4de3-84c8-2c998254c68c")]
		public enum DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS : uint
		{
			/// <summary>
			/// Indicates that the string in the monitorFriendlyDeviceName member of the DISPLAYCONFIG_TARGET_DEVICE_NAME structure was
			/// constructed from the manufacture identification string in the extended display identification data (EDID).
			/// </summary>
			friendlyNameFromEdid = 1,

			/// <summary>
			/// Indicates that the target is forced with no detectable monitor attached and the monitorFriendlyDeviceName member of the
			/// DISPLAYCONFIG_TARGET_DEVICE_NAME structure is a NULL-terminated empty string.
			/// </summary>
			friendlyNameForced = 2,

			/// <summary>
			/// Indicates that the edidManufactureId and edidProductCodeId members of the DISPLAYCONFIG_TARGET_DEVICE_NAME structure are
			/// valid and were obtained from the EDID.
			/// </summary>
			edidIdsValid = 4
		}

		/// <summary>The DISPLAYCONFIG_TOPOLOGY_ID enumeration specifies the type of display topology.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-displayconfig_topology_id typedef enum
		// DISPLAYCONFIG_TOPOLOGY_ID { DISPLAYCONFIG_TOPOLOGY_INTERNAL, DISPLAYCONFIG_TOPOLOGY_CLONE, DISPLAYCONFIG_TOPOLOGY_EXTEND,
		// DISPLAYCONFIG_TOPOLOGY_EXTERNAL, DISPLAYCONFIG_TOPOLOGY_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "0018f137-7cdf-47b7-9ede-8685f9b073fb")]
		[Flags]
		public enum DISPLAYCONFIG_TOPOLOGY_ID : uint
		{
			/// <summary>Indicates that the display topology is an internal configuration.</summary>
			DISPLAYCONFIG_TOPOLOGY_INTERNAL = 1,

			/// <summary>Indicates that the display topology is clone-view configuration.</summary>
			DISPLAYCONFIG_TOPOLOGY_CLONE = 2,

			/// <summary>Indicates that the display topology is an extended configuration.</summary>
			DISPLAYCONFIG_TOPOLOGY_EXTEND = 4,

			/// <summary>Indicates that the display topology is an external configuration.</summary>
			DISPLAYCONFIG_TOPOLOGY_EXTERNAL = 8,
		}

		/// <summary>The DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY enumeration specifies the target's connector type.</summary>
		/// <remarks>
		/// <para>
		/// Values with "embedded" in their names indicate that the graphics adapter's video output device connects internally to the display
		/// device. In those cases, the DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL value is redundant. The caller should ignore
		/// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL and just process the embedded values,
		/// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED and DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED.
		/// </para>
		/// <para>An embedded display port or UDI is also known as an integrated display port or UDI.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ne-wingdi-displayconfig_video_output_technology typedef enum {
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INDIRECT_WIRED,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INDIRECT_VIRTUAL, DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL,
		// DISPLAYCONFIG_OUTPUT_TECHNOLOGY_FORCE_UINT32 } ;
		[PInvokeData("wingdi.h", MSDNShortId = "f8c2095a-d67e-42ed-b615-b5e0e0e0d507")]
		public enum DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY : uint
		{
			/// <summary>Indicates a connector that is not one of the types that is indicated by the following enumerators in this enumeration.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_OTHER = unchecked((uint)-1),

			/// <summary>Indicates an HD15 (VGA) connector.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HD15 = 0,

			/// <summary>Indicates an S-video connector.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SVIDEO,

			/// <summary>Indicates a composite video connector group.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPOSITE_VIDEO,

			/// <summary>Indicates a component video connector group.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_COMPONENT_VIDEO,

			/// <summary>Indicates a Digital Video Interface (DVI) connector.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DVI,

			/// <summary>Indicates a High-Definition Multimedia Interface (HDMI) connector.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_HDMI,

			/// <summary>Indicates a Low Voltage Differential Swing (LVDS) connector.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_LVDS,

			/// <summary>Indicates a Japanese D connector.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_D_JPN,

			/// <summary>Indicates an SDI connector.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDI,

			/// <summary>Indicates an external display port, which is a display port that connects externally to a display device.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EXTERNAL,

			/// <summary>Indicates an embedded display port that connects internally to a display device.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_DISPLAYPORT_EMBEDDED,

			/// <summary>
			/// Indicates an external Unified Display Interface (UDI), which is a UDI that connects externally to a display device.
			/// </summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EXTERNAL,

			/// <summary>Indicates an embedded UDI that connects internally to a display device.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_UDI_EMBEDDED,

			/// <summary>Indicates a dongle cable that supports standard definition television (SDTV).</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_SDTVDONGLE,

			/// <summary>Indicates that the VidPN target is a Miracast wireless display device. Supported starting in Windows 8.1.</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST,

			/// <summary>The displayconfig output technology indirect wired</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INDIRECT_WIRED,

			/// <summary>The displayconfig output technology indirect virtual</summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INDIRECT_VIRTUAL,

			/// <summary>
			/// Indicates that the video output device connects internally to a display device (for example, the internal connection in a
			/// laptop computer).
			/// </summary>
			DISPLAYCONFIG_OUTPUT_TECHNOLOGY_INTERNAL = 0x80000000,
		}

		/// <summary>The DISPLAYCONFIG_2DREGION structure represents a point or an offset in a two-dimensional space.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_2dregion typedef struct DISPLAYCONFIG_2DREGION
		// { UINT32 cx; UINT32 cy; } DISPLAYCONFIG_2DREGION;
		[PInvokeData("wingdi.h", MSDNShortId = "ea306268-53fc-488b-afae-b8e9e5d09f2b")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DISPLAYCONFIG_2DREGION
		{
			/// <summary>The horizontal component of the point or offset.</summary>
			public uint cx;

			/// <summary>The vertical component of the point or offset.</summary>
			public uint cy;
		}

		/// <summary>The DISPLAYCONFIG_ADAPTER_NAME structure contains information about the display adapter.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_adapter_name typedef struct
		// DISPLAYCONFIG_ADAPTER_NAME { DISPLAYCONFIG_DEVICE_INFO_HEADER header; WCHAR adapterDevicePath[128]; } DISPLAYCONFIG_ADAPTER_NAME;
		[PInvokeData("wingdi.h", MSDNShortId = "248f325f-37ae-48f4-a758-ee78a3e3f0b8")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DISPLAYCONFIG_ADAPTER_NAME
		{
			/// <summary>
			/// A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the adapter name. The caller
			/// should set the <c>type</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to DISPLAYCONFIG_DEVICE_INFO_GET_ADAPTER_NAME and the
			/// <c>adapterId</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to the adapter identifier of the adapter for which the caller
			/// wants the name. For this request, the caller does not need to set the <c>id</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER.
			/// The caller should set the <c>size</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to at least the size of the
			/// DISPLAYCONFIG_ADAPTER_NAME structure.
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>
			/// A NULL-terminated WCHAR string that is the device name for the adapter. This name can be used with SetupAPI.dll to obtain the
			/// device name that is contained in the installation package.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string adapterDevicePath;
		}

		/// <summary>The DISPLAYCONFIG_DESKTOP_IMAGE_INFO structure contains information about the image displayed on the desktop.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_desktop_image_info typedef struct
		// DISPLAYCONFIG_DESKTOP_IMAGE_INFO { POINTL PathSourceSize; RECTL DesktopImageRegion; RECTL DesktopImageClip; } DISPLAYCONFIG_DESKTOP_IMAGE_INFO;
		[PInvokeData("wingdi.h", MSDNShortId = "2DACA175-19BC-4192-A2FF-CB8AC7220B98")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DISPLAYCONFIG_DESKTOP_IMAGE_INFO
		{
			/// <summary>A POINTL structure that specifies the size of the VidPn source surface that is being displayed on the monitor.</summary>
			public Point PathSourceSize;

			/// <summary>
			/// A RECTL structure that defines where the desktop image will be positioned within path source. Region must be completely
			/// inside the bounds of the path source size.
			/// </summary>
			public RECT DesktopImageRegion;

			/// <summary>
			/// A RECTL structure that defines which part of the desktop image for this clone group will be displayed on this path. This
			/// currently must be set to the desktop size.
			/// </summary>
			public RECT DesktopImageClip;
		}

		/// <summary>The DISPLAYCONFIG_DEVICE_INFO_HEADER structure contains display information about the device.</summary>
		/// <remarks>
		/// The DisplayConfigGetDeviceInfo function uses the DISPLAYCONFIG_DEVICE_INFO_HEADER structure for retrieving display configuration
		/// information about the device, and the DisplayConfigSetDeviceInfo function uses the DISPLAYCONFIG_DEVICE_INFO_HEADER structure for
		/// setting display configuration information for the device.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_device_info_header typedef struct
		// DISPLAYCONFIG_DEVICE_INFO_HEADER { DISPLAYCONFIG_DEVICE_INFO_TYPE type; UINT32 size; LUID adapterId; UINT32 id; } DISPLAYCONFIG_DEVICE_INFO_HEADER;
		[PInvokeData("wingdi.h", MSDNShortId = "2fdfa54e-2a5f-448f-98e3-e51ce0acaeaf")]
		[StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Auto)]
		public struct DISPLAYCONFIG_DEVICE_INFO_HEADER
		{
			/// <summary>
			/// A DISPLAYCONFIG_DEVICE_INFO_TYPE enumerated value that determines the type of device information to retrieve or set. The
			/// remainder of the packet for the retrieve or set operation follows immediately after the DISPLAYCONFIG_DEVICE_INFO_HEADER structure.
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_TYPE type;

			/// <summary>
			/// The size, in bytes, of the device information that is retrieved or set. This size includes the size of the header and the
			/// size of the additional data that follows the header. This device information depends on the request type.
			/// </summary>
			public uint size;

			/// <summary>A locally unique identifier (LUID) that identifies the adapter that the device information packet refers to.</summary>
			public ulong adapterId;

			/// <summary>
			/// The source or target identifier to get or set the device information for. The meaning of this identifier is related to the
			/// type of information being requested. For example, in the case of DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME, this is the
			/// source identifier.
			/// </summary>
			public uint id;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("wingdi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO
		{
			/// <summary>Undocumented.</summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>Undocumented.</summary>
			public DISPLAYCONFIG_GET_ADVANCED_COLOR_INFO_VALUE value;

			/// <summary>Undocumented.</summary>
			public DISPLAYCONFIG_COLOR_ENCODING colorEncoding;

			/// <summary>Undocumented.</summary>
			public uint bitsPerColorChannel;
		}

		/// <summary>The DISPLAYCONFIG_MODE_INFO structure contains either source mode or target mode information.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_mode_info typedef struct
		// DISPLAYCONFIG_MODE_INFO { DISPLAYCONFIG_MODE_INFO_TYPE infoType; UINT32 id; LUID adapterId; union { DISPLAYCONFIG_TARGET_MODE
		// targetMode; DISPLAYCONFIG_SOURCE_MODE sourceMode; DISPLAYCONFIG_DESKTOP_IMAGE_INFO desktopImageInfo; } DUMMYUNIONNAME; } DISPLAYCONFIG_MODE_INFO;
		[PInvokeData("wingdi.h", MSDNShortId = "39ffe49b-96d3-4d8b-94a7-01c388448b82")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		public struct DISPLAYCONFIG_MODE_INFO
		{
			/// <summary>
			/// A value that indicates whether the <c>DISPLAYCONFIG_MODE_INFO</c> structure represents source or target mode information. If
			/// <c>infoType</c> is DISPLAYCONFIG_MODE_INFO_TYPE_TARGET, the targetMode parameter value contains a valid
			/// DISPLAYCONFIG_TARGET_MODE structure describing the specified target. If <c>infoType</c> is
			/// DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE, the sourceMode parameter value contains a valid DISPLAYCONFIG_SOURCE_MODE structure
			/// describing the specified source.
			/// </summary>
			public DISPLAYCONFIG_MODE_INFO_TYPE infoType;

			/// <summary>The source or target identifier on the specified adapter that this path relates to.</summary>
			public uint id;

			/// <summary>The identifier of the adapter that this source or target mode information relates to.</summary>
			public ulong adapterId;

			/// <summary>
			/// A valid DISPLAYCONFIG_TARGET_MODE structure that describes the specified target only when <c>infoType</c> is DISPLAYCONFIG_MODE_INFO_TYPE_TARGET.
			/// </summary>
			public DISPLAYCONFIG_TARGET_MODE targetMode;

			/// <summary>
			/// A valid DISPLAYCONFIG_SOURCE_MODE structure that describes the specified source only when <c>infoType</c> is DISPLAYCONFIG_MODE_INFO_TYPE_SOURCE.
			/// </summary>
			public DISPLAYCONFIG_SOURCE_MODE sourceMode;

			/// <summary>
			/// <para>
			/// A DISPLAYCONFIG_DESKTOP_IMAGE_INFO structure that describes information about the desktop image only when <c>infoType</c> is DISPLAYCONFIG_MODE_INFO_TYPE_.
			/// </para>
			/// <para>Supported starting in Windows 10.</para>
			/// </summary>
			public DISPLAYCONFIG_DESKTOP_IMAGE_INFO desktopImageInfo;
		}

		/// <summary>The DISPLAYCONFIG_PATH_INFO structure is used to describe a single path from a target to a source.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_path_info typedef struct
		// DISPLAYCONFIG_PATH_INFO { DISPLAYCONFIG_PATH_SOURCE_INFO sourceInfo; DISPLAYCONFIG_PATH_TARGET_INFO targetInfo; UINT32 flags; } DISPLAYCONFIG_PATH_INFO;
		[PInvokeData("wingdi.h", MSDNShortId = "e218c36d-60d5-42c8-9443-419a388a2b8d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DISPLAYCONFIG_PATH_INFO
		{
			/// <summary>A DISPLAYCONFIG_PATH_SOURCE_INFO structure that contains the source information for the path.</summary>
			public DISPLAYCONFIG_PATH_SOURCE_INFO sourceInfo;

			/// <summary>A DISPLAYCONFIG_PATH_TARGET_INFO structure that contains the target information for the path.</summary>
			public DISPLAYCONFIG_PATH_TARGET_INFO targetInfo;

			/// <summary>
			/// <para>A bitwise OR of flag values that indicates the state of the path. The following values are supported:</para>
			/// <para>DISPLAYCONFIG_PATH_ACTIVE</para>
			/// <para>
			/// Set by QueryDisplayConfig to indicate that the path is active and part of the desktop. If this flag value is set,
			/// SetDisplayConfig attempts to enable this path.
			/// </para>
			/// <para>DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE</para>
			/// <para>Set by QueryDisplayConfig to indicate that the path supports the virtual mode. Supported starting in Windows 10.</para>
			/// </summary>
			public uint flags;
		}

		/// <summary>The DISPLAYCONFIG_PATH_SOURCE_INFO structure contains source information for a single path.</summary>
		/// <remarks>
		/// <para>A DISPLAYCONFIG_PATH_SOURCE_INFO structure is specified in the <c>sourceInfo</c> member of a DISPLAYCONFIG_PATH_INFO structure.</para>
		/// <para>
		/// A source corresponds to a surface on which the display adapter can render pixels. Each display adapter is capable of rendering to
		/// x number of sources. What this means is how many desktops can be rendered for extend mode. This is typically 2. For example,
		/// source 0 might be rendering pixels from 0,0 to 1024,768, and source 1 might be rendering pixels from 1025,0 to 2048, 768.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_path_source_info typedef struct
		// DISPLAYCONFIG_PATH_SOURCE_INFO { LUID adapterId; UINT32 id; union { UINT32 modeInfoIdx; struct { UINT32 cloneGroupId : 16; UINT32
		// sourceModeInfoIdx : 16; } DUMMYSTRUCTNAME; } DUMMYUNIONNAME; UINT32 statusFlags; } DISPLAYCONFIG_PATH_SOURCE_INFO;
		[PInvokeData("wingdi.h", MSDNShortId = "df43d20b-a55a-4bec-89a2-9ede03b4d6c5")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		public struct DISPLAYCONFIG_PATH_SOURCE_INFO
		{
			/// <summary>The identifier of the adapter that this source information relates to.</summary>
			public ulong adapterId;

			/// <summary>The source identifier on the specified adapter that this path relates to.</summary>
			public uint id;

			/// <summary>A union.</summary>
			public Union union;

			/// <summary>
			/// <para>A bitwise OR of flag values that indicates the status of the source. The following values are supported:</para>
			/// <para>DISPLAYCONFIG_SOURCE_IN_USE</para>
			/// <para>This source is in use by at least one active path.</para>
			/// </summary>
			public uint statusFlags;

			/// <summary>A union.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct Union
			{
				/// <summary>
				/// A valid index into the mode information table that contains the source mode information for this path only when
				/// DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is not set. If source mode information is not available, the value of
				/// <c>modeInfoIdx</c> is DISPLAYCONFIG_PATH_MODE_IDX_INVALID.
				/// </summary>
				[FieldOffset(0)]
				public uint modeInfoIdx;

				/// <summary>
				/// <para>
				/// A valid identifier used to show which clone group the path is a member of only when
				/// DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is set. If this value is invalid, then it must be set to DISPLAYCONFIG_PATH_CLONE_GROUP_INVALID.
				/// </para>
				/// <para>
				/// <c>cloneGroupId</c> is only used when the source mode index is not specified. Two such scenarios are when the source mode
				/// info must be invalid because SDC_TOPOLOGY_SUPPLIED is used, and when SDC_USE_SUPPLIED_DISPLAY_CONFIG is used with paths
				/// that do not have source mode info. The <c>cloneGroupId</c> will be used to indicate which paths are in a clone group, all
				/// the paths with the same <c>cloneGroupId</c> value are considered in the same clone group. There is no requirement that
				/// the clone group id’s have to be zero based or contiguous. Supported starting in Windows 10.
				/// </para>
				/// </summary>
				[FieldOffset(0)]
				public ushort cloneGroupId;

				/// <summary>
				/// A valid index into the mode array of the DISPLAYCONFIG_SOURCE_MODE entry that contains the source mode information for
				/// this path only when DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is set. If there is no entry for this in the mode array, the
				/// value of <c>sourceModeInfoIdx</c> is DISPLAYCONFIG_PATH_SOURCE_MODE_IDX_INVALID. Supported starting in Windows 10.
				/// </summary>
				[FieldOffset(2)]
				public ushort sourceModeInfoIdx;
			}
		}

		/// <summary>The DISPLAYCONFIG_PATH_TARGET_INFO structure contains target information for a single path.</summary>
		/// <remarks>
		/// <para>A DISPLAYCONFIG_PATH_TARGET_INFO structure is specified in the <c>targetInfo</c> member of a DISPLAYCONFIG_PATH_INFO structure.</para>
		/// <para>
		/// A target corresponds to the number of possible video outputs on a display adapter. This number, however, does not equate to the
		/// number of physical connectors on the display adapter. Each connector exposes a number of targets that includes backward
		/// compatibility with older connector technology. For example, a DVI connector exposes a DVI target, as well as a VGA target. A
		/// DisplayPort connector, which was introduced in 2006, exposes DisplayPort, HDMI, DVI, legacy TV, and VGA targets.
		/// </para>
		/// <para>The <c>statusFlags</c> member is set when you call the QueryDisplayConfig function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_path_target_info typedef struct
		// DISPLAYCONFIG_PATH_TARGET_INFO { LUID adapterId; UINT32 id; union { UINT32 modeInfoIdx; struct { UINT32 desktopModeInfoIdx : 16;
		// UINT32 targetModeInfoIdx : 16; } DUMMYSTRUCTNAME; } DUMMYUNIONNAME; DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;
		// DISPLAYCONFIG_ROTATION rotation; DISPLAYCONFIG_SCALING scaling; DISPLAYCONFIG_RATIONAL refreshRate;
		// DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering; BOOL targetAvailable; UINT32 statusFlags; } DISPLAYCONFIG_PATH_TARGET_INFO;
		[PInvokeData("wingdi.h", MSDNShortId = "3dcdca96-7c5d-4e69-b7dd-8b5ccda25f6a")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		public struct DISPLAYCONFIG_PATH_TARGET_INFO
		{
			/// <summary>The identifier of the adapter that the path is on.</summary>
			public ulong adapterId;

			/// <summary>The target identifier on the specified adapter that this path relates to.</summary>
			public uint id;

			/// <summary>A union.</summary>
			public Union union;

			/// <summary>
			/// The target's connector type. For a list of possible values, see the DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY enumerated type.
			/// </summary>
			public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;

			/// <summary>
			/// A value that specifies the rotation of the target. For a list of possible values, see the DISPLAYCONFIG_ROTATION enumerated type.
			/// </summary>
			public DISPLAYCONFIG_ROTATION rotation;

			/// <summary>
			/// A value that specifies how the source image is scaled to the target. For a list of possible values, see the
			/// DISPLAYCONFIG_SCALING enumerated type. For more information about scaling, see Scaling the Desktop Image.
			/// </summary>
			public DISPLAYCONFIG_SCALING scaling;

			/// <summary>
			/// A DISPLAYCONFIG_RATIONAL structure that specifies the refresh rate of the target. If the caller specifies target mode
			/// information, the operating system will instead use the refresh rate that is stored in the <c>vSyncFreq</c> member of the
			/// DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure. In this case, the caller specifies this value in the <c>targetVideoSignalInfo</c>
			/// member of the DISPLAYCONFIG_TARGET_MODE structure. A refresh rate with both the numerator and denominator set to zero
			/// indicates that the caller does not specify a refresh rate and the operating system should use the most optimal refresh rate
			/// available. For this case, in a call to the SetDisplayConfig function, the caller must set the <c>scanLineOrdering</c> member
			/// to the DISPLAYCONFIG_SCANLINE_ORDERING_UNSPECIFIED value; otherwise, <c>SetDisplayConfig</c> fails.
			/// </summary>
			public DISPLAYCONFIG_RATIONAL refreshRate;

			/// <summary>
			/// A value that specifies the scan-line ordering of the output on the target. For a list of possible values, see the
			/// DISPLAYCONFIG_SCANLINE_ORDERING enumerated type. If the caller specifies target mode information, the operating system will
			/// instead use the scan-line ordering that is stored in the <c>scanLineOrdering</c> member of the
			/// DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure. In this case, the caller specifies this value in the <c>targetVideoSignalInfo</c>
			/// member of the DISPLAYCONFIG_TARGET_MODE structure.
			/// </summary>
			public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;

			/// <summary>
			/// <para>A Boolean value that specifies whether the target is available. <c>TRUE</c> indicates that the target is available.</para>
			/// <para>
			/// Because the asynchronous nature of display topology changes when a monitor is removed, a path might still be marked as active
			/// even though the monitor has been removed. In such a case, <c>targetAvailable</c> could be <c>FALSE</c> for an active path.
			/// This is typically a transient situation that will change after the operating system takes action on the monitor removal.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)] public bool targetAvailable;

			/// <summary>
			/// <para>A bitwise OR of flag values that indicates the status of the target. The following values are supported:</para>
			/// <para>DISPLAYCONFIG_TARGET_IN_USE</para>
			/// <para>Target is in use on an active path.</para>
			/// <para>DISPLAYCONFIG_TARGET_FORCIBLE</para>
			/// <para>The output can be forced on this target even if a monitor is not detected.</para>
			/// <para>DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_BOOT</para>
			/// <para>Output is currently being forced in a boot-persistent manner.</para>
			/// <para>DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_PATH</para>
			/// <para>Output is currently being forced in a path-persistent manner.</para>
			/// <para>DISPLAYCONFIG_TARGET_FORCED_AVAILABILITY_SYSTEM</para>
			/// <para>Output is currently being forced in a non-persistent manner.</para>
			/// </summary>
			public uint statusFlags;

			/// <summary>A union.</summary>
			[StructLayout(LayoutKind.Explicit)]
			public struct Union
			{
				/// <summary>
				/// A valid index into the mode information table that contains the target mode information for this path only when
				/// DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is not set. If target mode information is not available, the value of
				/// <c>modeInfoIdx</c> is DISPLAYCONFIG_PATH_MODE_IDX_INVALID.
				/// </summary>
				[FieldOffset(0)]
				public uint modeInfoIdx;

				/// <summary>
				/// A valid index into the mode array of the DISPLAYCONFIG_DESKTOP_IMAGE_INFO entry that contains the desktop mode
				/// information for this path only when DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is set. If there is no entry for this in the
				/// mode array, the value of <c>desktopModeInfoIdx</c> is DISPLAYCONFIG_PATH_DESKTOP_IMAGE_IDX_INVALID. Supported starting in
				/// Windows 10.
				/// </summary>
				[FieldOffset(0)]
				public ushort desktopModeInfoIdx;

				/// <summary>
				/// A valid index into the mode array of the DISPLAYCONFIG_TARGET_MODE entry that contains the target mode information for
				/// this path only when DISPLAYCONFIG_PATH_SUPPORT_VIRTUAL_MODE is set. If there is no entry for this in the mode array, the
				/// value of <c>targetModeInfoIdx</c> is DISPLAYCONFIG_PATH_TARGET_MODE_IDX_INVALID. Supported starting in Windows 10.
				/// </summary>
				[FieldOffset(2)]
				public ushort targetModeInfoIdx;
			}
		}

		/// <summary>
		/// The DISPLAYCONFIG_RATIONAL structure describes a fractional value that represents vertical and horizontal frequencies of a video
		/// mode (that is, vertical sync and horizontal sync).
		/// </summary>
		/// <remarks>
		/// A DISPLAYCONFIG_RATIONAL structure is specified in members of the DISPLAYCONFIG_PATH_TARGET_INFO and
		/// DISPLAYCONFIG_VIDEO_SIGNAL_INFO structures.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_rational typedef struct DISPLAYCONFIG_RATIONAL
		// { UINT32 Numerator; UINT32 Denominator; } DISPLAYCONFIG_RATIONAL;
		[PInvokeData("wingdi.h", MSDNShortId = "1f2f25f7-5ea1-46f4-ad9f-c50c367bb600")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DISPLAYCONFIG_RATIONAL
		{
			/// <summary>The numerator of the frequency fraction.</summary>
			public uint Numerator;

			/// <summary>The denominator of the frequency fraction.</summary>
			public uint Denominator;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("wingdi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISPLAYCONFIG_SDR_WHITE_LEVEL
		{
			/// <summary>Undocumented.</summary>
			private DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>
			/// SDRWhiteLevel represents a multiplier for standard SDR white peak value i.e. 80 nits represented as fixed point. To get value
			/// in nits use the following conversion SDRWhiteLevel in nits = (SDRWhiteLevel / 1000 ) * 80
			/// </summary>
			public uint SDRWhiteLevel;
		}

		/// <summary>Undocumented.</summary>
		[PInvokeData("wingdi.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISPLAYCONFIG_SET_ADVANCED_COLOR_STATE
		{
			/// <summary>Undocumented.</summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>Undocumented.</summary>
			public DISPLAYCONFIG_SET_ADVANCED_COLOR_STATE_VALUE value;
		}

		/// <summary>The DISPLAYCONFIG_SET_TARGET_PERSISTENCE structure contains information about setting the display.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_set_target_persistence typedef struct
		// DISPLAYCONFIG_SET_TARGET_PERSISTENCE { DISPLAYCONFIG_DEVICE_INFO_HEADER header; union { struct { UINT32 bootPersistenceOn : 1;
		// UINT32 reserved : 31; } DUMMYSTRUCTNAME; UINT32 value; } DUMMYUNIONNAME; } DISPLAYCONFIG_SET_TARGET_PERSISTENCE;
		[PInvokeData("wingdi.h", MSDNShortId = "4798a1e1-8685-40c2-917a-0ee071bc780c")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DISPLAYCONFIG_SET_TARGET_PERSISTENCE
		{
			/// <summary>
			/// A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information for setting the target persistence. The <c>type</c>
			/// member of DISPLAYCONFIG_DEVICE_INFO_HEADER is set to DISPLAYCONFIG_DEVICE_INFO_SET_TARGET_PERSISTENCE.
			/// DISPLAYCONFIG_DEVICE_INFO_HEADER also contains the adapter and target identifiers of the target to set the persistence for.
			/// The <c>size</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER is set to at least the size of the
			/// DISPLAYCONFIG_SET_TARGET_PERSISTENCE structure.
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>
			/// A member in the union that DISPLAYCONFIG_SET_TARGET_PERSISTENCE contains that can hold a 32-bit value that identifies
			/// information about setting the display.
			/// </summary>
			public DISPLAYCONFIG_SET_TARGET_PERSISTENCE_VALUE value;
		}

		/// <summary>The <c>DISPLAYCONFIG_SOURCE_DEVICE_NAME</c> structure contains the GDI device name for the source or view.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_source_device_name typedef struct
		// DISPLAYCONFIG_SOURCE_DEVICE_NAME { DISPLAYCONFIG_DEVICE_INFO_HEADER header; WCHAR viewGdiDeviceName[CCHDEVICENAME]; } DISPLAYCONFIG_SOURCE_DEVICE_NAME;
		[PInvokeData("wingdi.h", MSDNShortId = "92813ffc-1915-4f26-afb1-936bf76f7844")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DISPLAYCONFIG_SOURCE_DEVICE_NAME
		{
			/// <summary>
			/// A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the source device name. The
			/// caller should set the <c>type</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to DISPLAYCONFIG_DEVICE_INFO_GET_SOURCE_NAME and
			/// the <c>adapterId</c> and <c>id</c> members of DISPLAYCONFIG_DEVICE_INFO_HEADER to the source for which the caller wants the
			/// source device name. The caller should set the <c>size</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to at least the size of
			/// the DISPLAYCONFIG_SOURCE_DEVICE_NAME structure.
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>
			/// A NULL-terminated WCHAR string that is the GDI device name for the source, or view. This name can be used in a call to
			/// <c>EnumDisplaySettings</c> to obtain a list of available modes for the specified source.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			public string viewGdiDeviceName;
		}

		/// <summary>The <c>DISPLAYCONFIG_SOURCE_MODE</c> structure represents a point or an offset in a two-dimensional space.</summary>
		/// <remarks>
		/// <para>
		/// The arrangement of source surfaces on the desktop is controlled by the <c>position</c> member, which specifies the position in
		/// desktop coordinates of the upper-left corner of the source surface. The source surface that is positioned at (0, 0) is considered
		/// the primary. GDI has strict rules about how the source surfaces can be arranged in the desktop space. For example, there cannot
		/// be any gaps between source surfaces, and there can be no overlaps.
		/// </para>
		/// <para>
		/// The SetDisplayConfig function attempts to rearrange source surfaces in order to enforce these layout rules. The caller must make
		/// every effort to lay out the source surfaces correctly because GDI rearranges the sources in an undefined manner to enforce the
		/// layout rules. The resultant layout may not be what the caller wanted to achieve.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_source_mode typedef struct
		// DISPLAYCONFIG_SOURCE_MODE { UINT32 width; UINT32 height; DISPLAYCONFIG_PIXELFORMAT pixelFormat; POINTL position; } DISPLAYCONFIG_SOURCE_MODE;
		[PInvokeData("wingdi.h", MSDNShortId = "413d63e5-da9d-4906-80a9-049da6e85275")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DISPLAYCONFIG_SOURCE_MODE
		{
			/// <summary>The width in pixels of the source mode.</summary>
			public uint width;

			/// <summary>The height in pixels of the source mode.</summary>
			public uint height;

			/// <summary>A value from the DISPLAYCONFIG_PIXELFORMAT enumeration that specifies the pixel format of the source mode.</summary>
			public DISPLAYCONFIG_PIXELFORMAT pixelFormat;

			/// <summary>
			/// A POINTL structure that specifies the position in the desktop coordinate space of the upper-left corner of this source
			/// surface. The source surface that is located at (0, 0) is always the primary source surface.
			/// </summary>
			public Point position;
		}

		/// <summary>
		/// The DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION structure contains information on the state of virtual resolution support for the monitor.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_support_virtual_resolution typedef struct
		// DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION { DISPLAYCONFIG_DEVICE_INFO_HEADER header; union { struct { UINT32
		// disableMonitorVirtualResolution : 1; UINT32 reserved : 31; } DUMMYSTRUCTNAME; UINT32 value; } DUMMYSTRUCTNAME; } DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION;
		[PInvokeData("wingdi.h", MSDNShortId = "D9208D00-F437-4B2E-8C39-044F75088659")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION
		{
			/// <summary>
			/// A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that holds information on the type, size, adapterID, and ID of the target the
			/// monitor is connected to.
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>Reflects the value of <c>disableMonitorVirtualResolution</c> in cases where debugging is utilized.</summary>
			public DISPLAYCONFIG_SUPPORT_VIRTUAL_RESOLUTION_VALUE value;
		}

		/// <summary>Specifies base output technology info for a given target ID.</summary>
		/// <remarks>
		/// For a Miracast display device, a call to the DisplayConfigGetDeviceInfo function always returns a value of
		/// DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY. <c>DISPLAYCONFIG_OUTPUT_TECHNOLOGY_MIRACAST</c>, regardless of what the Miracast sink
		/// reports as the connector type.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_target_base_type typedef struct
		// DISPLAYCONFIG_TARGET_BASE_TYPE { DISPLAYCONFIG_DEVICE_INFO_HEADER header; DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY
		// baseOutputTechnology; } DISPLAYCONFIG_TARGET_BASE_TYPE;
		[PInvokeData("wingdi.h", MSDNShortId = "7916E714-9A3C-4682-AC08-9B6EE222D8B7")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DISPLAYCONFIG_TARGET_BASE_TYPE
		{
			/// <summary>
			/// <para>
			/// A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains info about the request for the target device name. The caller
			/// should set the <c>type</c> member of <c>DISPLAYCONFIG_DEVICE_INFO_HEADER</c> to
			/// <c>DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_BASE_TYPE</c> and the <c>adapterId</c> and <c>id</c> members of
			/// <c>DISPLAYCONFIG_DEVICE_INFO_HEADER</c> to the target for which the caller wants the target device name.
			/// </para>
			/// <para>
			/// The caller should set the <c>size</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to at least the size of the
			/// <c>DISPLAYCONFIG_TARGET_BASE_TYPE</c> structure.
			/// </para>
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>
			/// The base output technology, given as a constant value of the DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY enumeration, of the
			/// adapter and the target specified by the <c>header</c> member. See Remarks.
			/// </summary>
			public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY baseOutputTechnology;
		}

		/// <summary>The DISPLAYCONFIG_TARGET_DEVICE_NAME structure contains information about the target.</summary>
		/// <remarks>
		/// <para>
		/// Extended display identification data (EDID) is a set of data that is provided by a display to describe its capabilities to a
		/// graphics adapter. EDID data allows a computer to detect the type of monitor that is connected to it. EDID data includes the
		/// manufacturer name, the product type, the timings that are supported by the display, the display size, as well as other display
		/// characteristics. EDID is defined by a standard published by the Video Electronics Standards Association (VESA).
		/// </para>
		/// <para>
		/// A named device object has a path and name of the form \Device\DeviceName. This is known as the device name of the device object.
		/// </para>
		/// <para>
		/// If an application calls the DisplayConfigGetDeviceInfo function to obtain the monitor name and <c>DisplayConfigGetDeviceInfo</c>
		/// either cannot get the monitor name or the target is forced without a monitor connected, the string in the
		/// <c>monitorFriendlyDeviceName</c> member of the DISPLAYCONFIG_TARGET_DEVICE_NAME structure is a <c>NULL</c> string and none of the
		/// bit-field flags in the DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS structure are set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_target_device_name typedef struct
		// DISPLAYCONFIG_TARGET_DEVICE_NAME { DISPLAYCONFIG_DEVICE_INFO_HEADER header; DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS flags;
		// DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology; UINT16 edidManufactureId; UINT16 edidProductCodeId; UINT32
		// connectorInstance; WCHAR monitorFriendlyDeviceName[64]; WCHAR monitorDevicePath[128]; } DISPLAYCONFIG_TARGET_DEVICE_NAME;
		[PInvokeData("wingdi.h", MSDNShortId = "85507b69-8ce0-4f39-a4d3-7d67f515b451")]
		// [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)] public struct DISPLAYCONFIG_TARGET_DEVICE_NAME{public
		// DISPLAYCONFIG_DEVICE_INFO_HEADER header; public DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS flags; public
		// DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology; public ushort edidManufactureId; public ushort edidProductCodeId; public
		// uint connectorInstance; public ushort monitorFriendlyDeviceName[64]; public ushort monitorDevicePath[128]; public ; public
		// DISPLAYCONFIG_TARGET_DEVICE_NAME; }
		[StructLayout(LayoutKind.Sequential, Pack = 2, CharSet = CharSet.Unicode)]
		public struct DISPLAYCONFIG_TARGET_DEVICE_NAME
		{
			/// <summary>
			/// A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the target device name. The
			/// caller should set the <c>type</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_NAME and
			/// the <c>adapterId</c> and <c>id</c> members of DISPLAYCONFIG_DEVICE_INFO_HEADER to the target for which the caller wants the
			/// target device name. The caller should set the <c>size</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to at least the size of
			/// the DISPLAYCONFIG_TARGET_DEVICE_NAME structure.
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>
			/// A DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS structure that identifies, in bit-field flags, information about the target.
			/// </summary>
			public DISPLAYCONFIG_TARGET_DEVICE_NAME_FLAGS flags;

			/// <summary>A value from the DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY enumeration that specifies the target's connector type.</summary>
			public DISPLAYCONFIG_VIDEO_OUTPUT_TECHNOLOGY outputTechnology;

			/// <summary>
			/// The manufacture identifier from the monitor extended display identification data (EDID). This member is set only when the
			/// <c>edidIdsValid</c> bit-field is set in the <c>flags</c> member.
			/// </summary>
			public ushort edidManufactureId;

			/// <summary>
			/// The product code from the monitor EDID. This member is set only when the <c>edidIdsValid</c> bit-field is set in the
			/// <c>flags</c> member.
			/// </summary>
			public ushort edidProductCodeId;

			/// <summary>
			/// The one-based instance number of this particular target only when the adapter has multiple targets of this type. The
			/// connector instance is a consecutive one-based number that is unique within each adapter. If this is the only target of this
			/// type on the adapter, this value is zero.
			/// </summary>
			public uint connectorInstance;

			/// <summary>
			/// A NULL-terminated WCHAR string that is the device name for the monitor. This name can be used with SetupAPI.dll to obtain the
			/// device name that is contained in the installation package.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
			public string monitorFriendlyDeviceName;

			/// <summary>
			/// A NULL-terminated WCHAR string that is the path to the device name for the monitor. This path can be used with SetupAPI.dll
			/// to obtain the device name that is contained in the installation package.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string monitorDevicePath;
		}

		/// <summary>The DISPLAYCONFIG_TARGET_MODE structure describes a display path target mode.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_target_mode typedef struct
		// DISPLAYCONFIG_TARGET_MODE { DISPLAYCONFIG_VIDEO_SIGNAL_INFO targetVideoSignalInfo; } DISPLAYCONFIG_TARGET_MODE;
		[PInvokeData("wingdi.h", MSDNShortId = "c81768f0-67d3-4ddd-94c8-013b1e4cf83e")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISPLAYCONFIG_TARGET_MODE
		{
			/// <summary>A DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure that contains a detailed description of the current target mode.</summary>
			public DISPLAYCONFIG_VIDEO_SIGNAL_INFO targetVideoSignalInfo;
		}

		/// <summary>The <c>DISPLAYCONFIG_TARGET_PREFERRED_MODE</c> structure contains information about the preferred mode of a display.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_target_preferred_mode typedef struct
		// DISPLAYCONFIG_TARGET_PREFERRED_MODE { DISPLAYCONFIG_DEVICE_INFO_HEADER header; UINT32 width; UINT32 height;
		// DISPLAYCONFIG_TARGET_MODE targetMode; } DISPLAYCONFIG_TARGET_PREFERRED_MODE;
		[PInvokeData("wingdi.h", MSDNShortId = "1a4926ca-36d2-466c-b3d2-b59d34a89ee6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct DISPLAYCONFIG_TARGET_PREFERRED_MODE
		{
			/// <summary>
			/// A DISPLAYCONFIG_DEVICE_INFO_HEADER structure that contains information about the request for the target preferred mode. The
			/// caller should set the <c>type</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to
			/// DISPLAYCONFIG_DEVICE_INFO_GET_TARGET_PREFERRED_MODE and the <c>adapterId</c> and <c>id</c> members of
			/// DISPLAYCONFIG_DEVICE_INFO_HEADER to the target for which the caller wants the preferred mode. The caller should set the
			/// <c>size</c> member of DISPLAYCONFIG_DEVICE_INFO_HEADER to at least the size of the DISPLAYCONFIG_TARGET_PREFERRED_MODE structure.
			/// </summary>
			public DISPLAYCONFIG_DEVICE_INFO_HEADER header;

			/// <summary>
			/// The width in pixels of the best mode for the monitor that is connected to the target that the <c>targetMode</c> member specifies.
			/// </summary>
			public uint width;

			/// <summary>
			/// The height in pixels of the best mode for the monitor that is connected to the target that the <c>targetMode</c> member specifies.
			/// </summary>
			public uint height;

			private uint aligner;

			/// <summary>
			/// A DISPLAYCONFIG_TARGET_MODE structure that describes the best target mode for the monitor that is connected to the specified target.
			/// </summary>
			public DISPLAYCONFIG_TARGET_MODE targetMode;
		}

		/// <summary>The DISPLAYCONFIG_VIDEO_SIGNAL_INFO structure contains information about the video signal for a display.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wingdi/ns-wingdi-displayconfig_video_signal_info typedef struct
		// DISPLAYCONFIG_VIDEO_SIGNAL_INFO { UINT64 pixelRate; DISPLAYCONFIG_RATIONAL hSyncFreq; DISPLAYCONFIG_RATIONAL vSyncFreq;
		// DISPLAYCONFIG_2DREGION activeSize; DISPLAYCONFIG_2DREGION totalSize; union { struct { UINT32 videoStandard : 16; UINT32
		// vSyncFreqDivider : 6; UINT32 reserved : 10; } AdditionalSignalInfo; UINT32 videoStandard; } DUMMYUNIONNAME;
		// DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering; } DISPLAYCONFIG_VIDEO_SIGNAL_INFO;
		[PInvokeData("wingdi.h", MSDNShortId = "960089fe-dbb7-41a1-af73-0002cfce6da2")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		public struct DISPLAYCONFIG_VIDEO_SIGNAL_INFO
		{
			/// <summary>The pixel clock rate.</summary>
			public ulong pixelRate;

			/// <summary>A DISPLAYCONFIG_RATIONAL structure that represents horizontal sync.</summary>
			public DISPLAYCONFIG_RATIONAL hSyncFreq;

			/// <summary>A DISPLAYCONFIG_RATIONAL structure that represents vertical sync.</summary>
			public DISPLAYCONFIG_RATIONAL vSyncFreq;

			/// <summary>
			/// A DISPLAYCONFIG_2DREGION structure that specifies the width and height (in pixels) of the active portion of the video signal.
			/// </summary>
			public DISPLAYCONFIG_2DREGION activeSize;

			/// <summary>A DISPLAYCONFIG_2DREGION structure that specifies the width and height (in pixels) of the entire video signal.</summary>
			public DISPLAYCONFIG_2DREGION totalSize;

			/// <summary>
			/// The video standard (if any) that defines the video signal. For a list of possible values, see the
			/// D3DKMDT_VIDEO_SIGNAL_STANDARD enumerated type.
			/// </summary>
			public D3DKMDT_VIDEO_SIGNAL_STANDARD videoStandard;

			/// <summary>The ratio of the VSync rate of a monitor that displays through a Miracast connected session to the VSync rate of the Miracast sink.
			/// <para>To avoid visual artifacts, the VSync rate of the display monitor that's connected to the Miracast sink must be an integer multiple of the VSync rate of the Miracast sink. The display miniport driver reports the latter rate to the operating system as the refresh rate of the desktop present path.</para>
			/// <note>The operating system fails any attempt by the driver to add a target mode that results in a Miracast target having a VSync rate below 23.9 Hz.</note>
			/// <para>For a non-Miracast target, the driver should set vSyncFreqDivider to zero.</para>
			/// <para>Supported starting with Windows 8.1.</para></summary>
			public ushort vSyncFreqDivider;

			/// <summary>
			/// The scan-line ordering (for example, progressive or interlaced) of the video signal. For a list of possible values, see the
			/// DISPLAYCONFIG_SCANLINE_ORDERING enumerated type.
			/// </summary>
			public DISPLAYCONFIG_SCANLINE_ORDERING scanLineOrdering;
		}

		/// <summary>
		/// The D3DKMDT_VIDEO_SIGNAL_STANDARD enumeration contains constants that represent video signal standards.
		/// </summary>
		/// <remarks>
		///   <para>The <c>SignalInfo</c> member of the D3DKMDT_VIDPN_TARGET_MODE structure is a D3DKMDT_VIDEO_SIGNAL_MODE structure.</para><para>The <c>VideoStandard</c> member of the D3DKMDT_VIDEO_SIGNAL_MODE structure is a D3DKMDT_VIDEO_SIGNAL_STANDARD value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows-hardware/drivers/ddi/content/d3dkmdt/ne-d3dkmdt-_d3dkmdt_video_signal_standard
		// typedef enum _D3DKMDT_VIDEO_SIGNAL_STANDARD { D3DKMDT_VSS_UNINITIALIZED, D3DKMDT_VSS_VESA_DMT, D3DKMDT_VSS_VESA_GTF, D3DKMDT_VSS_VESA_CVT, D3DKMDT_VSS_IBM, D3DKMDT_VSS_APPLE, D3DKMDT_VSS_NTSC_M, D3DKMDT_VSS_NTSC_J, D3DKMDT_VSS_NTSC_443, D3DKMDT_VSS_PAL_B, D3DKMDT_VSS_PAL_B1, D3DKMDT_VSS_PAL_G, D3DKMDT_VSS_PAL_H, D3DKMDT_VSS_PAL_I, D3DKMDT_VSS_PAL_D, D3DKMDT_VSS_PAL_N, D3DKMDT_VSS_PAL_NC, D3DKMDT_VSS_SECAM_B, D3DKMDT_VSS_SECAM_D, D3DKMDT_VSS_SECAM_G, D3DKMDT_VSS_SECAM_H, D3DKMDT_VSS_SECAM_K, D3DKMDT_VSS_SECAM_K1, D3DKMDT_VSS_SECAM_L, D3DKMDT_VSS_SECAM_L1, D3DKMDT_VSS_EIA_861, D3DKMDT_VSS_EIA_861A, D3DKMDT_VSS_EIA_861B, D3DKMDT_VSS_PAL_K, D3DKMDT_VSS_PAL_K1, D3DKMDT_VSS_PAL_L, D3DKMDT_VSS_PAL_M, D3DKMDT_VSS_OTHER } D3DKMDT_VIDEO_SIGNAL_STANDARD;
		[PInvokeData("d3dkmdt.h", MSDNShortId = "bb129e02-ae01-4bbc-a81f-809f1a27060c")]
		public enum D3DKMDT_VIDEO_SIGNAL_STANDARD : ushort
		{
			/// <summary>
			/// Indicates that a variable of type D3DKMDT_VIDEO_SIGNAL_STANDARD has not yet been assigned a meaningful value.
			/// </summary>
			D3DKMDT_VSS_UNINITIALIZED = 0,
			/// <summary>Represents the Video Electronics Standards Association (VESA) Display Monitor Timing (DMT) standard.</summary>
			D3DKMDT_VSS_VESA_DMT,
			/// <summary>Represents the VESA Generalized Timing Formula (GTF) standard.</summary>
			D3DKMDT_VSS_VESA_GTF,
			/// <summary>Represents the VESA Coordinated Video Timing (CVT) standard.</summary>
			D3DKMDT_VSS_VESA_CVT,
			/// <summary>Represents the IBM standard.</summary>
			D3DKMDT_VSS_IBM,
			/// <summary>Represents the Apple standard.</summary>
			D3DKMDT_VSS_APPLE,
			/// <summary>Represents the National Television Standards Committee (NTSC) standard.</summary>
			D3DKMDT_VSS_NTSC_M,
			/// <summary>Represents the NTSC standard.</summary>
			D3DKMDT_VSS_NTSC_J,
			/// <summary>Represents the NTSC standard.</summary>
			D3DKMDT_VSS_NTSC_443,
			/// <summary>Represents the Phase Alteration Line (PAL) standard.</summary>
			D3DKMDT_VSS_PAL_B,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_B1,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_G,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_H,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_I,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_D,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_N,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_NC,
			/// <summary>Represents the Systeme Electronic Pour Couleur Avec Memoire (SECAM) standard.</summary>
			D3DKMDT_VSS_SECAM_B,
			/// <summary>Represents the SECAM standard.</summary>
			D3DKMDT_VSS_SECAM_D,
			/// <summary>Represents the SECAM standard.</summary>
			D3DKMDT_VSS_SECAM_G,
			/// <summary>Represents the SECAM standard.</summary>
			D3DKMDT_VSS_SECAM_H,
			/// <summary>Represents the SECAM standard.</summary>
			D3DKMDT_VSS_SECAM_K,
			/// <summary>Represents the SECAM standard.</summary>
			D3DKMDT_VSS_SECAM_K1,
			/// <summary>Represents the SECAM standard.</summary>
			D3DKMDT_VSS_SECAM_L,
			/// <summary>Represents the SECAM standard.</summary>
			D3DKMDT_VSS_SECAM_L1,
			/// <summary>Represents the Electronics Industries Association (EIA) standard.</summary>
			D3DKMDT_VSS_EIA_861,
			/// <summary>Represents the EIA standard.</summary>
			D3DKMDT_VSS_EIA_861A,
			/// <summary>Represents the EIA standard.</summary>
			D3DKMDT_VSS_EIA_861B,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_K,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_K1,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_L,
			/// <summary>Represents the PAL standard.</summary>
			D3DKMDT_VSS_PAL_M,
			/// <summary>
			/// Represents any video standard other than those represented by the previous constants in this enumeration.
			/// </summary>
			D3DKMDT_VSS_OTHER = 255,
		}
	}
}