![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.DnsApi NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.DnsApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants imported from Windows DnsApi.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.DnsApi

Functions | Enumerations | Structures
--- | --- | ---
DnsAcquireContextHandle_<br>DnsCancelQuery<br>DnsExtractRecordsFromMessage_W<br>DnsFree<br>DnsFreeCustomServers<br>DnsFreeProxyName<br>DnsGetApplicationSettings<br>DnsGetCacheDataTable<br>DnsGetProxyInformation<br>DnsModifyRecordsInSet_<br>DnsNameCompare_<br>DnsQuery_<br>DnsQueryConfig<br>DnsQueryEx<br>DnsRecordCompare<br>DnsRecordCopyEx<br>DnsRecordSetCompare<br>DnsRecordSetCopyEx<br>DnsRecordSetDetach<br>DnsReleaseContextHandle<br>DnsReplaceRecordSet<br>DnsServiceBrowse<br>DnsServiceBrowseCancel<br>DnsServiceConstructInstance<br>DnsServiceCopyInstance<br>DnsServiceDeRegister<br>DnsServiceFreeInstance<br>DnsServiceRegister<br>DnsServiceRegisterCancel<br>DnsServiceResolve<br>DnsServiceResolveCancel<br>DnsSetApplicationSettings<br>DnsStartMulticastQuery<br>DnsStopMulticastQuery<br>DnsValidateName_<br>DnsValidateServerStatus<br>DnsWriteQuestionToBuffer_W<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | ATMA<br>DNS_APP_SETTINGSF<br>DNS_CHARSET<br>DNS_CLASS<br>DNS_CONFIG_FLAG<br>DNS_CONFIG_TYPE<br>DNS_CUSTOM_SERVER_FLAGS<br>DNS_CUSTOM_SERVER_TYPE<br>DNS_FREE_TYPE<br>DNS_NAME_FORMAT<br>DNS_OPCODE<br>DNS_PROXY_INFORMATION_TYPE<br>DNS_QUERY_OPTIONS<br>DNS_RCODE<br>DNS_SECTION<br>DNS_TKEY_MODE<br>DNS_TYPE<br>DNS_UPDATE<br>DNS_WINS_FLAG<br>DnsServerStatus<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | DNS_A_DATA<br>DNS_AAAA_DATA<br>DNS_ADDR<br>DNS_ADDR_ARRAY<br>DNS_APPLICATION_SETTINGS<br>DNS_ATMA_DATA<br>DNS_CACHE_ENTRY<br>DNS_CUSTOM_SERVER<br>DNS_DHCID_DATA<br>DNS_DS_DATA<br>DNS_HEADER<br>DNS_KEY_DATA<br>DNS_LOC_DATA<br>DNS_MESSAGE_BUFFER<br>DNS_MINFO_DATA<br>DNS_MX_DATA<br>DNS_NAPTR_DATA<br>DNS_NSEC_DATA<br>DNS_NSEC3_DATA<br>DNS_NSEC3PARAM_DATA<br>DNS_NULL_DATA<br>DNS_NXT_DATA<br>DNS_OPT_DATA<br>DNS_PROXY_INFORMATION<br>DNS_PTR_DATA<br>DNS_QUERY_CANCEL<br>DNS_QUERY_REQUEST<br>DNS_QUERY_RESULT<br>DNS_RECORD<br>DNS_RECORD_FLAGS<br>DNS_RRSET<br>DNS_SERVICE_BROWSE_REQUEST<br>DNS_SERVICE_CANCEL<br>DNS_SERVICE_INSTANCE<br>DNS_SERVICE_REGISTER_REQUEST<br>DNS_SERVICE_RESOLVE_REQUEST<br>DNS_SIG_DATA<br>DNS_SOA_DATA<br>DNS_SRV_DATA<br>DNS_TKEY_DATA<br>DNS_TLSA_DATA<br>DNS_TSIG_DATA<br>DNS_TXT_DATA<br>DNS_UNKNOWN_DATA<br>DNS_WINS_DATA<br>DNS_WINSR_DATA<br>DNS_WIRE_QUESTION<br>DNS_WIRE_RECORD<br>DNS_WKS_DATA<br>IP4_ARRAY<br>MDNS_QUERY_HANDLE<br>MDNS_QUERY_REQUEST<br>HDNSCONTEXT<br>DNS_SERVICE_BROWSE_REQUEST_CALLBACK<br>
