using NUnit.Framework;
using System.Collections.Generic;

namespace Vanara.InteropServices.Tests;

[TestFixture]
public class SafeMemoryHandleTests
{
	static readonly byte[] bytes = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
	static readonly byte[] bad = [6, 7, 8, 9, 10];

	[Test]
	public void EqualsTest()
	{
		using SafeAllocatedMemoryHandle a = new SafeCoTaskMemHandle(bytes);
		using SafeAllocatedMemoryHandle b = new SafeNativeArray<byte>(bytes);
		using SafeAllocatedMemoryHandle c = new SafeNativeArray<byte>(bad);

		// IntPtr
		Assert.That(a.Equals(a.DangerousGetHandle()));
		Assert.That(!a.Equals(b.DangerousGetHandle()));

		// SafeAllocatedMemoryHandle
		Assert.That(a.Equals(b));
		Assert.That(b.Equals(a));

		Assert.That(!a.Equals(c));
		Assert.That(!c.Equals(a));

		// Null and invalid
		Assert.That(!a.Equals(null));
		Assert.That(() => !a!.Equals(0));

		// byte[]
		Assert.That(a!.Equals(bytes));
		Assert.That(!a.Equals(bad));

		// IReadOnlyList
		List<byte> l = new(bytes);
		Assert.That(a.Equals(l));

		// ReadOnlySpan
		//ReadOnlySpan<byte> r = new(bytes);
		//Assert.That(a.Equals(r));
		//var rs = r.Slice(4, 4);
		//Assert.That(!a.Equals(rs));
	}

	[Test]
	public void CompareToTest()
	{
		using SafeAllocatedMemoryHandle a = new SafeCoTaskMemHandle(bytes);
		using SafeAllocatedMemoryHandle b = new SafeNativeArray<byte>(bytes);
		using SafeAllocatedMemoryHandle c = new SafeNativeArray<byte>(bad);

		Assert.That(a.CompareTo(bytes), Is.Zero);
		Assert.That(a.CompareTo(bad), Is.GreaterThan(0));

		Assert.That(a.CompareTo(b), Is.Zero);
		Assert.That(a.CompareTo(c), Is.GreaterThan(0));
		Assert.That(c.CompareTo(a), Is.LessThan(0));

		List<byte> l = new(bytes);
		List<byte> x = new(bad);
		Assert.That(a.CompareTo(l), Is.Zero);
		Assert.That(a.CompareTo(x), Is.GreaterThan(0));
	}
}