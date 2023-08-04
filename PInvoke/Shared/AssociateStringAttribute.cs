namespace Vanara.PInvoke;

/// <summary>Associates a string with an element.</summary>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event |
				AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method |
				AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
public class AssociateStringAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="AssociateStringAttribute"/> class.</summary>
	/// <param name="value">A string value.</param>
	public AssociateStringAttribute(string value) => Value = value;

	/// <summary>Gets or sets the GUID associated with this element.</summary>
	/// <value>A GUID value.</value>
	public string Value { get; }
}