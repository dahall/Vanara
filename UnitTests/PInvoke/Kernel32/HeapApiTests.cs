using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class HeapApiTests
{
	[Test]
	public void GetProcessHeapTest()
	{
		Assert.That(GetProcessHeap().DangerousGetHandle(), Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void GetProcessHeapsTest()
	{
		Assert.That(GetProcessHeaps(), Is.Not.Empty);
	}

	[Test]
	public void HeapCreateAllocReallocFreeDestroyValidateTest()
	{
		using SafeHHEAP h = HeapCreate(HeapFlags.HEAP_REALLOC_IN_PLACE_ONLY, 512, 2048);
		Assert.That(h.IsInvalid, Is.False);
		using SafeHeapBlock hb = HeapAlloc(h, 0, 256);
		Assert.That(hb.IsInvalid, Is.False);
		Assert.That((uint)HeapSize(h, HeapFlags.HEAP_REALLOC_IN_PLACE_ONLY, hb), Is.EqualTo(256));
		using SafeHeapBlock hrb = HeapReAlloc(h, HeapFlags.HEAP_REALLOC_IN_PLACE_ONLY, hb, 1024);
		Assert.That(hrb.IsInvalid, Is.False);
		Assert.That(hb.IsClosed, Is.True);
		Assert.That(HeapValidate(h, HeapFlags.HEAP_REALLOC_IN_PLACE_ONLY, hrb), Is.True);
	}

	[Test]
	public void HeapLockUnlockTest()
	{
		using SafeHHEAP h = HeapCreate(HeapFlags.HEAP_REALLOC_IN_PLACE_ONLY, 512, 2048);
		Assert.That(h.IsInvalid, Is.False);
		Assert.That(HeapLock(h), Is.True);
		Assert.That(HeapUnlock(h), Is.True);
	}

	[Test]
	public void HeapQuerySetInformationTest()
	{
		using SafeHHEAP h = HeapCreate(HeapFlags.HEAP_REALLOC_IN_PLACE_ONLY, 512, 2048);
		Assert.That(h.IsInvalid, Is.False);
		Assert.That(() => HeapSetInformation(h, HEAP_INFORMATION_CLASS.HeapOptimizeResources, new HEAP_OPTIMIZE_RESOURCES_INFORMATION(0)), Throws.Nothing);
		// Not possible under debugger
		// Assert.That(() => HeapSetInformation(h, HEAP_INFORMATION_CLASS.HeapCompatibilityInformation, HeapCompatibility.HEAP_STANDARD), Throws.Nothing);
		Assert.That(HeapSetInformation(h, HEAP_INFORMATION_CLASS.HeapEnableTerminationOnCorruption, default, 0), Is.True);
		Assert.That(() =>
		{
			HeapCompatibility t = HeapQueryInformation<HeapCompatibility>(h, HEAP_INFORMATION_CLASS.HeapCompatibilityInformation);
			Assert.That((uint)t, Is.LessThanOrEqualTo(2));
		}, Throws.Nothing);
	}

	[Test]
	public void HeapSummaryTest()
	{
		HEAP_SUMMARY summary = HEAP_SUMMARY.Default;
		Assert.That(HeapSummary(HHEAP.FromProcess(), 0, ref summary), Is.True);
		TestContext.WriteLine($"{summary.cbAllocated} : {summary.cbCommitted} : {summary.cbReserved} : {summary.cbMaxReserve}");
	}

	[Test]
	public void HeapWalkTest()
	{
		Assert.That(HeapWalk(HHEAP.FromProcess()), Is.Not.Empty);
	}
}