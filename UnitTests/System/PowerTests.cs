using System;
using Vanara.Diagnostics;
using NUnit.Framework;
using System.Text;
using System.Linq;
using static Vanara.PInvoke.PowrProf;

namespace Vanara.Diagnostics.Tests
{
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
			PowerManager.PoweredDevices.TryGetValue(@"STORAGE\Volume", out var d1);
			PowerManager.PoweredDevices.TryGetValue(@"ROOT\VOLMGR", out var d2);

			PowerManager.PoweredDevices.UseHardwareId = true;
			var fullNameList = PowerManager.PoweredDevices.Keys;

			PowerManager.PoweredDevices.UseHardwareId = false;
			PowerManager.PoweredDevices.OnlyPresentDevices = true;
			var presIdList = PowerManager.PoweredDevices;

			Assert.That(presIdList.Count, Is.LessThanOrEqualTo(fullNameList.Count));

			TestContext.WriteLine($"Full count: {fullNameList.Count}");
			foreach (var i in fullNameList.Take(10))
				TestContext.WriteLine(i);
			TestContext.WriteLine();
			TestContext.WriteLine($"Present count: {presIdList.Count}");
			foreach (var i in presIdList.Take(10))
				TestContext.WriteLine(i);
		}

		[Test]
		public void GetSettingTest()
		{
			var setting = PowerScheme.Active.Groups[GUID_SLEEP_SUBGROUP].Settings[GUID_STANDBY_TIMEOUT];
		}
	}
}
