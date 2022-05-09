![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Mpr NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Mpr?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Mpr.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Mpr

Functions | Enumerations | Structures
--- | --- | ---
MultinetGetConnectionPerformance<br>WNetAddConnection<br>WNetAddConnection2<br>WNetAddConnection3<br>WNetCancelConnection2<br>WNetCloseEnum<br>WNetConnectionDialog<br>WNetConnectionDialog1<br>WNetDisconnectDialog<br>WNetDisconnectDialog1<br>WNetEnumResource<br>WNetGetConnection<br>WNetGetLastError<br>WNetGetNetworkInformation<br>WNetGetProviderName<br>WNetGetResourceInformation<br>WNetGetResourceParent<br>WNetGetUniversalName<br>WNetGetUser<br>WNetOpenEnum<br>WNetSetLastError<br>WNetUseConnection<br> | CONN_DLG<br>CONNECT<br>DISC<br>INFO_LEVEL<br>NETINFO<br>NETRESOURCEDisplayType<br>NETRESOURCEScope<br>NETRESOURCEType<br>NETRESOURCEUsage<br>WNCON<br>WNNC_NET<br><br><br><br><br><br><br><br><br><br><br><br> | CONNECTDLGSTRUCT<br>DISCDLGSTRUCT<br>NETCONNECTINFOSTRUCT<br>NETINFOSTRUCT<br>NETRESOURCE<br>REMOTE_NAME_INFO<br>UNIVERSAL_NAME_INFO<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
