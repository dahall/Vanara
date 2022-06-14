![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.PortableDeviceApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.PortableDeviceApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Portable Device (WPD) Api.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.PortableDeviceApi**

Enumerations | Interfaces
--- | ---
DELETE_OBJECT_OPTIONS WPD_DEVICE_TYPES WpdAttributeForm WpdParameterAttributeForm WPD_DEVICE_TRANSPORTS WPD_STORAGE_TYPE_VALUES WPD_STORAGE_ACCESS_CAPABILITY_VALUES WPD_SMS_ENCODING_TYPES SMS_MESSAGE_TYPES WPD_POWER_SOURCES WPD_WHITE_BALANCE_SETTINGS WPD_FOCUS_MODES WPD_EXPOSURE_METERING_MODES WPD_FLASH_MODES WPD_EXPOSURE_PROGRAM_MODES WPD_CAPTURE_MODES WPD_EFFECT_MODES WPD_FOCUS_METERING_MODES WPD_BITRATE_TYPES WPD_META_GENRES WPD_CROPPED_STATUS_VALUES WPD_COLOR_CORRECTED_STATUS_VALUES WPD_VIDEO_SCAN_TYPES WPD_OPERATION_STATES WPD_SECTION_DATA_UNITS_VALUES WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPES WPD_COMMAND_ACCESS_TYPES WPD_SERVICE_INHERITANCE_TYPES WPD_PARAMETER_USAGE_TYPES WPD_STREAM_UNITS  | IEnumPortableDeviceObjectIDs IPortableDevice IPortableDeviceCapabilities IPortableDeviceContent IPortableDeviceContent2 IPortableDeviceDataStream IPortableDeviceDispatchFactory IPortableDeviceEventCallback IPortableDeviceManager IPortableDeviceProperties IPortableDevicePropertiesBulk IPortableDevicePropertiesBulkCallback IPortableDeviceResources IPortableDeviceService IPortableDeviceServiceActivation IPortableDeviceServiceCapabilities IPortableDeviceServiceManager IPortableDeviceServiceMethodCallback IPortableDeviceServiceMethods IPortableDeviceServiceOpenCallback IConnectionRequestCallback IEnumPortableDeviceConnectors IPortableDeviceConnector IPortableDeviceKeyCollection IPortableDevicePropVariantCollection IPortableDeviceValues IPortableDeviceValuesCollection IWpdSerializer   
