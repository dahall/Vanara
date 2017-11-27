using NUnit.Framework;
using Vanara.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class GenericSafeHandleTests
	{
		[Test]
		public void GenericSafeHandleTest()
		{
			var h = new GenericSafeHandle(new IntPtr(1), p => true, true);
			Assert.That(!h.IsInvalid && !h.IsClosed && h.DangerousGetHandle().ToInt32() == 1);
			h.Dispose();
			Assert.That(h.IsInvalid);
			Assert.That(h.IsClosed);
			Assert.That(h.DangerousGetHandle() == IntPtr.Zero);
			h = new GenericSafeHandle(IntPtr.Zero, p => true);
			Assert.That(h.IsInvalid);
		}

		[Test]
		public void GenericSafeHandleTest1()
		{
			var h = new GenericSafeHandle(p => true);
			Assert.That(h.IsInvalid && h.DangerousGetHandle() == IntPtr.Zero);
			Assert.That(IntPtr.Zero.Equals((IntPtr)h));
			h.Dispose();
		}

		[Test]
		public void GenericSafeHandleTest2()
		{
			var h = new GenericSafeHandle2();
			Assert.That(h.ForceRelease, Is.True);
		}

		private class GenericSafeHandle2 : GenericSafeHandle
		{
			public GenericSafeHandle2() {  }
			public bool ForceRelease => ReleaseHandle();
		}
	}
}