using NUnit.Framework;
using System;
using System.Collections.Generic;
using static Vanara.PInvoke.User32;

namespace Vanara.PInvoke.Tests
{
    [TestFixture()]
    public partial class User32Tests
    {
        [Test]
        public void EnumDisplayMonitorsTest()
        {
            var hdc = new HDC();
            var monitors = new List<IntPtr>();
            bool result = EnumDisplayMonitors(hdc, null, (monitor, _, _, _) =>
            {
                monitors.Add(monitor);
                return true;
            }, IntPtr.Zero);
            
            Assert.IsTrue(result, "Error calling EnumDisplayMonitors()");
            Assert.IsNotEmpty(monitors, "Calling EnumDisplayMonitors() returns empty list");

            TestContext.WriteLine($"EnumDisplayMonitors() returned {monitors.Count} monitor(s)");

            var primaryDisplayHandle = IntPtr.Zero;
            foreach (var monitor in monitors)
            {
                var info = MONITORINFOEX.Default;
                bool getInfoResult = GetMonitorInfo(monitor, ref info);
                Assert.IsTrue(getInfoResult, $"Error calling GetMonitorInfo(h: {monitor}) returned: {getInfoResult}");

                Assert.IsFalse(info.rcMonitor.IsEmpty, $"Bounds of monitor(handle: {monitor}) are empty!");
                
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
}