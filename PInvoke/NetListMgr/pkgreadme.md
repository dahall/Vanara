![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.NetListMgr NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.NetListMgr?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (interfaces, structures and constants) for Windows NetListMgr COM object.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.NetListMgr**

Enumerations | Structures | Interfaces
--- | --- | ---
NLM_CONNECTION_COST NLM_CONNECTION_PROPERTY_CHANGE NLM_CONNECTIVITY NLM_DOMAIN_TYPE NLM_ENUM_NETWORK NLM_INTERNET_CONNECTIVITY NLM_NETWORK_CATEGORY NLM_NETWORK_CLASS NLM_NETWORK_PROPERTY_CHANGE     | NLM_DATAPLAN_STATUS NLM_SIMULATED_PROFILE_INFO NLM_SOCKADDR NLM_USAGE_DATA          | IEnumNetworkConnections IEnumNetworks INetwork INetworkConnection INetworkConnectionCost INetworkConnectionCostEvents INetworkConnectionEvents INetworkCostManager INetworkCostManagerEvents INetworkEvents INetworkListManager INetworkListManagerEvents 
