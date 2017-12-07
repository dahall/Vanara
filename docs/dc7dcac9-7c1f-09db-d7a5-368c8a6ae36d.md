# StringHelper.AllocChars Method 
 

Allocates a block of memory allocated from the unmanaged COM task allocator sufficient to hold the number of specified characters.

**Namespace:**&nbsp;<a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions</a><br />**Assembly:**&nbsp;Vanara.Core (in Vanara.Core.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static IntPtr AllocChars(
	uint count,
	CharSet charSet = CharSet.Auto
)
```

**VB**<br />
``` VB
Public Shared Function AllocChars ( 
	count As UInteger,
	Optional charSet As CharSet = CharSet.Auto
) As IntPtr
```

<br />

#### Parameters
&nbsp;<dl><dt>count</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/ctys3981" target="_blank">System.UInt32</a><br />The number of characters, inclusive of the null terminator.</dd><dt>charSet (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/aw448d0k" target="_blank">System.Runtime.InteropServices.CharSet</a><br />The character set.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/5he14kz8" target="_blank">IntPtr</a><br />The address of the block of memory allocated.

## See Also


#### Reference
<a href="dee9c0a6-9b96-531b-0835-9ab75c41b262">StringHelper Class</a><br /><a href="9abe54ff-18ce-e333-beed-30e855655381">Vanara.Extensions Namespace</a><br />