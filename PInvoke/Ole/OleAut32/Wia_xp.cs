using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke;

public static partial class OleAut32
{
	/// <summary>
	/// Provides a quick means by which applications can look up the standard Windows Image Acquisition (WIA) property name from the WIA
	/// property ID (or vice versa). If the <c>propid</c> does not exist in this array, it is likely not a standard WIA property. Other
	/// ways to get the property name from the property ID include using the <c>IEnumSTATPROPSTG</c> retrieved by calling
	/// IWiaPropertyStorage::Enum on a particular item.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/ns-wia_xp-wia_propid_to_name typedef struct _WIA_PROPID_TO_NAME {
	// PROPID propid; LPOLESTR pszName; } WIA_PROPID_TO_NAME, *PWIA_PROPID_TO_NAME;
	[PInvokeData("wia_xp.h")]
	public static Dictionary<WIA_PROPID, string> WIA_PROPID_TO_NAME = new()
	{
		{ WIA_PROPID.WIA_DIP_BAUDRATE                                     , "BaudRate" },
		{ WIA_PROPID.WIA_DIP_DEV_DESC                                     , "Description" },
		{ WIA_PROPID.WIA_DIP_DEV_ID                                       , "Unique Device ID" },
		{ WIA_PROPID.WIA_DIP_DEV_NAME                                     , "Name" },
		{ WIA_PROPID.WIA_DIP_DEV_TYPE                                     , "Type" },
		{ WIA_PROPID.WIA_DIP_DRIVER_VERSION                               , "Driver Version" },
		{ WIA_PROPID.WIA_DIP_HW_CONFIG                                    , "Hardware Configuration" },
		{ WIA_PROPID.WIA_DIP_PNP_ID                                       , "PnP ID String" },
		{ WIA_PROPID.WIA_DIP_PORT_NAME                                    , "Port" },
		{ WIA_PROPID.WIA_DIP_REMOTE_DEV_ID                                , "Remote Device ID" },
		{ WIA_PROPID.WIA_DIP_SERVER_NAME                                  , "Server" },
		{ WIA_PROPID.WIA_DIP_STI_DRIVER_VERSION                           , "STI Driver Version" },
		{ WIA_PROPID.WIA_DIP_STI_GEN_CAPABILITIES                         , "STI Generic Capabilities" },
		{ WIA_PROPID.WIA_DIP_UI_CLSID                                     , "UI Class ID" },
		{ WIA_PROPID.WIA_DIP_VEND_DESC                                    , "Manufacturer" },
		{ WIA_PROPID.WIA_DIP_WIA_VERSION                                  , "WIA Version" },
		{ WIA_PROPID.WIA_DPA_CONNECT_STATUS                               , "Connect Status" },
		{ WIA_PROPID.WIA_DPA_DEVICE_TIME                                  , "Device Time" },
		{ WIA_PROPID.WIA_DPA_FIRMWARE_VERSION                             , "Firmware Version" },
		{ WIA_PROPID.WIA_DPC_ARTIST                                       , "Artist" },
		{ WIA_PROPID.WIA_DPC_BATTERY_STATUS                               , "Battery Status" },
		{ WIA_PROPID.WIA_DPC_BURST_INTERVAL                               , "Burst Interval" },
		{ WIA_PROPID.WIA_DPC_BURST_NUMBER                                 , "Burst Number" },
		{ WIA_PROPID.WIA_DPC_CAPTURE_DELAY                                , "Capture Delay" },
		{ WIA_PROPID.WIA_DPC_CAPTURE_MODE                                 , "Capture Mode" },
		{ WIA_PROPID.WIA_DPC_COMPRESSION_SETTING                          , "Compression Setting" },
		{ WIA_PROPID.WIA_DPC_CONTRAST                                     , "Contrast" },
		{ WIA_PROPID.WIA_DPC_COPYRIGHT_INFO                               , "Copyright Info" },
		{ WIA_PROPID.WIA_DPC_DIGITAL_ZOOM                                 , "Digital Zoom" },
		{ WIA_PROPID.WIA_DPC_DIMENSION                                    , "Dimension" },
		{ WIA_PROPID.WIA_DPC_EFFECT_MODE                                  , "Effect Mode" },
		{ WIA_PROPID.WIA_DPC_EXPOSURE_COMP                                , "Exposure Compensation" },
		{ WIA_PROPID.WIA_DPC_EXPOSURE_INDEX                               , "Exposure Index" },
		{ WIA_PROPID.WIA_DPC_EXPOSURE_METERING_MODE                       , "Exposure Metering Mode" },
		{ WIA_PROPID.WIA_DPC_EXPOSURE_MODE                                , "Exposure Mode" },
		{ WIA_PROPID.WIA_DPC_EXPOSURE_TIME                                , "Exposure Time" },
		{ WIA_PROPID.WIA_DPC_FLASH_MODE                                   , "Flash Mode" },
		{ WIA_PROPID.WIA_DPC_FNUMBER                                      , "F Number" },
		{ WIA_PROPID.WIA_DPC_FOCAL_LENGTH                                 , "Focus Length" },
		{ WIA_PROPID.WIA_DPC_FOCUS_DISTANCE                               , "Focus Distance" },
		{ WIA_PROPID.WIA_DPC_FOCUS_MANUAL_DIST                            , "Focus Manual Dist" },
		{ WIA_PROPID.WIA_DPC_FOCUS_METERING                               , "Focus Metering Mode" },
		{ WIA_PROPID.WIA_DPC_FOCUS_METERING_MODE                          , "Focus Metering Mode" },
		{ WIA_PROPID.WIA_DPC_FOCUS_MODE                                   , "Focus Mode" },
		{ WIA_PROPID.WIA_DPC_PAN_POSITION                                 , "Pan Position" },
		{ WIA_PROPID.WIA_DPC_PICT_HEIGHT                                  , "Picture Height" },
		{ WIA_PROPID.WIA_DPC_PICT_WIDTH                                   , "Picture Width" },
		{ WIA_PROPID.WIA_DPC_PICTURES_REMAINING                           , "Pictures Remaining" },
		{ WIA_PROPID.WIA_DPC_PICTURES_TAKEN                               , "Pictures Taken" },
		{ WIA_PROPID.WIA_DPC_POWER_MODE                                   , "Power Mode" },
		{ WIA_PROPID.WIA_DPC_RGB_GAIN                                     , "RGB Gain" },
		{ WIA_PROPID.WIA_DPC_SHARPNESS                                    , "Sharpness" },
		{ WIA_PROPID.WIA_DPC_THUMB_HEIGHT                                 , "Thumbnail Height" },
		{ WIA_PROPID.WIA_DPC_THUMB_WIDTH                                  , "Thumbnail Width" },
		{ WIA_PROPID.WIA_DPC_TILT_POSITION                                , "Tilt Position" },
		{ WIA_PROPID.WIA_DPC_TIMELAPSE_INTERVAL                           , "Timelapse Interval" },
		{ WIA_PROPID.WIA_DPC_TIMELAPSE_NUMBER                             , "Timelapse Number" },
		{ WIA_PROPID.WIA_DPC_TIMER_MODE                                   , "Timer Mode" },
		{ WIA_PROPID.WIA_DPC_TIMER_VALUE                                  , "Timer Value" },
		{ WIA_PROPID.WIA_DPC_UPLOAD_URL                                   , "Upload URL" },
		{ WIA_PROPID.WIA_DPC_WHITE_BALANCE                                , "White Balance" },
		{ WIA_PROPID.WIA_DPC_ZOOM_POSITION                                , "Zoom Position" },
		{ WIA_PROPID.WIA_DPF_MOUNT_POINT                                  , "Directory mount point" },
		{ WIA_PROPID.WIA_DPS_DEVICE_ID                                    , "Device ID" },
		{ WIA_PROPID.WIA_DPS_DITHER_PATTERN_DATA                          , "Dither Pattern Data" },
		{ WIA_PROPID.WIA_DPS_DITHER_SELECT                                , "Dither Select" },
		{ WIA_PROPID.WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES               , "Document Handling Capabilities" },
		{ WIA_PROPID.WIA_DPS_DOCUMENT_HANDLING_CAPACITY                   , "Document Handling Capacity" },
		{ WIA_PROPID.WIA_DPS_DOCUMENT_HANDLING_SELECT                     , "Document Handling Select" },
		{ WIA_PROPID.WIA_DPS_DOCUMENT_HANDLING_STATUS                     , "Document Handling Status" },
		{ WIA_PROPID.WIA_DPS_ENDORSER_CHARACTERS                          , "Endorser Characters" },
		{ WIA_PROPID.WIA_DPS_ENDORSER_STRING                              , "Endorser String" },
		{ WIA_PROPID.WIA_DPS_FILTER_SELECT                                , "Filter Select" },
		{ WIA_PROPID.WIA_DPS_GLOBAL_IDENTITY                              , "Global Identity" },
		{ WIA_PROPID.WIA_DPS_HORIZONTAL_BED_REGISTRATION                  , "Horizontal Bed Registration" },
		{ WIA_PROPID.WIA_DPS_HORIZONTAL_BED_SIZE                          , "Horizontal Bed Size" },
		{ WIA_PROPID.WIA_DPS_HORIZONTAL_SHEET_FEED_SIZE                   , "Horizontal Sheet Feed Size" },
		{ WIA_PROPID.WIA_DPS_MAX_SCAN_TIME                                , "Max Scan Time" },
		{ WIA_PROPID.WIA_DPS_MIN_HORIZONTAL_SHEET_FEED_SIZE               , "Minimum Horizontal Sheet Feed Size" },
		{ WIA_PROPID.WIA_DPS_MIN_VERTICAL_SHEET_FEED_SIZE                 , "Minimum Vertical Sheet Feed Size" },
		{ WIA_PROPID.WIA_DPS_OPTICAL_XRES                                 , "Horizontal Optical Resolution" },
		{ WIA_PROPID.WIA_DPS_OPTICAL_YRES                                 , "Vertical Optical Resolution" },
		{ WIA_PROPID.WIA_DPS_PAD_COLOR                                    , "Pad Color" },
		{ WIA_PROPID.WIA_DPS_PAGE_HEIGHT                                  , "Page Height" },
		{ WIA_PROPID.WIA_DPS_PAGE_SIZE                                    , "Page Size" },
		{ WIA_PROPID.WIA_DPS_PAGE_WIDTH                                   , "Page Width" },
		{ WIA_PROPID.WIA_DPS_PAGES                                        , "Pages" },
		{ WIA_PROPID.WIA_DPS_PLATEN_COLOR                                 , "Platen Color" },
		{ WIA_PROPID.WIA_DPS_PREVIEW                                      , "Preview" },
		{ WIA_PROPID.WIA_DPS_SCAN_AHEAD_PAGES                             , "Scan Ahead Pages" },
		{ WIA_PROPID.WIA_DPS_SCAN_AVAILABLE_ITEM                          , "Scan Available Item" },
		{ WIA_PROPID.WIA_DPS_SERVICE_ID                                   , "Service ID" },
		{ WIA_PROPID.WIA_DPS_SHEET_FEEDER_REGISTRATION                    , "Sheet Feeder Registration" },
		{ WIA_PROPID.WIA_DPS_SHOW_PREVIEW_CONTROL                         , "Show preview control" },
		{ WIA_PROPID.WIA_DPS_TRANSPARENCY                                 , "Transparency Adapter" },
		{ WIA_PROPID.WIA_DPS_TRANSPARENCY_CAPABILITIES                    , "Transparency Adapter Capabilities" },
		{ WIA_PROPID.WIA_DPS_TRANSPARENCY_SELECT                          , "Transparency Adapter Select" },
		{ WIA_PROPID.WIA_DPS_TRANSPARENCY_STATUS                          , "Transparency Adapter Status" },
		{ WIA_PROPID.WIA_DPS_USER_NAME                                    , "User Name" },
		{ WIA_PROPID.WIA_DPS_VERTICAL_BED_REGISTRATION                    , "Vertical Bed Registration" },
		{ WIA_PROPID.WIA_DPS_VERTICAL_BED_SIZE                            , "Vertical Bed Size" },
		{ WIA_PROPID.WIA_DPS_VERTICAL_SHEET_FEED_SIZE                     , "Vertical Sheet Feed Size" },
		{ WIA_PROPID.WIA_DPV_DSHOW_DEVICE_PATH                            , "Directshow Device Path" },
		{ WIA_PROPID.WIA_DPV_IMAGES_DIRECTORY                             , "Images Directory" },
		{ WIA_PROPID.WIA_DPV_LAST_PICTURE_TAKEN                           , "Last Picture Taken" },
		{ WIA_PROPID.WIA_IPA_ACCESS_RIGHTS                                , "Access Rights" },
		{ WIA_PROPID.WIA_IPA_APP_COLOR_MAPPING                            , "Application Applies Color Mapping" },
		{ WIA_PROPID.WIA_IPA_BITS_PER_CHANNEL                             , "Bits Per Channel" },
		{ WIA_PROPID.WIA_IPA_BUFFER_SIZE                                  , "Buffer Size" },
		{ WIA_PROPID.WIA_IPA_BYTES_PER_LINE                               , "Bytes Per Line" },
		{ WIA_PROPID.WIA_IPA_CHANNELS_PER_PIXEL                           , "Channels Per Pixel" },
		{ WIA_PROPID.WIA_IPA_COLOR_PROFILE                                , "Color Profiles" },
		{ WIA_PROPID.WIA_IPA_COMPRESSION                                  , "Compression" },
		{ WIA_PROPID.WIA_IPA_DATATYPE                                     , "Data Type" },
		{ WIA_PROPID.WIA_IPA_DEPTH                                        , "Bits Per Pixel" },
		{ WIA_PROPID.WIA_IPA_FILENAME_EXTENSION                           , "Filename extension" },
		{ WIA_PROPID.WIA_IPA_FORMAT                                       , "Format" },
		{ WIA_PROPID.WIA_IPA_FULL_ITEM_NAME                               , "Full Item Name" },
		{ WIA_PROPID.WIA_IPA_GAMMA_CURVES                                 , "Gamma Curves" },
		{ WIA_PROPID.WIA_IPA_ICM_PROFILE_NAME                             , "Color Profile Name" },
		{ WIA_PROPID.WIA_IPA_ITEM_CATEGORY                                , "Item Category" },
		{ WIA_PROPID.WIA_IPA_ITEM_FLAGS                                   , "Item Flags" },
		{ WIA_PROPID.WIA_IPA_ITEM_NAME                                    , "Item Name" },
		{ WIA_PROPID.WIA_IPA_ITEM_SIZE                                    , "Item Size" },
		{ WIA_PROPID.WIA_IPA_ITEM_TIME                                    , "Item Time Stamp" },
		{ WIA_PROPID.WIA_IPA_ITEMS_STORED                                 , "Items Stored" },
		{ WIA_PROPID.WIA_IPA_NUMBER_OF_LINES                              , "Number of Lines" },
		{ WIA_PROPID.WIA_IPA_PIXELS_PER_LINE                              , "Pixels Per Line" },
		{ WIA_PROPID.WIA_IPA_PLANAR                                       , "Planar" },
		{ WIA_PROPID.WIA_IPA_PREFERRED_FORMAT                             , "Preferred Format" },
		{ WIA_PROPID.WIA_IPA_PROP_STREAM_COMPAT_ID                        , "Stream Compatibility ID" },
		{ WIA_PROPID.WIA_IPA_RAW_BITS_PER_CHANNEL                         , "Raw Bits Per Channel" },
		{ WIA_PROPID.WIA_IPA_REGION_TYPE                                  , "Region Type" },
		{ WIA_PROPID.WIA_IPA_SUPPRESS_PROPERTY_PAGE                       , "Suppress a property page" },
		{ WIA_PROPID.WIA_IPA_TYMED                                        , "Media Type" },
		{ WIA_PROPID.WIA_IPA_UPLOAD_ITEM_SIZE                             , "Upload Item Size" },
		{ WIA_PROPID.WIA_IPC_AUDIO_AVAILABLE                              , "Audio Available" },
		{ WIA_PROPID.WIA_IPC_AUDIO_DATA                                   , "Audio Data" },
		{ WIA_PROPID.WIA_IPC_AUDIO_DATA_FORMAT                            , "Audio Format" },
		{ WIA_PROPID.WIA_IPC_NUM_PICT_PER_ROW                             , "Pictures per Row" },
		{ WIA_PROPID.WIA_IPC_SEQUENCE                                     , "Sequence Number" },
		{ WIA_PROPID.WIA_IPC_THUMB_HEIGHT                                 , "Thumbnail Height" },
		{ WIA_PROPID.WIA_IPC_THUMB_WIDTH                                  , "Thumbnail Width" },
		{ WIA_PROPID.WIA_IPC_THUMBNAIL                                    , "Thumbnail Data" },
		{ WIA_PROPID.WIA_IPC_TIMEDELAY                                    , "Time Delay" },
		{ WIA_PROPID.WIA_IPS_ALARM                                        , "Alarm" },
		{ WIA_PROPID.WIA_IPS_AUTO_CROP                                    , "Auto-Crop" },
		{ WIA_PROPID.WIA_IPS_BARCODE_READER                               , "Barcode Reader" },
		{ WIA_PROPID.WIA_IPS_BARCODE_SEARCH_DIRECTION                     , "Barcode Search Direction" },
		{ WIA_PROPID.WIA_IPS_BARCODE_SEARCH_TIMEOUT                       , "Barcode Search Timeout" },
		{ WIA_PROPID.WIA_IPS_BLANK_PAGES                                  , "Blank Pages" },
		{ WIA_PROPID.WIA_IPS_BLANK_PAGES_SENSITIVITY                      , "Blank Pages Sensitivity" },
		{ WIA_PROPID.WIA_IPS_BRIGHTNESS                                   , "Brightness" },
		{ WIA_PROPID.WIA_IPS_COLOR_DROP                                   , "Color Drop" },
		{ WIA_PROPID.WIA_IPS_COLOR_DROP_BLUE                              , "Color Drop Blue" },
		{ WIA_PROPID.WIA_IPS_COLOR_DROP_GREEN                             , "Color Drop Green" },
		{ WIA_PROPID.WIA_IPS_COLOR_DROP_MULTI                             , "Color Drop Multiple" },
		{ WIA_PROPID.WIA_IPS_COLOR_DROP_RED                               , "Color Drop Red" },
		{ WIA_PROPID.WIA_IPS_CONTRAST                                     , "Contrast" },
		{ WIA_PROPID.WIA_IPS_CUR_INTENT                                   , "Current Intent" },
		{ WIA_PROPID.WIA_IPS_DESKEW_X                                     , "DeskewX" },
		{ WIA_PROPID.WIA_IPS_DESKEW_Y                                     , "DeskewY" },
		{ WIA_PROPID.WIA_IPS_ENABLED_BARCODE_TYPES                        , "Enabled Barcode Types" },
		{ WIA_PROPID.WIA_IPS_ENABLED_PATCH_CODE_TYPES                     , "Enabled Path Code Types" },
		{ WIA_PROPID.WIA_IPS_FEEDER_CONTROL                               , "Feeder Control" },
		{ WIA_PROPID.WIA_IPS_FILM_NODE_NAME                               , "Film Node Name" },
		{ WIA_PROPID.WIA_IPS_INVERT                                       , "Invert" },
		{ WIA_PROPID.WIA_IPS_JOB_SEPARATORS                               , "Job Separators" },
		{ WIA_PROPID.WIA_IPS_LONG_DOCUMENT                                , "Long Document" },
		{ WIA_PROPID.WIA_IPS_MAX_HORIZONTAL_SIZE                          , "Maximum Horizontal Scan Size" },
		{ WIA_PROPID.WIA_IPS_MAX_VERTICAL_SIZE                            , "Maximum Vertical Scan Size" },
		{ WIA_PROPID.WIA_IPS_MAXIMUM_BARCODE_SEARCH_RETRIES               , "Barcode Search Retries" },
		{ WIA_PROPID.WIA_IPS_MAXIMUM_BARCODES_PER_PAGE                    , "Maximum Barcodes Per Page" },
		{ WIA_PROPID.WIA_IPS_MICR_READER                                  , "MICR Reader" },
		{ WIA_PROPID.WIA_IPS_MIN_HORIZONTAL_SIZE                          , "Minimum Horizontal Scan Size" },
		{ WIA_PROPID.WIA_IPS_MIN_VERTICAL_SIZE                            , "Minimum Vertical Scan Size" },
		{ WIA_PROPID.WIA_IPS_MIRROR                                       , "Mirror" },
		{ WIA_PROPID.WIA_IPS_MULTI_FEED                                   , "Multi-Feed" },
		{ WIA_PROPID.WIA_IPS_MULTI_FEED_DETECT_METHOD                     , "Multi-Feed Detection Method" },
		{ WIA_PROPID.WIA_IPS_MULTI_FEED_SENSITIVITY                       , "Multi-Feed Sensitivity" },
		{ WIA_PROPID.WIA_IPS_ORIENTATION                                  , "Orientation" },
		{ WIA_PROPID.WIA_IPS_OVER_SCAN                                    , "Overscan" },
		{ WIA_PROPID.WIA_IPS_OVER_SCAN_BOTTOM                             , "Overscan Bottom" },
		{ WIA_PROPID.WIA_IPS_OVER_SCAN_LEFT                               , "Overscan Left" },
		{ WIA_PROPID.WIA_IPS_OVER_SCAN_RIGHT                              , "Overscan Right" },
		{ WIA_PROPID.WIA_IPS_OVER_SCAN_TOP                                , "Overscan Top" },
		{ WIA_PROPID.WIA_IPS_PATCH_CODE_READER                            , "Patch Code Reader" },
		{ WIA_PROPID.WIA_IPS_PHOTOMETRIC_INTERP                           , "Photometric Interpretation" },
		{ WIA_PROPID.WIA_IPS_PREVIEW_TYPE                                 , "Preview Type" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER                             , "Printer/Endorser" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_CHARACTER_ROTATION          , "Printer/Endorser Character Rotation" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_COUNTER                     , "Printer/Endorser Counter" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_COUNTER_DIGITS              , "Printer/Endorser Counter Digits" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_FONT_TYPE                   , "Printer/Endorser Font Type" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS                    , "Printer/Endorser Graphics" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS_DOWNLOAD           , "Printer/Endorser Graphics Download" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_HEIGHT         , "Printer/Endorser Graphics Maximum Height" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_WIDTH          , "Printer/Endorser Graphics Maximum Width" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_HEIGHT         , "Printer/Endorser Graphics Minimum Height" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_WIDTH          , "Printer/Endorser Graphics Minimum Width" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS_POSITION           , "Printer/Endorser Graphics Position" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_GRAPHICS_UPLOAD             , "Printer/Endorser Graphics Upload" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_INK                         , "Printer/Endorser Ink" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_MAX_CHARACTERS              , "Printer/Endorser Maximum Characters" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_MAX_GRAPHICS                , "Printer/Endorser Maximum Graphics" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_NUM_LINES                   , "Printer/Endorser Lines" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_ORDER                       , "Printer/Endorser Order" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_PADDING                     , "Printer/Endorser Padding" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_STEP                        , "Printer/Endorser Step" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_STRING                      , "Printer/Endorser String" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_TEXT_DOWNLOAD               , "Printer/Endorser Text Download" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_TEXT_UPLOAD                 , "Printer/Endorser Text Upload" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_VALID_CHARACTERS            , "Printer/Endorser Valid Characters" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_VALID_FORMAT_SPECIFIERS     , "Printer/Endorser Valid Format Specifiers" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_XOFFSET                     , "Printer/Endorser Horizontal Offset" },
		{ WIA_PROPID.WIA_IPS_PRINTER_ENDORSER_YOFFSET                     , "Printer/Endorser Vertical Offset" },
		{ WIA_PROPID.WIA_IPS_ROTATION                                     , "Rotation" },
		{ WIA_PROPID.WIA_IPS_SCAN_AHEAD                                   , "Scan Ahead" },
		{ WIA_PROPID.WIA_IPS_SCAN_AHEAD_CAPACITY                          , "Scan Ahead Capacity" },
		{ WIA_PROPID.WIA_IPS_SEGMENTATION                                 , "Segmentation" },
		{ WIA_PROPID.WIA_IPS_SUPPORTED_BARCODE_TYPES                      , "Supported Barcode Types" },
		{ WIA_PROPID.WIA_IPS_SUPPORTED_PATCH_CODE_TYPES                   , "Supported Patch Code Types" },
		{ WIA_PROPID.WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION                 , "Supports Child Item Creation" },
		{ WIA_PROPID.WIA_IPS_THRESHOLD                                    , "Threshold" },
		{ WIA_PROPID.WIA_IPS_TRANSFER_CAPABILITIES                        , "Transfer Capabilities" },
		{ WIA_PROPID.WIA_IPS_WARM_UP_TIME                                 , "Lamp Warm up Time" },
		{ WIA_PROPID.WIA_IPS_XEXTENT                                      , "Horizontal Extent" },
		{ WIA_PROPID.WIA_IPS_XPOS                                         , "Horizontal Start Position" },
		{ WIA_PROPID.WIA_IPS_XRES                                         , "Horizontal Resolution" },
		{ WIA_PROPID.WIA_IPS_XSCALING                                     , "Horizontal Scaling" },
		{ WIA_PROPID.WIA_IPS_YEXTENT                                      , "Vertical Extent" },
		{ WIA_PROPID.WIA_IPS_YPOS                                         , "Vertical Start Position" },
		{ WIA_PROPID.WIA_IPS_YRES                                         , "Vertical Resolution" },
		{ WIA_PROPID.WIA_IPS_YSCALING                                     , "Vertical Scaling" },
	};

	/// <summary>IWiaDataCallback and IWiaMiniDrvCallBack message ID constants</summary>
	[PInvokeData("wiadef.h")]
	public enum IT_MSG
	{
		/// <summary>The application is receiving a header prior to receiving the actual data.</summary>
		IT_MSG_DATA_HEADER = 0x0001,

		/// <summary>The WIA system is transferring data to the application.</summary>
		IT_MSG_DATA = 0x0002,

		/// <summary>This invocation of the callback is sending only status information.</summary>
		IT_MSG_STATUS = 0x0003,

		/// <summary>The data transfer is complete.</summary>
		IT_MSG_TERMINATION = 0x0004,

		/// <summary>The data transfer is beginning a new page.</summary>
		IT_MSG_NEW_PAGE = 0x0005,

		/// <summary>The WIA system is transferring preview data to the application.</summary>
		IT_MSG_FILE_PREVIEW_DATA = 0x0006,

		/// <summary>The application is receiving a header prior to receiving the actual preview data.</summary>
		IT_MSG_FILE_PREVIEW_DATA_HEADER = 0x0007,

		/// <summary>Windows Vista or later. Status at the device has changed.</summary>
		IT_MSG_DEVICE_STATUS = 8
	}

	/// <summary>IWiaDataCallback and IWiaMiniDrvCallBack status flag constants</summary>
	[PInvokeData("wiadef.h")]
	[Flags]
	public enum IT_STATUS
	{
		/// <summary>Data is currently being transferred from the WIA device.</summary>
		IT_STATUS_TRANSFER_FROM_DEVICE = 0x0001,

		/// <summary>Data is currently being processed.</summary>
		IT_STATUS_PROCESSING_DATA = 0x0002,

		/// <summary>Data is currently being transferred to the client's data buffer.</summary>
		IT_STATUS_TRANSFER_TO_CLIENT = 0x0004,

		/// <summary>Mask</summary>
		IT_STATUS_MASK = 0x0007,
	}

	/// <summary>WIA property identifiers.</summary>
	[PInvokeData("wiadef.h")]
	public enum WIA_PROPID : uint
	{
		/// <summary>Unique Device ID</summary>
		WIA_DIP_DEV_ID = 2,

		/// <summary>Manufacturer</summary>
		WIA_DIP_VEND_DESC = 3,

		/// <summary>Description</summary>
		WIA_DIP_DEV_DESC = 4,

		/// <summary>Type</summary>
		WIA_DIP_DEV_TYPE = 5,

		/// <summary>Port</summary>
		WIA_DIP_PORT_NAME = 6,

		/// <summary>Name</summary>
		WIA_DIP_DEV_NAME = 7,

		/// <summary>Server</summary>
		WIA_DIP_SERVER_NAME = 8,

		/// <summary>Remote Device ID</summary>
		WIA_DIP_REMOTE_DEV_ID = 9,

		/// <summary>UI Class ID</summary>
		WIA_DIP_UI_CLSID = 10,

		/// <summary>Hardware Configuration</summary>
		WIA_DIP_HW_CONFIG = 11,

		/// <summary>BaudRate</summary>
		WIA_DIP_BAUDRATE = 12,

		/// <summary>STI Generic Capabilities</summary>
		WIA_DIP_STI_GEN_CAPABILITIES = 13,

		/// <summary>WIA Version</summary>
		WIA_DIP_WIA_VERSION = 14,

		/// <summary>Driver Version</summary>
		WIA_DIP_DRIVER_VERSION = 15,

		/// <summary>PnP ID String</summary>
		WIA_DIP_PNP_ID = 16,

		/// <summary>STI Driver Version</summary>
		WIA_DIP_STI_DRIVER_VERSION = 17,

		/// <summary>Firmware Version</summary>
		WIA_DPA_FIRMWARE_VERSION = 1026,

		/// <summary>Connect Status</summary>
		WIA_DPA_CONNECT_STATUS = 1027,

		/// <summary>Device Time</summary>
		WIA_DPA_DEVICE_TIME = 1028,

		/// <summary>Pictures Taken</summary>
		WIA_DPC_PICTURES_TAKEN = 2050,

		/// <summary>Pictures Remaining</summary>
		WIA_DPC_PICTURES_REMAINING = 2051,

		/// <summary>Exposure Mode</summary>
		WIA_DPC_EXPOSURE_MODE = 2052,

		/// <summary>Exposure Compensation</summary>
		WIA_DPC_EXPOSURE_COMP = 2053,

		/// <summary>Exposure Time</summary>
		WIA_DPC_EXPOSURE_TIME = 2054,

		/// <summary>F Number</summary>
		WIA_DPC_FNUMBER = 2055,

		/// <summary>Flash Mode</summary>
		WIA_DPC_FLASH_MODE = 2056,

		/// <summary>Focus Mode</summary>
		WIA_DPC_FOCUS_MODE = 2057,

		/// <summary>Focus Manual Dist</summary>
		WIA_DPC_FOCUS_MANUAL_DIST = 2058,

		/// <summary>Zoom Position</summary>
		WIA_DPC_ZOOM_POSITION = 2059,

		/// <summary>Pan Position</summary>
		WIA_DPC_PAN_POSITION = 2060,

		/// <summary>Tilt Position</summary>
		WIA_DPC_TILT_POSITION = 2061,

		/// <summary>Timer Mode</summary>
		WIA_DPC_TIMER_MODE = 2062,

		/// <summary>Timer Value</summary>
		WIA_DPC_TIMER_VALUE = 2063,

		/// <summary>Power Mode</summary>
		WIA_DPC_POWER_MODE = 2064,

		/// <summary>Battery Status</summary>
		WIA_DPC_BATTERY_STATUS = 2065,

		/// <summary>Thumbnail Width</summary>
		WIA_DPC_THUMB_WIDTH = 2066,

		/// <summary>Thumbnail Height</summary>
		WIA_DPC_THUMB_HEIGHT = 2067,

		/// <summary>Picture Width</summary>
		WIA_DPC_PICT_WIDTH = 2068,

		/// <summary>Picture Height</summary>
		WIA_DPC_PICT_HEIGHT = 2069,

		/// <summary>Dimension</summary>
		WIA_DPC_DIMENSION = 2070,

		/// <summary>Compression Setting</summary>
		WIA_DPC_COMPRESSION_SETTING = 2071,

		/// <summary>Focus Metering Mode</summary>
		WIA_DPC_FOCUS_METERING = 2072,

		/// <summary>Timelapse Interval</summary>
		WIA_DPC_TIMELAPSE_INTERVAL = 2073,

		/// <summary>Timelapse Number</summary>
		WIA_DPC_TIMELAPSE_NUMBER = 2074,

		/// <summary>Burst Interval</summary>
		WIA_DPC_BURST_INTERVAL = 2075,

		/// <summary>Burst Number</summary>
		WIA_DPC_BURST_NUMBER = 2076,

		/// <summary>Effect Mode</summary>
		WIA_DPC_EFFECT_MODE = 2077,

		/// <summary>Digital Zoom</summary>
		WIA_DPC_DIGITAL_ZOOM = 2078,

		/// <summary>Sharpness</summary>
		WIA_DPC_SHARPNESS = 2079,

		/// <summary>Contrast</summary>
		WIA_DPC_CONTRAST = 2080,

		/// <summary>Capture Mode</summary>
		WIA_DPC_CAPTURE_MODE = 2081,

		/// <summary>Capture Delay</summary>
		WIA_DPC_CAPTURE_DELAY = 2082,

		/// <summary>Exposure Index</summary>
		WIA_DPC_EXPOSURE_INDEX = 2083,

		/// <summary>Exposure Metering Mode</summary>
		WIA_DPC_EXPOSURE_METERING_MODE = 2084,

		/// <summary>Focus Metering Mode</summary>
		WIA_DPC_FOCUS_METERING_MODE = 2085,

		/// <summary>Focus Distance</summary>
		WIA_DPC_FOCUS_DISTANCE = 2086,

		/// <summary>Focus Length</summary>
		WIA_DPC_FOCAL_LENGTH = 2087,

		/// <summary>RGB Gain</summary>
		WIA_DPC_RGB_GAIN = 2088,

		/// <summary>White Balance</summary>
		WIA_DPC_WHITE_BALANCE = 2089,

		/// <summary>Upload URL</summary>
		WIA_DPC_UPLOAD_URL = 2090,

		/// <summary>Artist</summary>
		WIA_DPC_ARTIST = 2091,

		/// <summary>Copyright Info</summary>
		WIA_DPC_COPYRIGHT_INFO = 2092,

		/// <summary>Horizontal Bed Size</summary>
		WIA_DPS_HORIZONTAL_BED_SIZE = 3074,

		/// <summary>Vertical Bed Size</summary>
		WIA_DPS_VERTICAL_BED_SIZE = 3075,

		/// <summary>Horizontal Sheet Feed Size</summary>
		WIA_DPS_HORIZONTAL_SHEET_FEED_SIZE = 3076,

		/// <summary>Vertical Sheet Feed Size</summary>
		WIA_DPS_VERTICAL_SHEET_FEED_SIZE = 3077,

		/// <summary>Sheet Feeder Registration</summary>
		WIA_DPS_SHEET_FEEDER_REGISTRATION = 3078,

		/// <summary>Horizontal Bed Registration</summary>
		WIA_DPS_HORIZONTAL_BED_REGISTRATION = 3079,

		/// <summary>Vertical Bed Registration</summary>
		WIA_DPS_VERTICAL_BED_REGISTRATION = 3080,

		/// <summary>Platen Color</summary>
		WIA_DPS_PLATEN_COLOR = 3081,

		/// <summary>Pad Color</summary>
		WIA_DPS_PAD_COLOR = 3082,

		/// <summary>Filter Select</summary>
		WIA_DPS_FILTER_SELECT = 3083,

		/// <summary>Dither Select</summary>
		WIA_DPS_DITHER_SELECT = 3084,

		/// <summary>Dither Pattern Data</summary>
		WIA_DPS_DITHER_PATTERN_DATA = 3085,

		/// <summary>Document Handling Capabilities</summary>
		WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES = 3086,

		/// <summary>Document Handling Status</summary>
		WIA_DPS_DOCUMENT_HANDLING_STATUS = 3087,

		/// <summary>Document Handling Select</summary>
		WIA_DPS_DOCUMENT_HANDLING_SELECT = 3088,

		/// <summary>Document Handling Capacity</summary>
		WIA_DPS_DOCUMENT_HANDLING_CAPACITY = 3089,

		/// <summary>Horizontal Optical Resolution</summary>
		WIA_DPS_OPTICAL_XRES = 3090,

		/// <summary>Vertical Optical Resolution</summary>
		WIA_DPS_OPTICAL_YRES = 3091,

		/// <summary>Endorser Characters</summary>
		WIA_DPS_ENDORSER_CHARACTERS = 3092,

		/// <summary>Endorser String</summary>
		WIA_DPS_ENDORSER_STRING = 3093,

		/// <summary>Scan Ahead Pages</summary>
		WIA_DPS_SCAN_AHEAD_PAGES = 3094,

		/// <summary>Max Scan Time</summary>
		WIA_DPS_MAX_SCAN_TIME = 3095,

		/// <summary>Pages</summary>
		WIA_DPS_PAGES = 3096,

		/// <summary>Page Size</summary>
		WIA_DPS_PAGE_SIZE = 3097,

		/// <summary>Page Width</summary>
		WIA_DPS_PAGE_WIDTH = 3098,

		/// <summary>Page Height</summary>
		WIA_DPS_PAGE_HEIGHT = 3099,

		/// <summary>Preview</summary>
		WIA_DPS_PREVIEW = 3100,

		/// <summary>Transparency Adapter</summary>
		WIA_DPS_TRANSPARENCY = 3101,

		/// <summary>Transparency Adapter Select</summary>
		WIA_DPS_TRANSPARENCY_SELECT = 3102,

		/// <summary>Show preview control</summary>
		WIA_DPS_SHOW_PREVIEW_CONTROL = 3103,

		/// <summary>Minimum Horizontal Sheet Feed Size</summary>
		WIA_DPS_MIN_HORIZONTAL_SHEET_FEED_SIZE = 3104,

		/// <summary>Minimum Vertical Sheet Feed Size</summary>
		WIA_DPS_MIN_VERTICAL_SHEET_FEED_SIZE = 3105,

		/// <summary>Transparency Adapter Capabilities</summary>
		WIA_DPS_TRANSPARENCY_CAPABILITIES = 3106,

		/// <summary>Transparency Adapter Status</summary>
		WIA_DPS_TRANSPARENCY_STATUS = 3107,

		/// <summary>Directory mount point</summary>
		WIA_DPF_MOUNT_POINT = 3330,

		/// <summary>Last Picture Taken</summary>
		WIA_DPV_LAST_PICTURE_TAKEN = 3586,

		/// <summary>Images Directory</summary>
		WIA_DPV_IMAGES_DIRECTORY = 3587,

		/// <summary>Directshow Device Path</summary>
		WIA_DPV_DSHOW_DEVICE_PATH = 3588,

		/// <summary>Item Name</summary>
		WIA_IPA_ITEM_NAME = 4098,

		/// <summary>Full Item Name</summary>
		WIA_IPA_FULL_ITEM_NAME = 4099,

		/// <summary>Item Time Stamp</summary>
		WIA_IPA_ITEM_TIME = 4100,

		/// <summary>Item Flags</summary>
		WIA_IPA_ITEM_FLAGS = 4101,

		/// <summary>Access Rights</summary>
		WIA_IPA_ACCESS_RIGHTS = 4102,

		/// <summary>Data Type</summary>
		WIA_IPA_DATATYPE = 4103,

		/// <summary>Bits Per Pixel</summary>
		WIA_IPA_DEPTH = 4104,

		/// <summary>Preferred Format</summary>
		WIA_IPA_PREFERRED_FORMAT = 4105,

		/// <summary>Format</summary>
		WIA_IPA_FORMAT = 4106,

		/// <summary>Compression</summary>
		WIA_IPA_COMPRESSION = 4107,

		/// <summary>Media Type</summary>
		WIA_IPA_TYMED = 4108,

		/// <summary>Channels Per Pixel</summary>
		WIA_IPA_CHANNELS_PER_PIXEL = 4109,

		/// <summary>Bits Per Channel</summary>
		WIA_IPA_BITS_PER_CHANNEL = 4110,

		/// <summary>Planar</summary>
		WIA_IPA_PLANAR = 4111,

		/// <summary>Pixels Per Line</summary>
		WIA_IPA_PIXELS_PER_LINE = 4112,

		/// <summary>Bytes Per Line</summary>
		WIA_IPA_BYTES_PER_LINE = 4113,

		/// <summary>Number of Lines</summary>
		WIA_IPA_NUMBER_OF_LINES = 4114,

		/// <summary>Gamma Curves</summary>
		WIA_IPA_GAMMA_CURVES = 4115,

		/// <summary>Item Size</summary>
		WIA_IPA_ITEM_SIZE = 4116,

		/// <summary>Color Profiles</summary>
		WIA_IPA_COLOR_PROFILE = 4117,

		/// <summary>Buffer Size</summary>
		WIA_IPA_MIN_BUFFER_SIZE = 4118,

		/// <summary>Buffer Size</summary>
		WIA_IPA_BUFFER_SIZE = 4118,

		/// <summary>Region Type</summary>
		WIA_IPA_REGION_TYPE = 4119,

		/// <summary>Color Profile Name</summary>
		WIA_IPA_ICM_PROFILE_NAME = 4120,

		/// <summary>Application Applies Color Mapping</summary>
		WIA_IPA_APP_COLOR_MAPPING = 4121,

		/// <summary>Stream Compatibility ID</summary>
		WIA_IPA_PROP_STREAM_COMPAT_ID = 4122,

		/// <summary>Filename extension</summary>
		WIA_IPA_FILENAME_EXTENSION = 4123,

		/// <summary>Suppress a property page</summary>
		WIA_IPA_SUPPRESS_PROPERTY_PAGE = 4124,

		/// <summary>Thumbnail Data</summary>
		WIA_IPC_THUMBNAIL = 5122,

		/// <summary>Thumbnail Width</summary>
		WIA_IPC_THUMB_WIDTH = 5123,

		/// <summary>Thumbnail Height</summary>
		WIA_IPC_THUMB_HEIGHT = 5124,

		/// <summary>Audio Available</summary>
		WIA_IPC_AUDIO_AVAILABLE = 5125,

		/// <summary>Audio Format</summary>
		WIA_IPC_AUDIO_DATA_FORMAT = 5126,

		/// <summary>Audio Data</summary>
		WIA_IPC_AUDIO_DATA = 5127,

		/// <summary>Pictures per Row</summary>
		WIA_IPC_NUM_PICT_PER_ROW = 5128,

		/// <summary>Sequence Number</summary>
		WIA_IPC_SEQUENCE = 5129,

		/// <summary>Time Delay</summary>
		WIA_IPC_TIMEDELAY = 5130,

		/// <summary>Current Intent</summary>
		WIA_IPS_CUR_INTENT = 6146,

		/// <summary>Horizontal Resolution</summary>
		WIA_IPS_XRES = 6147,

		/// <summary>Vertical Resolution</summary>
		WIA_IPS_YRES = 6148,

		/// <summary>Horizontal Start Position</summary>
		WIA_IPS_XPOS = 6149,

		/// <summary>Vertical Start Position</summary>
		WIA_IPS_YPOS = 6150,

		/// <summary>Horizontal Extent</summary>
		WIA_IPS_XEXTENT = 6151,

		/// <summary>Vertical Extent</summary>
		WIA_IPS_YEXTENT = 6152,

		/// <summary>Photometric Interpretation</summary>
		WIA_IPS_PHOTOMETRIC_INTERP = 6153,

		/// <summary>Brightness</summary>
		WIA_IPS_BRIGHTNESS = 6154,

		/// <summary>Contrast</summary>
		WIA_IPS_CONTRAST = 6155,

		/// <summary>Orientation</summary>
		WIA_IPS_ORIENTATION = 6156,

		/// <summary>Rotation</summary>
		WIA_IPS_ROTATION = 6157,

		/// <summary>Mirror</summary>
		WIA_IPS_MIRROR = 6158,

		/// <summary>Threshold</summary>
		WIA_IPS_THRESHOLD = 6159,

		/// <summary>Invert</summary>
		WIA_IPS_INVERT = 6160,

		/// <summary>Lamp Warm up Time</summary>
		WIA_IPS_WARM_UP_TIME = 6161,

		/// <summary>User Name</summary>
		WIA_DPS_USER_NAME = 3112,

		/// <summary>Service ID</summary>
		WIA_DPS_SERVICE_ID = 3113,

		/// <summary>Device ID</summary>
		WIA_DPS_DEVICE_ID = 3114,

		/// <summary>Global Identity</summary>
		WIA_DPS_GLOBAL_IDENTITY = 3115,

		/// <summary>Scan Available Item</summary>
		WIA_DPS_SCAN_AVAILABLE_ITEM = 3116,

		/// <summary>DeskewX</summary>
		WIA_IPS_DESKEW_X = 6162,

		/// <summary>DeskewY</summary>
		WIA_IPS_DESKEW_Y = 6163,

		/// <summary>Segmentation</summary>
		WIA_IPS_SEGMENTATION = 6164,

		/// <summary>Maximum Horizontal Scan Size</summary>
		WIA_IPS_MAX_HORIZONTAL_SIZE = 6165,

		/// <summary>Maximum Vertical Scan Size</summary>
		WIA_IPS_MAX_VERTICAL_SIZE = 6166,

		/// <summary>Minimum Horizontal Scan Size</summary>
		WIA_IPS_MIN_HORIZONTAL_SIZE = 6167,

		/// <summary>Minimum Vertical Scan Size</summary>
		WIA_IPS_MIN_VERTICAL_SIZE = 6168,

		/// <summary>Transfer Capabilities</summary>
		WIA_IPS_TRANSFER_CAPABILITIES = 6169,

		/// <summary>Sheet Feeder Registration</summary>
		WIA_IPS_SHEET_FEEDER_REGISTRATION = 3078,

		/// <summary>Document Handling Select</summary>
		WIA_IPS_DOCUMENT_HANDLING_SELECT = 3088,

		/// <summary>Horizontal Optical Resolution</summary>
		WIA_IPS_OPTICAL_XRES = 3090,

		/// <summary>Vertical Optical Resolution</summary>
		WIA_IPS_OPTICAL_YRES = 3091,

		/// <summary>Pages</summary>
		WIA_IPS_PAGES = 3096,

		/// <summary>Page Size</summary>
		WIA_IPS_PAGE_SIZE = 3097,

		/// <summary>Page Width</summary>
		WIA_IPS_PAGE_WIDTH = 3098,

		/// <summary>Page Height</summary>
		WIA_IPS_PAGE_HEIGHT = 3099,

		/// <summary>Preview</summary>
		WIA_IPS_PREVIEW = 3100,

		/// <summary>Show preview control</summary>
		WIA_IPS_SHOW_PREVIEW_CONTROL = 3103,

		/// <summary>Film Scan Mode</summary>
		WIA_IPS_FILM_SCAN_MODE = 3104,

		/// <summary>Lamp</summary>
		WIA_IPS_LAMP = 3105,

		/// <summary>Lamp Auto Off</summary>
		WIA_IPS_LAMP_AUTO_OFF = 3106,

		/// <summary>Automatic Deskew</summary>
		WIA_IPS_AUTO_DESKEW = 3107,

		/// <summary>Supports Child Item Creation</summary>
		WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION = 3108,

		/// <summary>Horizontal Scaling</summary>
		WIA_IPS_XSCALING = 3109,

		/// <summary>Vertical Scaling</summary>
		WIA_IPS_YSCALING = 3110,

		/// <summary>Preview Type</summary>
		WIA_IPS_PREVIEW_TYPE = 3111,

		/// <summary>Item Category</summary>
		WIA_IPA_ITEM_CATEGORY = 4125,

		/// <summary>Upload Item Size</summary>
		WIA_IPA_UPLOAD_ITEM_SIZE = 4126,

		/// <summary>Items Stored</summary>
		WIA_IPA_ITEMS_STORED = 4127,

		/// <summary>Raw Bits Per Channel</summary>
		WIA_IPA_RAW_BITS_PER_CHANNEL = 4128,

		/// <summary>Film Node Name</summary>
		WIA_IPS_FILM_NODE_NAME = 4129,

		/// <summary>Printer/Endorser</summary>
		WIA_IPS_PRINTER_ENDORSER = 4130,

		/// <summary>Printer/Endorser Order</summary>
		WIA_IPS_PRINTER_ENDORSER_ORDER = 4131,

		/// <summary>Printer/Endorser Counter</summary>
		WIA_IPS_PRINTER_ENDORSER_COUNTER = 4132,

		/// <summary>Printer/Endorser Step</summary>
		WIA_IPS_PRINTER_ENDORSER_STEP = 4133,

		/// <summary>Printer/Endorser Horizontal Offset</summary>
		WIA_IPS_PRINTER_ENDORSER_XOFFSET = 4134,

		/// <summary>Printer/Endorser Vertical Offset</summary>
		WIA_IPS_PRINTER_ENDORSER_YOFFSET = 4135,

		/// <summary>Printer/Endorser Lines</summary>
		WIA_IPS_PRINTER_ENDORSER_NUM_LINES = 4136,

		/// <summary>Printer/Endorser String</summary>
		WIA_IPS_PRINTER_ENDORSER_STRING = 4137,

		/// <summary>Printer/Endorser Valid Characters</summary>
		WIA_IPS_PRINTER_ENDORSER_VALID_CHARACTERS = 4138,

		/// <summary>Printer/Endorser Valid Format Specifiers</summary>
		WIA_IPS_PRINTER_ENDORSER_VALID_FORMAT_SPECIFIERS = 4139,

		/// <summary>Printer/Endorser Text Upload</summary>
		WIA_IPS_PRINTER_ENDORSER_TEXT_UPLOAD = 4140,

		/// <summary>Printer/Endorser Text Download</summary>
		WIA_IPS_PRINTER_ENDORSER_TEXT_DOWNLOAD = 4141,

		/// <summary>Printer/Endorser Graphics</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS = 4142,

		/// <summary>Printer/Endorser Graphics Position</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS_POSITION = 4143,

		/// <summary>Printer/Endorser Graphics Minimum Width</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_WIDTH = 4144,

		/// <summary>Printer/Endorser Graphics Maximum Width</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_WIDTH = 4145,

		/// <summary>Printer/Endorser Graphics Minimum Height</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_HEIGHT = 4146,

		/// <summary>Printer/Endorser Graphics Maximum Height</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_HEIGHT = 4147,

		/// <summary>Printer/Endorser Graphics Upload</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS_UPLOAD = 4148,

		/// <summary>Printer/Endorser Graphics Download</summary>
		WIA_IPS_PRINTER_ENDORSER_GRAPHICS_DOWNLOAD = 4149,

		/// <summary>Barcode Reader</summary>
		WIA_IPS_BARCODE_READER = 4150,

		/// <summary>Maximum Barcodes Per Page</summary>
		WIA_IPS_MAXIMUM_BARCODES_PER_PAGE = 4151,

		/// <summary>Barcode Search Direction</summary>
		WIA_IPS_BARCODE_SEARCH_DIRECTION = 4152,

		/// <summary>Barcode Search Retries</summary>
		WIA_IPS_MAXIMUM_BARCODE_SEARCH_RETRIES = 4153,

		/// <summary>Barcode Search Timeout</summary>
		WIA_IPS_BARCODE_SEARCH_TIMEOUT = 4154,

		/// <summary>Supported Barcode Types</summary>
		WIA_IPS_SUPPORTED_BARCODE_TYPES = 4155,

		/// <summary>Enabled Barcode Types</summary>
		WIA_IPS_ENABLED_BARCODE_TYPES = 4156,

		/// <summary>Patch Code Reader</summary>
		WIA_IPS_PATCH_CODE_READER = 4157,

		/// <summary>Supported Patch Code Types</summary>
		WIA_IPS_SUPPORTED_PATCH_CODE_TYPES = 4162,

		/// <summary>Enabled Path Code Types</summary>
		WIA_IPS_ENABLED_PATCH_CODE_TYPES = 4163,

		/// <summary>MICR Reader</summary>
		WIA_IPS_MICR_READER = 4164,

		/// <summary>Job Separators</summary>
		WIA_IPS_JOB_SEPARATORS = 4165,

		/// <summary>Long Document</summary>
		WIA_IPS_LONG_DOCUMENT = 4166,

		/// <summary>Blank Pages</summary>
		WIA_IPS_BLANK_PAGES = 4167,

		/// <summary>Multi-Feed</summary>
		WIA_IPS_MULTI_FEED = 4168,

		/// <summary>Multi-Feed Sensitivity</summary>
		WIA_IPS_MULTI_FEED_SENSITIVITY = 4169,

		/// <summary>Auto-Crop</summary>
		WIA_IPS_AUTO_CROP = 4170,

		/// <summary>Overscan</summary>
		WIA_IPS_OVER_SCAN = 4171,

		/// <summary>Overscan Left</summary>
		WIA_IPS_OVER_SCAN_LEFT = 4172,

		/// <summary>Overscan Right</summary>
		WIA_IPS_OVER_SCAN_RIGHT = 4173,

		/// <summary>Overscan Top</summary>
		WIA_IPS_OVER_SCAN_TOP = 4174,

		/// <summary>Overscan Bottom</summary>
		WIA_IPS_OVER_SCAN_BOTTOM = 4175,

		/// <summary>Color Drop</summary>
		WIA_IPS_COLOR_DROP = 4176,

		/// <summary>Color Drop Red</summary>
		WIA_IPS_COLOR_DROP_RED = 4177,

		/// <summary>Color Drop Green</summary>
		WIA_IPS_COLOR_DROP_GREEN = 4178,

		/// <summary>Color Drop Blue</summary>
		WIA_IPS_COLOR_DROP_BLUE = 4179,

		/// <summary>Scan Ahead</summary>
		WIA_IPS_SCAN_AHEAD = 4180,

		/// <summary>Scan Ahead Capacity</summary>
		WIA_IPS_SCAN_AHEAD_CAPACITY = 4181,

		/// <summary>Feeder Control</summary>
		WIA_IPS_FEEDER_CONTROL = 4182,

		/// <summary>Printer/Endorser Padding</summary>
		WIA_IPS_PRINTER_ENDORSER_PADDING = 4183,

		/// <summary>Printer/Endorser Font Type</summary>
		WIA_IPS_PRINTER_ENDORSER_FONT_TYPE = 4184,

		/// <summary>Alarm</summary>
		WIA_IPS_ALARM = 4185,

		/// <summary>Printer/Endorser Ink</summary>
		WIA_IPS_PRINTER_ENDORSER_INK = 4186,

		/// <summary>Printer/Endorser Character Rotation</summary>
		WIA_IPS_PRINTER_ENDORSER_CHARACTER_ROTATION = 4187,

		/// <summary>Printer/Endorser Maximum Characters</summary>
		WIA_IPS_PRINTER_ENDORSER_MAX_CHARACTERS = 4188,

		/// <summary>Printer/Endorser Maximum Graphics</summary>
		WIA_IPS_PRINTER_ENDORSER_MAX_GRAPHICS = 4189,

		/// <summary>Printer/Endorser Counter Digits</summary>
		WIA_IPS_PRINTER_ENDORSER_COUNTER_DIGITS = 4190,

		/// <summary>Color Drop Multiple</summary>
		WIA_IPS_COLOR_DROP_MULTI = 4191,

		/// <summary>Blank Pages Sensitivity</summary>
		WIA_IPS_BLANK_PAGES_SENSITIVITY = 4192,

		/// <summary>Multi-Feed Detection Method</summary>
		WIA_IPS_MULTI_FEED_DETECT_METHOD = 4193,
	}

	/// <summary>Selects the type of capabilities to enumerate in IWiaItem.EnumDeviceCapabilities.</summary>
	[PInvokeData("wiadef.h")]
	public enum WiaDevCap
	{
		/// <summary>Enumerate device commands.</summary>
		WIA_DEVICE_COMMANDS = 1,

		/// <summary>Enumerate device events.</summary>
		WIA_DEVICE_EVENTS = 2
	}

	/// <summary>Options for IWiaItem.DeviceDlg.</summary>
	[PInvokeData("wiadef.h")]
	[Flags]
	public enum WiaDevDlg
	{
		/// <summary>Restrict image selection to a single image in the device image acquisition dialog box.</summary>
		WIA_DEVICE_DIALOG_SINGLE_IMAGE = 0x00000002,

		/// <summary>
		/// Use the system UI, if available, rather than the vendor-supplied UI. If the system UI is not available, the vendor UI is
		/// used. If neither UI is available, the function returns E_NOTIMPL.
		/// </summary>
		WIA_DEVICE_DIALOG_USE_COMMON_UI = 0x00000004,
	}

	/// <summary>Image Intent Constants.</summary>
	[PInvokeData("wiadef.h")]
	[Flags]
	public enum WiaImageIntent
	{
		/// <summary/>
		WIA_INTENT_NONE = 0,

		/// <summary>Preset properties for color content.</summary>
		WIA_INTENT_IMAGE_TYPE_COLOR = 0x00000001,

		/// <summary>Preset properties for grayscale content.</summary>
		WIA_INTENT_IMAGE_TYPE_GRAYSCALE = 0x00000002,

		/// <summary>Preset properties for text content.</summary>
		WIA_INTENT_IMAGE_TYPE_TEXT = 0x00000004,

		/// <summary>Preset properties to minimize image size.</summary>
		WIA_INTENT_MINIMIZE_SIZE = 0x00010000,

		/// <summary>Preset properties to maximize image quality.</summary>
		WIA_INTENT_MAXIMIZE_QUALITY = 0x00020000,

		/// <summary>Specifies the best quality preview.</summary>
		WIA_INTENT_BEST_PREVIEW = 0x00040000,
	}

	/// <summary>Specify the Windows Image Acquisition (WIA) item type.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/wia/-wia-wia-item-type-flags
	[PInvokeData("wiadef.h", MSDNShortId = "7961f692-088a-4f3b-84e9-5fabb0373c3c")]
	public enum WiaItemType : uint
	{
		/// <summary>The item is uninitialized or has been deleted.</summary>
		WiaItemTypeFree = 0x00000000,

		/// <summary>The item is an image file. Only valid for items that also have the WiaItemTypeFile attribute.</summary>
		WiaItemTypeImage = 0x00000001,

		/// <summary>The item is a file.</summary>
		WiaItemTypeFile = 0x00000002,

		/// <summary>The item is a folder.</summary>
		WiaItemTypeFolder = 0x00000004,

		/// <summary>
		/// Identifies the root item in the device's tree of item objects. This constant is supported only by Windows Vista and later.
		/// </summary>
		WiaItemTypeRoot = 0x00000008,

		/// <summary>This item supports the IWiaItem::AnalyzeItem method. This constant is not supported by Windows Vista and later.</summary>
		WiaItemTypeAnalyze = 0x00000010,

		/// <summary>The item is an audio file. Only valid for items that also have the WiaItemTypeFile attribute.</summary>
		WiaItemTypeAudio = 0x00000020,

		/// <summary>The item represents a connected device.</summary>
		WiaItemTypeDevice = 0x00000040,

		/// <summary>The item is marked as deleted from the tree.</summary>
		WiaItemTypeDeleted = 0x00000080,

		/// <summary>The item represents a disconnected device.</summary>
		WiaItemTypeDisconnected = 0x00000100,

		/// <summary>The item represents a horizontal panoramic image. This constant is not supported by Windows Vista and later.</summary>
		WiaItemTypeHPanorama = 0x00000200,

		/// <summary>The item represents a vertical panoramic image. This constant is not supported by Windows Vista and later.</summary>
		WiaItemTypeVPanorama = 0x00000400,

		/// <summary>
		/// For folders only. Images in this folder were taken in a continuous time sequence. This constant is not supported by Windows
		/// Vista and later.
		/// </summary>
		WiaItemTypeBurst = 0x00000800,

		/// <summary>The item represents a storage medium.</summary>
		WiaItemTypeStorage = 0x00001000,

		/// <summary>The item can be transferred.</summary>
		WiaItemTypeTransfer = 0x00002000,

		/// <summary>
		/// This item was created by the application or the driver, and does not have a corresponding item in the driver item tree.
		/// </summary>
		WiaItemTypeGenerated = 0x00004000,

		/// <summary>The item has file attachments. This constant is not supported by Windows Vista and later.</summary>
		WiaItemTypeHasAttachments = 0x00008000,

		/// <summary>
		/// The item represents streaming video. This constant is not supported by either Windows Server 2003*,* Windows Vista*, or later.*
		/// </summary>
		WiaItemTypeVideo = 0x00010000,

		/// <summary>
		/// This type indicates that the WIA device is capable of receiving TWAIN capability data from the TWAIN compatibility layer. If
		/// this type is set, any TWAIN capability that isn't understood by the TWAIN compatibility layer, during a TWAIN session, will
		/// be passed to the WIA driver.
		/// </summary>
		WiaItemTypeTwainCapabilityPassThrough = 0x00020000,

		/// <summary>The item has been removed from the device.</summary>
		WiaItemTypeRemoved = 0x80000000,

		/// <summary>The item represents a document. This constant is supported only by Windows Vista and later.</summary>
		WiaItemTypeDocument = 0x00040000,

		/// <summary>The item represents a programmable data source. This constant is supported only by Windows Vista and later.</summary>
		WiaItemTypeProgrammableDataSource = 0x00080000,
	}

	/// <summary>
	/// The <c>IEnumWIA_DEV_CAPS</c> interface enumerates the currently available Windows Image Acquisition (WIA) hardware device
	/// capabilities. Device capabilities include commands and events that the device supports.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IEnumWIA_DEV_CAPS</c> interface is a specific implementation for WIA of the standard OLE enumeration interface. For
	/// details, see IEnumXXXX.
	/// </para>
	/// <para>
	/// Applications obtain a pointer to the <c>IEnumWIA_DEV_CAPS</c> interface by invoking the IWiaItem::EnumDeviceCapabilities method.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-ienumwia_dev_caps
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("1fcc4287-aca6-11d2-a093-00c04f72dc3c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumWIA_DEV_CAPS : Vanara.Collections.ICOMEnum<WIA_DEV_CAP>
	{
		/// <summary>The <c>IEnumWIA_DEV_CAPS::Next</c> method fills an array of pointers to WIA_DEV_CAP structures.</summary>
		/// <param name="celt">Specifies the number of array elements in the array indicated by the rgelt parameter.</param>
		/// <param name="rgelt">Pointer to an array of WIA_DEV_CAP structures. IEnumWIA_DEV_CAPS::Next fills this array of structures.</param>
		/// <param name="pceltFetched">
		/// On output, this parameter contains the number of structure pointers actually stored in the array indicated by the rgelt parameter.
		/// </param>
		/// <returns>If this method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
		/// <remarks>
		/// <para>
		/// Applications use this method to query the capabilities of each available Windows Image Acquisition (WIA) hardware device. To
		/// do so, the application passes a pointer to an array of WIA_DEV_CAP structures that it allocates. It also passes in the
		/// number of array elements in the parameter celt. The <c>IEnumWIA_DEV_CAPS::Next</c> method fills the array with structures.
		/// Applications then use the structures to enumerate WIA hardware device capabilities.
		/// </para>
		/// <para>
		/// WIA device capabilities are defined as events and commands that the device supports. Using the rgelt array,
		/// <c>IEnumWIA_DEV_CAPS::Next</c> passes a single structure to the application for each event and command that the device supports.
		/// </para>
		/// <para>
		/// Note that <c>IEnumWIA_DEV_CAPS::Next</c> dynamically allocates the WIA_DEV_CAP structures it provides to applications.
		/// Therefore, applications must delete the <c>WIA_DEV_CAP</c> structures they receive through the rgelt parameter. Applications
		/// should use SysFreeString to free the bstrName, bstrDescription, and bstrIcon fields of all <c>WIA_DEV_CAP</c> structures.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_caps-next HRESULT Next( ULONG celt,
		// WIA_DEV_CAP *rgelt, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] WIA_DEV_CAP[] rgelt, out uint pceltFetched);

		/// <summary>
		/// The <c>IEnumWIA_DEV_CAPS::Skip</c> method skips the specified number of hardware device capabilities during an enumeration
		/// of available device capabilities.
		/// </summary>
		/// <param name="celt">Specifies the number of items to skip.</param>
		/// <returns>
		/// If the method succeeds, the method returns S_OK. It returns S_FALSE if it could not skip the specified number of device
		/// capabilities. If the method fails, it returns a standard COM error code.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_caps-skip
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>The <c>IEnumWIA_DEV_CAPS::Reset</c> method is used by applications to restart the enumeration of device capabilities.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_caps-reset
		void Reset();

		/// <summary>
		/// The <c>IEnumWIA_DEV_CAPS::Clone</c> method creates an additional instance of the IEnumWIA_DEV_CAPS interface and sends back
		/// a pointer to it.
		/// </summary>
		/// <returns>Contains the address of a pointer to the instance of IEnumWIA_DEV_CAPS that IEnumWIA_DEV_CAPS::Clone creates.</returns>
		/// <remarks>Applications must call the IUnknown::Release method on the pointers they receive through the ppIEnum parameter.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_caps-clone
		IEnumWIA_DEV_CAPS Clone();

		/// <summary>The <c>IEnumWIA_DEV_CAPS::GetCount</c> method returns the number of elements stored by this enumerator.</summary>
		/// <returns>The number of elements in the enumeration.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_caps-getcount
		uint GetCount();
	}

	/// <summary>
	/// The <c>IEnumWIA_DEV_INFO</c> interface enumerates the currently available Windows Image Acquisition (WIA) hardware devices and
	/// their properties. Device information properties describe the installation and configuration of WIA hardware devices.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IEnumWIA_DEV_INFO</c> interface is a specific implementation for WIA of the standard OLE enumeration interface. For
	/// details, see IEnumXXXX.
	/// </para>
	/// <para>Applications obtain a pointer to the <c>IEnumWIA_DEV_INFO</c> interface by invoking the IWiaDevMgr::EnumDeviceInfo method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-ienumwia_dev_info
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("5e38b83c-8cf1-11d1-bf92-0060081ed811"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumWIA_DEV_INFO : Vanara.Collections.ICOMEnum<IWiaPropertyStorage>
	{
		/// <summary>The <c>IEnumWIA_DEV_INFO::Next</c> method fills an array of pointers to IWiaPropertyStorage interfaces.</summary>
		/// <param name="celt">Specifies the number of array elements in the array indicated by the rgelt parameter.</param>
		/// <param name="rgelt">
		/// Receives the address of an array of IWiaPropertyStorage interface pointers. IEnumWIA_DEV_INFO::Next fills this array with
		/// interface pointers.
		/// </param>
		/// <param name="pceltFetched">
		/// On output, this parameter contains the number of interface pointers actually stored in the array indicated by the rgelt parameter.
		/// </param>
		/// <returns>
		/// While there are devices left to enumerate, this method returns S_OK. It returns S_FALSE when the enumeration is finished. If
		/// the method fails, it returns a standard COM error code.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications use this method to query the properties of each available Windows Image Acquisition (WIA) hardware device. To
		/// do so, the application passes an array of IWiaPropertyStorage interface pointers that it allocates. It also passes the
		/// number of array elements in the parameter celt. The <c>IEnumWIA_DEV_INFO::Next</c> method fills the array with pointers to
		/// <c>IWiaPropertyStorage</c> interfaces. Applications can query the interfaces for the properties that the device supports.
		/// </para>
		/// <para>Applications must call the IUnknown::Release method on the interface pointers they receive through the rgelt parameter.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_info-next HRESULT Next( ULONG celt,
		// IWiaPropertyStorage **rgelt, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IWiaPropertyStorage[] rgelt, out uint pceltFetched);

		/// <summary>
		/// The <c>IEnumWIA_DEV_INFO::Skip</c> method skips the specified number of hardware devices during an enumeration of available devices.
		/// </summary>
		/// <param name="celt">Specifies the number of devices to skip.</param>
		/// <returns>
		/// If the method succeeds, the method returns S_OK. If it is unable to skip the specified number of devices, it returns
		/// S_FALSE. If the method fails, it returns a standard COM error code.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_info-skip HRESULT Skip( ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>The <c>IEnumWIA_DEV_INFO::Reset</c> method is used by applications to restart the enumeration of device information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_info-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The <c>IEnumWIA_DEV_INFO::Clone</c> method creates an additional instance of the IEnumWIA_DEV_INFO interface and sends back
		/// a pointer to it.
		/// </summary>
		/// <returns>
		/// Pointer to an IEnumWIA_DEV_INFO interface. This parameter contains a pointer to the IEnumWIA_DEV_INFO interface instance
		/// that IEnumWIA_DEV_INFO::Clone creates.
		/// </returns>
		/// <remarks>Applications must call the IUnknown::Release method on the pointers they receive through the ppIEnum parameter.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_info-clone HRESULT Clone( IEnumWIA_DEV_INFO
		// **ppIEnum );
		IEnumWIA_DEV_INFO Clone();

		/// <summary>The <c>IEnumWIA_DEV_INFO::GetCount</c> method returns the number of elements stored by this enumerator.</summary>
		/// <returns>The number of elements in the enumeration.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_dev_info-getcount HRESULT GetCount( ULONG *celt );
		uint GetCount();
	}

	/// <summary>Use the <c>IEnumWIA_FORMAT_INFO</c> interface to enumerate the format and media type information for a device.</summary>
	/// <remarks>
	/// <para>
	/// The <c>IEnumWIA_FORMAT_INFO</c> interface is a specific implementation for Windows Image Acquisition (WIA) of the standard
	/// Component Object Model (COM) enumeration interface. For details, see IEnumXXXX.
	/// </para>
	/// <para>
	/// Applications obtain a pointer to the <c>IEnumWIA_FORMAT_INFO</c> interface by invoking the
	/// IWiaDataTransfer::idtEnumWIA_FORMAT_INFO method of an item's IWiaDataTransfer interface.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-ienumwia_format_info
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("81BEFC5B-656D-44f1-B24C-D41D51B4DC81"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumWIA_FORMAT_INFO : Vanara.Collections.ICOMEnum<WIA_FORMAT_INFO>
	{
		/// <summary>The <c>IEnumWIA_FORMAT_INFO::Next</c> method returns an array of WIA_FORMAT_INFO structures.</summary>
		/// <param name="celt">Specifies the number of elements requested.</param>
		/// <param name="rgelt">Receives the address of the array of WIA_FORMAT_INFO structures.</param>
		/// <param name="pceltFetched">
		/// On output, receives the address of a ULONG that contains the number of WIA_FORMAT_INFO structures actually returned in the
		/// rgelt parameter.
		/// </param>
		/// <returns>
		/// If the enumeration is continuing, this method returns S_OK and sets the value pointed to by pceltFetched to the number of
		/// capabilities returned. If the enumeration is complete, it returns S_FALSE and sets the value pointed to by pceltFetched to
		/// zero. If the method fails, it returns a standard COM error.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_format_info-next HRESULT Next( ULONG celt,
		// WIA_FORMAT_INFO *rgelt, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] WIA_FORMAT_INFO[] rgelt, out uint pceltFetched);

		/// <summary>The <c>IEnumWIA_FORMAT_INFO::Skip</c> method skips the specified number of structures in the enumeration.</summary>
		/// <param name="celt">Specifies the number of structures to skip.</param>
		/// <returns>
		/// This method returns S_OK if it is able to skip the specified number of elements. It returns S_FALSE if it is unable to skip
		/// the specified number of elements. If the method fails, it returns a standard COM error.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_format_info-skip HRESULT Skip( ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>The <c>IEnumWIA_FORMAT_INFO::Reset</c> method sets the enumeration back to the first WIA_FORMAT_INFO structure.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_format_info-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The <c>IEnumWIA_FORMAT_INFO::Clone</c> method creates an additional instance of the IEnumWIA_FORMAT_INFO interface and
		/// returns an interface pointer to the new interface.
		/// </summary>
		/// <returns>Pointer to a new IEnumWIA_FORMAT_INFO interface.</returns>
		/// <remarks>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIEnum parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_format_info-clone HRESULT Clone(
		// IEnumWIA_FORMAT_INFO **ppIEnum );
		IEnumWIA_DEV_INFO Clone();

		/// <summary>The <c>IEnumWIA_FORMAT_INFO::GetCount</c> method returns the number of elements stored by this enumerator.</summary>
		/// <returns>The number of elements in the enumeration.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwia_format_info-getcount HRESULT GetCount( ULONG
		// *pcelt );
		uint GetCount();
	}

	/// <summary>
	/// <para>
	/// The <c>IEnumWiaItem</c> interface is used by applications to enumerate IWiaItem objects in the tree's current folder. The
	/// Windows Image Acquisition (WIA) run-time system represents every WIA hardware device to applications as a hierarchical tree of
	/// <c>IWiaItem</c> objects.
	/// </para>
	/// <para><c>Note</c> For Windows Vista applications, use IEnumWiaItem2 instead of <c>IEnumWiaItem</c>.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IEnumWiaItem</c> interface is a specific implementation for WIA of the standard Component Object Model (COM) enumeration
	/// interface. For details, see IEnumXXXX.
	/// </para>
	/// <para>Applications obtain a pointer to the <c>IEnumWiaItem</c> interface by invoking the IWiaItem::EnumChildItems method.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-ienumwiaitem
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("5e8383fc-3391-11d2-9a33-00c04fa36145"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumWiaItem : Vanara.Collections.ICOMEnum<IWiaItem>
	{
		/// <summary>The <c>IEnumWiaItem::Next</c> method fills an array of pointers to IWiaItem interfaces.</summary>
		/// <param name="celt">Specifies the number of array elements in the array indicated by the ppIWiaItem parameter.</param>
		/// <param name="rgelt">
		/// Receives the address of an array of IWiaItem interface pointers. IEnumWiaItem::Next fills this array with interface pointers.
		/// </param>
		/// <param name="pceltFetched">
		/// On output, this parameter receives the number of interface pointers actually stored in the array indicated by the ppIWiaItem
		/// parameter. When the enumeration is complete, this parameter will contain zero.
		/// </param>
		/// <returns>
		/// If the method succeeds, the method returns S_OK. When the enumeration is complete, it returns S_FALSE. If the method fails,
		/// it returns a standard COM error code.
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Windows Image Acquisition (WIA) run-time system represents WIA hardware devices as a hierarchical tree of IWiaItem
		/// objects. Applications use the <c>IEnumWiaItem::Next</c> method to obtain an <c>IWiaItem</c> interface pointer for each item
		/// in the current folder of a hardware device's <c>IWiaItem</c> object tree.
		/// </para>
		/// <para>
		/// To obtain the list of pointers, the application passes an array of IWiaItem interface pointers that it allocates. It also
		/// passes the number of array elements in the celt parameter. The <c>IEnumWiaItem::Next</c> method fills the array with
		/// pointers to <c>IWiaItem</c> interfaces.
		/// </para>
		/// <para>
		/// Until the enumeration process completes, the <c>IEnumWiaItem::Next</c> method returns S_OK. Each time it does, it sets the
		/// value pointed to by pceltFetched to the number of items it inserted into the array. When <c>IEnumWiaItem::Next</c> finishes
		/// the process of enumerating IWiaItem objects, it returns S_FALSE and sets the memory location pointed to by pceltFetched to zero.
		/// </para>
		/// <para>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIWiaItem parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwiaitem-next HRESULT Next( ULONG celt, IWiaItem
		// **ppIWiaItem, ULONG *pceltFetched );
		[PreserveSig]
		HRESULT Next(uint celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] IWiaItem[] rgelt, out uint pceltFetched);

		/// <summary>
		/// The <c>IEnumWiaItem::Skip</c> method skips the specified number of items during an enumeration of available IWiaItem objects.
		/// </summary>
		/// <param name="celt">Specifies the number of items to skip.</param>
		/// <returns>
		/// If the method succeeds, the method returns S_OK. If it is unable to skip the specified number of items, it returns S_FALSE.
		/// If the method fails, it returns a standard COM error code.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwiaitem-skip HRESULT Skip( ULONG celt );
		[PreserveSig]
		HRESULT Skip(uint celt);

		/// <summary>The <c>IEnumWiaItem::Reset</c> method is used by applications to restart the enumeration of item information.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwiaitem-reset HRESULT Reset();
		void Reset();

		/// <summary>
		/// The <c>IEnumWiaItem::Clone</c> method creates an additional instance of the IEnumWiaItem interface and sends back a pointer
		/// to it.
		/// </summary>
		/// <returns>
		/// Pointer to the IEnumWiaItem interface. Receives the address of the IEnumWiaItem interface instance that IEnumWiaItem::Clone creates.
		/// </returns>
		/// <remarks>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIEnum parameter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwiaitem-clone HRESULT Clone( IEnumWiaItem **ppIEnum );
		IEnumWIA_DEV_INFO Clone();

		/// <summary>The <c>IEnumWiaItem::GetCount</c> method returns the number of elements stored by this enumerator.</summary>
		/// <returns>The number of elements in the enumeration.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-ienumwiaitem-getcount HRESULT GetCount( ULONG *celt );
		uint GetCount();
	}

	/// <summary>
	/// <para>
	/// Provides an application callback mechanism during data transfers from Windows Image Acquisition (WIA) hardware devices to applications.
	/// </para>
	/// <para><c>Note</c> For Windows Vista applications, use IWiaTransferCallback instead of <c>IWiaDataCallback</c>.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IWiaDataCallback</c> interface, like all Component Object Model (COM) interfaces, inherits the IUnknown interface methods.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>IUnknown Methods</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IUnknown::QueryInterface</term>
	/// <term>Returns pointers to supported interfaces.</term>
	/// </item>
	/// <item>
	/// <term>IUnknown::AddRef</term>
	/// <term>Increments reference count.</term>
	/// </item>
	/// <item>
	/// <term>IUnknown::Release</term>
	/// <term>Decrements reference count.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-iwiadatacallback
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("a558a866-a5b0-11d2-a08f-00c04f72dc3c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWiaDataCallback
	{
		/// <summary>
		/// Provides data transfer status notifications. Windows Image Acquisition (WIA) data transfer methods of the IWiaDataTransfer
		/// interface periodically call this method.
		/// </summary>
		/// <param name="lMessage">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies a constant that indicates the reason for the callback. Can be one of the following values:</para>
		/// <para>IT_MSG_DATA</para>
		/// <para>The WIA system is transferring data to the application.</para>
		/// <para>IT_MSG_DATA_HEADER</para>
		/// <para>The application is receiving a header prior to receiving the actual data.</para>
		/// <para>IT_MSG_DEVICE_STATUS</para>
		/// <para>Windows Vista or later. Status at the device has changed.</para>
		/// <para>IT_MSG_FILE_PREVIEW_DATA</para>
		/// <para>The WIA system is transferring preview data to the application.</para>
		/// <para>IT_MSG_FILE_PREVIEW_DATA_HEADER</para>
		/// <para>The application is receiving a header prior to receiving the actual preview data.</para>
		/// <para>IT_MSG_NEW_PAGE</para>
		/// <para>The data transfer is beginning a new page.</para>
		/// <para>IT_MSG_STATUS</para>
		/// <para>This invocation of the callback is sending only status information.</para>
		/// <para>IT_MSG_TERMINATION</para>
		/// <para>The data transfer is complete.</para>
		/// </param>
		/// <param name="lStatus">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies a constant that indicates the status of the WIA device. Can be set to a combination of the following:</para>
		/// <para>IT_STATUS_TRANSFER_FROM_DEVICE</para>
		/// <para>Data is currently being transferred from the WIA device.</para>
		/// <para>IT_STATUS_PROCESSING_DATA</para>
		/// <para>Data is currently being processed.</para>
		/// <para>IT_STATUS_TRANSFER_TO_CLIENT</para>
		/// <para>Data is currently being transferred to the client's data buffer.</para>
		/// </param>
		/// <param name="lPercentComplete">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the percentage of the total data that has been transferred so far.</para>
		/// </param>
		/// <param name="lOffset">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies an offset, in bytes, from the beginning of the buffer where the current band of data begins.</para>
		/// </param>
		/// <param name="lLength">
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the length, in bytes, of the current band of data.</para>
		/// </param>
		/// <param name="lReserved">
		/// <para>Type: <c>int</c></para>
		/// <para>Reserved for internal use by the WIA run-time system.</para>
		/// </param>
		/// <param name="lResLength">
		/// <para>Type: <c>int</c></para>
		/// <para>Reserved for internal use by the WIA run-time system.</para>
		/// </param>
		/// <param name="pbBuffer">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to the data buffer.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If the method succeeds, the method returns S_OK. To cancel the data transfer, it returns S_FALSE. If the method fails, it
		/// returns a standard COM error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Your application must provide the <c>IWiaDataCallback::BandedDataCallback</c> method. This method is periodically invoked by
		/// the data transfer methods of the IWiaDataTransfer interface. It provides status messages to the application during the data
		/// transfer. By returning S_FALSE, your program can also use this method to prematurely terminate the data transfer.
		/// </para>
		/// <para>
		/// When this method is invoked, the lMessage parameter will contain the reason for the call. Not all parameters will contain
		/// data on all calls. For example, when <c>IWiaDataCallback::BandedDataCallback</c> is invoked with a message of
		/// IT_MSG_TERMINATION, it should not attempt to use the values in the pbBuffer, lOffset, and lLength parameters.
		/// </para>
		/// <para>
		/// If the value of lMessage is IT_MSG_DATA, the buffer pointed to by pbBuffer contains a band of image data. The lOffset
		/// parameter contains an offset in bytes from the beginning of the buffer where the current band of data begins. The lLength
		/// parameter specified the length in bytes of the current band of data.
		/// </para>
		/// <para>
		/// During calls where lMessage is set to IT_MSG_DATA or IT_MSG_STATUS, the lStatus parameter contains a valid value. Its
		/// contents should not be used when lMessage contains other values.
		/// </para>
		/// <para>If lMessage is IT_MSG_DATA_HEADER, the pbBuffer parameter points to a WIA_DATA_CALLBACK_HEADER structure.</para>
		/// <para>
		/// When an error has occurred during an image data transfer, the driver sets lMessage to IT_MSG_DEVICE_STATUS. The proxy
		/// callback object calls ReportStatus, which handles the error and displays messages to the user.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example shows one possible way to implement the <c>IWiaDataCallback::BandedDataCallback</c> method.</para>
		/// <para>
		/// The example application code defines the <c>CDataCallback</c> object that it derives from the IWiaDataCallback interface.
		/// The application must instantiate a <c>CDataCallback</c> object. It then calls <c>CDataCallback::QueryInterface</c> to obtain
		/// an <c>IWiaDataCallback</c> interface pointer. When the application is ready to receive data, it invokes the idtGetBandedData
		/// method and passes the method a pointer to the <c>IWiaDataCallback</c> interface.
		/// </para>
		/// <para>
		/// Periodically, the idtGetBandedData method uses the IWiaDataCallback interface pointer to invoke the
		/// <c>CDataCallback::BandedDataCallback</c> method of the application. The first invocations send status messages. These are
		/// followed by a call that transfers a data header to the callback method. After the application receives the data header,
		/// <c>idtGetBandedData</c> invokes <c>CDataCallback::BandedDataCallback</c> to transfer data to the application. When the data
		/// transfer is complete, it calls the callback method a final time to transmit a termination message.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadatacallback-bandeddatacallback
		[PreserveSig]
		HRESULT BandedDataCallback(IT_MSG lMessage, IT_STATUS lStatus, int lPercentComplete, int lOffset, int lLength, [Optional] int lReserved, [Optional] int lResLength, IntPtr pbBuffer);
	}

	/// <summary>
	/// <para>
	/// The <c>IWiaDataTransfer</c> interface is a high performance data transfer interface. This interface supports a shared memory
	/// window to transfer data from the device object to the application, and eliminates unnecessary data copies during marshalling. A
	/// callback mechanism is provided in the form of the IWiaDataCallback interface. It enables applications to obtain data transfer
	/// status notification, transfer data from the Windows Image Acquisition (WIA) device to the application, and cancel pending data transfers.
	/// </para>
	/// <para><c>Note</c> For Windows Vista applications, use IWiaTransfer instead of <c>IWiaDataTransfer</c>.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-iwiadatatransfer
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("a6cef998-a5b0-11d2-a08f-00c04f72dc3c"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWiaDataTransfer
	{
		/// <summary>
		/// The <c>IWiaDataTransfer::idtGetData</c> method retrieves complete files from a Windows Image Acquisition (WIA) device.
		/// </summary>
		/// <param name="pMedium">
		/// <para>Type: <c>LPSTGMEDIUM</c></para>
		/// <para>Pointer to the STGMEDIUM structure.</para>
		/// </param>
		/// <param name="pIWiaDataCallback">
		/// <para>Type: <c>IWiaDataCallback*</c></para>
		/// <para>Pointer to the IWiaDataCallback interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return any one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters to this method contain invalid data.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>This method cannot allocate enough memory to complete its operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unknown error occurred.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The application canceled the operation.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The image was successfully acquired.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_MEDIUMFULL</term>
		/// <term>The storage medium the application is using to acquire the image is full.</term>
		/// </item>
		/// <item>
		/// <term>WIA_S_NO_DEVICE_AVAILABLE</term>
		/// <term>There are no WIA hardware devices attached to the user's computer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This method will return a value specified in Error Codes, or a standard COM error if it fails for any reason other than
		/// those specified in the preceding table.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In most respects, this method operates identically to the IDataObject::GetData method. The primary difference is that
		/// <c>IWiaDataTransfer::idtGetData</c> provides an additional parameter for a pointer to the IWiaDataCallback interface.
		/// Applications use this optional parameter to obtain status notifications during the data transfer. If no status notifications
		/// are needed, it should be set to zero.
		/// </para>
		/// <para>
		/// The format of the data transfer is determined by the values of the item's WIA_IPA_FORMAT and <c>WIA_IPA_TYMED</c>
		/// properties. The application sets these properties with calls to the IWiaPropertyStorage::WriteMultiple method.
		/// </para>
		/// <para>
		/// Unlike the IWiaDataTransfer::idtGetBandedData method, <c>IWiaDataTransfer::idtGetData</c> transfers a complete file from a
		/// WIA device to an application rather than just a single band of data. The pMedium parameter is a pointer to the STGMEDIUM
		/// structure which contains information on the storage medium to be used for the data transfer. Programs use the
		/// pIWiaDataCallback parameter to pass this method a pointer to the IWiaDataCallback interface. Periodically, this method will
		/// use the interface pointer to invoke the BandedDataCallback method and provide the application with status information about
		/// the data transfer in progress.
		/// </para>
		/// <para>
		/// Pass <c>NULL</c> as the value of the <c>lpszFileName</c> member of the pMedium structure to allow WIA to determine the file
		/// name and location for the new file. Upon return, the <c>lpszFileName</c> member of the pMedium structure contains the
		/// location and name of the new file.
		/// </para>
		/// <para>
		/// If the value returned by this method is a COM SUCCESS value or the transfer is a multipage file transfer, and the error code
		/// returned is WIA_ERROR_PAPER_JAM, WIA_ERROR_PAPER_EMPTY, or WIA_ERROR_PAPER_PROBLEM, WIA does not delete the file.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadatatransfer-idtgetdata HRESULT idtGetData(
		// LPSTGMEDIUM pMedium, IWiaDataCallback *pIWiaDataCallback );
		[PreserveSig]
		HRESULT idtGetData(ref STGMEDIUM pMedium, IWiaDataCallback pIWiaDataCallback);

		/// <summary>
		/// The <c>IWiaDataTransfer::idtGetBandedData</c> method transfers a band of data from a hardware device to an application. For
		/// efficiency, applications retrieve data from Windows Image Acquisition (WIA) hardware devices in successive bands.
		/// </summary>
		/// <param name="pWiaDataTransInfo">
		/// <para>Type: <c>PWIA_DATA_TRANSFER_INFO</c></para>
		/// <para>Pointer to the WIA_DATA_TRANSFER_INFO structure.</para>
		/// </param>
		/// <param name="pIWiaDataCallback">
		/// <para>Type: <c>IWiaDataCallback*</c></para>
		/// <para>
		/// Pointer to the IWiaDataCallback interface. Periodically, this method will call the BandedDataCallback method to provide the
		/// application with data transfer status notification.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method can return any one of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more parameters to this method contain invalid data.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>This method cannot allocate enough memory to complete its operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unknown error occurred.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The application canceled the operation.</term>
		/// </item>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The image was successfully acquired.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_MEDIUMFULL</term>
		/// <term>The storage medium the application is using to acquire the image is full.</term>
		/// </item>
		/// <item>
		/// <term>WIA_S_NO_DEVICE_AVAILABLE</term>
		/// <term>There are no WIA hardware devices attached to the user's computer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// This method will return a value specified in Error Codes, or a standard COM error if it fails for any reason other than
		/// those specified in the preceding table.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IWiaDataTransfer::idtGetBandedData</c> method allocates a section of memory to transfer data without requiring an
		/// extra data copy through the Component Object Model/Remote Procedure Call (COM/RPC) marshalling layer. This memory section is
		/// shared between the application and the hardware device's item tree.
		/// </para>
		/// <para>
		/// Optionally, the application can pass in a pointer to a block of memory that <c>IWiaDataTransfer::idtGetBandedData</c> will
		/// use as its shared section. The application passes this handle by storing the pointer in the <c>ulSection</c> member of the
		/// WIA_DATA_TRANSFER_INFO structure prior to calling <c>IWiaDataTransfer::idtGetBandedData</c>.
		/// </para>
		/// <para>
		/// Applications can improve performance by using double buffering. To do this, applications must set the <c>bDoubleBuffer</c>
		/// member of the WIA_DATA_TRANSFER_INFO structure to <c>TRUE</c>. The <c>IWiaDataTransfer::idtGetBandedData</c> method will
		/// divide the data buffer in half. When one half of the buffer is full, <c>IWiaDataTransfer::idtGetBandedData</c> will send a
		/// notification to the application using the IWiaDataCallback pointer passed in through the pIWiaDataCallback parameter. While
		/// the application is retrieving the data from the full half of the buffer, the device driver can fill the other half with data.
		/// </para>
		/// <para>
		/// The format of the data transfer is determined by the values of the item's WIA_IPA_FORMAT and <c>WIA_IPA_TYMED</c>
		/// properties. The application sets these properties with calls to the IWiaPropertyStorage::WriteMultiple method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadatatransfer-idtgetbandeddata HRESULT
		// idtGetBandedData( PWIA_DATA_TRANSFER_INFO pWiaDataTransInfo, IWiaDataCallback *pIWiaDataCallback );
		[PreserveSig]
		HRESULT idtGetBandedData(in WIA_DATA_TRANSFER_INFO pWiaDataTransInfo, IWiaDataCallback pIWiaDataCallback);

		/// <summary>
		/// The <c>IWiaDataTransfer::idtQueryGetData</c> method is used by applications to query a Windows Image Acquisition (WIA)
		/// device to determine what types of data formats it supports.
		/// </summary>
		/// <param name="pfe">
		/// <para>Type: <c>WIA_FORMAT_INFO*</c></para>
		/// <para>Pointer to a WIA_FORMAT_INFO structure.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// If this method succeeds, it returns S_OK. Otherwise it returns a value specified in Error Codes, or a standard COM error.
		/// </para>
		/// </returns>
		/// <remarks>
		/// This method queries a device to determine the data formats it supports. Prior to a data transfer, an application can fill in
		/// the WIA_FORMAT_INFO structure with the intended medium and data format information. It then calls
		/// <c>IWiaDataTransfer::idtQueryGetData</c> and receives a return value of S_OK if the data format and media type are supported
		/// by this device.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadatatransfer-idtquerygetdata HRESULT idtQueryGetData(
		// WIA_FORMAT_INFO *pfe );
		void idtQueryGetData(in WIA_FORMAT_INFO pfe);

		/// <summary>
		/// The <c>IWiaDataTransfer::idtEnumWIA_FORMAT_INFO</c> method creates a banded transfer implementation of the
		/// IEnumWIA_FORMAT_INFO interface.
		/// </summary>
		/// <returns>Receives the address of a pointer to the IEnumWIA_FORMAT_INFO interface.</returns>
		/// <remarks>
		/// <para>
		/// This method creates the IEnumWIA_FORMAT_INFO interface that applications use to enumerate an array of WIA_FORMAT_INFO
		/// structures. This provides applications with the ability to determine the formats and media types of incoming data when
		/// transferring banded data.
		/// </para>
		/// <para>
		/// Note that applications must call IUnknown::Release method on the interface pointers they receive through the ppEnum parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadatatransfer-idtenumwia_format_info HRESULT
		// idtEnumWIA_FORMAT_INFO( IEnumWIA_FORMAT_INFO **ppEnum );
		IEnumWIA_FORMAT_INFO idtEnumWIA_FORMAT_INFO();

		/// <summary>
		/// The <c>IWiaDataTransfer::idtGetExtendedTransferInfo</c> retrieves extended information relating to data transfer buffers in
		/// the case of banded data transfers. Applications typically use this method to retrieve driver recommended settings for
		/// minimum buffer size, maximum buffer size, and optimal buffer size for banded data transfers.
		/// </summary>
		/// <param name="pExtendedTransferInfo">
		/// <para>Type: <c>PWIA_EXTENDED_TRANSFER_INFO</c></para>
		/// <para>Pointer to a WIA_EXTENDED_TRANSFER_INFO structure containing the extended information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadatatransfer-idtgetextendedtransferinfo HRESULT
		// idtGetExtendedTransferInfo( PWIA_EXTENDED_TRANSFER_INFO pExtendedTransferInfo );
		void idtGetExtendedTransferInfo(out WIA_EXTENDED_TRANSFER_INFO pExtendedTransferInfo);
	}

	/// <summary>
	/// <para>
	/// Applications use the <c>IWiaDevMgr</c> interface to create and manage image acquisition devices. They also use it to register to
	/// receive device events.
	/// </para>
	/// <para><c>Note</c> For Windows Vista applications, use IWiaDevMgr2 instead of <c>IWiaDevMgr</c>.</para>
	/// </summary>
	/// <remarks>
	/// <para>The <c>IWiaDevMgr</c> interface, like all Component Object Model (COM) interfaces, inherits the IUnknown interface methods.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>IUnknown Methods</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IUnknown::QueryInterface</term>
	/// <term>Returns pointers to supported interfaces.</term>
	/// </item>
	/// <item>
	/// <term>IUnknown::AddRef</term>
	/// <term>Increments reference count.</term>
	/// </item>
	/// <item>
	/// <term>IUnknown::Release</term>
	/// <term>Decrements reference count.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-iwiadevmgr
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("5eb2502a-8cf1-11d1-bf92-0060081ed811"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWiaDevMgr
	{
		/// <summary>
		/// Applications use the <c>IWiaDevMgr::EnumDeviceInfo</c> method to enumerate property information for each available Windows
		/// Image Acquisition (WIA) device.
		/// </summary>
		/// <param name="lFlag">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies the types of WIA devices to enumerate. Should be set to WIA_DEVINFO_ENUM_LOCAL.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IEnumWIA_DEV_INFO**</c></para>
		/// <para>Receives the address of a pointer to the IEnumWIA_DEV_INFO interface.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IWiaDevMgr::EnumDeviceInfo</c> method creates an enumerator object, that supports the IEnumWIA_DEV_INFO interface.
		/// <c>IWiaDevMgr::EnumDeviceInfo</c> stores a pointer to the <c>IEnumWIA_DEV_INFO</c> interface in the parameter ppIEnum.
		/// Applications can use the <c>IEnumWIA_DEV_INFO</c> interface pointer to enumerate the properties of each WIA device attached
		/// to the user's computer.
		/// </para>
		/// <para>Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIEnum parameter.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-enumdeviceinfo HRESULT EnumDeviceInfo( LONG
		// lFlag, IEnumWIA_DEV_INFO **ppIEnum );
		IEnumWIA_DEV_INFO EnumDeviceInfo(int lFlag);

		/// <summary>
		/// The <c>IWiaDevMgr::CreateDevice</c> creates a hierarchical tree of IWiaItem objects for a Windows Image Acquisition (WIA) device.
		/// </summary>
		/// <param name="bstrDeviceID">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the unique identifier of the WIA device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWiaItem**</c></para>
		/// <para>Pointer to a pointer to the IWiaItem interface of the root item in the hierarchical tree for the WIA device.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications use the <c>IWiaDevMgr::CreateDevice</c> method to create a device object for the WIA devices specified by the
		/// bstrDeviceID parameter.
		/// </para>
		/// <para>
		/// When it returns, the <c>IWiaDevMgr::CreateDevice</c> method stores an address of a pointer in the parameter ppWiaItemRoot.
		/// The pointer points to the root item of the tree of IWiaItem objects created by <c>IWiaDevMgr::CreateDevice</c>. Applications
		/// can use this tree of objects to control and retrieve data from the WIA device.
		/// </para>
		/// <para>
		/// Note that applications must call the IUnknown::Release method on the pointers they receive through the ppWiaItemRoot parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-createdevice HRESULT CreateDevice( BSTR
		// bstrDeviceID, IWiaItem **ppWiaItemRoot );
		IWiaItem CreateDevice([MarshalAs(UnmanagedType.BStr)] string bstrDeviceID);

		/// <summary>
		/// The <c>IWiaDevMgr::SelectDeviceDlg</c> displays a dialog box that enables the user to select a hardware device for image acquisition.
		/// </summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle of the window that owns the <c>Select Device</c> dialog box.</para>
		/// </param>
		/// <param name="lDeviceType">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies which type of WIA device to use. Can be set to <c>StiDeviceTypeDefault</c>, <c>StiDeviceTypeScanner</c>, or <c>StiDeviceTypeDigitalCamera</c>.
		/// </para>
		/// </param>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies dialog box behavior. Can be set to any of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Use the default behavior.</term>
		/// </item>
		/// <item>
		/// <term>WIA_SELECT_DEVICE_NODEFAULT</term>
		/// <term>
		/// Display the dialog box even if there is only one matching device. For more information, see the Remarks section of this
		/// reference page.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbstrDeviceID">
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>
		/// On output, receives a string which contains the device's identifier string. On input, pass the address of a pointer if this
		/// information is needed, or <c>NULL</c> if it is not needed.
		/// </para>
		/// </param>
		/// <param name="ppItemRoot">
		/// <para>Type: <c>IWiaItem**</c></para>
		/// <para>
		/// Receives the address of a pointer to the IWiaItem interface of the root item of the tree that represents the selected WIA
		/// device. If no devices are found, it contains the value <c>NULL</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>A device was successfully selected.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The user canceled the dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WIA_S_NO_DEVICE_AVAILABLE</term>
		/// <term>There are no WIA hardware devices that match the specifications given in the lDeviceType parameter.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method creates and displays the <c>Select Device</c> dialog box so the user can select a WIA device for image
		/// acquisition. If a device is successfully selected, the <c>IWiaDevMgr::SelectDeviceDlg</c> method creates a hierarchical tree
		/// of IWiaItem objects for the device. It stores a pointer to the <c>IWiaItem</c> interface of the root item in the parameter ppItemRoot.
		/// </para>
		/// <para>
		/// Particular types of devices may be displayed to the user by specifying the device types through the lDeviceType parameter.
		/// If only one device meets the specification, <c>IWiaDevMgr::SelectDeviceDlg</c> does not display the <c>Select Device</c>
		/// dialog box. Instead it creates the IWiaItem tree for the device and store a pointer to the <c>IWiaItem</c> interface of the
		/// root item in the parameter ppItemRoot. You can override this behavior and force <c>IWiaDevMgr::SelectDeviceDlg</c> to
		/// display the <c>Select Device</c> dialog box by passing WIA_SELECT_DEVICE_NODEFAULT as the value for the lFlags parameter.
		/// </para>
		/// <para>
		/// If more than one WIA device matches the specification, all matching devices are displayed in the <c>Select Device</c> dialog
		/// box so the user may choose one.
		/// </para>
		/// <para>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppItemRoot parameter.
		/// </para>
		/// <para>
		/// It is recommended that applications make device and image selection available through a menu item named <c>From scanner or
		/// camera</c> on the <c>File</c> menu.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-selectdevicedlg HRESULT SelectDeviceDlg( HWND
		// hwndParent, LONG lDeviceType, LONG lFlags, BSTR *pbstrDeviceID, IWiaItem **ppItemRoot );
		[PreserveSig]
		HRESULT SelectDeviceDlg(HWND hwndParent, int lDeviceType, int lFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrDeviceID, out IWiaItem ppItemRoot);

		/// <summary>
		/// The <c>IWiaDevMgr::SelectDeviceDlgID</c> method displays a dialog box that enables the user to select a hardware device for
		/// image acquisition.
		/// </summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle of the window that owns the <c>Select Device</c> dialog box.</para>
		/// </param>
		/// <param name="lDeviceType">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies which type of WIA device to use. Can be set to <c>StiDeviceTypeDefault</c>, <c>StiDeviceTypeScanner</c>, or <c>StiDeviceTypeDigitalCamera</c>.
		/// </para>
		/// </param>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies dialog box behavior. Can be set to any of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Constant</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Use the default behavior.</term>
		/// </item>
		/// <item>
		/// <term>WIA_SELECT_DEVICE_NODEFAULT</term>
		/// <term>
		/// Display the dialog box even if there is only one matching device. For more information, see the Remarks section of this
		/// reference page.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pbstrDeviceID">
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>Pointer to a string that receives the identifier string of the device.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>A device was successfully selected.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The user canceled the dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WIA_S_NO_DEVICE_AVAILABLE</term>
		/// <term>There are no WIA hardware devices attached to the user's computer that match the specifications.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method works in a similar manner to IWiaDevMgr::SelectDeviceDlg. The primary difference is that if it finds a matching
		/// device, it does not create the hierarchical tree of IWiaItem objects for the device.
		/// </para>
		/// <para>
		/// Like IWiaDevMgr::SelectDeviceDlg, the <c>IWiaDevMgr::SelectDeviceDlgID</c> method creates and displays the <c>Select
		/// Device</c> dialog box. This enables the user to select a WIA device for image acquisition. If a device is successfully
		/// selected, the <c>IWiaDevMgr::SelectDeviceDlgID</c> method passes its identifier string to the application through its
		/// pbstrDeviceID parameter.
		/// </para>
		/// <para>
		/// Particular types of devices may be displayed to the user by specifying the device types through the lDeviceType parameter.
		/// If only one device meets the specification, <c>IWiaDevMgr::SelectDeviceDlgID</c> does not display the <c>Select Device</c>
		/// dialog box. Instead it passes the device's identifier string to the application without displaying the dialog box. You can
		/// override this behavior and force <c>IWiaDevMgr::SelectDeviceDlgID</c> to display the <c>Select Device</c> dialog box by
		/// passing WIA_SELECT_DEVICE_NODEFAULT as the value for the lFlags parameter.
		/// </para>
		/// <para>
		/// If more than one WIA device matches the specification, all matching devices are displayed in the <c>Select Device</c> dialog
		/// box so the user may choose one.
		/// </para>
		/// <para>
		/// It is recommended that applications make device and image selection available through a menu item named <c>From scanner or
		/// camera</c> on the <c>File</c> menu.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-selectdevicedlgid HRESULT SelectDeviceDlgID(
		// HWND hwndParent, LONG lDeviceType, LONG lFlags, BSTR *pbstrDeviceID );
		[PreserveSig]
		HRESULT SelectDeviceDlgID(HWND hwndParent, int lDeviceType, int lFlags, [MarshalAs(UnmanagedType.BStr)] out string pbstrDeviceID);

		/// <summary>
		/// The <c>IWiaDevMgr::GetImageDlg</c> method displays one or more dialog boxes that enable a user to acquire an image from a
		/// Windows Image Acquisition (WIA) device and write the image to a specified file. This method combines the functionality of
		/// IWiaDevMgr::SelectDeviceDlg to completely encapsulate image acquisition within a single API call.
		/// </summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle of the window that owns the <c>Get Image</c> dialog box.</para>
		/// </param>
		/// <param name="lDeviceType">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies which type of WIA device to use. Is set to <c>StiDeviceTypeDefault</c>, <c>StiDeviceTypeScanner</c>, or <c>StiDeviceTypeDigitalCamera</c>.
		/// </para>
		/// </param>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies dialog box behavior. Can be set to the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Default behavior.</term>
		/// </item>
		/// <item>
		/// <term>WIA_SELECT_DEVICE_NODEFAULT</term>
		/// <term>
		/// Force this method to display the Select Device dialog box. For more information, see the Remarks section of this reference page.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WIA_DEVICE_DIALOG_SINGLE_IMAGE</term>
		/// <term>Restrict image selection to a single image in the device image acquisition dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WIA_DEVICE_DIALOG_USE_COMMON_UI</term>
		/// <term>
		/// Use the system UI, if available, rather than the vendor-supplied UI. If the system UI is not available, the vendor UI is
		/// used. If neither UI is available, the function returns E_NOTIMPL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lIntent">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies what type of data the image is intended to represent. For a list of image intent values, see Image Intent Constants.
		/// </para>
		/// </param>
		/// <param name="pItemRoot">
		/// <para>Type: <c>IWiaItem*</c></para>
		/// <para>Pointer to the interface of the hierarchical tree of IWiaItem objects returned by IWiaDevMgr::CreateDevice.</para>
		/// </param>
		/// <param name="bstrFilename">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the name of the file to which the image data is written.</para>
		/// </param>
		/// <param name="pguidFormat">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>
		/// On input, contains a pointer to a GUID that specifies the format to use. On output, holds the format used. Pass IID_NULL to
		/// use the default format.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// <c>IWiaDevMgr::GetImageDlg</c> returns S_FALSE if the user cancels the device selection or image acquisition dialog boxes,
		/// WIA_S_NO_DEVICE_AVAILABLE if no WIA device is currently available, E_NOTIMPL if no UI is available, and S_OK if the data is
		/// transferred successfully.
		/// </para>
		/// <para>
		/// <c>IWiaDevMgr::GetImageDlg</c> returns a value specified in Error Codes, or a standard COM error if it fails for any reason
		/// other than those specified.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Invoking this method displays a dialog box that enables users to acquire images. It can also display the <c>Select
		/// Device</c> dialog box created by the IWiaDevMgr::SelectDeviceDlg method.
		/// </para>
		/// <para>
		/// If the application passes <c>NULL</c> for the value of the pItemRoot parameter, <c>IWiaDevMgr::GetImageDlg</c> displays the
		/// <c>Select Device</c> dialog box that lets the user select the WIA input device. If the application specifies a WIA input
		/// device by passing a pointer to the device's item tree through the pItemRoot parameter, <c>IWiaDevMgr::GetImageDlg</c> does
		/// not display the <c>Select Device</c> dialog box. Instead, it will use the specified input device to acquire the image.
		/// </para>
		/// <para>
		/// When using the <c>Select Device</c> dialog box, applications can specify types of WIA input devices. To do so, they must set
		/// the pItemRoot parameter to <c>NULL</c> and pass the appropriate constants through the lDeviceType parameter. If more than
		/// one device of the specified type is present, the <c>IWiaDevMgr::GetImageDlg</c> displays the <c>Select Device</c> dialog box
		/// to let the user select which device will be used.
		/// </para>
		/// <para>
		/// If <c>IWiaDevMgr::GetImageDlg</c> finds only one matching device, it will not display the <c>Select Device</c> dialog box.
		/// Instead, it will select the matching device. You can override this behavior and force <c>IWiaDevMgr::GetImageDlg</c> to
		/// display the <c>Select Device</c> dialog box by passing WIA_SELECT_DEVICE_NODEFAULT as the value for the lFlags parameter.
		/// </para>
		/// <para>
		/// It is recommended that applications make device and image selection available through a menu item named <c>From scanner or
		/// camera</c> on the <c>File</c> menu.
		/// </para>
		/// <para>
		/// The dialog must have sufficient rights to the folder for bstrFilename that it can save the file with a unique file name. The
		/// folder should also be protected with an access control list (ACL) because it contains user data.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-getimagedlg HRESULT GetImageDlg( HWND
		// hwndParent, LONG lDeviceType, LONG lFlags, LONG lIntent, IWiaItem *pItemRoot, BSTR bstrFilename, GUID *pguidFormat );
		[PreserveSig]
		HRESULT GetImageDlg(HWND hwndParent, int lDeviceType, int lFlags, int lIntent, IWiaItem? pItemRoot, [MarshalAs(UnmanagedType.BStr)] string bstrFilename, ref Guid pguidFormat);

		/// <summary>
		/// The <c>IWiaDevMgr::RegisterEventCallbackProgram</c> method registers an application to receive device events. It is
		/// primarily provided for backward compatibility with applications that were not written for WIA.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies registration flags. Can be set to the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Registration Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WIA_REGISTER_EVENT_CALLBACK</term>
		/// <term>Register for the event.</term>
		/// </item>
		/// <item>
		/// <term>WIA_UNREGISTER_EVENT_CALLBACK</term>
		/// <term>Delete the registration for the event.</term>
		/// </item>
		/// <item>
		/// <term>WIA_SET_DEFAULT_HANDLER</term>
		/// <term>Set the application as the default event handler.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bstrDeviceID">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies a device identifier. Pass <c>NULL</c> to register for the event on all WIA devices.</para>
		/// </param>
		/// <param name="pEventGUID">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Specifies the event for which the application is registering. For a list of valid event GUIDs, see WIA Event Identifiers.</para>
		/// </param>
		/// <param name="bstrCommandline">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>
		/// Specifies a string that contains the full path name and the appropriate command-line arguments needed to invoke the
		/// application. Two pairs of quotation marks should be used, for example, ""C:\Program Files\MyExe.exe" /arg1".
		/// </para>
		/// </param>
		/// <param name="bstrName">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>
		/// Specifies the name of the application. This name is displayed to the user when multiple applications register for the same event.
		/// </para>
		/// </param>
		/// <param name="bstrDescription">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>
		/// Specifies the description of the application. This description is displayed to the user when multiple applications register
		/// for the same event.
		/// </para>
		/// </param>
		/// <param name="bstrIcon">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>
		/// Specifies the icon that represents the application. The icon is displayed to the user when multiple applications register
		/// for the same event. The string contains the name of the application and the 0-based index of the icon (there may be more
		/// than one icon that represent application) separated by a comma. For example, "MyApp, 0".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use <c>IWiaDevMgr::RegisterEventCallbackProgram</c> to register for hardware device events of the type WIA_ACTION_EVENT.
		/// When an event occurs for which an application is registered, the application is launched and the event information is
		/// transmitted to the application.
		/// </para>
		/// <para>
		/// Applications use the EnumRegisterEventInfo method to retrieve a pointer to an enumerator object for event registration properties.
		/// </para>
		/// <para>
		/// An application can find whether an event is an action type or notification type (or both) event by examinging the
		/// <c>ulFlags</c> value of a WIA_DEV_CAP structure returned by event enumeration.
		/// </para>
		/// <para>
		/// Programs should only use the <c>IWiaDevMgr::RegisterEventCallbackProgram</c> method for backward compatibility with
		/// applications not written for the WIA architecture. New applications should use the Component Object Model (COM) interfaces
		/// provided by the WIA architecture. Specifically, they should call IWiaDevMgr::RegisterEventCallbackInterface or
		/// IWiaDevMgr::RegisterEventCallbackCLSID to register for device events.
		/// </para>
		/// <para>
		/// Typically, this method is called by an install program or a script. The install program or script registers the application
		/// to receive WIA device events. When the event occurs, the application will be started by the WIA run-time system.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-registereventcallbackprogram HRESULT
		// RegisterEventCallbackProgram( LONG lFlags, BSTR bstrDeviceID, const GUID *pEventGUID, BSTR bstrCommandline, BSTR bstrName,
		// BSTR bstrDescription, BSTR bstrIcon );
		void RegisterEventCallbackProgram(int lFlags, [MarshalAs(UnmanagedType.BStr)] string? bstrDeviceID, in Guid pEventGUID, [MarshalAs(UnmanagedType.BStr)] string bstrCommandline,
			[MarshalAs(UnmanagedType.BStr)] string bstrName, [MarshalAs(UnmanagedType.BStr)] string bstrDescription, [MarshalAs(UnmanagedType.BStr)] string bstrIcon);

		/// <summary>
		/// The <c>IWiaDevMgr::RegisterEventCallbackInterface</c> method registers a running application Windows Image Acquisition (WIA)
		/// event notification.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Currently unused. Should be set to zero.</para>
		/// </param>
		/// <param name="bstrDeviceID">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies a device identifier. Pass <c>NULL</c> to register for the event on all WIA devices.</para>
		/// </param>
		/// <param name="pEventGUID">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Specifies the event for which the application is registering. For a list of standard events, see WIA Event Identifiers.</para>
		/// </param>
		/// <param name="pIWiaEventCallback">
		/// <para>Type: <c>IWiaEventCallback*</c></para>
		/// <para>Pointer to the IWiaEventCallback interface that the WIA system used to send the event notification.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IUnknown**</c></para>
		/// <para>Receives the address of a pointer to the IUnknown interface.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Warning</c> Using the <c>IWiaDevMgr::RegisterEventCallbackInterface</c>, IWiaDevMgr2::RegisterEventCallbackInterface, and
		/// DeviceManager.RegisterEvent methods from the same process after the Still Image Service is restarted may cause an access
		/// violation, if the functions were used before the service was stopped.
		/// </para>
		/// <para>
		/// When they begin executing, WIA applications use this method to register to receive hardware device events of the type
		/// WIA_NOTIFICATION_EVENT. This prevents the application from being restarted when another event for which it is registered
		/// occurs. Once a program invokes <c>IWiaDevMgr::RegisterEventCallbackInterface</c> to register itself to receive WIA events
		/// from a device, the registered events are routed to the program by the WIA system.
		/// </para>
		/// <para>
		/// Applications use the EnumRegisterEventInfo method to retrieve a pointer to an enumerator object for event registration properties.
		/// </para>
		/// <para>
		/// An application can find whether an event is an action type or notification type (or both) event by examinging the
		/// <c>ulFlags</c> value of a WIA_DEV_CAP structure returned by event enumeration.
		/// </para>
		/// <para>
		/// Applications can unregister for events by using the IUnknown pointer returned through the pEventObject parameter to call the
		/// IUnknown::Release method.
		/// </para>
		/// <para>
		/// <c>Note</c> In a multi-threaded application, there is no guarantee that the event notification callback will come in on the
		/// same thread that registered the callback.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-registereventcallbackinterface HRESULT
		// RegisterEventCallbackInterface( LONG lFlags, BSTR bstrDeviceID, const GUID *pEventGUID, IWiaEventCallback
		// *pIWiaEventCallback, IUnknown **pEventObject );
		[return: MarshalAs(UnmanagedType.IUnknown)]
		object RegisterEventCallbackInterface(int lFlags, [MarshalAs(UnmanagedType.BStr), Optional] string? bstrDeviceID, in Guid pEventGUID, IWiaEventCallback pIWiaEventCallback);

		/// <summary>
		/// The <c>IWiaDevMgr::RegisterEventCallbackCLSID</c> method registers an application to receive events even if the application
		/// may not be running.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies registration flags. Can be set to the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Registration Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WIA_REGISTER_EVENT_CALLBACK</term>
		/// <term>Register for the event.</term>
		/// </item>
		/// <item>
		/// <term>WIA_UNREGISTER_EVENT_CALLBACK</term>
		/// <term>Delete the registration for the event.</term>
		/// </item>
		/// <item>
		/// <term>WIA_SET_DEFAULT_HANDLER</term>
		/// <term>Set the application as the default event handler.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="bstrDeviceID">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies a device identifier. Pass <c>NULL</c> to register for the event on all WIA devices.</para>
		/// </param>
		/// <param name="pEventGUID">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Specifies the event for which the application is registering. For a list of standard events, see WIA Event Identifiers.</para>
		/// </param>
		/// <param name="pClsID">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>
		/// Pointer to the application's class ID ( <c>CLSID</c>). The WIA run-time system uses the application's <c>CLSID</c> to start
		/// the application when an event occurs for which it is registered.
		/// </para>
		/// </param>
		/// <param name="bstrName">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the name of the application that registers for the event.</para>
		/// </param>
		/// <param name="bstrDescription">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies a text description of the application that registers for the event.</para>
		/// </param>
		/// <param name="bstrIcon">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the name of an image file to be used for the icon for the application that registers for the event.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// WIA applications use this method to register to receive hardware device events of the type WIA_ACTION_EVENT. Once programs
		/// call <c>IWiaDevMgr::RegisterEventCallbackCLSID</c>, they are registered to receive WIA device events even if they are not running.
		/// </para>
		/// <para>
		/// When the event occurs, the WIA system determines which application is registered to receive the event. It uses the
		/// CoCreateInstance function and the class ID specified in the pClsID parameter to create an instance of the application. It
		/// then calls the application's ImageEventCallback method to transmit the event information.
		/// </para>
		/// <para>An application can invoke the EnumRegisterEventInfo method to enumerate event registration information.</para>
		/// <para>
		/// An application can find whether an event is an action type or notification type (or both) event by examinging the
		/// <c>ulFlags</c> value of a WIA_DEV_CAP structure returned by event enumeration.
		/// </para>
		/// <para>
		/// If the application is not a registered Component Object Model (COM) component and is not compatible with the WIA
		/// architecture, developers should use IWiaDevMgr::RegisterEventCallbackProgram instead of this method.
		/// </para>
		/// <para>
		/// <c>Note</c> In a multi-threaded application, there is no guarantee that the event notification callback will come in on the
		/// same thread that registered the callback.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-registereventcallbackclsid HRESULT
		// RegisterEventCallbackCLSID( LONG lFlags, BSTR bstrDeviceID, const GUID *pEventGUID, const GUID *pClsID, BSTR bstrName, BSTR
		// bstrDescription, BSTR bstrIcon );
		void RegisterEventCallbackCLSID(int lFlags, [MarshalAs(UnmanagedType.BStr), Optional] string? bstrDeviceID, in Guid pEventGUID, in Guid pClsID,
			[MarshalAs(UnmanagedType.BStr)] string bstrName, [MarshalAs(UnmanagedType.BStr)] string bstrDescription, [MarshalAs(UnmanagedType.BStr)] string bstrIcon);

		/// <summary>This method is not implemented.</summary>
		/// <param name="hwndParent">Type: <c>HWND</c></param>
		/// <param name="lFlags">Type: <c>LONG</c></param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiadevmgr-adddevicedlg HRESULT AddDeviceDlg( HWND
		// hwndParent, LONG lFlags );
		void AddDeviceDlg(HWND hwndParent, int lFlags);
	}

	/// <summary>
	/// The <c>IWiaEventCallback</c> interface is used by applications to receive notification of Windows Image Acquisition (WIA)
	/// hardware device events. An application registers itself to receive event notifications by passing a pointer to the
	/// <c>IWiaEventCallback</c> interface to the IWiaDevMgr::RegisterEventCallbackInterface method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-iwiaeventcallback
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("ae6287b0-0084-11d2-973b-00a0c9068f2e"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWiaEventCallback
	{
		/// <summary>
		/// The <c>IWiaEventCallback::ImageEventCallback</c> method is invoked by the Windows Image Acquisition (WIA) run-time system
		/// when a hardware device event occurs.
		/// </summary>
		/// <param name="pEventGUID">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Specifies the unique identifier of the event. For a complete list of device events, see WIA Event Identifiers.</para>
		/// </param>
		/// <param name="bstrEventDescription">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the string description of the event.</para>
		/// </param>
		/// <param name="bstrDeviceID">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the unique identifier of the WIA device.</para>
		/// </param>
		/// <param name="bstrDeviceDescription">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the string description of the device.</para>
		/// </param>
		/// <param name="dwDeviceType">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Specifies the type of the device. See WIA Device Type Specifiers for a list of possible values.</para>
		/// </param>
		/// <param name="bstrFullItemName">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the full name of the WIA item that represents the device.</para>
		/// </param>
		/// <param name="pulEventType">
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>
		/// Pointer to a <c>ULONG</c> that specifies whether an event is a notification event, an action event, or both. A value of 1
		/// indicates a notification event, a value of 2 indicates an action event, and a value of 3 indicates that the event is of both
		/// notification and action type.
		/// </para>
		/// </param>
		/// <param name="ulReserved">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Reserved for user information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To receive notification of WIA hardware device events, applications pass a pointer to the IWiaEventCallback interface to the
		/// RegisterEventCallbackInterface method. The WIA run-time system then uses that interface pointer to invoke the
		/// <c>IWiaEventCallback::ImageEventCallback</c> method whenever a WIA hardware device event occurs.
		/// </para>
		/// <para>
		/// Note that there is no guarantee the callback will be invoked on the same thread that registered the IWiaEventCallback interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaeventcallback-imageeventcallback HRESULT
		// ImageEventCallback( const GUID *pEventGUID, BSTR bstrEventDescription, BSTR bstrDeviceID, BSTR bstrDeviceDescription, DWORD
		// dwDeviceType, BSTR bstrFullItemName, ULONG *pulEventType, ULONG ulReserved );
		void ImageEventCallback(in Guid pEventGUID, [MarshalAs(UnmanagedType.BStr)] string bstrEventDescription, [MarshalAs(UnmanagedType.BStr)] string bstrDeviceID,
			[MarshalAs(UnmanagedType.BStr)] string bstrDeviceDescription, uint dwDeviceType, [MarshalAs(UnmanagedType.BStr)] string bstrFullItemName, ref uint pulEventType, uint ulReserved = 0);
	}

	/// <summary>
	/// Each Windows Image Acquisition (WIA) hardware device is represented to an application as a hierarchical tree of <c>IWiaItem</c>
	/// objects. The <c>IWiaItem</c> interface provides applications with the ability to query devices to discover their capabilities.
	/// It also provides access to data transfer interfaces and item properties. In addition, the <c>IWiaItem</c> interface provides
	/// methods to enable applications to control the device.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Some of the methods of the <c>IWiaItem</c> interface are valid only on the root item of the device's tree. Other methods are
	/// valid on all items. The methods are grouped as follows:
	/// </para>
	/// <list type="table">
	/// <item>
	/// <term>Valid On Root Item Only</term>
	/// <term>IWiaItem::DeviceCommand</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::DeviceDlg</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::EnumDeviceCapabilities</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::EnumRegisterEventInfo</term>
	/// </item>
	/// <item>
	/// <term>Valid On All Items</term>
	/// <term>IWiaItem::AnalyzeItem</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::CreateChildItem</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::DeleteItem</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::EnumChildItems</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::FindItemByName</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::GetItemType</term>
	/// </item>
	/// <item>
	/// <term/>
	/// <term>IWiaItem::GetRootItem</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-iwiaitem
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("4db1ad10-3391-11d2-9a33-00c04fa36145"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWiaItem
	{
		/// <summary>The <c>IWiaItem::GetItemType</c> method is called by applications to obtain the type information of an item.</summary>
		/// <returns>
		/// <para>Type: <c>LONG*</c></para>
		/// <para>Receives the address of a <c>LONG</c> variable that contains a combination of WIA Item Type Flags.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Every IWiaItem object in the hierarchical tree of objects associated with a Windows Image Acquisition (WIA) hardware device
		/// has a specific data type. Item objects represent folders and files. Folders contain file objects. File objects contain data
		/// acquired by the device such as images and sounds. This method enables applications to identify the type of any item in a
		/// hierarchical tree of item objects in a device.
		/// </para>
		/// <para>
		/// An item may have more than one type. For example, an item that represents an audio file will have the type attributes
		/// WiaItemTypeAudio | <c>WiaItemTypeFile</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-getitemtype HRESULT GetItemType( LONG *pItemType );
		WiaItemType GetItemType();

		/// <summary>
		/// The <c>IWiaItem::AnalyzeItem</c> method causes the Windows Image Acquisition (WIA) hardware device to acquire and try to
		/// detect what data types are present.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Currently unused. Should be set to zero.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// This method is used with scanners to detect what type of data is on a page. When an application calls this method, the WIA
		/// hardware device driver scans and analyzes the current page. For each data type it detects, it creates an IWiaItem object to
		/// represent the region on the page the data occupies.
		/// </para>
		/// <para>
		/// Image processing and OCR software can use this capability to detect graphics and text on a page. This method adds the
		/// regions it creates into the WIA device's IWiaItem tree. The application can select the individual regions and use the
		/// standard data transfer methods to acquire data from them.
		/// </para>
		/// <para>If necessary, applications can override the regions created by this method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-analyzeitem HRESULT AnalyzeItem( LONG lFlags );
		void AnalyzeItem(int lFlags = 0);

		/// <summary>
		/// The <c>IWiaItem::EnumChildItems</c> method creates an enumerator object and passes back a pointer to its IEnumWiaItem
		/// interface for non-empty folders in a IWiaItem tree of a Windows Image Acquisition (WIA) device.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IEnumWiaItem**</c></para>
		/// <para>Receives the address of a pointer to the IEnumWiaItem interface that <c>IWiaItem::EnumChildItems</c> creates.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The WIA run-time system represents each WIA hardware device as a hierarchical tree of IWiaItem objects. The
		/// <c>IWiaItem::EnumChildItems</c> method enables applications to enumerate child items in the current item. However, it can
		/// only be applied to items that are folders.
		/// </para>
		/// <para>
		/// If the folder is not empty, it contains a subtree of IWiaItem objects. The <c>IWiaItem::EnumChildItems</c> method enumerates
		/// all of the items contained in the folder. It stores a pointer to an enumerator in the ppIEnumWiaItem parameter. Applications
		/// use the enumerator pointer to perform the enumeration of an object's child items.
		/// </para>
		/// <para>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIEnumWiaItem parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-enumchilditems HRESULT EnumChildItems(
		// IEnumWiaItem **ppIEnumWiaItem );
		IEnumWiaItem EnumChildItems();

		/// <summary>The <c>IWiaItem::DeleteItem</c> method removes the current IWiaItem object from the object tree of the device.</summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Currently unused. Should be set to zero.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns S_OK regardless of how many items were deleted. If the method fails, it returns a standard COM error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The Windows Image Acquisition (WIA) run-time system represents each WIA hardware device connected to the user's computer as
		/// a hierarchical tree of IWiaItem objects. A given WIA device may or may not allow applications to delete <c>IWiaItem</c>
		/// objects from its tree. Use the IEnumWIA_DEV_CAPS interface to query the device for item deletion capability.
		/// </para>
		/// <para>
		/// If the device supports item deletion in its IWiaItem tree, invoke the <c>IWiaItem::DeleteItem</c> method to remove the
		/// <c>IWiaItem</c> object. Note that this method will only delete an object after all references to the object have been released.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-deleteitem HRESULT DeleteItem( LONG lFlags );
		void DeleteItem(int lFlags = 0);

		/// <summary>
		/// The <c>IWiaItem::CreateChildItem</c> method is used by applications to add IWiaItem objects to the <c>IWiaItem</c> tree of a device.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies the WIA item type. Must be set to one of the values listed in WIA Item Type Flags.</para>
		/// </param>
		/// <param name="bstrItemName">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the WIA item name, such as "Top". You can think of this parameter as being equivalent to a file name.</para>
		/// </param>
		/// <param name="bstrFullItemName">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>
		/// Specifies the full WIA item name. You can think of this parameter as equivalent to a full path to a file, such as "003\Root\Top".
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWiaItem**</c></para>
		/// <para>Receives the address of a pointer to the IWiaItem interface that sets the <c>IWiaItem::CreateChildItem</c> method.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Some WIA hardware devices allow applications to create new items in the IWiaItem tree that represents the device.
		/// Applications must test the devices to see if they support this capability. Use the IEnumWIA_DEV_CAPS interface to enumerate
		/// the current device's capabilities.
		/// </para>
		/// <para>
		/// If the device allows the creation of new items in the IWiaItem tree, invoking <c>IWiaItem::CreateChildItem</c> creates a new
		/// <c>IWiaItem</c> that is a child of the current node. <c>IWiaItem::CreateChildItem</c> passes a pointer to the new node to
		/// the application through the ppIWiaItem parameter.
		/// </para>
		/// <para>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIWiaItem parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-createchilditem HRESULT CreateChildItem( LONG
		// lFlags, BSTR bstrItemName, BSTR bstrFullItemName, IWiaItem **ppIWiaItem );
		IWiaItem CreateChildItem(WiaItemType lFlags, [MarshalAs(UnmanagedType.BStr)] string bstrItemName, [MarshalAs(UnmanagedType.BStr)] string bstrFullItemName);

		/// <summary>
		/// The <c>IWiaItem::EnumRegisterEventInfo</c> method creates an enumerator used to obtain information about events for which an
		/// application is registered.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Currently unused. Should be set to zero.</para>
		/// </param>
		/// <param name="pEventGUID">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>Pointer to an identifier that specifies the hardware event for which you want registration information.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IEnumWIA_DEV_CAPS**</c></para>
		/// <para>Receives the address of a pointer to the IEnumWIA_DEV_CAPS interface.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application invokes this method to create an enumerator object for the event information.
		/// <c>IWiaItem::EnumRegisterEventInfo</c> stores the address of the IEnumWIA_DEV_CAPS interface of the enumerator object in the
		/// ppIEnum parameter. The program then uses the interface pointer to enumerate the properties of the event for which it is registered.
		/// </para>
		/// <para>
		/// Each WIA_DEV_CAP structure includes an indication of whether the event is of type WIA_NOTIFICATION_EVENT or WIA_ACTION_EVENT
		/// or both.
		/// </para>
		/// <para>Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIEnum parameter.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-enumregistereventinfo HRESULT
		// EnumRegisterEventInfo( LONG lFlags, const GUID *pEventGUID, IEnumWIA_DEV_CAPS **ppIEnum );
		IEnumWIA_DEV_CAPS EnumRegisterEventInfo([Optional] int lFlags, in Guid pEventGUID);

		/// <summary>
		/// The <c>IWiaItem::FindItemByName</c> method searches an item's tree of sub-items using the name as the search key. Each
		/// IWiaItem object has a name as one of its standard properties.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Currently unused. Should be set to zero.</para>
		/// </param>
		/// <param name="bstrFullItemName">
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies the name of the item for which to search.</para>
		/// </param>
		/// <param name="ppIWiaItem">
		/// <para>Type: <c>IWiaItem**</c></para>
		/// <para>Pointer to the IWiaItem interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>
		/// This method returns S_OK if it finds the item, or S_FALSE if it does not find the item. If the method fails, it returns a
		/// standard COM error code.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method searches the current item's tree of sub-items using the name as the search key. If
		/// <c>IWiaItem::FindItemByName</c> finds the item specified by bstrFullItemName, it stores the address of a pointer to the
		/// IWiaItem interface of the item in the ppIWiaItem parameter.
		/// </para>
		/// <para>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIWiaItem parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-finditembyname HRESULT FindItemByName( LONG
		// lFlags, BSTR bstrFullItemName, IWiaItem **ppIWiaItem );
		[PreserveSig]
		HRESULT FindItemByName([Optional] int lFlags, [MarshalAs(UnmanagedType.BStr)] string bstrFullItemName, out IWiaItem ppIWiaItem);

		/// <summary>
		/// The <c>IWiaItem::DeviceDlg</c> method is used by applications to display a dialog box to the user to prepare for image acquisition.
		/// </summary>
		/// <param name="hwndParent">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Handle of the parent window of the dialog box.</para>
		/// </param>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies a set of flags that control the dialog box's operation. Can be set to any of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>0</term>
		/// <term>Default behavior.</term>
		/// </item>
		/// <item>
		/// <term>WIA_DEVICE_DIALOG_SINGLE_IMAGE</term>
		/// <term>Restrict image selection to a single image in the device image acquisition dialog box.</term>
		/// </item>
		/// <item>
		/// <term>WIA_DEVICE_DIALOG_USE_COMMON_UI</term>
		/// <term>
		/// Use the system UI, if available, rather than the vendor-supplied UI. If the system UI is not available, the vendor UI is
		/// used. If neither UI is available, the function returns E_NOTIMPL.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lIntent">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies what type of data the image is intended to represent. For a list of image intent values, see Image Intent Constants.
		/// </para>
		/// <para><c>Note</c> This method ignores all WIA_INTENT_IMAGE_* image intents.</para>
		/// </param>
		/// <param name="plItemCount">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>Receives the number of items in the array indicated by the ppIWiaItem parameter.</para>
		/// </param>
		/// <param name="ppIWiaItem">
		/// <para>Type: <c>IWiaItem***</c></para>
		/// <para>Receives the address of an array of pointers to IWiaItem interfaces.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method displays a dialog box to the user that an application uses to gather all the information required for image
		/// acquisition. For instance, this dialog box enables the user to select images to download from a camera. When using a
		/// scanner, it is also used to specify image scan properties such as brightness and contrast.
		/// </para>
		/// <para>After this method returns, the application can use the IWiaDataTransfer interface to acquire the image.</para>
		/// <para>
		/// Applications must call the IUnknown::Release method for each element in the array of interface pointers they receive through
		/// the ppIWiaItem parameter. Applications must also free the array using CoTaskMemFree.
		/// </para>
		/// <para>
		/// It is recommended that applications make device and image selection available through a menu item named <c>From scanner or
		/// camera</c> on the <c>File</c> menu.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-devicedlg HRESULT DeviceDlg( HWND hwndParent,
		// LONG lFlags, LONG lIntent, LONG *plItemCount, IWiaItem ***ppIWiaItem );
		void DeviceDlg(HWND hwndParent, WiaDevDlg lFlags, WiaImageIntent lIntent, out int plItemCount, out SafeCoTaskMemHandle ppIWiaItem);

		/// <summary>The <c>IWiaItem::DeviceCommand</c> issues a command to a Windows Image Acquisition (WIA) hardware device.</summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Currently unused. Should be set to zero.</para>
		/// </param>
		/// <param name="pCmdGUID">
		/// <para>Type: <c>const GUID*</c></para>
		/// <para>
		/// Specifies a unique identifier that specifies the command to send to the WIA hardware device. For a list of valid device
		/// commands, see WIA Device Commands.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IWiaItem**</c></para>
		/// <para>On output, this pointer points to the item created by the command, if any.</para>
		/// </returns>
		/// <remarks>
		/// <para>Applications use this method to send WIA commands to hardware devices.</para>
		/// <para>
		/// When the application sends the WIA_CMD_TAKE_PICTURE command to the device, <c>IWiaItem::DeviceCommand</c>, the WIA run-time
		/// system creates the IWiaItem object to represent the image. The <c>IWiaItem::DeviceCommand</c> method stores the address of
		/// the interface in the pIWiaItem parameter.
		/// </para>
		/// <para>Applications must call the IUnknown::Release method on the interface pointers they receive through the pIWiaItem parameter.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-devicecommand HRESULT DeviceCommand( LONG
		// lFlags, const GUID *pCmdGUID, IWiaItem **pIWiaItem );
		IWiaItem DeviceCommand([Optional] int lFlags, in Guid pCmdGUID);

		/// <summary>
		/// The <c>IWiaItem::GetRootItem</c> method retrieves the root item of a tree of item objects used to represent a Windows Image
		/// Acquisition (WIA) hardware device.
		/// </summary>
		/// <returns>
		/// <para>Type: <c>IWiaItem**</c></para>
		/// <para>
		/// Receives the address of a pointer to the IWiaItem interface that contains a pointer to the <c>IWiaItem</c> interface of the
		/// root item.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Given any IWiaItem object in the object tree of a WIA hardware device, the application retrieves a pointer to the root item
		/// by calling this function.
		/// </para>
		/// <para>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIWiaItem parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-getrootitem HRESULT GetRootItem( IWiaItem
		// **ppIWiaItem );
		IWiaItem GetRootItem();

		/// <summary>
		/// The <c>IWiaItem::EnumDeviceCapabilities</c> method creates an enumerator that is used to ascertain the commands and events a
		/// Windows Image Acquisition (WIA) device supports.
		/// </summary>
		/// <param name="lFlags">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies a flag that selects the type of capabilities to enumerate. Can be set to one or more of the following values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WIA_DEVICE_COMMANDS</term>
		/// <term>Enumerate device commands.</term>
		/// </item>
		/// <item>
		/// <term>WIA_DEVICE_EVENTS</term>
		/// <term>Enumerate device events.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IEnumWIA_DEV_CAPS**</c></para>
		/// <para>Pointer to IEnumWIA_DEV_CAPS interface created by <c>IWiaItem::EnumDeviceCapabilities</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use this method to create an enumerator object to obtain the set of commands and events that a WIA device supports. You can
		/// use the lFlags parameter to specify which kinds of device capabilities to enumerate. The
		/// <c>IWiaItem::EnumDeviceCapabilities</c> method stores the address of the interface of the enumerator object in the
		/// ppIEnumWIA_DEV_CAPS parameter.
		/// </para>
		/// <para>
		/// Applications must call the IUnknown::Release method on the interface pointers they receive through the ppIEnumWIA_DEV_CAPS parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-enumdevicecapabilities HRESULT
		// EnumDeviceCapabilities( LONG lFlags, IEnumWIA_DEV_CAPS **ppIEnumWIA_DEV_CAPS );
		IEnumWIA_DEV_CAPS EnumDeviceCapabilities(WiaDevCap lFlags);

		/// <summary>This method is not supported.</summary>
		/// <returns>Type: <c>BSTR*</c></returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-dumpitemdata HRESULT DumpItemData( BSTR
		// *bstrData );
		[return: MarshalAs(UnmanagedType.BStr)]
		string DumpItemData();

		/// <summary>This method is not supported.</summary>
		/// <returns>Type: <c>BSTR*</c></returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-dumpdrvitemdata HRESULT DumpDrvItemData( BSTR
		// *bstrData );
		[return: MarshalAs(UnmanagedType.BStr)]
		string DumpDrvItemData();

		/// <summary>This method is not supported.</summary>
		/// <returns>Type: <c>BSTR*</c></returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-dumptreeitemdata HRESULT DumpTreeItemData( BSTR
		// *bstrData );
		[return: MarshalAs(UnmanagedType.BStr)]
		string DumpTreeItemData();

		/// <summary>This method is not supported.</summary>
		/// <param name="ulSize">Type: <c>ULONG</c></param>
		/// <param name="pBuffer">Type: <c>BYTE*</c></param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitem-diagnostic HRESULT Diagnostic( ULONG ulSize,
		// BYTE *pBuffer );
		void Diagnostic(uint ulSize, IntPtr pBuffer);
	}

	/// <summary>
	/// The <c>IWiaItemExtras</c> interface provides several methods that enable applications to communicate with hardware drivers.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IWiaItemExtras</c> interface, like all Component Object Model (COM) interfaces, inherits the IUnknown interface methods.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>IUnknown Methods</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IUnknown::QueryInterface</term>
	/// <term>Returns pointers to supported interfaces.</term>
	/// </item>
	/// <item>
	/// <term>IUnknown::AddRef</term>
	/// <term>Increments reference count.</term>
	/// </item>
	/// <item>
	/// <term>IUnknown::Release</term>
	/// <term>Decrements reference count.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-iwiaitemextras
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("6291ef2c-36ef-4532-876a-8e132593778d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWiaItemExtras
	{
		/// <summary>
		/// The <c>IWiaItemExtras::GetExtendedErrorInfo</c> method gets a string from the device driver that contains information about
		/// the most recent error. Call this method after an error during an operation on a Windows Image Acquisition (WIA) item (such
		/// as data transfer).
		/// </summary>
		/// <returns>
		/// <para>Type: <c>BSTR*</c></para>
		/// <para>Pointer to a string that contains the error information.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitemextras-getextendederrorinfo HRESULT
		// GetExtendedErrorInfo( BSTR *bstrErrorText );
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetExtendedErrorInfo();

		/// <summary>
		/// The <c>IWiaItemExtras::Escape</c> method sends a request for a vendor-specific I/O operation to a still image device.
		/// </summary>
		/// <param name="dwEscapeCode">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Calling application-supplied, vendor-defined, DWORD-sized value that represents an I/O operation.</para>
		/// </param>
		/// <param name="lpInData">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to a calling application-supplied buffer that contains data to be sent to the device.</para>
		/// </param>
		/// <param name="cbInDataSize">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Calling application-supplied length, in bytes, of the data contained in the buffer pointed to by lpInData.</para>
		/// </param>
		/// <param name="pOutData">
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Pointer to a calling application-supplied memory buffer to receive data from the device.</para>
		/// </param>
		/// <param name="dwOutDataSize">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>Calling application-supplied length, in bytes, of the buffer pointed to by pOutData.</para>
		/// </param>
		/// <param name="pdwActualDataSize">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>Receives the number of bytes actually written to pOutData.</para>
		/// </param>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitemextras-escape HRESULT Escape( DWORD dwEscapeCode,
		// BYTE *lpInData, DWORD cbInDataSize, BYTE *pOutData, DWORD dwOutDataSize, DWORD *pdwActualDataSize );
		void Escape(uint dwEscapeCode, IntPtr lpInData, uint cbInDataSize, IntPtr pOutData, uint dwOutDataSize, out uint pdwActualDataSize);

		/// <summary>The <c>IWiaItemExtras::CancelPendingIO</c> method cancels all pending input/output operations on the driver.</summary>
		/// <remarks>Drivers are not required to support this method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiaitemextras-cancelpendingio HRESULT CancelPendingIO();
		void CancelPendingIO();
	}

	/// <summary>
	/// The <c>IWiaPropertyStorage</c> interface is used to access information about the IWiaItem object's properties. Applications must
	/// query an item to obtain its <c>IWiaPropertyStorage</c> interface.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The <c>IWiaPropertyStorage</c> interface includes several methods that are very similar to the following methods from the <see
	/// cref="IPropertyStorage"/> interface. The descriptions and remarks for the IPropertyStorage version of these methods applies to
	/// the <c>IWiaPropertyStorage</c> as well.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>IPropertyStorage Methods</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>IPropertyStorage::ReadMultiple</term>
	/// <term>Reads property values in a property set.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::WriteMultiple</term>
	/// <term>Writes property values in a property set.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::DeleteMultiple</term>
	/// <term>Deletes properties in a property set.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::ReadPropertyNames</term>
	/// <term>Gets string names that correspond to given property identifiers.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::WritePropertyNames</term>
	/// <term>Creates or changes string names that corresponds to given property identifiers.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::DeletePropertyNames</term>
	/// <term>Deletes string names for given property identifiers.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::SetClass</term>
	/// <term>Assigns a CLSID to the property set.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::Commit</term>
	/// <term>As in IStorage::Commit, flushes or commits changes to the property storage object.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::Revert</term>
	/// <term>When the property storage is opened in transacted mode, discards all changes since the last commit.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::Enum</term>
	/// <term>Creates and gets a pointer to an enumerator for properties within this set.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::Stat</term>
	/// <term>Receives statistics about this property set.</term>
	/// </item>
	/// <item>
	/// <term>IPropertyStorage::SetTimes</term>
	/// <term>Sets modification, creation, and access times for the property set.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nn-wia_xp-iwiapropertystorage
	[PInvokeData("wia_xp.h")]
	[ComImport, Guid("98B5E8A0-29CC-491a-AAC0-E6DB4FDCCEB6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IWiaPropertyStorage
	{
		/// <summary>
		/// <para>The <c>ReadMultiple</c> method reads specified properties from the current property set.</para>
		/// </summary>
		/// <param name="cpspec">
		/// <para>
		/// The numeric count of properties to be specified in the array. The value of this parameter can be set to zero; however, that
		/// defeats the purpose of the method as no properties are thereby read, regardless of the values set in .
		/// </para>
		/// </param>
		/// <param name="rgpspec">
		/// <para>
		/// An array of PROPSPEC structures specifies which properties are read. Properties can be specified either by a property ID or
		/// by an optional string name. It is not necessary to specify properties in any particular order in the array. The array can
		/// contain duplicate properties, resulting in duplicate property values on return for simple properties. Nonsimple properties
		/// should return access denied on an attempt to open them a second time. The array can contain a mixture of property IDs and
		/// string IDs.
		/// </para>
		/// </param>
		/// <param name="rgpropvar">
		/// <para>
		/// Caller-allocated array of a PROPVARIANT structure that, on return, contains the values of the properties specified by the
		/// corresponding elements in the array. The array must be at least large enough to hold values of the parameter of the
		/// <c>PROPVARIANT</c> structure. The parameter specifies the number of properties set in the array. The caller is not required
		/// to initialize these <c>PROPVARIANT</c> structure values in any specific order. However, the implementation must fill all
		/// members correctly on return. If there is no other appropriate value, the implementation must set the <c>vt</c> member of
		/// each <c>PROPVARIANT</c> structure to <c>VT_EMPTY</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following:</para>
		/// <para>
		/// This function can also return any file system errors or Win32 errors wrapped in an <c>HRESULT</c> data type. For more
		/// information, see Error Handling Strategies.
		/// </para>
		/// <para>For more information, see Property Storage Considerations.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-readmultiple
		[PreserveSig]
		HRESULT ReadMultiple(uint cpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPVARIANT[] rgpropvar);

		/// <summary>
		/// <para>
		/// The <c>WriteMultiple</c> method writes a specified group of properties to the current property set. If a property with a
		/// specified name or property identifier already exists, it is replaced, even when the old and new types for the property value
		/// are different. If a property of a given name or property ID does not exist, it is created.
		/// </para>
		/// </summary>
		/// <param name="cpspec">
		/// <para>
		/// The number of properties set. The value of this parameter can be set to zero; however, this defeats the purpose of the
		/// method as no properties are then written.
		/// </para>
		/// </param>
		/// <param name="rgpspec">
		/// <para>
		/// An array of the property IDs (PROPSPEC) to which properties are set. These need not be in any particular order, and may
		/// contain duplicates, however the last specified property ID is the one that takes effect. A mixture of property IDs and
		/// string names is permitted.
		/// </para>
		/// </param>
		/// <param name="rgpropvar">
		/// <para>
		/// An array (of size ) of PROPVARIANT structures that contain the property values to be written. The array must be the size
		/// specified by .
		/// </para>
		/// </param>
		/// <param name="propidNameFirst">
		/// <para>
		/// The minimum value for the property IDs that the method must assign if the parameter specifies string-named properties for
		/// which no property IDs currently exist. If all string-named properties specified already exist in this set, and thus already
		/// have property IDs, this value is ignored. When not ignored, this value must be greater than, or equal to, two and less than
		/// 0x80000000. Property IDs 0 and 1 and greater than 0x80000000 are reserved for special use.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// <para>
		/// This function can also return any file system errors or Win32 errors wrapped in an <c>HRESULT</c> data type. For more
		/// information, see Error Handling Strategies.
		/// </para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If a specified property already exists, its value is replaced with the one specified in , even when the old and new types
		/// for the property value are different. If the specified property does not already exist, that property is created. The
		/// changes are not persisted to the underlying storage until IPropertyStorage::Commit has been called.
		/// </para>
		/// <para>
		/// Property names are stored in a special dictionary section of the property set, which maps such names to property IDs. All
		/// properties have an ID, but names are optional. A string name is supplied by specifying PRSPEC_LPWSTR in the <c>ulKind</c>
		/// member of the PROPSPEC structure. If a string name is supplied for a property, and the name does not already exist in the
		/// dictionary, the method will allocate a property ID, and add the property ID and the name to the dictionary. The property ID
		/// is allocated in such a way that it does not conflict with other IDs in the property set. The value of the property ID also
		/// is no less than the value specified by the parameter. If the parameter specifies string-named properties for which no
		/// property IDs currently exist, the parameter specifies the minimum value for the property IDs that the <c>WriteMultiple</c>
		/// method must assign.
		/// </para>
		/// <para>
		/// When a new property set is created, the special <c>codepage (</c> Property ID 1 <c>)</c> and <c>Locale ID (</c> Property ID
		/// 0x80000000 <c>)</c> properties are written to the property set automatically. These properties can subsequently be read,
		/// using the IPropertyStorage::ReadMultiple method, by specifying property IDs with the header-defined PID_CODEPAGE and
		/// PID_LOCALE values, respectively. If a property set is non-empty — has one or more properties in addition to the
		/// <c>codepage</c> and <c>Locale ID</c> properties or has one or more names in its dictionary — the special <c>codepage</c> and
		/// <c>Locale ID</c> properties cannot be modified by calling <c>IPropertyStorage::WriteMultiple</c>. However, if the property
		/// set is empty, one or both of these special properties can be modified.
		/// </para>
		/// <para>
		/// If an element in the array is set with a PRSPEC_PROPID value of 0xffffffff (PID_ILLEGAL), the corresponding value in the
		/// array is ignored by <c>IPropertyStorage::WriteMultiple</c>. For example, if this method is called with the parameter set to
		/// 3, but is set to PRSPEC_PROPID and is set to PID_ILLEGAL, only two properties will be written. The element is silently ignored.
		/// </para>
		/// <para>Use the PropVariantInit macro to initialize PROPVARIANT structures.</para>
		/// <para>
		/// Property sets, not including the data for nonsimple properties, are limited to 256 KB in size for Windows NT 4.0 and
		/// earlier. For Windows 2000, Windows XP and Windows Server 2003, OLE property sets are limited to 1 MB. If these limits are
		/// exceeded, the operation fails and the caller receives an error message. There is no possibility of a memory leak or overrun.
		/// For more information, see Managing Property Sets.
		/// </para>
		/// <para>
		/// Unless PROPSETFLAG_CASE_SENSITIVE is passed to IPropertySetStorage::Create, property set names are case insensitive.
		/// Specifying a property by its name in <c>IPropertyStorage::WriteMultiple</c> will result in a case-insensitive search of the
		/// names in the property set. To compare case-insensitive strings, the locale of the strings must be known. For more
		/// information, see IPropertyStorage::WritePropertyNames.
		/// </para>
		/// <para>For more information, see Property Storage Considerations.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-writemultiple
		[PreserveSig]
		HRESULT WriteMultiple(uint cpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPVARIANT[] rgpropvar, uint propidNameFirst);

		/// <summary>
		/// <para>The <c>DeleteMultiple</c> method deletes as many of the indicated properties as exist in this property set.</para>
		/// </summary>
		/// <param name="cpspec">
		/// <para>
		/// The numerical count of properties to be deleted. The value of this parameter can legally be set to zero, however that
		/// defeats the purpose of the method as no properties are thereby deleted, regardless of the value set in .
		/// </para>
		/// </param>
		/// <param name="rgpspec">
		/// <para>
		/// Properties to be deleted. A mixture of property identifiers and string-named properties is permitted. There may be
		/// duplicates, and there is no requirement that properties be specified in any order.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>IPropertyStorage::DeleteMultiple</c> must delete as many of the indicated properties as are in the current property set.
		/// If a deletion of a stream- or storage-valued property occurs while that property is open, the deletion will succeed and
		/// place the previously returned IStream or IStorage pointer in the reverted state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-deletemultiple
		[PreserveSig]
		HRESULT DeleteMultiple(uint cpspec, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec);

		/// <summary>
		/// <para>The <c>ReadPropertyNames</c> method retrieves any existing string names for the specified property IDs.</para>
		/// </summary>
		/// <param name="cpropid">
		/// <para>
		/// The number of elements on input of the array . The value of this parameter can be set to zero, however that defeats the
		/// purpose of this method as no property names are thereby read.
		/// </para>
		/// </param>
		/// <param name="rgpropid">
		/// <para>An array of property IDs for which names are to be retrieved.</para>
		/// </param>
		/// <param name="rglpwstrName">
		/// <para>
		/// A caller-allocated array of size of <c>PWSTR</c> members. On return, the implementation fills in this array. A given entry
		/// contains either the corresponding string name of a property ID or it can be empty if the property ID has no string names.
		/// </para>
		/// <para>Each <c>PWSTR</c> member of the array should be freed using the CoTaskMemFree function.</para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For each property ID in the list of property IDs supplied in the array, <c>ReadPropertyNames</c> retrieves the corresponding
		/// string name, if there is one. String names are created either by specifying the names in calls to
		/// IPropertyStorage::WriteMultiple when creating the property, or through a call to IPropertyStorage::WritePropertyNames. In
		/// either case, the string name is optional, however all properties must have a property ID.
		/// </para>
		/// <para>String names mapped to property IDs must be unique within the set.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-readpropertynames
		[PreserveSig]
		HRESULT ReadPropertyNames(uint cpropid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgpropid, [In, Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rglpwstrName);

		/// <summary>
		/// <para>
		/// The <c>WritePropertyNames</c> method assigns string IPropertyStoragenames to a specified array of property IDs in the
		/// current property set.
		/// </para>
		/// </summary>
		/// <param name="cpropid">
		/// <para>The size on input of the array . Can be zero. However, making it zero causes this method to become non-operational.</para>
		/// </param>
		/// <param name="rgpropid">
		/// <para>An array of the property IDs for which names are to be set.</para>
		/// </param>
		/// <param name="rglpwstrName">
		/// <para>
		/// An array of new names to be assigned to the corresponding property IDs in the array. These names may not exceed 255
		/// characters (not including the <c>NULL</c> terminator).
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value <c>E_UNEXPECTED</c>, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>For more information about property sets and memory management, see Managing Property Sets.</para>
		/// <para>
		/// <c>IPropertyStorage::WritePropertyNames</c> assigns string names to property IDs passed to the method in the array. It
		/// associates each string name in the array with the respective property ID in . It is explicitly valid to define a name for a
		/// property ID that is not currently present in the property storage object.
		/// </para>
		/// <para>
		/// It is also valid to change the mapping for an existing string name (determined by a case-insensitive match). That is, you
		/// can use the <c>WritePropertyNames</c> method to map an existing name to a new property ID, or to map a new name to a
		/// property ID that already has a name in the dictionary. In either case, the original mapping is deleted. Property names must
		/// be unique (as are property IDs) within the property set.
		/// </para>
		/// <para>
		/// The storage of string property names preserves the case. Unless <c>PROPSETFLAG_CASE_SENSITIVE</c> is passed to
		/// IPropertySetStorage::Create, property set names are case insensitive by default. With case-insensitive property sets, the
		/// name strings passed by the caller are interpreted according to the locale of the property set, as specified by the
		/// <c>PID_LOCALE</c> property. If the property set has no locale property, the current user is assumed by default. String
		/// property names are limited in length to 128 characters. Property names that begin with the binary Unicode characters 0x0001
		/// through 0x001F are reserved for future use.
		/// </para>
		/// <para>
		/// If the value of an element in the array parameter is set to 0xffffffff (PID_ILLEGAL), the corresponding name is ignored by
		/// <c>IPropertyStorage::WritePropertyNames</c>. For example, if this method is called with a parameter of 3, but the first
		/// element of the array, , is set to <c>PID_ILLEGAL</c>, then only two property names are written. The element is ignored.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-writepropertynames
		[PreserveSig]
		HRESULT WritePropertyNames(uint cpropid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgpropid, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 0)] string[] rglpwstrName);

		/// <summary>
		/// <para>The <c>DeletePropertyNames</c> method deletes specified string names from the current property set.</para>
		/// </summary>
		/// <param name="cpropid">
		/// <para>The size on input of the array . If 0, no property names are deleted.</para>
		/// </param>
		/// <param name="rgpropid">
		/// <para>Property identifiers for which string names are to be deleted.</para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For each property identifier in , <c>IPropertyStorage::DeletePropertyNames</c> removes any corresponding name-to-property ID
		/// mapping. An attempt is silently ignored to delete the name of a property that either does not exist or does not currently
		/// have a string name associated with it. This method has no effect on the properties themselves.
		/// </para>
		/// <para>
		/// <c>Note</c> All the stored string property names can be deleted by deleting property identifier zero, but must be equal to 1
		/// for this to be a valid parameter error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-deletepropertynames
		[PreserveSig]
		HRESULT DeletePropertyNames(uint cpropid, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] uint[] rgpropid);

		/// <summary>
		/// <para>The <c>IPropertyStorage::Commit</c> method saves changes made to a property storage object to the parent storage object.</para>
		/// </summary>
		/// <param name="grfCommitFlags">
		/// <para>
		/// The flags that specify the conditions under which the commit is to be performed. For more information about specific flags
		/// and their meanings, see the Remarks section.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, as well as the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Like IStorage::Commit, the <c>IPropertyStorage::Commit</c> method ensures that any changes made to a property storage object
		/// are reflected in the parent storage.
		/// </para>
		/// <para>
		/// In direct mode in the compound file implementation, a call to this method causes any changes currently in the memory buffers
		/// to be flushed to the underlying property stream. In the compound-file implementation for nonsimple property sets,
		/// IStorage::Commit is also called on the underlying substorage object with the passed parameter.
		/// </para>
		/// <para>
		/// In transacted mode, this method causes the changes to be permanently reflected in the persistent image of the storage
		/// object. The changes that are committed must have been made to this property set since it was opened or since the last commit
		/// on this opening of the property set. The <c>commit</c> method publishes the changes made on one object level to the next
		/// level. Of course, this remains subject to any outer-level transaction that may be present on the object in which this
		/// property set is contained. Write permission must be specified when the property set is opened (through IPropertySetStorage)
		/// on the property set opening for the commit operation to succeed.
		/// </para>
		/// <para>
		/// If the commit operation fails for any reason, the state of the property storage object remains as it was before the commit.
		/// </para>
		/// <para>
		/// This call has no effect on existing storage- or stream-valued properties opened from this property storage, but it does
		/// commit them.
		/// </para>
		/// <para>Valid values for the parameter are listed in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>STGC_DEFAULT</term>
		/// <term>Commits per the usual transaction semantics. Last writer wins. This flag may not be specified with other flag values.</term>
		/// </item>
		/// <item>
		/// <term>STGC_ONLYIFCURRENT</term>
		/// <term>
		/// Commits the changes only if the current persistent contents of the property set are the ones on which the changes about to
		/// be committed are based. That is, does not commit changes if the contents of the property set have been changed by a commit
		/// from another opening of the property set. The error STG_E_NOTCURRENT is returned if the commit does not succeed for this reason.
		/// </term>
		/// </item>
		/// <item>
		/// <term>STGC_OVERWRITE</term>
		/// <term>
		/// Useful only when committing a transaction that has no further outer nesting level of transactions, though acceptable in all cases.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Using <c>IPropertyStorage::Commit</c> to write properties to image files on Windows XP does not work. Affected
		/// image file formats include:Due to a bug in the image file property handler on Windows XP, calling
		/// <c>IPropertyStorage::Commit</c> actually discards any changes made rather than persisting them.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-commit
		[PreserveSig]
		HRESULT Commit(uint grfCommitFlags);

		/// <summary>
		/// <para>
		/// The <c>Revert</c> method discards all changes to the named property set since it was last opened or discards changes that
		/// were last committed to the property set. This method has no effect on a direct-mode property set.
		/// </para>
		/// </summary>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// For transacted-mode property sets, this method discards all changes that have been made in this property set since the set
		/// was opened or since the time it was last committed, (whichever is later). After this operation, any existing storage- or
		/// stream-valued properties that have been opened from the property set being reverted are no longer valid and cannot be used.
		/// The error STG_E_REVERTED will be returned on all calls, except those to <c>Release</c>, using these streams or storages.
		/// </para>
		/// <para>For direct-mode property sets, this request is ignored and returns S_OK.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-revert
		[PreserveSig]
		HRESULT Revert();

		/// <summary>
		/// <para>
		/// The <c>Enum</c> method creates an enumerator object designed to enumerate data of type STATPROPSTG, which contains
		/// information on the current property set. On return, this method supplies a pointer to the IEnumSTATPROPSTG pointer on this object.
		/// </para>
		/// </summary>
		/// <param name="ppenum">
		/// <para>Pointer to IEnumSTATPROPSTG pointer variable that receives the interface pointer to the new enumerator object.</para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>IPropertyStorage::Enum</c> creates an enumeration object that can be used to iterate STATPROPSTG structures. On return,
		/// this method supplies a pointer to an instance of the IEnumSTATPROPSTG interface on this object, whose methods you can call
		/// to obtain information about the current property set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-enum
		[PreserveSig]
		HRESULT Enum(out IEnumSTATPROPSTG ppenum);

		/// <summary>
		/// <para>
		/// The <c>SetTimes</c> method sets the modification, access, and creation times of this property set, if supported by the
		/// implementation. Not all implementations support all these time values.
		/// </para>
		/// </summary>
		/// <param name="pctime">
		/// <para>
		/// Pointer to the new creation time for the property set. May be <c>NULL</c>, indicating that this time is not to be modified
		/// by this call.
		/// </para>
		/// </param>
		/// <param name="patime">
		/// <para>
		/// Pointer to the new access time for the property set. May be <c>NULL</c>, indicating that this time is not to be modified by
		/// this call.
		/// </para>
		/// </param>
		/// <param name="pmtime">
		/// <para>
		/// Pointer to the new modification time for the property set. May be <c>NULL</c>, indicating that this time is not to be
		/// modified by this call.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Sets the modification, access, and creation times of the current open property set, if supported by the implementation (not
		/// all implementations support all these time values). Unsupported time stamps are always reported as zero, enabling the caller
		/// to test for support. A call to IPropertyStorage::Stat supplies (among other data) time-stamp information.
		/// </para>
		/// <para>
		/// Notice that this functionality is provided as an IPropertyStorage method on a property-storage object that is already open,
		/// in contrast to being provided as a method in IPropertySetStorage. Normally, when the <c>SetTimes</c> method is not
		/// explicitly called, the access and modification times are updated as a side effect of reading and writing the property set.
		/// When <c>SetTimes</c> is used, the latest specified times supersede either default times or time values specified in previous
		/// calls to <c>SetTimes</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-settimes
		[PreserveSig]
		HRESULT SetTimes([In, Optional] PFILETIME? pctime, [In, Optional] PFILETIME? patime, [In, Optional] PFILETIME? pmtime);

		/// <summary>
		/// <para>
		/// The <c>SetClass</c> method assigns a new CLSID to the current property storage object, and persistently stores the CLSID
		/// with the object.
		/// </para>
		/// </summary>
		/// <param name="clsid">
		/// <para>New CLSID to be associated with the property set.</para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Assigns a CLSID to the current property storage object. The CLSID has no relationship to the stored property IDs. Assigning
		/// a CLSID allows a piece of code to be associated with a given instance of a property set; such code, for example, might
		/// manage the user interface (UI). Different CLSIDs can be associated with different property set instances that have the same FMTID.
		/// </para>
		/// <para>
		/// If the property set is created with the parameter of the IPropertySetStorage::Create method specified as <c>NULL</c>, the
		/// CLSID is set to all zeroes.
		/// </para>
		/// <para>
		/// The current CLSID on a property storage object can be retrieved with a call to IPropertyStorage::Stat. The initial value for
		/// the CLSID can be specified at the time that the storage is created with a call to IPropertySetStorage::Create.
		/// </para>
		/// <para>
		/// Setting the CLSID on a nonsimple property set (one that can legally contain storage- or stream-valued properties, as
		/// described in IPropertySetStorage::Create) also sets the CLSID on the underlying sub-storage.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-setclass
		[PreserveSig]
		HRESULT SetClass(in Guid clsid);

		/// <summary>
		/// <para>The <c>Stat</c> method retrieves information about the current open property set.</para>
		/// </summary>
		/// <param name="pstatpsstg">
		/// <para>Pointer to a STATPROPSETSTG structure, which contains statistics about the current open property set.</para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_UNEXPECTED, in addition to the following:</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>IPropertyStorage::Stat</c> fills in and returns a pointer to a STATPROPSETSTG structure, containing statistics about the
		/// current property set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/propidl/nf-propidl-ipropertystorage-stat
		[PreserveSig]
		HRESULT Stat(out STATPROPSETSTG pstatpsstg);

		/// <summary>
		/// The <c>IWiaPropertyStorage::GetPropertyAttributes</c> method retrieves access rights and legal value information for a
		/// specified set of properties.
		/// </summary>
		/// <param name="cpspec">
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Specifies the number of property attributes to query.</para>
		/// </param>
		/// <param name="rgpspec">
		/// <para>Type: <c>PROPSPEC[]</c></para>
		/// <para>Specifies an array of Device Information Property Constants. Each constant in the array selects a property to query.</para>
		/// </param>
		/// <param name="rgflags">
		/// <para>Type: <c>ULONG[]</c></para>
		/// <para>
		/// An array that receives a property attribute descriptor for each property specified in the rgpspec array. Each element in the
		/// array is one or more descriptor values combined with a bitwise <c>OR</c> operation.
		/// </para>
		/// </param>
		/// <param name="rgpropvar">
		/// <para>Type: <c>PROPVARIANT[]</c></para>
		/// <para>
		/// An array that receives a property attribute descriptor for each property specified in the pPROPSPEC array. For more
		/// information, see PROPVARIANT.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>This method returns one of the following values or a standard COM error code:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>This method succeeded.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The specified property names do not exist. No attributes were retrieved.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_ACCESSDENIED</term>
		/// <term>The application does not have access to the property stream or the stream may already be open.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_INSUFFICIENTMEMORY</term>
		/// <term>There is not enough memory to complete the operation.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NOT_SUPPORTED</term>
		/// <term>The property type is not supported.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALIDPARAMETER</term>
		/// <term>One or more parameters are invalid. One or more of the PROPSPEC structures contain invalid data.</term>
		/// </item>
		/// <item>
		/// <term>STG_E_INVALIDPOINTER</term>
		/// <term>One or more of the pointers passed to this method are invalid.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_NO_UNICODE_TRANSLATION</term>
		/// <term>A translation from Unicode to ANSI or ANSI to Unicode failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method retrieves both property access rights and valid property values. Access rights report whether the property is
		/// readable, writeable, or both. Valid property values are specified as a range of values, a list of values, or a group of flag
		/// values. For more information, see Property Attributes.
		/// </para>
		/// <para>
		/// If the property access rights flag has the <c>WIA_PROP_NONE</c> bit set, no legal value information is available for this
		/// property. Read only properties and properties with a binary data type are examples of properties that would have the
		/// <c>WIA_PROP_NONE</c> bit set.
		/// </para>
		/// <para>
		/// If the property has a range of valid values, they can be determined through the rgpropvar parameter upon completion of this
		/// method. The ppvValidValues parameter specifies an array of PROPVARIANT structures.
		/// </para>
		/// <para>
		/// For example, if the property range is specified as VT_VECTOR | VT_UI4, range information can be retrieved through the
		/// structure member
		/// </para>
		/// <para>rgpropvar[n].caul.pElems[range_specifier]</para>
		/// <para>where n is the index number of the property that is inspected and range_specifier is one of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Range Specifier</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WIA_RANGE_MAX</term>
		/// <term>Maximum value to which the property may be set.</term>
		/// </item>
		/// <item>
		/// <term>WIA_RANGE_MIN</term>
		/// <term>Minimum value to which the property may be set.</term>
		/// </item>
		/// <item>
		/// <term>WIA_RANGE_NOM</term>
		/// <term>Normal or default property value.</term>
		/// </item>
		/// <item>
		/// <term>WIA_RANGE_STEP</term>
		/// <term>Increment or decrement between property values.</term>
		/// </item>
		/// </list>
		/// <para>
		/// If the property has a list of valid values, applications determine them through the ppvValidValues parameter upon completion
		/// of this method.
		/// </para>
		/// <para>
		/// For example, if the property range is specified as VT_VECTOR | VT_UI4, the list of valid property values can be retrieved
		/// through the structure member
		/// </para>
		/// <para>rgpropspecValues[n].caul.pElems[list_specifier]</para>
		/// <para>where n is the index number of the property that is inspected and list_specifier is one of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Range Specifier</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WIA_LIST_COUNT</term>
		/// <term>Total number of list elements excluding the nominal value.</term>
		/// </item>
		/// <item>
		/// <term>WIA_LIST_NOM</term>
		/// <term>Nominal value for the property.</term>
		/// </item>
		/// <item>
		/// <term>WIA_LIST_VALUES</term>
		/// <term>The index number of the first value.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Programs also use the ppvValidValues parameter to retrieve valid flag values. For instance, if the property flags are
		/// specified as VT_UI4, valid flag values can be determined through the structure member
		/// </para>
		/// <para>rgpropspec[n].caul.pElems[flag_specifier]</para>
		/// <para>where n is the index number of the property that is inspected, and flag_specifier is one of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Range Specifier</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WIA_FLAG_NOM</term>
		/// <term>The nominal value for the property.</term>
		/// </item>
		/// <item>
		/// <term>WIA_FLAG_NUM_ELEMS</term>
		/// <term>Total number of list elements excluding the nominal value.</term>
		/// </item>
		/// <item>
		/// <term>WIA_FLAG_VALUES</term>
		/// <term>All values with all valid flag bits set.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiapropertystorage-getpropertyattributes HRESULT
		// GetPropertyAttributes( ULONG cpspec, PROPSPEC [] rgpspec, ULONG [] rgflags, PROPVARIANT [] rgpropvar );
		HRESULT GetPropertyAttributes(uint cpspec, [In, MarshalAs(UnmanagedType.LPArray)] PROPSPEC[] rgpspec, [Out, MarshalAs(UnmanagedType.LPArray)] uint[] rgflags, [Out, MarshalAs(UnmanagedType.LPArray)] PROPVARIANT[] rgpropvar);

		/// <summary>The <c>IWiaPropertyStorage::GetCount</c> method returns the number of properties stored in the property storage.</summary>
		/// <returns>
		/// <para>Type: <c>ULONG*</c></para>
		/// <para>Receives the number of properties stored in the property storage.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiapropertystorage-getcount HRESULT GetCount( ULONG
		// *pulNumProps );
		uint GetCount();

		/// <summary>The <c>IWiaPropertyStorage::GetPropertyStream</c> method retrieves the property stream of an item.</summary>
		/// <param name="pCompatibilityId">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Receives a unique identifier for a set of property values.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>IStream**</c></para>
		/// <para>Pointer to a stream that receives the item properties. For more information, see IStream.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Applications use this method to get a snapshot of the current properties of an item. These are subsequently restored by
		/// calling IWiaPropertyStorage::SetPropertyStream.
		/// </para>
		/// <para>
		/// Applications can use the pCompatibilityID parameter to check if a device supports a specific set of property values before
		/// attempting to write these values to the device.
		/// </para>
		/// <para>When it is finished using the item's property stream, the application must release it.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiapropertystorage-getpropertystream HRESULT
		// GetPropertyStream( GUID *pCompatibilityId, IStream **ppIStream );
		IStream GetPropertyStream(in Guid pCompatibilityId);

		/// <summary>
		/// The <c>IWiaPropertyStorage::SetPropertyStream</c> sets the property stream of an item in the tree of IWiaItem objects of a
		/// Windows Image Acquisition (WIA) hardware device.
		/// </summary>
		/// <param name="pCompatibilityId">
		/// <para>Type: <c>GUID*</c></para>
		/// <para>Specifies a unique identifier for a set of property values.</para>
		/// </param>
		/// <param name="pIStream">
		/// <para>Type: <c>IStream*</c></para>
		/// <para>Pointer to the property stream that is used to set the current item's property stream.</para>
		/// </param>
		/// <remarks>
		/// <para>
		/// Applications use the pCompatibilityID parameter to check whether a device supports a specific set of property values before
		/// attempting to write these values to the device.
		/// </para>
		/// <para>Set pIStream to <c>NULL</c> to check whether the device driver accepts the CompatibilityID specified by pCompatibilityID.</para>
		/// <para>
		/// If the application obtained the property stream of the item using the IWiaPropertyStorage::GetPropertyStream method, the
		/// application must release it. For more information, see IStream.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-iwiapropertystorage-setpropertystream HRESULT
		// SetPropertyStream( GUID *pCompatibilityId, IStream *pIStream );
		void SetPropertyStream(in Guid pCompatibilityId, IStream? pIStream);
	}

	/// <summary>Frees resources on the server side when called by RPC stub files.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">The safe array to free.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_userfree void LPSAFEARRAY_UserFree( unsigned long
	// *, LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h", MSDNShortId = "87dc42de-70dc-4ae7-9bd0-89add31a5976")]
	public static extern void LPSAFEARRAY_UserFree(IntPtr arg1, IntPtr arg2);

	/// <summary>Frees resources on the server side when called by RPC stub files.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">The safe array to free.</param>
	/// <returns>This function does not return a value.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_userfree64 void LPSAFEARRAY_UserFree64( unsigned
	// long *, LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h", MSDNShortId = "79D73C90-4F31-4F18-B47D-2FBB4D9ED45C")]
	public static extern void LPSAFEARRAY_UserFree64(IntPtr arg1, IntPtr arg2);

	/// <summary>Marshals data from the specified SAFEARRAY object to the user's RPC buffer on the client or server side.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">
	/// The current buffer. This pointer may or may not be aligned on entry. The function aligns the buffer pointer, marshals the data,
	/// and returns the new buffer position, which is the address of the first byte after the marshaled object.
	/// </param>
	/// <param name="arg3">The safe array that contains the data to marshal.</param>
	/// <returns>
	/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The ppSafeArray parameter is not a valid safe array.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The array could not be locked.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_usermarshal unsigned char *
	// LPSAFEARRAY_UserMarshal( unsigned long *, unsigned char *, LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h", MSDNShortId = "8255d1a0-b102-443d-a10f-8c6bd9047703")]
	public static extern IntPtr LPSAFEARRAY_UserMarshal(IntPtr arg1, IntPtr arg2, IntPtr arg3);

	/// <summary>Marshals data from the specified SAFEARRAY object to the user's RPC buffer on the client or server side.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">
	/// The current buffer. This pointer may or may not be aligned on entry. The function aligns the buffer pointer, marshals the data,
	/// and returns the new buffer position, which is the address of the first byte after the marshaled object.
	/// </param>
	/// <param name="arg3">The safe array that contains the data to marshal.</param>
	/// <returns>
	/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The ppSafeArray parameter is not a valid safe array.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The array could not be locked.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_usermarshal64 unsigned char *
	// LPSAFEARRAY_UserMarshal64( unsigned long *, unsigned char *, LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h", MSDNShortId = "532CE1FB-FDE0-491A-90D2-CC6F45DB7FDF")]
	public static extern IntPtr LPSAFEARRAY_UserMarshal64(IntPtr arg1, IntPtr arg2, IntPtr arg3);

	/// <summary>Calculates the wire size of the SAFEARRAY object, and gets its handle and data.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">Sets the buffer offset so that the SAFEARRAY object is properly aligned when it is marshaled to the buffer.</param>
	/// <param name="arg3">The safe array that contains the data to marshal.</param>
	/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_usersize unsigned long LPSAFEARRAY_UserSize(
	// unsigned long *, unsigned long , LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h", MSDNShortId = "85cb5bc1-5dab-4b50-950e-0d18c403f996")]
	public static extern uint LPSAFEARRAY_UserSize(IntPtr arg1, uint arg2, IntPtr arg3);

	/// <summary>Calculates the wire size of the SAFEARRAY object, and gets its handle and data.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">Sets the buffer offset so that the SAFEARRAY object is properly aligned when it is marshaled to the buffer.</param>
	/// <param name="arg3">The safe array that contains the data to marshal.</param>
	/// <returns>The value obtained from the returned <c>HRESULT</c> value is <c>S_OK</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_usersize64 unsigned long LPSAFEARRAY_UserSize64(
	// unsigned long *, unsigned long , LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h", MSDNShortId = "5F41D197-027E-4640-833A-4F6239F0DFB0")]
	public static extern uint LPSAFEARRAY_UserSize64(IntPtr arg1, uint arg2, IntPtr arg3);

	/// <summary>Unmarshals a SAFEARRAY object from the RPC buffer.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">
	/// The current buffer. This pointer may or may not be aligned on entry. The function aligns the buffer pointer, marshals the data,
	/// and returns the new buffer position, which is the address of the first byte after the marshaled object.
	/// </param>
	/// <param name="arg3">Receives the safe array that contains the data.</param>
	/// <returns>
	/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>RPC_X_BAD_STUB_DATA</term>
	/// <term>The stub has received bad data.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The array could not be found.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory for this function to perform.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADCALLEE</term>
	/// <term>The SAFEARRAY object does not have the correct dimensions, does not have the correct features, or memory cannot be reallocated.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_userunmarshal unsigned char *
	// LPSAFEARRAY_UserUnmarshal( unsigned long *, unsigned char *, LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h", MSDNShortId = "8798b8c1-d1c0-4729-b7bd-0329e8b71b0d")]
	public static extern IntPtr LPSAFEARRAY_UserUnmarshal(IntPtr arg1, IntPtr arg2, IntPtr arg3);

	/// <summary>Unmarshals a SAFEARRAY object from the RPC buffer.</summary>
	/// <param name="arg1">The data used by RPC.</param>
	/// <param name="arg2">
	/// The current buffer. This pointer may or may not be aligned on entry. The function aligns the buffer pointer, marshals the data,
	/// and returns the new buffer position, which is the address of the first byte after the marshaled object.
	/// </param>
	/// <param name="arg3">Receives the safe array that contains the data.</param>
	/// <returns>
	/// <para>The value obtained from the returned <c>HRESULT</c> value is one of the following.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>RPC_X_BAD_STUB_DATA</term>
	/// <term>The stub has received bad data.</term>
	/// </item>
	/// <item>
	/// <term>E_UNEXPECTED</term>
	/// <term>The array could not be found.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Insufficient memory for this function to perform.</term>
	/// </item>
	/// <item>
	/// <term>DISP_E_BADCALLEE</term>
	/// <term>The SAFEARRAY object does not have the correct dimensions, does not have the correct features, or memory cannot be reallocated.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/nf-wia_xp-lpsafearray_userunmarshal unsigned char *
	// LPSAFEARRAY_UserUnmarshal( unsigned long *, unsigned char *, LPSAFEARRAY * );
	[DllImport(Lib.OleAut32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wia_xp.h")]
	public static extern IntPtr LPSAFEARRAY_UserUnmarshal64(IntPtr arg1, IntPtr arg2, IntPtr arg3);

	/// <summary>
	/// The <c>WIA_DATA_CALLBACK_HEADER</c> is transmitted to an application during a series of calls by the Windows Image Acquisition
	/// (WIA) run-time system to the IWiaDataCallback::BandedDataCallback method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/ns-wia_xp-wia_data_callback_header typedef struct
	// _WIA_DATA_CALLBACK_HEADER { int lSize; GUID guidFormatID; int lBufferSize; int lPageCount; } WIA_DATA_CALLBACK_HEADER, *PWIA_DATA_CALLBACK_HEADER;
	[PInvokeData("wia_xp.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WIA_DATA_CALLBACK_HEADER
	{
		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Must contain the size of this structure in bytes. Should be initialized to <c>sizeof(WIA_DATA_CALLBACK_HEADER)</c>.</para>
		/// </summary>
		public int lSize;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>
		/// Indicates the image clipboard format. For a list of clipboard formats, see SetClipboardData Function. This parameter is
		/// queried during a callback to the IWiaDataCallback::BandedDataCallback method with the lMessage parameter set to IT_MSG_DATA_HEADER.
		/// </para>
		/// </summary>
		public Guid guidFormatID;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the size in bytes of the buffer needed for a complete data transfer. This value can be zero, which indicates that
		/// the total image size is unknown. (when using compressed data formats, for example). In this case, the application should
		/// dynamically increase the size of its buffer. For more information, see Common WIA Item Property Constants in WIA_IPA_ITEM_SIZE.
		/// </para>
		/// </summary>
		public int lBufferSize;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>
		/// Specifies the page count. Indicates the number of callbacks to the IWiaDataCallback::BandedDataCallback method with the
		/// lMessage parameter set to IT_MSG_NEW_PAGE.
		/// </para>
		/// </summary>
		public int lPageCount;
	}

	/// <summary>
	/// The <c>WIA_DATA_TRANSFER_INFO</c> structure is used by applications to describe the buffer used to retrieve bands of data from
	/// Windows Image Acquisition (WIA) devices. It is primarily used in conjunction with the methods of the IWiaDataTransfer interface.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/ns-wia_xp-wia_data_transfer_info typedef struct _WIA_DATA_TRANSFER_INFO
	// { ULONG ulSize; ULONG ulSection; ULONG ulBufferSize; BOOL bDoubleBuffer; ULONG ulReserved1; ULONG ulReserved2; ULONG ulReserved3;
	// } WIA_DATA_TRANSFER_INFO, *PWIA_DATA_TRANSFER_INFO;
	[PInvokeData("wia_xp.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WIA_DATA_TRANSFER_INFO
	{
		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>
		/// Contains the size of this structure. Must be set to <c>sizeof(WIA_DATA_TRANSFER_INFO)</c> before your application passes
		/// this structure to any WIA interface methods.
		/// </para>
		/// </summary>
		public uint ulSize;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>
		/// Specifies an optional handle to a shared section of memory allocated by the application. If this member is set to
		/// <c>NULL</c>, IWiaDataTransfer::idtGetBandedData allocates the shared memory itself.
		/// </para>
		/// </summary>
		public uint ulSection;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The size in bytes of the buffer that is used for the data transfer.</para>
		/// </summary>
		public uint ulBufferSize;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para>Contains <c>TRUE</c> if the device is double buffered, <c>FALSE</c> if the device is not double buffered.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool bDoubleBuffer;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Reserved for use by the WIA system DLLs. Must be set to zero.</para>
		/// </summary>
		public uint ulReserved1;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Reserved for use by the WIA system DLLs. Must be set to zero.</para>
		/// </summary>
		public uint ulReserved2;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Reserved for use by the WIA system DLLs. Must be set to zero.</para>
		/// </summary>
		public uint ulReserved3;
	}

	/// <summary>
	/// Applications use the WIA_DEV_CAP structure to enumerate device capabilities. A device capability is defined by an event or
	/// command that the device supports. For more information, see IEnumWIA_DEV_CAPS.
	/// </summary>
	[PInvokeData("wia_xp.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WIA_DEV_CAP
	{
		/// <summary>
		/// Specifies a GUID that identifies the device capability. This member can be set to any of the values specified in WIA Device
		/// Commands or WIA Event Identifiers.
		/// </summary>
		public Guid guid;

		/// <summary>Used when enumerating event handlers.</summary>
		public uint ulFlags;

		/// <summary>Specifies a string that contains a short version of the capability name.</summary>
		[MarshalAs(UnmanagedType.BStr)] public string bstrName;

		/// <summary>Specifies a string that contains a description of the capability that is displayed to the user.</summary>
		[MarshalAs(UnmanagedType.BStr)] public string bstrDescription;

		/// <summary>
		/// Specifies a string that represents the location and resource ID of the icon that represents this capability or handler. The
		/// string must be of the following form: <c>drive:path module,n</c>, where n is the icon's negated resource ID (that is, if the
		/// resource ID of the icon is 100, then n is -100).
		/// </summary>
		[MarshalAs(UnmanagedType.BStr)] public string bstrIcon;

		/// <summary>Specifies a string that represents command line arguments.</summary>
		[MarshalAs(UnmanagedType.BStr)] public string bstrCommandline;
	}

	/// <summary>
	/// The <c>WIA_DITHER_PATTERN_DATA</c> structure specifies a dither pattern for scanners. It is used in conjunction with the scanner
	/// device property constant WIA_DPS_DITHER_PATTERN_DATA.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/ns-wia_xp-wia_dither_pattern_data typedef struct
	// _WIA_DITHER_PATTERN_DATA { int lSize; BSTR bstrPatternName; int lPatternWidth; int lPatternLength; int cbPattern; BYTE
	// *pbPattern; } WIA_DITHER_PATTERN_DATA, *PWIA_DITHER_PATTERN_DATA;
	[PInvokeData("wia_xp.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct WIA_DITHER_PATTERN_DATA
	{
		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the size of this structure in bytes. Should be set to <c>sizeof(WIA_DITHER_PATTERN_DATA)</c>.</para>
		/// </summary>
		public int lSize;

		/// <summary>
		/// <para>Type: <c>BSTR</c></para>
		/// <para>Specifies a string that contains the name of this dither pattern.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.BStr)] public string bstrPatternName;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Indicates the width of the dither pattern in bytes.</para>
		/// </summary>
		public int lPatternWidth;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Indicates the length of the dither pattern in bytes.</para>
		/// </summary>
		public int lPatternLength;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>Specifies the total number of bytes in the array pointed to by the <c>pbPattern</c> member.</para>
		/// </summary>
		public int cbPattern;

		/// <summary>
		/// <para>Type: <c>BYTE*</c></para>
		/// <para>Specifies a pointer to a buffer that contains the dither pattern.</para>
		/// </summary>
		public IntPtr pbPattern;
	}

	/// <summary>
	/// The <c>WIA_EXTENDED_TRANSFER_INFO</c> structure specifies extended transfer information for the
	/// IWiaDataTransfer::idtGetExtendedTransferInfo method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/ns-wia_xp-wia_extended_transfer_info typedef struct
	// _WIA_EXTENDED_TRANSFER_INFO { ULONG ulSize; ULONG ulMinBufferSize; ULONG ulOptimalBufferSize; ULONG ulMaxBufferSize; ULONG
	// ulNumBuffers; } WIA_EXTENDED_TRANSFER_INFO, *PWIA_EXTENDED_TRANSFER_INFO;
	[PInvokeData("wia_xp.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WIA_EXTENDED_TRANSFER_INFO
	{
		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Size of this structure.</para>
		/// </summary>
		public uint ulSize;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Minimum buffer size the application should request in a call to IWiaDataTransfer::idtGetBandedData.</para>
		/// </summary>
		public uint ulMinBufferSize;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Driver-recommended buffer size the application should request in a call to IWiaDataTransfer::idtGetBandedData.</para>
		/// </summary>
		public uint ulOptimalBufferSize;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>
		/// Driver-recommended maximum buffer size the application could request in a call to IWiaDataTransfer::idtGetBandedData. Going
		/// over this limit is not detrimental, however, the driver can simply not use the whole buffer and limit each band of data to
		/// this maximum size.
		/// </para>
		/// </summary>
		public uint ulMaxBufferSize;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>This value is not used and should be ignored.</para>
		/// </summary>
		public uint ulNumBuffers;
	}

	/// <summary>The <c>WIA_FORMAT_INFO</c> structure specifies valid format and media type pairs for a device.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wia_xp/ns-wia_xp-wia_format_info typedef struct _WIA_FORMAT_INFO { GUID
	// guidFormatID; int lTymed; } WIA_FORMAT_INFO, *PWIA_FORMAT_INFO;
	[PInvokeData("wia_xp.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct WIA_FORMAT_INFO
	{
		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>GUID that identifies the format.</para>
		/// </summary>
		public Guid guidFormatID;

		/// <summary>
		/// <para>Type: <c>int</c></para>
		/// <para>The media type that corresponds to the <c>guidFormatID</c> member.</para>
		/// </summary>
		public int lTymed;
	}
}