using System;
using System.Linq;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ole32;
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

namespace Vanara.PInvoke;

    public static partial class PortableDeviceApi
    {
        /****************************************************************************
         * This section declares WPD guids used in PnP
         ****************************************************************************/
        /// <summary>
        /// This Guid is used to identify devices / drivers that support the WPD DDI. The WPD Class Extension component enables this device
        /// interface for WPD Drivers that use it. Clients use this PnP interface when registering for PnP device arrival messages for WPD devices.
        /// </summary>
        public static Guid GUID_DEVINTERFACE_WPD => new(0x6AC27878, 0xA6FA, 0x4155, 0xBA, 0x85, 0xF9, 0x8F, 0x49, 0x1D, 0x4F, 0x33);
        /// <summary>
        /// This Guid is used to identify devices / drivers that can be used only by a specialized WPD client and will not show up in normal
        /// WPD enumeration. Devices identified with this interface cannot be used with normal WPD applications. Generic WPD drivers and
        /// clients should not use this interface.
        /// </summary>
        public static Guid GUID_DEVINTERFACE_WPD_PRIVATE => new(0xBA0C718F, 0x4DED, 0x49B7, 0xBD, 0xD3, 0xFA, 0xBE, 0x28, 0x66, 0x12, 0x11);
        /// <summary>
        /// This Guid is used to identify services that support the WPD Services DDI. The WPD Class Extension component enables this device
        /// interface for WPD Services that use it. Clients use this PnP interface when registering for PnP device arrival messages for ALL
        /// WPD services. To register for specific categories of services, client should use the service category or service implements Guid.
        /// </summary>
        public static Guid GUID_DEVINTERFACE_WPD_SERVICE => new(0x9EF44F80, 0x3D64, 0x4246, 0xA6, 0xAA, 0x20, 0x6F, 0x32, 0x8D, 0x1E, 0xDC);

        /****************************************************************************
         * This section declares WPD defines
         ****************************************************************************/
        // WPD specific function number used to construct WPD I/O control codes. Drivers should not use this define directly.
        public const ushort WPD_CONTROL_FUNCTION_GENERIC_MESSAGE = 0x42;

        // Defines WPD specific IOCTL number used by drivers to detect WPD requests that may require READ and WRITE access to the device.
        public static readonly uint IOCTL_WPD_MESSAGE_READWRITE_ACCESS = CTL_CODE(DEVICE_TYPE.FILE_DEVICE_WPD, WPD_CONTROL_FUNCTION_GENERIC_MESSAGE, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS | IOAccess.FILE_WRITE_ACCESS);

        // Defines WPD specific IOCTL number used by drivers to detect WPD requests that require READ-only access to the device.
        public static readonly uint IOCTL_WPD_MESSAGE_READ_ACCESS = CTL_CODE(DEVICE_TYPE.FILE_DEVICE_WPD, WPD_CONTROL_FUNCTION_GENERIC_MESSAGE, IOMethod.METHOD_BUFFERED, IOAccess.FILE_READ_ACCESS);

        // Drivers can use this macro to detect whether the incoming IOCTL is a WPD message or not.
        public static bool IS_WPD_IOCTL(uint ControlCode) => ((ControlCode == IOCTL_WPD_MESSAGE_READWRITE_ACCESS) || (ControlCode == IOCTL_WPD_MESSAGE_READ_ACCESS));

        // Pre-defined ObjectID for the DEVICE object.
        public const string WPD_DEVICE_OBJECT_ID = "DEVICE";

        // Pre-defined IWMDMDevice for the IWMDRMDeviceApp license/metering APIs.
        public static readonly IntPtr WMDRMDEVICEAPP_USE_WPD_DEVICE_PTR = new(-1);

        // Pre-defined name of a REG_DWORD value that defines the device type, used for representation purposes only. Functional
        // characteristics of the device are decided through functional objects. This value can be retrieved using
        // IPortableDeviceManager::GetDeviceProperty(...). See WPD_DEVICE_TYPES enumeration for possible values.
        public const string PORTABLE_DEVICE_TYPE = "PortableDeviceType";

        // Pre-defined name of a REG_SZ/REG_EXPAND_SZ/REG_MULTI_SZ value that indicates the location of the device icon file or device icon
        // resource. This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...). This
        // REG_SZ/REG_EXPAND_SZ/REG_MULTI_SZ value is either in the form "file.dll, resourceID" or a full file path to an icon file. e.g.: "x:\file.ico"
        public const string PORTABLE_DEVICE_ICON = "Icons";

        // Pre-defined name of a REG_DWORD value that indicates the amount of time in milliseconds the WPD Namespace Extension will keep its
        // reference to the device open under idle conditions. This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...).
        public const string PORTABLE_DEVICE_NAMESPACE_TIMEOUT = "PortableDeviceNameSpaceTimeout";

        // Pre-defined name of a REG_DWORD value that is used as a flag to indicate whether the device should, or should not, be shown in
        // the Explorer view. This value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...). Meaning of values are: 0 =
        // include, 1 = exclude. 0 is assumed if this value doesn't exist.
        public const string PORTABLE_DEVICE_NAMESPACE_EXCLUDE_FROM_SHELL = "PortableDeviceNameSpaceExcludeFromShell";

        // Pre-defined name of a REG_SZ or REG_MULTI_SZ value containing content type guids that are used indicate for what content types
        // the portable device namespace should attempt to automatically generate a thumbnail when placing new content on the device. This
        // value can be retrieved using IPortableDeviceManager::GetDeviceProperty(...). Values should be a string representation of a GUID,
        // in the form '{00000000-0000-0000-0000-000000000000}'. By default the portable device namespace attempts to automatically generate
        // thumbnails for WPD_CONTENT_TYPE_IMAGE, if a device does not want this behavior it can set this value to an empty string.
        public const string PORTABLE_DEVICE_NAMESPACE_THUMBNAIL_CONTENT_TYPES = "PortableDeviceNameSpaceThumbnailContentTypes";

        // Pre-defined name of a REG_DWORD value that indicates whether a Portable Device is a Mass Storage Class (MSC) device. This is used
        // to avoid duplication of the device in certain views and scenarios that include both file system and Portable Devices. This value
        // can be retrieved using IPortableDeviceManager::GetDeviceProperty(...). Meaning of values are: 0 = device is not mass storage, 1 =
        // device is mass storage. 0 is assumed if this value doesn't exist.
        public const string PORTABLE_DEVICE_IS_MASS_STORAGE = "PortableDeviceIsMassStorage";

        // Pre-defined value identifying the "Windows Media Digital Rights Management 10 for Portable Devices" scheme for protecting
        // content. This value can be used by drivers to indicate they support WMDRM10-PD. See WPD_DEVICE_SUPPORTED_DRM_SCHEMES.
        public const string PORTABLE_DEVICE_DRM_SCHEME_WMDRM10_PD = "WMDRM10-PD";

        // Pre-defined value identifying the "Portable Device Digital Rights Management" scheme for protecting content. This value can be
        // used by drivers to indicate they support PDDRM. See WPD_DEVICE_SUPPORTED_DRM_SCHEMES.
        public const string PORTABLE_DEVICE_DRM_SCHEME_PDDRM = "PDDRM";

        /****************************************************************************
        * This section defines flags used in API arguments
        ****************************************************************************/

        /// <summary>
        /// The <c>DELETE_OBJECT_OPTIONS</c> enumeration type describes options that are supported by a device when deleting an object.
        /// </summary>
        /// <remarks>
        /// The application can retrieve the deletion options that the device supports by calling
        /// <c>IPortableDeviceCapabilities::GetCommandOptions</c> for the <c>WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS</c> command. It
        /// should examine the <c>WPD_OPTION_OBJECT_MANAGEMENT_RECURSIVE_DELETE_SUPPORTED</c> option value that this method returns in an
        /// <c>IPortableDeviceValuesCollection</c> object.
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/delete-object-options typedef enum DELETE_OBJECT_OPTIONS {
        // PORTABLE_DEVICE_DELETE_NO_RECURSION = 0, PORTABLE_DEVICE_DELETE_WITH_RECURSION = 1 } ;
        [PInvokeData("portabledevice.h")]
        public enum DELETE_OBJECT_OPTIONS
        {
            /// <summary>Delete the object only and fail if it has children.</summary>
            PORTABLE_DEVICE_DELETE_NO_RECURSION,
            /// <summary>Delete the object and all its children.</summary>
            PORTABLE_DEVICE_DELETE_WITH_RECURSION,
        }

        /// <summary>
        /// The <c>WPD_DEVICE_TYPES</c> enumeration type describes the different Windows Portable Device (WPD) types commonly used to
        /// determine the basic classification and visual appearance of a portable device.
        /// </summary>
        /// <remarks>
        /// <para>
        /// <c>WPD_DEVICE_TYPES</c> are read using the <c>IPortableDeviceManager</c> interface. WPD applications may use these values to
        /// determine the generic visual appearance of the device. That is, a camera picture is displayed for camera-like devices, a mobile
        /// phone picture is displayed for phone-like devices, and so on.
        /// </para>
        /// <para>
        /// <para>Note</para>
        /// <para>
        /// WPD applications must use the capabilities of the portable device to determine functionally, not the <c>WPD_DEVICE_TYPES</c> value.
        /// </para>
        /// </para>
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-device-types typedef enum tagWPD_DEVICE_TYPES {
        // WPD_DEVICE_TYPE_GENERIC = 0, WPD_DEVICE_TYPE_CAMERA = 1, WPD_DEVICE_TYPE_MEDIA_PLAYER = 2, WPD_DEVICE_TYPE_PHONE = 3,
        // WPD_DEVICE_TYPE_VIDEO = 4, WPD_DEVICE_TYPE_PERSONAL_INFORMATION_MANAGER = 5, WPD_DEVICE_TYPE_AUDIO_RECORDER = 6 } WPD_DEVICE_TYPES;
        [PInvokeData("portabledevice.h")]
        public enum WPD_DEVICE_TYPES
        {
            /// <summary>
            /// A generic WPD that includes multifunction devices that do not fall into one of the other <c>WPD_DEVICE_TYPES</c> enumeration values.
            /// </summary>
            WPD_DEVICE_TYPE_GENERIC,
            /// <summary>A camera device, such as a digital still camera.</summary>
            WPD_DEVICE_TYPE_CAMERA,
            /// <summary>
            /// A media player device that supports playing audio, video, or viewing pictures, such as a portable music player or portable
            /// media center. Not all of this functionally is classified as a WPD_DEVICE_TYPE_MEDIA_PLAYER. For example, portable music
            /// player devices are classified as WPD_DEVICE_TYPE_MEDIA_PLAYER.
            /// </summary>
            WPD_DEVICE_TYPE_MEDIA_PLAYER,
            /// <summary>A phone device, such as a mobile phone.</summary>
            WPD_DEVICE_TYPE_PHONE,
            /// <summary>A video device.</summary>
            WPD_DEVICE_TYPE_VIDEO,
            /// <summary>A personal information manager device.</summary>
            WPD_DEVICE_TYPE_PERSONAL_INFORMATION_MANAGER,
            /// <summary>An audio recorder device.</summary>
            WPD_DEVICE_TYPE_AUDIO_RECORDER,
        }

        /// <summary>The <c>WpdAttributeForm</c> enumeration type describes how a property stores its values.</summary>
        /// <remarks>This enumeration is used by the WPD_PROPERTY_ATTRIBUTE_FORM property to describe how a property's data is stored.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpdattributeform typedef enum WpdAttributeForm {
        // WPD_PROPERTY_ATTRIBUTE_FORM_UNSPECIFIED = 0, WPD_PROPERTY_ATTRIBUTE_FORM_RANGE = 1, WPD_PROPERTY_ATTRIBUTE_FORM_ENUMERATION = 2,
        // WPD_PROPERTY_ATTRIBUTE_FORM_REGULAR_EXPRESSION = 3, WPD_PROPERTY_ATTRIBUTE_FORM_OJBECT_IDENTIFIER = 4 } ;
        [PInvokeData("portabledevice.h")]
        public enum WpdAttributeForm
        {
            /// <summary>The form of the property's data is not specified.</summary>
            WPD_PROPERTY_ATTRIBUTE_FORM_UNSPECIFIED,
            /// <summary>The value is expressed as a range of values, with a minimum and a maximum.</summary>
            WPD_PROPERTY_ATTRIBUTE_FORM_RANGE,
            /// <summary>The property has a series of individual values.</summary>
            WPD_PROPERTY_ATTRIBUTE_FORM_ENUMERATION,
            /// <summary>The property value is a regular expression, not a literal expression.</summary>
            WPD_PROPERTY_ATTRIBUTE_FORM_REGULAR_EXPRESSION,
            /// <summary>The property value represents an object identifier.</summary>
            WPD_PROPERTY_ATTRIBUTE_FORM_OJBECT_IDENTIFIER,
        }

        /// <summary>The <c>WpdParameterAttributeForm</c> enumeration type describes how a (method or event) parameter stores its value.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-parameter-attribute-form typedef enum tagWpdParameterAttributeForm {
        // WPD_PARAMETER_ATTRIBUTE_FORM_UNSPECIFIED = 0, WPD_PARAMETER_ATTRIBUTE_FORM_RANGE = 1, WPD_PARAMETER_ATTRIBUTE_FORM_ENUMERATION =
        // 2, WPD_PARAMETER_ATTRIBUTE_FORM_REGULAR_EXPRESSION = 3, WPD_PARAMETER_ATTRIBUTE_OBJECT_IDENTIFIER = 4 } WpdParameterAttributeForm;
        [PInvokeData("portabledevice.h")]
        public enum WpdParameterAttributeForm
        {
            /// <summary>The form of the parameter is not specified.</summary>
            WPD_PARAMETER_ATTRIBUTE_FORM_UNSPECIFIED,
            /// <summary>The parameter specifies a range.</summary>
            WPD_PARAMETER_ATTRIBUTE_FORM_RANGE,
            /// <summary>The parameter is an enumeration.</summary>
            WPD_PARAMETER_ATTRIBUTE_FORM_ENUMERATION,
            /// <summary>The parameter is a regular expression.</summary>
            WPD_PARAMETER_ATTRIBUTE_FORM_REGULAR_EXPRESSION,
            /// <summary>The parameter is an object identifier.</summary>
            WPD_PARAMETER_ATTRIBUTE_OBJECT_IDENTIFIER,
        }

        /// <summary>
        /// The <c>WPD_DEVICE_TRANSPORTS</c> enumeration type specifies the inheritance relationship for a service. This enumeration is used
        /// by the <c>WPD_DEVICE_TRANSPORT</c> property.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-device-transports typedef enum tagWPD_DEVICE_TRANSPORTS {
        // WPD_DEVICE_TRANSPORT_UNSPECIFIED = 0, WPD_DEVICE_TRANSPORT_USB = 1, WPD_DEVICE_TRANSPORT_IP = 2, WPD_DEVICE_TRANSPORT_BLUETOOTH =
        // 3 } WPD_DEVICE_TRANSPORTS;
        [PInvokeData("portabledevice.h")]
        public enum WPD_DEVICE_TRANSPORTS
        {
            /// <summary>The transport type was not specified.</summary>
            WPD_DEVICE_TRANSPORT_UNSPECIFIED,
            /// <summary>The device is connected through USB.</summary>
            WPD_DEVICE_TRANSPORT_USB,
            /// <summary>The device is connected through Internet Protocol (IP).</summary>
            WPD_DEVICE_TRANSPORT_IP,
            /// <summary>The device is connected through Bluetooth.</summary>
            WPD_DEVICE_TRANSPORT_BLUETOOTH,
        }

        /// <summary>The <c>WPD_STORAGE_TYPE_VALUES</c> enumeration type describes the different Windows Portable Device storage types.</summary>
        /// <remarks>None.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-storage-type-values typedef enum tagWPD_STORAGE_TYPE_VALUES {
        // WPD_STORAGE_TYPE_UNDEFINED = 0, WPD_STORAGE_TYPE_FIXED_ROM = 1, WPD_STORAGE_TYPE_REMOVABLE_ROM = 2, WPD_STORAGE_TYPE_FIXED_RAM =
        // 3, WPD_STORAGE_TYPE_REMOVABLE_RAM = 4 } WPD_STORAGE_TYPE_VALUES;
        [PInvokeData("portabledevice.h")]
        public enum WPD_STORAGE_TYPE_VALUES
        {
            /// <summary>The storage is of an undefined type.</summary>
            WPD_STORAGE_TYPE_UNDEFINED,
            /// <summary>The storage is non-removable and read-only.</summary>
            WPD_STORAGE_TYPE_FIXED_ROM,
            /// <summary>The storage is removable and is read-only.</summary>
            WPD_STORAGE_TYPE_REMOVABLE_ROM,
            /// <summary>The storage is non-removable and is read/write capable.</summary>
            WPD_STORAGE_TYPE_FIXED_RAM,
            /// <summary>The storage is removable and is read/write capable.</summary>
            WPD_STORAGE_TYPE_REMOVABLE_RAM,
        }

        /// <summary>Indicates write-protection that globally affects the storage.</summary>
        [PInvokeData("portabledevice.h")]
        public enum WPD_STORAGE_ACCESS_CAPABILITY_VALUES
        {
            WPD_STORAGE_ACCESS_CAPABILITY_READWRITE,
            WPD_STORAGE_ACCESS_CAPABILITY_READ_ONLY_WITHOUT_OBJECT_DELETION = 1,
            WPD_STORAGE_ACCESS_CAPABILITY_READ_ONLY_WITH_OBJECT_DELETION = 2
        }

        /// <summary>
        /// The <c>WPD_SMS_ENCODING_TYPES</c> enumeration type describes the encoding type of a short message service (SMS) message.
        /// </summary>
        /// <remarks>This enumeration is used by the WPD_SMS_ENCODING property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-sms-encoding-types typedef enum WPD_SMS_ENCODING_TYPES {
        // SMS_ENCODING_7_BIT = 0, SMS_ENCODING_8_BIT = 1, SMS_ENCODING_UTF_16 = 2 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_SMS_ENCODING_TYPES
        {
            /// <summary>Seven-bit encoding.</summary>
            SMS_ENCODING_7_BIT,
            /// <summary>Eight-bit encoding.</summary>
            SMS_ENCODING_8_BIT,
            /// <summary>Sixteen-bit encoding (UTF).</summary>
            SMS_ENCODING_UTF_16,
        }

        /// <summary>Possible values for WPD_PROPERTY_SMS_MESSAGE_TYPE</summary>
        [PInvokeData("portabledevice.h")]
        public enum SMS_MESSAGE_TYPES
        {
            SMS_TEXT_MESSAGE,
            SMS_BINARY_MESSAGE = 1
        }

        /// <summary>The <c>WPD_POWER_SOURCES</c> enumeration type describes the power source that a device is using.</summary>
        /// <remarks>This enumeration is used by the WPD_DEVICE_POWER_SOURCE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-power-sources typedef enum WPD_POWER_SOURCES {
        // WPD_POWER_SOURCE_BATTERY = 0, WPD_POWER_SOURCE_EXTERNAL = 1 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_POWER_SOURCES
        {
            /// <summary>The device power source is a battery.</summary>
            WPD_POWER_SOURCE_BATTERY,
            /// <summary>The device uses an external power source.</summary>
            WPD_POWER_SOURCE_EXTERNAL,
        }

        /// <summary>
        /// The <c>WPD_WHITE_BALANCE_SETTINGS</c> enumeration type describes how a video or image device weights color channels to achieve a
        /// proper white balance.
        /// </summary>
        /// <remarks>This enumeration is used by the WPD_STILL_IMAGE_WHITE_BALANCE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-white-balance-settings typedef enum WPD_WHITE_BALANCE_SETTINGS {
        // WPD_WHITE_BALANCE_UNDEFINED = 0, WPD_WHITE_BALANCE_MANUAL = 1, WPD_WHITE_BALANCE_AUTOMATIC = 2,
        // WPD_WHITE_BALANCE_ONE_PUSH_AUTOMATIC = 3, WPD_WHITE_BALANCE_DAYLIGHT = 4, WPD_WHITE_BALANCE_TUNGSTEN = 5, WPD_WHITE_BALANCE_FLASH
        // = 6 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_WHITE_BALANCE_SETTINGS
        {
            /// <summary>This value has not been defined.</summary>
            WPD_WHITE_BALANCE_UNDEFINED,
            /// <summary>The white balance is set explicitly by using the WPD_STILL_IMAGE_RGB_GAIN property and will not change by itself.</summary>
            WPD_WHITE_BALANCE_MANUAL,
            /// <summary>The device will set the white balance.</summary>
            WPD_WHITE_BALANCE_AUTOMATIC,
            /// <summary>
            /// The device will set the white balance, but only when the user pushes the device's capture button while aiming the device at
            /// a white field.
            /// </summary>
            WPD_WHITE_BALANCE_ONE_PUSH_AUTOMATIC,
            /// <summary>The device will use white balance numbers appropriate for use in most daylight settings.</summary>
            WPD_WHITE_BALANCE_DAYLIGHT,
            /// <summary>The device will use white balance numbers appropriate for use in most indoor, incandescent lighting settings.</summary>
            WPD_WHITE_BALANCE_TUNGSTEN,
            /// <summary>The device will use white balance numbers appropriate for use with a flash.</summary>
            WPD_WHITE_BALANCE_FLASH,
        }

        /// <summary>The <c>WPD_FOCUS_MODES</c> enumeration type describes the focus mode used by a still image capture device.</summary>
        /// <remarks>This enumeration is used by the WPD_STILL_IMAGE_FOCUS_MODE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-focus-modes typedef enum WPD_FOCUS_MODES { WPD_FOCUS_UNDEFINED = 0,
        // WPD_FOCUS_MANUAL = 1, WPD_FOCUS_AUTOMATIC = 2, WPD_FOCUS_AUTOMATIC_MACRO = 3 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_FOCUS_MODES
        {
            /// <summary>The focus mode has not been specified.</summary>
            WPD_FOCUS_UNDEFINED,
            /// <summary>Specifies manual focus.</summary>
            WPD_FOCUS_MANUAL,
            /// <summary>Specifies automatic focus, controlled by the device.</summary>
            WPD_FOCUS_AUTOMATIC,
            /// <summary>Specifies that the device should automatically switch between macro and normal focus, as required.</summary>
            WPD_FOCUS_AUTOMATIC_MACRO,
        }

        /// <summary>
        /// The <c>WPD_EXPOSURE_METERING_MODES</c> enumeration type describes the metering mode to use when estimating exposure for still
        /// image capture by a device.
        /// </summary>
        /// <remarks>
        /// Indicates the metering mode of the device. This enumeration is used by the WPD_STILL_IMAGE_EXPOSURE_METERING_MODE property.
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-exposure-metering-modes typedef enum WPD_EXPOSURE_METERING_MODES {
        // WPD_EXPOSURE_METERING_MODE_UNDEFINED = 0, WPD_EXPOSURE_METERING_MODE_AVERAGE = 1,
        // WPD_EXPOSURE_METERING_MODE_CENTER_WEIGHTED_AVERAGE = 2, WPD_EXPOSURE_METERING_MODE_MULTI_SPOT = 3,
        // WPD_EXPOSURE_METERING_MODE_CENTER_SPOT = 4 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_EXPOSURE_METERING_MODES
        {
            /// <summary>The metering mode is undefined.</summary>
            WPD_EXPOSURE_METERING_MODE_UNDEFINED,
            /// <summary>Use averaged exposure across the full image.</summary>
            WPD_EXPOSURE_METERING_MODE_AVERAGE,
            /// <summary>Use an averaged exposure, with the center of the image given more weight.</summary>
            WPD_EXPOSURE_METERING_MODE_CENTER_WEIGHTED_AVERAGE,
            /// <summary>Use a multi-spot averaging technique.</summary>
            WPD_EXPOSURE_METERING_MODE_MULTI_SPOT,
            /// <summary>Use a center-spot averaging technique.</summary>
            WPD_EXPOSURE_METERING_MODE_CENTER_SPOT,
        }

        /// <summary>The <c>WPD_FLASH_MODES</c> enumeration type describes a flash mode to use when capturing images with a device.</summary>
        /// <remarks>This enumeration is used by the WPD_STILL_IMAGE_FLASH_MODE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-flash-modes typedef enum WPD_FLASH_MODES { WPD_FLASH_MODE_UNDEFINED =
        // 0, WPD_FLASH_MODE_AUTO = 1, WPD_FLASH_MODE_OFF = 2, WPD_FLASH_MODE_FILL = 3, WPD_FLASH_MODE_RED_EYE_AUTO = 4,
        // WPD_FLASH_MODE_RED_EYE_FILL = 5, WPD_FLASH_MODE_EXTERNAL_SYNC = 6 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_FLASH_MODES
        {
            /// <summary>No flash mode has been specified.</summary>
            WPD_FLASH_MODE_UNDEFINED,
            /// <summary>Specifies that the flash should be used in the automatic mode, as specified by the device.</summary>
            WPD_FLASH_MODE_AUTO,
            /// <summary>Specifies that no flash should be used.</summary>
            WPD_FLASH_MODE_OFF,
            /// <summary>Specifies a fill-type flash.</summary>
            WPD_FLASH_MODE_FILL,
            /// <summary>Specifies that the red eye reduction flash should be used.</summary>
            WPD_FLASH_MODE_RED_EYE_AUTO,
            /// <summary>Specifies that the red eye fill flash should be used.</summary>
            WPD_FLASH_MODE_RED_EYE_FILL,
            /// <summary>Specifies that the flash should be synchronized with other external flash devices.</summary>
            WPD_FLASH_MODE_EXTERNAL_SYNC,
        }

        /// <summary>
        /// The <c>WPD_EXPOSURE_PROGRAM_MODES</c> enumeration type describes an exposure mode to use when capturing images with a device.
        /// </summary>
        /// <remarks>
        /// Indicates the exposure program mode of the device. This enumeration is used by the WPD_STILL_IMAGE_EXPOSURE_PROGRAM_MODE property.
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-exposure-program-modes typedef enum WPD_EXPOSURE_PROGRAM_MODES {
        // WPD_EXPOSURE_PROGRAM_MODE_UNDEFINED = 0, WPD_EXPOSURE_PROGRAM_MODE_MANUAL = 1, WPD_EXPOSURE_PROGRAM_MODE_AUTO = 2,
        // WPD_EXPOSURE_PROGRAM_MODE_APERTURE_PRIORITY = 3, WPD_EXPOSURE_PROGRAM_MODE_SHUTTER_PRIORITY = 4, WPD_EXPOSURE_PROGRAM_MODE_CREATIVE = 5,
        // WPD_EXPOSURE_PROGRAM_MODE_ACTION = 6, WPD_EXPOSURE_PROGRAM_MODE_PORTRAIT = 7 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_EXPOSURE_PROGRAM_MODES
        {
            /// <summary>The exposure mode has not been specified.</summary>
            WPD_EXPOSURE_PROGRAM_MODE_UNDEFINED,
            /// <summary>The application should specify all exposure settings.</summary>
            WPD_EXPOSURE_PROGRAM_MODE_MANUAL,
            /// <summary>Use a device-defined automatic exposure mode.</summary>
            WPD_EXPOSURE_PROGRAM_MODE_AUTO,
            /// <summary>
            /// An automated exposure mode that indicates that the lens aperture value should remain fixed, but shutter speed should be
            /// determined by the device.
            /// </summary>
            WPD_EXPOSURE_PROGRAM_MODE_APERTURE_PRIORITY,
            /// <summary>
            /// An automated exposure mode that indicates that the shutter speed should remain fixed, but that lens aperture should be
            /// determined by the device.
            /// </summary>
            WPD_EXPOSURE_PROGRAM_MODE_SHUTTER_PRIORITY,
            /// <summary>An automated exposure mode that tries to maximize the depth of field.</summary>
            WPD_EXPOSURE_PROGRAM_MODE_CREATIVE,
            /// <summary>An automated exposure mode that tries to maximize the shutter speed.</summary>
            WPD_EXPOSURE_PROGRAM_MODE_ACTION,
            /// <summary>An automated exposure mode that specifies a relatively shallow depth of field.</summary>
            WPD_EXPOSURE_PROGRAM_MODE_PORTRAIT,
        }

        /// <summary>The <c>WPD_CAPTURE_MODES</c> enumeration type describes the capture timing mode of a still image capture.</summary>
        /// <remarks>This enumeration is used by the WPD_STILL_IMAGE_CAPTURE_MODE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-capture-modes typedef enum WPD_CAPTURE_MODES { WPD_CAPTURE_MODE_UNDEFINED = 0,
        // WPD_CAPTURE_MODE_NORMAL = 1, WPD_CAPTURE_MODE_BURST = 2, WPD_CAPTURE_MODE_TIMELAPSE = 3 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_CAPTURE_MODES
        {
            /// <summary>The capture mode has not been defined.</summary>
            WPD_CAPTURE_MODE_UNDEFINED,
            /// <summary>No delay or burst mode should be used.</summary>
            WPD_CAPTURE_MODE_NORMAL,
            /// <summary>
            /// Specifies that a defined number of images should be captured with a defined interval between them. The number of images to
            /// capture and time delay between them are specified by the WPD_STILL_IMAGE_BURST_NUMBER and WPD_STILL_IMAGE_BURST_INTERVAL properties.
            /// </summary>
            WPD_CAPTURE_MODE_BURST,
            /// <summary>
            /// Image capture should use time lapse photography. The number of images and interval between them are described by the
            /// WPD_STILL_IMAGE_TIMELAPSE_NUMBER and WPD_STILL_IMAGE_TIMELAPSE_INTERVAL properties.
            /// </summary>
            WPD_CAPTURE_MODE_TIMELAPSE,
        }

        /// <summary>The <c>WPD_EFFECT_MODES</c> enumeration type describes various visual effects that can be applied to an image.</summary>
        /// <remarks>This enumeration is used by the WPD_STILL_IMAGE_EFFECT_MODE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-effect-modes typedef enum WPD_EFFECT_MODES { WPD_EFFECT_MODE_UNDEFINED = 0,
        // WPD_EFFECT_MODE_COLOR = 1, WPD_EFFECT_MODE_BLACK_AND_WHITE = 2, WPD_EFFECT_MODE_SEPIA = 3 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_EFFECT_MODES
        {
            /// <summary>No effect has been specified.</summary>
            WPD_EFFECT_MODE_UNDEFINED,
            /// <summary>The image should be color.</summary>
            WPD_EFFECT_MODE_COLOR,
            /// <summary>The image should be black and white.</summary>
            WPD_EFFECT_MODE_BLACK_AND_WHITE,
            /// <summary>The image should be sepia.</summary>
            WPD_EFFECT_MODE_SEPIA,
        }

        /// <summary>
        /// The <c>WPD_FOCUS_METERING_MODES</c> enumeration type describes how a device should decide what part of a frame to use to set focus.
        /// </summary>
        /// <remarks>This enumeration is specified by the WPD_STILL_IMAGE_FOCUS_METERING_MODE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-focus-metering-modes typedef enum WPD_FOCUS_METERING_MODES {
        // WPD_FOCUS_METERING_MODE_UNDEFINED = 0, WPD_FOCUS_METERING_MODE_CENTER_SPOT = 1, WPD_FOCUS_METERING_MODE_MULTI_SPOT = 2 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_FOCUS_METERING_MODES
        {
            /// <summary>Indicates that no focusing mode has been specified.</summary>
            WPD_FOCUS_METERING_MODE_UNDEFINED,
            /// <summary>Focuses on the center of the framed area.</summary>
            WPD_FOCUS_METERING_MODE_CENTER_SPOT,
            /// <summary>Determine focus by analyzing multiple parts of the framed area.</summary>
            WPD_FOCUS_METERING_MODE_MULTI_SPOT,
        }

        /// <summary>The <c>WPD_BITRATE_TYPES</c> enumeration type describes an audio file's compression type.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-bitrate-types typedef enum WPD_BITRATE_TYPES { WPD_BITRATE_TYPE_UNUSED = 0,
        // WPD_BITRATE_TYPE_DISCRETE = 1, WPD_BITRATE_TYPE_VARIABLE = 2, WPD_BITRATE_TYPE_FREE = 3 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_BITRATE_TYPES
        {
            /// <summary>This value has not been specified.</summary>
            WPD_BITRATE_TYPE_UNUSED,
            /// <summary>Constant bit rate compression.</summary>
            WPD_BITRATE_TYPE_DISCRETE,
            /// <summary>Variable bit rate compression.</summary>
            WPD_BITRATE_TYPE_VARIABLE,
            /// <summary>Free format bit rate. This is a constant bit rate that is lower than the maximum allowed bit rate.</summary>
            WPD_BITRATE_TYPE_FREE,
        }

        /// <summary>The <c>WPD_META_GENRES</c> enumeration type describes a broad genre type of a media file.</summary>
        /// <remarks>This enumeration is used by the WPD_MEDIA_META_GENRE property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-meta-genres typedef enum WPD_META_GENRES { WPD_META_GENRE_UNUSED = 0x0,
        // WPD_META_GENRE_GENERIC_MUSIC_AUDIO_FILE = 0x1, WPD_META_GENRE_GENERIC_NON_MUSIC_AUDIO_FILE = 0x11,
        // WPD_META_GENRE_SPOKEN_WORD_AUDIO_BOOK_FILES = 0x12, WPD_META_GENRE_SPOKEN_WORD_FILES_NON_AUDIO_BOOK = 0x13,
        // WPD_META_GENRE_SPOKEN_WORD_NEWS = 0x14, WPD_META_GENRE_SPOKEN_WORD_TALK_SHOWS = 0x15, WPD_META_GENRE_GENERIC_VIDEO_FILE = 0x21,
        // WPD_META_GENRE_NEWS_VIDEO_FILE = 0x22, WPD_META_GENRE_MUSIC_VIDEO_FILE = 0x23, WPD_META_GENRE_HOME_VIDEO_FILE = 0x24,
        // WPD_META_GENRE_FEATURE_FILM_VIDEO_FILE = 0x25, WPD_META_GENRE_TELEVISION_VIDEO_FILE = 0x26,
        // WPD_META_GENRE_TRAINING_EDUCATIONAL_VIDEO_FILE = 0x27, WPD_META_GENRE_PHOTO_MONTAGE_VIDEO_FILE = 0x28,
        // WPD_META_GENRE_GENERIC_NON_AUDIO_NON_VIDEO = 0x30, WPD_META_GENRE_AUDIO_PODCAST = 0x40, WPD_META_GENRE_VIDEO_PODCAST = 0x41,
        // WPD_META_GENRE_MIXED_PODCAST = 0x42 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_META_GENRES
        {
            /// <summary>The genre has not been set, or is not applicable.</summary>
            WPD_META_GENRE_UNUSED = 0x0,
            /// <summary>This is a generic music file (audio only).</summary>
            WPD_META_GENRE_GENERIC_MUSIC_AUDIO_FILE = 0x1,
            /// <summary>This is a generic non-music audio file, for example, a speech or audio book.</summary>
            WPD_META_GENRE_GENERIC_NON_MUSIC_AUDIO_FILE = 0x11,
            /// <summary>This is an audio book file.</summary>
            WPD_META_GENRE_SPOKEN_WORD_AUDIO_BOOK_FILES = 0x12,
            /// <summary>This is a spoken-word audio file that is not an audio book, for example, an interview or speech.</summary>
            WPD_META_GENRE_SPOKEN_WORD_FILES_NON_AUDIO_BOOK = 0x13,
            /// <summary>This is a news audio or video file.</summary>
            WPD_META_GENRE_SPOKEN_WORD_NEWS = 0x14,
            /// <summary>This is an audio recording of a talk show.</summary>
            WPD_META_GENRE_SPOKEN_WORD_TALK_SHOWS = 0x15,
            /// <summary>This is a generic video file.</summary>
            WPD_META_GENRE_GENERIC_VIDEO_FILE = 0x21,
            /// <summary>This is a news video file.</summary>
            WPD_META_GENRE_NEWS_VIDEO_FILE = 0x22,
            /// <summary>This is a music video file.</summary>
            WPD_META_GENRE_MUSIC_VIDEO_FILE = 0x23,
            /// <summary>This is a home video file.</summary>
            WPD_META_GENRE_HOME_VIDEO_FILE = 0x24,
            /// <summary>This is a feature film video file.</summary>
            WPD_META_GENRE_FEATURE_FILM_VIDEO_FILE = 0x25,
            /// <summary>This is a television program video file.</summary>
            WPD_META_GENRE_TELEVISION_VIDEO_FILE = 0x26,
            /// <summary>This is an educational video file.</summary>
            WPD_META_GENRE_TRAINING_EDUCATIONAL_VIDEO_FILE = 0x27,
            /// <summary>This is a video file featuring a photo montage.</summary>
            WPD_META_GENRE_PHOTO_MONTAGE_VIDEO_FILE = 0x28,
            /// <summary>This is a file without audio or video.</summary>
            WPD_META_GENRE_GENERIC_NON_AUDIO_NON_VIDEO = 0x30,
            /// <summary>This is an audio podcast.</summary>
            WPD_META_GENRE_AUDIO_PODCAST = 0x40,
            /// <summary>This is a video podcast.</summary>
            WPD_META_GENRE_VIDEO_PODCAST = 0x41,
            /// <summary>This is a podcast containing both audio and video.</summary>
            WPD_META_GENRE_MIXED_PODCAST = 0x42
        }

        /// <summary>The <c>WPD_CROPPED_STATUS_VALUES</c> enumeration type describes the cropping status of an image.</summary>
        /// <remarks>Indicates the cropped status of an image. This enumeration is used by the WPD_IMAGE_CROPPED_STATUS property.</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-cropped-status-values typedef enum WPD_CROPPED_STATUS_VALUES {
        // WPD_CROPPED_STATUS_NOT_CROPPED = 0, WPD_CROPPED_STATUS_CROPPED = 1, WPD_CROPPED_STATUS_SHOULD_NOT_BE_CROPPED = 2 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_CROPPED_STATUS_VALUES
        {
            /// <summary>The image has not been cropped.</summary>
            WPD_CROPPED_STATUS_NOT_CROPPED,
            /// <summary>The image has been cropped.</summary>
            WPD_CROPPED_STATUS_CROPPED,
            /// <summary>The image has not been, and should not be, cropped.</summary>
            WPD_CROPPED_STATUS_SHOULD_NOT_BE_CROPPED,
        }

        /// <summary>
        /// The <c>WPD_COLOR_CORRECTED_STATUS_VALUES</c> enumeration type describes the color correction status of an image or video file.
        /// </summary>
        /// <remarks>
        /// Indicates the color corrected status of an image. This enumeration is used by the WPD_IMAGE_COLOR_CORRECTED_STATUS property.
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-color-corrected-status-values typedef enum WPD_COLOR_CORRECTED_STATUS_VALUES {
        // WPD_COLOR_CORRECTED_STATUS_NOT_CORRECTED = 0, WPD_COLOR_CORRECTED_STATUS_CORRECTED = 1,
        // WPD_COLOR_CORRECTED_STATUS_SHOULD_NOT_BE_CORRECTED = 2 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_COLOR_CORRECTED_STATUS_VALUES
        {
            /// <summary>The image has not been color corrected.</summary>
            WPD_COLOR_CORRECTED_STATUS_NOT_CORRECTED,
            /// <summary>The image has been color corrected.</summary>
            WPD_COLOR_CORRECTED_STATUS_CORRECTED,
            /// <summary>The image has not been, and should not be, color corrected.</summary>
            WPD_COLOR_CORRECTED_STATUS_SHOULD_NOT_BE_CORRECTED,
        }

        /// <summary>The <c>WPD_VIDEO_SCAN_TYPES</c> enumeration type describes how the fields in a video file are encoded.</summary>
        /// <remarks>
        /// <para>This enumeration is used by the WPD_VIDEO_SCAN_TYPE property.</para>
        /// <para>
        /// There are two types of interleaved file formats that are specified by this enumeration.
        /// <c>WPD_VIDEO_SCAN_TYPE_FIELD_INTERLEAVED</c> refers to a file format where frames are delivered as they were scanned fields
        /// alternate and data goes line by line, as shown here:
        /// </para>
        /// <para><c>Frame 1</c></para>
        /// <para>Field 1: Line 1</para>
        /// <para>Field 2: Line 1</para>
        /// <para>Field 1: Line 2</para>
        /// <para>Field 2: Line 2</para>
        /// <para>Field 1: Line 3</para>
        /// <para>Field 2: Line 3</para>
        /// <para>...</para>
        /// <para>
        /// <c>WPD_VIDEO_SCAN_TYPE_FIELD_SINGLE</c> refers to a file format where each field is stored in a single block of scan lines, and
        /// fields are stored sequentially, as shown here:
        /// </para>
        /// <para><c>Frame 1</c></para>
        /// <para>Field 1: Line 1</para>
        /// <para>Field 1: Line 2</para>
        /// <para>Field 1: Line 3</para>
        /// <para>...</para>
        /// <para>Followed by</para>
        /// <para>Field 2: Line 1</para>
        /// <para>Field 2: Line 2</para>
        /// <para>Field 2: Line 3</para>
        /// <para>...</para>
        /// </remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-video-scan-types typedef enum WPD_VIDEO_SCAN_TYPES {
        // WPD_VIDEO_SCAN_TYPE_UNUSED = 0, WPD_VIDEO_SCAN_TYPE_PROGRESSIVE = 1, WPD_VIDEO_SCAN_TYPE_FIELD_INTERLEAVED_UPPER_FIRST = 2,
        // WPD_VIDEO_SCAN_TYPE_FIELD_INTERLEAVED_LOWER_FIRST = 3, WPD_VIDEO_SCAN_TYPE_FIELD_SINGLE_UPPER_FIRST = 4,
        // WPD_VIDEO_SCAN_TYPE_FIELD_SINGLE_LOWER_FIRST = 5, WPD_VIDEO_SCAN_TYPE_MIXED_INTERLACE = 6,
        // WPD_VIDEO_SCAN_TYPE_MIXED_INTERLACE_AND_PROGRESSIVE = 7 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_VIDEO_SCAN_TYPES
        {
            /// <summary>The scan type has not been defined for this video file, or is not applicable.</summary>
            WPD_VIDEO_SCAN_TYPE_UNUSED,
            /// <summary>A progressive scan video file.</summary>
            WPD_VIDEO_SCAN_TYPE_PROGRESSIVE,
            /// <summary>
            /// An interleaved video file where the fields alternate and the upper field (with line 1) is drawn first. For more information,
            /// see the Remarks section.
            /// </summary>
            WPD_VIDEO_SCAN_TYPE_FIELD_INTERLEAVED_UPPER_FIRST,
            /// <summary>
            /// An interleaved video file where the fields alternate and the lower field (with line 2) is drawn first. For more information,
            /// see Remarks, following this section.
            /// </summary>
            WPD_VIDEO_SCAN_TYPE_FIELD_INTERLEAVED_LOWER_FIRST,
            /// <summary>
            /// An interleaved video file where the fields are sent as contiguous samples and the upper field (with line 1) is drawn first.
            /// For more information, see Remarks, following this section.
            /// </summary>
            WPD_VIDEO_SCAN_TYPE_FIELD_SINGLE_UPPER_FIRST,
            /// <summary>
            /// An interleaved video file where the fields are sent as contiguous samples and the lower field (with line 2) is sent first.
            /// </summary>
            WPD_VIDEO_SCAN_TYPE_FIELD_SINGLE_LOWER_FIRST,
            /// <summary>A video file with a mix of interlacing modes.</summary>
            WPD_VIDEO_SCAN_TYPE_MIXED_INTERLACE,
            /// <summary>A video file with a mix of interlaced and progressive modes.</summary>
            WPD_VIDEO_SCAN_TYPE_MIXED_INTERLACE_AND_PROGRESSIVE,
        }

        /// <summary>The <c>WPD_OPERATION_STATES</c> enumeration values describe the current state of an operation in progress.</summary>
        /// <remarks>These values are received in the application-defined callback ( <c>IPortableDeviceEventCallback</c>).</remarks>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-operation-states typedef enum tagWPD_OPERATION_STATES {
        // WPD_OPERATION_STATE_UNSPECIFIED = 0, WPD_OPERATION_STATE_STARTED = 1, WPD_OPERATION_STATE_RUNNING = 2, WPD_OPERATION_STATE_PAUSED = 3,
        // WPD_OPERATION_STATE_CANCELLED = 4, WPD_OPERATION_STATE_FINISHED = 5, WPD_OPERATION_STATE_ABORTED = 6 } WPD_OPERATION_STATES;
        [PInvokeData("portabledevice.h")]
        public enum WPD_OPERATION_STATES
        {
            /// <summary>The current operation is in an unspecified state (not set) and unknown.</summary>
            WPD_OPERATION_STATE_UNSPECIFIED,
            /// <summary>The operation is started.</summary>
            WPD_OPERATION_STATE_STARTED,
            /// <summary>The operation is running.</summary>
            WPD_OPERATION_STATE_RUNNING,
            /// <summary>The operation is paused.</summary>
            WPD_OPERATION_STATE_PAUSED,
            /// <summary>The operation is canceled.</summary>
            WPD_OPERATION_STATE_CANCELLED,
            /// <summary>The operation is finished.</summary>
            WPD_OPERATION_STATE_FINISHED,
            /// <summary>The operation is aborted.</summary>
            WPD_OPERATION_STATE_ABORTED,
        }

        /// <summary>The <c>WPD_SECTION_DATA_UNITS_VALUES</c> enumeration indicates the units for a referenced section of data.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-section-data-units-values typedef enum WPD_SECTION_DATA_UNITS_VALUES {
        // WPD_SECTION_DATA_UNITS_BYTES = 0, WPD_SECTION_DATA_UNITS_MILLISECONDS = 1 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_SECTION_DATA_UNITS_VALUES
        {
            /// <summary>The given units are specified in bytes.</summary>
            WPD_SECTION_DATA_UNITS_BYTES,
            /// <summary>The given units are specified in milliseconds.</summary>
            WPD_SECTION_DATA_UNITS_MILLISECONDS,
        }

        /// <summary>
        /// The <c>WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPES</c> enumeration type indicates whether the rendering information profile
        /// entry corresponds to an Object or a Resource.
        /// </summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-rendering-information-profile-entry-types typedef enum SMS_MESSAGE_TYPES {
        // WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPE_OBJECT = 0, WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPE_RESOURCE = 1 } ;
        [PInvokeData("portabledevice.h")]
        public enum WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPES
        {
            /// <summary>The entry corresponds to an object.</summary>
            WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPE_OBJECT,
            /// <summary>The entry corresponds to a resource.</summary>
            WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPE_RESOURCE,
        }

        /// <summary>
        /// Indicates the type of access the command requires. This is only used internally by the command access lookup table. There is no
        /// need to use these values directly.
        /// </summary>
        [PInvokeData("portabledevice.h")]
        public enum WPD_COMMAND_ACCESS_TYPES
        {
            WPD_COMMAND_ACCESS_READ = 1,
            WPD_COMMAND_ACCESS_READWRITE = 3,
            WPD_COMMAND_ACCESS_FROM_PROPERTY_WITH_STGM_ACCESS = 4,
            WPD_COMMAND_ACCESS_FROM_PROPERTY_WITH_FILE_ACCESS = 8,
            WPD_COMMAND_ACCESS_FROM_ATTRIBUTE_WITH_METHOD_ACCESS = 16
        }

        /// <summary>The <c>WPD_SERVICE_INHERITANCE_TYPES</c> enumeration type specifies the inheritance relationship for a service.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-service-inheritance-types2 typedef enum tagWPD_SERVICE_INHERITANCE_TYPES {
        // WPD_SERVICE_INHERITANCE_IMPLEMENTATION = 0 } WPD_SERVICE_INHERITANCE_TYPES;
        [PInvokeData("portabledevice.h")]
        public enum WPD_SERVICE_INHERITANCE_TYPES
        {
            /// <summary>The service inherits by implementing an abstract service definition.</summary>
            WPD_SERVICE_INHERITANCE_IMPLEMENTATION,
        }

        /// <summary>The <c>WPD_PARAMETER_USAGE_TYPES</c> enumeration type describes how a method parameter is used in a given method.</summary>
        // https://docs.microsoft.com/en-us/windows/win32/wpd_sdk/wpd-parameter-usage-types typedef enum tagWPD_PARAMETER_USAGE_TYPES {
        // WPD_PARAMETER_USAGE_RETURN = 0, WPD_PARAMETER_USAGE_IN = 1, WPD_PARAMETER_USAGE_OUT = 2, WPD_PARAMETER_USAGE_INOUT = 3 } WPD_PARAMETER_USAGE_TYPES;
        [PInvokeData("portabledevice.h")]
        public enum WPD_PARAMETER_USAGE_TYPES
        {
            /// <summary>The parameter receives the return value, if specified by the method.</summary>
            WPD_PARAMETER_USAGE_RETURN,
            /// <summary>The parameter contains an input value before the method is called.</summary>
            WPD_PARAMETER_USAGE_IN,
            /// <summary>The parameter contains an output value when the method returns.</summary>
            WPD_PARAMETER_USAGE_OUT,
            /// <summary>The parameter contains an input value before the method is called and an output value when it returns.</summary>
            WPD_PARAMETER_USAGE_INOUT,
        }


        /****************************************************************************
        * This section declares WPD specific Errors
        ****************************************************************************/
        public const ushort FACILITY_WPD = 42;

        // TODO #define HRESULT.E_WPD_DEVICE_ALREADY_OPENED MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 1 ) #define HRESULT.E_WPD_DEVICE_NOT_OPEN MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 2 ) #define HRESULT.E_WPD_OBJECT_ALREADY_ATTACHED_TO_DEVICE MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 3 ) #define HRESULT.E_WPD_OBJECT_NOT_ATTACHED_TO_DEVICE MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 4 ) #define HRESULT.E_WPD_OBJECT_NOT_COMMITED MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 5 ) #define HRESULT.E_WPD_DEVICE_IS_HUNG MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 6 ) #define HRESULT.E_WPD_SMS_INVALID_RECIPIENT MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 100 ) #define HRESULT.E_WPD_SMS_INVALID_MESSAGE_BODY MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 101 ) #define HRESULT.E_WPD_SMS_SERVICE_UNAVAILABLE MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 102 ) #define HRESULT.E_WPD_SERVICE_ALREADY_OPENED MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 200 ) #define HRESULT.E_WPD_SERVICE_NOT_OPEN MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 201 ) #define HRESULT.E_WPD_OBJECT_ALREADY_ATTACHED_TO_SERVICE MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 202 ) #define HRESULT.E_WPD_OBJECT_NOT_ATTACHED_TO_SERVICE MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 203 ) #define HRESULT.E_WPD_SERVICE_BAD_PARAMETER_ORDER MAKE_HRESULT(SEVERITY_ERROR , FACILITY_WPD, 204 )

        /**************************************************************************** 
        * This section defines all WPD Events
        ****************************************************************************/

        /// <summary>This Guid is used to identify all WPD driver events to the event sub-system. The driver uses this as the Guid identifier when it queues an event with IWdfDevice::PostEvent(). Applications never use this value.</summary>
        public static Guid WPD_EVENT_NOTIFICATION => new(0x2BA2E40A, 0x6B4C, 0x4295, 0xBB, 0x43, 0x26, 0x32, 0x2B, 0x99, 0xAE, 0xB2);

        /// <summary>This event is sent after a new object is available on the device.</summary>
        public static Guid WPD_EVENT_OBJECT_ADDED => new(0xA726DA95, 0xE207, 0x4B02, 0x8D, 0x44, 0xBE, 0xF2, 0xE8, 0x6C, 0xBF, 0xFC);

        /// <summary>This event is sent after a previously existing object has been removed from the device.</summary>
        public static Guid WPD_EVENT_OBJECT_REMOVED => new(0xBE82AB88, 0xA52C, 0x4823, 0x96, 0xE5, 0xD0, 0x27, 0x26, 0x71, 0xFC, 0x38);

        /// <summary>This event is sent after an object has been updated such that any connected client should refresh its view of that object.</summary>
        public static Guid WPD_EVENT_OBJECT_UPDATED => new(0x1445A759, 0x2E01, 0x485D, 0x9F, 0x27, 0xFF, 0x07, 0xDA, 0xE6, 0x97, 0xAB);

        /// <summary>This event indicates that the device is about to be reset, and all connected clients should close their connection to the device.</summary>
        public static Guid WPD_EVENT_DEVICE_RESET => new(0x7755CF53, 0xC1ED, 0x44F3, 0xB5, 0xA2, 0x45, 0x1E, 0x2C, 0x37, 0x6B, 0x27);

        /// <summary>This event indicates that the device capabilities have changed. Clients should re-query the device if they have made any decisions based on device capabilities.</summary>
        public static Guid WPD_EVENT_DEVICE_CAPABILITIES_UPDATED => new(0x36885AA1, 0xCD54, 0x4DAA, 0xB3, 0xD0, 0xAF, 0xB3, 0xE0, 0x3F, 0x59, 0x99);

        /// <summary>This event indicates the progress of a format operation on a storage object.</summary>
        public static Guid WPD_EVENT_STORAGE_FORMAT => new(0x3782616B, 0x22BC, 0x4474, 0xA2, 0x51, 0x30, 0x70, 0xF8, 0xD3, 0x88, 0x57);

        /// <summary>This event is sent to request an application to transfer a particular object from the device.</summary>
        public static Guid WPD_EVENT_OBJECT_TRANSFER_REQUESTED => new(0x8D16A0A1, 0xF2C6, 0x41DA, 0x8F, 0x19, 0x5E, 0x53, 0x72, 0x1A, 0xDB, 0xF2);

        /// <summary>This event is sent when a driver for a device is being unloaded. This is typically a result of the device being unplugged.</summary>
        public static Guid WPD_EVENT_DEVICE_REMOVED => new(0xE4CBCA1B, 0x6918, 0x48B9, 0x85, 0xEE, 0x02, 0xBE, 0x7C, 0x85, 0x0A, 0xF9);

        /// <summary>This event is sent when a driver has completed invoking a service method. This event must be sent even when the method fails.</summary>
        public static Guid WPD_EVENT_SERVICE_METHOD_COMPLETE => new(0x8A33F5F8, 0x0ACC, 0x4D9B, 0x9C, 0xC4, 0x11, 0x2D, 0x35, 0x3B, 0x86, 0xCA);

        /****************************************************************************
        * This section defines all WPD content types
        ****************************************************************************/

        /// <summary>Indicates this object represents a functional object, not content data on the device.</summary>
        public static Guid WPD_CONTENT_TYPE_FUNCTIONAL_OBJECT => new(0x99ED0160, 0x17FF, 0x4C44, 0x9D, 0x98, 0x1D, 0x7A, 0x6F, 0x94, 0x19, 0x21);

        /// <summary>Indicates this object is a folder.</summary>
        public static Guid WPD_CONTENT_TYPE_FOLDER => new(0x27E2E392, 0xA111, 0x48E0, 0xAB, 0x0C, 0xE1, 0x77, 0x05, 0xA0, 0x5F, 0x85);

        /// <summary>Indicates this object represents image data (e.g. a JPEG file)</summary>
        public static Guid WPD_CONTENT_TYPE_IMAGE => new(0xef2107d5, 0xa52a, 0x4243, 0xa2, 0x6b, 0x62, 0xd4, 0x17, 0x6d, 0x76, 0x03);

        /// <summary>Indicates this object represents document data (e.g. a MS ushort file, TEXT file, etc.)</summary>
        public static Guid WPD_CONTENT_TYPE_DOCUMENT => new(0x680ADF52, 0x950A, 0x4041, 0x9B, 0x41, 0x65, 0xE3, 0x93, 0x64, 0x81, 0x55);

        /// <summary>Indicates this object represents contact data (e.g. name/number, or a VCARD file)</summary>
        public static Guid WPD_CONTENT_TYPE_CONTACT => new(0xEABA8313, 0x4525, 0x4707, 0x9F, 0x0E, 0x87, 0xC6, 0x80, 0x8E, 0x94, 0x35);

        /// <summary>Indicates this object represents a group of contacts.</summary>
        public static Guid WPD_CONTENT_TYPE_CONTACT_GROUP => new(0x346B8932, 0x4C36, 0x40D8, 0x94, 0x15, 0x18, 0x28, 0x29, 0x1F, 0x9D, 0xE9);

        /// <summary>Indicates this object represents audio data (e.g. a WMA or MP3 file)</summary>
        public static Guid WPD_CONTENT_TYPE_AUDIO => new(0x4AD2C85E, 0x5E2D, 0x45E5, 0x88, 0x64, 0x4F, 0x22, 0x9E, 0x3C, 0x6C, 0xF0);

        /// <summary>Indicates this object represents video data (e.g. a WMV or AVI file)</summary>
        public static Guid WPD_CONTENT_TYPE_VIDEO => new(0x9261B03C, 0x3D78, 0x4519, 0x85, 0xE3, 0x02, 0xC5, 0xE1, 0xF5, 0x0B, 0xB9);

        /// <summary>Indicates this object represents a television recording.</summary>
        public static Guid WPD_CONTENT_TYPE_TELEVISION => new(0x60A169CF, 0xF2AE, 0x4E21, 0x93, 0x75, 0x96, 0x77, 0xF1, 0x1C, 0x1C, 0x6E);

        /// <summary>Indicates this object represents a playlist.</summary>
        public static Guid WPD_CONTENT_TYPE_PLAYLIST => new(0x1A33F7E4, 0xAF13, 0x48F5, 0x99, 0x4E, 0x77, 0x36, 0x9D, 0xFE, 0x04, 0xA3);

        /// <summary>Indicates this object represents an album, which may contain objects of different content types (typically, MUSIC, IMAGE and VIDEO).</summary>
        public static Guid WPD_CONTENT_TYPE_MIXED_CONTENT_ALBUM => new(0x00F0C3AC, 0xA593, 0x49AC, 0x92, 0x19, 0x24, 0xAB, 0xCA, 0x5A, 0x25, 0x63);

        /// <summary>Indicates this object represents an audio album.</summary>
        public static Guid WPD_CONTENT_TYPE_AUDIO_ALBUM => new(0xAA18737E, 0x5009, 0x48FA, 0xAE, 0x21, 0x85, 0xF2, 0x43, 0x83, 0xB4, 0xE6);

        /// <summary>Indicates this object represents an image album.</summary>
        public static Guid WPD_CONTENT_TYPE_IMAGE_ALBUM => new(0x75793148, 0x15F5, 0x4A30, 0xA8, 0x13, 0x54, 0xED, 0x8A, 0x37, 0xE2, 0x26);

        /// <summary>Indicates this object represents a video album.</summary>
        public static Guid WPD_CONTENT_TYPE_VIDEO_ALBUM => new(0x012B0DB7, 0xD4C1, 0x45D6, 0xB0, 0x81, 0x94, 0xB8, 0x77, 0x79, 0x61, 0x4F);

        /// <summary>Indicates this object represents memo data</summary>
        public static Guid WPD_CONTENT_TYPE_MEMO => new(0x9CD20ECF, 0x3B50, 0x414F, 0xA6, 0x41, 0xE4, 0x73, 0xFF, 0xE4, 0x57, 0x51);

        /// <summary>Indicates this object represents e-mail data</summary>
        public static Guid WPD_CONTENT_TYPE_EMAIL => new(0x8038044A, 0x7E51, 0x4F8F, 0x88, 0x3D, 0x1D, 0x06, 0x23, 0xD1, 0x45, 0x33);

        /// <summary>Indicates this object represents an appointment in a calendar</summary>
        public static Guid WPD_CONTENT_TYPE_APPOINTMENT => new(0x0FED060E, 0x8793, 0x4B1E, 0x90, 0xC9, 0x48, 0xAC, 0x38, 0x9A, 0xC6, 0x31);

        /// <summary>Indicates this object represents a task for tracking (e.g. a TODO list)</summary>
        public static Guid WPD_CONTENT_TYPE_TASK => new(0x63252F2C, 0x887F, 0x4CB6, 0xB1, 0xAC, 0xD2, 0x98, 0x55, 0xDC, 0xEF, 0x6C);

        /// <summary>Indicates this object represents a file that can be run. This could be a script, executable and so on.</summary>
        public static Guid WPD_CONTENT_TYPE_PROGRAM => new(0xD269F96A, 0x247C, 0x4BFF, 0x98, 0xFB, 0x97, 0xF3, 0xC4, 0x92, 0x20, 0xE6);

        /// <summary>Indicates this object represents a file that does not fall into any of the other predefined WPD types for files.</summary>
        public static Guid WPD_CONTENT_TYPE_GENERIC_FILE => new(0x0085E0A6, 0x8D34, 0x45D7, 0xBC, 0x5C, 0x44, 0x7E, 0x59, 0xC7, 0x3D, 0x48);

        /// <summary>Indicates this object represents a calender</summary>
        public static Guid WPD_CONTENT_TYPE_CALENDAR => new(0xA1FD5967, 0x6023, 0x49A0, 0x9D, 0xF1, 0xF8, 0x06, 0x0B, 0xE7, 0x51, 0xB0);

        /// <summary>Indicates this object represents a message (e.g. SMS message, E-Mail message, etc.)</summary>
        public static Guid WPD_CONTENT_TYPE_GENERIC_MESSAGE => new(0xE80EAAF8, 0xB2DB, 0x4133, 0xB6, 0x7E, 0x1B, 0xEF, 0x4B, 0x4A, 0x6E, 0x5F);

        /// <summary>Indicates this object represents an association between a host and a device.</summary>
        public static Guid WPD_CONTENT_TYPE_NETWORK_ASSOCIATION => new(0x031DA7EE, 0x18C8, 0x4205, 0x84, 0x7E, 0x89, 0xA1, 0x12, 0x61, 0xD0, 0xF3);

        /// <summary>Indicates this object represents certificate used for authentication.</summary>
        public static Guid WPD_CONTENT_TYPE_CERTIFICATE => new(0xDC3876E8, 0xA948, 0x4060, 0x90, 0x50, 0xCB, 0xD7, 0x7E, 0x8A, 0x3D, 0x87);

        /// <summary>Indicates this object represents wireless network access information.</summary>
        public static Guid WPD_CONTENT_TYPE_WIRELESS_PROFILE => new(0x0BAC070A, 0x9F5F, 0x4DA4, 0xA8, 0xF6, 0x3D, 0xE4, 0x4D, 0x68, 0xFD, 0x6C);

        /// <summary>Indicates this object represents a media cast. A media cast object can be though of as a container object that groups related content, similar to how a playlist groups songs to play. Often, a media cast object is used to group media content originally published online.</summary>
        public static Guid WPD_CONTENT_TYPE_MEDIA_CAST => new(0x5E88B3CC, 0x3E65, 0x4E62, 0xBF, 0xFF, 0x22, 0x94, 0x95, 0x25, 0x3A, 0xB0);

        /// <summary>Indicates this object describes a section of data contained in another object. The WPD_OBJECT_REFERENCES property indicates which object contains the actual data.</summary>
        public static Guid WPD_CONTENT_TYPE_SECTION => new(0x821089F5, 0x1D91, 0x4DC9, 0xBE, 0x3C, 0xBB, 0xB1, 0xB3, 0x5B, 0x18, 0xCE);

        /// <summary>Indicates this object doesn't fall into the predefined WPD content types</summary>
        public static Guid WPD_CONTENT_TYPE_UNSPECIFIED => new(0x28D8D31E, 0x249C, 0x454E, 0xAA, 0xBC, 0x34, 0x88, 0x31, 0x68, 0xE6, 0x34);

        /// <summary>This content type is only valid as a parameter to API functions and driver commands. It should not be reported as a supported content type by the driver.</summary>
        public static Guid WPD_CONTENT_TYPE_ALL => new(0x80E170D2, 0x1055, 0x4A3E, 0xB9, 0x52, 0x82, 0xCC, 0x4F, 0x8A, 0x86, 0x89);

        /**************************************************************************** 
        * This section defines all WPD Functional Categories
        ****************************************************************************/

        /// <summary>Used for the device object, which is always the top-most object of the device. </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_DEVICE => new(0x08EA466B, 0xE3A4, 0x4336, 0xA1, 0xF3, 0xA4, 0x4D, 0x2B, 0x5C, 0x43, 0x8C);

        /// <summary>Indicates this object encapsulates storage functionality on the device (e.g. memory cards, internal memory) </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_STORAGE => new(0x23F05BBC, 0x15DE, 0x4C2A, 0xA5, 0x5B, 0xA9, 0xAF, 0x5C, 0xE4, 0x12, 0xEF);

        /// <summary>Indicates this object encapsulates still image capture functionality on the device (e.g. camera or camera attachment) </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE => new(0x613CA327, 0xAB93, 0x4900, 0xB4, 0xFA, 0x89, 0x5B, 0xB5, 0x87, 0x4B, 0x79);

        /// <summary>Indicates this object encapsulates audio capture functionality on the device (e.g. voice recorder or other audio recording component) </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_AUDIO_CAPTURE => new(0x3F2A1919, 0xC7C2, 0x4A00, 0x85, 0x5D, 0xF5, 0x7C, 0xF0, 0x6D, 0xEB, 0xBB);

        /// <summary>Indicates this object encapsulates video capture functionality on the device (e.g. video recorder or video recording component) </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_VIDEO_CAPTURE => new(0xE23E5F6B, 0x7243, 0x43AA, 0x8D, 0xF1, 0x0E, 0xB3, 0xD9, 0x68, 0xA9, 0x18);

        /// <summary>Indicates this object encapsulates SMS sending functionality on the device (not the receiving or saved SMS messages since those are represented as content objects on the device) </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_SMS => new(0x0044A0B1, 0xC1E9, 0x4AFD, 0xB3, 0x58, 0xA6, 0x2C, 0x61, 0x17, 0xC9, 0xCF);

        /// <summary>Indicates this object provides information about the rendering characteristics of the device. </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_RENDERING_INFORMATION => new(0x08600BA4, 0xA7BA, 0x4A01, 0xAB, 0x0E, 0x00, 0x65, 0xD0, 0xA3, 0x56, 0xD3);

        /// <summary>Indicates this object encapsulates network configuration functionality on the device (e.g. WiFi Profiles, Partnerships). </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_NETWORK_CONFIGURATION => new(0x48F4DB72, 0x7C6A, 0x4AB0, 0x9E, 0x1A, 0x47, 0x0E, 0x3C, 0xDB, 0xF2, 0x6A);

        /// <summary>This functional category is only valid as a parameter to API functions and driver commands. It should not be reported as a supported functional category by the driver. </summary>
        public static Guid WPD_FUNCTIONAL_CATEGORY_ALL => new(0x2D8A6512, 0xA74C, 0x448E, 0xBA, 0x8A, 0xF4, 0xAC, 0x07, 0xC4, 0x93, 0x99);

        /**************************************************************************** 
        * This section defines all WPD Formats
        ****************************************************************************/

        /// <summary>Standard Windows ICON format </summary>
        public static Guid WPD_OBJECT_FORMAT_ICON => new(0x077232ED, 0x102C, 0x4638, 0x9C, 0x22, 0x83, 0xF1, 0x42, 0xBF, 0xC8, 0x22);

        /// <summary>Audio file format </summary>
        public static Guid WPD_OBJECT_FORMAT_M4A => new(0x30ABA7AC, 0x6FFD, 0x4C23, 0xA3, 0x59, 0x3E, 0x9B, 0x52, 0xF3, 0xF1, 0xC8);

        /// <summary>Network Association file format. </summary>
        public static Guid WPD_OBJECT_FORMAT_NETWORK_ASSOCIATION => new(0xB1020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

        /// <summary>X.509 V3 Certificate file format. </summary>
        public static Guid WPD_OBJECT_FORMAT_X509V3CERTIFICATE => new(0xB1030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

        /// <summary>Windows Connect Now file format. </summary>
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_WFC => new(0xB1040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

        /// <summary>Audio file format </summary>
        public static Guid WPD_OBJECT_FORMAT_3GPA => new(0xE5172730, 0xF971, 0x41EF, 0xA1, 0x0B, 0x22, 0x71, 0xA0, 0x01, 0x9D, 0x7A);

        /// <summary>Audio file format </summary>
        public static Guid WPD_OBJECT_FORMAT_3G2A => new(0x1A11202D, 0x8759, 0x4E34, 0xBA, 0x5E, 0xB1, 0x21, 0x10, 0x87, 0xEE, 0xE4);

        /// <summary>This format is only valid as a parameter to API functions and driver commands. It should not be reported as a supported format by the driver. </summary>
        public static Guid WPD_OBJECT_FORMAT_ALL => new(0xC1F62EB2, 0x4BB3, 0x479C, 0x9C, 0xFA, 0x05, 0xB5, 0xF3, 0xA5, 0x7B, 0x22);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_NULL 
        *
        * This category is used exclusively for the default property key define.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_NULL => new(0x00000000, 0x0000, 0x0000, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00);

        /// <summary>[ VT_EMPTY ] A default property key.</summary>
        [CorrespondingType(null)]
        public static PROPERTYKEY WPD_PROPERTY_NULL => new(new(0x00000000, 0x0000, 0x0000, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00), 0);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_OBJECT_PROPERTIES_V1 
        ****************************************************************************/

        /// <summary>This category is for all common object properties.</summary>
        public static Guid WPD_OBJECT_PROPERTIES_V1 => new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C);

        /// <summary>[ VT_CLSID ] The abstract type for the object content, indicating the kinds of properties and data that may be supported on the object.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_OBJECT_CONTENT_TYPE => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 7);

        /// <summary>IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of ObjectIDs.[ VT_UNKNOWN ] </summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_OBJECT_REFERENCES => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 14);

        /// <summary>[ VT_LPWSTR ] Indicates the Object ID of the closest functional object ancestor. For example, objects that represent files/folders under a Storage functional object, will have this property set to the object ID of the storage functional object.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_CONTAINER_FUNCTIONAL_OBJECT_ID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 23);

        /// <summary>[ VT_BOOL ] Indicates whether the thumbnail for this object should be generated from the default resource.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OBJECT_GENERATE_THUMBNAIL_FROM_RESOURCE => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 24);

        /// <summary>[ VT_LPWSTR ] If this object appears as a hint location, this property indicates the hint-specific name to display instead of the object name.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_HINT_LOCATION_DISPLAY_NAME => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 25);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_OBJECT_PROPERTIES_V2 
        ****************************************************************************/
        /// <summary>This category is for all common object properties.</summary>
        public static Guid WPD_OBJECT_PROPERTIES_V2 => new(0x0373CD3D, 0x4A46, 0x40D7, 0xB4, 0xD8, 0x73, 0xE8, 0xDA, 0x74, 0xE7, 0x75);

        /// <summary>Indicates the units supported on this object.[ VT_UI4 ] </summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_OBJECT_SUPPORTED_UNITS => new(new(0x0373CD3D, 0x4A46, 0x40D7, 0xB4, 0xD8, 0x73, 0xE8, 0xDA, 0x74, 0xE7, 0x75), 2);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_FUNCTIONAL_OBJECT_PROPERTIES_V1 
        ****************************************************************************/
        /// <summary>This category is for properties common to all functional objects.</summary>
        public static Guid WPD_FUNCTIONAL_OBJECT_PROPERTIES_V1 => new(0x8F052D93, 0xABCA, 0x4FC5, 0xA5, 0xAC, 0xB0, 0x1D, 0xF4, 0xDB, 0xE5, 0x98);

        /// <summary>[ VT_CLSID ] Indicates the object's functional category.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_FUNCTIONAL_OBJECT_CATEGORY => new(new(0x8F052D93, 0xABCA, 0x4FC5, 0xA5, 0xAC, 0xB0, 0x1D, 0xF4, 0xDB, 0xE5, 0x98), 2);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_STORAGE_OBJECT_PROPERTIES_V1 
        ****************************************************************************/
        /// <summary>This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STORAGE.</summary>
        public static Guid WPD_STORAGE_OBJECT_PROPERTIES_V1 => new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A);

        /// <summary>[ VT_UI4 ] Indicates the type of storage e.g. fixed, removable etc.</summary>
        [CorrespondingType(typeof(WPD_STORAGE_TYPE_VALUES))]
        public static PROPERTYKEY WPD_STORAGE_TYPE => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 2);

        /// <summary>[ VT_LPWSTR ] Indicates the file system type e.g. "FAT32" or "NTFS" or "My Special File System"</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STORAGE_FILE_SYSTEM_TYPE => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 3);

        /// <summary>[ VT_UI8 ] Indicates the total storage capacity in bytes.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_STORAGE_CAPACITY => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 4);

        /// <summary>[ VT_UI8 ] Indicates the available space in bytes.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_STORAGE_FREE_SPACE_IN_BYTES => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 5);

        /// <summary>Indicates the available space in objects e.g. available slots on a SIM card.[ VT_UI8 ] </summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_STORAGE_FREE_SPACE_IN_OBJECTS => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 6);

        /// <summary>[ VT_LPWSTR ] Contains a description of the storage.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STORAGE_DESCRIPTION => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 7);

        /// <summary>[ VT_LPWSTR ] Contains the serial number of the storage.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STORAGE_SERIAL_NUMBER => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 8);

        /// <summary>[ VT_UI8 ] Specifies the maximum size of a single object (in bytes) that can be placed on this storage.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_STORAGE_MAX_OBJECT_SIZE => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 9);

        /// <summary>[ VT_UI8 ] Indicates the total storage capacity in objects e.g. available slots on a SIM card.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_STORAGE_CAPACITY_IN_OBJECTS => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 10);

        /// <summary>[ VT_UI4 ] This property identifies any write-protection that globally affects this storage. This takes precedence over access specified on individual objects.</summary>
        [CorrespondingType(typeof(WPD_STORAGE_ACCESS_CAPABILITY_VALUES))]
        public static PROPERTYKEY WPD_STORAGE_ACCESS_CAPABILITY => new(new(0x01A3057A, 0x74D6, 0x4E80, 0xBE, 0xA7, 0xDC, 0x4C, 0x21, 0x2C, 0xE5, 0x0A), 11);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_NETWORK_ASSOCIATION_PROPERTIES_V1 
        ****************************************************************************/
        /// <summary>This category is for properties common to all network association objects.</summary>
        public static Guid WPD_NETWORK_ASSOCIATION_PROPERTIES_V1 => new(0xE4C93C1F, 0xB203, 0x43F1, 0xA1, 0x00, 0x5A, 0x07, 0xD1, 0x1B, 0x02, 0x74);

        /// <summary>[ VT_VECTOR | VT_UI1 ] The list of EUI-64 host identifiers valid for this association.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_NETWORK_ASSOCIATION_HOST_NETWORK_IDENTIFIERS => new(new(0xE4C93C1F, 0xB203, 0x43F1, 0xA1, 0x00, 0x5A, 0x07, 0xD1, 0x1B, 0x02, 0x74), 2);

        /// <summary>[ VT_VECTOR | VT_UI1 ] The sequence of X.509 v3 certificates to be provided for TLS server authentication.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_NETWORK_ASSOCIATION_X509V3SEQUENCE => new(new(0xE4C93C1F, 0xB203, 0x43F1, 0xA1, 0x00, 0x5A, 0x07, 0xD1, 0x1B, 0x02, 0x74), 3);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1 
        ****************************************************************************/
        /// <summary>This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_STILL_IMAGE_CAPTURE</summary>
        public static Guid WPD_STILL_IMAGE_CAPTURE_OBJECT_PROPERTIES_V1 => new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60);

        /// <summary>[ VT_LPWSTR ] Controls the size of the image dimensions to capture in pixel width and height.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STILL_IMAGE_CAPTURE_RESOLUTION => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 2);

        /// <summary>[ VT_CLSID ] Controls the format of the image to capture.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_STILL_IMAGE_CAPTURE_FORMAT => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 3);

        /// <summary>[ VT_UI8 ] Controls the device-specific quality setting.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_STILL_IMAGE_COMPRESSION_SETTING => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 4);

        /// <summary>[ VT_UI4 ] Controls how the device weights color channels.</summary>
        [CorrespondingType(typeof(WPD_WHITE_BALANCE_SETTINGS))]
        public static PROPERTYKEY WPD_STILL_IMAGE_WHITE_BALANCE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 5);

        /// <summary>[ VT_LPWSTR ] Controls the RGB gain.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STILL_IMAGE_RGB_GAIN => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 6);

        /// <summary>[ VT_UI4 ] Controls the aperture of the lens.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_FNUMBER => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 7);

        /// <summary>[ VT_UI4 ] Controls the 35mm equivalent focal length.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_FOCAL_LENGTH => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 8);

        /// <summary>[ VT_UI4 ] This property corresponds to the focus distance in millimeters</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_FOCUS_DISTANCE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 9);

        /// <summary>[ VT_UI4 ] Identifies the focusing mode used by the device for image capture.</summary>
        [CorrespondingType(typeof(WPD_FOCUS_MODES))]
        public static PROPERTYKEY WPD_STILL_IMAGE_FOCUS_MODE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 10);

        /// <summary>[ VT_UI4 ] Identifies the exposure metering mode used by the device for image capture.</summary>
        [CorrespondingType(typeof(WPD_EXPOSURE_METERING_MODES))]
        public static PROPERTYKEY WPD_STILL_IMAGE_EXPOSURE_METERING_MODE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 11);

        /// <summary>[ VT_UI4 ] </summary>
        [CorrespondingType(typeof(WPD_FLASH_MODES))]
        public static PROPERTYKEY WPD_STILL_IMAGE_FLASH_MODE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 12);

        /// <summary>[ VT_UI4 ] Controls the shutter speed of the device.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_EXPOSURE_TIME => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 13);

        /// <summary>[ VT_UI4 ] Controls the exposure program mode of the device.</summary>
        [CorrespondingType(typeof(WPD_EXPOSURE_PROGRAM_MODES))]
        public static PROPERTYKEY WPD_STILL_IMAGE_EXPOSURE_PROGRAM_MODE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 14);

        /// <summary>[ VT_UI4 ] Controls the emulation of film speed settings.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_EXPOSURE_INDEX => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 15);

        /// <summary>[ VT_I4 ] Controls the adjustment of the auto exposure control.</summary>
        [CorrespondingType(typeof(int))]
        public static PROPERTYKEY WPD_STILL_IMAGE_EXPOSURE_BIAS_COMPENSATION => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 16);

        /// <summary>[ VT_UI4 ] Controls the amount of time delay between the capture trigger and the actual data capture (in milliseconds).</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_CAPTURE_DELAY => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 17);

        /// <summary>[ VT_UI4 ] Controls the type of still image capture.</summary>
        [CorrespondingType(typeof(WPD_CAPTURE_MODES))]
        public static PROPERTYKEY WPD_STILL_IMAGE_CAPTURE_MODE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 18);

        /// <summary>[ VT_UI4 ] Controls the perceived contrast of captured images.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_CONTRAST => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 19);

        /// <summary>[ VT_UI4 ] Controls the perceived sharpness of the captured image.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_SHARPNESS => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 20);

        /// <summary>[ VT_UI4 ] Controls the effective zoom ratio of a digital camera's acquired image scaled by a factor of 10.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_DIGITAL_ZOOM => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 21);

        /// <summary>[ VT_UI4 ] Controls the special effect mode of the capture.</summary>
        [CorrespondingType(typeof(WPD_EFFECT_MODES))]
        public static PROPERTYKEY WPD_STILL_IMAGE_EFFECT_MODE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 22);

        /// <summary>[ VT_UI4 ] Controls the number of images that the device will attempt to capture upon initiation of a burst operation.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_BURST_NUMBER => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 23);

        /// <summary>[ VT_UI4 ] Controls the time delay between captures upon initiation of a burst operation.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_BURST_INTERVAL => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 24);

        /// <summary>[ VT_UI4 ] Controls the number of images that the device will attempt to capture upon initiation of a time-lapse capture.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_TIMELAPSE_NUMBER => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 25);

        /// <summary>[ VT_UI4 ] Controls the time delay between captures upon initiation of a time-lapse operation.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_STILL_IMAGE_TIMELAPSE_INTERVAL => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 26);

        /// <summary>[ VT_UI4 ] Controls which automatic focus mechanism is used by the device.</summary>
        [CorrespondingType(typeof(WPD_FOCUS_METERING_MODES))]
        public static PROPERTYKEY WPD_STILL_IMAGE_FOCUS_METERING_MODE => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 27);

        /// <summary>[ VT_LPWSTR ] Used to describe the URL that the device may use to upload images upon capture.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STILL_IMAGE_UPLOAD_URL => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 28);

        /// <summary>[ VT_LPWSTR ] Contains the owner/user of the device, which may be inserted as meta-data into any images that are captured.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STILL_IMAGE_ARTIST => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 29);

        /// <summary>[ VT_LPWSTR ] Contains the model of the device</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STILL_IMAGE_CAMERA_MODEL => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 30);

        /// <summary>[ VT_LPWSTR ] Contains the manufacturer of the device</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_STILL_IMAGE_CAMERA_MANUFACTURER => new(new(0x58C571EC, 0x1BCB, 0x42A7, 0x8A, 0xC5, 0xBB, 0x29, 0x15, 0x73, 0xA2, 0x60), 31);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_RENDERING_INFORMATION_OBJECT_PROPERTIES_V1 
        ****************************************************************************/
        /// <summary>This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_AUDIO_RENDERING_INFORMATION</summary>
        public static Guid WPD_RENDERING_INFORMATION_OBJECT_PROPERTIES_V1 => new(0xC53D039F, 0xEE23, 0x4A31, 0x85, 0x90, 0x76, 0x39, 0x87, 0x98, 0x70, 0xB4);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValuesCollection, where each element indicates the property settings for a supported profile.</summary>
        [CorrespondingType(typeof(IPortableDeviceValuesCollection))]
        public static PROPERTYKEY WPD_RENDERING_INFORMATION_PROFILES => new(new(0xC53D039F, 0xEE23, 0x4A31, 0x85, 0x90, 0x76, 0x39, 0x87, 0x98, 0x70, 0xB4), 2);

        /// <summary>[ VT_UI4 ] Indicates whether a given entry (i.e. an IPortableDeviceValues) in WPD_RENDERING_INFORMATION_PROFILES relates to an Object or a Resource.</summary>
        [CorrespondingType(typeof(WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPES))]
        public static PROPERTYKEY WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPE => new(new(0xC53D039F, 0xEE23, 0x4A31, 0x85, 0x90, 0x76, 0x39, 0x87, 0x98, 0x70, 0xB4), 3);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection identifying the resources that can be created on an object with this rendering profile.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_RENDERING_INFORMATION_PROFILE_ENTRY_CREATABLE_RESOURCES => new(new(0xC53D039F, 0xEE23, 0x4A31, 0x85, 0x90, 0x76, 0x39, 0x87, 0x98, 0x70, 0xB4), 4);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CLIENT_INFORMATION_PROPERTIES_V1 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_CLIENT_INFORMATION_PROPERTIES_V1 => new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59);

        /// <summary>[ VT_LPWSTR ] Specifies the name the client uses to identify itself.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CLIENT_NAME => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 2);

        /// <summary>[ VT_UI4 ] Specifies the major version of the client.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_CLIENT_MAJOR_VERSION => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 3);

        /// <summary>[ VT_UI4 ] Specifies the major version of the client.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_CLIENT_MINOR_VERSION => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 4);

        /// <summary>[ VT_UI4 ] Specifies the revision (or build number) of the client.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_CLIENT_REVISION => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 5);

        /// <summary>[ VT_VECTOR | VT_UI1 ] Specifies the Windows Media DRM application private key of the client.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_CLIENT_WMDRM_APPLICATION_PRIVATE_KEY => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 6);

        /// <summary>[ VT_VECTOR | VT_UI1 ] Specifies the Windows Media DRM application certificate of the client.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_CLIENT_WMDRM_APPLICATION_CERTIFICATE => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 7);

        /// <summary>[ VT_UI4 ] Specifies the Security Quality of Service for the connection to the driver. This relates to the Security Quality of Service flags for CreateFile. For example, these allow or disallow a driver to impersonate the client.</summary>
        [CorrespondingType(typeof(FileFlagsAndAttributes))]
        public static PROPERTYKEY WPD_CLIENT_SECURITY_QUALITY_OF_SERVICE => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 8);

        /// <summary>[ VT_UI4 ] Specifies the desired access the client is requesting to this driver. The possible values are the same as for CreateFile (e.g. GENERIC_READ, GENERIC_WRITE etc.).</summary>
        [CorrespondingType(typeof(ACCESS_MASK))]
        public static PROPERTYKEY WPD_CLIENT_DESIRED_ACCESS => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 9);

        /// <summary>[ VT_UI4 ] Specifies the share mode the client is requesting to this driver. The possible values are the same as for CreateFile (e.g. FILE_SHARE_READ, FILE_SHARE_WRITE etc.).</summary>
        [CorrespondingType(typeof(System.IO.FileShare))]
        public static PROPERTYKEY WPD_CLIENT_SHARE_MODE => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 10);

        /// <summary>[ VT_LPWSTR ] Client supplied cookie returned by the driver in events posted as a direct result of operations issued by this client.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CLIENT_EVENT_COOKIE => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 11);

        /// <summary>[ VT_UI4 ] Specifies the minimum buffer size (in bytes) used for sending commands to the driver.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_CLIENT_MINIMUM_RESULTS_BUFFER_SIZE => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 12);

        /// <summary>[ VT_BOOL ] An advanced option for clients that wish to manually call IPortableDevice::Close or IPortableDeviceService::Close for each object on device disconnect, instead of relying on the API to call Close on its behalf.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_CLIENT_MANUAL_CLOSE_ON_DISCONNECT => new(new(0x204D9F0C, 0x2292, 0x4080, 0x9F, 0x42, 0x40, 0x66, 0x4E, 0x70, 0xF8, 0x59), 13);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_PROPERTY_ATTRIBUTES_V1 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_PROPERTY_ATTRIBUTES_V1 => new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37);

        /// <summary>[ VT_UI4 ] Specifies the form of the valid values allowed for this property.</summary>
        [CorrespondingType(typeof(WpdAttributeForm))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_FORM => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 2);

        /// <summary>[ VT_BOOL ] Indicates whether client applications have permission to Read the property.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_CAN_READ => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 3);

        /// <summary>[ VT_BOOL ] Indicates whether client applications have permission to Write the property.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_CAN_WRITE => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 4);

        /// <summary>[ VT_BOOL ] Indicates whether client applications have permission to Delete the property.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_CAN_DELETE => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 5);

        /// <summary>[ VT_XXXX ] Specifies the default value for a write-able property.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_DEFAULT_VALUE => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 6);

        /// <summary>[ VT_BOOL ] If True, then this property belongs to the PORTABLE_DEVICE_FAST_PROPERTIES group.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_FAST_PROPERTY => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 7);

        /// <summary>[ VT_XXXX ] The minimum value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_RANGE_MIN => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 8);

        /// <summary>[ VT_XXXX ] The maximum value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_RANGE_MAX => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 9);

        /// <summary>[ VT_XXXX ] The step value for a property whose form is of WPD_PROPERTY_ATTRIBUTE_FORM_RANGE.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_RANGE_STEP => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 10);

        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection containing the enumeration values.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_ENUMERATION_ELEMENTS => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 11);

        /// <summary>[ VT_LPWSTR ] A regular expression string indicating acceptable values for properties whose form is WPD_PROPERTY_ATTRIBUTE_FORM_REGULAR_EXPRESSION.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_REGULAR_EXPRESSION => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 12);

        /// <summary>[ VT_UI8 ] This indicates the maximum size (in bytes) for the value of this property.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_MAX_SIZE => new(new(0xAB7943D8, 0x6332, 0x445F, 0xA0, 0x0D, 0x8D, 0x5E, 0xF1, 0xE9, 0x6F, 0x37), 13);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_PROPERTY_ATTRIBUTES_V2 
        ****************************************************************************/
        /// <summary>This category defines additional property attributes used by device services.</summary>
        public static Guid WPD_PROPERTY_ATTRIBUTES_V2 => new(0x5D9DA160, 0x74AE, 0x43CC, 0x85, 0xA9, 0xFE, 0x55, 0x5A, 0x80, 0x79, 0x8E);

        /// <summary>Contains the name of the property.[ VT_LPWSTR ] </summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_NAME => new(new(0x5D9DA160, 0x74AE, 0x43CC, 0x85, 0xA9, 0xFE, 0x55, 0x5A, 0x80, 0x79, 0x8E), 2);

        /// <summary>[ VT_UI4 ] Contains the VARTYPE of the property.[ VT_LPWSTR ] </summary>
        [CorrespondingType(typeof(VARTYPE))]
        public static PROPERTYKEY WPD_PROPERTY_ATTRIBUTE_VARTYPE => new(new(0x5D9DA160, 0x74AE, 0x43CC, 0x85, 0xA9, 0xFE, 0x55, 0x5A, 0x80, 0x79, 0x8E), 3);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CLASS_EXTENSION_OPTIONS_V1 
        ****************************************************************************/
        /// <summary>This category of properties relates to options used for the WPD device class extension</summary>
        public static Guid WPD_CLASS_EXTENSION_OPTIONS_V1 => new(0x6309FFEF, 0xA87C, 0x4CA7, 0x84, 0x34, 0x79, 0x75, 0x76, 0xE4, 0x0A, 0x96);

        /// <summary>[ VT_UNKNOWN ] Indicates the (super-set) list of content types supported by the driver (similar to calling WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES on WPD_FUNCTIONAL_CATEGORY_ALL).</summary>
        public static PROPERTYKEY WPD_CLASS_EXTENSION_OPTIONS_SUPPORTED_CONTENT_TYPES => new(new(0x6309FFEF, 0xA87C, 0x4CA7, 0x84, 0x34, 0x79, 0x75, 0x76, 0xE4, 0x0A, 0x96), 2);

        /// <summary>[ VT_BOOL ] Indicates that the caller does not want the WPD class extension library to register the WPD Device Class interface. The caller will take responsibility for doing it.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_CLASS_EXTENSION_OPTIONS_DONT_REGISTER_WPD_DEVICE_INTERFACE => new(new(0x6309FFEF, 0xA87C, 0x4CA7, 0x84, 0x34, 0x79, 0x75, 0x76, 0xE4, 0x0A, 0x96), 3);

        /// <summary>[ VT_BOOL ] Indicates that the caller wants the WPD class extension library to register the private WPD Device Class interface.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_CLASS_EXTENSION_OPTIONS_REGISTER_WPD_PRIVATE_DEVICE_INTERFACE => new(new(0x6309FFEF, 0xA87C, 0x4CA7, 0x84, 0x34, 0x79, 0x75, 0x76, 0xE4, 0x0A, 0x96), 4);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CLASS_EXTENSION_OPTIONS_V2 
        ****************************************************************************/
        /// <summary>This category of properties relates to options used for the WPD device class extension</summary>
        public static Guid WPD_CLASS_EXTENSION_OPTIONS_V2 => new(0x3E3595DA, 0x4D71, 0x49FE, 0xA0, 0xB4, 0xD4, 0x40, 0x6C, 0x3A, 0xE9, 0x3F);

        /// <summary>[ VT_BOOL ] Indicates that the caller wants the WPD class extension library to go into Multi-Transport mode (if true).</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_CLASS_EXTENSION_OPTIONS_MULTITRANSPORT_MODE => new(new(0x3E3595DA, 0x4D71, 0x49FE, 0xA0, 0xB4, 0xD4, 0x40, 0x6C, 0x3A, 0xE9, 0x3F), 2);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the device identification values (WPD_DEVICE_MANUFACTURER, WPD_DEVICE_MODEL, WPD_DEVICE_FIRMWARE_VERSION and WPD_DEVICE_FUNCTIONAL_UNIQUE_ID). Include this with other Class Extension options when initializing.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_CLASS_EXTENSION_OPTIONS_DEVICE_IDENTIFICATION_VALUES => new(new(0x3E3595DA, 0x4D71, 0x49FE, 0xA0, 0xB4, 0xD4, 0x40, 0x6C, 0x3A, 0xE9, 0x3F), 3);

        /// <summary>[ VT_UI4 ] Indicates the theoretical maximum bandwidth of the transport in kilobits per second.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_CLASS_EXTENSION_OPTIONS_TRANSPORT_BANDWIDTH => new(new(0x3E3595DA, 0x4D71, 0x49FE, 0xA0, 0xB4, 0xD4, 0x40, 0x6C, 0x3A, 0xE9, 0x3F), 4);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CLASS_EXTENSION_OPTIONS_V3 
        ****************************************************************************/
        /// <summary>This category of properties relates to options used for the WPD device class extension</summary>
        public static Guid WPD_CLASS_EXTENSION_OPTIONS_V3 => new(0x65C160F8, 0x1367, 0x4CE2, 0x93, 0x9D, 0x83, 0x10, 0x83, 0x9F, 0x0D, 0x30);

        /// <summary>[ VT_BOOL ] Indicates that the caller wants Autoplay to be silent when the device is connected (if true).</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_CLASS_EXTENSION_OPTIONS_SILENCE_AUTOPLAY => new(new(0x65C160F8, 0x1367, 0x4CE2, 0x93, 0x9D, 0x83, 0x10, 0x83, 0x9F, 0x0D, 0x30), 2);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_RESOURCE_ATTRIBUTES_V1 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_RESOURCE_ATTRIBUTES_V1 => new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6);

        /// <summary>[ VT_UI8 ] Total size in bytes of the resource data.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_TOTAL_SIZE => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 2);

        /// <summary>[ VT_BOOL ] Indicates whether client applications have permission to open the resource for Read access.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_CAN_READ => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 3);

        /// <summary>[ VT_BOOL ] Indicates whether client applications have permission to open the resource for Write access.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_CAN_WRITE => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 4);

        /// <summary>[ VT_BOOL ] Indicates whether client applications have permission to Delete a resource from the device.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_CAN_DELETE => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 5);

        /// <summary>[ VT_UI4 ] The recommended buffer size a caller should use when doing buffered reads on the resource.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_OPTIMAL_READ_BUFFER_SIZE => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 6);

        /// <summary>[ VT_UI4 ] The recommended buffer size a caller should use when doing buffered writes on the resource.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_OPTIMAL_WRITE_BUFFER_SIZE => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 7);

        /// <summary>[ VT_CLSID ] Indicates the format of the resource data.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_FORMAT => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 8);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing a single value, which is the key identifying the resource.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_RESOURCE_ATTRIBUTE_RESOURCE_KEY => new(new(0x1EB6F604, 0x9278, 0x429F, 0x93, 0xCC, 0x5B, 0xB8, 0xC0, 0x66, 0x56, 0xB6), 9);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_DEVICE_PROPERTIES_V1 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_DEVICE_PROPERTIES_V1 => new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC);

        /// <summary>[ VT_LPWSTR ] Indicates a human-readable description of a synchronization partner for the device.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_SYNC_PARTNER => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 2);

        /// <summary>[ VT_LPWSTR ] Indicates the firmware version for the device.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_FIRMWARE_VERSION => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 3);

        /// <summary>[ VT_UI4 ] Indicates the power level of the device's battery.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_DEVICE_POWER_LEVEL => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 4);

        /// <summary>[ VT_UI4 ] Indicates the power source of the device e.g. whether it is battery or external.</summary>
        [CorrespondingType(typeof(WPD_POWER_SOURCES))]
        public static PROPERTYKEY WPD_DEVICE_POWER_SOURCE => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 5);

        /// <summary>[ VT_LPWSTR ] Identifies the device protocol being used.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_PROTOCOL => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 6);

        /// <summary>[ VT_LPWSTR ] Identifies the device manufacturer.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_MANUFACTURER => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 7);

        /// <summary>[ VT_LPWSTR ] Identifies the device model.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_MODEL => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 8);

        /// <summary>[ VT_LPWSTR ] Identifies the serial number of the device.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_SERIAL_NUMBER => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 9);

        /// <summary>[ VT_BOOL ] Indicates whether the device supports non-consumable objects.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_DEVICE_SUPPORTS_NON_CONSUMABLE => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 10);

        /// <summary>[ VT_DATE ] Represents the current date and time settings of the device.</summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_DEVICE_DATETIME => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 11);

        /// <summary>[ VT_LPWSTR ] Represents the friendly name set by the user on the device.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_FRIENDLY_NAME => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 12);

        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of VT_LPWSTR values indicating the Digital Rights Management schemes supported by the driver.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_DEVICE_SUPPORTED_DRM_SCHEMES => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 13);

        /// <summary>[ VT_BOOL ] Indicates whether the supported formats returned from the device are in a preferred order. (First format in the list is most preferred by the device, while the last is the least preferred.)</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_DEVICE_SUPPORTED_FORMATS_ARE_ORDERED => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 14);

        /// <summary>[ VT_UI4 ] Indicates the device type, used for representation purposes only. Functional characteristics of the device are decided through functional objects.</summary>
        [CorrespondingType(typeof(WPD_DEVICE_TYPES))]
        public static PROPERTYKEY WPD_DEVICE_TYPE => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 15);

        /// <summary>[ VT_UI8 ] Indicates the EUI-64 network identifier of the device, used for out-of-band Network Association operations.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_DEVICE_NETWORK_IDENTIFIER => new(new(0x26D4979A, 0xE643, 0x4626, 0x9E, 0x2B, 0x73, 0x6D, 0xC0, 0xC9, 0x2F, 0xDC), 16);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_DEVICE_PROPERTIES_V2 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_DEVICE_PROPERTIES_V2 => new(0x463DD662, 0x7FC4, 0x4291, 0x91, 0x1C, 0x7F, 0x4C, 0x9C, 0xCA, 0x97, 0x99);

        /// <summary>[ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier common across multiple transports supported by the device.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_DEVICE_FUNCTIONAL_UNIQUE_ID => new(new(0x463DD662, 0x7FC4, 0x4291, 0x91, 0x1C, 0x7F, 0x4C, 0x9C, 0xCA, 0x97, 0x99), 2);

        /// <summary>[ VT_VECTOR | VT_UI1 ] Indicates a unique 16 byte identifier for cosmetic differentiation among different models of the device.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_DEVICE_MODEL_UNIQUE_ID => new(new(0x463DD662, 0x7FC4, 0x4291, 0x91, 0x1C, 0x7F, 0x4C, 0x9C, 0xCA, 0x97, 0x99), 3);

        /// <summary>[ VT_UI4 ] Indicates the transport type (USB, IP, Bluetooth, etc.).</summary>
        [CorrespondingType(typeof(WPD_DEVICE_TRANSPORTS))]
        public static PROPERTYKEY WPD_DEVICE_TRANSPORT => new(new(0x463DD662, 0x7FC4, 0x4291, 0x91, 0x1C, 0x7F, 0x4C, 0x9C, 0xCA, 0x97, 0x99), 4);

        /// <summary>[ VT_BOOL ] If this property exists and is set to true, the device can be used with Device Stage.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_DEVICE_USE_DEVICE_STAGE => new(new(0x463DD662, 0x7FC4, 0x4291, 0x91, 0x1C, 0x7F, 0x4C, 0x9C, 0xCA, 0x97, 0x99), 5);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_DEVICE_PROPERTIES_V3 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_DEVICE_PROPERTIES_V3 => new(0x6C2B878C, 0xC2EC, 0x490D, 0xB4, 0x25, 0xD7, 0xA7, 0x5E, 0x23, 0xE5, 0xED);

        /// <summary>[ VT_LPWSTR ] Represents EDP identity of the device.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_DEVICE_EDP_IDENTITY => new(new(0x6C2B878C, 0xC2EC, 0x490D, 0xB4, 0x25, 0xD7, 0xA7, 0x5E, 0x23, 0xE5, 0xED), 1);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_SERVICE_PROPERTIES_V1 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_SERVICE_PROPERTIES_V1 => new(0x7510698A, 0xCB54, 0x481C, 0xB8, 0xDB, 0x0D, 0x75, 0xC9, 0x3F, 0x1C, 0x06);

        /// <summary>[ VT_LPWSTR ] Indicates the implementation version of a service.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_SERVICE_VERSION => new(new(0x7510698A, 0xCB54, 0x481C, 0xB8, 0xDB, 0x0D, 0x75, 0xC9, 0x3F, 0x1C, 0x06), 2);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_EVENT_PROPERTIES_V1 
        *
        * The properties in this category are for properties that may be needed for event processing, but do not have object property equivalents (i.e. they are not exposed as object properties, but rather, used only as event parameters).
        ****************************************************************************/
        public static Guid WPD_EVENT_PROPERTIES_V1 => new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0);

        /// <summary>[ VT_LPWSTR ] Indicates the device that originated the event.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_PNP_DEVICE_ID => new(new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0), 2);

        /// <summary>[ VT_CLSID ] Indicates the event sent.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_EVENT_ID => new(new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0), 3);

        /// <summary>[ VT_UI4 ] Indicates the current state of the operation (e.g. started, running, stopped etc.).</summary>
        [CorrespondingType(typeof(WPD_OPERATION_STATES))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_OPERATION_STATE => new(new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0), 4);

        /// <summary>[ VT_UI4 ] Indicates the progress of a currently executing operation. Value is from 0 to 100, with 100 indicating that the operation is complete.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_OPERATION_PROGRESS => new(new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0), 5);

        /// <summary>[ VT_LPWSTR ] Uniquely identifies the parent object, similar to WPD_OBJECT_PARENT_ID, but this ID will not change between sessions.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_OBJECT_PARENT_PERSISTENT_UNIQUE_ID => new(new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0), 6);

        /// <summary>[ VT_LPWSTR ] This is the cookie handed back to a client when it requested an object creation using the IPortableDeviceContent::CreateObjectWithPropertiesAndData method.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_OBJECT_CREATION_COOKIE => new(new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0), 7);

        /// <summary>[ VT_BOOL ] Indicates that the child hiearchy for the object has changed.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_CHILD_HIERARCHY_CHANGED => new(new(0x15AB1953, 0xF817, 0x4FEF, 0xA9, 0x21, 0x56, 0x76, 0xE8, 0x38, 0xF6, 0xE0), 8);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_EVENT_PROPERTIES_V2 
        *
        * The properties in this category are for properties that may be needed for event processing, but do not have object property equivalents (i.e. they are not exposed as object properties, but rather, used only as event parameters).
        ****************************************************************************/
        public static Guid WPD_EVENT_PROPERTIES_V2 => new(0x52807B8A, 0x4914, 0x4323, 0x9B, 0x9A, 0x74, 0xF6, 0x54, 0xB2, 0xB8, 0x46);

        /// <summary>[ VT_LPWSTR ] Indicates the service method invocation context.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EVENT_PARAMETER_SERVICE_METHOD_CONTEXT => new(new(0x52807B8A, 0x4914, 0x4323, 0x9B, 0x9A, 0x74, 0xF6, 0x54, 0xB2, 0xB8, 0x46), 2);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_EVENT_OPTIONS_V1 
        *
        * The properties in this category describe event options.
        ****************************************************************************/
        public static Guid WPD_EVENT_OPTIONS_V1 => new(0xB3D8DAD7, 0xA361, 0x4B83, 0x8A, 0x48, 0x5B, 0x02, 0xCE, 0x10, 0x71, 0x3B);

        /// <summary>[ VT_BOOL ] Indicates that the event is broadcast to all clients.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_EVENT_OPTION_IS_BROADCAST_EVENT => new(new(0xB3D8DAD7, 0xA361, 0x4B83, 0x8A, 0x48, 0x5B, 0x02, 0xCE, 0x10, 0x71, 0x3B), 2);

        /// <summary>[ VT_BOOL ] Indicates that the event is sent to and handled by Autoplay.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_EVENT_OPTION_IS_AUTOPLAY_EVENT => new(new(0xB3D8DAD7, 0xA361, 0x4B83, 0x8A, 0x48, 0x5B, 0x02, 0xCE, 0x10, 0x71, 0x3B), 3);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_EVENT_ATTRIBUTES_V1 
        *
        * The properties in this category describe event attributes.
        ****************************************************************************/
        public static Guid WPD_EVENT_ATTRIBUTES_V1 => new(0x10C96578, 0x2E81, 0x4111, 0xAD, 0xDE, 0xE0, 0x8C, 0xA6, 0x13, 0x8F, 0x6D);

        /// <summary>[ VT_LPWSTR ] Contains the name of the event.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EVENT_ATTRIBUTE_NAME => new(new(0x10C96578, 0x2E81, 0x4111, 0xAD, 0xDE, 0xE0, 0x8C, 0xA6, 0x13, 0x8F, 0x6D), 2);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the event parameters.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_EVENT_ATTRIBUTE_PARAMETERS => new(new(0x10C96578, 0x2E81, 0x4111, 0xAD, 0xDE, 0xE0, 0x8C, 0xA6, 0x13, 0x8F, 0x6D), 3);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the event options.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_EVENT_ATTRIBUTE_OPTIONS => new(new(0x10C96578, 0x2E81, 0x4111, 0xAD, 0xDE, 0xE0, 0x8C, 0xA6, 0x13, 0x8F, 0x6D), 4);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_API_OPTIONS_V1 
        *
        * The properties in this category describe API options.
        ****************************************************************************/
        public static Guid WPD_API_OPTIONS_V1 => new(0x10E54A3E, 0x052D, 0x4777, 0xA1, 0x3C, 0xDE, 0x76, 0x14, 0xBE, 0x2B, 0xC4);

        /// <summary>[ VT_BOOL ] Indicates that the data stream created for data transfer will be clear only (i.e. No DRM will be involved).</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_API_OPTION_USE_CLEAR_DATA_STREAM => new(new(0x10E54A3E, 0x052D, 0x4777, 0xA1, 0x3C, 0xDE, 0x76, 0x14, 0xBE, 0x2B, 0xC4), 2);

        /// <summary>[ VT_UI4 ] An optional property that clients can add to the [In] parameter set of IPortableDevice::SendCommand to specify the access required for the command. The Portable Device API uses this to identify whether the IOCTL sent to the driver is sent with FILE_READ_ACCESS or (FILE_READ_ACCESS | FILE_WRITE_ACCESS) access flags.</summary>
        [CorrespondingType(typeof(Kernel32.IOAccess))]
        public static PROPERTYKEY WPD_API_OPTION_IOCTL_ACCESS => new(new(0x10E54A3E, 0x052D, 0x4777, 0xA1, 0x3C, 0xDE, 0x76, 0x14, 0xBE, 0x2B, 0xC4), 3);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_FORMAT_ATTRIBUTES_V1 
        *
        * The properties in this category describe format attributes.
        ****************************************************************************/
        public static Guid WPD_FORMAT_ATTRIBUTES_V1 => new(0xA0A02000, 0xBCAF, 0x4BE8, 0xB3, 0xF5, 0x23, 0x3F, 0x23, 0x1C, 0xF5, 0x8F);

        /// <summary>[ VT_LPWSTR ] Contains the name of the format.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_FORMAT_ATTRIBUTE_NAME => new(new(0xA0A02000, 0xBCAF, 0x4BE8, 0xB3, 0xF5, 0x23, 0x3F, 0x23, 0x1C, 0xF5, 0x8F), 2);

        /// <summary>[ VT_LPWSTR ] Contains the MIME type of the format.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_FORMAT_ATTRIBUTE_MIMETYPE => new(new(0xA0A02000, 0xBCAF, 0x4BE8, 0xB3, 0xF5, 0x23, 0x3F, 0x23, 0x1C, 0xF5, 0x8F), 3);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_METHOD_ATTRIBUTES_V1 
        *
        * The properties in this category describe method attributes.
        ****************************************************************************/
        public static Guid WPD_METHOD_ATTRIBUTES_V1 => new(0xF17A5071, 0xF039, 0x44AF, 0x8E, 0xFE, 0x43, 0x2C, 0xF3, 0x2E, 0x43, 0x2A);

        /// <summary>[ VT_LPWSTR ] Contains the name of the method.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_METHOD_ATTRIBUTE_NAME => new(new(0xF17A5071, 0xF039, 0x44AF, 0x8E, 0xFE, 0x43, 0x2C, 0xF3, 0x2E, 0x43, 0x2A), 2);

        /// <summary>[ VT_CLSID ] Contains the format this method applies to. This is Guid.Empty if the method does not apply to a format.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_METHOD_ATTRIBUTE_ASSOCIATED_FORMAT => new(new(0xF17A5071, 0xF039, 0x44AF, 0x8E, 0xFE, 0x43, 0x2C, 0xF3, 0x2E, 0x43, 0x2A), 3);

        /// <summary>[ VT_UI4 ] Indicates the required access for a method.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_METHOD_ATTRIBUTE_ACCESS => new(new(0xF17A5071, 0xF039, 0x44AF, 0x8E, 0xFE, 0x43, 0x2C, 0xF3, 0x2E, 0x43, 0x2A), 4);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing the method parameters.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_METHOD_ATTRIBUTE_PARAMETERS => new(new(0xF17A5071, 0xF039, 0x44AF, 0x8E, 0xFE, 0x43, 0x2C, 0xF3, 0x2E, 0x43, 0x2A), 5);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_PARAMETER_ATTRIBUTES_V1 
        *
        * The properties in this category describe parameter attributes.
        ****************************************************************************/
        public static Guid WPD_PARAMETER_ATTRIBUTES_V1 => new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58);

        /// <summary>[ VT_UI4 ] The order (starting from 0) of a method parameter.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_ORDER => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 2);

        /// <summary>[ VT_UI4 ] The usage of the method parameter.</summary>
        [CorrespondingType(typeof(WPD_PARAMETER_USAGE_TYPES))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_USAGE => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 3);

        /// <summary>[ VT_UI4 ] Specifies the form of the valid values allowed for this parameter.</summary>
        [CorrespondingType(typeof(WpdParameterAttributeForm))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_FORM => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 4);

        /// <summary>[ VT_XXXX ] Specifies the default value for this parameter.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_DEFAULT_VALUE => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 5);

        /// <summary>[ VT_XXXX ] The minimum value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_RANGE_MIN => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 6);

        /// <summary>[ VT_XXXX ] The maximum value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_RANGE_MAX => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 7);

        /// <summary>[ VT_XXXX ] The step value for a parameter whose form is of WPD_PARAMETER_ATTRIBUTE_FORM_RANGE.</summary>
        [CorrespondingType(typeof(object))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_RANGE_STEP => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 8);

        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection containing the enumeration values.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_ENUMERATION_ELEMENTS => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 9);

        /// <summary>[ VT_LPWSTR ] A regular expression string indicating acceptable values for parameters whose form is WPD_PARAMETER_ATTRIBUTE_FORM_REGULAR_EXPRESSION.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_REGULAR_EXPRESSION => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 10);

        /// <summary>[ VT_UI8 ] This indicates the maximum size (in bytes) for the value of this parameter.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_MAX_SIZE => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 11);

        /// <summary>[ VT_UI4 ] Contains the VARTYPE of the parameter.</summary>
        [CorrespondingType(typeof(VARTYPE))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_VARTYPE => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 12);

        /// <summary>[ VT_LPWSTR ] Contains the parameter name.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PARAMETER_ATTRIBUTE_NAME => new(new(0xE6864DD7, 0xF325, 0x45EA, 0xA1, 0xD5, 0x97, 0xCF, 0x73, 0xB6, 0xCA, 0x58), 13);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_COMMON 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_CATEGORY_COMMON => new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A);

        // ======== Commands ========
        /// <summary>
        /// WPD_COMMAND_COMMON_RESET_DEVICE 
        /// This command is sent by clients to reset the device. 
        /// Access:
        /// (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        /// Parameters:
        /// None
        /// Results:
        /// None</summary>
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        public static PROPERTYKEY WPD_COMMAND_COMMON_RESET_DEVICE => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 2);
        /// <summary>
        /// WPD_COMMAND_COMMON_GET_OBJECT_IDS_FROM_PERSISTENT_UNIQUE_IDS 
        /// This command is sent when a client wants to get current ObjectIDs representing objects specified by previously acquired Persistent Unique IDs. 
        /// Access:
        /// FILE_READ_ACCESS
        /// Parameters:
        /// [ Required ] WPD_PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS 
        /// Results:
        /// [ Required ] WPD_PROPERTY_COMMON_OBJECT_IDS </summary>
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_OBJECT_IDS), true)]
        public static PROPERTYKEY WPD_COMMAND_COMMON_GET_OBJECT_IDS_FROM_PERSISTENT_UNIQUE_IDS => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 3);
        /// <summary>
        /// WPD_COMMAND_COMMON_SAVE_CLIENT_INFORMATION 
        /// This command is sent when a client first connects to a device. 
        /// Access:
        /// FILE_READ_ACCESS
        /// Parameters:
        /// [ Required ] WPD_PROPERTY_COMMON_CLIENT_INFORMATION 
        /// Results:
        /// [ Optional ] WPD_PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT </summary>
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_COMMON_CLIENT_INFORMATION), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT), false)]
        public static PROPERTYKEY WPD_COMMAND_COMMON_SAVE_CLIENT_INFORMATION => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 4);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_CLSID ] Specifies the command Category (i.e. the Guid portion of the PROPERTYKEY indicating the command).</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_COMMAND_CATEGORY => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1001);

        /// <summary>[ VT_UI4 ] Specifies the command ID, which is the PID portion of the PROPERTYKEY indicating the command.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_COMMAND_ID => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1002);

        /// <summary>[ VT_ERROR ] The driver sets this to be the HRESULT of the requested operation.</summary>
        [CorrespondingType(typeof(HRESULT))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_HRESULT => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1003);

        /// <summary>[ VT_UI4 ] Special driver specific code which driver may return on error. Typically only for use with diagnostic tools or vertical solutions.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_DRIVER_ERROR_CODE => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1004);

        /// <summary>[ VT_LPWSTR ] Identifies the object which the command is intended for.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_COMMAND_TARGET => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1006);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Persistent Unique IDs.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_PERSISTENT_UNIQUE_IDS => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1007);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Objects IDs.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_OBJECT_IDS => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1008);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues used to identify itself to the driver.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_CLIENT_INFORMATION => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1009);

        /// <summary>[ VT_LPWSTR ] Driver specified context which will be sent for the particular client on all subsequent operations.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_CLIENT_INFORMATION_CONTEXT => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1010);

        /// <summary>[ VT_CLSID ] An optional ActivityID set either by a client or by WPD API, when ETW tracing is enabled.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_COMMON_ACTIVITY_ID => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 1011);

        // ======== Command Options ========

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR specifying list of Objects IDs of the objects that support the command. </summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_OPTION_VALID_OBJECT_IDS => new(new(0xF0422A9C, 0x5DC8, 0x4440, 0xB5, 0xBD, 0x5D, 0xF2, 0x88, 0x35, 0x65, 0x8A), 5001);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_OBJECT_ENUMERATION 
        *
        * The commands in this category are used for basic object enumeration.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_OBJECT_ENUMERATION => new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC);

        // ======== Commands ========
        //
        // WPD_COMMAND_OBJECT_ENUMERATION_START_FIND 
        // The driver receives this command when a client wishes to start enumeration. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_ENUMERATION_PARENT_ID 
        // [ Optional ] WPD_PROPERTY_OBJECT_ENUMERATION_FILTER 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_ENUMERATION_PARENT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_ENUMERATION_FILTER), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_ENUMERATION_START_FIND => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 2);
        //
        // WPD_COMMAND_OBJECT_ENUMERATION_FIND_NEXT 
        // This command is used when the client requests the next batch of ObjectIDs during enumeration. Only objects that match the constraints set up in WPD_COMMAND_OBJECT_ENUMERATION_START_FIND should be returned. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_ENUMERATION_FIND_NEXT => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 3);
        //
        // WPD_COMMAND_OBJECT_ENUMERATION_END_FIND 
        // The driver should destroy any resources associated with this enumeration context. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT 
        // Results:
        // None
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_ENUMERATION_END_FIND => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 4);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_LPWSTR ] The ObjectID specifying the parent object where enumeration should start.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_ENUMERATION_PARENT_ID => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 1001);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which specifies the properties used to filter on. If the caller does not want filtering, then this value will not be set.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_ENUMERATION_FILTER => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 1002);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDevicePropVariantCollection of ObjectIDs (of type VT_LPWSTR). If 0 objects are returned, this should be an empty collection, not default.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_ENUMERATION_OBJECT_IDS => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 1003);

        /// <summary>[ VT_LPWSTR ] This is a driver-specified identifier for the context associated with this enumeration.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_ENUMERATION_CONTEXT => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 1004);

        /// <summary>[ VT_UI4 ] The maximum number of ObjectIDs to return back to the client.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_ENUMERATION_NUM_OBJECTS_REQUESTED => new(new(0xB7474E91, 0xE7F8, 0x4AD9, 0xB4, 0x00, 0xAD, 0x1A, 0x4B, 0x58, 0xEE, 0xEC), 1005);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_OBJECT_PROPERTIES 
        *
        * This category of commands is used to perform basic property operations such as Reading/Writing values, listing supported values and so on.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_OBJECT_PROPERTIES => new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04);

        // ======== Commands ========
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED 
        // This command is used when the client requests the list of properties supported by the specified object. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_GET_SUPPORTED => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 2);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_GET_ATTRIBUTES 
        // This command is used when the client requests the property attributes for the specified object properties. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_GET_ATTRIBUTES => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 3);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_GET 
        // This command is used when the client requests a set of property values for the specified object. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_GET => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 4);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_SET 
        // This command is used when the client requests to write a set of property values on the specified object. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_SET => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 5);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_GET_ALL 
        // This command is used when the client requests all property values for the specified object. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_GET_ALL => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 6);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_DELETE 
        // This command is sent when the caller wants to delete properties from the specified object. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS 
        // Results:
        // [ Optional ] WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS), false)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_DELETE => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 7);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_LPWSTR ] The ObjectID specifying the object whose properties are being queried/manipulated.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 1001);

        /// <summary>[ VT_UNKNOWN ] An IPortableDeviceKeyCollection identifying which specific property values we are querying/manipulating.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_KEYS => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 1002);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the attributes for each property requested.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_ATTRIBUTES => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 1003);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the values read. For any property whose value could not be read, the type must be set to VT_ERROR, and the 'scode' field must contain the failure HRESULT.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_VALUES => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 1004);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each property write operation.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_WRITE_RESULTS => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 1005);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each property delete operation.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_PROPERTY_DELETE_RESULTS => new(new(0x9E5582E4, 0x0814, 0x44E6, 0x98, 0x1A, 0xB2, 0x99, 0x8D, 0x58, 0x38, 0x04), 1006);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_OBJECT_PROPERTIES_BULK 
        *
        * This category contains commands and properties for property operations across multiple objects.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_OBJECT_PROPERTIES_BULK => new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E);

        // ======== Commands ========
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_START 
        // Initializes the operation to get the property values for all caller-specified objects. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS 
        // [ Optional ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_START => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 2);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_NEXT 
        // Get the next set of property values. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_NEXT => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 3);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_END 
        // Ends the bulk property operation for getting property values by object list. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        // Results:
        // None
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_LIST_END => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 4);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_START 
        // Initializes the operation to get the property values for objects of the specified format 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT 
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH 
        // [ Optional ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS), false)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_START => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 5);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_NEXT 
        // Get the next set of property values. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_NEXT => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 6);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_END 
        // Ends the bulk property operation for getting property values by object format. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        // Results:
        // None
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_GET_VALUES_BY_OBJECT_FORMAT_END => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 7);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_START 
        // Initializes the operation to set the property values for specified objects. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_START => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 8);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_NEXT 
        // Set the next set of property values. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_NEXT => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 9);
        //
        // WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_END 
        // Ends the bulk property operation for setting property values by object list. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_PROPERTIES_BULK_SET_VALUES_BY_OBJECT_LIST_END => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 10);

        // ======== Command Parameters ======== 

        /// <summary>WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS </summary>
        // [ VT_UNKNOWN ] A collection of ObjectIDs for which supported property list must be returned.
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_IDS => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1001);

        /// <summary>[ VT_LPWSTR ] The driver-specified context identifying this particular bulk operation.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_CONTEXT => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1002);

        /// <summary>[ VT_UNKNOWN ] Contains an IPortableDeviceValuesCollection specifying the next set of IPortableDeviceValues elements.</summary>
        [CorrespondingType(typeof(IPortableDeviceValuesCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_VALUES => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1003);

        /// <summary>[ VT_UNKNOWN ] Contains an IPortableDeviceKeyCollection specifying which properties the caller wants to return. May not exist, which indicates caller wants ALL properties.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PROPERTY_KEYS => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1004);

        /// <summary>[ VT_UI4 ] Contains a value specifying the hierarchical depth from the parent to include in this operation.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_DEPTH => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1005);

        /// <summary>[ VT_LPWSTR ] Contains the ObjectID of the object to start the operation from.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_PARENT_OBJECT_ID => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1006);

        /// <summary>[ VT_CLSID ] Specifies the object format the client is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_OBJECT_FORMAT => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1007);

        /// <summary>[ VT_UNKNOWN ] Contains an IPortableDeviceValuesCollection specifying the set of IPortableDeviceValues elements indicating the write results for each property set.</summary>
        [CorrespondingType(typeof(IPortableDeviceValuesCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_PROPERTIES_BULK_WRITE_RESULTS => new(new(0x11C824DD, 0x04CD, 0x4E4E, 0x8C, 0x7B, 0xF6, 0xEF, 0xB7, 0x94, 0xD8, 0x4E), 1008);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_OBJECT_RESOURCES 
        *
        * The commands in this category are used for basic object resource enumeration and transfer.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_OBJECT_RESOURCES => new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A);

        // ======== Commands ========
        //
        // WPD_COMMAND_OBJECT_RESOURCES_GET_SUPPORTED 
        // This command is sent when a client wants to get the list of resources supported on a particular object. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_GET_SUPPORTED => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 2);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_GET_ATTRIBUTES 
        // This command is used when the client requests the attributes for the specified object resource. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_GET_ATTRIBUTES => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 3);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_OPEN 
        // This command is sent when a client wants to use a particular resource on an object. 
        // Access:
        // Dependent on the value of WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE. STGM_READ will indicate FILE_READ_ACCESS for the command, anything else will indicate (FILE_READ_ACCESS | FILE_WRITE_ACCESS).
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE 
        // [ Optional ] WPD_PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_FROM_PROPERTY_WITH_STGM_ACCESS, nameof(WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE))]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS), false)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_OPEN => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 4);

        //
        // WPD_COMMAND_OBJECT_RESOURCES_READ 
        // This command is sent when a client wants to read the next band of data from a previously opened object resource. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ 
        // [ Required except when the driver returns true for the WPD_OPTION_OBJECT_RESOURCES_NO_INPUT_BUFFER_ON_READ option. ] WPD_PROPERTY_OBJECT_RESOURCES_DATA 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_DATA 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_DATA), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_DATA), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_READ => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 5);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_WRITE 
        // This command is sent when a client wants to write the next band of data to a previously opened object resource. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_DATA 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_DATA), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_WRITE => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 6);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_CLOSE 
        // This command is sent when a client is finished transferring data to a previously opened object resource. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // Results:
        // None
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_CLOSE => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 7);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_DELETE 
        // This command is sent when the client wants to delete the data associated with the specified resources from the specified object. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_DELETE => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 8);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_CREATE_RESOURCE 
        // This command is sent when a client wants to create a new object resource on the device. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_CREATE_RESOURCE => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 9);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_REVERT 
        // This command is sent when a client wants to cancel the resource creation request that is currently still in progress. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_REVERT => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 10);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_SEEK 
        // This command is sent when a client wants to seek to a specific offset in the data stream. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_SEEK => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 11);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_COMMIT 
        // This command is sent when a client wants to commit changes to a data stream. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_COMMIT => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 12);
        //
        // WPD_COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS 
        // This command is sent when a client wants to seek to a specific offset in the data stream using alternate units. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_STREAM_UNITS 
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_STREAM_UNITS), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 13);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_LPWSTR ] </summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_OBJECT_ID => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1001);

        /// <summary>[ VT_UI4 ] Specifies the type of access the client is requesting for the resource.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_ACCESS_MODE => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1002);

        ///   <summary>[ VT_UNKNOWN ] </summary>
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_KEYS => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1003);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the attributes for the resource requested.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_RESOURCE_ATTRIBUTES => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1004);

        /// <summary>[ VT_LPWSTR ] This is a driver-specified identifier for the context associated with the resource operation.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_CONTEXT => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1005);

        /// <summary>[ VT_UI4 ] Specifies the number of bytes the client is requesting to read.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_READ => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1006);

        /// <summary>[ VT_UI4 ] Specifies the number of bytes actually read from the resource.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_READ => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1007);

        /// <summary>[ VT_UI4 ] Specifies the number of bytes the client is requesting to write.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_TO_WRITE => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1008);

        /// <summary>[ VT_UI4 ] Driver sets this to let caller know how many bytes were actually written.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_NUM_BYTES_WRITTEN => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1009);

        /// <summary>[ VT_VECTOR | VT_UI1 ] </summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_DATA => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1010);

        /// <summary>[ VT_UI4 ] Indicates the optimal transfer buffer size (in bytes) that clients should use when reading/writing this resource.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_OPTIMAL_TRANSFER_BUFFER_SIZE => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1011);

        /// <summary>[ VT_I8 ] Displacement to be added to the location indicated by the WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG parameter.</summary>
        [CorrespondingType(typeof(long))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_SEEK_OFFSET => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1012);

        /// <summary>[ VT_UI4 ] Specifies the origin of the displacement for the seek operation.</summary>
        [CorrespondingType(typeof(System.IO.SeekOrigin))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_SEEK_ORIGIN_FLAG => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1013);

        /// <summary>[ VT_UI8 ] Value of the new seek pointer from the beginning of the data stream.</summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1014);

        /// <summary>[ VT_BOOL ] A Boolean value that specifies whether this resource supports operations (such as seek) using alternate units. This occurs if the driver can understand WPD_COMMAND_OBJECT_RESOURCES_SEEK_IN_UNITS.</summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_SUPPORTS_UNITS => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1015);

        /// <summary>[ VT_UI4 ] The units for the WPD_PROPERTY_OBJECT_SEEK_OFFSET parameter and the WPD_PROPERTY_OBJECT_RESOURCES_POSITION_FROM_START result.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_RESOURCES_STREAM_UNITS => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 1016);

        // ======== Command Options ========

        /// <summary>[ VT_BOOL ] Indicates whether the driver can Seek on a resource opened for Read access. </summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OPTION_OBJECT_RESOURCES_SEEK_ON_READ_SUPPORTED => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 5001);

        /// <summary>[ VT_BOOL ] Indicates whether the driver can Seek on a resource opened for Write access. </summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OPTION_OBJECT_RESOURCES_SEEK_ON_WRITE_SUPPORTED => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 5002);

        /// <summary>[ VT_BOOL ] Indicates whether the driver requires an input buffer for WPD_COMMAND_OBJECT_RESOURCES_READ. If not set, defaults to False. </summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OPTION_OBJECT_RESOURCES_NO_INPUT_BUFFER_ON_READ => new(new(0xB3A2B22D, 0xA595, 0x4108, 0xBE, 0x0A, 0xFC, 0x3C, 0x96, 0x5F, 0x3D, 0x4A), 5003);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_OBJECT_MANAGEMENT 
        *
        * The commands specified in this category are used to Create/Delete objects on the device.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_OBJECT_MANAGEMENT => new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89);

        // ======== Commands ========
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_ONLY 
        // This command is sent when a client wants to create a new object on the device, specified only by properties. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_ONLY => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 2);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_AND_DATA 
        // This command is sent when a client wants to create a new object on the device, specified by properties and data. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_CREATE_OBJECT_WITH_PROPERTIES_AND_DATA => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 3);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_WRITE_OBJECT_DATA 
        // This command is sent when a client wants to write the next band of data to a newly created object or an object being updated. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE 
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_DATA 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_DATA), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_WRITE_OBJECT_DATA => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 4);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_COMMIT_OBJECT 
        // This command is sent when a client has finished sending all the data associated with an object creation or update request, and wishes to ensure that the object is saved to the device. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_COMMIT_OBJECT => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 5);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_REVERT_OBJECT 
        // This command is sent when a client wants to cancel the object creation or update request that is currently still in progress. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_REVERT_OBJECT => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 6);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS 
        // This command is sent when the client wishes to remove a set of objects from the device. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS 
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_DELETE_OBJECTS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 7);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_MOVE_OBJECTS 
        // This command will move the specified objects to the destination folder. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_MOVE_OBJECTS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 8);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_COPY_OBJECTS 
        // This command will copy the specified objects to the destination folder. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS 
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_COPY_OBJECTS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 9);
        //
        // WPD_COMMAND_OBJECT_MANAGEMENT_UPDATE_OBJECT_WITH_PROPERTIES_AND_DATA 
        // This command is sent when a client wants to update the object's data and dependent properties simultaneously. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES 
        // Results:
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT 
        // [ Required ] WPD_PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE), true)]
        public static PROPERTYKEY WPD_COMMAND_OBJECT_MANAGEMENT_UPDATE_OBJECT_WITH_PROPERTIES_AND_DATA => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 10);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which specifies the properties used to create the new object.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_CREATION_PROPERTIES => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1001);

        /// <summary>[ VT_LPWSTR ] This is a driver-specified identifier for the context associated with this 'create object' operation.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_CONTEXT => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1002);

        /// <summary>[ VT_UI4 ] Specifies the number of bytes the client is requesting to write.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_TO_WRITE => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1003);

        /// <summary>[ VT_UI4 ] Indicates the number of bytes written for the object.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_NUM_BYTES_WRITTEN => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1004);

        /// <summary>[ VT_VECTOR | VT_UI1 ] Indicates binary data of the object being created on the device.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_DATA => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1005);

        /// <summary>[ VT_LPWSTR ] Identifies a newly created object on the device.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_ID => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1006);

        /// <summary>[ VT_UI4 ] Indicates if the delete operation should be recursive or not.</summary>
        [CorrespondingType(typeof(DELETE_OBJECT_OPTIONS))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_OPTIONS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1007);

        /// <summary>[ VT_UI4 ] Indicates the optimal transfer buffer size (in bytes) that clients should use when writing this object's data.</summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_OPTIMAL_TRANSFER_BUFFER_SIZE => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1008);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR, containing the ObjectIDs to delete.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_IDS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1009);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_DELETE_RESULTS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1010);

        /// <summary>[ VT_LPWSTR ] Indicates the destination folder for the move operation.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_DESTINATION_FOLDER_OBJECT_ID => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1011);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_MOVE_RESULTS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1012);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_COPY_RESULTS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1013);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the object properties to update.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_UPDATE_PROPERTIES => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1014);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the property keys required to update this object.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_PROPERTY_KEYS => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1015);

        /// <summary>[ VT_CLSID ] Indicates the object format the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_OBJECT_MANAGEMENT_OBJECT_FORMAT => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 1016);

        // ======== Command Options ========

        /// <summary>[ VT_BOOL ] Indicates whether the driver supports recursive deletion. </summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OPTION_OBJECT_MANAGEMENT_RECURSIVE_DELETE_SUPPORTED => new(new(0xEF1E43DD, 0xA9ED, 0x4341, 0x8B, 0xCC, 0x18, 0x61, 0x92, 0xAE, 0xA0, 0x89), 5001);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_CAPABILITIES 
        *
        * This command category is used to query capabilities of the device.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_CAPABILITIES => new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56);

        // ======== Commands ========
        //
        // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_COMMANDS 
        // Return all commands supported by this driver. This includes custom commands, if any. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_COMMANDS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 2);
        //
        // WPD_COMMAND_CAPABILITIES_GET_COMMAND_OPTIONS 
        // Returns the supported options for the specified command. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_COMMAND 
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_COMMAND_OPTIONS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_COMMAND), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_COMMAND_OPTIONS), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_COMMAND_OPTIONS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 3);
        //
        // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FUNCTIONAL_CATEGORIES 
        // This command is used by clients to query the functional categories supported by the driver. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FUNCTIONAL_CATEGORIES => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 4);
        //
        // WPD_COMMAND_CAPABILITIES_GET_FUNCTIONAL_OBJECTS 
        // Retrieves the ObjectIDs of the objects belonging to the specified functional category. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY 
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_FUNCTIONAL_OBJECTS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 5);
        //
        // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES 
        // Retrieves the list of content types supported by this driver for the specified functional category. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY 
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_CONTENT_TYPES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_CONTENT_TYPES), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_CONTENT_TYPES => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 6);
        //
        // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMATS 
        // This command is used to query the possible formats supported by the specified content type (e.g. for image objects, the driver may choose to support JPEG and BMP files). 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_CONTENT_TYPE 
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_FORMATS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_CONTENT_TYPE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_FORMATS), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMATS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 7);
        //
        // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES 
        // Get the list of properties that an object of the given format supports. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_FORMAT 
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_FORMAT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 8);
        //
        // WPD_COMMAND_CAPABILITIES_GET_FIXED_PROPERTY_ATTRIBUTES 
        // Returns the property attributes that are the same for all objects of the given format. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_FORMAT 
        // [ Required ] WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS 
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_FORMAT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_FIXED_PROPERTY_ATTRIBUTES => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 9);
        //
        // WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_EVENTS 
        // Return all events supported by this driver. This includes custom events, if any. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_SUPPORTED_EVENTS 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_SUPPORTED_EVENTS), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_SUPPORTED_EVENTS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 10);
        //
        // WPD_COMMAND_CAPABILITIES_GET_EVENT_OPTIONS 
        // Return extra information about a specified event, such as whether the event is for notification or action purposes. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_EVENT 
        // Results:
        // [ Required ] WPD_PROPERTY_CAPABILITIES_EVENT_OPTIONS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_CAPABILITIES_EVENT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CAPABILITIES_EVENT_OPTIONS), true)]
        public static PROPERTYKEY WPD_COMMAND_CAPABILITIES_GET_EVENT_OPTIONS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 11);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_UNKNOWN ] IPortableDeviceKeyCollection containing all commands a driver supports.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_SUPPORTED_COMMANDS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1001);

        /// <summary>[ VT_UNKNOWN ] Indicates the command whose options the caller is interested in.</summary>
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_COMMAND => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1002);

        /// <summary>[ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant command options.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_COMMAND_OPTIONS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1003);

        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_CLSID which indicates the functional categories supported by the driver.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORIES => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1004);

        /// <summary>[ VT_CLSID ] The category the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_CATEGORY => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1005);

        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection (of type VT_LPWSTR) containing the ObjectIDs of the functional objects who belong to the specified functional category.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_FUNCTIONAL_OBJECTS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1006);

        /// <summary>[ VT_UNKNOWN ] Indicates list of content types supported for the specified functional category.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_CONTENT_TYPES => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1007);

        /// <summary>[ VT_CLSID ] Indicates the content type whose formats the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_CONTENT_TYPE => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1008);

        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of VT_CLSID values indicating the formats supported for the specified content type.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_FORMATS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1009);

        /// <summary>[ VT_CLSID ] Specifies the format the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_FORMAT => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1010);

        /// <summary>[ VT_UNKNOWN ] An IPortableDeviceKeyCollection containing the property keys.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_PROPERTY_KEYS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1011);

        /// <summary>[ VT_UNKNOWN ] An IPortableDeviceValues containing the property attributes.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_PROPERTY_ATTRIBUTES => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1012);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of VT_CLSID values containing all events a driver supports.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_SUPPORTED_EVENTS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1013);

        /// <summary>[ VT_CLSID ] Indicates the event the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_EVENT => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1014);

        /// <summary>[ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant event options.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_CAPABILITIES_EVENT_OPTIONS => new(new(0x0CABEC78, 0x6B74, 0x41C6, 0x92, 0x16, 0x26, 0x39, 0xD1, 0xFC, 0xE3, 0x56), 1015);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_STORAGE 
        *
        * This category is for commands and parameters for storage functional objects.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_STORAGE => new(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94);

        // ======== Commands ========
        //
        // WPD_COMMAND_STORAGE_FORMAT 
        // This command will format the storage. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_STORAGE_OBJECT_ID 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_STORAGE_OBJECT_ID), true)]
        public static PROPERTYKEY WPD_COMMAND_STORAGE_FORMAT => new(new(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94), 2);
        //
        // WPD_COMMAND_STORAGE_EJECT 
        // This will eject the storage, if it is a removable store and is capable of being ejected by the device. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_STORAGE_OBJECT_ID 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_STORAGE_OBJECT_ID), true)]
        public static PROPERTYKEY WPD_COMMAND_STORAGE_EJECT => new(new(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94), 4);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_LPWSTR ] Indicates the object to format, move or eject.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_STORAGE_OBJECT_ID => new(new(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94), 1001);

        /// <summary>[ VT_LPWSTR ] Indicates the (folder) object destination for a move operation.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_STORAGE_DESTINATION_OBJECT_ID => new(new(0xD8F907A6, 0x34CC, 0x45FA, 0x97, 0xFB, 0xD0, 0x07, 0xFA, 0x47, 0xEC, 0x94), 1002);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_SMS 
        *
        * The commands in this category relate to Short-Message-Service functionality, typically exposed on mobile phones.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_SMS => new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1);

        // ======== Commands ========
        //
        // WPD_COMMAND_SMS_SEND 
        // This command is used to initiate the sending of an SMS message. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_COMMON_COMMAND_TARGET 
        // [ Required ] WPD_PROPERTY_SMS_RECIPIENT 
        // [ Required ] WPD_PROPERTY_SMS_MESSAGE_TYPE 
        // [ Optional ] WPD_PROPERTY_SMS_TEXT_MESSAGE 
        // [ Optional ] WPD_PROPERTY_SMS_BINARY_MESSAGE 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_COMMON_COMMAND_TARGET), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SMS_RECIPIENT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SMS_MESSAGE_TYPE), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SMS_TEXT_MESSAGE), false)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SMS_BINARY_MESSAGE), false)]
        public static PROPERTYKEY WPD_COMMAND_SMS_SEND => new(new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1), 2);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_LPWSTR ] Indicates the recipient's address.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_SMS_RECIPIENT => new(new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1), 1001);

        /// <summary>[ VT_UI4 ] Indicates whether the message is binary or text.</summary>
        [CorrespondingType(typeof(SMS_MESSAGE_TYPES))]
        public static PROPERTYKEY WPD_PROPERTY_SMS_MESSAGE_TYPE => new(new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1), 1002);

        /// <summary>[ VT_LPWSTR ] if WPD_PROPERTY_SMS_MESSAGE_TYPE == SMS_TEXT_MESSAGE, then this will contain the message body.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_SMS_TEXT_MESSAGE => new(new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1), 1003);

        /// <summary>[ VT_VECTOR | VT_UI1 ] if WPD_PROPERTY_SMS_MESSAGE_TYPE == SMS_BINARY_MESSAGE, then this will contain the binary message body.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_PROPERTY_SMS_BINARY_MESSAGE => new(new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1), 1004);

        /// <summary>[ VT_BOOL ] Indicates whether the driver can support binary messages as well as text messages. </summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OPTION_SMS_BINARY_MESSAGE_SUPPORTED => new(new(0xAFC25D66, 0xFE0D, 0x4114, 0x90, 0x97, 0x97, 0x0C, 0x93, 0xE9, 0x20, 0xD1), 5001);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_STILL_IMAGE_CAPTURE 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_CATEGORY_STILL_IMAGE_CAPTURE => new(0x4FCD6982, 0x22A2, 0x4B05, 0xA4, 0x8B, 0x62, 0xD3, 0x8B, 0xF2, 0x7B, 0x32);

        // ======== Commands ========
        //
        // WPD_COMMAND_STILL_IMAGE_CAPTURE_INITIATE 
        // Initiates a still image capture. This is processed as a single command i.e. there is no start or stop required. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_COMMON_COMMAND_TARGET 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_COMMON_COMMAND_TARGET), true)]
        public static PROPERTYKEY WPD_COMMAND_STILL_IMAGE_CAPTURE_INITIATE => new(new(0x4FCD6982, 0x22A2, 0x4B05, 0xA4, 0x8B, 0x62, 0xD3, 0x8B, 0xF2, 0x7B, 0x32), 2);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_MEDIA_CAPTURE 
        *
        * 
        ****************************************************************************/
        public static Guid WPD_CATEGORY_MEDIA_CAPTURE => new(0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8);

        // ======== Commands ========
        //
        // WPD_COMMAND_MEDIA_CAPTURE_START 
        // Initiates a media capture operation that will only be ended by a subsequent WPD_COMMAND_MEDIA_CAPTURE_STOP command. Typically used to capture media streams such as audio and video. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_COMMON_COMMAND_TARGET 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_COMMON_COMMAND_TARGET), true)]
        public static PROPERTYKEY WPD_COMMAND_MEDIA_CAPTURE_START => new(new(0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8), 2);
        //
        // WPD_COMMAND_MEDIA_CAPTURE_STOP 
        // Ends a media capture operation started by a WPD_COMMAND_MEDIA_CAPTURE_START command. Typically used to end capture of media streams such as audio and video. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_COMMON_COMMAND_TARGET 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_COMMON_COMMAND_TARGET), true)]
        public static PROPERTYKEY WPD_COMMAND_MEDIA_CAPTURE_STOP => new(new(0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8), 3);
        //
        // WPD_COMMAND_MEDIA_CAPTURE_PAUSE 
        // Pauses a media capture operation started by a WPD_COMMAND_MEDIA_CAPTURE_START command. Typically used to pause capture of media streams such as audio and video. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_COMMON_COMMAND_TARGET 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_COMMON_COMMAND_TARGET), true)]
        public static PROPERTYKEY WPD_COMMAND_MEDIA_CAPTURE_PAUSE => new(new(0x59B433BA, 0xFE44, 0x4D8D, 0x80, 0x8C, 0x6B, 0xCB, 0x9B, 0x0F, 0x15, 0xE8), 4);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_DEVICE_HINTS 
        *
        * The commands in this category relate to hints that a device can provide to improve end-user experience.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_DEVICE_HINTS => new(0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84);

        // ======== Commands ========
        //
        // WPD_COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION 
        // This command is used to retrieve the ObjectIDs of folders that contain the specified content type. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_DEVICE_HINTS_CONTENT_TYPE 
        // Results:
        // [ Required ] WPD_PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_DEVICE_HINTS_CONTENT_TYPE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS), true)]
        public static PROPERTYKEY WPD_COMMAND_DEVICE_HINTS_GET_CONTENT_LOCATION => new(new(0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84), 2);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_CLSID ] Indicates the WPD content type that the caller is looking for. For example, to get the top-level folder objects that contain images, this parameter would be WPD_CONTENT_TYPE_IMAGE.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_DEVICE_HINTS_CONTENT_TYPE => new(new(0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84), 1001);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of folder ObjectIDs.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_DEVICE_HINTS_CONTENT_LOCATIONS => new(new(0x0D5FB92B, 0xCB46, 0x4C4F, 0x83, 0x43, 0x0B, 0xC3, 0xD3, 0xF1, 0x7C, 0x84), 1002);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CLASS_EXTENSION_V1 
        *
        * The commands in this category relate to the WPD device class extension.
        ****************************************************************************/
        public static Guid WPD_CLASS_EXTENSION_V1 => new(0x33FB0D11, 0x64A3, 0x4FAC, 0xB4, 0xC7, 0x3D, 0xFE, 0xAA, 0x99, 0xB0, 0x51);

        // ======== Commands ========
        //
        // WPD_COMMAND_CLASS_EXTENSION_WRITE_DEVICE_INFORMATION 
        // This command is used to update the a cache of device-specific information. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES 
        // Results:
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_CLASS_EXTENSION_WRITE_DEVICE_INFORMATION => new(new(0x33FB0D11, 0x64A3, 0x4FAC, 0xB4, 0xC7, 0x3D, 0xFE, 0xAA, 0x99, 0xB0, 0x51), 2);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the values.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_VALUES => new(new(0x33FB0D11, 0x64A3, 0x4FAC, 0xB4, 0xC7, 0x3D, 0xFE, 0xAA, 0x99, 0xB0, 0x51), 1001);

        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceValues which contains the result of each value write operation.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_CLASS_EXTENSION_DEVICE_INFORMATION_WRITE_RESULTS => new(new(0x33FB0D11, 0x64A3, 0x4FAC, 0xB4, 0xC7, 0x3D, 0xFE, 0xAA, 0x99, 0xB0, 0x51), 1002);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CLASS_EXTENSION_V2 
        *
        * The commands in this category relate to the WPD device class extension.
        ****************************************************************************/
        public static Guid WPD_CLASS_EXTENSION_V2 => new(0x7F0779B5, 0xFA2B, 0x4766, 0x9C, 0xB2, 0xF7, 0x3B, 0xA3, 0x0B, 0x67, 0x58);

        // ======== Commands ========
        //
        // WPD_COMMAND_CLASS_EXTENSION_REGISTER_SERVICE_INTERFACES 
        // This command is used to register a service's Plug and Play interfaces. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES 
        // Results:
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_CLASS_EXTENSION_REGISTER_SERVICE_INTERFACES => new(new(0x7F0779B5, 0xFA2B, 0x4766, 0x9C, 0xB2, 0xF7, 0x3B, 0xA3, 0x0B, 0x67, 0x58), 2);
        //
        // WPD_COMMAND_CLASS_EXTENSION_UNREGISTER_SERVICE_INTERFACES 
        // This command is used to unregister a service's Plug and Play interfaces. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID 
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES 
        // Results:
        // [ Required ] WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS), true)]
        public static PROPERTYKEY WPD_COMMAND_CLASS_EXTENSION_UNREGISTER_SERVICE_INTERFACES => new(new(0x7F0779B5, 0xFA2B, 0x4766, 0x9C, 0xB2, 0xF7, 0x3B, 0xA3, 0x0B, 0x67, 0x58), 3);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_LPWSTR ] The Object ID of the service.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_CLASS_EXTENSION_SERVICE_OBJECT_ID => new(new(0x7F0779B5, 0xFA2B, 0x4766, 0x9C, 0xB2, 0xF7, 0x3B, 0xA3, 0x0B, 0x67, 0x58), 1001);

        /// <summary>[ VT_UNKNOWN ] This is an IPortablePropVariantCollection of type VT_CLSID which contains the interface GUIDs that this service implements, including the service type Guid.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CLASS_EXTENSION_SERVICE_INTERFACES => new(new(0x7F0779B5, 0xFA2B, 0x4766, 0x9C, 0xB2, 0xF7, 0x3B, 0xA3, 0x0B, 0x67, 0x58), 1002);

        /// <summary>[ VT_UNKNOWN ] This is an IPortablePropVariantCollection of type VT_ERROR, where each element is the HRESULT indicating the success or failure of the operation.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_CLASS_EXTENSION_SERVICE_REGISTRATION_RESULTS => new(new(0x7F0779B5, 0xFA2B, 0x4766, 0x9C, 0xB2, 0xF7, 0x3B, 0xA3, 0x0B, 0x67, 0x58), 1003);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_NETWORK_CONFIGURATION 
        *
        * The commands in this category are used for Network Association and WiFi Configuration.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_NETWORK_CONFIGURATION => new(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4);

        // ======== Commands ========
        //
        // WPD_COMMAND_GENERATE_KEYPAIR 
        // Initiates the generation of a public/private key pair and returns the public key. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_PUBLIC_KEY 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandResult(nameof(WPD_PROPERTY_PUBLIC_KEY), true)]
        public static PROPERTYKEY WPD_COMMAND_GENERATE_KEYPAIR => new(new(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4), 2);
        //
        // WPD_COMMAND_COMMIT_KEYPAIR 
        // Commits a public/private key pair. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // None
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        public static PROPERTYKEY WPD_COMMAND_COMMIT_KEYPAIR => new(new(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4), 3);
        //
        // WPD_COMMAND_PROCESS_WIRELESS_PROFILE 
        // Initiates the processing of a Wireless Profile file. 
        // Access:
        // (FILE_READ_ACCESS | FILE_WRITE_ACCESS)
        // Parameters:
        // [ Required ] WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE)]
        [WPDCommandParam(nameof(WPD_PROPERTY_OBJECT_PROPERTIES_OBJECT_ID), true)]
        public static PROPERTYKEY WPD_COMMAND_PROCESS_WIRELESS_PROFILE => new(new(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4), 4);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_VECTOR | VT_UI1 ] A public key generated for RSA key exchange.</summary>
        [CorrespondingType(typeof(byte[]))]
        public static PROPERTYKEY WPD_PROPERTY_PUBLIC_KEY => new(new(0x78F9C6FC, 0x79B8, 0x473C, 0x90, 0x60, 0x6B, 0xD2, 0x3D, 0xD0, 0x72, 0xC4), 1001);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_SERVICE_COMMON 
        *
        * The commands in this category relate to a device service.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_SERVICE_COMMON => new(0x322F071D, 0x36EF, 0x477F, 0xB4, 0xB5, 0x6F, 0x52, 0xD7, 0x34, 0xBA, 0xEE);

        // ======== Commands ========
        //
        // WPD_COMMAND_SERVICE_COMMON_GET_SERVICE_OBJECT_ID 
        // This command is used to get the service object identifier. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_OBJECT_ID 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_OBJECT_ID), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_COMMON_GET_SERVICE_OBJECT_ID => new(new(0x322F071D, 0x36EF, 0x477F, 0xB4, 0xB5, 0x6F, 0x52, 0xD7, 0x34, 0xBA, 0xEE), 2);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_LPWSTR ] Contains the service object identifier.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_OBJECT_ID => new(new(0x322F071D, 0x36EF, 0x477F, 0xB4, 0xB5, 0x6F, 0x52, 0xD7, 0x34, 0xBA, 0xEE), 1001);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_SERVICE_CAPABILITIES 
        *
        * The commands in this category relate to capabilities of a device service.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_SERVICE_CAPABILITIES => new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89);

        // ======== Commands ========
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS 
        // This command is used to get the methods that apply to a service. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 2);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS_BY_FORMAT 
        // This command is used to get the methods that apply to a format of a service. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_METHODS_BY_FORMAT => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 3);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_ATTRIBUTES 
        // This command is used to get the attributes of a method. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 4);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_PARAMETER_ATTRIBUTES 
        // This command is used to get the attributes of a parameter used in a method. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD 
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_METHOD_PARAMETER_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 5);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMATS 
        // This command is used to get formats supported by this service. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_FORMATS 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_FORMATS), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMATS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 6);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_ATTRIBUTES 
        // This command is used to get attributes of a format, such as the format name. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 7);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES 
        // This command is used to get supported properties of a format. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_FORMAT_PROPERTIES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 8);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_PROPERTY_ATTRIBUTES 
        // This command is used to get the property attributes that are same for all objects of a given format on the service. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_PROPERTY_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 9);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_EVENTS 
        // This command is used to get the supported events of the service. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_EVENTS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 10);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_ATTRIBUTES 
        // This command is used to get the attributes of an event. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 11);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_PARAMETER_ATTRIBUTES 
        // This command is used to get the attributes of a parameter used in an event. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT 
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_EVENT_PARAMETER_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 12);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_INHERITED_SERVICES 
        // This command is used to get the inherited services. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_INHERITED_SERVICES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 13);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_RENDERING_PROFILES 
        // This command is used to get the resource rendering profiles for a format. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_FORMAT_RENDERING_PROFILES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 14);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_COMMANDS 
        // Return all commands supported by this driver for a service. This includes custom commands, if any. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // None
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS 
        [WPDCommand]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_SUPPORTED_COMMANDS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 15);
        //
        // WPD_COMMAND_SERVICE_CAPABILITIES_GET_COMMAND_OPTIONS 
        // Returns the supported options for the specified command. 
        // Access:
        // FILE_READ_ACCESS
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS 
        [WPDCommand]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_CAPABILITIES_GET_COMMAND_OPTIONS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 16);

        // ======== Command Parameters ======== 


        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing methods that apply to a service.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_METHODS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1001);

        /// <summary>[ VT_CLSID ] Indicates the format the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1002);

        /// <summary>[ VT_CLSID ] Indicates the method the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1003);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the method attributes.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_METHOD_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1004);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the parameter the caller is interested in.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1005);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the parameter attributes.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_PARAMETER_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1006);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing the formats.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_FORMATS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1007);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the format attributes, such as the format name and MIME Type.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_FORMAT_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1008);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceKeyCollection containing the supported property keys.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_KEYS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1009);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the property attributes.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_PROPERTY_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1010);

        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection (of type VT_CLSID) containing all events supported by the service.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_EVENTS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1011);

        /// <summary>[ VT_CLSID ] Indicates the event the caller is interested in.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1012);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the event attributes.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_EVENT_ATTRIBUTES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1013);

        /// <summary>[ VT_UI4 ] Indicates the inheritance type the caller is interested in.</summary>
        [CorrespondingType(typeof(WPD_SERVICE_INHERITANCE_TYPES))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITANCE_TYPE => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1014);

        /// <summary>[ VT_UNKNOWN ] Contains the list of inherited services.</summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_INHERITED_SERVICES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1015);

        /// <summary>[ VT_UNKNOWN ] Contains the list of format rendering profiles.</summary>
        [CorrespondingType(typeof(IPortableDeviceValuesCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_RENDERING_PROFILES => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1016);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceKeyCollection containing all commands a driver supports for a service.</summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_SUPPORTED_COMMANDS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1017);

        /// <summary>[ VT_UNKNOWN ] Indicates the command whose options the caller is interested in.</summary>
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1018);

        /// <summary>[ VT_UNKNOWN ] Contains an IPortableDeviceValues with the relevant command options.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_CAPABILITIES_COMMAND_OPTIONS => new(new(0x24457E74, 0x2E9F, 0x44F9, 0x8C, 0x57, 0x1D, 0x1B, 0xCB, 0x17, 0x0B, 0x89), 1019);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CATEGORY_SERVICE_METHODS 
        *
        * The commands in this category relate to methods of a device service.
        ****************************************************************************/
        public static Guid WPD_CATEGORY_SERVICE_METHODS => new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC);

        // ======== Commands ========
        //
        // WPD_COMMAND_SERVICE_METHODS_START_INVOKE 
        // Invokes a service method. 
        // Access:
        // Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_METHOD 
        // [ Required ] WPD_PROPERTY_SERVICE_METHOD_PARAMETER_VALUES 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_FROM_ATTRIBUTE_WITH_METHOD_ACCESS, nameof(WPD_METHOD_ATTRIBUTE_ACCESS))]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_METHOD), true)]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_METHOD_PARAMETER_VALUES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_METHOD_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_METHODS_START_INVOKE => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 2);
        //
        // WPD_COMMAND_SERVICE_METHODS_CANCEL_INVOKE 
        // This command is sent when a client wants to cancel a method that is currently still in progress. 
        // Access:
        // Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
        // Results:
        // None
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_FROM_ATTRIBUTE_WITH_METHOD_ACCESS, nameof(WPD_METHOD_ATTRIBUTE_ACCESS))]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_METHOD_CONTEXT), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_METHODS_CANCEL_INVOKE => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 3);
        //
        // WPD_COMMAND_SERVICE_METHODS_END_INVOKE 
        // This command is sent in response to a WPD_EVENT_SERVICE_METHOD_COMPLETE event from the driver to retrieve the method results. 
        // Access:
        // Dependent on the value of WPD_METHOD_ATTRIBUTE_ACCESS.
        // Parameters:
        // [ Required ] WPD_PROPERTY_SERVICE_METHOD_CONTEXT 
        // Results:
        // [ Required ] WPD_PROPERTY_SERVICE_METHOD_RESULT_VALUES 
        // [ Required ] WPD_PROPERTY_SERVICE_METHOD_HRESULT 
        [WPDCommand(WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_FROM_ATTRIBUTE_WITH_METHOD_ACCESS, nameof(WPD_METHOD_ATTRIBUTE_ACCESS))]
        [WPDCommandParam(nameof(WPD_PROPERTY_SERVICE_METHOD_CONTEXT), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_METHOD_RESULT_VALUES), true)]
        [WPDCommandResult(nameof(WPD_PROPERTY_SERVICE_METHOD_HRESULT), true)]
        public static PROPERTYKEY WPD_COMMAND_SERVICE_METHODS_END_INVOKE => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 4);

        // ======== Command Parameters ======== 

        /// <summary>[ VT_CLSID ] Indicates the method to invoke.</summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_METHOD => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 1001);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the method parameters.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_METHOD_PARAMETER_VALUES => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 1002);

        /// <summary>[ VT_UNKNOWN ] IPortableDeviceValues containing the method results.</summary>
        [CorrespondingType(typeof(IPortableDeviceValues))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_METHOD_RESULT_VALUES => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 1003);

        /// <summary>[ VT_LPWSTR ] The unique context identifying this method operation.</summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_METHOD_CONTEXT => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 1004);

        /// <summary>[ VT_ERROR ] Contains the status HRESULT of this method invocation.</summary>
        [CorrespondingType(typeof(HRESULT))]
        public static PROPERTYKEY WPD_PROPERTY_SERVICE_METHOD_HRESULT => new(new(0x2D521CA8, 0xC1B0, 0x4268, 0xA3, 0x42, 0xCF, 0x19, 0x32, 0x15, 0x69, 0xBC), 1005);

        /****************************************************************************
        * This section defines all Resource keys. Resources are place-holders for
        * binary data.
        *
        ****************************************************************************/
        /// <summary>Represents the entire object's data. There can be only one default resource on an object. </summary>
        public static PROPERTYKEY WPD_RESOURCE_DEFAULT => new(new(0xE81E79BE, 0x34F0, 0x41BF, 0xB5, 0x3F, 0xF1, 0xA0, 0x6A, 0xE8, 0x78, 0x42), 0);
        /// <summary>Represents the contact's photo data. </summary>
        public static PROPERTYKEY WPD_RESOURCE_CONTACT_PHOTO => new(new(0x2C4D6803, 0x80EA, 0x4580, 0xAF, 0x9A, 0x5B, 0xE1, 0xA2, 0x3E, 0xDD, 0xCB), 0);
        /// <summary>Represents the thumbnail data for an object. </summary>
        public static PROPERTYKEY WPD_RESOURCE_THUMBNAIL => new(new(0xC7C407BA, 0x98FA, 0x46B5, 0x99, 0x60, 0x23, 0xFE, 0xC1, 0x24, 0xCF, 0xDE), 0);
        /// <summary>Represents the icon data for an object. </summary>
        public static PROPERTYKEY WPD_RESOURCE_ICON => new(new(0xF195FED8, 0xAA28, 0x4EE3, 0xB1, 0x53, 0xE1, 0x82, 0xDD, 0x5E, 0xDC, 0x39), 0);
        /// <summary>Represents an audio sample data for an object. </summary>
        public static PROPERTYKEY WPD_RESOURCE_AUDIO_CLIP => new(new(0x3BC13982, 0x85B1, 0x48E0, 0x95, 0xA6, 0x8D, 0x3A, 0xD0, 0x6B, 0xE1, 0x17), 0);
        /// <summary>Represents the album artwork this media originated from. </summary>
        public static PROPERTYKEY WPD_RESOURCE_ALBUM_ART => new(new(0xF02AA354, 0x2300, 0x4E2D, 0xA1, 0xB9, 0x3B, 0x67, 0x30, 0xF7, 0xFA, 0x21), 0);
        /// <summary>Represents an arbitrary binary blob associated with this object. </summary>
        public static PROPERTYKEY WPD_RESOURCE_GENERIC => new(new(0xB9B9F515, 0xBA70, 0x4647, 0x94, 0xDC, 0xFA, 0x49, 0x25, 0xE9, 0x5A, 0x07), 0);
        /// <summary>Represents a video sample for an object. </summary>
        public static PROPERTYKEY WPD_RESOURCE_VIDEO_CLIP => new(new(0xB566EE42, 0x6368, 0x4290, 0x86, 0x62, 0x70, 0x18, 0x2F, 0xB7, 0x9F, 0x20), 0);
        /// <summary>Represents the product branding artwork or logo for an object. This resource is typically found on, but not limited to the device object. </summary>
        public static PROPERTYKEY WPD_RESOURCE_BRANDING_ART => new(new(0xB633B1AE, 0x6CAF, 0x4A87, 0x95, 0x89, 0x22, 0xDE, 0xD6, 0xDD, 0x58, 0x99), 0);


        /****************************************************************************
        * This section defines the legacy WPD definitions
        *
        * When WPD_SERVICES_STRICT mode is defined, these definitions are removed
        * from this header file. You may find replacements or equivalents
        * in the Device Services headers (for example, BridgeDeviceService.h).
        ****************************************************************************/

        /****************************************************************************
        * This section defines the legacy WPD Formats
        ****************************************************************************/
        /// <summary>This object has no data stream and is completely specified by properties only.
        /// <para>Device Services Format: FORMAT_Association</para></summary>
        public static Guid WPD_OBJECT_FORMAT_PROPERTIES_ONLY => new(0x30010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>An undefined object format on the device (e.g. objects that can not be classified by the other defined WPD format codes)
        /// <para>Device Services Format: FORMAT_Undefined</para></summary>
        public static Guid WPD_OBJECT_FORMAT_UNSPECIFIED => new(0x30000000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>A device model-specific script
        /// <para>Device Services Format: FORMAT_DeviceScript</para></summary>
        public static Guid WPD_OBJECT_FORMAT_SCRIPT => new(0x30020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>A device model-specific binary executable
        /// <para>Device Services Format: FORMAT_DeviceExecutable</para></summary>
        public static Guid WPD_OBJECT_FORMAT_EXECUTABLE => new(0x30030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>A text file
        /// <para>Device Services Format: FORMAT_TextDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_TEXT => new(0x30040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>A HyperText Markup Language file (text)
        /// <para>Device Services Format: FORMAT_HTMLDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_HTML => new(0x30050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>A Digital Print Order File (text)
        /// <para>Device Services Format: FORMAT_DPOFDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_DPOF => new(0x30060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format
        /// <para>Device Services Format: FORMAT_AIFFFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_AIFF => new(0x30070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format
        /// <para>Device Services Format: FORMAT_WAVFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_WAVE => new(0x30080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format
        /// <para>Device Services Format: FORMAT_MP3File</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MP3 => new(0x30090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Video file format
        /// <para>Device Services Format: FORMAT_AVIFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_AVI => new(0x300A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Video file format
        /// <para>Device Services Format: FORMAT_MPEGFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MPEG => new(0x300B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Video file format (Microsoft Advanced Streaming Format)
        /// <para>Device Services Format: FORMAT_ASFFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_ASF => new(0x300C0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Exchangeable File Format), JEIDA standard
        /// <para>Device Services Format: FORMAT_EXIFImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_EXIF => new(0x38010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Tag Image File Format for Electronic Photography)
        /// <para>Device Services Format: FORMAT_TIFFEPImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_TIFFEP => new(0x38020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Structured Storage Image Format)
        /// <para>Device Services Format: FORMAT_FlashPixImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_FLASHPIX => new(0x38030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Microsoft Windows Bitmap file)
        /// <para>Device Services Format: FORMAT_BMPImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_BMP => new(0x38040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Canon Camera Image File Format)
        /// <para>Device Services Format: FORMAT_CIFFImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_CIFF => new(0x38050000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Graphics Interchange Format)
        /// <para>Device Services Format: FORMAT_GIFImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_GIF => new(0x38070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (JPEG Interchange Format)
        /// <para>Device Services Format: FORMAT_JFIFImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_JFIF => new(0x38080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (PhotoCD Image Pac)
        /// <para>Device Services Format: FORMAT_PCDImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_PCD => new(0x38090000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Quickdraw Image Format)
        /// <para>Device Services Format: FORMAT_PICTImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_PICT => new(0x380A0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Portable Network Graphics)
        /// <para>Device Services Format: FORMAT_PNGImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_PNG => new(0x380B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Tag Image File Format)
        /// <para>Device Services Format: FORMAT_TIFFImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_TIFF => new(0x380D0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Tag Image File Format for Informational Technology) Graphic Arts
        /// <para>Device Services Format: FORMAT_TIFFITImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_TIFFIT => new(0x380E0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (JPEG2000 Baseline File Format)
        /// <para>Device Services Format: FORMAT_JP2Image</para></summary>
        public static Guid WPD_OBJECT_FORMAT_JP2 => new(0x380F0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (JPEG2000 Extended File Format)
        /// <para>Device Services Format: FORMAT_JPXImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_JPX => new(0x38100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (Wireless Application Protocol Bitmap Format)
        /// <para>Device Services Format: FORMAT_WBMPImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_WBMP => new(0xB8030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format (JPEG XR, also known as HD Photo)
        /// <para>Device Services Format: FORMAT_JPEGXRImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_JPEGXR => new(0xB8040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Image file format
        /// <para>Device Services Format: FORMAT_HDPhotoImage</para></summary>
        public static Guid WPD_OBJECT_FORMAT_WINDOWSIMAGEFORMAT => new(0xB8810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format (Windows Media Audio)
        /// <para>Device Services Format: FORMAT_WMAFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_WMA => new(0xB9010000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Video file format (Windows Media Video)
        /// <para>Device Services Format: FORMAT_WMVFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_WMV => new(0xB9810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Playlist file format
        /// <para>Device Services Format: FORMAT_WPLPlaylist</para></summary>
        public static Guid WPD_OBJECT_FORMAT_WPLPLAYLIST => new(0xBA100000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Playlist file format
        /// <para>Device Services Format: FORMAT_M3UPlaylist</para></summary>
        public static Guid WPD_OBJECT_FORMAT_M3UPLAYLIST => new(0xBA110000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Playlist file format
        /// <para>Device Services Format: FORMAT_MPLPlaylist</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MPLPLAYLIST => new(0xBA120000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Playlist file format
        /// <para>Device Services Format: FORMAT_ASXPlaylist</para></summary>
        public static Guid WPD_OBJECT_FORMAT_ASXPLAYLIST => new(0xBA130000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Playlist file format
        /// <para>Device Services Format: FORMAT_PSLPlaylist</para></summary>
        public static Guid WPD_OBJECT_FORMAT_PLSPLAYLIST => new(0xBA140000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Generic format for contact group objects
        /// <para>Device Services Format: FORMAT_AbstractContactGroup</para></summary>
        public static Guid WPD_OBJECT_FORMAT_ABSTRACT_CONTACT_GROUP => new(0xBA060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>MediaCast file format
        /// <para>Device Services Format: FORMAT_AbstractMediacast</para></summary>
        public static Guid WPD_OBJECT_FORMAT_ABSTRACT_MEDIA_CAST => new(0xBA0B0000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>VCALENDAR file format (VCALENDAR Version 1)
        /// <para>Device Services Format: FORMAT_VCalendar1</para></summary>
        public static Guid WPD_OBJECT_FORMAT_VCALENDAR1 => new(0xBE020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>ICALENDAR file format (VCALENDAR Version 2)
        /// <para>Device Services Format: FORMAT_ICalendar</para></summary>
        public static Guid WPD_OBJECT_FORMAT_ICALENDAR => new(0xBE030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Abstract contact file format
        /// <para>Device Services Format: FORMAT_AbstractContact</para></summary>
        public static Guid WPD_OBJECT_FORMAT_ABSTRACT_CONTACT => new(0xBB810000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>VCARD file format (VCARD Version 2)
        /// <para>Device Services Format: FORMAT_VCard2Contact</para></summary>
        public static Guid WPD_OBJECT_FORMAT_VCARD2 => new(0xBB820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>VCARD file format (VCARD Version 3)
        /// <para>Device Services Format: FORMAT_VCard3Contact</para></summary>
        public static Guid WPD_OBJECT_FORMAT_VCARD3 => new(0xBB830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>XML file format.
        /// <para>Device Services Format: FORMAT_XMLDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_XML => new(0xBA820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format
        /// <para>Device Services Format: FORMAT_AACFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_AAC => new(0xB9030000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format
        /// <para>Device Services Format: FORMAT_AudibleFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_AUDIBLE => new(0xB9040000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format
        /// <para>Device Services Format: FORMAT_FLACFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_FLAC => new(0xB9060000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format (Qualcomm Code Excited Linear Prediction)
        /// <para>Device Services Format: FORMAT_QCELPFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_QCELP => new(0xB9070000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format (Adaptive Multi-Rate audio codec)
        /// <para>Device Services Format: FORMAT_AMRFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_AMR => new(0xB9080000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio file format
        /// <para>Device Services Format: FORMAT_OGGFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_OGG => new(0xB9020000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_MPEG4File</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MP4 => new(0xB9820000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_MPEG2File</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MP2 => new(0xB9830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Microsoft Office Word Document file format.
        /// <para>Device Services Format: FORMAT_WordDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_WORD => new(0xBA830000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>MHT Compiled HTML Document file format.
        /// <para>Device Services Format: FORMAT_MHTDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MHT_COMPILED_HTML => new(0xBA840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Microsoft Office Excel Document file format.
        /// <para>Device Services Format: FORMAT_ExcelDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_EXCEL => new(0xBA850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Microsoft Office PowerPoint Document file format.
        /// <para>Device Services Format: FORMAT_PowerPointDocument</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MICROSOFT_POWERPOINT => new(0xBA860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_3GPPFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_3GP => new(0xB9840000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_3GPP2File</para></summary>
        public static Guid WPD_OBJECT_FORMAT_3G2 => new(0xB9850000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_AVCHDFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_AVCHD => new(0xB9860000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_ATSCTSFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_ATSCTS => new(0xB9870000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_DVBTSFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_DVBTS => new(0xB9880000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xC5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);
        /// <summary>Audio or Video file format
        /// <para>Device Services Format: FORMAT_MKVFile</para></summary>
        public static Guid WPD_OBJECT_FORMAT_MKV => new(0xB9900000, 0xAE6C, 0x4804, 0x98, 0xBA, 0xc5, 0x7B, 0x46, 0x96, 0x5F, 0xE7);

        /****************************************************************************
        * This section defines the legacy WPD Properties
        ****************************************************************************/
        /// <summary>[ VT_LPWSTR ] Uniquely identifies object on the Portable Device.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_ObjectID</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_ID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 2);
        /// <summary>[ VT_LPWSTR ] Object identifier indicating the parent object.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_ParentID</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_PARENT_ID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 3);
        /// <summary>[ VT_LPWSTR ] The display name for this object.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_Name</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_NAME => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 4);
        /// <summary>[ VT_LPWSTR ] Uniquely identifies the object on the Portable Device, similar to WPD_OBJECT_ID, but this ID will not change between sessions.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_PersistentUID</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_PERSISTENT_UNIQUE_ID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 5);
        /// <summary>[ VT_CLSID ] Indicates the format of the object's data.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_ObjectFormat</para></summary>
        [CorrespondingType(typeof(Guid))]
        public static PROPERTYKEY WPD_OBJECT_FORMAT => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 6);
        /// <summary>[ VT_BOOL ] Indicates whether the object should be hidden.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_Hidden</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OBJECT_ISHIDDEN => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 9);
        /// <summary>[ VT_BOOL ] Indicates whether the object represents system data.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_SystemObject</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OBJECT_ISSYSTEM => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 10);
        /// <summary>[ VT_UI8 ] The size of the object data.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_ObjectSize</para></summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_OBJECT_SIZE => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 11);
        /// <summary>[ VT_LPWSTR ] Contains the name of the file this object represents.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_ObjectFileName</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_ORIGINAL_FILE_NAME => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 12);
        /// <summary>[ VT_BOOL ] This property determines whether or not this object is intended to be understood by the device, or whether it has been placed on the device just for storage.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_NonConsumable</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OBJECT_NON_CONSUMABLE => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 13);
        /// <summary>[ VT_LPWSTR ] String containing a list of keywords associated with this object.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_Keywords</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_KEYWORDS => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 15);
        /// <summary>[ VT_LPWSTR ] Opaque string set by client to retain state between sessions without retaining a catalogue of connected device content.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_SyncID</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_SYNC_ID => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 16);
        /// <summary>[ VT_BOOL ] Indicates whether the media data is DRM protected.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_DRMStatus</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OBJECT_IS_DRM_PROTECTED => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 17);
        /// <summary>[ VT_DATE ] Indicates the date and time the object was created on the device.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_DateCreated</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_OBJECT_DATE_CREATED => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 18);
        /// <summary>[ VT_DATE ] Indicates the date and time the object was modified on the device.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_DateModified</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_OBJECT_DATE_MODIFIED => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 19);
        /// <summary>[ VT_DATE ] Indicates the date and time the object was authored (e.g. for music, this would be the date the music was recorded).
        /// <para>Recommended Device Services Property: PKEY_GenericObj_DateAuthored</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_OBJECT_DATE_AUTHORED => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 20);
        /// <summary>[ VT_UNKNOWN ] IPortableDevicePropVariantCollection of type VT_LPWSTR indicating a list of ObjectIDs.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_ReferenceParentID</para></summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_OBJECT_BACK_REFERENCES => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 21);
        /// <summary>[ VT_BOOL ] Indicates whether the object can be deleted, or not.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_ProtectionStatus</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_OBJECT_CAN_DELETE => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 26);
        /// <summary>[ VT_LPWSTR ] Identifies the language of this object. If multiple languages are contained in this object, it should identify the primary language (if any).
        /// <para>Recommended Device Services Property: PKEY_GenericObj_LanguageLocale</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_OBJECT_LANGUAGE_LOCALE => new(new(0xEF6B490D, 0x5CD8, 0x437A, 0xAF, 0xFC, 0xDA, 0x8B, 0x60, 0xEE, 0x4A, 0x3C), 27);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_FOLDER_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all folder objects.
        ****************************************************************************/
        public static Guid WPD_FOLDER_OBJECT_PROPERTIES_V1 => new(0x7E9A7ABF, 0xE568, 0x4B34, 0xAA, 0x2F, 0x13, 0xBB, 0x12, 0xAB, 0x17, 0x7D);
        /// <summary>[ VT_UNKNOWN ] Indicates the subset of content types that can be created in this folder directly (i.e. children may have different restrictions).
        /// <para>Recommended Device Services Property: None</para></summary>
        public static PROPERTYKEY WPD_FOLDER_CONTENT_TYPES_ALLOWED => new(new(0x7E9A7ABF, 0xE568, 0x4B34, 0xAA, 0x2F, 0x13, 0xBB, 0x12, 0xAB, 0x17, 0x7D), 2);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_IMAGE_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all image objects.
        ****************************************************************************/
        public static Guid WPD_IMAGE_OBJECT_PROPERTIES_V1 => new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB);
        /// <summary>[ VT_UI4 ] Indicates the bitdepth of an image
        /// <para>Recommended Device Services Property: PKEY_ImageObj_ImageBitDepth</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_IMAGE_BITDEPTH => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 3);
        /// <summary>[ VT_UI4 ] Signals whether the file has been cropped.
        /// <para>Recommended Device Services Property: PKEY_ImageObj_IsCropped</para></summary>
        [CorrespondingType(typeof(WPD_CROPPED_STATUS_VALUES))]
        public static PROPERTYKEY WPD_IMAGE_CROPPED_STATUS => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 4);
        /// <summary>[ VT_UI4 ] Signals whether the file has been color corrected.
        /// <para>Recommended Device Services Property: PKEY_ImageObj_IsColorCorrected</para></summary>
        [CorrespondingType(typeof(WPD_COLOR_CORRECTED_STATUS_VALUES))]
        public static PROPERTYKEY WPD_IMAGE_COLOR_CORRECTED_STATUS => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 5);
        /// <summary>[ VT_UI4 ] Identifies the aperture setting of the lens when this image was captured.
        /// <para>Recommended Device Services Property: PKEY_ImageObj_Aperature</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_IMAGE_FNUMBER => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 6);
        /// <summary>[ VT_UI4 ] Identifies the shutter speed of the device when this image was captured.
        /// <para>Recommended Device Services Property: PKEY_ImageObj_Exposure</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_IMAGE_EXPOSURE_TIME => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 7);
        /// <summary>[ VT_UI4 ] Identifies the emulation of film speed settings when this image was captured.
        /// <para>Recommended Device Services Property: PKEY_ImageObj_ISOSpeed</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_IMAGE_EXPOSURE_INDEX => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 8);
        /// <summary>[ VT_R8 ] Indicates the horizontal resolution (DPI) of an image
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(double))]
        public static PROPERTYKEY WPD_IMAGE_HORIZONTAL_RESOLUTION => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 9);
        /// <summary>[ VT_R8 ] Indicates the vertical resolution (DPI) of an image
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(double))]
        public static PROPERTYKEY WPD_IMAGE_VERTICAL_RESOLUTION => new(new(0x63D64908, 0x9FA1, 0x479F, 0x85, 0xBA, 0x99, 0x52, 0x21, 0x64, 0x47, 0xDB), 10);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_DOCUMENT_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all document objects.
        ****************************************************************************/
        public static Guid WPD_DOCUMENT_OBJECT_PROPERTIES_V1 => new(0x0B110203, 0xEB95, 0x4F02, 0x93, 0xE0, 0x97, 0xC6, 0x31, 0x49, 0x3A, 0xD5);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_MEDIA_PROPERTIES_V1 
        *
        * This category is for properties common to media objects (e.g. audio and video).
        ****************************************************************************/
        public static Guid WPD_MEDIA_PROPERTIES_V1 => new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8);
        /// <summary>[ VT_UI4 ] The total number of bits that one second will consume.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_TotalBitRate</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_TOTAL_BITRATE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 2);
        /// <summary>[ VT_UI4 ] Further qualifies the bitrate of audio or video data.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_BitRateType</para></summary>
        [CorrespondingType(typeof(WPD_BITRATE_TYPES))]
        public static PROPERTYKEY WPD_MEDIA_BITRATE_TYPE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 3);
        /// <summary>[ VT_LPWSTR ] Indicates the copyright information.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_Copyright</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_COPYRIGHT => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 4);
        /// <summary>[ VT_LPWSTR ] Provides additional information to identify a piece of content relative to an online subscription service.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_SubscriptionContentID</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_SUBSCRIPTION_CONTENT_ID => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 5);
        /// <summary>[ VT_UI4 ] Indicates the total number of times this media has been played or viewed on the device.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_UseCount</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_USE_COUNT => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 6);
        /// <summary>[ VT_UI4 ] Indicates the total number of times this media was setup to be played or viewed but was manually skipped by the user.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_SkipCount</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_SKIP_COUNT => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 7);
        /// <summary>[ VT_DATE ] Indicates the date and time the media was last accessed on the device.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_DateAccessed</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_MEDIA_LAST_ACCESSED_TIME => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 8);
        /// <summary>[ VT_LPWSTR ] Indicates the parental rating of the media file.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_ParentalRating</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_PARENTAL_RATING => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 9);
        /// <summary>[ VT_UI4 ] Further qualifies a piece of media in a contextual way.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_MediaType</para></summary>
        [CorrespondingType(typeof(WPD_META_GENRES))]
        public static PROPERTYKEY WPD_MEDIA_META_GENRE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 10);
        /// <summary>[ VT_LPWSTR ] Identifies the composer when the composer is not the artist who performed it.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Composer</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_COMPOSER => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 11);
        /// <summary>[ VT_UI4 ] Contains an assigned rating for media not set by the user, but is generated based upon usage statistics.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_EffectiveRating</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_EFFECTIVE_RATING => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 12);
        /// <summary>[ VT_LPWSTR ] Further qualifies the title when the title is ambiguous or general.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Subtitle</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_SUB_TITLE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 13);
        /// <summary>[ VT_DATE ] Indicates when the media was released.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_DateOriginalRelease</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_MEDIA_RELEASE_DATE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 14);
        /// <summary>[ VT_UI4 ] Indicates the number of times media selection was sampled per second during encoding.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_SampleRate</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_SAMPLE_RATE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 15);
        /// <summary>[ VT_UI4 ] Indicates the star rating for this media.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_STAR_RATING => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 16);
        /// <summary>[ VT_UI4 ] Indicates the rating for this media.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_UserRating</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_USER_EFFECTIVE_RATING => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 17);
        /// <summary>[ VT_LPWSTR ] Indicates the title of this media.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_TITLE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 18);
        /// <summary>[ VT_UI8 ] Indicates the duration of this media in milliseconds.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Duration</para></summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_MEDIA_DURATION => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 19);
        /// <summary>[ VT_BOOL ] TBD
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_MEDIA_BUY_NOW => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 20);
        /// <summary>[ VT_LPWSTR ] Media codecs may be encoded in accordance with a profile, which defines a particular encoding algorithm or optimization process.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_EncodingProfile</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_ENCODING_PROFILE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 21);
        /// <summary>[ VT_UI4 ] Indicates the width of an object in pixels
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Width</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_WIDTH => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 22);
        /// <summary>[ VT_UI4 ] Indicates the height of an object in pixels
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Height</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MEDIA_HEIGHT => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 23);
        /// <summary>[ VT_LPWSTR ] Indicates the artist for this media.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Artist</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_ARTIST => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 24);
        /// <summary>[ VT_LPWSTR ] Indicates the artist of the entire album rather than for a particular track.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_AlbumArtist</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_ALBUM_ARTIST => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 25);
        /// <summary>[ VT_LPWSTR ] Indicates the e-mail address of the owner for this media.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Owner</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_OWNER => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 26);
        /// <summary>[ VT_LPWSTR ] Indicates the e-mail address of the managing editor for this media.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Editor</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_MANAGING_EDITOR => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 27);
        /// <summary>[ VT_LPWSTR ] Indicates the e-mail address of the Webmaster for this media.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_WebMaster</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_WEBMASTER => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 28);
        /// <summary>[ VT_LPWSTR ] Identifies the source URL for this object.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_URLSource</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_SOURCE_URL => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 29);
        /// <summary>[ VT_LPWSTR ] Identifies the URL that an object is linked to if a user clicks on it.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_URLLink</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_DESTINATION_URL => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 30);
        /// <summary>[ VT_LPWSTR ] Contains a description of the media content for this object.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_Description</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_DESCRIPTION => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 31);
        /// <summary>[ VT_LPWSTR ] A text field indicating the genre this media belongs to.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Genre</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_GENRE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 32);
        /// <summary>[ VT_UI8 ] Indicates a bookmark (in milliseconds) of the last position played or viewed on media that have duration.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_BookmarkTime</para></summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_MEDIA_TIME_BOOKMARK => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 33);
        /// <summary>[ VT_LPWSTR ] Indicates a WPD_OBJECT_ID of the last object viewed or played for those objects that refer to a list of objects (such as playlists or media casts).
        /// <para>Recommended Device Services Property: PKEY_MediaObj_BookmarkObject</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_OBJECT_BOOKMARK => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 34);
        /// <summary>[ VT_DATE ] Indicates the last time a series in a media cast was changed or edited.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_DateRevised</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_MEDIA_LAST_BUILD_DATE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 35);
        /// <summary>[ VT_UI8 ] Indicates a bookmark (as a zero-based byte offset) of the last position played or viewed on this media object.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_BookmarkByte</para></summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_MEDIA_BYTE_BOOKMARK => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 36);
        /// <summary>[ VT_UI8 ] It is the number of minutes that indicates how long a channel can be cached before refreshing from the source. Applies to WPD_CONTENT_TYPE_MEDIA_CAST objects.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_TimeToLive</para></summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_MEDIA_TIME_TO_LIVE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 37);
        /// <summary>[ VT_LPWSTR ] A text field indicating the Guid of this media.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_MediaUID</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_GUID => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 38);
        /// <summary>[ VT_LPWSTR ] Contains a sub description of the media content for this object.
        /// <para>Recommended Device Services Property: PKEY_GenericObj_SubDescription</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_SUB_DESCRIPTION => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 39);
        /// <summary>[ VT_LPWSTR ] Media codecs may be encoded in accordance with a profile, which defines a particular encoding algorithm or optimization process.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_AudioEncodingProfile</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MEDIA_AUDIO_ENCODING_PROFILE => new(new(0x2ED8BA05, 0x0AD3, 0x42DC, 0xB0, 0xD0, 0xBC, 0x95, 0xAC, 0x39, 0x6A, 0xC8), 49);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_CONTACT_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all contact objects.
        ****************************************************************************/
        public static Guid WPD_CONTACT_OBJECT_PROPERTIES_V1 => new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B);
        /// <summary>[ VT_LPWSTR ] Indicates the display name of the contact (e.g "John Doe")
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_DISPLAY_NAME => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 2);
        /// <summary>[ VT_LPWSTR ] Indicates the first name of the contact (e.g. "John")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_GivenName</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_FIRST_NAME => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 3);
        /// <summary>[ VT_LPWSTR ] Indicates the middle name of the contact
        /// <para>Recommended Device Services Property: PKEY_ContactObj_MiddleNames</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_MIDDLE_NAMES => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 4);
        /// <summary>[ VT_LPWSTR ] Indicates the last name of the contact (e.g. "Doe")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_FamilyName</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_LAST_NAME => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 5);
        /// <summary>[ VT_LPWSTR ] Indicates the prefix of the name of the contact (e.g. "Mr.")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Title</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PREFIX => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 6);
        /// <summary>[ VT_LPWSTR ] Indicates the suffix of the name of the contact (e.g. "Jr.")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Suffix</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_SUFFIX => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 7);
        /// <summary>[ VT_LPWSTR ] The phonetic guide for pronouncing the contact's first name.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PhoneticGivenName</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PHONETIC_FIRST_NAME => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 8);
        /// <summary>[ VT_LPWSTR ] The phonetic guide for pronouncing the contact's last name.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PhoneticFamilyName</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PHONETIC_LAST_NAME => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 9);
        /// <summary>[ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive, PhoneLand, WA 12345")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalAddressFull</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_FULL_POSTAL_ADDRESS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 10);
        /// <summary>[ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalAddressStreet</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_LINE1 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 11);
        /// <summary>[ VT_LPWSTR ] Indicates the second line of a postal address of the contact
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalAddressLine2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_LINE2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 12);
        /// <summary>[ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalAddressCity</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_CITY => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 13);
        /// <summary>[ VT_LPWSTR ] Indicates the region of a postal address of the contact
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalAddressRegion</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_REGION => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 14);
        /// <summary>[ VT_LPWSTR ] Indicates the postal code of the address.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalAddressPostalCode</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_POSTAL_CODE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 15);
        /// <summary>[ VT_LPWSTR ] 
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalAddressCountry</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_POSTAL_ADDRESS_COUNTRY => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 16);
        /// <summary>[ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive, PhoneLand, WA 12345")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessAddressFull</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_FULL_POSTAL_ADDRESS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 17);
        /// <summary>[ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessAddressStreet</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_LINE1 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 18);
        /// <summary>[ VT_LPWSTR ] Indicates the second line of a postal address of the contact
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessAddressLine2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_LINE2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 19);
        /// <summary>[ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand")
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessAddressCity</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_CITY => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 20);
        /// <summary>[ VT_LPWSTR ] 
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessAddressRegion</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_REGION => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 21);
        /// <summary>[ VT_LPWSTR ] Indicates the postal code of the address.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessAddressPostalCode</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_POSTAL_CODE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 22);
        /// <summary>[ VT_LPWSTR ] 
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessAddressCountry</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_POSTAL_ADDRESS_COUNTRY => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 23);
        /// <summary>[ VT_LPWSTR ] Indicates the full postal address of the contact (e.g. "555 Dial Drive, PhoneLand, WA 12345").
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherAddressFull</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_FULL_POSTAL_ADDRESS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 24);
        /// <summary>[ VT_LPWSTR ] Indicates the first line of a postal address of the contact (e.g. "555 Dial Drive").
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherAddressStreet</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_POSTAL_ADDRESS_LINE1 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 25);
        /// <summary>[ VT_LPWSTR ] Indicates the second line of a postal address of the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherAddressLine2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_POSTAL_ADDRESS_LINE2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 26);
        /// <summary>[ VT_LPWSTR ] Indicates the city of a postal address of the contact (e.g. "PhoneLand").
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherAddressCity</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_POSTAL_ADDRESS_CITY => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 27);
        /// <summary>[ VT_LPWSTR ] Indicates the region of a postal address of the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherAddressRegion</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_POSTAL_ADDRESS_REGION => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 28);
        /// <summary>[ VT_LPWSTR ] Indicates the postal code of the address.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherAddressPostalCode</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_CODE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 29);
        /// <summary>[ VT_LPWSTR ] Indicates the country/region of the postal address.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherAddressCountry</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_POSTAL_ADDRESS_POSTAL_COUNTRY => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 30);
        /// <summary>[ VT_LPWSTR ] Indicates the primary email address for the contact e.g. "someone@example.com"
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Email</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PRIMARY_EMAIL_ADDRESS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 31);
        /// <summary>[ VT_LPWSTR ] Indicates the personal email address for the contact e.g. "someone@example.com"
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalEmail</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_EMAIL => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 32);
        /// <summary>[ VT_LPWSTR ] Indicates an alternate personal email address for the contact e.g. "someone@example.com"
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalEmail2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_EMAIL2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 33);
        /// <summary>[ VT_LPWSTR ] Indicates the business email address for the contact e.g. "someone@example.com"
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessEmail</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_EMAIL => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 34);
        /// <summary>[ VT_LPWSTR ] Indicates an alternate business email address for the contact e.g. "someone@example.com"
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessEmail2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_EMAIL2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 35);
        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR, where each element is an alternate email addresses for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherEmail</para></summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_EMAILS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 36);
        /// <summary>[ VT_LPWSTR ] Indicates the primary phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Phone</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PRIMARY_PHONE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 37);
        /// <summary>[ VT_LPWSTR ] Indicates the personal phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalPhone</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_PHONE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 38);
        /// <summary>[ VT_LPWSTR ] Indicates an alternate personal phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalPhone2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_PHONE2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 39);
        /// <summary>[ VT_LPWSTR ] Indicates the business phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessPhone</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_PHONE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 40);
        /// <summary>[ VT_LPWSTR ] Indicates an alternate business phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessPhone2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_PHONE2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 41);
        /// <summary>[ VT_LPWSTR ] Indicates the mobile phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_MobilePhone</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_MOBILE_PHONE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 42);
        /// <summary>[ VT_LPWSTR ] Indicates an alternate mobile phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_MobilePhone2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_MOBILE_PHONE2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 43);
        /// <summary>[ VT_LPWSTR ] Indicates the personal fax number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalFax</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_FAX => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 44);
        /// <summary>[ VT_LPWSTR ] Indicates the business fax number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessFax</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_FAX => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 45);
        /// <summary>[ VT_LPWSTR ] 
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Pager</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PAGER => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 46);
        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR, where each element is an alternate phone number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_OtherPhone</para></summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_CONTACT_OTHER_PHONES => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 47);
        /// <summary>[ VT_LPWSTR ] Indicates the primary web address for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_WebAddress</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PRIMARY_WEB_ADDRESS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 48);
        /// <summary>[ VT_LPWSTR ] Indicates the personal web address for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PersonalWebAddress</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PERSONAL_WEB_ADDRESS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 49);
        /// <summary>[ VT_LPWSTR ] Indicates the business web address for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_BusinessWebAddress</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BUSINESS_WEB_ADDRESS => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 50);
        /// <summary>[ VT_LPWSTR ] Indicates the instant messenger address for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_IMAddress</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_INSTANT_MESSENGER => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 51);
        /// <summary>[ VT_LPWSTR ] Indicates an alternate instant messenger address for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_IMAddress2</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_INSTANT_MESSENGER2 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 52);
        /// <summary>[ VT_LPWSTR ] Indicates an alternate instant messenger address for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_IMAddress3</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_INSTANT_MESSENGER3 => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 53);
        /// <summary>[ VT_LPWSTR ] Indicates the company name for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Organization</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_COMPANY_NAME => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 54);
        /// <summary>[ VT_LPWSTR ] The phonetic guide for pronouncing the contact's company name.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_PhoneticOrganization</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PHONETIC_COMPANY_NAME => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 55);
        /// <summary>[ VT_LPWSTR ] Indicates the role for the contact e.g. "Software Engineer".
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Role</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_ROLE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 56);
        /// <summary>[ VT_DATE ] Indicates the birthdate for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Birthdate</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_BIRTHDATE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 57);
        /// <summary>[ VT_LPWSTR ] Indicates the primary fax number for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Fax</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_PRIMARY_FAX => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 58);
        /// <summary>[ VT_LPWSTR ] Indicates the full name of the spouse/domestic partner for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Spouse</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_SPOUSE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 59);
        /// <summary>[ VT_UNKNOWN ] An IPortableDevicePropVariantCollection of type VT_LPWSTR, where each element is the full name of a child of the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Children</para></summary>
        [CorrespondingType(typeof(IPortableDevicePropVariantCollection))]
        public static PROPERTYKEY WPD_CONTACT_CHILDREN => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 60);
        /// <summary>[ VT_LPWSTR ] Indicates the full name of the assistant for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Assistant</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_ASSISTANT => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 61);
        /// <summary>[ VT_DATE ] Indicates the anniversary date for the contact.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_AnniversaryDate</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_CONTACT_ANNIVERSARY_DATE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 62);
        /// <summary>[ VT_LPWSTR ] Indicates an object id of a ringtone file on the device.
        /// <para>Recommended Device Services Property: PKEY_ContactObj_Ringtone</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_CONTACT_RINGTONE => new(new(0xFBD4FDAB, 0x987D, 0x4777, 0xB3, 0xF9, 0x72, 0x61, 0x85, 0xA9, 0x31, 0x2B), 63);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_MUSIC_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all music objects.
        ****************************************************************************/
        public static Guid WPD_MUSIC_OBJECT_PROPERTIES_V1 => new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6);
        /// <summary>[ VT_LPWSTR ] Indicates the album of the music file.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_AlbumName</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MUSIC_ALBUM => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 3);
        /// <summary>[ VT_UI4 ] Indicates the track number for the music file.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Track</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_MUSIC_TRACK => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 4);
        /// <summary>[ VT_LPWSTR ] Indicates the lyrics for the music file.
        /// <para>Recommended Device Services Property: PKEY_AudioObj_Lyrics</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MUSIC_LYRICS => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 6);
        /// <summary>[ VT_LPWSTR ] Indicates the mood for the music file.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Mood</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_MUSIC_MOOD => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 8);
        /// <summary>[ VT_UI4 ] Indicates the bit rate for the audio data, specified in bits per second.
        /// <para>Recommended Device Services Property: PKEY_AudioObj_AudioBitRate</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_AUDIO_BITRATE => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 9);
        /// <summary>[ VT_R4 ] Indicates the number of channels in this audio file e.g. 1, 2, 5.1 etc.
        /// <para>Recommended Device Services Property: PKEY_AudioObj_Channels</para></summary>
        [CorrespondingType(typeof(float))]
        public static PROPERTYKEY WPD_AUDIO_CHANNEL_COUNT => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 10);
        /// <summary>[ VT_UI4 ] Indicates the registered WAVE format code.
        /// <para>Recommended Device Services Property: PKEY_AudioObj_AudioFormatCode</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_AUDIO_FORMAT_CODE => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 11);
        /// <summary>[ VT_UI4 ] This property identifies the bit-depth of the audio.
        /// <para>Recommended Device Services Property: PKEY_AudioObj_AudioBitDepth</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_AUDIO_BIT_DEPTH => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 12);
        /// <summary>[ VT_UI4 ] This property identifies the audio block alignment
        /// <para>Recommended Device Services Property: PKEY_AudioObj_AudioBlockAlignment</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_AUDIO_BLOCK_ALIGNMENT => new(new(0xB324F56A, 0xDC5D, 0x46E5, 0xB6, 0xDF, 0xD2, 0xEA, 0x41, 0x48, 0x88, 0xC6), 13);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_VIDEO_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all video objects.
        ****************************************************************************/
        public static Guid WPD_VIDEO_OBJECT_PROPERTIES_V1 => new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A);
        /// <summary>[ VT_LPWSTR ] Indicates the author of the video file.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Producer</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_VIDEO_AUTHOR => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 2);
        /// <summary>[ VT_LPWSTR ] Indicates the TV station the video was recorded from.
        /// <para>Recommended Device Services Property: PKEY_VideoObj_Source</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_VIDEO_RECORDEDTV_STATION_NAME => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 4);
        /// <summary>[ VT_UI4 ] Indicates the TV channel number the video was recorded from.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_VIDEO_RECORDEDTV_CHANNEL_NUMBER => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 5);
        /// <summary>[ VT_BOOL ] Indicates whether the recorded TV program was a repeat showing.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_VIDEO_RECORDEDTV_REPEAT => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 7);
        /// <summary>[ VT_UI4 ] Indicates the video buffer size.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_BufferSize</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_VIDEO_BUFFER_SIZE => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 8);
        /// <summary>[ VT_LPWSTR ] Indicates the credit text for the video file.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_Credits</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_VIDEO_CREDITS => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 9);
        /// <summary>[ VT_UI4 ] Indicates the interval between key frames in milliseconds.
        /// <para>Recommended Device Services Property: PKEY_VideoObj_KeyFrameDistance</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_VIDEO_KEY_FRAME_DISTANCE => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 10);
        /// <summary>[ VT_UI4 ] Indicates the quality setting for the video file.
        /// <para>Recommended Device Services Property: PKEY_MediaObj_EncodingQuality</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_VIDEO_QUALITY_SETTING => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 11);
        /// <summary>[ VT_UI4 ] This property identifies the video scan information.
        /// <para>Recommended Device Services Property: PKEY_VideoObj_ScanType</para></summary>
        [CorrespondingType(typeof(WPD_VIDEO_SCAN_TYPES))]
        public static PROPERTYKEY WPD_VIDEO_SCAN_TYPE => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 12);
        /// <summary>[ VT_UI4 ] Indicates the bitrate for the video data.
        /// <para>Recommended Device Services Property: PKEY_VideoObj_VideoBitRate</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_VIDEO_BITRATE => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 13);
        /// <summary>[ VT_UI4 ] The registered FourCC code indicating the codec used for the video file.
        /// <para>Recommended Device Services Property: PKEY_VideoObj_VideoFormatCode</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_VIDEO_FOURCC_CODE => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 14);
        /// <summary>[ VT_UI4 ] Indicates the frame rate for the video data.
        /// <para>Recommended Device Services Property: PKEY_VideoObj_VideoFrameRate</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_VIDEO_FRAMERATE => new(new(0x346F2163, 0xF998, 0x4146, 0x8B, 0x01, 0xD1, 0x9B, 0x4C, 0x00, 0xDE, 0x9A), 15);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_COMMON_INFORMATION_OBJECT_PROPERTIES_V1 
        *
        * This category is properties that pertain to informational objects such as appointments, tasks, memos and even documents.
        ****************************************************************************/
        public static Guid WPD_COMMON_INFORMATION_OBJECT_PROPERTIES_V1 => new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F);
        /// <summary>[ VT_LPWSTR ] Indicates the subject field of this object.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_Subject</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_COMMON_INFORMATION_SUBJECT => new(new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F), 2);
        /// <summary>[ VT_LPWSTR ] This property contains the body text of an object, in plaintext or HTML format.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_Body</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_COMMON_INFORMATION_BODY_TEXT => new(new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F), 3);
        /// <summary>[ VT_UI4 ] Indicates the priority of this object.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_Priority</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_COMMON_INFORMATION_PRIORITY => new(new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F), 4);
        /// <summary>[ VT_DATE ] For appointments, tasks and similar objects, this indicates the date/time that this item is scheduled to start.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_PatternValidStartDate</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_COMMON_INFORMATION_START_DATETIME => new(new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F), 5);
        /// <summary>[ VT_DATE ] For appointments, tasks and similar objects, this indicates the date/time that this item is scheduled to end.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_PatternValidEndDate</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_COMMON_INFORMATION_END_DATETIME => new(new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F), 6);
        /// <summary>[ VT_LPWSTR ] For appointments, tasks and similar objects, this indicates any notes for this object.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_COMMON_INFORMATION_NOTES => new(new(0xB28AE94B, 0x05A4, 0x4E8E, 0xBE, 0x01, 0x72, 0xCC, 0x7E, 0x09, 0x9D, 0x8F), 7);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_MEMO_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all memo objects.
        ****************************************************************************/
        public static Guid WPD_MEMO_OBJECT_PROPERTIES_V1 => new(0x5FFBFC7B, 0x7483, 0x41AD, 0xAF, 0xB9, 0xDA, 0x3F, 0x4E, 0x59, 0x2B, 0x8D);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_EMAIL_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all email objects.
        ****************************************************************************/
        public static Guid WPD_EMAIL_OBJECT_PROPERTIES_V1 => new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5);
        /// <summary>[ VT_LPWSTR ] Indicates the normal recipients for the message.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_To</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EMAIL_TO_LINE => new(new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5), 2);
        /// <summary>[ VT_LPWSTR ] Indicates the copied recipients for the message.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_CC</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EMAIL_CC_LINE => new(new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5), 3);
        /// <summary>[ VT_LPWSTR ] Indicates the recipients for the message who receive a "blind copy".
        /// <para>Recommended Device Services Property: PKEY_MessageObj_BCC</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EMAIL_BCC_LINE => new(new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5), 4);
        /// <summary>[ VT_BOOL ] Indicates whether the user has read this message.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_Read</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_EMAIL_HAS_BEEN_READ => new(new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5), 7);
        /// <summary>[ VT_DATE ] Indicates at what time the message was received.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_ReceivedTime</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_EMAIL_RECEIVED_TIME => new(new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5), 8);
        /// <summary>[ VT_BOOL ] Indicates whether this message has attachments.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(bool))]
        public static PROPERTYKEY WPD_EMAIL_HAS_ATTACHMENTS => new(new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5), 9);
        /// <summary>[ VT_LPWSTR ] Indicates who sent the message.
        /// <para>Recommended Device Services Property: PKEY_MessageObj_Sender</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_EMAIL_SENDER_ADDRESS => new(new(0x41F8F65A, 0x5484, 0x4782, 0xB1, 0x3D, 0x47, 0x40, 0xDD, 0x7C, 0x37, 0xC5), 10);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_APPOINTMENT_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all appointment objects.
        ****************************************************************************/
        public static Guid WPD_APPOINTMENT_OBJECT_PROPERTIES_V1 => new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3);
        /// <summary>[ VT_LPWSTR ] Indicates the location of the appointment e.g. "Building 5, Conf. room 7".
        /// <para>Recommended Device Services Property: PKEY_CalendarObj_Location</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_LOCATION => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 3);
        /// <summary>[ VT_LPWSTR ] Indicates the type of appointment e.g. "Personal", "Business" etc.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_TYPE => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 7);
        /// <summary>[ VT_LPWSTR ] Semi-colon separated list of required attendees.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_REQUIRED_ATTENDEES => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 8);
        /// <summary>[ VT_LPWSTR ] Semi-colon separated list of optional attendees.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_OPTIONAL_ATTENDEES => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 9);
        /// <summary>[ VT_LPWSTR ] Semi-colon separated list of attendees who have accepted the appointment.
        /// <para>Recommended Device Services Property: PKEY_CalendarObj_Accepted</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_ACCEPTED_ATTENDEES => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 10);
        /// <summary>[ VT_LPWSTR ] Semi-colon separated list of resources needed for the appointment.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_RESOURCES => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 11);
        /// <summary>[ VT_LPWSTR ] Semi-colon separated list of attendees who have tentatively accepted the appointment.
        /// <para>Recommended Device Services Property: PKEY_CalendarObj_Tentative</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_TENTATIVE_ATTENDEES => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 12);
        /// <summary>[ VT_LPWSTR ] Semi-colon separated list of attendees who have declined the appointment.
        /// <para>Recommended Device Services Property: PKEY_CalendarObj_Declined</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_APPOINTMENT_DECLINED_ATTENDEES => new(new(0xF99EFD03, 0x431D, 0x40D8, 0xA1, 0xC9, 0x4E, 0x22, 0x0D, 0x9C, 0x88, 0xD3), 13);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_TASK_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all task objects.
        ****************************************************************************/
        public static Guid WPD_TASK_OBJECT_PROPERTIES_V1 => new(0xE354E95E, 0xD8A0, 0x4637, 0xA0, 0x3A, 0x0C, 0xB2, 0x68, 0x38, 0xDB, 0xC7);
        /// <summary>[ VT_LPWSTR ] Indicates the status of the task e.g. "In Progress".
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_TASK_STATUS => new(new(0xE354E95E, 0xD8A0, 0x4637, 0xA0, 0x3A, 0x0C, 0xB2, 0x68, 0x38, 0xDB, 0xC7), 6);
        /// <summary>[ VT_UI4 ] Indicates how much of the task has been completed.
        /// <para>Recommended Device Services Property: PKEY_TaskObj_Complete</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_TASK_PERCENT_COMPLETE => new(new(0xE354E95E, 0xD8A0, 0x4637, 0xA0, 0x3A, 0x0C, 0xB2, 0x68, 0x38, 0xDB, 0xC7), 8);
        /// <summary>[ VT_DATE ] Indicates the date and time set for the reminder. If this value is 0, then it is assumed that this task has no reminder.
        /// <para>Recommended Device Services Property: PKEY_TaskObj_ReminderDateTime</para></summary>
        [CorrespondingType(typeof(DATE))]
        public static PROPERTYKEY WPD_TASK_REMINDER_DATE => new(new(0xE354E95E, 0xD8A0, 0x4637, 0xA0, 0x3A, 0x0C, 0xB2, 0x68, 0x38, 0xDB, 0xC7), 10);
        /// <summary>[ VT_LPWSTR ] Indicates the owner of the task.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_TASK_OWNER => new(new(0xE354E95E, 0xD8A0, 0x4637, 0xA0, 0x3A, 0x0C, 0xB2, 0x68, 0x38, 0xDB, 0xC7), 11);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_SMS_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all objects whose functional category is WPD_FUNCTIONAL_CATEGORY_SMS
        ****************************************************************************/
        public static Guid WPD_SMS_OBJECT_PROPERTIES_V1 => new(0x7E1074CC, 0x50FF, 0x4DD1, 0xA7, 0x42, 0x53, 0xBE, 0x6F, 0x09, 0x3A, 0x0D);
        /// <summary>[ VT_LPWSTR ] Indicates the service provider name.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(string))]
        public static PROPERTYKEY WPD_SMS_PROVIDER => new(new(0x7E1074CC, 0x50FF, 0x4DD1, 0xA7, 0x42, 0x53, 0xBE, 0x6F, 0x09, 0x3A, 0x0D), 2);
        /// <summary>[ VT_UI4 ] Indicates the number of milliseconds until a timeout is returned.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_SMS_TIMEOUT => new(new(0x7E1074CC, 0x50FF, 0x4DD1, 0xA7, 0x42, 0x53, 0xBE, 0x6F, 0x09, 0x3A, 0x0D), 3);
        /// <summary>[ VT_UI4 ] Indicates the maximum number of bytes that can be contained in a message.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(uint))]
        public static PROPERTYKEY WPD_SMS_MAX_PAYLOAD => new(new(0x7E1074CC, 0x50FF, 0x4DD1, 0xA7, 0x42, 0x53, 0xBE, 0x6F, 0x09, 0x3A, 0x0D), 4);
        /// <summary>[ VT_UI4 ] Indicates how the driver will encode the text message sent by the client.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(WPD_SMS_ENCODING_TYPES))]
        public static PROPERTYKEY WPD_SMS_ENCODING => new(new(0x7E1074CC, 0x50FF, 0x4DD1, 0xA7, 0x42, 0x53, 0xBE, 0x6F, 0x09, 0x3A, 0x0D), 5);

        /****************************************************************************
        * This section defines all Commands, Parameters and Options associated with:
        * WPD_SECTION_OBJECT_PROPERTIES_V1 
        *
        * This category is for properties common to all objects whose content type is WPD_CONTENT_TYPE_SECTION
        ****************************************************************************/
        public static Guid WPD_SECTION_OBJECT_PROPERTIES_V1 => new(0x516AFD2B, 0xC64E, 0x44F0, 0x98, 0xDC, 0xBE, 0xE1, 0xC8, 0x8F, 0x7D, 0x66);
        /// <summary>[ VT_UI8 ] Indicates the zero-based offset of the data for the referenced object.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_SECTION_DATA_OFFSET => new(new(0x516AFD2B, 0xC64E, 0x44F0, 0x98, 0xDC, 0xBE, 0xE1, 0xC8, 0x8F, 0x7D, 0x66), 2);
        /// <summary>[ VT_UI8 ] Indicates the length of data for the referenced object.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(ulong))]
        public static PROPERTYKEY WPD_SECTION_DATA_LENGTH => new(new(0x516AFD2B, 0xC64E, 0x44F0, 0x98, 0xDC, 0xBE, 0xE1, 0xC8, 0x8F, 0x7D, 0x66), 3);
        /// <summary>[ VT_UI4 ] Indicates the units for WPD_SECTION_DATA_OFFSET and WPD_SECTION_DATA_LENGTH properties on this object (e.g. offset in bytes, offset in milliseconds etc.).
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(WPD_SECTION_DATA_UNITS_VALUES))]
        public static PROPERTYKEY WPD_SECTION_DATA_UNITS => new(new(0x516AFD2B, 0xC64E, 0x44F0, 0x98, 0xDC, 0xBE, 0xE1, 0xC8, 0x8F, 0x7D, 0x66), 4);
        /// <summary>[ VT_UNKNOWN ] This is an IPortableDeviceKeyCollection containing a single value, which is the key identifying the resource on the referenced object which the WPD_SECTION_DATA_OFFSET and WPD_SECTION_DATA_LENGTH apply to.
        /// <para>Recommended Device Services Property: None</para></summary>
        [CorrespondingType(typeof(IPortableDeviceKeyCollection))]
        public static PROPERTYKEY WPD_SECTION_DATA_REFERENCED_OBJECT_RESOURCE => new(new(0x516AFD2B, 0xC64E, 0x44F0, 0x98, 0xDC, 0xBE, 0xE1, 0xC8, 0x8F, 0x7D, 0x66), 5);

        /// <summary>Determines whether a PROPERTYKEY represents a command for WPD.</summary>
        /// <param name="pk">The PROPERTYKEY value to check.</param>
        /// <returns><see langword="true"/> if <paramref name="pk"/> is a WPD command; otherwise, <see langword="false"/>.</returns>
        public static bool IsCommandInWpdCommandAccessMap(in PROPERTYKEY pk) => pk.TryGetCommandInfo(out _, out _, out _);

        /// <summary>Verifies that a IO control code is valid for the parameters exposed by an <see cref="IPortableDeviceValues"/> instance.</summary>
        /// <param name="ControlCode">The control code.</param>
        /// <param name="pCommandParams">The <see cref="IPortableDeviceValues"/> instance.</param>
        /// <returns>S_OK on success; otherwise and error code.</returns>
        public static HRESULT VerifyWpdCommandAccessFromMap(uint ControlCode, IPortableDeviceValues pCommandParams)
        {
            HRESULT hr = HRESULT.S_OK;
            uint dwExpectedControlCode = IOCTL_WPD_MESSAGE_READWRITE_ACCESS;
            if (pCommandParams is null)
            {
                return HRESULT.E_POINTER;
            }
            if (ControlCode == IOCTL_WPD_MESSAGE_READWRITE_ACCESS)
            {
                return HRESULT.S_OK;
            }
            try
            {
                var WpdCommand = pCommandParams.GetCommandPKey();
                if (WpdCommand.TryGetCommandInfo(out var value, out _, out _))
                {
                    switch (value.Access)
                    {
                        case WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READ:
                            dwExpectedControlCode = IOCTL_WPD_MESSAGE_READ_ACCESS;
                            break;
                        case WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READWRITE:
                            dwExpectedControlCode = IOCTL_WPD_MESSAGE_READWRITE_ACCESS;
                            break;
                        case WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_FROM_PROPERTY_WITH_STGM_ACCESS:
                            if (value.AccessDependency.HasValue)
                            {
                                STGM dwAccessPropVal = (STGM)pCommandParams.GetUnsignedIntegerValue(value.AccessDependency.Value);
                                dwExpectedControlCode = dwAccessPropVal == STGM.STGM_READ ? IOCTL_WPD_MESSAGE_READ_ACCESS : IOCTL_WPD_MESSAGE_READWRITE_ACCESS;
                            }
                            break;
                        case WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_FROM_PROPERTY_WITH_FILE_ACCESS:
                            if (value.AccessDependency.HasValue)
                            {
                                uint dwVal = pCommandParams.GetUnsignedIntegerValue(value.AccessDependency.Value);
                                dwExpectedControlCode = dwVal == (uint)System.IO.FileAccess.Read ? IOCTL_WPD_MESSAGE_READ_ACCESS : IOCTL_WPD_MESSAGE_READWRITE_ACCESS;
                            }
                            break;
                        default:
                            dwExpectedControlCode = IOCTL_WPD_MESSAGE_READWRITE_ACCESS;
                            break;
                    }
                }
            }
            catch (Exception e) { hr = HRESULT.FromException(e); }

            return hr.Succeeded && ControlCode != dwExpectedControlCode ? HRESULT.E_INVALIDARG : hr;
        }

        private static PROPERTYKEY? GetWPDPKey(string propName) => propName is null ? null : PortableDeviceExtensions.GetKeyFromName(propName);

        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
        public class WPDCommandAttribute : Attribute
        {
            public WPDCommandAttribute(WPD_COMMAND_ACCESS_TYPES access = WPD_COMMAND_ACCESS_TYPES.WPD_COMMAND_ACCESS_READ, string depProp = null)
            {
                Access = access;
                AccessDependency = GetWPDPKey(depProp);
            }

            public WPD_COMMAND_ACCESS_TYPES Access { get; }

            public PROPERTYKEY? AccessDependency { get; }
        }

        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
        public class WPDCommandParamAttribute : Attribute
        {
            public WPDCommandParamAttribute(string prop, bool required)
            {
                Property = GetWPDPKey(prop).GetValueOrDefault();
                Required = required;
            }

            public PROPERTYKEY Property { get; }

            public bool Required { get; }
        }

        [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
        public class WPDCommandResultAttribute : Attribute
        {
            public WPDCommandResultAttribute(string prop, bool required)
            {
                Property = GetWPDPKey(prop).GetValueOrDefault();
                Required = required;
            }

            public PROPERTYKEY Property { get; }

            public bool Required { get; }
        }
    }