﻿![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.DOSvc NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.DOSvc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Delivery Optimization (dosvc.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.DOSvc**

Enumerations | Structures | Interfaces
--- | --- | ---
DeliveryOptimizationFileProperty DODownloadCostPolicy DODownloadProperty DODownloadPropertyEx DODownloadState DownloadMode SwarmStatus  | DO_DOWNLOAD_ENUM_CATEGORY DO_DOWNLOAD_RANGE DO_DOWNLOAD_RANGES_INFO DO_DOWNLOAD_STATUS DOSwarmStats    | IDODownload IDODownloadStatusCallback IDOManager     
