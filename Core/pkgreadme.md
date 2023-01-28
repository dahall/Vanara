![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.Core NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.Core?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

This library includes shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions. It includes:
* Extension methods for working with enumerated types (enum), FILETIME, and method and property extractions via reflection
* Extension and helper methods to marshaling structures arrays and strings
* SafeHandle based classes for working with memory allocated via CoTaskMem, HGlobal, or Local calls that handles packing and extracting arrays, structures and raw memory
* Safe pinning of objects in memory
* Memory stream based on marshaled memory

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.Core**

Classes | Structures | Enumerations | Interfaces
--- | --- | --- | ---
AlignedMemory BeginEndEventContext BitHelper ByteSizeFormatter ComConnectionPoint ComReleaser ComReleaserFactory ComStream ComTypeExtensions ConstantConversionExtensions CorrespondingTypeAttribute CoTaskMemoryMethods EnumerableEqualityComparer EnumExtensions EventedList FileTimeExtensions Formatter FormatterComposer GenericSafeHandle GenericVirtualReadOnlyDictionary HexDempHelpers HGlobalMemoryMethods History IArrayStructExtensions IArrayStructMarshaler InteropExtensions IntPtrConverter IOExtensions LibHelper ListChangedEventArgs MarshalingStream MemoryMethodsBase NativeMemoryEnumerator NativeMemoryStream PinnedObject ReflectionExtensions ReflectionExtensions RequiresUnreferencedCodeAttribute SafeAllocatedMemoryHandle SafeAllocatedMemoryHandleBase SafeByteArray SafeCoTaskMemHandle SafeCoTaskMemString SafeCoTaskMemStruct SafeGuidPtr SafeHGlobalHandle SafeHGlobalStruct SafeLPSTR SafeLPTSTR SafeLPWSTR SafeMemoryHandle SafeMemoryHandleExt SafeMemoryPool SafeMemString SafeMemStruct SparseArray StringHelper TryGetValueDelegate UntypedNativeMemoryEnumerator VanaraCustomMarshaler VanaraMarshaler VanaraMarshalerAttribute VirtualDictionary VirtualReadOnlyDictionary  | BOOL BOOLEAN EnumFlagIndexer GuidPtr RefEnumerator SizeT StrPtrAnsi StrPtrAuto StrPtrUni time_t                                                        | CorrespondingAction FileAttributeConstant FileOpConstant FilePermissionConstant StringListPackMethod                                                             | IArrayStruct IHistory IMemoryMethods ISafeMemoryHandle ISimpleMemoryMethods ISupportIndexer IVanaraMarshaler                                                          
