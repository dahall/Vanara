# SafeMemoryHandleExt(*TMem*).AddSubReference Method 
 

Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of pointers to other objects

**Namespace:**&nbsp;<a href="46913109-b3e0-3b59-6f7f-071f8aa90bf0">Vanara.InteropServices</a><br />**Assembly:**&nbsp;Vanara.Core (in Vanara.Core.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public void AddSubReference(
	IEnumerable<ISafeMemoryHandle> children
)
```

**VB**<br />
``` VB
Public Sub AddSubReference ( 
	children As IEnumerable(Of ISafeMemoryHandle)
)
```


#### Parameters
&nbsp;<dl><dt>children</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/9eekhta0" target="_blank">System.Collections.Generic.IEnumerable</a>(<a href="5ef0b2c9-b809-7f82-ec9a-603c8e39cd02">ISafeMemoryHandle</a>)<br />Collection of SafeMemoryHandle objects referred to by this object.</dd></dl>

#### Implements
<a href="9e390edd-ec6c-ab6d-f969-04bbff47d01a">ISafeMemoryHandle.AddSubReference(IEnumerable(ISafeMemoryHandle))</a><br />

## See Also


#### Reference
<a href="f2e4f2cf-d8a1-b88f-7bae-5d00065f9f86">SafeMemoryHandleExt(TMem) Class</a><br /><a href="46913109-b3e0-3b59-6f7f-071f8aa90bf0">Vanara.InteropServices Namespace</a><br />