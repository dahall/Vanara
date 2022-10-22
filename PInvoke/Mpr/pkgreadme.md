![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Mpr NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Mpr?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Mpr.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Mpr**

Functions | Enumerations | Structures
--- | --- | ---
MultinetGetConnectionPerformance WNetAddConnection WNetAddConnection2 WNetAddConnection3 WNetCancelConnection2 WNetCloseEnum WNetConnectionDialog WNetConnectionDialog1 WNetDisconnectDialog WNetDisconnectDialog1 WNetEnumResource WNetGetConnection WNetGetLastError WNetGetNetworkInformation WNetGetProviderName WNetGetResourceInformation WNetGetResourceParent WNetGetUniversalName WNetGetUser WNetOpenEnum WNetSetLastError WNetUseConnection  | CONN_DLG CONNECT DISC INFO_LEVEL NETINFO NETRESOURCEDisplayType NETRESOURCEScope NETRESOURCEType NETRESOURCEUsage WNCON WNNC_NET             | CONNECTDLGSTRUCT DISCDLGSTRUCT NETCONNECTINFOSTRUCT NETINFOSTRUCT NETRESOURCE REMOTE_NAME_INFO UNIVERSAL_NAME_INFO                
