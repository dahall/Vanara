using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PsApiTests
{
	[Test]
	public void EmptyWorkingSetTest() => Assert.That(EmptyWorkingSet(GetCurrentProcess()), Is.True);

	[Test]
	public void EnumDeviceDriversTest() => Assert.That(EnumDeviceDrivers(), Is.Not.Empty);

	[Test]
	public void EnumPageFilesTest() => Assert.That(EnumPageFiles(), Is.Not.Empty);

	[Test]
	public void EnumProcessesTest() => Assert.That(EnumProcesses(), Is.Not.Empty);

	[Test]
	public void EnumProcessModulesExTest() => Assert.That(EnumProcessModulesEx(GetCurrentProcess()), Is.Not.Empty);

	[Test]
	public void EnumProcessModulesTest() => Assert.That(EnumProcessModules(GetCurrentProcess()), Is.Not.Empty);

	[Test]
	public void GetDeviceDriverBaseFileNameTest()
	{
		IntPtr imgBase = EnumDeviceDrivers()[0];
		StringBuilder sb = new(MAX_PATH);
		Assert.That(GetDeviceDriverBaseName(imgBase, sb, (uint)sb.Capacity), Is.Not.Zero);
		TestContext.Write(sb + " : ");
		sb.Clear();
		Assert.That(GetDeviceDriverFileName(imgBase, sb, (uint)sb.Capacity), Is.Not.Zero);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetModuleInformationTest()
	{
		HINSTANCE hMod = EnumProcessModules(GetCurrentProcess())[0];
		StringBuilder sb = new(MAX_PATH);
		Assert.That(GetModuleBaseName(GetCurrentProcess(), hMod, sb, (uint)sb.Capacity), Is.Not.Zero);
		TestContext.WriteLine(sb);
		Assert.That(GetModuleInformation(GetCurrentProcess(), hMod, out MODULEINFO modInfo, (uint)Marshal.SizeOf<MODULEINFO>()), Is.True);
		TestContext.WriteLine(modInfo.SizeOfImage);
	}

	[Test]
	public void GetPerformanceInfoTest()
	{
		Assert.That(GetPerformanceInfo(out PERFORMANCE_INFORMATION pi, PERFORMANCE_INFORMATION.Default.cb), Is.True);
		TestContext.WriteLine($"PgSz = {pi.PageSize}");
	}

	[Test]
	public void GetProcessImageFileNameTest()
	{
		StringBuilder sb = new(MAX_PATH);
		Assert.That(GetProcessImageFileName(GetCurrentProcess(), sb, (uint)sb.Capacity), Is.Not.Zero);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetProcessMemoryInfoTest()
	{
		Assert.That(GetProcessMemoryInfo(GetCurrentProcess(), out PROCESS_MEMORY_COUNTERS cnt, PROCESS_MEMORY_COUNTERS.Default.cb), Is.True);
		TestContext.WriteLine($"PgUse = {cnt.PeakPagefileUsage}");

		Assert.That(GetProcessMemoryInfo(GetCurrentProcess(), out PROCESS_MEMORY_COUNTERS_EX cntex, PROCESS_MEMORY_COUNTERS_EX.Default.cb), Is.True);
		TestContext.WriteLine($"PvUse = {cntex.PrivateUsage}");
	}

	[Test]
	public void QueryWorkingSetTest() => Assert.That(QueryWorkingSet(GetCurrentProcess()), Is.Not.Empty);

	[Test]
	public void QueryWorkingSetExTest() => Assert.That(() =>
												{
													PSAPI_WORKING_SET_EX_INFORMATION[] info = QueryWorkingSetEx(GetCurrentProcess());
													Assert.That(info, Is.Not.Empty);
													PSAPI_WORKING_SET_EX_INFORMATION i1 = QueryWorkingSetEx(GetCurrentProcess(), info[0].VirtualAddress)[0];
													Assert.That(i1.VirtualAddress, Is.EqualTo(info[0].VirtualAddress));
													Assert.That(i1.VirtualAttributes.Valid, Is.True);
												}, Throws.Nothing);

	[Test]
	public void WsWatchExTest()
	{
		Assert.That(InitializeProcessForWsWatch(GetCurrentProcess()), ResultIs.Successful);
		Assert.That(() => GetWsChangesEx(GetCurrentProcess()), Throws.Nothing);
	}

	[Test]
	public void WsWatchTest()
	{
		Assert.That(InitializeProcessForWsWatch(GetCurrentProcess()), ResultIs.Successful);
		Assert.That(GetWsChanges(GetCurrentProcess()), Is.Not.Empty);
	}
}