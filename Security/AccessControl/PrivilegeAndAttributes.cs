using Vanara.Security.AccessControl;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.AccessControl
{
	public class PrivilegeAndAttributes
	{
		public PrivilegeAndAttributes(SystemPrivilege p, PrivilegeAttributes a)
		{
			Privilege = p;
			Attributes = a;
		}

		public SystemPrivilege Privilege { get; }
		public PrivilegeAttributes Attributes { get; }
	}
}