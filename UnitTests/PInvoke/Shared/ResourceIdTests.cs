using NUnit.Framework;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class SafeResourceIdTests
{
	[TestCase("X")]
	[TestCase("When overridden in a derived class, gets a value indicating whether the handle value is invalid.")]
	public void SafeResourceIdTest(string s)
	{
		var r = new SafeResourceId(s);
		Assert.That(r.IsInvalid, Is.False);
		Assert.That(r.ToString(), Is.EqualTo(s));
		Assert.That((string)r, Is.EqualTo(s));
		Assert.That((int)r, Is.EqualTo(0));
		Assert.That(r.GetHashCode(), Is.Not.Zero);
	}

	[TestCase(1)]
	[TestCase(ushort.MaxValue)]
	public void SafeResourceIdTest1(int s)
	{
		var r = new SafeResourceId(s);
		Assert.That(r.IsInvalid, Is.False);
		Assert.That(r.ToString(), Does.StartWith("#"));
		Assert.That((string)r, Does.StartWith("#"));
		Assert.That((int)r, Is.EqualTo(s));
		Assert.That(((ResourceId)r).id, Is.EqualTo(s));
	}

	[Test]
	public void SafeResourceIdTest2()
	{
		var r = new SafeResourceId(ResourceType.RT_BITMAP);
		Assert.That(r.IsInvalid, Is.False);
		Assert.That(r.ToString(), Does.StartWith("#"));
		Assert.That((string)r, Does.StartWith("#"));
		Assert.That((int)r, Is.EqualTo(2));
		Assert.That(((ResourceId)r).id, Is.EqualTo(2));
	}

	[Test]
	public void SafeResourceIdTest3()
	{
		const string s = "Test";
		var sptr = new SafeCoTaskMemString(s);
		var r = new SafeResourceId((IntPtr)sptr);
		sptr.Dispose();
		Assert.That(r.IsInvalid, Is.False);
		Assert.That(r.ToString(), Is.EqualTo(s));
		Assert.That((string)r, Is.EqualTo(s));
		Assert.That((int)r, Is.EqualTo(0));

		const int i = 5;
		r = (IntPtr)i;
		Assert.That(r.Equals((IntPtr)i));
		Assert.That(r.IsInvalid, Is.False);
		Assert.That(r.ToString(), Does.StartWith("#"));
		Assert.That((string)r, Does.StartWith("#"));
		Assert.That((int)r, Is.EqualTo(i));
		Assert.That(((ResourceId)r).id, Is.EqualTo(i));
	}

	[Test]
	public void SafeResourceIdTest4()
	{
		Assert.That(() => new SafeResourceId(null), Throws.TypeOf<ArgumentNullException>());
		Assert.That(() => new SafeResourceId(string.Empty), Throws.TypeOf<ArgumentNullException>());
		Assert.That(() => new SafeResourceId(0), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SafeResourceId(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SafeResourceId(int.MaxValue), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[Test()]
	public void EqualsTest()
	{
		Assert.That(((SafeResourceId)"Test").Equals((object)null), Is.False);
		Assert.That(((SafeResourceId)"Test").Equals("Test"));
		Assert.That(((SafeResourceId)"Test").Equals((object)"Test"));
		Assert.That(((SafeResourceId)20).Equals(20));
		Assert.That(((SafeResourceId)20).Equals((object)20));
		Assert.That(((SafeResourceId)20).Equals(0xFFFFFFFF), Is.False);
		Assert.That(((SafeResourceId)20).Equals(false), Is.False);
		Assert.That(((SafeResourceId)20).Equals(DateTime.Now), Is.False);
		Assert.That(((SafeResourceId)ResourceType.RT_BITMAP).Equals(ResourceType.RT_BITMAP));
		Assert.That(((SafeResourceId)ResourceType.RT_BITMAP).Equals(DateTime.Today), Is.False);
	}
}