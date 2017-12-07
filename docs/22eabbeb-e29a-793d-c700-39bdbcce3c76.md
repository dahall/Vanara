# SystemSecurity.UserLogonRights Method 
 

Gets the system access for the specified user.

**Namespace:**&nbsp;<a href="62a937f8-234b-6e15-2f22-272a8ae206a7">Vanara.Security.AccessControl</a><br />**Assembly:**&nbsp;Vanara.Security (in Vanara.Security.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public SystemSecurity.LogonRights UserLogonRights(
	string user
)
```

**VB**<br />
``` VB
Public Function UserLogonRights ( 
	user As String
) As SystemSecurity.LogonRights
```

<br />

#### Parameters
&nbsp;<dl><dt>user</dt><dd>Type: <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">System.String</a><br />The user name of the account for which to manage privileges.</dd></dl>

#### Return Value
Type: <a href="3db47a0d-4f08-7235-620f-8970ed7885de">SystemSecurity.LogonRights</a><br />A <a href="3db47a0d-4f08-7235-620f-8970ed7885de">SystemSecurity.LogonRights</a> instance for the specified user.

## See Also


#### Reference
<a href="d966f360-1793-ec9a-f172-06cfdff71c9b">SystemSecurity Class</a><br /><a href="62a937f8-234b-6e15-2f22-272a8ae206a7">Vanara.Security.AccessControl Namespace</a><br />