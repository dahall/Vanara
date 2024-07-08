using NUnit.Framework;
using System.Linq;
using System.Threading;
using static Vanara.PInvoke.PowrProf;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PowrProfTests
{
	[Test]
	public void EnumPwrSchemesTest()
	{
		Assert.That(EnumPwrSchemes(p), Is.True);

		static bool p(uint uiIndex, uint dwName, string sName, uint dwDesc, string sDesc, in POWER_POLICY pp, IntPtr lParam)
		{
			TestContext.WriteLine($"Idx:{uiIndex}; Name:{sName}; Desc:{sDesc}");
			return true;
		}
	}

	[Test]
	public void PowerEnumerateTest()
	{
		foreach (var scheme in PowerEnumerate<Guid>(null, null))
		{
			PowerGetActiveScheme(out var active);
			TestContext.WriteLine($"Scheme: {scheme} {(scheme == active ? "(Active)" : "")}");
			foreach (var subgroup in PowerEnumerate<Guid>(scheme, null).Concat(new[] { NO_SUBGROUP_GUID }))
			{
				TestContext.Write("  ");
				WriteName(scheme, subgroup, null);
				foreach (var value in PowerEnumerate<Guid>(scheme, subgroup))
				{
					TestContext.Write("    ");
					WriteName(scheme, subgroup, value);
				}
			}
		}

		static void WriteName(Guid? sch, Guid? grp, Guid? setting) => TestContext.WriteLine($"{PowerReadFriendlyName(sch, grp, setting)} : {PowerReadDescription(sch, grp, setting)} : {setting}");
	}

	[Test]
	public void PowerReadSettingAttributesTest()
	{
		var attr = PowerReadSettingAttributes(default, default);
		TestContext.WriteLine($"DefGuid={attr}");
		attr = PowerReadSettingAttributes(GUID_SYSTEM_BUTTON_SUBGROUP, default);
		TestContext.WriteLine($"GUID_SYSTEM_BUTTON_SUBGROUP={attr}");
	}

	[Test]
	public void PowerSettingRegisterNotificationTest()
	{
		uint timeOut = 0;
		AutoResetEvent evt = new(false);
		Assert.That(PowerSettingRegisterNotification(GUID_VIDEO_POWERDOWN_TIMEOUT, DEVICE_PWR_NOTIFY.DEVICE_NOTIFY_CALLBACK, new DEVICE_NOTIFY_SUBSCRIBE_PARAMETERS { Callback = PowerSettingFunc }, out var powerNotification), ResultIs.Successful);
		evt.WaitOne(1000);
		Assert.That(PowerSettingUnregisterNotification(powerNotification), ResultIs.Successful);
		Assert.That(timeOut, Is.Not.Zero);
		TestContext.Write($"timeout={timeOut}");

		Win32Error PowerSettingFunc(IntPtr Context, uint Type, IntPtr Setting)
		{
			if (Type == (uint)User32.PowerBroadcastType.PBT_POWERSETTINGCHANGE && Setting != IntPtr.Zero)
			{
				var pbSetting = Setting.ToStructure<User32.POWERBROADCAST_SETTING>();
				if (pbSetting.DataLength == Marshal.SizeOf(typeof(uint)))
					timeOut = BitConverter.ToUInt32(pbSetting.Data, 0);
			}
			evt.Set();
			return Win32Error.ERROR_SUCCESS;
		}
	}
}