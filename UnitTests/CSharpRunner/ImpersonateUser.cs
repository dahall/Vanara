using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

public class ImpersonatedUser : IDisposable
{
	private readonly SafeHTOKEN hToken;

	public ImpersonatedUser(string un, string pwd, string? svr = null)
	{
		if (!(svr?.StartsWith('\\') ?? false))
			svr = $@"\\{svr}";
		Win32Error.ThrowLastErrorIfFalse(LogonUser(un, svr, pwd, LogonUserType.LOGON32_LOGON_NETWORK, LogonUserProvider.LOGON32_PROVIDER_DEFAULT, out hToken));
		Win32Error.ThrowLastErrorIfFalse(ImpersonateLoggedOnUser(hToken));
	}

	public void Dispose()
	{
		RevertToSelf();
		((IDisposable)hToken).Dispose();
		GC.SuppressFinalize(this);
	}
}
