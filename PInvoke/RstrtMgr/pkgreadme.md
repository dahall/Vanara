![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.RstrtMgr NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.RstrtMgr?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows RstrtMgr.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.RstrtMgr

Functions | Enumerations | Structures
--- | --- | ---
RmAddFilter<br>RmCancelCurrentTask<br>RmEndSession<br>RmGetFilterList<br>RmGetList<br>RmJoinSession<br>RmRegisterResources<br>RmRemoveFilter<br>RmRestart<br>RmShutdown<br>RmStartSession<br> | RM_APP_STATUS<br>RM_APP_TYPE<br>RM_FILTER_ACTION<br>RM_FILTER_TRIGGER<br>RM_REBOOT_REASON<br>RM_SHUTDOWN_TYPE<br><br><br><br><br><br> | RM_FILTER_INFO<br>RM_PROCESS_INFO<br>RM_UNIQUE_PROCESS<br><br><br><br><br><br><br><br><br>
