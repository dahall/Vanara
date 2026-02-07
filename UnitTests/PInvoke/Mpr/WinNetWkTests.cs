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
		uint sz = 0;
		Assert.That(WNetGetConnection(ldev, null, ref sz), Is.EqualTo(Win32Error.ERROR_MORE_DATA));

		var sb = new StringBuilder((int)sz);
		WNetGetConnection(ldev, sb, ref sz).ThrowIfFailed();
		Assert.That(sb.ToString(), Contains.Substring(@"\\"));
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
		uint sz = 0;
		var sb = new StringBuilder(1);
		Assert.That(WNetGetProviderName(WNNC_NET.WNNC_NET_SMB, sb, ref sz), Is.EqualTo(Win32Error.ERROR_MORE_DATA));

		sb = new StringBuilder((int)sz);
		WNetGetProviderName(WNNC_NET.WNNC_NET_SMB, sb, ref sz).ThrowIfFailed();
		Assert.That(sb.ToString(), Is.EqualTo(prov));
	}

	[Test]
	public void WNetGetResourceInformationTest()
	{
		uint sz = 1;
		var lnr = new NETRESOURCE(remSh + shDir);
		var ptr = new SafeCoTaskMemHandle((int)sz);
		Assert.That(WNetGetResourceInformation(lnr, (IntPtr)ptr, ref sz, out var _), Is.EqualTo(Win32Error.ERROR_MORE_DATA));

		ptr.Size = (int)sz;
		WNetGetResourceInformation(lnr, (IntPtr)ptr, ref sz, out var sys).ThrowIfFailed();
		var rnr = ptr.ToStructure<NETRESOURCE>()!;
		Assert.That((int)rnr.dwUsage, Is.Not.Zero);
		Assert.That(rnr.lpRemoteName, Is.EqualTo(remSh));
		Assert.That(sys, Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void WNetGetResourceParentTest()
	{
		uint sz = 1;
		var lnr = new NETRESOURCE(remSh + shDir, null, prov);
		var ptr = new SafeCoTaskMemHandle((int)sz);
		Assert.That(WNetGetResourceParent(lnr, (IntPtr)ptr, ref sz), Is.EqualTo(Win32Error.ERROR_MORE_DATA));

		ptr.Size = (int)sz;
		WNetGetResourceParent(lnr, (IntPtr)ptr, ref sz).ThrowIfFailed();
		var nrp = ptr.ToStructure<NETRESOURCE>()!;
		Assert.That((int)nrp.dwUsage, Is.Not.Zero);
		Assert.That(nrp.lpRemoteName, Is.EqualTo(remSh));
	}

	[Test]
	public void WNetGetUniversalNameTest()
	{
		uint sz = 1;
		var ptr = new SafeCoTaskMemHandle((int)sz);
		Assert.That(WNetGetUniversalName(ldev + shDir, INFO_LEVEL.REMOTE_NAME_INFO_LEVEL, (IntPtr)ptr, ref sz), Is.EqualTo(Win32Error.ERROR_MORE_DATA));

		ptr.Size = (int)sz;
		WNetGetUniversalName(ldev + shDir, INFO_LEVEL.REMOTE_NAME_INFO_LEVEL, (IntPtr)ptr, ref sz).ThrowIfFailed();
		var rni = ptr.ToStructure<REMOTE_NAME_INFO>();
		Assert.That(rni.lpUniversalName, Is.EqualTo(remSh + shDir));
		Assert.That(rni.lpRemainingPath, Is.EqualTo(shDir));

		sz = 1;
		Assert.That(WNetGetUniversalName(ldev + shDir, INFO_LEVEL.UNIVERSAL_NAME_INFO_LEVEL, (IntPtr)ptr, ref sz), Is.EqualTo(Win32Error.ERROR_MORE_DATA));

		ptr.Size = (int)sz;
		WNetGetUniversalName(ldev + shDir, INFO_LEVEL.UNIVERSAL_NAME_INFO_LEVEL, (IntPtr)ptr, ref sz).ThrowIfFailed();
		var uni = ptr.ToStructure<UNIVERSAL_NAME_INFO>();
		Assert.That(uni.lpUniversalName, Is.EqualTo(remSh + shDir));
	}

	[Test]
	public void WNetGetUserTest()
	{
		uint sz = 0;
		Assert.That(WNetGetUser(ldev, null, ref sz), Is.EqualTo(Win32Error.ERROR_MORE_DATA));

		var sb = new StringBuilder((int)sz);
		WNetGetUser(ldev, sb, ref sz).ThrowIfFailed();
		Assert.That(sb.ToString(), Contains.Substring(@"da"));
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
		var sz = 20U;
		var sb = new StringBuilder((int)sz);
		WNetUseConnection(HWND.NULL, new NETRESOURCE(remSh), null, null, CONNECT.CONNECT_REDIRECT, sb, ref sz, out var drv).ThrowIfFailed();
		Assert.That(sb.Length, Is.GreaterThan(0));
		TestContext.WriteLine($"{sb} {drv}");
		WNetCancelConnection2(sb.ToString(), 0, true);
	}
}
