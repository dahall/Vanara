using System;
using System.Security.Principal;

namespace Vanara.Security
{
	/// <summary>Helper methods for working with <see cref="WindowsIdentity"/> and user names.</summary>
	public static partial class AccountUtils
	{
		public static bool IsAdmin(this WindowsIdentity id) => new WindowsPrincipal(id).IsInRole(WindowsBuiltInRole.Administrator);


		public static bool IsServiceAccount(this WindowsIdentity id)
		{
			try
			{
				var acct = new NTAccount(id.Name);

				var si = (SecurityIdentifier) acct.Translate(typeof(SecurityIdentifier));

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
			if (identity is null) func();
#if NET20 || NET35 || NET40 || NET45
			using (new Principal.WindowsImpersonatedIdentity(identity))
				func();
#else
			WindowsIdentity.RunImpersonated(identity.AccessToken, func);
#endif
		}
		/// <summary>Runs the specified function as the impersonated Windows identity.</summary>
		/// <typeparam name="T">The type of object used by and returned by the function.</typeparam>
		/// <param name="identity">The impersonated identity under which to run the function.</param>
		/// <param name="func">The System.Func to run.</param>
		/// <returns>The result of the function.</returns>
		public static T Run<T>(this WindowsIdentity identity, Func<T> func)
		{
			if (identity is null) return func();
#if NET20 || NET35 || NET40 || NET45
			using (new Principal.WindowsImpersonatedIdentity(identity))
				return func();
#else
			return WindowsIdentity.RunImpersonated(identity.AccessToken, func);
#endif
		}

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

		/*private static bool LookupAccountSid(string computerName, IntPtr sid, out string accountName, out string domainName, out SID_NAME_USE use)
			{
				int anLen = 0x100;
				int dnLen = 0x100;
				StringBuilder acctName = new StringBuilder(anLen);
				StringBuilder domName = new StringBuilder(dnLen);
				if (LookupAccountSid(computerName, sid, acctName, ref anLen, domName, ref dnLen, out use))
				{
					accountName = acctName.ToString().TrimEnd('$');
					domainName = domName.ToString();
					return true;
				}
				accountName = domainName = null;
				return false;
			}

			private static bool FindUserFromSid(IntPtr incomingSid, string computerName, ref string userName)
			{
				SID_NAME_USE use;
				string acctName, domainName;
				if (!LookupAccountSid(computerName, incomingSid, out acctName, out domainName, out use))
					throw new Win32Exception();
				bool flag = use == SID_NAME_USE.SidTypeUser;
				if (userName == null)
					return flag;

				if (!string.IsNullOrEmpty(domainName))
					domainName = computerName;
				userName = string.Format("{0}\\{1}", domainName, acctName);
				return flag;
			}

			private static string FormattedUserNameFromSid(IntPtr incomingSid, string computerName)
			{
				string userName = string.Empty;
				FindUserFromSid(incomingSid, computerName, ref userName);
				if (!string.IsNullOrEmpty(userName))
				{
					SecurityIdentifier identifier = new SecurityIdentifier(incomingSid);
					string[] strArray = userName.Split(new char[] { '\\' });
					if (strArray.Length != 2)
					{
						return userName;
					}
					string str2 = strArray[1];
					if ((identifier.IsWellKnown(WellKnownSidType.NetworkServiceSid) || identifier.IsWellKnown(WellKnownSidType.AnonymousSid)) || ((identifier.IsWellKnown(WellKnownSidType.LocalSystemSid) || identifier.IsWellKnown(WellKnownSidType.LocalServiceSid)) || identifier.IsWellKnown(WellKnownSidType.LocalSid)))
					{
						return str2;
					}
					if (string.Compare(strArray[0], computerName, StringComparison.CurrentCultureIgnoreCase) == 0)
					{
						userName = str2;
					}
				}
				return userName;
			}

			private static string FormattedUserNameFromStringSid(string incomingSid, string computerName)
			{
				string str = string.Empty;
				IntPtr zero = IntPtr.Zero;
				if (!ConvertStringSidToSid(incomingSid, ref zero))
				{
					throw new Win32Exception();
				}
				str = FormattedUserNameFromSid(zero, computerName);
				Marshal.FreeHGlobal(zero);
				return str;
			}*/
	}
}