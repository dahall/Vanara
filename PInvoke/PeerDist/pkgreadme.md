![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.PeerDist NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.PeerDist?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows PeerDist.dll for the Peer Distribution API, which supports the Branch Cache feature in Windows 7.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.PeerDist**

Functions | Enumerations | Structures
--- | --- | ---
PeerDistClientAddContentInformation PeerDistClientAddData PeerDistClientBlockRead PeerDistClientCancelAsyncOperation PeerDistClientCloseContent PeerDistClientCompleteContentInformation PeerDistClientFlushContent PeerDistClientGetInformationByHandle PeerDistClientOpenContent PeerDistClientStreamRead PeerDistGetOverlappedResult PeerDistGetStatus PeerDistGetStatusEx PeerDistRegisterForStatusChangeNotification PeerDistRegisterForStatusChangeNotificationEx PeerDistServerCancelAsyncOperation PeerDistServerCloseContentInformation PeerDistServerCloseStreamHandle PeerDistServerOpenContentInformation PeerDistServerOpenContentInformationEx PeerDistServerPublishAddToStream PeerDistServerPublishCompleteStream PeerDistServerPublishStream PeerDistServerRetrieveContentInformation PeerDistServerUnpublish PeerDistShutdown PeerDistStartup PeerDistUnregisterForStatusChangeNotification  | PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS PEERDIST_STATUS                            | PEERDIST_CLIENT_BASIC_INFO PEERDIST_CONTENT_TAG PEERDIST_PUBLICATION_OPTIONS PEERDIST_RETRIEVAL_OPTIONS PEERDIST_STATUS_INFO PEERDIST_CONTENT_HANDLE PEERDIST_CONTENTINFO_HANDLE PEERDIST_INSTANCE_HANDLE PEERDIST_STREAM_HANDLE                    
