using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.TaskSchd;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class TaskSchdTests
	{
		[Test]
		public void SettingsTest()
		{
			var ts = new ITaskService();
			var td = ts.NewTask(0);
			var settings = td.Settings;
			settings.ExecutionTimeLimit = TimeSpan.FromDays(1);
			Assert.That(settings.ExecutionTimeLimit.Value, Is.EqualTo(TimeSpan.FromDays(1)));
			settings.ExecutionTimeLimit = TimeSpan.Zero;
			Assert.That(settings.ExecutionTimeLimit.Value, Is.EqualTo(TimeSpan.Zero));
			settings.ExecutionTimeLimit = (TimeSpan?)null;
			Assert.That(settings.ExecutionTimeLimit.Value, Is.Null);
			var triggers = td.Triggers;
			var tr = triggers.Create(TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);
			tr.StartBoundary = DateTime.Today;
			Assert.That(tr.StartBoundary.Value, Is.EqualTo(DateTime.Today));
			Assert.That(tr.EndBoundary.Value, Is.Null);
			Marshal.ReleaseComObject(tr);
			Marshal.ReleaseComObject(triggers);
			Marshal.ReleaseComObject(settings);
			Marshal.ReleaseComObject(td);
			Marshal.ReleaseComObject(ts);
		}
	}
}