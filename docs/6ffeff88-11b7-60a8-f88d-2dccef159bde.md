# SafeCoTaskMemString&nbsp;Implicit Conversion (SafeCoTaskMemString to String)
 

Returns the string value held by a <a href="6d23abd3-8745-d88b-b84c-7be2ecffb3d7">SafeCoTaskMemString</a>.

**Namespace:**&nbsp;<a href="46913109-b3e0-3b59-6f7f-071f8aa90bf0">Vanara.InteropServices</a><br />**Assembly:**&nbsp;Vanara.Core (in Vanara.Core.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static implicit operator string (
	SafeCoTaskMemString s
)
```

**VB**<br />
``` VB
Public Shared Widening Operator CType ( 
	s As SafeCoTaskMemString
) As String
```

<br />

#### Parameters
&nbsp;<dl><dt>s</dt><dd>Type: <a href="6d23abd3-8745-d88b-b84c-7be2ecffb3d7">Vanara.InteropServices.SafeCoTaskMemString</a><br />The <a href="6d23abd3-8745-d88b-b84c-7be2ecffb3d7">SafeCoTaskMemString</a> instance.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a><br />A <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a> value held by the <a href="6d23abd3-8745-d88b-b84c-7be2ecffb3d7">SafeCoTaskMemString</a> or `null` if the handle or value is invalid.

## See Also


#### Reference
<a href="6d23abd3-8745-d88b-b84c-7be2ecffb3d7">SafeCoTaskMemString Class</a><br /><a href="46913109-b3e0-3b59-6f7f-071f8aa90bf0">Vanara.InteropServices Namespace</a><br />