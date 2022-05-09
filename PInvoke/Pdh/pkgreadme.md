![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Pdh NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Pdh?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants imported from Windows Pdh.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Pdh

Functions | Enumerations | Structures
--- | --- | ---
PdhAddCounter<br>PdhAddEnglishCounter<br>PdhBindInputDataSource<br>PdhBrowseCounters<br>PdhBrowseCountersH<br>PdhCalculateCounterFromRawValue<br>PdhCloseLog<br>PdhCloseQuery<br>PdhCollectQueryData<br>PdhCollectQueryDataEx<br>PdhCollectQueryDataWithTime<br>PdhComputeCounterStatistics<br>PdhConnectMachine<br>PdhEnumLogSetNames<br>PdhEnumMachines<br>PdhEnumMachinesH<br>PdhEnumObjectItems<br>PdhEnumObjectItemsH<br>PdhEnumObjects<br>PdhEnumObjectsH<br>PdhExpandCounterPath<br>PdhExpandWildCardPath<br>PdhExpandWildCardPathH<br>PdhFormatFromRawValue<br>PdhGetCounterInfo<br>PdhGetCounterTimeBase<br>PdhGetDataSourceTimeRange<br>PdhGetDataSourceTimeRangeH<br>PdhGetDefaultPerfCounter<br>PdhGetDefaultPerfCounterH<br>PdhGetDefaultPerfObject<br>PdhGetDefaultPerfObjectH<br>PdhGetDllVersion<br>PdhGetFormattedCounterArray<br>PdhGetFormattedCounterValue<br>PdhGetLogFileSize<br>PdhGetRawCounterArray<br>PdhGetRawCounterValue<br>PdhIsRealTimeQuery<br>PdhLookupPerfIndexByName<br>PdhLookupPerfNameByIndex<br>PdhMakeCounterPath<br>PdhOpenLog<br>PdhOpenQuery<br>PdhOpenQueryH<br>PdhParseCounterPath<br>PdhParseInstanceName<br>PdhReadRawLogRecord<br>PdhRemoveCounter<br>PdhSelectDataSource<br>PdhSetCounterScaleFactor<br>PdhSetDefaultRealTimeDataSource<br>PdhSetQueryTimeRange<br>PdhUpdateLog<br>PdhUpdateLogFileCatalog<br>PdhValidatePath<br>PdhValidatePathExWA<br>PdhValidatePathExWW<br> | BrowseFlag<br>CounterType<br>PDH_FMT<br>PDH_LOG_TYPE<br>PDH_PATH<br>PdhExpandFlags<br>PdhLogAccess<br>PdhSelectDataSourceFlags<br>PERF_DETAIL<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | PDH_BROWSE_DLG_CONFIG<br>PDH_BROWSE_DLG_CONFIG_H<br>PDH_COUNTER_INFO<br>PDH_COUNTER_PATH_ELEMENTS<br>PDH_DATA_ITEM_PATH_ELEMENTS<br>PDH_FMT_COUNTERVALUE<br>PDH_FMT_COUNTERVALUE_ITEM<br>PDH_HCOUNTER<br>PDH_HLOG<br>PDH_HQUERY<br>PDH_RAW_COUNTER<br>PDH_RAW_COUNTER_ITEM<br>PDH_RAW_LOG_RECORD<br>PDH_STATISTICS<br>PDH_TIME_INFO<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
