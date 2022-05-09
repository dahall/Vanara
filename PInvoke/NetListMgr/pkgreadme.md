![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.NetListMgr NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.NetListMgr?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (interfaces, structures and constants) for Windows NetListMgr COM object.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.NetListMgr

Enumerations | Structures | Interfaces
--- | --- | ---
NLM_CONNECTION_COST<br>NLM_CONNECTION_PROPERTY_CHANGE<br>NLM_CONNECTIVITY<br>NLM_DOMAIN_TYPE<br>NLM_ENUM_NETWORK<br>NLM_INTERNET_CONNECTIVITY<br>NLM_NETWORK_CATEGORY<br>NLM_NETWORK_CLASS<br>NLM_NETWORK_PROPERTY_CHANGE<br><br><br><br> | NLM_DATAPLAN_STATUS<br>NLM_SIMULATED_PROFILE_INFO<br>NLM_SOCKADDR<br>NLM_USAGE_DATA<br><br><br><br><br><br><br><br><br> | IEnumNetworkConnections<br>IEnumNetworks<br>INetwork<br>INetworkConnection<br>INetworkConnectionCost<br>INetworkConnectionCostEvents<br>INetworkConnectionEvents<br>INetworkCostManager<br>INetworkCostManagerEvents<br>INetworkEvents<br>INetworkListManager<br>INetworkListManagerEvents<br>
