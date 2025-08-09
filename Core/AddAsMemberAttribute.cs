namespace Vanara.PInvoke;

/// <summary>
/// <note type="implement">This attribute does not yet have an implemented generator.</note>
/// An attribute to indicate that the method of the attributed parameter should be added as a member of the class or structure of the type
/// being annotated. The type must be <c>partial</c> and either a structure or class.
/// </summary>
/// <remarks>
/// <para>
/// This attribute indicates that the enclosing method can be added to the type of the attributed parameter. This is helpful when exposing
/// member methods of handles and safe handles. For example, <c>HEVENT</c> has a number of supporting functions like <c>bool SetEvent([In]
/// HEVENT hEvent)</c>. Placing this attribute on the <c>bool SetEvent([In, AddAsMember] HEVENT hEvent)</c> parameter will then add <c>bool
/// SetEvent()</c> to the HEVENT structure.
/// </para>
/// <para>
/// If there are supporting classes, like SafeEventHandle for HEVENT, then you can use the alternate parameter of the attribute to indicate
/// that class name that should also receive the method (e.g., <c>bool SetEvent([In, AddAsMember(typeof(SafeEventHandle))] HEVENT hEvent)</c>).
/// </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class AddAsMemberAttribute(Type? alternate = null) : Attribute
{
	/// <summary>Gets the type of an alternate class or structure to which to add the method.</summary>
	public Type? AlternateType { get; } = alternate;
}