![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.Core NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.Core?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

This library includes shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions. It includes:
* Extension methods for working with enumerated types (enum), FILETIME, and method and property extractions via reflection
* Extension and helper methods to marshaling structures arrays and strings
* SafeHandle based classes for working with memory allocated via CoTaskMem, HGlobal, or Local calls that handles packing and extracting arrays, structures and raw memory
* Safe pinning of objects in memory
* Memory stream based on marshaled memory

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.Core**

Classes | Structures | Enumerations | Interfaces
--- | --- | --- | ---
AlignedMemory AppendedStringAttribute ArrayAttribute AutoHandleAttribute AutoSafeHandleAttribute BeginEndEventContext BitFieldAttribute BitHelper ByteSizeFormatter CloseHandleFunc ComConnectionPoint ComEnumString ComReleaser ComReleaserFactory ComStream ComTypeExtensions ConstantConversionExtensions CorrespondingTypeAttribute CoTaskMemoryMethods EnumerableEqualityComparer EnumExtensions EventedList FileTimeExtensions FixedStringAttribute Formatter FormatterComposer GenericSafeHandle GenericVirtualReadOnlyDictionary HexDumpHelpers HGlobalMemoryMethods History IArrayStructExtensions IArrayStructMarshaler InteropExtensions IntPtrConverter IOExtensions LibHelper LinqHelpers ListChangedEventArgs MarshaledAttribute Marshaler MarshalerOptions MarshalException MarshalFieldAs MarshalingStream Matrix Matrix MemoryMethodsBase NativeMemoryEnumerator NativeMemoryStream PinnedObject ReflectionExtensions ReflectionExtensions SafeAllocatedMemoryHandle SafeAllocatedMemoryHandleBase SafeByteArray SafeCoTaskMemHandle SafeCoTaskMemString SafeCoTaskMemStruct SafeGuidPtr SafeHANDLE SafeHGlobalHandle SafeHGlobalStruct SafeLPSTR SafeLPTSTR SafeLPWSTR SafeMemoryHandle SafeMemoryHandleExt SafeMemoryPool SafeMemString SafeMemStruct SizeFieldNameAttribute SizeFieldNameAttributeExt SizeOfAttribute SpanAction SparseArray StringHelper StructPtrAttribute SuppressAutoGenAttribute TryGetDelegate TryGetValueDelegate UntypedNativeMemoryEnumerator VanaraCustomMarshaler VanaraMarshaler VanaraMarshalerAttribute VirtualDictionary VirtualList VirtualListMethodCarrier VirtualReadOnlyDictionary VirtualReadOnlyList  | AnySizeStructFieldArray AnySizeStructUnmanagedFieldArray ArrayPointer BitField BOOL BOOLEAN EnumFlagIndexer GuidPtr IUnknownPointer LPCSTRArrayPointer LPCTSTRArrayPointer LPCWSTRArrayPointer ManagedArrayPointer ManagedStructPointer RefEnumerator SizeT StrPtrAnsi StrPtrAuto StrPtrUni StructPointer time_t                                                                       | ArrayLayout Bitness CorrespondingAction FileAttributeConstant FileOpConstant FilePermissionConstant LayoutModel StringEncoding StringListPackMethod                                                                                   | IArrayStruct IHandle IHistory IMemoryMethods ISafeMemoryHandle ISafeMemoryHandleFactory ISimpleMemoryMethods ISupportIndexer IVanaraMarshaler IVirtualListMethods IVirtualReadOnlyListMethods                                                                                
