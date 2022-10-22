![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WinHTTP NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WinHTTP?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants) imported from Windows WinHTTP.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WinHTTP**

Functions | Enumerations | Structures
--- | --- | ---
WinHttpAddRequestHeaders WinHttpAddRequestHeadersEx WinHttpCheckPlatform WinHttpCloseHandle WinHttpConnect WinHttpCrackUrl WinHttpCreateProxyResolver WinHttpCreateUrl WinHttpDetectAutoProxyConfigUrl WinHttpFreeProxyResult WinHttpFreeQueryConnectionGroupResult WinHttpGetDefaultProxyConfiguration WinHttpGetIEProxyConfigForCurrentUser WinHttpGetProxyForUrl WinHttpGetProxyForUrlEx WinHttpGetProxyResult WinHttpOpen WinHttpOpenRequest WinHttpQueryAuthSchemes WinHttpQueryConnectionGroup WinHttpQueryDataAvailable WinHttpQueryHeaders WinHttpQueryHeadersEx WinHttpQueryOption WinHttpReadData WinHttpReadDataEx WinHttpReceiveResponse WinHttpResetAutoProxy WinHttpSendRequest WinHttpSetCredentials WinHttpSetDefaultProxyConfiguration WinHttpSetOption WinHttpSetStatusCallback WinHttpSetTimeouts WinHttpTimeFromSystemTime WinHttpTimeToSystemTime WinHttpWebSocketClose WinHttpWebSocketCompleteUpgrade WinHttpWebSocketQueryCloseStatus WinHttpWebSocketReceive WinHttpWebSocketSend WinHttpWebSocketShutdown WinHttpWriteData  | ASYNC_RESULT HTTP_STATUS ICU INTERNET_SCHEME SECURITY_FLAG WINHTTP_ACCESS_TYPE WINHTTP_ADDREQ_FLAG WINHTTP_AUTH_SCHEME WINHTTP_AUTH_TARGET WINHTTP_AUTO_DETECT_TYPE WINHTTP_AUTOLOGON_SECURITY_LEVEL WINHTTP_AUTOPROXY WINHTTP_CALLBACK_FLAG WINHTTP_CALLBACK_STATUS WINHTTP_CALLBACK_STATUS_FLAG WINHTTP_DECOMPRESSION_FLAG WINHTTP_DISABLE WINHTTP_DISABLE_PASSPORT WINHTTP_ENABLE_SSL WINHTTP_EXTENDED_HEADER_FLAG WINHTTP_FLAG_SECURE_PROTOCOL WINHTTP_HANDLE_TYPE WINHTTP_MATCH_CONNECTION_GUID_FLAG WINHTTP_OPEN_FLAG WINHTTP_OPENREQ_FLAG WINHTTP_OPTION WINHTTP_OPTION_REDIRECT_POLICY WINHTTP_PROTOCOL_FLAG WINHTTP_QUERY WINHTTP_QUERY_CONNECTION_GROUP_FLAG WINHTTP_READ_DATA_EX_FLAG WINHTTP_REQUEST_STAT_ENTRY WINHTTP_REQUEST_STAT_FLAG WINHTTP_REQUEST_TIME_ENTRY WINHTTP_RESET WINHTTP_SPN WINHTTP_WEB_SOCKET_BUFFER_TYPE WINHTTP_WEB_SOCKET_CLOSE_STATUS WINHTTP_WEB_SOCKET_OPERATION WinHttpRequestAutoLogonPolicy WinHttpRequestOption    | HINTERNET HTTP_VERSION_INFO WINHTTP_ASYNC_RESULT WINHTTP_AUTOPROXY_OPTIONS WINHTTP_CERTIFICATE_INFO WINHTTP_CONNECTION_GROUP WINHTTP_CONNECTION_INFO WINHTTP_CREDS WINHTTP_CREDS_EX WINHTTP_CURRENT_USER_IE_PROXY_CONFIG WINHTTP_EXTENDED_HEADER WINHTTP_HEADER_NAME WINHTTP_HOST_CONNECTION_GROUP WINHTTP_MATCH_CONNECTION_GUID WINHTTP_PROXY_INFO WINHTTP_PROXY_INFO_IN WINHTTP_PROXY_RESULT WINHTTP_PROXY_RESULT_ENTRY WINHTTP_PROXY_SETTINGS WINHTTP_PROXY_NETWORKING_KEY WINHTTP_QUERY_CONNECTION_GROUP_RESULT WINHTTP_REQUEST_STATS WINHTTP_REQUEST_TIMES WINHTTP_SECURITY_INFO WINHTTP_URL_COMPONENTS WINHTTP_URL_COMPONENTS_IN WINHTTP_WEB_SOCKET_ASYNC_RESULT WINHTTP_WEB_SOCKET_STATUS                
