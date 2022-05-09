![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.FhSvcCtl NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.FhSvcCtl?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows FhSvcCtl.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.FhSvcCtl

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
FhServiceBlockBackup<br>FhServiceClosePipe<br>FhServiceOpenPipe<br>FhServiceReloadConfiguration<br>FhServiceStartBackup<br>FhServiceStopBackup<br>FhServiceUnblockBackup<br><br> | FH_BACKUP_STATUS<br>FH_DEVICE_VALIDATION_RESULT<br>FH_LOCAL_POLICY_TYPE<br>FH_PROTECTED_ITEM_CATEGORY<br>FH_RETENTION_TYPES<br>FH_STATE<br>FH_TARGET_DRIVE_TYPES<br>FH_TARGET_PROPERTY_TYPE<br> | FH_SERVICE_PIPE_HANDLE<br><br><br><br><br><br><br><br> | IFhConfigMgr<br>IFhReassociation<br>IFhScopeIterator<br>IFhTarget<br><br><br><br><br>
