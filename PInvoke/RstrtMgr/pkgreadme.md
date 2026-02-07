![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.RstrtMgr NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.RstrtMgr?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows RstrtMgr.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.RstrtMgr**

Functions | Enumerations | Structures
--- | --- | ---
RmAddFilter RmCancelCurrentTask RmEndSession RmGetFilterList RmGetList RmJoinSession RmRegisterResources RmRemoveFilter RmRestart RmShutdown RmStartSession  | RM_APP_STATUS RM_APP_TYPE RM_FILTER_ACTION RM_FILTER_TRIGGER RM_REBOOT_REASON RM_SHUTDOWN_TYPE       | RM_FILTER_INFO RM_PROCESS_INFO RM_UNIQUE_PROCESS         
