using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests
{
	[Test]
	public void ActivateActCtxTest()
	{
		ACTCTX ctx = new(@"C:\Users\dahall\Documents\GitHubRepos\TaskScheduler\TaskSchedulerMockup\app.manifest");
		using SafeHACTCTX hctx = CreateActCtx(ctx);
		Assert.That(hctx, ResultIs.ValidHandle);
		Assert.That(ActivateActCtx(hctx, out IntPtr cookie), ResultIs.Successful);

		Assert.That(() => AddRefActCtx(hctx), Throws.Nothing);
		Assert.That(() => ReleaseActCtx(hctx), Throws.Nothing);

		Assert.That(GetCurrentActCtx(out HACTCTX hctx2), ResultIs.Successful);
		Assert.That(hctx2, ResultIs.ValidHandle);

		Assert.That(RegisterApplicationRestart("cmd.exe", ApplicationRestartFlags.RESTART_NO_REBOOT), ResultIs.Successful);
		StringBuilder sb = new(1024, 1024);
		uint sz = (uint)sb.Capacity;
		Assert.That(GetApplicationRestartSettings(GetCurrentProcess(), sb, ref sz, out ApplicationRestartFlags rFlags), ResultIs.Successful);
		Assert.That(sb.ToString(), Is.EqualTo("cmd.exe"));
		Assert.That(UnregisterApplicationRestart(), ResultIs.Successful);

		Assert.That(RegisterApplicationRecoveryCallback(callback, default, 0), ResultIs.Successful);
		Assert.That(GetApplicationRecoveryCallback(GetCurrentProcess(), out ApplicationRecoveryCallback getCallback, out _, out uint interval, out int callbackFlags), ResultIs.Successful);
		Assert.That(getCallback, Is.Not.Null);
		Assert.That(UnregisterApplicationRecoveryCallback(), ResultIs.Successful);

		sb.Clear();
		Assert.That(QueryActCtxSettingsW(0, hctx, null, "Dummy", sb, sb.Capacity, out SizeT req), ResultIs.Failure);
		Assert.That(() => QueryActCtxW<ACTIVATION_CONTEXT_BASIC_INFORMATION>(QueryActCtxFlag.QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX, SafeHACTCTX.Null, ACTIVATION_CONTEXT_INFO_CLASS.ActivationContextBasicInformation).WriteValues(), Throws.Nothing);
		Assert.That(() => QueryActCtxW<ACTIVATION_CONTEXT_DETAILED_INFORMATION>(QueryActCtxFlag.QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX, SafeHACTCTX.Null, ACTIVATION_CONTEXT_INFO_CLASS.ActivationContextDetailedInformation).WriteValues(), Throws.Nothing);
		Assert.That(() => QueryActCtxW<ACTIVATION_CONTEXT_ASSEMBLY_DETAILED_INFORMATION>(QueryActCtxFlag.QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX, SafeHACTCTX.Null, ACTIVATION_CONTEXT_INFO_CLASS.AssemblyDetailedInformationInActivationContext, 1).WriteValues(), Throws.Nothing);
		Assert.That(() => QueryActCtxW<ACTIVATION_CONTEXT_COMPATIBILITY_INFORMATION>(QueryActCtxFlag.QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX, SafeHACTCTX.Null, ACTIVATION_CONTEXT_INFO_CLASS.CompatibilityInformationInActivationContext).WriteValues(), Throws.Nothing);
		//Assert.That(() => QueryActCtxW<ASSEMBLY_FILE_DETAILED_INFORMATION>(QueryActCtxFlag.QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX, SafeHACTCTX.Null, ACTIVATION_CONTEXT_INFO_CLASS.FileInformationInAssemblyOfAssemblyInActivationContext, new ACTIVATION_CONTEXT_QUERY_INDEX(1, 0)).WriteValues(), Throws.Nothing);
		Assert.That(() => QueryActCtxW<ACTIVATION_CONTEXT_RUN_LEVEL_INFORMATION>(QueryActCtxFlag.QUERY_ACTCTX_FLAG_USE_ACTIVE_ACTCTX, SafeHACTCTX.Null, ACTIVATION_CONTEXT_INFO_CLASS.RunlevelInformationInActivationContext).WriteValues(), Throws.Nothing);

		Assert.That(ZombifyActCtx(hctx), ResultIs.Successful);
		Assert.That(DeactivateActCtx(0, cookie), ResultIs.Successful);

		uint callback(IntPtr pvParameter) => 0U;
	}

	[Test]
	public void ApplicationRecoveryTest()
	{
		// Unable to test functionality so just test for exceptions
		Assert.That(() =>
		{
			ApplicationRecoveryInProgress(out bool c);
			ApplicationRecoveryFinished(true);
		}, Throws.Nothing);
	}

	[Test]
	public void FindActCtxSectionTest()
	{
		// Unable to test functionality so just test for exceptions
		Assert.That(() =>
		{
			FindActCtxSectionGuid(FIND_ACTCTX_SECTION.FIND_ACTCTX_SECTION_KEY_RETURN_ASSEMBLY_METADATA, default, ACTCTX_SECTION.ACTIVATION_CONTEXT_SECTION_APPLICATION_SETTINGS, Guid.NewGuid(), out ACTCTX_SECTION_KEYED_DATA ret);
			FindActCtxSectionString(FIND_ACTCTX_SECTION.FIND_ACTCTX_SECTION_KEY_RETURN_ASSEMBLY_METADATA, default, ACTCTX_SECTION.ACTIVATION_CONTEXT_SECTION_APPLICATION_SETTINGS, "Dummy", out ret);
		}, Throws.Nothing);
	}
}