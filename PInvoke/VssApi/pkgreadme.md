![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.VssApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Volume Shadow Copy Service (VssApi.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.VssApi**

Functions
---
CreateVssBackupComponentsInternal CreateVssExamineWriterMetadataInternal CreateVssExpressWriterInternal CreateVssSnapshotSetDescription CreateWriter CreateWriterEx GetProviderMgmtInterface GetProviderMgmtInterfaceInternal IsVolumeSnapshotted IsVolumeSnapshottedInternal LoadVssSnapshotSetDescription long __cdecl CreateVssBackupComponents(class IVssBackupComponents * __ptr64 * __ptr64) long __cdecl CreateVssExamineWriterMetadata(unsigned short * __ptr64,class IVssExamineWriterMetadata * __ptr64 * __ptr64) ShouldBlockRevert ShouldBlockRevertInternal VssFreeSnapshotProperties VssFreeSnapshotPropertiesInternal 
