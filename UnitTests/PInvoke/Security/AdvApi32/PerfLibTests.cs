using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
[Guid("1232C7F8-4B6F-47A6-9078-8F62CF3F53CB")]
public class PerfLibTests
{
	//private SafePPERF_COUNTERSET_INSTANCE hinst;
	//private SafeHPERFPROV hprov;
	private static readonly Guid provGuid = new("1232C7F8-4B6F-47A6-9078-8F62CF3F53CB");
	private static readonly Guid instGuid = new(0xb4fc721a, 0x378, 0x476f, 0x89, 0xba, 0xa5, 0xa7, 0x9f, 0x81, 0xb, 0x36);
	private static readonly (string name, uint id) instance = ("_Total", 23);
	private const uint counterId = 1;

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
	public void PerfStructSizes()
	{
		foreach (var s in typeof(Vanara.PInvoke.AdvApi32).GetNestedStructSizes("PERF_"))
			TestContext.WriteLine(s);
	}

	private static readonly object[][] QueryIdSources = [
		[new PPERF_COUNTER_IDENTIFIER(instGuid, PERF_WILDCARD_INSTANCE), PerfCounterDataType.PERF_COUNTERSET],
		[new PPERF_COUNTER_IDENTIFIER(instGuid, instance.name, counterId), PerfCounterDataType.PERF_SINGLE_COUNTER],
		[new PPERF_COUNTER_IDENTIFIER(instGuid, instance.name, instanceId: instance.id), PerfCounterDataType.PERF_MULTIPLE_COUNTERS],
		[new PPERF_COUNTER_IDENTIFIER(instGuid, PERF_WILDCARD_INSTANCE, counterId), PerfCounterDataType.PERF_MULTIPLE_INSTANCES],
		[new PPERF_COUNTER_IDENTIFIER(instGuid, instance.name, instanceId: instance.id - 2), PerfCounterDataType.PERF_ERROR_RETURN],
	];

	[TestCaseSource(nameof(QueryIdSources))]
	public void PerfAddCountersTest(PPERF_COUNTER_IDENTIFIER id, PerfCounterDataType expType)
	{
		Assert.That(PerfOpenQueryHandle(null, out var hquery), ResultIs.Successful);
		using (hquery)
		{
			PPERF_COUNTER_IDENTIFIER[] pAdds = [id];
			Assert.That(PerfAddCounters(hquery, pAdds), ResultIs.Successful);
			Assert.That(pAdds[0].Status, ResultIs.Successful);

			//Assert.That(PerfQueryCounterInfo(hquery, out var gets), ResultIs.Successful);
			//Assert.That(gets, Has.Count.EqualTo(1));
			//Assert.That(gets[0].CounterSetGuid, Is.EqualTo(instGuid));
			//Assert.That(gets[0].InstanceName, Is.EqualTo(name));

			Assert.That(PerfQueryCounterData(hquery, out var pDataHdr), ResultIs.Successful);
			ref var hdr = ref pDataHdr.AsRef();
			Assert.That(hdr.dwNumCounters, Is.EqualTo(1));
			Assert.That(hdr.dwTotalSize, Is.GreaterThanOrEqualTo(Marshal.SizeOf<PERF_DATA_HEADER>()));
			hdr.WriteValues();
			var (value, ptr) = PERF_DATA_HEADER.GetCounters(pDataHdr).First();
			value.WriteValues();
			Assert.That(value.dwType, Is.EqualTo(expType));
			switch (value.dwType)
			{
				case PerfCounterDataType.PERF_ERROR_RETURN:
					TestContext.WriteLine($"Error: {value.dwStatus}");
					break;
				case PerfCounterDataType.PERF_SINGLE_COUNTER:
					WriteCntData(PERF_COUNTER_HEADER.GetSingleCounter(ptr));
					break;
				case PerfCounterDataType.PERF_MULTIPLE_COUNTERS:
					PERF_COUNTER_HEADER.GetMultiCounters(ptr).AsRef().WriteValues();
					foreach (var p in PERF_COUNTER_HEADER.GetMultiCountersData(ptr))
						TestContext.WriteLine($"({p.id}) PERF_COUNTER_DATA = {p.data}");
					break;
				case PerfCounterDataType.PERF_MULTIPLE_INSTANCES:
					var pmi = PERF_COUNTER_HEADER.GetMultiInstances(ptr);
					pmi.AsRef().WriteValues();
					foreach (var pih in PERF_MULTI_INSTANCES.GetInstances(pmi))
					{
						pih.AsRef().WriteValues();
						TestContext.WriteLine(PERF_INSTANCE_HEADER.GetInstanceName(pih));
						TestContext.WriteLine($"PERF_COUNTER_DATA={PERF_INSTANCE_HEADER.GetMultiInstData(pih)}");
					}
					break;
				case PerfCounterDataType.PERF_COUNTERSET:
					var pMultiCounters = PERF_COUNTER_HEADER.GetCounterset(ptr);
					pMultiCounters.AsRef().WriteValues();
					TestContext.WriteLine("IDs: " + string.Join(',', PERF_MULTI_COUNTERS.GetDataIds(pMultiCounters).ToArray()));
					var pMultiInstances = PERF_MULTI_COUNTERS.GetMultiInstances(pMultiCounters);
					pMultiInstances.AsRef().WriteValues();
					foreach (var pInstanceHeader in PERF_MULTI_INSTANCES.GetCountersetInstances(pMultiInstances, pMultiCounters.AsRef().dwCounters))
					{
						pInstanceHeader.AsRef().WriteValues();
						TestContext.WriteLine(PERF_INSTANCE_HEADER.GetInstanceName(pInstanceHeader));
						foreach (var pCounterData in PERF_INSTANCE_HEADER.GetCountersetData(pInstanceHeader, pMultiCounters.AsRef().dwCounters))
							WriteCntData(pCounterData);
					}
					break;
				default:
					break;
			}

			PPERF_COUNTER_IDENTIFIER[] pDels = [id];
			Assert.That(PerfDeleteCounters(hquery, pDels), ResultIs.Successful);
			//Assert.That(pDels[0].Status, ResultIs.Successful);
		}

		static StructPointer<PERF_COUNTER_DATA> WriteCntData(StructPointer<PERF_COUNTER_DATA> pCounterData)
		{
			TestContext.WriteLine($"PERF_COUNTER_DATA({pCounterData.AsRef().dwDataSize}) = {PERF_COUNTER_DATA.GetData(pCounterData)}");
			return ((IntPtr)pCounterData).Offset(pCounterData.AsRef().dwSize);
		}
	}

	[TestCaseSource(nameof(QueryIdSources))]
	public unsafe void PerfQueryCounterDataUnsafeTest(PPERF_COUNTER_IDENTIFIER id, PerfCounterDataType expType)
	{
		Assert.That(PerfOpenQueryHandle(null, out var hquery), ResultIs.Successful);
		using (hquery)
		{
			PPERF_COUNTER_IDENTIFIER[] pAdds = [id];
			Assert.That(PerfAddCounters(hquery, pAdds), ResultIs.Successful);
			Assert.That(pAdds[0].Status, ResultIs.Successful);
			Assert.That(PerfQueryCounterData(hquery, out var pDataHdr), ResultIs.Successful);

			PERF_DATA_HEADER* pDataHeader = (PERF_DATA_HEADER*)pDataHdr;
			Assert.That(pDataHeader->dwNumCounters, Is.EqualTo(1));
			Assert.That(pDataHeader->dwTotalSize, Is.GreaterThanOrEqualTo(Marshal.SizeOf<PERF_DATA_HEADER>()));
			(*pDataHeader).WriteValues();
			PERF_COUNTER_HEADER* pCounterHeader = (PERF_COUNTER_HEADER*)(pDataHeader + 1);
			(*pCounterHeader).WriteValues();
			Assert.That(pCounterHeader->dwType, Is.EqualTo(expType));
			switch (pCounterHeader->dwType)
			{
				case PerfCounterDataType.PERF_ERROR_RETURN:
					TestContext.WriteLine($"Error: {pCounterHeader->dwStatus}");
					break;
				case PerfCounterDataType.PERF_SINGLE_COUNTER:
					WriteCntData((PERF_COUNTER_DATA*)(pCounterHeader + 1));
					break;
				case PerfCounterDataType.PERF_MULTIPLE_COUNTERS:
					var pmc = (PERF_MULTI_COUNTERS*)(pCounterHeader + 1);
					(*pmc).WriteValues();
					var ids = new Span<uint>((void*)(pmc + 1), (int)pmc->dwCounters);
					var pcd = (PERF_COUNTER_DATA*)((byte*)pmc + pmc->dwSize);
					for (int i = 0; i < pmc->dwCounters; i++)
					{
						TestContext.Write($"({ids[i]}) ");
						pcd = WriteCntData(pcd);
					}
					break;
				case PerfCounterDataType.PERF_MULTIPLE_INSTANCES:
					var pmi = (PERF_MULTI_INSTANCES*)(pCounterHeader + 1);
					(*pmi).WriteValues();
					var cInstances2 = pmi->dwInstances;
					var pih = (PERF_INSTANCE_HEADER*)(pmi + 1);
					for (int i = 0; i < cInstances2; i++)
					{
						(*pih).WriteValues();
						TestContext.WriteLine(PERF_INSTANCE_HEADER.GetInstanceName(pih));
						var pCounterData = (PERF_COUNTER_DATA*)((byte*)pih + pih->Size);
						pih = (PERF_INSTANCE_HEADER*)WriteCntData(pCounterData);
					}
					break;
				case PerfCounterDataType.PERF_COUNTERSET:
					var pMultiCounters = (PERF_MULTI_COUNTERS*)(pCounterHeader + 1);
					(*pMultiCounters).WriteValues();
					TestContext.WriteLine("IDs: " + string.Join(',', new Span<uint>((void*)(pMultiCounters + 1), (int)pMultiCounters->dwCounters).ToArray()));
					var pMultiInstances = (PERF_MULTI_INSTANCES*)((byte*)pMultiCounters + pMultiCounters->dwSize);
					(*pMultiInstances).WriteValues();
					var cInstances = pMultiInstances->dwInstances;
					var pInstanceHeader = (PERF_INSTANCE_HEADER*)(pMultiInstances + 1);
					for (int i = 0; i < cInstances; i++)
					{
						(*pInstanceHeader).WriteValues();
						TestContext.WriteLine(PERF_INSTANCE_HEADER.GetInstanceName(pInstanceHeader));
						var pCounterData = (PERF_COUNTER_DATA*)((byte*)pInstanceHeader + pInstanceHeader->Size);
						for (int ic = 0; ic < pMultiCounters->dwCounters; ic++)
							pCounterData = WriteCntData(pCounterData);
						pInstanceHeader = (PERF_INSTANCE_HEADER*)pCounterData;
					}
					break;
				default:
					break;
			}

			PPERF_COUNTER_IDENTIFIER[] pDels = [id];
			Assert.That(PerfDeleteCounters(hquery, pDels), ResultIs.Successful);
		}

		static PERF_COUNTER_DATA* WriteCntData(PERF_COUNTER_DATA* pCounterData)
		{
			var pData = (byte*)(pCounterData + 1);
			TestContext.WriteLine($"PERF_COUNTER_DATA({pCounterData->dwDataSize}) = {(pCounterData->dwDataSize == 4 ? *(uint*)pData : *(ulong*)pData)}");
			return (PERF_COUNTER_DATA*)((byte*)pCounterData + pCounterData->dwSize);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	private struct CounterSetStruct
	{
		public PERF_COUNTERSET_INFO CounterSet;
		public PERF_COUNTER_INFO Counter0;
	}

	[Test]
	public void PerfQueryInstanceTest()
	{
		var ProviderGuid = new Guid(0x22222222, 0x2222, 0x2222, 0x22, 0x22, 0x22, 0x22, 0x22, 0x22, 0x22, 0x22);
		var providerContext = PERF_PROVIDER_CONTEXT.Default;
		Assert.That(PerfStartProviderEx(ProviderGuid, providerContext, out var hProvider), ResultIs.Successful);
		Assert.That(hProvider, ResultIs.ValidHandle);

		var CounterSetGuid = new Guid(0x33333333, 0x3333, 0x3333, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33, 0x33);
		var pInfo = new CounterSetStruct
		{
			CounterSet = new(CounterSetGuid, ProviderGuid, 1),
			Counter0 = new(1, (uint)System.Diagnostics.PerformanceData.CounterType.RawData32, sizeof(uint), 100)
		};
		using PinnedObject pCounterSet = new(pInfo);
		Assert.That(PerfSetCounterSetInfo(hProvider, pCounterSet, (uint)Marshal.SizeOf(pInfo)), ResultIs.Successful);
		//Assert.That(PerfQueryCounterSetRegistrationInfo(null, CounterSetGuid, PerfRegInfoType.PERF_REG_COUNTERSET_STRUCT, 0, out byte[] info), ResultIs.Successful);
		//Assert.That(MemoryMarshal.Cast<byte, PERF_COUNTERSET_REG_INFO>(new Span<byte>(info))[0].NumCounters, Is.EqualTo(1));

		using var Object1Instance1 = PerfCreateInstance(hProvider, CounterSetGuid, "Instance_1", 1);
		Assert.That(Object1Instance1, ResultIs.ValidHandle);
		System.Threading.Thread.Sleep(500);

		Assert.That(PerfSetULongCounterValue(hProvider, Object1Instance1, 1, 30U), ResultIs.Successful);
		Assert.That(PerfDecrementULongCounterValue(hProvider, Object1Instance1, 1, 1), ResultIs.Successful);
		Assert.That(PerfIncrementULongCounterValue(hProvider, Object1Instance1, 1, 1), ResultIs.Successful);
		Assert.That(PerfSetCounterRefValue(hProvider, Object1Instance1, 1, new PinnedObject(4U)), ResultIs.Successful);

		// While here, test the other methods.
		Assert.That(PerfEnumerateCounterSet(null, out var ids), ResultIs.Successful);
		Assert.That(ids!.Length, Is.GreaterThan(0));
		ids.WriteValues();

		//Assert.That(PerfEnumerateCounterSetInstances(null, CounterSetGuid, out var instances), ResultIs.Successful);
		//Assert.That(instances.Any());

		PPERF_COUNTERSET_INSTANCE pci;
		Assert.That((IntPtr)(pci = PerfQueryInstance(hProvider, CounterSetGuid, "Instance_1", 1)), ResultIs.ValidHandle);
		ref var pciRef = ref pci.Ref;
		Assert.That(pciRef.CounterSetGuid, Is.EqualTo(CounterSetGuid));
		TestContext.WriteLine($"Instance ID: {pciRef.InstanceId}, Inst Name: {Marshal.PtrToStringUni(((IntPtr)pci).Offset(pciRef.InstanceNameOffset))}");
		//Assert.That(PerfQueryCounterSetRegistrationInfo(null, CounterSetGuid, PerfRegInfoType.PERF_REG_COUNTERSET_STRUCT,
		//	Kernel32.LANG_USER_DEFAULT, default, 0, out var actual), ResultIs.FailureCode(Win32Error.ERROR_NOT_ENOUGH_MEMORY));
	}
}