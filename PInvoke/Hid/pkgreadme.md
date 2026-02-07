![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Hid NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Hid?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows Human Interface Devices (hid.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Hid**

Functions | Enumerations | Structures
--- | --- | ---
HidD_FlushQueue HidD_FreePreparsedData HidD_GetAttributes HidD_GetFeature HidD_GetHidGuid HidD_GetIndexedString HidD_GetInputReport HidD_GetManufacturerString HidD_GetNumInputBuffers HidD_GetPhysicalDescriptor HidD_GetPreparsedData HidD_GetProductString HidD_GetSerialNumberString HidD_SetFeature HidD_SetNumInputBuffers HidD_SetOutputReport HidNotifyPresence HidP_FreeCollectionDescription HidP_GetButtonArray HidP_GetButtonCaps HidP_GetCaps HidP_GetCollectionDescription HidP_GetData HidP_GetExtendedAttributes HidP_GetLinkCollectionNodes HidP_GetScaledUsageValue HidP_GetSpecificButtonCaps HidP_GetSpecificValueCaps HidP_GetUsages HidP_GetUsagesEx HidP_GetUsageValue HidP_GetUsageValueArray HidP_GetValueCaps HidP_GetVersion HidP_InitializeReportForID HidP_MaxDataListLength HidP_MaxUsageListLength HidP_SetButtonArray HidP_SetData HidP_SetScaledUsageValue HidP_SetUsages HidP_SetUsageValue HidP_SetUsageValueArray HidP_TranslateUsagesToI8042ScanCodes HidP_UnsetUsages HidP_UsageAndPageListDifference HidP_UsageListDifference HidRegisterMinidriver HIDSPICX_DEVICE_CONFIG_INIT HidSpiCxDeviceConfigure HidSpiCxDeviceInitConfig HidSpiCxNotifyDeviceReset VHF_CONFIG_INIT VhfAsyncOperationComplete VhfCreate VhfDelete VhfReadReportSubmit VhfStart         | HIDP_GETCOLDESC_RESULT HIDP_KEYBOARD_DIRECTION HIDP_LINK_COLLECTION HIDP_REPORT_TYPE HIDSPICXFUNCENUM USAGE USAGE_VALUE KBDMOU I8042_BUTTONS I8042_PORT_TYPE MOUSE_RESET_SUBSTATE KEYBOARD_SCAN_STATE MOUSE_STATE TRANSMIT_STATE KEYBOARD_INPUT_FLAGS LED_FLAGS MOUSE_BUTTON_FLAG MOUSE_IDENTIFIER MOUSE_INPUT_FLAG                                                | HID_COLLECTION_INFORMATION HID_XFER_PACKET HIDP_COLLECTION_DESC HIDP_DEVICE_DESC HIDP_GETCOLDESC_DBG HIDP_REPORT_IDS HIDP_BUTTON_ARRAY_DATA HIDP_BUTTON_CAPS HIDP_CAPS HIDP_DATA HIDP_EXTENDED_ATTRIBUTES HIDP_KEYBOARD_MODIFIER_STATE HIDP_LINK_COLLECTION_NODE HIDP_UNKNOWN_TOKEN HIDP_VALUE_CAPS PHIDP_PREPARSED_DATA PHIDP_REPORT_DESCRIPTOR USAGE_AND_PAGE HID_DESCRIPTOR HID_DEVICE_ATTRIBUTES HID_DEVICE_EXTENSION HID_MINIDRIVER_REGISTRATION HID_SUBMIT_IDLE_NOTIFICATION_CALLBACK_INFO PDEVICE_OBJECT PDRIVER_OBJECT PFILE_OBJECT HIDD_ATTRIBUTES HIDSPICX_DEVICE_CONFIG HIDSPICX_DRIVER_GLOBALS HIDSPICX_REPORT CONNECT_DATA INTERNAL_I8042_HOOK_KEYBOARD INTERNAL_I8042_HOOK_MOUSE INTERNAL_I8042_START_INFORMATION OUTPUT_PACKET INDICATOR_LIST KEYBOARD_ATTRIBUTES KEYBOARD_EXTENDED_ATTRIBUTES KEYBOARD_ID KEYBOARD_INDICATOR_PARAMETERS KEYBOARD_INDICATOR_TRANSLATION KEYBOARD_INPUT_DATA KEYBOARD_TYPEMATIC_PARAMETERS KEYBOARD_UNIT_ID_PARAMETER MOUSE_ATTRIBUTES MOUSE_INPUT_DATA MOUSE_UNIT_ID_PARAMETER VHF_CONFIG VHFHANDLE VHFOPERATIONHANDLE <Reserved>e__FixedBuffer <_args>e__FixedBuffer RangeUnion NotRangeUnion <Reserved>e__FixedBuffer <Reserved>e__FixedBuffer <Reserved>e__FixedBuffer <Reserved>e__FixedBuffer RangeUnion NotRangeUnion <Reserved2>e__FixedBuffer HID_DESCRIPTOR_DESC_LIST <Reserved>e__FixedBuffer <Reserved>e__FixedBuffer <Reserved>e__FixedBuffer 
