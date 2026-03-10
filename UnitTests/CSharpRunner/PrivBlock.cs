using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

public class ElevPriv : IDisposable
{
	TOKEN_PRIVILEGES prevState;
	public readonly SafeHTOKEN hTok;

	public ElevPriv(string priv, HPROCESS hProc = default, TokenAccess access = TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY) :
		this([priv], hProc, access) { }

	public ElevPriv(string[] privs, HPROCESS hProc = default, TokenAccess access = TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY) :
		this(privs, SafeHTOKEN.FromProcess(hProc.IsNull ? GetCurrentProcess() : hProc, access)) { }

	public ElevPriv(string priv, HTOKEN hToken) : this([priv], hToken) { }

	public ElevPriv(string[] privs, HTOKEN hToken)
	{
		hTok = new SafeHTOKEN((IntPtr)hToken, false);
		var newPriv = new TOKEN_PRIVILEGES(Array.ConvertAll(privs, s => new LUID_AND_ATTRIBUTES(LUID.FromName(s), PrivilegeAttributes.SE_PRIVILEGE_ENABLED)));
		AdjustTokenPrivileges(hTok, false, newPriv, out prevState).ThrowIfFailed();
	}

	public void Dispose()
	{
		AdjustTokenPrivileges(hTok, false, prevState, out _);
		hTok.Dispose();
		GC.SuppressFinalize(this);
	}
}