![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Shared NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Shared?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

Shared methods, structures and constants for use throughout the Vanara.PInvoke assemblies. Includes:
* IEnumerable helpers for COM enumerations
* Custom marshaler for CoTaskMem pointers
* Enhanced error results classes for HRESULT, Win32Error and NTStatus
* Standard windows.h macros (e.g. HIWORD, MAKELONG, etc.)
* Overlapped method wrapper
* Resource ID holder
* Shared structures and enums (see release notes)

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Shared**

Classes | Structures | Enumerations | Interfaces
--- | --- | --- | ---
AnySizeStringMarshaler AssociateAttribute AssociateStringAttribute ClipCorrespondingTypeAttribute ComTryGetNext CoTaskMemStringMarshaler EnumeratorToEnumVariantMarshaler ErrorHelper FunctionHelper GenericStringMarshaler GenericStringMarshalerBase HANDLEConverter IEnumeratorFromNext IEnumFromCom IEnumFromIndexer IEnumFromNext IidFunc IidFunc IidFunc1 IidFunc1 IidFunc2 IidFunc2 IndirectResource IndirectString Lib LOGPALETTE Macros NullTermStringArrayMarshaler OverlappedAsync OverlappedAsyncResult PFILETIME PInvokeClientExtensions PInvokeDataAttribute PRECT PSYSTEMTIME PtrFunc RegistryTypeExt SafeAnysizeStruct SafeAnysizeStructBase SafeAnysizeStructMarshaler SafeElementArray SafeNativeArray SafeNativeArrayBase SafeNativeLinkedList SafeNativeListBase SafeResourceId SBFunc SBFunc SBFunc SECURITY_ATTRIBUTES SizeFunc StaticFieldValueHash StringPtrArrayMarshaler StructHelper TryGetNext TryGetNext                                          | ACCESS_MASK BusNumber CLIPFORMAT CM_FULL_RESOURCE_DESCRIPTOR CM_PARTIAL_RESOURCE_DESCRIPTOR CM_PARTIAL_RESOURCE_LIST CM_POWER_DATA CM_RESOURCE_LIST COLORREF Connection CORRELATION_VECTOR CY DATE DECIMAL DEVICE_CAPABILITIES DevicePrivate DeviceSpecificData DEVMODE Dma DmaV3 Generic HACCEL HANDLE HBITMAP HBRUSH HCOLORSPACE HCURSOR HDC HDESK HDPA HDROP HDSA HDWP HENHMETAFILE HEVENT HFILE HFONT HGDIOBJ HICON HIMAGELIST HINSTANCE HKEY HMENU HMETAFILE HMONITOR HPALETTE HPEN HPROCESS HPROPSHEET HPROPSHEETPAGE HRESULT HRGN HSECTION HTASK HTHEME HTHREAD HTHUMBNAIL HTOKEN HWINSTA HWND Interrupt LANGID LCID LOGFONT LOGPALETTE LUID Memory40 Memory48 Memory64 MessageInterruptRaw MSG NTStatus OBJECT_TYPE_LIST OFSTRUCT PACE PACL PALETTEENTRY PFILETIME POINT POINTS PRECT PSECURITY_DESCRIPTOR PSID PSYSTEMTIME RECT ResourceId ResourceIdOrHandle RGBQUAD SECURITY_ATTRIBUTES SIZE SYSTEMTIME tagSECURITY_ATTRIBUTES TEXTMETRIC Union WIN32_FIND_DATA Win32Error  | CharacterSet CM_DEVCAP CM_FILE CM_INSTALL_STATE CM_REMOVAL_POLICY CM_RESOURCE CM_SHARE_DISPOSITION CmResourceType CONFIGFLAG DEVICE_POWER_STATE DEVICE_SCALE_FACTOR DMCOLLATE DMCOLOR DMDFO DMDISPLAY DMDITHER DMDO DMDUP DMFIELDS DMICM DMICMMETHOD DMMEDIA DMNUP DMORIENT DMPAPER DMRES DMTT DN DrawTextFlags FacilityCode FacilityCode FILE_DEVICE FILE_SHARE FileFlagsAndAttributes FontFamily FontPitch INTERFACE_TYPE LANG LogFontClippingPrecision LogFontOutputPrecision LogFontOutputQuality MouseButtonState NTDDI ObjectTypeListLevel PC PDCAP PInvokeClient ProcessorArchitecture REG_VALUE_TYPE ResourceType SECURITY_INFORMATION SeverityLevel SeverityLevel ShowWindowCommand SORT STGM SUBLANG SYSTEM_POWER_STATE SystemColorIndex SystemShutDownReason URLZONE WIN32_WINNT                                    | IClipboardFormatter ICOMEnum IDeviceContextHandle IErrorProvider IGraphicsObjectHandle IKernelHandle ISecurityObject IShellHandle ISyncHandle IUserHandle                                                                                       
