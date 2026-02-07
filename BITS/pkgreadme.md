![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.BITS NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.BITS?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

Complete .NET coverage of Windows BITS (Background Intelligent Transfer Service) functionality. Provides access to all library functions through Windows 11 and gracefully fails when new features are not available on older OS versions.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.BITS**

Classes | Structures | Enumerations
--- | --- | ---
BackgroundCopyException BackgroundCopyFileCollection BackgroundCopyFileInfo BackgroundCopyFileRange BackgroundCopyFileRangesTransferredEventArgs BackgroundCopyFileTransferredEventArgs BackgroundCopyJob BackgroundCopyJobCollection BackgroundCopyJobCredential BackgroundCopyJobCredentials BackgroundCopyJobEventArgs BackgroundCopyManager CachePeer CachePeers PeerCacheAdministration PeerCacheRecord PeerCacheRecords  | BackgroundCopyFileRange BackgroundCopyJobProgress BackgroundCopyJobReplyProgress                | BackgroundCopyACLFlags BackgroundCopyCost BackgroundCopyErrorContext BackgroundCopyJobCredentialScheme BackgroundCopyJobCredentialTarget BackgroundCopyJobEnablePeerCaching BackgroundCopyJobNotify BackgroundCopyJobPriority BackgroundCopyJobSecurity BackgroundCopyJobState BackgroundCopyJobType PeerCaching      
