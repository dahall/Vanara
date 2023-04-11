using NUnit.Framework;
using System;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ProcessThreadsApiTests
{
	[Test]
	public void CreateProcessAsUserTest()
	{
		Assert.That(OpenProcessToken(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS, out SafeHTOKEN? hTok), ResultIs.Successful);
		using (hTok)
		{
			STARTUPINFO si = STARTUPINFO.Default;
			si.ShowWindowCommand = ShowWindowCommand.SW_MAXIMIZE;
			Assert.That(CreateProcessAsUser(hTok, @"C:\Windows\notepad.exe", bInheritHandles: false, dwCreationFlags: CREATE_PROCESS.NORMAL_PRIORITY_CLASS, lpStartupInfo: si, lpProcessInformation: out SafePROCESS_INFORMATION? pi), ResultIs.Successful);
			Sleep(500);
			Kernel32.TerminateProcess(pi.hProcess, 0);
		}
	}

	[Test]
	public void CreateProcessAsUserTest2()
	{
		Assert.That(OpenProcessToken(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS, out SafeHTOKEN? hTok), ResultIs.Successful);
		using (hTok)
		{
			STARTUPINFOEX si = STARTUPINFOEX.Default;
			si.StartupInfo.ShowWindowCommand = ShowWindowCommand.SW_MAXIMIZE;
			Assert.That(CreateProcessAsUser(hTok, @"C:\Windows\notepad.exe", bInheritHandles: false, dwCreationFlags: CREATE_PROCESS.NORMAL_PRIORITY_CLASS, lpStartupInfo: si, lpProcessInformation: out SafePROCESS_INFORMATION? pi), ResultIs.Successful);
			Sleep(500);
			Kernel32.TerminateProcess(pi.hProcess, 0);
		}
	}

	[Test]
	public void OpenThreadTokenTest()
	{
		Assert.That(OpenThreadToken(GetCurrentThread(), TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_ADJUST_PRIVILEGES, true, out SafeHTOKEN? hTok), ResultIs.FailureCode(Win32Error.ERROR_NO_TOKEN));
		Assert.That(OpenProcessToken(GetCurrentProcess(), TokenAccess.TOKEN_DUPLICATE, out SafeHTOKEN? hPrTok), ResultIs.Successful);
		using (hPrTok)
		{
			Assert.That(DuplicateTokenEx(hPrTok, TokenAccess.TOKEN_IMPERSONATE | TokenAccess.TOKEN_QUERY | TokenAccess.TOKEN_ADJUST_PRIVILEGES,
			  default, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, TOKEN_TYPE.TokenImpersonation, out hTok), ResultIs.Successful);
			using (hTok)
				Assert.That(SetThreadToken(GetCurrentThread(), hTok), ResultIs.Successful);
			Assert.That(SetThreadToken(IntPtr.Zero, HTOKEN.NULL), ResultIs.Successful);
		}
	}
}