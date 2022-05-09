![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Shared NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Shared?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

Shared methods, structures and constants for use throughout the Vanara.PInvoke assemblies. Includes:
* IEnumerable helpers for COM enumerations
* Custom marshaler for CoTaskMem pointers
* Enhanced error results classes for HRESULT, Win32Error and NTStatus
* Standard windows.h macros (e.g. HIWORD, MAKELONG, etc.)
* Overlapped method wrapper
* Resource ID holder
* Shared structures and enums (see release notes)

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Shared

Classes | Structures | Enumerations | Interfaces
--- | --- | --- | ---
AnySizeStringMarshaler<br>AssociateAttribute<br>AssociateStringAttribute<br>ClipCorrespondingTypeAttribute<br>ComTryGetNext<br>CoTaskMemStringMarshaler<br>FunctionHelper<br>GenericStringMarshaler<br>GenericStringMarshalerBase<br>IEnumeratorFromNext<br>IEnumFromCom<br>IEnumFromIndexer<br>IEnumFromNext<br>Lib<br>LOGPALETTE<br>Macros<br>NullTermStringArrayMarshaler<br>OverlappedAsync<br>OverlappedAsyncResult<br>PInvokeClientExtensions<br>PInvokeDataAttribute<br>PRECT<br>PtrFunc<br>RegistryTypeExt<br>SafeAnysizeStruct<br>SafeAnysizeStructBase<br>SafeAnysizeStructMarshaler<br>SafeElementArray<br>SafeHANDLE<br>SafeNativeArray<br>SafeNativeArrayBase<br>SafeNativeLinkedList<br>SafeNativeListBase<br>SafeResourceId<br>SBFunc<br>SECURITY_ATTRIBUTES<br>SizeFunc<br>StaticFieldValueHash<br>StringPtrArrayMarshaler<br>StructHelper<br>TryGetNext<br>TryGetNext<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | ACCESS_MASK<br>BusNumber<br>CLIPFORMAT<br>CM_FULL_RESOURCE_DESCRIPTOR<br>CM_PARTIAL_RESOURCE_DESCRIPTOR<br>CM_PARTIAL_RESOURCE_LIST<br>CM_POWER_DATA<br>CM_RESOURCE_LIST<br>COLORREF<br>Connection<br>CORRELATION_VECTOR<br>CY<br>DATE<br>DECIMAL<br>DEVICE_CAPABILITIES<br>DevicePrivate<br>DeviceSpecificData<br>DEVMODE<br>Dma<br>DmaV3<br>Generic<br>HACCEL<br>HANDLE<br>HBITMAP<br>HBRUSH<br>HCOLORSPACE<br>HCURSOR<br>HDC<br>HDESK<br>HDPA<br>HDROP<br>HDSA<br>HDWP<br>HENHMETAFILE<br>HEVENT<br>HFILE<br>HFONT<br>HGDIOBJ<br>HICON<br>HIMAGELIST<br>HINSTANCE<br>HKEY<br>HMENU<br>HMETAFILE<br>HMONITOR<br>HPALETTE<br>HPEN<br>HPROCESS<br>HPROPSHEET<br>HPROPSHEETPAGE<br>HRESULT<br>HRGN<br>HSECTION<br>HTASK<br>HTHEME<br>HTHREAD<br>HTHUMBNAIL<br>HTOKEN<br>HWINSTA<br>HWND<br>Interrupt<br>LANGID<br>LCID<br>LOGFONT<br>LOGPALETTE<br>Memory40<br>Memory48<br>Memory64<br>MessageInterruptRaw<br>MSG<br>NTStatus<br>OBJECT_TYPE_LIST<br>OFSTRUCT<br>PACE<br>PACL<br>PALETTEENTRY<br>POINT<br>POINTS<br>PRECT<br>PSECURITY_DESCRIPTOR<br>PSID<br>RECT<br>ResourceId<br>ResourceIdOrHandle<br>RGBQUAD<br>SECURITY_ATTRIBUTES<br>SIZE<br>SYSTEMTIME<br>tagSECURITY_ATTRIBUTES<br>TEXTMETRIC<br>union<br>WIN32_FIND_DATA<br>Win32Error<br> | CharacterSet<br>CM_DEVCAP<br>CM_FILE<br>CM_INSTALL_STATE<br>CM_REMOVAL_POLICY<br>CM_RESOURCE<br>CM_SHARE_DISPOSITION<br>CmResourceType<br>CONFIGFLAG<br>DEVICE_POWER_STATE<br>DEVICE_SCALE_FACTOR<br>DMCOLLATE<br>DMCOLOR<br>DMDFO<br>DMDISPLAY<br>DMDITHER<br>DMDO<br>DMDUP<br>DMFIELDS<br>DMICM<br>DMICMMETHOD<br>DMMEDIA<br>DMNUP<br>DMORIENT<br>DMPAPER<br>DMRES<br>DMTT<br>DN<br>DrawTextFlags<br>FacilityCode<br>FacilityCode<br>FILE_DEVICE<br>FileFlagsAndAttributes<br>FontFamily<br>FontPitch<br>INTERFACE_TYPE<br>LANG<br>LogFontClippingPrecision<br>LogFontOutputPrecision<br>LogFontOutputQuality<br>MouseButtonState<br>NTDDI<br>ObjectTypeListLevel<br>PC<br>PDCAP<br>PInvokeClient<br>ProcessorArchitecture<br>REG_VALUE_TYPE<br>ResourceType<br>SECURITY_INFORMATION<br>SeverityLevel<br>SeverityLevel<br>ShowWindowCommand<br>SORT<br>STGM<br>SUBLANG<br>SYSTEM_POWER_STATE<br>SystemColorIndex<br>SystemShutDownReason<br>URLZONE<br>WIN32_WINNT<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | IClipboardFormatter<br>ICOMEnum<br>IErrorProvider<br>IGraphicsObjectHandle<br>IHandle<br>IKernelHandle<br>ISecurityObject<br>IShellHandle<br>ISyncHandle<br>IUserHandle<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
