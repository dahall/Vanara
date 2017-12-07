# SystemShutdown.ShutdownBlockReasonSet Method 
 

Indicates that the system cannot be shut down and sets a reason string to be displayed to the user if system shutdown is initiated.

**Namespace:**&nbsp;<a href="ae9a7c38-6642-96aa-d3f5-fcde8a4bd54e">Vanara.Diagnostics</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static bool ShutdownBlockReasonSet(
	this Form form,
	string reason
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function ShutdownBlockReasonSet ( 
	form As Form,
	reason As String
) As Boolean
```

<br />

#### Parameters
&nbsp;<dl><dt>form</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/w4bcxb43" target="_blank">System.Windows.Forms.Form</a><br />A top level <a href="http://msdn2.microsoft.com/en-us/library/w4bcxb43" target="_blank">Form</a> instance.</dd><dt>reason</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The reason the application must block system shutdown. This string will be truncated for display purposes after MAX_STR_BLOCKREASON characters.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />If the call succeeds, the return value is nonzero. If the call fails, the return value is zero. To get extended error information, call GetLastError.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/w4bcxb43" target="_blank">Form</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="ad6f6ae9-fa9f-8e45-4be0-0a56f367e403">SystemShutdown Class</a><br /><a href="ae9a7c38-6642-96aa-d3f5-fcde8a4bd54e">Vanara.Diagnostics Namespace</a><br />