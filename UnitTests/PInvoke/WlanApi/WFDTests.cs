using NUnit.Framework;
using System;
using System.Linq;
using System.Net.NetworkInformation;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.WlanApi;

namespace WlanApi;

public class WFDTests
{
	private DOT11_MAC_ADDRESS? mac;

	private DOT11_MAC_ADDRESS MacAddr
	{
		get
		{
			if (!mac.HasValue)
				mac = new DOT11_MAC_ADDRESS { ucDot11MacAddress = new byte[] { 0x7E, 0xD2, 0x94, 0x36, 0x25, 0xC2 } }; // GetDefaultMacAddress()?.GetAddressBytes() };
			return mac.Value;
		}
	}

	[Test]
	public void WFDOpenCloseHandleTest()
	{
		Assert.That(WFDOpenHandle(WFD_API_VERSION, out _, out var hSvc), ResultIs.Successful);
		Assert.That(() => hSvc.Dispose(), Throws.Nothing);
	}

	[Test]
	public void WFDOpenLegacySessionTest()
	{
		Assert.That(WFDOpenHandle(WFD_API_VERSION, out _, out var hSvc), ResultIs.Successful);
		using (hSvc)
		{
			Assert.That(WFDOpenLegacySession(hSvc, MacAddr, out var hSess, out var intf), ResultIs.Successful);
			Assert.That(() => hSess.Dispose(), Throws.Nothing);
			TestContext.Write(intf);
		}
	}

	[Test]
	public void WFDStartOpenSessionTest()
	{
		Assert.That(WFDOpenHandle(WFD_API_VERSION, out _, out var hSvc), ResultIs.Successful);
		using (hSvc)
		{
			Assert.That(WFDStartOpenSession(hSvc, MacAddr, default, Callback, out var hSess), ResultIs.Successful);
			Assert.That(() => hSess.Dispose(), Throws.Nothing);
		}

		void Callback(HWFDSESSION hSessionHandle, IntPtr pvContext, Guid guidSessionInterface, uint dwError, uint dwReasonCode) =>
			TestContext.WriteLine($"{guidSessionInterface} = Err:{dwError:X}, Rsn:{dwReasonCode}");
	}

	[Test]
	public void WFDUpdateDeviceVisibilityTest()
	{
		Assert.That(WFDUpdateDeviceVisibility(MacAddr), ResultIs.Successful);
	}

	private PhysicalAddress GetDefaultMacAddress() =>
		NetworkInterface.GetAllNetworkInterfaces().Where(ni => ni.OperationalStatus == OperationalStatus.Up).
		OrderBy(ni => { var st = ni.GetIPStatistics(); return st.BytesReceived + st.BytesSent; }).Select(ni => ni.GetPhysicalAddress()).FirstOrDefault();
}