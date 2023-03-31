using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.AccessControl;

/// <summary>Class to hold associated <see cref="SystemPrivilege"/> and <see cref="PrivilegeAttributes"/> pairs.</summary>
public class PrivilegeAndAttributes
{
	/// <summary>Initializes a new instance of the <see cref="PrivilegeAndAttributes"/> class.</summary>
	/// <param name="p">The privilege.</param>
	/// <param name="a">The attribute.</param>
	public PrivilegeAndAttributes(SystemPrivilege p, PrivilegeAttributes a)
	{
		Privilege = p;
		Attributes = a;
	}

	/// <summary>Gets the privilege.</summary>
	/// <value>The privilege.</value>
	public SystemPrivilege Privilege { get; }
	/// <summary>Gets the attributes.</summary>
	/// <value>The attributes.</value>
	public PrivilegeAttributes Attributes { get; }
}