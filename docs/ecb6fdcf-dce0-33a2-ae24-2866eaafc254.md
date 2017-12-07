# ControlExtension.CallWhenHandleValid Method 
 

Performs an action on a control after its handle has been created. If the control's handle has already been created, the action is executed immediately.

**Namespace:**&nbsp;<a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static void CallWhenHandleValid(
	this Control ctrl,
	Action<Control> action
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Sub CallWhenHandleValid ( 
	ctrl As Control,
	action As Action(Of Control)
)
```

<br />

#### Parameters
&nbsp;<dl><dt>ctrl</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/36cd312w" target="_blank">System.Windows.Forms.Control</a><br />This control.</dd><dt>action</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/018hxwa8" target="_blank">System.Action</a>(<a href="http://msdn2.microsoft.com/en-us/library/36cd312w" target="_blank">Control</a>)<br />The action to execute.</dd></dl>

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/36cd312w" target="_blank">Control</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="ccd6a3d6-cafd-3c05-1f87-8ef6e3a4b593">ControlExtension Class</a><br /><a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions Namespace</a><br />