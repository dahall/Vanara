using NUnit.Framework;

namespace Vanara.Extensions.Tests;

[TestFixture]
public class LinqExtensionsTests
{
	[Test]
	public void CompTest()
	{
		Assert.That("Test1".SequenceCompare("Test1"), Is.EqualTo(0));
		Assert.That("Test1".SequenceCompare("Test2"), Is.LessThan(0));
		Assert.That("Test2".SequenceCompare("Test1"), Is.GreaterThan(0));
		Assert.That("Test1".SequenceCompare("Test11"), Is.LessThan(0));
		Assert.That("Test11".SequenceCompare("Test1"), Is.GreaterThan(0));
	}
}