using System;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	public class ElevPriv : IDisposable
	{
		SafeCoTaskMemHandle prevState;
		SafeHTOKEN tok;

		public ElevPriv(string priv, HPROCESS hProc = default, TokenAccess access = TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY)
		{
			if (hProc.IsNull) hProc = GetCurrentProcess();
			tok = SafeHTOKEN.FromProcess(hProc, access);
			var newPriv = new PTOKEN_PRIVILEGES(LUID.FromName(priv), PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
			prevState = PTOKEN_PRIVILEGES.GetAllocatedAndEmptyInstance();
			if (!AdjustTokenPrivileges(tok, false, newPriv, (uint)prevState.Size, prevState, out var retLen))
				Win32Error.ThrowLastError();
			prevState.Size = (int)retLen;
		}

		public void Dispose()
		{
			AdjustTokenPrivileges(tok, false, prevState);
			prevState.Dispose();
			tok.Dispose();
		}
	}
}