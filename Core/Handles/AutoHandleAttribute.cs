namespace Vanara.PInvoke;

/// <summary>
/// Attribute to apply to simple struct definition that will generate the code for a full HANDLE.
/// </summary>
/// <remarks>To use this attribute, apply to a structure that defines the handle name.
/// <code lang="cs">
/// /// &lt;summary&gt;A handle to a module.&lt;/summary&gt;
/// [AutoHandle] // Automatically derives from IHandle
/// public partial struct HMODULE { }
/// 
/// /// &lt;summary&gt;A handle to a synchronization event.&lt;/summary&gt;
/// [AutoHandle(typeof(ISynchHandle))]
/// public partial struct HEVENT
/// {
///    /// &lt;summary&gt;Sets the signaled state.&lt;/summary&gt;
///    public bool SetEvent() => SetEvent(handle);
/// }
/// </code>
/// </remarks>
[AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
public sealed class AutoHandleAttribute(Type? baseInterface = null) : Attribute
{
	/// <summary>Gets or sets the base interface.</summary>
	/// <value>The base interface.</value>
	public Type BaseInterface { get; set; } = baseInterface ?? typeof(IHandle);
}