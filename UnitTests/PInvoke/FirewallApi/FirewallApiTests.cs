using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.FirewallApi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class FirewallApiTests
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
	public void INetFwMgrTest()
	{
		using var pMgr = ComReleaserFactory.Create(new INetFwMgr());
		pMgr.Item.CurrentProfileType.WriteValues();
		pMgr.Item.IsPortAllowed(null, NET_FW_IP_VERSION.NET_FW_IP_VERSION_ANY, 80, null, NET_FW_IP_PROTOCOL.NET_FW_IP_PROTOCOL_TCP, out var allowed, out var restricted);
		TestContext.WriteLine($"Port 80: allowed={allowed}, restricted={restricted}");
		pMgr.Item.IsIcmpTypeAllowed(NET_FW_IP_VERSION.NET_FW_IP_VERSION_V4, null, 0, out allowed, out restricted);
		TestContext.WriteLine($"ECHO: allowed={allowed}, restricted={restricted}");
	}

	[Test]
	public void GetProfileByTypeTest()
	{
		using var pMgr = ComReleaserFactory.Create(new INetFwMgr());
		Assert.IsNotNull(pMgr.Item);
		using var pPol = ComReleaserFactory.Create(pMgr.Item.LocalPolicy);
		Assert.IsNotNull(pPol.Item);
		using var pProf = ComReleaserFactory.Create(pPol.Item.GetProfileByType(NET_FW_PROFILE_TYPE.NET_FW_PROFILE_DOMAIN));
		Assert.IsNotNull(pProf.Item);

		TestContext.WriteLine($"Type={pProf.Item.Type}, FwEnable={pProf.Item.FirewallEnabled}, NoExc={pProf.Item.ExceptionsNotAllowed}, NoNtf={pProf.Item.NotificationsDisabled}, NoUnc={pProf.Item.UnicastResponsesToMulticastBroadcastDisabled}");
	}

	[Test]
	public void RemoteAdminSettingsTest()
	{
		using var pMgr = ComReleaserFactory.Create(new INetFwMgr());
		Assert.IsNotNull(pMgr.Item);
		using var pPol = ComReleaserFactory.Create(pMgr.Item.LocalPolicy);
		Assert.IsNotNull(pPol.Item);
		using var pProf = ComReleaserFactory.Create(pPol.Item.CurrentProfile);
		Assert.IsNotNull(pProf.Item);
		using var pSet = ComReleaserFactory.Create(pProf.Item.RemoteAdminSettings);
		Assert.IsNotNull(pSet.Item);

		TestContext.WriteLine($"Ver={pSet.Item.IpVersion}, Scope={pSet.Item.Scope}, Addr={pSet.Item.RemoteAddresses}, Enabled={pSet.Item.Enabled}");
	}

	[Test]
	public void IcmpSettingsTest()
	{
		using var pMgr = ComReleaserFactory.Create(new INetFwMgr());
		Assert.IsNotNull(pMgr.Item);
		using var pPol = ComReleaserFactory.Create(pMgr.Item.LocalPolicy);
		Assert.IsNotNull(pPol.Item);
		using var pProf = ComReleaserFactory.Create(pPol.Item.CurrentProfile);
		Assert.IsNotNull(pProf.Item);
		using var pSet = ComReleaserFactory.Create(pProf.Item.IcmpSettings);
		Assert.IsNotNull(pSet.Item);

		TestContext.WriteLine($"ObDest={pSet.Item.AllowOutboundDestinationUnreachable}, Redircope={pSet.Item.AllowRedirect}, InEcho={pSet.Item.AllowInboundEchoRequest}, ObTimeout={pSet.Item.AllowOutboundTimeExceeded}");
		TestContext.WriteLine($"ObParam={pSet.Item.AllowOutboundParameterProblem}, ObSrcQuench={pSet.Item.AllowOutboundSourceQuench}, InRtReq={pSet.Item.AllowInboundRouterRequest}, InTimeReq={pSet.Item.AllowInboundTimestampRequest}");
		TestContext.WriteLine($"InMaskReq={pSet.Item.AllowInboundMaskRequest}, ObBigPkt={pSet.Item.AllowOutboundPacketTooBig}");
	}

	[Test]
	public void GloballyOpenPortsTest()
	{
		using var pMgr = ComReleaserFactory.Create(new INetFwMgr());
		Assert.IsNotNull(pMgr.Item);
		using var pPol = ComReleaserFactory.Create(pMgr.Item.LocalPolicy);
		Assert.IsNotNull(pPol.Item);
		using var pProf = ComReleaserFactory.Create(pPol.Item.CurrentProfile);
		Assert.IsNotNull(pProf.Item);
		using var pSet = ComReleaserFactory.Create(pProf.Item.GloballyOpenPorts);
		Assert.IsNotNull(pSet.Item);

		var i = 0;
		foreach (var pPort in pSet.Item.Cast<INetFwOpenPort>().Select(p => ComReleaserFactory.Create(p)))
		{
			using (pPort)
			{
				TestContext.WriteLine($"{i}) Name={pPort.Item.Name}, Ver={pPort.Item.IpVersion}, Prot={pPort.Item.Protocol}, Port={pPort.Item.Port}");
				TestContext.WriteLine($"     Scope={pPort.Item.Scope}, RmAdd={pPort.Item.RemoteAddresses}, Enab={pPort.Item.Enabled}, BuiltIn={pPort.Item.BuiltIn}");
			}
			i += 1;
		}
		Assert.That(i, Is.EqualTo(pSet.Item.Count));

		using var pNewPort = ComReleaserFactory.Create(new INetFwOpenPort());
		pNewPort.Item.Name = "HTTP";
		pNewPort.Item.Port = 80;
		pNewPort.Item.Protocol = NET_FW_IP_PROTOCOL.NET_FW_IP_PROTOCOL_TCP;
		pSet.Item.Add(pNewPort.Item);
		Assert.That(i + 1, Is.EqualTo(pSet.Item.Count));
		using var pAddedPort = ComReleaserFactory.Create(pSet.Item.Item(pNewPort.Item.Port, pNewPort.Item.Protocol));
		Assert.IsNotNull(pAddedPort.Item);
		pSet.Item.Remove(pNewPort.Item.Port, pNewPort.Item.Protocol);
		Assert.That(i, Is.EqualTo(pSet.Item.Count));
	}

	[Test]
	public void ServicesTest()
	{
		using var pMgr = ComReleaserFactory.Create(new INetFwMgr());
		Assert.IsNotNull(pMgr.Item);
		using var pPol = ComReleaserFactory.Create(pMgr.Item.LocalPolicy);
		Assert.IsNotNull(pPol.Item);
		using var pProf = ComReleaserFactory.Create(pPol.Item.CurrentProfile);
		Assert.IsNotNull(pProf.Item);
		using var pSet = ComReleaserFactory.Create(pProf.Item.Services);
		Assert.IsNotNull(pSet.Item);

		var i = 0;
		foreach (var pSvc in pSet.Item.Cast<INetFwService>().Select(p => ComReleaserFactory.Create(p)))
		{
			using (pSvc)
			{
				TestContext.WriteLine($"{i}) Name={pSvc.Item.Name}, Type={pSvc.Item.Type}, Cust={pSvc.Item.Customized}, IpVer={pSvc.Item.IpVersion}");
				TestContext.WriteLine($"     Scope={pSvc.Item.Scope}, RmAdd={pSvc.Item.RemoteAddresses}, Enab={pSvc.Item.Enabled}");
			}
			i += 1;
		}
		Assert.That(i, Is.EqualTo(pSet.Item.Count));
	}

	[Test]
	public void AuthorizedApplicationsTest()
	{
		using var pMgr = ComReleaserFactory.Create(new INetFwMgr());
		Assert.IsNotNull(pMgr.Item);
		using var pPol = ComReleaserFactory.Create(pMgr.Item.LocalPolicy);
		Assert.IsNotNull(pPol.Item);
		using var pProf = ComReleaserFactory.Create(pPol.Item.CurrentProfile);
		Assert.IsNotNull(pProf.Item);
		using var pSet = ComReleaserFactory.Create(pProf.Item.AuthorizedApplications);
		Assert.IsNotNull(pSet.Item);

		var i = 0;
		foreach (var pApp in pSet.Item.Cast<INetFwAuthorizedApplication>().Select(p => ComReleaserFactory.Create(p)))
		{
			using (pApp)
			{
				TestContext.WriteLine($"{i}) Name={pApp.Item.Name}, FN={pApp.Item.ProcessImageFileName}, IpVer={pApp.Item.IpVersion}");
				TestContext.WriteLine($"     Scope={pApp.Item.Scope}, RmAdd={pApp.Item.RemoteAddresses}, Enab={pApp.Item.Enabled}");
			}
			i += 1;
		}
		Assert.That(i, Is.EqualTo(pSet.Item.Count));

		using var pNewApp = ComReleaserFactory.Create(new INetFwAuthorizedApplication());
		pNewApp.Item.Name = "Notepad";
		pNewApp.Item.ProcessImageFileName = @"C:\Windows\notepad.exe";
		pNewApp.Item.Enabled = true;
		pSet.Item.Add(pNewApp.Item);
		Assert.That(i + 1, Is.EqualTo(pSet.Item.Count));
		pSet.Item.Remove(pNewApp.Item.ProcessImageFileName);
		Assert.That(i, Is.EqualTo(pSet.Item.Count));
	}

	[Test]
	public void INetFwProductsTest()
	{
		using var pProds = ComReleaserFactory.Create(new INetFwProducts());
		Assert.IsNotNull(pProds.Item);

		var i = 0;
		foreach (var pProd in pProds.Item.Cast<INetFwProduct>().Select(p => ComReleaserFactory.Create(p)))
		{
			using (pProd)
			{
				TestContext.WriteLine($"{i}) Name={pProd.Item.DisplayName}, Exe={pProd.Item.PathToSignedProductExe}");
				TestContext.WriteLine($"   Cats={string.Join("; ", (string[])pProd.Item.RuleCategories)}");
			}
			i += 1;
		}
		Assert.That(i, Is.EqualTo(pProds.Item.Count));
	}

	[Test]
	public void INetFwPolicy2Test()
	{
		using var pPol = ComReleaserFactory.Create(new INetFwPolicy2());
		Assert.IsNotNull(pPol.Item);

		TestContext.WriteLine($"Types={pPol.Item.CurrentProfileTypes}; ModState={pPol.Item.LocalPolicyModifyState}");
		var prof = pPol.Item.CurrentProfileTypes.GetFlags().First();
		var exInt = pPol.Item.ExcludedInterfaces[prof];
		TestContext.WriteLine($"Enab={pPol.Item.FirewallEnabled[prof]}, ExInt={exInt}, BlkInb={pPol.Item.BlockAllInboundTraffic[prof]}, NoNotf={pPol.Item.NotificationsDisabled[prof]}");
		TestContext.WriteLine($"NoUni={pPol.Item.UnicastResponsesToMulticastBroadcastDisabled[prof]}, DefInAct={pPol.Item.DefaultInboundAction[prof]}, DefOutAct={pPol.Item.DefaultOutboundAction[prof]}");

		using var pRules = ComReleaserFactory.Create(pPol.Item.Rules);
		Assert.IsNotNull(pRules.Item);

		var i = 0;
		var groups = new List<string>();
		foreach (var pRule in pRules.Item.Cast<INetFwRule>().Select(p => ComReleaserFactory.Create(p)))
		{
			using (pRule)
				groups.Add(pRule.Item.Grouping);
			i++;
		}
		Assert.That(i, Is.EqualTo(pRules.Item.Count));
		groups = groups.Distinct().ToList();

		using var pRstr = ComReleaserFactory.Create(pPol.Item.ServiceRestriction);
		Assert.IsNotNull(pRules.Item);

		if (groups.Count > 0 && pPol.Item.IsRuleGroupCurrentlyEnabled[groups[0]])
		{
			TestContext.WriteLine($"Group '{groups[0]}' is enabled={pPol.Item.IsRuleGroupEnabled(prof, groups[0])}");
		}
	}

	[Test]
	public void INetFwRuleTest()
	{
		using var pPol = ComReleaserFactory.Create(new INetFwPolicy2());
		Assert.IsNotNull(pPol.Item);
		using var pRules = ComReleaserFactory.Create(pPol.Item.Rules);
		Assert.IsNotNull(pRules.Item);
		foreach (var pRule in pRules.Item.Cast<INetFwRule>().Select(p => ComReleaserFactory.Create(p)))
		{
			using (pRule)
			{
				var r3 = (INetFwRule3)pRule.Item;
				var intf = r3.GetInterfaces();
				TestContext.WriteLine(new string('=', 30));
				TestContext.WriteLine($"{r3.Name}: {r3.Description}");
				TestContext.WriteLine($"  App={r3.ApplicationName}, Svc={r3.serviceName}, Prot={r3.Protocol}, LcPrt={r3.LocalPorts}, RmPrt={r3.RemotePorts}, LcAddr={r3.LocalAddresses}");
				TestContext.WriteLine($"  RmAddr={r3.RemoteAddresses}, Icmp={r3.IcmpTypesAndCodes}, Dir={r3.Direction}, Intf={string.Join(";", intf)}, IntfT={r3.InterfaceTypes}, Enab={r3.Enabled}");
				TestContext.WriteLine($"  Grp={r3.Grouping}, Prof={r3.Profiles}, EdgeTrv={r3.EdgeTraversal}");
				TestContext.WriteLine($"  Action={r3.Action}, EdgeTrvOp={r3.EdgeTraversalOptions}, LcPkg={r3.LocalAppPackageId}");
				TestContext.WriteLine($"  LcUsr={r3.LocalUserOwner}, LcUsrAuth={r3.LocalUserAuthorizedList}, RmUsrAuth={r3.RemoteUserAuthorizedList}, RmMachAuth={r3.RemoteMachineAuthorizedList}, Sec={r3.SecureFlags}");
			}
		}
	}
}