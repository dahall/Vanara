using NUnit.Framework;

namespace Vanara.InteropServices.Tests;

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
	public void GenericSafeHandleCloseMethodNull()
	{
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
		Assert.Throws<ArgumentNullException>(() => new GenericSafeHandle((IntPtr)1, null));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
	}

	[Test]
	public void GenericSafeHandleCloseMethodTest()
	{
		var i = 0;
		using (var h = new GenericSafeHandleWithSetHandle(ptr =>
		{
			i = 1;
			return true;
		}))
		{
			h.SetHandle((IntPtr)1);	
		}

		Assert.AreEqual(1, i);
	}
	
	
	private class GenericSafeHandleWithSetHandle : GenericSafeHandle
	{
		public GenericSafeHandleWithSetHandle(Func<IntPtr, bool> closeMethod) : base(closeMethod)
		{}

		public new void SetHandle(IntPtr handle)
		{
			base.SetHandle(handle);
		}
	}

	[Test]
	public void GenericSafeHandleCloseMethodWithHandleTest()
	{
		var i = 0;
		using (new GenericSafeHandle((IntPtr)1, ptr =>
		{
			i = 1;
			return true;
		}))
		{
		}

		Assert.AreEqual(1, i);
	}

	[Test]
	public void GenericSafeHandleTest1()
	{
		var h = new GenericSafeHandle(p => true);
		Assert.That(h.IsInvalid && h.DangerousGetHandle() == IntPtr.Zero);
		Assert.That(IntPtr.Zero.Equals(h.DangerousGetHandle()));
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