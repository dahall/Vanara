using NUnit.Framework;
using Vanara.PInvoke;

namespace Vanara.Windows.Shell.Tests;

[TestFixture]
public class BindContextTests
{
	[Test]
	public void BindContextTest()
	{
		var bc = new BindContext();
		Assert.That((int)bc.BindFlags, Is.Zero);
		Assert.That(bc.Deadline, Is.EqualTo(TimeSpan.Zero));
		Assert.That(() => bc.Dispose(), Throws.Nothing);
	}

	[Test]
	public void BindContext2Test()
	{
		var bc = new BindContext(timeout: TimeSpan.FromSeconds(30), bindFlags: Ole32.BIND_FLAGS.BIND_MAYBOTHERUSER);
		Assert.That(bc.BindFlags, Is.EqualTo(Ole32.BIND_FLAGS.BIND_MAYBOTHERUSER));
		Assert.That(bc.Deadline, Is.EqualTo(TimeSpan.FromSeconds(30)));
		Assert.That(() => bc.Dispose(), Throws.Nothing);
	}

	[Test]
	public void EnumObjectParamTest()
	{
		using var bc = new BindContext();
		Assert.That(() => bc.EnumObjectParam(), Throws.Nothing);
	}
}