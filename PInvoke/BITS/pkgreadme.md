![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.BITS NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.BITS?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (interfaces, structures and constants) imported for Windows BITS (Background Intelligent Transfer Service).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.BITS**

Enumerations | Structures | Interfaces
--- | --- | ---
BG_AUTH_SCHEME BG_AUTH_TARGET BG_CERT_STORE_LOCATION BG_COPY_FILE BG_ENABLE_PEERCACHING BG_ERROR_CONTEXT BG_HTTP_SECURITY BG_JOB_ENABLE_PEERCACHING BG_JOB_ENUM BG_JOB_PRIORITY BG_JOB_PROXY_USAGE BG_JOB_STATE BG_JOB_TYPE BG_NOTIFY BG_TOKEN BITS_COST_STATE BITS_FILE_PROPERTY_ID BITS_JOB_PROPERTY_ID            | BG_AUTH_CREDENTIALS BG_FILE_INFO BG_FILE_PROGRESS BG_FILE_RANGE BG_JOB_PROGRESS BG_JOB_REPLY_PROGRESS BG_JOB_TIMES BITS_FILE_PROPERTY_VALUE BITS_JOB_PROPERTY_VALUE BG_AUTH_CREDENTIALS_UNION BG_BASIC_CREDENTIALS                   | IBackgroundCopyCallback IBackgroundCopyCallback2 IBackgroundCopyCallback3 IBackgroundCopyError IBackgroundCopyFile IBackgroundCopyFile2 IBackgroundCopyFile3 IBackgroundCopyFile4 IBackgroundCopyFile5 IBackgroundCopyFile6 IBackgroundCopyJob IBackgroundCopyJob2 IBackgroundCopyJob3 IBackgroundCopyJob4 IBackgroundCopyJob5 IBackgroundCopyJobHttpOptions IBackgroundCopyJobHttpOptions2 IBackgroundCopyJobHttpOptions3 IBackgroundCopyManager IBackgroundCopyServerCertificateValidationCallback IBitsPeer IBitsPeerCacheAdministration IBitsPeerCacheRecord IBitsTokenOptions IEnumBackgroundCopyFiles IEnumBackgroundCopyJobs IEnumBitsPeerCacheRecords IEnumBitsPeers 
