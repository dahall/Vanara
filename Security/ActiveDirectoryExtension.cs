using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using Vanara.Extensions.Reflection;
using static Vanara.PInvoke.NTDSApi;

namespace Vanara.Extensions;

/// <summary>Extensions for AD objects (e.g. DomainController).</summary>
public static class ActiveDirectoryExtension
{
	/// <summary>
	/// Converts an array of directory service object names from one format to another. Name conversion enables client applications to
	/// map between the multiple names used to identify various directory service objects. For example, user objects can be identified
	/// by SAM account names (Domain\UserName), user principal name (UserName@Domain.com), or distinguished name.
	/// </summary>
	/// <param name="dc">The <see cref="DomainController"/> instance to query.</param>
	/// <param name="names">The names to convert.</param>
	/// <param name="formatDesired">
	/// Contains one of the DS_NAME_FORMAT values that identifies the format of the output names. The DS_SID_OR_SID_HISTORY_NAME value
	/// is not supported.
	/// </param>
	/// <param name="formatOffered">Contains one of the DS_NAME_FORMAT values that identifies the format of the input names.</param>
	/// <param name="flags">Contains one or more of the DS_NAME_FLAGS values used to determine how the name syntax will be cracked.</param>
	/// <returns>The converted names.</returns>
	public static string[] CrackNames(this DomainController dc, string[] names,
		DS_NAME_FORMAT formatDesired = DS_NAME_FORMAT.DS_USER_PRINCIPAL_NAME,
		DS_NAME_FORMAT formatOffered = DS_NAME_FORMAT.DS_NT4_ACCOUNT_NAME,
		DS_NAME_FLAGS flags = DS_NAME_FLAGS.DS_NAME_NO_FLAGS)
	{
		lock (dc)
			using (var ds = dc.GetHandle())
				return DsCrackNames(ds, names, formatDesired, formatOffered, flags).Select(r => r.pName).ToArray();
	}

	/// <summary>Uses reflection to get the hiddent handle of a <see cref="DomainController"/>.</summary>
	/// <param name="dc">The <see cref="DomainController"/> instance.</param>
	/// <returns>A <see cref="SafeDsHandle"/> for the domain controller in <paramref name="dc"/>.</returns>
	/// <exception cref="InvalidOperationException"></exception>
	public static SafeDsHandle GetHandle(this DomainController dc)
	{
		var hDc = dc.GetPropertyValue("Handle", IntPtr.Zero);
		if (hDc == IntPtr.Zero) throw new InvalidOperationException();
		return new SafeDsHandle(hDc);
	}
}