#if NETFRAMEWORK
using System.Security.Principal;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.Principal;

/// <summary>
/// Impersonation of a user. Allows to execute code under another user context. Please note that the account that instantiates this class
/// needs to have the 'Act as part of operating system' privilege set.
/// </summary>
/// <remarks>
/// <code>
/// // The following code impersonates an account to perform work
/// using (new WindowsImpersonatedIdentity("bob", "WORKDOMAIN", "bobs_secret_passw0rd")
/// {
/// // Perform impersonated work in the body. Once the 'using' statement closes,
/// // the impersonation ends.
/// }
/// </code>
/// </remarks>
public class WindowsImpersonatedIdentity : WindowsLoggedInIdentity
{
	private readonly WindowsImpersonationContext? impersonationContext;

	/// <summary>
	/// Starts the impersonation with the given credentials. Please note that the account that instantiates this class needs to have the
	/// 'Act as part of operating system' privilege set.
	/// </summary>
	/// <param name="userName">
	/// A string that specifies the name of the user. This is the name of the user account to log on to. If you use the user principal
	/// name (UPN) format, User@DNSDomainName, the <paramref name="domainName"/> parameter must be NULL.
	/// </param>
	/// <param name="domainName">
	/// A string that specifies the name of the domain or server whose account database contains the <paramref name="userName"/> account.
	/// If this parameter is NULL, the user name must be specified in UPN format. If this parameter is ".", the account is validated by
	/// using only the local account database.
	/// </param>
	/// <param name="password">A string that specifies the plain-text password for the user account specified by <paramref name="userName"/>.</param>
	/// <param name="logonType">
	/// Type of the logon. This parameter can usually be left as the default. For more information, lookup more detail for the
	/// dwLogonType parameter of the Windows LogonUser function.
	/// </param>
	/// <param name="provider">
	/// The logon provider. This parameter can usually be left as the default. For more information, lookup more detail for the
	/// dwLogonProvider parameter of the Windows LogonUser function.
	/// </param>
	public WindowsImpersonatedIdentity(string userName, string domainName, string password, LogonUserType logonType = LogonUserType.LOGON32_LOGON_INTERACTIVE,
		LogonUserProvider provider = LogonUserProvider.LOGON32_PROVIDER_DEFAULT) : base(userName, domainName, password, logonType, provider) => impersonationContext = AuthenticatedIdentity?.Impersonate();

	/// <summary>
	/// Starts the impersonation with the given <see cref="WindowsIdentity"/>. Please note that the account that instantiates this class
	/// needs to have the 'Act as part of operating system' privilege set.
	/// </summary>
	/// <param name="identityToImpersonate">The identity to impersonate.</param>
	public WindowsImpersonatedIdentity(WindowsIdentity identityToImpersonate) : base(identityToImpersonate) => impersonationContext = AuthenticatedIdentity?.Impersonate();

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public override void Dispose()
	{
		impersonationContext?.Undo();
		base.Dispose();
	}
}
#endif