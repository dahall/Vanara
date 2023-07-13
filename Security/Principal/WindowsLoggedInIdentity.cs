using System;
using System.ComponentModel;
using System.Security.Principal;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.Principal;

/// <summary>
/// Impersonation of a user. Allows to execute code under another user context. Please note that the account that instantiates this class
/// needs to have the 'Act as part of operating system' privilege set.
/// </summary>
public class WindowsLoggedInIdentity : IDisposable, IIdentity
{
	private readonly SafeHTOKEN hToken = new(IntPtr.Zero, false);
	private readonly bool ownId = true;

	/// <summary>
	/// Provides an identity to a logged into user given the supplied credentials. Please note that the account that instantiates this
	/// class needs to have the 'Act as part of operating system' privilege set.
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
	public WindowsLoggedInIdentity(string userName, string domainName, string password, LogonUserType logonType = LogonUserType.LOGON32_LOGON_INTERACTIVE,
		LogonUserProvider provider = LogonUserProvider.LOGON32_PROVIDER_DEFAULT)
	{
		if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException(nameof(userName));
		if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
		if (string.IsNullOrEmpty(domainName) && !userName.Contains("@")) throw new ArgumentNullException(nameof(domainName));
		if (LogonUser(userName, domainName, password, logonType, provider, out hToken))
		{
			using (hToken)
			{
				AuthenticatedIdentity = new WindowsIdentity(hToken.DangerousGetHandle());
			}
		}
		else
			throw new Win32Exception();
	}

	/// <summary>
	/// Starts the impersonation with the given <see cref="WindowsIdentity"/>. Please note that the account that instantiates this class
	/// needs to have the 'Act as part of operating system' privilege set.
	/// </summary>
	/// <param name="identityToImpersonate">The identity to impersonate.</param>
	public WindowsLoggedInIdentity(WindowsIdentity identityToImpersonate)
	{
		AuthenticatedIdentity = identityToImpersonate;
		ownId = false;
	}

	/// <summary>Gets the authenticated identity.</summary>
	public WindowsIdentity AuthenticatedIdentity { get; private set; }

	/// <summary>Gets the type of authentication used.</summary>
	string? IIdentity.AuthenticationType => AuthenticatedIdentity?.AuthenticationType;

	/// <summary>Gets a value that indicates whether the user has been authenticated.</summary>
	bool IIdentity.IsAuthenticated => AuthenticatedIdentity?.IsAuthenticated ?? false;

	/// <summary>Gets the name of the current user.</summary>
	string? IIdentity.Name => AuthenticatedIdentity?.Name;

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public virtual void Dispose()
	{
		if (ownId) AuthenticatedIdentity?.Dispose();
		hToken?.Dispose();
	}
}