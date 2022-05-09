![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Drt NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Drt?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Drt.dll for the Distributed Routing Table (DRT) API.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Drt

Functions | Enumerations | Structures
--- | --- | ---
DrtClose<br>DrtContinueSearch<br>DrtCreateDerivedKey<br>DrtCreateDerivedKeySecurityProvider<br>DrtCreateDnsBootstrapResolver<br>DrtCreateIpv6UdpTransport<br>DrtCreateNullSecurityProvider<br>DrtCreatePnrpBootstrapResolver<br>DrtDeleteDerivedKeySecurityProvider<br>DrtDeleteDnsBootstrapResolver<br>DrtDeleteIpv6UdpTransport<br>DrtDeleteNullSecurityProvider<br>DrtDeletePnrpBootstrapResolver<br>DrtEndSearch<br>DrtGetEventData<br>DrtGetEventDataSize<br>DrtGetInstanceName<br>DrtGetInstanceNameSize<br>DrtGetSearchPath<br>DrtGetSearchPathSize<br>DrtGetSearchResult<br>DrtGetSearchResultSize<br>DrtOpen<br>DrtRegisterKey<br>DrtStartSearch<br>DrtUnregisterKey<br>DrtUpdateKey<br> | DRT_ADDRESS_FLAGS<br>DRT_EVENT_TYPE<br>DRT_LEAFSET_KEY_CHANGE_TYPE<br>DRT_MATCH_TYPE<br>DRT_REGISTRATION_STATE<br>DRT_SCOPE<br>DRT_SECURITY_MODE<br>DRT_STATUS<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | DRT_ADDRESS<br>DRT_ADDRESS_LIST<br>DRT_BOOTSTRAP_PROVIDER<br>DRT_BOOTSTRAP_RESOLVE_CONTEXT<br>DRT_DATA<br>DRT_EVENT_DATA<br>DRT_REGISTRATION<br>DRT_SEARCH_INFO<br>DRT_SEARCH_RESULT<br>DRT_SECURITY_PROVIDER<br>DRT_SETTINGS<br>HDRT<br>HDRT_REGISTRATION_CONTEXT<br>HDRT_SEARCH_CONTEXT<br>HDRT_TRANSPORT<br>SafeDRT_DATA<br>UNION<br>LEAFSETKEYCHANGE<br>REGISTRATIONSTATECHANGE<br>STATUSCHANGE<br>BOOTSTRAPADDRESSES<br><br><br><br><br><br><br>
