using NUnit.Framework;
using Vanara.Extensions.Reflection;
using static Vanara.PInvoke.TaskSchd;

namespace Vanara.PInvoke.Tests;

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
	}

	[Test]
	public void TriggerTest()
	{
		var its = new ITaskService();
		its.Connect();
		Assert.That(its.Connected);
		var itd = its.NewTask(0U);
		var igt = itd.Triggers.Create(TASK_TRIGGER_TYPE2.TASK_TRIGGER_WEEKLY);
		Assert.That(itd.Triggers.Count, Is.EqualTo(1));
		var itt = (IWeeklyTrigger)igt;
		itt.Id = "Test";
		itt.StartBoundary = DateTime.Today;
		itt.WeeksInterval = 3;
		itt.RandomDelay = TimeSpan.FromMinutes(5);
		Assert.That(igt.Id, Is.EqualTo("Test"));
		Assert.That(itt.WeeksInterval, Is.EqualTo((short)3));
		Assert.That(((IWeeklyTrigger)igt).WeeksInterval, Is.EqualTo((short)3));
		Assert.That(GetProp<short, IWeeklyTrigger>(igt, "WeeksInterval"), Is.EqualTo((short)3));

		static T? GetProp<T, TC>(object obj, string pName) => ((TC)obj).GetPropertyValue(pName, default(T));
	}

	[Test]
	public void GetTimesTest()
	{
		ITaskService its = new();
		its.Connect();
		Assert.That(its.Connected);

		var itd = its.NewTask(0U);
		var itt = (IWeeklyTrigger)itd.Triggers.Create(TASK_TRIGGER_TYPE2.TASK_TRIGGER_WEEKLY);
		itt.StartBoundary = DateTime.Today;
		itt.WeeksInterval = 3;
		itt.DaysOfWeek = MSTask.TaskDaysOfTheWeek.TASK_MONDAY;
		var iea = (IExecAction)itd.Actions.Create(TASK_ACTION_TYPE.TASK_ACTION_EXEC);
		iea.Path = "notepad.exe";

		var irf = its.GetFolder("\\");
		var irt = irf.RegisterTaskDefinition("Test", itd, TASK_CREATION.TASK_CREATE_OR_UPDATE, logonType: TASK_LOGON_TYPE.TASK_LOGON_S4U);
		var dt = DateTime.Now;
		try
		{
			var times = irt.GetRunTimes(new SYSTEMTIME(dt), null, 10);
			Assert.That(times, Is.Not.Empty);
			Array.ConvertAll(times, t => t.ToDateTime(dt.Kind)).WriteValues();
		}
		finally
		{
			irf.DeleteTask("Test");
		}
	}
}