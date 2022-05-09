![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.Wer NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.Wer?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants imported from Windows Wer.dll.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.Wer

Functions | Enumerations | Structures
--- | --- | ---
WerAddExcludedApplication<br>WerFreeString<br>WerRemoveExcludedApplication<br>WerReportAddDump<br>WerReportAddFile<br>WerReportCloseHandle<br>WerReportCreate<br>WerReportSetParameter<br>WerReportSetUIOption<br>WerReportSubmit<br>WerStoreClose<br>WerStoreGetFirstReportKey<br>WerStoreGetNextReportKey<br>WerStoreOpen<br>WerStoreQueryReportMetadataV2<br> | MINIDUMP_TYPE<br>THREAD_WRITE_FLAGS<br>MODULE_WRITE_FLAGS<br>REPORT_STORE_TYPES<br>WER_CONSENT<br>WER_DUMP<br>WER_DUMP_MASK<br>WER_DUMP_TYPE<br>WER_P<br>WER_SUBMIT<br><br><br><br><br><br> | HREPORT<br>HREPORTSTORE<br>WER_DUMP_CUSTOM_OPTIONS<br>WER_EXCEPTION_INFORMATION<br>WER_REPORT_INFORMATION<br>WER_REPORT_METADATA_V2<br>WER_REPORT_PARAMETER<br>WER_REPORT_SIGNATURE<br><br><br><br><br><br><br><br>
