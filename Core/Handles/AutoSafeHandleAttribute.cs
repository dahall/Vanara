namespace Vanara.PInvoke;

/// <summary>
/// Attribute to apply to simple class definition that will generate the code for a full SafeHANDLE
/// that will perform a close operation on disposal.
/// </summary>
/// <remarks>
/// To use this attribute, apply to a class that defines the safe handle name.
/// <code lang="cs">
/// /// &lt;summary&gt;A safe handle to a module.&lt;/summary&gt;
/// [AutoSafeHandle(typeof(HMODULE), "FreeLibrary(handle)", typeof(SafeHANDLE))]
/// public partial class SafeHMODULE { }
/// </code>
/// </remarks>
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AutoSafeHandleAttribute(string? closeHandleFuncName = null, Type? handleStruct = null, Type? baseSafeHandle = null, Type? inheritedHandle = null) : Attribute
{
	/// <summary>Gets the base safe handle. Defaults to <see cref="SafeHandleV"/>.</summary>
	/// <value>The base safe handle.</value>
	public Type BaseSafeHandle { get; } = baseSafeHandle ?? typeof(SafeHandleV);

	/// <summary>
	/// Gets the name of the close handle function. This should be expressed as a lambda function
	/// that matches the <see cref="CloseHandleFuncName"/> delegate and uses <c>'handle'</c> to
	/// represent the <see cref="IntPtr"/> value passed to the function.
	/// </summary>
	/// <value>The name of the close handle function.</value>
	public string? CloseHandleFuncName { get; } = closeHandleFuncName;

	/// <summary>Gets the handle type that this safe handle holds and disposes.</summary>
	/// <value>The handle structure.</value>
	public Type HandleStruct { get; } = handleStruct ?? typeof(IntPtr);

	/// <summary>Gets the inherited handle.</summary>
	/// <value>The inherited handle.</value>
	public Type? InheritedHandle { get; } = inheritedHandle;
}