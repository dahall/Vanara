using NUnit.Framework;
using System.Linq;

namespace Vanara.PInvoke.Tests;

partial class BackgroundCopyTests
{
	[Test]
	public void EnumJobTest()
	{
		var cnt = 0;

		Assert.That(() => BackgroundCopyManager.Jobs.Count, Throws.Nothing);

		Assert.That(cnt = BackgroundCopyManager.Jobs.Count, Is.GreaterThanOrEqualTo(0));

		Assert.That(BackgroundCopyManager.Jobs.Count(), Is.EqualTo(cnt));
	}
}
