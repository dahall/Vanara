![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Dhcp NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Dhcp?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Dhcpcsvc.dll and Dhcpcsvc6.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Dhcp**

Functions | Enumerations | Structures
--- | --- | ---
DhcpCApiCleanup DhcpCApiInitialize DhcpDeRegisterParamChange DhcpGetOriginalSubnetMask DhcpRegisterParamChange DhcpRemoveDNSRegistrations DhcpRequestParams DhcpUndoRequestParams Dhcpv6CApiCleanup Dhcpv6CApiInitialize Dhcpv6ReleasePrefix Dhcpv6RenewPrefix Dhcpv6RequestParams Dhcpv6RequestPrefix McastApiCleanup McastApiStartup McastEnumerateScopes McastGenUID McastReleaseAddress McastRenewAddress McastRequestAddress  | DHCP_OPTION_ID DHCPCAPI_REQUEST DHCPV6_OPTION_ID StatusCode                   | DHCP_IP_ADDRESS DHCPAPI_PARAMS DHCPCAPI_CLASSID DHCPCAPI_PARAMS_ARRAY DHCPV6CAPI_CLASSID DHCPV6CAPI_PARAMS DHCPV6CAPI_PARAMS_ARRAY DHCPV6Prefix DHCPV6PrefixLeaseInformation IPNG_ADDRESS MCAST_CLIENT_UID MCAST_LEASE_REQUEST MCAST_LEASE_RESPONSE MCAST_SCOPE_CTX MCAST_SCOPE_ENTRY       
