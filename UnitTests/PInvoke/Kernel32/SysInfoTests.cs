using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SysInfoTests
{
	[Test]
	public void DnsHostnameToComputerNameTest()
	{
		Assert.That(GetComputerNameEx(COMPUTER_NAME_FORMAT.ComputerNameDnsFullyQualified, out var name), ResultIs.Successful);
		Assert.That(DnsHostnameToComputerName(name!, out var compName), ResultIs.Successful);
		Assert.That(compName, Is.EqualTo(Environment.MachineName));
		TestContext.WriteLine($"{name} => {compName}");
	}

	[Test]
	public void EnumSystemFirmwareTablesTest()
	{
		Assert.That(EnumSystemFirmwareTables(FirmwareTableProviderId.ACPI, out var ids), ResultIs.Successful);
		Assert.That(ids?.Length, Is.GreaterThan(0));
		ids?.WriteValues();
	}

	[Test]
	public void GetComputerNameTest()
	{
		Assert.That(GetComputerName(out var name), ResultIs.Successful);
		Assert.That(name, Is.EqualTo(Environment.MachineName));
		TestContext.WriteLine(name);
	}

	[Test]
	public void GetFirmwareEnvironmentVariableTest()
	{
		Assert.That(GetFirmwareEnvironmentVariable("", "{00000000-0000-0000-0000-000000000000}", default, 0), Is.EqualTo(0));
	}

	[Test]
	public void GetIntegratedDisplaySizeTest()
	{
		Assert.That(GetIntegratedDisplaySize(out double sz), ResultIs.Successful);
		Assert.That(sz, Is.GreaterThan(10.0));
	}

	[Test]
	public void GetLocalTimeTest()
	{
		GetLocalTime(out SYSTEMTIME st);
		Assert.That(st.Ticks, Is.Not.Zero);
	}

	[Test]
	public void GetLogicalProcessorInformationExTest()
	{
		unsafe
		{
			Assert.That(GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP.RelationGroup, out SafeSYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX_List info), ResultIs.Successful);
			using (info)
			{
				Assert.That(info.Count, Is.GreaterThan(0));
				for (int i = 0; i < info.Count; i++)
				{
					SYSTEM_LOGICAL_PROCESSOR_INFORMATION_EX* pr = info[i];
					switch (pr->Relationship)
					{
						case LOGICAL_PROCESSOR_RELATIONSHIP.RelationNumaNode:
							pr->NumaNode.WriteValues();
							break;
						case LOGICAL_PROCESSOR_RELATIONSHIP.RelationCache:
							pr->Cache.WriteValues();
							break;
						case LOGICAL_PROCESSOR_RELATIONSHIP.RelationProcessorCore:
						case LOGICAL_PROCESSOR_RELATIONSHIP.RelationProcessorPackage:
							pr->Processor.WriteValues();
							break;
						case LOGICAL_PROCESSOR_RELATIONSHIP.RelationGroup:
							pr->Group.WriteValues();
							break;
						default:
							break;
					}
				}
			}
		}
	}

	[Test]
	public void GetLogicalProcessorInformationTest()
	{
		Assert.That(GetLogicalProcessorInformation(out var info), ResultIs.Successful);
		Assert.That(info?.Length, Is.GreaterThan(0));
		info?.WriteValues();
	}

	[Test]
	public void GetNativeSystemInfoTest()
	{
		GetNativeSystemInfo(out SYSTEM_INFO si);
		Assert.That(si.wProcessorRevision, Is.Not.Zero);
		si.WriteValues();
	}

	[Test]
	public void GetOsManufacturingModeTest()
	{
		Assert.That(GetOsManufacturingMode(out bool enabled), ResultIs.Successful);
	}

	[Test]
	public void GetOsSafeBootModeTest()
	{
		Assert.That(GetOsSafeBootMode(out uint flags), ResultIs.Successful);
		TestContext.Write(flags);
	}

	[Test]
	public void GetPhysicallyInstalledSystemMemoryTest()
	{
		Assert.That(GetPhysicallyInstalledSystemMemory(out ulong kb), ResultIs.Successful);
		TestContext.Write(kb);
	}

	[Test]
	public void GetProcessorSystemCycleTimeTest()
	{
		Assert.That(GetProcessorSystemCycleTime(0, out var info), ResultIs.Successful);
		Assert.That(info?.Length, Is.GreaterThan(0));
		info?.WriteValues();
	}

	[Test]
	public void GetProductInfoTest()
	{
		Assert.That(GetProductInfo(6, 3, 0, 0, out PRODUCT_TYPE type), ResultIs.Successful);
		TestContext.Write(type);
	}

	[Test]
	public void GetSystemDirectoryTest()
	{
		Assert.That(GetSystemDirectory(), Has.Length.GreaterThan(0));
	}

	[Test]
	public void GetSystemFirmwareTableTest()
	{
		Assert.That(GetSystemFirmwareTable(FirmwareTableProviderId.FIRM, 0, default, 0), Is.Zero);
	}

	[Test]
	public void GetSystemInfoTest()
	{
		GetSystemInfo(out SYSTEM_INFO si);
		Assert.That(si.wProcessorRevision, Is.Not.Zero);
		si.WriteValues();
	}

	[Test]
	public void GetSystemRegistryQuotaTest()
	{
		Assert.That(GetSystemRegistryQuota(out uint allowed, out uint used), ResultIs.Successful);
		TestContext.Write((allowed, used));
	}

	[Test]
	public void GetSystemTimeTest()
	{
		GetSystemTime(out SYSTEMTIME st);
		Assert.That(st.Ticks, Is.Not.Zero);
	}

	[Test]
	public void GetSystemTimeAdjustmentTest()
	{
		Assert.That(GetSystemTimeAdjustment(out uint adj, out uint inc, out bool disabled), Is.True);
		TestContext.Write((adj, inc, disabled));
	}

	[Test]
	public void GetSystemTimeAdjustmentPreciseTest()
	{
		Assert.That(GetSystemTimeAdjustmentPrecise(out ulong adj, out ulong inc, out bool disabled), Is.True);
		TestContext.Write((adj, inc, disabled));
	}

	[Test]
	public void GetSystemTimeAsFileTimeTest()
	{
		GetSystemTimeAsFileTime(out FILETIME ft);
		Assert.That(ft.ToSYSTEMTIME().Ticks, Is.Not.Zero);
	}

	[Test]
	public void GetSystemTimePreciseAsFileTimeTest()
	{
		GetSystemTimePreciseAsFileTime(out FILETIME ft);
		Assert.That(ft.ToSYSTEMTIME().Ticks, Is.Not.Zero);
	}

	[Test]
	public void GetSystemWindowsDirectoryTest()
	{
		Assert.That(GetSystemWindowsDirectory(), Has.Length.GreaterThan(0));
	}

	[Test]
	public void GetTickCountTest()
	{
		Assert.That(GetTickCount(), Is.Not.Zero);
	}

	[Test]
	public void GetTickCount64Test()
	{
		Assert.That(GetTickCount64(), Is.Not.Zero);
	}

	[Test]
	public void GetVersionTest()
	{
		Assert.That(GetVersion(), Is.Not.Zero);
	}

	[Test]
	public void GetVersionExTest()
	{
		OSVERSIONINFOEX ver = OSVERSIONINFOEX.Default;
		Assert.That(GetVersionEx(ref ver), ResultIs.Successful);
		Assert.That(ver.wProductType, Is.Not.Zero);
		ver.WriteValues();
	}

	[Test]
	public void GetWindowsDirectoryTest()
	{
		Assert.That(GetWindowsDirectory(), Has.Length.GreaterThan(0));
	}

	[Test]
	public void GlobalMemoryStatusTest()
	{
		MEMORYSTATUS status = MEMORYSTATUS.Default;
		GlobalMemoryStatus(ref status);
		Assert.That(status.dwAvailVirtual, Is.Not.Zero);
		status.WriteValues();
	}

	[Test]
	public void GlobalMemoryStatusExTest()
	{
		MEMORYSTATUSEX status = MEMORYSTATUSEX.Default;
		GlobalMemoryStatusEx(ref status);
		Assert.That(status.ullAvailVirtual, Is.Not.Zero);
		status.WriteValues();
	}

	[Test]
	public void VerifyVersionInfoTest()
	{
		ulong mask = VerSetConditionMask(0, VERSION_MASK.VER_PRODUCT_TYPE, VERSION_CONDITION.VER_EQUAL);
		OSVERSIONINFOEX ver = OSVERSIONINFOEX.Default;
		ver.wProductType = ProductType.VER_NT_WORKSTATION;
		Assert.That(VerifyVersionInfo(ref ver, VERSION_MASK.VER_PRODUCT_TYPE, mask), Is.True);
	}
}