# ShellLink.GetProperty(*T*) Method 
 

Gets the property specified by *key*.

**Namespace:**&nbsp;<a href="be182789-447d-1423-b31f-7fd1f1f04ab2">Vanara.Windows.Shell</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public T GetProperty<T>(
	PROPERTYKEY key,
	T defValue = null
)

```

**VB**<br />
``` VB
Public Function GetProperty(Of T) ( 
	key As PROPERTYKEY,
	Optional defValue As T = Nothing
) As T
```

<br />

#### Parameters
&nbsp;<dl><dt>key</dt><dd>Type: PROPERTYKEY<br />The property key.</dd><dt>defValue (Optional)</dt><dd>Type: *T*<br />The default value.</dd></dl>

#### Type Parameters
&nbsp;<dl><dt>T</dt><dd>Property type</dd></dl>

#### Return Value
Type: *T*<br />The value of the property or *defValue* if not found.

## See Also


#### Reference
<a href="89f142ea-a38c-21e5-1d8c-e787b266682e">ShellLink Class</a><br /><a href="be182789-447d-1423-b31f-7fd1f1f04ab2">Vanara.Windows.Shell Namespace</a><br />