using System.Security.Principal;

namespace Vanara.Security
{
	public static partial class AccountUtils
	{
		public static bool IsAdmin(this WindowsIdentity id) => new WindowsPrincipal(id).IsInRole(WindowsBuiltInRole.Administrator);

		public static bool IsServiceAccount(this WindowsIdentity id)
		{
			try
			{
				var acct = new NTAccount(id.Name);
				var si = (SecurityIdentifier)acct.Translate(typeof(SecurityIdentifier));
				return (si.IsWellKnown(WellKnownSidType.LocalSystemSid) || si.IsWellKnown(WellKnownSidType.NetworkServiceSid) ||
						si.IsWellKnown(WellKnownSidType.LocalServiceSid));
			}
			catch { }
			return false;
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