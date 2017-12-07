# EnumExtensions.ClearFlags(*T*) Method 
 

Clears the specified flags from an enumerated value and returns the new value.

**Namespace:**&nbsp;<a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions</a><br />**Assembly:**&nbsp;Vanara.Core (in Vanara.Core.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static T ClearFlags<T>(
	this T flags,
	T flag
)
where T : struct, new(), IConvertible

```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function ClearFlags(Of T As {Structure, New, IConvertible}) ( 
	flags As T,
	flag As T
) As T
```

<br />

#### Parameters
&nbsp;<dl><dt>flags</dt><dd>Type: *T*<br />The enumerated value.</dd><dt>flag</dt><dd>Type: *T*<br />The flags to clear or unset.</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>The enumerated type.</dd></dl>

#### Return Value
Type: *T*<br />The resulting enumerated value after the *flag* has been unset.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type . When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="42c3c3f8-1676-a911-01bf-74e8ddc5f4bc">EnumExtensions Class</a><br /><a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions Namespace</a><br />