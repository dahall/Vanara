![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.ProjectedFSLib NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.ProjectedFSLib?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows ProjectedFSLib.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.ProjectedFSLib

Functions | Enumerations | Structures
--- | --- | ---
PrjAllocateAlignedBuffer<br>PrjClearNegativePathCache<br>PrjCompleteCommand<br>PrjDeleteFile<br>PrjDoesNameContainWildCards<br>PrjFileNameCompare<br>PrjFileNameMatch<br>PrjFillDirEntryBuffer<br>PrjFillDirEntryBuffer2<br>PrjFreeAlignedBuffer<br>PrjGetOnDiskFileState<br>PrjGetVirtualizationInstanceInfo<br>PrjMarkDirectoryAsPlaceholder<br>PrjStartVirtualizing<br>PrjStopVirtualizing<br>PrjUpdateFileIfNeeded<br>PrjWriteFileData<br>PrjWritePlaceholderInfo<br>PrjWritePlaceholderInfo2<br> | PRJ_CALLBACK_DATA_FLAGS<br>PRJ_COMPLETE_COMMAND_TYPE<br>PRJ_EXT_INFO_TYPE<br>PRJ_FILE_STATE<br>PRJ_NOTIFICATION<br>PRJ_NOTIFY_TYPES<br>PRJ_PLACEHOLDER_ID<br>PRJ_STARTVIRTUALIZING_FLAGS<br>PRJ_UPDATE_FAILURE_CAUSES<br>PRJ_UPDATE_TYPES<br><br><br><br><br><br><br><br><br><br> | PRJ_CALLBACK_DATA<br>PRJ_CALLBACKS<br>PRJ_COMPLETE_COMMAND_EXTENDED_PARAMETERS<br>PRJ_DIR_ENTRY_BUFFER_HANDLE<br>PRJ_EXTENDED_INFO<br>PRJ_FILE_BASIC_INFO<br>PRJ_NAMESPACE_VIRTUALIZATION_CONTEXT<br>PRJ_NOTIFICATION_MAPPING<br>PRJ_NOTIFICATION_PARAMETERS<br>PRJ_PLACEHOLDER_INFO<br>PRJ_PLACEHOLDER_VERSION_INFO<br>PRJ_STARTVIRTUALIZING_OPTIONS<br>PRJ_VIRTUALIZATION_INSTANCE_INFO<br>SYMLINK<br>EAINFORMATION<br>SECURITYINFORMATION<br>STREAMSINFORMATION<br><br><br>
