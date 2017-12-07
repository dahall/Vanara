# NotifyPropertyChangedInvocatorAttribute Class
 

Indicates that the method is contained in a type that implements `System.ComponentModel.INotifyPropertyChanged` interface and this method is used to notify that some property value changed.


## Inheritance Hierarchy
<a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">System.Object</a><br />&nbsp;&nbsp;<a href="http://msdn2.microsoft.com/en-us/library/e8kc3626" target="_blank">System.Attribute</a><br />&nbsp;&nbsp;&nbsp;&nbsp;Vanara.Windows.Forms.Annotations.NotifyPropertyChangedInvocatorAttribute<br />
**Namespace:**&nbsp;<a href="600255aa-5477-7018-00f3-14fce5adebc9">Vanara.Windows.Forms.Annotations</a><br />**Assembly:**&nbsp;Vanara.UI (in Vanara.UI.dll) Version: 1.0.3

## Syntax

**C#**<br />
``` C#
public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
```

**VB**<br />
``` VB
Public NotInheritable Class NotifyPropertyChangedInvocatorAttribute
	Inherits Attribute
```

The NotifyPropertyChangedInvocatorAttribute type exposes the following members.


## Constructors
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="f65f27c7-75b3-58b6-22e4-54ab264c5d88">NotifyPropertyChangedInvocatorAttribute()</a></td><td>
Initializes a new instance of the NotifyPropertyChangedInvocatorAttribute class</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="e6043094-dc19-11fc-f17a-a404f4bef050">NotifyPropertyChangedInvocatorAttribute(String)</a></td><td>
Initializes a new instance of the NotifyPropertyChangedInvocatorAttribute class</td></tr></table>&nbsp;
<a href="#notifypropertychangedinvocatorattribute-class">Back to Top</a>

## Properties
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="ae5faa83-7913-902f-0edf-8f5f6c889b31">ParameterName</a></td><td /></tr><tr><td>![Public property](media/pubproperty.gif "Public property")</td><td><a href="http://msdn2.microsoft.com/en-us/library/sa1bf03e" target="_blank">TypeId</a></td><td>
When implemented in a derived class, gets a unique identifier for this <a href="http://msdn2.microsoft.com/en-us/library/e8kc3626" target="_blank">Attribute</a>.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e8kc3626" target="_blank">Attribute</a>.)</td></tr></table>&nbsp;
<a href="#notifypropertychangedinvocatorattribute-class">Back to Top</a>

## Methods
&nbsp;<table><tr><th></th><th>Name</th><th>Description</th></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/09ds241w" target="_blank">Equals</a></td><td>
Returns a value that indicates whether this instance is equal to a specified object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e8kc3626" target="_blank">Attribute</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/365e1bxs" target="_blank">GetHashCode</a></td><td>
Returns the hash code for this instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e8kc3626" target="_blank">Attribute</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/dfwy45w9" target="_blank">GetType</a></td><td>
Gets the <a href="http://msdn2.microsoft.com/en-us/library/42892f65" target="_blank">Type</a> of the current instance.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/tbkb5x6t" target="_blank">IsDefaultAttribute</a></td><td>
When overridden in a derived class, indicates whether the value of this instance is the default value for the derived class.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e8kc3626" target="_blank">Attribute</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/wy7chz44" target="_blank">Match</a></td><td>
When overridden in a derived class, returns a value that indicates whether this instance equals a specified object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e8kc3626" target="_blank">Attribute</a>.)</td></tr><tr><td>![Public method](media/pubmethod.gif "Public method")</td><td><a href="http://msdn2.microsoft.com/en-us/library/7bxwbwt2" target="_blank">ToString</a></td><td>
Returns a string that represents the current object.
 (Inherited from <a href="http://msdn2.microsoft.com/en-us/library/e5kfa45b" target="_blank">Object</a>.)</td></tr></table>&nbsp;
<a href="#notifypropertychangedinvocatorattribute-class">Back to Top</a>

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
<a href="#notifypropertychangedinvocatorattribute-class">Back to Top</a>

## Remarks
The method should be non-static and conform to one of the supported signatures: `NotifyChanged(string)``NotifyChanged(params string[])``NotifyChanged{T}(Expression{Func{T}})``NotifyChanged{T,U}(Expression{Func{T,U}})``SetProperty{T}(ref T, T, string)`

## Examples

```
public class Foo : INotifyPropertyChanged {
  public event PropertyChangedEventHandler PropertyChanged;

  [NotifyPropertyChangedInvocator]
  protected virtual void NotifyChanged(string propertyName) { ... }

  string _name;

  public string Name {
    get { return _name; }
    set { _name = value; NotifyChanged("LastName"); /* Warning */ }
  }
}
```
 Examples of generated notifications: `NotifyChanged("Property")``NotifyChanged(() => Property)``NotifyChanged((VM x) => x.Property)``SetProperty(ref myField, value, "Property")`

## See Also


#### Reference
<a href="600255aa-5477-7018-00f3-14fce5adebc9">Vanara.Windows.Forms.Annotations Namespace</a><br />