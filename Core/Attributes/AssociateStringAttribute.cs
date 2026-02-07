namespace Vanara.PInvoke;

/// <summary>Associates a string with an element.</summary>
/// <seealso cref="Attribute"/>
/// <remarks>Initializes a new instance of the <see cref="AssociateStringAttribute"/> class.</remarks>
/// <param name="value">A string value.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event |
				AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method |
				AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
public class AssociateStringAttribute(string value) : Attribute
{

	/// <summary>Gets or sets the GUID associated with this element.</summary>
	/// <value>A GUID value.</value>
	public string Value { get; } = value;
}