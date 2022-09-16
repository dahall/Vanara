using Microsoft.CodeAnalysis;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
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
}