#if !NET5_0_OR_GREATER
namespace System.Runtime.Versioning;

/// <summary>
/// Some information relates to prerelease product that may be substantially modified before it’s released. Microsoft makes no warranties,
/// express or implied, with respect to the information provided here.
/// </summary>
public abstract class OSPlatformAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="OSPlatformAttribute"/> class.</summary>
	/// <param name="platformName">Name of the platform.</param>
	protected OSPlatformAttribute(string platformName) => PlatformName = platformName;

	/// <summary>Gets the name of the platform.</summary>
	/// <value>The name of the platform.</value>
	public string PlatformName { get; }
}

/// <summary>
/// Some information relates to prerelease product that may be substantially modified before it’s released. Microsoft makes no warranties,
/// express or implied, with respect to the information provided here.
/// </summary>
/// <remarks>
/// Callers can apply a SupportedOSPlatformAttribute or use guards to prevent calls to APIs on unsupported operating systems. A given
/// platform should only be specified once.
/// </remarks>
[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor |
	AttributeTargets.Enum | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Interface |
	AttributeTargets.Method | AttributeTargets.Module | AttributeTargets.Property | AttributeTargets.Struct,
	AllowMultiple = true, Inherited = false)]
public class SupportedOSPlatformAttribute : OSPlatformAttribute
{
	/// <summary>Initializes a new instance of the <see cref="SupportedOSPlatformAttribute"/> class.</summary>
	/// <param name="platformName">Name of the platform.</param>
	public SupportedOSPlatformAttribute(string platformName) : base(platformName) { }
}
#endif