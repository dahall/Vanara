# ComponentDesignerExtension.EditValue Method 
 

Launches the design-time editor for the property of the component behind a designer.

**Namespace:**&nbsp;<a href="47183544-7c44-c1e2-cf57-c68e49a55933">Vanara.Windows.Forms.Design</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static Object EditValue(
	this ComponentDesigner designer,
	string propName,
	Object objectToChange = null
)
```

**VB**<br />
``` VB
<ExtensionAttribute>
Public Shared Function EditValue ( 
	designer As ComponentDesigner,
	propName As String,
	Optional objectToChange As Object = Nothing
) As Object
```


#### Parameters
&nbsp;<dl><dt>designer</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/72ea7ss5" target="_blank">System.ComponentModel.Design.ComponentDesigner</a><br />The designer for a component.</dd><dt>propName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The name of the property to edit. If this value is null, the default property for the object is used.</dd><dt>objectToChange (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />The object on which to edit the property. If this value is null, the Component property of the designer is used.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a><br />The new value returned by the editor.

#### Usage Note
In Visual Basic and C#, you can call this method as an instance method on any object of type <a href="http://msdn2.microsoft.com/en-us/library/72ea7ss5" target="_blank">ComponentDesigner</a>. When you use instance method syntax to call this method, omit the first parameter. For more information, see <a href="http://msdn.microsoft.com/en-us/library/bb384936.aspx">Extension Methods (Visual Basic)</a> or <a href="http://msdn.microsoft.com/en-us/library/bb383977.aspx">Extension Methods (C# Programming Guide)</a>.

## See Also


#### Reference
<a href="6211dc76-47ba-8406-4d11-89f3e1d12747">ComponentDesignerExtension Class</a><br /><a href="47183544-7c44-c1e2-cf57-c68e49a55933">Vanara.Windows.Forms.Design Namespace</a><br />