using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class RealtimeApiSetTests
	{
		[Test]
		public void ConvertAuxiliaryCounterToPerformanceCounterTest()
		{
			ulong aux = (ulong)new Random().Next();
			Assert.That(ConvertAuxiliaryCounterToPerformanceCounter(aux, out var perf, out var err), ResultIs.Successful);
			Assert.That(ConvertPerformanceCounterToAuxiliaryCounter(perf, out var aux2, out err), ResultIs.Successful);
			Assert.That(aux, Is.EqualTo(aux2));
		}

		[Test]
		public void QueryAuxiliaryCounterFrequencyTest()
		{
			Assert.That(QueryAuxiliaryCounterFrequency(out var f), ResultIs.Successful);
			Assert.That(f, Is.Not.Zero);
		}

		[Test]
		public void QueryIdleProcessorCycleTimeTest()
		{
			Assert.That(() => { Assert.That(QueryIdleProcessorCycleTime(), Is.Not.Empty); }, Throws.Nothing);
		}

		[Test]
		public void QueryIdleProcessorCycleTimeExTest()
		{
			Assert.That(() => { Assert.That(QueryIdleProcessorCycleTimeEx(0), Is.Not.Empty); }, Throws.Nothing);
		}

		[Test]
		public void QueryInterruptTimeTest()
		{
			QueryInterruptTime(out var t);
			Assert.That(t, Is.Not.Zero);
		}

		[Test]
		public void QueryInterruptTimePreciseTest()
		{
			QueryInterruptTimePrecise(out var t);
			Assert.That(t, Is.Not.Zero);
		}

		[Test]
		public void QueryProcessCycleTimeTest()
		{
			Assert.That(QueryProcessCycleTime(GetCurrentProcess(), out var t), ResultIs.Successful);
			Assert.That(t, Is.Not.Zero);
		}

		[Test]
		public void QueryThreadCycleTimeTest()
		{
			Assert.That(QueryThreadCycleTime(GetCurrentThread(), out var t), ResultIs.Successful);
			Assert.That(t, Is.Not.Zero);
		}

		[Test]
		public void QueryUnbiasedInterruptTimeTest()
		{
			Assert.That(QueryUnbiasedInterruptTime(out var t), ResultIs.Successful);
			Assert.That(t, Is.Not.Zero);
		}

		[Test]
		public void QueryUnbiasedInterruptTimePreciseTest()
		{
			QueryUnbiasedInterruptTimePrecise(out var t);
			Assert.That(t, Is.Not.Zero);
		}
	}
}