![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.QoS NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.QoS?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from dlls associated with Windows Quality of Service (QOS); specifically qwave.dll and traffic.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.QoS**

Functions | Enumerations | Structures
--- | --- | ---
QOSAddSocketToFlow QOSCancel QOSCloseHandle QOSCreateHandle QOSEnumerateFlows QOSNotifyFlow QOSQueryFlow QOSRemoveSocketFromFlow QOSSetFlow QOSStartTrackingClient QOSStopTrackingClient TcAddFilter TcAddFlow TcCloseInterface TcDeleteFilter TcDeleteFlow TcDeregisterClient TcEnumerateFlows TcEnumerateInterfaces TcGetFlowName TcModifyFlow TcOpenInterface TcQueryFlow TcQueryInterface TcRegisterClient TcSetFlow TcSetInterface                         | NDIS_PROTOCOL_ID QOS_OBJ_TYPE TC_NONCONF QOS_FLOW_TYPE QOS_FLOWRATE_REASON QOS_NOTIFY_FLOW QOS_QUERY_FLOW QOS_QUERYFLOW QOS_SET_FLOW QOS_SHAPING QOS_TRAFFIC_TYPE AD_FLAG FilterType RSVP TC_NOTIFY                                     | NETWORK_ADDRESS NETWORK_ADDRESS_LIST QOS_DIFFSERV QOS_DIFFSERV_RULE QOS_DS_CLASS QOS_FRIENDLY_NAME QOS_TCP_TRAFFIC QOS_TRAFFIC_CLASS QOS_OBJECT_HDR QOS_SD_MODE QOS_SHAPING_RATE QOS_FLOW_FUNDAMENTALS QOS_FLOWRATE_OUTGOING QOS_PACKET_PRIORITY QOS_VERSION AD_GENERAL_PARAMS AD_GUARANTEED CONTROL_SERVICE FLOWDESCRIPTOR PARAM_BUFFER QOS_DESTADDR RSVP_ADSPEC RSVP_FILTERSPEC RSVP_FILTERSPEC_V4 RSVP_FILTERSPEC_V4_GPI RSVP_FILTERSPEC_V6 RSVP_FILTERSPEC_V6_FLOW RSVP_FILTERSPEC_V6_GPI RSVP_POLICY RSVP_POLICY_INFO RSVP_RESERVE_INFO RSVP_STATUS_INFO HQOS ADDRESS_LIST_DESCRIPTOR ENUMERATION_BUFFER IP_PATTERN IPX_PATTERN TC_GEN_FILTER TC_IFC_DESCRIPTOR TCI_CLIENT_FUNC_LIST HCLIENT HFILTER HFLOW HFLOWENUM HIFC UNION UNION IPX PORTS ICMP 
