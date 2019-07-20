using NUnit.Framework;
using System;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class UtilApiSetTests
	{
		[Test]
		public void BeepTest()
		{
			Assert.That(Beep(523, 500), Is.True);
			Assert.That(Beep(587, 500), Is.True);
			Assert.That(Beep(659, 500), Is.True);
		}

		[Test]
		public void EncodePointerTest()
		{
			Assert.That(() =>
			{
				var pint = new PinnedObject(123);
				var eptr = EncodePointer(pint);
				Assert.That(eptr, Is.Not.EqualTo(IntPtr.Zero));
				var dptr = DecodePointer(eptr);
				Assert.That((IntPtr)pint, Is.EqualTo(dptr));
			}, Throws.Nothing);
		}

		[Test]
		public void EncodeRemotePointerTest()
		{
			Assert.That(() =>
			{
				var pint = new PinnedObject(123);
				Assert.That(EncodeRemotePointer(GetCurrentProcess(), pint, out var eptr), ResultIs.Successful);
				Assert.That(eptr, Is.Not.EqualTo(IntPtr.Zero));
				Assert.That(DecodeRemotePointer(GetCurrentProcess(), eptr, out var dptr), ResultIs.Successful);
				Assert.That((IntPtr)pint, Is.EqualTo(dptr));
			}, Throws.Nothing);
		}

		[Test]
		public void EncodeSystemPointerTest()
		{
			Assert.That(() =>
			{
				var pint = new PinnedObject(123);
				var eptr = EncodeSystemPointer(pint);
				Assert.That(eptr, Is.Not.EqualTo(IntPtr.Zero));
				var dptr = DecodeSystemPointer(eptr);
				Assert.That((IntPtr)pint, Is.EqualTo(dptr));
			}, Throws.Nothing);
		}
	}
}