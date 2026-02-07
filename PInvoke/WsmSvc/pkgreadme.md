![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WsmSvc NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WsmSvc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml/badge.svg?branch=master)](https://github.com/dahall/Vanara/actions/workflows/cibuild.yml)

PInvoke API (methods, interfaces, structures and constants) imported from Windows WsmSvc.dll for Windows Remote Management.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [MyGet build](https://www.myget.org/feed/Packages/vanara).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WsmSvc**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
WSManCloseCommand WSManCloseOperation WSManCloseSession WSManCloseShell WSManConnectShell WSManConnectShellCommand WSManCreateSession WSManCreateShell WSManCreateShellEx WSManDeinitialize WSManDisconnectShell WSManGetErrorMessage WSManGetSessionOptionAsDword WSManGetSessionOptionAsString WSManInitialize WSManPluginAuthzOperationComplete WSManPluginAuthzQueryQuotaComplete WSManPluginAuthzUserComplete WSManPluginFreeRequestDetails WSManPluginGetOperationParameters WSManPluginOperationComplete WSManPluginReceiveResult WSManPluginReportContext WSManReceiveShellOutput WSManReconnectShell WSManReconnectShellCommand WSManRunShellCommand WSManRunShellCommandEx WSManSendShellInput WSManSetSessionOption WSManSignalShell    | WSMAN_FLAG_REQUESTED_API_VERSION WSMAN_FLAG_SERVER_BUFFERING_MODE WSMAN_PLUGIN_PARAMS_OP WSMAN_SHUTDOWN WSManAuthenticationFlags WSManCallbackFlags WSManDataType WSManProxyAccessType WSManSessionOption WSManEnumFlags WSManProxyAccessTypeFlags WSManProxyAuthenticationFlags WSManSessionFlags WsmError                     | WSMAN_AUTHENTICATION_CREDENTIALS WSMAN_AUTHZ_QUOTA WSMAN_CERTIFICATE_DETAILS WSMAN_COMMAND_ARG_SET WSMAN_DATA WSMAN_DATA_BINARY WSMAN_DATA_TEXT WSMAN_ENVIRONMENT_VARIABLE WSMAN_ENVIRONMENT_VARIABLE_SET WSMAN_ERROR WSMAN_FILTER WSMAN_FRAGMENT WSMAN_KEY WSMAN_OPERATION_INFO WSMAN_OPTION WSMAN_OPTION_SET WSMAN_PLUGIN_REQUEST WSMAN_PROXY_INFO WSMAN_RECEIVE_DATA_RESULT WSMAN_RESPONSE_DATA WSMAN_SELECTOR_SET WSMAN_SENDER_DETAILS WSMAN_SHELL_ASYNC WSMAN_SHELL_DISCONNECT_INFO WSMAN_SHELL_STARTUP_INFO WSMAN_STREAM_ID_SET WSMAN_USERNAME_PASSWORD_CREDS WSMAN_API_HANDLE WSMAN_COMMAND_HANDLE WSMAN_OPERATION_HANDLE WSMAN_SESSION_HANDLE WSMAN_SHELL_HANDLE WSMAN_DATA_UNION  | IWSMan IWSManConnectionOptions IWSManConnectionOptionsEx IWSManConnectionOptionsEx2 IWSManEnumerator IWSManEx IWSManEx2 IWSManEx3 IWSManResourceLocator IWSManSession                        
