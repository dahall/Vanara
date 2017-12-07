# NetworkProfile Class
 

Represents a wireless network profile


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;Vanara.Network.NetworkProfile<br />
**Namespace:**&nbsp;<a href="6f9c0845-1a20-2cb1-a754-0b5e90c1683a">Vanara.Network</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public class NetworkProfile
```

**VB**<br />
``` VB
Public Class NetworkProfile
```

<br />
The NetworkProfile type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="590e574e-14ac-96b5-b605-abcceb5ac1ff">NetworkProfile</a></td><td>
Initializes a new instance of the NetworkProfile class using the GUID of the network profile.</td></tr></table>&nbsp;
<a href="#networkprofile-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="5209f2fc-ebf5-be4a-d779-a167d6439c18">Id</a></td><td>
Gets the GUID of the profile.</td></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="12f5131c-cd2f-5cb1-c886-96f95ca8c686">Name</a></td><td>
Gets the name of the profile.</td></tr></table>&nbsp;
<a href="#networkprofile-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="79de994c-a29a-78d0-6b63-d9e60f88b69e">Equals</a></td><td>
Determines whether the specified <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a> is equal to this instance.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/bsc2ak47" target="_blank">Object.Equals(Object)</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/4k87zsw7" target="_blank">Finalize</a></td><td>
Allows an object to try to free resources and perform other cleanup operations before it is reclaimed by garbage collection.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")![Static member](media/static.gif "Static member")</td><td><a href="d3ebb169-8879-f4ad-18bc-81925abf5618">GetAllLocalProfiles</a></td><td>
Gets all local profiles.</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="199cc613-2f25-8cbb-0016-ce0b958b3c31">GetHashCode</a></td><td>
Returns a hash code for this instance.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/zdee4b3y" target="_blank">Object.GetHashCode()</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Protected method](media/protmethod.gif "Protected method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/57ctke0a" target="_blank">MemberwiseClone</a></td><td>
Creates a shallow copy of the current <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="97559bcd-e0cd-62d9-6ec3-b045a277eded">ToString</a></td><td>
Returns a <a href="http://msdn2.microsoft.com/en-us/library/s1wwdcbf" target="_blank">String</a> that represents this instance.
 (Overrides <a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">Object.ToString()</a>.)</td></tr></table>&nbsp;
<a href="#networkprofile-class">Back to Top</a>

## Extension Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="609b1449-9696-245e-03a2-e22beb84efe1">GetPropertyValue(T)</a></td><td>
Gets a named property value from an object.
 (Defined by <a href="00588eb4-ca31-ef7e-81da-3ce105aa9b63">ReflectionExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="cc997716-244b-d4f1-e26d-139cc82ce6b0">InvokeMethod(String, Object[])</a></td><td>Overloaded.  
Invokes a named method on an object with parameters and no return value.
 (Defined by <a href="00588eb4-ca31-ef7e-81da-3ce105aa9b63">ReflectionExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="35c20259-aa16-9a35-254f-8bf630272463">InvokeMethod(String, Type[], Object[])</a></td><td>Overloaded.  
Invokes a named method on an object with parameters and no return value.
 (Defined by <a href="00588eb4-ca31-ef7e-81da-3ce105aa9b63">ReflectionExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="39c67efc-5f5d-9e71-64bc-8e89b4589f75">InvokeMethod(T)(String, Object[])</a></td><td>Overloaded.  
Invokes a named method on an object with parameters and no return value.
 (Defined by <a href="00588eb4-ca31-ef7e-81da-3ce105aa9b63">ReflectionExtensions</a>.)</td></tr><tr><td>![Public Extension Method](media/pubextension.gif "Public Extension Method")</td><td><a href="4a4da18e-d1a2-3a1f-28b0-10fb9f9646e6">InvokeMethod(T)(String, Type[], Object[])</a></td><td>Overloaded.  
Invokes a named method on an object with parameters and no return value.
 (Defined by <a href="00588eb4-ca31-ef7e-81da-3ce105aa9b63">ReflectionExtensions</a>.)</td></tr></table>&nbsp;
<a href="#networkprofile-class">Back to Top</a>

## See Also


#### Reference
<a href="6f9c0845-1a20-2cb1-a754-0b5e90c1683a">Vanara.Network Namespace</a><br />