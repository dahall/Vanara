![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WebSocket NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WebSocket?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, structures and constants) imported from the WebSocket API (WebSocket.dll).

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WebSocket**

Functions | Enumerations | Structures
--- | --- | ---
WebSocketAbortHandle WebSocketBeginClientHandshake WebSocketBeginServerHandshake WebSocketCompleteAction WebSocketCreateClientHandle WebSocketCreateServerHandle WebSocketDeleteHandle WebSocketEndClientHandshake WebSocketEndServerHandshake WebSocketGetAction WebSocketGetGlobalProperty WebSocketReceive WebSocketSend  | WEB_SOCKET_ACTION WEB_SOCKET_ACTION_QUEUE WEB_SOCKET_BUFFER_TYPE WEB_SOCKET_CLOSE_STATUS WEB_SOCKET_PROPERTY_TYPE          | WEB_SOCKET_BUFFER WEB_SOCKET_HTTP_HEADER WEB_SOCKET_PROPERTY WEB_SOCKET_HANDLE DATA CLOSESTATUS        
