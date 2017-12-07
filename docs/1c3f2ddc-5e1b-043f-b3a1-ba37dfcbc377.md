# SystemShutdown.InitiateShutdown Method (String, String, TimeSpan, AdvApi32.ShutdownFlags, SystemShutDownReason)
 

Initiates a shutdown and restart of the specified computer, and restarts any applications that have been registered for restart.

**Namespace:**&nbsp;<a href="ae9a7c38-6642-96aa-d3f5-fcde8a4bd54e">Vanara.Diagnostics</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static void InitiateShutdown(
	string machineName,
	string message,
	TimeSpan gracePeriod,
	ShutdownFlags flags,
	SystemShutDownReason reason = SystemShutDownReason.SHTDN_REASON_MINOR_NONE
)
```

**VB**<br />
``` VB
Public Shared Sub InitiateShutdown ( 
	machineName As String,
	message As String,
	gracePeriod As TimeSpan,
	flags As ShutdownFlags,
	Optional reason As SystemShutDownReason = SystemShutDownReason.SHTDN_REASON_MINOR_NONE
)
```

<br />

#### Parameters
&nbsp;<dl><dt>machineName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the computer to be shut down. If the value of this parameter is NULL, the local computer is shut down.</dd><dt>message</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The message to be displayed in the interactive shutdown dialog box.</dd><dt>gracePeriod</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/269ew577" target="_blank">System.TimeSpan</a><br />The number of seconds to wait before shutting down the computer. If the value of this parameter is zero, the computer is shut down immediately. This value is limited to MAX_SHUTDOWN_TIMEOUT. 
If the value of this parameter is greater than zero, and the dwShutdownFlags parameter specifies the flag SHUTDOWN_GRACE_OVERRIDE, the function fails and returns the error code ERROR_BAD_ARGUMENTS.</dd><dt>flags</dt><dd>Type: ShutdownFlags<br />One or more bit flags that specify options for the shutdown.</dd><dt>reason (Optional)</dt><dd>Type: SystemShutDownReason<br />The reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes. If this parameter is zero, the default is an undefined shutdown that is logged as "No title for this reason could be found". By default, it is also an unplanned shutdown. Depending on how the system is configured, an unplanned shutdown triggers the creation of a file that contains the system state information, which can delay shutdown. Therefore, do not use zero for this parameter.</dd></dl>

## See Also


#### Reference
<a href="ad6f6ae9-fa9f-8e45-4be0-0a56f367e403">SystemShutdown Class</a><br /><a href="aefa53cb-b41c-5db7-aa3c-4616f1edeb8b">InitiateShutdown Overload</a><br /><a href="ae9a7c38-6642-96aa-d3f5-fcde8a4bd54e">Vanara.Diagnostics Namespace</a><br />