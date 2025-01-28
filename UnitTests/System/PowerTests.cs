using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.PowrProf;

namespace Vanara.Diagnostics.Tests;

[TestFixture]
public class PowerTests
{
	[Test]
	public void EnumTest()
	{
		foreach (var scheme in PowerManager.Schemes.Values)
		{
			TestContext.WriteLine($"{scheme.Name} : {scheme.Description} : {scheme.ApiName}");
			foreach (var group in scheme.Groups.Values)
			{
				TestContext.WriteLine($"  {group.Name} : {group.Description} : {group.ApiName}");
				foreach (var setting in group.Settings.Values)
				{
					TestContext.WriteLine($"     {setting.Name} : {setting.ApiName} : AC:{setting.ACValueDefaultIndex}/{setting.ACValueIndex}/{setting.ACValue} : DC:{setting.DCValueDefaultIndex}/{setting.DCValueIndex}/{setting.DCValue}");
					if (setting.IsRange)
						TestContext.WriteLine($"      Range: {setting.Range}");
					else
					{
						var vals = setting.PossibleValues;
						foreach (var val in vals)
							TestContext.WriteLine($"      Value: {val}");
					}
				}
			}
		}
	}

	[Test]
	public void DeviceEnumTest()
	{
		PowerManager.PoweredDevices.TryGetValue(@"STORAGE\Volume", out _);
		PowerManager.PoweredDevices.TryGetValue(@"ROOT\VOLMGR", out _);

		PowerManager.PoweredDevices.UseHardwareId = true;
		var fullNameList = PowerManager.PoweredDevices.Keys;

		PowerManager.PoweredDevices.UseHardwareId = false;
		PowerManager.PoweredDevices.OnlyPresentDevices = true;
		var presIdList = PowerManager.PoweredDevices;

		Assert.That(presIdList.Count, Is.Not.EqualTo(fullNameList.Count));

		TestContext.WriteLine($"Full count: {fullNameList.Count}");
		foreach (var i in fullNameList.Take(10))
			TestContext.WriteLine(i);
		TestContext.WriteLine();
		TestContext.WriteLine($"Present count: {presIdList.Count}");
		foreach (var i in presIdList.Take(10))
			TestContext.WriteLine(i);
	}

	[Test]
	public void GetMgrPropTest()
	{
		foreach (var pi in typeof(PowerManager).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
		{
			var val = pi.GetValue(null);
			if (val is System.Collections.IEnumerable ie)
				val = string.Join(", ", ie.Cast<object>().Select(o => o.ToString()));
			TestContext.WriteLine($"{pi.Name} = {val}");
		}
	}

	[Test]
	public void EventTest()
	{
		//bool eventFired = false, eventFailed = false;
		//PowerManager.QueryStandby += (s, e) => { e.Cancel = true; eventFired = true; };
		//PowerManager.StandingBy += (s, e) => eventFired = true;
		//PowerManager.StandbyFailed += (s, e) => eventFailed = true;

		for (int i = 0; i < 50; i++)
			System.Threading.Thread.Sleep(100);

		//System.Diagnostics.Debug.WriteLine("Suspending...");
		//Assert.That(SystemShutdown.Suspend(), ResultIs.Successful);

		//for (int i = 0; i < 50; i++)
		//	System.Threading.Thread.Sleep(10);

		//Assert.That(eventFired);
		//TestContext.WriteLine($"Failed={eventFailed}");
	}

	[Test]
	public void EventGuidTest()
	{
		bool eventFired = false;
		PowerManager.PowerSchemePersonalityChanged += EventHandler;
		System.Threading.Thread.Sleep(1000);
		PowerManager.Schemes[GUID_MIN_POWER_SAVINGS].IsActive = true;
		for (int i = 0; i < 20; i++)
			System.Threading.Thread.Sleep(10);
		PowerManager.Schemes[GUID_TYPICAL_POWER_SAVINGS].IsActive = true;
		for (int i = 0; i < 20; i++)
			System.Threading.Thread.Sleep(10);
		PowerManager.PowerSchemePersonalityChanged -= EventHandler;
		Assert.That(eventFired);

		void EventHandler(object? sender, PowerEventArgs<Guid> e) => eventFired = true;
	}

	[Test]
	public void GetSettingTest() => _ = PowerScheme.Active.Groups[GUID_SLEEP_SUBGROUP].Settings[GUID_STANDBY_TIMEOUT];
}
