using System;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

public class ElevPriv : IDisposable
{
	TOKEN_PRIVILEGES prevState;
	SafeHTOKEN tok;

	public ElevPriv(string priv, HPROCESS hProc = default, TokenAccess access = TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY) :
		this(new[] { priv }, hProc, access)
	{ }

	public ElevPriv(string[] privs, HPROCESS hProc = default, TokenAccess access = TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY)
	{
		if (hProc.IsNull) hProc = GetCurrentProcess();
		tok = SafeHTOKEN.FromProcess(hProc, access);
		ElevatePrivileges(privs);
	}

	public ElevPriv(string priv, HTOKEN hToken) : this(new[] { priv }, hToken) { }

	public ElevPriv(string[] privs, HTOKEN hToken)
	{
		tok = new SafeHTOKEN((IntPtr)hToken, false);
		ElevatePrivileges(privs);
	}

	private void ElevatePrivileges(string[] privs)
	{
		var newPriv = new TOKEN_PRIVILEGES(Array.ConvertAll(privs, s => new LUID_AND_ATTRIBUTES(LUID.FromName(s), PrivilegeAttributes.SE_PRIVILEGE_ENABLED)));
		AdjustTokenPrivileges(tok, false, newPriv, out prevState).ThrowIfFailed();
	}

	public void Dispose()
	{
		AdjustTokenPrivileges(tok, false, prevState, out _);
		tok.Dispose();
	}
}