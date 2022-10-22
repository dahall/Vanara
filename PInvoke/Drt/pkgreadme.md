![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Drt NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Drt?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Drt.dll for the Distributed Routing Table (DRT) API.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Drt**

Functions | Enumerations | Structures
--- | --- | ---
DrtClose DrtContinueSearch DrtCreateDerivedKey DrtCreateDerivedKeySecurityProvider DrtCreateDnsBootstrapResolver DrtCreateIpv6UdpTransport DrtCreateNullSecurityProvider DrtCreatePnrpBootstrapResolver DrtDeleteDerivedKeySecurityProvider DrtDeleteDnsBootstrapResolver DrtDeleteIpv6UdpTransport DrtDeleteNullSecurityProvider DrtDeletePnrpBootstrapResolver DrtEndSearch DrtGetEventData DrtGetEventDataSize DrtGetInstanceName DrtGetInstanceNameSize DrtGetSearchPath DrtGetSearchPathSize DrtGetSearchResult DrtGetSearchResultSize DrtOpen DrtRegisterKey DrtStartSearch DrtUnregisterKey DrtUpdateKey  | DRT_ADDRESS_FLAGS DRT_EVENT_TYPE DRT_LEAFSET_KEY_CHANGE_TYPE DRT_MATCH_TYPE DRT_REGISTRATION_STATE DRT_SCOPE DRT_SECURITY_MODE DRT_STATUS                     | DRT_ADDRESS DRT_ADDRESS_LIST DRT_BOOTSTRAP_PROVIDER DRT_BOOTSTRAP_RESOLVE_CONTEXT DRT_DATA DRT_EVENT_DATA DRT_REGISTRATION DRT_SEARCH_INFO DRT_SEARCH_RESULT DRT_SECURITY_PROVIDER DRT_SETTINGS HDRT HDRT_REGISTRATION_CONTEXT HDRT_SEARCH_CONTEXT HDRT_TRANSPORT SafeDRT_DATA UNION LEAFSETKEYCHANGE REGISTRATIONSTATECHANGE STATUSCHANGE BOOTSTRAPADDRESSES       
