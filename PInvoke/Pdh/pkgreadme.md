![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Pdh NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Pdh?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants imported from Windows Pdh.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Pdh**

Functions | Enumerations | Structures
--- | --- | ---
PdhAddCounter PdhAddEnglishCounter PdhBindInputDataSource PdhBrowseCounters PdhBrowseCountersH PdhCalculateCounterFromRawValue PdhCloseLog PdhCloseQuery PdhCollectQueryData PdhCollectQueryDataEx PdhCollectQueryDataWithTime PdhComputeCounterStatistics PdhConnectMachine PdhEnumLogSetNames PdhEnumMachines PdhEnumMachinesH PdhEnumObjectItems PdhEnumObjectItemsH PdhEnumObjects PdhEnumObjectsH PdhExpandCounterPath PdhExpandWildCardPath PdhExpandWildCardPathH PdhFormatFromRawValue PdhGetCounterInfo PdhGetCounterTimeBase PdhGetDataSourceTimeRange PdhGetDataSourceTimeRangeH PdhGetDefaultPerfCounter PdhGetDefaultPerfCounterH PdhGetDefaultPerfObject PdhGetDefaultPerfObjectH PdhGetDllVersion PdhGetFormattedCounterArray PdhGetFormattedCounterValue PdhGetLogFileSize PdhGetRawCounterArray PdhGetRawCounterValue PdhIsRealTimeQuery PdhLookupPerfIndexByName PdhLookupPerfNameByIndex PdhMakeCounterPath PdhOpenLog PdhOpenQuery PdhOpenQueryH PdhParseCounterPath PdhParseInstanceName PdhReadRawLogRecord PdhRemoveCounter PdhSelectDataSource PdhSetCounterScaleFactor PdhSetDefaultRealTimeDataSource PdhSetQueryTimeRange PdhUpdateLog PdhUpdateLogFileCatalog PdhValidatePath PdhValidatePathExWA PdhValidatePathExWW  | BrowseFlag CounterType PDH_FMT PDH_LOG_TYPE PDH_PATH PdhExpandFlags PdhLogAccess PdhSelectDataSourceFlags PERF_DETAIL                                                   | PDH_BROWSE_DLG_CONFIG PDH_BROWSE_DLG_CONFIG_H PDH_COUNTER_INFO PDH_COUNTER_INFO_MGD PDH_COUNTER_PATH_ELEMENTS PDH_DATA_ITEM_PATH_ELEMENTS PDH_FMT_COUNTERVALUE PDH_FMT_COUNTERVALUE_ITEM PDH_RAW_COUNTER PDH_RAW_COUNTER_ITEM PDH_RAW_LOG_RECORD PDH_STATISTICS PDH_TIME_INFO PDH_HCOUNTER PDH_HLOG PDH_HQUERY                                           
