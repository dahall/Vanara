namespace Vanara.PInvoke;

/// <summary>Specifies one or more types that the attributed class is intended to wrap or represent.</summary>
/// <remarks>
/// Apply this attribute to a class to indicate that it serves as a wrapper for the specified types. This can be used for code generation,
/// metadata analysis, or tooling scenarios where type relationships need to be explicitly declared.
/// </remarks>
/// <param name="types">An array of types that the attributed class wraps. Cannot be null or contain null elements.</param>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class WrapsAttribute(params Type[] types) : Attribute
{
	/// <summary>Gets the collection of types associated with the current instance.</summary>
	public Type[] Types { get; } = types;
}