![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.NTDSApi NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.NTDSApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows NTDSApi.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.NTDSApi

Functions | Enumerations | Structures
--- | --- | ---
DsAddSidHistory<br>DsBind<br>DsBindByInstance<br>DsBindingSetTimeout<br>DsBindToISTG<br>DsBindWithCred<br>DsBindWithSpn<br>DsBindWithSpnEx<br>DsClientMakeSpnForTargetServer<br>DsCrackNames<br>DsCrackSpn<br>DsCrackUnquotedMangledRdn<br>DsFreeDomainControllerInfo<br>DsFreeNameResult<br>DsFreePasswordCredentials<br>DsFreeSchemaGuidMap<br>DsFreeSpnArray<br>DsGetDomainControllerInfo<br>DsGetRdnW<br>DsGetSpn<br>DsInheritSecurityIdentity<br>DsIsMangledDn<br>DsIsMangledRdnValue<br>DsListDomainsInSite<br>DsListInfoForServer<br>DsListRoles<br>DsListServersForDomainInSite<br>DsListServersInSite<br>DsListSites<br>DsMakePasswordCredentials<br>DsMakeSpn<br>DsMapSchemaGuids<br>DsQuerySitesByCost<br>DsQuerySitesFree<br>DsQuoteRdnValue<br>DsRemoveDsDomain<br>DsRemoveDsServer<br>DsReplicaAdd<br>DsReplicaConsistencyCheck<br>DsReplicaDel<br>DsReplicaFreeInfo<br>DsReplicaGetInfo2W<br>DsReplicaGetInfoW<br>DsReplicaModify<br>DsReplicaSync<br>DsReplicaSyncAll<br>DsReplicaUpdateRefs<br>DsReplicaVerifyObjects<br>DsServerRegisterSpn<br>DsUnBind<br>DsUnquoteRdnValue<br>DsWriteAccountSpn<br> | DS_MANGLE_FOR<br>DS_KCC_TASKID<br>DS_NAME_ERROR<br>DS_NAME_FLAGS<br>DS_NAME_FORMAT<br>DS_REPL_INFO_TYPE<br>DS_REPL_OP_TYPE<br>DS_REPSYNCALL_ERROR<br>DS_REPSYNCALL_EVENT<br>DS_SPN_NAME_TYPE<br>DS_SPN_WRITE_OP<br>DsBindFlags<br>DsKCCFlags<br>DsReplicaAddOptions<br>DsReplicaDelOptions<br>DsReplInfoFlags<br>DsReplModFieldFlags<br>DsReplModOptions<br>DsReplNeighborFlags<br>DsReplSyncAllFlags<br>DsReplSyncOptions<br>DsReplUpdateOptions<br>DsReplVerifyOptions<br>DsSchemaGuidType<br>ScheduleType<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | DCInfoHandle<br>DS_DOMAIN_CONTROLLER_INFO_1<br>DS_DOMAIN_CONTROLLER_INFO_2<br>DS_DOMAIN_CONTROLLER_INFO_3<br>DS_NAME_RESULT<br>DS_NAME_RESULT_ITEM<br>DS_REPL_ATTR_META_DATA<br>DS_REPL_ATTR_META_DATA_2<br>DS_REPL_ATTR_META_DATA_BLOB<br>DS_REPL_ATTR_VALUE_META_DATA<br>DS_REPL_ATTR_VALUE_META_DATA_2<br>DS_REPL_ATTR_VALUE_META_DATA_EXT<br>DS_REPL_CURSOR<br>DS_REPL_CURSOR_2<br>DS_REPL_CURSOR_3W<br>DS_REPL_CURSOR_BLOB<br>DS_REPL_CURSORS<br>DS_REPL_CURSORS_2<br>DS_REPL_CURSORS_3W<br>DS_REPL_KCC_DSA_FAILURESW<br>DS_REPL_KCC_DSA_FAILUREW<br>DS_REPL_KCC_DSA_FAILUREW_BLOB<br>DS_REPL_NEIGHBOR<br>DS_REPL_NEIGHBORS<br>DS_REPL_NEIGHBORW_BLOB<br>DS_REPL_OBJ_META_DATA<br>DS_REPL_OBJ_META_DATA_2<br>DS_REPL_OPW<br>DS_REPL_OPW_BLOB<br>DS_REPL_PENDING_OPSW<br>DS_REPL_QUEUE_STATISTICSW<br>DS_REPL_VALUE_META_DATA<br>DS_REPL_VALUE_META_DATA_2<br>DS_REPL_VALUE_META_DATA_BLOB<br>DS_REPL_VALUE_META_DATA_BLOB_EXT<br>DS_REPL_VALUE_META_DATA_EXT<br>DS_REPSYNCALL_ERRINFO<br>DS_REPSYNCALL_UPDATE<br>DS_SCHEMA_GUID_MAP<br>DS_SITE_COST_INFO<br>SCHEDULE_HEADER<br>SpnArrayHandle<br>SCHEDULE<br><br><br><br><br><br><br><br><br><br>
