using NUnit.Framework;
using static Vanara.PInvoke.Mpr;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WinNetWkTests
{
	const string ldev = "S:";
	const string prov = "Microsoft Windows Network";
	static readonly string remSh = TestCaseSources.GetValueOrDefault("RemoteShare", $"\\\\{Environment.MachineName}\\Users")!;
	const string shDir = @"\Music";

	[OneTimeSetUp]
	public void FixtureSetup()
	{
		FixtureTeardown();
		Assert.That(WNetAddConnection(remSh, null, ldev), ResultIs.Successful);
	}

	[OneTimeTearDown]
	public void FixtureTeardown()
	{
		WNetCancelConnection2(ldev, 0, true);
	}

	[Test]
	public void MultinetGetConnectionPerformanceTest()
	{
		var nci = NETCONNECTINFOSTRUCT.Empty;
		MultinetGetConnectionPerformance(new NETRESOURCE(remSh), ref nci).ThrowIfFailed();
		Assert.That((int)nci.dwFlags, Is.GreaterThan(0));
	}

	[Test]
	public void WNetAddConnection2Test()
	{
		var drv = "Q:";
		WNetAddConnection2(new NETRESOURCE(remSh, drv), null, null, CONNECT.CONNECT_INTERACTIVE).ThrowIfFailed();
		var dds = new DISCDLGSTRUCT { cbStructure = (uint)Marshal.SizeOf(typeof(DISCDLGSTRUCT)), lpLocalName = drv };
		WNetDisconnectDialog1(dds).ThrowIfFailed();
	}

	[Test]
	public void WNetAddConnection3Test()
	{
		var drv = "Q:";
		WNetAddConnection3(HWND.NULL, new NETRESOURCE(remSh, drv), null, null, CONNECT.CONNECT_INTERACTIVE).ThrowIfFailed();
		WNetCancelConnection2(drv, 0, true).ThrowIfFailed();
	}

	[Test]
	public void WNetEnumResourceTest()
	{
		var ne = WNetEnumResources(dwScope: NETRESOURCEScope.RESOURCE_REMEMBERED, recurseContainers: true);
		Assert.That(ne, Is.Not.Empty);
		foreach (var net in ne)
			TestContext.WriteLine($"Type:{net.dwDisplayType}; Prov:{net.lpProvider}; Loc:{net.lpLocalName}; Rem:{net.lpRemoteName}");

		TestContext.WriteLine();
		var nr = new NETRESOURCE(@"\\" + Environment.MachineName) { dwType = NETRESOURCEType.RESOURCETYPE_ANY, dwScope = NETRESOURCEScope.RESOURCE_GLOBALNET, dwUsage = NETRESOURCEUsage.RESOURCEUSAGE_CONTAINER };
		ne = WNetEnumResources(nr, dwType: NETRESOURCEType.RESOURCETYPE_DISK);
		Assert.That(ne, Is.Not.Empty);
		foreach (var net in ne)
			TestContext.WriteLine($"Type:{net.dwDisplayType}; Prov:{net.lpProvider}; Loc:{net.lpLocalName}; Rem:{net.lpRemoteName}");
	}

	[Test]
	public void WNetGetConnectionTest()
	{
		Assert.That(WNetGetConnection(ldev, out var sb), ResultIs.Successful);
		Assert.That(sb, Contains.Substring(@"\\"));
	}

	[Test]
	public void WNetGetNetworkInformationTest()
	{
		var nis = NETINFOSTRUCT.Empty;
		WNetGetNetworkInformation(prov, ref nis).ThrowIfFailed();
		Assert.That(nis.dwDrives, Is.GreaterThan(0));
		TestContext.WriteLine($"Ch={nis.dwCharacteristics};Dr={nis.dwDrives};Pr={nis.dwPrinters};Ver={nis.dwProviderVersion};St={nis.dwStatus};NT={nis.wNetType}");
	}

	[Test]
	public void WNetGetProviderNameTest()
	{
		Assert.That(WNetGetProviderName(WNNC_NET.WNNC_NET_SMB, out var sb), ResultIs.Successful);
		Assert.That(sb, Is.EqualTo(prov));
	}

	[Test]
	public void WNetGetResourceInformationTest()
	{
		var lnr = new NETRESOURCE(remSh + shDir);
		Assert.That(WNetGetResourceInformation(lnr, out var rnr, out var sys), ResultIs.Successful);
		Assert.That((int)rnr!.dwUsage, Is.Not.Zero);
		Assert.That(rnr.lpRemoteName, Is.EqualTo(remSh));
		Assert.That(sys, Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void WNetGetResourceParentTest()
	{
		var lnr = new NETRESOURCE(remSh + shDir, null, prov);
		Assert.That(WNetGetResourceParent(lnr, out var nrp), ResultIs.Successful);
		Assert.That((int)nrp!.dwUsage, Is.Not.Zero);
		Assert.That(nrp!.lpRemoteName, Is.EqualTo(remSh));
	}

	[Test]
	public void WNetGetUniversalNameTest()
	{
		Assert.That(WNetGetUniversalName<REMOTE_NAME_INFO>(ldev + shDir, out var rni), ResultIs.Successful);
		Assert.That(rni.lpUniversalName, Is.EqualTo(remSh + shDir));
		Assert.That(rni.lpRemainingPath, Is.EqualTo(shDir));

		Assert.That(WNetGetUniversalName<UNIVERSAL_NAME_INFO>(ldev + shDir, out var uni), ResultIs.Successful);
		Assert.That(uni.lpUniversalName, Is.EqualTo(remSh + shDir));
	}

	[Test]
	public void WNetGetUserTest()
	{
		Assert.That(WNetGetUser(ldev, out var sb), ResultIs.Successful);
		Assert.That(sb, Contains.Substring(@"da"));
	}

	[Test]
	public void WNetSetLastErrorTest()
	{
		const string serr = "I need so much more";
		Assert.That(() => WNetSetLastError(Win32Error.ERROR_MORE_DATA, serr, prov), Throws.Nothing);

		var sb = new StringBuilder(256);
		var sb2 = new StringBuilder(256);
		WNetGetLastError(out var err, sb, 256, sb2, 256).ThrowIfFailed();
		Assert.That(sb.ToString(), Is.EqualTo(serr));
	}

	[Test]
	public void WNetUseConnectionTest()
	{
		WNetUseConnection(HWND.NULL, new NETRESOURCE(remSh), null, null, CONNECT.CONNECT_REDIRECT, out var sb, out var drv).ThrowIfFailed();
		Assert.That(sb?.Length ?? 0, Is.GreaterThan(0));
		TestContext.WriteLine($"{sb} {drv}");
		WNetCancelConnection2(sb!, 0, true);
	}
}
