![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.SearchApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.SearchApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants imported from Windows Search.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.SearchApi**

Enumerations | Structures | Interfaces
--- | --- | ---
AUTH_TYPE CatalogPausedReason CatalogStatus CHUNK_BREAKTYPE CHUNKSTATE CLUSION_REASON FOLLOW_FLAGS IFILTER_FLAGS IFILTER_INIT PRIORITIZE_FLAGS PRIORITY_LEVEL PROXY_ACCESS ROWSETEVENT_ITEMSTATE ROWSETEVENT_TYPE SEARCH_INDEXING_PHASE SEARCH_KIND_OF_CHANGE SEARCH_NOTIFICATION_PRIORITY SEARCH_QUERY_SYNTAX SEARCH_TERM_EXPANSION CONDITION_CREATION_OPTIONS QUERY_PARSER_MANAGER_OPTION STRUCTURED_QUERY_MULTIOPTION STRUCTURED_QUERY_RESOLVE_OPTION STRUCTURED_QUERY_SINGLE_OPTION CONDITION_OPERATION CONDITION_TYPE                     | AUTHENTICATION_INFO FILTERED_DATA_SOURCES FILTERREGION FULLPROPSPEC INCREMENTAL_ACCESS_INFO ITEM_INFO PROXY_INFO SEARCH_COLUMN_PROPERTIES SEARCH_ITEM_CHANGE SEARCH_ITEM_INDEXING_STATUS SEARCH_ITEM_PERSISTENT_CHANGE STAT_CHUNK TIMEOUT_INFO                                  | IEnumSearchRoots IEnumSearchScopeRules IFilter ILoadFilter IOpLockStatus IProtocolHandlerSite IRowsetEvents IRowsetPrioritization ISearchCatalogManager ISearchCatalogManager2 ISearchCrawlScopeManager ISearchCrawlScopeManager2 ISearchItemsChangedSink ISearchLanguageSupport ISearchManager ISearchManager2 ISearchNotifyInlineSite ISearchPersistentItemsChangedSink ISearchProtocol ISearchProtocol2 ISearchProtocolThreadContext ISearchQueryHelper ISearchRoot ISearchScopeRule ISearchViewChangedSink IUrlAccessor IUrlAccessor2 IUrlAccessor3 IUrlAccessor4 IOpenSearchSource ISearchFolderItemFactory IConditionFactory IConditionFactory2 IEntity INamedEntity IQueryParser IQueryParserManager IQuerySolution IRelationship ISchemaLocalizerSupport ISchemaProvider ITokenCollection ICondition ICondition2 IRichChunk 
