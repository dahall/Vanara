# SystemShutdown.InitiateShutdown Method (String, String, Nullable(TimeSpan), Boolean, Boolean, SystemShutDownReason)
 

Initiates a shutdown and optional restart of the specified computer.

**Namespace:**&nbsp;<a href="ae9a7c38-6642-96aa-d3f5-fcde8a4bd54e">Vanara.Diagnostics</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static bool InitiateShutdown(
	string machineName = null,
	string message = null,
	Nullable<TimeSpan> timeout = null,
	bool forceAppsClosed = false,
	bool rebootAfterShutdown = false,
	SystemShutDownReason reason = SystemShutDownReason.SHTDN_REASON_MINOR_NONE
)
```

**VB**<br />
``` VB
Public Shared Function InitiateShutdown ( 
	Optional machineName As String = Nothing,
	Optional message As String = Nothing,
	Optional timeout As Nullable(Of TimeSpan) = Nothing,
	Optional forceAppsClosed As Boolean = false,
	Optional rebootAfterShutdown As Boolean = false,
	Optional reason As SystemShutDownReason = SystemShutDownReason.SHTDN_REASON_MINOR_NONE
) As Boolean
```

<br />

#### Parameters
&nbsp;<dl><dt>machineName (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />String that specifies the network name of the computer to shut down. If NULL or an empty string, the function shuts down the local computer.</dd><dt>message (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />String that specifies a message to display in the shutdown dialog box. This parameter can be NULL if no message is required.</dd><dt>timeout (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/b3h38hb0" target="_blank">System.Nullable</a>(<a href="http://msdn2.microsoft.com/en-us/library/269ew577" target="_blank">TimeSpan</a>)<br />Time that the shutdown dialog box should be displayed, in seconds. While this dialog box is displayed, shutdown can be stopped by the AbortSystemShutdown function.</dd><dt>forceAppsClosed (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />If this parameter is TRUE, applications with unsaved changes are to be forcibly closed. If this parameter is FALSE, the system displays a dialog box instructing the user to close the applications.</dd><dt>rebootAfterShutdown (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />If this parameter is TRUE, the computer is to restart immediately after shutting down. If this parameter is FALSE, the system flushes all caches to disk and clears the screen.</dd><dt>reason (Optional)</dt><dd>Type: SystemShutDownReason<br />Reason for initiating the shutdown. This parameter must be one of the system shutdown reason codes.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />0 on failure, non-zero for success

## See Also


#### Reference
<a href="ad6f6ae9-fa9f-8e45-4be0-0a56f367e403">SystemShutdown Class</a><br /><a href="aefa53cb-b41c-5db7-aa3c-4616f1edeb8b">InitiateShutdown Overload</a><br /><a href="ae9a7c38-6642-96aa-d3f5-fcde8a4bd54e">Vanara.Diagnostics Namespace</a><br />