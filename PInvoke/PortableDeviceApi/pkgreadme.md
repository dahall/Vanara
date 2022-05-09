![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.PortableDeviceApi NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.PortableDeviceApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Portable Device (WPD) Api.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.PortableDeviceApi

Enumerations | Interfaces
--- | ---
DELETE_OBJECT_OPTIONS<br>WPD_DEVICE_TYPES<br>WpdAttributeForm<br>WpdParameterAttributeForm<br>WPD_DEVICE_TRANSPORTS<br>WPD_STORAGE_TYPE_VALUES<br>WPD_STORAGE_ACCESS_CAPABILITY_VALUES<br>WPD_SMS_ENCODING_TYPES<br>SMS_MESSAGE_TYPES<br>WPD_POWER_SOURCES<br>WPD_WHITE_BALANCE_SETTINGS<br>WPD_FOCUS_MODES<br>WPD_EXPOSURE_METERING_MODES<br>WPD_FLASH_MODES<br>WPD_EXPOSURE_PROGRAM_MODES<br>WPD_CAPTURE_MODES<br>WPD_EFFECT_MODES<br>WPD_FOCUS_METERING_MODES<br>WPD_BITRATE_TYPES<br>WPD_META_GENRES<br>WPD_CROPPED_STATUS_VALUES<br>WPD_COLOR_CORRECTED_STATUS_VALUES<br>WPD_VIDEO_SCAN_TYPES<br>WPD_OPERATION_STATES<br>WPD_SECTION_DATA_UNITS_VALUES<br>WPD_RENDERING_INFORMATION_PROFILE_ENTRY_TYPES<br>WPD_COMMAND_ACCESS_TYPES<br>WPD_SERVICE_INHERITANCE_TYPES<br>WPD_PARAMETER_USAGE_TYPES<br>WPD_STREAM_UNITS<br> | IEnumPortableDeviceObjectIDs<br>IPortableDevice<br>IPortableDeviceCapabilities<br>IPortableDeviceContent<br>IPortableDeviceContent2<br>IPortableDeviceDataStream<br>IPortableDeviceDispatchFactory<br>IPortableDeviceEventCallback<br>IPortableDeviceManager<br>IPortableDeviceProperties<br>IPortableDevicePropertiesBulk<br>IPortableDevicePropertiesBulkCallback<br>IPortableDeviceResources<br>IPortableDeviceService<br>IPortableDeviceServiceActivation<br>IPortableDeviceServiceCapabilities<br>IPortableDeviceServiceManager<br>IPortableDeviceServiceMethodCallback<br>IPortableDeviceServiceMethods<br>IPortableDeviceServiceOpenCallback<br>IConnectionRequestCallback<br>IEnumPortableDeviceConnectors<br>IPortableDeviceConnector<br>IPortableDeviceKeyCollection<br>IPortableDevicePropVariantCollection<br>IPortableDeviceValues<br>IPortableDeviceValuesCollection<br>IWpdSerializer<br><br><br>
