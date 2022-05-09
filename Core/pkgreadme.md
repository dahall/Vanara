![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.Core NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.Core?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

This library includes shared methods, structures and constants for use throughout the Vanara assemblies. Think of it as windows.h with some useful extensions. It includes:
* Extension methods for working with enumerated types (enum), FILETIME, and method and property extractions via reflection
* Extension and helper methods to marshaling structures arrays and strings
* SafeHandle based classes for working with memory allocated via CoTaskMem, HGlobal, or Local calls that handles packing and extracting arrays, structures and raw memory
* Safe pinning of objects in memory
* Memory stream based on marshaled memory

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.Core

Classes | Structures | Enumerations | Interfaces
--- | --- | --- | ---
AlignedMemory<br>BeginEndEventContext<br>BitHelper<br>ByteSizeFormatter<br>ComConnectionPoint<br>ComReleaser<br>ComReleaserFactory<br>ComStream<br>ComTypeExtensions<br>ConstantConversionExtensions<br>CorrespondingTypeAttribute<br>CoTaskMemoryMethods<br>EnumerableEqualityComparer<br>EnumExtensions<br>EventedList<br>FileTimeExtensions<br>Formatter<br>FormatterComposer<br>GenericSafeHandle<br>GenericVirtualReadOnlyDictionary<br>HexDempHelpers<br>HGlobalMemoryMethods<br>History<br>IArrayStructExtensions<br>IArrayStructMarshaler<br>InteropExtensions<br>IntPtrConverter<br>IOExtensions<br>LibHelper<br>ListChangedEventArgs<br>MarshalingStream<br>MemoryMethodsBase<br>NativeMemoryEnumerator<br>NativeMemoryStream<br>PinnedObject<br>ReflectionExtensions<br>ReflectionExtensions<br>SafeAllocatedMemoryHandle<br>SafeAllocatedMemoryHandleBase<br>SafeByteArray<br>SafeCoTaskMemHandle<br>SafeCoTaskMemString<br>SafeCoTaskMemStruct<br>SafeGuidPtr<br>SafeHGlobalHandle<br>SafeHGlobalStruct<br>SafeMemoryHandle<br>SafeMemoryHandleExt<br>SafeMemString<br>SafeMemStruct<br>SparseArray<br>StringHelper<br>TryGetValueDelegate<br>UntypedNativeMemoryEnumerator<br>VanaraCustomMarshaler<br>VanaraMarshaler<br>VanaraMarshalerAttribute<br>VirtualDictionary<br>VirtualReadOnlyDictionary<br> | BOOL<br>BOOLEAN<br>EnumFlagIndexer<br>GuidPtr<br>RefEnumerator<br>SizeT<br>StrPtrAnsi<br>StrPtrAuto<br>StrPtrUni<br>time_t<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | CorrespondingAction<br>FileAttributeConstant<br>FileOpConstant<br>FilePermissionConstant<br>StringListPackMethod<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | IArrayStruct<br>IHistory<br>IMemoryMethods<br>ISafeMemoryHandle<br>ISimpleMemoryMethods<br>IVanaraMarshaler<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
