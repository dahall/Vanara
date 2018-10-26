using NUnit.Framework;
using System;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class SysInfoTests
	{
		[Test]
		public void EnumSystemFirmwareTablesTest()
		{
			Assert.That(EnumSystemFirmwareTables(FirmwareTableProviderId.ACPI, out var ids), Is.EqualTo(Win32Error.ERROR_SUCCESS));
			Assert.That(ids.Length, Is.GreaterThan(0));
		}

		[Test]
		public void GetLogGetLogicalProcessorInformationTest()
		{
			Assert.That(GetLogicalProcessorInformation(out var info), Is.EqualTo(Win32Error.ERROR_SUCCESS));
			Assert.That(info.Length, Is.GreaterThan(0));
		}

		[Test]
		public void GetLogGetLogicalProcessorInformationExTest()
		{
			Assert.That(GetLogicalProcessorInformationEx(LOGICAL_PROCESSOR_RELATIONSHIP.RelationGroup, out var info), Is.EqualTo(Win32Error.ERROR_SUCCESS));
			Assert.That(info.Length, Is.GreaterThan(0));
		}

		[Test]
		public void GetProcessorSystemCycleTimeTest()
		{
			Assert.That(GetProcessorSystemCycleTime(0, out var info), Is.EqualTo(Win32Error.ERROR_SUCCESS));
			Assert.That(info.Length, Is.GreaterThan(0));
		}

		[Test]
		public void GetComputerNameExTest()
		{
			Assert.That(GetComputerNameEx(COMPUTER_NAME_FORMAT.ComputerNameDnsFullyQualified, out var name));
			Assert.That(name, Is.Not.Null);
			TestContext.WriteLine(name);
		}
	}
}