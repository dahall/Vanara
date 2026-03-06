#if !NET9_0_OR_GREATER
namespace System.Runtime.CompilerServices;

/// <summary>Specifies the priority of a member in overload resolution. When unspecified, the default priority is 0.</summary>
/// <param name="priority">The priority of the attributed member. Higher numbers are prioritized, lower numbers are deprioritized. 0 is the default if no attribute is present.</param>
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public sealed class OverloadResolutionPriorityAttribute(int priority) : Attribute
{
	/// <summary>The priority of the member.</summary>
	public int Priority { get; } = priority;
}
#endif