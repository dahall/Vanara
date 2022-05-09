![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.PeerDist NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.PeerDist?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows PeerDist.dll for the Peer Distribution API, which supports the Branch Cache feature in Windows 7.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.PeerDist

Functions | Enumerations | Structures
--- | --- | ---
PeerDistClientAddContentInformation<br>PeerDistClientAddData<br>PeerDistClientBlockRead<br>PeerDistClientCancelAsyncOperation<br>PeerDistClientCloseContent<br>PeerDistClientCompleteContentInformation<br>PeerDistClientFlushContent<br>PeerDistClientGetInformationByHandle<br>PeerDistClientOpenContent<br>PeerDistClientStreamRead<br>PeerDistGetOverlappedResult<br>PeerDistGetStatus<br>PeerDistGetStatusEx<br>PeerDistRegisterForStatusChangeNotification<br>PeerDistRegisterForStatusChangeNotificationEx<br>PeerDistServerCancelAsyncOperation<br>PeerDistServerCloseContentInformation<br>PeerDistServerCloseStreamHandle<br>PeerDistServerOpenContentInformation<br>PeerDistServerOpenContentInformationEx<br>PeerDistServerPublishAddToStream<br>PeerDistServerPublishCompleteStream<br>PeerDistServerPublishStream<br>PeerDistServerRetrieveContentInformation<br>PeerDistServerUnpublish<br>PeerDistShutdown<br>PeerDistStartup<br>PeerDistUnregisterForStatusChangeNotification<br> | PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS<br>PEERDIST_STATUS<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | PEERDIST_CLIENT_BASIC_INFO<br>PEERDIST_CONTENT_HANDLE<br>PEERDIST_CONTENT_TAG<br>PEERDIST_CONTENTINFO_HANDLE<br>PEERDIST_INSTANCE_HANDLE<br>PEERDIST_PUBLICATION_OPTIONS<br>PEERDIST_RETRIEVAL_OPTIONS<br>PEERDIST_STATUS_INFO<br>PEERDIST_STREAM_HANDLE<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
