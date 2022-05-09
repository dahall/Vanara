![Vanara](https://github.com/dahall/Vanara/raw/master/docs/icons/VanaraHeading.png)
### Vanara.PInvoke.WsmSvc NuGet Package
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WsmSvc?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, interfaces, structures and constants) imported from Windows WsmSvc.dll for Windows Remote Management.

### What is Vanara?

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### Issues?

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### Included in Vanara.PInvoke.WsmSvc

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
WSManCloseCommand<br>WSManCloseOperation<br>WSManCloseSession<br>WSManCloseShell<br>WSManConnectShell<br>WSManConnectShellCommand<br>WSManCreateSession<br>WSManCreateShell<br>WSManCreateShellEx<br>WSManDeinitialize<br>WSManDisconnectShell<br>WSManGetErrorMessage<br>WSManGetSessionOptionAsDword<br>WSManGetSessionOptionAsString<br>WSManInitialize<br>WSManPluginAuthzOperationComplete<br>WSManPluginAuthzQueryQuotaComplete<br>WSManPluginAuthzUserComplete<br>WSManPluginFreeRequestDetails<br>WSManPluginGetOperationParameters<br>WSManPluginOperationComplete<br>WSManPluginReceiveResult<br>WSManPluginReportContext<br>WSManReceiveShellOutput<br>WSManReconnectShell<br>WSManReconnectShellCommand<br>WSManRunShellCommand<br>WSManRunShellCommandEx<br>WSManSendShellInput<br>WSManSetSessionOption<br>WSManSignalShell<br><br><br><br> | WSMAN_FLAG_REQUESTED_API_VERSION<br>WSMAN_FLAG_SERVER_BUFFERING_MODE<br>WSMAN_PLUGIN_PARAMS_OP<br>WSMAN_SHUTDOWN<br>WSManAuthenticationFlags<br>WSManCallbackFlags<br>WSManDataType<br>WSManProxyAccessType<br>WSManSessionOption<br>WSManEnumFlags<br>WSManProxyAccessTypeFlags<br>WSManProxyAuthenticationFlags<br>WSManSessionFlags<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br> | WSMAN_API_HANDLE<br>WSMAN_AUTHENTICATION_CREDENTIALS<br>WSMAN_AUTHZ_QUOTA<br>WSMAN_CERTIFICATE_DETAILS<br>WSMAN_COMMAND_ARG_SET<br>WSMAN_COMMAND_HANDLE<br>WSMAN_DATA<br>WSMAN_DATA_BINARY<br>WSMAN_DATA_TEXT<br>WSMAN_ENVIRONMENT_VARIABLE<br>WSMAN_ENVIRONMENT_VARIABLE_SET<br>WSMAN_ERROR<br>WSMAN_FILTER<br>WSMAN_FRAGMENT<br>WSMAN_KEY<br>WSMAN_OPERATION_HANDLE<br>WSMAN_OPERATION_INFO<br>WSMAN_OPTION<br>WSMAN_OPTION_SET<br>WSMAN_PLUGIN_REQUEST<br>WSMAN_PROXY_INFO<br>WSMAN_RECEIVE_DATA_RESULT<br>WSMAN_RESPONSE_DATA<br>WSMAN_SELECTOR_SET<br>WSMAN_SENDER_DETAILS<br>WSMAN_SESSION_HANDLE<br>WSMAN_SHELL_ASYNC<br>WSMAN_SHELL_DISCONNECT_INFO<br>WSMAN_SHELL_HANDLE<br>WSMAN_SHELL_STARTUP_INFO_V10<br>WSMAN_SHELL_STARTUP_INFO_V11<br>WSMAN_STREAM_ID_SET<br>WSMAN_USERNAME_PASSWORD_CREDS<br>WSMAN_DATA_UNION<br> | IWSMan<br>IWSManConnectionOptions<br>IWSManConnectionOptionsEx<br>IWSManConnectionOptionsEx2<br>IWSManEnumerator<br>IWSManEx<br>IWSManEx2<br>IWSManEx3<br>IWSManResourceLocator<br>IWSManSession<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>
