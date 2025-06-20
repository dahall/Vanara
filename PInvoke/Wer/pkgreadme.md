![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.Wer NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Wer?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants imported from Windows Wer.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.Wer**

Functions | Enumerations | Structures
--- | --- | ---
WerAddExcludedApplication WerFreeString WerRemoveExcludedApplication WerReportAddDump WerReportAddFile WerReportCloseHandle WerReportCreate WerReportSetParameter WerReportSetUIOption WerReportSubmit WerStoreClose WerStoreGetFirstReportKey WerStoreGetNextReportKey WerStoreOpen WerStoreQueryReportMetadataV2  | MINIDUMP_TYPE THREAD_WRITE_FLAGS MODULE_WRITE_FLAGS REPORT_STORE_TYPES WER_CONSENT WER_DUMP WER_DUMP_MASK WER_DUMP_TYPE WER_P WER_SUBMIT       | WER_DUMP_CUSTOM_OPTIONS WER_EXCEPTION_INFORMATION WER_REPORT_INFORMATION WER_REPORT_METADATA_V2 WER_REPORT_PARAMETER WER_REPORT_SIGNATURE HREPORT HREPORTSTORE        
