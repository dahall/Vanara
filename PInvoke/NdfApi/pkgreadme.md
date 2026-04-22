![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.NdfApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.NdfApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows Network Diagnostic Framework (NdfApi.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.NdfApi**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
NdfCancelIncident<br>NdfCloseIncident<br>NdfCreateConnectivityIncident<br>NdfCreateDNSIncident<br>NdfCreateGroupingIncident<br>NdfCreateInboundIncident<br>NdfCreateIncident<br>NdfCreateNetConnectionIncident<br>NdfCreatePnrpIncident<br>NdfCreateSharingIncident<br>NdfCreateWebIncident<br>NdfCreateWebIncidentEx<br>NdfCreateWinSockIncident<br>NdfDiagnoseIncident<br>NdfExecuteDiagnosis<br>NdfGetTraceFile<br>NdfRepairIncident<br> | ATTRIBUTE_TYPE<br>RCF<br>REPAIR_FLAG<br>REPAIR_RISK<br>REPAIR_SCOPE<br>UI_INFO_TYPE<br>WCN_ATTRIBUTE_TYPE<br>NDF_DIAG<br>NDF_INBOUND_FLAG<br>DF<br>DIAGNOSIS_STATUS<br>PROBLEM_TYPE<br>REPAIR_STATUS<br><br><br><br><br> | DIAG_SOCKADDR<br>HELPER_ATTRIBUTE<br>LIFE_TIME<br>OCTET_STRING<br>RepairInfo<br>RepairInfoEx<br>RootCauseInfo<br>ShellCommandInfo<br>UiInfo<br>DiagnosticsInfo<br>HelperAttributeInfo<br>HYPOTHESIS<br>HypothesisResult<br>NDFHANDLE<br><br><br><br> | INetDiagExtensibleHelper<br>INetDiagHelper<br>INetDiagHelperEx<br>INetDiagHelperInfo<br>INetDiagHelperUtilFactory<br><br><br><br><br><br><br><br><br><br><br><br><br>
