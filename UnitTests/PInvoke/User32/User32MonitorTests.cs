using NUnit.Framework;
using System.Collections.Generic;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public partial class User32Tests
{
	[Test]
	public void EnumDisplayMonitorsTest()
	{
		List<HMONITOR> monitors = [];
		Assert.That(EnumDisplayMonitors(HDC.NULL, null, (monitor, _, _, _) => { monitors.Add(monitor); return true; }), ResultIs.Successful);
		Assert.That(monitors, Is.Not.Empty, "Calling EnumDisplayMonitors() returns empty list");
		TestContext.WriteLine($"EnumDisplayMonitors() returned {monitors.Count} monitor(s)");

		HMONITOR primaryDisplayHandle = default;
		foreach (var monitor in monitors)
		{
			MONITORINFOEX info = new();
			Assert.That(GetMonitorInfo(monitor, ref info), ResultIs.Successful);
			Assert.That(!info.rcMonitor.IsEmpty, $"Bounds of monitor(handle: {monitor}) are empty!");

			var isPrimary = (info.dwFlags & MonitorInfoFlags.MONITORINFOF_PRIMARY) != 0;
			TestContext.WriteLine(
				$"handle: {monitor}, name: {info.szDevice}, flags: {info.dwFlags}, isPrimary: {isPrimary}," +
				$" bounds: {info.rcMonitor}, workarea: {info.rcWork}");

			if (isPrimary)
			{
				if (primaryDisplayHandle == IntPtr.Zero)
				{
					primaryDisplayHandle = monitor;
				}
				else
				{
					Assert.Fail(
						$"Error calling GetMonitorInfo(h: {monitor}) returned flag that this monitor is primary, " +
						$"but there is already another monitor (handle: {primaryDisplayHandle}) with flag primary.");
				}
			}
		}
	}
}