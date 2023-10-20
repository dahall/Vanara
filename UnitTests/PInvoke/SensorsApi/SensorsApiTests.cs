using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.SensorsApi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SensorsApiTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void Test()
	{
		var mgr = new ISensorManager();
		foreach (var s in mgr.GetSensorsByCategory(Sensors.SENSOR_CATEGORY_ALL).Enumerate())
		{
			Console.WriteLine($"{s.GetFriendlyName()}: {s.GetID()}");
			var vals = s.GetProperties(null);
			foreach (var pv in vals.Enumerate())
				Console.WriteLine($"  {pv.Item2}");
		}
	}
}
