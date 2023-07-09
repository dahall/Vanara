using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
[Guid("1232C7F8-4B6F-47A6-9078-8F62CF3F53CB")]
public class PerfLibTests
{
	//private SafePPERF_COUNTERSET_INSTANCE hinst;
	//private SafeHPERFPROV hprov;
	private static readonly Guid provGuid = new("1232C7F8-4B6F-47A6-9078-8F62CF3F53CB");
	private static readonly Guid instGuid = new("1232C7F9-4B6F-47A6-9078-8F62CF3F53CB");

	//[OneTimeSetUp]
	//public void _Setup()
	//{
	//	provGuid = Guid.NewGuid();
	//	instGuid = Guid.NewGuid();
	//	Assert.That(PerfStartProvider(provGuid, null, out hprov), ResultIs.Successful);
	//	hinst = PerfCreateInstance(hprov, instGuid, "MyPerfInst", 256);
	//	Assert.That(hinst, ResultIs.ValidHandle);
	//}

	//[OneTimeTearDown]
	//public void _TearDown()
	//{
	//	hprov?.Dispose();
	//	hinst?.Dispose();
	//}

	[Test]
	public void PerfAddCountersTest()
	{
		Assert.That(PerfOpenQueryHandle(null, out var hquery), ResultIs.Successful);
		using (hquery)
		{
			var pc = PERF_COUNTER_IDENTIFIER_WITH_INST_NAME.Default;
			pc.CounterSetGuid = instGuid;
			pc.CounterId = pc.InstanceId = PERF_WILDCARD_COUNTER;
			pc.InstanceName = "MyName";
			var adds = new[] { pc };
			Assert.That(PerfAddCounters(hquery, adds, (uint)adds.Length), ResultIs.Successful);
			var gets = new[] { PERF_COUNTER_IDENTIFIER_WITH_INST_NAME.Default };
			Assert.That(PerfQueryCounterInfo(hquery, gets, (uint)gets.Length, out _), ResultIs.Successful);
			Assert.That(PerfDeleteCounters(hquery, adds, (uint)adds.Length), ResultIs.Successful);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct CounterSetStruct
	{
		public PERF_COUNTERSET_INFO CounterSet;
		public PERF_COUNTER_INFO Counter0;
		public PERF_COUNTER_INFO Counter1;
	}

	[Test]
	public void PerfQueryInstanceTest()
	{
		var GeometricWaveGuid = new Guid(0xffeeaadd, 0xc923, 0x4794, 0xb6, 0x96, 0x70, 0x57, 0x76, 0x30, 0xb5, 0xcf);
		var UserModeCountersSampleGuid = new Guid(0xffeeaadd, 0x965a, 0x4cf9, 0x9c, 0x7, 0xfe, 0x25, 0x37, 0x8c, 0x2a, 0x23);
		var GeometricWaveInfo = new CounterSetStruct
		{
			CounterSet = new PERF_COUNTERSET_INFO
			{
				CounterSetGuid = GeometricWaveGuid,
				ProviderGuid = UserModeCountersSampleGuid,
				NumCounters = 2,
				InstanceType = 6
			},
			Counter0 = new PERF_COUNTER_INFO
			{
				CounterId = 1,
				Type = (uint)System.Diagnostics.PerformanceData.CounterType.RawData32,
				Size = 4,
				DetailLevel = 100
			},
			Counter1 = new PERF_COUNTER_INFO
			{
				CounterId = 2,
				Type = (uint)System.Diagnostics.PerformanceData.CounterType.RawData32,
				Size = 4,
				DetailLevel = 100
			}
		};

		var ProviderContext = PERF_PROVIDER_CONTEXT.Default;
		Assert.That(PerfStartProviderEx(UserModeCountersSampleGuid, ProviderContext, out var UserModeCountersSample), ResultIs.Successful);
		using (UserModeCountersSample)
		{
			Assert.That(PerfSetCounterSetInfo(UserModeCountersSample, ref GeometricWaveInfo.CounterSet, (uint)Marshal.SizeOf(GeometricWaveInfo)), ResultIs.Successful);

			using var Object1Instance1 = PerfCreateInstance(UserModeCountersSample, GeometricWaveGuid, "Instance_1", 0);
			using var Object1Instance2 = PerfCreateInstance(UserModeCountersSample, GeometricWaveGuid, "Instance_2", 0);
			using var Object1Instance3 = PerfCreateInstance(UserModeCountersSample, GeometricWaveGuid, "Instance_3", 0);
			Assert.That(Object1Instance1, ResultIs.ValidHandle);
			Assert.That(Object1Instance2, ResultIs.ValidHandle);
			Assert.That(Object1Instance3, ResultIs.ValidHandle);

			Assert.That(PerfSetULongCounterValue(UserModeCountersSample, Object1Instance1, 1, 30U), ResultIs.Successful);
			Assert.That(PerfDecrementULongCounterValue(UserModeCountersSample, Object1Instance1, 1, 1), ResultIs.Successful);
			Assert.That(PerfIncrementULongCounterValue(UserModeCountersSample, Object1Instance1, 1, 1), ResultIs.Successful);
			Assert.That(PerfSetCounterRefValue(UserModeCountersSample, Object1Instance1, 1, new PinnedObject(4U)), ResultIs.Successful);

			// While here, test the other methods.
			var ids = new Guid[50];
			Assert.That(PerfEnumerateCounterSet(Environment.MachineName, ids, (uint)ids.Length, out var actual), ResultIs.Successful);
			Assert.That(actual, Is.GreaterThan(0));
			Assert.That(PerfEnumerateCounterSetInstances(Environment.MachineName, GeometricWaveGuid, default, 0, out actual), ResultIs.FailureCode(Win32Error.ERROR_NOT_ENOUGH_MEMORY));
			Assert.That(actual, Is.GreaterThan(0));
			using (var mem = new SafeHGlobalHandle(actual))
			{
				Assert.That(PerfEnumerateCounterSetInstances(Environment.MachineName, GeometricWaveGuid, mem, mem.Size, out actual), ResultIs.Successful);
			}
			Assert.That(PerfQueryInstance(UserModeCountersSample, GeometricWaveGuid, "Instance_1", 0), ResultIs.ValidHandle);
			Assert.That(PerfQueryCounterSetRegistrationInfo(Environment.MachineName, GeometricWaveGuid, PerfRegInfoType.PERF_REG_COUNTERSET_STRUCT,
				Kernel32.LANG_USER_DEFAULT, default, 0, out actual), ResultIs.FailureCode(Win32Error.ERROR_NOT_ENOUGH_MEMORY));
		}
	}
}