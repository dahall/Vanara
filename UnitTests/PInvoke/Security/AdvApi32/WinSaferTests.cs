using NUnit.Framework;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class WinSaferTests
{
	[Test]
	public void SaferComputeTokenFromLevelTest()
	{
		Assert.That(SaferCreateLevel(SAFER_SCOPEID.SAFER_SCOPEID_USER, SAFER_LEVELID.SAFER_LEVELID_NORMALUSER, SAFER_LEVEL_CREATE_FLAGS.SAFER_LEVEL_OPEN, out var hLvl), ResultIs.Successful);
		using (hLvl)
		{
			Assert.That(SaferComputeTokenFromLevel(hLvl, HTOKEN.NULL, out var hSaferTok, 0, out _), ResultIs.Successful);
			hSaferTok.Dispose();
		}
	}

	[Test]
	public void SaferGetSetLevelInformationTest()
	{
		Assert.That(SaferCreateLevel(SAFER_SCOPEID.SAFER_SCOPEID_USER, SAFER_LEVELID.SAFER_LEVELID_NORMALUSER, SAFER_LEVEL_CREATE_FLAGS.SAFER_LEVEL_OPEN, out var hLvl), ResultIs.Successful);
		using (hLvl)
		{
			//using (var str = new SafeCoTaskMemString("Description"))
			using var retstr = new SafeCoTaskMemString(1024);
			//Assert.That(SaferSetLevelInformation(hLvl, SAFER_OBJECT_INFO_CLASS.SaferObjectDescription, str, str.Size), ResultIs.Successful);
			Assert.That(SaferGetLevelInformation(hLvl, SAFER_OBJECT_INFO_CLASS.SaferObjectDescription, retstr, retstr.Size, out _), ResultIs.Successful);
			//Assert.That(retstr.ToString(), Is.EqualTo(str.ToString()));
			TestContext.WriteLine(retstr);
		}
	}

	[Test]
	public void SaferGetSetPolicyInformationTest()
	{
		using var mem = SafeHGlobalHandle.CreateFromStructure<uint>();
		Assert.That(SaferGetPolicyInformation(SAFER_SCOPEID.SAFER_SCOPEID_USER, SAFER_POLICY_INFO_CLASS.SaferPolicyDefaultLevel, mem.Size, mem, out _), ResultIs.Successful);
		var defLvl = mem.ToStructure<SAFER_LEVELID>();
		Assert.That((uint)defLvl, Is.Not.Zero);

		mem.Write(SAFER_LEVELID.SAFER_LEVELID_NORMALUSER);
		Assert.That(SaferSetPolicyInformation(SAFER_SCOPEID.SAFER_SCOPEID_USER, SAFER_POLICY_INFO_CLASS.SaferPolicyDefaultLevel, mem.Size, mem), ResultIs.Successful);
		Assert.That(SaferGetPolicyInformation(SAFER_SCOPEID.SAFER_SCOPEID_USER, SAFER_POLICY_INFO_CLASS.SaferPolicyDefaultLevel, mem.Size, mem, out _), ResultIs.Successful);
		Assert.That(mem.ToStructure<SAFER_LEVELID>(), Is.EqualTo(SAFER_LEVELID.SAFER_LEVELID_NORMALUSER));

		mem.Write(defLvl);
		Assert.That(SaferSetPolicyInformation(SAFER_SCOPEID.SAFER_SCOPEID_USER, SAFER_POLICY_INFO_CLASS.SaferPolicyDefaultLevel, mem.Size, mem), ResultIs.Successful);
	}

	[Test]
	public void SaferIdentifyLevelTest()
	{
		var props = new[] { new SAFER_CODE_PROPERTIES_V1 {
			cbSize = (uint)Marshal.SizeOf<SAFER_CODE_PROPERTIES_V1>(),
			dwCheckFlags = (SAFER_CRITERIA)13,
			ImagePath = @"C:\Program Files\WindowsPowerShell\Modules\PowerShellGet\1.0.0.1\PowerShellGet.psd1",
			dwWVTUIChoice = 2
		} };
		Assert.That(SaferIdentifyLevel((uint)props.Length, props, out var hLvl, SRP_POLICY_SCRIPT), ResultIs.Successful);
		hLvl.Dispose();

		var props2 = new[] { new SAFER_CODE_PROPERTIES_V2 {
			cbSize = (uint)Marshal.SizeOf<SAFER_CODE_PROPERTIES_V2>(),
			dwCheckFlags = (SAFER_CRITERIA)13,
			ImagePath = @"C:\Program Files\WindowsPowerShell\Modules\PowerShellGet\1.0.0.1\PowerShellGet.psd1",
			dwWVTUIChoice = 2
		} };
		Assert.That(SaferIdentifyLevel((uint)props.Length, props2, out hLvl, SRP_POLICY_SCRIPT), ResultIs.Successful);
		hLvl.Dispose();
	}

	[Test]
	public void SaferiIsExecutableFileTypeTest() => Assert.That(SaferiIsExecutableFileType(@"C:\Windows\notepad.exe", false), Is.True);

	[Test]
	public void SaferiSearchMatchingHashRulesTest() => Assert.That(SaferiSearchMatchingHashRules(Crypt32.ALG_ID.CALG_MD5, new byte[256], 256, 2048, out _), Is.False);

	[Test]
	public void SaferRecordEventLogEntryTest()
	{
		Assert.That(SaferCreateLevel(SAFER_SCOPEID.SAFER_SCOPEID_USER, SAFER_LEVELID.SAFER_LEVELID_NORMALUSER, SAFER_LEVEL_CREATE_FLAGS.SAFER_LEVEL_OPEN, out var hLvl), ResultIs.Successful);
		using (hLvl)
		{
			// Not sure how to make this return success
			Assert.That(SaferRecordEventLogEntry(hLvl, @"C:\Windows\notepad.exe"), ResultIs.FailureCode(Win32Error.ERROR_NOT_FOUND));
		}
	}
}