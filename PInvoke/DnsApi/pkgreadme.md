![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.DnsApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.DnsApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants imported from Windows DnsApi.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.DnsApi**

Functions | Enumerations | Structures
--- | --- | ---
DnsAcquireContextHandle_ DnsCancelQuery DnsCancelQueryRaw DnsExtractRecordsFromMessage_W DnsFree DnsFreeCustomServers DnsFreeProxyName DnsGetApplicationSettings DnsGetCacheDataTable DnsGetProxyInformation DnsModifyRecordsInSet_ DnsNameCompare_ DnsQuery_ DnsQueryConfig DnsQueryEx DnsQueryRaw DnsQueryRawResultFree DnsRecordCompare DnsRecordCopyEx DnsRecordSetCompare DnsRecordSetCopyEx DnsRecordSetDetach DnsReleaseContextHandle DnsReplaceRecordSet DnsServiceBrowse DnsServiceBrowseCancel DnsServiceConstructInstance DnsServiceCopyInstance DnsServiceDeRegister DnsServiceFreeInstance DnsServiceRegister DnsServiceRegisterCancel DnsServiceResolve DnsServiceResolveCancel DnsSetApplicationSettings DnsStartMulticastQuery DnsStopMulticastQuery DnsValidateName_ DnsValidateServerStatus DnsWriteQuestionToBuffer_W                    | ATMA DNS_APP_SETTINGSF DNS_CHARSET DNS_CLASS DNS_CONFIG_FLAG DNS_CONFIG_TYPE DNS_CUSTOM_SERVER_FLAGS DNS_CUSTOM_SERVER_TYPE DNS_FREE_TYPE DNS_NAME_FORMAT DNS_OPCODE DNS_PROTOCOL DNS_PROXY_INFORMATION_TYPE DNS_QUERY_OPTIONS DNS_RCODE DNS_SECTION DNS_TKEY_MODE DNS_TYPE DNS_UPDATE DNS_WINS_FLAG DnsServerStatus                                       | DNS_A_DATA DNS_AAAA_DATA DNS_ADDR DNS_ADDR_ARRAY DNS_APPLICATION_SETTINGS DNS_ATMA_DATA DNS_CACHE_ENTRY DNS_CUSTOM_SERVER DNS_DHCID_DATA DNS_DS_DATA DNS_HEADER DNS_KEY_DATA DNS_LOC_DATA DNS_MESSAGE_BUFFER DNS_MINFO_DATA DNS_MX_DATA DNS_NAPTR_DATA DNS_NSEC_DATA DNS_NSEC3_DATA DNS_NSEC3PARAM_DATA DNS_NULL_DATA DNS_NXT_DATA DNS_OPT_DATA DNS_PROXY_INFORMATION DNS_PTR_DATA DNS_QUERY_CANCEL DNS_QUERY_RAW_CANCEL DNS_QUERY_RAW_REQUEST DNS_QUERY_RAW_RESULT DNS_QUERY_REQUEST DNS_QUERY_REQUEST3 DNS_QUERY_RESULT DNS_RECORD DNS_RECORD_FLAGS DNS_RRSET DNS_SERVICE_BROWSE_REQUEST DNS_SERVICE_CANCEL DNS_SERVICE_INSTANCE DNS_SERVICE_REGISTER_REQUEST DNS_SERVICE_RESOLVE_REQUEST DNS_SIG_DATA DNS_SOA_DATA DNS_SRV_DATA DNS_TKEY_DATA DNS_TLSA_DATA DNS_TSIG_DATA DNS_TXT_DATA DNS_UNKNOWN_DATA DNS_WINS_DATA DNS_WINSR_DATA DNS_WIRE_QUESTION DNS_WIRE_RECORD DNS_WKS_DATA IP4_ARRAY MDNS_QUERY_HANDLE MDNS_QUERY_REQUEST HDNSCONTEXT DNS_SERVICE_BROWSE_REQUEST_CALLBACK 
