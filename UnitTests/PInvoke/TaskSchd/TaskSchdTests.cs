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
			var t = ts.NewTask(0);
			var settings = t.Settings;
			//settings.DeleteExpiredTaskAfter = TimeSpan.FromDays(1);
			//Assert.That(settings.DeleteExpiredTaskAfter, Is.EqualTo(TimeSpan.FromDays(1)));
			//settings.DeleteExpiredTaskAfter = TimeSpan.Zero;
			//Assert.That(settings.DeleteExpiredTaskAfter, Is.Null);
			Marshal.ReleaseComObject(settings);
			Marshal.ReleaseComObject(t);
			Marshal.ReleaseComObject(ts);
		}
	}
}