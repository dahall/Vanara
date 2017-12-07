# ReflectionExtensions.InvokeNotOverride Method 
 

Invokes a method from a derived base class.

**Namespace:**&nbsp;<a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions</a><br />**Assembly:**&nbsp;Vanara.Core (in Vanara.Core.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static Object InvokeNotOverride(
	this MethodInfo methodInfo,
	Object targetObject,
	params Object[] arguments
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function InvokeNotOverride ( 
	methodInfo As MethodInfo,
	targetObject As Object,
	ParamArray arguments As Object()
) As Object
```

<br />

#### Parameters
&nbsp;<dl><dt>methodInfo</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/1wa35kh5" target="_blank">System.Reflection.MethodInfo</a><br />The <a href="http://msdn2.microsoft.com/en-us/library/1wa35kh5" target="_blank">MethodInfo</a> instance from the derived class for the method to invoke.</dd><dt>targetObject</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The target object.</dd><dt>arguments</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a>[]<br />The arguments.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a><br />The value returned from the method.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/1wa35kh5" target="_blank">MethodInfo</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="00588eb4-ca31-ef7e-81da-3ce105aa9b63">ReflectionExtensions Class</a><br /><a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions Namespace</a><br />