# VirtualDisk.Open Method (String, Boolean, Boolean, Boolean)
 

Creates an instance of a Virtual Disk from a file.

**Namespace:**&nbsp;<a href="d3362b0a-0ff5-4e50-dbee-d2c8d2fbae9f">Vanara.IO</a><br />**Assembly:**&nbsp;Vanara.SystemServices (in Vanara.SystemServices.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public static VirtualDisk Open(
	string path,
	bool readOnly,
	bool getInfoOnly = false,
	bool noParents = false
)
```

**VB**<br />
``` VB
Public Shared Function Open ( 
	path As String,
	readOnly As Boolean,
	Optional getInfoOnly As Boolean = false,
	Optional noParents As Boolean = false
) As VirtualDisk
```

<br />

#### Parameters
&nbsp;<dl><dt>path</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />A valid path to the virtual disk image to open.</dd><dt>readOnly</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />If TRUE, indicates the file backing store is to be opened as read-only.</dd><dt>getInfoOnly (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />If TRUE, indicates the handle is only to be used to get information on the virtual disk.</dd><dt>noParents (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">System.Boolean</a><br />Open the VHD file (backing store) without opening any differencing-chain parents. Used to correct broken parent links. This flag is not supported for ISO virtual disks.</dd></dl>

#### Return Value
Type: <a href="14596a99-aae8-0fef-6be2-950bbcd08026">VirtualDisk</a><br />\[Missing <returns> documentation for "M:Vanara.IO.VirtualDisk.Open(System.String,System.Boolean,System.Boolean,System.Boolean)"\]

## See Also


#### Reference
<a href="14596a99-aae8-0fef-6be2-950bbcd08026">VirtualDisk Class</a><br /><a href="54c8a373-9828-6495-891a-70193b057546">Open Overload</a><br /><a href="d3362b0a-0ff5-4e50-dbee-d2c8d2fbae9f">Vanara.IO Namespace</a><br />