# TaskDialog.RunDialog Method 
 

The required implementation of CommonDialog that shows the Task Dialog.

**Namespace:**&nbsp;<a href="c580cf52-4028-70db-28d0-f9b1abc03861">Vanara.Windows.Forms</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
protected override bool RunDialog(
	IntPtr hwndOwner
)
```

**VB**<br />
``` VB
Protected Overrides Function RunDialog ( 
	hwndOwner As IntPtr
) As Boolean
```

<br />

#### Parameters
&nbsp;<dl><dt>hwndOwner</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/5he14kz8" target="_blank">System.IntPtr</a><br />Owner window. This can be null.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/a28wyd50" target="_blank">Boolean</a><br />If this method returns true, then ShowDialog will return DialogResult.OK. If this method returns false, then ShowDialog will return DialogResult.Cancel. The user of this class must use the TaskDialogResult member to get more information.

## See Also


#### Reference
<a href="0e4976bb-9701-b107-c589-9d00dabbbae0">TaskDialog Class</a><br /><a href="c580cf52-4028-70db-28d0-f9b1abc03861">Vanara.Windows.Forms Namespace</a><br />