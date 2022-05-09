![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.AMSI NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.AMSI?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Antimalware Scan Interface (AMSI.dll).

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.AMSI

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
AmsiCloseSession<br>AmsiInitialize<br>AmsiNotifyOperation<br>AmsiOpenSession<br>AmsiScanBuffer<br>AmsiScanString<br>AmsiUninitialize<br> | AMSI_ATTRIBUTE<br>AMSI_RESULT<br><br><br><br><br><br> | HAMSICONTEXT<br>HAMSISESSION<br><br><br><br><br><br> | IAmsiStream<br>IAntimalware<br>IAntimalware2<br>IAntimalwareProvider<br>IAntimalwareProvider2<br><br><br>
