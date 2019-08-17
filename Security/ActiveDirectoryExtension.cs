#if (NET20 || NET35 || NET40 || NET45)
using System;
using System.Linq;
using System.DirectoryServices.ActiveDirectory;
using Vanara.Extensions.Reflection;
using static Vanara.PInvoke.NTDSApi;

namespace Vanara.Extensions
{
	public static class ActiveDirectoryExtension
	{
		public static string[] CrackNames(this DomainController dc, string[] names,
			DS_NAME_FORMAT formatDesired = DS_NAME_FORMAT.DS_USER_PRINCIPAL_NAME,
			DS_NAME_FORMAT formatOffered = DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME,
			DS_NAME_FLAGS flags = DS_NAME_FLAGS.DS_NAME_NO_FLAGS)
		{
			lock (dc)
				using (var ds = dc.GetHandle())
					return DsCrackNames(ds, names, formatDesired, formatOffered, flags).Select(r => r.pName).ToArray();
		}

		public static SafeDsHandle GetHandle(this DomainController dc)
		{
			var hDc = dc.GetPropertyValue("Handle", IntPtr.Zero);
			if (hDc == IntPtr.Zero) throw new InvalidOperationException();
			return new SafeDsHandle(hDc);
		}
	}
}
#endif