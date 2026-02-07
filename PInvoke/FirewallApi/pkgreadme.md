![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.FirewallApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.FirewallApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from FirewallApi.dll for Windows Firewall with Advanced Security.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.FirewallApi**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
NetworkIsolationDiagnoseConnectFailureAndGetInfo NetworkIsolationEnumAppContainers NetworkIsolationEnumerateAppContainerRules NetworkIsolationFreeAppContainers NetworkIsolationGetAppContainerConfig NetworkIsolationGetEnterpriseIdAsync NetworkIsolationGetEnterpriseIdClose NetworkIsolationRegisterForAppContainerChanges NetworkIsolationSetAppContainerConfig NetworkIsolationSetupAppContainerBinaries NetworkIsolationUnregisterForAppContainerChanges          | NET_FW_ACTION NET_FW_AUTHENTICATE_TYPE NET_FW_EDGE_TRAVERSAL_TYPE NET_FW_IP_PROTOCOL NET_FW_IP_VERSION NET_FW_MODIFY_STATE NET_FW_POLICY_TYPE NET_FW_PROFILE_TYPE NET_FW_PROFILE_TYPE2 NET_FW_RULE_CATEGORY NET_FW_RULE_DIRECTION NET_FW_SCOPE NET_FW_SERVICE_TYPE INET_FIREWALL_AC_CREATION_TYPE NETISO_ERROR_TYPE NETISO_FLAG NETISO_GEID INET_FIREWALL_AC_CHANGE_TYPE   | INET_FIREWALL_AC_BINARIES INET_FIREWALL_AC_CHANGE INET_FIREWALL_AC_CAPABILITIES INET_FIREWALL_APP_CONTAINER UNIONType                | INetFwAuthorizedApplication INetFwAuthorizedApplications INetFwIcmpSettings INetFwMgr INetFwOpenPort INetFwOpenPorts INetFwPolicy INetFwPolicy2 INetFwProduct INetFwProducts INetFwProfile INetFwRemoteAdminSettings INetFwRule INetFwRule2 INetFwRule3 INetFwRules INetFwService INetFwServiceRestriction INetFwServices 
