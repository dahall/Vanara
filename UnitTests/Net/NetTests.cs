using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Vanara.Net;
using static Vanara.PInvoke.Dhcp;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class NetTests
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
	public async Task TestDnsCreateService()
	{
		const string svcName = "initial._windns-example._udp.local";
		using var dnsClient = new DnsService(svcName, "example.com", 1);
		await dnsClient.RegisterAsync();
		TestContext.WriteLine("Created\r\n=================");
		dnsClient.WriteValues();
		try
		{
			Assert.That(dnsClient.IsRegistered, Is.True);
			using var dnsLookup = DnsService.ResolveAsync(svcName).Result;
			Assert.That(dnsLookup.InstanceName, Is.EqualTo(svcName));
			TestContext.WriteLine("Found\r\n=================");
			dnsLookup.WriteValues();
		}
		finally
		{
			await dnsClient.DeRegisterAsync();
		}
	}

	[Test]
	public void TestDhcpProps()
	{
		using var client = new DhcpClient();
		client.WriteValues();
		client.GetDhcpServers().WriteValues();
		client.GetOriginalSubnetMask().WriteValues();
	}

	[Test]
	public void TestDhcpListeners()
	{
		var client = new DhcpClient();
		try
		{
			client.ChangeEventIds = new[] { DHCP_OPTION_ID.OPTION_DEFAULT_TTL, DHCP_OPTION_ID.OPTION_LEASE_TIME, DHCP_OPTION_ID.OPTION_MESSAGE };
			Thread.Sleep(1000);
			client.ChangeEventIds = null;
			Thread.Sleep(1000);
		}
		finally
		{
			client.Dispose();
		}
	}

	[Test]
	public void TestDrt()
	{
		using Firewall fw = new();
		if (TestHelper.IsElevated)
			fw.AddApp(Process.GetCurrentProcess().ProcessName, Process.GetCurrentProcess().MainModule.FileName);
		try
		{
			using DistributedRoutingTable drt = new(null, new(null, 0));
			drt.StatusChange += (s, e) => e.WriteValues();
			const int msinc = 250;
			const float totms = 5000;
			for (int ms = 0; ms < totms; ms += msinc)
				Thread.Sleep(msinc);
		}
		finally
		{
			try { fw.RemoveApp(Process.GetCurrentProcess().MainModule.FileName); } catch { }
		}
	}

	private class Firewall : IDisposable
	{
		Dictionary<string, ComReleaser<INetFwAuthorizedApplication>> newApps = new();
		ComReleaser<INetFwMgr> pMgr;
		ComReleaser<INetFwPolicy> pPol;
		ComReleaser<INetFwProfile> pProf;
		ComReleaser<INetFwAuthorizedApplications> pSet;

		public Firewall()
		{
			pMgr = ComReleaserFactory.Create(new INetFwMgr());
			Assert.IsNotNull(pMgr.Item);
			pPol = ComReleaserFactory.Create(pMgr.Item.LocalPolicy);
			Assert.IsNotNull(pPol.Item);
			pProf = ComReleaserFactory.Create(pPol.Item.CurrentProfile);
			Assert.IsNotNull(pProf.Item);
			pSet = ComReleaserFactory.Create(pProf.Item.AuthorizedApplications);
			Assert.IsNotNull(pSet.Item);
		}

		public void AddApp(string name, string exePath)
		{
			var pNewApp = ComReleaserFactory.Create(new INetFwAuthorizedApplication());
			pNewApp.Item.Name = name;
			pNewApp.Item.ProcessImageFileName = exePath;
			pNewApp.Item.Enabled = true;
			pSet.Item.Add(pNewApp.Item);
			newApps.Add(exePath, pNewApp);
		}

		public void Dispose()
		{
			pSet.Dispose();
			pProf.Dispose();
			pPol.Dispose();
			pMgr.Dispose();
			foreach (var app in newApps.Values)
				app.Dispose();
		}

		public void RemoveApp(string exePath) => pSet.Item.Remove(exePath);
	}
}