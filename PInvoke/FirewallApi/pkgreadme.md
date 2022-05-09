![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.FirewallApi NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.FirewallApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from FirewallApi.dll for Windows Firewall with Advanced Security.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.FirewallApi

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
NetworkIsolationDiagnoseConnectFailureAndGetInfo<br>NetworkIsolationEnumAppContainers<br>NetworkIsolationEnumerateAppContainerRules<br>NetworkIsolationFreeAppContainers<br>NetworkIsolationGetAppContainerConfig<br>NetworkIsolationGetEnterpriseIdAsync<br>NetworkIsolationGetEnterpriseIdClose<br>NetworkIsolationRegisterForAppContainerChanges<br>NetworkIsolationSetAppContainerConfig<br>NetworkIsolationSetupAppContainerBinaries<br>NetworkIsolationUnregisterForAppContainerChanges<br><br><br><br><br><br><br><br><br> | NET_FW_ACTION<br>NET_FW_AUTHENTICATE_TYPE<br>NET_FW_EDGE_TRAVERSAL_TYPE<br>NET_FW_IP_PROTOCOL<br>NET_FW_IP_VERSION<br>NET_FW_MODIFY_STATE<br>NET_FW_POLICY_TYPE<br>NET_FW_PROFILE_TYPE<br>NET_FW_PROFILE_TYPE2<br>NET_FW_RULE_CATEGORY<br>NET_FW_RULE_DIRECTION<br>NET_FW_SCOPE<br>NET_FW_SERVICE_TYPE<br>INET_FIREWALL_AC_CREATION_TYPE<br>NETISO_ERROR_TYPE<br>NETISO_FLAG<br>NETISO_GEID<br>INET_FIREWALL_AC_CHANGE_TYPE<br><br> | INET_FIREWALL_AC_BINARIES<br>INET_FIREWALL_AC_CHANGE<br>INET_FIREWALL_AC_CAPABILITIES<br>INET_FIREWALL_APP_CONTAINER<br>UNIONType<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | INetFwAuthorizedApplication<br>INetFwAuthorizedApplications<br>INetFwIcmpSettings<br>INetFwMgr<br>INetFwOpenPort<br>INetFwOpenPorts<br>INetFwPolicy<br>INetFwPolicy2<br>INetFwProduct<br>INetFwProducts<br>INetFwProfile<br>INetFwRemoteAdminSettings<br>INetFwRule<br>INetFwRule2<br>INetFwRule3<br>INetFwRules<br>INetFwService<br>INetFwServiceRestriction<br>INetFwServices<br>
