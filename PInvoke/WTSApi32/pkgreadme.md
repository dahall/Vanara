![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WTSApi32 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WTSApi32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows WTSApi32.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WTSApi32**

Functions | Enumerations | Structures
--- | --- | ---
WTSCloseServer WTSConnectSession WTSCreateListener WTSDisconnectSession WTSEnableChildSessions WTSEnumerateListeners WTSEnumerateProcesses WTSEnumerateProcessesEx WTSEnumerateServers WTSEnumerateSessions WTSEnumerateSessionsEx WTSFreeMemory WTSFreeMemoryEx WTSGetChildSessionId WTSGetListenerSecurity WTSIsChildSessionsEnabled WTSLogoffSession WTSOpenServer WTSOpenServerEx WTSQueryListenerConfig WTSQuerySessionInformation WTSQueryUserConfig WTSQueryUserToken WTSRegisterSessionNotification WTSRegisterSessionNotificationEx WTSSendMessage WTSSetListenerSecurity WTSSetRenderHint WTSSetUserConfig WTSShutdownSystem WTSStartRemoteControlSession WTSStopRemoteControlSession WTSTerminateProcess WTSUnRegisterSessionNotification WTSUnRegisterSessionNotificationEx WTSVirtualChannelClose WTSVirtualChannelOpen WTSVirtualChannelOpenEx WTSVirtualChannelPurgeInput WTSVirtualChannelPurgeOutput WTSVirtualChannelQuery WTSVirtualChannelRead WTSVirtualChannelWrite WTSWaitSystemEvent  | REMOTECONTROL_HOTKEY SessionProtocolType WTS_CHANNEL_OPTION WTS_CONFIG_CLASS WTS_CONFIG_SOURCE WTS_CONNECTSTATE_CLASS WTS_EVENT WTS_INFO_CLASS WTS_LISTENER WTS_SESSIONSTATE WTS_TYPE_CLASS WTS_VIRTUAL_CLASS WTS_WSD RENDER_HINT                                | HVIRTUALCHANNEL HWTSSERVER WTS_CLIENT_ADDRESS WTS_CLIENT_DISPLAY WTS_PROCESS_INFO WTS_PROCESS_INFO_EX WTS_SERVER_INFO WTS_SESSION_ADDRESS WTS_SESSION_INFO WTS_SESSION_INFO_1 WTSCLIENT WTSCONFIGINFO WTSINFO WTSINFOEX WTSINFOEX_LEVEL WTSINFOEX_LEVEL1 WTSLISTENERCONFIG WTSLISTENERNAME WTSUSERCONFIG                          
