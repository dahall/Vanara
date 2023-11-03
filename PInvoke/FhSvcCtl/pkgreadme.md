![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.FhSvcCtl NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.FhSvcCtl?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows FhSvcCtl.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.FhSvcCtl**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
FhServiceBlockBackup FhServiceClosePipe FhServiceOpenPipe FhServiceReloadConfiguration FhServiceStartBackup FhServiceStopBackup FhServiceUnblockBackup    | FH_BACKUP_STATUS FH_DEVICE_VALIDATION_RESULT FH_LOCAL_POLICY_TYPE FH_PROTECTED_ITEM_CATEGORY FH_RETENTION_TYPES FH_STATE FH_TARGET_DRIVE_TYPES FH_TARGET_PROPERTY_TYPE FHERR  | FH_SERVICE_PIPE_HANDLE          | IFhConfigMgr IFhReassociation IFhScopeIterator IFhTarget      
