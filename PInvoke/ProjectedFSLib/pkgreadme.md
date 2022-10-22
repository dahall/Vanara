![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.ProjectedFSLib NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.ProjectedFSLib?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows ProjectedFSLib.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.ProjectedFSLib**

Functions | Enumerations | Structures
--- | --- | ---
PrjAllocateAlignedBuffer PrjClearNegativePathCache PrjCompleteCommand PrjDeleteFile PrjDoesNameContainWildCards PrjFileNameCompare PrjFileNameMatch PrjFillDirEntryBuffer PrjFillDirEntryBuffer2 PrjFreeAlignedBuffer PrjGetOnDiskFileState PrjGetVirtualizationInstanceInfo PrjMarkDirectoryAsPlaceholder PrjStartVirtualizing PrjStopVirtualizing PrjUpdateFileIfNeeded PrjWriteFileData PrjWritePlaceholderInfo PrjWritePlaceholderInfo2  | PRJ_CALLBACK_DATA_FLAGS PRJ_COMPLETE_COMMAND_TYPE PRJ_EXT_INFO_TYPE PRJ_FILE_STATE PRJ_NOTIFICATION PRJ_NOTIFY_TYPES PRJ_PLACEHOLDER_ID PRJ_STARTVIRTUALIZING_FLAGS PRJ_UPDATE_FAILURE_CAUSES PRJ_UPDATE_TYPES           | PRJ_CALLBACK_DATA PRJ_CALLBACKS PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS PRJ_DIR_ENTRY_BUFFER_HANDLE PRJ_EXTENDED_INFO PRJ_FILE_BASIC_INFO PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT PRJ_NOTIFICATION_MAPPING PRJ_NOTIFICATION_PARAMETERS PRJ_PLACEHOLDER_INFO PRJ_PLACEHOLDER_VERSION_INFO PRJ_STARTVIRTUALIZING_OPTIONS PRJ_VIRTUALIZATION_INSTANCE_INFO SYMLINK EAINFORMATION SECURITYINFORMATION STREAMSINFORMATION   
