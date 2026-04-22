![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WTSApi32 NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WTSApi32?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from Windows WTSApi32.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WTSApi32**

Functions | Enumerations | Structures
--- | --- | ---
WTSActiveSessionExists<br>WTSCloseServer<br>WTSConnectSession<br>WTSCreateListener<br>WTSDisconnectSession<br>WTSEnableChildSessions<br>WTSEnumerateListeners<br>WTSEnumerateProcesses<br>WTSEnumerateProcessesEx<br>WTSEnumerateServers<br>WTSEnumerateSessions<br>WTSEnumerateSessionsEx<br>WTSFreeMemory<br>WTSFreeMemoryEx<br>WTSGetChildSessionId<br>WTSGetListenerSecurity<br>WTSIsChildSessionsEnabled<br>WTSLogoffSession<br>WTSOpenServer<br>WTSOpenServerEx<br>WTSQueryListenerConfig<br>WTSQuerySessionInformation<br>WTSQueryUserConfig<br>WTSQueryUserToken<br>WTSRegisterSessionNotification<br>WTSRegisterSessionNotificationEx<br>WTSSendMessage<br>WTSSetListenerSecurity<br>WTSSetRenderHint<br>WTSSetUserConfig<br>WTSShutdownSystem<br>WTSStartRemoteControlSession<br>WTSStopRemoteControlSession<br>WTSTerminateProcess<br>WTSUnRegisterSessionNotification<br>WTSUnRegisterSessionNotificationEx<br>WTSVirtualChannelClose<br>WTSVirtualChannelOpen<br>WTSVirtualChannelOpenEx<br>WTSVirtualChannelPurgeInput<br>WTSVirtualChannelPurgeOutput<br>WTSVirtualChannelQuery<br>WTSVirtualChannelRead<br>WTSVirtualChannelWrite<br>WTSWaitSystemEvent<br> | REMOTECONTROL_HOTKEY<br>SessionProtocolType<br>WTS_CHANNEL_OPTION<br>WTS_CONFIG_CLASS<br>WTS_CONFIG_SOURCE<br>WTS_CONNECTSTATE_CLASS<br>WTS_EVENT<br>WTS_INFO_CLASS<br>WTS_LISTENER<br>WTS_SESSIONSTATE<br>WTS_TYPE_CLASS<br>WTS_VIRTUAL_CLASS<br>WTS_WSD<br>WTSNotification<br>RENDER_HINT<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | HWTSSERVER<br>WTS_CLIENT_ADDRESS<br>WTS_CLIENT_DISPLAY<br>WTS_PROCESS_INFO<br>WTS_PROCESS_INFO_EX<br>WTS_SERVER_INFO<br>WTS_SESSION_ADDRESS<br>WTS_SESSION_INFO<br>WTS_SESSION_INFO_1<br>WTSCLIENT<br>WTSCONFIGINFO<br>WTSINFO<br>WTSINFOEX<br>WTSINFOEX_LEVEL<br>WTSINFOEX_LEVEL1<br>WTSLISTENERCONFIG<br>WTSLISTENERNAME<br>WTSUSERCONFIG<br>HVIRTUALCHANNEL<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
