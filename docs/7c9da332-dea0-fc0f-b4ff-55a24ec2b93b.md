# ShellLink.GetAccessControl Method 
 

Gets a FileSecurity object that encapsulates the specified type of access control list (ACL) entries for the file described by the current FileInfo object.

**Namespace:**&nbsp;<a href="be182789-447d-1423-b31f-7fd1f1f04ab2">Vanara.Windows.Shell</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public FileSecurity GetAccessControl(
	AccessControlSections includeSections = AccessControlSections.None|AccessControlSections.Access|AccessControlSections.Owner|AccessControlSections.Group
)
```

**VB**<br />
``` VB
Public Function GetAccessControl ( 
	Optional includeSections As AccessControlSections = AccessControlSections.None Or AccessControlSections.Access Or AccessControlSections.Owner Or AccessControlSections.Group
) As FileSecurity
```

<br />

#### Parameters
&nbsp;<dl><dt>includeSections (Optional)</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/wc2zdbth" target="_blank">System.Security.AccessControl.AccessControlSections</a><br />One of the AccessControlSections values that specifies which group of access control entries to retrieve.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/hdwe2zfh" target="_blank">FileSecurity</a><br />A FileSecurity object that encapsulates the access control rules for the current file.

## See Also


#### Reference
<a href="89f142ea-a38c-21e5-1d8c-e787b266682e">ShellLink Class</a><br /><a href="be182789-447d-1423-b31f-7fd1f1f04ab2">Vanara.Windows.Shell Namespace</a><br />