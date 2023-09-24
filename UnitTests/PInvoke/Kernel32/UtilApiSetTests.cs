using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

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
			PinnedObject pint = new(123);
			IntPtr eptr = EncodePointer(pint);
			Assert.That(eptr, Is.Not.EqualTo(IntPtr.Zero));
			IntPtr dptr = DecodePointer(eptr);
			Assert.That((IntPtr)pint, Is.EqualTo(dptr));
		}, Throws.Nothing);
	}

	[Test]
	public void EncodeRemotePointerTest()
	{
		Assert.That(() =>
		{
			PinnedObject pint = new(123);
			Assert.That(EncodeRemotePointer(GetCurrentProcess(), pint, out IntPtr eptr), ResultIs.Successful);
			Assert.That(eptr, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(DecodeRemotePointer(GetCurrentProcess(), eptr, out IntPtr dptr), ResultIs.Successful);
			Assert.That((IntPtr)pint, Is.EqualTo(dptr));
		}, Throws.Nothing);
	}

	[Test]
	public void EncodeSystemPointerTest()
	{
		Assert.That(() =>
		{
			PinnedObject pint = new(123);
			IntPtr eptr = EncodeSystemPointer(pint);
			Assert.That(eptr, Is.Not.EqualTo(IntPtr.Zero));
			IntPtr dptr = DecodeSystemPointer(eptr);
			Assert.That((IntPtr)pint, Is.EqualTo(dptr));
		}, Throws.Nothing);
	}
}