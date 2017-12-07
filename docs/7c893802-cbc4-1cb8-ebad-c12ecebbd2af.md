# MarshalingStream.Seek Method 
 

Sets the position within the current stream.

**Namespace:**&nbsp;<a href="46913109-b3e0-3b59-6f7f-071f8aa90bf0">Vanara.InteropServices</a><br />**Assembly:**&nbsp;Vanara.Core (in Vanara.Core.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public override long Seek(
	long offset,
	SeekOrigin origin
)
```

**VB**<br />
``` VB
Public Overrides Function Seek ( 
	offset As Long,
	origin As SeekOrigin
) As Long
```

<br />

#### Parameters
&nbsp;<dl><dt>offset</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/6yy583ek" target="_blank">System.Int64</a><br />A byte offset relative to the *origin* parameter.</dd><dt>origin</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/883dhyx0" target="_blank">System.IO.SeekOrigin</a><br />A value of type <a href="http://msdn2.microsoft.com/en-us/library/883dhyx0" target="_blank">SeekOrigin</a> indicating the reference point used to obtain the new position.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/6yy583ek" target="_blank">Int64</a><br />The new position within the current stream.

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/3w1b3114" target="_blank">ArgumentException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="cd922f26-ef66-7f8c-9c42-cb4bc2cfe527">MarshalingStream Class</a><br /><a href="46913109-b3e0-3b59-6f7f-071f8aa90bf0">Vanara.InteropServices Namespace</a><br />