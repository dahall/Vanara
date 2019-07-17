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
	public class SystemTopologyTests
	{
		[Test]
		public void GetNumaHighestNodeNumberTest()
		{
			Assert.That(GetNumaHighestNodeNumber(out var highNode), ResultIs.Successful);
			Assert.That(highNode, Is.InRange(0, Environment.ProcessorCount - 1));
		}

		[Test]
		public void GetNumaNodeProcessorMaskExTest()
		{
			GetNumaHighestNodeNumber(out var n);
			Assert.That(GetNumaNodeProcessorMaskEx((ushort)n, out var ga), ResultIs.Successful);
			Assert.That(ga.Group, Is.InRange(0, Environment.ProcessorCount - 1));
		}

		[Test]
		public void GetNumaProximityNodeExTest()
		{
			Assert.That(GetNumaProximityNodeEx(0, out var n), ResultIs.Successful);
		}
	}
}