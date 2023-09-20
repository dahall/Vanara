using NUnit.Framework;
using Vanara.PInvoke.Tests;
using System.Linq;

namespace Vanara.Network.Tests;

[TestFixture]
public class FirewallTests
{
	[Test]
	public void TestRuleEnum()
	{
		foreach (var rule in WindowsFirewall.Rules)
			rule.WriteValues();
		TestContext.WriteLine("====================================");
		foreach (var rule in WindowsFirewall.ServiceHardeningRules)
			rule.WriteValues();
	}

	[Test]
	public void NetworkInterfaceTest()
	{
		var name = "VanaraTest" + Guid.NewGuid().ToString("N");
		FirewallRule rule = new(name, "MyGroup")
		{
			Interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Take(2).ToArray()
		};
		Assert.That(rule.InterfaceNames, Has.Length.LessThanOrEqualTo(2));
		rule.WriteValues();
	}

	[Test]
	public void AddRemoveAppRuleTest()
	{
		var name = "VanaraTest" + Guid.NewGuid().ToString("N");
		FirewallRule rule = new(name, "MyGroup") { ApplicationName = @"notepad.exe" };
		rule.WriteValues();
		if (TestHelper.IsElevated)
		{
			Assert.That(() => WindowsFirewall.Rules.Add(rule), Throws.Nothing);
			WindowsFirewall.Rules.Remove(name);
		}
	}

	[Test]
	public void ProfileTest()
	{
		WindowsFirewall.PublicProfile.WriteValues();
	}
}
