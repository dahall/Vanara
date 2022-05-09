![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Dhcp NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Dhcp?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Dhcpcsvc.dll and Dhcpcsvc6.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Dhcp

Functions | Enumerations | Structures
--- | --- | ---
DhcpCApiCleanup<br>DhcpCApiInitialize<br>DhcpDeRegisterParamChange<br>DhcpGetOriginalSubnetMask<br>DhcpRegisterParamChange<br>DhcpRemoveDNSRegistrations<br>DhcpRequestParams<br>DhcpUndoRequestParams<br>Dhcpv6CApiCleanup<br>Dhcpv6CApiInitialize<br>Dhcpv6ReleasePrefix<br>Dhcpv6RenewPrefix<br>Dhcpv6RequestParams<br>Dhcpv6RequestPrefix<br>McastApiCleanup<br>McastApiStartup<br>McastEnumerateScopes<br>McastGenUID<br>McastReleaseAddress<br>McastRenewAddress<br>McastRequestAddress<br> | DHCP_OPTION_ID<br>DHCPCAPI_REQUEST<br>DHCPV6_OPTION_ID<br>StatusCode<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | DHCP_IP_ADDRESS<br>DHCPAPI_PARAMS<br>DHCPCAPI_CLASSID<br>DHCPCAPI_PARAMS_ARRAY<br>DHCPV6CAPI_CLASSID<br>DHCPV6CAPI_PARAMS<br>DHCPV6CAPI_PARAMS_ARRAY<br>DHCPV6Prefix<br>DHCPV6PrefixLeaseInformation<br>IPNG_ADDRESS<br>MCAST_CLIENT_UID<br>MCAST_LEASE_REQUEST<br>MCAST_LEASE_RESPONSE<br>MCAST_SCOPE_CTX<br>MCAST_SCOPE_ENTRY<br><br><br><br><br><br><br>
