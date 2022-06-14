![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.NTDSApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.NTDSApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows NTDSApi.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.NTDSApi**

Functions | Enumerations | Structures
--- | --- | ---
DsAddSidHistory DsBind DsBindByInstance DsBindingSetTimeout DsBindToISTG DsBindWithCred DsBindWithSpn DsBindWithSpnEx DsClientMakeSpnForTargetServer DsCrackNames DsCrackSpn DsCrackUnquotedMangledRdn DsFreeDomainControllerInfo DsFreeNameResult DsFreePasswordCredentials DsFreeSchemaGuidMap DsFreeSpnArray DsGetDomainControllerInfo DsGetRdnW DsGetSpn DsInheritSecurityIdentity DsIsMangledDn DsIsMangledRdnValue DsListDomainsInSite DsListInfoForServer DsListRoles DsListServersForDomainInSite DsListServersInSite DsListSites DsMakePasswordCredentials DsMakeSpn DsMapSchemaGuids DsQuerySitesByCost DsQuerySitesFree DsQuoteRdnValue DsRemoveDsDomain DsRemoveDsServer DsReplicaAdd DsReplicaConsistencyCheck DsReplicaDel DsReplicaFreeInfo DsReplicaGetInfo2W DsReplicaGetInfoW DsReplicaModify DsReplicaSync DsReplicaSyncAll DsReplicaUpdateRefs DsReplicaVerifyObjects DsServerRegisterSpn DsUnBind DsUnquoteRdnValue DsWriteAccountSpn  | DS_MANGLE_FOR DS_KCC_TASKID DS_NAME_ERROR DS_NAME_FLAGS DS_NAME_FORMAT DS_REPL_INFO_TYPE DS_REPL_OP_TYPE DS_REPSYNCALL_ERROR DS_REPSYNCALL_EVENT DS_SPN_NAME_TYPE DS_SPN_WRITE_OP DsBindFlags DsKCCFlags DsReplicaAddOptions DsReplicaDelOptions DsReplInfoFlags DsReplModFieldFlags DsReplModOptions DsReplNeighborFlags DsReplSyncAllFlags DsReplSyncOptions DsReplUpdateOptions DsReplVerifyOptions DsSchemaGuidType ScheduleType                             | DCInfoHandle DS_DOMAIN_CONTROLLER_INFO_1 DS_DOMAIN_CONTROLLER_INFO_2 DS_DOMAIN_CONTROLLER_INFO_3 DS_NAME_RESULT DS_NAME_RESULT_ITEM DS_REPL_ATTR_META_DATA DS_REPL_ATTR_META_DATA_2 DS_REPL_ATTR_META_DATA_BLOB DS_REPL_ATTR_VALUE_META_DATA DS_REPL_ATTR_VALUE_META_DATA_2 DS_REPL_ATTR_VALUE_META_DATA_EXT DS_REPL_CURSOR DS_REPL_CURSOR_2 DS_REPL_CURSOR_3W DS_REPL_CURSOR_BLOB DS_REPL_CURSORS DS_REPL_CURSORS_2 DS_REPL_CURSORS_3W DS_REPL_KCC_DSA_FAILURESW DS_REPL_KCC_DSA_FAILUREW DS_REPL_KCC_DSA_FAILUREW_BLOB DS_REPL_NEIGHBOR DS_REPL_NEIGHBORS DS_REPL_NEIGHBORW_BLOB DS_REPL_OBJ_META_DATA DS_REPL_OBJ_META_DATA_2 DS_REPL_OPW DS_REPL_OPW_BLOB DS_REPL_PENDING_OPSW DS_REPL_QUEUE_STATISTICSW DS_REPL_VALUE_META_DATA DS_REPL_VALUE_META_DATA_2 DS_REPL_VALUE_META_DATA_BLOB DS_REPL_VALUE_META_DATA_BLOB_EXT DS_REPL_VALUE_META_DATA_EXT DS_REPSYNCALL_ERRINFO DS_REPSYNCALL_UPDATE DS_SCHEMA_GUID_MAP DS_SITE_COST_INFO SCHEDULE_HEADER SpnArrayHandle SCHEDULE          
