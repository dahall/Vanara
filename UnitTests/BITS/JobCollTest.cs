using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vanara.IO.Tests
{
	partial class BackgroundCopyTests
	{
		[Test]
		public void JobCollTest()
		{
			var guid = Guid.Empty;

			BackgroundCopyJob job = null;


			Assert.That(() => { var j = BackgroundCopyManager.Jobs.Add(GetCurrentMethodName()); guid = j.ID; }, Throws.Nothing);

			Assert.That(BackgroundCopyManager.Jobs.Count, Is.GreaterThanOrEqualTo(1));

			Assert.That(BackgroundCopyManager.Jobs.Contains(guid), Is.True);

			Assert.That(() => job = BackgroundCopyManager.Jobs[guid], Throws.Nothing);

			Assert.That(job, Is.Not.Null);

			Assert.That(BackgroundCopyManager.Jobs.Count(j => j.ID == guid), Is.EqualTo(1));


			var array = new BackgroundCopyJob[BackgroundCopyManager.Jobs.Count];

			Assert.That(() => ((ICollection<BackgroundCopyJob>)BackgroundCopyManager.Jobs).CopyTo(array, 0), Throws.Nothing);

			Assert.That(array[0], Is.Not.Null);

			Assert.That(() => BackgroundCopyManager.Jobs.Remove(job), Throws.Nothing);

			Assert.That(BackgroundCopyManager.Jobs.Contains(guid), Is.False);
		}
	}
}
