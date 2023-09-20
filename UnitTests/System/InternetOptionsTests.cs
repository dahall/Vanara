using NUnit.Framework;

namespace Vanara.Network.Tests;

[TestFixture]
public class InternetOptionsTests
{
	[Test]
	public void AutomaticallyDetectSettingsTest()
	{
		using var inet = new InternetProxyOptions();

		var autoDetEnabled = inet.AutomaticallyDetectSettings;
		inet.AutomaticallyDetectSettings = !autoDetEnabled;
		Assert.That(inet.AutomaticallyDetectSettings, Is.EqualTo(!autoDetEnabled));
		inet.AutomaticallyDetectSettings = autoDetEnabled;
		Assert.That(inet.AutomaticallyDetectSettings, Is.EqualTo(autoDetEnabled));
	}

	[Test]
	public void SetupScriptUrlTest()
	{
		using var inet = new InternetProxyOptions();

		const string mySS = "setupscript.cmd";
		var setupScript = inet.SetupScriptUrl;
		inet.SetupScriptUrl = setupScript is null ? mySS : null;
		if (setupScript is null)
			Assert.That(inet.SetupScriptUrl, Is.Not.Null);
		else
			Assert.That(inet.SetupScriptUrl, Is.Null);
		inet.SetupScriptUrl = setupScript;
		if (setupScript is null)
			Assert.That(inet.SetupScriptUrl, Is.Null);
		else
			Assert.That(inet.SetupScriptUrl, Is.Not.Null);
	}

	[Test]
	public void ManualProxyUrlTest()
	{
		using var inet = new InternetProxyOptions();

		const string myProxy = "http://privateproxy.com";
		var proxy = inet.SetupScriptUrl;
		inet.ManualProxyUrl = proxy is null ? myProxy : null;
		if (proxy is null)
			Assert.That(inet.ManualProxyUrl, Is.Not.Null);
		else
			Assert.That(inet.ManualProxyUrl, Is.Null);
		inet.ManualProxyUrl = proxy;
		if (proxy is null)
			Assert.That(inet.ManualProxyUrl, Is.Null);
		else
			Assert.That(inet.ManualProxyUrl, Is.Not.Null);
	}

	[Test]
	public void ProxyBypassEntriesTest()
	{
		using var inet = new InternetProxyOptions();

		var byp = inet.ProxyBypassEntries ?? new string[0];
		var newList = new string[byp.Length + 2];
		Array.Copy(byp, newList, byp.Length);
		newList[newList.Length - 1] = "att.com";
		newList[newList.Length - 2] = "bp.com";
		inet.ProxyBypassEntries = newList;
		Assert.That(inet.ProxyBypassEntries, Is.Not.Null.And.Property("Length").EqualTo(newList.Length));
		inet.ProxyBypassEntries = byp.Length == 0 ? null : byp;
	}
}
