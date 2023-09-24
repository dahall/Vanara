using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests
{
	[Test]
	public void AddLocalAlternateComputerNameTest()
	{
		Assert.That(AddLocalAlternateComputerName("BadName"), ResultIs.Successful);
	}

	[Test]
	public void AddRemoveSecureMemoryCacheCallbackTest()
	{
		Assert.That(AddSecureMemoryCacheCallback(callback), ResultIs.Successful);
		Assert.That(RemoveSecureMemoryCacheCallback(callback), ResultIs.Successful);

		bool callback(IntPtr Addr, SizeT Range) => true;
	}

	[Test]
	public void BaseFlushAppcompatCacheTest()
	{
		Assert.That(BaseFlushAppcompatCache(), ResultIs.Successful);
	}

	[Test]
	public void CopyInitializeContextTest()
	{
		// Calls InitializeContext
		Assert.That(InitializeContext(CONTEXT_FLAG.CONTEXT_ALL, out SafeCONTEXT pCtx), ResultIs.Successful);
		Assert.That(pCtx, ResultIs.ValidHandle);

		// Calls CopyContext
		Assert.That(pCtx.Clone(CONTEXT_FLAG.CONTEXT_ALL), ResultIs.ValidHandle);

		pCtx.Dispose();
	}

	[Test]
	public void EnableThreadProfilingTest()
	{
		Assert.That(EnableThreadProfiling(GetCurrentThread(), 0, 1, out PerformanceDataHandle hPD), ResultIs.Successful);
		Assert.That(QueryThreadProfiling(GetCurrentThread(), out bool enabled), ResultIs.Successful);
		Assert.That(enabled);
		PERFORMANCE_DATA pd = PERFORMANCE_DATA.Default;
		Assert.That(ReadThreadProfilingData(hPD, READ_THREAD_PROFILING_FLAG.READ_THREAD_PROFILING_FLAG_HARDWARE_COUNTERS, ref pd), ResultIs.Successful);
		pd.WriteValues();
		Assert.That(DisableThreadProfiling(hPD), ResultIs.Successful);
	}

	[Test]
	public void GetActiveProcessorCountTest()
	{
		ushort gc = GetActiveProcessorGroupCount();
		Assert.That(gc, ResultIs.Not.Value(0));
		uint pc = GetActiveProcessorCount(--gc);
		Assert.That(pc, ResultIs.Not.Value(0));
	}

	[Test]
	public void GetBinaryTypeTest()
	{
		Assert.That(GetBinaryType(Environment.ExpandEnvironmentVariables("%WINDIR%\\notepad.exe"), out SCS type), ResultIs.Successful);
		Assert.That(type.IsValid(), Is.True);
	}

	[Test]
	public void GetComPlusPackageInstallStatusTest()
	{
		Assert.That(GetComPlusPackageInstallStatus(), Is.InRange(0, 1));
	}

	[Test]
	public void GetEnabledXStateFeaturesTest()
	{
		Assert.That(GetEnabledXStateFeatures(), Is.Not.Zero);
	}

	[Test]
	public void GetMaximumProcessorCountTest()
	{
		ushort gc = GetMaximumProcessorGroupCount();
		if (gc == 0)
			Assert.Fail(Win32Error.GetLastError().ToString());
		uint pc = GetMaximumProcessorCount(--gc);
		if (pc == 0)
			Assert.Fail(Win32Error.GetLastError().ToString());
	}

	[Test]
	public void GetSetFirmwareEnvironmentVariableExTest()
	{
		uint val = 256U;
		PinnedObject pval = new(val);
		VARIABLE_ATTRIBUTE attr = 0U;
		Guid guid = Guid.Empty;
		using (new ElevPriv("SeSystemEnvironmentPrivilege"))
		{
			Assert.That(GetFirmwareEnvironmentVariableEx("Test", guid.ToString("B"), pval, 4, out attr), ResultIs.Successful);
			Assert.That(SetFirmwareEnvironmentVariableEx("Test", guid.ToString("B"), pval, 4, attr), ResultIs.Failure);
		}
	}

	[Test]
	public void GetSetProcessDEPPolicyTest()
	{
		Assert.That(GetProcessDEPPolicy(GetCurrentProcess(), out PROCESS_DEP dep, out bool perm), ResultIs.Successful);
		Assert.That(dep.IsValid(), Is.True);
		Assert.That(SetProcessDEPPolicy(dep), ResultIs.Failure);
	}

	[Test]
	public void GetSetXStateFeaturesMaskTest()
	{
		using SafeCONTEXT hCtx = new(CONTEXT_FLAG.CONTEXT_ALL);
		Assert.That(GetXStateFeaturesMask(hCtx, out ulong feat), ResultIs.Successful);
		Assert.That(SetXStateFeaturesMask(hCtx, feat), ResultIs.Successful);
	}

	[Test]
	public void GetSystemDEPPolicyTest()
	{
		Assert.That(GetSystemDEPPolicy().IsValid(), Is.True);
	}

	[Test]
	public void IsNativeVhdBootTest()
	{
		Assert.That(IsNativeVhdBoot(out bool native), ResultIs.Successful);
		Assert.That(native, Is.False);
	}

	[Test]
	public void LoadPackagedLibraryTest()
	{
		Assert.That(LoadPackagedLibrary("kernel32").IsInvalid, Is.True);
	}

	[Test]
	public void LocateXStateFeatureTest()
	{
		using SafeCONTEXT hCtx = new(CONTEXT_FLAG.CONTEXT_ALL);
		Assert.That(LocateXStateFeature(hCtx, 0, out uint len), Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void lstrcmpiTest()
	{
		Assert.That(lstrcmpi("xx", "XX"), Is.Zero);
		Assert.That(lstrcmpi(null, "XX"), Is.Not.Zero);
	}

	[Test]
	public void lstrcmpTest()
	{
		Assert.That(lstrcmp("XX", "XX"), Is.Zero);
		Assert.That(lstrcmp(null, "XX"), Is.Not.Zero);
	}

	[Test]
	public void lstrcpynTest()
	{
		StringBuilder sb = new("ABCDEFGHIJ", 40);
		Assert.That(lstrcpyn(sb, "1234", 3), Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(sb.ToString(), Is.EqualTo("12"));
	}

	[Test]
	public void lstrlenTest()
	{
		Assert.That(lstrlen("1234"), Is.EqualTo(4));
		Assert.That(lstrlen(null), Is.Zero);
	}

	[Test]
	public void MulDivTest()
	{
		Assert.That(MulDiv(0x60000000, 0x60000000, 0x7FFFFFFF), Is.EqualTo(1207959553));
	}

	[Test]
	public void PowerRequestTest()
	{
		using (SafePowerRequestObject h = PowerCreateRequest(new REASON_CONTEXT("Just because")))
		{
			Assert.That(h, ResultIs.ValidHandle);
			Assert.That(PowerSetRequest(h, POWER_REQUEST_TYPE.PowerRequestSystemRequired), ResultIs.Successful);
			Assert.That(PowerClearRequest(h, POWER_REQUEST_TYPE.PowerRequestSystemRequired), ResultIs.Successful);
		}
		using SafeHINSTANCE l = LoadLibraryEx("user32.dll", LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
		using SafePowerRequestObject h1 = PowerCreateRequest(new REASON_CONTEXT(l, 800));
		Assert.That(h1, ResultIs.ValidHandle);
	}

	[Test]
	public void QueryFullProcessImageNameTest()
	{
		StringBuilder sb = new(MAX_PATH);
		uint sz = (uint)sb.Capacity;
		Assert.That(QueryFullProcessImageName(GetCurrentProcess(), PROCESS_NAME.PROCESS_NAME_WIN32, sb, ref sz), ResultIs.Successful);
		Assert.That(sb.ToString(), Is.Not.Empty);
	}

	[Test]
	public void SetSearchPathModeTest()
	{
		Assert.That(SetSearchPathMode(BASE_SEARCH_PATH.BASE_SEARCH_PATH_ENABLE_SAFE_SEARCHMODE), ResultIs.Successful);
	}

	[Test]
	public void TermsrvAppInstallModeTest()
	{
		Assert.That(TermsrvAppInstallMode(), Is.False);
	}

	[Test]
	public void Wow64GetSetThreadContextTest()
	{
		using SafeHTHREAD hThread = CreateThread(null, 0, p => { for (int i = 0; i < 4; i++) Sleep(250); return 0; }, default, 0, out _);
		Assert.That(Wow64SuspendThread(hThread), Is.Not.EqualTo(uint.MaxValue));
		//var ctx = new WOW64_CONTEXT { ContextFlags = WOW64_CONTEXT_FLAGS.WOW64_CONTEXT_CONTROL };
		//Assert.That(Wow64GetThreadContext(hThread, ref ctx), ResultIs.Failure);
		//Assert.That(Wow64SetThreadContext(hThread, ctx), ResultIs.Failure);
		ResumeThread(hThread);
		TerminateThread(hThread, 0);
	}

	[Test]
	public void Wow64GetThreadSelectorEntryTest()
	{
		Assert.That(Wow64GetThreadSelectorEntry(GetCurrentThread(), 0, out WOW64_LDT_ENTRY entry), ResultIs.Successful);
		entry.WriteValues();
	}
}