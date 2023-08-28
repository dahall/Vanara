using NUnit.Framework;

namespace Vanara.InteropServices.Tests;

[TestFixture()]
public class PinnedObjectTests
{
	[Test()]
	public void PinnedObjectTest()
	{
		var iArray = new int[] {4, 3, 2, 1};
		using (var pin = new PinnedObject(iArray))
		{
			Assert.That(Marshal.ReadInt32(pin), Is.EqualTo(4));
			Marshal.WriteInt32(pin, 1);
			Assert.That(Marshal.ReadInt32(pin), Is.EqualTo(1));
		}
		Assert.That(iArray[0], Is.EqualTo(1));
	}

	[Test()]
	public void PinnedObjectTest2()
	{
		var iArray = new int[] {4, 3, 2, 1};
		using var pin = new PinnedObject(iArray, sizeof(int));
		Assert.That(Marshal.ReadInt32((IntPtr)pin), Is.EqualTo(3));
	}

	[Test()]
	public void PinnedObjectTest3()
	{
		using var pin = new PinnedObject(null, sizeof(int));
		Assert.That(pin.IsInvalid);
		Assert.That((IntPtr)pin, Is.EqualTo(IntPtr.Zero));
	}
}