# GenericProvider.GetEffectivePermission Method (Guid, AdvApi32.PSID, String, IntPtr, OBJECT_TYPE_LIST[])
 

Gets the effective permissions for the provided Sid within the Security Descriptor. Called only when an object type identifier is specified.

**Namespace:**&nbsp;<a href="62a937f8-234b-6e15-2f22-272a8ae206a7">Vanara.Security.AccessControl</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public virtual uint[] GetEffectivePermission(
	Guid objTypeId,
	PSID pUserSid,
	string serverName,
	IntPtr pSecurityDescriptor,
	out OBJECT_TYPE_LIST[] objectTypeList
)
```

**VB**<br />
``` VB
Public Overridable Function GetEffectivePermission ( 
	objTypeId As Guid,
	pUserSid As PSID,
	serverName As String,
	pSecurityDescriptor As IntPtr,
	<OutAttribute> ByRef objectTypeList As OBJECT_TYPE_LIST()
) As UInteger()
```


#### Parameters
&nbsp;<dl><dt>objTypeId</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/cey1zx63" target="_blank">System.Guid</a><br />The object type identifier.</dd><dt>pUserSid</dt><dd>Type: PSID<br />A pointer to the Sid of the identity to check.</dd><dt>serverName</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />Name of the server. This can be `null`.</dd><dt>pSecurityDescriptor</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/5he14kz8" target="_blank">System.IntPtr</a><br />A pointer to the security descriptor.</dd><dt>objectTypeList</dt><dd>Type: OBJECT_TYPE_LIST[]<br />The object type list.</dd></dl>

#### Return Value
Type: <a href="http://msdn2.microsoft.com/en-us/library/ctys3981" target="_blank">UInt32</a>[]<br />An array of access masks.

#### Implements
<a href="59aa5433-1cc0-4b57-57b2-cebd01e98a9b">IAccessControlEditorDialogProvider.GetEffectivePermission(Guid, PSID, String, IntPtr, OBJECT_TYPE_LIST[])</a><br />

## Exceptions
&nbsp;<table><tr><th>Exception</th><th>Condition</th></tr><tr><td><a href="http://msdn2.microsoft.com/en-us/library/6byb74h9" target="_blank">NotImplementedException</a></td><td /></tr></table>

## See Also


#### Reference
<a href="b8d8d51e-378b-9b9d-583d-4216609b4738">GenericProvider Class</a><br /><a href="4db16f3d-a643-7173-3598-e36aa3d7a388">GetEffectivePermission Overload</a><br /><a href="62a937f8-234b-6e15-2f22-272a8ae206a7">Vanara.Security.AccessControl Namespace</a><br />