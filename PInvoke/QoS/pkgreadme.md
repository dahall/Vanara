![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.QoS NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.QoS?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from dlls associated with Windows Quality of Service (QOS); specifically qwave.dll and traffic.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.QoS**

Functions | Enumerations | Structures
--- | --- | ---
QOSAddSocketToFlow<br>QOSCancel<br>QOSCloseHandle<br>QOSCreateHandle<br>QOSEnumerateFlows<br>QOSNotifyFlow<br>QOSQueryFlow<br>QOSRemoveSocketFromFlow<br>QOSSetFlow<br>QOSStartTrackingClient<br>QOSStopTrackingClient<br>TcAddFilter<br>TcAddFlow<br>TcCloseInterface<br>TcDeleteFilter<br>TcDeleteFlow<br>TcDeregisterClient<br>TcEnumerateFlows<br>TcEnumerateInterfaces<br>TcGetFlowName<br>TcModifyFlow<br>TcOpenInterface<br>TcQueryFlow<br>TcQueryInterface<br>TcRegisterClient<br>TcSetFlow<br>TcSetInterface<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | NDIS_PROTOCOL_ID<br>QOS_OBJ_TYPE<br>TC_NONCONF<br>QOS_FLOW_TYPE<br>QOS_FLOWRATE_REASON<br>QOS_NOTIFY_FLOW<br>QOS_QUERY_FLOW<br>QOS_QUERYFLOW<br>QOS_SET_FLOW<br>QOS_SHAPING<br>QOS_TRAFFIC_TYPE<br>AD_FLAG<br>FilterType<br>RSVP<br>TC_NOTIFY<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | NETWORK_ADDRESS<br>NETWORK_ADDRESS_LIST<br>QOS_DIFFSERV<br>QOS_DIFFSERV_RULE<br>QOS_DS_CLASS<br>QOS_FRIENDLY_NAME<br>QOS_TCP_TRAFFIC<br>QOS_TRAFFIC_CLASS<br>QOS_OBJECT_HDR<br>QOS_SD_MODE<br>QOS_SHAPING_RATE<br>QOS_FLOW_FUNDAMENTALS<br>QOS_FLOWRATE_OUTGOING<br>QOS_PACKET_PRIORITY<br>QOS_VERSION<br>AD_GENERAL_PARAMS<br>AD_GUARANTEED<br>CONTROL_SERVICE<br>FLOWDESCRIPTOR<br>PARAM_BUFFER<br>QOS_DESTADDR<br>RSVP_ADSPEC<br>RSVP_FILTERSPEC<br>RSVP_FILTERSPEC_V4<br>RSVP_FILTERSPEC_V4_GPI<br>RSVP_FILTERSPEC_V6<br>RSVP_FILTERSPEC_V6_FLOW<br>RSVP_FILTERSPEC_V6_GPI<br>RSVP_POLICY<br>RSVP_POLICY_INFO<br>RSVP_RESERVE_INFO<br>RSVP_STATUS_INFO<br>HQOS<br>ADDRESS_LIST_DESCRIPTOR<br>ENUMERATION_BUFFER<br>IP_PATTERN<br>IPX_PATTERN<br>TC_GEN_FILTER<br>TC_IFC_DESCRIPTOR<br>TCI_CLIENT_FUNC_LIST<br>HCLIENT<br>HFILTER<br>HFLOW<br>HFLOWENUM<br>HIFC<br>UNION<br>UNION<br>IPX<br>PORTS<br>ICMP<br>
