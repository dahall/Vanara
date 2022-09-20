using System.Collections.Generic;

namespace Vanara.PInvoke.Tests;

internal partial class BackgroundCopyTests
{
	[Test]
	public void JobCollTest()
	{
		BackgroundCopyJob newJob = null;
		var guid = Guid.Empty;
		Assert.That(() => { guid = (newJob = BackgroundCopyManager.Jobs.Add(GetCurrentMethodName())).ID; }, Throws.Nothing);
		try
		{
			Assert.That(BackgroundCopyManager.Jobs.Count, Is.GreaterThanOrEqualTo(1));
			Assert.That(BackgroundCopyManager.Jobs.Contains(guid), Is.True);

			BackgroundCopyJob job = null;
			Assert.That(() => job = BackgroundCopyManager.Jobs[guid], Throws.Nothing);
			Assert.That(job, Is.Not.Null);

			var array = new BackgroundCopyJob[BackgroundCopyManager.Jobs.Count];
			Assert.That(() => ((ICollection<BackgroundCopyJob>)BackgroundCopyManager.Jobs).CopyTo(array, 0), Throws.Nothing);
			Assert.That(array[0], Is.Not.Null);
			TestContext.WriteLine(string.Join("\n", array.Select(j => $"'{j.DisplayName}' ({j.Files.Count}:{j.State})")));
		}
		finally
		{
			Assert.That(() => BackgroundCopyManager.Jobs.Remove(newJob), Throws.Nothing);
		}
		Assert.That(BackgroundCopyManager.Jobs.Contains(guid), Is.False);
	}
}