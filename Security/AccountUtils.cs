using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security
{
	/// <summary>Helper methods for working with <see cref="WindowsIdentity"/> and user names.</summary>
	public static partial class AccountUtils
	{
		/// <summary>Returns a value indicating if the Windows identity is an administrator.</summary>
		/// <param name="id">The identity to evaluate.</param>
		/// <returns><see langword="true"/> if the identity is in an Administrator role.</returns>
		public static bool IsAdmin(this WindowsIdentity id) => new WindowsPrincipal(id).IsInRole(WindowsBuiltInRole.Administrator);

		/// <summary>Returns a value indicating if the Windows identity is a service account.</summary>
		/// <param name="id">The identity to evaluate.</param>
		/// <returns><see langword="true"/> if the identity is in a service account.</returns>
		public static bool IsServiceAccount(this WindowsIdentity id)
		{
			try
			{
				var acct = new NTAccount(id.Name);

				var si = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));

				return si.IsWellKnown(WellKnownSidType.LocalSystemSid) || si.IsWellKnown(WellKnownSidType.NetworkServiceSid) || si.IsWellKnown(WellKnownSidType.LocalServiceSid) || si.IsWellKnown(WellKnownSidType.ServiceSid);
			}
			catch { }
			return false;
		}

		/// <summary>Runs the specified function as the impersonated Windows identity.</summary>
		/// <param name="identity">The impersonated identity under which to run the function.</param>
		/// <param name="func">The System.Func to run.</param>
		public static void Run(this WindowsIdentity identity, Action func)
		{
			if (identity is null)
			{
				func();
			}
			else
			{
#if NETFRAMEWORK
				using (new Principal.WindowsImpersonatedIdentity(identity))
					func();
#else
				WindowsIdentity.RunImpersonated(identity.AccessToken, func);
#endif
			}
		}
		/// <summary>Runs the specified function as the impersonated Windows identity.</summary>
		/// <typeparam name="T">The type of object used by and returned by the function.</typeparam>
		/// <param name="identity">The impersonated identity under which to run the function.</param>
		/// <param name="func">The System.Func to run.</param>
		/// <returns>The result of the function.</returns>
		public static T Run<T>(this WindowsIdentity identity, Func<T> func)
		{
			if (identity is null) return func();
#if NETFRAMEWORK
			using (new Principal.WindowsImpersonatedIdentity(identity))
				return func();
#else
			return WindowsIdentity.RunImpersonated(identity.AccessToken, func);
#endif
		}

		/// <summary>Gets the SDDL formatted SID value from a user name.</summary>
		/// <param name="userName">Name of the user.</param>
		/// <returns>The SDDL SID string.</returns>
		public static string SidStringFromUserName(string userName)
		{
			var acct = new NTAccount(userName);
			try
			{
				var si = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));
				return si.ToString();
			}
			catch { }
			return null;
		}

		/// <summary>Get a user name for a supplied SDDL SID string.</summary>
		/// <param name="sid">The SID string in SDDL format.</param>
		/// <returns>The full user name of the identity referred to by <paramref name="sid"/>.</returns>
		public static string UserNameFromSidString(string sid)
		{
			try
			{
				var si = new SecurityIdentifier(sid);
				var acct = (NTAccount)si.Translate(typeof(NTAccount));
				return acct.Value;
			}
			catch { }
			return null;
		}
	}
}