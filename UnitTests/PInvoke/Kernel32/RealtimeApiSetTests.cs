using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class RealtimeApiSetTests
{
	//[Test]
	public void ConvertAuxiliaryCounterToPerformanceCounterTest()
	{
		ulong aux = (ulong)new Random().Next();
		Assert.That(ConvertAuxiliaryCounterToPerformanceCounter(aux, out ulong perf, out ulong err), ResultIs.Successful);
		Assert.That(ConvertPerformanceCounterToAuxiliaryCounter(perf, out ulong aux2, out err), ResultIs.Successful);
		Assert.That(aux, Is.EqualTo(aux2));
	}

	[Test]
	public void QueryAuxiliaryCounterFrequencyTest()
	{
		Assert.That(QueryAuxiliaryCounterFrequency(out ulong f), ResultIs.Successful);
		Assert.That(f, Is.Not.Zero);
	}

	[Test]
	public void QueryIdleProcessorCycleTimeTest() => Assert.That(() => { Assert.That(QueryIdleProcessorCycleTime(), Is.Not.Empty); }, Throws.Nothing);

	[Test]
	public void QueryIdleProcessorCycleTimeExTest() => Assert.That(() => { Assert.That(QueryIdleProcessorCycleTimeEx(0), Is.Not.Empty); }, Throws.Nothing);

	[Test]
	public void QueryInterruptTimeTest()
	{
		QueryInterruptTime(out ulong t);
		Assert.That(t, Is.Not.Zero);
	}

	[Test]
	public void QueryInterruptTimePreciseTest()
	{
		QueryInterruptTimePrecise(out ulong t);
		Assert.That(t, Is.Not.Zero);
	}

	[Test]
	public void QueryProcessCycleTimeTest()
	{
		Assert.That(QueryProcessCycleTime(GetCurrentProcess(), out ulong t), ResultIs.Successful);
		Assert.That(t, Is.Not.Zero);
	}

	[Test]
	public void QueryThreadCycleTimeTest()
	{
		Assert.That(QueryThreadCycleTime(GetCurrentThread(), out ulong t), ResultIs.Successful);
		Assert.That(t, Is.Not.Zero);
	}

	[Test]
	public void QueryUnbiasedInterruptTimeTest()
	{
		Assert.That(QueryUnbiasedInterruptTime(out ulong t), ResultIs.Successful);
		Assert.That(t, Is.Not.Zero);
	}

	[Test]
	public void QueryUnbiasedInterruptTimePreciseTest()
	{
		QueryUnbiasedInterruptTimePrecise(out ulong t);
		Assert.That(t, Is.Not.Zero);
	}
}