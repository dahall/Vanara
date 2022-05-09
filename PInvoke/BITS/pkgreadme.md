![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.BITS NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.BITS?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (interfaces, structures and constants) imported for Windows BITS (Background Intelligent Transfer Service).

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.BITS

Enumerations | Structures | Interfaces
--- | --- | ---
BG_AUTH_SCHEME<br>BG_AUTH_TARGET<br>BG_CERT_STORE_LOCATION<br>BG_COPY_FILE<br>BG_ENABLE_PEERCACHING<br>BG_ERROR_CONTEXT<br>BG_HTTP_SECURITY<br>BG_JOB_ENABLE_PEERCACHING<br>BG_JOB_ENUM<br>BG_JOB_PRIORITY<br>BG_JOB_PROXY_USAGE<br>BG_JOB_STATE<br>BG_JOB_TYPE<br>BG_NOTIFY<br>BG_TOKEN<br>BITS_COST_STATE<br>BITS_FILE_PROPERTY_ID<br>BITS_JOB_PROPERTY_ID<br><br><br><br><br><br><br><br><br><br><br> | BG_AUTH_CREDENTIALS<br>BG_FILE_INFO<br>BG_FILE_PROGRESS<br>BG_FILE_RANGE<br>BG_JOB_PROGRESS<br>BG_JOB_REPLY_PROGRESS<br>BG_JOB_TIMES<br>BITS_FILE_PROPERTY_VALUE<br>BITS_JOB_PROPERTY_VALUE<br>BG_AUTH_CREDENTIALS_UNION<br>BG_BASIC_CREDENTIALS<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | IBackgroundCopyCallback<br>IBackgroundCopyCallback2<br>IBackgroundCopyCallback3<br>IBackgroundCopyError<br>IBackgroundCopyFile<br>IBackgroundCopyFile2<br>IBackgroundCopyFile3<br>IBackgroundCopyFile4<br>IBackgroundCopyFile5<br>IBackgroundCopyFile6<br>IBackgroundCopyJob<br>IBackgroundCopyJob2<br>IBackgroundCopyJob3<br>IBackgroundCopyJob4<br>IBackgroundCopyJob5<br>IBackgroundCopyJobHttpOptions<br>IBackgroundCopyJobHttpOptions2<br>IBackgroundCopyJobHttpOptions3<br>IBackgroundCopyManager<br>IBitsPeer<br>IBitsPeerCacheAdministration<br>IBitsPeerCacheRecord<br>IBackgroundCopyServerCertificateValidationCallback<br>IBitsTokenOptions<br>IEnumBackgroundCopyFiles<br>IEnumBackgroundCopyJobs<br>IEnumBitsPeerCacheRecords<br>IEnumBitsPeers<br>
