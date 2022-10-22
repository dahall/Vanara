![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.NdfApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.NdfApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows Network Diagnostic Framework (NdfApi.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.NdfApi**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
NdfCancelIncident NdfCloseIncident NdfCreateConnectivityIncident NdfCreateDNSIncident NdfCreateGroupingIncident NdfCreateInboundIncident NdfCreateIncident NdfCreateNetConnectionIncident NdfCreatePnrpIncident NdfCreateSharingIncident NdfCreateWebIncident NdfCreateWebIncidentEx NdfCreateWinSockIncident NdfDiagnoseIncident NdfExecuteDiagnosis NdfGetTraceFile NdfRepairIncident  | ATTRIBUTE_TYPE RCF REPAIR_FLAG REPAIR_RISK REPAIR_SCOPE UI_INFO_TYPE WCN_ATTRIBUTE_TYPE NDF_DIAG NDF_INBOUND_FLAG DF DIAGNOSIS_STATUS PROBLEM_TYPE REPAIR_STATUS      | DIAG_SOCKADDR HELPER_ATTRIBUTE LIFE_TIME OCTET_STRING RepairInfo RepairInfoEx RootCauseInfo ShellCommandInfo UiInfo NDFHANDLE DiagnosticsInfo HelperAttributeInfo HYPOTHESIS HypothesisResult     | INetDiagExtensibleHelper INetDiagHelper INetDiagHelperEx INetDiagHelperInfo INetDiagHelperUtilFactory             
